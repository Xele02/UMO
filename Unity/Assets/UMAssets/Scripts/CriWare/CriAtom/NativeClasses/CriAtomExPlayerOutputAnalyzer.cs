/****************************************************************************
 *
 * Copyright (c) 2018 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

/*==========================================================================
 *      CRI Atom Native Wrapper
 *=========================================================================*/
/**
 * \addtogroup CRIATOM_NATIVE_WRAPPER
 * @{
 */

namespace CriWare {

/**
 * \deprecated
 * 削除予定の非推奨APIです。
 * CriAtomExOutputAnalyzerクラスの使用を検討してください。
 * <summary>音声出力データ解析モジュール（プレーヤ/ソース単位)</summary>
 * <remarks>
 * <para header='説明'>CriAtomSource/CriAtomExPlayerごとの音声出力の解析を行います。<br/>
 * レベルメータ機能などを提供します。<br/></para>
 * <para header='注意'>将来的に本クラスは廃止される予定です。CriAtomExOutputAnalyzerをご利用ください。<br/>
 * HCA-MXやプラットフォーム固有の音声圧縮コーデックを使用している場合は解析できません。<br/>
 * HCAもしくはADXコーデックをご利用ください。</para>
 * </remarks>
*/
[System.Obsolete("Use CriAtomExOutputAnalyzer")]
public class CriAtomExPlayerOutputAnalyzer : CriAtomExOutputAnalyzer
{
	/**
	 * <summary>解析処理種別</summary>
	 * <remarks>
	 * <para header='説明'>解析モジュール作成時に指定する解析処理の種別を示す値です。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExOutputAnalyzer'/>
	 */
	public enum Type {
		LevelMeter = 0,         /**< レベルメーター(RMSレベル計測) */
		SpectrumAnalyzer = 1,   /**< スペクトルアナライザ */
		PcmCapture = 2,         /**< 波形データ取得 */
	}

	/**
	 * <summary>音声出力データ解析モジュールコンフィグ構造体</summary>
	 * <remarks>
	 * <para header='説明'>解析モジュール作成時に指定するコンフィグです。<br/>
	 * num_spectrum_analyzer_bands：スペクトルアナライザのバンド数<br/>
	 * num_stored_output_data：記録する出力データサンプル数<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayerOutputAnalyzer'/>
	 */
	public new struct Config {
		public int num_spectrum_analyzer_bands;
		public int num_stored_output_data;

		public Config(int num_spectrum_analyzer_bands = 8, int num_stored_output_data = 4096)
		{
			this.num_spectrum_analyzer_bands = num_spectrum_analyzer_bands;
			this.num_stored_output_data = num_stored_output_data;
		}
	}

	/**
	 * <summary>音声出力データ解析モジュールの作成</summary>
	 * <returns>音声出力データ解析モジュール</returns>
	 * <remarks>
	 * <para header='説明'>CriAtomSource/CriAtomExPlayerの出力音声データの解析モジュールを作成します。<br/>
	 * 作成した解析モジュールは、CriAtomSourceまたはCriAtomExPlayerにアタッチして使用します。<br/>
	 * アタッチしている音声出力に対し、レベルメータなどの解析を行います。<br/></para>
	 * <para header='備考'>解析モジュールにアタッチ可能なCriAtomSource/CriAtomExPlayerは一つのみです。<br/>
	 * 解析モジュールを使いまわす場合は、デタッチを行ってください。<br/></para>
	 * <para header='注意'>将来的に本クラスは廃止される予定です。CriAtomExOutputAnalyzerをご利用ください。<br/>
	 * 音声出力データ解析モジュールの作成時には、アンマネージドなリソースが確保されます。<br/>
	 * 解析モジュールが不要になった際は、必ず CriAtomExPlayerOutputAnalyzer.Dispose メソッドを呼んでください。</para>
	 * </remarks>
	 */
	public CriAtomExPlayerOutputAnalyzer(Type[] types, Config[] configs = null)
		: base()
	{
		CriAtomExOutputAnalyzer.Config config = new CriAtomExOutputAnalyzer.Config();
		for (int i = 0; i < types.Length; i++) {
			switch (types[i]) {
				case Type.LevelMeter:
				{
					config.enableLevelmeter = true;
					break;
				}
				case Type.SpectrumAnalyzer:
				{
					config.enableSpectrumAnalyzer = true;
					if (configs != null && configs.Length > i) {
						config.numSpectrumAnalyzerBands = configs[i].num_spectrum_analyzer_bands;
					} else {
						config.numSpectrumAnalyzerBands = 8;
					}
					break;
				}
				case Type.PcmCapture:
				{
					config.enablePcmCapture = true;
					if (configs != null && configs.Length > i) {
						config.numCapturedPcmSamples = configs[i].num_stored_output_data;
					} else {
						config.numCapturedPcmSamples = 4096;
					}
					break;
				}
			}
		}
		this.InitializeWithConfig(config);
	}
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
