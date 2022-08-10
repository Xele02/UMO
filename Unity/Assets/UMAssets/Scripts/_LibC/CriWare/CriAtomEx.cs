
using System;
using CriWare;

namespace ExternLib
{
    public static partial class LibCriWare
    {
        public static bool criAtomEx_RegisterAcfFile(CriFsBinder binder, string path, IntPtr work, int workSize)
        {
            TodoLogger.Log(5, "criAtomEx_RegisterAcfFile");
            return true;
        }

        public static void criAtomEx_UnregisterAcf()
        {
            
        }

        public static void criAtomEx_SetRandomSeed(uint seed)
        {

        }
        public static void criAtomEx_AttachDspBusSetting(string settingName, IntPtr work, int workSize)
        {

        }

        public static void criAtomEx_DetachDspBusSetting()
        {
            
        }
    }
}