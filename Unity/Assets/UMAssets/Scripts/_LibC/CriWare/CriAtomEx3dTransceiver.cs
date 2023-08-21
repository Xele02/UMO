
using System;
using CriWare;

namespace ExternLib
{
#if !UNITY_ANDROID
    public static partial class LibCriWare
    {
        public static IntPtr criAtomEx3dRegion_Create(ref CriAtomEx3dRegion.Config config, IntPtr work, int work_size)
        {
            TodoLogger.LogError(0, "criAtomEx3dRegion_Create");
            return IntPtr.Zero;
        }

        public static void criAtomEx3dRegion_Destroy(IntPtr ex_3d_region)
        {
            TodoLogger.LogError(0, "criAtomEx3dRegion_Destroy");
        }
    }
#endif
}
