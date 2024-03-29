using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using CriWare;

namespace ExternLib
{
#if !UNITY_ANDROID
    public static partial class LibCriWare
    {
        private static FileInfo GetFileInfo(string path)
        {
            FileInfo fi = new FileInfo(path);
            if(!fi.Exists)
            {
                string nPath = path.Replace(CriWare.Common.streamingAssetsPath, Path.Combine(CriWare.Common.streamingAssetsPath, "../../../Data/"));
                FileInfo tfi = new FileInfo(nPath);
                if(tfi.Exists)
                    fi = tfi;
            }
            return fi;
        }

        public static int criFsInstaller_ExecuteMain()
        {
            foreach(var item in bindList)
            {
                if(item.Value.status == CriFsBinder.Status.Analyze)
                {
                    if(item.Value.fileInfo.Exists)
                    {
                        item.Value.status = CriFsBinder.Status.Complete;
                    }
                    else
                    {
                        item.Value.status = CriFsBinder.Status.Error;
                        TodoLogger.LogError(TodoLogger.Filesystem, "Unable to open "+item.Value.path);
                    }
                }
            }
            return 0;
        }
    }
#endif
}
