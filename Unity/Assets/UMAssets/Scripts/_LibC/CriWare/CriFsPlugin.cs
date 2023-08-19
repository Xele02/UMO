using System;
using UnityEngine;
using System.Collections.Generic;

namespace ExternLib
{
#if !UNITY_ANDROID
    public static partial class LibCriWare
    {
        private class FsPluginData
        {
            public bool isInitialized = false;
        }
        static FsPluginData fsPluginData = new FsPluginData();


        public static bool CRIWARE1FDF7DD5() /*IsLibraryInitialized*/
        {
            return fsPluginData.isInitialized;
        }

        public static void CRIWARE1682FBAD()
        {
            fsPluginData.isInitialized = true;
        }
    }
#endif
}