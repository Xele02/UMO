/****************************************************************************
 *
 * Copyright (c) 2012 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;

namespace CriWare {

/**
 * <summary>CRI File System初期化パラメータ</summary>
 */
[System.Serializable]
public class CriFsConfig {
	/** デバイス性能読み込み速度のデフォルト値(bps) */
	public const int defaultAndroidDeviceReadBitrate = 50000000;

	/** ローダー数 */
	public int numberOfLoaders    = 16;
	/** バインダ数 */
	public int numberOfBinders    = 8;
	/** インストーラ数 */
	public int numberOfInstallers = 2;
	/** インストールバッファのサイズ */
	public int installBufferSize  = CriFsPlugin.defaultInstallBufferSize / 1024;
	/** パスの最大長 */
	public int maxPath            = 256;
	/** ユーザーエージェント文字列 */
	public string userAgentString = "";
	/** ファイルディスクリプタの節約モードフラグ */
	public bool minimizeFileDescriptorUsage = false;
	/** CPKファイルのCRCチェックを行うかどうか */
	public bool enableCrcCheck = false;
	/** [Android] デバイス性能読み込み速度(bps) */
	public int androidDeviceReadBitrate = defaultAndroidDeviceReadBitrate;

}

/**
 * <summary>CRI Atom初期化パラメータ</summary>
 */
[System.Serializable]
public class CriAtomConfig {
	/**
	 * <summary>ACFファイル名</summary>
	 * <remarks>
	 * <para header='注意'>ACFファイルをStreamingAssetsフォルダに配置しておく必要あり。</para>
	 * </remarks>
	 */
	public string acfFileName = "";

	/** 標準ボイスプール作成パラメータ */
	[System.Serializable]
	public class StandardVoicePoolConfig {
		public int memoryVoices    = 16;
		public int streamingVoices = 8;
	}

	/** HCA-MXボイスプール作成パラメータ */
	[System.Serializable]
	public class HcaMxVoicePoolConfig {
		public int memoryVoices    = 0;
		public int streamingVoices = 0;
	}

	/** インゲームプレビュー設定 */
	[System.Serializable]
	public enum InGamePreviewSwitchMode {
		Disable,                /** 無効 */
		Enable,                 /** 有効 */
		FollowBuildSetting,     /** Development Build時のみ有効 */
		Default                 /** "usesInGamePreview" */
	}

	/** インゲームプレビューパラメータ */
	[System.Serializable]
	public class InGamePreviewConfig {
		/** 最大プレビューオブジェクト数 */
		public int maxPreviewObjects                = 200;
		/** 通信用バッファサイズ(KiB) */
		public int communicationBufferSize          = 2048;
		/** 再生位置情報更新間隔(サーバ処理の回数) */
		public int playbackPositionUpdateInterval   = 8;
	}

	/** 最大バーチャルボイス数 */
	public int maxVirtualVoices = 32;
	/** 最大ボイスリミットグループ数 */
	public int maxVoiceLimitGroups = 32;
	/** 最大カテゴリ数 */
	public int maxCategories = 32;
	/** 1フレーム当たりの最大シーケンスイベント数 */
	public int maxSequenceEventsPerFrame = 2;
	/** 1フレーム当たりの最大ビート同期コールバック数 */
	public int maxBeatSyncCallbacksPerFrame = 1;
	/** 1フレーム当たりの最大キューリンクコールバック数 */
	public int maxCueLinkCallbacksPerFrame = 1;
	/** 標準ボイスプール作成パラメータ */
	public StandardVoicePoolConfig standardVoicePoolConfig = new StandardVoicePoolConfig();
	/** HCA-MXボイスプール作成パラメータ */
	public HcaMxVoicePoolConfig hcaMxVoicePoolConfig = new HcaMxVoicePoolConfig();
	/** 出力サンプリングレート */
	public int outputSamplingRate = 0;
	/** インゲームプレビューを使用するかどうか */
	public bool usesInGamePreview = false;
	/** インゲームプレビュー設定(Inspector 指定時のみ有効) */
	public InGamePreviewSwitchMode inGamePreviewMode = InGamePreviewSwitchMode.Default;
	/** インゲームプレビューパラメータ */
	public InGamePreviewConfig inGamePreviewConfig = new InGamePreviewConfig();
	/** サーバ周波数 */
	public float serverFrequency  = 60.0f;
	/** ASR出力チャンネル数 */
	public int asrOutputChannels  = 0;
	/** 乱数種に時間（System.DateTime.Now.Ticks）を使用するかどうか */
	public bool useRandomSeedWithTime = false;
	/** 再生単位でのカテゴリ参照数 */
	public int categoriesPerPlayback = 4;
	/** 最大バス数 */
	public int maxBuses = 8;
	/** 最大パラメータブロック数 */
	public int maxParameterBlocks = 1024;
	/** VR サウンド出力モードを使用するか否か */
	public bool vrMode = false;
	/** StandAlone プラットフォームやエディタでポーズ時に音声出力もポーズするか否か */
	public bool keepPlayingSoundOnPause = true;

	/** [PC] 出力バッファリング時間 */
	public int pcBufferingTime = 0;


	/** [iOS] SonicSYNCモード有効化 */
	public bool iosEnableSonicSync = true;
	/** [iOS] 出力バッファリング時間(ミリ秒) */
	public int  iosBufferingTime     = 50;
	/** [iOS] iPodの再生を上書きするか？ */
	public bool iosOverrideIPodMusic = false;

	/** [Android] SonicSYNCモード有効化 */
	public bool androidEnableSonicSync = true;
	/** [Android] ASR(通常再生)出力バッファリング時間 */
	public int androidBufferingTime      = 133;
	/** [Android] NSR(低遅延再生)再生開始バッファリング時間 */
	public int androidStartBufferingTime = 100;

	/** [Android] 低遅延再生用ボイスプール作成パラメータ */
	[System.Serializable]
	public class AndroidLowLatencyStandardVoicePoolConfig {
		public int memoryVoices    = 0;
		public int streamingVoices = 0;
	}
	/** [Android] 低遅延再生用ボイスプール作成パラメータ */
	public AndroidLowLatencyStandardVoicePoolConfig androidLowLatencyStandardVoicePoolConfig = new AndroidLowLatencyStandardVoicePoolConfig();
	/** [Android] Android OS の Fast Mixer を使用して、音声再生時の発音遅延を短縮するかどうか。ASR/NSR の発音遅延や、遅延推測機能の結果に影響する */
	public bool androidUsesAndroidFastMixer = true;
	/** [Android] 非低遅延再生指定時のCriAtomSourceで、強制的にASRによる再生を行うか */
	public bool androidForceToUseAsrForDefaultPlayback = true;
	/** [Android] β版機能：AAudioを有効にするかどうか */
	public bool androidUsesAAudio = false;

}

/**
 * <summary>CRI Mana初期化パラメータ</summary>
 */
[System.Serializable]
public class CriManaConfig {
	/** デコーダー数 */
	public int  numberOfDecoders   = 8;
	/** 連結再生エントリー数 */
	public int  numberOfMaxEntries = 4;
	/** GL.IssuePluginEventを用いたマルチスレッドでのテクスチャ描画処理を有効にするかどうか */
	public readonly bool graphicsMultiThreaded = true; // always true.

}


} //namespace CriWare

/**
 * \addtogroup CRIWARE_UNITY_COMPONENT
 * @{
 */

namespace CriWare {

/**
 * <summary>CRIWARE初期化コンポーネント</summary>
 * <remarks>
 * <para header='説明'>CRIWAREライブラリの初期化を行うためのコンポーネントです。<br/></para>
 * </remarks>
 */
[AddComponentMenu("CRIWARE/Library Initializer")]
public class CriWareInitializer : CriMonoBehaviour {

	/** CRI File Systemライブラリを初期化するかどうか */
	public bool initializesFileSystem = true;

	/** CRI File Systemライブラリ初期化設定 */
	public CriFsConfig fileSystemConfig = new CriFsConfig();

	/** CRI Atomライブラリを初期化するかどうか */
	public bool initializesAtom = true;

	/** CRI Atomライブラリ初期化設定 */
	public CriAtomConfig atomConfig = new CriAtomConfig();

	/** CRI Manaライブラリを初期化するかどうか */
	public bool initializesMana = true;

	/** CRI Manaライブラリ初期化設定 */
	public CriManaConfig manaConfig = new CriManaConfig();



	/** Awake時にライブラリを初期化するかどうか */
	public bool dontInitializeOnAwake = false;

	/** シーンチェンジ時にライブラリを終了するかどうか */
	public bool dontDestroyOnLoad = false;

	/* オブジェクト作成時の処理 */
	void Awake() {
		/* 現在のランタイムのバージョンが正しいかチェック */
		CriWare.Common.CheckBinaryVersionCompatibility();

		if (dontInitializeOnAwake) {
			/* フラグが立っていた場合はAwakeでは初期化を行わない */
			return;
		}

		/* プラグインの初期化 */
		this.Initialize();
	}

	/* Execution Order の設定を確実に有効にするために OnEnable をオーバーライド */
	protected override void OnEnable() {
		base.OnEnable();
	}

	void Start () { }

	void OnDestroy() {
		Shutdown();
	}

#if !UNITY_EDITOR && UNITY_IOS
	static int frameCnt = 0;
#endif
	public override void CriInternalUpdate() {
#if !UNITY_EDITOR && UNITY_IOS
		if (frameCnt > 3) {
			return;
		}
		frameCnt++;
		if (frameCnt == 2) {
			CriAtomPlugin.Pause(true);
		} else if (frameCnt == 3) {
			CriAtomPlugin.Pause(false);
		}
#endif
	}

	public override void CriInternalLateUpdate() { }

	/**
	 * <summary>プラグインの初期化（手動初期化用）</summary>
	 * <remarks>
	 * <para header='説明'>プラグインの初期化を行います。<br/>
	 * デフォルトでは本関数はAwake関数内で自動的に呼び出されるので、アプリケーションが直接呼び出す必要はありません。<br/>
	 * <br/>
	 * 初期化パラメタをスクリプトから動的に変更して初期化を行いたい場合、本関数を使用してください。<br/></para>
	 * <para header='注意'>本関数を使用する場合は、 自動初期化を無効にするため、
	 * ::CriWareInitializer::dontInitializeOnAwake プロパティをインスペクタ上でチェックしてください。<br/>
	 * また、本関数を呼び出すタイミングは全てのプラグインAPIよりも前である必要があります。
	 * Script Execution Orderが高いスクリプト上で行ってください。</para>
	 * </remarks>
	 *
	 */
	public void Initialize() {
		/* 初期化カウンタの更新 */
		initializationCount++;
		if (initializationCount != 1) {
			/* CriWareInitializer自身による多重初期化は許可しない */
			GameObject.Destroy(this);
			return;
		}

		/* 非実行時にライブラリ機能を使用していた場合は一度終了処理を行う */
		if ((CriFsPlugin.IsLibraryInitialized() == true && CriAtomPlugin.IsLibraryInitialized() == true && CriManaPlugin.IsLibraryInitialized() == true) ||
			(CriFsPlugin.IsLibraryInitialized() == true && CriAtomPlugin.IsLibraryInitialized() == true && CriManaPlugin.IsLibraryInitialized() == false) ||
			(CriFsPlugin.IsLibraryInitialized() == true && CriAtomPlugin.IsLibraryInitialized() == false && CriManaPlugin.IsLibraryInitialized() == false)) {
#if UNITY_EDITOR || (!UNITY_PS3)
			/* CRI Manaライブラリの終了 */
			if (initializesMana) {
				CriManaPlugin.FinalizeLibrary();
			}
#endif

			/* CRI Atomライブラリの終了 */
			if (initializesAtom) {
				/* EstimatorがStop状態になるまでFinalize */
				while (CriAtomExLatencyEstimator.GetCurrentInfo().status != CriAtomExLatencyEstimator.Status.Stop) {
					CriAtomExLatencyEstimator.FinalizeModule();
				}

				/* 終了処理の実行 */
				CriAtomPlugin.FinalizeLibrary();
			}

			/* CRI File Systemライブラリの終了 */
			if (initializesFileSystem) {
				CriFsPlugin.FinalizeLibrary();
			}
		}

		/* CRI File Systemライブラリの初期化 */
		if (initializesFileSystem) {
			InitializeFileSystem(fileSystemConfig);
		}


		/* CRI Atomライブラリの初期化 */
		if (initializesAtom) {
			switch (atomConfig.inGamePreviewMode) {
				case CriAtomConfig.InGamePreviewSwitchMode.Disable:
					atomConfig.usesInGamePreview = false;
					break;
				case CriAtomConfig.InGamePreviewSwitchMode.Enable:
					atomConfig.usesInGamePreview = true;
					break;
				case CriAtomConfig.InGamePreviewSwitchMode.FollowBuildSetting:
					atomConfig.usesInGamePreview = UnityEngine.Debug.isDebugBuild;
					break;
				default:
					/* 既に設定されたフラグに従う */
					break;
			}
			InitializeAtom(atomConfig);
		}


		/* シーンチェンジ後もオブジェクトを維持するかどうかの設定 */
		if (dontDestroyOnLoad) {
			DontDestroyOnLoad(transform.gameObject);
			DontDestroyOnLoad(CriWare.Common.managerObject);
		}
	}

	/**
	 * <summary>プラグインの終了（手動終了用）</summary>
	 * <remarks>
	 * <para header='説明'>プラグインを終了します。<br/>
	 * デフォルトでは本関数はOnDestroy関数内で自動的に呼び出されるので、アプリケーションが直接呼び出す必要はありません。</para>
	 * </remarks>
	 */
	public void Shutdown() {
		/* 初期化カウンタの更新 */
		initializationCount--;
		if (initializationCount != 0) {
			initializationCount = initializationCount < 0 ? 0 : initializationCount;
			return;
		}


		/* CRI Atomライブラリの終了 */
		if (initializesAtom) {
			/* EstimatorがStop状態になるまでFinalize */
			while (CriAtomExLatencyEstimator.GetCurrentInfo().status != CriAtomExLatencyEstimator.Status.Stop) {
				CriAtomExLatencyEstimator.FinalizeModule();
			}

			/* 終了処理の実行 */
			CriAtomPlugin.FinalizeLibrary();
		}

		/* CRI File Systemライブラリの終了 */
		if (initializesFileSystem) {
			CriFsPlugin.FinalizeLibrary();
		}
	}

	/* 初期化カウンタ */
	private static int initializationCount = 0;

	/* 初期化実行チェック関数 */
	public static bool IsInitialized() {
		if (initializationCount > 0) {
			return true;
		} else {
			/* 現在のランタイムのバージョンが正しいかチェック */
			CriWare.Common.CheckBinaryVersionCompatibility();
			return false;
		}
	}

	/**
	 * <summary>カスタムエフェクトのインタフェース登録</summary>
	 * <remarks>
	 * <para header='説明'>ユーザが独自に実装したASRバスエフェクト(カスタムエフェクト)の
	 * インタフェースを登録するためのメソッドです。
	 * CRI ADX2 Audio Effect Plugin SDK を使用することで、
	 * ユーザ独自の ASR バスエフェクトを作成することができます。
	 * <br/>
	 * 通常は、予め用意されたエフェクト処理しか使うことができません。
	 * CRIWARE で定められたルールに従ってカスタムエフェクトライブラリを実装することで、
	 * ユーザは CRIWAER Unity Plug-in 用カスタムエフェクトインタフェースを用意することができます。
	 * <br/>
	 * このインタフェースへのポインタを、本関数を用いて CRIWAER Unity Plug-in に登録することで、
	 * CRI ライブラリ初期化時にカスタムエフェクトが有効化されます。
	 * <br/>
	 * なお、登録したカスタムエフェクトは CRI ライブラリの終了時に強制的に登録解除されます。
	 * 再度 CRI ライブラリを初期化する際には、改めて本関数を呼び出してカスタムエフェクトの
	 * インタフェース登録を行ってください。</para>
	 * <para header='注意'>必ず CRI ライブラリの初期化前に本関数を呼んでください。
	 * 本関数で追加されたカスタムエフェクトのインタフェースは、CRI ライブラリの初期化処理内で
	 * 実際に有効化されます。</para>
	 * </remarks>
	 */
	static public void AddAudioEffectInterface(IntPtr effect_interface)
	{
		List<IntPtr> effect_interface_list = null;
		if (CriAtomPlugin.GetAudioEffectInterfaceList(out effect_interface_list))
		{
			effect_interface_list.Add(effect_interface);
		}
	}

	public static bool InitializeFileSystem(CriFsConfig config)
	{
		/* CRI File Systemライブラリの初期化 */
		if (!CriFsPlugin.IsLibraryInitialized()) {
			CriFsPlugin.SetConfigParameters(
				config.numberOfLoaders,
				config.numberOfBinders,
				config.numberOfInstallers,
				(config.installBufferSize * 1024),
				config.maxPath,
				config.minimizeFileDescriptorUsage//,
				//config.enableCrcCheck // hack removed in LE
				);
			{
				/* Ver.2.03.03 以前は 0 がデフォルト値だったことの互換性維持のための処理 */
				if (config.androidDeviceReadBitrate == 0) {
					config.androidDeviceReadBitrate = CriFsConfig.defaultAndroidDeviceReadBitrate;
				}
			}
			CriFsPlugin.SetConfigAdditionalParameters_ANDROID(config.androidDeviceReadBitrate);
			CriFsPlugin.InitializeLibrary();
			if (config.userAgentString.Length != 0) {
				CriFsUtility.SetUserAgentString(config.userAgentString);
			}
			return true;
		} else {
			return false;
		}
	}

	public static bool InitializeAtom(CriAtomConfig config)
	{
		/* CRI Atomライブラリの初期化 */
		if (CriAtomPlugin.IsLibraryInitialized() == false) {
			/* 初期化処理の実行 */
			CriAtomPlugin.SetConfigParameters(
				(int)Math.Max(config.maxVirtualVoices, CriAtomPlugin.GetRequiredMaxVirtualVoices(config)),
				config.maxVoiceLimitGroups,
				config.maxCategories,
				config.maxSequenceEventsPerFrame,
				config.maxBeatSyncCallbacksPerFrame,
				config.maxCueLinkCallbacksPerFrame,
				config.standardVoicePoolConfig.memoryVoices,
				config.standardVoicePoolConfig.streamingVoices,
				config.hcaMxVoicePoolConfig.memoryVoices,
				config.hcaMxVoicePoolConfig.streamingVoices,
				config.outputSamplingRate,
				config.asrOutputChannels,
				config.usesInGamePreview,
				config.serverFrequency,
				config.maxParameterBlocks,
				config.categoriesPerPlayback,
				config.maxBuses,
				config.vrMode);

			CriAtomPlugin.SetConfigMonitorParametes(
				config.inGamePreviewConfig.maxPreviewObjects,
				config.inGamePreviewConfig.communicationBufferSize,
				config.inGamePreviewConfig.playbackPositionUpdateInterval
			);

			CriAtomPlugin.SetConfigAdditionalParameters_PC(
				config.pcBufferingTime
				);


			CriAtomPlugin.SetConfigAdditionalParameters_IOS(
				config.iosEnableSonicSync,
				(uint)Math.Max(config.iosBufferingTime, 16),
				config.iosOverrideIPodMusic
				);
			/* Android 固有の初期化パラメータを登録 */
			{
				/* Ver.2.03.03 以前は 0 がデフォルト値だったことの互換性維持のための処理 */
				if (config.androidBufferingTime == 0) {
					config.androidBufferingTime = (int)(4 * 1000.0 / config.serverFrequency);
				}
				if (config.androidStartBufferingTime == 0) {
					config.androidStartBufferingTime = (int)(3 * 1000.0 / config.serverFrequency);
				}
#if !UNITY_EDITOR && UNITY_ANDROID
				CriAtomEx.androidDefaultSoundRendererType = config.androidForceToUseAsrForDefaultPlayback ?
					CriAtomEx.SoundRendererType.Asr : CriAtomEx.SoundRendererType.Default;
#endif
				CriAtomPlugin.SetConfigAdditionalParameters_ANDROID(
					config.androidEnableSonicSync,
					config.androidLowLatencyStandardVoicePoolConfig.memoryVoices,
					config.androidLowLatencyStandardVoicePoolConfig.streamingVoices,
					config.androidBufferingTime,
					config.androidStartBufferingTime,
					config.androidUsesAndroidFastMixer,
					config.androidUsesAAudio);
			}

			CriAtomPlugin.InitializeLibrary();

			if (config.useRandomSeedWithTime == true){
				/* 時刻を乱数種に設定 */
				CriAtomEx.SetRandomSeed((uint)System.DateTime.Now.Ticks);
			}

			/* ACFファイル指定時は登録 */
			if (config.acfFileName.Length != 0) {
			#if UNITY_WEBGL
				Debug.LogError("In WebGL, ACF File path should be set to CriAtom Component.");
			#else
				string acfPath = config.acfFileName;
				if (CriWare.Common.IsStreamingAssetsPath(acfPath)) {
					acfPath = Path.Combine(CriWare.Common.streamingAssetsPath, acfPath);
				}

				CriAtomEx.RegisterAcf(null, acfPath);
			#endif
			}
			CriAtomServer.KeepPlayingSoundOnPause = config.keepPlayingSoundOnPause;
			return true;
		} else {
			return false;
		}

	}

	public static bool InitializeMana(CriManaConfig config) {
		/* CRI Manaライブラリの初期化 */
		if (CriManaPlugin.IsLibraryInitialized() == false) {
			CriManaPlugin.SetConfigParameters(config.graphicsMultiThreaded, config.numberOfDecoders, config.numberOfMaxEntries);

			CriManaPlugin.InitializeLibrary();

			// set shader global keyword to inform cri mana shaders to output to correct colorspace
			if (QualitySettings.activeColorSpace == ColorSpace.Linear) {
				Shader.EnableKeyword("CRI_LINEAR_COLORSPACE");
			}
			return true;
		} else {
			return false;
		}
	}


} // end of class

} //namespace CriWare
/** @} */

/* --- end of file --- */
