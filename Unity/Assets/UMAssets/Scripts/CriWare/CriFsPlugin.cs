using UnityEngine;

public static class CriFsPlugin
{
	private static int initializationCount = 0; // 0x0
	private static bool isConfigured = false; // 0x4
	public static int defaultInstallBufferSize = 0x400000; // 0x8
	public static int installBufferSize = 0x400000; // 0xC

	public static bool isInitialized { get { return initializationCount > 0; } } // 0x2949834

	// // RVA: 0x29498CC Offset: 0x29498CC VA: 0x29498CC
	public static void SetConfigParameters(int num_loaders, int num_binders, int num_installers, int argInstallBufferSize, int max_path, bool minimize_file_descriptor_usage, bool enable_crc_check)
	{
		TodoLogger.Log(TodoLogger.CriFsPlugin, "CriFsPlugin.SetConfigParameters");
	}

	// // RVA: 0x2949AD4 Offset: 0x2949AD4 VA: 0x2949AD4
	// public static void SetReadDeviceEnabled(int deviceId, bool enabled) { }

	// // RVA: 0x2949C94 Offset: 0x2949C94 VA: 0x2949C94
	public static void SetConfigAdditionalParameters_ANDROID(int device_read_bps)
	{
		TodoLogger.Log(TodoLogger.CriFsPlugin, "CriFsPlugin.SetConfigAdditionalParameters_ANDROID");
	}

	// // RVA: 0x2949E0C Offset: 0x2949E0C VA: 0x2949E0C
	// public static void SetMemoryFileSystemThreadPriorityExperimentalAndroid(int prio) { }

	// // RVA: 0x2949F88 Offset: 0x2949F88 VA: 0x2949F88
	// public static void SetDataDecompressionThreadPriorityExperimentalAndroid(int prio) { }

	// // RVA: 0x294A100 Offset: 0x294A100 VA: 0x294A100
	public static void InitializeLibrary()
	{
		initializationCount = initializationCount + 1;
		if(initializationCount != 1)
			return;

		if(IsLibraryInitialized())
		{
			FinalizeLibrary();
		}
		if(!isConfigured)
		{
			Debug.Log("[CRIWARE] FileSystem initialization parameters are not configured. Initializes FileSystem by default parameters.");
		}
		CRIWARE1682FBAD();
	}

	// // RVA: 0x29446E4 Offset: 0x29446E4 VA: 0x29446E4
	public static bool IsLibraryInitialized()
	{
		return CRIWARE1FDF7DD5();
	}

	// // RVA: 0x294A2E8 Offset: 0x294A2E8 VA: 0x294A2E8
	public static void FinalizeLibrary()
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0x29499A8 Offset: 0x29499A8 VA: 0x29499A8
	// private static extern void CRIWARE60B91352(int num_loaders, int num_binders, int num_installers, int max_path, bool minimize_file_descriptor_usage, bool enable_crc_check) { }

	// // RVA: 0x294A4E8 Offset: 0x294A4E8 VA: 0x294A4E8
	private static /*extern*/ void CRIWARE1682FBAD()
	{
		ExternLib.LibCriWare.CRIWARE1682FBAD();
	}

	// // RVA: 0x294A5E0 Offset: 0x294A5E0 VA: 0x294A5E0
	public static /*extern */bool CRIWARE1FDF7DD5()
	{
		return ExternLib.LibCriWare.CRIWARE1FDF7DD5();
	}

	// // RVA: 0x294A828 Offset: 0x294A828 VA: 0x294A828
	// private static extern void CRIWAREA56770FF() { }

	// // RVA: 0x294A920 Offset: 0x294A920 VA: 0x294A920
	// public static extern uint CRIWARE0DECC482() { }

	// // RVA: 0x294AA18 Offset: 0x294AA18 VA: 0x294AA18
	// public static extern uint criFsLoader_GetRetryCount() { }

	// // RVA: 0x294AB20 Offset: 0x294AB20 VA: 0x294AB20
	// public static extern int criFs_GetNumBinds(ref int cur, ref int max, ref int limit) { }

	// // RVA: 0x294AC38 Offset: 0x294AC38 VA: 0x294AC38
	// public static extern int criFs_GetNumUsedLoaders(ref int cur, ref int max, ref int limit) { }

	// // RVA: 0x294AD60 Offset: 0x294AD60 VA: 0x294AD60
	// public static extern int criFs_GetNumUsedInstallers(ref int cur, ref int max, ref int limit) { }

	// // RVA: 0x2949BB0 Offset: 0x2949BB0 VA: 0x2949BB0
	// private static extern int criFs_SetReadDeviceEnabled(int device_id, bool enabled) { }

	// // RVA: 0x2949D18 Offset: 0x2949D18 VA: 0x2949D18
	// private static extern void criFsUnity_SetConfigAdditionalParameters_ANDROID(int device_read_bps) { }

	// // RVA: 0x2949E90 Offset: 0x2949E90 VA: 0x2949E90
	// public static extern void criFsUnity_SetMemoryFileSystemThreadPriority_ANDROID(int prio) { }

	// // RVA: 0x294A008 Offset: 0x294A008 VA: 0x294A008
	// public static extern void criFsUnity_SetDataDecompressionThreadPriority_ANDROID(int prio) { }
}
