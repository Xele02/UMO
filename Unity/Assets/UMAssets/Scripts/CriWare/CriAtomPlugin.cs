using System.Collections.Generic;
using System;
using UnityEngine;

namespace CriWare {
	public static class CriAtomPlugin
	{
#if UNITY_EDITOR
		public static bool showDebugLog = false;
		public delegate void PreviewCallback();
		public static PreviewCallback previewCallback = null;
#endif

		private static int initializationCount = 0; // 0x0
		private static List<IntPtr> effectInterfaceList = null; // 0x4
		private static bool isConfigured = false; // 0x8
		private static float timeSinceStartup = Time.realtimeSinceStartup; // 0xC
		private static CriWare.Common.CpuUsage cpuUsage; // 0x10
		private static int CRIATOMUNITY_PARAMETER_ID_LOOP_COUNT = 0; // 0x1C
		private static ushort CRIATOMPARAMETER2_ID_INVALID = ushort.MaxValue; // 0x20
		// private static ulong temporalStorage = 0; // 0x28

		public static bool isInitialized { get { return initializationCount > 0; } } // 0x28B1260

		// // RVA: 0x28B125C Offset: 0x28B125C VA: 0x28B125C
		// public static void Log(string log) { }

		// // RVA: 0x28B12F8 Offset: 0x28B12F8 VA: 0x28B12F8
		// public static bool GetAudioEffectInterfaceList(out List<IntPtr> effect_interface_list) { }

		// // RVA: 0x28B1480 Offset: 0x28B1480 VA: 0x28B1480
		// private static IntPtr GetSpatializerCoreInterfaceFromAtomOculusAudioBridge() { }

		// // RVA: 0x28B181C Offset: 0x28B181C VA: 0x28B181C
		public static void SetConfigParameters(int max_virtual_voices, int max_voice_limit_groups, int max_categories, int max_sequence_events_per_frame, int max_beatsync_callbacks_per_frame, int max_cuelink_callbacks_per_frame, int num_standard_memory_voices, int num_standard_streaming_voices, int num_hca_mx_memory_voices, int num_hca_mx_streaming_voices, int output_sampling_rate, int num_asr_output_channels, bool uses_in_game_preview, float server_frequency, int max_parameter_blocks, int categories_per_playback, int num_buses, bool vr_mode)
		{
			TodoLogger.Log(5, "TODO");
		}

		// // RVA: 0x28B1B0C Offset: 0x28B1B0C VA: 0x28B1B0C
		public static void SetConfigMonitorParametes(int max_preview_objects, int communication_buffer_size, int playback_position_update_interval)
		{
			TodoLogger.Log(5, "SetConfigMonitorParametes");
		}

		// // RVA: 0x28B1CB4 Offset: 0x28B1CB4 VA: 0x28B1CB4
		public static void SetConfigAdditionalParameters_PC(long buffering_time_pc)
		{
			TodoLogger.Log(5, "SetConfigAdditionalParameters_PC");
		}

		// // RVA: 0x28B1E4C Offset: 0x28B1E4C VA: 0x28B1E4C
		public static void SetConfigAdditionalParameters_LINUX(CriAtomConfig.LinuxOutput output, int pulse_latency_usec)
		{
			TodoLogger.Log(5, "SetConfigAdditionalParameters_LINUX");
		}

		// // RVA: 0x28B1FE4 Offset: 0x28B1FE4 VA: 0x28B1FE4
		public static void SetConfigAdditionalParameters_IOS(bool enable_sonicsync, uint buffering_time_ios, bool override_ipod_music_ios)
		{
			TodoLogger.Log(5, "SetConfigAdditionalParameters_IOS");
		}

		// // RVA: 0x28B218C Offset: 0x28B218C VA: 0x28B218C
		public static void SetConfigAdditionalParameters_ANDROID(bool enable_sonicsync, int num_low_delay_memory_voices, int num_low_delay_streaming_voices, int sound_buffering_time, int sound_start_buffering_time, bool use_fast_mixer, bool use_aaudio)
		{
			TodoLogger.Log(5, "SetConfigAdditionalParameters_ANDROID");
		}

		// // RVA: 0x28B284C Offset: 0x28B284C VA: 0x28B284C
		public static void SetConfigAdditionalParameters_VITA(int num_atrac9_memory_voices, int num_atrac9_streaming_voices, int num_mana_decoders)
		{
			TodoLogger.Log(5, "SetConfigAdditionalParameters_VITA");
		}

		// // RVA: 0x28B2850 Offset: 0x28B2850 VA: 0x28B2850
		public static void SetConfigAdditionalParameters_PS4(int num_atrac9_memory_voices, int num_atrac9_streaming_voices, bool use_audio3d, int num_audio3d_memory_voices, int num_audio3d_streaming_voices)
		{
			TodoLogger.Log(5, "SetConfigAdditionalParameters_PS4");
		}

		// // RVA: 0x28B2854 Offset: 0x28B2854 VA: 0x28B2854
		public static void SetConfigAdditionalParameters_SWITCH(int num_opus_memory_voices, int num_opus_streaming_voices, bool init_socket)
		{
			TodoLogger.Log(5, "SetConfigAdditionalParameters_SWITCH");
		}

		// // RVA: 0x28B2858 Offset: 0x28B2858 VA: 0x28B2858
		public static void SetConfigAdditionalParameters_WEBGL(int num_webaudio_voices)
		{
			TodoLogger.Log(5, "SetConfigAdditionalParameters_WEBGL");
		}

		// // RVA: 0x28B285C Offset: 0x28B285C VA: 0x28B285C
		// public static void SetMaxSamplingRateForStandardVoicePool(int sampling_rate_for_memory, int sampling_rate_for_streaming) { }

		// // RVA: 0x28B29F4 Offset: 0x28B29F4 VA: 0x28B29F4
		public static int GetRequiredMaxVirtualVoices(CriAtomConfig atomConfig)
		{
			TodoLogger.Log(5, "GetRequiredMaxVirtualVoices");
			return 20;
		}

		// // RVA: 0x28B2AB8 Offset: 0x28B2AB8 VA: 0x28B2AB8
		public static void InitializeLibrary()
		{
			CriAtomPlugin.initializationCount++;
			if (CriAtomPlugin.initializationCount != 1) {
				return;
			}

			if (CriAtomPlugin.IsLibraryInitialized() == true) {
				CriAtomPlugin.FinalizeLibrary();
				CriAtomPlugin.initializationCount = 1;
			}

			if (CriAtomPlugin.isConfigured == false) {
				Debug.Log("[CRIWARE] Atom initialization parameters are not configured. "
					+ "Initializes Atom by default parameters.");
			}

			CriFsPlugin.InitializeLibrary();

			CriAtomPlugin.CRIWARE6B0DCA88_criAtomUnity_Initialize();

			if(effectInterfaceList != null)
			{
				for(int i = 0; i < effectInterfaceList.Count; i++)
				{
					TodoLogger.Log(0, "call effectInterfaceList RegisterEffectInterface");
				}
			}

			#if UNITY_EDITOR
			if (UnityEngine.Application.isPlaying) {
				CriAtomServer.CreateInstance();
			}
			#else
			CriAtomServer.CreateInstance();
			#endif

			CriAtomListener.CreateDummyNativeListener();
		}

		// // RVA: 0x28A1A5C Offset: 0x28A1A5C VA: 0x28A1A5C
		public static bool IsLibraryInitialized()
		{
			return CRIWARE73A63785_criAtomUnity_IsInitialized();
		}

		// // RVA: 0x28B2E64 Offset: 0x28B2E64 VA: 0x28B2E64
		public static void FinalizeLibrary()
		{
			CriAtomPlugin.initializationCount--;
			if (CriAtomPlugin.initializationCount < 0) {
				CriAtomPlugin.initializationCount = 0;
				if (CriAtomPlugin.IsLibraryInitialized() == false) {
					return;
				}
			}
			if (CriAtomPlugin.initializationCount != 0) {
				return;
			}

			CriAtomListener.DestroyDummyNativeListener();

			CriAtomServer.DestroyInstance();

			CriDisposableObjectManager.CallOnModuleFinalization(CriDisposableObjectManager.ModuleType.Atom);

			if (effectInterfaceList != null) {
				effectInterfaceList.Clear();
				effectInterfaceList = null;
			}

			CriAtomPlugin.CRIWARE111A4C56_criAtomUnity_Finalize();

			CriFsPlugin.FinalizeLibrary();
		}

		// // RVA: 0x28B36C4 Offset: 0x28B36C4 VA: 0x28B36C4
		public static void Pause(bool pause)
		{
			if (isInitialized) {
				CRIWARE59269F98_criAtomUnity_Pause(pause);
			}
		}

		// // RVA: 0x28B3884 Offset: 0x28B3884 VA: 0x28B3884
		// public static Common.CpuUsage GetCpuUsage() { }

		// // RVA: 0x28AA560 Offset: 0x28AA560 VA: 0x28AA560
		public static ushort GetLoopCountParameterId()
		{
			ushort ret = CRIWARE2178C0A8_criAtomUnity_GetNativeParameterId(CRIATOMUNITY_PARAMETER_ID_LOOP_COUNT);
			if (ret == CRIATOMPARAMETER2_ID_INVALID) {
				throw new Exception("GetNativeParameterId failed.");
			}
			return ret;
		}

		// // RVA: 0x28B3BB4 Offset: 0x28B3BB4 VA: 0x28B3BB4
		// public static void DecryptAcb(IntPtr acb_hn, ulong key, ulong nonce) { }

		// [MonoPInvokeCallbackAttribute] // RVA: 0x6353A4 Offset: 0x6353A4 VA: 0x6353A4
		// // RVA: 0x28B11D0 Offset: 0x28B11D0 VA: 0x28B11D0
		// private static ulong CallbackFromNative(IntPtr ptr1) { }

		// // RVA: 0x28B19A0 Offset: 0x28B19A0 VA: 0x28B19A0
		// private static extern void CRIWARE496A3B2F(int max_virtual_voices, int max_voice_limit_groups, int max_categories, int max_sequence_events_per_frame, int max_beatsync_callbacks_per_frame, int max_cuelink_callbacks_per_frame, int num_standard_memory_voices, int num_standard_streaming_voices, int num_hca_mx_memory_voices, int num_hca_mx_streaming_voices, int output_sampling_rate, int num_asr_output_channels, bool uses_in_game_preview, float server_frequency, int max_parameter_blocks, int categories_per_playback, int num_buses, bool use_ambisonics, IntPtr spatializer_core_interface) { }

		// // RVA: 0x28B1BA0 Offset: 0x28B1BA0 VA: 0x28B1BA0
		// private static extern void CRIWARE5486CB0C(uint max_preivew_objects, uint communication_buffer_size, int playback_position_update_interval) { }

		// // RVA: 0x28B1D40 Offset: 0x28B1D40 VA: 0x28B1D40
		// private static extern void CRIWARE986A7557(long buffering_time_pc) { }

		// // RVA: 0x28B1ED8 Offset: 0x28B1ED8 VA: 0x28B1ED8
		// private static extern void CRIWARE1EF773FF(int output, int pulse_latency_usec) { }

		// // RVA: 0x28B2078 Offset: 0x28B2078 VA: 0x28B2078
		// private static extern void CRIWAREA8DDE932(bool enable_sonicsync, uint buffering_time_ios, bool override_ipod_music_ios) { }

		// // RVA: 0x28B2510 Offset: 0x28B2510 VA: 0x28B2510
		// private static extern void CRIWARE7300EC66(bool enable_sonicsync, int num_low_delay_memory_voices, int num_low_delay_streaming_voices, int sound_buffering_time, int sound_start_buffering_time, bool apply_hw_property) { }

		// // RVA: 0x28B2640 Offset: 0x28B2640 VA: 0x28B2640
		// private static extern void CRIWAREB80BEF9C(IntPtr android_context) { }

		// // RVA: 0x28B2748 Offset: 0x28B2748 VA: 0x28B2748
		// private static extern void CRIWARE1DC61BE9(bool flag) { }

		// // RVA: 0x28B3160 Offset: 0x28B3160 VA: 0x28B3160
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE6B0DCA88_criAtomUnity_Initialize();
		#else
		private static void CRIWARE6B0DCA88_criAtomUnity_Initialize()
		{
			ExternLib.LibCriWare.CRIWARE6B0DCA88_criAtomUnity_Initialize();
		}
		#endif

		// // RVA: 0x28B3388 Offset: 0x28B3388 VA: 0x28B3388
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		public static extern bool CRIWARE73A63785_criAtomUnity_IsInitialized();
		#else
		public static bool CRIWARE73A63785_criAtomUnity_IsInitialized()
		{
			return ExternLib.LibCriWare.CRIWARE73A63785_criAtomUnity_IsInitialized();
		}
		#endif

		// // RVA: 0x28B35D0 Offset: 0x28B35D0 VA: 0x28B35D0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		public static extern bool CRIWARE111A4C56_criAtomUnity_Finalize();
		#else
		private static void CRIWARE111A4C56_criAtomUnity_Finalize()
		{
			ExternLib.LibCriWare.CRIWARE111A4C56_criAtomUnity_Finalize();
		}
		#endif

		// // RVA: 0x28B3780 Offset: 0x28B3780 VA: 0x28B3780
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE59269F98_criAtomUnity_Pause(bool pause);
		#else
		private static void CRIWARE59269F98_criAtomUnity_Pause(bool pause)
		{
			ExternLib.LibCriWare.CRIWARE59269F98_criAtomUnity_Pause(pause);
		}
		#endif

		// // RVA: 0x28B3E00 Offset: 0x28B3E00 VA: 0x28B3E00
		// public static extern uint CRIWARE5C7A47BE() { }

		// // RVA: 0x28B3EF8 Offset: 0x28B3EF8 VA: 0x28B3EF8
		// public static extern void CRIWAREDD99CEC5(int code) { }

		// // RVA: 0x28B4000 Offset: 0x28B4000 VA: 0x28B4000
		// public static extern void CRIWAREA2F80582(IntPtr cbfunc, string separator_string) { }

		// // RVA: 0x28B4128 Offset: 0x28B4128 VA: 0x28B4128
		// public static extern void CRIWAREC42CD834(IntPtr cbfunc) { }

		// // RVA: 0x28B4230 Offset: 0x28B4230 VA: 0x28B4230
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		public static extern void CRIWARE148BE2F8_criAtomUnitySequencer_ExecuteQueuedEventCallbacks();
		#else
		public static void CRIWARE148BE2F8_criAtomUnitySequencer_ExecuteQueuedEventCallbacks()
		{
			ExternLib.LibCriWare.CRIWARE148BE2F8_criAtomUnitySequencer_ExecuteQueuedEventCallbacks();
		}
		#endif

		// // RVA: 0x28B4328 Offset: 0x28B4328 VA: 0x28B4328
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		public static extern void CRIWARE2DDFB51C_criAtomUnity_SetBeatSyncCallback(IntPtr cbfunc);
		#else
		public static void CRIWARE2DDFB51C_criAtomUnity_SetBeatSyncCallback(IntPtr cbfunc)
		{
			ExternLib.LibCriWare.CRIWARE2DDFB51C_criAtomUnity_SetBeatSyncCallback(cbfunc);
		}
		#endif

		// // RVA: 0x28B4430 Offset: 0x28B4430 VA: 0x28B4430
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		public static extern void CRIWARE75F073A2_criAtomUnity_ExecuteQueuedBeatSyncCallbacks();
		#else
		public static void CRIWARE75F073A2_criAtomUnity_ExecuteQueuedBeatSyncCallbacks()
		{
			ExternLib.LibCriWare.CRIWARE75F073A2_criAtomUnity_ExecuteQueuedBeatSyncCallbacks();
		}
		#endif

		// // RVA: 0x28B4528 Offset: 0x28B4528 VA: 0x28B4528
		// public static extern void criAtomUnity_SetCueLinkCallback(IntPtr cbfunc) { }

		// // RVA: 0x28B4608 Offset: 0x28B4608 VA: 0x28B4608
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		public static extern void criAtomUnity_ExecuteQueuedCueLinkCallbacks();
		#else
		public static void criAtomUnity_ExecuteQueuedCueLinkCallbacks()
		{
			ExternLib.LibCriWare.criAtomUnity_ExecuteQueuedCueLinkCallbacks();
		}
		#endif

		// // RVA: 0x28B28E8 Offset: 0x28B28E8 VA: 0x28B28E8
		// private static extern void CRIWAREBF5EE548(int sampling_rate_for_memory, int sampling_rate_for_streaming) { }

		// // RVA: 0x28B46F0 Offset: 0x28B46F0 VA: 0x28B46F0
		// public static extern void CRIWAREB02E50B1() { }

		// // RVA: 0x28B47E8 Offset: 0x28B47E8 VA: 0x28B47E8
		// public static extern void CRIWARE3EE7B6BD() { }

		// // RVA: 0x28B3CE0 Offset: 0x28B3CE0 VA: 0x28B3CE0
		// public static extern void CRIWARE3284CFDB(IntPtr acb_hn, CriAtomPlugin.CallbackFromNativeDelegate func, IntPtr obj) { }

		// // RVA: 0x28B3AB0 Offset: 0x28B3AB0 VA: 0x28B3AB0
		#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		public static extern ushort CRIWARE2178C0A8(int id);
		#endif
		public static ushort CRIWARE2178C0A8_criAtomUnity_GetNativeParameterId(int id)
		{
			#if UNITY_ANDROID
				return CRIWARE2178C0A8(id);
			#else
				return ExternLib.LibCriWare.CRIWARE2178C0A8_criAtomUnity_GetNativeParameterId(id);
			#endif
		}
	}
}