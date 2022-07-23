using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VGMToolbox.format.iso
{
    public interface IVolume
    {        
        long VolumeBaseOffset { set; get; }
        string FormatDescription { set; get; }
        VolumeDataType VolumeType { set; get; }
        string VolumeIdentifier { set; get; }
        bool IsRawDump { set; get; }
        IDirectoryStructure[] Directories { set; get; }

        void Initialize(FileStream isoStream, long offset, bool isRawDump);
        void ExtractAll(ref Dictionary<string, FileStream> streamCache, string destintionFolder, bool extractAsRaw);
    }
}