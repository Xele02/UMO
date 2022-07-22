/****************************************************************************
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

/*==========================================================================
 *      CRI Atom Native Wrapper
 *=========================================================================*/
/**
 * \addtogroup CRIATOM_NATIVE_WRAPPER
 * @{
 */

namespace CriWare {

/**
 * <summary>AtomExプレーヤ</summary>
 * <remarks>
 * <para header='説明'>音声再生制御に用いるプレーヤクラスです。<br/>
 * データのセットや再生の開始、ステータスの取得等の制御を行います。<br/></para>
 * </remarks>
 */
public class CriAtomExPlayer : CriDisposable
{
	public IntPtr nativeHandle {get {return this.handle;} }
	public bool isAvailable {get {return this.handle != IntPtr.Zero;} }
	private event CriAtomExBeatSync.CbFunc _onBeatSyncCallback = null;

	/**
	 * <summary>シーケンスイベントコールバックの登録</summary>
	 * <remarks>
	 * <para header='説明'>プレーヤで再生しているキューに埋め込まれたコールバックマーカー同期で実行するコールバック関数を登録します。<br/>
	 * 登録されたコールバック関数は、コールバックイベントを処理した直後の、アプリケーション
	 * メインスレッドの更新タイミングで実行されます。<br/></para>
	 * </remarks>
	 */
	public event CriAtomExBeatSync.CbFunc OnBeatSyncCallback {
		add {
			if (_onBeatSyncCallback == null) {
				CriAtom.OnBeatSyncCallback += OnBeatSyncCallbackChainInternal;
			}
			_onBeatSyncCallback += value;
		}
		remove {
			_onBeatSyncCallback -= value;
			if (_onBeatSyncCallback == null) {
				CriAtom.OnBeatSyncCallback -= OnBeatSyncCallbackChainInternal;
			}
		}
	}

	private event CriAtomExSequencer.EventCallback _onSequenceCallback = null;

	/**
	 * <summary>ビート同期コールバックの登録</summary>
	 * <remarks>
	 * <para header='説明'>プレーヤで再生しているキューに埋め込まれたビート同期位置情報を受け取るコールバック関数を登録します。<br/>
	 * 登録されたコールバック関数は、コールバックイベントを処理した直後の、アプリケーション
	 * メインスレッドの更新タイミングで実行されます。<br/></para>
	 * </remarks>
	 */
	public event CriAtomExSequencer.EventCallback OnSequenceCallback
		{
		add {
			if (_onSequenceCallback == null) {
				CriAtomExSequencer.OnCallback += OnSequenceCallbackChainInternal;
			}
			_onSequenceCallback += value;
		}
		remove {
			_onSequenceCallback -= value;
			if (_onSequenceCallback == null) {
				CriAtomExSequencer.OnCallback -= OnSequenceCallbackChainInternal;
			}
		}
	}

	private bool hasExistingNativeHandle = false;
	private IntPtr entryPoolHandle = IntPtr.Zero;
	private int _entryPoolCapacity = 0;
    private int max_path = 0;

	/**
	 * <summary>プレーヤステータス</summary>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤの再生状態を示す値です。<br/>
	 * ::CriAtomExPlayer::GetStatus 関数で取得可能です。<br/>
	 * <br/>
	 * 再生状態は、通常以下の順序で遷移します。<br/>
	 * -# Stop
	 * -# Prep
	 * -# Playing
	 * -# PlayEnd
	 * .
	 * AtomExプレーヤ作成直後の状態は、停止状態（ Stop ）です。<br/>
	 * ::CriAtomExPlayer::SetCue 関数等でデータをセットし、 ::CriAtomExPlayer::Start
	 * 関数を実行すると、再生準備状態（ Prep ）に遷移し、再生準備を始めます。<br/>
	 * データが充分供給され、再生準備が整うと、ステータスは再生中（ Playing ）
	 * に変わり、音声の出力が開始されます。<br/>
	 * セットされたデータを全て再生し終えた時点で、ステータスは再生完了
	 * （ PlayEnd ）に変わります。</para>
	 * <para header='備考'>AtomExプレーヤは、1つのプレーヤで複数音の再生が可能です。<br/>
	 * 再生中のAtomExプレーヤに対して ::CriAtomExPlayer::Start 関数を実行すると、
	 * 2つの音が重なって再生されます。<br/>
	 * 再生中に ::CriAtomExPlayer::Stop 関数を実行した場合、
	 * AtomExプレーヤで再生中の全ての音声が停止し、ステータスは Stop に戻ります。<br/>
	 * （ ::CriAtomExPlayer::Stop 関数の呼び出しタイミングによっては、 Stop
	 * に遷移するまでに時間がかかる場合があります。）<br/>
	 * <br/>
	 * 1つのAtomExプレーヤで複数回 ::CriAtomExPlayer::Start 関数を実行した場合、
	 * 1つでも再生準備中の音があれば、ステータスは Prep 状態になります。<br/>
	 * （全ての音声が再生中の状態になるまで、ステータスは Playing 状態に
	 * 遷移しません。）<br/>
	 * また、 Playing 状態のプレーヤに対し、再度 ::CriAtomExPlayer::Start
	 * 関数を実行した場合、ステータスは一時的に Prep に戻ります。<br/>
	 * <br/>
	 * 再生中に不正なデータを読み込んだ場合や、ファイルアクセスに失敗した場合、
	 * ステータスは Error に遷移します。<br/>
	 * 複数の音声を再生中にある音声でエラーが発生した場合、プレーヤのステータスは
	 * 他の音声の状態に関係なく、 Error に遷移します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::GetStatus'/>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer'/>
	 */
	public enum Status {
		Stop = 0,       /**< 停止中 */
		Prep,           /**< 再生準備中 */
		Playing,        /**< 再生中 */
		PlayEnd,        /**< 再生完了 */
		Error,          /**< エラーが発生 */
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	private struct Config {
		public CriAtomEx.VoiceAllocationMethod voiceAllocationMethod;
		public int maxPathStrings;
		public int maxPath;
		public int maxAisacs;
		public bool updatesTime;
		public bool enableAudioSyncedTimer;
	}

	/**
	 * <summary>AtomExPlayerの作成</summary>
	 * <returns>AtomExプレーヤ</returns>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤを作成します。<br/>
	 * <br/>
	 * 作成されたAtomExプレーヤを使用して音声データを再生する手順は以下のとおりです。<br/>
	 * -# ::CriAtomExPlayer::SetCue 関数を使用して、AtomExプレーヤに再生するデータをセットする。<br/>
	 * -# ::CriAtomExPlayer::Start 関数で再生を開始する。<br/></para>
	 * <para header='注意'>本関数を実行する前に、ライブラリを初期化しておく必要があります。<br/>
	 * <br/>
	 * パッキングされていない音声ファイルを ::CriAtomExPlayer::SetFile
	 * 関数で指定して再生する場合、本関数の代わりに
	 * ::CriAtomExPlayer::CriAtomExPlayer(int, int) を使用する必要があります。<br/>
	 * <br/>
	 * 本関数は完了復帰型の関数です。<br/>
	 * AtomExプレーヤの作成にかかる時間は、プラットフォームによって異なります。<br/>
	 * ゲームループ等の画面更新が必要なタイミングで本関数を実行するとミリ秒単位で
	 * 処理がブロックされ、フレーム落ちが発生する恐れがあります。<br/>
	 * AtomExプレーヤの作成／破棄は、シーンの切り替わり等、負荷変動を許容できる
	 * タイミングで行うようお願いいたします。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Dispose'/>
	 * <seealso cref='CriAtomExPlayer::SetCue'/>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer(int, int)'/>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer(bool)'/>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer(int, int, bool)'/>
	 */
	public CriAtomExPlayer() : this(0, 0, false, IntPtr.Zero)
	{
	}

	/**
	 * <summary>AtomExPlayerの作成（単体ファイル再生用）</summary>
	 * <param name='maxPath'>最大パス文字列長</param>
	 * <param name='maxPathStrings'>同時再生ファイル数</param>
	 * <returns>AtomExプレーヤ</returns>
	 * <remarks>
	 * <para header='説明'>単体ファイル再生用にAtomExプレーヤを作成します。<br/>
	 * 単体ファイル再生が可能な点を除き、基本的な仕様は
	 * ::CriAtomExPlayer::CriAtomExPlayer() 関数と同じです。<br/></para>
	 * <para header='備考'>本関数で作成されたAtomExプレーヤは、
	 * 単体ファイル再生用にmaxPath×maxPathStrings分のメモリ領域を確保します。<br/>
	 * この領域は、ACBファイルやAWBファイルを再生する際には使用されません。<br/>
	 * ::CriAtomExPlayer::SetFile 関数を使用しない場合、本関数の代わりに
	 * ::CriAtomExPlayer::CriAtomExPlayer() を使用することで、
	 * メモリ使用量を抑えることが可能です。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer()'/>
	 */
	public CriAtomExPlayer(int maxPath, int maxPathStrings) : this(maxPath, maxPathStrings, false, IntPtr.Zero)
	{
	}

	/**
	 * <summary>AtomExPlayerの作成（音声同期タイマ利用）</summary>
	 * <param name='enableAudioSyncedTimer'>音声同期タイマ有効フラグ</param>
	 * <returns>AtomExプレーヤ</returns>
	 * <remarks>
	 * <para header='説明'>音声同期タイマが利用可能なAtomExプレーヤを作成します。<br/>
	 * 音声に同期した再生時刻が取得可能な点を除き、基本的な仕様は
	 * ::CriAtomExPlayer::CriAtomExPlayer() 関数と同じです。<br/></para>
	 * <para header='備考'>本関数で引数に true を指定して作成されたAtomExプレーヤを用いて
	 * 再生された音声に対しては、再生済みサンプル数に同期する時刻の更新処理が
	 * 行われるようになります。<br/>
	 * ::CriAtomExPlayback::GetTimeSyncedWithAudio 関数を使用しない場合、
	 * 本関数の引数に false を指定するか、本関数の代わりに
	 * ::CriAtomExPlayer::CriAtomExPlayer() を使用することで、負荷の増加を
	 * 抑えることが可能です。<br/></para>
	 * <para header='注意'>本関数で引数に true を指定して作成されたAtomExプレーヤに対しては、
	 * ::CriAtomExPlayer::SetPitch 関数による再生ピッチの変更は行えません。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer()'/>
	 * <seealso cref='CriAtomExPlayback::GetTimeSyncedWithAudio()'/>
	 */
	public CriAtomExPlayer(bool enableAudioSyncedTimer) : this(0, 0, enableAudioSyncedTimer, IntPtr.Zero)
	{
	}

	/**
	 * <summary>AtomExPlayerの作成（単体ファイル再生、音声同期タイマ利用）</summary>
	 * <param name='maxPath'>最大パス文字列長</param>
	 * <param name='maxPathStrings'>同時再生ファイル数</param>
	 * <param name='enableAudioSyncedTimer'>音声同期タイマ有効フラグ</param>
	 * <returns>AtomExプレーヤ</returns>
	 * <remarks>
	 * <para header='説明'>単体ファイル再生用にAtomExプレーヤを作成します。<br/>
	 * enableAudioSyncedTimer へのフラグ指定により、音声に同期した再生時刻が
	 * 取得可能になります。<br/>
	 * 基本的な仕様は ::CriAtomExPlayer::CriAtomExPlayer() 関数と同じです。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer()'/>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer(int, int)'/>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer(bool)'/>
	 */
	public CriAtomExPlayer(int maxPath, int maxPathStrings, bool enableAudioSyncedTimer) : this(maxPath, maxPathStrings, enableAudioSyncedTimer, IntPtr.Zero)
	{
	}

	public CriAtomExPlayer(IntPtr existingNativeHandle) : this(0, 0, false, existingNativeHandle)
	{
	}

	public CriAtomExPlayer(int maxPath, int maxPathStrings, bool enableAudioSyncedTimer, IntPtr existingNativeHandle)
	{
		/*  ライブラリの初期化  */
		if (!CriAtomPlugin.IsLibraryInitialized()) {
			throw new Exception("CriAtomPlugin is not initialized.");
		}

		/* ハンドルの作成 */
		Config config;
		config.voiceAllocationMethod = CriAtomEx.VoiceAllocationMethod.Once;
		config.maxPath = maxPath;
		config.maxPathStrings = maxPathStrings;
		config.enableAudioSyncedTimer = enableAudioSyncedTimer;
		/* デフォルト値 */
		config.maxAisacs = 8;
		config.updatesTime = true;

		/* 既存の (外部で作成された) CriAtomExPlayerHn を渡されたか？ */
		hasExistingNativeHandle = (existingNativeHandle != IntPtr.Zero);
		if (hasExistingNativeHandle) {
			this.handle = existingNativeHandle;
		} else {
			/* CriAtomExPlayerHn を新規作成する */
			this.handle = criAtomExPlayer_Create(ref config, IntPtr.Zero, 0);
            this.max_path = config.maxPath;
		}

		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
	}



	/**
	 * <summary>AtomExプレーヤの破棄</summary>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤを破棄します。<br/>
	 * 本関数を実行した時点で、AtomExプレーヤ作成時にDLL内で確保されたリソースが全て解放されます。<br/></para>
	 * <para header='注意'>本関数は完了復帰型の関数です。<br/>
	 * 音声再生中のAtomExプレーヤを破棄しようとした場合、本関数内で再生停止を
	 * 待ってからリソースの解放が行われます。<br/>
	 * （ファイルから再生している場合は、さらに読み込み完了待ちが行われます。）<br/>
	 * そのため、本関数内で処理が長時間（数フレーム）ブロックされる可能性があります。<br/>
	 * AtomExプレーヤの作成／破棄は、シーンの切り替わり等、負荷変動を許容できる
	 * タイミングで行うようお願いいたします。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer'/>
	 */
	public override void Dispose()
	{
		CriDisposableObjectManager.Unregister(this);
		if (this.entryPoolHandle != IntPtr.Zero) {
			this.StopWithoutReleaseTime();
			criAtomUnityEntryPool_Destroy(this.entryPoolHandle);
		}
		this.entryPoolHandle = IntPtr.Zero;
		this._entryPoolCapacity = 0;
		if (hasExistingNativeHandle == false && isAvailable) {
			/* CriAtomExPlayerHn を新規作成した場合 */
			/* ハンドルの削除 */
			criAtomExPlayer_Destroy(this.handle);
		}
		if (_onBeatSyncCallback != null) {
			_onBeatSyncCallback = null;
			CriAtom.OnBeatSyncCallback -= OnBeatSyncCallbackChainInternal;
		}
		this.handle = IntPtr.Zero;
		GC.SuppressFinalize(this);
	}

	/**
	 * <summary>音声データのセット（キュー名指定）</summary>
	 * <param name='acb'>ACBオブジェクト</param>
	 * <param name='name'>キュー名</param>
	 * <remarks>
	 * <para header='説明'>キュー名を、AtomExプレーヤに関連付けます。<br/>
	 * 本関数でキュー名を指定後、 ::CriAtomExPlayer::Start
	 * 関数で再生を開始すると、指定されたキューが再生されます。<br/></para>
	 * <para header='備考'>::CriAtomExPlayer::SetCue 関数でキューをセットした場合、
	 * 以下の関数で設定されたパラメータは無視されます。<br/>
	 *  - ::CriAtomExPlayer::SetFormat
	 *  - ::CriAtomExPlayer::SetNumChannels
	 *  - ::CriAtomExPlayer::SetSamplingRate
	 *  .
	 * （音声フォーマットやチャンネル数、サンプリングレート等の情報は、
	 * ACB ファイルの情報を元に自動的にセットされます。）<br/></para>
	 * </remarks>
	 * <example><code>
	 *      :
	 *  // プレーヤの作成
	 *  CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 *  // ACFファイルの登録
	 *  CriAtomEx.RegisterAcf(null, "sample.acf");
	 *
	 *  // ACBファイルのロード
	 *  CriAtomExAcb acb = CriAtomExAcb.LoadAcbFile(null, "sample.acb", "sample.awb");
	 *
	 *  // 再生するキューの名前を指定
	 *  player.SetCue(acb, "gun_shot");
	 *
	 *  // セットされた音声データを再生
	 *  player.Start();
	 *      :
	 * </code>尚、一旦セットしたデータの情報は、
	 * 他のデータがセットされるまでAtomExプレーヤ内に保持されます。<br/>
	 * そのため、同じデータを何度も再生する場合には、
	 * 再生毎にデータをセットしなおす必要はありません。<br/>
	 * （ ::CriAtomExPlayer::Start 関数を繰り返し実行可能です。）</example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public void SetCue(CriAtomExAcb acb, string name)
	{
		criAtomExPlayer_SetCueName(this.handle,
			(acb != null) ? acb.nativeHandle : IntPtr.Zero, name);
	}

	/**
	 * <summary>音声データのセット（キューID指定）</summary>
	 * <param name='acb'>ACBオブジェクト</param>
	 * <param name='id'>キューID</param>
	 * <remarks>
	 * <para header='説明'>キューIDを、AtomExプレーヤに関連付けます。<br/>
	 * 本関数でキューIDを指定後、 ::CriAtomExPlayer::Start
	 * 関数で再生を開始すると、指定されたキューが再生されます。</para>
	 * <para header='備考'>::CriAtomExPlayer::SetCue 関数でキューをセットした場合、以下の関数で設定された
	 * パラメータは無視されます。<br/>
	 *  - ::CriAtomExPlayer::SetFormat
	 *  - ::CriAtomExPlayer::SetNumChannels
	 *  - ::CriAtomExPlayer::SetSamplingRate
	 *  .
	 * （音声フォーマットやチャンネル数、サンプリングレート等の情報は、
	 * ACB ファイルの情報を元に自動的にセットされます。）<br/></para>
	 * </remarks>
	 * <example><code>
	 *      :
	 *  // プレーヤの作成
	 *  CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 *  // ACFファイルの登録
	 *  CriAtomEx.RegisterAcf(null, "sample.acf");
	 *
	 *  // ACBファイルのロード
	 *  CriAtomExAcb acb = CriAtomExAcb.LoadAcbFile(null, "sample.acb", "sample.awb");
	 *
	 *  // 再生するキューのIDを指定
	 *  player.SetCue(acb, 100);
	 *
	 *  // セットされた音声データを再生
	 *  player.Start();
	 *      :
	 * </code>尚、一旦セットしたデータの情報は、
	 * 他のデータがセットされるまでAtomExプレーヤ内に保持されます。<br/>
	 * そのため、同じデータを何度も再生する場合には、
	 * 再生毎にデータをセットしなおす必要はありません。<br/>
	 * （ ::CriAtomExPlayer::Start 関数を繰り返し実行可能です。）</example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public void SetCue(CriAtomExAcb acb, int id)
	{
		criAtomExPlayer_SetCueId(this.handle,
			(acb != null) ? acb.nativeHandle : IntPtr.Zero, id);
	}

	/**
	 * <summary>音声データのセット（キューインデックス指定）</summary>
	 * <param name='acb'>ACBオブジェクト</param>
	 * <param name='index'>キューインデックス</param>
	 * <remarks>
	 * <para header='説明'>キューインデックスを、AtomExプレーヤに関連付けます。<br/>
	 * 本関数でキューインデックスを指定後、 ::CriAtomExPlayer::Start
	 * 関数で再生を開始すると、指定されたキューが再生されます。</para>
	 * <para header='備考'>::CriAtomExPlayer::SetCueIndex 関数でキューをセットした場合、
	 * 以下の関数で設定されたパラメータは無視されます。<br/>
	 *  - ::CriAtomExPlayer::SetFormat
	 *  - ::CriAtomExPlayer::SetNumChannels
	 *  - ::CriAtomExPlayer::SetSamplingRate
	 *  .
	 * （音声フォーマットやチャンネル数、サンプリングレート等の情報は、
	 * ACB ファイルの情報を元に自動的にセットされます。）<br/>
	 * <br/>
	 * 本関数を使用することで、キュー名やキューIDを指定せずにプレーヤに対して
	 * 音声をセットすることが可能です。<br/>
	 * （キュー名やキューIDがわからない場合でも、
	 * ACBファイル内のコンテンツを一通り再生可能なので、
	 * デバッグ用途に利用可能です。）<br/></para>
	 * </remarks>
	 * <example><code>
	 *      :
	 *  // プレーヤの作成
	 *  CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 *  // ACFファイルの登録
	 *  CriAtomEx.RegisterAcf(null, "sample.acf");
	 *
	 *  // ACBファイルのロード
	 *  CriAtomExAcb acb = CriAtomExAcb.LoadAcbFile(null, "sample.acb", "sample.awb");
	 *
	 *  // 再生するキューのインデックスを指定
	 *  player.SetCueIndex(acb, 300);
	 *
	 *  // セットされた音声データを再生
	 *  player.Start();
	 *      :
	 * </code>尚、一旦セットしたデータの情報は、
	 * 他のデータがセットされるまでAtomExプレーヤ内に保持されます。<br/>
	 * そのため、同じデータを何度も再生する場合には、
	 * 再生毎にデータをセットしなおす必要はありません。<br/>
	 * （ ::CriAtomExPlayer::Start 関数を繰り返し実行可能です。）</example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public void SetCueIndex(CriAtomExAcb acb, int index)
	{
		criAtomExPlayer_SetCueIndex(this.handle,
			(acb != null) ? acb.nativeHandle : IntPtr.Zero, index);
	}

	/**
	 * <summary>音声データのセット（CPKコンテンツIDの指定）</summary>
	 * <param name='binder'>バインダ</param>
	 * <param name='contentId'>コンテンツID</param>
	 * <remarks>
	 * <para header='説明'>コンテンツをAtomExプレーヤに関連付けます。<br/>
	 * CRI File Systemライブラリを使用してCPKファイル内のコンテンツファイルを
	 * ID指定で再生するために使用します。<br/>
	 * 本関数でプレーヤにバインダとコンテンツIDを指定し、
	 * ::CriAtomExPlayer::Start 関数を実行すると、
	 * 指定されたコンテンツファイルがストリーミング再生されます。<br/>
	 * 尚、本関数を実行した時点では、ファイルの読み込みは開始されません。<br/>
	 * ファイルの読み込みが開始されるのは、 ::CriAtomExPlayer::Start 関数実行後です。<br/></para>
	 * <para header='注意'>::CriAtomExPlayer::SetContentId 関数で音声データをセットする場合、
	 * 以下の関数を使用して再生する音声データの情報を別途指定する必要があります。<br/>
	 *  - ::CriAtomExPlayer::SetFormat
	 *  - ::CriAtomExPlayer::SetNumChannels
	 *  - ::CriAtomExPlayer::SetSamplingRate
	 *  .</para>
	 * </remarks>
	 * <example><code>
	 *      :
	 *  // プレーヤの作成
	 *  CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 *  // バインダの作成
	 *  CriFsBinder binder = new CriFsBinder();
	 *
	 *  // CPKファイルのバインドを開始
	 *  CriFsBindRequest bindRequest = CriFsUtility.BindCpk(binder, "sample.cpk");
	 *
	 *  // バインドの完了を待つ
	 *  yield return bindRequest.WaitForDone(this);
	 *
	 *  // 音声ファイルをセット
	 *  // sample.cpk内の1番のコンテンツをセット
	 *  player.SetContentId(binder, 1);
	 *
	 *  // 再生する音声データのフォーマットを指定
	 *  player.SetFormat(CriAtomEx.Format.ADX);
	 *  player.SetNumChannels(2);
	 *  player.SetSamplingRate(44100);
	 *
	 *  // セットされた音声データを再生
	 *  plaeyr.Start();
	 *      :
	 * </code>尚、一旦セットしたファイルの情報は、
	 * 他のデータがセットされるまでAtomExプレーヤ内に保持されます。<br/>
	 * そのため、同じデータを何度も再生する場合には、
	 * 再生毎にデータをセットしなおす必要はありません。<br/>
	 * （ ::CriAtomExPlayer::Start 関数を繰り返し実行可能です。）</example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::SetFormat'/>
	 * <seealso cref='CriAtomExPlayer::SetNumChannels'/>
	 * <seealso cref='CriAtomExPlayer::SetSamplingRate'/>
	 */
	public void SetContentId(CriFsBinder binder, int contentId)
	{
		criAtomExPlayer_SetContentId(this.handle,
			(binder != null) ? binder.nativeHandle : IntPtr.Zero, contentId);
	}

	/**
	 * <summary>音声データのセット（ファイル名の指定）</summary>
	 * <param name='binder'>バインダオブジェクト</param>
	 * <param name='path'>ファイルパス</param>
	 * <remarks>
	 * <para header='説明'>音声ファイルをAtomExプレーヤに関連付けます。<br/>
	 * 本関数でファイルを指定後、 ::CriAtomExPlayer::Start 関数で再生を開始すると、
	 * 指定されたファイルがストリーミング再生されます。<br/>
	 * 尚、本関数を実行した時点では、ファイルの読み込みは開始されません。<br/>
	 * ファイルの読み込みが開始されるのは、 ::CriAtomExPlayer::Start 関数実行後です。<br/></para>
	 * <para header='注意'>本関数を使用する場合、AtomExプレーヤを単体ファイル再生用に作成する必要があります。<br/>
	 * 具体的には、 ::CriAtomExPlayer::CriAtomExPlayer() の代わりに、
	 * ::CriAtomExPlayer::CriAtomExPlayer(int, int) を使用する必要があります。<br/>
	 * <br/>
	 * ::CriAtomExPlayer::SetFile 関数で音声データをセットする場合、
	 * 以下の関数を使用して再生する音声データの情報を別途指定する必要があります。<br/>
	 *  - ::CriAtomExPlayer::SetFormat
	 *  - ::CriAtomExPlayer::SetNumChannels
	 *  - ::CriAtomExPlayer::SetSamplingRate</para>
	 * </remarks>
	 * <example><code>
	 *      :
	 *  // プレーヤの作成
	 *  CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 *  // 音声ファイルをセット
	 *  player.SetFile(null, "sample.hca");
	 *
	 *  // 再生する音声データのフォーマットを指定
	 *  player.SetFormat(CriAtomEx.Format.HCA);
	 *  player.SetNumChannels(2);
	 *  player.SetSamplingRate(48000);
	 *
	 *  // セットされた音声データを再生
	 *  player.Start();
	 *      :
	 * </code>尚、一旦セットしたファイルの情報は、
	 * 他のデータがセットされるまでAtomExプレーヤ内に保持されます。<br/>
	 * そのため、同じデータを何度も再生する場合には、
	 * 再生毎にデータをセットしなおす必要はありません。<br/>
	 * （ ::CriAtomExPlayer::Start 関数を繰り返し実行可能です。）</example>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer(int, int)'/>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::SetFormat'/>
	 * <seealso cref='CriAtomExPlayer::SetNumChannels'/>
	 * <seealso cref='CriAtomExPlayer::SetSamplingRate'/>
	 */
	public void SetFile(CriFsBinder binder, string path)
	{
		criAtomExPlayer_SetFile(this.handle,
			(binder != null) ? binder.nativeHandle : IntPtr.Zero, path);
	}

	/**
	 * <summary>音声データのセット（オンメモリバイト配列の指定）</summary>
	 * <param name='buffer'>バイト配列</param>
	 * <param name='size'>バッファサイズ</param>
	 * <remarks>
	 * <para header='説明'>メモリ上に配置された音声データをAtomExプレーヤに関連付けます。<br/>
	 * 本関数でメモリアドレスとサイズを指定後、 ::CriAtomExPlayer::Start 関数で再生を開始すると、
	 * 指定されたデータが再生されます。<br/></para>
	 * <para header='注意'>本関数を使用する場合、AtomExプレーヤを単体ファイル再生用に作成する必要があります。<br/>
	 * 具体的には、 ::CriAtomExPlayer::CriAtomExPlayer() の代わりに、
	 * ::CriAtomExPlayer::CriAtomExPlayer(int, int) を使用する必要があります。<br/>
	 * <br/>
	 * ::CriAtomExPlayer::SetData 関数で音声データをセットする場合、
	 * 以下の関数を使用して再生する音声データの情報を別途指定する必要があります。<br/>
	 *  - ::CriAtomExPlayer::SetFormat
	 *  - ::CriAtomExPlayer::SetNumChannels
	 *  - ::CriAtomExPlayer::SetSamplingRate</para>
	 * <para header='注意'>SetDataに渡すバッファアドレスは、ガベージコレクターに移動されないようにアプリケーション
	 * 側で事前に固定したものを渡してください。<br/></para>
	 * </remarks>
	 * <example><code>
	 *      :
	 *  // プレーヤの作成
	 *  CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 *  // 音声ファイルをセット
	 *  player.SetData(null, buffer, size);
	 *
	 *  // 再生する音声データのフォーマットを指定
	 *  player.SetFormat(CriAtomEx.Format.HCA);
	 *  player.SetNumChannels(2);
	 *  player.SetSamplingRate(48000);
	 *
	 *  // セットされた音声データを再生
	 *  player.Start();
	 *      :
	 * </code>尚、一旦セットしたファイルの情報は、
	 * 他のデータがセットされるまでAtomExプレーヤ内に保持されます。<br/>
	 * そのため、同じデータを何度も再生する場合には、
	 * 再生毎にデータをセットしなおす必要はありません。<br/>
	 * （ ::CriAtomExPlayer::Start 関数を繰り返し実行可能です。）</example>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer(int, int)'/>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::SetFormat'/>
	 * <seealso cref='CriAtomExPlayer::SetNumChannels'/>
	 * <seealso cref='CriAtomExPlayer::SetSamplingRate'/>
	 */
	public void SetData(byte[] buffer, int size)
	{
		criAtomExPlayer_SetData(this.handle,
			buffer, size);
	}

	/**
	 * <summary>音声データのセット（オンメモリバッファアドレスの指定）</summary>
	 * <param name='buffer'>バッファアドレス</param>
	 * <param name='size'>バッファサイズ</param>
	 * <remarks>
	 * <para header='説明'>詳細は ::CriAtomExPlayer::SetData(byte[], int) を参照してください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::SetData(byte[], int)'/>
	 */
	public void SetData(IntPtr buffer, int size) {
		criAtomExPlayer_SetData(this.handle,
			buffer, size);
	}

	/**
	 * <summary>フォーマットの指定</summary>
	 * <param name='format'>フォーマット</param>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤで再生する音声のフォーマットを指定します。<br/>
	 * ::CriAtomExPlayer::Start 関数で音声を再生した際、AtomExプレーヤは本関数で
	 * 指定されたフォーマットのデータを再生可能なボイスを、ボイスプールから取得します。<br/>
	 * 関数実行前のデフォルト設定値はADXフォーマットです。<br/></para>
	 * <para header='備考'>本関数は、ACBファイルを使用せずに音声を再生する場合にのみセットする必要があります。<br/>
	 * キューを再生する場合、フォーマットはキューシートから自動で取得されるため、
	 * 別途本関数を実行する必要はありません。<br/></para>
	 * </remarks>
	 */
	public void SetFormat(CriAtomEx.Format format)
	{
		criAtomExPlayer_SetFormat(this.handle, format);
	}

	/**
	 * <summary>チャンネル数の指定</summary>
	 * <param name='numChannels'>チャンネル数</param>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤで再生する音声のチャンネル数を指定します。<br/>
	 * ::CriAtomExPlayer::Start 関数で音声を再生した際、AtomExプレーヤは本関数で
	 * 指定されたチャンネル数のデータを再生可能なボイスを、ボイスプールから取得します。<br/>
	 * 関数実行前のデフォルト設定値は2チャンネルです。<br/></para>
	 * <para header='備考'>本関数は、ACBファイルを使用せずに音声を再生する場合にのみセットする必要があります。<br/>
	 * キューを再生する場合、フォーマットはキューシートから自動で取得されるため、
	 * 別途本関数を実行する必要はありません。<br/></para>
	 * </remarks>
	 */
	public void SetNumChannels(int numChannels)
	{
		criAtomExPlayer_SetNumChannels(this.handle, numChannels);
	}

	/**
	 * <summary>サンプリングレートの指定</summary>
	 * <param name='samplingRate'>サンプリングレート</param>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤで再生する音声のサンプリングレートを指定します。<br/>
	 * ::CriAtomExPlayer::Start 関数で音声を再生した際、AtomExプレーヤは本関数で
	 * 指定されたサンプリングレートのデータを再生可能なボイスを、ボイスプールから取得します。<br/>
	 * 関数実行前のデフォルト設定値は32000Hzです。<br/></para>
	 * <para header='備考'>本関数は、ACBファイルを使用せずに音声を再生する場合にのみセットする必要があります。<br/>
	 * キューを再生する場合、フォーマットはキューシートから自動で取得されるため、
	 * 別途本関数を実行する必要はありません。<br/></para>
	 * </remarks>
	 */
	public void SetSamplingRate(int samplingRate)
	{
		criAtomExPlayer_SetSamplingRate(this.handle, samplingRate);
	}

	/**
	 * <summary>連結再生用エントリプールの作成</summary>
	 * <param name='capacity'>入力可能なデータ個数</param>
	 * <param name='stopOnEmpty'>エントリプールが空の場合に停止するか</param>
	 * <remarks>
	 * <para header='説明'>::CriAtomExPlayer::EntryData 等を利用した連結再生を行うためのエントリプールを作成します。<br/></para>
	 * <para header='注意'>本関数を呼び出すと、プレーヤは連結再生用の再生モードになります。<br/>
	 * stopOnEmpty フラグが false の場合、 ::CriAtomExPlayer::SetData や ::CriAtomExPlayer::EntryData
	 * などで供給したデータが終端まで達した場合も、再生中状態のまま次のデータ入力を待つようになります。<br/>
	 * true の場合、供給したデータが枯渇すると再生を停止しますので、余裕をもってデータ入力を
	 * 行うようにしてください。</para>
	 * </remarks>
	 *
	 */
	public void PrepareEntryPool(int capacity, bool stopOnEmpty)
	{
		if (this.entryPoolHandle != IntPtr.Zero) {
			criAtomUnityEntryPool_Destroy(this.entryPoolHandle);
			this._entryPoolCapacity = 0;
			this.entryPoolHandle = IntPtr.Zero;
		}

		if (capacity <= 0)
			return;

		this.entryPoolHandle = criAtomUnityEntryPool_Create(this.handle, capacity, this.max_path, stopOnEmpty);
		if (this.entryPoolHandle != IntPtr.Zero) {
			this._entryPoolCapacity = capacity;
		}
	}

	/**
	 * <summary>連結再生用データのエントリ数</summary>
	 * <returns>エントリ数</returns>
	 * <remarks>
	 * <para header='説明'>連結再生用に入力されているエントリの数を取得します。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::PrepareEntryPool'/>
	 * <seealso cref='CriAtomExPlayer::EntryData'/>
	 */
	public int GetNumEntries()
	{
		if (this.entryPoolHandle == IntPtr.Zero) {
			return 0;
		}
		return criAtomUnityEntryPool_GetNumEntries(this.entryPoolHandle);
	}

	/**
	 * <summary>入力可能な連結再生用データの数</summary>
	 */
	public int entryPoolCapacity { get { return _entryPoolCapacity; } }


	/**
	 * <summary>連結再生用データの入力（ファイル名の指定）</summary>
	 * <param name='binder'>バインダオブジェクト</param>
	 * <param name='path'>ファイルパス</param>
	 * <param name='repeat'>次のデータが入力されていない場合に繰り返し再生するか</param>
	 * <returns>データ入力に成功したか</returns>
	 * <remarks>
	 * <para header='説明'>連結再生用に音声ファイルを入力します。<br/>
	 * 連結再生を行う場合には、先頭データを ::CriAtomExPlayer::SetData 関数等で
	 * 設定して再生開始後、本関数により追加の再生用データを入力してください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::PrepareEntryPool'/>
	 * <seealso cref='CriAtomExPlayer::EntryContentId'/>
	 * <seealso cref='CriAtomExPlayer::EntryData'/>
	 */
	public bool EntryFile(CriFsBinder binder, string path, bool repeat)
	{
		if (this.entryPoolHandle == IntPtr.Zero) {
			return false;
		}
		return criAtomUnityEntryPool_EntryFile(this.entryPoolHandle,
								(binder != null) ? binder.nativeHandle : IntPtr.Zero,
								path,
								repeat,
								this.max_path);
	}

	/**
	 * <summary>連結再生用データの入力（CPKコンテンツIDの指定）</summary>
	 * <param name='binder'>バインダオブジェクト</param>
	 * <param name='contentId'>コンテンツID</param>
	 * <param name='repeat'>次のデータが入力されていない場合に繰り返し再生するか</param>
	 * <returns>データ入力に成功したか</returns>
	 * <remarks>
	 * <para header='説明'>連結再生用にコンテンツを入力します。<br/>
	 * CRI File Systemライブラリを使用してCPKファイル内のコンテンツファイルを
	 * ID指定で再生するために使用します。<br/>
	 * 連結再生を行う場合には、先頭データを ::CriAtomExPlayer::SetData 関数等で
	 * 設定して再生開始後、本関数により追加の再生用データを入力してください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::PrepareEntryPool'/>
	 * <seealso cref='CriAtomExPlayer::EntryFile'/>
	 * <seealso cref='CriAtomExPlayer::EntryData'/>
	 */
	public bool EntryContentId(CriFsBinder binder, int contentId, bool repeat)
	{
		if (this.entryPoolHandle == IntPtr.Zero) {
			return false;
		}
		return criAtomUnityEntryPool_EntryContentId(this.entryPoolHandle,
								(binder != null) ? binder.nativeHandle : IntPtr.Zero,
								contentId,
								repeat);
	}

	/**
	 * <summary>連結再生用データの入力（オンメモリバイト配列の指定）</summary>
	 * <param name='buffer'>オンメモリバイト配列</param>
	 * <param name='size'>バッファサイズ</param>
	 * <param name='repeat'>次のデータが入力されていない場合に繰り返し再生するか</param>
	 * <returns>データ入力に成功したか</returns>
	 * <remarks>
	 * <para header='説明'>連結再生用データを入力します。<br/>
	 * 連結再生を行う場合には、先頭データを ::CriAtomExPlayer::SetData 関数等で
	 * 設定して再生開始後、本関数によりデータを入力してください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::PrepareEntryPool'/>
	 * <seealso cref='CriAtomExPlayer::EntryFile'/>
	 * <seealso cref='CriAtomExPlayer::EntryContentId'/>
	 */
	public bool EntryData(byte[] buffer, int size, bool repeat)
	{
		if (this.entryPoolHandle == IntPtr.Zero) {
			return false;
		}
		return criAtomUnityEntryPool_EntryData(this.entryPoolHandle, buffer, size, repeat);
	}

	/**
	 * <summary>連結再生用データの入力（オンメモリバッファアドレスの指定）</summary>
	 * <param name='buffer'>バッファアドレス</param>
	 * <param name='size'>バッファサイズ</param>
	 * <param name='repeat'>次のデータが入力されていない場合に繰り返し再生するか</param>
	 * <returns>データ入力に成功したか</returns>
	 * <remarks>
	 * <para header='説明'>連結再生用データを入力します。<br/>
	 * 連結再生を行う場合には、先頭データを ::CriAtomExPlayer::SetData 関数等で
	 * 設定して再生開始後、本関数によりデータを入力してください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::PrepareEntryPool'/>
	 */
	public bool EntryData(IntPtr buffer, int size, bool repeat)
	{
		if (this.entryPoolHandle == IntPtr.Zero) {
			return false;
		}
		return criAtomUnityEntryPool_EntryData(this.entryPoolHandle, buffer, size, repeat);
	}

	/**
	 * <summary>連結再生用データの入力（キュー名の指定）</summary>
	 * <param name='acb'>ACBハンドル</param>
	 * <param name='name'>キュー名</param>
	 * <param name='repeat'>次のデータが入力されていない場合に繰り返し再生するか</param>
	 * <returns>データ入力に成功したか</returns>
	 * <remarks>
	 * <para header='説明'>連結再生用データを入力します。<br/>
	 * 連結再生を行う場合には、先頭データを ::CriAtomExPlayer::SetData 関数等で
	 * 設定して再生開始後、本関数によりデータを入力してください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::PrepareEntryPool'/>
	 */
	public bool EntryCue(CriAtomExAcb acb, string name, bool repeat)
	{
		if (this.entryPoolHandle == IntPtr.Zero) {
			return false;
		}
		return criAtomUnityEntryPool_EntryCue(this.entryPoolHandle,
			(acb != null) ? acb.nativeHandle : IntPtr.Zero, name, repeat);
	}

	/**
	 * <summary>再生の開始</summary>
	 * <returns>CriAtomExPlaybackオブジェクト</returns>
	 * <remarks>
	 * <para header='説明'>音声データの再生処理を開始します。<br/>
	 * 本関数を実行する前に、事前に ::CriAtomExPlayer::SetCue 関数等を使用し、
	 * 再生する音声データをAtomExプレーヤにセットしておく必要があります。<br/>
	 * 例えば、キューを再生する場合には、以下のように事前に
	 * ::CriAtomExPlayer::SetCue 関数を使って音声データをセットした後、本関数を実行する
	 * 必要があります。<br/><code>
	 *      :
	 *  // ACFファイルの登録
	 *  CriAtomEx.RegisterAcf(null, "sample.acf");
	 *
	 *  // ACBファイルのロード
	 *  CriAtomExAcb acb = CriAtomExAcb.LoadAcbFile(null, "sample.acb", "sample.awb");
	 *
	 *  // プレーヤの作成
	 *  CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 *  // 再生するキューの名前を指定
	 *  player.SetCue(acb, "gun_shot");
	 *
	 *  // セットされた音声データを再生
	 *  player.Start();
	 *      :
	 * </code>
	 * 本関数実行後、再生の進み具合（発音が開始されたか、再生が完了したか等）
	 * がどうなっているかは、ステータスを取得することで確認が可能です。<br/>
	 * ステータスの取得には、 ::CriAtomExPlayer::GetStatus 関数を使用します。<br/>
	 * ::CriAtomExPlayer::GetStatus 関数は以下の5通りのステータスを返します。<br/> -# Stop
	 *  -# Prep
	 *  -# Playing
	 *  -# PlayEnd
	 *  -# Error
	 *  .
	 * AtomExプレーヤを作成した時点では、AtomExプレーヤのステータスは停止状態（ Stop ）です。<br/>
	 * 再生する音声データをセット後、本関数を実行することで、
	 * AtomExプレーヤのステータスが準備状態（ Prep ）に変更されます。<br/>
	 * （Prep は、データ供給やデコードの開始を待っている状態です。）<br/>
	 * 再生の開始に充分なデータが供給された時点で、AtomExプレーヤはステータスを
	 * 再生状態（ Playing ）に変更し、音声の出力を開始します。<br/>
	 * セットされたデータを全て再生し終えると、AtomExプレーヤはステータスを再生終了状態
	 * （ PlayEnd ）に変更します。<br/>
	 * 尚、再生中にエラーが発生した場合には、AtomExプレーヤはステータスをエラー状態
	 * （ Error ）に変更します。<br/>
	 * <br/>
	 * AtomExプレーヤのステータスをチェックし、ステータスに応じて処理を切り替えることで、
	 * 音声の再生状態に連動したプログラムを作成することが可能です。<br/>
	 * 例えば、音声の再生完了を待って処理を進めたい場合には、以下のようなコードになります。<code>
	 *      :
	 *  // プレーヤの作成
	 *  CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 *  // 再生するキューの名前を指定
	 *  player.SetCue(acb, "gun_shot");
	 *
	 *  // セットされた音声データを再生
	 *  player.Start();
	 *
	 *  // 再生完了待ち
	 *  while (player.GetStatus() != CriAtomExPlayer.Status.PlayEnd) {
	 *      yield return null;
	 *  }
	 *      :
	 * </code>
	 * </para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::SetCue'/>
	 * <seealso cref='CriAtomExPlayer::GetStatus'/>
	 */
	public CriAtomExPlayback Start()
	{
		return new CriAtomExPlayback(criAtomExPlayer_Start(this.handle));
	}

	/**
	 * <summary>再生の準備</summary>
	 * <returns>CriAtomExPlaybackオブジェクト</returns>
	 * <remarks>
	 * <para header='説明'>音声データの再生を準備します。<br/>
	 * 本関数を実行する前に、事前に ::CriAtomExPlayer::SetData 関数等を使用し、
	 * 再生すべき音声データをAtomExプレーヤにセットしておく必要があります。<br/>
	 * <br/>
	 * 本関数を実行すると、ポーズをかけた状態で音声の再生を開始します。<br/>
	 * 関数実行のタイミングで音声再生に必要なリソースを確保し、
	 * バッファリング（ストリーム再生を行うファイルの読み込み）を開始しますが、
	 * バッファリング完了後も発音は行われません。<br/>
	 * （発音可能な状態になっても、ポーズ状態で待機します。）<br/>
	 * <br/>
	 * 1音だけを再生するケースでは、本関数は以下のコードと同じ動作をします。<br/><code>
	 *      ：
	 *  // プレーヤをポーズ状態に設定
	 *  player.Pause();
	 *
	 *  // 音声の再生を開始
	 *  CriAtomExPlayback playback = player.Start();
	 *      ：
	 * </code>
	 * <br/>
	 * 本関数で再生準備を行った音声を発音するには、
	 * 本関数が返すCriAtomExPlaybackオブジェクトに対し、
	 * ::CriAtomExPlayback::Resume を実行する必要があります。<br/>
	 * </para>
	 * <para header='備考'>ストリーミング再生時には、 ::CriAtomExPlayer::Start 関数で再生を開始しても、
	 * 実際に音声の再生が開始されるまでにはタイムラグがあります。<br/>
	 * （音声データのバッファリングに時間がかかるため。）<br/>
	 * <br/>
	 * 以下の操作を行うことで、ストリーム再生の音声についても、発音のタイミングを
	 * 制御することが可能になります。
	 *  -# ::CriAtomExPlayer::Prepare 関数で準備を開始する。
	 *  -# 手順1.で取得したCriAtomExPlaybackオブジェクトのステータスを ::CriAtomExPlayback::GetStatus 関数で確認。
	 *  -# ステータスが Playing になった時点で ::CriAtomExPlayback::Resume 関数でポーズを解除。
	 *  -# ポーズ解除後、次にサーバ処理が動作するタイミングで発音が開始される。
	 *  .
	 * 具体的なコードは、以下のとおりです。<br/><code>
	 *      :
	 *  // プレーヤの作成
	 *  CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 *  // 再生するキューの名前を指定
	 *  player.SetCue(acb, "gun_shot");
	 *
	 *  // セットされた音声データの再生準備を開始
	 *  CriAtomExPlayback playback = player.Prepare();
	 *
	 *  // 再生準備完了待ち
	 *  while (playback.GetStatus() != CriAtomExPlayback.Status.Playing) {
	 *      yield return null;
	 *  }
	 *
	 *  // ポーズを解除
	 *  playback.Resume(CriAtomEx.ResumeMode.PreparedPlayback);
	 *      :
	 * </code>
	 * </para>
	 * <para header='注意'>ポーズ解除時に PausedPlayback を指定した場合、
	 * 本関数による再生準備のためのポーズと、 ::CriAtomExPlayer::Pause
	 * 関数による一時停止処理の両方が解除されます。<br/>
	 * ::CriAtomExPlayer::Pause 関数でポーズした音声を停止したまま
	 * 本関数で再生準備を行った音声を再生したい場合、ポーズの解除時に
	 * PreparedPlayback を指定してください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayback::GetStatus'/>
	 * <seealso cref='CriAtomExPlayback::Resume'/>
	 */
	public CriAtomExPlayback Prepare()
	{
		return new CriAtomExPlayback(criAtomExPlayer_Prepare(this.handle));
	}

	/**
	 * <summary>再生の停止</summary>
	 * <param name='ignoresReleaseTime'>リリース時間を無視するかどうか
	 * （false = リリース処理を行う、ture = リリース時間を無視して即座に停止する）</param>
	 * <remarks>
	 * <para header='説明'>再生の停止要求を発行します。<br/>
	 * 音声再生中のAtomExプレーヤに対して本関数を実行すると、
	 * AtomExプレーヤは再生を停止（ファイルの読み込みや、発音を停止）し、
	 * ステータスを停止状態（ Stop ）に遷移します。<br/>
	 * <br/>
	 * 引数をtrueに設定した場合、
	 * 再生中の音声にエンベロープのリリースタイムが設定されていたとしても、
	 * リリース時間を無視して音声を即座に停止します。<br/></para>
	 * <para header='備考'>既に停止しているAtomExプレーヤ（ステータスが PlayEnd や Error のAtomExプレーヤ）
	 * に対して本関数を実行すると、AtomExプレーヤのステータスを Stop に変更します。</para>
	 * <para header='注意'>音声再生中のAtomExプレーヤに対して本関数を実行した場合、
	 * ステータスが即座に Stop になるとは限りません。<br/>
	 * （停止状態になるまでに、時間がかかる場合があります。）<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::GetStatus'/>
	 */
	public void Stop(bool ignoresReleaseTime)
	{
		if (!this.isAvailable) {
			return;
		}

		if (ignoresReleaseTime == false) {
			criAtomExPlayer_Stop(this.handle);
		} else {
			criAtomExPlayer_StopWithoutReleaseTime(this.handle);
		}
		if (this.entryPoolHandle != IntPtr.Zero) {
			criAtomUnityEntryPool_Clear(this.entryPoolHandle);
		}
	}

	/**
	 * <summary>ポーズ</summary>
	 * <remarks>
	 * <para header='説明'>再生を一時停止します。<br/></para>
	 * <para header='備考'>デフォルト状態（プレーヤ作成直後の状態）では、ポーズは解除されています。<br/></para>
	 * <para header='注意'>本関数を実行すると、プレーヤで再生している"全ての"音声に対してポーズ処理が行われます。<br/>
	 * 再生中の個々の音声に対し、個別にポーズ処理を行う場合には、
	 * ::CriAtomExPlayback::Pause 関数をご利用ください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Resume'/>
	 * <seealso cref='CriAtomExPlayer::IsPaused'/>
	 * <seealso cref='CriAtomExPlayback::Pause'/>
	 */
	public void Pause()
	{
		criAtomExPlayer_Pause(this.handle, true);
	}

	/**
	 * <summary>ポーズ解除</summary>
	 * <param name='mode'>ポーズ解除対象</param>
	 * <remarks>
	 * <para header='説明'>一時停止状態の解除を行います。<br/>
	 * <br/>
	 * 引数（mode）に PausedPlayback を指定して本関数を実行すると、
	 * ユーザが ::CriAtomExPlayer::Pause 関数（または ::CriAtomExPlayback::Pause
	 * 関数）で一時停止状態になった音声の再生が再開されます。<br/>
	 * 引数（mode）に PreparedPlayback を指定して本関数を実行すると、
	 * ユーザが ::CriAtomExPlayer::Prepare 関数で再生準備を指示した音声の再生が開始されます。<br/></para>
	 * <para header='備考'>::CriAtomExPlayer::Pause 関数でポーズ状態のプレーヤに対して ::CriAtomExPlayer::Prepare
	 * 関数で再生準備を行った場合、その音声は PausedPlayback 指定のポーズ解除処理と、
	 * PreparedPlayback 指定のポーズ解除処理の両方が行われるまで、再生が開始されません。<br/>
	 * <br/>
	 * ::CriAtomExPlayer::Pause 関数か ::CriAtomExPlayer::Prepare 関数かに関係なく、
	 * 常に再生を開始したい場合には、引数（mode）に AllPlayback を指定して本関数を実行してください。<br/></para>
	 * <para header='注意'>本関数を実行すると、プレーヤで再生している"全ての"音声に対してポーズ解除
	 * の処理が行われます。<br/>
	 * 再生中の個々の音声に対し、個別にポーズ解除の処理を行う場合には、
	 * ::CriAtomExPlayback::Resume 関数をご利用ください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Pause'/>
	 * <seealso cref='CriAtomExPlayback::Resume'/>
	 */
	public void Resume(CriAtomEx.ResumeMode mode)
	{
		criAtomExPlayer_Resume(this.handle, mode);
	}

	/**
	 * <summary>ポーズ状態の取得</summary>
	 * <returns>ポーズ中かどうか（false = ポーズされていない、true = ポーズ中）</returns>
	 * <remarks>
	 * <para header='説明'>プレーヤがポーズ中かどうかを返します。<br/></para>
	 * <para header='注意'>本関数が ture を返すのは、「全ての音声がポーズ中の場合」のみです。<br/>
	 * ::CriAtomExPlayer::Pause 関数実行後、再生ID指定で個々の音声のポーズを解除
	 * （ ::CriAtomExPlayback::Pause 関数を実行）した場合、本関数は false を
	 * 返します。<br/>
	 * <br/>
	 * 本関数は ::CriAtomExPlayer::Pause 関数でポーズされた音声と、
	 * ::CriAtomExPlayer::Prepare 関数でポーズされた音声とを区別しません。<br/>
	 * （ポーズ方法に関係なく、全ての音声がポーズされているかどうかのみを判定します。）<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Pause'/>
	 * <seealso cref='CriAtomExPlayback::Pause'/>
	 */
	public bool IsPaused()
	{
		return criAtomExPlayer_IsPaused(this.handle);
	}

	/**
	 * <summary>ボリュームの設定</summary>
	 * <param name='volume'>ボリューム値</param>
	 * <remarks>
	 * <para header='説明'>出力音声のボリュームを指定します。<br/>
	 * 本関数でボリュームを設定後、 ::CriAtomExPlayer::Start 関数で再生を開始すると、
	 * 設定されたボリュームで音声が再生されます。<br/>
	 * またボリューム設定後に ::CriAtomExPlayer::Update 関数や ::CriAtomExPlayer::UpdateAll
	 * 関数を呼び出すことで、すでに再生中の音声のボリュームを更新することも可能です。<br/>
	 * <br/>
	 * ボリューム値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br/>
	 * 例えば、1.0fを指定した場合、原音はそのままのボリュームで出力されます。<br/>
	 * 0.5fを指定した場合、原音波形の振幅を半分にしたデータと同じ音量（-6dB）で
	 * 音声が出力されます。<br/>
	 * 0.0fを指定した場合、音声はミュートされます（無音になります）。<br/>
	 * ボリュームのデフォルト値は1.0fです。<br/></para>
	 * <para header='備考'>ボリューム値には0.0f以上の値が設定可能です。<br/>
	 * 1.0fを超える値をセットした場合、<b>プラットフォームによっては</b>、
	 * 波形データを元素材よりも大きな音量で再生可能です。<br/>
	 * ボリューム値に0.0f未満の値を指定した場合、値は0.0fにクリップされます。<br/>
	 * （ボリューム値に負の値を設定した場合でも、
	 * 波形データの位相が反転されることはありません。）<br/>
	 * <br/>
	 * キュー再生時、データ側にボリュームが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>乗算</b>した値が適用されます。<br/>
	 * 例えば、データ側のボリュームが0.8f、AtomExプレーヤのボリュームが0.5fの場合、
	 * 実際に適用されるボリュームは0.4fになります。<br/>
	 * <br/>
	 * デシベルで設定したい場合、以下の計算式で変換してから設定してください。<br/><code>
	 * volume = Math.Pow(10.0f, db_vol / 20.0f);
	 * </code>
	 * ※db_volがデシベル値、volumeがボリューム値です。
	 * </para>
	 * <para header='注意'>1.0fを超えるボリュームを指定する場合、以下の点に注意する必要があります。<br/>
	 *  - プラットフォームごとに挙動が異なる可能性がある。
	 *  - 音割れが発生する可能性がある。
	 *  .
	 * <br/>
	 * 本関数に1.0fを超えるボリューム値を設定した場合でも、
	 * 音声が元の波形データよりも大きな音量で再生されるかどうかは、
	 * プラットフォームや音声圧縮コーデックの種別によって異なります。<br/>
	 * そのため、マルチプラットフォームタイトルでボリュームを調整する場合には、
	 * 1.0fを超えるボリューム値を使用しないことをおすすめします。<br/>
	 * （1.0fを超えるボリューム値を指定した場合、同じ波形データを再生した場合でも、
	 * 機種ごとに異なる音量で出力される可能性があります。）<br/>
	 * <br/>
	 * また、音量を上げることが可能な機種であっても、
	 * ハードウェアで出力可能な音量には上限があるため、
	 * 音割れによるノイズが発生する可能性があります。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // ボリュームの設定
	 * player.SetVolume(0.5f);
	 *
	 * // 再生の開始
	 * // 備考）ボリュームはプレーヤに設定された値（＝0.5f）で再生される。
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // ボリュームの変更
	 * // 注意）この時点では再生中の音声のボリュームは変更されない。
	 * player.SetVolume(0.3f);
	 *
	 * // プレーヤに設定されたボリュームを再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 */
	public void SetVolume(float volume)
	{
		criAtomExPlayer_SetVolume(this.handle, volume);
	}

	/**
	 * <summary>ピッチの設定</summary>
	 * <param name='pitch'>ピッチ（セント単位）</param>
	 * <remarks>
	 * <para header='説明'>出力音声のピッチを指定します。<br/>
	 * 本関数でピッチを設定後、 ::CriAtomExPlayer::Start 関数で再生開始すると、
	 * 設定されたピッチで音声が再生されます。<br/>
	 * またピッチ後に ::CriAtomExPlayer::Update 関数や ::CriAtomExPlayer::UpdateAll
	 * 関数を呼び出すことにより、すでに再生された音声のピッチを更新することが可能です。<br/>
	 * <br/>
	 * ピッチはセント単位で指定します。<br/>
	 * 1セントは1オクターブの1/1200です。半音は100セントです。<br/>
	 * 例えば、100.0fを指定した場合、ピッチが半音上がります。-100.0fを指定した場合、
	 * ピッチが半音下がります。<br/>
	 * ピッチのデフォルト値は0.0fです。<br/></para>
	 * <para header='備考'>キュー再生時、データ側にピッチが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>加算</b>した値が適用されます。<br/>
	 * 例えば、データ側のピッチが-100.0f、AtomExプレーヤのピッチが200.0fの場合、
	 * 実際に適用されるピッチは100.0fになります。
	 * <br/>
	 * サンプリングレートの周波数比率で設定したい場合、以下の計算式で変換してから設定してください。<br/><code>
	 * pitch = 1200.0 * Math.Log(freq_ratio, 2.0);
	 * </code>
	 * ※freq_ratioが周波数比率、pitchがピッチの値です。
	 * </para>
	 * <para header='注意'>HCA-MX用にエンコードされた音声データは、ピッチの変更ができません。<br/>
	 * （本関数を実行しても、ピッチは変わりません。）<br/>
	 * ピッチを変更したい音声については、ADXやHCA等、他のコーデックでエンコードを行ってください。<br/>
	 * <br/>
	 * 設定可能な最大ピッチは、音声データのサンプリングレートとボイスプールの最大サンプリングレートに依存します。<br/>
	 * 例えば、音声データのサンプリングレートが24kHzで、ボイスプールの最大サンプリングレートが48kHzの場合、
	 * 設定可能な最大ピッチは1200(周波数比率2倍)になります。<br/>
	 * <br/>
	 * 再生サンプリングレートの上下によりピッチを実装しているため、
	 * ピッチを変更すると音程と一緒に再生速度も変化します。</para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // ピッチの設定
	 * player.SetPitch(100.0f);
	 *
	 * // 再生の開始
	 * // 備考）ピッチはプレーヤに設定された値（＝100セント）で再生される。
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // ピッチの変更
	 * // 注意）この時点では再生中の音声のピッチは変更されない。
	 * player.SetPitch(-200.0f);
	 *
	 * // プレーヤに設定されたピッチを再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 */
	public void SetPitch(float pitch)
	{
		criAtomExPlayer_SetPitch(this.handle, pitch);
	}

	/**
	 * <summary>シーケンス再生レシオの設定</summary>
	 * <param name='ratio'>シーケンス再生レシオ</param>
	 * <remarks>
	 * <para header='説明'>プレーヤで再生するシーケンスの再生レシオを設定します。<br/>
	 * 再生レシオの設定範囲は 0.0f ～ 2.0f です。<br/>
	 * 範囲外の値を設定した場合は、下限値もしくは上限値が設定されます。<br/>
	 * 本関数で再生レシオを指定後、 ::CriAtomExPlayer::Start
	 * 関数で再生を開始すると、指定された再生レシオで再生できます。
	 * 再生中にレシオを変更したい場合は、 ::CriAtomExPlayer::Update 関数や
	 * ::CriAtomExPlayer::UpdateAll 関数を呼び出してください。</para>
	 * <para header='注意'>本関数による設定値は、シーケンスタイプのキューを再生する場合にのみ適用されます。<br/>
	 * シーケンスにて発音する波形データの再生レシオには利用できません。<br/>
	 * 波形の再生レシオを変更したい場合は、タイムストレッチ機能をご利用ください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomPlayer::Update'/>
	 * <seealso cref='CriAtomPlayer::UpdateAll'/>
	 */
	public void SetPlaybackRatio(float ratio)
	{
		criAtomExPlayer_SetPlaybackRatio(this.handle, ratio);
	}

	/**
	 * <summary>パンニング3D角度の設定</summary>
	 * <param name='angle'>パンニング3D角度（-180.0f～180.0f：度単位）</param>
	 * <remarks>
	 * <para header='説明'>パンニング3D角度を指定します。<br/>
	 * 本関数でパンニング3D角度を設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたパンニング3D角度で再生されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声のパンニング3D角度を更新することができます。<br/>
	 * <br/>
	 * 角度は度単位で指定します。<br/>
	 * 前方を0度とし、右方向（時計回り）に180.0f、左方向（反時計回り）に-180.0fまで設定できます。<br/>
	 * 例えば、45.0fを指定した場合、右前方45度に定位します。-45.0fを指定した場合、左前方45度に定位します。<br/></para>
	 * <para header='備考'>キュー再生時、データ側にパンニング3D角度が設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>加算</b>した値が適用されます。<br/>
	 * 例えば、データ側のパンニング3D角度が15.0f、AtomExプレーヤのパンニング3D角度が30.0fの場合、
	 * 実際に適用されるパンニング3D角度は45.0fになります。
	 * <br/>
	 * 実際に適用されるパンニング3D角度が180.0fを超える値になった場合、値を-360.0fして範囲内に納めます。<br/>
	 * 同様に、実際に適用されるボリューム値が-180.0f未満の値になった場合は、値を+360.0fして範囲内に納めます。<br/>
	 * （+360.0f, -360.0fしても定位は変わらないため、実質的には-180.0f～180.0fの範囲を超えて設定可能です。）</para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // パンニング3D角度の設定
	 * player.SetPan3dAngle(45.0f);
	 *
	 * // 再生の開始
	 * // 備考）パンニング3D角度はプレーヤに設定された値（＝45.0f）で再生される。
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // パンニング3D角度の変更
	 * // 注意）この時点では再生中の音声のパンニング3D角度は変更されない。
	 * player.SetPan3dAngle(-45.0f);
	 *
	 * // プレーヤに設定されたパンニング3D角度を再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 */
	public void SetPan3dAngle(float angle)
	{
		criAtomExPlayer_SetPan3dAngle(this.handle, angle);
	}

	/**
	 * <summary>パンニング3D距離の設定</summary>
	 * <param name='distance'>パンニング3D距離（-1.0f～1.0f）</param>
	 * <remarks>
	 * <para header='説明'>パンニング3Dでインテリアパンニングを行う際の距離を指定します。<br/>
	 * 本関数でパンニング3D距離を設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたパンニング3D距離で再生されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll
	 * 関数を呼び出すことにより、すでに再生された音声のパンニング3D距離を更新することができます。<br/>
	 * <br/>
	 * 距離は、リスナー位置を0.0f、スピーカーの配置されている円周上を1.0fとして、-1.0f～1.0fの範囲で指定します。<br/>
	 * 負値を指定すると、パンニング3D角度が180度反転し、逆方向に定位します。</para>
	 * <para header='備考'>キュー再生時、データ側にパンニング3D距離が設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>乗算</b>した値が適用されます。<br/>
	 * 例えば、データ側のパンニング3D距離が0.8f、AtomExプレーヤのパンニング3D距離が0.5fの場合、
	 * 実際に適用されるパンニング3D距離は0.4fになります。
	 * <br/>
	 * 実際に適用されるパンニング3D距離が1.0fを超える値になった場合、値は1.0fにクリップされます。<br/>
	 * 同様に、実際に適用されるパンニング3D距離が-1.0f未満の値になった場合も、値は-1.0fにクリップされます。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // パンニング3D距離の設定
	 * player.SetPan3dInteriorDistance(0.5f);
	 *
	 * // 再生の開始
	 * // 備考）パンニング3D距離はプレーヤに設定された値（＝0.5f）で再生される。
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // パンニング3D距離の変更
	 * // 注意）この時点では再生中の音声のパンニング3D距離は変更されない。
	 * // 備考）以下の処理はパン3D角度を180度反転するのと等価
	 * player.SetPan3dInteriorDistance(-0.5f);
	 *
	 * // プレーヤに設定されたパンニング3D距離を再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 */
	public void SetPan3dInteriorDistance(float distance)
	{
		criAtomExPlayer_SetPan3dInteriorDistance(this.handle, distance);
	}

	/**
	 * <summary>パンニング3Dボリュームの設定</summary>
	 * <param name='volume'>パンニング3Dボリューム（0.0f～1.0f）</param>
	 * <remarks>
	 * <para header='説明'>パンニング3Dのボリュームを指定します。<br/>
	 * 本関数でパンニング3Dボリュームを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたパンニング3Dボリュームで再生されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声のパンニング3Dボリュームを更新することができます。<br/>
	 * <br/>
	 * パンニング3Dボリュームは、パンニング3D成分と、
	 * センター／LFEへの出力レベルとを個別に制御する場合に使用します。<br/>
	 * 例えば、センドレベルで常にLFEから一定のボリュームで出力させておき、
	 * 定位はパンニング3Dでコントロールするような場合です。
	 * <br/>
	 * 値の範囲や扱いは、通常のボリュームと同等です。 ::CriAtomExPlayer::SetVolume 関数を参照してください。</para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // パンニング3Dボリュームの設定
	 * player.SetPan3dVolume(0.8f);
	 *
	 * // 再生の開始
	 * // 備考）パンニング3Dボリュームはプレーヤに設定された値（＝0.5f）で再生される。
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // パンニング3Dボリュームの変更
	 * // 注意）この時点では再生中の音声のパンニング3Dボリュームは変更されない。
	 * player.SetPan3dVolume(0.7f);
	 *
	 * // プレーヤに設定されたパンニング3Dボリュームを再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 * <seealso cref='CriAtomExPlayer::SetVolume'/>
	 */
	public void SetPan3dVolume(float volume)
	{
		criAtomExPlayer_SetPan3dVolume(this.handle, volume);
	}

	/**
	 * <summary>パンタイプの設定</summary>
	 * <param name='panType'>パンタイプ</param>
	 * <remarks>
	 * <para header='説明'>パンタイプを指定します。<br/>
	 * 本関数でパンタイプを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたパンタイプで再生されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声のパンタイプを更新することができます。<br/></para>
	 * <para header='備考'>キュー再生時に本関数を呼び出すと、データ側に設定されているパンタイプ設定を
	 * <b>上書き</b>します（データ側の設定値は無視されます）。<br/>
	 * 通常はデータ側でパンタイプが設定されているため、本関数を呼び出す必要はありません。<br/>
	 * ACBファイルを使用せずに音声を再生する場合に、3Dポジショニング処理を有効にするためには、
	 * 本関数で Pos3d を設定してください。
	 * <br/></para>
	 * <para header='注意'>CriAtomEx.PanType.Unknownを指定して実行した場合、エラーが発生します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 * <seealso cref='CriAtomEx.PanType'/>
	 */
	public void SetPanType(CriAtomEx.PanType panType)
	{
		criAtomExPlayer_SetPanType(this.handle, panType);
	}

	/**
	 * <summary>センドレベルの設定</summary>
	 * <param name='channel'>チャンネル番号</param>
	 * <param name='id'>スピーカーID</param>
	 * <param name='level'>センドレベル値（0.0f～1.0f）</param>
	 * <remarks>
	 * <para header='説明'>センドレベルを指定します。<br/>
	 * センドレベルは、音声データの各チャンネルの音声を、どのスピーカーから
	 * どの程度の音量で出力するかを指定するための仕組みです。<br/>
	 * 本関数でセンドレベルを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたセンドレベルで再生されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声のセンドレベルを更新することができます。<br/>
	 * <br/>
	 * 第1引数のチャンネル番号は"音声データのチャンネル番号"を指定します。<br/>
	 * 第2引数のスピーカーIDには、指定したチャンネル番号のデータをどのスピーカーから
	 * 出力するかを指定し、第3引数では送信時のレベル（ボリューム）を指定します。<br/>
	 * 例えば、音声データのチャンネル0番のデータをライトスピーカーから
	 * フルボリューム（1.0f）で出力したい場合、指定は以下のようになります。<code>
	 * player.SetSendLevel(0, CriAtomEx.Speaker.FrontRight, 1.0f);
	 * </code>
	 * <br/>
	 * センドレベル値の範囲や扱いは、ボリュームと同等です。 ::CriAtomExPlayer::SetVolume 関数を参照してください。<br/>
	 * <br/>
	 * </para>
	 * <para header='備考'>センドレベルの設定には「自動設定」「手動設定」の2通りが存在します。<br/>
	 * AtomExプレーヤを作成した直後や、 ::CriAtomExPlayer::ResetParameters 関数で
	 * パラメータをクリアした場合、センドレベルの設定は「自動設定」となります。<br/>
	 * これに対し、本関数を実行した場合、センドレベルの設定は「手動設定」になります。<br/>
	 * （ユーザが各スピーカーへのセンドレベルをコントロールし、パンニングを行う必要があります。）<br/>
	 * <br/>
	 * 「自動設定」の場合、AtomExプレーヤは以下のように音声をルーティングします。<br/>
	 * <br/>
	 * 【モノラル音声を再生する場合】<br/>
	 * チャンネル0の音声を左右のスピーカーから約0.7f（-3dB）のボリュームで出力します。<br/>
	 * <br/>
	 * 【ステレオ音声を再生する場合】<br/>
	 * チャンネル0の音声をレフトスピーカーから、
	 * チャンネル1の音声をライトスピーカーから出力します。<br/>
	 * <br/>
	 * 【4ch音声を再生する場合】<br/>
	 * チャンネル0の音声をレフトスピーカーから、チャンネル1の音声をライトスピーカーから、
	 * チャンネル2の音声をサラウンドレフトスピーカーから、
	 * チャンネル3の音声をサラウンドライトスピーカーからでそれぞれ出力します。<br/>
	 * <br/>
	 * 【5.1ch音声を再生する場合】<br/>
	 * チャンネル0の音声をレフトスピーカーから、チャンネル1の音声をライトスピーカーから、
	 * チャンネル2の音声をセンタースピーカーから、チャンネル3の音声をLFEから、
	 * チャンネル4の音声をサラウンドレフトスピーカーから、
	 * チャンネル5の音声をサラウンドライトスピーカーからそれぞれ出力します。<br/>
	 * <br/>
	 * 【7.1ch音声を再生する場合】<br/>
	 * チャンネル0の音声をレフトスピーカーから、チャンネル1の音声をライトスピーカーから、
	 * チャンネル2の音声をセンタースピーカーから、チャンネル3の音声をLFEから、
	 * チャンネル4の音声をサラウンドレフトスピーカーから、
	 * チャンネル5の音声をサラウンドライトスピーカーからそれぞれ出力します。<br/>
	 * チャンネル6の音声をサラウンドバックレフトスピーカーから、
	 * チャンネル7の音声をサラウンドバックライトスピーカーからそれぞれ出力します。<br/>
	 * <br/>
	 * これに対し、本関数を用いて「手動設定」を行った場合、音声データのチャンネル数に
	 * 関係なく、指定されたセンドレベル設定で音声が出力されます。<br/>
	 * （音声データのチャンネル数に応じて、適宜センドレベル設定を切り替える必要があります。）<br/>
	 * <br/>
	 * 過去に指定したセンドレベルをクリアし、ルーティングを「自動設定」の状態に戻したい場合は、
	 * ::CriAtomExPlayer::ResetParameters 関数を実行してください。<br/>
	 * <br/>
	 * 本パラメータはデータ側には設定できないため、常に本関数の設定値が適用されます。<br/></para>
	 * <para header='注意'>センドレベルを設定していないチャンネルについては、音声が出力されません。<br/>
	 * 例えば、再生する音声データがステレオにもかかわらず、どちらか一方のチャンネルに対して
	 * しかセンドレベルが設定されていない場合、センドレベルを設定していないチャンネルの音声
	 * はミュートされます。<br/>
	 * センドレベルをコントロールする際には、必ず出力を行いたい全てのチャンネルについてセンド
	 * レベルの設定を行ってください。<br/></para>
	 * </remarks>
	 * <example><code>
	 * CriSint32 ch = 0;    // channel number 0
	 * CriAtomEx.Speaker spk = CriAtomEx.Speaker.FrontCenter;
	 * CriFloat32 level = 1.0f;
	 * // Set send level(ch0 to center)
	 * player.SetSendLevel(ch, spk, level);
	 * // Start playback
	 * CriAtomExPlayback playback = player.Start();
	 *                :
	 * // Change send level
	 * level = 0.7f;
	 * player.SetSendLevel(ch, spk, level);
	 * player.Update(playback);
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 * <seealso cref='CriAtomExPlayer::SetVolume'/>
	 */
	public void SetSendLevel(int channel, CriAtomEx.Speaker id, float level)
	{
		criAtomExPlayer_SetSendLevel(this.handle, channel, id, level);
	}

	/**
	 * <summary>バイクアッドフィルタのパラメータの設定</summary>
	 * <param name='type'>フィルタタイプ</param>
	 * <param name='frequency'>正規化周波数（0.0f～1.0f）</param>
	 * <param name='gain'>ゲイン（デシベル値）</param>
	 * <param name='q'>Q値</param>
	 * <remarks>
	 * <para header='説明'>バイクアッドフィルタの各種パラメータを指定します。<br/>
	 * 本関数でパラメータを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたパラメータでバイクアッドフィルタが動作します。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声に対してバイクアッドフィルタのパラメータを更新することができます。<br/>
	 * <br/>
	 * 正規化周波数は、対数軸上の24Hz～24000Hzを、0.0f～1.0fに正規化した値です。<br/>
	 * ゲインはデシベルで指定します。<br/>
	 * ゲインはフィルタタイプが以下の場合のみ有効です。<br/>
	 * - LowShelf   ：ローシェルフフィルタ
	 * - HighShelf  ：ハイシェルフフィルタ
	 * - Peaking    ：ピーキングフフィルタ
	 * .</para>
	 * <para header='備考'>- type<br/>
	 *  データに設定された値を上書きします。
	 * - frequency<br/>
	 *  データに設定された値に加算されます。
	 * - gain<br/>
	 *  データに設定された値に乗算されます。
	 * - q<br/>
	 *  データに設定された値に加算されます。
	 * .
	 * <br/>
	 * 実際に適用される正規化カットオフ周波数が1.0fを超える値になった場合、値は1.0fにクリップされます。<br/>
	 * 同様に、実際に適用される正規化カットオフ周波数が0.0f未満の値になった場合も、値は0.0fにクリップされます。<br/></para>
	 * <para header='注意'>HCA-MX用にエンコードされた音声データには、バイクアッドフィルタが適用されません。<br/>
	 * バイクアッドフィルタを使用したい音声は、ADXやHCA等、他のコーデックでエンコードしてください。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // フィルタのパラメータを設定
	 * CriAtomEx.BiquadFilterType type = CriAtomEx.BiquadFilterType.LowPass;
	 * float frequency = 0.5f;
	 * float gain = 1.0f;
	 * float q = 3.0f;
	 * player.SetBiquadFilterParameters(type, frequency, gain, q);
	 *
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // パラメータの変更
	 * // 注意）この時点では再生中の音声のパラメータは変更されない。
	 * frequency = 0.7f;
	 * player.SetBiquadFilterParameters(type, frequency, gain, q);
	 *
	 * // プレーヤに設定されたパラメータを再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 */
	public void SetBiquadFilterParameters(
		CriAtomEx.BiquadFilterType type, float frequency, float gain, float q)
	{
		criAtomExPlayer_SetBiquadFilterParameters(this.handle, type, frequency, gain, q);
	}

	/**
	 * <summary>バンドパスフィルタのパラメータ設定</summary>
	 * <param name='cofLow'>正規化低域カットオフ周波数（0.0f～1.0f）</param>
	 * <param name='cofHigh'>正規化高域カットオフ周波数（0.0f～1.0f）</param>
	 * <remarks>
	 * <para header='説明'>バンドパスフィルタのカットオフ周波数を指定します。<br/>
	 * 本関数でカットオフ周波数を設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたカットオフ周波数でバンドパスフィルタが動作します。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声に対してバンドパスフィルタのカットオフ周波数を更新することができます。<br/>
	 * <br/>
	 * 正規化カットオフ周波数は、対数軸上の24Hz～24000Hzを、0.0f～1.0fに正規化した値です。<br/>
	 * 例えば、正規化低域カットオフ周波数を0.0f、正規化高域カットオフ周波数を1.0fと指定すると、
	 * バンドパスフィルタは全域が通過し、正規化低域カットオフ周波数を上げるほど、
	 * また正規化高域カットオフ周波数を下げるほど、通過域が狭くなっていきます。<br/></para>
	 * <para header='備考'>キュー再生時、データ側にバンドパスフィルタのパラメータが設定されている場合に本関数を呼び出すと、
	 * 以下のように設定されます。
	 * - cofLow<br/>
	 *  データに設定された値に対し、「cofLowRev = 1.0f - cofLow」としてから乗算し、
	 *  最終的にまた「cofLow = 1.0f - cofLowRev」と元に戻して適用されます。<br/>
	 *  つまり、0.0fを「低域側に最もフィルタを開く」として、開き具合を乗算して適用していく形になります。
	 * - cofHigh<br/>
	 *  データに設定された値に対し、乗算して適用されます。<br/>
	 *  つまり、1.0fを「高域側に最もフィルタを開く」として、開き具合を乗算して適用していく形になります。
	 * .
	 * <br/>
	 * 実際に適用される正規化カットオフ周波数が1.0fを超える値になった場合、値は1.0fにクリップされます。<br/>
	 * 同様に、実際に適用される正規化カットオフ周波数が0.0f未満の値になった場合も、値は0.0fにクリップされます。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // フィルタのパラメータを設定
	 * float cof_low = 0.0f;
	 * float cof_high = 0.3f;
	 * player.SetBandpassFilterParameter(cof_low, cof_high);
	 *
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // パラメータの変更
	 * // 注意）この時点では再生中の音声のパラメータは変更されない。
	 * cof_low = 0.7f;
	 * cof_high = 1.0f;
	 * player.SetBandpassFilterParameter(cof_low, cof_high);
	 *
	 * // プレーヤに設定されたパラメータを再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 */
	public void SetBandpassFilterParameters(float cofLow, float cofHigh)
	{
		criAtomExPlayer_SetBandpassFilterParameters(this.handle, cofLow, cofHigh);
	}

	/**
	 * <summary>バスセンドレベルの設定（バス名指定）</summary>
	 * <param name='busName'>バス名</param>
	 * <param name='level'>センドレベル値（0.0f～1.0f）</param>
	 * <remarks>
	 * <para header='説明'>バスセンドレベルを指定します。<br/>
	 * バスセンドレベルは、音声をどのバスにどれだけ流すかを指定するための仕組みです。<br/>
	 * 本関数でバスセンドレベルを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたバスセンドレベルで再生されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声のバスセンドレベルを更新することができます。<br/>
	 * <br/>
	 * 第1引数のバスIDは"音声データのチャンネル番号"を指定します。<br/>
	 * 第2引数では送信時のレベル（ボリューム）を指定します。<br/>
	 * <br/>
	 * センドレベル値の範囲や扱いは、ボリュームと同等です。 ::CriAtomExPlayer::SetVolume 関数を参照してください。</para>
	 * <para header='備考'>本関数を複数回呼び出すことで、複数のバスに流すこともできます。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // バスセンドレベルを設定
	 * int bus_id = 1;  // ex. reverb, etc...
	 * float level = 0.3f;
	 * player.SetBusSendLevel(bus_id, level);
	 *
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // パラメータの変更
	 * // 注意）この時点では再生中の音声のパラメータは変更されない。
	 * level = 0.5f;
	 * player.SetBusSendLevel(bus_id, level);
	 *
	 * // プレーヤに設定されたパラメータを再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 * <seealso cref='CriAtomExPlayer::SetVolume'/>
	 */
	public void SetBusSendLevel(string busName, float level)
	{
		criAtomExPlayer_SetBusSendLevelByName(this.handle, busName, level);
	}

	/**
	 * <summary>バスセンドレベルの取得（バス名指定）</summary>
	 * <param name='busName'>バス名</param>
	 * <param name='level'>センドレベル値（0.0f～1.0f）</param>
	 * <returns>取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
	 * <remarks>
	 * <para header='説明'>プレーヤーに設定されている特定のバスセンドレベルを取得します。<br/>
	 * 以下のケースに該当する場合、バス鮮度レベルの取得に失敗します。<br/>
	 *  - 指定した名前のバスが適用中のDSPバス設定に存在しない
	 *  - プレーヤーに指定したバスへのセンドレベル設定が行われていない</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::SetBusSendLevel'/>
	 */
	public bool GetBusSendLevel(string busName, out float level) 
	{
		return criAtomExPlayer_GetBusSendLevelByName(this.handle, busName, out level);
	}

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * CriAtomExPlayer.SetBusSendLevel(string busName, float level)の使用を検討してください。
	*/
	[System.Obsolete("Use CriAtomExPlayer.SetBusSendLevel(string busName, float level)")]
	public void SetBusSendLevel(int busId, float level)
	{
		criAtomExPlayer_SetBusSendLevel(this.handle, busId, level);
	}


	/**
	 * <summary>オフセットによるバスセンドレベルの設定（バス名指定）</summary>
	 * <param name='busName'>バス名</param>
	 * <param name='levelOffset'>センドレベル値（0.0f～1.0f）</param>
	 * <remarks>
	 * <para header='説明'>バスセンドレベルをオフセットで指定します。<br/>
	 * キュー再生時、データ側にバスセンドレベルが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>加算</b>した値が適用されます。<br/>
	 * それ以外の仕様は ::CriAtomExPlayer::SetBusSendLevel 関数と同様です。</para>
	 * <para header='備考'>::CriAtomExPlayer::SetBusSendLevel 関数で 0.0f を設定し、かつ本関数でオフセット値を設定することで、<br/>
	 * データ側に設定されていたバスセンドレベルを無視して値が設定可能です。（上書き設定）</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::SetBusSendLevel'/>
	 */
	public void SetBusSendLevelOffset(string busName, float levelOffset)
	{
		criAtomExPlayer_SetBusSendLevelOffsetByName(this.handle, busName, levelOffset);
	}

	/**
	 * <summary>バスセンドレベルのオフセットの取得（バス名指定）</summary>
	 * <param name='busName'>バス名</param>
	 * <param name='level'>センドレベルのオフセット値（0.0f～1.0f）</param>
	 * <returns>取得できたかどうか？（取得できた：TRUE／取得できない：FALSE）</returns>
	 * <remarks>
	 * <para header='説明'>プレーヤーに設定されている特定のバスセンドレベルのオフセットを取得します。<br/>
	 * 以下のケースに該当する場合、バス鮮度レベルの取得に失敗します。<br/>
	 *  - 指定した名前のバスが適用中のDSPバス設定に存在しない
	 *  - プレーヤーに指定したバスへのセンドレベル設定が行われていない</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::SetBusSendLevelOffset'/>
	 */
	public bool GetBusSendLevelOffset(string busName, out float level) 
	{
		return criAtomExPlayer_GetBusSendLevelOffsetByName(this.handle, busName, out level);
	}

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * CriAtomExPlayer.SetBusSendLevelOffset(int busId, float levelOffset)の使用を検討してください。
	*/
	[System.Obsolete("Use CriAtomExPlayer.SetBusSendLevelOffset(int busId, float levelOffset)")]
	public void SetBusSendLevelOffset(int busId, float levelOffset)
	{
		criAtomExPlayer_SetBusSendLevelOffset(this.handle, busId, levelOffset);
	}

	/**
	 * <summary>プレーヤにAISACを付与</summary>
	 * <param name='globalAisacName'>取り付けるグローバルAISAC名</param>
	 * <remarks>
	 * <para header='説明'>プレーヤにAISACをアタッチ（付与）します。
	 * AISACをアタッチすることにより、キューやトラックにAISACを設定していなくても、AISACの効果を得ることができます。<br/>
	 * 本関数でAISACをアタッチ後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * アタッチしたAISACを考慮して、各種パラメータが適用されます。<br/>
	 * またアタッチ後、::CriAtomExPlayer::Update 関数、::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声に対しても、アタッチしたAISACによる各種パラメータ設定を適用することができます。<br/></para>
	 * <para header='備考'>全体設定（ACFファイル）に含まれるグローバルAISACのみ、アタッチ可能です。<br/>
	 * AISACの効果を得るには、キューやトラックに設定されているAISACと同様に、
	 * 該当するAISACコントロール値を設定する必要があります。
	 * <br/>
	 * 本パラメータは ::CriAtomExPlayer::ResetParameters 関数にてクリアされます。</para>
	 * <para header='注意'>キューやトラックに「AISACコントロール値を変更するAISAC」が設定されていたとしても、
	 * その適用結果のAISACコントロール値は、プレーヤにアタッチしたAISACには影響しません。
	 * 現在、「オートモジュレーション」や「ランダム」といったコントロールタイプのAISACのアタッチには対応しておりません。<br/>
	 * 現在、プレーヤにアタッチできるAISACの最大数は、8個固定です。</para>
	 * </remarks>
	 */
	public void AttachAisac(string globalAisacName)
	{
		criAtomExPlayer_AttachAisac(this.handle, globalAisacName);
	}

	/**
	 * <summary>プレーヤからAISACを分離</summary>
	 * <param name='globalAisacName'>取り外すグローバルAISAC名</param>
	 * <remarks>
	 * <para header='説明'>プレーヤからAISACをデタッチ（分離）します。<br/>
	 * 本関数でAISACをデタッチ後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * デタッチしたAISACの影響は受けなくなります。<br/>
	 * またデタッチ後、::CriAtomExPlayer::Update 関数、::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声に対しても、デタッチしたAISACによる影響を受けなくなります。<br/></para>
	 * </remarks>
	 */
	public void DetachAisac(string globalAisacName)
	{
		criAtomExPlayer_DetachAisac(this.handle, globalAisacName);
	}


	/**
	 * <summary>AISACコントロール値の設定（コントロール名指定）</summary>
	 * <param name='controlName'>コントロール名</param>
	 * <param name='value'>コントロール値（0.0f～1.0f）</param>
	 * <remarks>
	 * <para header='説明'>コントロール名指定でAISACのコントロール値を指定します。<br/>
	 * AISACのコントロール値は１つのプレイヤーに対して最大８つまで設定可能です。 <br/>
	 * 本関数でAISACコントロール値を設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたAISACコントロール値で再生されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声のAISACコントロール値を更新することができます。<br/>
	 * <br/>
	 * AISACコントロール値の扱いは::CriAtomExPlayer::SetAisacControl 関数と同様です。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // AISACコントロール値の設定
	 * float control_value = 0.5f;
	 * player.SetAisacControl("Any", control_value);
	 *
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // パラメータの変更
	 * // 注意）この時点では再生中の音声のパラメータは変更されない。
	 * control_value = 0.3f;
	 * player.SetAisacControl("Any", control_value);
	 *
	 * // プレーヤに設定されたパラメータを再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 * <seealso cref='CriAtomExPlayer::SetAisacControl(uint, float)'/>
	 */
	public void SetAisacControl(string controlName, float value)
	{
		criAtomExPlayer_SetAisacControlByName(this.handle, controlName, value);
	}

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * CriAtomExPlayer.SetAisacControlの使用を検討してください。
	*/
	[System.Obsolete("Use CriAtomExPlayer.SetAisacControl")]
	public void SetAisac(string controlName, float value)
	{
		SetAisacControl(controlName, value);
	}

	/**
	 * <summary>AISACコントロール値の設定（コントロールID指定）</summary>
	 * <param name='controlId'>コントロールID</param>
	 * <param name='value'>コントロール値（0.0f～1.0f）</param>
	 * <remarks>
	 * <para header='説明'>コントロールID指定でAISACのコントロール値を指定します。<br/>
	 * AISACのコントロール値は１つのプレイヤーに対して最大８つまで設定可能です。 <br/>
	 * 本関数でAISACコントロール値を設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたAISACコントロール値で再生されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声のAISACコントロール値を更新することができます。<br/>
	 * <br/>
	 * AISACコントロール値には、0.0f～1.0fの範囲で実数値を指定します。<br/></para>
	 * <para header='備考'>AISACのコントロールタイプによって、以下のように挙動が変わります。
	 *  - オフ
	 *      - 本関数等によるAISACコントロール値が未設定の場合はそのAISACは動作しません。
	 *      .
	 *  - オートモジュレーション
	 *      - 本関数の設定値には影響されず、時間経過とともに自動的にAISACコントロール値が変化します。
	 *      .
	 *  - ランダム
	 *      - 本関数等によって設定されたAISACコントロール値を中央値として、
	 *        データに設定されたランダム幅でランダマイズし、最終的なAISACコントロール値を決定します。
	 *      - ランダマイズ処理は再生開始時のパラメータ適用でのみ行われ、
	 *        再生中の音声に対するAISACコントロール値変更はできません。
	 *      - 再生開始時にAISACコントロール値が設定されていなかった場合、
	 *        0.0fを中央値としてランダマイズ処理を行います。
	 *      .
	 *  .</para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // AISACコントロール値の設定
	 * CriAtomExAisacControlId control_id = 0;
	 * float control_value = 0.5f;
	 * player.SetAisacControl(control_id, control_value);
	 *
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // パラメータの変更
	 * // 注意）この時点では再生中の音声のパラメータは変更されない。
	 * control_value = 0.3f;
	 * player.SetAisacControl(control_id, control_value);
	 *
	 * // プレーヤに設定されたパラメータを再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 * <seealso cref='CriAtomExPlayer::SetAisacControl(string, float)'/>
	 */
	public void SetAisacControl(uint controlId, float value)
	{
		criAtomExPlayer_SetAisacControlById(this.handle, (ushort)controlId, value);
	}

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * CriAtomExPlayer.SetAisacControlの使用を検討してください。
	*/
	[System.Obsolete("Use SetAisacControl")]
	public void SetAisac(uint controlId, float value)
	{
		criAtomExPlayer_SetAisacControlById(this.handle, (ushort)controlId, value);
	}

	/**
	 * <summary>プレーヤにアタッチされているAISAC情報の取得</summary>
	 * <param name='aisacAttachedIndex'>アタッチされているAISACのインデックス</param>
	 * <param name='aisacInfo'>AISAC情報取得用構造体</param>
	 * <remarks>
	 * <para header='説明'>プレーヤにアタッチされているAISACの情報を取得します。<br/></para>
	 * <para header='注意'>無効なインデックスを指定した場合、falseが返ります。<br/></para>
	 * </remarks>
	 */
	public bool GetAttachedAisacInfo(int aisacAttachedIndex, out CriAtomEx.AisacInfo aisacInfo)
	{
		using (var mem = new CriStructMemory<CriAtomEx.AisacInfo>()) {
			bool result = criAtomExPlayer_GetAttachedAisacInfo(this.handle, aisacAttachedIndex, mem.ptr);
			if (result) {
				aisacInfo = new CriAtomEx.AisacInfo(mem.bytes, 0);
			} else {
				aisacInfo = new CriAtomEx.AisacInfo();
			}
			return result;
		}
	}

	/**
	 * <summary>3D音源オブジェクトの設定</summary>
	 * <param name='source'>CriAtomEx3dSourceオブジェクト</param>
	 * <remarks>
	 * <para header='説明'>3Dポジショニングを実現するための3D音源オブジェクトを設定します。<br/>
	 * 3Dリスナーオブジェクトと3D音源オブジェクトを設定することで、
	 * 3Dリスナーオブジェクトと3D音源オブジェクトの位置関係等から定位や音量、ピッチ等が自動的に適用されます。<br/>
	 * 本関数で3D音源オブジェクトを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定された3D音源オブジェクトを参照して再生されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声が参照する3D音源オブジェクトを変更することができます。<br/>
	 * sourceにnullを設定した場合は、すでに設定されている3D音源オブジェクトをクリアします。<br/></para>
	 * <para header='注意'>3D音源オブジェクトのパラメータの変更、更新は、AtomExプレーヤの関数ではなく、
	 * 3D音源オブジェクトの関数を使用して行います。<br/>
	 * デフォルトでは、3Dポジショニングの計算は左手座標系で行われます。<br/>
	 * <br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // リスナの作成
	 * CriAtomEx3dListener listener = new CriAtomEx3dListener();
	 *
	 * // ソースの作成
	 * CriAtomEx3dSource source = new CriAtomEx3dSource();
	 *
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 * // ソース、リスナをプレーヤに設定
	 * player.Set3dListener(listener);
	 * player.Set3dSource(source);
	 *  ：
	 * // 音源の位置を初期化
	 * source.SetPosition(0.0f, 0.0f, 0.0f);
	 * source.Update();
	 *  ：
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // 音源の位置を変更
	 * source.SetPosition(10.0f, 0.0f, 0.0f);
	 * source.Update();
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomEx3dListener'/>
	 * <seealso cref='CriAtomExPlayer::Set3dSource'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 */
	public void Set3dSource(CriAtomEx3dSource source)
	{
		criAtomExPlayer_Set3dSourceHn(this.handle, (source == null) ? IntPtr.Zero : source.nativeHandle);
	}

	/**
	 * <summary>3Dリスナーオブジェクトの設定</summary>
	 * <param name='listener'>3Dリスナーオブジェクト</param>
	 * <remarks>
	 * <para header='説明'>3Dポジショニングを実現するための3Dリスナーオブジェクトを設定します。<br/>
	 * 3Dリスナーオブジェクトと3D音源オブジェクトを設定することで、
	 * 3Dリスナーと3D音源の位置関係等から定位や音量、ピッチ等が自動的に適用されます。<br/>
	 * 本関数で3Dリスナーオブジェクトを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定された3Dリスナーオブジェクトを参照して再生されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声が参照する3Dリスナーオブジェクトを変更することができます。<br/>
	 * listenerにnullを設定した場合は、すでに設定されている3Dリスナーオブジェクトをクリアします。<br/></para>
	 * <para header='注意'>3Dリスナーオブジェクトのパラメータの変更、更新は、AtomExプレーヤの関数ではなく、
	 * 3Dリスナーオブジェクトの関数を使用して行います。<br/>
	 * デフォルトでは、3Dポジショニングの計算は左手座標系で行われます。<br/>
	 * <br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // リスナの作成
	 * CriAtomEx3dListener listener = new CriAtomEx3dListener();
	 *
	 * // ソースの作成
	 * CriAtomEx3dSource source = new CriAtomEx3dSource();
	 *
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *
	 * // ソース、リスナをプレーヤに設定
	 * player.Set3dListener(listener);
	 * player.Set3dSource(source);
	 *  ：
	 * // 音源の位置を初期化
	 * source.SetPosition(0.0f, 0.0f, 0.0f);
	 * source.Update();
	 *  ：
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // リスナの位置を変更
	 * listener.SetPosition(-10.0f, 0.0f, 0.0f);
	 * listener.Update();
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomEx3dListener'/>
	 * <seealso cref='CriAtomExPlayer::Set3dSource'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 */
	public void Set3dListener(CriAtomEx3dListener listener)
	{
		criAtomExPlayer_Set3dListenerHn(this.handle, ((listener == null) ? IntPtr.Zero : listener.nativeHandle));
	}

	/**
	 * <summary>再生開始位置の指定</summary>
	 * <param name='startTimeMs'>再生開始位置（ミリ秒指定）</param>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤで再生する音声について、再生を開始する位置を指定します。<br/>
	 * 音声データを途中から再生したい場合、再生開始前に本関数で再生開始位置を
	 * 指定する必要があります。<br/>
	 * <br/>
	 * 再生開始位置の指定はミリ秒単位で行います。<br/>
	 * 例えば、 start_time_ms に 10000 をセットして本関数を実行すると、
	 * 次に再生する音声データは 10 秒目の位置から再生されます。</para>
	 * <para header='備考'>音声データ途中からの再生は、音声データ先頭からの再生に比べ、発音開始の
	 * タイミングが遅くなります。<br/>
	 * これは、一旦音声データのヘッダを解析後、指定位置にジャンプしてからデータを読み
	 * 直して再生を開始するためです。</para>
	 * <para header='注意'>startTimeMs には64bit値をセット可能ですが、現状、32bit以上の再生時刻を
	 * 指定することはできません。<br/>
	 * <br/>
	 * 
	 * 再生開始位置を指定してシーケンスを再生した場合、指定位置よりも前に配置された
	 * 波形データは再生されません。<br/>
	 * （シーケンス内の個々の波形が途中から再生されることはありません。）<br/></para>
	 * </remarks>
	 */
	public void SetStartTime(long startTimeMs)
	{
		criAtomExPlayer_SetStartTime(this.handle, startTimeMs);
	}

	/**
	 * <summary>再生開始ブロックのセット（ブロックインデックス指定）</summary>
	 * <param name='index'>ブロックインデックス</param>
	 * <remarks>
	 * <para header='説明'>再生開始ブロックインデックスを、AtomExプレーヤに関連付けます。<br/>
	 * 本関数で再生開始ブロックインデックスを指定後、ブロックシーケンスキューを
	 * ::CriAtomExPlayer::Start 関数で再生開始すると指定したブロックから再生を開始します。</para>
	 * <para header='備考'>AtomExプレーヤのデフォルトブロックインデックスは 0 です。<br/>
	 * ::CriAtomExPlayer::Start 関数による再生開始時にプレーヤに設定されているキューが
	 * ブロックシーケンスでない場合は、本関数で設定した値は利用されません。<br/>
	 * 指定したインデックスに対応したブロックがない場合は先頭ブロックから再生が行われます。<br/>
	 * この際、指定インデックスのブロックが存在しない内容のワーニングが発生します。<br/></para>
	 * <para header='備考'>再生開始後のブロック遷移は ::CriAtomExPlayback::SetNextBlockIndex 関数を使用して行い、
	 * 再生中のブロックインデックス取得は ::CriAtomExPlayback::GetCurrentBlockIndex 関数を使用します。</para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // 音声データをセット
	 * player.SetCue(acb, 300);
	 *
	 * // 開始ブロックをセット
	 * player.SetFirstBlockIndex(1);
	 *
	 * // セットされた音声データを再生
	 * player.Start();
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayback::SetNextBlockIndex'/>
	 * <seealso cref='CriAtomExPlayback::GetCurrentBlockIndex'/>
	 */
	public void SetFirstBlockIndex(int index)
	{
		criAtomExPlayer_SetFirstBlockIndex(this.handle, index);
	}

	/**
	 * <summary>セレクタ情報の設定</summary>
	 * <param name='selector'>セレクタ名</param>
	 * <param name='label'>ラベル名</param>
	 * <remarks>
	 * <para header='説明'>セレクタ名とラベル名を指定して、プレーヤに設定します。１つのプレイヤーに対して最大８つまで設定可能です。<br/>
	 * トラックにセレクタラベルが指定されているキューを再生した場合、本関数で指定したセレクタラベル
	 * と一致したトラックだけを再生します。<br/>
	 * プレーヤに設定したラベル情報の個別削除は ::CriAtomExPlayer::UnsetSelectorLabel を実行してください。<br/>
	 * 全てのラベル情報の削除は ::CriAtomExPlayer::ClearSelectorLabels を実行してください。<br/>
	 * ラベル情報を含む全てのプレーヤ設定値削除は ::CriAtomExPlayer::ResetParameters を実行してください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::UnsetSelectorLabel'/>
	 * <seealso cref='CriAtomExPlayer::ClearSelectorLabels'/>
	 * <seealso cref='CriAtomExPlayer::ResetParameters'/>
	 */
	public void SetSelectorLabel(string selector, string label)
	{
		criAtomExPlayer_SetSelectorLabel(this.handle, selector, label);
	}

	/**
	 * <summary>設定されているセレクタ情報の削除</summary>
	 * <param name='selector'>セレクタ名</param>
	 * <param name='label'>ラベル名</param>
	 * <remarks>
	 * <para header='説明'>プレーヤに設定されている指定のセレクタ名とそれに紐づくラベル名の情報を削除します。<br/>
	 * また削除後、::CriAtomExPlayer::Update 、::CriAtomExPlayer::UpdateAll を呼び出すことにより、
	 * すでに再生中の音声に対してセレクタ情報の削除が行えますが、再生中音声が停止することはありません。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::UnsetSelectorLabel'/>
	 * <seealso cref='CriAtomExPlayer::SetSelectorLabel'/>
	 * <seealso cref='CriAtomExPlayer::ClearSelectorLabels'/>
	 */
	public void UnsetSelectorLabel(string selector, string label)
	{
		criAtomExPlayer_UnsetSelectorLabel(this.handle, selector, label);
	}

	/**
	 * <summary>設定されている全てのセレクタ情報の削除</summary>
	 * <remarks>
	 * <para header='説明'>プレーヤに設定されているセレクタ名、ラベル名情報を全て削除します。<br/>
	 * また削除後、::CriAtomExPlayer::Update 、::CriAtomExPlayer::UpdateAll を呼び出すことにより、
	 * すでに再生中の音声に対してセレクタ情報の削除が行えますが、再生中音声が停止することはありません。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::ResetParameters'/>
	 */
	public void ClearSelectorLabels()
	{
		criAtomExPlayer_ClearSelectorLabels(this.handle);
	}

	/**
	 * <summary>カテゴリの設定（ID指定）</summary>
	 * <param name='categoryId'>カテゴリID</param>
	 * <remarks>
	 * <para header='説明'>カテゴリID指定でカテゴリを設定します。<br/>
	 * 設定したカテゴリ情報を削除するには、 ::CriAtomExPlayer::UnsetCategory 関数を使用します。<br/></para>
	 * <para header='備考'>キュー再生時に本関数を呼び出すと、データ側に設定されているカテゴリ設定を
	 * <b>上書き</b>します（データ側の設定値は無視されます）。<br/>
	 * 本関数で設定したカテゴリ情報は、ACFのレジスト、アンレジストを行うとクリアされます。<br/>
	 * ACFをレジストしていない状態ではデフォルトカテゴリが使用可能です。</para>
	 * <para header='注意'>カテゴリ設定は再生開始前に行ってください。再生中の音声に対してカテゴリ設定の更新を行うと、
	 * カテゴリの再生数カウントが異常になる危険があります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::UnsetCategory'/>
	 * <seealso cref='CriAtomExPlayer::SetCategory(string)'/>
	 */
	public void SetCategory(int categoryId)
	{
		criAtomExPlayer_SetCategoryById(this.handle, (uint)categoryId);
	}

	/**
	 * <summary>カテゴリの設定（カテゴリ名指定）</summary>
	 * <param name='categoryName'>カテゴリ名</param>
	 * <remarks>
	 * <para header='説明'>カテゴリ名指定でカテゴリを設定します。<br/>
	 * 設定したカテゴリ情報を削除するには、 ::CriAtomExPlayer::UnsetCategory 関数を使用します。<br/></para>
	 * <para header='備考'>カテゴリ指定を名前で行うことを除き、基本的な仕様は ::CriAtomExPlayer::SetCategory(int) 関数と同様です。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::UnsetCategory'/>
	 * <seealso cref='CriAtomExPlayer::SetCategory(int)'/>
	 */
	public void SetCategory(string categoryName)
	{
		criAtomExPlayer_SetCategoryByName(this.handle, categoryName);
	}

	/**
	 * <summary>カテゴリの削除</summary>
	 * <remarks>
	 * <para header='説明'>プレーヤハンドルに設定されているカテゴリ情報を削除します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::SetCategory'/>
	 */
	public void UnsetCategory()
	{
		criAtomExPlayer_UnsetCategory(this.handle);
	}

	/**
	 * <summary>キュープライオリティの設定</summary>
	 * <param name='priority'>キュープライオリティ</param>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤにキュープライオリティを設定します。<br/>
	 * 本関数でキュープライオリティをセット後、 ::CriAtomExPlayer::Start 関数で音声を再生すると、
	 * 再生された音声は本関数でセットしたキュープライオリティで発音されます。<br/>
	 * 関数実行前のデフォルト設定値は0です。<br/></para>
	 * <para header='備考'>AtomExプレーヤがキューを再生した際、再生するキューの所属先カテゴリがリミット数
	 * 分発音済みの場合、プライオリティによる発音制御が行われます。<br/>
	 * 具体的には、AtomExプレーヤの再生リクエストが、再生中のキューのプライオリティよりも
	 * 高い場合、AtomExプレーヤは再生中のキューを停止し、リクエストによる再生を開始します。<br/>
	 * （再生中の音声が停止され、別の音声が再生されます。）<br/>
	 * 逆に、AtomExプレーヤの再生リクエストが、再生中のキューのプライオリティよりも低い場合、
	 * AtomExプレーヤの再生リクエストが拒否されます。<br/>
	 * （リクエストされたキューは再生されません。）<br/>
	 * AtomExプレーヤの再生リクエストが、再生中のキューのプライオリティと等しい場合、
	 * AtomExプレーヤは後着優先で発音制御を行います。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::ResetParameters'/>
	 */
	public void SetCuePriority(int priority)
	{
		criAtomExPlayer_SetCuePriority(this.handle, priority);
	}

	/**
	 * <summary>ボイスプライオリティの設定</summary>
	 * <param name='priority'>ボイスプライオリティ（-255～255）</param>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤにボイスプライオリティを設定します。<br/>
	 * 本関数でプライオリティをセット後、 ::CriAtomExPlayer::Start 関数で音声を再生すると、
	 * 再生された音声は本関数でセットしたプライオリティで発音されます。<br/>
	 * また設定後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出すことにより、
	 * すでに再生された音声のプライオリティを更新することができます。<br/>
	 * <br/>
	 * ボイスプライオリティには、-255～255の範囲で整数値を指定します。<br/>
	 * 範囲外の値を設定した場合、範囲に収まるようにクリッピングされます。<br/>
	 * 関数実行前のデフォルト設定値は0です。<br/></para>
	 * <para header='備考'>AtomExプレーヤが波形データを再生しようとした際、
	 * 当該波形データが所属するボイスリミットグループの発音数が上限に達していた場合や、
	 * ボイスプール内のボイスが全て使用中であった場合、
	 * ボイスプライオリティによる発音制御が行われます。<br/>
	 * （指定された波形データを再生するかどうかを、ボイスプライオリティを元に判定します。）<br/>
	 * <br/>
	 * 具体的には、再生を行おうとした波形データのプライオリティが、
	 * 現在ボイスで再生中の波形データのプライオリティよりも高い場合、
	 * AtomExプレーヤは再生中のボイスを奪い取り、リクエストされた波形データの再生を開始します。<br/>
	 * （再生中の音声が停止され、別の音声が再生されます。）<br/>
	 * <br/>
	 * 逆に、再生を行おうとした波形データのプライオリティが、
	 * ボイスで再生中の波形データのプライオリティよりも低い場合、
	 * AtomExプレーヤはリクエストされた波形データの再生を行いません。<br/>
	 * （リクエストされた音声は再生されず、再生中の音声が引き続き鳴り続けます。）<br/>
	 * <br/>
	 * 再生しようとした波形データのプライオリティが、
	 * ボイスで再生中の波形データのプライオリティと等しい場合、
	 * AtomExプレーヤは発音制御方式（先着優先 or 後着優先）に従い、
	 * 以下のような制御が行われます。<br/>
	 * - 先着優先時は、再生中の波形データを優先し、リクエストされた波形データを再生しません。
	 * - 後着優先時は、リクエストされた波形データを優先し、ボイスを奪い取ります。
	 * .
	 * <br/>
	 * キュー再生時、データ側にボイスプライオリティが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数による設定値とを<b>加算</b>した値が適用されます。<br/>
	 * 例えば、データ側のプライオリティが255、AtomExプレーヤのプライオリティが45の場合、
	 * 実際に適用されるプライオリティは300になります。<br/>
	 * 本関数で設定可能な値の範囲は-255～255ですが、ライブラリ内部の計算はintの範囲で行われるため、
	 * データ側と加算した結果は-255～255を超える場合があります。<br/></para>
	 * <para header='注意'>本関数は、波形データにセットされた<b>ボイスプライオリティ</b>を制御します。<br/>
	 * Atom Craft上でキューに対して設定された<b>カテゴリキュープライオリティ</b>には影響を与えませんので、
	 * ご注意ください。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 * <seealso cref='CriAtomExPlayer::SetVoiceControlMethod'/>
	 */
	public void SetVoicePriority(int priority)
	{
		criAtomExPlayer_SetVoicePriority(this.handle, priority);
	}

	/**
	 * <summary>ボイス制御方法の指定</summary>
	 * <param name='method'>ボイス制御方法</param>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤにボイス制御方法を設定します。<br/>
	 * 本関数でボイス制御方法をセット後、 ::CriAtomExPlayer::Start 関数で音声を再生すると、
	 * 当該プレーヤで再生する波形データには、本関数で指定した制御方式が適用されます。<br/>
	 * 関数実行前のデフォルト設定値は後着優先（ PreferLast ）です。<br/></para>
	 * <para header='備考'>AtomExプレーヤが波形データを再生しようとした際、
	 * 当該波形データが所属するボイスリミットグループの発音数が上限に達していた場合や、
	 * ボイスプール内のボイスが全て使用中であった場合、
	 * ボイスプライオリティによる発音制御が行われます。<br/>
	 * <br/>
	 * 本関数でセットされたボイス制御方式は、発音制御の際、
	 * 再生しようとした波形データのプライオリティと、
	 * 再生中の波形データのプライオリティが同プライオリティであった場合に考慮されます。<br/>
	 * （ボイスプライオリティによる発音制御の詳細は ::CriAtomExPlayer::SetVoicePriority
	 * 関数の説明をご参照ください。）<br/></para>
	 * <para header='既知の不具合'>現状、本関数でボイス制御方法を指定した場合でも、
	 * キュー再生時にはオーサリングツール上でセットしたボイス制御方法が優先して適用されます。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::SetVoicePriority'/>
	 * <seealso cref='CriAtomEx.VoiceControlMethod'/>
	 */
	public void SetVoiceControlMethod(CriAtomEx.VoiceControlMethod method)
	{
		criAtomExPlayer_SetVoiceControlMethod(this.handle, method);
	}

	/**
	 * <summary>プリディレイタイムの設定</summary>
	 * <param name='time'>プリディレイタイム（0.0f～2000.0f）</param>
	 * <remarks>
	 * <para header='説明'>プリディレイタイムを設定します。<br/>
	 * 本関数でプリディレイタイムを設定後、::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたプリディレイタイム発音を待ちます。<br/>
	 * <br/>
	 * プリディレイタイムには、0.0f～10000.0fの範囲で実数値を指定します。単位はms（ミリ秒）です。<br/>
	 * プリディレイタイムのデフォルト値は0.0fです。<br/></para>
	 * <para header='備考'>キュー再生時、データ側にプリディレイタイムが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値と本関数の設定値を<b>加算</b>した値が適用されます。<br/></para>
	 * <para header='注意'>再生中に ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数によって更新することはできません。<br/>
	 * <br/>
	 * HCA-MX用にエンコードされた音声データには、プリディレイが適用されません。<br/>
	 * エンベロープを使用したい音声は、ADXやHCA等、他のコーデックでエンコードしてください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public void SetPreDelayTime(float time)
	{
		criAtomExPlayer_SetPreDelayTime(this.handle, time);
	}

	/**
	 * <summary>エンベロープのアタックタイムの設定</summary>
	 * <param name='time'>アタックタイム（0.0f～2000.0f）</param>
	 * <remarks>
	 * <para header='説明'>エンベロープのアタックタイムを設定します。<br/>
	 * 本関数でアタックタイムを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたアタックタイムで再生されます。<br/>
	 * <br/>
	 * アタックタイムには、0.0f～2000.0fの範囲で実数値を指定します。単位はms（ミリ秒）です。<br/>
	 * アタックタイムのデフォルト値は0.0fです。<br/></para>
	 * <para header='備考'>キュー再生時、データ側にアタックタイムが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値を<b>上書き</b>して適用されます（データ側の設定値は無視されます）。<br/></para>
	 * <para header='注意'>再生中に ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数によって更新することはできません。<br/>
	 * <br/>
	 * HCA-MX用にエンコードされた音声データには、エンベロープが適用されません。<br/>
	 * エンベロープを使用したい音声は、ADXやHCA等、他のコーデックでエンコードしてください。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // エンベロープの設定
	 * player.SetEnvelopeAttackTime(10.0f);
	 *
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public void SetEnvelopeAttackTime(float time)
	{
		criAtomExPlayer_SetEnvelopeAttackTime(this.handle, time);
	}

	/**
	 * <summary>エンベロープのホールドタイムの設定</summary>
	 * <param name='time'>ホールドタイム（0.0f～2000.0f）</param>
	 * <remarks>
	 * <para header='説明'>エンベロープのホールドタイムを設定します。<br/>
	 * 本関数でホールドタイムを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたホールドタイムで再生されます。<br/>
	 * <br/>
	 * ホールドタイムには、0.0f～2000.0fの範囲で実数値を指定します。単位はms（ミリ秒）です。<br/>
	 * ホールドタイムのデフォルト値は0.0fです。<br/></para>
	 * <para header='備考'>キュー再生時、データ側にホールドタイムが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値を<b>上書き</b>して適用されます（データ側の設定値は無視されます）。<br/></para>
	 * <para header='注意'>再生中に ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数によって
	 * 更新することはできません。<br/>
	 * <br/>
	 * HCA-MX用にエンコードされた音声データには、エンベロープが適用されません。<br/>
	 * エンベロープを使用したい音声は、ADXやHCA等、他のコーデックでエンコードしてください。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // エンベロープの設定
	 * player.SetEnvelopeHoldTime(player, 20.0f);
	 *
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public void SetEnvelopeHoldTime(float time)
	{
		criAtomExPlayer_SetEnvelopeHoldTime(this.handle, time);
	}

	/**
	 * <summary>エンベロープのディケイタイムの設定</summary>
	 * <param name='time'>ディケイタイム（0.0f～2000.0f）</param>
	 * <remarks>
	 * <para header='説明'>エンベロープのディケイタイムを設定します。<br/>
	 * 本関数でディケイタイムを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたディケイタイムで再生されます。<br/>
	 * <br/>
	 * ディケイタイムには、0.0f～2000.0fの範囲で実数値を指定します。単位はms（ミリ秒）です。<br/>
	 * ディケイタイムのデフォルト値は0.0fです。<br/></para>
	 * <para header='備考'>キュー再生時、データ側にディケイタイムが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値を<b>上書き</b>して適用されます（データ側の設定値は無視されます）。<br/></para>
	 * <para header='注意'>再生中に ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数によって
	 * 更新することはできません。<br/>
	 * <br/>
	 * HCA-MX用にエンコードされた音声データには、エンベロープが適用されません。<br/>
	 * エンベロープを使用したい音声は、ADXやHCA等、他のコーデックでエンコードしてください。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // エンベロープの設定
	 * player.SetEnvelopeDecayTime(player, 10.0f);
	 *
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public void SetEnvelopeDecayTime(float time)
	{
		criAtomExPlayer_SetEnvelopeDecayTime(this.handle, time);
	}

	/**
	 * <summary>エンベロープのリリースタイムの設定</summary>
	 * <param name='time'>リリースタイム（0.0f～10000.0f）</param>
	 * <remarks>
	 * <para header='説明'>エンベロープのリリースタイムを設定します。<br/>
	 * 本関数でリリースタイムを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたリリースタイムで再生されます。<br/>
	 * <br/>
	 * リリースタイムには、0.0f～10000.0fの範囲で実数値を指定します。単位はms（ミリ秒）です。<br/>
	 * リリースタイムのデフォルト値は0.0fです。<br/></para>
	 * <para header='備考'>キュー再生時、データ側にリリースタイムが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値を<b>上書き</b>して適用されます（データ側の設定値は無視されます）。<br/></para>
	 * <para header='注意'>再生中に ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数によって
	 * 更新することはできません。<br/>
	 * <br/>
	 * HCA-MX用にエンコードされた音声データには、エンベロープが適用されません。<br/>
	 * エンベロープを使用したい音声は、ADXやHCA等、他のコーデックでエンコードしてください。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // エンベロープの設定
	 * player.SetEnvelopeReleaseTime(player, 3000.0f);
	 *
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public void SetEnvelopeReleaseTime(float time)
	{
		criAtomExPlayer_SetEnvelopeReleaseTime(this.handle, time);
	}

	/**
	 * <summary>エンベロープのサスティンレベルの設定</summary>
	 * <param name='level'>サスティンレベル（0.0f～2000.0f）</param>
	 * <remarks>
	 * <para header='説明'>エンベロープのサスティンレベルを設定します。<br/>
	 * 本関数でサスティンレベルを設定後、 ::CriAtomExPlayer::Start 関数により再生開始すると、
	 * 設定されたサスティンレベルで再生されます。<br/>
	 * <br/>
	 * サスティンレベルには、0.0f～1.0fの範囲で実数値を指定します。<br/>
	 * サスティンレベルのデフォルト値は0.0fです。<br/></para>
	 * <para header='備考'>キュー再生時、データ側にサスティンレベルが設定されている場合に本関数を呼び出すと、
	 * データ側に設定されている値を<b>上書き</b>して適用されます（データ側の設定値は無視されます）。<br/></para>
	 * <para header='注意'>再生中に ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数によって
	 * 更新することはできません。<br/>
	 * <br/>
	 * HCA-MX用にエンコードされた音声データには、エンベロープが適用されません。<br/>
	 * エンベロープを使用したい音声は、ADXやHCA等、他のコーデックでエンコードしてください。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // エンベロープの設定
	 * player.SetEnvelopeSustainLevel(0.5f);
	 *
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public void SetEnvelopeSustainLevel(float level)
	{
		criAtomExPlayer_SetEnvelopeSustainLevel(this.handle, level);
	}

	/**
	 * <summary>プレーヤにフェーダを取り付ける</summary>
	 * <remarks>
	 * <para header='説明'>プレーヤにフェーダをアタッチ（取り付け）し、
	 * CriAtomExPlayerをクロスフェード専用のプレーヤに変化させます。<br/>
	 * （複数音の同時再生等、従来のCriAtomExPlayerの持つ機能が一部利用できなくなります。）<br/>
	 * <br/>
	 * 本関数でフェーダをアタッチしたプレーヤは、以降音声再生開始毎
	 * （ ::CriAtomExPlayer::Start 関数や ::CriAtomExPlayer::Prepare 実行を実行する毎）に、
	 * 以下の制御を行います。<br/>
	 * - 既にフェードアウト中の音があれば強制停止。
	 * - 現在再生中（またはフェードイン中）の音声をフェードアウト。
	 * - 新規に再生を開始する音声をフェードイン。
	 * .
	 * <br/>
	 * また、再生停止時（ ::CriAtomExPlayer::Stop 関数実行時）には、
	 * 以下の制御を行います。<br/>
	 * - 既にフェードアウト中の音があれば強制停止。
	 * - 現在再生中（またはフェードイン中）の音声をフェードアウト。</para>
	 * <para header='備考'>フェーダをアタッチするプレーヤが音声再生中の場合、本関数を実行したタイミングで
	 * プレーヤが再生中の音声は全て停止されます。<br/>
	 * <br/>
	 * フェーダは、アタッチ中のプレーヤに対して ::CriAtomExPlayer::Start
	 * 関数や、 ::CriAtomExPlayer::Stop 関数が実行される度、
	 * 当該プレーヤで再生中の音声に対して以下の制御を行います。<br/>
	 * <br/>
	 * -# 既にフェードアウト中の音声が存在する場合、その音声を即座に停止する。
	 * -# フェードイン中の音声（または再生中の音声）が存在する場合、
	 * その音声をその時点の音量から ::CriAtomExPlayer::SetFadeOutTime
	 * 関数で指定された時間をかけてフェードアウトさせる。
	 * -# ::CriAtomExPlayer::Start 関数が実行された場合、
	 * プレーヤにセットされている音声データをボリューム0で再生開始し、
	 * ::CriAtomExPlayer::SetFadeInTime 関数で指定された時間をかけてフェードインさせる。
	 * .
	 * <br/>
	 * （ ::CriAtomExPlayer::Start 関数の代わりに ::CriAtomExPlayer::Prepare
	 * 関数を使用した場合、ポーズを解除する時点で上記の制御が行われます。）<br/></para>
	 * <para header='注意'>本関数を実行すると、CriAtomExPlayerに対する再生／停止操作が大きく変更されます。<br/>
	 * （フェーダアタッチ前後で挙動が大きく変わります。）<br/>
	 * 具体的には、同時に発音可能な音声の数が1音（クロスフェード中のみ2音）に限定され、
	 * ::CriAtomExPlayback を用いた制御も行えなくなります。<br/>
	 * <br/>
	 * 本関数は、クロスフェード処理を行いたい場合にのみ必要となります。<br/>
	 * 1音だけのフェードイン／アウトについては、エンベロープやTweenをご利用ください。<br/>
	 * <br/>
	 * フェーダの動作仕様の都合上、フェードイン／アウトの処理対象となるのは、
	 * 過去2回の音声再生のみです。<br/>
	 * それ以前に再生された音声は、 ::CriAtomExPlayer::Start 関数や
	 * ::CriAtomExPlayer::Stop 関数が実行された時点で強制的に停止されます。<br/>
	 * 強制停止処理のタイミングで意図しないノイズが発生する恐れがありますので、
	 * 同時再生数が3音以上にならないよう注意してください。<br/>
	 * <br/>
	 * フェードイン／アウトが機能するのは『AtomExプレーヤに対する操作』のみです。<br/>
	 * ::CriAtomExPlayer::Start 関数実行時に取得した再生IDに対し、
	 * ::CriAtomExPlayback::Stop を実行しても、フェードアウトは行われません。<br/>
	 * （フェーダの設定が無視され、即座に停止処理が行われます。）<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::DetachFader'/>
	 */
	public void AttachFader()
	{
		criAtomExPlayer_AttachFader(this.handle, IntPtr.Zero, IntPtr.Zero, 0);
	}

	/**
	 * <summary>プレーヤからフェーダを取り外す</summary>
	 * <remarks>
	 * <para header='説明'>プレーヤからフェーダをデタッチ（取り外し）します。<br/>
	 * 本関数でフェーダをデタッチしたプレーヤには、以降フェードイン／アウトの処理が行われなくなります。<br/></para>
	 * <para header='備考'>フェーダをデタッチするプレーヤが音声再生中の場合、本関数を実行したタイミングで
	 * プレーヤが再生中の音声は全て停止されます。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::AttachFader'/>
	 */
	public void DetachFader()
	{
		criAtomExPlayer_DetachFader(this.handle);
	}

	/**
	 * <summary>フェードアウト時間の設定</summary>
	 * <param name='ms'>フェードアウト時間（ミリ秒指定）</param>
	 * <remarks>
	 * <para header='説明'>フェーダをアタッチ済みのプレーヤに対し、フェードアウト時間を指定します。<br/>
	 * 次回音声再生時（ ::CriAtomExPlayer::Start 関数実行時）には、本関数で設定された
	 * 時間で再生中の音声がフェードアウトします。<br/>
	 * <br/>
	 * フェードアウト時間のデフォルト値は 500 ミリ秒です。<br/></para>
	 * <para header='備考'>フェードアウト時間が設定されている場合、CriAtomExPlayer は以下の順序で再生を停止します。<br/>
	 * <br/>
	 *  -# 指定された時間で音声のボリュームを 0 まで落とす。
	 *  -# ボリュームが 0 の状態でディレイ時間が経過するまで再生を続ける。
	 *  -# ディレイ時間経過後に再生を停止する。
	 *  .
	 * <br/>
	 * フェードアウト時のボリュームコントロールは、音声再生停止前に行われます。<br/>
	 * そのため、波形データにあらかじめ設定されたエンベロープのリリース時間は無視されます。<br/>
	 * （厳密には、ボリュームが 0 になってからエンベロープのリリース処理が適用されます。）<br/>
	 * <br/>
	 * 第2引数（ ms ）に 0 を指定する場合と、 -1
	 * を指定する場合とでは、以下のように挙動が異なります。<br/>
	 * <br/>
	 *  - 0 指定時：即座にボリュームが 0 に落とされ、停止処理が行われる。
	 *  - -1 指定時：ボリューム変更は行われず、停止処理が行われる。
	 *  .
	 * <br/>
	 * 再生停止時にフェードアウト処理を行わず、波形にあらかじめ設定されている
	 * エンベロープのリリース処理を有効にしたい場合、第2引数（ ms ）に、
	 * -1 を指定してください。<br/>
	 * -1 を指定することで、フェードアウト処理によるボリューム制御が行われなくなるため、
	 * ::CriAtomExPlayer::Stop 関数実行後、ディレイ時間経過後に通常の停止処理が行われます。<br/>
	 * （波形データにエンベロープのリリースが設定されている場合、リリース処理が行われます。）<br/></para>
	 * <para header='注意'>本関数を実行する前に、 ::CriAtomExPlayer::AttachFader 関数を使用して
	 * あらかじめプレーヤにフェーダをアタッチしておく必要があります。<br/>
	 * <br/>
	 * 本関数で設定した値は、既に再生中の音声には一切影響しません。<br/>
	 * 本関数で設定したフェード時間は、本関数実行後に ::CriAtomExPlayer::Start 関数や
	 * ::CriAtomExPlayer::Stop 関数を実行するタイミングで適用されます。<br/>
	 * （既にフェードアウトを開始している音声に対しては、
	 * 本関数で後からフェードアウト時間を変更することはできません。）<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::AttachFader'/>
	 * <seealso cref='CriAtomExPlayer::SetFadeInTime'/>
	 */
	public void SetFadeOutTime(int ms)
	{
		criAtomExPlayer_SetFadeOutTime(this.handle, ms);
	}

	/**
	 * <summary>フェードイン時間の設定</summary>
	 * <param name='ms'>フェードイン時間（ミリ秒指定）</param>
	 * <remarks>
	 * <para header='説明'>フェーダをアタッチ済みのプレーヤに対し、フェードイン時間を指定します。<br/>
	 * 次回音声再生時（ ::CriAtomExPlayer::Start 関数実行時）には、本関数で設定された
	 * 時間で新規に音声がフェードイン再生されます。<br/>
	 * <br/>
	 * フェードイン時間のデフォルト値は 0 秒です。<br/>
	 * そのため、本関数を使用しない場合フェードインは行われず、即座にフルボリューム
	 * で音声の再生が開始されます。<br/></para>
	 * <para header='注意'>本関数を実行する前に、 ::CriAtomExPlayer::AttachFader 関数を使用して
	 * あらかじめプレーヤにフェーダをアタッチしておく必要があります。<br/>
	 * <br/>
	 * 本関数で設定した値は、既に再生中の音声には一切影響しません。<br/>
	 * 本関数で設定したフェード時間は、本関数実行後に ::CriAtomExPlayer::Start 関数を
	 * 実行するタイミングで適用されます。<br/>
	 * （既にフェードインを開始している音声に対しては、
	 * 本関数で後からフェードイン時間を変更することはできません。）<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::AttachFader'/>
	 * <seealso cref='CriAtomExPlayer::SetFadeInTime'/>
	 */
	public void SetFadeInTime(int ms)
	{
		criAtomExPlayer_SetFadeInTime(this.handle, ms);
	}

	/**
	 * <summary>フェードイン開始オフセットの設定</summary>
	 * <param name='ms'>フェードイン開始オフセット（ミリ秒指定）</param>
	 * <remarks>
	 * <para header='説明'>フェーダをアタッチ済みのプレーヤに対し、フェードイン開始オフセットを指定します。<br/>
	 * 本関数を使用することで、フェードインを開始するタイミングをフェードアウトに対して
	 * 任意の時間早めたり、遅らせることが可能です。<br/>
	 * 例えば、フェードアウト時間を5秒、フェードイン開始オフセットを5秒に設定した場合、
	 * フェードアウトが5秒で完了した直後に次の音声をフェードインさせることが可能です。<br/>
	 * 逆に、フェードイン時間を5秒、フェードイン開始オフセットを-5秒に設定した場合、
	 * フェードインが5秒で完了した直後に再生中の音のフェードアウトを開始させることが可能です。<br/>
	 * <br/>
	 * フェードイン開始オフセットのデフォルト値は 0 秒です。<br/>
	 * （フェードインとフェードアウトが同時に開始されます。）<br/></para>
	 * <para header='備考'>フェードイン開始のタイミングは、フェードインする音声の再生準備が整ったタイミングです。<br/>
	 * そのため、フェードイン開始オフセットが 0 秒に設定されている場合でも、フェードイン音声
	 * のバッファリングに時間がかかる場合（ストリーム再生時等）には、フェードアウトの開始までに
	 * しばらく時間がかかります。<br/>
	 * （本パラメータは、フェードインとフェードアウトのタイミングを調整するための相対値です。）<br/></para>
	 * <para header='注意'>本関数を実行する前に、 ::CriAtomExPlayer::AttachFader 関数を使用して
	 * あらかじめプレーヤにフェーダをアタッチしておく必要があります。<br/>
	 * <br/>
	 * 本関数で設定した値は、既に再生中の音声には一切影響しません。<br/>
	 * 本関数で設定したフェード時間は、本関数実行後に ::CriAtomExPlayer::Start 関数や
	 * ::CriAtomExPlayer::Stop 関数を実行するタイミングで適用されます。<br/>
	 * （既にフェード処理を開始している音声に対しては、
	 * 本関数で後からフェード処理のタイミングを変更することはできません。）<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::AttachFader'/>
	 * <seealso cref='CriAtomExPlayer::SetFadeInTime'/>
	 */
	public void SetFadeInStartOffset(int ms)
	{
		criAtomExPlayer_SetFadeInStartOffset(this.handle, ms);
	}

	/**
	 * <summary>フェードアウト後のディレイ時間の設定</summary>
	 * <param name='ms'>フェードアウト後のディレイ時間（ミリ秒指定）</param>
	 * <remarks>
	 * <para header='説明'>フェードアウト完了後、ボイスを破棄するまでのディレイ時間を設定します。<br/>
	 * 本関数を使用することで、フェードアウトを終えたボイスが破棄されるまでのタイミングを任意に設定可能です。<br/>
	 * <br/>
	 * ディレイ時間のデフォルト値は 500 ミリ秒です。<br/>
	 * （フェードアウト音を再生するボイスは、ボリュームが 0 に設定された後、 500 ミリ秒後に破棄されます。）<br/></para>
	 * <para header='備考'>音声のフェードアウトが完了する前にボイスが停止されるプラットフォーム以外は、
	 * 本関数を使用する必要はありません。<br/></para>
	 * <para header='注意'>本関数を実行する前に、 ::CriAtomExPlayer::AttachFader 関数を使用して
	 * あらかじめプレーヤにフェーダをアタッチしておく必要があります。<br/>
	 * <br/>
	 * 本関数で設定した値は、既に再生中の音声には一切影響しません。<br/>
	 * 本関数で設定したフェード時間は、本関数実行後に ::CriAtomExPlayer::Start 関数や
	 * ::CriAtomExPlayer::Stop 関数を実行するタイミングで適用されます。<br/>
	 * （既にフェードアウトを開始している音声に対しては、
	 * 本関数で後からフェードアウト後のディレイ時間を変更することはできません。）<br/>
	 * <br/>
	 * ボリュームの制御とボイスの停止が反映されるタイミングは、プラットフォームによって異なります。<br/>
	 * そのため、本関数に 0 を指定した場合、プラットフォームによってはボリュームの変更が反映される
	 * 前にボイスが停止される恐れがあります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::AttachFader'/>
	 */
	public void SetFadeOutEndDelay(int ms)
	{
		criAtomExPlayer_SetFadeOutEndDelay(this.handle, ms);
	}

	/**
	 * <summary>フェード処理中かどうかを取得</summary>
	 * <returns>フェード処理中かどうか</returns>
	 * <remarks>
	 * <para header='説明'>フェード処理が行われている最中かどうかを取得します。<br/></para>
	 * <para header='備考'>本関数は、以下の処理期間中 true を返します。<br/>
	 * - クロスフェード開始のための同期待ち中。
	 * - フェードイン／フェードアウト処理中（ボリューム変更中）。
	 * - フェードアウト完了後のディレイ期間中。</para>
	 * </remarks>
	 */
	public bool IsFading()
	{
		return criAtomExPlayer_IsFading(this.handle);
	}

	/**
	 * <summary>フェーダパラメータの初期化</summary>
	 * <remarks>
	 * <para header='説明'>フェーダに設定されている各種パラメータをクリアし、初期値に戻します。<br/></para>
	 * <para header='注意'>本関数を実行する前に、 CriAtomExPlayer::AttachFader 関数を使用して
	 * あらかじめプレーヤにフェーダをアタッチしておく必要があります。<br/>
	 * <br/>
	 * 本関数でフェーダパラメータをクリアしても、既に再生中の音声には一切影響しません。<br/>
	 * 本関数でクリアしたフェーダパラメータは、本関数実行後に CriAtomExPlayer::Start 関数や
	 * CriAtomExPlayer::Stop 関数を実行するタイミングで適用されます。<br/>
	 * （既にフェード処理を開始している音声に対しては、
	 * 本関数でクリアしたフェーダパラメータを適用することはできません。）<br/></para>
	 * </remarks>
	 */
	public void ResetFaderParameters()
	{
		criAtomExPlayer_ResetFaderParameters(this.handle);
	}

	/**
	 * <summary>グループ番号の指定</summary>
	 * <remarks>
	 * <para header='説明'>発音時にボイスをどのボイスリミットグループから取得するかを指定します。<br/>
	 * <br/>
	 * group_no に -1 を指定した場合、プレーヤはボイスリミットグループによる制限を受けなくなります。<br/>
	 * （空きボイスがあるか、または自身より低プライオリティのボイスがあれば、<br/>
	 * ボイスリミットグループに関係なくボイスを取得します。）<br/></para>
	 * <para header='注意'>再生を開始し、指定したボイスリミットグループのボイスが全て使用中だった場合、
	 * 再生した音声が発音されるかどうかは、ボイスプライオリティ制御によって決まります。<br/>
	 * （ボイスプライオリティによる発音制御の詳細は ::CriAtomExPlayer::SetVoicePriority
	 * 関数の説明をご参照ください。）<br/>
	 * <br/>
	 * キュー再生時に本関数を呼び出すと、データ側に設定されているボイスリミットグループ設定を<br/>
	 * 上書きします（データ側の設定値は無視されます）。<br/>
	 * ただし、group_no に -1 を指定した場合はデータ側に設定されているボイスリミットグループを参照します。<br/>
	 * <br/></para>
	 * </remarks>
	 */
	public void SetGroupNumber(int group_no)
	{
		criAtomExPlayer_SetGroupNumber(this.handle, group_no);
	}

	/**
	 * <summary>再生パラメータの更新（CriAtomExPlaybackオブジェクト単位）</summary>
	 * <param name='playback'>CriAtomExPlaybackオブジェクト</param>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤに設定されている再生パラメータ（AISACコントロール値を含む）を使用して、
	 * CriAtomExPlaybackオブジェクトのパラメータを更新します。<br/></para>
	 * <para header='注意'>パラメータ更新に仕様するCriAtomExPlayerオブジェクトは、
	 * CriAtomExPlaybackオブジェクトを生成したプレーヤでなければなりません。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // ボリュームの変更
	 * // 注意）この時点では再生中の音声のパラメータは変更されない。
	 * player.SetVolume(volume);
	 *
	 * // プレーヤに設定されたパラメータを再生中の音声にも反映
	 * player.Update(playback);
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::UpdateAll'/>
	 */
	public void Update(CriAtomExPlayback playback)
	{
		criAtomExPlayer_Update(this.handle, playback.id);
	}

	/**
	 * <summary>再生パラメータの更新（再生中の音全て）</summary>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤに設定されている再生パラメータ（AISACコントロール値を含む）を使用して、
	 * このAtomExプレーヤで再生中の音全ての再生パラメータを更新します。<br/></para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // 再生の開始
	 * CriAtomExPlayback playback = player.Start();
	 *  ：
	 * // ボリュームの変更
	 * // 注意）この時点では再生中の音声のパラメータは変更されない。
	 * player.SetVolume(volume);
	 *
	 * // プレーヤに設定されたパラメータを再生中の全ての音声に反映
	 * player.UpdateAll();
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomExPlayer::Update'/>
	 */
	public void UpdateAll()
	{
		criAtomExPlayer_UpdateAll(this.handle);
	}

	/**
	 * <summary>再生パラメータの初期化</summary>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤに設定されている再生パラメータ（AISACコントロール値を含む）をリセットし、
	 * 初期状態（未設定状態）に戻します。<br/>
	 * 本関数呼び出し後、 ::CriAtomExPlayer::Start 関数により再生開始すると、初期状態の再生パラメータで再生されます。<br/></para>
	 * <para header='備考'>本関数呼び出し後、 ::CriAtomExPlayer::Update 関数、 ::CriAtomExPlayer::UpdateAll 関数を呼び出したとしても、
	 * すでに再生されている音声のパラメータは初期値には戻りません。<br/>
	 * すでに再生されている音声のパラメータを変える場合は、
	 * 明示的に ::CriAtomExPlayer::SetVolume 関数等を呼び出してください。<br/>
	 * <br/>
	 * 本関数でリセットされるパラメータは、以下のパラメータです。<br/>
	 * - ::CriAtomEx::Parameter に定義されているパラメータ
	 * - AISACコントロール値（ ::CriAtomExPlayer::SetAisacControl 関数で設定）
	 * - キュープライオリティ（ ::CriAtomExPlayer::SetCuePriority 関数で設定）
	 * - 3D音源ハンドル（ ::CriAtomExPlayer::Set3dSource 関数で設定）
	 * - 3Dリスナーハンドル（ ::CriAtomExPlayer::Set3dListener 関数で設定）
	 * - カテゴリ設定（ ::CriAtomExPlayer::SetCategory 関数で設定）
	 * - 再生開始ブロック（ ::CriAtomExPlayer::SetFirstBlockIndex 関数で設定）
	 * .
	 * なお、本関数では3D音源ハンドルや3Dリスナーハンドル自体のもつパラメータ（位置等）はリセットされません。
	 * 「AtomExプレーヤに設定されているハンドルが何か」という設定だけがリセットされます。
	 * これらのハンドル自体のパラメータをリセットしたい場合には、
	 * それぞれのハンドルのパラメータリセット関数を呼び出してください。</para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // ボリュームの変更
	 * player.SetVolume(0.5f);
	 *
	 * // 音声を再生
	 * // 備考）ここで再生された音声は0.5fのボリュームで出力される。
	 * CriAtomExPlayback playback1 = player.Start();
	 *
	 * // プレーヤに設定されたパラメータをリセット
	 * // 備考）プレーヤのボリューム設定がデフォルト値（1.0f）に戻される。
	 * player.ResetParameters();
	 *
	 * // 別の音を再生
	 * // 備考）ここで再生された音声は1.0fのボリュームで出力される。
	 * CriAtomExPlayback playback2 = player.Start();
	 *  ：
	 * </code></example>
	 * <seealso cref='CriAtomEx3dSource::ResetParameters'/>
	 * <seealso cref='CriAtomEx3dListener::ResetParameters'/>
	 */
	public void ResetParameters()
	{
		criAtomExPlayer_ResetParameters(this.handle);
	}

	/**
	 * <summary>再生時刻の取得</summary>
	 * <returns>再生時刻（ミリ秒単位）</returns>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤで最後に再生した音声の、再生時刻を取得します。<br/>
	 * <br/>
	 * 再生時刻が取得できた場合、本関数は 0 以上の値を返します。<br/>
	 * 再生時刻が取得できない場合（ボイスの取得に失敗した場合等）、本関数は負値を返します。<br/></para>
	 * <para header='備考'>同一プレーヤで複数の音声を再生し、本関数を実行した場合、本関数は
	 * "最後に"再生した音声の時刻を返します。<br/>
	 * 複数の音声に対して再生時刻をチェックする必要がある場合には、
	 * 再生する音声の数分だけプレーヤを作成するか、または
	 * ::CriAtomExPlayback::GetTime 関数をご利用ください。<br/>
	 * <br/>
	 * 本関数が返す再生時刻は「再生開始後からの経過時間」です。<br/>
	 * ループ再生時や、シームレス連結再生時を行った場合でも、
	 * 再生位置に応じて時刻が巻き戻ることはありません。<br/>
	 * <br/>
	 * ::CriAtomExPlayer::Pause 関数でポーズをかけた場合、
	 * 再生時刻のカウントアップも停止します。<br/>
	 * （ポーズを解除すれば再度カウントアップが再開されます。）
	 * <br/>
	 * 本関数で取得可能な時刻の精度は、サーバ処理の周波数に依存します。<br/>
	 * （時刻の更新はサーバ処理単位で行われます。）<br/>
	 * より精度の高い時刻を取得する必要がある場合には、本関数の代わりに
	 * ::CriAtomExPlayback::GetNumPlayedSamples 関数を使用し、
	 * 再生済みサンプル数を取得してください。<br/></para>
	 * <para header='注意'>戻り値の型はlongですが、現状、32bit以上の精度はありません。<br/>
	 * 再生時刻を元に制御を行う場合、約24日で再生時刻が異常になる点に注意が必要です。<br/>
	 * （ 2147483647 ミリ秒を超えた時点で、再生時刻がオーバーフローし、負値になります。）<br/>
	 * <br/>
	 * 再生中の音声が発音数制御によって消去された場合、
	 * 再生時刻のカウントアップもその時点で停止します。<br/>
	 * また、再生開始時点で発音数制御によりボイスが割り当てられなかった場合、
	 * 本関数は正しい時刻を返しません。<br/>
	 * （負値が返ります。）<br/>
	 * <br/>
	 * ドライブでリードリトライ処理等が発生し、一時的に音声データの供給が途切れた場合でも、
	 * 再生時刻のカウントアップが途切れることはありません。<br/>
	 * （データ供給停止により再生が停止した場合でも、時刻は進み続けます。）<br/>
	 * そのため、本関数で取得した時刻を元に映像との同期を行った場合、
	 * リードリトライ発生毎に同期が大きくズレる可能性があります。<br/>
	 * 波形データと映像の同期を厳密に取る必要がある場合は、本関数の代わりに
	 * ::CriAtomExPlayback::GetNumPlayedSamples 関数を使用し、
	 * 再生済みサンプル数との同期を取ってください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayback::GetTime'/>
	 * <seealso cref='CriAtomExPlayback::GetNumPlayedSamples'/>
	 */
	public long GetTime()
	{
		return criAtomExPlayer_GetTime(this.handle);
	}

	/**
	 * <summary>ステータスの取得</summary>
	 * <returns>ステータス</returns>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤのステータスを取得します。<br/>
	 * ステータスはAtomExプレーヤの再生状態を示す ::CriAtomExPlayer::Status 型の値で、
	 * 以下の5通りの値が存在します。<br/>
	 * -# Stop
	 * -# Prep
	 * -# Playing
	 * -# PlayEnd
	 * -# Error
	 * .
	 * AtomExプレーヤを作成した時点では、AtomExプレーヤのステータスは停止状態（ Stop ）です。<br/>
	 * 再生する音声データをセット後、 ::CriAtomExPlayer::Start 関数を実行することで、
	 * AtomExプレーヤのステータスが準備状態（ Prep ）に変更されます。<br/>
	 * （ Prep は、データ供給やデコードの開始を待っている状態です。）<br/>
	 * 再生の開始に充分なデータが供給された時点で、AtomExプレーヤはステータスを
	 * 再生状態（ Playing ）に変更し、音声の出力を開始します。<br/>
	 * セットされたデータを全て再生し終えると、AtomExプレーヤはステータスを再生終了状態
	 * （ PlayEnd ）に変更します。<br/>
	 * 尚、再生中にエラーが発生した場合には、AtomExプレーヤはステータスをエラー状態
	 * （ Error ）に変更します。<br/>
	 * <br/>
	 * AtomExプレーヤのステータスをチェックし、ステータスに応じて処理を切り替えることで、
	 * 音声の再生状態に連動したプログラムを作成することが可能です。<br/>
	 * 例えば、音声の再生完了を待って処理を進めたい場合には、以下のようなコードになります。<code>
	 *  ：
	 * // プレーヤの作成
	 * CriAtomExPlayer player = new CriAtomExPlayer();
	 *  ：
	 * // 音声データをセット
	 * player.SetCue(acb, cueId);
	 *
	 * // セットされた音声データを再生
	 * player.Start();
	 *
	 * // 再生完了待ち
	 * while (player.GetStatus() != CriAtomExPlayer.Status.PlayEnd) {
	 *  yield return null;
	 * }
	 *  :
	 * </code>
	 * </para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public Status GetStatus()
	{
		return criAtomExPlayer_GetStatus(this.handle);
	}

	/**
	 * <summary>パラメータの取得（浮動小数点数）</summary>
	 * <param name='id'>パラメータID</param>
	 * <returns>パラメータ設定値</returns>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤに設定されている各種パラメータの値を取得します。<br/>
	 * 値は浮動小数点数で取得されます。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx.Parameter'/>
	 * <seealso cref='CriAtomExPlayer::GetParameterUint32'/>
	 * <seealso cref='CriAtomExPlayer::GetParameterSint32'/>
	 */
	public float GetParameterFloat32(CriAtomEx.Parameter id)
	{
		return criAtomExPlayer_GetParameterFloat32(this.handle, id);
	}

	/**
	 * <summary>パラメータの取得（符号なし整数）</summary>
	 * <param name='id'>パラメータID</param>
	 * <returns>パラメータ設定値</returns>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤに設定されている各種パラメータの値を取得します。<br/>
	 * 値は符号なし整数で取得されます。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx.Parameter'/>
	 * <seealso cref='CriAtomExPlayer::GetParameterFloat32'/>
	 * <seealso cref='CriAtomExPlayer::GetParameterSint32'/>
	 */
	public uint GetParameterUint32(CriAtomEx.Parameter id)
	{
		return criAtomExPlayer_GetParameterUint32(this.handle, id);
	}

	/**
	 * <summary>パラメータの取得（符号付き整数）</summary>
	 * <param name='id'>パラメータID</param>
	 * <returns>パラメータ設定値</returns>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤに設定されている各種パラメータの値を取得します。<br/>
	 * 値は符号付き整数で取得されます。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx.Parameter'/>
	 * <seealso cref='CriAtomExPlayer::GetParameterFloat32'/>
	 * <seealso cref='CriAtomExPlayer::GetParameterUint32'/>
	 */
	public int GetParameterSint32(CriAtomEx.Parameter id)
	{
		return criAtomExPlayer_GetParameterSint32(this.handle, id);
	}

	/**
	 * <summary>出力サウンドレンダラタイプの設定</summary>
	 * <param name='type'>出力先のサウンドレンダラタイプ</param>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤの再生に使用するサウンドレンダラの種別を設定します。<br/>
	 * 本設定を行ってから再生を開始すると、設定されたサウンドレンダラタイプで作成されたボイス
	 * プールから再生可能なボイスを取得します。<br/>
	 * サウンドレンダラタイプの設定はキューの再生単位で設定可能です。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomEx.SoundRendererType'/>
	 */
	public void SetSoundRendererType(CriAtomEx.SoundRendererType type)
	{
		criAtomExPlayer_SetSoundRendererType(this.handle, type);
	}

	/**
	 * <summary>乱数種の設定</summary>
	 * <param name='seed'>乱数種</param>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤが保持する疑似乱数生成器に乱数種を設定します。<br/>
	 * 乱数種を設定することにより、各種ランダム再生処理に再現性を持たせることができます。<br/>
	 * <br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomEx.SetRandomSeed'/>
	 */
	public void SetRandomSeed(uint seed)
	{
		criAtomExPlayer_SetRandomSeed(this.handle, seed);
	}

	/**
	 * <summary>ループ再生の切り替え</summary>
	 * <param name='sw'>ループスイッチ（true: ループモード、false: ループモード解除）</param>
	 * <remarks>
	 * <para header='説明'>ループポイントを持たない波形データに対し、ループ再生のON/OFFを切り替えます。<br/>
	 * デフォルトはループOFFです。<br/>
	 * ループ再生をONにした場合は、音声終端まで再生しても再生は終了せず先頭に戻って再生を繰り返します。<br/></para>
	 * <para header='注意'>本関数の設定は波形データに対して適用されます。<br/>
	 * シーケンスデータに対して本関数を実行した場合、
	 * シーケンスデータ内の個々の波形データがループ再生される形になります。<br/>
	 * <br/>
	 * 本関数による指定は、ループポイントを持たない波形データに対してのみ有効です。<br/>
	 * ループポイントを持つ波形データを再生する場合、本関数の指定に関係なく、
	 * 波形データのループ位置に従ってループ再生が行われます。<br/>
	 * <br/>
	 * 本関数は内部的にシームレス連結再生機能を使用します。<br/>
	 * そのため、シームレス連結再生に未対応のフォーマット（HCA-MX等）を使用した場合、
	 * ループ位置にある程度の無音が入る形になります。<br/>
	 * <br/>
	 * ループスイッチの変更は、再生開始前にのみ可能です。<br/>
	 * 再生中のプレーヤに対してループスイッチを変更することはできません。<br/></para>
	 * </remarks>
	 */
	public void Loop(bool sw)
	{
		if (sw)
		{
			/*(-1) JP<ループ回数制限なし   */
			/*(-2) JP<ループ情報を無視      */
			/*(-3) JP<強制ループ再生     */
			criAtomExPlayer_LimitLoopCount(this.handle, -3);
		}else
		{
			ushort CRIATOMPARAMETER2_ID_LOOP_COUNT = CriAtomPlugin.GetLoopCountParameterId();
			IntPtr player_parameter = criAtomExPlayer_GetPlayerParameter(this.handle);
			criAtomExPlayerParameter_RemoveParameter(player_parameter, CRIATOMPARAMETER2_ID_LOOP_COUNT);
		}
	}

	/**
	 * <summary>ASRラックIDの指定</summary>
	 * <param name='asr_rack_id'>ASRラックID</param>
	 * <remarks>
	 * <para header='説明'>ボイスの出力先ASRラックIDを指定します。<br/></para>
	 * <para header='注意'>本関数は ボイスのサウンドレンダラタイプにASRを使用する場合にのみ効果があります。<br/>
	 * （他のボイスを使用する場合、本関数の設定値は無視されます。）<br/>
	 * <br/>
	 * ASRラックIDは再生開始前に設定する必要があります。<br/>
	 * 既に再生が開始された音声に対し、後からASRラックIDを変更することはできません。<br/>
	 * <br/>
	 * HCA-MX用にエンコードされた音声データには、本関数の設定が適用されません。<br/></para>
	 * </remarks>
	 */
	public void SetAsrRackId(int asr_rack_id)
	{
		criAtomExPlayer_SetAsrRackId(this.handle, asr_rack_id);
	}

	/**
	 * <summary>ボイスプール識別子の設定</summary>
	 * <param name='identifier'>ボイスプール識別子</param>
	 * <remarks>
	 * <para header='説明'>発音時にボイスをどのボイスプールから取得するかを指定します。<br/>
	 * 本関数を実行すると、プレーヤは以降指定されたボイスプール識別子に一致するボイスプールからのみ
	 * ボイスを取得します。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExStandardVoicePool'/>
	 * <seealso cref='CriAtomExWaveVoicePool'/>
	 */
	public void SetVoicePoolIdentifier(uint identifier)
	{
		criAtomExPlayer_SetVoicePoolIdentifier(this.handle, identifier);
	}

	/**
	 * <summary>DSPタイムストレッチ比率の設定</summary>
	 * <param name='ratio'>ストレッチ比率</param>
	 * <remarks>
	 * <para header='説明'>DSPタイムストレッチの再生時間の倍率を設定します。<br/>
	 * 元データの再生時刻に ratio を掛けた値がストレッチ結果の再生時間となります。<br/>
	 * 設定可能な値の範囲は 0.5f ～ 2.0f までです。</para>
	 * <para header='注意'>設定する値は再生速度ではなく「再生時間」に対する倍率です。<br/>
	 * ストレッチの割合を再生速度で指定する場合、再生速度の倍率の逆数を設定してください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExVoicePool.AttachDspTimeStretch'/>
	 * <seealso cref='CriAtomExPlayer.SetVoicePoolIdentifier'/>
	 */
	public void SetDspTimeStretchRatio(float ratio)
	{
		SetDspParameter((int)TimeStretchParameterId.Ratio, ratio);
	}

	/**
	 * <summary>DSPピッチシフタのピッチシフト量の設定</summary>
	 * <param name='pitch'>ピッチシフト量</param>
	 * <remarks>
	 * <para header='説明'>DSPピッチシフタのピッチシフト量を設定します。<br/>
	 * 単位はセントです。<br/>
	 * 設定可能な値の範囲は -2400 ～ 2400 までです。<br/>
	 * 原音と比べて 1200 で 2倍、-1200 で 1/2倍 のピッチシフトになります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExVoicePool.AttachDspPitchShifter'/>
	 * <seealso cref='CriAtomExPlayer.SetVoicePoolIdentifier'/>
	 */
	public void SetDspPitchShifterPitch(float pitch)
	{
		float value = pitch / 4800.0f + 0.5f;
		SetDspParameter((int)PitchShifterParameterId.Pitch, value);
	}

	/**
	 * <summary>DSPパラメータの設定</summary>
	 * <param name='id'>パラメータID</param>
	 * <param name='value'>パラメータ値</param>
	 * <remarks>
	 * <para header='説明'>ボイスにアタッチしているDSPのパラメータを設定します。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExVoicePool.AttachDspTimeStretch'/>
	 * <seealso cref='CriAtomExVoicePool.AttachDspPitchShifter'/>
	 * <seealso cref='SetVoicePoolIdentifier'/>
	 */
	public void SetDspParameter(int id, float value)
	{
		criAtomExPlayer_SetDspParameter(this.handle, id, value);
	}

	public void SetSequencePrepareTime(uint ms)
	{
		criAtomExPlayer_SetSequencePrepareTime(this.handle, ms);
	}

	/**
	 * <summary>タイムストレッチ用パラメータ</summary>
	 * <remarks>
	 * <para header='説明'>タイムストレッチDSPに指定するパラメータです。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExVoicePool.AttachDspTimeStretch'/>
	 * <seealso cref='CriAtomExPlayer.SetDspParameter'/>
	 */
	public enum TimeStretchParameterId : int {
		Ratio       = 0,        /**< ストレッチ比率 */
		FrameTime   = 1,        /**< フレーム時間 */
		Quality     = 2         /**< 処理品質 */
	}

	/**
	 * <summary>ピッチシフタ用パラメータ</summary>
	 * <remarks>
	 * <para header='説明'>ピッチシフタDSPに指定するパラメータです。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExVoicePool.AttachDspPitchShifter'/>
	 * <seealso cref='CriAtomExPlayer.SetDspParameter'/>
	 */
	public enum PitchShifterParameterId : int {
		Pitch       = 0,        /**< ピッチ */
		Formant     = 1,        /**< フォルマント */
		Mode        = 2         /**< ピッチシフトモード */
	}

    /**
     * <summary>AtomExTweenの取り付け</summary>
     * <remarks>
     * <para header='説明'>プレイヤーにAtomExTweenを取り付けることで簡単なパラメータアニメーションが可能です。<br/>
	 * アタッチ前に再生が始まっていた音声に対してAtomExTweenのアニメーションを適用する場合は、<br/>
	 * CriAtomExPlayer.Update または CriAtomExPlayer.UpdateAll を呼ぶ必要があります。</para>
     * </remarks>
     * <param name='tween'>AtomExTweenオブジェクト</param>
     * <seealso cref='CriAtomExTween'/>
     */
    public void AttachTween(CriAtomExTween tween)
    {
        criAtomExPlayer_AttachTween(this.handle, tween.nativeHandle);
    }

    /**
     * <summary>AtomExTweenの取り外し</summary>
     * <param name='tween'>AtomExTweenオブジェクト</param>
     * <seealso cref='CriAtomExTween'/>
     */
    public void DetachTween(CriAtomExTween tween)
    {
        criAtomExPlayer_DetachTween(this.handle, tween.nativeHandle);
    }

    /**
     * <summary>全てのAtomExTweenの取り外し</summary>
     * <seealso cref='CriAtomExTween'/>
     */
    public void DetachTweenAll()
    {
        criAtomExPlayer_DetachTweenAll(this.handle);
    }

    /* Old APIs */
    public void Stop() {
		if (this.isAvailable) {
			criAtomExPlayer_Stop(this.handle);
			criAtomUnityEntryPool_Clear(this.entryPoolHandle);
		}
	}
	public void StopWithoutReleaseTime() {
		if (this.isAvailable) {
			criAtomExPlayer_StopWithoutReleaseTime(this.handle);
			criAtomUnityEntryPool_Clear(this.entryPoolHandle);
		}
	}
	public void Pause(bool sw) { criAtomExPlayer_Pause(this.handle, sw); }

	#region Internal Members

	~CriAtomExPlayer()
	{
		this.Dispose();
	}

	private IntPtr handle = IntPtr.Zero;

	private void OnBeatSyncCallbackChainInternal(ref CriAtomExBeatSync.Info info)
	{
		if (info.playerHn != this.nativeHandle) {
			return;
		}
		_onBeatSyncCallback(ref info);
	}

	private void OnSequenceCallbackChainInternal(ref CriAtomExSequencer.CriAtomExSequenceEventInfo info)
	{
		if (info.playerHn != this.nativeHandle) {
			return;
		}
		_onSequenceCallback(ref info);
	}

	#endregion

	#region DLL Import
	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomExPlayer_Create(ref Config config, IntPtr work, int work_size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_Destroy(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetCueId(
		IntPtr player, IntPtr acb_hn, int id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetCueName(
		IntPtr player, IntPtr acb_hn, string cue_name);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetCueIndex(
		IntPtr player, IntPtr acb_hn, int index);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetFile(
		IntPtr player, IntPtr binder, string path);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetData(
		IntPtr player, byte[] buffer, int size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetData(
		IntPtr player, IntPtr buffer, int size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetContentId(
		IntPtr player, IntPtr binder, int id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetVoicePoolIdentifier(
		IntPtr player, uint identifier);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern uint criAtomExPlayer_Start(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern uint criAtomExPlayer_Prepare(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_Stop(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_StopWithoutReleaseTime(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_Pause(IntPtr player, bool sw);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_Resume(IntPtr player, CriAtomEx.ResumeMode mode);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExPlayer_IsPaused(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern Status criAtomExPlayer_GetStatus(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern long criAtomExPlayer_GetTime(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetFormat(IntPtr player, CriAtomEx.Format format);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetNumChannels(IntPtr player, int num_channels);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetSamplingRate(IntPtr player, int sampling_rate);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomUnityEntryPool_Create(IntPtr player, int capacity, int max_path, bool stopOnEmpty);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomUnityEntryPool_Destroy(IntPtr pool);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomUnityEntryPool_GetNumEntries(IntPtr pool);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomUnityEntryPool_EntryFile(IntPtr pool, IntPtr binder, string path, bool repeat, int max_path);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomUnityEntryPool_EntryContentId(IntPtr pool,  IntPtr binder, int id, bool repeat);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomUnityEntryPool_EntryData(IntPtr pool, byte[] buffer, int size, bool repeat);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomUnityEntryPool_EntryData(IntPtr pool, IntPtr buffer, int size, bool repeat);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomUnityEntryPool_EntryCue(IntPtr pool, IntPtr acbhn, string name, bool repeat);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomUnityEntryPool_Clear(IntPtr pool);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetStartTime(
		IntPtr player, long start_time_ms);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetSequencePrepareTime(
		IntPtr player, uint seq_prep_time_ms);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_LimitLoopCount(IntPtr player, int count);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_Update(IntPtr player, uint id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_UpdateAll(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_ResetParameters(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern float criAtomExPlayer_GetParameterFloat32(IntPtr player, CriAtomEx.Parameter id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern uint criAtomExPlayer_GetParameterUint32(IntPtr player, CriAtomEx.Parameter id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomExPlayer_GetParameterSint32(IntPtr player, CriAtomEx.Parameter id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomExPlayer_GetPlayerParameter(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayerParameter_RemoveParameter(IntPtr player_parameter, System.UInt16 id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetVolume(IntPtr player, float volume);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetPitch(IntPtr player, float pitch);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetPlaybackRatio(IntPtr player, float playback_ratio);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetPan3dAngle(IntPtr player, float pan3d_angle);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetPan3dInteriorDistance(
		IntPtr player, float pan3d_interior_distance);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetPan3dVolume(IntPtr player, float pan3d_volume);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetPanType(IntPtr player, CriAtomEx.PanType panType);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetSendLevel(IntPtr player, int channel, CriAtomEx.Speaker id, float level);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetBusSendLevel(
		IntPtr player, int bus_id, float level);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetBusSendLevelByName(
		IntPtr player, string bus_name, float level);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExPlayer_GetBusSendLevelByName(
		IntPtr player, string bus_name, out float level);
	
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetBusSendLevelOffset(
		IntPtr player, int bus_id, float level_offset);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetBusSendLevelOffsetByName(
		IntPtr player, string bus_name, float level_offset);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExPlayer_GetBusSendLevelOffsetByName(
		IntPtr player, string bus_name, out float level_offset);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetBandpassFilterParameters(
		IntPtr player, float cof_low, float cof_high);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetBiquadFilterParameters(
		IntPtr player, CriAtomEx.BiquadFilterType type, float frequency, float gain, float q);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetVoicePriority(
		IntPtr player, int priority);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetVoiceControlMethod(
		IntPtr player, CriAtomEx.VoiceControlMethod method);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetAisacControlById(
		IntPtr player, ushort control_id, float control_value);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetAisacControlByName(
		IntPtr player, string control_name, float control_value);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_Set3dSourceHn(
		IntPtr player, IntPtr source);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_Set3dListenerHn(
		IntPtr player, IntPtr listener);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetCategoryById(
		IntPtr player, uint category_id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetCategoryByName(
		IntPtr player, string category_name);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_UnsetCategory(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetCuePriority(
		IntPtr player, int cue_priority);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetPreDelayTime(
		IntPtr player, float predelay_time_ms);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetEnvelopeAttackTime(
		IntPtr player, float attack_time_ms);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetEnvelopeHoldTime(
		IntPtr player, float hold_time_ms);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetEnvelopeDecayTime(
		IntPtr player, float decay_time_ms);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetEnvelopeReleaseTime(
		IntPtr player, float release_time_ms);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetEnvelopeSustainLevel(
		IntPtr player, float susutain_level);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_AttachFader(
		IntPtr player, IntPtr config, IntPtr work, int work_size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_AttachAisac(
		IntPtr player, string globalAisacName);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_DetachAisac(
		IntPtr player, string globalAisacName);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_DetachFader(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetFadeOutTime(IntPtr player, int ms);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetFadeInTime(IntPtr player, int ms );

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetFadeInStartOffset(IntPtr player, int ms);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetFadeOutEndDelay(IntPtr player, int ms);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExPlayer_IsFading(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_ResetFaderParameters(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetGroupNumber(IntPtr player, int group_no);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExPlayer_GetAttachedAisacInfo(
		IntPtr player, int aisac_attached_index, IntPtr aisac_info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetFirstBlockIndex(IntPtr player, int index);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetSelectorLabel(IntPtr player, string selector, string label);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_UnsetSelectorLabel(IntPtr player, string selector, string label);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_ClearSelectorLabels(IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetSoundRendererType(IntPtr player, CriAtomEx.SoundRendererType type);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetRandomSeed(IntPtr player, uint seed);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_Loop(IntPtr player, bool sw);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetAsrRackId(IntPtr player, int asr_rack_id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayer_SetDspParameter(IntPtr player, int id, float value);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern void criAtomExPlayer_AttachTween(IntPtr player, IntPtr tween);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern void criAtomExPlayer_DetachTween(IntPtr player, IntPtr tween);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern void criAtomExPlayer_DetachTweenAll(IntPtr player);
#else
	private Status _dummyStatus = Status.Stop;
	private bool _dummyPaused = false;
	private bool _dummyLoop = false;
	private static IntPtr criAtomExPlayer_Create(ref Config config, IntPtr work, int work_size) { return IntPtr.Zero; }
	private static void criAtomExPlayer_Destroy(IntPtr player) { }
	private static void criAtomExPlayer_SetCueId(IntPtr player, IntPtr acb_hn, int id) { }
	private static void criAtomExPlayer_SetCueName(IntPtr player, IntPtr acb_hn, string cue_name) { }
	private static void criAtomExPlayer_SetCueIndex(IntPtr player, IntPtr acb_hn, int index) { }
	private static void criAtomExPlayer_SetFile(IntPtr player, IntPtr binder, string path) { }
	private static void criAtomExPlayer_SetData(IntPtr player, byte[] buffer, int size) { }
	private static void criAtomExPlayer_SetData(IntPtr player, IntPtr buffer, int size) { }
	private static void criAtomExPlayer_SetContentId(IntPtr player, IntPtr binder, int id) { }
	private static void criAtomExPlayer_SetVoicePoolIdentifier(IntPtr player, uint identifier) { }
	private uint criAtomExPlayer_Start(IntPtr player) { _dummyStatus = Status.Prep; _dummyPaused = false; return 0u; }
	private uint criAtomExPlayer_Prepare(IntPtr player) { _dummyStatus = Status.Prep; return 0u; }
	private void criAtomExPlayer_Stop(IntPtr player) { _dummyStatus = Status.Stop; }
	private void criAtomExPlayer_StopWithoutReleaseTime(IntPtr player) { _dummyStatus = Status.Stop; }
	private void criAtomExPlayer_Pause(IntPtr player, bool sw) { _dummyPaused = false; }
	private static void criAtomExPlayer_Resume(IntPtr player, CriAtomEx.ResumeMode mode) { }
	private bool criAtomExPlayer_IsPaused(IntPtr player) { return _dummyPaused; }
	private Status criAtomExPlayer_GetStatus(IntPtr player) {
		Status ret = _dummyStatus;
		if (!_dummyPaused && _dummyStatus != Status.PlayEnd && _dummyStatus != Status.Stop) {
			_dummyStatus = _dummyStatus == Status.Prep ? Status.Playing :
							!(_dummyPaused || _dummyLoop) ? Status.PlayEnd : Status.Playing;
		}
		return ret;
	}
	private static long criAtomExPlayer_GetTime(IntPtr player) { return 0; }
	private static void criAtomExPlayer_SetFormat(IntPtr player, CriAtomEx.Format format) { }
	private static void criAtomExPlayer_SetNumChannels(IntPtr player, int num_channels) { }
	private static void criAtomExPlayer_SetSamplingRate(IntPtr player, int sampling_rate) { }
	private static IntPtr criAtomUnityEntryPool_Create(IntPtr player, int capacity, int max_path, bool stopOnEmpty) { return new IntPtr(1); }
	private static void criAtomUnityEntryPool_Destroy(IntPtr pool) { }
	private static int criAtomUnityEntryPool_GetNumEntries(IntPtr pool) { return 0; }
	private static bool criAtomUnityEntryPool_EntryFile(IntPtr pool, IntPtr binder, string path, bool repeat, int max_path) { return true; }
	private static bool criAtomUnityEntryPool_EntryContentId(IntPtr pool,  IntPtr binder, int id, bool repeat) { return true; }
	private static bool criAtomUnityEntryPool_EntryData(IntPtr pool, byte[] buffer, int size, bool repeat) { return true; }
	private static bool criAtomUnityEntryPool_EntryData(IntPtr pool, IntPtr buffer, int size, bool repeat) { return true; }
	private static bool criAtomUnityEntryPool_EntryCue(IntPtr pool, IntPtr acbhn, string name, bool repeat) { return true; }
	private static void criAtomUnityEntryPool_Clear(IntPtr pool) { }
	private static void criAtomExPlayer_SetStartTime(IntPtr player, long start_time_ms) { }
	private static void criAtomExPlayer_SetSequencePrepareTime(IntPtr player, uint seq_prep_time_ms) { }
	private void criAtomExPlayer_LimitLoopCount(IntPtr player, int count) { _dummyLoop = (count == -3);  }
	private static void criAtomExPlayer_Update(IntPtr player, uint id) { }
	private static void criAtomExPlayer_UpdateAll(IntPtr player) { }
	private static void criAtomExPlayer_ResetParameters(IntPtr player) { }
	private static float criAtomExPlayer_GetParameterFloat32(IntPtr player, CriAtomEx.Parameter id) { return 0.0f; }
	private static uint criAtomExPlayer_GetParameterUint32(IntPtr player, CriAtomEx.Parameter id) { return 0u; }
	private static int criAtomExPlayer_GetParameterSint32(IntPtr player, CriAtomEx.Parameter id) { return 0; }
	private static IntPtr criAtomExPlayer_GetPlayerParameter(IntPtr player) { return IntPtr.Zero; }
	private void criAtomExPlayerParameter_RemoveParameter(IntPtr player_parameter, System.UInt16 id) { _dummyLoop = false; }
	private static void criAtomExPlayer_SetVolume(IntPtr player, float volume) { }
	private static void criAtomExPlayer_SetPitch(IntPtr player, float pitch) { }
	private static void criAtomExPlayer_SetPlaybackRatio(IntPtr player, float playback_ratio) { }
	private static void criAtomExPlayer_SetPan3dAngle(IntPtr player, float pan3d_angle) { }
	private static void criAtomExPlayer_SetPan3dInteriorDistance(
		IntPtr player, float pan3d_interior_distance) { }
	private static void criAtomExPlayer_SetPan3dVolume(IntPtr player, float pan3d_volume) { }
	private static void criAtomExPlayer_SetPanType(IntPtr player, CriAtomEx.PanType panType) { }
	private static void criAtomExPlayer_SetSendLevel(IntPtr player, int channel, CriAtomEx.Speaker id, float level) { }
	private static void criAtomExPlayer_SetBusSendLevel(IntPtr player, int bus_id, float level) { }
	private static void criAtomExPlayer_SetBusSendLevelByName(IntPtr player, string bus_name, float level) { }
	private static bool criAtomExPlayer_GetBusSendLevelByName(IntPtr player, string bus_name, out float level) { level = 0.0f; return false; }
	private static void criAtomExPlayer_SetBusSendLevelOffset(IntPtr player, int bus_id, float level_offset) { }
	private static void criAtomExPlayer_SetBusSendLevelOffsetByName(IntPtr player, string bus_name, float level_offset) { }
	private static bool criAtomExPlayer_GetBusSendLevelOffsetByName(IntPtr player, string bus_name, out float level_offset) { level_offset = 0.0f; return false; }
	private static void criAtomExPlayer_SetBandpassFilterParameters(IntPtr player, float cof_low, float cof_high) { }
	private static void criAtomExPlayer_SetBiquadFilterParameters(
		IntPtr player, CriAtomEx.BiquadFilterType type, float frequency, float gain, float q) { }
	private static void criAtomExPlayer_SetVoicePriority(IntPtr player, int priority) { }
	private static void criAtomExPlayer_SetVoiceControlMethod(IntPtr player, CriAtomEx.VoiceControlMethod method) { }
	private static void criAtomExPlayer_AttachAisac(IntPtr player, string globalAisacName) { }
	private static void criAtomExPlayer_DetachAisac(IntPtr player, string globalAisacName) { }
	private static void criAtomExPlayer_SetAisacControlById(IntPtr player, ushort control_id, float control_value) { }
	private static void criAtomExPlayer_SetAisacControlByName(IntPtr player, string control_name, float control_value) { }
	private static void criAtomExPlayer_Set3dSourceHn(IntPtr player, IntPtr source) { }
	private static void criAtomExPlayer_Set3dListenerHn(IntPtr player, IntPtr listener) { }
	private static void criAtomExPlayer_SetCategoryById(IntPtr player, uint category_id) { }
	private static void criAtomExPlayer_SetCategoryByName(IntPtr player, string category_name) { }
	private static void criAtomExPlayer_UnsetCategory(IntPtr player) { }
	private static void criAtomExPlayer_SetCuePriority(IntPtr player, int cue_priority) { }
	private static void criAtomExPlayer_SetPreDelayTime(IntPtr player, float predelay_time_ms) { }
	private static void criAtomExPlayer_SetEnvelopeAttackTime(IntPtr player, float attack_time_ms) { }
	private static void criAtomExPlayer_SetEnvelopeHoldTime(IntPtr player, float hold_time_ms) { }
	private static void criAtomExPlayer_SetEnvelopeDecayTime(IntPtr player, float decay_time_ms) { }
	private static void criAtomExPlayer_SetEnvelopeReleaseTime(IntPtr player, float release_time_ms) { }
	private static void criAtomExPlayer_SetEnvelopeSustainLevel(IntPtr player, float susutain_level) { }
	private static void criAtomExPlayer_AttachFader(IntPtr player, IntPtr config, IntPtr work, int work_size) { }
	private static void criAtomExPlayer_DetachFader(IntPtr player) { }
	private static void criAtomExPlayer_SetFadeOutTime(IntPtr player, int ms) { }
	private static void criAtomExPlayer_SetFadeInTime(IntPtr player, int ms ) { }
	private static void criAtomExPlayer_SetFadeInStartOffset(IntPtr player, int ms) { }
	private static void criAtomExPlayer_SetFadeOutEndDelay(IntPtr player, int ms) { }
	private static bool criAtomExPlayer_IsFading(IntPtr player) { return false; }
	private static void criAtomExPlayer_ResetFaderParameters(IntPtr player) { }
	private static void criAtomExPlayer_SetGroupNumber(IntPtr player, int group_no) { }
	private static bool criAtomExPlayer_GetAttachedAisacInfo(
		IntPtr player, int aisac_attached_index, IntPtr aisac_info) { return false; }
	private static void criAtomExPlayer_SetFirstBlockIndex(IntPtr player, int index) { }
	private static void criAtomExPlayer_SetSelectorLabel(IntPtr player, string selector, string label) { }
	private static void criAtomExPlayer_UnsetSelectorLabel(IntPtr player, string selector, string label) { }
	private static void criAtomExPlayer_ClearSelectorLabels(IntPtr player) { }
	private static void criAtomExPlayer_SetSoundRendererType(IntPtr player, CriAtomEx.SoundRendererType type) { }
	private static void criAtomExPlayer_SetRandomSeed(IntPtr player, uint seed) { }
	private void criAtomExPlayer_Loop(IntPtr player, bool sw) { _dummyLoop = sw; }
	private static void criAtomExPlayer_SetAsrRackId(IntPtr player, int asr_rack_id) { }
	private static void criAtomExPlayer_SetDspParameter(IntPtr player, int id, float value) { }

    private static void criAtomExPlayer_AttachTween(IntPtr player, IntPtr tween){}
    private static void criAtomExPlayer_DetachTween(IntPtr player, IntPtr tween){}
    private static void criAtomExPlayer_DetachTweenAll(IntPtr player){}
#endif
    #endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
