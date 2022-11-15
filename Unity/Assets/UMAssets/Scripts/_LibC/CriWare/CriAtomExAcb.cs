
using System;
using System.Collections.Generic;
using System.IO;
using CriWare;
using UnityEngine;
using VGMToolbox.format;

namespace ExternLib
{
    public static partial class LibCriWare
    {
		class AcbData
		{
			public CriAcbFile file;
			public Dictionary<string, AudioClip> cachedAudioClips = new Dictionary<string, AudioClip>();
		}

        static Dictionary<IntPtr, AcbData> acbFiles = new Dictionary<IntPtr, AcbData>();
        static int acbCount = 0;

        public static void criAtomExAcb_Release(IntPtr acb_hn)
        {
            TodoLogger.Log(0, "criAtomExAcb_Release");
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
            CriAcbFile file = acbFiles[acb_hn].file;
            CriAcbCueRecord cueRecord = file.GetCueRecord(name);
            if(cueRecord == null)
                return false;
            info.length = cueRecord.LengthMilli;
            TodoLogger.Log(0, "finish criAtomExAcb_GetCueInfoByName");
            return true;
        }

        public static IntPtr criAtomExAcb_LoadAcbFile(CriFsBinder acb_binder, string acb_path, CriFsBinder awb_binder, string awb_path, IntPtr work, int work_size)
        {
            if(acb_binder != null || awb_binder != null)
            {
                TodoLogger.Log(0, "criAtomExAcb_LoadAcbFile with binder");
                return IntPtr.Zero;
            }
            using(FileStream fs = File.Open(acb_path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                CriAcbFile file = new CriAcbFile(fs, 0, false, awb_path);
                IntPtr res = new IntPtr(++acbCount);
                acbFiles[res] = new AcbData();
				acbFiles[res].file = file;
				return res;
            }
        }
    }
}
