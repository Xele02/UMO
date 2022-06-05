using XeSys;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Core
{
	public class AssetBundleManager : SingletonBehaviour<AssetBundleManager>
	{
		// private static AssetBundleManifest m_AssetBundleManifest; // 0x0
		// private static Dictionary<string, LoadedAssetBundle> m_LoadedAssetBundles; // 0x4
		private static Dictionary<string, int> m_lodingAssetBundle; // 0x8
		private static Dictionary<string, string> m_lodingErrors; // 0xC
		// private static List<AssetBundleLoadOperation> m_InProgressOperations; // 0x10
		private static Dictionary<string, string[]> m_Dependencies; // 0x14
		public static bool isTutorialNow; // 0x18
		public static Dictionary<string, int> m_tutorialAssetMap; // 0x1C
		// [CompilerGeneratedAttribute] // RVA: 0x68F3E4 Offset: 0x68F3E4 VA: 0x68F3E4
		// private static string <BaseAssetBundleInstallPath>k__BackingField; // 0x20
		// [CompilerGeneratedAttribute] // RVA: 0x68F3F4 Offset: 0x68F3F4 VA: 0x68F3F4
		// private static string <StreamingAssetBundlePath>k__BackingField; // 0x24

		public static string BaseAssetBundleInstallPath { get; set; }
		public static string StreamingAssetBundlePath { get; set; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x747BE0 Offset: 0x747BE0 VA: 0x747BE0
		// // RVA: 0xE11F3C Offset: 0xE11F3C VA: 0xE11F3C
		// public static string get_BaseAssetBundleInstallPath() { }

		// [CompilerGeneratedAttribute] // RVA: 0x747BF0 Offset: 0x747BF0 VA: 0x747BF0
		// // RVA: 0xE11FC8 Offset: 0xE11FC8 VA: 0xE11FC8
		// public static void set_BaseAssetBundleInstallPath(string value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x747C00 Offset: 0x747C00 VA: 0x747C00
		// // RVA: 0xE12058 Offset: 0xE12058 VA: 0xE12058
		// public static string get_StreamingAssetBundlePath() { }

		// [CompilerGeneratedAttribute] // RVA: 0x747C10 Offset: 0x747C10 VA: 0x747C10
		// // RVA: 0xE120E4 Offset: 0xE120E4 VA: 0xE120E4
		// public static void set_StreamingAssetBundlePath(string value) { }

		// // RVA: 0xE12174 Offset: 0xE12174 VA: 0xE12174
		public static string GetPlatformName()
		{
			RuntimePlatform platform = Application.platform;
			if(platform == RuntimePlatform.Android)
				return "android";
			else if(platform == RuntimePlatform.IPhonePlayer)
				return "ios";
			//return "unknown";
			return "android"; // Hack for editor play
		}

		// // RVA: 0xE121F4 Offset: 0xE121F4 VA: 0xE121F4
		// protected static bool LoadAssetBundleInternal(string assetBundleName) { }

		// [ConditionalAttribute] // RVA: 0x747C20 Offset: 0x747C20 VA: 0x747C20
		// // RVA: 0xE127E8 Offset: 0xE127E8 VA: 0xE127E8
		// protected static void LoadDependencies(string assetBundleName) { }

		// // RVA: 0xE12A28 Offset: 0xE12A28 VA: 0xE12A28
		// protected static void LoadAssetBundle(string assetBundleName, bool isLoadingAssetBundleManifest = False) { }

		// // RVA: 0xE12AA8 Offset: 0xE12AA8 VA: 0xE12AA8
		// public static AssetBundleLoadAssetOperation LoadAssetAsync(string assetBundleName, string assetName, Type type) { }

		// // RVA: 0xE12BA8 Offset: 0xE12BA8 VA: 0xE12BA8
		// public static UnionAssetBundleLoadOperation LoadUnionAssetBundle(string assetBundleName) { }

		// // RVA: 0xE12C98 Offset: 0xE12C98 VA: 0xE12C98
		// public static ShaderAssetBundleLoadOperation LoadShaderAssetBundle(string assetBundleName) { }

		// // RVA: 0xE12D88 Offset: 0xE12D88 VA: 0xE12D88
		public static AssetBundleLoadAllAssetOperationBase LoadAllAssetAsync(string assetBundleName)
		{
			UnityEngine.Debug.LogError("TODO");
			return null;
		}

		// // RVA: 0xE12E78 Offset: 0xE12E78 VA: 0xE12E78
		// public static AssetBundleLoadLayoutOperationBase LoadLayoutAsync(string assetBundleName, string prefabName) { }

		// // RVA: 0xE12F6C Offset: 0xE12F6C VA: 0xE12F6C
		// public static AssetBundleLoadUGUIOperationBase LoadUGUIAsync(string assetBundleName, string prefabName) { }

		// // RVA: 0xE0F2E0 Offset: 0xE0F2E0 VA: 0xE0F2E0
		// public static LoadedAssetBundle GetLoadedAssetBundle(string assetBundleName, out string error) { }

		// // RVA: 0xE13060 Offset: 0xE13060 VA: 0xE13060
		// public static string MakeAssetBundlePath(string assetBundleName) { }

		// // RVA: 0xE130F4 Offset: 0xE130F4 VA: 0xE130F4
		// public static AssetBundleLoadAllAssetOperationBase LoadDecorationItemAssetAsync(string assetBundleName) { }

		// // RVA: 0xE131E4 Offset: 0xE131E4 VA: 0xE131E4
		public static void UnloadAssetBundle(string assetBundleName, bool unloadAllLoadedObject = false)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x747C54 Offset: 0x747C54 VA: 0x747C54
		// // RVA: 0xE133B0 Offset: 0xE133B0 VA: 0xE133B0
		// public static IEnumerator UnloadAllAssetBundle() { }

		// [ConditionalAttribute] // RVA: 0x747CCC Offset: 0x747CCC VA: 0x747CCC
		// // RVA: 0xE13420 Offset: 0xE13420 VA: 0xE13420
		// protected static void UnloadDependencies(string assetBundleName) { }

		// // RVA: 0xE1326C Offset: 0xE1326C VA: 0xE1326C
		// protected static void UnloadAssetBundleInternal(string assetBundleName, bool unloadAllLoadedObject = False) { }

		// // RVA: 0xE135EC Offset: 0xE135EC VA: 0xE135EC
		// private void Update() { }

		// // RVA: 0xE137F0 Offset: 0xE137F0 VA: 0xE137F0
		// public static void LoadTutorialAssetsList() { }

		// // RVA: 0xE13AEC Offset: 0xE13AEC VA: 0xE13AEC
		// public void .ctor() { }

		// // RVA: 0xE13B50 Offset: 0xE13B50 VA: 0xE13B50
		// private static void .cctor() { }
	}
}
