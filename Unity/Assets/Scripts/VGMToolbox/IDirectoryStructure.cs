using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VGMToolbox.format.iso
{
    public interface IDirectoryStructure : IComparable
    {
        string SourceFilePath { set; get; }
        string DirectoryName { set; get; }

        IDirectoryStructure[] SubDirectories { set; get; }
        IFileStructure[] Files { set; get; }

        void Extract(ref Dictionary<string, FileStream> streamCache, string destinationFolder, bool extractAsRaw);
    }
}