using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using VGMToolbox.util;

namespace VGMToolbox.format
{
    public class CriField
    {        
        public byte Type { set; get; }
        public string Name { set; get; }        
        public object Value { set; get; }
        public ulong Offset { set; get; }
        public ulong Size { set; get; }

        //public override string ToString()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    string value = String.Empty;

        //    sb.AppendFormat("0x{0} {1} {2} = {3}", 
        //                        this.Offset.ToString("X8"),
        //                        this.Type.ToString("X2"),
        //                        this.Name,
        //                        this.GetStringValue());
        //    return sb.ToString();
        //}

        public string ToString(FileStream fs,
                               int currentIdent,
                               bool useIncomingKeys = false,
                               Dictionary < string, byte> lcgEncryptionKeys = null)
        {
            StringBuilder sb = new StringBuilder();
            string frontPad = new string(' ', currentIdent);

            sb.AppendFormat("0x{0} {1} {2} = {3}",
                                this.Offset.ToString("X8"),
                                this.Type.ToString("X2"),
                                this.Name,
                                this.GetStringValue(currentIdent, fs, useIncomingKeys, lcgEncryptionKeys));

            return frontPad + sb.ToString();
        }

        public string GetStringValue(int currentIdent,
                                     FileStream utfStream = null,                                     
                                     bool useIncomingKeys = false,
                                     Dictionary<string, byte> lcgEncryptionKeys = null)
        {
            ulong numericValue;
            long signedNumericValue;
            byte maskedType = (byte)(this.Type & CriUtfTable.COLUMN_TYPE_MASK);
            string stringValue = String.Empty;

            string frontPad = new string(' ', currentIdent);
            string formattedString;

            switch (maskedType)
            {
                case CriUtfTable.COLUMN_TYPE_DATA:
                    if (utfStream == null)
                    {
                        stringValue = this.Value.ToString();
                    }
                    else if (CriUtfTable.IsUtfTable(utfStream, (long)this.Offset, useIncomingKeys, lcgEncryptionKeys))
                    {
                        CriUtfTable newUtf = new CriUtfTable();
                        newUtf.Initialize(utfStream, (long)this.Offset);
                        stringValue = newUtf.GetTableAsString((currentIdent + 4), true);
                    }
                    else
                    {
                        stringValue = FileUtil.GetStringFromFileChunk(utfStream, this.Offset, this.Size);

                        if (stringValue.Length > 0x20)
                        {
                            formattedString = Regex.Replace(stringValue, ".{8}(?!$)", "$0 ");
                            stringValue = Environment.NewLine + formattedString;
                        }
                    }
                    
                    break;
                case CriUtfTable.COLUMN_TYPE_STRING:
                    stringValue = (string)this.Value;
                    break;
                case CriUtfTable.COLUMN_TYPE_FLOAT:
                    stringValue = Convert.ToSingle(this.Value).ToString();
                    break;
                case CriUtfTable.COLUMN_TYPE_8BYTE:                    
                case CriUtfTable.COLUMN_TYPE_4BYTE:
                case CriUtfTable.COLUMN_TYPE_2BYTE:
                case CriUtfTable.COLUMN_TYPE_1BYTE:
                    numericValue = Convert.ToUInt64(this.Value);
                    stringValue = String.Format("0x{0} ({1})", numericValue.ToString("X8"), numericValue.ToString());
                    break;
                case CriUtfTable.COLUMN_TYPE_4BYTE2:
                case CriUtfTable.COLUMN_TYPE_2BYTE2:
                case CriUtfTable.COLUMN_TYPE_1BYTE2:
                    signedNumericValue = Convert.ToInt64(this.Value);
                    stringValue = String.Format("0x{0} ({1})", signedNumericValue.ToString("X8"), signedNumericValue.ToString());
                    break;
            }

            return stringValue;
        }
    }

    public class CriUtfTocFileInfo
    {
        public string DirName { set; get; }
        public string FileName { set; get; }
        public uint FileSize { set; get; }
        public uint ExtractSize { set; get; }
        public ulong FileOffset { set; get; }
    }

    public class CriUtfTable
    {
        // thanks to hcs for all of this!!!

        #region Constants

        public static readonly byte[] SIGNATURE_BYTES = new byte[] { 0x40, 0x55, 0x54, 0x46 };
        public const string LCG_SEED_KEY = "SEED";
        public const string LCG_INCREMENT_KEY = "INC";
        public const string TEMP_UTF_TABLE_FILE = "VGMT_UTF.BIN";

        public const byte COLUMN_STORAGE_MASK = 0xF0;
        public const byte COLUMN_STORAGE_PERROW = 0x50;
        public const byte COLUMN_STORAGE_CONSTANT = 0x30;
        public const byte COLUMN_STORAGE_CONSTANT2 = 0x70;
        public const byte COLUMN_STORAGE_ZERO = 0x10;

        // I suspect that "type 2" is signed
        public const byte COLUMN_TYPE_MASK = 0x0F;
        public const byte COLUMN_TYPE_DATA = 0x0B;
        public const byte COLUMN_TYPE_STRING = 0x0A;
        // 0x09 double? 
        public const byte COLUMN_TYPE_FLOAT = 0x08;
        // 0x07 signed 8byte? 
        public const byte COLUMN_TYPE_8BYTE = 0x06;
        public const byte COLUMN_TYPE_4BYTE2 = 0x05;
        public const byte COLUMN_TYPE_4BYTE = 0x04;
        public const byte COLUMN_TYPE_2BYTE2 = 0x03;
        public const byte COLUMN_TYPE_2BYTE = 0x02;
        public const byte COLUMN_TYPE_1BYTE2 = 0x01;
        public const byte COLUMN_TYPE_1BYTE = 0x00;

        #endregion

        #region Members

        public string SourceFile { set; get; }
        public long BaseOffset { set; get; }
        public string UtfTableFile { set; get; }

        public byte[] MagicBytes { set; get; }
        public bool IsEncrypted { set; get; }
        public Dictionary<string, byte> LcgEncryptionKeys { set; get; }
        public uint TableSize { set; get; }

        public ushort Unknown1 { set; get; }

        public uint RowOffset { set; get; }
        public uint StringTableOffset { set; get; }
        public uint DataOffset { set; get; }

        public uint TableNameOffset { set; get; }
        public string TableName { set; get; }

        public ushort NumberOfFields { set; get; }
        
        public ushort RowSize { set; get; }
        public uint NumberOfRows { set; get; }

        public Dictionary<string, CriField>[] Rows { set; get; }

        public CriUtfReader UtfReader { set; get; }

        #endregion

        public void Initialize(FileStream fs, long offset)
        {
            this.SourceFile = fs.Name;
            this.BaseOffset = offset;

            try
            {
                this.MagicBytes = ParseFile.ParseSimpleOffset(fs, this.BaseOffset, 4);

                // check if file is decrypted and get decryption keys if needed
                this.checkEncryption(fs);

                // write (decrypted) utf header to file 
                this.UtfTableFile = this.WriteTableToTempFile(fs, offset);
                
                this.IsEncrypted = false; // since we've decrypted to a temp file
                this.UtfReader.IsEncrypted = false;

                if (ParseFile.CompareSegment(this.MagicBytes, 0, SIGNATURE_BYTES))
                {
                    using (FileStream utfTableStream = File.Open(this.UtfTableFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        // read header
                        this.initializeUtfHeader(utfTableStream);

                        // initialize rows
                        this.Rows = new Dictionary<string, CriField>[this.NumberOfRows];

                        // read schema
                        if (this.TableSize > 0)
                        {
                            this.initializeUtfSchema(fs, utfTableStream, 0x20);
                        }
                    }
                }
                else
                {
                    //Dictionary<string, byte> foo = GetKeysForEncryptedUtfTable(this.MagicBytes);
                    throw new FormatException(String.Format("@UTF signature not found at offset <0x{0}>.", offset.ToString("X8")));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!String.IsNullOrEmpty(this.UtfTableFile))
                {
                    File.Delete(this.UtfTableFile);
                }
            }
        
        }

        public string GetTableAsString(int currentIdent, bool useExistingKeys = false)
        {
            CriField field;
            StringBuilder sb = new StringBuilder();

            string frontPad = new string(' ', currentIdent);

            sb.AppendLine();
            sb.AppendLine(frontPad + "---------------------------");
            sb.AppendLine(frontPad + "-------- UTF START --------".PadLeft(currentIdent));
            sb.AppendLine(frontPad + "---------------------------".PadLeft(currentIdent));

            using (FileStream fs = File.Open(this.SourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                for (int i = 0; i < this.Rows.Length; i++)
                {
                    sb.AppendFormat("{0}{1}[0x{2}]{3}", frontPad, this.TableName, i.ToString("X4"), Environment.NewLine);

                    var d = this.Rows[i];

                    foreach (var key in d.Keys)
                    {
                        field = d[key];
                        sb.AppendLine(field.ToString(fs, (currentIdent + 2), useExistingKeys, this.LcgEncryptionKeys));
                    }

                    sb.AppendLine();
                }
            }

            sb.AppendLine(frontPad + "---------------------------");
            sb.AppendLine(frontPad + "--------- UTF END ---------");
            sb.AppendLine(frontPad + "---------------------------");

            return sb.ToString();
        }

        private void checkEncryption(FileStream fs, bool useIncomingKeys = false, Dictionary<string, byte> incomingLcgEncryptionKeys = null)
        {
            if (ParseFile.CompareSegment(this.MagicBytes, 0, SIGNATURE_BYTES) ||
                ((useIncomingKeys) && (incomingLcgEncryptionKeys == null))
                )
            {
                this.IsEncrypted = false;
                this.UtfReader = new CriUtfReader();
            }
            else
            {
                this.IsEncrypted = true;

                if (useIncomingKeys) // use incoming keys if available
                {
                    if (incomingLcgEncryptionKeys != null) 
                    {
                        this.LcgEncryptionKeys = incomingLcgEncryptionKeys;
                    }
                }
                else if (this.LcgEncryptionKeys == null) // use keys found earlier, assume same keys for entire file
                {
                    this.LcgEncryptionKeys = GetKeysForEncryptedUtfTable(this.MagicBytes);
                }

                if (this.LcgEncryptionKeys.Count != 2)
                {
                    throw new FormatException(String.Format("Unable to decrypt UTF table at offset: 0x{0}", this.BaseOffset.ToString("X8")));
                }
                else
                {
                    this.UtfReader = new CriUtfReader(this.LcgEncryptionKeys[LCG_SEED_KEY], 
                                                      this.LcgEncryptionKeys[LCG_INCREMENT_KEY], this.IsEncrypted);
                }

                this.MagicBytes = this.UtfReader.GetBytes(fs, this.BaseOffset, 4, 0);
            }

        }

        private void initializeUtfHeader(FileStream UtfTableFs)
        {
            this.TableSize = ParseFile.ReadUintBE(UtfTableFs, 4);

            this.Unknown1 = ParseFile.ReadUshortBE(UtfTableFs, 8);

            this.RowOffset = (uint)ParseFile.ReadUshortBE(UtfTableFs, 0xA) + 8;
            this.StringTableOffset = ParseFile.ReadUintBE(UtfTableFs, 0xC) + 8;
            this.DataOffset = ParseFile.ReadUintBE(UtfTableFs, 0x10) + 8;

            this.TableNameOffset = ParseFile.ReadUintBE(UtfTableFs, 0x14);
            this.TableName = ParseFile.ReadAsciiString(UtfTableFs, this.StringTableOffset + this.TableNameOffset);

            this.NumberOfFields = ParseFile.ReadUshortBE(UtfTableFs, 0x18);

            this.RowSize = ParseFile.ReadUshortBE(UtfTableFs, 0x1A);
            this.NumberOfRows = ParseFile.ReadUintBE(UtfTableFs, 0x1C);        
        }

        private void initializeUtfSchema(FileStream SourceFs, FileStream UtfTableFs, long schemaOffset)
        {
            long nameOffset;

            long constantOffset;
            
            long dataOffset;
            long dataSize;

            long rowDataOffset;
            long rowDataSize;

            long currentOffset = schemaOffset;
            long currentRowBase;
            long currentRowOffset = 0;
            
            CriField field;

            for (uint i = 0; i < this.NumberOfRows; i++)
            {
                //if (i == 0x1a2a)
                //{
                //    int yuuuu = 1;
                //}                
                //try
                //{
                    currentOffset = schemaOffset;
                    currentRowBase = this.RowOffset + (this.RowSize * i);
                    currentRowOffset = 0;
                    this.Rows[i] = new Dictionary<string, CriField>();

                    // parse fields
                    for (ushort j = 0; j < this.NumberOfFields; j++)
                    {
                        field = new CriField();

                        field.Type = ParseFile.ReadByte(UtfTableFs, currentOffset);
                        nameOffset = ParseFile.ReadUintBE(UtfTableFs, currentOffset + 1);
                        field.Name = ParseFile.ReadAsciiString(UtfTableFs, this.StringTableOffset + nameOffset);

                        // each row will have a constant
                        if (((field.Type & COLUMN_STORAGE_MASK) == COLUMN_STORAGE_CONSTANT) ||
                            ((field.Type & COLUMN_STORAGE_MASK) == COLUMN_STORAGE_CONSTANT2))
                        {
                            // capture offset of constant
                            constantOffset = currentOffset + 5;

                            // read the constant depending on the type
                            switch (field.Type & COLUMN_TYPE_MASK)
                            {
                                case COLUMN_TYPE_STRING:
                                    dataOffset = ParseFile.ReadUintBE(UtfTableFs, constantOffset);
                                    field.Value = ParseFile.ReadAsciiString(UtfTableFs, this.StringTableOffset + dataOffset);
                                    currentOffset += 4;
                                    break;
                                case COLUMN_TYPE_8BYTE:
                                    field.Value = ParseFile.ReadUlongBE(UtfTableFs, constantOffset);
                                    currentOffset += 8;
                                    break;
                                case COLUMN_TYPE_DATA:
                                    dataOffset = ParseFile.ReadUintBE(UtfTableFs, constantOffset);
                                    dataSize = ParseFile.ReadUintBE(UtfTableFs, constantOffset + 4);
                                    field.Offset = (ulong)(this.BaseOffset + this.DataOffset + dataOffset);
                                    field.Size = (ulong)dataSize;
                                    
                                    // don't think this is encrypted, need to check
                                    field.Value = ParseFile.ParseSimpleOffset(SourceFs, (long)field.Offset, (int)dataSize);
                                    currentOffset += 8;
                                    break;
                                case COLUMN_TYPE_FLOAT:
                                    field.Value = ParseFile.ReadFloatBE(UtfTableFs, constantOffset);
                                    currentOffset += 4;
                                    break;
                                case COLUMN_TYPE_4BYTE2:
                                    field.Value = ParseFile.ReadInt32BE(UtfTableFs, constantOffset);
                                    currentOffset += 4;
                                    break;
                                case COLUMN_TYPE_4BYTE:
                                    field.Value = ParseFile.ReadUintBE(UtfTableFs, constantOffset);
                                    currentOffset += 4;
                                    break;
                                case COLUMN_TYPE_2BYTE2:
                                    field.Value = ParseFile.ReadInt16BE(UtfTableFs, constantOffset);
                                    currentOffset += 2;
                                    break;
                                case COLUMN_TYPE_2BYTE:
                                    field.Value = ParseFile.ReadUshortBE(UtfTableFs, constantOffset);
                                    currentOffset += 2;
                                    break;
                                case COLUMN_TYPE_1BYTE2:
                                    field.Value = ParseFile.ReadSByte(UtfTableFs, constantOffset);
                                    currentOffset += 1;
                                    break;
                                case COLUMN_TYPE_1BYTE:
                                    field.Value = ParseFile.ReadByte(UtfTableFs, constantOffset);
                                    currentOffset += 1;
                                    break;
                                default:
                                    throw new FormatException(String.Format("Unknown COLUMN TYPE at offset: 0x{0}", currentOffset.ToString("X8")));

                            } // switch (field.Type & COLUMN_TYPE_MASK)
                        }
                        else if ((field.Type & COLUMN_STORAGE_MASK) == COLUMN_STORAGE_PERROW)
                        {
                            // read the constant depending on the type
                            switch (field.Type & COLUMN_TYPE_MASK)
                            {
                                case COLUMN_TYPE_STRING:
                                    rowDataOffset = ParseFile.ReadUintBE(UtfTableFs, currentRowBase + currentRowOffset);
                                    field.Value = ParseFile.ReadAsciiString(UtfTableFs, this.StringTableOffset + rowDataOffset);
                                    currentRowOffset += 4;
                                    break;
                                case COLUMN_TYPE_8BYTE:
                                    field.Value = ParseFile.ReadUlongBE(UtfTableFs, currentRowBase + currentRowOffset);
                                    currentRowOffset += 8;
                                    break;
                                case COLUMN_TYPE_DATA:
                                    rowDataOffset = ParseFile.ReadUintBE(UtfTableFs, currentRowBase + currentRowOffset);
                                    rowDataSize = ParseFile.ReadUintBE(UtfTableFs, currentRowBase + currentRowOffset + 4);
                                    field.Offset = (ulong)(this.BaseOffset + this.DataOffset + rowDataOffset);
                                    field.Size = (ulong)rowDataSize;
                                    
                                    // don't think this is encrypted
                                    field.Value = ParseFile.ParseSimpleOffset(SourceFs, (long)field.Offset, (int)rowDataSize);
                                    currentRowOffset += 8;
                                    break;
                                case COLUMN_TYPE_FLOAT:
                                    field.Value = ParseFile.ReadFloatBE(UtfTableFs, currentRowBase + currentRowOffset);
                                    currentRowOffset += 4;
                                    break;
                                case COLUMN_TYPE_4BYTE2:
                                    field.Value = ParseFile.ReadInt32BE(UtfTableFs, currentRowBase + currentRowOffset);
                                    currentRowOffset += 4;
                                    break;
                                case COLUMN_TYPE_4BYTE:
                                    field.Value = ParseFile.ReadUintBE(UtfTableFs, currentRowBase + currentRowOffset);
                                    currentRowOffset += 4;
                                    break;
                                case COLUMN_TYPE_2BYTE2:
                                    field.Value = ParseFile.ReadInt16BE(UtfTableFs, currentRowBase + currentRowOffset);
                                    currentRowOffset += 2;
                                    break;
                                case COLUMN_TYPE_2BYTE:
                                    field.Value = ParseFile.ReadUshortBE(UtfTableFs, currentRowBase + currentRowOffset);
                                    currentRowOffset += 2;
                                    break;
                                case COLUMN_TYPE_1BYTE2:
                                    field.Value = ParseFile.ReadSByte(UtfTableFs, currentRowBase + currentRowOffset);
                                    currentRowOffset += 1;
                                    break;
                                case COLUMN_TYPE_1BYTE:
                                    field.Value = ParseFile.ReadByte(UtfTableFs, currentRowBase + currentRowOffset);
                                    currentRowOffset += 1;
                                    break;
                                default:
                                    throw new FormatException(String.Format("Unknown COLUMN TYPE at offset: 0x{0}", currentOffset.ToString("X8")));

                            } // switch (field.Type & COLUMN_TYPE_MASK)

                        } // if ((fields[i].Type & COLUMN_STORAGE_MASK) == COLUMN_STORAGE_CONSTANT)

                        // add field to dictionary
                        this.Rows[i].Add(field.Name, field);

                        // move to next field
                        currentOffset += 5; //  sizeof(CriField.Type + CriField.NameOffset)

                    } // for (ushort j = 0; j < this.NumberOfFields; j++)
                //}
                //catch (Exception ex)
                //{
                //    int xxxx = 1;
                //}
            } // for (uint i = 0; i < this.NumberOfRows; i++)
        }

        public string WriteTableToTempFile(FileStream fs, long offsetToUtfTable, int? maxTableSize = null)
        {
            string pathToUtf = null;

            int totalBytesRead = 0;
            int maxRead;
            byte[] buffer = new byte[Constants.FileReadChunkSize];
            
            int tableSize;

            if (maxTableSize != null) // typically used for isUtf function
            {
                tableSize = (int)maxTableSize;
            }
            else
            {
                tableSize = (int)this.UtfReader.ReadUint(fs, offsetToUtfTable, 4) + 8;
            }

            pathToUtf = Path.Combine(Path.GetTempPath(), TEMP_UTF_TABLE_FILE);
            
            if (this.IsEncrypted)
            {
                using (FileStream tempStream = File.Open(pathToUtf, FileMode.Create, FileAccess.Write, FileShare.Read))
                {
                    while (totalBytesRead < tableSize)
                    {
                        if ((tableSize - totalBytesRead) > buffer.Length)
                        {
                            maxRead = buffer.Length;
                        }
                        else
                        {
                            maxRead = (tableSize - totalBytesRead);
                        }

                        buffer = this.UtfReader.GetBytes(fs, offsetToUtfTable, maxRead, totalBytesRead);
                        tempStream.Write(buffer, 0, maxRead);
                        totalBytesRead += maxRead;
                    }
                }
            }
            else
            {
                if (File.Exists(pathToUtf))
                {
                    File.Delete(pathToUtf);
                }

                ParseFile.ExtractChunkToFile64(fs, (ulong)offsetToUtfTable, (ulong)tableSize, pathToUtf, false, false);
            }

            return pathToUtf;
        }

        public static object GetUtfFieldForRow(CriUtfTable utfTable, int rowIndex, string key)
        {
            object ret = null;

            if (utfTable.Rows.GetLength(0) > rowIndex)
            {
                if (utfTable.Rows[rowIndex].ContainsKey(key))
                {
                    ret = utfTable.Rows[rowIndex][key].Value;
                }
            }

            return ret;
        }

        public static ulong GetOffsetForUtfFieldForRow(CriUtfTable utfTable, int rowIndex, string key)
        {
            ulong ret = 0;

            if (utfTable.Rows.GetLength(0) > rowIndex)
            {
                if (utfTable.Rows[rowIndex].ContainsKey(key))
                {
                    ret = utfTable.Rows[rowIndex][key].Offset;
                }
            }

            return ret;
        }

        public static ulong GetSizeForUtfFieldForRow(CriUtfTable utfTable, int rowIndex, string key)
        {
            ulong ret = 0;

            if (utfTable.Rows.GetLength(0) > rowIndex)
            {
                if (utfTable.Rows[rowIndex].ContainsKey(key))
                {
                    ret = utfTable.Rows[rowIndex][key].Size;
                }
            }

            return ret;
        }
       
        public static Dictionary<string, byte> GetKeysForEncryptedUtfTable(byte[] encryptedUtfSignature)
        {
            Dictionary<string, byte> keys = new Dictionary<string, byte>();
            byte m, t;

            byte[] xorBytes = new byte[SIGNATURE_BYTES.Length];
            bool keysFound = false;

            for (byte seed = 0; seed <= byte.MaxValue; seed++)
            {
                if (!keysFound)
                {
                    // match first char
                    if ((encryptedUtfSignature[0] ^ seed) == SIGNATURE_BYTES[0])
                    {
                        for (byte increment = 0; increment <= byte.MaxValue; increment++)
                        {
                            if (!keysFound)
                            {
                                m = (byte)(seed * increment);

                                if ((encryptedUtfSignature[1] ^ m) == SIGNATURE_BYTES[1])
                                {
                                    t = increment;

                                    for (int j = 2; j < SIGNATURE_BYTES.Length; j++)
                                    {
                                        m *= t;

                                        if ((encryptedUtfSignature[j] ^ m) != SIGNATURE_BYTES[j])
                                        {
                                            break;
                                        }
                                        else if (j == (SIGNATURE_BYTES.Length - 1))
                                        {
                                            keys.Add(LCG_SEED_KEY, seed);
                                            keys.Add(LCG_INCREMENT_KEY, increment);
                                            keysFound = true;
                                        }
                                    }
                                } // if ((encryptedUtfSignature[1] ^ m) == SIGNATURE_BYTES[1])
                            }
                            else
                            {
                                break;
                            } // if (!keysFound)
                        } // for (byte inc = 0; inc <= byte.MaxValue; inc++)
                    } // if ((encryptedUtfSignature[0] ^ mult) == SIGNATURE_BYTES[0])
                } // if (!keysFound)
                else
                {
                    break;
                }
            } // for (byte mult = 0; mult <= byte.MaxValue; mult++)

            return keys;
        }

        public static bool IsUtfTable(FileStream fs, long offset,
                                      bool useIncomingKeys = false,
                                      Dictionary<string, byte> incomingLcgEncryptionKeys = null)
        {
            bool ret = false;
            CriUtfTable utf = new CriUtfTable();

            utf.SourceFile = fs.Name;
            utf.BaseOffset = offset;

            try
            {
                utf.MagicBytes = ParseFile.ParseSimpleOffset(fs, utf.BaseOffset, 4);

                // check if file is decrypted and get decryption keys if needed
                utf.checkEncryption(fs, useIncomingKeys, incomingLcgEncryptionKeys);

                if (utf.IsEncrypted)
                {
                    // write (decrypted) utf header to file 
                    utf.UtfTableFile = utf.WriteTableToTempFile(fs, offset, 4);

                    using (FileStream checkFs = File.Open(utf.UtfTableFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        utf.MagicBytes = ParseFile.ParseSimpleOffset(checkFs, utf.BaseOffset, 4);
                    }


                    //utf.IsEncrypted = false; // since we've decrypted to a temp file
                    // utf.UtfReader.IsEncrypted = false;
                }
                
                if (ParseFile.CompareSegment(utf.MagicBytes, 0, SIGNATURE_BYTES))
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!String.IsNullOrEmpty(utf.UtfTableFile))
                {
                    File.Delete(utf.UtfTableFile);
                }
            }

            return ret;
        }
    }

    public class CriUtfReader
    {
        public byte Seed { set; get; }
        public byte Increment { set; get; }
        public bool IsEncrypted { set; get; }
        
        public byte CurrentXor { set; get; }
        public long CurrentUtfOffset { set; get; }

        public byte CurrentStringXor { set; get; }
        public long CurrentUtfStringOffset { set; get; }

        public CriUtfReader()
        {
            this.IsEncrypted = false;
        }

        public CriUtfReader(byte seed, byte increment, bool isEncrypted)
        {
            this.Seed = seed;
            this.Increment = increment;
            this.IsEncrypted = isEncrypted;
        }

        public byte[] GetBytes(FileStream fs, long BaseOffset, int Size, long UtfOffset)
        {
            byte[] ret;

            ret = ParseFile.ParseSimpleOffset(fs, BaseOffset + UtfOffset, Size);

            if (this.IsEncrypted)
            {               
                if (UtfOffset < this.CurrentUtfOffset)
                {
                    // reset, maybe add some sort of index later?
                    this.CurrentUtfOffset = 0;
                }

                if (this.CurrentUtfOffset == 0)
                {
                    // reset or initialize
                    this.CurrentXor = this.Seed;
                }

                // catch up to this offset
                for (long j = this.CurrentUtfOffset; j < UtfOffset; j++)
                {
                    if (j > 0)
                    {
                        this.CurrentXor *= this.Increment;
                    }

                    this.CurrentUtfOffset++;
                }

                // decrypt this offset
                for (long i = 0; i < Size; i++)
                {
                    // first byte of UTF table must be XOR'd with the seed
                    if ((this.CurrentUtfOffset != 0) || (i > 0))
                    {
                        this.CurrentXor *= this.Increment;                        
                    }

                    ret[i] ^= this.CurrentXor;
                    this.CurrentUtfOffset++;
                }
            }
            
            return ret;
        }

        public string ReadAsciiString(FileStream fs, long BaseOffset, long UtfOffset)
        {
            byte encryptedByte;
            byte decryptedByte;

            StringBuilder asciiVal =  new StringBuilder();
            byte xorByte;
            long fileSize = fs.Length;

            if (this.IsEncrypted)
            {
                fs.Position = (BaseOffset + UtfOffset);

                if (UtfOffset < this.CurrentUtfStringOffset)
                {
                    // reset, maybe add some sort of index later?
                    this.CurrentUtfStringOffset = 0;
                }

                if (this.CurrentUtfStringOffset == 0)
                {
                    // reset or initialize
                    this.CurrentStringXor = this.Seed;
                }

                for (long j = this.CurrentUtfStringOffset; j < UtfOffset; j++)
                {
                    if (j > 0)
                    {
                        this.CurrentStringXor *= this.Increment;
                    }

                    this.CurrentUtfStringOffset++;
                }

                for (long i = UtfOffset; i < (fileSize - (BaseOffset + UtfOffset)); i++)
                {
                    this.CurrentStringXor *= this.Increment;
                    this.CurrentUtfStringOffset++;

                    encryptedByte = (byte)fs.ReadByte();
                    decryptedByte = (byte)(encryptedByte ^ this.CurrentStringXor);

                    if (decryptedByte == 0)
                    {
                        break;
                    }
                    else
                    {
                        asciiVal.Append(Convert.ToChar(decryptedByte));
                    }                    
                }
            }
            else
            {
                asciiVal.Append(ParseFile.ReadAsciiString(fs, BaseOffset + UtfOffset));
            }
            
            return asciiVal.ToString();
        }

        public byte ReadByte(FileStream fs, long BaseOffset, long UtfOffset)
        {
            return this.GetBytes(fs, BaseOffset, 1, UtfOffset)[0];
        }

        public SByte ReadSByte(FileStream fs, long BaseOffset, long UtfOffset)
        {
            return (SByte)this.GetBytes(fs, BaseOffset, 1, UtfOffset)[0];
        }

        public ushort ReadUshort(FileStream fs, long BaseOffset, long UtfOffset)
        {
            byte[] temp = this.GetBytes(fs, BaseOffset, 2, UtfOffset);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(temp);
            }
            return BitConverter.ToUInt16(temp, 0);
        }

        public short ReadShort(FileStream fs, long BaseOffset, long UtfOffset)
        {
            byte[] temp = this.GetBytes(fs, BaseOffset, 2, UtfOffset);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(temp);
            }
            return BitConverter.ToInt16(temp, 0);
        }

        public uint ReadUint(FileStream fs, long BaseOffset, long UtfOffset)
        {
            byte[] temp = this.GetBytes(fs, BaseOffset, 4, UtfOffset);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(temp);
            }
            return BitConverter.ToUInt32(temp, 0);
        }

        public int ReadInt(FileStream fs, long BaseOffset, long UtfOffset)
        {
            byte[] temp = this.GetBytes(fs, BaseOffset, 4, UtfOffset);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(temp);
            }
            return BitConverter.ToInt32(temp, 0);
        }

        public ulong ReadUlong(FileStream fs, long BaseOffset, long UtfOffset)
        {
            byte[] temp = this.GetBytes(fs, BaseOffset, 8, UtfOffset);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(temp);
            }
            return BitConverter.ToUInt64(temp, 0);
        }

        public float ReadFloat(FileStream fs, long BaseOffset, long UtfOffset)
        {
            byte[] temp = this.GetBytes(fs, BaseOffset, 4, UtfOffset);

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(temp);
            }
            return BitConverter.ToSingle(temp, 0);
        }
    }
}