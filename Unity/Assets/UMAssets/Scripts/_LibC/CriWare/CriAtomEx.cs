
using System;
using CriWare;

namespace ExternLib
{
#if !UNITY_ANDROID
    public static partial class LibCriWare
    {
        public static bool criAtomEx_RegisterAcfFile(CriFsBinder binder, string path, IntPtr work, int workSize)
        {
            TodoLogger.LogError(TodoLogger.CriAtomExLib, "CriAtomExLib.criAtomEx_RegisterAcfFile");
            return true;
        }

        public static void criAtomEx_UnregisterAcf()
        {
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "CriAtomExLib.criAtomEx_UnregisterAcf");
		}

        public static void criAtomEx_SetRandomSeed(uint seed)
        {
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "CriAtomExLib.criAtomEx_SetRandomSeed");
		}
        public static void criAtomEx_AttachDspBusSetting(string settingName, IntPtr work, int workSize)
        {
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "CriAtomExLib.criAtomEx_AttachDspBusSetting");
		}

        public static void criAtomEx_DetachDspBusSetting()
        {
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "CriAtomExLib.criAtomEx_DetachDspBusSetting");
		}
    }
#endif
}
