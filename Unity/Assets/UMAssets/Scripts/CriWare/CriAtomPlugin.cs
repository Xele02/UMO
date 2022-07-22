//using System.Collections.Generic;
//using System;
//using UnityEngine;

//public static class CriAtomPlugin
//{
//	private static int initializationCount = 0; // 0x0
//	private static List<IntPtr> effectInterfaceList = null; // 0x4
//	private static bool isConfigured = false; // 0x8
//	private static float timeSinceStartup = Time.realtimeSinceStartup; // 0xC
//	private static CriWare.Common.CpuUsage cpuUsage; // 0x10
//	private static int CRIATOMUNITY_PARAMETER_ID_LOOP_COUNT = 0; // 0x1C
//	private static ushort CRIATOMPARAMETER2_ID_INVALID = 0xFFFF; // 0x20
//	private static ulong temporalStorage = 0; // 0x28

//	public static bool isInitialized { get { return initializationCount > 0; } } // 0x28B1260

//	// // RVA: 0x28B125C Offset: 0x28B125C VA: 0x28B125C
//	// public static void Log(string log) { }

//	// // RVA: 0x28B12F8 Offset: 0x28B12F8 VA: 0x28B12F8
//	// public static bool GetAudioEffectInterfaceList(out List<IntPtr> effect_interface_list) { }

//	// // RVA: 0x28B1480 Offset: 0x28B1480 VA: 0x28B1480
//	// private static IntPtr GetSpatializerCoreInterfaceFromAtomOculusAudioBridge() { }

//	// // RVA: 0x28B181C Offset: 0x28B181C VA: 0x28B181C
//	public static void SetConfigParameters(int max_virtual_voices, int max_voice_limit_groups, int max_categories, int max_sequence_events_per_frame, int max_beatsync_callbacks_per_frame, int max_cuelink_callbacks_per_frame, int num_standard_memory_voices, int num_standard_streaming_voices, int num_hca_mx_memory_voices, int num_hca_mx_streaming_voices, int output_sampling_rate, int num_asr_output_channels, bool uses_in_game_preview, float server_frequency, int max_parameter_blocks, int categories_per_playback, int num_buses, bool vr_mode)
//    {
//        UnityEngine.Debug.LogWarning("TODO");
//    }

//	// // RVA: 0x28B1B0C Offset: 0x28B1B0C VA: 0x28B1B0C
//	public static void SetConfigMonitorParametes(int max_preview_objects, int communication_buffer_size, int playback_position_update_interval)
//    {
//        UnityEngine.Debug.LogWarning("TODO SetConfigMonitorParametes");
//    }

//	// // RVA: 0x28B1CB4 Offset: 0x28B1CB4 VA: 0x28B1CB4
//	public static void SetConfigAdditionalParameters_PC(long buffering_time_pc)
//    {
//        UnityEngine.Debug.LogWarning("TODO SetConfigAdditionalParameters_PC");
//    }

//	// // RVA: 0x28B1E4C Offset: 0x28B1E4C VA: 0x28B1E4C
//	public static void SetConfigAdditionalParameters_LINUX(CriAtomConfig.LinuxOutput output, int pulse_latency_usec)
//    {
//        UnityEngine.Debug.LogWarning("TODO SetConfigAdditionalParameters_LINUX");
//    }

//	// // RVA: 0x28B1FE4 Offset: 0x28B1FE4 VA: 0x28B1FE4
//	public static void SetConfigAdditionalParameters_IOS(bool enable_sonicsync, uint buffering_time_ios, bool override_ipod_music_ios)
//    {
//        UnityEngine.Debug.LogWarning("TODO SetConfigAdditionalParameters_IOS");
//    }

//	// // RVA: 0x28B218C Offset: 0x28B218C VA: 0x28B218C
//	public static void SetConfigAdditionalParameters_ANDROID(bool enable_sonicsync, int num_low_delay_memory_voices, int num_low_delay_streaming_voices, int sound_buffering_time, int sound_start_buffering_time, bool use_fast_mixer, bool use_aaudio)
//    {
//        UnityEngine.Debug.LogWarning("TODO SetConfigAdditionalParameters_ANDROID");
//    }

//	// // RVA: 0x28B284C Offset: 0x28B284C VA: 0x28B284C
//	public static void SetConfigAdditionalParameters_VITA(int num_atrac9_memory_voices, int num_atrac9_streaming_voices, int num_mana_decoders)
//    {
//        UnityEngine.Debug.LogWarning("TODO SetConfigAdditionalParameters_VITA");
//    }

//	// // RVA: 0x28B2850 Offset: 0x28B2850 VA: 0x28B2850
//	public static void SetConfigAdditionalParameters_PS4(int num_atrac9_memory_voices, int num_atrac9_streaming_voices, bool use_audio3d, int num_audio3d_memory_voices, int num_audio3d_streaming_voices)
//    {
//        UnityEngine.Debug.LogWarning("TODO SetConfigAdditionalParameters_PS4");
//    }

//	// // RVA: 0x28B2854 Offset: 0x28B2854 VA: 0x28B2854
//	public static void SetConfigAdditionalParameters_SWITCH(int num_opus_memory_voices, int num_opus_streaming_voices, bool init_socket)
//    {
//        UnityEngine.Debug.LogWarning("TODO SetConfigAdditionalParameters_SWITCH");
//    }

//	// // RVA: 0x28B2858 Offset: 0x28B2858 VA: 0x28B2858
//	public static void SetConfigAdditionalParameters_WEBGL(int num_webaudio_voices)
//    {
//        UnityEngine.Debug.LogWarning("TODO SetConfigAdditionalParameters_WEBGL");
//    }

//	// // RVA: 0x28B285C Offset: 0x28B285C VA: 0x28B285C
//	// public static void SetMaxSamplingRateForStandardVoicePool(int sampling_rate_for_memory, int sampling_rate_for_streaming) { }

//	// // RVA: 0x28B29F4 Offset: 0x28B29F4 VA: 0x28B29F4
//	public static int GetRequiredMaxVirtualVoices(CriAtomConfig atomConfig)
//    {
//        UnityEngine.Debug.LogWarning("TODO GetRequiredMaxVirtualVoices");
//        return 20;
//    }

//	// // RVA: 0x28B2AB8 Offset: 0x28B2AB8 VA: 0x28B2AB8
//	public static void InitializeLibrary()
//    {
//        UnityEngine.Debug.LogWarning("TODO CriAtom InitializeLibrary");
//    }

//	// // RVA: 0x28A1A5C Offset: 0x28A1A5C VA: 0x28A1A5C
//	public static bool IsLibraryInitialized()
//    {
//        return CRIWARE73A63785();
//    }

//	// // RVA: 0x28B2E64 Offset: 0x28B2E64 VA: 0x28B2E64
//	public static void FinalizeLibrary()
//    {
//        UnityEngine.Debug.LogError("TODO");
//    }

//	// // RVA: 0x28B36C4 Offset: 0x28B36C4 VA: 0x28B36C4
//	// public static void Pause(bool pause) { }

//	// // RVA: 0x28B3884 Offset: 0x28B3884 VA: 0x28B3884
//	// public static Common.CpuUsage GetCpuUsage() { }

//	// // RVA: 0x28AA560 Offset: 0x28AA560 VA: 0x28AA560
//	// public static ushort GetLoopCountParameterId() { }

//	// // RVA: 0x28B3BB4 Offset: 0x28B3BB4 VA: 0x28B3BB4
//	// public static void DecryptAcb(IntPtr acb_hn, ulong key, ulong nonce) { }

//	// [MonoPInvokeCallbackAttribute] // RVA: 0x6353A4 Offset: 0x6353A4 VA: 0x6353A4
//	// // RVA: 0x28B11D0 Offset: 0x28B11D0 VA: 0x28B11D0
//	// private static ulong CallbackFromNative(IntPtr ptr1) { }

//	// // RVA: 0x28B19A0 Offset: 0x28B19A0 VA: 0x28B19A0
//	// private static extern void CRIWARE496A3B2F(int max_virtual_voices, int max_voice_limit_groups, int max_categories, int max_sequence_events_per_frame, int max_beatsync_callbacks_per_frame, int max_cuelink_callbacks_per_frame, int num_standard_memory_voices, int num_standard_streaming_voices, int num_hca_mx_memory_voices, int num_hca_mx_streaming_voices, int output_sampling_rate, int num_asr_output_channels, bool uses_in_game_preview, float server_frequency, int max_parameter_blocks, int categories_per_playback, int num_buses, bool use_ambisonics, IntPtr spatializer_core_interface) { }

//	// // RVA: 0x28B1BA0 Offset: 0x28B1BA0 VA: 0x28B1BA0
//	// private static extern void CRIWARE5486CB0C(uint max_preivew_objects, uint communication_buffer_size, int playback_position_update_interval) { }

//	// // RVA: 0x28B1D40 Offset: 0x28B1D40 VA: 0x28B1D40
//	// private static extern void CRIWARE986A7557(long buffering_time_pc) { }

//	// // RVA: 0x28B1ED8 Offset: 0x28B1ED8 VA: 0x28B1ED8
//	// private static extern void CRIWARE1EF773FF(int output, int pulse_latency_usec) { }

//	// // RVA: 0x28B2078 Offset: 0x28B2078 VA: 0x28B2078
//	// private static extern void CRIWAREA8DDE932(bool enable_sonicsync, uint buffering_time_ios, bool override_ipod_music_ios) { }

//	// // RVA: 0x28B2510 Offset: 0x28B2510 VA: 0x28B2510
//	// private static extern void CRIWARE7300EC66(bool enable_sonicsync, int num_low_delay_memory_voices, int num_low_delay_streaming_voices, int sound_buffering_time, int sound_start_buffering_time, bool apply_hw_property) { }

//	// // RVA: 0x28B2640 Offset: 0x28B2640 VA: 0x28B2640
//	// private static extern void CRIWAREB80BEF9C(IntPtr android_context) { }

//	// // RVA: 0x28B2748 Offset: 0x28B2748 VA: 0x28B2748
//	// private static extern void CRIWARE1DC61BE9(bool flag) { }

//	// // RVA: 0x28B3160 Offset: 0x28B3160 VA: 0x28B3160
//	// private static extern void CRIWARE6B0DCA88() { }

//	// // RVA: 0x28B3388 Offset: 0x28B3388 VA: 0x28B3388
//	public static /*extern*/ bool CRIWARE73A63785()
//    {
//        return ExternLib.LibCriWare.CRIWARE73A63785();
//    }

//	// // RVA: 0x28B35D0 Offset: 0x28B35D0 VA: 0x28B35D0
//	// private static extern void CRIWARE111A4C56() { }

//	// // RVA: 0x28B3780 Offset: 0x28B3780 VA: 0x28B3780
//	// private static extern void CRIWARE59269F98(bool pause) { }

//	// // RVA: 0x28B3E00 Offset: 0x28B3E00 VA: 0x28B3E00
//	// public static extern uint CRIWARE5C7A47BE() { }

//	// // RVA: 0x28B3EF8 Offset: 0x28B3EF8 VA: 0x28B3EF8
//	// public static extern void CRIWAREDD99CEC5(int code) { }

//	// // RVA: 0x28B4000 Offset: 0x28B4000 VA: 0x28B4000
//	// public static extern void CRIWAREA2F80582(IntPtr cbfunc, string separator_string) { }

//	// // RVA: 0x28B4128 Offset: 0x28B4128 VA: 0x28B4128
//	// public static extern void CRIWAREC42CD834(IntPtr cbfunc) { }

//	// // RVA: 0x28B4230 Offset: 0x28B4230 VA: 0x28B4230
//	// public static extern void CRIWARE148BE2F8() { }

//	// // RVA: 0x28B4328 Offset: 0x28B4328 VA: 0x28B4328
//	// public static extern void CRIWARE2DDFB51C(IntPtr cbfunc) { }

//	// // RVA: 0x28B4430 Offset: 0x28B4430 VA: 0x28B4430
//	// public static extern void CRIWARE75F073A2() { }

//	// // RVA: 0x28B4528 Offset: 0x28B4528 VA: 0x28B4528
//	// public static extern void criAtomUnity_SetCueLinkCallback(IntPtr cbfunc) { }

//	// // RVA: 0x28B4608 Offset: 0x28B4608 VA: 0x28B4608
//	// public static extern void criAtomUnity_ExecuteQueuedCueLinkCallbacks() { }

//	// // RVA: 0x28B28E8 Offset: 0x28B28E8 VA: 0x28B28E8
//	// private static extern void CRIWAREBF5EE548(int sampling_rate_for_memory, int sampling_rate_for_streaming) { }

//	// // RVA: 0x28B46F0 Offset: 0x28B46F0 VA: 0x28B46F0
//	// public static extern void CRIWAREB02E50B1() { }

//	// // RVA: 0x28B47E8 Offset: 0x28B47E8 VA: 0x28B47E8
//	// public static extern void CRIWARE3EE7B6BD() { }

//	// // RVA: 0x28B3CE0 Offset: 0x28B3CE0 VA: 0x28B3CE0
//	// public static extern void CRIWARE3284CFDB(IntPtr acb_hn, CriAtomPlugin.CallbackFromNativeDelegate func, IntPtr obj) { }

//	// // RVA: 0x28B3AB0 Offset: 0x28B3AB0 VA: 0x28B3AB0
//	// public static extern ushort CRIWARE2178C0A8(int id) { }
//}
