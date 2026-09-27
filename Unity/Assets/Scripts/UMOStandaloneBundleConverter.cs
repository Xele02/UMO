using System;
using System.IO;
using System.Text;

// UnityFS container conversion only; never changes the archive on disk or saves.
// Android shader replacement remains the responsibility of BundleShaderInfo.
public static class UMOStandaloneBundleConverter
{
    public static byte[] Convert(byte[] source, int targetPlatform, out int patchedFiles)
    {
        patchedFiles = 0;
        using(var input = new BinaryReader(new MemoryStream(source)))
        {
            if(ReadString(input) != "UnityFS")
                throw new InvalidDataException("Expected a UnityFS asset bundle.");
            uint format = ReadUInt32(input);
            if(format != 6)
                throw new InvalidDataException("Unsupported UnityFS version: " + format);
            string playerVersion = ReadString(input);
            string engineVersion = ReadString(input);
            long declaredSize = ReadInt64(input);
            if(declaredSize != source.LongLength)
                throw new InvalidDataException("UnityFS file length mismatch.");
            int infoCompressedSize = checked((int)ReadUInt32(input));
            int infoSize = checked((int)ReadUInt32(input));
            uint flags = ReadUInt32(input);
            long headerEnd = input.BaseStream.Position;
            if((flags & ~0xffU) != 0)
                throw new InvalidDataException("Unsupported UnityFS layout flags: " + flags);
            if((flags & 0x80) != 0)
                input.BaseStream.Position = source.LongLength - infoCompressedSize;
            byte[] info = Decode(ReadExact(input, infoCompressedSize), infoSize, (int)(flags & 63));
            input.BaseStream.Position = (flags & 0x80) != 0 ? headerEnd : headerEnd + infoCompressedSize;

            using(var directory = new BinaryReader(new MemoryStream(info)))
            using(var payload = new MemoryStream())
            using(var newInfoStream = new MemoryStream())
            using(var newInfo = new BinaryWriter(newInfoStream))
            {
                ReadExact(directory, 16); // Old uncompressed data hash no longer applies.
                newInfo.Write(new byte[16]);
                int blockCount = checked((int)ReadUInt32(directory));
                if(blockCount > info.Length / 10)
                    throw new InvalidDataException("Invalid UnityFS block count.");
                WriteUInt32(newInfo, (uint)blockCount);
                for(int i = 0; i < blockCount; i++)
                {
                    int unpackedSize = checked((int)ReadUInt32(directory));
                    int packedSize = checked((int)ReadUInt32(directory));
                    int blockFlags = (directory.ReadByte() << 8) | directory.ReadByte();
                    byte[] unpacked = Decode(ReadExact(input, packedSize), unpackedSize, blockFlags & 63);
                    payload.Write(unpacked, 0, unpacked.Length);
                    WriteUInt32(newInfo, (uint)unpackedSize);
                    WriteUInt32(newInfo, (uint)unpackedSize);
                    newInfo.Write((byte)0);
                    newInfo.Write((byte)0); // Uncompressed block.
                }
                byte[] content = payload.ToArray();
                long directoryStart = directory.BaseStream.Position;
                int count = checked((int)ReadUInt32(directory));
                if(count > info.Length / 21)
                    throw new InvalidDataException("Invalid UnityFS directory count.");
                for(int i = 0; i < count; i++)
                {
                    long offset = ReadInt64(directory);
                    long length = ReadInt64(directory);
                    uint nodeFlags = ReadUInt32(directory);
                    ReadString(directory);
                    if(offset < 0 || length < 0 || offset > content.LongLength - length)
                        throw new InvalidDataException("UnityFS directory entry is out of bounds.");
                    if((nodeFlags & 4) != 0 && PatchSerializedPlatform(content, checked((int)offset), checked((int)length), targetPlatform))
                        patchedFiles++;
                }
                if(patchedFiles == 0)
                    return source;
                // Node offsets and sizes are unchanged because only four metadata bytes changed.
                newInfo.Write(info, (int)directoryStart, info.Length - (int)directoryStart);
                byte[] rebuiltInfo = newInfoStream.ToArray();
                using(var output = new MemoryStream())
                using(var writer = new BinaryWriter(output))
                {
                    WriteString(writer, "UnityFS");
                    WriteUInt32(writer, format);
                    WriteString(writer, playerVersion);
                    WriteString(writer, engineVersion);
                    WriteInt64(writer, headerEnd + rebuiltInfo.LongLength + content.LongLength);
                    WriteUInt32(writer, (uint)rebuiltInfo.Length);
                    WriteUInt32(writer, (uint)rebuiltInfo.Length);
                    WriteUInt32(writer, 0x40); // Combined directory, uncompressed, before data.
                    writer.Write(rebuiltInfo);
                    writer.Write(content);
                    return output.ToArray();
                }
            }
        }
    }

    private static bool PatchSerializedPlatform(byte[] bytes, int start, int size, int target)
    {
        if(size < 24)
            throw new InvalidDataException("Truncated serialized CAB header.");
        int version = (bytes[start + 8] << 24) | (bytes[start + 9] << 16) | (bytes[start + 10] << 8) | bytes[start + 11];
        if(version < 9 || version >= 22)
            throw new InvalidDataException("Unsupported serialized CAB version: " + version);
        int pos = start + 20;
        while(pos < start + size && bytes[pos] != 0)
            pos++;
        pos++;
        if(pos > start + size - 4)
            throw new InvalidDataException("Missing CAB target platform.");
        bool littleEndian = bytes[start + 16] == 0;
        int platform = littleEndian
            ? bytes[pos] | (bytes[pos + 1] << 8) | (bytes[pos + 2] << 16) | (bytes[pos + 3] << 24)
            : (bytes[pos] << 24) | (bytes[pos + 1] << 16) | (bytes[pos + 2] << 8) | bytes[pos + 3];
        if(platform == target)
            return false;
        if(platform != 13)
            throw new InvalidDataException("Unexpected CAB target platform: " + platform);
        for(int i = 0; i < 4; i++)
            bytes[pos + i] = (byte)(target >> (littleEndian ? 8 * i : 8 * (3 - i)));
        return true;
    }

    private static byte[] Decode(byte[] packed, int size, int compression)
    {
        if(size < 0)
            throw new InvalidDataException("Negative block size.");
        if(compression == 0)
        {
            if(packed.Length != size)
                throw new InvalidDataException("Uncompressed block size mismatch.");
            return packed;
        }
        if(compression != 2 && compression != 3)
            throw new InvalidDataException("Unsupported bundle compression: " + compression);
        byte[] output = new byte[size];
        int inputPos = 0, outputPos = 0;
        while(inputPos < packed.Length)
        {
            int token = packed[inputPos++];
            int literal = ExtendLength(packed, ref inputPos, token >> 4);
            if(literal > packed.Length - inputPos || literal > size - outputPos)
                throw new InvalidDataException("LZ4 literal is out of bounds.");
            Buffer.BlockCopy(packed, inputPos, output, outputPos, literal);
            inputPos += literal;
            outputPos += literal;
            if(inputPos == packed.Length)
                break;
            if(inputPos > packed.Length - 2)
                throw new InvalidDataException("Truncated LZ4 match offset.");
            int distance = packed[inputPos] | (packed[inputPos + 1] << 8);
            inputPos += 2;
            int match = checked(ExtendLength(packed, ref inputPos, token & 15) + 4);
            if(distance == 0 || distance > outputPos || match > size - outputPos)
                throw new InvalidDataException("LZ4 match is out of bounds.");
            for(int i = 0; i < match; i++)
            {
                output[outputPos] = output[outputPos - distance];
                outputPos++;
            }
        }
        if(outputPos != size)
            throw new InvalidDataException("LZ4 decoded size mismatch.");
        return output;
    }

    private static int ExtendLength(byte[] bytes, ref int pos, int length)
    {
        if(length != 15)
            return length;
        int next;
        do
        {
            if(pos >= bytes.Length)
                throw new InvalidDataException("Truncated LZ4 length.");
            next = bytes[pos++];
            length = checked(length + next);
        } while(next == 255);
        return length;
    }

    private static byte[] ReadExact(BinaryReader reader, int count)
    {
        if(count < 0 || count > reader.BaseStream.Length - reader.BaseStream.Position)
            throw new InvalidDataException("Truncated UnityFS data.");
        return reader.ReadBytes(count);
    }
    private static string ReadString(BinaryReader reader)
    {
        using(var bytes = new MemoryStream())
        {
            byte c;
            while((c = reader.ReadByte()) != 0)
                bytes.WriteByte(c);
            return Encoding.UTF8.GetString(bytes.ToArray());
        }
    }
    private static uint ReadUInt32(BinaryReader reader)
    {
        return ((uint)reader.ReadByte() << 24) | ((uint)reader.ReadByte() << 16) | ((uint)reader.ReadByte() << 8) | reader.ReadByte();
    }
    private static long ReadInt64(BinaryReader reader)
    {
        return unchecked((long)(((ulong)ReadUInt32(reader) << 32) | ReadUInt32(reader)));
    }
    private static void WriteUInt32(BinaryWriter writer, uint value)
    {
        for(int i = 3; i >= 0; i--)
            writer.Write((byte)(value >> (8 * i)));
    }
    private static void WriteInt64(BinaryWriter writer, long value)
    {
        WriteUInt32(writer, (uint)((ulong)value >> 32));
        WriteUInt32(writer, (uint)value);
    }
    private static void WriteString(BinaryWriter writer, string value)
    {
        writer.Write(Encoding.UTF8.GetBytes(value));
        writer.Write((byte)0);
    }
}