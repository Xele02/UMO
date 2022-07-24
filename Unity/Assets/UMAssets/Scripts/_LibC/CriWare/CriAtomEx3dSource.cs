
using System;
using System.Collections.Generic;
using CriWare;

namespace ExternLib
{
    public static partial class LibCriWare
    {
        class SourceInfo
        {
            public CriAtomEx3dSource.Config config;
        }
        static Dictionary<IntPtr, SourceInfo> srcsList = new Dictionary<IntPtr, SourceInfo>();
        static int sourceCnt = 0;

		public static IntPtr criAtomEx3dSource_Create(ref CriAtomEx3dSource.Config config, IntPtr work, int work_size)
        {
            SourceInfo info = new SourceInfo();
            info.config = config;
            IntPtr res = new IntPtr(++sourceCnt);
            srcsList[res] = info;
            return res;
        }

        public static void criAtomEx3dSource_Destroy(IntPtr ex_3d_source)
        {
            if(srcsList.ContainsKey(ex_3d_source))
            {
                srcsList.Remove(ex_3d_source);
            }
        }

        public static void criAtomEx3dSource_Update(IntPtr ex_3d_source)
        {
        }

        public static void criAtomEx3dSource_SetRandomPositionConfig(IntPtr ex_3d_source, ref CriAtomEx.Randomize3dConfig config)
        {
            UnityEngine.Debug.LogError("TODO criAtomEx3dSource_SetRandomPositionConfig");
        }

        public static void criAtomEx3dSource_SetRandomPositionConfig(IntPtr ex_3d_source, IntPtr config)
        {
            if(config == IntPtr.Zero)
                return;
            UnityEngine.Debug.LogError("TODO criAtomEx3dSource_SetRandomPositionConfig");
        }

        public static void criAtomEx3dSource_SetPosition(IntPtr ex_3d_source, ref CriAtomEx.NativeVector position)
        {
        }

        public static void criAtomEx3dSource_SetVelocity(IntPtr ex_3d_source, ref CriAtomEx.NativeVector velocity)
        {
        }

        public static void criAtomEx3dSource_SetOrientation(IntPtr ex_3d_source, ref CriAtomEx.NativeVector front, ref CriAtomEx.NativeVector top)
        {
        }

        public static void criAtomEx3dSource_Set3dRegionHn(IntPtr ex_3d_source, IntPtr ex_3d_region)
        {
            UnityEngine.Debug.LogError("TODO criAtomEx3dSource_Set3dRegionHn");
        }
    }
}