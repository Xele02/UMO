using System;
using UnityEngine;
using System.Collections.Generic;

namespace ExternLib
{
    public static partial class LibCriWare
    {
        private class AtomPluginData
        {
            public bool isInitialized = false;
        }
        static AtomPluginData atomPluginData = new AtomPluginData();


        public static bool CRIWARE73A63785() /*IsLibraryInitialized*/
        {
            return atomPluginData.isInitialized;
        }
    }
}