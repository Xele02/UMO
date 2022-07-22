/****************************************************************************
 *
 * Copyright (c) 2018 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

#if (UNITY_EDITOR && !UNITY_EDITOR_LINUX) || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_ANDROID || UNITY_IOS
#define CRIWAREPLUGIN_SUPPORT_MIC
#endif

using System;
using System.Runtime.InteropServices;
using UnityEngine;

/*==========================================================================
 *      CRI Atom Native Wrapper
 *=========================================================================*/
/**
 * \addtogroup CRIATOM_NATIVE_WRAPPER
 * @{
 */

namespace CriWare {

/**
 * <summary>音声キャプチャするためのマイク</summary>
 * <remarks>
 * <para header='説明'>物理的なマイクや音声デバイスからの入力をキャプチャするためのクラスです。<br/>
 * 入力の開始、ステータスの取得、データの取得等の制御を行います。<br/>
 * また、::CriAtomExMic::GetDevices で音声入力デバイスの情報を取得することができます。<br/></para>
 * </remarks>
 */
public class CriAtomExMic : CriDisposable
{
	/**
	 * <summary>マイクデバイス情報構造体</summary>
	 * <remarks>
	 * <para header='説明'>音声入力デバイス情報の構造体です。<br/>
	 * デバイス情報は ::CriAtomExMic::GetDevices から取得します。<br/></para>
	 * </remarks>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct DeviceInfo
	{
		/**
		 * <summary>デバイスID</summary>
		 * <remarks>
		 * <para header='説明'>プラットフォームのオーディオ入力デバイスの識別子を示す文字列です。<br/></para>
		 * </remarks>
		 */
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
		public string deviceId;
		/**
		 * <summary>デバイス名</summary>
		 * <remarks>
		 * <para header='説明'>プラットフォームのオーディオ入力デバイスの名前情報です。<br/></para>
		 * </remarks>
		 */
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
		public string deviceName;
		/**
		 * <summary>デバイスフラグ</summary>
		 * <remarks>
		 * <para header='説明'>オーディオ入力デバイスを作成する際に参照されるフラグ値です。<br/></para>
		 * </remarks>
		 */
		public uint deviceFlags;
		/**
		 * <summary>最大チャンネル数</summary>
		 * <remarks>
		 * <para header='説明'>サポートされている最大のチャンネル数です。<br/></para>
		 * </remarks>
		 */
		public int maxChannels;
		/**
		 * <summary>最大サンプリング周波数</summary>
		 * <remarks>
		 * <para header='説明'>サポートされている最大のサンプリング周波数です。<br/></para>
		 * </remarks>
		 */
		public int maxSamplingRate;
	}

	/**
	 * <summary>AtomExマイク作成用コンフィグ構造体</summary>
	 * <remarks>
	 * <para header='説明'>AtomExマイクを作成するための、動作仕様を指定するための構造体です。<br/>
	 * ::CriAtomExMic::Create 関数の引数に指定します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::Create'/>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct Config
	{
		/**
		 * <summary>デバイスID</summary>
		 * <remarks>
		 * <para header='説明'>プラットフォームのオーディオ入力デバイスの識別子を示す文字列です。<br/>
		 * 特に指定しない場合はCRIATOMMIC_DEFAULT_DEVICE_IDを指定します。<br/></para>
		 * </remarks>
		 * <seealso cref='CriAtomExMic::Create'/>
		 * <seealso cref='CriAtomExMic::GetDevices'/>
		 */
		[MarshalAs(UnmanagedType.LPStr)]
		public string deviceId;
		/**
		 * <summary>作成フラグ</summary>
		 * <remarks>
		 * <para header='説明'>オーディオ入力デバイスを作成する際に参照されるフラグ値です。<br/></para>
		 * </remarks>
		 */
		public uint flags;
		/**
		 * <summary>チャンネル数</summary>
		 * <remarks>
		 * <para header='説明'>オーディオ入力に要求するチャンネル数です。デフォルトは1です。<br/>
		 * サポートされていないチャンネル数を指定すると作成に失敗します。<br/></para>
		 * </remarks>
		 * <seealso cref='CriAtomExMic::IsFormatSupported'/>
		 */
		public int numChannels;
		/**
		 * <summary>サンプリングレート</summary>
		 * <remarks>
		 * <para header='説明'>オーディオ入力に要求するサンプリング周波数です。デフォルトは44100です。<br/>
		 * サポートされていないサンプリング周波数を指定すると作成に失敗します。<br/></para>
		 * </remarks>
		 * <seealso cref='CriAtomExMic::IsFormatSupported'/>
		 */
		public int samplingRate;
		/**
		 * <summary>フレームサイズ(サンプル数)</summary>
		 * <remarks>
		 * <para header='説明'>1フレームのサイズを示すサンプル数です。デフォルトは256です。<br/>
		 * ::CriAtomExMic::AttachEffect したエフェクトの処理単位になります。<br/></para>
		 * </remarks>
		 */
		public uint frameSize;
		/**
		 * <summary>バッファサイズ(ミリ秒)</summary>
		 * <remarks>
		 * <para header='説明'>内部で持つバッファサイズです。デフォルトは50msecです。<br/>
		 * ::CriAtomExMic::AttachEffect したエフェクトの処理単位になります。<br/></para>
		 * </remarks>
		 */
		public uint bufferingTime;
		/**
		 * <summary>プラットフォームコンテキスト</summary>
		 * <remarks>
		 * <para header='説明'>現時点では使用されていません。<br/></para>
		 * </remarks>
		 */
		public IntPtr context;

		/**
		 * <summary>デフォルト設定</summary>
		 * <remarks>
		 * <para header='説明'>コンフィグ構造体のデフォルト設定です。<br/></para>
		 * </remarks>
		 */
		public static Config Default {
			get {
				Config config = new Config();
				config.deviceId = null;
				config.flags = 0;
				config.numChannels = 1;
				config.samplingRate = 44100;
				config.frameSize = 256;
				config.bufferingTime = 50;
				return config;
			}
		}
	}

	/**
	 * <summary>マイクエフェクト</summary>
	 * <remarks>
	 * <para header='説明'>マイクの入力音声にかけるエフェクトのクラスです。<br/>
	 * ::CriAtomExMic::AttachEffect が返却します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::SetEffectParameter'/>
	 * <seealso cref='CriAtomExMic::UpdateEffectParameter'/>
	 */
	public class Effect
	{
		public IntPtr handle { get; private set; }
		public IntPtr afxInstance { get; private set; }

		public Effect(IntPtr handle, IntPtr afxInstance)
		{
			this.handle = handle;
			this.afxInstance = afxInstance;
		}
	}

	#region Error Messages
	private const string errorInvalidHandle = "[CRIWARE] Invalid native handle of CriAtomMic.";
	private const string errorInvalidBufferLength = "[CRIWARE] Invalid buffer length for CriAtomMic.ReadData.";
	private const string errorInvalidNumBuffers = "[CRIWARE] Number of buffers are not same with channels of CriAtomMic.";
	private const string errorAlreadyInitialized = "[CRIWARE] CriAtomMic module is already initialized.";
	private const string errorNotInitialized = "[CRIWARE] CriAtomMic module is not initialized.";
	#endregion

	public static bool isInitialized { get; private set; }

	/**
	 * <summary>CriAtomMic モジュールの初期化</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomMic モジュールを初期化します。<br/>
	 * モジュールの機能を利用するには、必ずこの関数を実行する必要があります。<br/>
	 * （モジュールの機能は、本関数を実行後、 ::CriAtomExMic::FinalizeModule 関数を実行するまでの間、利用可能です。）<br/></para>
	 * <para header='注意'>本関数を実行後、必ず対になる ::CriAtomExMic::FinalizeModule 関数を実行してください。<br/>
	 * また、 ::CriAtomExMic::FinalizeModule 関数を実行するまでは、本関数を再度実行することはできません。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::FinalizeModule'/>
	 */
	public static void InitializeModule()
	{
		_initializationCount++;
		if (_initializationCount > 1) {
			return;
		}

#if CRIWAREPLUGIN_SUPPORT_MIC
		if (isInitialized) {
			Debug.LogError(errorAlreadyInitialized);
			return;
		}
		criAtomMicUnity_Initialize();
		isInitialized = true;
#else
		Debug.LogError("[CRIWARE] CriAtomExMic does not support this platform.");
#endif
	}

	/**
	 * <summary>CriAtomMic モジュールの終了</summary>
	 * <remarks>
	 * <para header='説明'>CriAtomMic モジュールを終了します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::InitializeModule'/>
	 */
	public static void FinalizeModule()
	{
		_initializationCount--;
		if (_initializationCount > 0) {
			return;
		} else if (_initializationCount < 0) {
			_initializationCount = 0;
		}

#if CRIWAREPLUGIN_SUPPORT_MIC
		if (!isInitialized) {
			Debug.LogError(errorNotInitialized);
			return;
		}
		CriDisposableObjectManager.CallOnModuleFinalization(CriDisposableObjectManager.ModuleType.AtomMic);
		criAtomMicUnity_Finalize();
		isInitialized = false;
#endif
	}

	/**
	 * <summary>マイクデバイスの取得</summary>
	 * <returns>マイクデバイス配列</returns>
	 * <remarks>
	 * <para header='説明'>マイクデバイスの情報を取得します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::GetDefaultDevice'/>
	 */
	public static DeviceInfo[] GetDevices()
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		if (!isInitialized) {
			Debug.LogError(errorNotInitialized);
			return null;
		}

		int numDevices = criAtomMic_GetNumDevices();
		var devices = new DeviceInfo[numDevices];
		for (int i = 0; i < numDevices; i++) {
			criAtomMic_GetDevice(i, out devices[i]);
		}
		return devices;
#else
		return null;
#endif
	}

	/**
	 * <summary>マイクデバイス数の取得</summary>
	 * <returns>マイクデバイス数</returns>
	 * <remarks>
	 * <para header='説明'>端末に接続されたマイクデバイスの数を取得します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::GetDevices'/>
	 */
	public static int GetNumDevices()
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		return criAtomMic_GetNumDevices();
#else
		return 0;
#endif
	}

	/**
	 * <summary>デフォルトマイクデバイスの取得</summary>
	 * <returns>マイクデバイス構造体</returns>
	 * <remarks>
	 * <para header='説明'>デフォルト設定されたマイクデバイスの情報を取得します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::GetDevices'/>
	 */
	public static DeviceInfo? GetDefaultDevice()
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		if (!isInitialized) {
			Debug.LogError(errorNotInitialized);
			return null;
		}

		var device = new DeviceInfo();
		bool result = criAtomMic_GetDefaultDevice(out device);
		if (result) {
			return device;
		}
#endif
		return null;
	}

	/**
	 * <summary>フォーマットがサポート状況の取得</summary>
	 * <param name='config'>コンフィグ情報</param>
	 * <returns>true:サポート, false:非サポート</returns>
	 * <remarks>
	 * <para header='説明'>指定したコンフィグ情報のフォーマットがサポートされているか取得します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::GetDevices'/>
	 */
	public static bool IsFormatSupported(Config config)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		return criAtomMic_IsFormatSupported(ref config);
#else
		return false;
#endif
	}

	#region Internal Members
	private IntPtr handle = IntPtr.Zero;
	private IntPtr[] bufferPointers = null;
	private GCHandle[] gcHandles = null;
#if CRIWAREPLUGIN_SUPPORT_MIC
	private CriAudioWriteStream outputWriteStream = null;
#endif

	private static int _initializationCount = 0;
	#endregion

	/**
	 * <summary>AtomExマイクの作成</summary>
	 * <param name='config'>コンフィグ情報</param>
	 * <returns>AtomExマイク</returns>
	 * <remarks>
	 * <para header='説明'>音声キャプチャするためのマイクインスタンスを作成します。<br/>
	 * <br/>
	 * ::CriAtomExMic::Create 関数を実行すると、AtomExマイクが作成され、
	 * マイクを制御するためのインスタンス（ CriAtomExMic ）が返されます。<br/>
	 * <br/>
	 * 音声入力デバイスのオープンに失敗した場合、本関数はnullを返します。
	 * <br/>
	 * 実際に音声入力を開始するには ::CriAtomExMic::Start 関数を実行します。<br/>
	 * 入力された音声データは ::CriAtomExMic::ReadData 関数で取得します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::Destroy'/>
	 */
	public static CriAtomExMic Create(Config? config = null)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		if (!isInitialized) {
			Debug.LogError(errorNotInitialized);
			return null;
		}

		Config internalConfig = (config.HasValue) ? config.Value : Config.Default;
		IntPtr handle = criAtomMic_Create(ref internalConfig, IntPtr.Zero, 0);
		if (handle == IntPtr.Zero) {
			Debug.LogWarning("Failed to open audio input device.");
			return null;
		}
		return new CriAtomExMic(handle);
#else
		return null;
#endif
	}

	private CriAtomExMic(IntPtr handle)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		this.handle = handle;
		int numChannels = this.GetNumChannels();
		this.bufferPointers = new IntPtr[numChannels];
		this.gcHandles = new GCHandle[numChannels];

		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.AtomMic);
#endif
	}

	/**
	 * <summary>マイクの破棄</summary>
	 * <remarks>
	 * <para header='説明'>音声入力用のマイクを破棄します。<br/></para>
	 * <para header='注意'>本関数は完了復帰型の関数です。実行にかかる時間は、プラットフォームによって異なります。<br/>
	 * ゲームループ等の画面更新が必要なタイミングで本関数を実行するとミリ秒単位で
	 * 処理がブロックされ、フレーム落ちが発生する恐れがあります。<br/>
	 * マイクの作成／破棄は、シーンの切り替わり等、負荷変動を許容できる
	 * タイミングで行うようお願いいたします。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::Create'/>
	 */
	public override void Dispose()
	{
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		CriDisposableObjectManager.Unregister(this);

		if (this.handle != IntPtr.Zero) {
			criAtomMic_Destroy(this.handle);
			this.handle = IntPtr.Zero;
		}
#endif
	}

	/**
	 * <summary>マイクの音声入力開始</summary>
	 * <remarks>
	 * <para header='説明'>マイクの音声入力を開始します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::Create'/>
	 * <seealso cref='CriAtomExMic::Stop'/>
	 */
	public void Start()
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		criAtomMic_Start(this.handle);
#endif
	}

	/**
	 * <summary>マイクの音声入力停止</summary>
	 * <remarks>
	 * <para header='説明'>マイクの音声入力を停止します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::Create'/>
	 * <seealso cref='CriAtomExMic::Start'/>
	 */
	public void Stop()
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		criAtomMic_Stop(this.handle);
#endif
	}

	/**
	 * <summary>マイクのチャンネル数の取得</summary>
	 * <returns>チャンネル数</returns>
	 * <remarks>
	 * <para header='説明'>マイクのチャンネル数を取得します。<br/></para>
	 * </remarks>
	 */
	public int GetNumChannels()
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		return criAtomMic_GetNumChannels(this.handle);
#else
		return 0;
#endif
	}

	/**
	 * <summary>マイクのサンプリング周波数の取得</summary>
	 * <returns>サンプリング周波数</returns>
	 * <remarks>
	 * <para header='説明'>マイクのサンプリング周波数を取得します。<br/></para>
	 * </remarks>
	 */
	public int GetSamplingRate()
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		return criAtomMic_GetSamplingRate(this.handle);
#else
		return 0;
#endif
	}

	/**
	 * <summary>バッファリングされたデータのサンプル数取得</summary>
	 * <returns>バッファリングされているサンプル数</returns>
	 * <remarks>
	 * <para header='説明'>内部のバッファに存在するマイク入力データのサンプル数を取得します。<br/></para>
	 * </remarks>
	 */
	public uint GetNumBufferredSamples()
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		return criAtomMic_GetNumBufferredSamples(this.handle);
#else
		return 0;
#endif
	}

	/**
	 * <summary>マイクの使用可能状態の取得</summary>
	 * <returns>使用可能かどうか(true:使用可能、false:使用不可)</returns>
	 * <remarks>
	 * <para header='説明'>オーディオ入力デバイスの状態をチェックして使用可能かどうかを取得します。<br/></para>
	 * </remarks>
	 */
	public bool IsAvailable()
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		return this.handle != IntPtr.Zero ? criAtomMic_IsAvailable(this.handle) : false;
#else
		return false;
#endif
	}

	/**
	 * <summary>マイク入力データの読み出し(モノラル)</summary>
	 * <param name='bufferMono'>データバッファ</param>
	 * <returns>取得できたサンプル数</returns>
	 * <remarks>
	 * <para header='説明'>マイクに入力されたデータを取得します。<br/>
	 * 本関数は定期的に呼び出しを行わず内部バッファが一杯になると、
	 * バッファに入りきらないデータは捨てられます。</para>
	 * <para header='注意'>本関数はチャンネル数1を指定して ::CriAtomExMic::Start を呼び出した場合にのみ
	 * 有効です。<br/>
	 * その他の場合はアサート失敗します。</para>
	 * </remarks>
	 */
	public uint ReadData(float[] bufferMono)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		return ReadData(bufferMono, (uint)bufferMono.Length);
#else
		return 0;
#endif
	}

	/**
	 * <summary>マイク入力データの読み出し(モノラル)</summary>
	 * <param name='bufferMono'>データバッファ</param>
	 * <param name='numToRead'>読み出すサンプル数</param>
	 * <returns>取得できたサンプル数</returns>
	 * <remarks>
	 * <para header='説明'>マイクに入力されたデータを取得します。<br/>
	 * 本関数は定期的に呼び出しを行わず内部バッファが一杯になると、
	 * バッファに入りきらないデータは捨てられます。</para>
	 * <para header='注意'>本関数はチャンネル数1を指定して ::CriAtomExMic::Start を呼び出した場合にのみ
	 * 有効です。<br/>
	 * その他の場合はアサート失敗します。</para>
	 * </remarks>
	 */
	public uint ReadData(float[] bufferMono, uint numToRead)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		Debug.Assert(this.bufferPointers.Length == 1, errorInvalidNumBuffers);
		Debug.Assert(bufferMono.Length >= numToRead && numToRead > 0, errorInvalidBufferLength);

		if (this.outputWriteStream != null) {
			return 0;
		}

		var gch = GCHandle.Alloc(bufferMono, GCHandleType.Pinned);
		this.bufferPointers[0] = gch.AddrOfPinnedObject();

		uint result = InternalReadDataFromBufferPointers(numToRead);
		InternalClearBuffers();
		return result;
#else
		return 0;
#endif
	}

	/**
	 * <summary>マイク入力データの読み出し(ステレオ)</summary>
	 * <param name='bufferL'>データバッファ(Lチャンネル)</param>
	 * <param name='bufferR'>データバッファ(Rチャンネル)</param>
	 * <returns>取得できたサンプル数</returns>
	 * <remarks>
	 * <para header='説明'>マイクに入力されたデータを取得します。<br/>
	 * 本関数は定期的に呼び出しを行わず内部バッファが一杯になると、
	 * バッファに入りきらないデータは捨てられます。</para>
	 * <para header='注意'>本関数はチャンネル数2を指定して ::CriAtomExMic::Start を呼び出した場合にのみ
	 * 有効です。<br/>
	 * その他の場合はアサート失敗します。<br/>
	 * また、各データバッファは等しい配列長となるようにしてください。</para>
	 * </remarks>
	 */
	public uint ReadData(float[] bufferL, float[] bufferR)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(bufferL.Length == bufferR.Length, errorInvalidBufferLength);

		return ReadData(bufferL, bufferR, (uint)bufferL.Length);
#else
		return 0;
#endif
	}

	/**
	 * <summary>マイク入力データの読み出し(ステレオ)</summary>
	 * <param name='bufferL'>データバッファ(Lチャンネル)</param>
	 * <param name='bufferR'>データバッファ(Rチャンネル)</param>
	 * <param name='numToRead'>読み出すサンプル数</param>
	 * <returns>取得できたサンプル数</returns>
	 * <remarks>
	 * <para header='説明'>マイクに入力されたデータを取得します。<br/>
	 * 本関数は定期的に呼び出しを行わず内部バッファが一杯になると、
	 * バッファに入りきらないデータは捨てられます。</para>
	 * <para header='注意'>本関数はチャンネル数2を指定して ::CriAtomExMic::Start を呼び出した場合にのみ
	 * 有効です。<br/>
	 * その他の場合はアサート失敗します。<br/>
	 * また、各データバッファはすべて numToRead 以上の配列長となるようにしてください。</para>
	 * </remarks>
	 */
	public uint ReadData(float[] bufferL, float[] bufferR, uint numToRead)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		Debug.Assert(this.bufferPointers.Length == 2, errorInvalidNumBuffers);
		Debug.Assert(bufferL.Length >= numToRead && bufferR.Length >= numToRead, errorInvalidBufferLength);

		if (this.outputWriteStream != null) {
			return 0;
		}

		this.gcHandles[0] = GCHandle.Alloc(bufferL, GCHandleType.Pinned);
		this.gcHandles[1] = GCHandle.Alloc(bufferR, GCHandleType.Pinned);
		for (int i = 0; i < this.bufferPointers.Length; i++) {
			this.bufferPointers[i] = this.gcHandles[i].AddrOfPinnedObject();
		}
		for (int i = 2; i < this.bufferPointers.Length; i++) {
			this.bufferPointers[i] = IntPtr.Zero;
		}

		uint result = InternalReadDataFromBufferPointers(numToRead);
		InternalClearBuffers();

		return result;
#else
		return 0;
#endif
	}

	/**
	 * <summary>マイク入力データの読み出し(マルチチャンネル)</summary>
	 * <param name='buffers'>データバッファ配列</param>
	 * <returns>取得できたサンプル数</returns>
	 * <remarks>
	 * <para header='説明'>マイクに入力されたデータを取得します。<br/>
	 * 本関数は定期的に呼び出しを行わず内部バッファが一杯になると、
	 * バッファに入りきらないデータは捨てられます。</para>
	 * <para header='注意'>本関数に渡すデータバッファ配列の配列長は、 CriAtomExMic::Start に渡した
	 * CriAtomExMic::Config のチャンネル数以上である必要があります。<br/>
	 * その他の場合はアサート失敗します。<br/>
	 * また、各データバッファはすべて numToRead 以上の配列長となるようにしてください。</para>
	 * </remarks>
	 */
	public uint ReadData(float[][] buffers)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(buffers != null);
		Debug.Assert(buffers.Length >= this.bufferPointers.Length, errorInvalidNumBuffers);

		int bufferLength = buffers[0].Length;
		for (int i = 1; i < this.bufferPointers.Length; i++) {
			Debug.Assert(buffers[i].Length == bufferLength, errorInvalidNumBuffers);
		}

		return ReadData(buffers, (uint)bufferLength);
#else
		return 0;
#endif
	}

	/**
	 * <summary>マイク入力データの読み出し(マルチチャンネル)</summary>
	 * <param name='buffers'>データバッファ配列</param>
	 * <param name='numToRead'>読み出すサンプル数</param>
	 * <returns>取得できたサンプル数</returns>
	 * <remarks>
	 * <para header='説明'>マイクに入力されたデータを取得します。<br/>
	 * 本関数は定期的に呼び出しを行わず内部バッファが一杯になると、
	 * バッファに入りきらないデータは捨てられます。</para>
	 * <para header='注意'>本関数に渡すデータバッファ配列の配列長は、 ::CriAtomExMic::Start に渡した
	 * CriAtomExMic::Config のチャンネル数と等しい必要があります。<br/>
	 * その他の場合はアサート失敗します。<br/>
	 * また、各データバッファは numToRead 以上の配列長となるようにしてください。</para>
	 * </remarks>
	 */
	public uint ReadData(float[][] buffers, uint numToRead)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		Debug.Assert(buffers != null);
		Debug.Assert(buffers.Length >= this.bufferPointers.Length);
		Debug.Assert(numToRead > 0);

		for (int i = 0; i < this.bufferPointers.Length; i++) {
			Debug.Assert(buffers[i].Length >= numToRead);
		}

		if (this.outputWriteStream != null) {
			return 0;
		}

		for (int i = 0; i < this.bufferPointers.Length; i++) {
			this.gcHandles[i] = GCHandle.Alloc(buffers[i], GCHandleType.Pinned);
			this.bufferPointers[i] = this.gcHandles[i].AddrOfPinnedObject();
		}

		uint result = InternalReadDataFromBufferPointers(numToRead);
		InternalClearBuffers();

		return result;
#else
		return 0;
#endif
	}

	/**
	 * <summary>ライトストリームの設定</summary>
	 * <param name='stream'>ライトストリーム</param>
	 * <remarks>
	 * <para header='説明'>マイクに出力方向のライトストリームを設定します。<br/>
	 * ライトストリームのコールバック関数はマイク入力が行われたタイミングで呼び出されます。<br/>
	 * コールバック関数は大抵のプラットフォームで別スレッドから呼ばれるため、
	 * 呼ばれる側はスレッドセーフ実装する必要があります。</para>
	 * </remarks>
	 */
	public void SetOutputWriteStream(CriAudioWriteStream stream)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		this.outputWriteStream = stream;
		if (stream != null) {
			criAtomMic_SetOutputWriteStream(this.handle, stream.callbackFunction, stream.callbackPointer);
		} else {
			criAtomMic_SetOutputWriteStream(this.handle, IntPtr.Zero, IntPtr.Zero);
		}
#endif
	}

	/**
	 * <summary>リードストリームの取得</summary>
	 * <returns>リードストリームのコールバック関数</returns>
	 * <remarks>
	 * <para header='説明'>マイクの出力方向のリードストリームを取得します。<br/>
	 * リードストリームのコールバック関数を呼び出す際は、第1引数にAtomExマイクハンドルを指定する必要があります。<br/>
	 * リードストリームのコールバック関数は定期的に呼び出しを行わず内部バッファが一杯になると、
	 * バッファに入りきらないデータは捨てられます。</para>
	 * </remarks>
	 */
	public CriAudioReadStream GetOutputReadStream()
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		return new CriAudioReadStream(criAtomMic_GetOutputReadStream(), this.handle);
#else
		return null;
#endif
	}

	/**
	 * <summary>エフェクトの追加</summary>
	 * <param name='afxInterface'>CriAfxインターフェース</param>
	 * <param name='configParameters'>CriAfx作成用コンフィグパラメータ配列</param>
	 * <returns>マイクエフェクト</returns>
	 * <remarks>
	 * <para header='説明'>マイクにエフェクトを追加します。<br/>
	 * 追加するエフェクトはCriAfxインターフェースで作成されている必要があります。<br/>
	 * <br/>
	 * マイク動作中に本関数を実行するとエフェクト処理が急に行われるようになるため
	 * 音にノイズが入る可能性があります。</para>
	 * </remarks>
	 */
	public Effect AttachEffect(IntPtr afxInterface, float[] configParameters)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		IntPtr effectHandle = criAtomMic_AttachEffect(this.handle, afxInterface,
			configParameters, (uint)configParameters.Length, IntPtr.Zero, 0);
		if (effectHandle == IntPtr.Zero) {
			return null;
		}
		return new Effect(effectHandle, criAtomMic_GetEffectInstance(this.handle, effectHandle));
#else
		return null;
#endif
	}

	/**
	 * <summary>エフェクトの削除</summary>
	 * <param name='effect'>マイクエフェクト</param>
	 * <remarks>
	 * <para header='説明'>マイクのエフェクトを削除します。<br/>
	 * <br/>
	 * マイク動作中に本関数を実行するとエフェクト処理が急に行われなくなるため
	 * 音にノイズが入る可能性があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::AttachEffect'/>
	 */
	public void DetachEffect(Effect effect)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		criAtomMic_DetachEffect(this.handle, effect.handle);
#endif
	}

	/**
	 * <summary>エフェクトパラメータの設定</summary>
	 * <param name='effect'>マイクエフェクト</param>
	 * <param name='parameterIndex'>パラメータインデックス</param>
	 * <param name='parameterValue'>パラメータ値</param>
	 * <remarks>
	 * <para header='説明'>マイクのエフェクトにパラメータを設定します。<br/>
	 * パラメータのインデックスを指定して対応したパラメータの値を設定します。<br/>
	 * <br/>
	 * 本関数を呼ぶだけではエフェクトにパラメータの反映が行われないため、
	 * 最終的にcriAtomMic_UpdateEffectParametersを実行してパラメータを反映させる必要があります。。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::UpdateEffectParameters'/>
	 */
	public void SetEffectParameter(Effect effect, int parameterIndex, float parameterValue)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		criAtomMic_SetEffectParameter(this.handle, effect.handle, (uint)parameterIndex, parameterValue);
#endif
	}

	/**
	 * <summary>エフェクトパラメータの取得</summary>
	 * <param name='effect'>マイクエフェクト</param>
	 * <param name='parameterIndex'>パラメータインデックス</param>
	 * <returns>パラメータ値</returns>
	 * <remarks>
	 * <para header='説明'>マイクのエフェクトにパラメータを取得します。<br/>
	 * パラメータのインデックスを指定すると対応したパラメータの値が返ります。<br/></para>
	 * </remarks>
	 */
	public float GetEffectParameter(Effect effect, int parameterIndex)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		return criAtomMic_GetEffectParameter(this.handle, effect.handle, (uint)parameterIndex);
#else
		return 0.0f;
#endif
	}

	/**
	 * <summary>エフェクトのバイパス設定</summary>
	 * <param name='effect'>マイクエフェクト</param>
	 * <param name='bypass'>バイパス設定</param>
	 * <remarks>
	 * <para header='説明'>マイクのエフェクトのバイパスを設定します。<br/>
	 * bypassにtrueを指定するとエフェクトの処理が行われなくなります。<br/></para>
	 * </remarks>
	 */
	public void SetEffectBypass(Effect effect, bool bypass)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		criAtomMic_SetEffectBypass(this.handle, effect.handle, bypass);
#endif
	}

	/**
	 * <summary>エフェクトパラメータの設定</summary>
	 * <param name='effect'>マイクエフェクト</param>
	 * <remarks>
	 * <para header='説明'>マイクのエフェクトにパラメータを設定します。<br/>
	 * パラメータのインデックスを指定して対応したパラメータの値を設定します。<br/>
	 * <br/>
	 * 本関数を呼ぶだけではエフェクトにパラメータの反映が行われないため、
	 * 最終的にcriAtomMic_UpdateEffectParametersを実行してパラメータを反映させる必要があります。。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExMic::UpdateEffectParameters'/>
	 */
	public void UpdateEffectParameters(Effect effect)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		criAtomMic_UpdateEffectParameters(this.handle, effect.handle);
#endif
	}

	private uint InternalReadDataFromBufferPointers(uint numToRead)
	{
#if CRIWAREPLUGIN_SUPPORT_MIC
		return criAtomMic_ReadData(this.handle, this.bufferPointers, numToRead);
#else
		return 0;
#endif
	}

	private void InternalClearBuffers()
	{
		for (int i = 0; i < bufferPointers.Length; i++) {
			if (this.gcHandles[i].IsAllocated) {
				this.gcHandles[i].Free();
			}
			this.bufferPointers[i] = IntPtr.Zero;
		}
	}

	#region DLL Import
#if CRIWAREPLUGIN_SUPPORT_MIC
	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomMicUnity_Initialize();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomMicUnity_Finalize();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomMic_GetNumDevices();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomMic_GetDevice(int index, out DeviceInfo info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomMic_GetDefaultDevice(out DeviceInfo info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomMic_IsFormatSupported([In] ref Config config);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomMic_Create([In] ref Config config, IntPtr work, int work_size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomMic_Destroy(IntPtr mic);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomMic_Start(IntPtr mic);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomMic_Stop(IntPtr mic);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomMic_GetNumChannels(IntPtr mic);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomMic_GetSamplingRate(IntPtr mic);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern uint criAtomMic_GetNumBufferredSamples(IntPtr mic);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomMic_IsAvailable(IntPtr mic);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern uint criAtomMic_ReadData(IntPtr mic, IntPtr[] data, uint num_samples);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomMic_SetOutputWriteStream(IntPtr mic, IntPtr stream_cbfunc, IntPtr stream_ptr);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomMic_GetOutputReadStream();

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomMic_CalculateWorkSizeForEffect(IntPtr mic,
		IntPtr afx_interface, float[] config_parameters, uint num_config_parameters);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomMic_AttachEffect(IntPtr mic,
		IntPtr afx_interface, float[] config_parameters, uint num_config_parameters,
		IntPtr work, int work_size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomMic_DetachEffect(IntPtr mic, IntPtr effect);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomMic_GetEffectInstance(IntPtr mic, IntPtr effect);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomMic_SetEffectBypass(IntPtr mic, IntPtr effect, bool bypass);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomMic_SetEffectParameter(IntPtr mic, IntPtr effect,
		uint parameter_index, float parameter_value);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern float criAtomMic_GetEffectParameter(IntPtr mic, IntPtr effect, uint parameter_index);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomMic_UpdateEffectParameters(IntPtr mic, IntPtr effect);
	#else
	private static void criAtomMicUnity_Initialize() { }
	private static void criAtomMicUnity_Finalize() { }
	private static int criAtomMic_GetNumDevices() { return 0; }
	private static bool criAtomMic_GetDevice(int index, out DeviceInfo info) { info = new DeviceInfo(); return false; }
	private static bool criAtomMic_GetDefaultDevice(out DeviceInfo info) { info = new DeviceInfo(); return false; }
	private static bool criAtomMic_IsFormatSupported([In] ref Config config) { return false; }
	private static IntPtr criAtomMic_Create([In] ref Config config, IntPtr work, int work_size) { return IntPtr.Zero; }
	private static void criAtomMic_Destroy(IntPtr mic) { }
	private static void criAtomMic_Start(IntPtr mic) { }
	private static void criAtomMic_Stop(IntPtr mic) { }
	private static int criAtomMic_GetNumChannels(IntPtr mic) { return 0; }
	private static int criAtomMic_GetSamplingRate(IntPtr mic) { return 0; }
	private static uint criAtomMic_GetNumBufferredSamples(IntPtr mic) { return 0u; }
	private static bool criAtomMic_IsAvailable(IntPtr mic) { return false; }
	private static uint criAtomMic_ReadData(IntPtr mic, IntPtr[] data, uint num_samples) { return 0u; }
	private static void criAtomMic_SetOutputWriteStream(IntPtr mic, IntPtr stream_cbfunc, IntPtr stream_ptr) { }
	private static IntPtr criAtomMic_GetOutputReadStream() { return IntPtr.Zero; }
	private static int criAtomMic_CalculateWorkSizeForEffect(IntPtr mic,
		IntPtr afx_interface, float[] config_parameters, uint num_config_parameters) { return 0; }
	private static IntPtr criAtomMic_AttachEffect(IntPtr mic,
		IntPtr afx_interface, float[] config_parameters, uint num_config_parameters,
		IntPtr work, int work_size) { return IntPtr.Zero; }
	private static void criAtomMic_DetachEffect(IntPtr mic, IntPtr effect) { }
	private static IntPtr criAtomMic_GetEffectInstance(IntPtr mic, IntPtr effect) { return IntPtr.Zero; }
	private static void criAtomMic_SetEffectBypass(IntPtr mic, IntPtr effect, bool bypass) { }
	private static void criAtomMic_SetEffectParameter(IntPtr mic, IntPtr effect,
		uint parameter_index, float parameter_value) { }
	private static float criAtomMic_GetEffectParameter(IntPtr mic, IntPtr effect, uint parameter_index) { return 0.0f; }
	private static void criAtomMic_UpdateEffectParameters(IntPtr mic, IntPtr effect) { }
	#endif
#endif
	#endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
