/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011-2015 CRI Middleware Co., Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom for Unity
 * File	    : CriAtom.cs
 *
 ****************************************************************************/
/*---------------------------
 * Sequence Callback Defines
 *---------------------------*/
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_ANDROID || UNITY_IOS || UNITY_TVOS || UNITY_WINRT
	#define CRIWARE_SUPPORT_SEQUENCE_CALLBACK
	/* Callback Implentation Defines */
	#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_ANDROID || UNITY_WINRT
		#define CRIWARE_CALLBACK_IMPL_NATIVE2MANAGED
	#elif UNITY_IOS || UNITY_TVOS
		#define CRIWARE_CALLBACK_IMPL_UNITYSENDMESSAGE
	#else
		#error supported platform must select one of callback implementations
	#endif
#elif UNITY_WIIU || UNITY_PSP2 || UNITY_PS3 || UNITY_PS4 || UNITY_WEBGL
	#define CRIWARE_UNSUPPORT_SEQUENCE_CALLBACK
#else
	#error undefined platform if supporting sequence callback
#endif

using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

public static class CriAtomPlugin
{
	#region Version Info.
	public const string criAtomUnityEditorVersion = "Ver.0.21.05";
	#endregion

	#region Editor/Runtime共通
	
#if UNITY_EDITOR
	public static bool showDebugLog = false;
	public delegate void PreviewCallback();
	public static PreviewCallback previewCallback = null;
#endif

	public static void Log(string log)
	{
	#if UNITY_EDITOR
		if (CriAtomPlugin.showDebugLog) {
			Debug.Log(log);
		}
	#endif
	}

	/* 初期化カウンタ */
	private static int initializationCount = 0;
	
	public static bool isInitialized { get { return initializationCount > 0; } }
	
	public static void SetConfigParameters(int max_virtual_voices,
		int num_standard_memory_voices, int num_standard_streaming_voices,
		int num_hca_mx_memory_voices, int num_hca_mx_streaming_voices,
		int output_sampling_rate, bool uses_in_game_preview,
		float server_frequency)
	{
		criAtomUnity_SetConfigParameters(max_virtual_voices,
			num_standard_memory_voices, num_standard_streaming_voices,
			num_hca_mx_memory_voices, num_hca_mx_streaming_voices,
			output_sampling_rate, uses_in_game_preview,
			server_frequency);
	}
	
	public static void SetConfigAdditionalParameters_IOS(uint buffering_time_ios, bool override_ipod_music_ios)
	{
		criAtomUnity_SetConfigAdditionalParameters_IOS(buffering_time_ios, override_ipod_music_ios);
	}

	public static void SetConfigAdditionalParameters_ANDROID(int num_low_delay_memory_voices, int num_low_delay_streaming_voices,
															 int sound_buffering_time,		  int sound_start_buffering_time)
	{
		criAtomUnity_SetConfigAdditionalParameters_ANDROID(num_low_delay_memory_voices, num_low_delay_streaming_voices, 
														   sound_buffering_time,		sound_start_buffering_time);
	}

	public static void SetConfigAdditionalParameters_VITA(int num_atrac9_memory_voices, int num_atrac9_streaming_voices, int num_mana_decoders)
	{
		#if !UNITY_EDITOR && UNITY_PSP2
		criAtomUnity_SetConfigAdditionalParameters_VITA(num_atrac9_memory_voices, num_atrac9_streaming_voices, num_mana_decoders);
		#endif
	}

	public static void SetConfigAdditionalParameters_PS4(int num_atrac9_memory_voices, int num_atrac9_streaming_voices)
	{
		#if !UNITY_EDITOR && UNITY_PS4
		criAtomUnity_SetConfigAdditionalParameters_PS4(num_atrac9_memory_voices, num_atrac9_streaming_voices);
		#endif
	}

	public static void SetMaxSamplingRateForStandardVoicePool(int sampling_rate_for_memory, int sampling_rate_for_streaming)
	{
		criAtomUnity_SetMaxSamplingRateForStandardVoicePool(sampling_rate_for_memory, sampling_rate_for_streaming);
	}

	public static int GetRequiredMaxVirtualVoices(CriAtomConfig atomConfig)
	{
		/* バーチャルボイスは、全ボイスプールのボイスの合計値よりも多くなくてはならない */
		int requiredVirtualVoices = 0;

		requiredVirtualVoices += atomConfig.standardVoicePoolConfig.memoryVoices;
		requiredVirtualVoices += atomConfig.standardVoicePoolConfig.streamingVoices;
		requiredVirtualVoices += atomConfig.hcaMxVoicePoolConfig.memoryVoices;
		requiredVirtualVoices += atomConfig.hcaMxVoicePoolConfig.streamingVoices;

		#if UNITY_ANDROID
		requiredVirtualVoices += atomConfig.androidLowLatencyStandardVoicePoolConfig.memoryVoices;
		requiredVirtualVoices += atomConfig.androidLowLatencyStandardVoicePoolConfig.streamingVoices;
		#elif UNITY_PSP2
		requiredVirtualVoices += atomConfig.vitaAtrac9VoicePoolConfig.memoryVoices;
		requiredVirtualVoices += atomConfig.vitaAtrac9VoicePoolConfig.streamingVoices;
		#endif

		return requiredVirtualVoices;
	}

	public static void InitializeLibrary()
	{
		/* 初期化カウンタの更新 */
		CriAtomPlugin.initializationCount++;
		if (CriAtomPlugin.initializationCount != 1) {
			return;
		}
		
		/* CriWareInitializerが実行済みかどうかを確認 */
		bool initializerWorking = CriWareInitializer.IsInitialized();
		if (initializerWorking == false) {
			Debug.Log("[CRIWARE] CriWareInitializer is not working. "
				+ "Initializes Atom by default parameters.");
		}
		
		/* 依存ライブラリの初期化 */
		CriFsPlugin.InitializeLibrary();
		
		/* ライブラリの初期化 */
		CriAtomPlugin.criAtomUnity_Initialize();
		
		/* CriAtomServerのインスタンスを生成 */
		#if UNITY_EDITOR
		/* ゲームプレビュー時のみ生成する */
		if (UnityEngine.Application.isPlaying) {
			CriAtomServer.CreateInstance();
		}
		#else
		CriAtomServer.CreateInstance();
		#endif

		/* CriAtomListener の共有ネイティブリスナーを生成 */
		CriAtomListener.CreateSharedNativeListener();
	}

	public static void FinalizeLibrary()
	{
		/* 初期化カウンタの更新 */
		CriAtomPlugin.initializationCount--;
		if (CriAtomPlugin.initializationCount < 0) {
			Debug.LogError("[CRIWARE] ERROR: Atom library is already finalized.");
			return;
		}
		if (CriAtomPlugin.initializationCount != 0) {
			return;
		}

		/* CriAtomListener の共有ネイティブリスナーを破棄 */
		CriAtomListener.DestroySharedNativeListener();
		
		/* CriAtomServerのインスタンスを破棄 */
		CriAtomServer.DestroyInstance();
		
		/* ライブラリの終了 */
		CriAtomPlugin.criAtomUnity_Finalize();
		
		/* 依存ライブラリの終了 */
		CriFsPlugin.FinalizeLibrary();
	}

	public static void Pause(bool pause)
	{
		if (isInitialized) {
			criAtomUnity_Pause(pause);
		}
	}

	public static CriWare.CpuUsage GetCpuUsage()
	{
		var usage = new CriWare.CpuUsage();
		criAtomUnity_GetCpuUsage(out usage.last, out usage.average, out usage.peak);
		return usage;
	}

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomUnity_SetConfigParameters(int max_virtual_voices,
		int num_standard_memory_voices, int num_standard_streaming_voices,
		int num_hca_mx_memory_voices, int num_hca_mx_streaming_voices,
		int output_sampling_rate, bool uses_in_game_preview,
		float server_frequency);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomUnity_SetConfigAdditionalParameters_IOS(uint buffering_time_ios, bool override_ipod_music_ios);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomUnity_SetConfigAdditionalParameters_ANDROID(int num_low_delay_memory_voices, int num_low_delay_streaming_voices,
																				  int sound_buffering_time,		   int sound_start_buffering_time);
	#if !UNITY_EDITOR && UNITY_PSP2
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomUnity_SetConfigAdditionalParameters_VITA(int num_atrac9_memory_voices, int num_atrac9_streaming_voices, int num_mana_decoders);
	#endif
    
    #if !UNITY_EDITOR && UNITY_PS4
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomUnity_SetConfigAdditionalParameters_PS4(int num_atrac9_memory_voices, int num_atrac9_streaming_voices);
	#endif

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomUnity_Initialize();

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomUnity_Finalize();
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomUnity_Pause(bool pause);
	
	[DllImport(CriWare.pluginName)]
	public static extern void criAtomUnity_GetCpuUsage(out float last, out float average, out float peak);
	
	[DllImport(CriWare.pluginName)]
	public static extern uint criAtomUnity_GetAllocatedHeapSize();
	
	[DllImport(CriWare.pluginName)]
	public static extern void criAtomUnity_ControlDataCompatibility(int code);

	[DllImport(CriWare.pluginName)]
	public static extern void criAtomUnitySeqencer_SetEventCallback(IntPtr cbfunc, string gameobj_name, string func_name, string separator_string);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomUnity_SetMaxSamplingRateForStandardVoicePool(int sampling_rate_for_memory, int sampling_rate_for_streaming);

	#endregion
}

[Serializable]
public class CriAtomCueSheet
{
	public string name = "";
	public string acbFile = "";
	public string awbFile = "";
	public CriAtomExAcb acb;
}

/// \addtogroup CRIATOM_UNITY_COMPONENT
/// @{
/**
 * <summary>サウンド再生全体を制御するためのコンポーネントです。</summary>
 * \par 説明:
 * 各シーンにひとつ用意しておく必要があります。<br/>
 * UnityEditor上でCRI Atomウィンドウを使用して CriAtomSource を作成した場合、
 * 「CRIWARE」という名前を持つオブジェクトとして自動的に作成されます。通常はユーザーが作成する必要はありません。
 */
[AddComponentMenu("CRIWARE/CRI Atom")]
public class CriAtom : MonoBehaviour
{

	/* @cond DOXYGEN_IGNORE */
	public string acfFile = "";
	public CriAtomCueSheet[] cueSheets = {};
	public string dspBusSetting = "";
	public bool dontDestroyOnLoad = false;
	private static CriAtom instance {
		get; set;
	}
#if CRIWARE_SUPPORT_SEQUENCE_CALLBACK
	private static CriAtomExSequencer.EventCbFunc eventUserCbFunc = null;
	#if CRIWARE_CALLBACK_IMPL_UNITYSENDMESSAGE
	//  no use of  event queue since event is directly passed  from native to managed
	#elif CRIWARE_CALLBACK_IMPL_NATIVE2MANAGED
	private static Queue<string> eventQueue = new Queue<string>();
	#endif
#endif	
	/* @endcond */

	#region Functions

	/**
	 * <summary>DSPバス設定のアタッチ</summary>
	 * <param name="settingName">DSPバス設定の名前</param>
	 * \par 説明:
	 * DSPバス設定からDSPバスを構築してサウンドレンダラにアタッチします。<br/>
	 * 現在設定中のDSPバス設定を切り替える場合は、一度デタッチしてから再アタッチしてください。
	 * <br/>
	 * \attention
	 * 本関数は完了復帰型の関数です。<br/>
	 * 本関数を実行すると、しばらくの間Atomライブラリのサーバ処理がブロックされます。<br/>
	 * 音声再生中に本関数を実行すると、音途切れ等の不具合が発生する可能性があるため、
	 * 本関数の呼び出しはシーンの切り替わり等、負荷変動を許容できるタイミングで行ってください。<br/>
	 * \sa CriAtom::DetachDspBusSetting
	 */
	public static void AttachDspBusSetting(string settingName)
	{
		CriAtom.instance.dspBusSetting = settingName;
		if (!String.IsNullOrEmpty(settingName)) {
			CriAtomEx.AttachDspBusSetting(settingName);
		} else {
			CriAtomEx.DetachDspBusSetting();
		}
	}

	/**
	 * <summary>DSPバス設定のデタッチ</summary>
	 * <param name="settingName">DSPバス設定の名前</param>
	 * \par 説明:
	 * DSPバス設定をデタッチします。<br/>
	 * <br/>
	 * \attention
	 * 本関数は完了復帰型の関数です。<br/>
	 * 本関数を実行すると、しばらくの間Atomライブラリのサーバ処理がブロックされます。<br/>
	 * 音声再生中に本関数を実行すると、音途切れ等の不具合が発生する可能性があるため、
	 * 本関数の呼び出しはシーンの切り替わり等、負荷変動を許容できるタイミングで行ってください。<br/>
	 * \sa CriAtom::DetachDspBusSetting
	 */
	public static void DetachDspBusSetting()
	{
		CriAtom.instance.dspBusSetting = "";
		CriAtomEx.DetachDspBusSetting();
	}

	public static CriAtomCueSheet GetCueSheet(string name)
	{
		return CriAtom.instance.GetCueSheetInternal(name);
	}

	/**
	 * <summary>キューシートの追加</summary>
	 * <param name="name">キューシート名</param>
	 * <param name="acbFile">ACBファイルパス</param>
	 * <param name="awbFile">AWBファイルパス</param>
	 * <param name="binder">バインダオブジェクト(オプション)</param>
	 * <returns>キューシートオブジェクト</returns>
	 * \par 説明:
	 * 引数に指定したファイルパス情報を元にキューシートの追加を行います。<br/>
	 * 同時に複数のキューシートを登録することが可能です。<br/>
	 * <br/>
	 * 各ファイルパスに対して相対パスを指定した場合は StreamingAssets フォルダからの相対でファイルをロードします。<br/>
	 * 絶対パス、あるいはURLを指定した場合には指定したパスでファイルをロードします。<br/>
	 * <br/>
	 * CPKファイルにパッキングされたACBファイルとAWBファイルからキューシートを追加する場合は、
	 * binder引数にCPKをバインドしたバインダを指定してください。<br/>
	 * なお、バインダ機能はADX2LEではご利用になれません。<br/>
	 */
	public static CriAtomCueSheet AddCueSheet(string name, string acbFile, string awbFile, CriFsBinder binder = null)
	{
		CriAtomCueSheet cueSheet = CriAtom.instance.AddCueSheetInternal(name, acbFile, awbFile, binder);
		if (Application.isPlaying) {
			cueSheet.acb = CriAtom.instance.LoadAcbFile(binder, acbFile, awbFile);
		}
		return cueSheet;
	}

	/**
	 * <summary>キューシートの追加（メモリからの読み込み）</summary>
	 * <param name="name">キューシート名</param>
	 * <param name="acbData">ACBデータ</param>
	 * <param name="awbFile">AWBファイルパス</param>
	 * <param name="awbBinder">AWB用バインダオブジェクト(オプション)</param>
	 * <returns>キューシートオブジェクト</returns>
	 * \par 説明:
	 * 引数に指定したデータとファイルパス情報からキューシートの追加を行います。<br/>
	 * 同時に複数のキューシートを登録することが可能です。<br/>
	 * <br/>
	 * ファイルパスに対して相対パスを指定した場合は StreamingAssets フォルダからの相対でファイルをロードします。<br/>
	 * 絶対パス、あるいはURLを指定した場合には指定したパスでファイルをロードします。<br/>
	 * <br/>
	 * CPKファイルにパッキングされたAWBファイルからキューシートを追加する場合は、
	 * awbBinder引数にCPKをバインドしたバインダを指定してください。<br/>
	 * なお、バインダ機能はADX2LEではご利用になれません。<br/>
	 */
	public static CriAtomCueSheet AddCueSheet(string name, byte[] acbData, string awbFile, CriFsBinder awbBinder = null)
	{
		CriAtomCueSheet cueSheet = CriAtom.instance.AddCueSheetInternal(name, "", awbFile, awbBinder);
		if (Application.isPlaying) {
			cueSheet.acb = CriAtom.instance.LoadAcbData(acbData, awbBinder, awbFile);
		}
		return cueSheet;
	}

	/**
	 * <summary>キューシートの削除</summary>
	 * <param name="name">キューシート名</param>
	 * \par 説明:
	 * 追加済みのキューシートを削除します。<br/>
	 */
	public static void RemoveCueSheet(string name)
	{
		CriAtom.instance.RemoveCueSheetInternal(name);
	}

	/**
	 * <summary>ACBオブジェクトの取得</summary>
	 * <param name="cueSheetName">キューシート名</param>
	 * <returns>ACBオブジェクト</returns>
	 * \par 説明:
	 * 指定したキューシートに対応するACBオブジェクトを取得します。<br/>
	 */
	public static CriAtomExAcb GetAcb(string cueSheetName)
	{
		foreach (var cueSheet in CriAtom.instance.cueSheets) {
			if (cueSheetName == cueSheet.name) {
				return cueSheet.acb;
			}
		}
		Debug.LogWarning(cueSheetName + " is not loaded.");
		return null;
	}
	
	/**
	 * <summary>カテゴリ名指定でカテゴリボリュームを設定します。</summary>
	 * <param name="name">カテゴリ名</param>
	 * <param name="volume">ボリューム</param>
	 */
	public static void SetCategoryVolume(string name, float volume)
	{
		CriAtomExCategory.SetVolume(name, volume);
	}

	/**
	 * <summary>カテゴリID指定でカテゴリボリュームを設定します。</summary>
	 * <param name="id">カテゴリID</param>
	 * <param name="volume">ボリューム</param>
	 */
	public static void SetCategoryVolume(int id, float volume)
	{
		CriAtomExCategory.SetVolume(id, volume);
	}

	/**
	 * <summary>カテゴリ名指定でカテゴリボリュームを取得します。</summary>
	 * <param name="name">カテゴリ名</param>
	 * <returns>ボリューム</returns>
	 */
	public static float GetCategoryVolume(string name)
	{
		return CriAtomExCategory.GetVolume(name);
	}
	/**
	 * <summary>カテゴリID指定でカテゴリボリュームを取得します。</summary>
	 * <param name="id">カテゴリID</param>
	 * <returns>ボリューム</returns>
	 */
	public static float GetCategoryVolume(int id)
	{
		return CriAtomExCategory.GetVolume(id);
	}
	
	/**
	 * <summary>バス情報取得を有効にします。</summary>
	 * <param name="sw">true: 取得を有効にする。 false: 取得を無効にする</param>
	 */
	public static void SetBusAnalyzer(bool sw)
	{
	#if !UNITY_EDITOR && UNITY_PSP2	
		// unsupported
	#else
		if (sw) {
			CriAtomExAsr.AttachBusAnalyzer(50, 1000);
		} else {
			CriAtomExAsr.DetachBusAnalyzer();
		}
	#endif
	}

	/**
	 * <summary>バス情報を取得します。</summary>
	 * <param name="bus">DSPバス番号</param>
	 * <returns>DSPバス情報</returns>
	 */
	public static CriAtomExAsr.BusAnalyzerInfo GetBusAnalyzerInfo(int bus)
	{
		CriAtomExAsr.BusAnalyzerInfo info;
	#if !UNITY_EDITOR && UNITY_PSP2
		info = new CriAtomExAsr.BusAnalyzerInfo(null);
	#else
		CriAtomExAsr.GetBusAnalyzerInfo(bus, out info);
	#endif
		return info;
	}

	#endregion // Functions

	/* @cond DOXYGEN_IGNORE */
	#region Functions for internal use

	private void Setup()
	{
		CriAtom.instance = this;
		
		CriAtomPlugin.InitializeLibrary();

		if (!String.IsNullOrEmpty(this.acfFile)) {
			string acfPath = Path.Combine(CriWare.streamingAssetsPath, this.acfFile);
			CriAtomEx.RegisterAcf(null, acfPath);
		}

		if (!String.IsNullOrEmpty(dspBusSetting)) {
			AttachDspBusSetting(dspBusSetting);
		}
		
		foreach (var cueSheet in this.cueSheets) {
			cueSheet.acb = this.LoadAcbFile(null, cueSheet.acbFile, cueSheet.awbFile);
		}

		if (this.dontDestroyOnLoad) {
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
	}

	private void Shutdown()
	{
		foreach (var cueCheet in this.cueSheets) {
			if (cueCheet.acb != null) {
				cueCheet.acb.Dispose();
				cueCheet.acb = null;
			}
		}
		CriAtomPlugin.FinalizeLibrary();
		CriAtom.instance = null;
	}
	
	private void Awake()
	{
		if (CriAtom.instance != null) {
			if (CriAtom.instance.acfFile != this.acfFile) {
				var obj = CriAtom.instance.gameObject;
				CriAtom.instance.Shutdown();
				CriAtomEx.UnregisterAcf();
				GameObject.Destroy(obj);
				return;
			}
			if (CriAtom.instance.dspBusSetting != this.dspBusSetting) {
				CriAtom.AttachDspBusSetting(this.dspBusSetting);
			}
			CriAtom.instance.MargeCueSheet(this.cueSheets, this.dontRemoveExistsCueSheet);
			GameObject.Destroy(this.gameObject);
		}
	}

	private void OnEnable()
	{
	#if UNITY_EDITOR
		if (CriAtomPlugin.previewCallback != null) {
			CriAtomPlugin.previewCallback();
		}
	#endif
		if (CriAtom.instance != null) {
			return;
		}
		this.Setup();
	}
	
	private void OnDestroy()
	{
		if (this != CriAtom.instance) {
			return;
		}
		this.Shutdown();
	}

	private void Update()
	{
#if CRIWARE_SUPPORT_SEQUENCE_CALLBACK
	#if CRIWARE_CALLBACK_IMPL_UNITYSENDMESSAGE
		// no need to invoke the delegate since it will be invoked via the callback directly.
	#elif CRIWARE_CALLBACK_IMPL_NATIVE2MANAGED
		if (eventUserCbFunc != null) {
			int numQues = eventQueue.Count;
			string msg;
			
			for (int i=0;i<numQues;i++) {
				/* キューイングされたイベントがあればそれを実行する */
				lock (((ICollection)eventQueue).SyncRoot)
				{
					msg = eventQueue.Dequeue();	/* デキューの瞬間だけ排他制御を行う */
				}
				eventUserCbFunc(msg);
			}
		}
	#endif
#endif
	}

	public CriAtomCueSheet GetCueSheetInternal(string name)
	{
		for (int i = 0; i < this.cueSheets.Length; i++) {
			CriAtomCueSheet cueSheet = this.cueSheets[i];
			if (cueSheet.name == name) {
				return cueSheet;
			}
		}
		return null;
	}
	
	public CriAtomCueSheet AddCueSheetInternal(string name, string acbFile, string awbFile, CriFsBinder binder)
	{
		var cueSheets = new CriAtomCueSheet[this.cueSheets.Length + 1];
		this.cueSheets.CopyTo(cueSheets, 0);
		this.cueSheets = cueSheets;

		var cueSheet = new CriAtomCueSheet();
		this.cueSheets[this.cueSheets.Length - 1] = cueSheet;
		if (String.IsNullOrEmpty(name)) {
			cueSheet.name = Path.GetFileNameWithoutExtension(acbFile);
		} else {
			cueSheet.name = name;
		}
		cueSheet.acbFile = acbFile;
		cueSheet.awbFile = awbFile;
		return cueSheet;
	}
	
	public void RemoveCueSheetInternal(string name)
	{
		int index = -1;
		for (int i = 0; i < this.cueSheets.Length; i++) {
			if (name == this.cueSheets[i].name) {
				index = i;
			}
		}
		if (index < 0) {
			return;
		}

		var cueSheet = this.cueSheets[index];
		if (cueSheet.acb != null) {
			cueSheet.acb.Dispose();
		}

		var cueSheets = new CriAtomCueSheet[this.cueSheets.Length - 1];
		Array.Copy(this.cueSheets, 0, cueSheets, 0, index);
		Array.Copy(this.cueSheets, index + 1, cueSheets, index, this.cueSheets.Length - index - 1);
		this.cueSheets = cueSheets;
	}

	public bool dontRemoveExistsCueSheet = false;

	/*
	 * newDontRemoveExistsCueSheet == false の場合、古いキューシートを登録解除して、新しいキューシートの登録を行う。
	 * ただし同じキューシートの再登録は回避する
	 */
	private void MargeCueSheet(CriAtomCueSheet[] newCueSheets, bool newDontRemoveExistsCueSheet)
	{
		if (!newDontRemoveExistsCueSheet) {
			for (int i = 0; i < this.cueSheets.Length; ) {
				int index = Array.FindIndex(newCueSheets, sheet => sheet.name == this.cueSheets[i].name);
				if (index < 0) {
					CriAtom.RemoveCueSheet(this.cueSheets[i].name);
				} else {
					i++;
				}
			}
		}

		foreach (var sheet1 in newCueSheets) {
			var sheet2 = this.GetCueSheetInternal(sheet1.name);
			if (sheet2 == null) {
				CriAtom.AddCueSheet(null, sheet1.acbFile, sheet1.awbFile, null);
			}
		}
	}

	private CriAtomExAcb LoadAcbFile(CriFsBinder binder, string acbFile, string awbFile)
	{
		if (String.IsNullOrEmpty(acbFile)) {
			return null;
		}

		string acbPath = acbFile;
		if ((binder == null) && CriWare.IsStreamingAssetsPath(acbPath)) {
			acbPath = Path.Combine(CriWare.streamingAssetsPath, acbPath);
		}

		string awbPath = awbFile;
		if (!String.IsNullOrEmpty(awbPath)) {
			if ((binder == null) && CriWare.IsStreamingAssetsPath(awbPath)) {
				awbPath = Path.Combine(CriWare.streamingAssetsPath, awbPath);
			}
		}

		return CriAtomExAcb.LoadAcbFile(binder, acbPath, awbPath);
	}

	private CriAtomExAcb LoadAcbData(byte[] acbData, CriFsBinder binder, string awbFile)
	{
		if (acbData == null) {
			return null;
		}

		string awbPath = awbFile;
		if (!String.IsNullOrEmpty(awbPath)) {
			if ((binder == null) && CriWare.IsStreamingAssetsPath(awbPath)) {
				awbPath = Path.Combine(CriWare.streamingAssetsPath, awbPath);
			}
		}

		return CriAtomExAcb.LoadAcbData(acbData, binder, awbPath);
	}

#if CRIWARE_SUPPORT_SEQUENCE_CALLBACK
	public void EventCallbackFromNative(string eventString)
	{
		if (eventUserCbFunc != null) {
	#if CRIWARE_CALLBACK_IMPL_UNITYSENDMESSAGE
			eventUserCbFunc(eventString);
	#elif CRIWARE_CALLBACK_IMPL_NATIVE2MANAGED
			/* イベントのキューイング */
			/* 備考) iOS以外はCRI Atom内のスレッドから呼び出されるため */
			lock (((ICollection)eventQueue).SyncRoot)
			{
				eventQueue.Enqueue(eventString);
			}
	#endif
		}
	}
#endif

	/* プラグイン内部用API */
	public static void SetEventCallback(CriAtomExSequencer.EventCbFunc func, string separator)
	{

#if CRIWARE_SUPPORT_SEQUENCE_CALLBACK
		/* ネイティブプラグインに関数ポインタを登録 */
		IntPtr ptr = IntPtr.Zero;
		eventUserCbFunc = func;
		if (func != null) {
	#if CRIWARE_CALLBACK_IMPL_UNITYSENDMESSAGE
			ptr = IntPtr.Zero;
	#elif CRIWARE_CALLBACK_IMPL_NATIVE2MANAGED
			CriAtomExSequencer.EventCbFunc localFunc;
			localFunc = new CriAtomExSequencer.EventCbFunc(CriAtom.instance.EventCallbackFromNative);
			ptr = Marshal.GetFunctionPointerForDelegate(localFunc);
	#endif
			CriAtomPlugin.criAtomUnitySeqencer_SetEventCallback(ptr, CriAtom.instance.gameObject.name, "EventCallbackFromNative", separator);		
		}	
#elif CRIWARE_UNSUPPORT_SEQUENCE_CALLBACK
		Debug.LogError("This platform does not support event callback feature.");
#endif
	}

	#endregion
	/* @endcond */

}

/// @}
/* end of file */
