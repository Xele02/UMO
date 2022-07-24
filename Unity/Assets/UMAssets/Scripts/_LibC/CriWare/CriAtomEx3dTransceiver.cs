
using System;
using CriWare;

namespace ExternLib
{
    public static partial class LibCriWare
    {
        public static IntPtr criAtomEx3dRegion_Create(ref CriAtomEx3dRegion.Config config, IntPtr work, int work_size)
        {
            UnityEngine.Debug.LogError("TODO criAtomEx3dRegion_Create");
            return IntPtr.Zero;
        }

        public static void criAtomEx3dRegion_Destroy(IntPtr ex_3d_region)
        {
            UnityEngine.Debug.LogError("TODO criAtomEx3dRegion_Destroy");
        }
    }
}