/****************************************************************************
 *
 * Copyright (c) 2018 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

#if (UNITY_EDITOR && !UNITY_EDITOR_LINUX) || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_ANDROID || UNITY_IOS
#define CRIWAREPLUGIN_SUPPORT_AUXIN
#pragma warning disable 0414
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
 * <summary>外部音声を入力するためのAuxIn</summary>
 * <remarks>
 * <para header='説明'>AuxInはADX2の外部の音声データをADX2のDSPバスに流すことができます。<br/>
 * 入力データの再生開始、ステータスの取得、入力データの書込み等の制御を行います。<br/></para>
 * </remarks>
 */
public class CriAtomExAuxIn : CriDisposable
{
	/**
	 * <summary>AuxIn作成用コンフィグ構造体</summary>
	 * <remarks>
	 * <para header='説明'>音声入力用のAuxInハンドルを作成するための、動作仕様を指定するための構造体です。<br/>
	 * 作成時の引数に指定します。<br/>
	 * <br/>
	 * 作成されるAuxInハンドルは、ハンドル作成時に本構造体で指定された設定に応じて、
	 * 内部リソースを必要なだけ確保します。<br/>
	 * プレーヤが必要とするワーク領域のサイズは、本構造体で指定されたパラメータに応じて変化します。</para>
	 * </remarks>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct Config
	{
		/**
		 * <summary>最大出力チャンネル数</summary>
		 * <remarks>
		 * <para header='説明'>AtomInで再生する音声のチャンネル数を指定します。<br/>
		 * 作成されたAuxInは、max_channelsで指定したチャンネル数"以下の"音声データを
		 * 再生可能です。<br/>
		 * 最大出力チャンネル数として指定する値と、作成されたAuxInで再生可能なデータの
		 * 関係を以下に示します。<br/>
		 * |最大出力チャンネル数（指定する値） | 作成されたAuxInで再生可能なデータ   |
		 * |-------------------------------|-------------------------------|
		 * |1                               | モノラル                          |
		 * |2                               | モノラル、ステレオ                   |
		 * |6                               | モノラル、ステレオ、5.1ch           |
		 * |8                               | モノラル、ステレオ、5.1ch、7.1ch       |
		 * <br/></para>
		 * <para header='備考'>サウンド出力時にハードウェアリソースを使用するプラットフォームにおいては、
		 * 出力チャンネル数を小さくすることで、ハードウェアリソースの消費を抑えることが
		 * 可能です。<br/></para>
		 * <para header='注意'>指定された最大出力チャンネル数を超えるデータは、再生することはできません。<br/>
		 * 例えば、最大出力チャンネル数を1に設定した場合、作成されたAuxInで
		 * ステレオ音声を再生することはできません。<br/>
		 * （モノラルにダウンミックスされて出力されることはありません。）</para>
		 * </remarks>
		 */
		public int maxChannels;

		/**
		 * <summary>最大サンプリングレート</summary>
		 * <remarks>
		 * <para header='説明'>AuxInで再生する音声のサンプリングレートを指定します。<br/>
		 * 作成されたAuxInは、max_sampling_rateで指定したサンプリングレート"以下の"
		 * 音声データを再生可能です。<br/>
		 * <br/></para>
		 * <para header='備考'>最大サンプリングレートを下げることで、AuxIn作成時に必要となるワークメモリ
		 * のサイズを抑えることが可能です。</para>
		 * <para header='注意'>指定された最大サンプリングレートを超えるデータは、再生することはできません。<br/>
		 * 例えば、最大サンプリングレートを24000に設定した場合、作成されたAuxInで
		 * 48000Hzの音声を再生することはできません。<br/>
		 * （ダウンサンプリングされて出力されることはありません。）</para>
		 * </remarks>
		 */
		public int maxSamplingRate;

		/**
		 * <summary>サウンドレンダラタイプ</summary>
		 * <remarks>
		 * <para header='説明'>AuxInが使用するサウンドレンダラの種別を指定します。<br/>
		 * CriAtomEx.SoundRendererType.Native を指定した場合、
		 * 音声データは各プラットフォームのサウンド出力に転送されます。<br/>
		 * CriAtomEx.SoundRendererType.Asr を指定した場合、
		 * 音声データはASR（Atom Sound Renderer）に転送されます。<br/>
		 * （ASRの出力先は、ASR初期化時に別途指定。）</para>
		 * </remarks>
		 */
		public CriAtomEx.SoundRendererType soundRendererType;

		public static Config Default {
			get {
				Config config = new Config();
				config.maxChannels = 2;
				config.maxSamplingRate = 48000;
				config.soundRendererType = CriAtomEx.SoundRendererType.Asr;
				return config;
			}
		}
	}

	#region Error Messages
	private const string errorInvalidHandle = "[CRIWARE] Invalid native handle of CriAtomExAuxIn.";
	#endregion

	#region Internal Members
#if CRIWAREPLUGIN_SUPPORT_AUXIN
	private IntPtr handle = IntPtr.Zero;
	private CriAudioReadStream inputReadStream;
#endif
	#endregion

	/**
	 * <summary>AuxInの作成</summary>
	 * <param name='config'>AuxIn作成用コンフィグ構造体</param>
	 * <returns>AtomAuxInハンドル</returns>
	 * <remarks>
	 * <para header='説明'>音声入力用のAuxInを作成します。<br/>
	 * AuxInはADX2の外部の音声データをADX2のDSPバスに流すことができます。<br/>
	 * <br/>
	 * 音声の再生を開始するには::CriAtomExAuxIn::Start 関数を実行します。<br/>
	 * 入力する音声は ::CriAtomExAuxIn::SetInputReadStream に指定するコールバック関数を
	 * 経由してAuxInに渡します。<br/></para>
	 * <para header='注意'>本関数は完了復帰型の関数です。実行にかかる時間は、プラットフォームによって異なります。<br/>
	 * マイクの作成／破棄は、シーンの切り替わり等、負荷変動を許容できる
	 * タイミングで行うようお願いいたします。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAuxIn::Destroy'/>
	 */
	public CriAtomExAuxIn(Config? config = null)
	{
#if CRIWAREPLUGIN_SUPPORT_AUXIN
		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
		Config internalConfig = (config.HasValue) ? config.Value : Config.Default;
		this.handle = criAtomAuxIn_Create(ref internalConfig, IntPtr.Zero, 0);
#else
		Debug.LogError("[CRIWARE] CriAtomExAuxIn does not support this platform.");
#endif
	}

	/**
	 * <summary>AuxInの破棄</summary>
	 * <remarks>
	 * <para header='説明'>AuxInを破棄します。<br/></para>
	 * <para header='注意'>本関数は完了復帰型の関数です。実行にかかる時間は、プラットフォームによって異なります。<br/>
	 * マイクの作成／破棄は、シーンの切り替わり等、負荷変動を許容できる
	 * タイミングで行うようお願いいたします。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAuxIn::CriAtomExAuxIn'/>
	 */
	public override void Dispose()
	{
#if CRIWAREPLUGIN_SUPPORT_AUXIN
		if (this.handle != IntPtr.Zero) {
			criAtomAuxIn_Destroy(this.handle);
			this.handle = IntPtr.Zero;
		}
		GC.SuppressFinalize(this);
		CriDisposableObjectManager.Unregister(this);
#endif
	}

	/**
	 * <summary>AuxInの再生開始</summary>
	 * <remarks>
	 * <para header='説明'>AuxInの再生を開始します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAuxIn::Stop'/>
	 */
	public void Start()
	{
#if CRIWAREPLUGIN_SUPPORT_AUXIN
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		criAtomAuxIn_Start(this.handle);
#endif
	}

	/**
	 * <summary>AuxInの再生停止</summary>
	 * <remarks>
	 * <para header='説明'>AuxInの再生を停止します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAuxIn::Start'/>
	 */
	public void Stop()
	{
#if CRIWAREPLUGIN_SUPPORT_AUXIN
		Debug.Assert(this.handle != IntPtr.Zero, errorInvalidHandle);
		criAtomAuxIn_Stop(this.handle);
#endif
	}

	/**
	 * <summary>フォーマットの設定</summary>
	 * <param name='numChannels'>チャンネル数</param>
	 * <param name='samplingRate'>サンプリング周波数</param>
	 * <remarks>
	 * <para header='説明'>再生を行う音声のフォーマットを設定します。<br/>
	 * ::CriAtomExAuxIn::Start を呼ぶ前に設定する必要があります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAuxIn::GetFormat'/>
	 */
	public void SetFormat(int numChannels, int samplingRate)
	{
#if CRIWAREPLUGIN_SUPPORT_AUXIN
		criAtomAuxIn_SetFormat(this.handle, numChannels, samplingRate);
#endif
	}

	/**
	 * <summary>フォーマットの取得</summary>
	 * <param name='numChannels'>チャンネル数</param>
	 * <param name='samplingRate'>サンプリング周波数</param>
	 * <remarks>
	 * <para header='説明'>::CriAtomExAuxIn::SetFormat で設定したフォーマット情報を取得します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAuxIn::SetFormat'/>
	 */
	public void GetFormat(out int numChannels, out int samplingRate)
	{
#if CRIWAREPLUGIN_SUPPORT_AUXIN
		criAtomAuxIn_GetFormat(this.handle, out numChannels, out samplingRate);
#else
		numChannels = 0;
		samplingRate = 0;
#endif
	}

	/**
	 * <summary>ボリューム設定</summary>
	 * <param name='volume'>ボリューム値</param>
	 * <remarks>
	 * <para header='説明'>AuxInの音声のボリュームを設定をします。<br/>
	 * <br/>
	 * ボリューム値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br/>
	 * 例えば、1.0fを指定した場合、原音はそのままのボリュームで出力されます。<br/>
	 * 0.5fを指定した場合、原音波形の振幅を半分にしたデータと同じ音量（-6dB）で
	 * 音声が出力されます。<br/>
	 * 0.0fを指定した場合、音声はミュートされます（無音になります）。</para>
	 * </remarks>
	 */
	public void SetVolume(float volume)
	{
#if CRIWAREPLUGIN_SUPPORT_AUXIN
		criAtomAuxIn_SetVolume(this.handle, volume);
#endif
	}

	/**
	 * <summary>周波数調整比の設定</summary>
	 * <param name='frequencyRatio'>周波数調整比(0.25f～4.0f)</param>
	 * <remarks>
	 * <para header='説明'>AuxInの音声の周波数調整比を設定します。<br/>
	 * 周波数調整比は、音声データの周波数と再生周波数の比率で、再生速度の倍率と等価です。<br/>
	 * 周波数比が1.0fを超える場合、音声データは原音より高速に再生され、
	 * 1.0f未満の場合は、音声データは原音より低速で再生されます。<br/>
	 * <br/>
	 * 周波数比は、音声のピッチにも影響します。<br/>
	 * 例えば、周波数比を1.0fで再生した場合、音声データは原音通りのピッチで再生されますが、
	 * 周波数比を2.0fに変更した場合、ピッチは1オクターブ上がます。<br/>
	 * （再生速度が2倍になるため。）<br/></para>
	 * <para header='注意'>周波数比に1.0fを超える値を設定した場合、再生する音声のデータが通常より
	 * 速く消費されるため、音声データの供給をより早く行う必要があります。<br/>
	 * 周波数比に1.0fを超える値を設定する場合には、AuxIn作成時に指定する
	 * 最大サンプリングレートの値を、周波数比を考慮した値に設定してください。<br/>
	 * （AuxIn作成時に指定する ::CriAtomExAuxIn::Config 構造体
	 * の maxSamplingRate の値に、「原音のサンプリングレート×周波数比」で
	 * 計算される値を指定する必要があります。）<br/></para>
	 * </remarks>
	 */
	public void SetFrequencyRatio(float frequencyRatio)
	{
#if CRIWAREPLUGIN_SUPPORT_AUXIN
		criAtomAuxIn_SetFrequencyRatio(this.handle, frequencyRatio);
#endif
	}

	/**
	 * <summary>バスセンドレベル設定</summary>
	 * <param name='busName'>バス名</param>
	 * <param name='level'>レベル値（0.0f?1.0f）</param>
	 * <remarks>
	 * <para header='説明'>AuxInの音声のバスセンドレベルを設定します。<br/>
	 * バスセンドレベルは、音声をどのバスにどれだけ流すかを指定するための仕組みです。<br/>
	 * <br/>
	 * 第2引数にはDSPバス設定内のバス名を指定します。<br/>
	 * 第3引数では送信時のレベル（ボリューム）を指定します。<br/>
	 * <br/>
	 * 第2引数のバス名で指定したバスが適用中のDSPバス設定に存在しない場合、設定値は無効値として処理されます。<br/>
	 * センドレベル値の範囲や扱いは、ボリュームと同等です。::CriAtomExAuxIn::SetVolume 関数を参照してください。</para>
	 * </remarks>
	 */
	public void SetBusSendLevel(string busName, float level)
	{
#if CRIWAREPLUGIN_SUPPORT_AUXIN
		criAtomAuxIn_SetBusSendLevelByName(this.handle, busName, level);
#endif
	}

	/**
	 * <summary>リードストリームの設定</summary>
	 * <param name='stream'>リードストリーム</param>
	 * <remarks>
	 * <para header='説明'>AuxInの入力方向のリードストリームを設定します。<br/>
	 * コールバック関数は大抵のプラットフォームで別スレッドから呼ばれるため、
	 * 呼ばれる側はスレッドセーフ実装する必要があります。</para>
	 * </remarks>
	 */
	public void SetInputReadStream(CriAudioReadStream stream)
	{
#if CRIWAREPLUGIN_SUPPORT_AUXIN
		this.inputReadStream = stream;
		criAtomAuxIn_SetInputReadStream(this.handle, stream.callbackFunction, stream.callbackPointer);
#endif
	}

	#region DLL Import
#if CRIWAREPLUGIN_SUPPORT_AUXIN
	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomAuxIn_Create([In] ref Config config, IntPtr work, int work_size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomAuxIn_Destroy(IntPtr aux_in);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomAuxIn_Start(IntPtr aux_in);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomAuxIn_Stop(IntPtr aux_in);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomAuxIn_SetVolume(IntPtr aux_in, float volume);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomAuxIn_SetFrequencyRatio(IntPtr aux_in, float ratio);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomAuxIn_SetBusSendLevelByName(IntPtr aux_in, string bus_name, float level);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomAuxIn_SetFormat(IntPtr aux_in, int num_channels, int sampling_rate);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomAuxIn_GetFormat(IntPtr aux_in, out int num_channels, out int sampling_rate);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomAuxIn_SetInputReadStream(IntPtr aux_in, IntPtr stream_cbfunc, IntPtr stream_ptr);
	#else
	private static IntPtr criAtomAuxIn_Create([In] ref Config config, IntPtr work, int work_size) { return new IntPtr(1); }
	private static void criAtomAuxIn_Destroy(IntPtr aux_in) { }
	private static void criAtomAuxIn_Start(IntPtr aux_in) { }
	private static void criAtomAuxIn_Stop(IntPtr aux_in) { }
	private static void criAtomAuxIn_SetVolume(IntPtr aux_in, float volume) { }
	private static void criAtomAuxIn_SetFrequencyRatio(IntPtr aux_in, float ratio) { }
	private static void criAtomAuxIn_SetBusSendLevelByName(IntPtr aux_in, string bus_name, float level) { }
	private static void criAtomAuxIn_SetFormat(IntPtr aux_in, int num_channels, int sampling_rate) { }
	private static void criAtomAuxIn_GetFormat(IntPtr aux_in, out int num_channels, out int sampling_rate) { num_channels = sampling_rate = 0; }
	private static void criAtomAuxIn_SetInputReadStream(IntPtr aux_in, IntPtr stream_cbfunc, IntPtr stream_ptr) { }
	#endif
#endif
	#endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
