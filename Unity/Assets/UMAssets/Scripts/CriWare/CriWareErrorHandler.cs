/****************************************************************************
 *
 * Copyright (c) 2012 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

#pragma warning disable 0618

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

/**
 * \addtogroup CRIWARE_UNITY_COMPONENT
 * @{
 */
 namespace CriWare {

/**
 * <summary>CRIWAREエラーオブジェクト</summary>
 * <remarks>
 * <para header='説明'>CRIWAREライブラリの初期化を行うためのコンポーネントです。<br/></para>
 * </remarks>
 */
[AddComponentMenu("CRIWARE/Error Handler")]
public class CriWareErrorHandler : CriMonoBehaviour{
	/**
	 * <summary>コンソールデバッグ出力を有効にするかどうか</summary>
	 * <remarks>
	 * <para header='注意'>Unityデバッグウィンドウだけでなく、コンソールデバッグ出力を有効にするかどうか [deprecated]
	 * PCの場合はデバッグウィンドウに出力されます。</para>
	 * </remarks>
	 */
	public bool enableDebugPrintOnTerminal = false;

	/** エラー発生時に強制的にクラッシュさせるかどうか(デバッグ用) */
	public bool enableForceCrashOnError = false;

	/** シーンチェンジ時にエラーハンドラを削除するかどうか */
	public bool dontDestroyOnLoad = true;

	/** エラーメッセージ */
	public static string errorMessage { get; set; }

	/**
	 * <summary>エラーコールバックデリゲート</summary>
	 * <remarks>
	 * <para header='説明'>CRIWAREネイティブライブラリ内でエラーが発生した際に呼び出されるコール
	 * バックデリゲートです。<br/>
	 * 引数の文字列には、"エラーID:エラー内容"のフォーマットでメッセージが
	 * 記載されています。</para>
	 * </remarks>
	 */
	public delegate void Callback(string message);

	/**
	 * <summary>エラーコールバックイベント</summary>
	 * <remarks>
	 * <para header='説明'>CRIWAREネイティブライブラリ内でエラーが発生した際に呼び出されるコール
	 * バックイベントです。<br/>
	 * 未設定時には、本クラス内に定義されているデフォルトのログ出力関数が
	 * 呼び出されます。<br/>
	 * エラーメッセージを元に独自の処理を記述したい場合、デリゲートを登録して
	 * コールバック関数内で処理を行ってください。<br/></para>
	 * <para header='注意'>登録したコールバックは、CriWareErrorHandlerが生存中は常に呼び出される
	 * 可能性があります。<br/>
	 * 呼び出し先関数の実体が、CriWareErrorHandlerよりも先に解放されないように
	 * ご注意ください。</para>
	 * </remarks>
	 */
	public static event Callback OnCallback = null;

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * CriWareErrorHandler.OnCallback event の使用を検討してください。
	 * <summary>エラーコールバック</summary>
	 * <remarks>
	 * <para header='説明'>CRIWAREネイティブライブラリ内でエラーが発生した際に呼び出されるコール
	 * バックです。<br/>
	 * 未設定時には、本クラス内に定義されているデフォルトのログ出力関数が
	 * 呼び出されます。<br/>
	 * エラーメッセージを元に独自の処理を記述したい場合、デリゲートを登録して
	 * コールバック関数内で処理を行ってください。<br/>
	 * 登録を解除する場合は null を設定してください。</para>
	 * <para header='注意'>登録したコールバックは、CriWareErrorHandlerが生存中は常に呼び出される
	 * 可能性があります。<br/>
	 * 呼び出し先関数の実体が、CriWareErrorHandlerよりも先に解放されないように
	 * ご注意ください。</para>
	 * </remarks>
	 */
	[Obsolete("CriWareErrorHandler.callback is deprecated. Use CriWareErrorHandler.OnCallback event", false)]
	public static Callback callback = null;

	/**
	 * <summary>エラーメッセージバッファ数の設定</summary>
	 * <remarks>
	 * <para header='説明'>エラー発生時に1アプリケーションフレーム内でハンドルするエラーの最大数を設定します。<br/>
	 * 設定数以上のエラーが一度に発生した場合はログ出力等がスキップされます。<br/>
	 * デフォルト値は8です。<br/>
	 * 0〜32の範囲で設定してください。<br/></para>
	 * </remarks>
	 */
	public uint messageBufferCounts = 8;

	/* オブジェクト作成時の処理 */
	void Awake() {
		/* 初期化カウンタの更新 */
		initializationCount++;
		if (initializationCount != 1) {
			/* 多重初期化は許可しない */
			GameObject.Destroy(this);
			return;
		}

		/* エラー処理の初期化 */
		criWareUnity_Initialize();
		criWareUnity_SetForceCrashFlagOnError(enableForceCrashOnError);
		criWareUnity_AllocateErrorMessageBuffer(messageBufferCounts);

		/* ターミナルへのログ出力表示切り替え */
		criWareUnity_ControlLogOutput(enableDebugPrintOnTerminal);

		criWareUnity_SetErrorCallback(ErrorCallbackFromNative);

		/* シーンチェンジ後もオブジェクトを維持するかどうかの設定 */
		if (dontDestroyOnLoad) {
			DontDestroyOnLoad(transform.gameObject);
		}
	}

	/* Execution Order の設定を確実に有効にするために OnEnable をオーバーライド */
	protected override void OnEnable() {
		base.OnEnable();
		criWareUnity_SetErrorCallback(ErrorCallbackFromNative);
	}

	protected override void OnDisable() {
		base.OnDisable();
		criWareUnity_SetErrorCallback(null);
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	public override void CriInternalUpdate() {
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS || UNITY_TVOS)
		if (enableDebugPrintOnTerminal == false){
			/* iOS/Androidの場合、エラーメッセージの出力先が重複してしまうため、*/
			/* ターミナル出力が無効になっている場合のみ、Unity出力を有効にする。*/
			DequeueErrorMessages();
		}
#else
		DequeueErrorMessages();
#endif
	}

	public override void CriInternalLateUpdate() { }

	void OnDestroy() {
		/* 初期化カウンタの更新 */
		initializationCount--;
		if (initializationCount != 0) {
			return;
		}
		criWareUnity_SetErrorCallback(null);
		criWareUnity_DeallocateErrorMessageBuffer();

		/* エラー処理の終了処理 */
		criWareUnity_Finalize();
	}

	/* エラーメッセージのポーリングと出力 */
	private void DequeueErrorMessages()
	{
		string message = null;
		while (true) {
			IntPtr ptr = criWareUnity_DequeueFirstErrorMessage();
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

	/** デフォルトのログ出力 */
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
	private static void ErrorCallbackFromNative(string errmsg)
	{
		HandleMessage(errmsg);
	}

	/** 初期化カウンタ */
	private static int initializationCount = 0;

	#region DLL Import
	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criWareUnity_AllocateErrorMessageBuffer(uint length);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criWareUnity_Initialize();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criWareUnity_Finalize();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criWareUnity_ControlLogOutput(bool sw);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criWareUnity_DeallocateErrorMessageBuffer();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criWareUnity_DequeueFirstErrorMessage();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criWareUnity_SetForceCrashFlagOnError(bool sw);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criWareUnity_SetErrorCallback(ErrorCallbackFunc callback);
	#else
	private static void criWareUnity_AllocateErrorMessageBuffer(uint length) { }
	private static void criWareUnity_Initialize() { }
	private static void criWareUnity_Finalize() { }
	private static System.IntPtr criWareUnity_GetFirstError() { return System.IntPtr.Zero; }
	private static void criWareUnity_ControlLogOutput(bool sw) { }
	private static void criWareUnity_DeallocateErrorMessageBuffer() { }
	private static System.IntPtr criWareUnity_DequeueFirstErrorMessage() { return System.IntPtr.Zero; }
	private static void criWareUnity_SetForceCrashFlagOnError(bool sw) { }
	private static void criWareUnity_SetErrorCallback(ErrorCallbackFunc callback) { }
	#endif
	#endregion
} // end of class

} //namespace CriWare
/** @} */

/* --- end of file --- */
