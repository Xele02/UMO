
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
            if(acbFiles.ContainsKey(acb_hn))
            {
                acbFiles.Remove(acb_hn);
            }
        }

		public static int criAtomExAcb_GetNumCues(IntPtr acb_hn)
		{
			if (!acbFiles.ContainsKey(acb_hn))
				return 0;
			CriAcbFile file = acbFiles[acb_hn].file;
			return file.CueList.Length;
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
            TodoLogger.Log(TodoLogger.CriAtomExLib, "finish criAtomExAcb_GetCueInfoByName");
            return true;
        }

		public static bool criAtomExAcb_GetCueInfoByIndex(IntPtr acb_hn, int index, out CriAtomEx.CueInfo info)
		{
			info = new CriAtomEx.CueInfo();
			if (!acbFiles.ContainsKey(acb_hn))
				return false;
			CriAcbFile file = acbFiles[acb_hn].file;
			CriAcbCueRecord cueRecord = file.GetCueRecord(index);
			if (cueRecord == null)
				return false;
			info.length = cueRecord.LengthMilli;
			TodoLogger.Log(0, "finish criAtomExAcb_GetCueInfoByIndex");
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

		public static void PreloadCue(IntPtr acb_hn, int cueId)
		{
			if (!acbFiles.ContainsKey(acb_hn))
				return;
			string name = "cue_" + cueId;
			if(!acbFiles[acb_hn].cachedAudioClips.ContainsKey(name))
			{
				//UnityEngine.Debug.LogError("Cache sound " + name+" in player "+ acb_hn.ToString());
				acbFiles[acb_hn].cachedAudioClips[name] = GetClip(acbFiles[acb_hn].file, "", cueId);
			}
		}
		public static void PreloadCue(IntPtr acb_hn, string cueName)
		{
			if (!acbFiles.ContainsKey(acb_hn))
				return;
			string name = cueName;
			if (!acbFiles[acb_hn].cachedAudioClips.ContainsKey(name))
			{
				//UnityEngine.Debug.LogError("Cache sound " + name + " in player " + acb_hn.ToString());
				acbFiles[acb_hn].cachedAudioClips[name] = GetClip(acbFiles[acb_hn].file, cueName, -1);
			}
		}

	}
}
