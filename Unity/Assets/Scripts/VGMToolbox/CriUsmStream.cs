using System;
using System.Collections.Generic;
using System.IO;

using VGMToolbox.util;

namespace VGMToolbox.format
{
    public class CriUsmStream : MpegStream
    {
        public const string DefaultAudioExtension = ".adx";
        public const string DefaultVideoExtension = ".m2v";
        public const string HcaAudioExtension = ".hca";

        static readonly byte[] HCA_SIG_BYTES = new byte[] { 0x48, 0x43, 0x41, 0x00 };

        protected static readonly byte[] ALP_BYTES = new byte[] { 0x40, 0x41, 0x4C, 0x50 };
        protected static readonly byte[] CRID_BYTES = new byte[] { 0x43, 0x52, 0x49, 0x44 };
        protected static readonly byte[] SFV_BYTES = new byte[] { 0x40, 0x53, 0x46, 0x56 };
        protected static readonly byte[] SFA_BYTES = new byte[] { 0x40, 0x53, 0x46, 0x41 };
        protected static readonly byte[] SBT_BYTES = new byte[] { 0x40, 0x53, 0x42, 0x54 };
        protected static readonly byte[] CUE_BYTES = new byte[] { 0x40, 0x43, 0x55, 0x45 };

        protected static readonly byte[] UTF_BYTES = new byte[] { 0x40, 0x55, 0x54, 0x46 };

        protected static readonly byte[] HEADER_END_BYTES =
            new byte[] { 0x23, 0x48, 0x45, 0x41, 0x44, 0x45, 0x52, 0x20,
                         0x45, 0x4E, 0x44, 0x20, 0x20, 0x20, 0x20, 0x20,
                         0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D,
                         0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x00 };

        protected static readonly byte[] METADATA_END_BYTES =
            new byte[] { 0x23, 0x4D, 0x45, 0x54, 0x41, 0x44, 0x41, 0x54,
                         0x41, 0x20, 0x45, 0x4E, 0x44, 0x20, 0x20, 0x20,
                         0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D,
                         0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x00 };

        protected static readonly byte[] CONTENTS_END_BYTES =
            new byte[] { 0x23, 0x43, 0x4F, 0x4E, 0x54, 0x45, 0x4E, 0x54,
                         0x53, 0x20, 0x45, 0x4E, 0x44, 0x20, 0x20, 0x20,
                         0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D,
                         0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x3D, 0x00 };

        protected byte[] _videoMask1 = new byte[0x20];
        protected byte[] _videoMask2 = new byte[0x20];
        protected byte[] _audioMask = new byte[0x20];

        public CriUsmStream(string path)
            : base(path)
        {
            this.UsesSameIdForMultipleAudioTracks = true;
            this.FileExtensionAudio = DefaultAudioExtension;
            this.FileExtensionVideo = DefaultVideoExtension;

            base.BlockIdDictionary.Clear();
            base.BlockIdDictionary[BitConverter.ToUInt32(ALP_BYTES, 0)] = new BlockSizeStruct(PacketSizeType.SizeBytes, 4); // @ALP
            base.BlockIdDictionary[BitConverter.ToUInt32(CRID_BYTES, 0)] = new BlockSizeStruct(PacketSizeType.SizeBytes, 4); // CRID
            base.BlockIdDictionary[BitConverter.ToUInt32(SFV_BYTES, 0)] = new BlockSizeStruct(PacketSizeType.SizeBytes, 4); // @SFV
            base.BlockIdDictionary[BitConverter.ToUInt32(SFA_BYTES, 0)] = new BlockSizeStruct(PacketSizeType.SizeBytes, 4); // @SFA
            base.BlockIdDictionary[BitConverter.ToUInt32(SBT_BYTES, 0)] = new BlockSizeStruct(PacketSizeType.SizeBytes, 4); // @SBT
            base.BlockIdDictionary[BitConverter.ToUInt32(CUE_BYTES, 0)] = new BlockSizeStruct(PacketSizeType.SizeBytes, 4); // @CUE
        }

        protected override byte[] GetPacketStartBytes() { return CRID_BYTES; }

        protected override int GetAudioPacketHeaderSize(Stream readStream, long currentOffset)
        {
            UInt16 checkBytes;
            OffsetDescription od = new OffsetDescription();

            od.OffsetByteOrder = Constants.BigEndianByteOrder;
            od.OffsetSize = "2";
            od.OffsetValue = "8";

            checkBytes = (UInt16)ParseFile.GetVaryingByteValueAtRelativeOffset(readStream, od, currentOffset);

            return checkBytes;
        }
        protected override int GetVideoPacketHeaderSize(Stream readStream, long currentOffset)
        {
            UInt16 checkBytes;
            OffsetDescription od = new OffsetDescription();

            od.OffsetByteOrder = Constants.BigEndianByteOrder;
            od.OffsetSize = "2";
            od.OffsetValue = "8";

            checkBytes = (UInt16)ParseFile.GetVaryingByteValueAtRelativeOffset(readStream, od, currentOffset);

            return checkBytes;
        }

        protected override bool IsThisAnAudioBlock(byte[] blockToCheck)
        {
            return ParseFile.CompareSegment(blockToCheck, 0, SFA_BYTES);
        }
        protected override bool IsThisAVideoBlock(byte[] blockToCheck)
        {
            return ParseFile.CompareSegment(blockToCheck, 0, SFV_BYTES);
        }

        protected override byte GetStreamId(Stream readStream, long currentOffset)
        {
            byte streamId;

            streamId = ParseFile.ParseSimpleOffset(readStream, currentOffset + 0xC, 1)[0];

            return streamId;
        }

        protected override int GetAudioPacketFooterSize(Stream readStream, long currentOffset)
        {
            UInt16 checkBytes;
            OffsetDescription od = new OffsetDescription();

            od.OffsetByteOrder = Constants.BigEndianByteOrder;
            od.OffsetSize = "2";
            od.OffsetValue = "0xA";

            checkBytes = (UInt16)ParseFile.GetVaryingByteValueAtRelativeOffset(readStream, od, currentOffset);

            return checkBytes;
        }

        protected override int GetVideoPacketFooterSize(Stream readStream, long currentOffset)
        {
            UInt16 checkBytes;
            OffsetDescription od = new OffsetDescription();

            od.OffsetByteOrder = Constants.BigEndianByteOrder;
            od.OffsetSize = "2";
            od.OffsetValue = "0xA";

            checkBytes = (UInt16)ParseFile.GetVaryingByteValueAtRelativeOffset(readStream, od, currentOffset);

            return checkBytes;
        }

        byte[] Reverse(byte[] array)
        {
            Array.Reverse(array);
            return array;
        }

        protected override bool ReadBlock(FileStream fs, byte[] currentBlockId, long currentOffset)
        {
            long startOffset = currentOffset;
            uint currentBlockIdVal = BitConverter.ToUInt32(currentBlockId, 0);
            currentOffset += 4;

            uint chunkSize = BitConverter.ToUInt32(Reverse(ParseFile.ParseSimpleOffset(fs, currentOffset, 4)), 0); currentOffset += 4;
            uint unknow = (char)ParseFile.ParseSimpleOffset(fs, currentOffset, 1)[0]; currentOffset += 1;
            uint payloadOffset = (char)ParseFile.ParseSimpleOffset(fs, currentOffset, 1)[0]; currentOffset += 1;
            uint paddingSize = BitConverter.ToUInt16(Reverse(ParseFile.ParseSimpleOffset(fs, currentOffset, 2)), 0); currentOffset += 2;
            uint channelNumber = (char)ParseFile.ParseSimpleOffset(fs, currentOffset, 1)[0]; currentOffset += 1;
            uint unknow2 = (char)ParseFile.ParseSimpleOffset(fs, currentOffset, 1)[0]; currentOffset += 1;
            uint unknow3 = (char)ParseFile.ParseSimpleOffset(fs, currentOffset, 1)[0]; currentOffset += 1;
            uint payloadType = (char)ParseFile.ParseSimpleOffset(fs, currentOffset, 1)[0]; currentOffset += 1;
            uint frameTime = BitConverter.ToUInt32(Reverse(ParseFile.ParseSimpleOffset(fs, currentOffset, 4)), 0); currentOffset += 4;
            uint frameRate = BitConverter.ToUInt32(Reverse(ParseFile.ParseSimpleOffset(fs, currentOffset, 4)), 0); currentOffset += 4;
            uint unknow4 = BitConverter.ToUInt32(Reverse(ParseFile.ParseSimpleOffset(fs, currentOffset, 4)), 0); currentOffset += 4;
            uint unknow5 = BitConverter.ToUInt32(Reverse(ParseFile.ParseSimpleOffset(fs, currentOffset, 4)), 0); currentOffset += 4;

            // UnityEngine.Debug.Log("Chunk Info : currentBlockIdVal : "+currentBlockIdVal
            //     +" chunkSize : "+chunkSize+" unknow : "+unknow.ToString()+" payloadOffset : "+payloadOffset.ToString()
            //     +" paddingSize : "+paddingSize+" channelNumber : "+channelNumber.ToString()
            //     +" unknow2 : "+unknow2.ToString()+" unknow3 : "+unknow3.ToString()+" payloadType : "+payloadType.ToString()
            //     +" frameTime : "+frameTime+" frameRate : "+frameRate+" unknow4 : "+unknow4+" unknow5 : "+unknow5);

            if(payloadType == 1 || payloadType == 3)
            {
                /*CriUtfTable utfTable = new CriUtfTable();
                utfTable.Initialize(fs, startOffset + 8 + payloadOffset);
                UnityEngine.Debug.Log(utfTable.GetTableAsString(0, true));*/
            }

            if(currentBlockIdVal == BitConverter.ToUInt32(CRID_BYTES, 0))
            {
                return true;
            }
            return false;
        }

        protected override void TryDecrypt(byte[] block)
        {
            int size = block.Length;
            int data = 0;
            data+=0x40;
            size-=0x40;
            if(size>=0x200){
                byte[] mask = new byte[0x20];
                Buffer.BlockCopy(_videoMask2, 0, mask, 0, mask.Length);
                for(int i=0x100;i<size;i++){
                    block[data +i]^=mask[i&0x1F];
                    mask[i&0x1F]=(byte)((block[data +i])^_videoMask2[i&0x1F]);
                }
                Buffer.BlockCopy(_videoMask1, 0, mask, 0, mask.Length);
                for(int i=0;i<0x100;i++){
                    mask[i&0x1F]^=block[data + 0x100+i];
                    block[data + i]^=(byte)(mask[i&0x1F]);
                }
            }
        }
        public override void DemultiplexStreams(DemuxOptionsStruct demuxOptions)
        {
            if(demuxOptions.Key1 != 0)
            {
                byte[] t = new byte[0x20];
                byte[] k1 = BitConverter.GetBytes(demuxOptions.Key1);
                byte[] k2 = BitConverter.GetBytes(demuxOptions.Key2);
                t[0x00]=k1[0];
                t[0x01]=k1[1];
                t[0x02]=k1[2];
                t[0x03]=(byte)(k1[3]-0x34);
                t[0x04]=(byte)(k2[0]+0xF9);
                t[0x05]=(byte)(k2[1]^0x13);
                t[0x06]=(byte)(k2[2]+0x61);
                t[0x07]=(byte)(t[0x00]^0xFF);
                t[0x08]=(byte)(t[0x02]+t[0x01]);
                t[0x09]=(byte)(t[0x01]-t[0x07]);
                t[0x0A]=(byte)(t[0x02]^0xFF);
                t[0x0B]=(byte)(t[0x01]^0xFF);
                t[0x0C]=(byte)(t[0x0B]+t[0x09]);
                t[0x0D]=(byte)(t[0x08]-t[0x03]);
                t[0x0E]=(byte)(t[0x0D]^0xFF);
                t[0x0F]=(byte)(t[0x0A]-t[0x0B]);
                t[0x10]=(byte)(t[0x08]-t[0x0F]);
                t[0x11]=(byte)(t[0x10]^t[0x07]);
                t[0x12]=(byte)(t[0x0F]^0xFF);
                t[0x13]=(byte)(t[0x03]^0x10);
                t[0x14]=(byte)(t[0x04]-0x32);
                t[0x15]=(byte)(t[0x05]+0xED);
                t[0x16]=(byte)(t[0x06]^0xF3);
                t[0x17]=(byte)(t[0x13]-t[0x0F]);
                t[0x18]=(byte)(t[0x15]+t[0x07]);
                t[0x19]=(byte)(0x21-t[0x13]);
                t[0x1A]=(byte)(t[0x14]^t[0x17]);
                t[0x1B]=(byte)(t[0x16]+t[0x16]);
                t[0x1C]=(byte)(t[0x17]+0x44);
                t[0x1D]=(byte)(t[0x03]+t[0x04]);
                t[0x1E]=(byte)(t[0x05]-t[0x16]);
                t[0x1F]=(byte)(t[0x1D]^t[0x13]);

                byte[] t2 = new byte[4]{(byte)'U',(byte)'R',(byte)'U',(byte)'C'};
                for(int i=0;i<0x20;i++){
                    _videoMask1[i]=t[i];
                    _videoMask2[i]=(byte)(t[i]^0xFF);
                    _audioMask[i]=(byte)(((i&1) != 0)?t2[(i>>1)&3]:t[i]^0xFF);
                }
            }

            base.DemultiplexStreams(demuxOptions);
        }

        protected override void DoFinalTasks(FileStream sourceFileStream, Dictionary<uint, Stream> outputFiles, bool addHeader)
        {
            long headerEndOffset;
            long metadataEndOffset;
            long headerSize;

            long footerOffset;
            long footerSize;

            string sourceFileName = "";
            string workingFile;
            string fileExtension = "";
            string destinationFileName;

            Dictionary<uint, Stream> newList = new Dictionary<uint, Stream>();

            foreach (uint streamId in outputFiles.Keys)
            {
                FileStream fs = outputFiles[streamId] as FileStream;
                if(fs != null)
                {
                    sourceFileName = fs.Name;
                }

                //--------------------------
                // get header size
                //--------------------------
                headerEndOffset = ParseFile.GetNextOffset(outputFiles[streamId], 0, HEADER_END_BYTES);
                metadataEndOffset = ParseFile.GetNextOffset(outputFiles[streamId], 0, METADATA_END_BYTES);

                if (metadataEndOffset > headerEndOffset)
                {
                    headerSize = metadataEndOffset + METADATA_END_BYTES.Length;
                }
                else
                {
                    headerSize = headerEndOffset + METADATA_END_BYTES.Length;
                }

                //-----------------
                // get footer size
                //-----------------
                footerOffset = ParseFile.GetNextOffset(outputFiles[streamId], 0, CONTENTS_END_BYTES) - headerSize;
                footerSize = outputFiles[streamId].Length - footerOffset;

                //------------------------------------------
                // check data to adjust extension if needed
                //------------------------------------------
                if(fs != null)
                {
                    if (this.IsThisAnAudioBlock(BitConverter.GetBytes(streamId & 0xFFFFFFF0))) // may need to change mask if more than 0xF streams
                    {
                        byte[] checkBytes = ParseFile.ParseSimpleOffset(outputFiles[streamId], headerSize, 4);

                        if (ParseFile.CompareSegment(checkBytes, 0, SofdecStream.AixSignatureBytes))
                        {
                            fileExtension = SofdecStream.AixAudioExtension;
                        }
                        else if (checkBytes[0] == 0x80)
                        {
                            fileExtension = SofdecStream.AdxAudioExtension;
                        }
                        else if (ParseFile.CompareSegment(checkBytes, 0, HCA_SIG_BYTES))
                        {
                            fileExtension = HcaAudioExtension;
                        }
                        else
                        {
                            fileExtension = ".bin";
                        }
                    }
                    else
                    {
                        fileExtension = Path.GetExtension(sourceFileName);
                    }
                }

                MemoryStream ms = null;
                if(fs == null)
                {
                    MemoryStream sourceFs = outputFiles[streamId] as MemoryStream;
                    ms = new MemoryStream();

                    // Remove header & footer
                    byte[] bytes = new byte[1024*1024];

                    // start after header
                    long currentPos = headerSize;
                    sourceFs.Seek(currentPos, SeekOrigin.Begin);

                    int bytesRead = sourceFs.Read(bytes, 0, bytes.Length);
                    while (bytesRead > 0)
                    {
                        int bytesToWrite = bytesRead;
                        if(footerOffset >= 0 && (currentPos + bytesToWrite) > footerOffset)
                        {
                            bytesToWrite = (int)(footerOffset - currentPos);
                            sourceFs.Seek(footerOffset + footerSize, SeekOrigin.Begin);
                            footerOffset = -1;
                        }
                        ms.Write(bytes, 0, bytesToWrite);
                        bytesRead = sourceFs.Read(bytes, 0, bytes.Length);
                    }
                    outputFiles[streamId].Close();
                    outputFiles[streamId].Dispose();
                    newList[streamId] = ms;
                }
                else
                {
                    outputFiles[streamId].Close();
                    outputFiles[streamId].Dispose();
                    workingFile = FileUtil.RemoveChunkFromFile(sourceFileName, 0, headerSize);
                    File.Copy(workingFile, sourceFileName, true);
                    File.Delete(workingFile);

                    workingFile = FileUtil.RemoveChunkFromFile(sourceFileName, footerOffset, footerSize);
                    destinationFileName = Path.ChangeExtension(sourceFileName, fileExtension);
                    File.Copy(workingFile, destinationFileName, true);
                    File.Delete(workingFile);

                    if ((sourceFileName != destinationFileName) && (File.Exists(sourceFileName)))
                    {
                        File.Delete(sourceFileName);
                    }
                }
            }
            outputFiles.Clear();
            foreach(var k in newList)
            {
                outputFiles[k.Key] = k.Value;
            }
        }
    }
}