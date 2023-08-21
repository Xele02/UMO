using System;
using UnityEngine;
using System.Collections.Generic;

namespace ExternLib
{
#if !UNITY_ANDROID
    public static partial class LibCriWare
    {
        private class AtomPluginData
        {
            public bool isInitialized = false;
        }
        static AtomPluginData atomPluginData = new AtomPluginData();

        public static void CRIWARE6B0DCA88_criAtomUnity_Initialize()
        {
            atomPluginData.isInitialized = true;
        }

        public static bool CRIWARE73A63785_criAtomUnity_IsInitialized()
        {
            return atomPluginData.isInitialized;
        }

        public static void CRIWARE111A4C56_criAtomUnity_Finalize()
        {
            atomPluginData.isInitialized = false;
        }

        public static void CRIWARE2DDFB51C_criAtomUnity_SetBeatSyncCallback(IntPtr cbfunc)
        {
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "CRIWARE2DDFB51C_criAtomUnity_SetBeatSyncCallback");
        }

        public static void criAtomUnity_ExecuteQueuedCueLinkCallbacks()
        {
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "criAtomUnity_ExecuteQueuedCueLinkCallbacks");
		}

        public static void CRIWARE148BE2F8_criAtomUnitySequencer_ExecuteQueuedEventCallbacks()
        {
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "CRIWARE148BE2F8_criAtomUnitySequencer_ExecuteQueuedEventCallbacks");
		}

        public static void CRIWARE75F073A2_criAtomUnity_ExecuteQueuedBeatSyncCallbacks()
        {
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "CRIWARE75F073A2_criAtomUnity_ExecuteQueuedBeatSyncCallbacks");
		}

        public static void CRIWARE59269F98_criAtomUnity_Pause(bool pause)
		{
			TodoLogger.LogError(TodoLogger.CriAtomPlugin, "CRIWARE59269F98_criAtomUnity_Pause");
		}
        public static ushort CRIWARE2178C0A8_criAtomUnity_GetNativeParameterId(int id)
        {
            TodoLogger.LogError(TodoLogger.CriAtomPlugin, "CRIWARE2178C0A8_criAtomUnity_GetNativeParameterId");
            return 0;
        }
    }
#endif
}
