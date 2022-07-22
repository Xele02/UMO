/****************************************************************************
 *
 * Copyright (c) CRI Middleware Co., Ltd.
 *
 ****************************************************************************/
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
#define CRIWAREPLUGIN_SUPPORT_OUTPUTDEVICE_OBSERVER
#endif

using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

/**
 * \addtogroup CRIWARE_COMMON_CLASS
 * @{
 */

namespace CriWare {


/**
 * <summary>音声出力デバイスの接続状態を監視するコンポーネントです。</summary>
 * <remarks>
 * <para header='説明'>任意のGameObjectに付加して使用します。<br/>
 * スマートフォン端末での音声出力デバイスの接続状態を監視し、外部から状態の取得が行えます。<br/>
 * デリゲートを登録することで、接続状態が変化した際にコールバックを受け取ることもできます。<br/>
 * 本コンポーネントを利用する場合は、Atomライブラリを初期化しておく必要があります。</para>
 * <para header='注意'>本コンポーネントの機能は、現状ではスマートフォン(Android/iOS)でのみ
 * 動作します。<br/>
 * その他のプラットフォームへの対応については今後のアップデートをお待ちください。</para>
 * </remarks>
 */
public class CriAtomOutputDeviceObserver : CriMonoBehaviour
{
	/**
	 * <summary>音声出力デバイス種別</summary>
	 * <remarks>
	 * <para header='説明'>アプリケーションからの音声出力先となるデバイス種別です。</para>
	 * </remarks>
	 * <seealso cref='CriAtomOutputDeviceObserver::DeviceType'/>
	 */
	public enum OutputDeviceType {
		BuiltinSpeaker,     /**< 内臓スピーカー */
		WiredDevice,        /**< 有線デバイス(有線ヘッドセットなど) */
		WirelessDevice,     /**< 無線デバイス(Bluetooth ヘッドセットなど) */
	}


	/**
	 * <summary>接続状態変化コールバックデリゲート型</summary>
	 * <param name='isConnected'>出力デバイス接続状態（false = 切断、true = 接続）</param>
	 * <param name='deviceType'>出力デバイス種別</param>
	 * <remarks>
	 * <para header='説明'>音声出力デバイスの接続状態変化時に呼び出されるコールバック関数型です。</para>
	 * </remarks>
	 * <seealso cref='CriAtomOutputDeviceObserver::OnDeviceConnectionChanged'/>
	 */
	public delegate void DeviceConnectionChangeCallback(bool isConnected, OutputDeviceType deviceType);


	/**
	 * <summary>接続状態変化コールバックデリゲート</summary>
	 * <remarks>
	 * <para header='説明'>音声出力デバイスの接続状態変化時に呼び出されるコールバック関数です。<br/>
	 * アプリケーションのメインスレッドから呼び出されます。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExOutputDeviceObserver::DeviceConnectionChangeCallback'/>
	 */
	public static event DeviceConnectionChangeCallback OnDeviceConnectionChanged {
		add {
			_onDeviceConnectionChanged += value;
			if (instance) {
				value(IsDeviceConnected, DeviceType);
			}
		}
		remove {
			_onDeviceConnectionChanged -= value;
		}
	}

	/**
	 * <summary>デバイス接続状態の取得</summary>
	 * <returns>接続中かどうか（false = 切断、true = 接続）</returns>
	 * <remarks>
	 * <para header='説明'>端末に音声出力用デバイスが接続されているかどうかを返します。<br/>
	 * 本体スピーカー以外のデバイスが出力先となっている場合に true を返します。</para>
	 * </remarks>
	 */
	public static bool IsDeviceConnected {
		get {
			if (instance == null) {
				return false;
			}
#if !UNITY_EDITOR && UNITY_IOS
			return UnsafeNativeMethods.criAtomUnity_IsOutputDeviceConnected_IOS();
#elif !UNITY_EDITOR && UNITY_ANDROID
			return instance.isConnected;
#else
			return false;
#endif
		}
	}

	/**
	 * <summary>出力デバイス種別の取得</summary>
	 * <returns>出力デバイス種別</returns>
	 * <remarks>
	 * <para header='説明'>現在の音声出力デバイスの種別を取得します。</para>
	 * </remarks>
	 */
	public static OutputDeviceType DeviceType {
		get {
			if (instance == null) {
				return OutputDeviceType.BuiltinSpeaker;
			}
#if !UNITY_EDITOR && UNITY_IOS
			return UnsafeNativeMethods.criAtomUnity_GetOutputDeviceType_IOS();
#elif !UNITY_EDITOR && UNITY_ANDROID
			return instance.deviceType;
#else
			return OutputDeviceType.BuiltinSpeaker;
#endif
		}
	}

	#region Internal Members
	[SerializeField] bool dontDestroyOnLoad = false;
	bool lastIsConnected = false;
	bool isConnected = false;
	OutputDeviceType lastDeviceType = OutputDeviceType.BuiltinSpeaker;
	OutputDeviceType deviceType = OutputDeviceType.BuiltinSpeaker;
	static CriAtomOutputDeviceObserver instance = null;
	static event DeviceConnectionChangeCallback _onDeviceConnectionChanged = null;
#if !UNITY_EDITOR && UNITY_ANDROID
	static UnityEngine.AndroidJavaObject checker = null;
#endif
	#endregion

	#region Internal Functions
	private void Awake() {
		if (instance != null) {
			Destroy(this);
			return;
		}

		if (!CriAtomPlugin.IsLibraryInitialized()) {
			Debug.LogError("[CRIWARE] Atom library is not initialized. Cannot setup CriAtomExOutputDeviceObserver.");
			Destroy(this);
			return;
		}

		instance = this;

#if CRIWAREPLUGIN_SUPPORT_OUTPUTDEVICE_OBSERVER
#if !UNITY_EDITOR && UNITY_IOS
		bool isStarted = UnsafeNativeMethods.criAtomUnity_StartOutputDeviceObserver_IOS();
		if (!isStarted) {
			Debug.LogError("[CRIWARE] CriAtomOutputDeviceObserver cannot start while Atom library is not initialized.");
		}
#elif !UNITY_EDITOR && UNITY_ANDROID
		UnityEngine.AndroidJavaClass jc = new UnityEngine.AndroidJavaClass("com.unity3d.player.UnityPlayer");
		UnityEngine.AndroidJavaObject activity = jc.GetStatic<UnityEngine.AndroidJavaObject>("currentActivity");
		
		if (checker == null) {
			checker = new UnityEngine.AndroidJavaObject("com.crimw.crijavaclasses.CriOutputDeviceObserver", activity, this.gameObject.name, "CallbackFromObserver_ANDROID");
		}
		if (checker == null) {
			Debug.LogError("[CRIWARE] Cannot load CriOutputDeviceObserver class in library.");
		}
		checker.Call("Start", activity);
		CheckOutputDevice_ANDROID();
#endif
		isConnected = lastIsConnected = IsDeviceConnected;
		deviceType = lastDeviceType = DeviceType;
		if (_onDeviceConnectionChanged != null) {
			_onDeviceConnectionChanged(isConnected, deviceType);
		}
#elif !UNITY_EDITOR
		Debug.Log("[CRIWARE] CriAtomOutputDeviceObserver is not supported on this platform.");
#endif
		if (this.dontDestroyOnLoad) {
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
	}


	private void OnDestroy() {
		if (instance != this) {
			return;
		}
		instance = null;

#if CRIWAREPLUGIN_SUPPORT_OUTPUTDEVICE_OBSERVER
#if !UNITY_EDITOR && UNITY_IOS
		UnsafeNativeMethods.criAtomUnity_StopOutputDeviceObserver_IOS();
#elif !UNITY_EDITOR && UNITY_ANDROID
		UnityEngine.AndroidJavaClass jc = new UnityEngine.AndroidJavaClass("com.unity3d.player.UnityPlayer");
		UnityEngine.AndroidJavaObject activity = jc.GetStatic<UnityEngine.AndroidJavaObject>("currentActivity");
		if (activity != null && checker != null) {
			checker.Call("Stop", activity);
		}
		checker = null;
#endif
#endif
	}


	public override void CriInternalUpdate() {
		isConnected = IsDeviceConnected;
		deviceType = DeviceType;

		if ((isConnected != lastIsConnected ||
			deviceType != lastDeviceType) &&
			_onDeviceConnectionChanged != null) {
			_onDeviceConnectionChanged(isConnected, deviceType);
		}
		lastIsConnected = isConnected;
		lastDeviceType = deviceType;
	}


	public override void CriInternalLateUpdate() {
	}

#if !UNITY_EDITOR && UNITY_ANDROID
	/* [ANDROID] Callback from CriOutputDeviceObserver class */
	private void CallbackFromObserver_ANDROID(string message) {
		if (message[0] == 'a') {
			CheckOutputDevice_ANDROID();
		} else if (message[0] == 'b') {
			StartCoroutine("CoroutineForCheck_ANDROID");
		}
	}

	private void CheckOutputDevice_ANDROID() {
		if (checker == null) {
			return;
		}

		UnityEngine.AndroidJavaClass jc = new UnityEngine.AndroidJavaClass("com.unity3d.player.UnityPlayer");
		UnityEngine.AndroidJavaObject activity = jc.GetStatic<UnityEngine.AndroidJavaObject>("currentActivity");
		int device = checker.Call<int>("CheckOutputDeviceType", activity);
		deviceType = (OutputDeviceType)device;
		isConnected = (deviceType != OutputDeviceType.BuiltinSpeaker);

	}

	private IEnumerator CoroutineForCheck_ANDROID() {
		const float waitSec = 1.0f;
		float time = 0.0f;
		while (time < waitSec) {
			yield return null;
			time += Time.deltaTime;
		}
		CheckOutputDevice_ANDROID();
	}

#endif
	#endregion

	#region Dll Import
	private static class UnsafeNativeMethods
	{
#if !CRIWARE_ENABLE_HEADLESS_MODE
#if !UNITY_EDITOR && UNITY_IOS
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern bool criAtomUnity_StartOutputDeviceObserver_IOS();
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomUnity_StopOutputDeviceObserver_IOS();
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern bool criAtomUnity_IsOutputDeviceConnected_IOS();
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern OutputDeviceType criAtomUnity_GetOutputDeviceType_IOS();
#endif
#else
#if !UNITY_EDITOR && UNITY_IOS
		internal static bool criAtomUnity_StartOutputDeviceObserver_IOS() { return false; }
		internal static void criAtomUnity_StopOutputDeviceObserver_IOS() { }
		internal static bool criAtomUnity_IsOutputDeviceConnected_IOS() { return false; }
		internal static OutputDeviceType criAtomUnity_GetOutputDeviceType_IOS() { return OutputDeviceType.BuiltinSpeaker; }
#endif
#endif
	}
	#endregion

} // end of class

} //namespace CriWare
/** @} */
/* end of file */
