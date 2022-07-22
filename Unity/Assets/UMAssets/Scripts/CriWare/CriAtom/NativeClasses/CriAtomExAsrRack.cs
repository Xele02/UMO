/****************************************************************************
 *
 * Copyright (c) 2016 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

/*---------------------------
 * Asr Support Defines
 *---------------------------*/
#if !UNITY_PSP2
#define CRIWARE_SUPPORT_ASR
#endif

using System;
using System.Runtime.InteropServices;

/*==========================================================================
 *      CRI Atom Native Wrapper
 *=========================================================================*/
/**
 * \addtogroup CRIATOM_NATIVE_WRAPPER
 * @{
 */

namespace CriWare {

/**
 * <summary>ASRラック</summary>
 */
public partial class CriAtomExAsrRack : CriDisposable
{
	#region Data Types
	/**
	 * <summary>ASRラック作成用コンフィグ構造体</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomExAsrRack の動作仕様を指定するための構造体です。<br/>
	 * モジュール作成時（::CriAtomExAsrRack::CriAtomExAsrRack 関数）に引数として本構造体を指定します。<br/></para>
	 * <para header='備考'>::CriAtomExAsrRack::defaultConfig で取得したデフォルトコンフィギュレーションを必要に応じて変更して
	 * ください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAsrRack::CriAtomExAsrRack'/>
	 * <seealso cref='CriAtomExAsrRack::defaultConfig'/>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct Config
	{
		/**
		 * <summary>サーバ処理の実行頻度</summary>
		 * <remarks>
		 * <para header='説明'>サーバ処理を実行する頻度を指定します。</para>
		 * <para header='注意'>CriWareInitializer に指定した CriAtomConfig::serverFrequency と同じ値を指定してください。</para>
		 * </remarks>
		 */
		public float serverFrequency;

		/**
		 * <summary>バス数</summary>
		 * <remarks>
		 * <para header='説明'>ASRが作成するバスの数を指定します。<br/>
		 * バスはサウンドのミックスや、DSPエフェクトの管理等を行います。</para>
		 * </remarks>
		 */
		public int numBuses;

		/**
		 * <summary>出力チャンネル数</summary>
		 * <remarks>
		 * <para header='説明'>ASRラックの出力チャンネル数を指定します。<br/>
		 * パン3Dもしくは3Dポジショニング機能を使用する場合は6ch以上を指定します。</para>
		 * </remarks>
		 */
		public int outputChannels;

		/**
		 * <summary>出力サンプリングレート</summary>
		 * <remarks>
		 * <para header='説明'>ASRラックの出力および処理過程のサンプリングレートを指定します。<br/>
		 * 通常、ターゲット機のサウンドデバイスのサンプリングレートを指定します。</para>
		 * <para header='備考'>低くすると処理負荷を下げることができますが音質が落ちます。</para>
		 * </remarks>
		 */
		public int outputSamplingRate;

		/**
		 * <summary>サウンドレンダラタイプ</summary>
		 * <remarks>
		 * <para header='説明'>ASRラックの出力先サウンドレンダラの種別を指定します。<br/>
		 * soundRendererType に CriAtomEx.SoundRendererType.Native を指定した場合、
		 * 音声データはデフォルト設定の各プラットフォームのサウンド出力に転送されます。</para>
		 * </remarks>
		 */
		public CriAtomEx.SoundRendererType soundRendererType;

		/**
		 * <summary>出力先ASRラックID</summary>
		 * <remarks>
		 * <para header='説明'>ASRラックの出力先ASRラックIDを指定します。<br/>
		 * soundRendererType に CriAtomEx.SoundRendererType.Asr を指定した場合のみ有効です。</para>
		 * </remarks>
		 */
		public int outputRackId;

		/**
		 * <summary>プラットフォーム固有のパラメータへのポインタ</summary>
		 * <remarks>
		 * <para header='説明'>プラットフォーム固有のパラメータへのポインタを指定します。<br/>
		 * CriAtomExAsrRack::CriAtomExAsrRack 関数の引数に用いる場合は、第二引数の
		 * PlatformContext で上書きされるため、 IntPtr.Zero を指定してください。</para>
		 * </remarks>
		 */
		public IntPtr context;
	}

	/**
	 * <summary>ASRラック作成用プラットフォーム固有コンフィグ構造体</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomExAsrRack の動作仕様を指定するための構造体です。<br/>
	 * モジュール作成時（::CriAtomExAsrRack::CriAtomExAsrRack 関数）に引数として本構造体を指定します。<br/>
	 * 詳細についてはプラットフォーム毎のマニュアルを参照してください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExAsrRack::CriAtomExAsrRack'/>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct PlatformConfig
	{
	#if !UNITY_EDITOR && UNITY_PS4
		public int userId;
		public CriWarePS4.AudioPortType portType;
		public CriWarePS4.AudioPortAttribute portAttr;
	#else
		public byte reserved;
	#endif
	}

	/**
	 * <summary>パフォーマンス情報</summary>
	 * <remarks>
	 * <para header='説明'>パフォーマンス情報を取得するための構造体です。<br/>
	 * ::CriAtomExAsrRack::GetPerformanceInfo 、 ::CriAtomExAsrRack::GetPerformanceInfoByRackId 関数で利用します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAsrRack::GetPerformanceInfo'/>
	 * <seealso cref='CriAtomExAsrRack::GetPerformanceInfoByRackId'/>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct PerformanceInfo
	{
		public UInt32 processCount;            /**< 信号生成処理回数 */
		public UInt32 lastProcessTime;         /**< 処理時間の最終計測値（マイクロ秒単位） */
		public UInt32 maxProcessTime;          /**< 処理時間の最大値（マイクロ秒単位） */
		public UInt32 averageProcessTime;      /**< 処理時間の平均値（マイクロ秒単位） */
		public UInt32 lastProcessInterval;     /**< 処理間隔の最終計測値（マイクロ秒単位） */
		public UInt32 maxProcessInterval;      /**< 処理間隔の最大値（マイクロ秒単位） */
		public UInt32 averageProcessInterval;  /**< 処理間隔の平均値（マイクロ秒単位） */
		public UInt32 lastProcessSamples;      /**< 単位処理で生成されたサンプル数の最終計測値 */
		public UInt32 maxProcessSamples;       /**< 単位処理で生成されたサンプル数の最大値 */
		public UInt32 averageProcessSamples;   /**< 単位処理で生成されたサンプル数の平均値 */
	}
	#endregion

	/**
	 * <summary>ASRラックの作成</summary>
	 * <param name='config'>コンフィグ構造体</param>
	 * <param name='platformConfig'>プラットフォーム固有パラメータ構造体</param>
	 * <returns>ASRラック</returns>
	 * <remarks>
	 * <para header='説明'>ASRラックを作成します。<br/>
	 * 本関数で作成したASRラックは、必ず Dispose 関数で破棄してください。</para>
	 * </remarks>
	 */
	public CriAtomExAsrRack(Config config, PlatformConfig platformConfig)
	{
	#if CRIWARE_SUPPORT_ASR
		this._rackId = criAtomUnityAsrRack_Create(ref config, ref platformConfig);
		if (config.context != IntPtr.Zero) {
			Marshal.FreeHGlobal(config.context);
		}
		if (this._rackId == -1) {
			throw new Exception("CriAtomExAsrRack() failed.");
		}

		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
	#else
		this._rackId = -1;
	#endif
	}

	/**
	 * <summary>スナップショット名の取得</summary>
	 * <param name='rackId'>ラックのID</param>
	 * <returns>スナップショット名</returns>
	 * <remarks>
	 * <para header='説明'>現在設定されているスナップショット名を取得します。設定されていない場合、nullを返しします。<br/></para>
	 * </remarks>
	 */
	public static string GetAppliedDspBusSnapshotName(int rackId)
	{
		string snapshotName;
		IntPtr ptr = criAtomExAsrRack_GetAppliedDspBusSnapshotName(rackId);
		if (ptr == IntPtr.Zero) {
			return null;
		}
		snapshotName = Marshal.PtrToStringAnsi(ptr);
		return snapshotName;
	}

	/**
	 * <summary>ASRラックのパフォーマンス情報を取得</summary>
	 * <returns>ASRラックのパフォーマンス情報</returns>
	 * <remarks>
	 * <para header='説明'>現在のASRラックインスタンスからパフォーマンス情報を取得します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAsrRack::ResetPerformanceMonitor'/>
	 * <seealso cref='CriAtomExAsrRack::GetPerformanceInfoByRackId'/>
	 */
	public PerformanceInfo GetPerformanceInfo()
	{
		PerformanceInfo info = new PerformanceInfo();
		if(this._rackId < 0) {
			UnityEngine.Debug.LogError("[CRIWARE] This ASR Rack is not initialized.");
			return info;
		}

		criAtomExAsrRack_GetPerformanceInfo(this._rackId, out info);
		return info;
	}

	/**
	 * <summary>ASRラックのパフォーマンス情報を取得</summary>
	 * <param name='rackId'>ラックのID</param>
	 * <returns>ASRラックのパフォーマンス情報</returns>
	 * <remarks>
	 * <para header='説明'>指定したIDのASRラックのパフォーマンス情報を取得します。<br/>
	 * ラックIDを指定しない場合、ライブラリ初期化時に生成されるデフォルトASRラックのパフォーマンス情報が返されます。<br/>
	 * 不正なラックIDが指定された場合、メンバー変数の値がすべて0の構造体が返されます。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAsrRack::ResetPerformanceMonitorByRackId'/>
	 * <seealso cref='CriAtomExAsrRack::GetPerformanceInfo'/>
	 */
	public static PerformanceInfo GetPerformanceInfoByRackId(int rackId = CriAtomExAsrRack.defaultRackId)
	{
		PerformanceInfo info = new PerformanceInfo();
		criAtomExAsrRack_GetPerformanceInfo(rackId, out info);
		return info;
	}

	/**
	 * <summary>ASRラックのパフォーマンス計測をリセット</summary>
	 * <remarks>
	 * <para header='説明'>現在のASRラックインスタンスのパフォーマンス計測をリセットします。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAsrRack::GetPerformanceInfo'/>
	 * <seealso cref='CriAtomExAsrRack::ResetPerformanceMonitorByRackId'/>
	 */
	public void ResetPerformanceMonitor()
	{
		criAtomExAsrRack_ResetPerformanceMonitor(this._rackId);
	}

	/**
	 * <summary>ASRラックのパフォーマンス計測をリセット</summary>
	 * <param name='rackId'>ラックのID</param>
	 * <remarks>
	 * <para header='説明'>指定したIDのASRラックのパフォーマンス計測をリセットします。<br/>
	 * ラックIDを指定しない場合、ライブラリ初期化時に生成されるデフォルトASRラックのパフォーマンス情報がリセットされます。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAsrRack::GetPerformanceInfoByRackId'/>
	 * <seealso cref='CriAtomExAsrRack::ResetPerformanceMonitor'/>
	 */
	public static void ResetPerformanceMonitorByRackId(int rackId = CriAtomExAsrRack.defaultRackId)
	{
		criAtomExAsrRack_ResetPerformanceMonitor(rackId);
	}

	/**
	 * <summary>ASRラックの破棄</summary>
	 * <remarks>
	 * <para header='説明'>ASRラックを破棄します。</para>
	 * </remarks>
	 */
	public override void Dispose()
	{
	#if CRIWARE_SUPPORT_ASR
		CriDisposableObjectManager.Unregister(this);

		if (this._rackId != -1) {
			criAtomExAsrRack_Destroy(this._rackId);
			this._rackId = -1;
		}
	#endif
		GC.SuppressFinalize(this);
	}

	public int rackId {
		get { return this._rackId; }
	}

	#region Static Properties
	/**
	 * <summary>デフォルトコンフィギュレーション</summary>
	 * <remarks>
	 * <para header='説明'>デフォルトコンフィグです。</para>
	 * <para header='備考'>本プロパティで取得したデフォルトコンフィギュレーションを必要に応じて変更して
	 * ::CriAtomExAsrRack::CriAtomExAsrRack 関数に指定してください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAsrRack::CriAtomExAsrRack'/>
	 */
	public static Config defaultConfig {
		get {
			Config config;
			config.serverFrequency = 60.0f;
			config.numBuses = 8;
			config.soundRendererType = CriAtomEx.SoundRendererType.Native;
			config.outputRackId = 0;
			config.context = System.IntPtr.Zero;
	#if !UNITY_EDITOR && UNITY_PS4
			config.outputChannels = 8;
			config.outputSamplingRate = 48000;
	#elif !UNITY_EDITOR && UNITY_IOS || UNITY_ANDROID
			config.outputChannels = 2;
			config.outputSamplingRate = 44100;
	#elif !UNITY_EDITOR && UNITY_PSP2
			config.outputChannels = 2;
			config.outputSamplingRate = 48000;
	#else
			config.outputChannels = 6;
			config.outputSamplingRate = 48000;
	#endif
			return config;
		}
	}

	/**
	 * <summary>デフォルトASRラックID</summary>
	 * <remarks>
	 * <para header='説明'>デフォルトのASRラックIDです。
	 * 通常出力に戻す場合や生成したASRラックを破棄する場合には、各種プレーヤに対して
	 * この定数を利用してASRラックIDの指定を行ってください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::SetAsrRackId'/>
	 * <seealso cref='CriMana::Player::SetAsrRackId'/>
	 */
	public const int defaultRackId = 0;

	#endregion


	#region internal members
	~CriAtomExAsrRack()
	{
		this.Dispose();
	}

	private int _rackId = -1;
	#endregion

	#region DLL Import
	#if CRIWARE_SUPPORT_ASR

	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomUnityAsrRack_Create([In] ref Config config, [In] ref PlatformConfig platformConfig);
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAsrRack_Destroy(Int32 rackId);
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAsrRack_AttachDspBusSetting(Int32 rackId, string setting, IntPtr work, Int32 workSize);
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAsrRack_DetachDspBusSetting(Int32 rackId);
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomExAsrRack_GetAppliedDspBusSnapshotName(int rackId);
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAsrRack_ApplyDspBusSnapshot(Int32 rackId, string snapshotName, Int32 timeMs);
	#else
	private static int criAtomUnityAsrRack_Create([In] ref Config config, [In] ref PlatformConfig platformConfig) { return 0; }
	private static void criAtomExAsrRack_Destroy(Int32 rackId) { }
	private static void criAtomExAsrRack_AttachDspBusSetting(Int32 rackId, string setting, IntPtr work, Int32 workSize) { }
	private static void criAtomExAsrRack_DetachDspBusSetting(Int32 rackId) { }
	private static void criAtomExAsrRack_ApplyDspBusSnapshot(Int32 rackId, string snapshotName, Int32 timeMs) { }
	private static IntPtr criAtomExAsrRack_GetAppliedDspBusSnapshotName(int rackId) { return IntPtr.Zero; }
	#endif

	#if !CRIWARE_ENABLE_HEADLESS_MODE && !UNITY_WEBGL
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAsrRack_GetPerformanceInfo(Int32 rackId, out PerformanceInfo perfInfo);
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAsrRack_ResetPerformanceMonitor(Int32 rackId);
	#else
	private static void criAtomExAsrRack_GetPerformanceInfo(Int32 rackId, out PerformanceInfo perfInfo) { perfInfo = new PerformanceInfo(); }
	private static void criAtomExAsrRack_ResetPerformanceMonitor(Int32 rackId) { }
	#endif

	#endif
	#endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
