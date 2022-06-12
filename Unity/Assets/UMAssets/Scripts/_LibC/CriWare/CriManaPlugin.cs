using System;
using UnityEngine;
using System.Collections.Generic;

namespace ExternLib
{
    public static partial class LibCriWare
    {
        private class ManaPluginData
        {
            public bool isInitialized = false;
        }
        static ManaPluginData manaPluginData = new ManaPluginData();


        public static bool CRIWARE50D2CE6F() /*IsLibraryInitialized*/
        {
            return manaPluginData.isInitialized;
        }
    }
}