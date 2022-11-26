using UnityEngine;
using System.Runtime.InteropServices;
using System.IO;

namespace CriWare
{
    public class Common
    {
        public struct CpuUsage
        {
            public float last; // 0x0
            public float average; // 0x4
            public float peak; // 0x8
        }

        private const string scriptVersionString = "2.37.13";
        private const int scriptVersionNumber = 37163776;
        public const bool supportsCriFsInstaller = true;
        public const bool supportsCriFsWebInstaller = true;
        public const string pluginName = "cri_ware_unity";
        public const CallingConvention pluginCallingConvention = CallingConvention.Winapi;
        private static GameObject _managerObject; // 0x0

        public static string streamingAssetsPath { get {
            if(Application.platform == RuntimePlatform.Android)
            {
                return "";
            }
            return Application.streamingAssetsPath;
        } } // 0x2BA8AE0
        public static string installTargetPath { get {
            if(Application.platform == RuntimePlatform.IPhonePlayer)
            {
                return Application.temporaryCachePath;
            }
            return Application.persistentDataPath;
        } } // 0x2BA8B54
        public static GameObject managerObject { get {
            if(_managerObject == null)
            {
                _managerObject = GameObject.Find("/CRIWARE");
                if(_managerObject == null)
                {
                    _managerObject = new GameObject("CRIWARE");
                }
            }
            return _managerObject;
        } } // 0x2BA8C3C

        // // RVA: 0x2BA8B84 Offset: 0x2BA8B84 VA: 0x2BA8B84
        public static bool IsStreamingAssetsPath(string path)
        {
            if(!Path.IsPathRooted(path))
            {
                return path.IndexOf(':') == -1;
            }
            return false;
        }

        // // RVA: 0x2BA8E84 Offset: 0x2BA8E84 VA: 0x2BA8E84
        // public static string GetScriptVersionString() { }

        // // RVA: 0x2BA8EE0 Offset: 0x2BA8EE0 VA: 0x2BA8EE0
        // public static int GetScriptVersionNumber() { }

        // // RVA: 0x2BA8EEC Offset: 0x2BA8EEC VA: 0x2BA8EEC
        public static int GetBinaryVersionNumber()
        {
            return CRIWARED1CDE3A7_criWareUnity_GetVersionNumber();
        }

        // // RVA: 0x2BA905C Offset: 0x2BA905C VA: 0x2BA905C
        public static int GetRequiredBinaryVersionNumber()
        {
            #if true
            return 0x02371300;
            #else
                #if UNITY_EDITOR
                        switch (Application.platform) {
                            case RuntimePlatform.WindowsEditor:
                                return 0x02371300;
                            case RuntimePlatform.OSXEditor:
                                return 0x02371300;
                            default:
                                return 0x02371300;
                        }
                #elif UNITY_STANDALONE_WIN
                        return 0x02371300;
                #elif UNITY_STANDALONE_OSX
                        return 0x02371300;
                #elif UNITY_IOS
                        return 0x02371300;
                #elif UNITY_TVOS
                        return 0x02371300;
                #elif UNITY_ANDROID
                        return 0x02371300;
                #else
                        return 0x02371300
                #endif
            #endif
        }

        // // RVA: 0x2BA9068 Offset: 0x2BA9068 VA: 0x2BA9068
        public static bool CheckBinaryVersionCompatibility()
        {
            if (GetBinaryVersionNumber() == GetRequiredBinaryVersionNumber()) {
                return true;
            } else {
                Debug.LogError("CRI runtime library is not compatible. Confirm the version number.");
                return false;
            }
        }

        // // RVA: 0x2BA9140 Offset: 0x2BA9140 VA: 0x2BA9140
        // public static uint GetFsMemoryUsage() { }

        // // RVA: 0x2BA91BC Offset: 0x2BA91BC VA: 0x2BA91BC
        // public static uint GetAtomMemoryUsage() { }

        // // RVA: 0x2BA9238 Offset: 0x2BA9238 VA: 0x2BA9238
        // public static uint GetManaMemoryUsage() { }

        // // RVA: 0x2BA92B4 Offset: 0x2BA92B4 VA: 0x2BA92B4
        // public static Common.CpuUsage GetAtomCpuUsage() { }

        // // RVA: 0x2BA8F68 Offset: 0x2BA8F68 VA: 0x2BA8F68
        #if UNITY_ANDROID
        [DllImport(pluginName, CallingConvention = pluginCallingConvention)]
        public static extern int CRIWARED1CDE3A7_criWareUnity_GetVersionNumber();
        #else
        public static int CRIWARED1CDE3A7_criWareUnity_GetVersionNumber()
        {
            return ExternLib.LibCriWare.CRIWARED1CDE3A7_criWareUnity_GetVersionNumber();
        }
        #endif

        // // RVA: 0x2BA9338 Offset: 0x2BA9338 VA: 0x2BA9338
        // public static extern void criWareUnity_SetRenderingEventOffsetForMana(int offset) { }
    }
}
