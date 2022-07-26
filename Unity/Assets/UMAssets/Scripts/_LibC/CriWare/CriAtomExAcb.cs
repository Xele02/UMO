
using System;
using System.Collections.Generic;
using System.IO;
using CriWare;
using VGMToolbox.format;

namespace ExternLib
{
    public static partial class LibCriWare
    {
        static Dictionary<IntPtr, CriAcbFile> acbFiles = new Dictionary<IntPtr, CriAcbFile>();
        static int acbCount = 0;

        public static void criAtomExAcb_Release(IntPtr acb_hn)
        {
            UnityEngine.Debug.LogError("TODO criAtomExAcb_Release");
            if(acbFiles.ContainsKey(acb_hn))
            {
                acbFiles.Remove(acb_hn);
            }
        }

        public static bool criAtomExAcb_GetCueInfoByName(IntPtr acb_hn, string name, out CriAtomEx.CueInfo info)
        {
            info = new CriAtomEx.CueInfo();
            if(!acbFiles.ContainsKey(acb_hn))
                return false;
            CriAcbFile file = acbFiles[acb_hn];
            CriAcbCueRecord cueRecord = file.GetCueRecord(name);
            if(cueRecord == null)
                return false;
            info.length = cueRecord.LengthMilli;
            UnityEngine.Debug.LogError("TODO finish criAtomExAcb_GetCueInfoByName");
            return true;
        }

        public static IntPtr criAtomExAcb_LoadAcbFile(CriFsBinder acb_binder, string acb_path, CriFsBinder awb_binder, string awb_path, IntPtr work, int work_size)
        {
            if(acb_binder != null || awb_binder != null)
            {
                UnityEngine.Debug.LogError("TODO criAtomExAcb_LoadAcbFile with binder");
                return IntPtr.Zero;
            }
            using(FileStream fs = File.Open(acb_path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                CriAcbFile file = new CriAcbFile(fs, 0, false, awb_path);
                IntPtr res = new IntPtr(++acbCount);
                acbFiles[res] = file;
                return res;
            }
        }
    }
}
