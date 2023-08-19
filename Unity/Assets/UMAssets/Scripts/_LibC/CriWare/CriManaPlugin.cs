using System;
using UnityEngine;
using System.Collections.Generic;

namespace ExternLib
{
#if !UNITY_ANDROID
    public static partial class LibCriWare
    {
        private class ManaPluginData
        {
            public bool isInitialized = false;
        }
        static ManaPluginData manaPluginData = new ManaPluginData();

        public static void CRIWARE9CF52E96_criManaUnity_Initialize()
        {
            manaPluginData.isInitialized = true;
        }

        public static void CRIWAREDC8B0D52_criManaUnity_Finalize()
        {
            manaPluginData.isInitialized = false;
        }

        public static bool CRIWARE50D2CE6F() /*IsLibraryInitialized*/
        {
            return manaPluginData.isInitialized;
        }
    }
#endif
}