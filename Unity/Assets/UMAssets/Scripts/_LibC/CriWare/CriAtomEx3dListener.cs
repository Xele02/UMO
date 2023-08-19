
using System;
using System.Collections.Generic;
using CriWare;
using UnityEngine;

namespace ExternLib
{
#if !UNITY_ANDROID
    public static partial class LibCriWare
    {
        public static IntPtr criAtomEx3dListener_Create(ref CriAtomEx3dListener.Config config, IntPtr work, int work_size)
        {
            return IntPtr.Zero;
        }

        public static void criAtomEx3dListener_Destroy(IntPtr ex_3d_listener)
        {
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "criAtomEx3dListener_Destroy");
        }

        public static void criAtomEx3dListener_Update(IntPtr ex_3d_listener)
        {
			TodoLogger.LogError(TodoLogger.CriAtomExLib, "criAtomEx3dListener_Update");
		}
    }
#endif
}
