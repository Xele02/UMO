using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using VGMToolbox.util;

namespace VGMToolbox.format
{
    public class CriAcbCueRecord
    {
        public uint CueId { set; get; }
        public byte ReferenceType { set; get; }
        public ushort ReferenceIndex { set; get; }

        public bool IsWaveformIdentified { set; get; }
        public ushort WaveformIndex { set; get; }
        public ushort WaveformId { set; get; }
        public byte EncodeType { set; get; }
        public bool IsStreaming { set; get; }

        public string OriginalCueName { set; get; }
        public string CueName { set; get; }
        public uint LengthMilli { set; get; }
    }
    
    public class CriAcbFile : CriUtfTable
    {
        public const string EXTRACTION_FOLDER_FORMAT = "_vgmt_acb_ext_{0}";
        public static readonly string ACB_AWB_EXTRACTION_FOLDER = "acb" + Path.DirectorySeparatorChar + "awb";
        public static readonly string ACB_CPK_EXTRACTION_FOLDER = "acb" + Path.DirectorySeparatorChar + "cpk";
        public static readonly string EXT_AWB_EXTRACTION_FOLDER = "awb";
        public static readonly string EXT_CPK_EXTRACTION_FOLDER = "cpk";

        public const byte WAVEFORM_ENCODE_TYPE_ADX = 0;
        public const byte WAVEFORM_ENCODE_TYPE_HCA = 2;
        public const byte WAVEFORM_ENCODE_TYPE_HCA_ALT = 6;
        public const byte WAVEFORM_ENCODE_TYPE_VAG = 7;        
        public const byte WAVEFORM_ENCODE_TYPE_ATRAC3 = 8;
        public const byte WAVEFORM_ENCODE_TYPE_BCWAV = 9;
        public const byte WAVEFORM_ENCODE_TYPE_ATRAC9 = 11;
        public const byte WAVEFORM_ENCODE_TYPE_NINTENDO_DSP = 13;

        public const string AWB_FORMAT1 = "{0}_streamfiles.awb";
        public const string AWB_FORMAT2 = "{0}.awb";
        public const string AWB_FORMAT3 = "{0}_STR.awb";

        protected enum AwbToExtract { Internal, External };


        public CriAcbFile(FileStream fs, long offset, bool includeCueIdInFileName)
        {
            // initialize UTF
            this.Initialize(fs, offset);
            
            // initialize ACB specific items
            this.InitializeCueList(fs);
            this.InitializeCueNameToWaveformMap(fs, includeCueIdInFileName);
                       
            // initialize internal AWB
            if (this.InternalAwbFileSize > 0)
            {
                if (CriAfs2Archive.IsCriAfs2Archive(fs, (long)this.InternalAwbFileOffset))
                {
                    this.InternalAwb = new CriAfs2Archive(fs, (long)this.InternalAwbFileOffset);
                }
                else if (CriCpkArchive.IsCriCpkArchive(fs, (long)this.InternalAwbFileOffset))
                {
                    this.InternalCpk = new CriCpkArchive();
                    this.InternalCpk.Initialize(fs, (long)this.InternalAwbFileOffset, true);
                }
            }

            // initialize external AWB

            // @TODO: This isn't correct for files with CPKs
            if ((this.StreamAwbAfs2HeaderSize > 0) ||
                (!ByteConversion.IsZeroFilledByteArray(this.StreamAwbHash)))
            {
                // get external file name
                this.StreamfilePath = this.GetStreamfilePath();

                // get file type
                using (FileStream awbFs = File.Open(this.StreamfilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    // AWB
                    if (CriAfs2Archive.IsCriAfs2Archive(awbFs, 0))
                    {
                        this.ExternalAwb = new CriAfs2Archive(awbFs, 0);
                    }
                    // CPK
                    else if (CriCpkArchive.IsCriCpkArchive(awbFs, 0))
                    {
                        this.ExternalCpk = new CriCpkArchive();
                        this.ExternalCpk.Initialize(awbFs, 0, true);
                    }
                }
            }
        }

        public string Name 
        {
            get 
            { 
                return (string)CriUtfTable.GetUtfFieldForRow(this, 0, "Name"); 
            }
        }
        public string VersionString
        {
            get
            {
                return (string)CriUtfTable.GetUtfFieldForRow(this, 0, "VersionString");
            }
        }

        public ulong InternalAwbFileOffset
        {
            get 
            {
                return (ulong)CriUtfTable.GetOffsetForUtfFieldForRow(this, 0, "AwbFile");                
            }
        
        }
        public ulong InternalAwbFileSize
        {
            get
            {
                return (ulong)CriUtfTable.GetSizeForUtfFieldForRow(this, 0, "AwbFile");
            }

        }

        public ulong CueTableOffset
        {
            get
            {
                return CriUtfTable.GetOffsetForUtfFieldForRow(this, 0, "CueTable");
            }
        }
        public ulong CueNameTableOffset
        {
            get
            {
                return CriUtfTable.GetOffsetForUtfFieldForRow(this, 0, "CueNameTable");
            }
        }
        public ulong WaveformTableOffset
        {
            get
            {
                return CriUtfTable.GetOffsetForUtfFieldForRow(this, 0, "WaveformTable");
            }
        }
        public ulong SynthTableOffset
        {
            get
            {
                return CriUtfTable.GetOffsetForUtfFieldForRow(this, 0, "SynthTable");
            }
        }

        public CriAcbCueRecord[] CueList { set; get; }
        public Dictionary<string, ushort> CueNamesToWaveforms { set; get; }

        public byte[] AcfMd5Hash
        {
            get
            {
                return (byte[])CriUtfTable.GetUtfFieldForRow(this, 0, "AcfMd5Hash");
            }        
        }
        public ulong AwbFileOffset
        {
            get
            {
                return CriUtfTable.GetOffsetForUtfFieldForRow(this, 0, "AwbFile");
            }        
        }
        public CriAfs2Archive InternalAwb { set; get; }
        public CriCpkArchive InternalCpk { set; get; }

        public byte[] StreamAwbHash
        {
            get 
            {
                return (byte[])CriUtfTable.GetUtfFieldForRow(this, 0, "StreamAwbHash");
            }
        }
        public ulong StreamAwbAfs2HeaderOffset
        {
            get
            {
                return (ulong)CriUtfTable.GetOffsetForUtfFieldForRow(this, 0, "StreamAwbAfs2Header");
            }
        }
        public ulong StreamAwbAfs2HeaderSize
        {
            get
            {
                return (ulong)CriUtfTable.GetSizeForUtfFieldForRow(this, 0, "StreamAwbAfs2Header");
            }
        }
        public string StreamfilePath { set; get; }
        public CriAfs2Archive ExternalAwb { set; get; }
        public CriCpkArchive ExternalCpk { set; get; }

        public void ExtractAll()
        { 
            string baseExtractionFolder = Path.Combine(Path.GetDirectoryName(this.SourceFile),
                                                       String.Format(EXTRACTION_FOLDER_FORMAT, Path.GetFileNameWithoutExtension(this.SourceFile)));
                  
            this.ExtractAllUsingCueList(baseExtractionFolder);
        }

        
        protected void InitializeCueNameToWaveformMap(FileStream fs, bool includeCueIdInFileName)
        {
            ushort cueIndex;
            string cueName;
                        
            CriUtfTable cueNameTableUtf = new CriUtfTable();
            cueNameTableUtf.Initialize(fs, (long)this.CueNameTableOffset);

            for (int i = 0; i < cueNameTableUtf.NumberOfRows; i++)
            {
                cueIndex = (ushort)CriUtfTable.GetUtfFieldForRow(cueNameTableUtf, i, "CueIndex");

                // skip cues with unidentified waveforms (see 'vc05_0140.acb, vc10_0372.acb' in Kidou_Senshi_Gundam_AGE_Universe_Accel (PSP))
                if (this.CueList[cueIndex].IsWaveformIdentified)
                {
                    cueName = (string)CriUtfTable.GetUtfFieldForRow(cueNameTableUtf, i, "CueName");

                    this.CueList[cueIndex].OriginalCueName = cueName;
                    this.CueList[cueIndex].CueName = cueName;
                    this.CueList[cueIndex].CueName += CriAcbFile.GetFileExtensionForEncodeType(this.CueList[cueIndex].EncodeType);

                    if (includeCueIdInFileName)
                    {
                        this.CueList[cueIndex].CueName = String.Format("{0}_{1}",
                            this.CueList[cueIndex].CueId.ToString("D5"), this.CueList[cueIndex].CueName);
                    }

                    this.CueNamesToWaveforms.Add(this.CueList[cueIndex].CueName, this.CueList[cueIndex].WaveformId);
                }
            }              
        }

        protected void InitializeCueList(FileStream fs)
        {
            this.CueNamesToWaveforms = new Dictionary<string, ushort>();

            ulong referenceItemsOffset = 0;
            ulong referenceItemsSize = 0;
            ulong referenceCorrection = 0;

            object dummy;
            byte isStreaming = 0;

            CriUtfTable cueTableUtf = new CriUtfTable();
            cueTableUtf.Initialize(fs, (long)this.CueTableOffset);

            CriUtfTable waveformTableUtf = new CriUtfTable();
            waveformTableUtf.Initialize(fs, (long)this.WaveformTableOffset);

            CriUtfTable synthTableUtf = new CriUtfTable();
            synthTableUtf.Initialize(fs, (long)this.SynthTableOffset);

            this.CueList = new CriAcbCueRecord[cueTableUtf.NumberOfRows];

            for (int i = 0; i < cueTableUtf.NumberOfRows; i++)
            {
                this.CueList[i] = new CriAcbCueRecord();
                this.CueList[i].IsWaveformIdentified = false;

                this.CueList[i].CueId = (uint)CriUtfTable.GetUtfFieldForRow(cueTableUtf, i, "CueId");
                this.CueList[i].ReferenceType = (byte)CriUtfTable.GetUtfFieldForRow(cueTableUtf, i, "ReferenceType");
                this.CueList[i].ReferenceIndex = (ushort)CriUtfTable.GetUtfFieldForRow(cueTableUtf, i, "ReferenceIndex");
                this.CueList[i].LengthMilli = (uint)CriUtfTable.GetUtfFieldForRow(cueTableUtf, i, "Length");

                switch (this.CueList[i].ReferenceType)
                {
                    case 2:
                        referenceItemsOffset = (ulong)CriUtfTable.GetOffsetForUtfFieldForRow(synthTableUtf, this.CueList[i].ReferenceIndex, "ReferenceItems");
                        referenceItemsSize = CriUtfTable.GetSizeForUtfFieldForRow(synthTableUtf, this.CueList[i].ReferenceIndex, "ReferenceItems");
                        referenceCorrection = referenceItemsSize + 2;
                        break;
                    case 3:
                    case 8:
                        if (i == 0) 
                        {
                            referenceItemsOffset = (ulong)CriUtfTable.GetOffsetForUtfFieldForRow(synthTableUtf, 0, "ReferenceItems");
                            referenceItemsSize = CriUtfTable.GetSizeForUtfFieldForRow(synthTableUtf, 0, "ReferenceItems");
                            referenceCorrection = referenceItemsSize - 2; // samples found have only had a '01 00' record => Always Waveform[0]?.                       
                        }
                        else
                        {
                            referenceCorrection += 4; // relative to previous offset, do not lookup
                                                      // @TODO: Should this do a referenceItemsSize - 2 for the ReferenceIndex?  Need to find 
                                                      //    one where size > 4.
                            //referenceItemsOffset = (ulong)CriUtfTable.GetOffsetForUtfFieldForRow(synthTableUtf, this.CueList[i].ReferenceIndex, "ReferenceItems");
                            //referenceItemsSize = CriUtfTable.GetSizeForUtfFieldForRow(synthTableUtf, this.CueList[i].ReferenceIndex, "ReferenceItems");
                            //referenceCorrection = referenceItemsSize - 2;
                        }
                        break;
                    default:
                        throw new FormatException(String.Format("  Unexpected ReferenceType: '{0}' for CueIndex: '{1}.'  Please report to VGMToolbox thread at hcs64.com forums, see link in 'Other' menu item.", this.CueList[i].ReferenceType.ToString("D"), i.ToString("D")));
                }

                if (referenceItemsSize != 0)
                {
                    // get wave form info
                    this.CueList[i].WaveformIndex = ParseFile.ReadUshortBE(fs, (long)(referenceItemsOffset + referenceCorrection));

                    // get Streaming flag, 0 = in ACB files, 1 = in AWB file
                    dummy = CriUtfTable.GetUtfFieldForRow(waveformTableUtf, this.CueList[i].WaveformIndex, "Streaming");

                    if (dummy != null) // check to see if this Id actually exists in the WaveformIndex
                    {
                        isStreaming = (byte)dummy;
                        this.CueList[i].IsStreaming = isStreaming == 0 ? false : true;

                        // get waveform id and encode type from corresponding waveform
                        var waveformId = CriUtfTable.GetUtfFieldForRow(waveformTableUtf, this.CueList[i].WaveformIndex, "Id");

                        if (waveformId != null)
                        {
                            // early revisions of ACB spec used "Id"
                            this.CueList[i].WaveformId = (ushort)waveformId;
                        }
                        else
                        {
                            // later versions using "MemoryAwbId" and  "StreamingAwbId"
                            if (this.CueList[i].IsStreaming)
                            {
                                this.CueList[i].WaveformId = (ushort)CriUtfTable.GetUtfFieldForRow(waveformTableUtf, this.CueList[i].WaveformIndex, "StreamAwbId");
                            }
                            else
                            {
                                this.CueList[i].WaveformId = (ushort)CriUtfTable.GetUtfFieldForRow(waveformTableUtf, this.CueList[i].WaveformIndex, "MemoryAwbId");
                            }
                        }

                        this.CueList[i].EncodeType = (byte)CriUtfTable.GetUtfFieldForRow(waveformTableUtf, this.CueList[i].WaveformIndex, "EncodeType");


                        // update flag
                        this.CueList[i].IsWaveformIdentified = true;
                    } // if (dummy != null)
                }                
            }
        }


        // @TODO: Need to update this for Internal/External CPK
        protected void ExtractAwbWithCueNames(string destinationFolder, AwbToExtract whichAwb)
        {
            CriUtfTable waveformTableUtf;
            byte encodeType;
            string rawFileName;
            
            CriAfs2Archive awb;
            string rawFileFormat = "{0}_{1}{2}";

            if (whichAwb == AwbToExtract.Internal)
            {
                awb = this.InternalAwb;
            }
            else
            {
                awb = this.ExternalAwb;
            }

            using (FileStream fs = File.Open(awb.SourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                // use files names for internal AWB
                foreach (string key in this.CueNamesToWaveforms.Keys)
                {
                    // extract file
                    ParseFile.ExtractChunkToFile64(fs,
                        (ulong)awb.Files[this.CueNamesToWaveforms[key]].FileOffsetByteAligned,
                        (ulong)awb.Files[this.CueNamesToWaveforms[key]].FileLength,
                        Path.Combine(destinationFolder, FileUtil.CleanFileName(key)), false, false);
                }

                //-------------------------------------
                // extract any items without a CueName
                //-------------------------------------
                using (FileStream acbStream = File.Open(this.SourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    waveformTableUtf = new CriUtfTable();
                    waveformTableUtf.Initialize(acbStream, (long)this.WaveformTableOffset);
                }

                // get list of unextracted files
                var unextractedFiles = awb.Files.Keys.Where(x => !this.CueNamesToWaveforms.ContainsValue(x));
                foreach (ushort key in unextractedFiles)
                {
                    encodeType = (byte)CriUtfTable.GetUtfFieldForRow(waveformTableUtf, key, "EncodeType");

                    rawFileName = String.Format(rawFileFormat,
                        Path.GetFileNameWithoutExtension(awb.SourceFile), key.ToString("D5"), 
                        CriAcbFile.GetFileExtensionForEncodeType(encodeType));

                    // extract file
                    ParseFile.ExtractChunkToFile64(fs,
                        (ulong)awb.Files[key].FileOffsetByteAligned,
                        (ulong)awb.Files[key].FileLength,
                        Path.Combine(destinationFolder, rawFileName), false, false);
                }
            }
        }

        protected void ExtractAllUsingCueList(string destinationFolder)
        {
            CriUtfTable waveformTableUtf;
            ushort waveformIndex;
            byte encodeType;
            string rawFileName;
            string rawFileFormat = "{0}.{1}{2}";
            
            FileStream internalFs = null;
            FileStream externalFs = null;

            ArrayList internalIdsExtracted = new ArrayList();
            ArrayList externalIdsExtracted = new ArrayList();

            string acbAwbDestinationFolder = Path.Combine(destinationFolder, ACB_AWB_EXTRACTION_FOLDER);
            string extAwbDestinationFolder = Path.Combine(destinationFolder, EXT_AWB_EXTRACTION_FOLDER);
            string acbCpkDestinationFolder = Path.Combine(destinationFolder, ACB_CPK_EXTRACTION_FOLDER);
            string extCpkDestinationFolder = Path.Combine(destinationFolder, EXT_CPK_EXTRACTION_FOLDER);

            try
            {
                // open streams
                if (this.InternalAwb != null)
                {
                    internalFs = File.Open(this.InternalAwb.SourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                }
                else if (this.InternalCpk != null)
                {
                    internalFs = File.Open(this.InternalCpk.SourceFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                }

                if (this.ExternalAwb != null)
                {
                    externalFs = File.Open(this.ExternalAwb.SourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                }
                else if (this.ExternalCpk != null)
                {
                    externalFs = File.Open(this.ExternalCpk.SourceFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                }
                
                // loop through cues and extract
                for (int i = 0; i < CueList.Length; i++)
                {
                    CriAcbCueRecord cue = CueList[i];

                    if (cue.IsWaveformIdentified)
                    {
                        if (cue.IsStreaming) // external AWB file
                        {
                            if (this.ExternalAwb != null)
                            {
                                ParseFile.ExtractChunkToFile64(externalFs,
                                    (ulong)this.ExternalAwb.Files[cue.WaveformId].FileOffsetByteAligned,
                                    (ulong)this.ExternalAwb.Files[cue.WaveformId].FileLength,
                                    Path.Combine(extAwbDestinationFolder, FileUtil.CleanFileName(cue.CueName)), false, false);
                            }
                            else if (this.ExternalCpk != null)
                            {
                                ParseFile.ExtractChunkToFile64(externalFs,
                                    (ulong)this.ExternalCpk.ItocFiles[cue.WaveformId].FileOffsetByteAligned,
                                    (ulong)this.ExternalCpk.ItocFiles[cue.WaveformId].FileLength,
                                    Path.Combine(extCpkDestinationFolder, FileUtil.CleanFileName(cue.CueName)), false, false);
                            }

                            externalIdsExtracted.Add(cue.WaveformId);
                        }
                        else // internal AWB file (inside ACB)
                        {
                            if (this.InternalAwb != null)
                            {
                                ParseFile.ExtractChunkToFile64(internalFs,
                                    (ulong)this.InternalAwb.Files[cue.WaveformId].FileOffsetByteAligned,
                                    (ulong)this.InternalAwb.Files[cue.WaveformId].FileLength,
                                    Path.Combine(acbAwbDestinationFolder, FileUtil.CleanFileName(cue.CueName)), false, false);
                            }
                            else if (this.InternalCpk != null)
                            {
                                ParseFile.ExtractChunkToFile64(internalFs,
                                    (ulong)this.InternalCpk.ItocFiles[cue.WaveformId].FileOffsetByteAligned,
                                    (ulong)this.InternalCpk.ItocFiles[cue.WaveformId].FileLength,
                                    Path.Combine(acbCpkDestinationFolder, FileUtil.CleanFileName(cue.CueName)), false, false);
                            }

                            internalIdsExtracted.Add(cue.WaveformId);
                        }
                    } // if (cue.IsWaveformIdentified)                    
                }

                // extract leftovers
                using (FileStream acbStream = File.Open(this.SourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    waveformTableUtf = new CriUtfTable();
                    waveformTableUtf.Initialize(acbStream, (long)this.WaveformTableOffset);
                }

                if (this.ExternalAwb != null)
                {
                    var unextractedExternalFiles = this.ExternalAwb.Files.Keys.Where(x => !externalIdsExtracted.Contains(x));
                    foreach (ushort key in unextractedExternalFiles)
                    {
                        waveformIndex = GetWaveformRowIndexForWaveformId(waveformTableUtf, key, true);

                        encodeType = (byte)CriUtfTable.GetUtfFieldForRow(waveformTableUtf, waveformIndex, "EncodeType");

                        rawFileName = String.Format(rawFileFormat,
                            Path.GetFileName(this.ExternalAwb.SourceFile), key.ToString("D5"),
                            CriAcbFile.GetFileExtensionForEncodeType(encodeType));

                        // extract file
                        ParseFile.ExtractChunkToFile64(externalFs,
                            (ulong)this.ExternalAwb.Files[key].FileOffsetByteAligned,
                            (ulong)this.ExternalAwb.Files[key].FileLength,
                            Path.Combine(extAwbDestinationFolder, rawFileName), false, false);
                    }
                }
                else if (this.ExternalCpk != null)
                {
                    var unextractedExternalFiles = this.ExternalCpk.ItocFiles.Keys.Where(x => !externalIdsExtracted.Contains(x));
                    foreach (ushort key in unextractedExternalFiles)
                    {
                        waveformIndex = GetWaveformRowIndexForWaveformId(waveformTableUtf, key, true);

                        encodeType = (byte)CriUtfTable.GetUtfFieldForRow(waveformTableUtf, waveformIndex, "EncodeType");

                        rawFileName = String.Format(rawFileFormat,
                            Path.GetFileName(this.ExternalCpk.SourceFileName), key.ToString("D5"),
                            CriAcbFile.GetFileExtensionForEncodeType(encodeType));

                        // extract file
                        ParseFile.ExtractChunkToFile64(externalFs,
                            (ulong)this.ExternalCpk.ItocFiles[key].FileOffsetByteAligned,
                            (ulong)this.ExternalCpk.ItocFiles[key].FileLength,
                            Path.Combine(extCpkDestinationFolder, rawFileName), false, false);
                    }
                }

                if (this.InternalAwb != null)
                {
                    var unextractedInternalFiles = this.InternalAwb.Files.Keys.Where(x => !internalIdsExtracted.Contains(x));
                    foreach (ushort key in unextractedInternalFiles)
                    {
                        waveformIndex = GetWaveformRowIndexForWaveformId(waveformTableUtf, key, false);

                        encodeType = (byte)CriUtfTable.GetUtfFieldForRow(waveformTableUtf, waveformIndex, "EncodeType");

                        rawFileName = String.Format(rawFileFormat,
                            Path.GetFileName(this.InternalAwb.SourceFile), key.ToString("D5"),
                            CriAcbFile.GetFileExtensionForEncodeType(encodeType));

                        // extract file
                        ParseFile.ExtractChunkToFile64(internalFs,
                            (ulong)this.InternalAwb.Files[key].FileOffsetByteAligned,
                            (ulong)this.InternalAwb.Files[key].FileLength,
                            Path.Combine(acbAwbDestinationFolder, rawFileName), false, false);
                    }
                }
                else if (this.InternalCpk != null)
                {
                    var unextractedInternalFiles = this.InternalCpk.ItocFiles.Keys.Where(x => !internalIdsExtracted.Contains(x));
                    foreach (ushort key in unextractedInternalFiles)
                    {
                        waveformIndex = GetWaveformRowIndexForWaveformId(waveformTableUtf, key, false);

                        encodeType = (byte)CriUtfTable.GetUtfFieldForRow(waveformTableUtf, waveformIndex, "EncodeType");

                        rawFileName = String.Format(rawFileFormat,
                            Path.GetFileName(this.InternalCpk.SourceFileName), key.ToString("D5"),
                            CriAcbFile.GetFileExtensionForEncodeType(encodeType));

                        // extract file
                        ParseFile.ExtractChunkToFile64(internalFs,
                            (ulong)this.InternalCpk.ItocFiles[key].FileOffsetByteAligned,
                            (ulong)this.InternalCpk.ItocFiles[key].FileLength,
                            Path.Combine(acbCpkDestinationFolder, rawFileName), false, false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (internalFs != null)
                {
                    internalFs.Close();
                    internalFs.Dispose();
                }

                if (externalFs != null)
                {
                    externalFs.Close();
                    externalFs.Dispose();
                }

            }        
        }

        protected string GetStreamfilePath()
        {
            string streamfilePath;

            string awbDirectory;
            string awbMask;
            string acbBaseFileName;
            string[] awbFiles;

            byte[] awbHashStored;
            byte[] awbHashCalculated;

            awbDirectory = Path.GetDirectoryName(this.SourceFile);

            // try format 1
            acbBaseFileName = Path.GetFileNameWithoutExtension(this.SourceFile);
            awbMask = String.Format(AWB_FORMAT1, acbBaseFileName);
            awbFiles = Directory.GetFiles(awbDirectory, awbMask, SearchOption.TopDirectoryOnly);

            if (awbFiles.Length < 1)
            {
                // try format 2
                awbMask = String.Format(AWB_FORMAT2, acbBaseFileName);
                awbFiles = Directory.GetFiles(awbDirectory, awbMask, SearchOption.TopDirectoryOnly);
            }

            if (awbFiles.Length < 1)
            {
                // try format 3
                awbMask = String.Format(AWB_FORMAT3, acbBaseFileName);
                awbFiles = Directory.GetFiles(awbDirectory, awbMask, SearchOption.TopDirectoryOnly);
            }

            // file not found
            if (awbFiles.Length < 1)
            {
                throw new FileNotFoundException(String.Format("Cannot find AWB file. Please verify corresponding AWB file is named '{0}', '{1}', or '{2}'.",
                    String.Format(AWB_FORMAT1, acbBaseFileName), String.Format(AWB_FORMAT2, acbBaseFileName), String.Format(AWB_FORMAT3, acbBaseFileName)));
            }

            if (awbFiles.Length > 1)
            {
                throw new FileNotFoundException(String.Format("More than one matching AWB file for this ACB. Please verify only one AWB file is named '{1}' or '{2}'.",
                    String.Format(AWB_FORMAT1, acbBaseFileName), String.Format(AWB_FORMAT2, acbBaseFileName)));
            }

            // initialize AFS2 file                        
            using (FileStream fs = File.Open(awbFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                awbHashStored = this.StreamAwbHash;

                if (awbHashStored.Length == 0x10) // MD5, hash in newer format unknown
                {
                    // validate MD5 checksum
                    awbHashCalculated = ByteConversion.GetBytesFromHexString(ChecksumUtil.GetMd5OfFullFile(fs));

                    if (!ParseFile.CompareSegment(awbHashCalculated, 0, awbHashStored))
                    {
                        throw new FormatException(String.Format("AWB file, <{0}>, did not match checksum inside ACB file.", Path.GetFileName(fs.Name)));
                    }
                }

                streamfilePath = awbFiles[0];
            }

            return streamfilePath;
        }

        protected CriAfs2Archive InitializeExternalAwbArchive()
        {
            CriAfs2Archive afs2 = null;

            string awbDirectory;
            string awbMask;
            string acbBaseFileName;
            string[] awbFiles;

            byte[] awbHashStored;
            byte[] awbHashCalculated;

            awbDirectory = Path.GetDirectoryName(this.SourceFile);

            // try format 1
            acbBaseFileName = Path.GetFileNameWithoutExtension(this.SourceFile);
            awbMask = String.Format(AWB_FORMAT1, acbBaseFileName);
            awbFiles = Directory.GetFiles(awbDirectory, awbMask, SearchOption.TopDirectoryOnly);

            if (awbFiles.Length < 1)
            {
                // try format 2
                awbMask = String.Format(AWB_FORMAT2, acbBaseFileName);
                awbFiles = Directory.GetFiles(awbDirectory, awbMask, SearchOption.TopDirectoryOnly);
            }

            if (awbFiles.Length < 1)
            {
                // try format 3
                awbMask = String.Format(AWB_FORMAT3, acbBaseFileName);
                awbFiles = Directory.GetFiles(awbDirectory, awbMask, SearchOption.TopDirectoryOnly);
            }

            // file not found
            if (awbFiles.Length < 1)
            {
                throw new FileNotFoundException(String.Format("Cannot find AWB file. Please verify corresponding AWB file is named '{0}', '{1}', or '{2}'.",
                    String.Format(AWB_FORMAT1, acbBaseFileName), String.Format(AWB_FORMAT2, acbBaseFileName), String.Format(AWB_FORMAT3, acbBaseFileName)));
            }

            if (awbFiles.Length > 1)
            {
                throw new FileNotFoundException(String.Format("More than one matching AWB file for this ACB. Please verify only one AWB file is named '{1}' or '{2}'.",
                    String.Format(AWB_FORMAT1, acbBaseFileName), String.Format(AWB_FORMAT2, acbBaseFileName)));
            }

            // initialize AFS2 file                        
            using (FileStream fs = File.Open(awbFiles[0], FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                awbHashStored = this.StreamAwbHash;

                if (awbHashStored.Length == 0x10) // MD5, hash in newer format unknown
                {
                    // validate MD5 checksum
                    awbHashCalculated = ByteConversion.GetBytesFromHexString(ChecksumUtil.GetMd5OfFullFile(fs));

                    if (!ParseFile.CompareSegment(awbHashCalculated, 0, awbHashStored))
                    {
                        throw new FormatException(String.Format("AWB file, <{0}>, did not match checksum inside ACB file.", Path.GetFileName(fs.Name)));
                    }
                }
                
                afs2 = new CriAfs2Archive(fs, 0);
            }

            return afs2;
        }

        public Stream GetCueFileStream(int cueId, out bool isStreamed)
        {
            return GetCueFileStream(GetCueRecord(cueId), out isStreamed);
        }

        public CriAcbCueRecord GetCueRecord(int id)
        {
            // loop through cues and extract
            for (int i = 0; i < CueList.Length; i++)
            {
                CriAcbCueRecord cue = CueList[i];
                //UnityEngine.Debug.LogError(cue.OriginalCueName+" "+cueName);
                if (cue.CueId == id)
                {
                    return cue;
                }
            }
            UnityEngine.Debug.LogError("cue "+id+" not found");
            return null;
        }

        public Stream GetCueFileStream(string cueName, out bool isStreamed)
        {
            return GetCueFileStream(GetCueRecord(cueName), out isStreamed);
        }

        public CriAcbCueRecord GetCueRecord(string cueName)
        {
            // loop through cues and extract
            for (int i = 0; i < CueList.Length; i++)
            {
                CriAcbCueRecord cue = CueList[i];
                //UnityEngine.Debug.LogError(cue.OriginalCueName+" "+cueName);
                if (cue.OriginalCueName == cueName)
                {
                    return cue;
                }
            }
            UnityEngine.Debug.LogError("cue "+cueName+" not found");
            return null;
        }

        private Stream GetCueFileStream(CriAcbCueRecord cue, out bool isStreamed)
        {
            Stream stream = null;
            isStreamed = false;

            if (cue.IsWaveformIdentified)
            {
                if (cue.IsStreaming) // external AWB file
                {
                    isStreamed = true;
                    if (this.ExternalAwb != null)
                    {
                        stream = File.Open(this.ExternalAwb.SourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                        stream.Seek(this.ExternalAwb.Files[cue.WaveformId].FileOffsetByteAligned, SeekOrigin.Begin);
                        long size = this.ExternalAwb.Files[cue.WaveformId].FileLength;
                    }
                    else if (this.ExternalCpk != null)
                    {
                        stream = File.Open(this.ExternalCpk.SourceFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                        stream.Seek(ExternalCpk.ItocFiles[cue.WaveformId].FileOffsetByteAligned, SeekOrigin.Begin);
                        long size = this.ExternalCpk.ItocFiles[cue.WaveformId].FileLength;
                    }
                }
                else // internal AWB file (inside ACB)
                {
                    if (this.InternalAwb != null)
                    {
                        stream = File.Open(this.InternalAwb.SourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                        stream.Seek(this.InternalAwb.Files[cue.WaveformId].FileOffsetByteAligned, SeekOrigin.Begin);
                        long size = this.InternalAwb.Files[cue.WaveformId].FileLength;
                    }
                    else if (this.InternalCpk != null)
                    {
                        stream = File.Open(this.InternalCpk.SourceFileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                        stream.Seek(this.InternalCpk.ItocFiles[cue.WaveformId].FileOffsetByteAligned, SeekOrigin.Begin);
                        long size = this.InternalCpk.ItocFiles[cue.WaveformId].FileLength;
                    }
                }
            } // if (cue.IsWaveformIdentified)
            return stream;
        }

        public static ushort GetWaveformRowIndexForWaveformId(CriUtfTable utfTable, ushort waveformId, bool isStreamed)
        {
            ushort ret = ushort.MaxValue;            

            for (int i = 0; i < utfTable.NumberOfRows; i++)
            {
                var tempId = CriUtfTable.GetUtfFieldForRow(utfTable, i, "Id");

                // newer archives use different labels
                if (tempId == null)
                {
                    if (isStreamed)
                    {
                        tempId = CriUtfTable.GetUtfFieldForRow(utfTable, i, "StreamAwbId");
                    }
                    else
                    {
                        tempId = CriUtfTable.GetUtfFieldForRow(utfTable, i, "MemoryAwbId");
                    }
                }

                if ((ushort)tempId == waveformId)
                {
                    ret = (ushort)i;
                }
            }

            return ret;
        }

        public static string GetFileExtensionForEncodeType(byte encodeType)
        {
            string ext;

            switch (encodeType)
            {
                case WAVEFORM_ENCODE_TYPE_ADX:
                    ext = ".adx";
                    break;
                case WAVEFORM_ENCODE_TYPE_HCA:
                case WAVEFORM_ENCODE_TYPE_HCA_ALT:
                    ext = ".hca";
                    break;
                case WAVEFORM_ENCODE_TYPE_ATRAC3:
                    ext = ".at3";
                    break;
                case WAVEFORM_ENCODE_TYPE_ATRAC9:
                    ext = ".at9";
                    break;
                case WAVEFORM_ENCODE_TYPE_VAG:
                    ext = ".vag";
                    break;
                case WAVEFORM_ENCODE_TYPE_BCWAV:
                    ext = ".bcwav";
                    break;
                case WAVEFORM_ENCODE_TYPE_NINTENDO_DSP:
                    ext = ".dsp";
                    break;
                default:
                    ext = String.Format(".EncodeType-{0}.bin", encodeType.ToString("D2"));
                    break;
            }

            return ext;
        }
    }
}