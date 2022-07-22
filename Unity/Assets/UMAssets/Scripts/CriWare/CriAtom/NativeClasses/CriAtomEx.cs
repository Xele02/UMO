/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011-2015 CRI Middleware Co., Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom Native Wrapper
 * File     : CriAtomEx.cs
 *
 ****************************************************************************/
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

public class CriStructMemory <Type> : IDisposable
{
	public byte[] bytes {
		get; private set;
	}
	public IntPtr ptr {
		get { return gch.AddrOfPinnedObject(); }
	}
	GCHandle gch;

	public CriStructMemory()
	{
		this.bytes = new byte[Marshal.SizeOf(typeof(Type))];
		this.gch = GCHandle.Alloc(this.bytes, GCHandleType.Pinned);
	}

	public void Dispose()
	{
		this.gch.Free();
	}
}

/*==========================================================================
 *      CRI Atom Native Wrapper
 *=========================================================================*/
/**
 * \addtogroup CRIATOM_NATIVE_WRAPPER
 * @{
 */

/**
 * <summary>Atomライブラリのグローバルクラスです。</summary>
 * \par 説明:
 * Atomライブラリに対する設定関数や、Atomライブラリ内で共有する変数型を含むクラスです。<br/>
 */
public static class CriAtomEx
{
	public enum SoundRendererType {
		Default = 0,
		Native = 1,
		Asr = 2,
		Hw1 = 1,
		Hw2 = 9,
	}
	
	public enum VoiceAllocationMethod {
		Once,						/**< ボイスの確保は1回限り		*/
		Retry,						/**< ボイスを繰り返し確保する	*/
	}
	
	/**
	 * <summary>バイクアッドフィルタのタイプ</summary>
	 * \par 説明:
	 * バイクアッドフィルタのタイプを指定するためのデータ型です。<br/>
	 * ::CriAtomExPlayer::SetBiquadFilterParameters 関数で利用します。
	 * \sa CriAtomExPlayer::SetBiquadFilterParameters
	 */
	public enum BiquadFilterType {
		Off,						/**<フィルタ無効			*/
		LowPass,					/**<ローパスフィルタ		*/
		HighPass,					/**<ハイパスフィルタ		*/
		Notch,						/**<ノッチフィルタ			*/
		LowShelf,					/**<ローシェルフフィルタ	*/
		HighShelf,					/**<ハイシェルフフィルタ	*/
		Peaking						/**<ピーキングフフィルタ	*/
	}

	/**
	 * <summary>ポーズ解除方法</summary>
	 * \par 説明:
	 * ポーズを解除する対象を指定するためのデータ型です。<br/>
	 * ::CriAtomExPlayer::Resume 関数、および ::CriAtomExPlayback::Resume
	 * 関数の引数として使用します。
	 * \sa CriAtomExPlayer::Resume, CriAtomExPlayback::Resume
	 */
	public enum ResumeMode {
		AllPlayback = 0,			/**< 一時停止方法に関係なく再生を再開					*/
		PausedPlayback = 1,			/**< Pause関数でポーズをかけた音声のみ再生を再開		*/
		PreparedPlayback = 2,		/**< Prepare関数で再生準備を指示した音声の再生を開始	*/
	}

	/**
	 * <summary>パンタイプ</summary>
	 * \par 説明:
	 * どのようにして定位計算を行うかを指定するためのデータ型です。<br/>
	 * ::CriAtomExPlayer::SetPanType 関数で利用します。<br/>
	 * \sa criAtomExPlayer::SetPanType
	 */
	public enum PanType {
		Pan3d = 0,					/**< パン3Dで定位を計算				*/
		Pos3d,						/**< 3Dポジショニングで定位を計算	*/
		Auto,						/**< AtomExプレーヤに3D音源／3Dリスナーが設定されている場合は3Dポジショニングで、
										 設定されていない場合はパン3Dで、それぞれ定位を計算します。*/
	}

	/**
	 * <summary>ボイス制御方式</summary>
	 * \par 説明:
	 * AtomExプレーヤで再生する音声の発音制御方法を指定するためのデータ型です。<br/>
	 * ::CriAtomExPlayer::SetVoiceControlMethod 関数で利用します。<br/>
	 * \sa CriAtomExPlayer::SetVoiceControlMethod
	 */
	public enum VoiceControlMethod {
		PreferLast = 0,				/**< 後着優先	*/
		PreferFirst,				/**< 先着優先	*/
	}

	/**
	 * <summary>パラメータID</summary>
	 * \par 説明:
	 * パラメータを指定するためのIDです。<br/>
	 * ::CriAtomExPlayer::GetParameterFloat32 関数等で利用します。
	 * \sa CriAtomExPlayer::GetParameterFloat32, CriAtomExPlayer::GetParameterSint32,
	 * CriAtomExPlayer::GetParameterUint32
	 */
	public enum Parameter {
		Volume					=  0,	/**< ボリューム									*/
		Pitch					=  1,	/**< ピッチ										*/
		Pan3dAngle				=  2,	/**< パンニング3D角度							*/
		Pan3dDistance			=  3,	/**< パンニング3D距離							*/
		Pan3dVolume				=  4,	/**< パンニング3Dボリューム						*/
		BusSendLevel0			=  9,	/**< バスセンドレベル0							*/
		BusSendLevel1			= 10,	/**< バスセンドレベル1							*/
		BusSendLevel2			= 11,	/**< バスセンドレベル2							*/
		BusSendLevel3			= 12,	/**< バスセンドレベル3							*/
		BusSendLevel4			= 13,	/**< バスセンドレベル4							*/
		BusSendLevel5			= 14,	/**< バスセンドレベル5							*/
		BusSendLevel6			= 15,	/**< バスセンドレベル6							*/
		BusSendLevel7			= 16,	/**< バスセンドレベル7							*/
		BandPassFilterCofLow	= 17,	/**< バンドパスフィルタの低域カットオフ周波数	*/
		BandPassFilterCofHigh	= 18,	/**< バンドパスフィルタの高域カットオフ周波数	*/
		BiquadFilterType		= 19,	/**< バイクアッドフィルタのフィルタタイプ		*/
		BiquadFilterFreq		= 20,	/**< バイクアッドフィルタの周波数				*/
		BiquadFIlterQ			= 21,	/**< バイクアッドフィルタのQ値					*/
		BiquadFilterGain		= 22,	/**< バイクアッドフィルタのゲイン				*/
		EnvelopeAttackTime		= 23,	/**< エンベロープのアタックタイム				*/
		EnvelopeHoldTime		= 24,	/**< エンベロープのホールドタイム				*/
		EnvelopeDecayTime		= 25,	/**< エンベロープのディケイタイム				*/
		EnvelopeReleaseTime		= 26,	/**< エンベロープのリリースタイム				*/
		EnvelopeSustainLevel	= 27,	/**< エンベロープのサスティンレベル				*/
		StartTime				= 28,	/**< 再生開始位置								*/
		Priority				= 31,	/**< ボイスプライオリティ						*/
	}

	/*JP
	 * <summary>スピーカーID</summary>
	 * \par 説明:
	 * 音声を出力するスピーカーを指定するためのIDです。<br>
	 * ::CriAtomExPlayer::SetSendLevel 関数で利用します。
	 * \sa CriAtomExPlayer::SetSendLevel
	 */
	public enum Speaker {
		FrontLeft			= 0,	/**< フロントレフトスピーカー			*/
		FrontRight			= 1,	/**< フロントライトスピーカー			*/
		FrontCenter			= 2,	/**< フロントセンタースピーカー			*/
		LowFrequency		= 3,	/**< LFE（≒サブウーハー）				*/
		SurroundLeft		= 4,	/**< サラウンドレフトスピーカー			*/
		SurroundRight		= 5,	/**< サラウンドライトスピーカー			*/
		SurroundBackLeft	= 6,	/**< サラウンドバックレフトスピーカー	*/
		SurroundBackRight	= 7,	/**< サラウンドバックライトスピーカー	*/
	}

	/**
	 * <summary>フォーマット種別</summary>
	 * \par 説明:
	 * AtomExプレーヤで再生する音声のフォーマットを指定するためのデータ型です。<br/>
	 * ::CriAtomExPlayer::SetFormat 関数で利用します。<br/>
	 * \sa CriAtomExPlayer::SetFormat
	 */
	public enum Format : uint {
		ADX			= 0x00000001,		/**< ADX				*/
		HCA			= 0x00000003,		/**< HCA				*/
		HCA_MX		= 0x00000004,		/**< HCA-MX				*/
	}
	
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct FormatInfo {
		public Format format;			/**< フォーマット種別		*/
		public int samplingRate;		/**< サンプリング周波数		*/
		public long numSamples;			/**< 総サンプル数			*/
		public long loopOffset;			/**< ループ開始サンプル		*/
		public long loopLength;			/**< ループ区間サンプル数	*/
		public int numChannels;			/**< チャンネル数			*/
		public uint reserved;			/**< 予約領域				*/
	}

	/**
	 * <summary>AISACコントロール情報取得用構造体</summary>
	 * \par 説明:
	 * AISACコントロール情報を取得するための構造体です。<br/>
	 * ::CriAtomExAcb::GetUsableAisacControl 関数に引数として渡します。<br/>
	 * \sa CriAtomExAcb::GetUsableAisacControl
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct AisacControlInfo {
		[MarshalAs(UnmanagedType.LPStr)]
		public readonly string	name;		/**< AISACコントロール名	*/
		public uint				id;			/**< AISACコントロールID	*/
		
		public AisacControlInfo(byte[] data, int startIndex)
		{
			if (IntPtr.Size == 4) {
				this.name	= Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 0)));
				this.id	= BitConverter.ToUInt32(data, startIndex + 4);
			} else {
				this.name	= Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 0)));
				this.id	= BitConverter.ToUInt32(data, startIndex + 8);
			}
		}
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CuePos3dInfo
	{
		public float coneInsideAngle;		/**< コーン内部角度				*/
		public float coneOutsideAngle;		/**< コーン外部角度				*/
		public float minDistance;			/**< 最小減衰距離				*/
		public float maxDistance;			/**< 最大減衰距離				*/
		public float dopplerFactor;			/**< ドップラー係数				*/
		public ushort distanceAisacControl;	/**< 距離減衰AISACコントロール	*/
		public ushort listenerBaseAngleAisacControl;	/**< リスナー基準角度AISACコントロール	*/
		public ushort sourceBaseAngleAisacControl;		/**< 音源基準角度AISACコントロール		*/
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public ushort[]	reserved;						/**< 予約領域		*/
		
		public CuePos3dInfo(byte[] data, int startIndex)
		{
			this.coneInsideAngle	= BitConverter.ToSingle(data, startIndex + 0);
			this.coneOutsideAngle	= BitConverter.ToSingle(data, startIndex + 4);
			this.minDistance	= BitConverter.ToSingle(data, startIndex + 8);
			this.maxDistance	= BitConverter.ToSingle(data, startIndex + 12);
			this.dopplerFactor	= BitConverter.ToSingle(data, startIndex + 16);
			this.distanceAisacControl	= BitConverter.ToUInt16(data, startIndex + 20);
			this.listenerBaseAngleAisacControl	= BitConverter.ToUInt16(data, startIndex + 22);
			this.sourceBaseAngleAisacControl	= BitConverter.ToUInt16(data, startIndex + 24);
			this.reserved	= new ushort[1];
			for (int i = 0; i < 1; ++i) {
				reserved[i] = BitConverter.ToUInt16(data, startIndex + 26 + (2 * i));
			}
		}
	}
	
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct GameVariableInfo
	{	
		[MarshalAs(UnmanagedType.LPStr)]
		public readonly string	name;		/**< ゲーム変数名	*/
		public uint 			id;			/**< ゲーム変数ID	*/
		public float			gameValue;	/**< ゲーム変数値	*/
		
		public GameVariableInfo(byte[] data, int startIndex)
		{
			if (IntPtr.Size == 4) {
				this.name	= Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 0)));
				this.id	= BitConverter.ToUInt32(data, startIndex + 4);
				this.gameValue	= BitConverter.ToSingle(data, startIndex + 8);
			} else {
				this.name	= Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 0)));
				this.id	= BitConverter.ToUInt32(data, startIndex + 8);
				this.gameValue	= BitConverter.ToSingle(data, startIndex + 12);
			}
		}

		public GameVariableInfo(string name, uint id, float gameValue)
		{
			this.name		= name;
			this.id			= id;
			this.gameValue	= gameValue;
		}
	}
	
	/**
	 * <summary>キュータイプ</summary>
	 * \sa CriAtomEx::CueInfo
	 */
	public enum CueType
	{
		Polyphonic,				/**< ポリフォニック											*/	
		Sequential,				/**< シーケンシャル											*/
		Shuffle,				/**< シャッフル再生											*/
		Random,					/**< ランダム												*/
		RandomNoRepeat,			/**< ランダム非連続（前回再生した音以外をランダムに鳴らす）	*/
		Switch,					/**< スイッチ再生（ゲーム変数を参照して再生トラックの切り替える）	*/
		ComboSequential,		/**< コンボシーケンシャル（「コンボ時間」内に連続コンボが決まるとシーケンシャル、最後までいくと「コンボループバック」地点に戻る）*/
	}

	/**
	 * <summary>キュー情報</summary>
	 * \par 説明:
	 * キューの詳細情報です。<br/>
	 * \sa CriAtomExAcb::GetCueInfo
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CueInfo
	{
		public int				id;							/**< キューID				*/
		public CueType			type;						/**< タイプ					*/
		[MarshalAs(UnmanagedType.LPStr)]
		public readonly string	name;						/**< キュー名				*/
		[MarshalAs(UnmanagedType.LPStr)]
		public readonly string	userData;					/**< ユーザーデータ			*/
		public long				length;						/**< 長さ(msec)				*/
		
		/* 最大再生毎カテゴリ参照数:CRIATOMEXCATEGORY_MAX_CATEGORIES_PER_PLAYBACKは16 */
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public ushort[]			categories;					/**< カテゴリインデックス			*/
		
		public short			numLimits;					/**< キューリミット					*/
		public ushort			numBlocks;					/**< ブロック数						*/
		public byte				priority;					/**< カテゴリキュープライオリティ	*/
		public byte				headerVisibility;			/**< ヘッダー公開フラグ				*/
		public byte				ignore_player_parameter;	/**< プレーヤパラメータ無効化フラグ	*/
		public byte				probability;				/**< 再生確率						*/
		public CuePos3dInfo		pos3dInfo;					/**< 3D情報							*/
		public GameVariableInfo gameVariableInfo;			/**< ゲーム変数						*/

		public CueInfo(byte[] data, int startIndex)
		{
			if (IntPtr.Size == 4) {
				this.id	= BitConverter.ToInt32(data, startIndex + 0);
				this.type	= (CueType)BitConverter.ToInt32(data, startIndex + 4);
				this.name	= Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 8)));
				this.userData	= Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt32(data, startIndex + 12)));
				this.length	= BitConverter.ToInt64(data, startIndex + 16);
				this.categories	= new ushort[16];
				for (int i = 0; i < 16; ++i) {
					categories[i] = BitConverter.ToUInt16(data, startIndex + 24 + (2 * i));
				}
				this.numLimits	= BitConverter.ToInt16(data, startIndex + 56);
				this.numBlocks	= BitConverter.ToUInt16(data, startIndex + 58);
				this.priority					= data[startIndex + 60];
				this.headerVisibility			= data[startIndex + 61];
				this.ignore_player_parameter	= data[startIndex + 62];
				this.probability				= data[startIndex + 63];
				this.pos3dInfo	= new CuePos3dInfo(data, startIndex + 64);
				this.gameVariableInfo	= new GameVariableInfo(data, startIndex + 92);
			} else {
				this.id	= BitConverter.ToInt32(data, startIndex + 0);
				this.type	= (CueType)BitConverter.ToInt32(data, startIndex + 4);
				this.name	= Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 8)));
				this.userData	= Marshal.PtrToStringAnsi(new IntPtr(BitConverter.ToInt64(data, startIndex + 16)));
				this.length	= BitConverter.ToInt64(data, startIndex + 24);
				this.categories	= new ushort[16];
				for (int i = 0; i < 16; ++i) {
					categories[i] = BitConverter.ToUInt16(data, startIndex + 32 + (2 * i));
				}
				this.numLimits	= BitConverter.ToInt16(data, startIndex + 64);
				this.numBlocks	= BitConverter.ToUInt16(data, startIndex + 66);
				this.priority					= data[startIndex + 68];
				this.headerVisibility			= data[startIndex + 69];
				this.ignore_player_parameter	= data[startIndex + 70];
				this.probability				= data[startIndex + 71];
				this.pos3dInfo	= new CuePos3dInfo(data, startIndex + 72);
				this.gameVariableInfo	= new GameVariableInfo(data, startIndex + 104);
			}
		}
	}
	
	/**
	 * <summary>音声波形情報</summary>
	 * \par 説明:
	 * 波形情報は、各キューから再生される音声波形の詳細情報です。<br/>
	 * \sa CriAtomExAcb::GetWaveformInfo
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct WaveformInfo
	{
		public int		waveId;				/**< 波形データID			*/
		public uint		format;				/**< フォーマット種別		*/
		public int		samplingRate;		/**< サンプリング周波数		*/
		public int		numChannels;		/**< チャンネル数			*/
		public long		numSamples;			/**< トータルサンプル数		*/
		public bool		streamingFlag;		/**< ストリーミングフラグ	*/
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[]	reserved;			/**< 予約領域				*/
		
		public WaveformInfo(byte[] data, int startIndex)
		{
			this.waveId	= BitConverter.ToInt32(data, startIndex + 0);
			this.format	= BitConverter.ToUInt32(data, startIndex + 4);
			this.samplingRate	= BitConverter.ToInt32(data, startIndex + 8);
			this.numChannels	= BitConverter.ToInt32(data, startIndex + 12);
			this.numSamples	= BitConverter.ToInt64(data, startIndex + 16);
			this.streamingFlag	= BitConverter.ToInt32(data, startIndex + 24) != 0;
			this.reserved	= new uint[1];
			for (int i = 0; i < 1; ++i) {
				reserved[i] = BitConverter.ToUInt32(data, startIndex + 28 + (4 * i));
			}
		}
	}
	
	/**
	 * <summary>パフォーマンス情報</summary>
	 * \par 説明:
	 * パフォーマンス情報を取得するための構造体です。<br/>
	 * ::CriAtomEx::GetPerformanceInfo 関数で利用します。
	 * \sa ::CriAtomEx::GetPerformanceInfo
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct PerformanceInfo
	{
		public uint serverProcessCount;		/**<サーバ処理実行回数									*/
		public uint lastServerTime;			/**<サーバ処理時間の最終計測値（マイクロ秒単位）		*/
		public uint maxServerTime;			/**<サーバ処理時間の最大値（マイクロ秒単位）			*/
		public uint averageServerTime;		/**<サーバ処理時間の平均値（マイクロ秒単位）			*/
		public uint lastServerInterval;		/**<サーバ処理実行間隔の最終計測値（マイクロ秒単位）	*/
		public uint maxServerInterval;		/**<サーバ処理実行間隔の最大値（マイクロ秒単位）		*/
		public uint averageServerInterval;	/**<サーバ処理実行間隔の平均値（マイクロ秒単位）		*/
		
		public PerformanceInfo(byte[] data, int startIndex)
		{
			this.serverProcessCount	= BitConverter.ToUInt32(data, startIndex + 0);
			this.lastServerTime	= BitConverter.ToUInt32(data, startIndex + 4);
			this.maxServerTime	= BitConverter.ToUInt32(data, startIndex + 8);
			this.averageServerTime	= BitConverter.ToUInt32(data, startIndex + 12);
			this.lastServerInterval	= BitConverter.ToUInt32(data, startIndex + 16);
			this.maxServerInterval	= BitConverter.ToUInt32(data, startIndex + 20);
			this.averageServerInterval	= BitConverter.ToUInt32(data, startIndex + 24);
		}
	}

	/**
	 * <summary>ACFファイルの登録</summary>
	 * <param name="binder">バインダ</param>
	 * <param name="acfPath">ACFファイルのファイルパス</param>
	 * \par 説明:
	 * ACFファイルをロードし、ライブラリに取り込みます。<br/>
	 * \sa CriAtomEx::UnregisterAcf
	 */
	public static void RegisterAcf(CriFsBinder binder, string acfPath)
	{
		IntPtr binderHandle = (binder != null) ? binder.nativeHandle : IntPtr.Zero;
		criAtomEx_RegisterAcfFile(binderHandle, acfPath, IntPtr.Zero, 0);
	}

	/**
	 * <summary>ACFデータの登録</summary>
	 * <param name="acfData">ACFデータ</param>
	 * \par 説明:
	 * メモリ上に配置されたACFデータをロードし、ライブラリに取り込みます。<br/>
	 * \sa CriAtomEx::UnregisterAcf
	 */
	public static void RegisterAcf(byte[] acfData)
	{
		criAtomEx_RegisterAcfData(acfData, acfData.Length, IntPtr.Zero, 0);
	}

	/**
	 * <summary>ACFファイルの登録解除</summary>
	 * \par 説明:
	 * ACFファイルの登録を解除します。<br/>
	 * \sa CriAtomEx::RegisterAcf
	 */
	public static void UnregisterAcf()
	{
		criAtomEx_UnregisterAcf();
	}
	
	/**
	 * <summary>DSPバス設定のアタッチ</summary>
	 * <param name="settingName">DSPバス設定の名前</param>
	 * \par 説明:
	 * DSPバス設定からDSPバスを構築してサウンドレンダラにアタッチします。<br/>
	 * 本関数を実行するには、あらかじめ CriAtomEx::RegisterAcf 
	 * 関数でACF情報を登録しておく必要があります<br/>
	 * \code
	 *		：
	 * 	// ACFファイルの読み込みと登録
	 * 	CriAtomEx.RegisterAcf("Sample.acf");
	 * 	
	 * 	// DSPバス設定の適用
	 * 	CriAtomEx.AttachDspBusSetting("DspBusSetting_0");
	 * 		：
	 * \endcode
	 * \attention
	 * 本関数は完了復帰型の関数です。<br/>
	 * 本関数を実行すると、しばらくの間Atomライブラリのサーバ処理がブロックされます。<br/>
	 * 音声再生中に本関数を実行すると、音途切れ等の不具合が発生する可能性があるため、
	 * 本関数の呼び出しはシーンの切り替わり等、負荷変動を許容できるタイミングで行ってください。<br/>
	 * \sa CriAtomEx::DetachDspBusSetting, CriAtomEx::RegisterAcf
	 */
	public static void AttachDspBusSetting(string settingName)
	{
		criAtomEx_AttachDspBusSetting(settingName, IntPtr.Zero, 0);
	}

	/**
	 * <summary>DSPバス設定のデタッチ</summary>
	 * \par 説明:
	 * DSPバス設定をデタッチします。<br/>
	 * \attention
	 * 本関数は完了復帰型の関数です。<br/>
	 * 本関数を実行すると、しばらくの間Atomライブラリのサーバ処理がブロックされます。<br/>
	 * 音声再生中に本関数を実行すると、音途切れ等の不具合が発生する可能性があるため、
	 * 本関数の呼び出しはシーンの切り替わり等、負荷変動を許容できるタイミングで行ってください。
	 * \sa CriAtomEx::AttachDspBusSetting
	 */
	public static void DetachDspBusSetting()
	{
		criAtomEx_DetachDspBusSetting();
	}

	/**
	 * <summary>DSPバススナップショットの適用 </summary>
	 * <param name="snapshot_name">DSPバススナップショット名</param>
	 * <param name="time_ms">スナップショットが完全に反映されるまでの時間（ミリ秒）</param>
	 * \par 説明:
	 * DSPバススナップショットを適用します。<br/>
	 * 本関数を呼び出すとスナップショットのパラメータに変化します。
	 * 完全に変化を終えるまでに、time_ms ミリ秒かかります。
	 */
	public static void ApplyDspBusSnapshot(string snapshot_name, int time_ms)
	{
		criAtomEx_ApplyDspBusSnapshot(snapshot_name, time_ms);
	}

	/**
	 * <summary>ゲーム変数の総数の取得</summary>
	 * <returns>ゲーム変数の総数</returns>
	 * \par 説明:
	 * ACFファイル内に登録されているゲーム変数の総数を取得します。<br>
	 * \attention
	 * 本関数を実行する前に、ACFファイルを登録しておく必要があります。<br>
	 * ACFファイルが登録されていない場合、-1が返ります。
	 */
	public static int GetNumGameVariables()
	{
		return criAtomEx_GetNumGameVariables();
	}

	/**
	 * <summary>ゲーム変数情報の取得（インデックス指定）</summary>
	 * <param name="index">ゲーム変数インデックス</param>
	 * <param name="info">ゲーム変数情報</param>
	 * <returns>情報が取得できたかどうか？</returns>
	 * \par 説明:
	 * ゲーム変数インデックスからゲーム変数情報を取得します。<br>
	 * 指定したインデックスのゲーム変数が存在しない場合、falseが返ります。
	 * \attention
	 * 本関数を実行する前に、ACFファイルを登録しておく必要があります。<br/>
	 */
	public static bool GetGameVariableInfo(ushort index, out GameVariableInfo info)
	{
		using (var mem = new CriStructMemory<GameVariableInfo>()) {
			bool result = criAtomEx_GetGameVariableInfo(index, mem.ptr);
			info = new GameVariableInfo(mem.bytes, 0);
			return result;
		}
	}

	/**
	 * <summary>ゲーム変数の取得</summary>
	 * <param name="game_variable_id">ゲーム変数ID</param>
	 * <returns>ゲーム変数値</returns>
	 * \par 説明:
	 * ACFファイル内に登録されているゲーム変数値を取得します。<br/>
	 * \attention
	 * 本関数を実行する前に、ACFファイルを登録しておく必要があります。<br/>
	 */
	public static float GetGameVariable(uint game_variable_id)
	{
		return criAtomEx_GetGameVariableById(game_variable_id);
	}

	/**
	 * <summary>ゲーム変数の取得</summary>
	 * <param name="game_variable_name">ゲーム変数名</param>
	 * <returns>ゲーム変数値</returns>
	 * \par 説明:
	 * ACFファイル内に登録されているゲーム変数値を取得します。<br/>
	 * \attention
	 * 本関数を実行する前に、ACFファイルを登録しておく必要があります。<br/>
	 */
	public static float GetGameVariable(string game_variable_name)
	{
		return criAtomEx_GetGameVariableByName(game_variable_name);
	}

	/**
	 * <summary>ゲーム変数の設定</summary>
	 * <param name="game_variable_id">ゲーム変数ID</param>
	 * <param name="game_variable_value">ゲーム変数値</param>
	 * \par 説明:
	 * ACFファイル内に登録されているゲーム変数に値を設定します。<br>
	 * 設定可能な範囲は0.0f～1.0fの間です。
	 * \attention
	 * 本関数を実行する前に、ACFファイルを登録しておく必要があります。<br>
	 */
	public static void SetGameVariable(uint game_variable_id, float game_variable_value)
	{
		criAtomEx_SetGameVariableById(game_variable_id, game_variable_value);
	}
	
	/**
	 * <summary>ゲーム変数の設定</summary>
	 * <param name="game_variable_name">ゲーム変数名</param>
	 * <param name="game_variable_value">ゲーム変数値</param>
	 * \par 説明:
	 * ACFファイル内に登録されているゲーム変数に値を設定します。<br>
	 * 設定可能な範囲は0.0f～1.0fの間です。
	 * \attention
	 * 本関数を実行する前に、ACFファイルを登録しておく必要があります。<br>
	 */
	public static void SetGameVariable(string game_variable_name, float game_variable_value)
	{
		criAtomEx_SetGameVariableByName(game_variable_name, game_variable_value);
	}

	/**
	 * <summary>乱数種の設定</summary>
	 * <param name="seed">乱数種</param>
	 * \par 説明:
	 * CRI Atomライブラリ全体で共有する疑似乱数生成器に乱数種を設定します。<br>
	 * 乱数種を設定することにより、各種ランダム再生処理に再現性を持たせることができます。<br>
	 * AtomExプレーヤごとに再現性を持たせたい場合は、 ::CriAtomExPlayer::SetRandomSeed 関数を使用してください。
	 * <br>
	 * 再現性の必要がなく、実行ごとに乱数種を切り替えたい場合は、本関数
	 * ではなく、 ::CriAtomConfig::useRandomSeedWithTime プロパティを使用してください。
	 * <br>
	 * \attention
	 * 本関数は ::CriAtomSource または ::CriAtomExPlayer の生成前に呼び出す必要が
	 * あります。乱数種を設定する前に作成されたものについては影響を受けません。
	 * \sa ::CriAtomExPlayer::SetRandomSeed
	 */
	public static void SetRandomSeed(uint seed)
	{
		criAtomEx_SetRandomSeed(seed);
	}

	/**
	 * <summary>パフォーマンスモニタのリセット</summary>
	 * \par 説明:
	 * 現在までの計測結果を破棄します。<br/>
	 * パフォーマンスモニタは、ライブラリ初期化直後からパフォーマンス情報の取得を開始し、
	 * 計測結果を累積します。<br/>
	 * 以前の計測結果を今後の計測に含めたくない場合には、
	 * 本関数を実行し、累積された計測内容を一旦破棄する必要があります。
	 * \sa CriAtomEx::GetPerformanceInfo
	 */
	public static void ResetPerformanceMonitor()
	{
		criAtom_ResetPerformanceMonitor();
	}
	
	/**
	 * <summary>パフォーマンス情報の取得</summary>
	 * \par 説明:
	 * パフォーマンス情報を取得します。<br/>
	 * \sa CriAtomEx::PerformanceInfo, CriAtomEx::ResetPerformanceMonitor
	 */
	public static void GetPerformanceInfo(out PerformanceInfo info)
	{
		using (var mem = new CriStructMemory<PerformanceInfo>()) {
			criAtom_GetPerformanceInfo(mem.ptr);
			info = new PerformanceInfo(mem.bytes, 0);
		}
	}

	/**
	 * <summary>[VITA] 出力ボリュームの指定</summary>
	 * \par 説明:
	 * オーディオの最終出力段のボリューム（マスターボリューム）を指定します。<br/>
	 * Atomライブラリで再生する全ての音声に対し、本関数で指定したボリューム値が掛け合わせで適用されます。<br>
	 * デフォルトのボリュームは1.0fです。<br>
	 * \par 注意:
	 * 本関数はVITA専用APIです。
	 */
	public static void SetOutputVolume_VITA(float volume)
	{
	#if !UNITY_EDITOR && UNITY_PSP2
		criAtom_SetOutputVolume_VITA(volume);
	#endif
	}

	/**
	 * <summary>[VITA] BGM出力権の確認</summary>
	 * \par 説明:
	 * BGM出力権の確認を行います。<br/>
	 * trueの場合、BGM出力権を取得していることを意味し、他アプリはBGMポートを使用していない状態です。<br>
	 * falseの場合、BGM出力権が取得できないことを意味し、他アプリがBGMポートを使用している状態です。<br>
	 * <br>
	 * 本関数でBGM出力権の確認後、必要に応じてBGM出力権の要求や、BGM音声のミュートを行ってください。<br>
	 * \par 注意:
	 * 本関数はVITA専用APIです。
	 */
	public static bool IsBgmPortAcquired_VITA()
	{
	#if !UNITY_EDITOR && UNITY_PSP2
		return criAtomUnity_IsBgmPortAcquired_VITA();
	#else
		return true;
	#endif
	}

	/**
	 * <summary>[Android] (旧API) 音声再生遅延の計測処理を有効・無効にする</summary>
	 * <param name="enabled">有効・無効切替フラグ</param>
	 * \attention
	 * 本関数は削除しました。代わりに CriAtomLatencyEstimator APIを使用してください。
	 */
	[Obsolete("CriAtomEx.SetAudioLatencyCheckEnabled_ANDROID() is deprecated, please use CriAtomLatencyEstimator APIs", true)]
	public static void SetAudioLatencyCheckEnabled_ANDROID(bool enabled)
	{
		// do nothing
		return;
	}
	
	/**
	 * <summary>[Android] (旧API) 音声再生遅延時間の推測値の取得</summary>
	 * \attention
	 * 本関数は削除しました。代わりに CriAtomLatencyEstimator APIを使用してください。
	 */
	[Obsolete("CriAtomEx.GetEstimatedSoundLatency_ANDROID() is deprecated, please use CriAtomLatencyEstimator APIs", true)]
	public static int GetEstimatedSoundLatency_ANDROID()
	{
		return -1;
	}

	#region DLL Import

	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomEx_RegisterAcfFile(
		IntPtr binder, string path, IntPtr work, int workSize);

	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomEx_RegisterAcfData(
		byte[] acfData, int acfDataSize, IntPtr work, int workSize);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx_UnregisterAcf();

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx_AttachDspBusSetting(
		string settingName, IntPtr work, int workSize);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx_DetachDspBusSetting();
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx_ApplyDspBusSnapshot(string snapshot_name, int time_ms);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criAtomEx_GetNumGameVariables();
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomEx_GetGameVariableInfo(ushort index, IntPtr game_variable_info);

	[DllImport(CriWare.pluginName)]
	private static extern float criAtomEx_GetGameVariableById(uint game_variable_id);

	[DllImport(CriWare.pluginName)]
	private static extern float criAtomEx_GetGameVariableByName(string game_variable_name);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx_SetGameVariableById(uint game_variable_id, float game_variable_value);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx_SetGameVariableByName(string game_variable_name, float game_variable_value);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx_SetRandomSeed(uint seed);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtom_ResetPerformanceMonitor();

	[DllImport(CriWare.pluginName)]
	private static extern void criAtom_GetPerformanceInfo(IntPtr info);

	#if !UNITY_EDITOR && UNITY_PSP2
	[DllImport(CriWare.pluginName)]
	private static extern void criAtom_SetOutputVolume_VITA(float volume);
	#endif

	#if !UNITY_EDITOR && UNITY_PSP2
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomUnity_IsBgmPortAcquired_VITA();
	#endif

	#if !UNITY_EDITOR && UNITY_ANDROID
	[DllImport(CriWare.pluginName)]
	public static extern void criAtom_EnableSlLatencyCheck_ANDROID(bool sw);
	#endif

	#if !UNITY_EDITOR && UNITY_ANDROID
	[DllImport(CriWare.pluginName)]
	public static extern int criAtom_GetSlBufferConsumptionLatency_ANDROID();
	#endif

	#endregion
}

/**
 * <summary>カテゴリ単位のパラメータ制御を行うためのクラスです。</summary>
 * \par 説明:
 * カテゴリ単位のパラメータ制御を行うためのクラスです。<br/>
 */
public static class CriAtomExCategory
{
	/**
	 * <summary>名前指定によるカテゴリに対するボリューム設定</summary>
	 * <param name="name">カテゴリ名</param>
	 * <param name="volume">ボリューム値</param>
	 * \par 説明:
	 * 名前指定でカテゴリに対してボリュームを設定します。
	 */
	public static void SetVolume(string name, float volume)
	{
		criAtomExCategory_SetVolumeByName(name, volume);
	}

	/**
	 * <summary>ID指定によるカテゴリに対するボリューム設定</summary>
	 * <param name="id">カテゴリID</param>
	 * <param name="volume">ボリューム値</param>
	 * \par説明:
	 * ID指定でカテゴリに対してボリュームを設定します。
	 */
	public static void SetVolume(int id, float volume)
	{
		criAtomExCategory_SetVolumeById(id, volume);
	}

	/**
	 * <summary>名前指定によるカテゴリボリューム取得</summary>
	 * <param name="name">カテゴリ名</param>
	 * <returns>カテゴリボリューム</returns>
	 * \par説明:
	 * 名前指定でカテゴリで適用されるのボリューム値を取得します。
	 */
	public static float GetVolume(string name)
	{
		return criAtomExCategory_GetVolumeByName(name);
	}

	/**
	 * <summary>ID指定によるカテゴリボリューム取得</summary>
	 * <param name="id">カテゴリID</param>
	 * <returns>カテゴリボリューム</returns>
	 * \par説明:
	 * ID指定でカテゴリで適用されるのボリューム値を取得します。
	 */
	public static float GetVolume(int id)
	{
		return criAtomExCategory_GetVolumeById(id);
	}

	/**
	 * <summary>名前指定によるカテゴリミュート状態設定</summary>
	 * <param name="name">カテゴリ名</param>
	 * <param name="mute">ミュート状態（false = ミュート解除、true = ミュート）</param>
	 * \par説明:
	 * 名前指定でカテゴリのミュート状態を設定します。
	 */
	public static void Mute(string name, bool mute)
	{
		criAtomExCategory_MuteByName(name, mute);
	}

	/**
	 * <summary>ID指定によるカテゴリミュート状態設定</summary>
	 * <param name="id">カテゴリID</param>
	 * <param name="mute">ミュート状態（false = ミュート解除、true = ミュート）</param>
	 * \par説明:
	 * ID指定でカテゴリのミュート状態を設定します。
	 */
	public static void Mute(int id, bool mute)
	{
		criAtomExCategory_MuteById(id, mute);
	}

	/**
	 * <summary>名前指定によるカテゴリミュート状態取得</summary>
	 * <param name="name">カテゴリ名</param>
	 * <returns>ミュート状態（false = ミュート中ではない、true = ミュート中）</returns>
	 * \par説明:
	 * 名前指定でカテゴリのミュート状態を取得します。
	 */
	public static bool IsMuted(string name)
	{
		return criAtomExCategory_IsMutedByName(name);
	}

	/**
	 * <summary>ID指定によるカテゴリミュート状態取得</summary>
	 * <param name="id">カテゴリID</param>
	 * <returns>ミュート状態（false = ミュート中ではない、true = ミュート中）</returns>
	 * \par説明:
	 * ID指定でカテゴリのミュート状態を取得します。
	 */
	public static bool IsMuted(int id)
	{
		return criAtomExCategory_IsMutedById(id);
	}

	/**
	 * <summary>名前指定によるカテゴリソロ状態設定</summary>
	 * <param name="name">カテゴリ名</param>
	 * <param name="solo">ソロ状態（false = ソロ解除、true = ソロ）</param>
	 * <param name="muteVolume">他のカテゴリに適用するミュートボリューム値</param>
	 * \par説明:
	 * 名前指定でカテゴリのソロ状態を設定します。<br/>
	 * muteVolume で指定したボリュームは、
	 * 同一カテゴリグループに所属するカテゴリに対して適用されます。
	 */
	public static void Solo(string name, bool solo, float muteVolume)
	{
		criAtomExCategory_SoloByName(name, solo, muteVolume);
	}

	/**
	 * <summary>ID指定によるカテゴリソロ状態設定</summary>
	 * <param name="id">カテゴリID</param>
	 * <param name="solo">ソロ状態（false = ソロ解除、true = ソロ）</param>
	 * <param name="muteVolume">他のカテゴリに適用するミュートボリューム値</param>
	 * \par説明:
	 * ID指定でカテゴリのソロ状態を設定します。<br/>
	 * muteVolume で指定したボリュームは、
	 * 同一カテゴリグループに所属するカテゴリに対して適用されます。
	 */
	public static void Solo(int id, bool solo, float muteVolume)
	{
		criAtomExCategory_SoloById(id, solo, muteVolume);
	}

	/**
	 * <summary>名前指定によるカテゴリソロ状態取得</summary>
	 * <param name="name">カテゴリ名</param>
	 * <returns>ソロ状態（false = ソロ中ではない、true = ソロ中）</returns>
	 * \par説明:
	 * 名前指定でカテゴリのソロ状態を取得します。
	 */
	public static bool IsSoloed(string name)
	{
		return criAtomExCategory_IsSoloedByName(name);
	}

	/**
	 * <summary>ID指定によるカテゴリソロ状態取得</summary>
	 * <param name="id">カテゴリID</param>
	 * <returns>ソロ状態（false = ソロ中ではない、true = ソロ中）</returns>
	 * \par説明:
	 * ID指定でカテゴリのソロ状態を取得します。
	 */
	public static bool IsSoloed(int id)
	{
		return criAtomExCategory_IsSoloedById(id);
	}

	/**
	 * <summary>名前指定によるカテゴリのポーズ／ポーズ解除</summary>
	 * <param name="name">カテゴリ名</param>
	 * <param name="pause">スイッチ（false = ポーズ解除、true = ポーズ）</param>
	 * \par説明:
	 * 名前指定でカテゴリのポーズ／ポーズ解除を行います。<br/>
	 * カテゴリを名前で指定する以外は、
	 * ::CriAtomExCategory::Pause(int, bool)  関数と仕様は同じです。<br/>
	 * \sa CriAtomExCategory::Pause(int, bool)
	 */
	public static void Pause(string name, bool pause)
	{
		criAtomExCategory_PauseByName(name, pause);
	}

	/**
	 * <summary>ID指定によるカテゴリのポーズ／ポーズ解除</summary>
	 * <param name="id">カテゴリID</param>
	 * <param name="pause">スイッチ（false = ポーズ解除、true = ポーズ）</param>
	 * \par説明:
	 * ID指定でカテゴリのポーズ／ポーズ解除を行います。<br/>
	 * \par 備考:
	 * カテゴリのポーズは、AtomExプレーヤ／再生音のポーズ
	 * （ ::CriAtomExPlayer::Pause 関数や ::CriAtomExPlayback::Pause 関数でのポーズ）とは独立して扱われ、
	 * 音声の最終的なポーズ状態は、それぞれのポーズ状態を考慮して決まります。<br/>
	 * すなわち、どちらかがポーズ状態ならポーズ、どちらもポーズ解除状態ならポーズ解除、となります。
	 * \sa CriAtomExCategory::Pause(string, bool)
	 */
	public static void Pause(int id, bool pause)
	{
		criAtomExCategory_PauseById(id, pause);
	}

	/**
	 * <summary>ID指定によるカテゴリのポーズ状態取得</summary>
	 * <param name="id">カテゴリID</param>
	 * <returns>ポーズ状態（false = ポーズ中ではない、true = ポーズ中）</returns>
	 * \par説明:
	 * ID指定でカテゴリのポーズ状態を取得します。
	 */
	public static bool IsPaused(string name)
	{
		return criAtomExCategory_IsPausedByName(name);
	}

	/**
	 * <summary>名前指定によるカテゴリのポーズ／ポーズ解除</summary>
	 * <param name="name">カテゴリ名</param>
	 * <returns>ポーズ状態（false = ポーズ中ではない、true = ポーズ中）</returns>
	 * \par説明:
	 * 名前指定でカテゴリのポーズ状態を取得します。
	 */
	public static bool IsPaused(int id)
	{
		return criAtomExCategory_IsPausedById(id);
	}

	/**
	 * <summary>名前指定によるカテゴリに対するAISACコントロール値設定</summary>
	 * <param name="name">カテゴリ名</param>
	 * <param name="controlName">AISACコントロール名</param>
	 * <param name="value">AISACコントロール値</param>
	 * \par説明:
	 * 名前指定でカテゴリに対してAISACコントロール値を設定します。<br/>
	 * カテゴリおよびAISACコントロールを名前で指定する以外は、
	 * ::criAtomExCategory::SetAisacById 関数と仕様は同じです。<br/>
	 * \par 備考:
	 * カテゴリを名前、AISACコントロールをIDで指定したい場合、
	 * ::criAtomExAcf::GetAisacControlNameById 関数にて変換を行ってください。
	 * \sa
	 * CriAtomExCategory::SetAisac(int, int, float), CriAtomExCategory::AttachAisac
	 */
	public static void SetAisac(string name, string controlName, float value)
	{
		criAtomExCategory_SetAisacControlByName(name, controlName, value);
	}

	/**
	 * <summary>ID指定によるカテゴリに対するAISACコントロール値設定</summary>
	 * <param name="id">カテゴリID</param>
	 * <param name="controlId">AISACコントロールID</param>
	 * <param name="value">AISACコントロール値</param>
	 * \par説明:
	 * ID指定でカテゴリに対してAISACコントロール値を設定します。<br/>
	 * \attention
	 * キューやトラックに設定されているAISACに関しては、
	 * プレーヤでのAISACコントロール値設定よりも、
	 * <b>カテゴリのAISACコントロール値を優先して</b>参照します。<br/>
	 * カテゴリにアタッチしたAISACについては、
	 * 常に<b>カテゴリに設定したAISACコントロール値のみ</b>、参照されます。
	 * \sa
	 * CriAtomExCategory::SetAisac(string, string, float), CriAtomExCategory::AttachAisac
	 */
	public static void SetAisac(int id, int controlId, float value)
	{
		criAtomExCategory_SetAisacControlById(id, (ushort)controlId, value);
	}

	#region DLL Import

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExCategory_SetVolumeByName(string name, float volume);
	
	[DllImport(CriWare.pluginName)]
	private static extern float criAtomExCategory_GetVolumeByName(string name);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExCategory_SetVolumeById(int id, float volume);

	[DllImport(CriWare.pluginName)]
	private static extern float criAtomExCategory_GetVolumeById(int id);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExCategory_MuteById(int id, bool mute);

	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExCategory_IsMutedById(int id);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExCategory_MuteByName(string name, bool mute);

	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExCategory_IsMutedByName(string name);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExCategory_SoloById(int id, bool solo, float volume);

	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExCategory_IsSoloedById(int id);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExCategory_SoloByName(string name, bool solo, float volume);

	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExCategory_IsSoloedByName(string name);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExCategory_PauseById(int id, bool pause);

	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExCategory_IsPausedById(int id);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExCategory_PauseByName(string name, bool pause);

	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExCategory_IsPausedByName(string name);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExCategory_SetAisacControlById(int id, ushort controlId, float value);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExCategory_SetAisacControlByName(string name, string controlName, float value);

	#endregion
}

/**
 * <summary>シーケンスデータを制御するためのクラスです。</summary>
 * \par 説明:
 * CRI Atom Craft上で作成したシーケンスデータを使用するためのクラスです。<br/>
 */
public static class CriAtomExSequencer
{
	/**
	 * <summary>シーケンスコールバック</summary>
	 * <param name="eventParamsString">イベントパラメタ文字列</param>	 
	 * \par 説明:
	 * シーケンスコールバック関数型です。<br/>
	 * 引数の文字列には以下の情報が含まれます。<br/>
	 *  -# イベント位置
	 *  -# イベントID
	 *  -# 再生ID
	 *  -# イベントタイプ
	 *  -# イベントタグ文字列
     *  .
	 * 各情報は指定した区切り文字列を挟みながら一つの文字列として連結されて渡ってきます。<br/>
	 * 必要なパラメタを文字列からパースしてご利用ください。<br/>
	 * \sa CriAtomExSequencer::SetEventCallback
	 */
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	public delegate void EventCbFunc(string eventParamsString);

	/**
	 * <summary>シーケンスイベントコールバックの登録</summary>
	 * <param name="func">シーケンスコールバック関数</param>
	 * <param name="separator">イベントパラメタ区切り文字列(最大15文字)</param>
	 * \par 説明:
	 * シーケンスデータに埋め込まれたコールバック情報を受け取るコールバック関数を登録します。<br/>
	 * 登録されたコールバック関数は、コールバックイベントを処理したタイミングで実行されます。<br/>
	 * \par 注意:
	 * コールバック関数は1つしか登録できません。<br/>
	 * 登録操作を複数回行った場合、既に登録済みのコールバック関数が、 後から登録したコールバック関数により上書きされてしまいます。<br/>
	 */
	public static void SetEventCallback(CriAtomExSequencer.EventCbFunc func, string separator = "\t")
	{
		/* MonoBehaviour側に登録 */
		CriAtom.SetEventCallback(func, separator);
	}
}

/**
 * <summary>Atomサウンドレンダラのバス出力を制御するクラスです。</summary>
 * \par 説明:
 * 本クラスでは、Atomサウンドレンダラのバス出力を操作してボリュームを変更したり、レベルを測定することができます。<br/>
 */
public class CriAtomExAsr
{
	[StructLayout(LayoutKind.Sequential)]
	private struct BusAnalyzerConfig
	{
		public int interval;
		public int peakHoldTime;
	}
	
	/**
	 * <summary>レベル測定情報</summary>
	 * DSPバスのレベル測定情報を取得するための構造体です。<br/>
	 * CriAtomExAsr::GetBusAnalyzerInfo 関数で利用します。
	 * \par 備考:
	 * 各レベル値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br/>
	 * 以下のコードでデシベル表記に変換することができます。<br/>
	 * dB = 10.0f * log10f(level);
	 * \sa CriAtomExAsr::GetBusAnalyzerInfo
	 */
	[StructLayout(LayoutKind.Sequential)]
	public struct BusAnalyzerInfo
	{
		public int numChannels;					/**< 有効チャンネル数		*/
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public float[] rmsLevels;				/**< RMSレベル				*/
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public float[] peakLevels;				/**< ピークレベル			*/
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public float[] peakHoldLevels;			/**< ピークホールドレベル	*/
		
		public BusAnalyzerInfo(byte[] data)
		{
			if (data != null) {
				this.numChannels = BitConverter.ToInt32(data, 0);
				this.rmsLevels = new float[8];
				for (int i = 0; i < 8; i++) {
					this.rmsLevels[i] = BitConverter.ToSingle(data, 4 + i * 4);
				}
				this.peakLevels = new float[8];
				for (int i = 0; i < 8; i++) {
					this.peakLevels[i] = BitConverter.ToSingle(data, 36 + i * 4);
				}
				this.peakHoldLevels = new float[8];
				for (int i = 0; i < 8; i++) {
					this.peakHoldLevels[i] = BitConverter.ToSingle(data, 68 + i * 4);
				}
			} else {
				this.numChannels = 0;
				this.rmsLevels = new float[8];
				this.peakLevels = new float[8];
				this.peakHoldLevels = new float[8];
			}
		}
	}
	
	/**
	 * <summary>レベル測定機能の追加</summary>
	 * <param name="interval">測定間隔（ミリ秒）</param>
	 * <param name="peakHoldTime">ピークホールドレベルのホールド時間（ミリ秒）</param>
	 * \par 説明:
	 * DSPバスにレベル測定機能を追加し、レベル測定処理を開始します。<br/>
	 * 本関数を実行後、 CriAtomExAsr::GetBusAnalyzerInfo 関数を実行することで、
	 * RMSレベル（音圧）、ピークレベル（最大振幅）、ピークホールドレベルを
	 * 取得することが可能です。
	 * 複数DSPバスのレベルを計測するには、DSPバスごとに本関数を呼び出す必要があります。
	 * \sa CriAtomExAsr::GetBusAnalyzerInfo, CriAtomExAsr::DetachBusAnalyzer
	 */
	public static void AttachBusAnalyzer(int interval, int peakHoldTime)
	{
		BusAnalyzerConfig config;
		config.interval = 50;
		config.peakHoldTime = 1000;
		for (int i = 0; i < 8; i++) {
			criAtomExAsr_AttachBusAnalyzer(i, ref config);
		}
	}
	
	/**
	 * <summary>レベル測定機能の削除</summary>
	 * \par 説明:
	 * DSPバスからレベル測定機能を削除します。
	 * \sa CriAtomExAsr::AttachBusAnalyzer
	 */
	public static void DetachBusAnalyzer()
	{
		for (int i = 0; i < 8; i++) {
			criAtomExAsr_DetachBusAnalyzer(i);
		}
	}
	
	/**
	 * <summary>レベル測定結果の取得</summary>
	 * <param name="bus">DSPバス番号</param>
	 * <param name="info">レベル測定結果</param>
	 * \par 説明:
	 * DSPバスからレベル測定機能の結果を取得します。
	 * \sa CriAtomExAsr::AttachBusAnalyzer
	 */
	public static void GetBusAnalyzerInfo(int bus, out BusAnalyzerInfo info)
	{
		using (var mem = new CriStructMemory<BusAnalyzerInfo>()) {
			criAtomExAsr_GetBusAnalyzerInfo(bus, mem.ptr);
			info = new BusAnalyzerInfo(mem.bytes);
		}
	}
	
	/**
	 * <summary>DSPバスのボリュームの設定</summary>
	 * <param name="bus">DSPバス番号</param>
	 * <param name="volume">ボリューム値</param>
	 * \par 説明:
	 * DSPバスのボリュームを設定します。<br/>
	 * センドタイプがポストボリューム、ポストパンのセンド先に有効です。<br/>
	 * <br/>
	 * ボリューム値には、0.0f～1.0fの範囲で実数値を指定します。<br/>
	 * ボリューム値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br/>
	 * 例えば、1.0fを指定した場合、原音はそのままのボリュームで出力されます。<br/>
	 * 0.5fを指定した場合、原音波形の振幅を半分にしたデータと同じ音量（-6dB）で
	 * 音声が出力されます。<br/>
	 * 0.0fを指定した場合、音声はミュートされます（無音になります）。<br/>
	 * ボリュームのデフォルト値はCRI Atom Craftで設定した値です。<br/>
	 */
	public static void SetBusVolume(int bus, float volume)
	{
		criAtomExAsr_SetBusVolume(bus, volume);
	}
	
	/**
	 * <summary>DSPバスのセンドレベルの設定</summary>
	 * <param name="bus">DSPバス番号</param>
	 * <param name="sendTo">センド先DSPバス番号</param>
	 * <param name="level">レベル値</param>
	 * \par 説明:
	 * センド先DSPバスに音声データを送る際のレベルを設定します。<br/>
	 * <br/>
	 * レベル値には、0.0f～1.0fの範囲で実数値を指定します。<br/>
	 * レベル値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br/>
	 * 例えば、1.0fを指定した場合、原音はそのままのレベルで出力されます。<br/>
	 * 0.5fを指定した場合、原音波形の振幅を半分にしたデータと同じ音量（-6dB）で
	 * 音声が出力されます。<br/>
	 * 0.0fを指定した場合、音声はミュートされます（無音になります）。<br/>
	 * レベルのデフォルト値はCRI Atom Craftで設定した値です。<br/>
	 */
	public static void SetBusSendLevel(int bus, int sendTo, float level)
	{
		criAtomExAsr_SetBusSendLevel(bus, sendTo, level);
	}

	/**
	 * <summary>DSPバスのレベル行列の設定</summary>
	 * <param name="bus">bus_no</param>
	 * <param name="input_channels">入力チャンネル数</param>
	 * <param name="output_channels">出力チャンネル数</param>
	 * <param name="matrix">レベル行列を1次元に表したレベル値の配列</param>
	 * \par 説明:
	 * DSPバスのレベル行列を設定します。<br/>
	 * センドタイプがポストパンのセンド先に有効です。<br/>
	 * <br/>
	 * レベルマトリックスは、音声データの各チャンネルの音声を、どのスピーカーから
	 * どの程度の音量で出力するかを指定するための仕組みです。<br/>
	 * matrixは[input_channels * output_channels]の配列です。<br/>
	 * 入力チャンネルch_inから出力チャンネルch_outにセンドされるレベルは
	 * matrix[ch_in * output_channels + ch_out]にセットします。<br/>
	 * レベル行列のデフォルト値は単位行列です。<br/>
	 * <br/>
	 * レベル値には、0.0f〜1.0fの範囲で実数値を指定します。<br/>
	 * レベル値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br/>
	 * 例えば、1.0fを指定した場合、原音はそのままのレベルで出力されます。<br/>
	 * 0.5fを指定した場合、原音波形の振幅を半分にしたデータと同じ音量（-6dB）で
	 * 音声が出力されます。<br/>
	 * 0.0fを指定した場合、音声はミュートされます（無音になります）。<br/>
	 */
	public static void SetBusMatrix(int bus, int inputChannels, int outputChannels, float[] matrix)
	{
		criAtomExAsr_SetBusMatrix(bus, inputChannels, outputChannels, matrix);
	}

	#region DLL Import

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAsr_AttachBusAnalyzer(
		int bus_no, ref BusAnalyzerConfig config);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAsr_DetachBusAnalyzer(int bus_no);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAsr_GetBusAnalyzerInfo(
		int bus_no, IntPtr info);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAsr_SetBusVolume(
		int bus_no, float volume);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAsr_SetBusSendLevel(
		int bus_no, int sendto_no, float level);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAsr_SetBusMatrix(
		int bus_no,
		int input_channels,
		int output_channels,
		[MarshalAs(UnmanagedType.LPArray)] float[] matrix
		);
	#endregion
}

/**
 * <summary>音声再生の遅延推測値を取得するためのクラスです。</summary>
 * \par 説明:
 * 本クラスでは、Atomサウンドレンダラのバス出力を操作してボリュームを変更したり、
 * レベルを測定することができます。<br/>
 */
public static class CriAtomExLatencyEstimator
{
	/**
	 * <summary>ステータス</summary>
	 * \par 説明:
	 * 遅延推測処理の状態を示す値です。<br/>
	 * ::CriAtomExLatencyEstimator::GetCurrentInfo 関数で取得可能です。<br/>
	 * <br/>
	 */
	public enum Status {
		Stop,						/**<初期状態/停止状態	*/
		Processing,					/**<遅延時間を推測中	*/
		Done,						/**<遅延時間の推測完了	*/
		Error,						/**<エラー				*/
	}

    /**
     * <summary>ステータス</summary>
     * \par 説明:
     * 遅延推測処理の情報を表現する構造体です。<br/>
     * 推測モジュールの実行状態と、推測結果のレイテンシ(推測値)を保持します。単位はミリ秒です。
     * ::CriAtomExLatencyEstimator::GetCurrentInfo 関数で取得可能です。<br/>
     * <br/>
     */
    [StructLayout(LayoutKind.Sequential)]
	public struct EstimatorInfo
	{
		public Status status;	/**<遅延推測モジュールの状態	*/
		public uint estimated_latency;	/**<推測結果のレイテンシ（単位：ミリ秒） */
	}

	/**
	 * <summary>遅延推測処理の初期化</summary>
	 * \par 呼び出し条件：
	 * 本関数はプラグインの初期化後に呼び出してください。
	 * \par 説明:
	 * 音声再生の遅延推測処理を開始します。<br/>
	 * <br/>
	 * CriAtomExLatencyEstimatorクラスを使用して音声の遅延推測値を取得する場合、
	 * 必ず本関数で初期化を行う必要があります。<br/>
	 * 推測値が取得できた、あるいはエラーが発生した場合は、CriAtomExLatencyEstimator.Finalize 
	 * 関数を呼び出してください。<br/>
	 * \par 備考:
	 * 本関数の多重呼び出しを許容しますが、呼び出し回数を内部でカウントしており、
	 * 実際の初期化処理が実行されるのは、最初の呼び出しの時だけになります。<br/>
	 * \sa CriAtomExLatencyEstimator.FinalizeModule
	 */
	public static void InitializeModule()
	{
	#if !UNITY_EDITOR && UNITY_ANDROID
		criAtomLatencyEstimator_Initialize_ANDROID();
	#endif
	}

	/**
	 * <summary>遅延推測処理の終了</summary>
	 * \par 説明:
	 * 音声再生の遅延推測処理を終了します。<br/>
	 * <br/>
	 * 遅延推測値の取得が完了したら、本関数を呼び出し推測処理を終了させてください。
	 * また、エラーが発生した場合や、推測処理を中断させる場合にも本関数を呼び出してください。
	 * \par 備考:
	 * CriAtomExLatencyEstimator.InitializeModule関数を複数回呼び出した場合、内部で呼び出し回数（参照カウント）が
	 * インクリメントされます。参照カウントが0になるまで終了処理は呼び出されませんので、複数回初期化を行った
	 * 場合には参照カウントが0になるまで本関数を呼び出してください。
	 * \sa CriAtomExLatencyEstimator.InitializeModule
	 */
	public static void FinalizeModule()
	{
	#if !UNITY_EDITOR && UNITY_ANDROID
		criAtomLatencyEstimator_Finalize_ANDROID();
	#endif
	}

	/**
	 * <summary>遅延推測の情報取得</summary>
	 * \par 説明：
	 * 遅延推測処理の現在の情報を取得します。<br/>
	 * 取得できる情報は「遅延推測器の状態」「推測遅延時間(ミリ秒)」の２つです。<br>
	 * <br/>
	 * 状態が Status.Done になった時に取得できた estimated_latency が、推測値です。</br>
	 * なお、遅延推測値はすぐには取得できません。Status.Processsingから Status.Doneになるまで、
	 * 数十～数百ミリ秒ほどかかります。（必要な時間はAtomの初期化設定や端末により異なります）
	 * <br/>
	 * Status.Done以外の時の estmated_latency の値は無効値です。必ず Status.Done であることを
	 * 確認してから estimated_latency の値を記録してください。<br/>
	 * <br/>
	 * 本関数を呼び出して推測値を取得したら、riAtomExLatencyEstimator.Finalizeで処理を終了してください。
	 * \sa CriAtomExLatencyEstimator.InitializeModule CriAtomExLatencyEstimator.FinalizeModule
	 */
	public static CriAtomExLatencyEstimator.EstimatorInfo GetCurrentInfo()
	{
	#if !UNITY_EDITOR && UNITY_ANDROID
		return criAtomLatencyEstimator_GetCurrentInfo_ANDROID();
	#else
		EstimatorInfo info = new EstimatorInfo();
		info.status = CriAtomExLatencyEstimator.Status.Stop;
		info.estimated_latency = 0;
		return info;
	#endif
	}
	
	#if !UNITY_EDITOR && UNITY_ANDROID
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomLatencyEstimator_Initialize_ANDROID();

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomLatencyEstimator_Finalize_ANDROID();

	[DllImport(CriWare.pluginName)]
	private static extern EstimatorInfo criAtomLatencyEstimator_GetCurrentInfo_ANDROID();
	#endif
}
/**
 * @}
 */

/* --- end of file --- */
