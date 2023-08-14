using System;
using System.Runtime.InteropServices;
#if UNITY_ANDROID
using NUnit.Framework;
#endif
using UnityEngine;

namespace CriWare
{

	// [AddComponentMenu] // RVA: 0x63296C Offset: 0x63296C VA: 0x63296C
	public class CriWareErrorHandler : CriMonoBehaviour
	{
		public bool enableDebugPrintOnTerminal; // 0x1C
		public bool enableForceCrashOnError; // 0x1D
		public bool dontDestroyOnLoad = true; // 0x1E
		public delegate void Callback(string message);
		public static event Callback OnCallback = null; // 0x4
		[Obsolete("CriWareErrorHandler.callback is deprecated. Use CriWareErrorHandler.OnCallback event", false)]
		public static Callback callback = null; // 0x8
		public uint messageBufferCounts = 8; // 0x20
		private static int initializationCount; // 0xC

		public static string errorMessage { get; set; } // 0x0

		// [CompilerGeneratedAttribute] // RVA: 0x6364FC Offset: 0x6364FC VA: 0x6364FC
		// // RVA: 0x2BAA120 Offset: 0x2BAA120 VA: 0x2BAA120
		// public static void add_OnCallback(CriWareErrorHandler.Callback value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x63650C Offset: 0x63650C VA: 0x63650C
		// // RVA: 0x2BAA2B4 Offset: 0x2BAA2B4 VA: 0x2BAA2B4
		// public static void remove_OnCallback(CriWareErrorHandler.Callback value) { }

		// // RVA: 0x2BAA448 Offset: 0x2BAA448 VA: 0x2BAA448
		private void Awake()
		{
			initializationCount++;
			if (initializationCount == 1)
			{
				CRIWARE2DABE6AD_criWareUnity_Initialize();
				CRIWARE2AB443C5_criWareUnity_SetForceCrashFlagOnError(enableForceCrashOnError);
				CRIWARE2944E024_criWareUnity_AllocateErrorMessageBuffer(messageBufferCounts);

				CRIWAREE5C6ECB6_criWareUnity_ControlLogOutput(enableDebugPrintOnTerminal);

				CRIWAREEA2D718D_criWareUnity_SetErrorCallback(ErrorCallbackFromNative);

				if (!dontDestroyOnLoad)
					return;
				DontDestroyOnLoad(transform.gameObject);
			}
			else
			{
				Destroy(this);
			}
		}

		// // RVA: 0x2BAAB48 Offset: 0x2BAAB48 VA: 0x2BAAB48 Slot: 4
		protected override void OnEnable()
		{
			base.OnEnable();
			CRIWAREEA2D718D_criWareUnity_SetErrorCallback(ErrorCallbackFromNative);
		}

		// // RVA: 0x2BAAC10 Offset: 0x2BAAC10 VA: 0x2BAAC10 Slot: 5
		protected override void OnDisable()
		{
			base.OnDisable();
			CRIWAREEA2D718D_criWareUnity_SetErrorCallback(null);
		}

		// // RVA: 0x2BAAC9C Offset: 0x2BAAC9C VA: 0x2BAAC9C
		private void Start()
		{
			return;
		}

		// // RVA: 0x2BAACA0 Offset: 0x2BAACA0 VA: 0x2BAACA0 Slot: 6
		public override void CriInternalUpdate()
		{
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS || UNITY_TVOS)
			if (enableDebugPrintOnTerminal == false){
				DequeueErrorMessages();
			}
#else
			DequeueErrorMessages();
#endif
		}

		// // RVA: 0x2BAAFA0 Offset: 0x2BAAFA0 VA: 0x2BAAFA0 Slot: 7
		public override void CriInternalLateUpdate()
		{
			return;
		}

		// // RVA: 0x2BAAFA4 Offset: 0x2BAAFA4 VA: 0x2BAAFA4
		private void OnDestroy()
		{
			initializationCount--;
			if (initializationCount != 0) {
				return;
			}

			CRIWAREEA2D718D_criWareUnity_SetErrorCallback(null);
			CRIWARE972AEE70_criWareUnity_DeallocateErrorMessageBuffer();

			CRIWARE992B1A7A_criWareUnity_Finalize();
		}

		// // RVA: 0x2BAACB0 Offset: 0x2BAACB0 VA: 0x2BAACB0
		private void DequeueErrorMessages()
		{
			string message = null;
			while (true) {
				IntPtr ptr = CRIWARE24FFC2BE_criWareUnity_DequeueFirstErrorMessage();
				if (ptr == IntPtr.Zero) {
					break;
				}
				try {
					message = Marshal.PtrToStringAnsi(ptr);
				} 
				catch (Exception) {
					Debug.LogError("[CRIWARE] Failed to parse error message.");
				}
				finally {
					if (message != null && message != string.Empty) {
						HandleMessage(message);
					}
				}
			}
		}

		// // RVA: 0x2BAB35C Offset: 0x2BAB35C VA: 0x2BAB35C
		private static void HandleMessage(string errmsg)
		{
			if (errmsg == null) {
				return;
			}

			if (OnCallback == null && callback == null) {
				OutputDefaultLog(errmsg);
			} else {
				if (OnCallback != null) {
					OnCallback(errmsg);
				}
				if (callback != null) {
					callback(errmsg);
				}
			}
		}

		// // RVA: 0x2BAB594 Offset: 0x2BAB594 VA: 0x2BAB594
		private static void OutputDefaultLog(string errmsg)
		{
			if (errmsg.StartsWith("E")) {
				Debug.LogError("[CRIWARE] Error:" + errmsg);
			} else if (errmsg.StartsWith("W")) {
				Debug.LogWarning("[CRIWARE] Warning:" + errmsg);
			} else {
				Debug.Log("[CRIWARE]" + errmsg);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void ErrorCallbackFunc(string errmsg);

		[AOT.MonoPInvokeCallback(typeof(ErrorCallbackFunc))]
		// // RVA: 0x2BA9F84 Offset: 0x2BA9F84 VA: 0x2BA9F84
		private static void ErrorCallbackFromNative(string errmsg)
		{
			HandleMessage(errmsg);
		}

		// // RVA: 0x2BAA818 Offset: 0x2BAA818 VA: 0x2BAA818
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE2944E024(uint length);
#endif
		private static void CRIWARE2944E024_criWareUnity_AllocateErrorMessageBuffer(uint length)
		{
#if UNITY_ANDROID
			CRIWARE2944E024(length);
#endif
		}

		// // RVA: 0x2BAA618 Offset: 0x2BAA618 VA: 0x2BAA618
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE2DABE6AD();
#endif
		private static void CRIWARE2DABE6AD_criWareUnity_Initialize()
		{
#if UNITY_ANDROID
			CRIWARE2DABE6AD();
#else

#endif
		}

		// // RVA: 0x2BAB170 Offset: 0x2BAB170 VA: 0x2BAB170
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE992B1A7A();
#endif
		private static void CRIWARE992B1A7A_criWareUnity_Finalize()
		{
#if UNITY_ANDROID
			CRIWARE992B1A7A();
#endif
		}

		// // RVA: 0x2BAA920 Offset: 0x2BAA920 VA: 0x2BAA920
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWAREE5C6ECB6(bool sw);
#endif
		private static void CRIWAREE5C6ECB6_criWareUnity_ControlLogOutput(bool sw)
		{
#if UNITY_ANDROID
			CRIWAREE5C6ECB6(sw);
#endif
		}

		// // RVA: 0x2BAB078 Offset: 0x2BAB078 VA: 0x2BAB078
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE972AEE70();
#endif
		private static void CRIWARE972AEE70_criWareUnity_DeallocateErrorMessageBuffer()
		{
#if UNITY_ANDROID
			CRIWARE972AEE70();
#endif
		}

		// // RVA: 0x2BAB268 Offset: 0x2BAB268 VA: 0x2BAB268
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern IntPtr CRIWARE24FFC2BE();
#endif
		private static IntPtr CRIWARE24FFC2BE_criWareUnity_DequeueFirstErrorMessage()
		{
#if UNITY_ANDROID
			return CRIWARE24FFC2BE();
#else
			return IntPtr.Zero;
#endif
		}

		// // RVA: 0x2BAA710 Offset: 0x2BAA710 VA: 0x2BAA710
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWARE2AB443C5(bool sw);

#endif
		private static void CRIWARE2AB443C5_criWareUnity_SetForceCrashFlagOnError(bool sw)
		{
#if UNITY_ANDROID
			CRIWARE2AB443C5(sw);
#endif
		}

		// // RVA: 0x2BAAA38 Offset: 0x2BAAA38 VA: 0x2BAAA38
#if UNITY_ANDROID
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		private static extern void CRIWAREEA2D718D(ErrorCallbackFunc callback);
#endif
		private static void CRIWAREEA2D718D_criWareUnity_SetErrorCallback(CriWareErrorHandler.ErrorCallbackFunc callback)
		{
#if UNITY_ANDROID
			CRIWAREEA2D718D(callback);
#endif
		}
	}
}
