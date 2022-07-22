/****************************************************************************
 *
 * Copyright (c) 2018 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/
using UnityEngine;
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
 * <summary>音声出力データ解析モジュール（プレーヤ/ソース/バス単位)</summary>
 * <remarks>
 * <para header='説明'>CriAtomSource/CriAtomExPlayerごと、またはバスごとの音声出力の解析を行います。<br/>
 * レベルメータ機能などを提供します。<br/></para>
 * <para header='注意'>CriAtomSource/CriAtomExPlayerにアタッチする場合、HCA-MXやプラットフォーム固有の
 * 音声圧縮コーデックを使用している場合は解析できません。<br/>
 * HCAもしくはADXコーデックをご利用ください。</para>
 * </remarks>
 */

public class CriAtomExOutputAnalyzer : CriDisposable
{
	public IntPtr nativeHandle {get {return this.handle;} }

	/**
	 * <summary>スペクトラムアナライザの最大バンド数</summary>
	 * <remarks>
	 * <para header='説明'>スペクトラムアナライザが出力できるバンド数の最大値です。</para>
	 * </remarks>
	 */
	public const int MaximumSpectrumBands = 512;

	/**
	 * <summary>波形取得コールバック</summary>
	 * <remarks>
	 * <para header='説明'>出力される波形データを取得するためのコールバックです。<br/></para>
	 * </remarks>
	 */
	public delegate void PcmCaptureCallback(float[] dataL, float[] dataR, int numChannels, int numData);

	/**
	 * <summary>音声出力データ解析モジュールコンフィグ構造体</summary>
	 * <remarks>
	 * <para header='説明'>解析モジュール作成時に指定するコンフィグです。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExOutputAnalyzer::CriAtomExOutputAnalyzer'/>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct Config
	{
		/**
		 * <summary>レベルメータを有効にするか</summary>
		 * <remarks>
		 * <para header='説明'>レベルメータを有効化します。</para>
		 * </remarks>
		 */
		public bool enableLevelmeter;

		/**
		 * <summary>スペクトラムアナライザを有効にするか</summary>
		 * <remarks>
		 * <para header='説明'>スペクトラムアナライザを有効化します。
		 * 機能を利用する場合、本フラグにtrueを指定すると同時に、
		 * numSpectrumAnalyzerBandsにMaximumSpectrumBands以下の正数を
		 * 指定してください。</para>
		 * </remarks>
		 */
		public bool enableSpectrumAnalyzer;

		/**
		 * <summary>波形データ取得を有効にするか</summary>
		 * <remarks>
		 * <para header='説明'>出力データの取得を有効化します。
		 * 機能を利用する場合、本フラグにtrueを指定すると同時に、
		 * numCapturedPcmSamplesに正数を指定してください。</para>
		 * </remarks>
		 */
		public bool enablePcmCapture;

		/**
		 * <summary>波形データ取得コールバックを有効にするか</summary>
		 * <remarks>
		 * <para header='説明'>出力データ取得用のコールバックを有効化します。<br/>
		 * 機能を利用する場合、本フラグにtrueを指定した上で、MonoBehaviour.Update 内等で
		 * 定期的に ExecutePcmCaptureCallback を呼び出してください。<br/></para>
		 * </remarks>
		 */
		public bool enablePcmCaptureCallback;

		/**
		 * <summary>スペクトラムアナライザのバンド数</summary>
		 */
		public int numSpectrumAnalyzerBands;

		/**
		 * <summary>一度に取得する波形データのサンプル数</summary>
		 */
		public int numCapturedPcmSamples;
	};

	/**
	 * <summary>音声出力データ解析モジュールの作成</summary>
	 * <returns>音声出力データ解析モジュール</returns>
	 * <remarks>
	 * <para header='説明'>出力音声データの解析モジュールを作成します。<br/>
	 * 作成した解析モジュールは、CriAtomSourceまたはCriAtomExPlayer、またはバスにアタッチして使用します。<br/>
	 * アタッチしている音声出力に対し、レベルメータなどの解析を行います。<br/><code>
	 * // 解析モジュールの作成例
	 *
	 * // コンフィグでSpectrumAnalyzerを有効にし、バンド数を指定
	 * CriAtomExOutputAnalyzer.Config config = new CriAtomExOutputAnalyzer.Config();
	 * config.enableSpectrumAnalyzer = true;
	 * config.numSpectrumAnalyzerBands = 16;
	 *
	 * // 出力データ解析モジュールを作成
	 * this.analyzer = new CriAtomExOutputAnalyzer(config);
	 * </code>
	 * </para>
	 * <para header='備考'>解析モジュールにアタッチ可能なCriAtomSource/CriAtomExPlayer/バスは一つのみです。<br/>
	 * 解析モジュールを使いまわす場合は、デタッチを行ってください。<br/></para>
	 * <para header='注意'>音声出力データ解析モジュールの作成時には、アンマネージドなリソースが確保されます。<br/>
	 * 解析モジュールが不要になった際は、必ず CriAtomExOutputAnalyzer.Dispose メソッドを呼んでください。</para>
	 * </remarks>
	 */
	public CriAtomExOutputAnalyzer(Config config)
	{
		InitializeWithConfig(config);
		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
	}

	/**
	 * <summary>出力データ解析モジュールの破棄</summary>
	 * <remarks>
	 * <para header='説明'>出力データ解析モジュールを破棄します。<br/>
	 * 本関数を実行した時点で、出力データ解析モジュール作成時にプラグイン内で確保されたリソースが全て解放されます。<br/>
	 * メモリリークを防ぐため、出力データ解析モジュールが不要になった時点で本メソッドを呼び出してください。<br/></para>
	 * <para header='注意'>本関数は完了復帰型の関数です。<br/>
	 * アタッチ済みのAtomExプレーヤがある場合、本関数内でデタッチが行われます。<br/>
	 * 対象のAtomExプレーヤが再生中の音声は強制的に停止しますのでご注意ください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExOutputAnalyzer::CriAtomExOutputAnalyzer'/>
	 */
	public override void Dispose()
	{
		this.Dispose(true);
	}

	protected void Dispose(bool disposing)
	{
		CriDisposableObjectManager.Unregister(this);

		if (this.handle != IntPtr.Zero) {
			/* アタッチ済みのプレーヤがあればデタッチ */
			this.DetachExPlayer();
			this.DetachDspBus();

			/* ネイティブリソースの破棄 */
			criAtomExOutputAnalyzer_Destroy(this.handle);
			this.handle = IntPtr.Zero;
		}

		if (disposing) {
			GC.SuppressFinalize(this);
		}
	}

	/**
	 * <summary>AtomExプレーヤのアタッチ</summary>
	 * <returns>アタッチが成功したかどうか（成功：true、失敗：false）</returns>
	 * <remarks>
	 * <para header='説明'>出力データ解析を行うAtomExプレーヤをアタッチします。<br/>
	 * 複数のAtomExプレーヤをアタッチすることは出来ません。
	 * アタッチ中に別のAtomExプレーヤをアタッチした場合、アタッチ中のAtomExプレーヤはデタッチされます。<br/>
	 * <br/>
	 * CriAtomSourceをアタッチする場合、CriAtomSource::AttachToOutputAnalyzerを使用してください。</para>
	 * <para header='注意'>アタッチは再生開始前に行う必要があります。再生開始後のアタッチは失敗します。<br/>
	 * <br/>
	 * 本関数でアタッチしたAtomExプレーヤをデタッチする前に破棄した場合、
	 * デタッチ時にアクセス違反が発生します。<br/>
	 * 必ず先にデタッチを行ってからAtomExプレーヤを破棄してください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExOutputAnalyzer::DetachExPlayer'/>
	 * <seealso cref='CriAtomSource::AttachToOutputAnalyzer'/>
	 */
	public bool AttachExPlayer(CriAtomExPlayer player)
	{
		if (player == null || !player.isAvailable ||
			this.handle == IntPtr.Zero) {
			return false;
		}

		/* アタッチ済みならデタッチ */
		this.DetachExPlayer();
		this.DetachDspBus();

		/* プレーヤの状態をチェック */
		CriAtomExPlayer.Status status = player.GetStatus();
		if (status != CriAtomExPlayer.Status.Stop) {
			return false;
		}

		criAtomExOutputAnalyzer_AttachExPlayer(this.handle, player.nativeHandle);
		this.player = player;

		return true;
	}

	/**
	 * <summary>AtomExプレーヤのデタッチ</summary>
	 * <remarks>
	 * <para header='説明'>出力データ解析を行うAtomExプレーヤをデタッチします。<br/>
	 * デタッチを行うと、以降の解析処理は行われなくなります。</para>
	 * <para header='注意'>アタッチ済みのプレーヤが音声を再生している状態で本関数を呼び出した場合、
	 * 強制的に再生を停止した上でデタッチが行われます。<br/>
	 * <br/>
	 * アタッチしたAtomExプレーヤが既に破棄されていた場合はアクセス違反が発生します。<br/>
	 * 必ず本関数、またはCriAtomExOutputAnalyzer::Disposeを呼び出してから、
	 * AtomExプレーヤを破棄するようにしてください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExOutputAnalyzer::AttachExPlayer'/>
	 * <seealso cref='CriAtomExOutputAnalyzer::Dispose'/>
	 */
	public void DetachExPlayer()
	{
		if (this.player == null || !this.player.isAvailable ||
			this.handle == IntPtr.Zero) {
			return;
		}

		CriAtomExPlayer.Status status = this.player.GetStatus();
		if (status != CriAtomExPlayer.Status.Stop) {
			/* 音声再生中にデタッチは行えないため、強制的に停止 */
			Debug.LogWarning("[CRIWARE] Warning: CriAtomExPlayer is forced to stop for detaching CriAtomExOutputAnalyzer.");
			this.player.StopWithoutReleaseTime();
		}

		criAtomExOutputAnalyzer_DetachExPlayer(this.handle, this.player.nativeHandle);
		this.player = null;
	}

	/**
	 * <summary>DSPバスのアタッチ</summary>
	 * <returns>アタッチが成功したかどうか（成功：true、失敗：false）</returns>
	 * <remarks>
	 * <para header='説明'>出力データ解析を行うDSPバスをアタッチします。<br/>
	 * 複数のDSPバスをアタッチすることは出来ません。
	 * アタッチ中に別のDSPバスをアタッチした場合、アタッチ中のDSPバスはデタッチされます。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExOutputAnalyzer::DetachDspBus'/>
	 */
	public bool AttachDspBus(string busName)
	{
		if (busName == null || this.handle == IntPtr.Zero) {
			return false;
		}

		/* アタッチ済みのプレーヤがあればデタッチ */
		this.DetachExPlayer();
		this.DetachDspBus();

	#if !UNITY_PSP2
		criAtomExOutputAnalyzer_AttachDspBusByName(this.handle, busName);
		this.busName = busName;
		return true;
	#else
		Debug.LogError("[CRIWARE] Error: CriAtomExOutputAnalyzer cannot be attached to bus on this platform.");
		return false;
	#endif
	}

	/**
	 * <summary>DSPバスのデタッチ</summary>
	 * <remarks>
	 * <para header='説明'>出力データ解析を行うDSPバスをデタッチします。<br/>
	 * デタッチを行うと、以降の解析処理は行われなくなります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExOutputAnalyzer::AttachDspBus'/>
	 * <seealso cref='CriAtomExOutputAnalyzer::Dispose'/>
	 */
	public void DetachDspBus()
	{
		if (this.busName == null || this.handle == IntPtr.Zero) {
			return;
		}

		criAtomExOutputAnalyzer_DetachDspBusByName(this.handle, busName);
		this.busName = null;
	}

	/**
	 * <summary>アタッチ中の音声出力のRMSレベルの取得</summary>
	 * <param name='channel'>チャンネル番号</param>
	 * <returns>RMSレベル</returns>
	 * <remarks>
	 * <para header='説明'>アタッチ中の音声出力のRMSレベルを取得します。<br/>
	 * 本機能を利用する場合、ConfigのenableLevelmeterにtrueを指定してモジュールを作成してください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExOutputAnalyzer::AttachExPlayer'/>
	 * <seealso cref='CriAtomExOutputAnalyzer::AttachDspBus'/>
	 */
	public float GetRms(int channel)
	{
		if ((this.player == null && this.busName == null)
			|| this.handle == IntPtr.Zero) {
			return 0.0f;
		}

		/* プレーヤが再生状態でなければレベルを落とす */
		if (this.player != null &&
			this.player.GetStatus() != CriAtomExPlayer.Status.Playing &&
			this.player.GetStatus() != CriAtomExPlayer.Status.Prep) {
			return 0.0f;
		}

		return criAtomExOutputAnalyzer_GetRms(this.handle, channel);
	}

	/**
	 * <summary>スペクトル解析結果の取得</summary>
	 * <param name='levels'>解析結果(帯域毎の振幅値)</param>
	 * <remarks>
	 * <para header='説明'>スペクトラムアナライザによって解析された帯域ごとの振幅値を取得します。<br/>
	 * 配列の要素数はモジュールの作成時に指定したバンド数です。<br/>
	 * 本機能を利用する場合、ConfigのenableSpectrumAnalyzerにtrueを、numSpectrumAnalyzerBandsに
	 * MaximumSpectrumBands以下の正数を指定してモジュールを作成してください。
	 * 解析結果を市販のスペクトルアナライザのように表示させたい場合、
	 * 本関数が返す値をデシベル値に変換する必要があります。<br/></para>
	 * </remarks>
	 * <example><code>
	 * // 例：スペクトル解析結果を取得するコンポーネント
	 * public class SpectrumLevelMeter : MonoBehaviour {
	 *  private CriAtomExOutputAnalyzer analyzer;
	 *  void Start() {
	 *      // 引数 config については省略。モジュールの作成時に指定したバンド数は 8 とする
	 *      this.analyzer = new CriAtomExOutputAnalyzer(config);
	 *      // CriAtomExPlayer のアタッチについては省略
	 *  }
	 *
	 *  void Update() {
	 *      // 音声再生中の実行
	 *      float[] levels = new float[8];
	 *      analyzer.GetSpectrumLevels (ref levels);
	 *      // levelsの0帯域目の振幅値をデシベル値に変換
	 *      float db = 20.0f * Mathf.Log10(levels[0]);
	 *      Debug.Log (db);
	 *  }
	 * }
	 * </code></example>
	 * <seealso cref='CriAtomExOutputAnalyzer::AttachExPlayer'/>
	 * <seealso cref='CriAtomExOutputAnalyzer::AttachDspBus'/>
	 */
	public void GetSpectrumLevels(ref float[] levels)
	{
		if ((this.player == null && this.busName == null) || this.handle == IntPtr.Zero) {
			return;
		}

		if (levels == null || levels.Length < numBands) {
			levels = new float[numBands];
		}

		IntPtr ret = criAtomExOutputAnalyzer_GetSpectrumLevels(this.handle);
		Marshal.Copy(ret, levels, 0, numBands);
	}

	/**
	 * <summary>アタッチ中の音声出力の波形データの取得</summary>
	 * <param name='data'>出力データ</param>
	 * <param name='ch'>チャンネル</param>
	 * <remarks>
	 * <para header='説明'>アタッチ中の音声出力の波形データを取得します。<br/>
	 * 本機能を利用する場合、ConfigのenablePcmCaptureにtrueを、numCapturedPcmSamplesに
	 * 正数を指定してモジュールを作成してください。<br/></para>
	 * <para header='注意'>引数の配列の長さが十分でない場合、関数内で配列の確保が行われます。<br/>
	 * 不要なGCの発生を避けるため、初期化コンフィグで指定したデータサンプル数以上の
	 * 長さの配列を引数に渡すようにしてください。
	 * 現状、取得可能なチャンネルはL/Rのみです。chには0か1を指定してください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExOutputAnalyzer::AttachExPlayer'/>
	 * <seealso cref='CriAtomExOutputAnalyzer::AttachDspBus'/>
	 */
	public void GetPcmData(ref float[] data, int ch)
	{
		if ((this.player == null && this.busName == null) || this.handle == IntPtr.Zero) {
			return;
		}

		if (data == null || data.Length < numCapturedPcmSamples) {
			data = new float[numCapturedPcmSamples];
		}

		IntPtr ret = criAtomExOutputAnalyzer_GetPcmData(this.handle, ch);
		if (ret != IntPtr.Zero) {
			Marshal.Copy(ret, data, 0, numCapturedPcmSamples);
		}
	}

	/**
	 * <summary>波形データ取得コールバックの登録</summary>
	 * <remarks>
	 * <para header='説明'>出力データ取得用のコールバックを登録します。<br/>
	 * コールバックによる波形データ取得を利用する場合、ExecutePcmCaptureCallbackの呼び出し前に
	 * 本関数によりコールバックの登録を行ってください。<br/></para>
	 * </remarks>
	 */
	public void SetPcmCaptureCallback(PcmCaptureCallback callback)
	{
		this.userPcmCaptureCallback = callback;
	}

	/**
	 * <summary>波形データ取得コールバックの実行</summary>
	 * <remarks>
	 * <para header='説明'>出力データ取得用のコールバックを実効します。<br/>
	 * 本関数を呼び出すと、最後の実行時からの出力差分データを引数とするコールバックが
	 * 複数回呼び出されます。<br/></para>
	 * <para header='注意'>コールバックによる波形データ取得を利用する場合、本関数を定期的に呼び出してください。<br/>
	 * 本関数が長時間呼び出されなかった場合、取得可能な波形データに欠落が生じます。<br/></para>
	 * </remarks>
	 */
	public void ExecutePcmCaptureCallback()
	{
	#if !(!UNITY_EDITOR && UNITY_WEBGL)
		if (CriAtomExOutputAnalyzer.InternalCallbackFunctionPointer == IntPtr.Zero) {
			CriAtomExOutputAnalyzer.DelegateObject = new InternalPcmCaptureCallback(CriAtomExOutputAnalyzer.Callback);
			CriAtomExOutputAnalyzer.InternalCallbackFunctionPointer = Marshal.GetFunctionPointerForDelegate(CriAtomExOutputAnalyzer.DelegateObject);
		}

		CriAtomExOutputAnalyzer.UserPcmCaptureCallback = this.userPcmCaptureCallback;
		CriAtomExOutputAnalyzer.DataL = this.dataL;
		CriAtomExOutputAnalyzer.DataR = this.dataR;

		criAtomExOutputAnalyzer_ExecuteQueuedPcmCapturerCallbacks(this.handle, CriAtomExOutputAnalyzer.InternalCallbackFunctionPointer);

		CriAtomExOutputAnalyzer.UserPcmCaptureCallback = null;
		CriAtomExOutputAnalyzer.DataL = null;
		CriAtomExOutputAnalyzer.DataR = null;
	#endif
	}

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * SetPcmCaptureCallback(PcmCaptureCallback) と ExecutePcmCaptureCallback()の使用を検討してください。
	*/
	[System.Obsolete("Use SetPcmCaptureCallback(PcmCaptureCallback) and ExecutePcmCaptureCallback()")]
	public void ExecutePcmCaptureCallback(PcmCaptureCallback callback)
	{
		this.userPcmCaptureCallback = callback;
		ExecutePcmCaptureCallback();
	}

	#region Internal Members
	protected CriAtomExOutputAnalyzer() {
		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
	}

	~CriAtomExOutputAnalyzer()
	{
		this.Dispose(false);
	}

	protected void InitializeWithConfig(Config config) {
		/* ネイティブリソースの作成 */
		this.handle = criAtomExOutputAnalyzer_Create(ref config);
		if (this.handle == IntPtr.Zero) {
			throw new Exception("criAtomExOutputAnalyzer_Create() failed.");
		}

		/* コンフィグ指定の記憶 */
		{
			this.numBands = config.numSpectrumAnalyzerBands;
			this.numCapturedPcmSamples = config.numCapturedPcmSamples;
			if (config.enablePcmCaptureCallback) {
	#if !UNITY_EDITOR && UNITY_WEBGL
				Debug.LogError("[CRIWARE] PCM capture callback is not supported for this platform.");
	#else
				if (this.dataL == null) {
					this.dataL = new float[pcmCapturerNumMaxData];
					this.dataR = new float[pcmCapturerNumMaxData];
				}
	#endif
			}
		}
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	protected delegate void InternalPcmCaptureCallback(IntPtr dataL, IntPtr dataR, int numChannels, int numData);

	protected IntPtr handle = IntPtr.Zero;
	protected CriAtomExPlayer player = null;
	protected string busName = null;
	protected int numBands = 8;
	protected int numCapturedPcmSamples = 4096;
	protected PcmCaptureCallback userPcmCaptureCallback = null;
	protected float [] dataL, dataR;
	protected const int pcmCapturerNumMaxData = 512;

	[AOT.MonoPInvokeCallback(typeof(InternalPcmCaptureCallback))]
	private static void Callback(IntPtr ptrL, IntPtr ptrR, int numChannels, int numData)
	{
		if (DataL == null)
			return;

		Marshal.Copy(ptrL, DataL, 0, numData);
		if (numChannels > 1) {
			Marshal.Copy(ptrR, DataR, 0, numData);
		}
		if (UserPcmCaptureCallback != null) {
			UserPcmCaptureCallback(DataL, DataR, numChannels, numData);
		}
	}

	protected static IntPtr InternalCallbackFunctionPointer = IntPtr.Zero;
	protected static InternalPcmCaptureCallback DelegateObject;
	protected static float [] DataL, DataR;
	protected static PcmCaptureCallback UserPcmCaptureCallback = null;
	#endregion

	#region DLL Import
	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	protected static extern IntPtr criAtomExOutputAnalyzer_Create([In] ref Config config);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	protected static extern void criAtomExOutputAnalyzer_Destroy(IntPtr analyzer);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	protected static extern void criAtomExOutputAnalyzer_AttachExPlayer(IntPtr analyzer, IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	protected static extern void criAtomExOutputAnalyzer_DetachExPlayer(IntPtr analyzer, IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	protected static extern void criAtomExOutputAnalyzer_AttachDspBusByName(IntPtr analyzer, string busName);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	protected static extern void criAtomExOutputAnalyzer_DetachDspBusByName(IntPtr analyzer, string busName);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	protected static extern float criAtomExOutputAnalyzer_GetRms(IntPtr analyzer, int channel);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	protected static extern IntPtr criAtomExOutputAnalyzer_GetSpectrumLevels(IntPtr analyzer);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	protected static extern IntPtr criAtomExOutputAnalyzer_GetPcmData(IntPtr analyzer, int ch);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	protected static extern void criAtomExOutputAnalyzer_ExecuteQueuedPcmCapturerCallbacks(IntPtr analyzer, IntPtr callback);
	#else
	protected static IntPtr criAtomExOutputAnalyzer_Create([In] ref Config config) { return new IntPtr(1); }
	protected static void criAtomExOutputAnalyzer_Destroy(IntPtr analyzer) {     }
	protected static void criAtomExOutputAnalyzer_AttachExPlayer(IntPtr analyzer, IntPtr player) { }
	protected static void criAtomExOutputAnalyzer_DetachExPlayer(IntPtr analyzer, IntPtr player) { }
	protected static void criAtomExOutputAnalyzer_AttachDspBusByName(IntPtr analyzer, string busName) { }
	protected static void criAtomExOutputAnalyzer_DetachDspBusByName(IntPtr analyzer, string busName) { }
	protected static float criAtomExOutputAnalyzer_GetRms(IntPtr analyzer, int channel) { return 0.0f; }
	protected static IntPtr criAtomExOutputAnalyzer_GetSpectrumLevels(IntPtr analyzer) { return IntPtr.Zero; }
	protected static IntPtr criAtomExOutputAnalyzer_GetPcmData(IntPtr analyzer, int ch) { return IntPtr.Zero; }
	protected static void criAtomExOutputAnalyzer_ExecuteQueuedPcmCapturerCallbacks(IntPtr analyzer, IntPtr callback) { }
	#endif
	#endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
