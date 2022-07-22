/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2015 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

/*---------------------------
 * Cueopint Callback Defines
 *---------------------------*/
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_ANDROID || UNITY_IOS || UNITY_TVOS || UNITY_WINRT
    #define CRIMANA_PLAYER_SUPPORT_CUEPOINT_CALLBACK
#elif UNITY_WIIU || UNITY_PSP2 || UNITY_PS3 || UNITY_PS4 || UNITY_WEBGL
    #define CRIMANA_PLAYER_UNSUPPORT_CUEPOINT_CALLBACK
#else
    #error undefined platform if supporting cuepoint callback
#endif

// Use old or new Low-level Native Plugin Interface (from unity 5.2)
#if (UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1)
    #define CRIPLUGIN_USE_OLD_LOWLEVEL_INTERFACE
#endif

using System;
using System.Runtime.InteropServices;

/**
 * \addtogroup CRIMANA_NATIVE_WRAPPER
 * @{
 */
namespace CriMana
{

/**
 * <summary>ムービ再生制御を行うネイティブプレーヤのラッパークラスです。</summary>
 * \par 説明:
 * <br/>
 * 通常、 CriManaMovieController や CriManaMovieControllerForUI コンポーネントから取り出して使用します。
 * 再生停止・ポーズ以上の複雑な再生制御を行う場合本クラスを使用してください。
 * <br/>
 * コンポーネントを使用せずに直接ムービ再生を制御したい場合、本オブジェクトを直接生成して使用することも可能です。
 * <br/>
 * \par 注意:
 * 本クラスのオブジェクトを直接アプリケーションから生成した場合、再生終了後に Player::Dispose 関数で必ず破棄してください。
 */
	public class Player : System.IDisposable
	{
		#region Data Types
		/**
		 * <summary>プレーヤの状態を示す値です。</summary>
		 * \sa Player::status
		 */
		public enum Status
		{
			Stop,			/**< 停止中		*/
			Dechead,		/**< ヘッダ解析中	*/
			WaitPrep,		/**< バッファリング開始停止中 */
			Prep,			/**< 再生準備中	*/
			Ready,			/**< 再生準備完了	*/
			Playing,		/**< 再生中		*/
			PlayEnd,		/**< 再生終了		*/
			Error,			/**< エラー		*/
			StopProcessing,	/**< 停止処理中	*/
		}


		/**
		 * <summary>ファイルをセットする際のモードです。</summary>
		 * \sa Player::SetFile, Player::SetContentId, Player::SetFileRange
		 */
		public enum SetMode
		{
			New,				/**< 次回の再生で利用するムービを指定	*/
			Append,				/**< 連結再生キューに追加する	*/
			AppendRepeatedly	/**< 連結再生キューに次のムービが登録されるまで繰り返し追加する	*/
		}


		/**
		 * <summary>オーディオトラックを設定する際のモードです。</summary>
		 * \sa Player::SetAudioTrack, Player::SetSubAudioTrack
		 */
		public enum AudioTrack
		{
			Off,	/**< オーディオ再生OFFの指定値	*/
			Auto,	/**< オーディオトラックのデフォルト値	*/
		}


		/**
		 * <summary>キューポイントコールバックデリゲート型です。</summary>
		 * <param name="eventPoint">イベントポイント情報</param>
		 * \par 説明:
		 * キューポイントコールバックデリゲート型です。<br/>
		 * \par 注意:
		 * キューポイントコールバック内では、ムービ再生をコントロールする関数を呼び出してはいけません。
		 * \sa Player::cuePointCallback
		 */
		public delegate void CuePointCallback(ref EventPoint eventPoint);


		/**
		 * <summary>シェーダ選択デリゲート型です。</summary>
		 * <param name="movieInfo">ムービ情報</param>	
		 * <param name="additiveMode">加算合成するかどうか</param>	 
		 * \par 説明:
		 * シェーダ選択デリゲート型です。<br/>
		 * \sa Player::SetShaderDispatchCallback
		 */
		public delegate UnityEngine.Shader ShaderDispatchCallback(MovieInfo movieInfo, bool additiveMode);
		#endregion


		#region Constant Variables
		private const int  InvalidPlayerId = -1;
		#endregion


		#region Internal Variables
		static private Player		updatingPlayer			= null;

		private bool				disposed				= false;

		private int					playerId				= InvalidPlayerId;
		private Status				requiredStatus			= Status.Stop;
		private Status				nativeStatus			= Status.Stop;
		private bool				isNativeStartInvoked	= false;
		private Detail.RendererResource	rendererResource;
		private MovieInfo			_movieInfo				= new MovieInfo();
		private FrameInfo			_frameInfo				= new FrameInfo();
		private bool				isMovieInfoAvailable	= false;
		private bool				isFrameInfoAvailable	= false;
		private ShaderDispatchCallback	_shaderDispatchCallback	= null;
		private bool				enableSubtitle			= false;
		private int					subtitleBufferSize		= 0;
		#endregion


		#region Properties
		/**
		 * <summary>キューポイントコールバックデリゲートです。</summary>
		 * \par 説明:
		 * キューポイントコールバックデリゲートです。<br/>
		 * \par 注意:
		 * Player::Prepare 関数および Player::Start 関数より前に設定する必要があります。
		 * \sa Player::CuePointCallback
		 */
		public CuePointCallback	cuePointCallback;


		/**
		 * <summary>ブレンドモードを加算合成モードにします。</summary>
		 * \par 説明:
		 * 再生時のシェーダ選択コールバックに渡される引数になります。<br/>
		 * \par 注意:
		 * Player::Prepare 関数および Player::Start 関数より前に設定する必要があります。
		 * \sa Player::ShaderDispatchCallback
		 */
		public bool additiveMode { get; set; }


		/**
		 * <summary>有効なフレームを所持しているかどうか</summary>
		 * \par 説明:
		 * 有効なフレームを所持しているかどうかを返します。<br/>
		 * \par 備考:
		 * 独自で描画を行う場合、本フラグで描画の切り替え制御を行ってください。<br/>
		 */
		public bool isFrameAvailable
		{
			get { return isFrameInfoAvailable; }
		}


		/**
		 * <summary>再生中のムービ情報を取得します。</summary>
		 * <param name="movieInfo">ムービ情報</param>
		 * \par 説明:
		 * 再生を開始したムービのヘッダ解析結果の情報です。<br/>
		 * ムービの解像度、フレームレートなどの情報が参照できます。<br/>
		 * \par 注意:
		 * プレーヤのステータスが \link Player::Status WaitPrep〜Playing \endlink 状態の間のみ情報が取得できます。<br/>
		 * それ以外の状態は null が返ります。
		 */
		public MovieInfo movieInfo
		{
			get { return isMovieInfoAvailable ? _movieInfo : null; }
		}


		/**
		 * <summary>再生中のムービのフレーム情報を取得します。</summary>
		 * <param name="frameInfo">フレーム情報</param>
		 * \par 説明:
		 * 現在描画中のフレーム情報を取得できます。<br/>
		 * \par 備考:
		 * 再生状態のみ情報が取得できます。それ以外の状態では null が返ります。<br/>
		 */
		public FrameInfo frameInfo
		{
			get { return isFrameAvailable ? _frameInfo : null; }
		}


		/**
		 * <summary>プレーヤのステータスを取得します。</summary>
		 * <returns>ステータス</returns>
		 * \par 説明：
		 * プレーヤのステータスを取得します。<br/>
		 */
		public Status status
		{
			get {
				if ((requiredStatus == Status.Stop) && (nativeStatus != Status.Stop)) {
					return Status.StopProcessing;
				}
				if (nativeStatus == Status.Ready) {
					return ((rendererResource != null) && (rendererResource.IsPrepared()))
						? Status.Ready : Status.Prep;
				} else {
					return nativeStatus;
				}
			}
		}


		/**
		 * <summary>連結再生エントリー数を取得します。</summary>
		 * \par 説明：
		 * 連結再生エントリー数を取得します。<br/>
		 * このプロパティで得られる値は、読み込みが開始されていないエントリー数です。<br/>
		 * 連結する数フレーム前に、エントリーに登録されているムービの読み込みが開始されます。<br/>
		 */
		public System.Int32 numberOfEntries
		{
			get {
				return (playerId != InvalidPlayerId) ? criManaUnityPlayer_GetNumberOfEntry(playerId) : -1;
			}
		}


		/**
		 * <summary>字幕データバッファへのポインタを取得します。</summary>
		 * \par 説明：
		 * 字幕データバッファへのポインタを取得します。<br/>
		 * 表示時刻になっている字幕データが格納されています。<br/>
		 * System.Runtime.InteropServices.Marshal.PtrToStringAuto などで変換して使用してください。<br/>
		 * \sa Player::SetSubtitleChannel, Player::subtitleSize
		 */
		public System.IntPtr subtitleBuffer { get; private set; }


		/**
		 * <summary>字幕データバッファのサイズを取得します。</summary>
		 * \par 説明：
		 * 字幕データバッファのサイズを取得します<br/>
		 * System.Runtime.InteropServices.Marshal.PtrToStringAuto などで変換して使用してください。<br/>
		 * \sa Player::SetSubtitleChannel, Player::subtitleBuffer
		 */
		public int subtitleSize { get; private set; }
		#endregion


		public Player()
		{
			CriManaPlugin.InitializeLibrary();
			playerId		= criManaUnityPlayer_Create();
			additiveMode	= false;
		}


		~Player()
		{
			Dispose(false);
		}


		/**
		 * <summary>プレーヤオブジェクトの破棄</summary>
		 * \par 説明:
		 * プレーヤオブジェクトを破棄します。<br/>
		 * 独自に CriMana::Player オブジェクトを生成した場合、必ず Dispose 関数を呼び出してください。
		 * 本関数を実行した時点で、プレーヤ作成時に確保されたリソースが全て解放されます。<br/>
		 */
		public void Dispose()
		{
			this.Dispose(true);
			System.GC.SuppressFinalize(this);
		}


		/**
		 * <summary>ムービ描画に必要なリソースを生成します。</summary>
		 * <param name="width">ムービの幅</param>
		 * <param name="height">ムービの高さ</param>
		 * <param name="alpha">アルファムービか否か</param>
		 * \par 説明:
		 * ムービ描画に必要なリソースを生成します。<br/>
		 * 通常はムービ描画に必要なリソースの生成はプレーヤ内部で自動的に行いますが、 Player::Prepare および
		 * Player::Start を呼び出す前に本関数を呼び出すことでリソースの生成を事前に行うことができます。<br/>
		 * ただし、この関数で事前に生成したリソースの幅、高さが不十分などの理由で<br/>
		 * 実際に再生するムービの描画に利用できない場合はリソースは破棄されて再生成されます。
		 * \sa Player::DisposeRendererResource
		 */
		public void CreateRendererResource(int width, int height, bool alpha)
		{
			MovieInfo dummyMovieInfo = new MovieInfo();
			dummyMovieInfo.hasAlpha			= alpha;
			dummyMovieInfo.width			= (System.UInt32)width;
			dummyMovieInfo.height			= (System.UInt32)height;
			dummyMovieInfo.dispWidth		= (System.UInt32)width;
			dummyMovieInfo.dispHeight		= (System.UInt32)height;
			dummyMovieInfo.codecType		= CodecType.SofdecPrime;
			dummyMovieInfo.alphaCodecType	= CodecType.SofdecPrime;

			UnityEngine.Shader userShader		= (_shaderDispatchCallback == null) ? null : _shaderDispatchCallback(movieInfo, additiveMode);
			if (rendererResource != null) {
				if (!rendererResource.IsSuitable(playerId, dummyMovieInfo, additiveMode, userShader)) {
					rendererResource.Dispose();
					rendererResource = null;
				}
			}
			if (rendererResource == null) {
				rendererResource = Detail.RendererResourceFactory.DispatchAndCreate(playerId, dummyMovieInfo, additiveMode, userShader);
			}
		}


		/**
		 * <summary>ムービ描画に必要なリソースを破棄します。</summary>
		 * \par 説明:
		 * ムービ描画に必要なリソースを破棄します。<br/>
		 * リソースの破棄は Player::Dispose 時に行われますが、
		 * 本関数で明示的に行うことができます。<br/>
		 * \sa Player::CreateRendererResource
		 */
		public void DisposeRendererResource()
		{
			if (rendererResource != null) {
				rendererResource.Dispose();
				rendererResource = null;
			}
		}


		/**
		 * <summary>再生準備処理を行います。</summary>
		 * \par 説明:
		 * ムービ再生は開始せず、ヘッダ解析と再生準備(バッファリング)のみを行って待機する関数です。<br/>
		 * ムービ再生開始の頭出しをそろえたい場合に本関数を使用します。<br/>
		 * <br/>
		 * 再生対象のムービを指定した後、本関数を呼び出してください。
		 * 再生準備が完了すると、プレーヤの状態は \link CriMana::Player::Status Ready \endlink 状態になり、 CriMana::Player::Play 関数ですぐに描画開始されます。<br/>
		 * <br/>
		 * 本関数は \link CriMana::Player::Status Stop \endlink 状態、また \link CriMana::Player::Status PlayEnd \endlink 状態でのみ呼び出してください。
		 */
		public void Prepare()
		{
			PrepareNativePlayer();
			UpdateNativePlayer();
			DisableInfos();
			requiredStatus = Status.Ready;
		}


		/**
		 * <summary>再生を開始します。</summary>
		 * \par 説明:
		 * ムービ再生を開始します。<br/>
		 * 再生が開始されると、状態は \link Player::Status Playing \endlink になります。
		 * \par 注意:
		 * 本関数を呼び出し後、実際にムービの描画が開始されるまで数フレームかかります。</br>
		 * ムービ再生の頭出しを行いたい場合は、 Player::Prepare 関数で事前に再生準備を行ってください。
		 * \sa Player::Stop, Player::Status
		 */
		public void Start()
		{
			if ((nativeStatus == Status.Stop) || (nativeStatus == Status.PlayEnd)) {
				PrepareNativePlayer();
				DisableInfos();
				UpdateNativePlayer();
			}
			requiredStatus = Status.Playing;
		}


		/**
		 * <summary>ムービ再生の停止要求を行います。</summary>
		 * \par 説明:
		 * ムービ再生の停止要求を出します。本関数は即時復帰関数です。<br/>
		 * 本関数を呼び出すと、描画は即座に終了しますが、再生はすぐには止まりません。<br/>
		 * \sa Player::Status
		 */
		public void Stop()
		{
			criManaUnityPlayer_Stop(playerId);
			UpdateNativePlayer();
			DisableInfos();
			requiredStatus = Status.Stop;
		}


		/**
		 * <summary>ムービ再生のポーズ切り替えを行います。</summary>
		 * <param name="sw">ポーズスイッチ(true: ポーズ, false: ポーズ解除)</param>
		 * \par 説明:
		 * ポーズのON/OFFを切り替えます。<br/>
		 * 引数にtrueを指定する一時停止、falseを指定すると再生再開です。<br/>
		 * Player::Stop 関数を呼び出すと、ポーズ状態は解除されます <br/>
		 * \sa Player::IsPaused
		 */
		public void Pause(bool sw)
		{
			criManaUnityPlayer_Pause(playerId, (sw) ? 1 : 0);
		}


		/**
		 * <summary>ムービ再生のポーズ状態の取得を行います。</summary>
		 * <returns>ポーズ状態</returns>
		 * \par 説明:
		 * ポーズのON/OFFを取得します。<br/>
		 * \sa Player::Pause
		 */
		public bool IsPaused()
		{
			return criManaUnityPlayer_IsPaused(playerId);
		}


		/**
		 * <summary>ストリーミング再生用のファイルパスの設定を行います。</summary>
		 * <param name="binder">CPKファイルをバインド済みのバインダ</param>
		 * <param name="moviePath">CPKファイル内のコンテンツパス</param>
		 * <param name="setMode">ムービの追加モード</param>
		 * <returns>セットに成功したか</returns>
		 * \par 説明:
		 * ストリーミング再生用のファイルパスを設定します。<br/>
		 * 第一引数の binder にCPKファイルをバインドしたバインダハンドルを指定することにより、CPKファイルからのムービ再生が行えます。<br/>
		 * CPKからではなく直接ファイルからストリーミングする場合は、binder に null を指定ください。<br/>
		 * 第三引数の setMode に Player::SetMode::Append を与えると、連結再生を行います。この場合、関数は false を返す可能性があります。<br/>
		 * 連結再生できるムービファイルには以下の条件があります。<br>
		 * - ビデオの解像度、フレームレート、コーデックが全て同じ
		 * - アルファ情報の有無が一致
		 * - 音声トラックの構成（トラック番号および各チャンネル数）、コーデックが全て同じ
		 * 
		 * \par バインダを指定しない場合(nullを指定した場合):
		 * - moviePath プロパティを設定した場合と等価です。<br/>
		 * - 相対パスを指定した場合は StreamingAssets フォルダからの相対でファイルをロードします。
		 * - 絶対パス、あるいはURLを指定した場合には指定したパスでファイルをロードします。<br/>
		 * 
		 * \par バインダを指定した場合:
		 * バインダ設定後に moviePath プロパティを設定した場合は、バインダにバインドされているCPKファイルからムービ再生が行われます。<br/>
		 * \sa Player::SetContentId, Player::SetFileRange, Player::moviePath
		 */
		public bool SetFile(CriFsBinder binder, string moviePath, SetMode setMode = SetMode.New)
		{
			System.IntPtr binderPtr = (binder == null) ? System.IntPtr.Zero : binder.nativeHandle;
			if ((binder == null) && CriWare.IsStreamingAssetsPath(moviePath) ) {
				moviePath = System.IO.Path.Combine(CriWare.streamingAssetsPath, moviePath);
			}
			if (setMode == SetMode.New) {
				criManaUnityPlayer_SetFile(playerId, binderPtr, moviePath);
				return true;
			} else {
				return criManaUnityPlayer_EntryFile(
					playerId, binderPtr, moviePath,
					(setMode == SetMode.AppendRepeatedly)
					);
			}
		}


		/**
		 * <summary>CPKファイル内のムービファイルの指定を行います。 (コンテンツID指定)</summary>
		 * <param name="binder">CPKファイルをバインド済みのバインダ</param>
		 * <param name="contentId">CPKファイル内のコンテンツID</param>
		 * <param name="setMode">ムービの追加モード</param>
		 * <returns>セットに成功したか</returns>
		 * \par 説明:
		 * ストリーミング再生用のコンテンツIDを設定します。<br/>
		 * 引数にバインダとコンテンツIDを指定することで、CPKファイル内の任意のムービデータを読み込み元にすることが出来ます。
		 * 第三引数の setMode に Append を与えると、連結再生を行います。この場合、関数は false を返す可能性があります。<br/>
		 * 連結再生できるムービファイルには以下の条件があります。<br>
		 * - ビデオの解像度、フレームレート、コーデックが全て同じ
		 * - アルファ情報の有無が一致
		 * - 音声トラックの構成（トラック番号および各チャンネル数）、コーデックが全て同じ
		 * \sa Player::SetFile, Player::SetFileRange
		 */
		public bool SetContentId(CriFsBinder binder, int contentId, SetMode setMode = SetMode.New)
		{
			if (binder == null) {
				UnityEngine.Debug.LogError("[CRIWARE] CriFsBinder is null");
				return false;
			}
			if (setMode == SetMode.New) {
				criManaUnityPlayer_SetContentId(playerId, binder.nativeHandle, contentId);
				return true;
			}
			else {
				return criManaUnityPlayer_EntryContentId(
					playerId, binder.nativeHandle, contentId,
					(setMode == SetMode.AppendRepeatedly)
					);
			}
		}


		/**
		 * <summary>パックファイル内のムービファイルの指定を行います。 (ファイル範囲指定)</summary>
		 * <param name="filePath">パックファイルへのパス</param>
		 * <param name="offset">パックファイル内のムービファイルのデータ開始位置</param>
		 * <param name="range">パックファイル内のムービファイルのデータ範囲</param>
		 * <param name="setMode">ムービの追加モード</param>
		 * <returns>セットに成功したか</returns>
		 * \par 説明:
		 * ストリーミング再生を行いたいムービファイルをパッキングしたファイルを指定します。<br/>
		 * 引数にオフセット位置とデータ範囲を指定することで、パックファイル内の任意のムービデータを読み込み元にすることが出来ます。
		 * 第二引数の range に -1 を指定した場合はパックファイルの終端までをデータ範囲とします。
		 * 第四引数の setMode に Player::SetMode.Append を与えると、連結再生を行います。この場合、関数は false を返す可能性があります。<br/>
		 * 連結再生できるムービファイルには以下の条件があります。<br>
		 * - ビデオの解像度、フレームレート、コーデックが全て同じ
		 * - アルファ情報の有無が一致
		 * - 音声トラックの構成（トラック番号および各チャンネル数）、コーデックが全て同じ
		 * \sa Player::SetFile, Player::SetContentId, Player::moviePath
		 */
		public bool SetFileRange(string filePath, System.UInt64 offset, System.Int64 range, SetMode setMode = SetMode.New)
		{
			if (setMode == SetMode.New) {
				criManaUnityPlayer_SetFileRange(playerId, filePath, offset, range);
				return true;
			}
			else {
				return criManaUnityPlayer_EntryFileRange(
					playerId, filePath, offset, range,
					(setMode == SetMode.AppendRepeatedly)
					);
			}
		}


		/**
		 * <summary>ムービ再生のループ切り替えを行います。</summary>
		 * \par 値の意味:
		 * <param name="sw">ループスイッチ(true: ループモード, false: ループモード解除)</param>
		 * \par 説明:
		 * ループ再生のON/OFFを切り替えます。デフォルトはループOFFです。<br/>
		 * ループ再生をONにした場合は、ムービ終端まで再生しても再生は終了せず先頭に戻って再生を
		 * 繰り返します。<br/>
		 */
		public void Loop(bool sw)
		{
			criManaUnityPlayer_Loop(playerId, sw ? 1 : 0);
		}


		/**
		 * <summary>シーク位置の設定を行います。</summary>
		 * <param name="frameNumber">シーク先のフレーム番号</param>
		 * \par 説明:
		 * シーク再生を開始するフレーム番号を指定します。<br>
		 * 本関数を実行しなかった場合、またはフレーム番号0を指定した場合はムービの先頭から再生を開始します。
		 * 指定したフレーム番号が、ムービデータの総フレーム数より大きかったり負の値だった場合もムービの先頭から再生します。
		 */
		public void SetSeekPosition(int frameNumber)
		{
			criManaUnityPlayer_SetSeekPosition(playerId, frameNumber);
		}


		/**
		 * <summary>ムービ再生の速度調整を行います。</summary>
		 * <param name="speed">再生速度</param>
		 * \par 説明:
		 * ムービの再生速度を指定します。<br/>
		 * 再生速度は、0.0f〜3.0fの範囲で実数値を指定します。<br/>
		 * 1.0fが指定された場合はデータ本来の速度で再生を行います。<br/>
		 * 例えば、2.0fを指定した場合、ムービはムービデータのフレームレートの２倍の速度で再生されます。<br/>
		 * 再生速度のデフォルト値は1.0fです。<br/>
		 * \par 注意:
		 * 再生中のムービに対する再生速度の変更は、音声がないムービを再生した場合のみ対応しています。<br/>
		 * 音声つきムービに対して再生中の速度変更を行うと正常動作しません。音声つきのムービの場合は、一度再生停止
		 * してから、再生速度を変更し、目的のフレーム番号からシーク再生をしてください。<br>
		 * <br/>
		 */
		public void SetSpeed(float speed)
		{
			criManaUnityPlayer_SetSpeed(playerId, speed);
		}


		/**
		 * <summary>最大ピクチャデータサイズの指定</summary>
		 * <param name="maxDataSize">最大ピクチャデータサイズ</param>
		 * \par 説明:
		 * 最大ピクチャデータサイズの設定をします。<br/>
		 * 通常再生では、本関数を使用する必要はありません。<br/>
		 * <br/>
		 * H.264ムービを連結再生する場合、本関数で最大ピクチャデータサイズを設定してから再生を開始してください。<br/>
		 * 設定すべきデータサイズは、USMファイルをWizzに入力した際、「Maximum chunk size」と表示される数値の、全USMの最大値です。
		 * <br/>
		 */
		public void SetMaxPictureDataSize(System.UInt32 maxDataSize)
		{
			criManaUnityPlayer_SetMaxPictureDataSize(playerId, maxDataSize);
		}


		/**
		 * <summary>メインオーディオトラック番号の設定を行います。</summary>
		 * <param name="track">トラック番号</param>
		 * \par 説明:
		 * ムービが複数のオーディオトラックを持っている場合に、再生するオーディオを指定します。<br>
		 * 本関数を実行しなかった場合は、もっとも若い番号のオーディオトラックを再生します。<br>
		 * データが存在しないトラック番号を指定した場合は、オーディオは再生されません。<br>
		 * <br>
		 * トラック番号としてAudioTrack.Offを指定すると、例えムービにオーディオが
		 * 含まれていたとしてもオーディオは再生しません。<br>
		 * <br>
		 * また、デフォルト設定（もっとも若いチャネルのオーディオを再生する）にしたい場合は、
		 * チャネルとしてAudioTrack.Autoを指定してください。<br>
		 *
		 * \par 備考:
		 * 再生中のトラック変更は未対応です。変更前のフレーム番号を記録しておいてシーク再生
		 * してください。
		 */
		public void SetAudioTrack(int track)
		{
			criManaUnityPlayer_SetAudioTrack(playerId, track);
		}


		public void SetAudioTrack(AudioTrack track)
		{
			if (track == AudioTrack.Off) {
				criManaUnityPlayer_SetAudioTrack(playerId, -1);
			} else if (track == AudioTrack.Auto) {
				criManaUnityPlayer_SetAudioTrack(playerId, 100);
			}
		}


		/**
		 * <summary>サブオーディオトラック番号の設定を行います。</summary>
		 * <param name="track">トラック番号</param>
		 * \par 説明:
		 * ムービが複数のオーディオトラックを持っている場合に、再生するオーディオを指定します。<br>
		 * 本関数を実行しなかった場合（デフォルト設定）はサブオーディオからは何も再生されません。
		 * また、データが存在しないトラック番号を指定した場合、サブオーディオトラックとして
		 * メインオーディオと同じトラックを指定した場合もサブオーディオからは何も再生されません。<br>
		 *
		 * \par 備考:
		 * 再生中のトラック変更は未対応です。変更前のフレーム番号を記録しておいてシーク再生
		 * してください。
		 */
		public void SetSubAudioTrack(int track)
		{
			criManaUnityPlayer_SetSubAudioTrack(playerId, track);
		}


		public void SetSubAudioTrack(AudioTrack track)
		{
			if (track == AudioTrack.Off) {
				criManaUnityPlayer_SetSubAudioTrack(playerId, -1);
			} else if (track == AudioTrack.Auto) {
				criManaUnityPlayer_SetSubAudioTrack(playerId, 100);
			}
		}


		/**
		 * <summary>サブオーディオトラック番号の設定を行います。</summary>
		 * <param name="track">トラック番号</param>
		 * \par 説明:
		 * ムービが複数のオーディオトラックを持っている場合に、再生するオーディオを指定します。<br>
		 * 本関数を実行しなかった場合（デフォルト設定）はサブオーディオからは何も再生されません。
		 * また、データが存在しないトラック番号を指定した場合、サブオーディオトラックとして
		 * メインオーディオと同じトラックを指定した場合もサブオーディオからは何も再生されません。<br>
		 *
		 * \par 備考:
		 * 再生中のトラック変更は未対応です。変更前のフレーム番号を記録しておいてシーク再生
		 * してください。
		 */
		public void SetVolume(float volume)
		{
			criManaUnityPlayer_SetVolume(playerId, volume);
		}


		/**
		 * <summary>ムービ再生の音声ボリューム調整を行います。（サブオーディオ）</summary>
		 * <param name="volume">ボリューム</param>
		 * \par 説明:
		 * ムービのサブオーディオトラックの出力音量ボリュームを指定します。<br/>
		 * ボリューム値には、0.0f〜1.0fの範囲で実数値を指定します。<br/>
		 * ボリューム値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br/>
		 * 例えば、1.0fを指定した場合、原音はそのままのボリュームで出力されます。<br/>
		 * 0.0fを指定した場合、音声はミュートされます（無音になります）。<br/>
		 * ボリュームのデフォルト値は1.0fです。<br>
		 * \par 備考:
		 * 0.0f〜1.0fの範囲外を指定した場合は、それぞれの最小・最大値にクリップされます。<br/>
		 */
		public void SetSubAudioVolume(float volume)
		{
			criManaUnityPlayer_SetSubAudioVolume(playerId, volume);
		}


		/**
		 * <summary>メインオーディオトラックのバスセンドレベル調整を行います。</summary>
		 * <param name="bus_name">バス名</param>
		 * <param name="level">バスセンドレベル</param>
		 * \par 説明:
		 * ムービのメインオーディオトラックのバスセンドレベル（振幅レベル）と、センド先のバス名を指定します。<br>
		 * バスセンドレベル値には、0.0f〜1.0fの範囲で実数値を指定します。<br>
		 * バスセンドレベル値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br>
		 * 例えば、1.0fを指定した場合、原音はそのままのボリュームでバスに出力されます。<br>
		 * 0.0fを指定した場合、バスには無音が出力されます。<br>
		 */
		public void SetBusSendLevel(string bus_name, float level)
		{
			criManaUnityPlayer_SetBusSendLevelByName(playerId, bus_name, level);
		}


		/**
		 * <summary>サブオーディオトラックのバスセンドレベル調整を行います。</summary>
		 * <param name="bus_name">バス名</param>
		 * <param name="volume">バスセンドレベル</param>
		 * \par 説明:
		 * ムービのメインオーディオトラックのバスセンドレベル（振幅レベル）と、センド先のバス名を指定します。<br>
		 * 本関数の動作仕様は SetBusSendLevel と同様です。
		 */
		public void SetSubAudioBusSendLevel(string bus_name, float volume)
		{
			criManaUnityPlayer_SetSubAudioBusSendLevelByName(playerId, bus_name, volume);
		}


		/**
		 * <summary>字幕チャネルの設定を行ないます。</summary>
		 * <param name="channel">字幕チャネル番号</param>
		 * \par 説明:
		 * 取得する字幕チャネルを設定します。デフォルトは字幕取得無しです。<br/>
		 * デフォルト設定（字幕取得無し）にしたい場合は、チャネルとして -1 を指定してください。<br/>
		 * ムービ再生中に字幕チャンネルを切り替えることも可能です。ただし、実際のチャネルが切り替わるのは
		 * 設定した直後の次の字幕からとなります。<br/>
		 * \sa Player::subtitleBuffer, Player::subtitleBuffer
		 */
		public void SetSubtitleChannel(int channel)
		{
			enableSubtitle = (channel != -1);
			if (enableSubtitle) {
				if (isMovieInfoAvailable) {
					AllocateSubtitleBuffer((int)movieInfo.maxSubtitleSize);
				}
			} else {
				DeallocateSubtitleBuffer();
			}
			criManaUnityPlayer_SetSubtitleChannel(playerId, channel);
		}


		/**
		 * <summary>シェーダ選択デリゲートの設定を行ないます。</summary>
		 * <param name="shaderDispatchCallback">シェーダ選択デリゲート</param>
		 * \par 説明:
		 * ユーザ定義シェーダを決定するデリゲートの設定を行ないます<br>
		 * \par 注意:
		 * Player::Prepare 関数および Player::Start 関数より前に設定する必要があります。
		 * \sa Player::ShaderDispatchCallback
		 */
		public void SetShaderDispatchCallback(ShaderDispatchCallback shaderDispatchCallback)
		{
			_shaderDispatchCallback = shaderDispatchCallback;
		}


		/**
		 * <summary>状態を更新します。</summary>
		 * \par 説明:
		 * プレーヤの状態を更新します。<br>
		 * アプリケーションは、この関数を定期的に実行する必要があります。<br>
		 * \par 注意:
		 * 本関数の呼び出しが滞るとムービ再生ががたつく場合があります。
		 */
		public void Update()
		{
			if (requiredStatus == Status.Stop) {
				if (nativeStatus != Status.Stop) {
					UpdateNativePlayer();
				}
				return;
			}

			switch (nativeStatus) {
			case Status.Stop:
				break;
			case Status.Dechead:
				UpdateNativePlayer();
				if (nativeStatus == Status.WaitPrep) {
					goto case Status.WaitPrep;
				}
				break;
			case Status.WaitPrep:
			{
				bool needRendererResourceDispatch = !isMovieInfoAvailable;
				if (needRendererResourceDispatch) {
					criManaUnityPlayer_GetMovieInfo(playerId, _movieInfo);
					isMovieInfoAvailable = true;
					if (enableSubtitle) {
						AllocateSubtitleBuffer((int)movieInfo.maxSubtitleSize);
					}
					UnityEngine.Shader userShader	= (_shaderDispatchCallback == null) ? null : _shaderDispatchCallback(movieInfo, additiveMode);
					if (rendererResource != null) {
						if (!rendererResource.IsSuitable(playerId, _movieInfo, additiveMode, userShader)) {
							rendererResource.Dispose();
							rendererResource = null;
						}
					}
					if (rendererResource == null) {
						rendererResource = Detail.RendererResourceFactory.DispatchAndCreate(playerId, _movieInfo, additiveMode, userShader);
						if (rendererResource == null) {
							Stop();
							return;
						}
					} 
				}
				if (!rendererResource.IsPrepared()) {
					rendererResource.ContinuePreparing();
					if (!rendererResource.IsPrepared()) {
						break;
					}
				}
				rendererResource.AttachToPlayer(playerId);
				if (requiredStatus == Status.Ready) {
					goto case Status.Prep;
				}
				if (requiredStatus == Status.Playing) {
					criManaUnityPlayer_Start(playerId);
					isNativeStartInvoked = true;
					goto case Status.Prep;
				}
			}
				break;
			case Status.Prep:
				UpdateNativePlayer();
				if (nativeStatus == Status.Ready) {
					goto case Status.Ready;
				} else if (nativeStatus == Status.Playing) {
					goto case Status.Playing;
				}
				break;
			case Status.Ready:
				if (requiredStatus == Status.Playing) {
					if (!isNativeStartInvoked) {
						criManaUnityPlayer_Start(playerId);
						isNativeStartInvoked = true;
					}
					goto case Status.Playing;
				}
				break;
			case Status.Playing:
				UpdateNativePlayer();
				if (nativeStatus == Status.Playing) {
					isFrameInfoAvailable |= rendererResource.UpdateFrame(playerId, _frameInfo);
				} else if (nativeStatus == Status.PlayEnd) {
					goto case Status.PlayEnd;
				}
				break;
			case Status.PlayEnd:
				// Do nothing
				break;
			case Status.Error:
				UpdateNativePlayer();
				break;
			}

			if (nativeStatus == Status.Error) {
				DisableInfos();
			}
		}


		/**
		 * <summary>マテリアルに現在のフレームを表示するための設定を行います。</summary>
		 * <param name="material">設定対象のマテリアル</param>
		 * <returns>設定を行なえたか</returns>
		 * \par 説明:
		 * マテリアルに現在のフレームを表示するためにシェーダや各種パラメータを設定します。<br>
		 */
		public bool UpdateMaterial(UnityEngine.Material material)
		{
			if ((rendererResource != null) && isFrameInfoAvailable) {
				return rendererResource.UpdateMaterial(material);
			}
			return false;
		}

#if !CRIPLUGIN_USE_OLD_LOWLEVEL_INTERFACE && !(UNITY_IOS || UNITY_TVOS)
        [DllImport(CriWare.pluginName)]
        private static extern IntPtr GetRenderEventFunc();
#endif

		public void IssuePluginEvent()
		{
#if !(UNITY_IOS || UNITY_TVOS)
			if (status == Status.Ready || status == Status.Playing) {
#if CRIPLUGIN_USE_OLD_LOWLEVEL_INTERFACE
				UnityEngine.GL.IssuePluginEvent(this.playerId + CriManaPlugin.renderingEventOffset);
#else
				UnityEngine.GL.IssuePluginEvent(GetRenderEventFunc(), this.playerId + CriManaPlugin.renderingEventOffset);
#endif
			}
#endif
		}


		#region Private Methods
		private void Dispose(bool disposing)
		{
			if (disposed) {
				return;
			}
			if (playerId != InvalidPlayerId) {
				criManaUnityPlayer_Destroy(playerId);
				playerId = InvalidPlayerId;
			}
			DisposeRendererResource();
			DeallocateSubtitleBuffer();
			CriManaPlugin.FinalizeLibrary();
			cuePointCallback = null;
			disposed = true;
		}

		private void DisableInfos()
		{
			isMovieInfoAvailable = false;
			isFrameInfoAvailable = false;
			isNativeStartInvoked = false;
			subtitleSize         = 0;
		}

		private void PrepareNativePlayer()
		{
			if (cuePointCallback != null) {
				#if CRIMANA_PLAYER_SUPPORT_CUEPOINT_CALLBACK
				criManaUnityPlayer_SetCuePointCallback(playerId, CuePointCallbackFromNative);
				#else
				UnityEngine.Debug.LogError("This platform does not support event callback feature.");
				#endif
			}
			criManaUnityPlayer_Prepare(playerId);
		}


		private void UpdateNativePlayer()
		{
			updatingPlayer = this;
			uint subtitleSizeTmp = (uint)subtitleBufferSize;
			nativeStatus = (Status)criManaUnityPlayer_Update(playerId, subtitleBuffer, ref subtitleSizeTmp);
			subtitleSize = (int)subtitleSizeTmp;
			updatingPlayer = null;
		}


		private void AllocateSubtitleBuffer(int size)
		{
			if (subtitleBufferSize < size) {
				DeallocateSubtitleBuffer();
				subtitleBuffer     = Marshal.AllocHGlobal(size);
				subtitleBufferSize = size;
				subtitleSize       = 0;
			}
		}

		private void DeallocateSubtitleBuffer()
		{
			if (subtitleBuffer != System.IntPtr.Zero) {
				Marshal.FreeHGlobal(subtitleBuffer);
				subtitleBuffer     = System.IntPtr.Zero;
				subtitleBufferSize = 0;
				subtitleSize       = 0;
			}
		}


		private delegate void CuePointCallbackFromNativeDelegate(System.IntPtr ptr1, System.IntPtr ptr2, [In] ref EventPoint eventPoint);


		[AOT.MonoPInvokeCallback(typeof(CuePointCallbackFromNativeDelegate))]
		private static void CuePointCallbackFromNative(System.IntPtr ptr1, System.IntPtr ptr2, [In] ref EventPoint eventPoint)
		{
			if (updatingPlayer.cuePointCallback != null) {
				updatingPlayer.cuePointCallback(ref eventPoint);
			}
		}
		#endregion


		#region Native API Definitions
		[DllImport(CriWare.pluginName)]
		private static extern int criManaUnityPlayer_Create();
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_Destroy(int player_id);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetFile(int player_id, System.IntPtr binder, string path);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetContentId(int player_id, System.IntPtr binder, int content_id);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetFileRange(int player_id, string path, System.UInt64 offset, System.Int64 range);
		[DllImport(CriWare.pluginName)]
		private static extern bool criManaUnityPlayer_EntryFile(int player_id, System.IntPtr binder, string path, bool repeat);
		[DllImport(CriWare.pluginName)]
		private static extern bool criManaUnityPlayer_EntryContentId(int player_id, System.IntPtr binder, int content_id, bool repeat);
		[DllImport(CriWare.pluginName)]
		private static extern bool criManaUnityPlayer_EntryFileRange(int player_id, string path, System.UInt64 offset, System.Int64 range, bool repeat);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_ClearEntry(int player_id);
		[DllImport(CriWare.pluginName)]
		private static extern System.Int32 criManaUnityPlayer_GetNumberOfEntry(int player_id);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetCuePointCallback(
			int player_id,
			CuePointCallbackFromNativeDelegate cbfunc
			);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_GetMovieInfo(int player_id, [Out] MovieInfo movie_info);
		[DllImport(CriWare.pluginName)]
		private static extern int criManaUnityPlayer_Update(
			int player_id,
			System.IntPtr subtitle_buffer,
			ref uint subtitle_size
			);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_Prepare(int player_id);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_Start(int player_id);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_Stop(int player_id);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetSeekPosition(int player_id, int seek_frame_no);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_Pause(int player_id, int sw);
		[DllImport(CriWare.pluginName)]
		private static extern bool criManaUnityPlayer_IsPaused(int player_id);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_Loop(int player_id, int sw);
		[DllImport(CriWare.pluginName)]
		private static extern long criManaUnityPlayer_GetTime(int player_id);
		[DllImport(CriWare.pluginName)]
		private static extern int criManaUnityPlayer_GetStatus(int player_id);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetAudioTrack(int player_id, int track);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetVolume(int player_id, float vol);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetSubAudioTrack(int player_id, int track);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetSubAudioVolume(int player_id, float vol);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetBusSendLevelByName(int player_id, string bus_name, float level);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetSubAudioBusSendLevelByName(int player_id, string bus_name, float level);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetSubtitleChannel(int player_id, int channel);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetSpeed(int player_id, float speed);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetDeviceSendLevel(int player_id, int device_id, float level);
		[DllImport(CriWare.pluginName)]
		private static extern void criManaUnityPlayer_SetMaxPictureDataSize(int player_id, System.UInt32 max_data_size);
		#endregion
	}
}

/**
 * @}
 */


/* end of file */