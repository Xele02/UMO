using UnityEngine;
using System.Runtime.InteropServices;
using System.IO;

namespace CriWare
{
    public class Common // TypeDefIndex: 5842
    {
        // Fields
        private const string scriptVersionString = "2.37.13";
        private const int scriptVersionNumber = 37163776;
        public const bool supportsCriFsInstaller = true;
        public const bool supportsCriFsWebInstaller = true;
        public const string pluginName = "cri_ware_unity";
        public const CallingConvention pluginCallingConvention = CallingConvention.Winapi;
        private static GameObject _managerObject; // 0x0

        // Properties
        public static string streamingAssetsPath { get; }
        public static string installTargetPath { get; }
        public static GameObject managerObject { get; }

        // Methods

        // // RVA: 0x2BA8AE0 Offset: 0x2BA8AE0 VA: 0x2BA8AE0
        // public static string get_streamingAssetsPath() { }

        // // RVA: 0x2BA8B54 Offset: 0x2BA8B54 VA: 0x2BA8B54
        // public static string get_installTargetPath() { }

        // // RVA: 0x2BA8B84 Offset: 0x2BA8B84 VA: 0x2BA8B84
        public static bool IsStreamingAssetsPath(string path)
        {
            if(!Path.IsPathRooted(path))
            {
                return path.IndexOf(':') == -1;
            }
            return false;
        }

        // // RVA: 0x2BA8C3C Offset: 0x2BA8C3C VA: 0x2BA8C3C
        // public static GameObject get_managerObject() { }

        // // RVA: 0x2BA8E84 Offset: 0x2BA8E84 VA: 0x2BA8E84
        // public static string GetScriptVersionString() { }

        // // RVA: 0x2BA8EE0 Offset: 0x2BA8EE0 VA: 0x2BA8EE0
        // public static int GetScriptVersionNumber() { }

        // // RVA: 0x2BA8EEC Offset: 0x2BA8EEC VA: 0x2BA8EEC
        // public static int GetBinaryVersionNumber() { }

        // // RVA: 0x2BA905C Offset: 0x2BA905C VA: 0x2BA905C
        // public static int GetRequiredBinaryVersionNumber() { }

        // // RVA: 0x2BA9068 Offset: 0x2BA9068 VA: 0x2BA9068
        // public static bool CheckBinaryVersionCompatibility() { }

        // // RVA: 0x2BA9140 Offset: 0x2BA9140 VA: 0x2BA9140
        // public static uint GetFsMemoryUsage() { }

        // // RVA: 0x2BA91BC Offset: 0x2BA91BC VA: 0x2BA91BC
        // public static uint GetAtomMemoryUsage() { }

        // // RVA: 0x2BA9238 Offset: 0x2BA9238 VA: 0x2BA9238
        // public static uint GetManaMemoryUsage() { }

        // // RVA: 0x2BA92B4 Offset: 0x2BA92B4 VA: 0x2BA92B4
        // public static Common.CpuUsage GetAtomCpuUsage() { }

        // // RVA: 0x2BA8F68 Offset: 0x2BA8F68 VA: 0x2BA8F68
        // public static extern int CRIWARED1CDE3A7() { }

        // // RVA: 0x2BA9338 Offset: 0x2BA9338 VA: 0x2BA9338
        // public static extern void criWareUnity_SetRenderingEventOffsetForMana(int offset) { }

        // // RVA: 0x2BA9424 Offset: 0x2BA9424 VA: 0x2BA9424
        // public void .ctor() { }

        // // RVA: 0x2BA942C Offset: 0x2BA942C VA: 0x2BA942C
        // private static void .cctor() { }
    }
}