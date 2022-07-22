using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;

namespace ExternLib
{
    public static partial class LibCriWare
    {
        private static FileInfo GetFileInfo(string path)
        {
            FileInfo fi = new FileInfo(path);
            if(!fi.Exists)
            {
                string nPath = path.Replace(CriWare.streamingAssetsPath, Path.Combine(CriWare.streamingAssetsPath, "../../../Data/"));
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
                        UnityEngine.Debug.LogError("Unable to open "+item.Value.path);
                    }
                }
            }
            return 0;
        }
    }
}
