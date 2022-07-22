/****************************************************************************
 *
 * Copyright (c) 2013 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using System;
using UnityEngine;
using System.Runtime.InteropServices;
using CriWare;

public static class CriFsPlugin
{
	/* 初期化カウンタ */
	private static int initializationCount = 0;

	private static bool isConfigured = false;

	public static int defaultInstallBufferSize   = 0;
	public static int installBufferSize      = defaultInstallBufferSize;

	public static bool isInitialized { get { return initializationCount > 0; } }

	public static void SetConfigParameters(
		int num_loaders, int num_binders, int num_installers, int argInstallBufferSize, int max_path, bool minimize_file_descriptor_usage, bool dummy_flag)
	{
		CriFsPlugin.criFsUnity_SetConfigParameters(
			num_loaders, num_binders, num_installers, max_path, minimize_file_descriptor_usage, dummy_flag);

		CriFsPlugin.isConfigured = true;
	}

	public static void SetConfigAdditionalParameters_ANDROID(
		int device_read_bps)
	{
#if !UNITY_EDITOR && UNITY_ANDROID
		CriFsPlugin.criFsUnity_SetConfigAdditionalParameters_ANDROID(device_read_bps);
#endif
	}

	public static void InitializeLibrary()
	{
		/* 初期化カウンタの更新 */
		CriFsPlugin.initializationCount++;
		if (CriFsPlugin.initializationCount != 1) {
			return;
		}

		/* シーン実行前に初期化済みの場合は終了させる */
		if (CriFsPlugin.IsLibraryInitialized() == true) {
			CriFsPlugin.FinalizeLibrary();
			CriFsPlugin.initializationCount = 1;
		}

		/* 初期化パラメータが設定済みかどうかを確認 */
		if (CriFsPlugin.isConfigured == false) {
			Debug.Log("[CRIWARE] FileSystem initialization parameters are not configured. "
				+ "Initializes FileSystem by default parameters.");
		}

		/* ライブラリの初期化 */
		CriFsPlugin.criFsUnity_Initialize();
	}

	public static bool IsLibraryInitialized()
	{
		/* ライブラリが初期化済みかチェック */
		return criFsUnity_IsInitialized();
	}

	public static void FinalizeLibrary()
	{
		/* 初期化カウンタの更新 */
		CriFsPlugin.initializationCount--;
		if (CriFsPlugin.initializationCount < 0) {
			CriFsPlugin.initializationCount = 0;
			if (CriFsPlugin.IsLibraryInitialized() == false) {
				return;
			}
		}
		if (CriFsPlugin.initializationCount != 0) {
			return;
		}

		/* パラメータを初期値に戻す */
		installBufferSize = defaultInstallBufferSize;

		/* 未破棄のDisposableを破棄 */
		CriDisposableObjectManager.CallOnModuleFinalization(CriDisposableObjectManager.ModuleType.Fs);

		/* ライブラリの終了 */
		CriFsPlugin.criFsUnity_Finalize();
	}

	#region DLL Import
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criFsUnity_SetConfigParameters(
		int num_loaders, int num_binders, int num_installers, int max_path, bool minimize_file_descriptor_usage, bool dummy_flag);


[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criFsUnity_Initialize();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	public static extern bool criFsUnity_IsInitialized();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criFsUnity_Finalize();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	public static extern uint criFsUnity_GetAllocatedHeapSize();

	#if !UNITY_EDITOR && UNITY_ANDROID
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criFsUnity_SetConfigAdditionalParameters_ANDROID(int device_read_bps);
	#endif
	#endregion
}

public class CriFsBinder
{
	public IntPtr nativeHandle { get { return IntPtr.Zero; } }
};

public static class CriFsUtility
{
	public static void SetUserAgentString(string userAgentString) {}
};

public static class CriManaPlugin
{
	public static uint criManaUnity_GetAllocatedHeapSize() { return 0; }
	public static void SetConfigParameters(bool graphicsMultiThreaded, int num_decoders, int max_num_of_entries) {}
	public static void InitializeLibrary() {}
	public static void FinalizeLibrary() {}
	public static bool IsLibraryInitialized()
	{
		/* ADX2LE では Mana を使用できないので常に false を返す*/
		return false;
	}
};


/* --- end of file --- */
