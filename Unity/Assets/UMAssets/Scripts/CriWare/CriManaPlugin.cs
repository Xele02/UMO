
using System;
using System.Runtime.InteropServices;
using CriWare.CriMana.Detail;
using UnityEngine;
using UnityEngine.Rendering;

namespace CriWare
{

	public class CriManaPlugin
	{
		private static int initializationCount = 0; // 0x0
		private static bool isConfigured = false; // 0x4
		private static bool enabledMultithreadedRendering = false; // 0x5
		public static int renderingEventOffset = 0x43570000; // 0x8

		public static bool isInitialized { get { return initializationCount > 0; } } // 0x29648D8
		public static bool isMultithreadedRenderingEnabled { get { return enabledMultithreadedRendering;} } // 0x2964970

		// // RVA: 0x29649FC Offset: 0x29649FC VA: 0x29649FC
		public static void SetConfigParameters(bool graphicsMultiThreaded, int num_decoders, int max_num_of_entries)
		{
			GraphicsDeviceType graphicsApi = SystemInfo.graphicsDeviceType;
			
	#if !UNITY_EDITOR && UNITY_ANDROID
			// currently, this feature is supported on Android only
			enabledMultithreadedRendering = graphicsMultiThreaded;
			CriWare.Common.criWareUnity_SetRenderingEventOffsetForMana(renderingEventOffset);
	#else
			enabledMultithreadedRendering = false;
	#endif

			CRIWARE476CEB30_criManaUnity_SetConfigParameters((int)graphicsApi, enabledMultithreadedRendering, num_decoders, max_num_of_entries);
			isConfigured = true;
		}

		// // RVA: 0x2964C3C Offset: 0x2964C3C VA: 0x2964C3C
		private static void SetupVp9()
		{
			Type t = Type.GetType("CriManaVp9");
			if(t == null)
				return;
			TodoLogger.LogError(0, "SetupVp9");
		}

		// [ObsoleteAttribute] // RVA: 0x636358 Offset: 0x636358 VA: 0x636358
		// // RVA: 0x2964F48 Offset: 0x2964F48 VA: 0x2964F48
		// public static void SetConfigAdditonalParameters_VITA(bool use_h264_playback, int width, int height) { }

		// // RVA: 0x2964F4C Offset: 0x2964F4C VA: 0x2964F4C
		// public static void SetConfigAdditonalParameters_PC(bool use_h264_playback) { }

		// // RVA: 0x2964F50 Offset: 0x2964F50 VA: 0x2964F50
		public static void SetConfigAdditonalParameters_ANDROID(bool use_h264_playback)
		{
			IntPtr android_context = IntPtr.Zero;
			using (AndroidJavaClass jc = new AndroidJavaClass("android.os.Build$VERSION"))
			{
				int val = jc.GetStatic<int>("SDK_INT");
				if(val > 15)
				{
					criManaUnity_SetConfigAdditionalParameters_ANDROID(use_h264_playback);
				}
			}

		}

		// // RVA: 0x2965224 Offset: 0x2965224 VA: 0x2965224
		// public static void SetConfigAdditonalParameters_WEBGL(string webworkerPath, uint heapSize) { }

		// // RVA: 0x2965228 Offset: 0x2965228 VA: 0x2965228
		public static void InitializeLibrary()
		{
			CriManaPlugin.initializationCount++;
			if (CriManaPlugin.initializationCount != 1) {
				return;
			}
			
			if(CriManaPlugin.IsLibraryInitialized())
			{
				FinalizeLibrary();
			}
			if(!isConfigured)
			{
				UnityEngine.Debug.Log("[CRIWARE] Mana initialization parameters are not configured. Initializes Mana by default parameters.");
			}
			CriFsPlugin.InitializeLibrary();
			CriAtomPlugin.InitializeLibrary();
			SetupVp9();
			CRIWARE9CF52E96_criManaUnity_Initialize();
			AutoResisterRendererResourceFactories.InvokeAutoRegister();
		}

		// // RVA: 0x2957C30 Offset: 0x2957C30 VA: 0x2957C30
		public static bool IsLibraryInitialized()
		{
			return CRIWARE50D2CE6F_();
		}

		// // RVA: 0x296547C Offset: 0x296547C VA: 0x296547C
		public static void FinalizeLibrary()
		{
			initializationCount++;
			if(initializationCount < 0)
			{
				initializationCount = 0;
				if(!IsLibraryInitialized())
					return;
			}
			if(initializationCount == 0)
			{
				CriDisposableObjectManager.CallOnModuleFinalization(CriDisposableObjectManager.ModuleType.Mana);
				CRIWAREDC8B0D52_criManaUnity_Finalize();
				RendererResourceFactory.DisposeAllFactories();
				CriAtomPlugin.FinalizeLibrary();
				CriFsPlugin.FinalizeLibrary();
			}
		}

		// // RVA: 0x29659AC Offset: 0x29659AC VA: 0x29659AC
		// public static void SetDecodeThreadPriorityAndroidExperimental(int prio) { }

		// // RVA: 0x2965B20 Offset: 0x2965B20 VA: 0x2965B20
		// public static bool ShouldSampleRed(GraphicsDeviceType type, IntPtr tex_ptr) { }

		// // RVA: 0x2965CB8 Offset: 0x2965CB8 VA: 0x2965CB8
		// public static void Lock() { }

		// // RVA: 0x2965E24 Offset: 0x2965E24 VA: 0x2965E24
		// public static void Unlock() { }

		// // RVA: 0x2964B20 Offset: 0x2964B20 VA: 0x2964B20
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE476CEB30(int graphics_api, bool graphics_multi_threaded, int num_decoders, int num_of_max_entries);
#endif
		private static void CRIWARE476CEB30_criManaUnity_SetConfigParameters(int graphics_api, bool graphics_multi_threaded, int num_decoders, int num_of_max_entries)
		{
#if UNITY_ANDROID
			CRIWARE476CEB30(graphics_api, graphics_multi_threaded, num_decoders, num_of_max_entries);
#else
#endif
		}

		// // RVA: 0x29656C0 Offset: 0x29656C0 VA: 0x29656C0
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE9CF52E96();
#endif
		private static void CRIWARE9CF52E96_criManaUnity_Initialize()
		{
#if UNITY_ANDROID
			CRIWARE9CF52E96();
#else
			ExternLib.LibCriWare.CRIWARE9CF52E96_criManaUnity_Initialize();
#endif
		}

		// // RVA: 0x29657B8 Offset: 0x29657B8 VA: 0x29657B8
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern bool CRIWARE50D2CE6F();
#endif
		public static bool CRIWARE50D2CE6F_()
		{
#if UNITY_ANDROID
			return CRIWARE50D2CE6F();
#else
			return ExternLib.LibCriWare.CRIWARE50D2CE6F();
#endif
		}

		// // RVA: 0x29658B8 Offset: 0x29658B8 VA: 0x29658B8
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWAREDC8B0D52();
#endif
		private static void CRIWAREDC8B0D52_criManaUnity_Finalize()
		{
#if UNITY_ANDROID
			CRIWAREDC8B0D52();
#else
			ExternLib.LibCriWare.CRIWAREDC8B0D52_criManaUnity_Finalize();
#endif
		}

		// // RVA: 0x2960F20 Offset: 0x2960F20 VA: 0x2960F20
		// public static extern void CRIWARE3AF940D2(bool flag) { }

		// // RVA: 0x2965D30 Offset: 0x2965D30 VA: 0x2965D30
		// public static extern void CRIWARE0F4D5885() { }

		// // RVA: 0x2965EA0 Offset: 0x2965EA0 VA: 0x2965EA0
		// public static extern void CRIWARE8B2825A3() { }

		// // RVA: 0x2965F98 Offset: 0x2965F98 VA: 0x2965F98
		// public static extern void criMana_UseStreamerManager(bool flag) { }

		// // RVA: 0x2966078 Offset: 0x2966078 VA: 0x2966078
		// public static extern bool criMana_IsStreamerManagerUsed() { }

		// // RVA: 0x2966158 Offset: 0x2966158 VA: 0x2966158
		// public static extern uint CRIWAREFC9E4898() { }

		// // RVA: 0x2965A30 Offset: 0x2965A30 VA: 0x2965A30
		// public static extern void criManaUnity_SetDecodeThreadPriority_ANDROID(int prio) { }

		// // RVA: 0x2965130 Offset: 0x2965130 VA: 0x2965130
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void criManaUnity_SetConfigAdditionalParameters_ANDROID(bool enable_h264_playback);
#else
		private static void criManaUnity_SetConfigAdditionalParameters_ANDROID(bool enable_h264_playback)
		{
			
		}
#endif

		// // RVA: 0x2966250 Offset: 0x2966250 VA: 0x2966250
		// public static extern void criManaUnity_EnableSwitchTextureSampleColorGLES30_ANDROID() { }

		// // RVA: 0x2965BB0 Offset: 0x2965BB0 VA: 0x2965BB0
		// private static extern bool criManaUnity_ShouldSwitchTextureSampleColorToRedGLES30_ANDROID(IntPtr tex_ptr) { }

	}
}
