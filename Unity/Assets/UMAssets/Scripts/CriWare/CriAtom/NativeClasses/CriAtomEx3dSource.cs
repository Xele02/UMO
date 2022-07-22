/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom Native Wrapper
 * File     : CriAtomEx3dSource.cs
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

/**
 * <summary>3D音源オブジェクト</summary>
 * \par 説明:
 * 3D音源を扱うためのオブジェクトです。<br>
 * 3Dポジショニング機能に使用します。<br>
 * <br>
 * 3D音源のパラメータ、位置情報の設定等は、3D音源オブジェクトを介して実行されます。
 */
public class CriAtomEx3dSource : IDisposable
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct Config {
		public int reserved;
	}

	/**
	 * <summary>3D音源オブジェクトの作成</summary>
	 * \par 説明:
	 * 3D音源オブジェクト作成用コンフィグに基づいて、3D音源オブジェクトを作成します。<br>
	 * \attention
	 * 本関数を実行する前に、ライブラリを初期化しておく必要があります。<br>
	 */
	public CriAtomEx3dSource()
	{
		Config config = new Config();
		this.handle = criAtomEx3dSource_Create(ref config, IntPtr.Zero, 0);
	}

	/**
	 * <summary>3D音源オブジェクトの破棄</summary>
	 * \par 説明:
	 * 3D音源オブジェクトを破棄します。<br>
	 * 本関数を実行した時点で、3D音源オブジェクト作成時にDLL内で確保されたリソースが全て解放されます。<br>
	 * 3D音源オブジェクトをセットしたAtomExプレーヤで再生している音声がある場合、
	 * 本関数を実行する前に、それらの音声を停止するか、そのAtomExプレーヤを破棄してください。
	 */
	public void Dispose()
	{
		criAtomEx3dSource_Destroy(this.handle);
		GC.SuppressFinalize(this);
	}

	public IntPtr nativeHandle
	{
		get {return this.handle;}
	}
	
	/**
	 * <summary>3D音源の更新</summary>
	 * \par 説明:
	 * 3D音源に設定されているパラメータを使用して、3D音源を更新します。<br>
	 * 本関数では、3D音源に設定されているすべてのパラメータを更新します。<br>
	 * パラメータをひとつ変更する度に本関数にて更新処理を行うよりも、
	 * 複数のパラメータを変更してから更新処理を行った方が効率的です。<br>
	 * \par 例:
	 * \code
	 * 	：
	 * // 音源の作成
	 * CriAtomEx3dSource source = new CriAtomEx3dSource();
	 * 	：
	 * // 音源の位置を設定
	 * source.SetPosition(0.0f, 0.0f, 1.0f);
	 * 
	 * // 音源の速度を設定
	 * source.SetVelocity(1.0f, 0.0f, 0.0f);
	 * 
	 * // 注意）この時点では音源の位置や速度はまだ変更されていません。
	 * 
	 * // 変更の適用
	 * source.Update();
	 * 	：
	 * \endcode
	 * \attention
	 * 本関数はAtomExプレーヤのパラメータ更新（ ::CriAtomExPlayer::UpdateAll, CriAtomExPlayer::Update ）
	 * とは独立して動作します。<br>
	 * 3D音源のパラメータを変更した際は、本関数にて更新処理を行ってください。
	 */
	public void Update()
	{
		criAtomEx3dSource_Update(this.handle);
	}
	
	/**
	 * <summary>3D音源パラメータの初期化</summary>
	 * \par 説明:
	 * 3D音源に設定されているパラメータをクリアし、初期値に戻します。<br>
	 * \attention
	 * クリアしたパラメータを実際に適用するには、 ::CriAtomEx3dSource::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dSource::Update
	 */
	public void ResetParameters()
	{
		criAtomEx3dSource_ResetParameters(this.handle);
	}
	
	/**
	 * <summary>3D音源の位置の設定</summary>
	 * <param name="x">X座標</param>
	 * <param name="y">Y座標</param>
	 * <param name="z">Z座標</param>
	 * \par 説明:
	 * 3D音源の位置を設定します。<br>
	 * 位置は、距離減衰、および定位計算に使用されます。<br>
	 * 位置は、3次元ベクトルで指定します。<br>
	 * 位置の単位がいくつであるかは、3Dリスナーの距離計数
	 * （ ::CriAtomEx3dListener::SetDistanceFactor 関数で設定 ）で決まります。<br>
	 * デフォルト値は(0.0f, 0.0f, 0.0f)です。<br>
	 * データ側には位置は設定できないため、常に本関数での設定値が使用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dSource::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dSource::Update
	 */
	public void SetPosition(float x, float y, float z)
	{
		CriAtomExVector position;
		position.x = x;
		position.y = y;
		position.z = z;
		criAtomEx3dSource_SetPosition(this.handle, ref position);
	}
	
	/**
	 * <summary>3D音源の速度の設定</summary>
	 * <param name="x">X軸方向の速度</param>
	 * <param name="y">Y軸方向の速度</param>
	 * <param name="z">Z軸方向の速度</param>
	 * \par 説明:
	 * 3D音源の速度を設定します。<br>
	 * 速度は、ドップラー効果の計算に使用されます。<br>
	 * 速度は、3次元ベクトルで指定します。<br>
	 * 速度の単位は、1秒あたりの移動距離です。<br>
	 * 距離の単位がいくつであるかは、3Dリスナーの距離計数
	 * （ ::CriAtomEx3dListener::SetDistanceFactor 関数で設定）で決まります。
	 * デフォルト値は(0.0f, 0.0f, 0.0f)です。<br>
	 * データ側には速度は設定できないため、常に本関数での設定値が使用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dSource::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dSource::Update
	 */
	public void SetVelocity(float x, float y, float z)
	{
		CriAtomExVector velocity;
		velocity.x = x;
		velocity.y = y;
		velocity.z = z;
		criAtomEx3dSource_SetVelocity(this.handle, ref velocity);
	}
	
	/**
	 * <summary>3D音源のサウンドコーンの向きの設定</summary>
	 * <param name="x">X方向の値</param>
	 * <param name="y">Y方向の値</param>
	 * <param name="z">Z方向の値</param>
	 * \par 説明:
	 * 3D音源のサウンドコーンの向きを設定します。<br>
	 * サウンドコーンは、音源から音が発生する方向を表し、音の指向性の表現に使用されます。<br>
	 * サウンドコーンの向きは、3次元ベクトルで指定します。<br>
	 * 設定された向きベクトルは、ライブラリ内部で正規化して使用されます。<br>
	 * デフォルト値は(0.0f, 0.0f, -1.0f)です。<br>
	 * データ側にはサウンドコーンの向きは設定できないため、常に本関数での設定値が使用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dSource::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dSource::SetConeParameter, CriAtomEx3dSource::Update
	 */
	public void SetConeOrientation(float x, float y, float z)
	{
		CriAtomExVector coneOrientation;
		coneOrientation.x = x;
		coneOrientation.y = y;
		coneOrientation.z = z;
		criAtomEx3dSource_SetConeOrientation(this.handle, ref coneOrientation);
	}
	
	/**
	 * <summary>3D音源のサウンドコーンパラメータの設定</summary>
	 * <param name="insideAngle">サウンドコーンのインサイドアングル</param>
	 * <param name="outsideAngle">サウンドコーンのアウトサイドアングル</param>
	 * <param name="outsideVolume">サウンドコーンのアウトサイドボリューム</param>
	 * \par 説明:
	 * 3D音源のサウンドコーンパラメータを設定します。<br>
	 * サウンドコーンは、音源から音が発生する方向を表し、音の指向性の表現に使用されます。<br>
	 * サウンドコーンは、内側コーン、外側コーンで構成されます。インサイドアングルは内側コーンの角度、
	 * アウトサイドアングルは外側コーンの角度、アウトサイドボリュームは外側コーンの角度以上の方向での音量をそれぞれ表します。<br>
	 * 内側コーンの角度より小さい角度の方向では、コーンによる減衰を受けません。
	 * 内側コーンと外側コーンの間の方向では、徐々にアウトサイドボリュームまで減衰します。<br>
	 * インサイドアングルおよびアウトサイドアングルは、0.0f～360.0fを度で指定します。<br>
	 * アウトサイドボリュームは、0.0f～1.0fを振幅に対する倍率で指定します（単位はデシベルではありません）。<br>
	 * ライブラリ初期化時のデフォルト値は以下のとおりであり、コーンによる減衰は行われません。<br>
	 * 	- インサイドアングル：360.0f
	 * 	- アウトサイドアングル：360.0f
	 * 	- アウトサイドボリューム：0.0f
	 * 	.
	 * データ側にサウンドコーンパラメータが設定されている場合に本関数を呼び出すと、以下のように適用されます。<br>
	 * 	- インサイドアングル：加算
	 * 	- アウトサイドアングル：加算
	 * 	- アウトサイドボリューム：乗算
	 * 	.
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dSource::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dSource::Update
	 */
	public void SetConeParameter(float insideAngle, float outsideAngle, float outsideVolume)
	{
		criAtomEx3dSource_SetConeParameter(this.handle, insideAngle, outsideAngle, outsideVolume);
	}

	/**
	 * <summary>3D音源の最小距離／最大距離の設定</summary>
	 * <param name="minDistance">最小距離</param>
	 * <param name="maxDistance">最大距離</param>
	 * \par 説明:
	 * 3D音源の最小距離／最大距離を設定します。<br>
	 * 最小距離は、これ以上音量が大きくならない距離を表します。<br>
	 * 最大距離は、最小音量になる距離を表します。<br>
	 * 距離の単位がいくつであるかは、3Dリスナーの距離計数
	 * （ ::CriAtomEx3dListener::SetDistanceFactor 関数で設定）で決まります。<br>
	 * ライブラリ初期化時のデフォルト値は以下のとおりです。<br>
	 * 	- 最小距離：0.0f
	 * 	- 最大距離：0.0f
	 * 	.
	 * データ側に最小距離／最大距離が設定されている場合に本関数を呼び出すと、データ側の値を上書き（無視）して適用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dSource::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dSource::Update
	 */
	public void SetMinMaxDistance(float minDistance, float maxDistance)
	{
		criAtomEx3dSource_SetMinMaxDistance(this.handle, minDistance, maxDistance);
	}
	
	/**
	 * <summary>3D音源のドップラー係数の設定</summary>
	 * <param name="dopplerFactor">ドップラー係数</param>
	 * \par 説明:
	 * 3D音源のドップラー係数を設定します。<br>
	 * ドップラー係数は、音速を340m/sとして計算されたドップラー効果に対して、誇張表現するための倍率を指定します。<br>
	 * 例えば、2.0fを指定すると、音速を340m/sとして計算したピッチを2倍して適用します。<br>
	 * 0.0fを指定すると、ドップラー効果は無効になります。<br>
	 * ライブラリ初期化時のデフォルト値は0.0fです。<br>
	 * データ側にドップラー係数が設定されている場合に本関数を呼び出すと、データ側の値を上書き（無視）して適用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dSource::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dSource::Update
	 */
	public void SetDopplerFactor(float dopplerFactor)
	{
		criAtomEx3dSource_SetDopplerFactor(this.handle, dopplerFactor);
	}
	
	/**
	 * <summary>3D音源のボリュームの設定</summary>
	 * <param name="volume">ボリューム</param>
	 * \par 説明:
	 * 3D音源のボリュームを設定します。<br>
	 * 3D音源のボリュームは、定位に関わる音量（L,R,SL,SR）にのみ影響し、LFEやセンターへの出力レベルには影響しません。<br>
	 * ボリューム値には、0.0f～1.0fの範囲で実数値を指定します。<br>
	 * ボリューム値は音声データの振幅に対する倍率です（単位はデシベルではありません）。<br>
	 * 例えば、1.0fを指定した場合、原音はそのままのボリュームで出力されます。<br>
	 * 0.5fを指定した場合、原音波形の振幅を半分にしたデータと同じ音量（-6dB）で
	 * 音声が出力されます。<br>
	 * 0.0fを指定した場合、音声はミュートされます（無音になります）。<br>
	 * ライブラリ初期化時のデフォルト値は1.0fです。<br>
	 * データ側に3D音源のボリュームが設定されている場合に本関数を呼び出すと、データ側の値と乗算して適用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dSource::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dSource::Update
	 */
	public void SetVolume(float volume)
	{
		criAtomEx3dSource_SetVolume(this.handle, volume);
	}
	
	/**
	 * <summary>角度AISACコントロール値の最大変化量の設定</summary>
	 * <param name="maxDelta">角度AISACコントロール値の最大変化量</param>
	 * \par 説明:
	 * 角度AISACによりAISACコントロール値が変更される際の、最大変化量を設定します。<br>
	 * 最大変化量を低めに変更すると、音源とリスナー間の相対角度が急激に変わった場合でも、
	 * 角度AISACによるAISACコントロール値の変化をスムーズにすることができます。<br>
	 * 例えば、(0.5f / 30.0f)を設定すると、角度が0度→180度に変化した場合に、30フレームかけて変化するような変化量となります。<br>
	 * デフォルト値は1.0f（制限なし）です。<br>
	 * データ側では本パラメータは設定できないため、常に本関数での設定値が使用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dSource::Update 関数を呼び出す必要があります。<br>
	 * 本関数で設定している最大変化量は、定位角度を元に計算されている、角度AISACコントロール値の変化にのみ適用されます。
	 * 定位角度自体には影響はありません。
	 * \sa CriAtomEx3dSource::Update
	 */
	public void SetMaxAngleAisacDelta(float maxDelta)
	{
		criAtomEx3dSource_SetMaxAngleAisacDelta(this.handle, maxDelta);
	}

	#region Internal Members
	
	~CriAtomEx3dSource()
	{
		this.Dispose();
	}

	private IntPtr handle = IntPtr.Zero;
	
	#endregion

	#region DLL Import
	
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	private struct CriAtomExVector
	{
		public float x, y, z;
	}
	
	[DllImport(CriWare.pluginName)]
	private static extern IntPtr criAtomEx3dSource_Create(ref Config config, IntPtr work, int work_size);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_Destroy(IntPtr ex_3d_source);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_Update(IntPtr ex_3d_source);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_ResetParameters(IntPtr ex_3d_source);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_SetPosition(IntPtr ex_3d_source, ref CriAtomExVector position);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_SetVelocity(IntPtr ex_3d_source, ref CriAtomExVector velocity);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_SetConeOrientation(IntPtr ex_3d_source, ref CriAtomExVector cone_orient);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_SetConeParameter(IntPtr ex_3d_source, float inside_angle, float outside_angle, float outside_volume);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_SetMinMaxDistance(IntPtr ex_3d_source, float min_distance, float max_distance);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_SetDopplerFactor(IntPtr ex_3d_source, float doppler_factor);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_SetVolume(IntPtr ex_3d_source, float volume);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dSource_SetMaxAngleAisacDelta(IntPtr ex_3d_source, float max_delta);

	#endregion
}

/**
 * @}
 */

/* --- end of file --- */
