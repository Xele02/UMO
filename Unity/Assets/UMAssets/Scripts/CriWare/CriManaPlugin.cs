
//public class CriManaPlugin
//{
//	private static int initializationCount = 0; // 0x0
//	private static bool isConfigured = false; // 0x4
//	private static bool enabledMultithreadedRendering = false; // 0x5
//	public static int renderingEventOffset = 0x43570000; // 0x8

//	public static bool isInitialized { get { return initializationCount > 0; } } // 0x29648D8
//	public static bool isMultithreadedRenderingEnabled { get { return enabledMultithreadedRendering;} } // 0x2964970

//	// // RVA: 0x29649FC Offset: 0x29649FC VA: 0x29649FC
//	public static void SetConfigParameters(bool graphicsMultiThreaded, int num_decoders, int max_num_of_entries)
//    {
//        UnityEngine.Debug.LogWarning("TODO CriManaPlugin SetConfigParameters");
//    }

//	// // RVA: 0x2964C3C Offset: 0x2964C3C VA: 0x2964C3C
//	// private static void SetupVp9() { }

//	// [ObsoleteAttribute] // RVA: 0x636358 Offset: 0x636358 VA: 0x636358
//	// // RVA: 0x2964F48 Offset: 0x2964F48 VA: 0x2964F48
//	// public static void SetConfigAdditonalParameters_VITA(bool use_h264_playback, int width, int height) { }

//	// // RVA: 0x2964F4C Offset: 0x2964F4C VA: 0x2964F4C
//	// public static void SetConfigAdditonalParameters_PC(bool use_h264_playback) { }

//	// // RVA: 0x2964F50 Offset: 0x2964F50 VA: 0x2964F50
//	public static void SetConfigAdditonalParameters_ANDROID(bool use_h264_playback)
//    {
//        UnityEngine.Debug.LogWarning("TODO CriManaPlugin SetConfigAdditonalParameters_ANDROID");
//    }

//	// // RVA: 0x2965224 Offset: 0x2965224 VA: 0x2965224
//	// public static void SetConfigAdditonalParameters_WEBGL(string webworkerPath, uint heapSize) { }

//	// // RVA: 0x2965228 Offset: 0x2965228 VA: 0x2965228
//	public static void InitializeLibrary()
//    {
//        UnityEngine.Debug.LogWarning("TODO CriManaPlugin InitializeLibrary");
//    }

//	// // RVA: 0x2957C30 Offset: 0x2957C30 VA: 0x2957C30
//	public static bool IsLibraryInitialized()
//    {
//        return CRIWARE50D2CE6F();
//    }

//	// // RVA: 0x296547C Offset: 0x296547C VA: 0x296547C
//	public static void FinalizeLibrary()
//    {
//        UnityEngine.Debug.LogError("TODO");
//    }

//	// // RVA: 0x29659AC Offset: 0x29659AC VA: 0x29659AC
//	// public static void SetDecodeThreadPriorityAndroidExperimental(int prio) { }

//	// // RVA: 0x2965B20 Offset: 0x2965B20 VA: 0x2965B20
//	// public static bool ShouldSampleRed(GraphicsDeviceType type, IntPtr tex_ptr) { }

//	// // RVA: 0x2965CB8 Offset: 0x2965CB8 VA: 0x2965CB8
//	// public static void Lock() { }

//	// // RVA: 0x2965E24 Offset: 0x2965E24 VA: 0x2965E24
//	// public static void Unlock() { }

//	// // RVA: 0x2964B20 Offset: 0x2964B20 VA: 0x2964B20
//	// private static extern void CRIWARE476CEB30(int graphics_api, bool graphics_multi_threaded, int num_decoders, int num_of_max_entries) { }

//	// // RVA: 0x29656C0 Offset: 0x29656C0 VA: 0x29656C0
//	// private static extern void CRIWARE9CF52E96() { }

//	// // RVA: 0x29657B8 Offset: 0x29657B8 VA: 0x29657B8
//	public static /*extern*/ bool CRIWARE50D2CE6F()
//    {
//        return ExternLib.LibCriWare.CRIWARE50D2CE6F();
//    }

//	// // RVA: 0x29658B8 Offset: 0x29658B8 VA: 0x29658B8
//	// private static extern void CRIWAREDC8B0D52() { }

//	// // RVA: 0x2960F20 Offset: 0x2960F20 VA: 0x2960F20
//	// public static extern void CRIWARE3AF940D2(bool flag) { }

//	// // RVA: 0x2965D30 Offset: 0x2965D30 VA: 0x2965D30
//	// public static extern void CRIWARE0F4D5885() { }

//	// // RVA: 0x2965EA0 Offset: 0x2965EA0 VA: 0x2965EA0
//	// public static extern void CRIWARE8B2825A3() { }

//	// // RVA: 0x2965F98 Offset: 0x2965F98 VA: 0x2965F98
//	// public static extern void criMana_UseStreamerManager(bool flag) { }

//	// // RVA: 0x2966078 Offset: 0x2966078 VA: 0x2966078
//	// public static extern bool criMana_IsStreamerManagerUsed() { }

//	// // RVA: 0x2966158 Offset: 0x2966158 VA: 0x2966158
//	// public static extern uint CRIWAREFC9E4898() { }

//	// // RVA: 0x2965A30 Offset: 0x2965A30 VA: 0x2965A30
//	// public static extern void criManaUnity_SetDecodeThreadPriority_ANDROID(int prio) { }

//	// // RVA: 0x2965130 Offset: 0x2965130 VA: 0x2965130
//	// private static extern void criManaUnity_SetConfigAdditionalParameters_ANDROID(bool enable_h264_playback) { }

//	// // RVA: 0x2966250 Offset: 0x2966250 VA: 0x2966250
//	// public static extern void criManaUnity_EnableSwitchTextureSampleColorGLES30_ANDROID() { }

//	// // RVA: 0x2965BB0 Offset: 0x2965BB0 VA: 0x2965BB0
//	// private static extern bool criManaUnity_ShouldSwitchTextureSampleColorToRedGLES30_ANDROID(IntPtr tex_ptr) { }

//}
