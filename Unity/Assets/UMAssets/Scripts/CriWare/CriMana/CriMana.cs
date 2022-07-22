/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011-2015 CRI Middleware Co., Ltd.
 *
 * Library  : CRI Mana
 * Module   : CRI Mana for Unity
 * File     : CriMana.cs
 *
 ****************************************************************************/

using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;


namespace CriMana
{
	/**
	 * <summary>ムービコーデックの種類を示す値です。</summary>
	 */
	public enum CodecType
	{
		Unknown			= 0,
		SofdecPrime		= 1,
		H264			= 5,
	}


	/**
	 * <summary>ムービの合成モードを示す値です。</summary>
	 */
	public enum AlphaType
	{
		CompoOpaq		= 0,	/**< 不透明、アルファ情報なし */
		CompoAlphaFull	= 1,	/**< フルAlpha合成（アルファ用データが8ビット) */
		CompoAlpha3Step	= 2,	/**< 3値アルファ */
		CompoAlpha32Bit = 3,	/**< フルAlpha、（カラーとアルファデータで32ビット） */
	}


	/**
	 * <summary>ムービファイル内のオーディオ解析情報です。</summary>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct AudioInfo
	{
		public UInt32	samplingRate;	/**< サンプリング周波数 */
		public UInt32	numChannels;	/**< オーディオチャネル数 */
		public UInt32	totalSamples;	/**< 総サンプル数 */
	}


	/**
	 * <summary>ムービファイルのヘッダ解析情報です。</summary>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public class MovieInfo
	{
		private UInt32	_reserved1;
		private UInt32	_hasAlpha;
		public UInt32	width;				/**< ムービ最大幅（８の倍数） */
		public UInt32	height;				/**< ムービ最大高さ（８の倍数） */
		public UInt32	dispWidth;			/**< 表示したい映像の横ピクセル数（左端から） */
		public UInt32	dispHeight;			/**< 表示したい映像の縦ピクセル数（上端から） */
		public UInt32	framerateN;			/**< 有理数形式フレームレート(分子) framerate [x1000] = framerateN / framerateD */
		public UInt32	framerateD;			/**< 有理数形式フレームレート(分母) framerate [x1000] = framerateN / framerateD */
		public UInt32	totalFrames;		/**< 総フレーム数 */
		private UInt32	_codecType;
		private UInt32	_alphaCodecType;
		public UInt32	numAudioStreams;			/**< オーディオストリームの数 */
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public AudioInfo[]	audioPrm;				/**< オーディオパラメータ */
		public UInt32		numSubtitleChannels;	/**< 字幕チャネル数 */
		public UInt32 		maxSubtitleSize;		/**< 字幕データの最大サイズ */
		
		public bool			hasAlpha { get { return _hasAlpha == 1; } set { _hasAlpha = value ? 1u : 0u; } }					/**< アルファムービーかどうか（1: アルファ有、0: アルファ無） */
		public CodecType	codecType { get { return (CodecType)_codecType; } set { _codecType = (UInt32)value; } }				/**< コーデック種別 (プラグイン内部で使用するための情報です) */
		public CodecType	alphaCodecType { get { return (CodecType)_alphaCodecType; } set { _codecType = (UInt32)value; } }	/**< アルファのコーデック種別 (プラグイン内部で使用するための情報です) */
	}


	/**
	 * <summary>ビデオフレーム情報です。</summary>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public class FrameInfo
	{
		public Int32	frameNo;				/**< フレーム識別番号(0からの通し番号) */
		public Int32	frameNoPerFile;			/**< フレーム識別番号(ムービファイル固有の識別番号) */
		public UInt32	width;					/**< ムービの横幅[pixel] (８の倍数) */
		public UInt32	height;					/**< ムービの高さ[pixel] (８の倍数) */
		public UInt32	dispWidth;				/**< 表示したい映像の横ピクセル数（左端から） */
		public UInt32	dispHeight;				/**< 表示したい映像の縦ピクセル数（上端から） */
		public UInt32	framerateN;				/**< 有理数形式フレームレート(分子) framerate [x1000] = framerateN / framerateD */
		public UInt32	framerateD;				/**< 有理数形式フレームレート(分子) framerate [x1000] = framerateN / framerateD */
		public UInt64	time;					/**< 時刻。time / tunit で秒を表す。ループ再生や連結再生時には継続加算。 */
		public UInt64	tunit;					/**< 時刻単位 */
		public UInt32	cntConcatenatedMovie;	/**< ムービの連結回数 */
		AlphaType		alphaType;				/**< アルファの合成モード */
		public UInt32	cntSkippedFrames;		/**< デコードスキップされたフレーム数 */
	}


	/**
	 * <summary>イベントポイント情報です。</summary>
	 * \par 説明:
	 * キューポイント機能でムービデータに埋め込まれた個々のイベントポイント情報です。<br/>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct EventPoint
	{
		public IntPtr	cueName;			/**< イベントポイント名へのポインタ。文字コードはキューポイント情報テキストに従います。 System.Runtime.InteropServices.Marshal.PtrToStringAuto などで変換して使用してください。 */
		public UInt32	cueNameSize;		/**< イベントポイント名のデータサイズ */
		public UInt64	time;				/**< タイマカウント */
		public UInt64	tunit;				/**< １秒あたりのタイマカウント値。count ÷ unit で秒単位の時刻となります。 */
		public Int32	type;				/**< イベントポイント種別 */
		public IntPtr	paramString;		/**< ユーザパラメータ文字列へのポインタ。文字コードはキューポイント情報テキストに従います。 System.Runtime.InteropServices.Marshal.PtrToStringAuto などで変換して使用してください。 */
		public UInt32	paramStringSize;	/**< ユーザパラメータ文字列のデータサイズ */
		public UInt32	cntCallback;		/**< キューポイントコールバックの呼び出しカウンタ */
	}
}


public class CriManaPlugin
{
	private enum GraphicsApi
	{
		Unknown			= 0,
		OpenGLES_2_0	= 1,
		OpenGLES_3_0	= 2,
		Metal			= 3
	};


	/* 初期化カウンタ */
	private static int initializationCount = 0;
	public static bool isInitialized { get { return initializationCount > 0; } }

	public static string cuePointFormatDelimiter;

	private static bool enabledMultithreadedRendering = false;
	public static bool isMultithreadedRenderingEnabled { get { return enabledMultithreadedRendering; } }

	public static int renderingEventOffset = 50000;
	
	public static void SetConfigParameters(bool graphicsMultiThreaded, int num_decoders, int max_num_of_entries)
	{
		GraphicsApi graphicsApi = GraphicsApi.Unknown;
#if !UNITY_EDITOR && (UNITY_IOS || UNITY_TVOS)
		if (SystemInfo.graphicsDeviceVersion.IndexOf("OpenGL ES 2.") > -1) {
			graphicsApi = GraphicsApi.OpenGLES_2_0;
		} else if (SystemInfo.graphicsDeviceVersion.IndexOf("OpenGL ES 3.") > -1) {
			graphicsApi = GraphicsApi.OpenGLES_3_0;
		} else if (SystemInfo.graphicsDeviceVersion.IndexOf("Metal") > -1) {
			graphicsApi = GraphicsApi.Metal;
		}
#endif

#if !UNITY_EDITOR && UNITY_ANDROID
		// currently, this feature is supported on Android only
		enabledMultithreadedRendering = graphicsMultiThreaded;
		CriWare.criWareUnity_SetRenderingEventOffsetForMana(renderingEventOffset);
#else
		enabledMultithreadedRendering = false;
#endif

		CriManaPlugin.criManaUnity_SetConfigParameters((int)graphicsApi, enabledMultithreadedRendering, num_decoders, max_num_of_entries);
	}


	public static void SetConfigAdditonalParameters_VITA(bool use_h264_playback, int width, int height)
	{
#if !UNITY_EDITOR && UNITY_PSP2
		CriManaPlugin.criManaUnity_SetConfigAdditionalParameters_VITA(use_h264_playback, (UInt32)width, (UInt32)height);
#endif

	}


	public static void InitializeLibrary()
	{
		/* 初期化カウンタの更新 */
		CriManaPlugin.initializationCount++;
		if (CriManaPlugin.initializationCount != 1) {
			return;
		}
		
		/* CriWareInitializerが実行済みかどうかを確認 */
		bool initializerWorking = CriWareInitializer.IsInitialized();
		if (initializerWorking == false) {
			Debug.Log("[CRIWARE] CriWareInitializer is not working. "
				+ "Initializes Mana by default parameters.");
		}
		
		/* 依存ライブラリの初期化 */
		CriFsPlugin.InitializeLibrary();
		CriAtomPlugin.InitializeLibrary();

		/* ライブラリの初期化 */
		CriManaPlugin.criManaUnity_Initialize();

		/* RendererResource の自動登録を実行 */
		CriMana.Detail.AutoResisterRendererResourceFactories.InvokeAutoRegister();

		cuePointFormatDelimiter = "\t";
	}


	public static void FinalizeLibrary()
	{
		/* 初期化カウンタの更新 */
		CriManaPlugin.initializationCount--;
		if (CriManaPlugin.initializationCount < 0) {
			Debug.LogError("[CRIWARE] ERROR: Mana library is already finalized.");
			return;
		}
		if (CriManaPlugin.initializationCount != 0) {
			return;
		}
		
		/* ライブラリの終了 */
		CriManaPlugin.criManaUnity_Finalize();

		/* RendererResourceFactoryのインスタンスを破棄 */
		CriMana.Detail.RendererResourceFactory.DisposeAllFactories();
		
		/* 依存ライブラリの終了 */
		CriAtomPlugin.FinalizeLibrary();
		CriFsPlugin.FinalizeLibrary();
	}


	/**
	 * <summary>キューポイントコールバックのイベントパラメタ区切り文字列を指定します。</summary>
	 * <param name="eventParamsString">イベントパラメタ区切り文字列</param>
	 * \par 説明:
	 * キューポイントコールバック関数に渡される文字列の各情報の区切り文字列を指定します。<br/>
	 * 区切り文字列を明示的に設定しない場合はタブ文字"\t"が使用されます。<br/>
	 * \par 注意:
	 * 区切り文字列は15文字以下である必要があります。
	 * \sa CriManaPlayer::CuePointCbFunc, CriManaPlayer::SetCuePointCallback
	 */
	public static void SetCuePointFormatDelimiter(string delimiter)
	{
		cuePointFormatDelimiter = delimiter;
	}

	public static void SetDecodeThreadPriorityAndroidExperimental(int prio)
	{
		/*
		 * <summary>
		 * デコードマスタースレッドのプライオリティを変更します。
		 * </summary>
		 * <param name="prio">スレッドプライオリティ</param>
		 * \par 呼び出し条件:
		 * Manaライブラリが初期化された後に本メソッドを呼び出してください。
		 * \par 説明:
		 * デコード処理を行うスレッドのプライオリティを変更します。
		 * デフォルトでは、デコードスレッドのプライオリティはメインスレッドよりも低く設定されています。
		 * \par 注意:
		 * 本メソッドはExperimentalです。今後のアップデートで削除、または仕様変更される可能性があります。
		 */
#if !UNITY_EDITOR && UNITY_ANDROID
		criManaUnity_SetDecodeThreadPriority_ANDROID(prio);
#endif
	}

	#region Native API Definition
	[DllImport(CriWare.pluginName)]
	private static extern void criManaUnity_SetConfigParameters(int graphics_api, bool graphics_multi_threaded, int num_decoders, int num_of_max_entries);

	[DllImport(CriWare.pluginName)]
	private static extern void criManaUnity_Initialize();

	[DllImport(CriWare.pluginName)]
	private static extern void criManaUnity_Finalize();

	[DllImport(CriWare.pluginName)]
	public static extern uint criManaUnity_GetAllocatedHeapSize();
	
#if !UNITY_EDITOR && UNITY_ANDROID
	[DllImport(CriWare.pluginName)]
	public static extern void criManaUnity_SetDecodeThreadPriority_ANDROID(int prio);
#elif !UNITY_EDITOR && UNITY_PSP2
	[DllImport(CriWare.pluginName)]
	public static extern void criManaUnity_SetConfigAdditionalParameters_VITA(bool use_h264_playback, UInt32 width, UInt32 height);
#endif

	#endregion
}


/* end of file */
