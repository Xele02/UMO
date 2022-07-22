/****************************************************************************
 *
 * Copyright (c) 2020 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

#if !UNITY_WEBGL
	#define CRIWARE_TRANSCEIVER_N_ELEVATIONANGLEAISAC_SUPPORT
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
 * <summary>3Dトランシーバーオブジェクト</summary>
 * <remarks>
 * <para header='説明'>3Dトランシーバーを取り扱うためのオブジェクトです。<br/>
 * <br/>
 * 3Dトランシーバーのパラメータ、位置情報の設定等は、このオブジェクトを介して実行されます。</para>
 * </remarks>
 */
public class CriAtomEx3dTransceiver : CriDisposable
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct Config
	{
		public int reserved;
	}

	/**
	 * <summary>3Dトランシーバーオブジェクトの作成</summary>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバーを作成します。<br/></para>
	 * <para header='注意'>本関数を実行する前に、ライブラリを初期化しておく必要があります。<br/></para>
	 * </remarks>
	 */
	public CriAtomEx3dTransceiver()
	{
		Config config = new Config();
		this.handle = UnsafeNativeMethods.criAtomEx3dTransceiver_Create(ref config, IntPtr.Zero, 0);
		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
	}

	/**
	 * <summary>3Dトランシーバーオブジェクトの破棄</summary>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバーオブジェクトを破棄します。<br/>
	 * 本関数を実行した時点で、3Dトランシーバーオブジェクト作成時にDLL内で確保されたリソースが全て解放され、<br/>
	 * 3Dトランシーバーが無効になります。</para>
	 * </remarks>
	 */
	public override void Dispose()
	{
		this.Dispose(true);
	}

	private void Dispose(bool disposing)
	{
		CriDisposableObjectManager.Unregister(this);

		if (this.handle != IntPtr.Zero) {
			UnsafeNativeMethods.criAtomEx3dTransceiver_Destroy(this.handle);
			this.handle = IntPtr.Zero;
		}

		if (disposing) {
			GC.SuppressFinalize(this);
		}
	}

	public IntPtr nativeHandle
	{
		get { return this.handle; }
	}

	/**
	 * <summary>3Dトランシーバーの更新</summary>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバーに設定されているパラメータを使用して、3Dトランシーバーを更新します。<br/>
	 * 本関数では、3Dトランシーバーに設定されているすべてのパラメータを更新します。<br/>
	 * パラメータをひとつ変更する度に本関数にて更新処理を行うよりも、
	 * 複数のパラメータを変更してから更新処理を行った方が効率的です。<br/></para>
	 * <para header='注意'>本関数はAtomExプレーヤのパラメータ更新（ ::CriAtomExPlayer::UpdateAll, CriAtomExPlayer::Update ）
	 * とは独立して動作します。<br/>
	 * 3Dトランシーバーのパラメータを変更した際は、本関数にて更新処理を行ってください。</para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // トランシーバーの作成
	 * CriAtomEx3dTransceiver transceiver = new CriAtomEx3dTransceiver();
	 *  ：
	 * // トランシーバーの入力位置を設定
	 * transceiver.SetInputPosition(Vector3.zero);
	 *
	 * // トランシーバーの出力位置を設定
	 * transceiver.SetOutputPosition(Vector3.zero);
	 *
	 * // 注意）この時点ではトランシーバーの位置はまだ変更されていません。
	 *
	 * // 変更の適用
	 * transceiver.Update();
	 *  ：
	 * </code></example>
	 */
	public void Update()
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_Update(this.handle);
	}

	/**
	 * <summary>3Dトランシーバー入力の位置の設定</summary>
	 * <param name='position'>入力位置ベクトル</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバー入力の位置を設定します。<br/>
	 * 位置は、距離減衰、および定位計算に使用されます。<br/>
	 * 位置は、3次元ベクトルで指定します。<br/>
	 * デフォルト値は(0.0f, 0.0f, 0.0f)です。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetInputPosition(Vector3 position)
	{
		CriAtomEx.NativeVector pos = new CriAtomEx.NativeVector(position);
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetInputPosition(this.handle, ref pos);
	}

	/**
	 * <summary>3Dトランシーバー出力の位置の設定</summary>
	 * <param name='position'>出力位置ベクトル</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバー出力の位置を設定します。<br/>
	 * 位置は、距離減衰、および定位計算に使用されます。<br/>
	 * 位置は、3次元ベクトルで指定します。<br/>
	 * デフォルト値は(0.0f, 0.0f, 0.0f)です。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetOutputPosition(Vector3 position)
	{
		CriAtomEx.NativeVector pos = new CriAtomEx.NativeVector(position);
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetOutputPosition(this.handle, ref pos);
	}

	/**
	 * <summary>3Dトランシーバー入力の向きの設定</summary>
	 * <param name='front'>前方ベクトル</param>
	 * <param name='top'>上方ベクトル</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバーの向きを前方ベクトルと上方ベクトルで設定します。<br/>
	 * 向きは、3次元ベクトルで指定します。設定された向きベクトルは、ライブラリ内部で正規化して使用されます。<br/>
	 * デフォルト値以下のとおりです。<br/>
	 *  - 前方ベクトル：(0.0f, 0.0f, 1.0f)
	 *  - 上方ベクトル：(0.0f, 1.0f, 0.0f)</para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetInputOrientation(Vector3 front, Vector3 top)
	{
		CriAtomEx.NativeVector orient_front = new CriAtomEx.NativeVector(front);
		CriAtomEx.NativeVector orient_top = new CriAtomEx.NativeVector(top);
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetInputOrientation(this.handle, ref orient_front, ref orient_top);
	}

	/**
	 * <summary>3Dトランシーバー出力の向きの設定</summary>
	 * <param name='front'>前方ベクトル</param>
	 * <param name='top'>上方ベクトル</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバーの向きを前方ベクトルと上方ベクトルで設定します。<br/>
	 * 向きは、3次元ベクトルで指定します。設定された向きベクトルは、ライブラリ内部で正規化して使用されます。<br/>
	 * デフォルト値以下のとおりです。<br/>
	 *  - 前方ベクトル：(0.0f, 0.0f, 1.0f)
	 *  - 上方ベクトル：(0.0f, 1.0f, 0.0f)</para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetOutputOrientation(Vector3 front, Vector3 top)
	{
		CriAtomEx.NativeVector orient_front = new CriAtomEx.NativeVector(front);
		CriAtomEx.NativeVector orient_top = new CriAtomEx.NativeVector(top);
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetOutputOrientation(this.handle, ref orient_front, ref orient_top);
	}

	/**
	 * <summary>3Dトランシーバー出力のサウンドコーンパラメータの設定</summary>
	 * <param name='insideAngle'>サウンドコーンのインサイドアングル</param>
	 * <param name='outsideAngle'>サウンドコーンのアウトサイドアングル</param>
	 * <param name='outsideVolume'>サウンドコーンのアウトサイドボリューム</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバー出力のサウンドコーンパラメータを設定します。<br/>
	 * サウンドコーンは、トランシーバーから音が発生する方向を表し、音の指向性の表現に使用されます。<br/>
	 * サウンドコーンは、内側コーン、外側コーンで構成されます。インサイドアングルは内側コーンの角度、
	 * アウトサイドアングルは外側コーンの角度、アウトサイドボリュームは外側コーンの角度以上の方向での音量を
	 * それぞれ表します。<br/>
	 * 内側コーンの角度より小さい角度の方向では、コーンによる減衰を受けません。
	 * 内側コーンと外側コーンの間の方向では、徐々にアウトサイドボリュームまで減衰します。<br/>
	 * インサイドアングルおよびアウトサイドアングルは、0.0f～360.0fを度で指定します。<br/>
	 * アウトサイドボリュームは、0.0f～1.0fを振幅に対する倍率で指定します（単位はデシベルではありません）。<br/>
	 * ライブラリ初期化時のデフォルト値は以下のとおりであり、コーンによる減衰は行われません。<br/>
	 *  - インサイドアングル：360.0f
	 *  - アウトサイドアングル：360.0f
	 *  - アウトサイドボリューム：0.0f
	 *  .</para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetOutputConeParameter(float insideAngle, float outsideAngle, float outsideVolume)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetOutputConeParameter(this.handle, insideAngle, outsideAngle, outsideVolume);
	}

	/**
	 * <summary>3Dトランシーバー出力の最小距離／最大距離の設定</summary>
	 * <param name='minDistance'>最小距離</param>
	 * <param name='maxDistance'>最大距離</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバー出力の最小距離／最大距離を設定します。<br/>
	 * 最小距離は、これ以上音量が大きくならない距離を表します。<br/>
	 * 最大距離は、最小音量になる距離を表します。<br/>
	 * ライブラリ初期化時のデフォルト値は以下のとおりです。<br/>
	 *  - 最小距離：0.0f
	 *  - 最大距離：0.0f
	 *  .
	 * データ側に最小距離／最大距離が設定されている場合に本関数を呼び出すと、
	 * データ側の値を上書き（無視）して適用されます。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetOutputMinMaxDistance(float minDistance, float maxDistance)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetOutputMinMaxAttenuationDistance(this.handle, minDistance, maxDistance);
	}

	/**
	 * <summary>3Dトランシーバー出力のインテリアパンニング境界距離の設定</summary>
	 * <param name='radius'>3Dトランシーバー出力の半径</param>
	 * <param name='interiorDistance'>インテリア距離</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバー出力のインテリアパンニング境界距離の設定をします。<br/>
	 * 3Dトランシーバー出力の半径は、3Dトランシーバー出力を球としたときの半径です。<br/>
	 * インテリア距離は、インテリアパンニング適用される3D音源の半径からの距離です。<br/>
	 * 3Dトランシーバー出力の半径内では、インテリアパンニング適用されますが、インテリア距離が0.0と扱われるため、
	 * 全てのスピーカーから同じ音量で音声が再生されます。<br/>
	 * インテリア距離内では、インテリアパンニング適用されます。<br/>
	 * インテリア距離外では、インテリアパンニング適用されず、3Dトランシーバー出力位置に最も近い1つ、
	 * または2つのスピーカーから音声が再生されます。<br/>
	 * ライブラリ初期化時のデフォルト値は以下のとおりです。<br/>
	 *  - 3Dトランシーバーの半径：0.0f
	 *  - インテリア距離：0.0f（3Dトランシーバーの最小距離に依存）
	 *  .</para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 * <seealso cref='CriAtomEx3dTransceiver::SetMinMaxDistance'/>
	 */
	public void SetOutputInteriorPanField(float radius, float interiorDistance)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetOutputInteriorPanField(this.handle, radius, interiorDistance);
	}

	/**
	 * <summary>3Dトランシーバー入力のクロスフェード境界距離の設定</summary>
	 * <param name='directAudioRadius'>直接音領域の半径</param>
	 * <param name='crossfadeDistance'>クロスフェード距離</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバー入力のクロスフェード境界距離の設定をします。<br/>
	 * 直接音領域の半径内では、3Dトランシーバーの出力からの音声は再生されず、3D音源からの音声のみが再生されます。<br/>
	 * クロスフェード距離は、3Dトランシーバー出力と3D音源からの音声のクロスフェードが適用される直接音領域からの距離です。<br/>
	 * 直接音領域では、クロスフェードの割合が音源からの音声=1、3Dトランシーバーからの音声=0になるので、
	 * 3Dトランシーバー出力からの音声は聞こえなくなり、音源からの音声のみが再生されます。<br/>
	 * クロスフェード距離内では、リスナーの位置に応じてクロスフェードが適用されます。<br/>
	 * クロスフェード距離外では、3D音源からの音声は聞こえず、3Dトランシーバー出力からの音声のみが聞こえるようになります。
	 * ライブラリ初期化時のデフォルト値は以下のとおりです。<br/>
	 *  - 直接音領域の半径：0.0f
	 *  - クロスフェード距離：0.0f
	 *  .</para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 * <seealso cref='CriAtomEx3dTransceiver::SetMinMaxDistance'/>
	 */
	public void SetInputCrossFadeField(float directAudioRadius, float crossfadeDistance)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetInputCrossFadeField(this.handle, directAudioRadius, crossfadeDistance);
	}

	/**
	 * <summary>3Dトランシーバー出力のボリュームの設定</summary>
	 * <param name='volume'>ボリューム</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバー出力のボリュームを設定します。<br/>
	 * 3Dトランシーバー出力のボリュームは、定位に関わる音量（L,R,SL,SR）にのみ影響し、
	 * LFEやセンターへの出力レベルには影響しません。<br/>
	 * ボリューム値には、0.0f～1.0fの範囲で実数値を指定します。<br/>
	 * ボリューム値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br/>
	 * 例えば、1.0fを指定した場合、原音はそのままのボリュームで出力されます。<br/>
	 * 0.5fを指定した場合、原音波形の振幅を半分にしたデータと同じ音量（-6dB）で
	 * 音声が出力されます。<br/>
	 * 0.0fを指定した場合、音声はミュートされます（無音になります）。<br/>
	 * ライブラリ初期化時のデフォルト値は1.0fです。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetOutputVolume(float volume)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetOutputVolume(this.handle, volume);
	}

	/**
	 * <summary>3DトランシーバーにAISACを取り付ける</summary>
	 * <param name='globalAisacName'>取り付けるグローバルAISAC名</param>
	 * <remarks>
	 * <para header='説明'>3DトランシーバーにAISACをアタッチ（取り付け）します。
	 * AISACをアタッチすることにより、キューやトラックにAISACを設定していなくても、
	 * AISACの効果を得ることができます。<br/>
	 * <br/>
	 * AISACのアタッチに失敗した場合、CriWareErrorHandlerでエラーコールバックが発生します。<br/>
	 * AISACのアタッチに失敗した理由については、エラーメッセージを確認してください。<br/></para>
	 * <para header='備考'>全体設定（ACFファイル）に含まれるグローバルAISACのみ、アタッチ可能です。<br/>
	 * AISACの効果を得るには、キューやトラックに設定されているAISACと同様に、
	 * 該当するAISACコントロール値を設定する必要があります。<br/></para>
	 * <para header='注意'>キューやトラックに「AISACコントロール値を変更するAISAC」が設定されていたとしても、
	 * その適用結果のAISACコントロール値は、3DトランシーバーにアタッチしたAISACには影響しません。<br/>
	 * 現在、「オートモジュレーション」や「ランダム」といったコントロールタイプのAISACの
	 * アタッチには対応しておりません。<br/>
	 * 現在、3DトランシーバーにアタッチできるAISACの最大数は、8個固定です。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::DetachAisac'/>
	 */
	public void AttachAisac(string globalAisacName)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_AttachAisac(this.handle, globalAisacName);
	}

	/**
	 * <summary>3DトランシーバーからAISACを取り外す</summary>
	 * <param name='globalAisacName'>取り外すグローバルAISAC名</param>
	 * <remarks>
	 * <para header='説明'>3DトランシーバーからAISACをデタッチ（取り外し）します。<br/>
	 * <br/>
	 * AISACのデタッチに失敗した場合、CriWareErrorHandlerでエラーコールバックが発生します。<br/>
	 * AISACのデタッチに失敗した理由については、エラーメッセージを確認してください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::AttachAisac'/>
	 */
	public void DetachAisac(string globalAisacName)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_DetachAisac(this.handle, globalAisacName);
	}

	/**
	 * <summary>角度AISACコントロール値の最大変化量の設定</summary>
	 * <param name='maxDelta'>角度AISACコントロール値の最大変化量</param>
	 * <remarks>
	 * <para header='説明'>角度AISACによりAISACコントロール値が変更される際の、最大変化量を設定します。<br/>
	 * 最大変化量を低めに変更すると、3Dトランシーバーとリスナー間の相対角度が急激に変わった場合でも、
	 * 角度AISACによるAISACコントロール値の変化をスムーズにすることができます。<br/>
	 * 例えば、(0.5f / 30.0f)を設定すると、角度が0度->180度に変化した場合に、
	 * 30フレームかけて変化するような変化量となります。<br/>
	 * デフォルト値は1.0f（制限なし）です。
	 * データ側では本パラメータは設定できないため、常に本関数での設定値が使用されます。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、
	 * ::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。<br/>
	 * 本関数で設定している最大変化量は、定位角度を元に計算されている、
	 * 角度AISACコントロール値の変化にのみ適用されます。
	 * 定位角度自体には影響はありません。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetMaxAngleAisacDelta(float maxDelta)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetMaxAngleAisacDelta(this.handle, maxDelta);
	}

	/**
	 * <summary>距離AISACコントロールIDの設定</summary>
	 * <param name='aisacControlId'>距離AISACコントロールID</param>
	 * <remarks>
	 * <para header='説明'>最小距離、最大距離間の距離減衰に連動するAISACコントロールIDを指定します。<br/>
	 * 本関数でAISACコントロールIDを設定した場合、デフォルトの距離減衰は無効になります。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetDistanceAisacControlId(ushort aisacControlId)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetDistanceAisacControlId(this.handle, aisacControlId);
	}

	/**
	 * <summary>リスナー基準方位角AISACコントロールIDの設定</summary>
	 * <param name='aisacControlId'>リスナー基準方位角AISACコントロールID</param>
	 * <remarks>
	 * <para header='説明'>リスナーから見た3Dトランシーバーの方位角に連動するAISACコントロールIDを指定します。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetListenerBasedAzimuthAngleAisacControlId(ushort aisacControlId)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetListenerBasedAzimuthAngleAisacControlId(this.handle, aisacControlId);
	}

	/**
	 * <summary>リスナー基準仰俯角AISACコントロールIDの設定</summary>
	 * <param name='aisacControlId'>リスナー基準仰俯角AISACコントロールID</param>
	 * <remarks>
	 * <para header='説明'>リスナーから見た3Dトランシーバーの仰俯角に連動するAISACコントロールIDを指定します。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetListenerBasedElevationAngleAisacControlId(ushort aisacControlId)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetListenerBasedElevationAngleAisacControlId(this.handle, aisacControlId);
	}

	/**
	 * <summary>3Dトランシーバー出力基準方位角AISACコントロールIDの設定</summary>
	 * <param name='aisacControlId'>3Dトランシーバー基準方位角AISACコントロールID</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバー出力の位置から見たリスナーの方位角に連動するAISACコントロールIDを指定します。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetTransceiverOutputBasedAzimuthAngleAisacControlId(ushort aisacControlId)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetTransceiverOutputBasedAzimuthAngleAisacControlId(this.handle, aisacControlId);
	}

	/**
	 * <summary>3Dトランシーバー出力基準仰俯角AISACコントロールIDの設定</summary>
	 * <param name='aisacControlId'>3Dトランシーバー基準仰俯角AISACコントロールID</param>
	 * <remarks>
	 * <para header='説明'>3Dトランシーバー出力の位置から見たリスナーの仰俯角に連動するAISACコントロールIDを指定します。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、::CriAtomEx3dTransceiver::Update 関数を呼び出す必要があります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void SetTransceiverOutputBasedElevationAngleAisacControlId(ushort aisacControlId)
	{
		UnsafeNativeMethods.criAtomEx3dTransceiver_SetTransceiverOutputBasedElevationAngleAisacControlId(this.handle, aisacControlId);
	}

	/**
	 * <summary>3Dリージョンの設定</summary>
	 * <remarks>
	 * <para header='説明'>3D音源に対して3Dリージョンを設定します。</para>
	 * <para header='注意'>同一のExPlayerに設定されている3D音源と3Dリスナーに設定されているリージョンが異なり、<br/>
	 * かつ3D音源と同じリージョンが設定されている3Dトランシーバーがない場合、音声はミュートされます。<br/>
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dSource::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dRegion::Create'/>
	 * <seealso cref='CriAtomEx3dTransceiver::Update'/>
	 */
	public void Set3dRegion(CriAtomEx3dRegion region3d)
	{
		IntPtr region3dHandle = (region3d == null) ? IntPtr.Zero : region3d.nativeHandle;
		UnsafeNativeMethods.criAtomEx3dTransceiver_Set3dRegionHn(this.handle, region3dHandle);
	}

	#region Internal Members
	~CriAtomEx3dTransceiver()
	{
		this.Dispose(false);
	}

	private IntPtr handle = IntPtr.Zero;
	#endregion

	#region Dll Import
	private static class UnsafeNativeMethods
	{
#if !CRIWARE_ENABLE_HEADLESS_MODE && CRIWARE_TRANSCEIVER_N_ELEVATIONANGLEAISAC_SUPPORT
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern IntPtr criAtomEx3dTransceiver_Create(ref Config config, IntPtr work, int work_size);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_Destroy(IntPtr ex_3d_transceiver);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_Update(IntPtr ex_3d_transceiver);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetInputPosition(IntPtr ex_3d_transceiver, ref CriAtomEx.NativeVector position);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetOutputPosition(IntPtr ex_3d_transceiver, ref CriAtomEx.NativeVector position);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetInputOrientation(IntPtr ex_3d_transceiver, ref CriAtomEx.NativeVector front, ref CriAtomEx.NativeVector top);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetOutputOrientation(IntPtr ex_3d_transceiver, ref CriAtomEx.NativeVector front, ref CriAtomEx.NativeVector top);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetOutputConeParameter(IntPtr ex_3d_transceiver, float inside_angle, float outside_angle, float outside_volume);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetOutputMinMaxAttenuationDistance(IntPtr ex_3d_transceiver, float min_attenuation_distance, float max_attenuation_distance);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetOutputInteriorPanField(IntPtr ex_3d_transceiver, float transceiver_radius, float interior_distance);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetInputCrossFadeField(IntPtr ex_3d_transceiver, float direct_audio_radius, float crossfade_distance);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetOutputVolume(IntPtr ex_3d_transceiver, float volume);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_AttachAisac(IntPtr ex_3d_transceiver, string global_aisac_name);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_DetachAisac(IntPtr ex_3d_transceiver, string global_aisac_name);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetMaxAngleAisacDelta(IntPtr ex_3d_transceiver, float max_delta);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetDistanceAisacControlId(IntPtr ex_3d_transceiver, ushort aisac_control_id);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetListenerBasedAzimuthAngleAisacControlId(IntPtr ex_3d_transceiver, ushort aisac_control_id);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetListenerBasedElevationAngleAisacControlId(IntPtr ex_3d_transceiver, ushort aisac_control_id);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetTransceiverOutputBasedAzimuthAngleAisacControlId(IntPtr ex_3d_transceiver, ushort aisac_control_id);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_SetTransceiverOutputBasedElevationAngleAisacControlId(IntPtr ex_3d_transceiver, ushort aisac_control_id);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dTransceiver_Set3dRegionHn(IntPtr ex_3d_transceiver, IntPtr ex_3d_region);
#else
		internal static IntPtr criAtomEx3dTransceiver_Create(ref Config config, IntPtr work, int work_size) { return IntPtr.Zero; }
		internal static void criAtomEx3dTransceiver_Destroy(IntPtr ex_3d_transceiver) { }
		internal static void criAtomEx3dTransceiver_Update(IntPtr ex_3d_transceiver) { }
		internal static void criAtomEx3dTransceiver_SetInputPosition(IntPtr ex_3d_transceiver, ref CriAtomEx.NativeVector position) { }
		internal static void criAtomEx3dTransceiver_SetOutputPosition(IntPtr ex_3d_transceiver, ref CriAtomEx.NativeVector position) { }
		internal static void criAtomEx3dTransceiver_SetInputOrientation(IntPtr ex_3d_transceiver, ref CriAtomEx.NativeVector front, ref CriAtomEx.NativeVector top) { }
		internal static void criAtomEx3dTransceiver_SetOutputOrientation(IntPtr ex_3d_transceiver, ref CriAtomEx.NativeVector front, ref CriAtomEx.NativeVector top) { }
		internal static void criAtomEx3dTransceiver_SetOutputConeParameter(IntPtr ex_3d_transceiver, float inside_angle, float outside_angle, float outside_volume) { }
		internal static void criAtomEx3dTransceiver_SetOutputMinMaxAttenuationDistance(IntPtr ex_3d_transceiver, float min_attenuation_distance, float max_attenuation_distance) { }
		internal static void criAtomEx3dTransceiver_SetOutputInteriorPanField(IntPtr ex_3d_transceiver, float transceiver_radius, float interior_distance) { }
		internal static void criAtomEx3dTransceiver_SetInputCrossFadeField(IntPtr ex_3d_transceiver, float direct_audio_radius, float crossfade_distance) { }
		internal static void criAtomEx3dTransceiver_SetOutputVolume(IntPtr ex_3d_transceiver, float volume) { }
		internal static void criAtomEx3dTransceiver_AttachAisac(IntPtr ex_3d_transceiver, string global_aisac_name) { }
		internal static void criAtomEx3dTransceiver_DetachAisac(IntPtr ex_3d_transceiver, string global_aisac_name) { }
		internal static void criAtomEx3dTransceiver_SetMaxAngleAisacDelta(IntPtr ex_3d_transceiver, float max_delta) { }
		internal static void criAtomEx3dTransceiver_SetDistanceAisacControlId(IntPtr ex_3d_transceiver, ushort aisac_control_id) { }
		internal static void criAtomEx3dTransceiver_SetListenerBasedAzimuthAngleAisacControlId(IntPtr ex_3d_transceiver, ushort aisac_control_id) { }
		internal static void criAtomEx3dTransceiver_SetListenerBasedElevationAngleAisacControlId(IntPtr ex_3d_transceiver, ushort aisac_control_id) { }
		internal static void criAtomEx3dTransceiver_SetTransceiverOutputBasedAzimuthAngleAisacControlId(IntPtr ex_3d_transceiver, ushort aisac_control_id) { }
		internal static void criAtomEx3dTransceiver_SetTransceiverOutputBasedElevationAngleAisacControlId(IntPtr ex_3d_transceiver, ushort aisac_control_id) { }
		internal static void criAtomEx3dTransceiver_Set3dRegionHn(IntPtr ex_3d_transceiver, IntPtr ex_3d_region) { }
#endif
	}
	#endregion
}


/**
 * <summary>3Dリージョンオブジェクト</summary>
 * <remarks>
 * <para header='説明'>3Dリージョンを取り扱うためのオブジェクトです。</para>
 * </remarks>
 */
public class CriAtomEx3dRegion : CriDisposable
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct Config
	{
		public int reserved;
	}

	/**
	 * <summary>3Dリージョンオブジェクトの作成</summary>
	 * <remarks>
	 * <para header='説明'>3Dリージョンオブジェクトを作成します。<br/></para>
	 * <para header='注意'>本関数を実行する前に、ライブラリを初期化しておく必要があります。<br/></para>
	 * </remarks>
	 */
	public CriAtomEx3dRegion()
	{
		Config config = new Config();
		this.handle = UnsafeNativeMethods.criAtomEx3dRegion_Create(ref config, IntPtr.Zero, 0);
		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
	}

	/**
	 * <summary>3Dリージョンオブジェクトの破棄</summary>
	 * <remarks>
	 * <para header='説明'>3Dリージョンオブジェクトを破棄します。<br/>
	 * 本関数を実行した時点で、3Dリージョンオブジェクト作成時にDLL内で確保されたリソースが全て解放され、<br/>
	 * 3Dリージョンオブジェクトが無効になります。</para>
	 * </remarks>
	 */
	public override void Dispose()
	{
		this.Dispose(true);
	}

	private void Dispose(bool disposing)
	{
		CriDisposableObjectManager.Unregister(this);

		if (this.handle != IntPtr.Zero) {
			UnsafeNativeMethods.criAtomEx3dRegion_Destroy(this.handle);
			this.handle = IntPtr.Zero;
		}

		if (disposing) {
			GC.SuppressFinalize(this);
		}
	}

	~CriAtomEx3dRegion()
	{
		this.Dispose(false);
	}

	public IntPtr nativeHandle
	{
		get { return this.handle; }
	}

	private IntPtr handle = IntPtr.Zero;

	private static class UnsafeNativeMethods
	{
#if !CRIWARE_ENABLE_HEADLESS_MODE && CRIWARE_TRANSCEIVER_N_ELEVATIONANGLEAISAC_SUPPORT
		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern IntPtr criAtomEx3dRegion_Create(ref Config config, IntPtr work, int work_size);

		[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
		internal static extern void criAtomEx3dRegion_Destroy(IntPtr ex_3d_region);
#else
		internal static IntPtr criAtomEx3dRegion_Create(ref Config config, IntPtr work, int work_size) { return IntPtr.Zero; }
		internal static void criAtomEx3dRegion_Destroy(IntPtr ex_3d_region) { }
#endif
	}
} // end of class

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
