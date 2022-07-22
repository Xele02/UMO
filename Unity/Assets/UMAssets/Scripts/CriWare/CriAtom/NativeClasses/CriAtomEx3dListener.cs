/****************************************************************************
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

#if !UNITY_WEBGL
	#define CRIWARE_TRANSCEIVER_N_ELEVATIONANGLEAISAC_SUPPORT
#endif

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
 * <summary>3Dリスナー</summary>
 * <remarks>
 * <para header='説明'>3Dリスナーを扱うためのオブジェクトです。<br/>
 * 3Dポジショニング機能に使用します。<br/>
 * <br/>
 * 3Dリスナーのパラメータ、位置情報の設定等は、3Dリスナーオブジェクトを介して実行されます。</para>
 * </remarks>
 */
public class CriAtomEx3dListener : CriDisposable
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct Config {
		public int reserved;
	}

	/**
	 * <summary>3Dリスナーの作成</summary>
	 * <remarks>
	 * <para header='説明'>3Dリスナーオブジェクトを作成します。<br/></para>
	 * <para header='注意'>本関数を実行する前に、ライブラリを初期化しておく必要があります。<br/></para>
	 * </remarks>
	 */
	public CriAtomEx3dListener()
	{
		Config config = new Config();
		this.handle = criAtomEx3dListener_Create(ref config, IntPtr.Zero, 0);
		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
	}

	/**
	 * <summary>3Dリスナーオブジェクトの破棄</summary>
	 * <remarks>
	 * <para header='説明'>3Dリスナーオブジェクトを破棄します。<br/>
	 * 本関数を実行した時点で、3Dリスナー作成時にDLL内で確保されたリソースが全て解放されます。<br/>
	 * 3DリスナーオブジェクトをセットしたAtomExプレーヤで再生している音声がある場合、
	 * 本関数を実行する前に、それらの音声を停止するか、そのAtomExプレーヤを破棄してください。</para>
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
			criAtomEx3dListener_Destroy(this.handle);
			this.handle = IntPtr.Zero;
		}

		if (disposing) {
			GC.SuppressFinalize(this);
		}
	}

	public IntPtr nativeHandle
	{
		get {return this.handle;}
	}

	/**
	 * <summary>3Dリスナーの更新</summary>
	 * <remarks>
	 * <para header='説明'>3Dリスナーに設定されているパラメータを使用して、3Dリスナーを更新します。<br/>
	 * 本関数では、3Dリスナーに設定されているすべてのパラメータを更新します。
	 * パラメータをひとつ変更する度に本関数にて更新処理を行うよりも、
	 * 複数のパラメータを変更してから更新処理を行った方が効率的です。</para>
	 * <para header='注意'>本関数はAtomExプレーヤのパラメータ更新（ ::CriAtomExPlayer::UpdateAll, ::CriAtomExPlayer::Update ）
	 * とは独立して動作します。<br/>
	 * 3Dリスナーのパラメータを変更した際は、本関数にて更新処理を行ってください。</para>
	 * </remarks>
	 * <example><code>
	 *  ：
	 * // リスナーの作成
	 * CriAtomExListener listener = new CriAtomEx3dListener();
	 *  ：
	 * // リスナー位置の設定
	 * listener.SetPosition(0.0f, 0.0f, 1.0f);
	 *
	 * // リスナー速度の設定
	 * listener.SetVelocity(1.0f, 0.0f, 0.0f);
	 *
	 * // 注意）この時点ではリスナーの位置や速度はまだ変更されていません。
	 *
	 * // 変更の適用
	 * listener.Update();
	 *  ：
	 * </code></example>
	 */
	public void Update()
	{
		if (this.handle != IntPtr.Zero)
			criAtomEx3dListener_Update(this.handle);
	}

	/**
	 * <summary>3D音源パラメータの初期化</summary>
	 * <remarks>
	 * <para header='説明'>3Dリスナーに設定されているパラメータをクリアし、初期値に戻します。<br/></para>
	 * <para header='注意'>クリアしたパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 */
	public void ResetParameters()
	{
		if (this.handle != IntPtr.Zero)
			criAtomEx3dListener_ResetParameters(this.handle);
	}

	/**
	 * <summary>3Dリスナーの位置の設定</summary>
	 * <param name='x'>X座標</param>
	 * <param name='y'>Y座標</param>
	 * <param name='z'>Z座標</param>
	 * <remarks>
	 * <para header='説明'>3Dリスナーの位置を設定します。<br/>
	 * 位置は、距離減衰、および定位計算に使用されます。<br/>
	 * 位置は、3次元ベクトルで指定します。<br/>
	 * 位置の単位がいくつであるかは、3Dリスナーの距離計数
	 * （ ::CriAtomEx3dListener::SetDistanceFactor 関数で設定）で決まります。<br/>
	 * デフォルト値は(0.0f, 0.0f, 0.0f)です。<br/>
	 * データ側には位置は設定できないため、常に本関数での設定値が使用されます。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dListener::Update'/>
	 */
	public void SetPosition(float x, float y, float z)
	{
		if (this.handle == IntPtr.Zero)
			return;

		CriAtomEx.NativeVector position;
		position.x = x;
		position.y = y;
		position.z = z;
		criAtomEx3dListener_SetPosition(this.handle, ref position);
	}

	/**
	 * <summary>3Dリスナーの速度の設定</summary>
	 * <param name='x'>X軸方向の速度</param>
	 * <param name='y'>Y軸方向の速度</param>
	 * <param name='z'>Z軸方向の速度</param>
	 * <remarks>
	 * <para header='説明'>3Dリスナーの速度を設定します。<br/>
	 * 速度は、ドップラー効果の計算に使用されます。<br/>
	 * 速度は、3次元ベクトルで指定します。<br/>
	 * 速度の単位は、1秒あたりの移動距離です。<br/>
	 * 距離の単位がいくつであるかは、3Dリスナーの距離計数
	 * （ ::CriAtomEx3dListener::SetDistanceFactor 関数で設定）で決まります。<br/>
	 * デフォルト値は(0.0f, 0.0f, 0.0f)です。<br/>
	 * データ側には速度は設定できないため、常に本関数での設定値が使用されます。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dListener::Update'/>
	 */
	public void SetVelocity(float x, float y, float z)
	{
		if (this.handle == IntPtr.Zero)
			return;

		CriAtomEx.NativeVector velocity;
		velocity.x = x;
		velocity.y = y;
		velocity.z = z;
		criAtomEx3dListener_SetVelocity(this.handle, ref velocity);
	}

	/**
	 * <summary>3Dリスナーの向きの設定</summary>
	 * <param name='fx'>前方ベクトルのX方向の値</param>
	 * <param name='fy'>前方ベクトルのY方向の値</param>
	 * <param name='fz'>前方ベクトルのZ方向の値</param>
	 * <param name='ux'>上方ベクトルのX方向の値</param>
	 * <param name='uy'>上方ベクトルのY方向の値</param>
	 * <param name='uz'>上方ベクトルのZ方向の値</param>
	 * <remarks>
	 * <para header='説明'>3Dリスナーの向きを前方ベクトルと上方ベクトルで設定します。<br/>
	 * 向きは、3次元ベクトルで指定します。<br/>
	 * 設定された向きベクトルは、ライブラリ内部で正規化して使用されます。<br/>
	 * デフォルト値以下のとおりです。<br/>
	 *  - 前方ベクトル：(0.0f, 0.0f, 1.0f)
	 *  - 上方ベクトル：(0.0f, 1.0f, 0.0f)
	 *  .
	 * データ側にはリスナーの向きは設定できないため、常に本関数での設定値が使用されます。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dListener::Update'/>
	 */
	public void SetOrientation(float fx, float fy, float fz, float ux, float uy, float uz)
	{
		if (this.handle == IntPtr.Zero)
			return;

		CriAtomEx.NativeVector front, top;
		front.x = fx;
		front.y = fy;
		front.z = fz;
		top.x = ux;
		top.y = uy;
		top.z = uz;
		criAtomEx3dListener_SetOrientation(this.handle, ref front, ref top);
	}

	/**
	 * \deprecated
	 * 削除予定の非推奨APIです。
	 * CriWareErrorHandler.OnCallback event の使用を検討してください。
	 * <summary>3Dリスナーの距離係数の設定</summary>
	 * <param name='distanceFactor'>距離係数</param>
	 * <remarks>
	 * <para header='説明'>3Dリスナーの距離係数を設定します。<br/>
	 * この係数はドップラー効果の計算に使用されます。<br/>
	 * 例えば、distance_factorに0.1fを指定すると、速度の1.0fを10メートルとして扱います。<br/>
	 * distanceFactorに指定できる値は0または0.0fより大きな値です。
	 * デフォルト値は1.0fです。<br/>
	 * データ側にはリスナーの距離係数は設定できないため、常に本関数での設定値が使用されます。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dListener::Update'/>
	 */
	[Obsolete("Use SetDopplerMultiplier instead")]
	public void SetDistanceFactor(float distanceFactor)
	{
		if (this.handle == IntPtr.Zero)
			return;

		if (distanceFactor < 0f) {
			UnityEngine.Debug.LogError("[CRIWARE] Invalid value for distanceFactor. Value >= 0f required.");
		} else if (distanceFactor == 0f) {
			criAtomEx3dListener_SetDopplerMultiplier(this.handle, 0f);
		} else {
			criAtomEx3dListener_SetDopplerMultiplier(this.handle, 1.0f / distanceFactor);
		}
	}

	/**
	 * <summary>3Dリスナーのドップラー倍率の設定</summary>
	 * <param name='dopplerMultiplier'>ドップラー倍率</param>
	 * <remarks>
	 * <para header='説明'>3Dリスナーのドップラー倍率を設定します。この倍率はドップラー効果の計算に使用されます。<br/>
	 * 例えば、dopplerMultiplierに10.0fを指定すると、ドップラー効果が通常の10倍になります。<br/>
	 * dopplerMultiplierに指定できる値は0または0.0fより大きな値です。
	 * デフォルト値は1.0fです。<br/>
	 * データ側にはリスナーのドップラー倍率は設定できないため、常に本関数での設定値が使用されます。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dListener::Update'/>
	 */
	public void SetDopplerMultiplier(float dopplerMultiplier)
	{
		if (this.handle == IntPtr.Zero)
			return;

		if (dopplerMultiplier < 0f) {
			UnityEngine.Debug.LogError("[CRIWARE] Invalid value for dopplerMultiplier. Value >= 0f required.");
			return;
		}

		criAtomEx3dListener_SetDopplerMultiplier(this.handle, dopplerMultiplier);
	}

	/**
	 * <summary>3Dリスナーの注目点の設定</summary>
	 * <remarks>
	 * <para header='説明'>3Dリスナーの注目点を設定します。<br/>
	 * 注目点は、3Dポジショニングを行うにあたって、
	 * 注目点を設定すると、リスナーの位置と注目点の間が直線で結ばれ、
	 * その直線上でマイクを移動させることができるようになります。<br/>
	 * 例えば、リスナーはカメラと常に同期させておき、主要キャラクタの位置に注目点を設定することで、
	 * 状況に応じて、客観的か主観的かを柔軟に表現／調整するような使い方ができます。<br/>
	 * なお、リスナーの位置と注目点の間で移動できるマイクは、現実世界のマイクと異なり、
	 * 距離センサ（距離減衰計算用）と方向センサ（定位計算用）を分離しています。<br/>
	 * これらを独立して操作することで、例えば「主役キャラに注目するので、距離減衰はキャラ位置基準で行いたい」
	 * 「定位は画面の見た目に合わせたいため、定位計算はカメラ位置基準で行いたい」
	 * という表現を行うことができます。<br/>
	 * デフォルト値は(0.0f, 0.0f, 0.0f)です。距離センサや方向センサのフォーカスレベルを設定しない状況では、
	 * 注目点を設定する必要はありません。
	 * その場合、従来どおり、全ての3Dポジショニング計算をリスナー位置基準で行います。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dListener::Update'/>
	 * <seealso cref='CriAtomEx3dListener::SetDistanceFocusLevel'/>
	 * <seealso cref='CriAtomEx3dListener::SetDirectionFocusLevel'/>
	 */
	public void SetFocusPoint(float x, float y, float z)
	{
		if (this.handle == IntPtr.Zero)
			return;

		CriAtomEx.NativeVector focus;
		focus.x = x;
		focus.y = y;
		focus.z = z;
		criAtomEx3dListener_SetFocusPoint(this.handle, ref focus);
	}

	/**
	 * <summary>距離センサのフォーカスレベルの設定</summary>
	 * <param name='distanceFocusLevel'>距離センサのフォーカスレベル</param>
	 * <remarks>
	 * <para header='説明'>距離センサのフォーカスレベルを設定します。<br/>
	 * 距離センサは、3Dポジショニング計算のうち、距離減衰計算の基準となる位置を表します。
	 * 定位を無視して距離減衰のかかり具合のみを感知するマイク、といった扱いです。<br/>
	 * フォーカスレベルは、注目点に対してどれだけセンサ（マイク）を近づけるかを表します。
	 * センサ（マイク）は、リスナー位置と注目点の間を結んだ直線上で動かすことができ、
	 * 0.0fがリスナー位置、1.0fが注目点と同じ位置になります。<br/>
	 * 例えば、距離センサのフォーカスレベルを1.0f、方向センサのフォーカスレベルを0.0fとすることで、
	 * 注目点を基準に距離減衰を適用し、リスナー位置を基準に定位を決定します。<br/>
	 * デフォルト値は0.0fです。距離センサや方向センサのフォーカスレベルを設定しない状況では、
	 * 従来どおり、全ての3Dポジショニング計算をリスナー位置基準で行います。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dListener::Update'/>
	 * <seealso cref='CriAtomEx3dListener::SetFocusPoint'/>
	 * <seealso cref='CriAtomEx3dListener::SetDirectionFocusLevel'/>
	 */
	public void SetDistanceFocusLevel(float distanceFocusLevel)
	{
		if (this.handle != IntPtr.Zero)
			criAtomEx3dListener_SetDistanceFocusLevel(this.handle, distanceFocusLevel);
	}

	/**
	 * <summary>方向センサのフォーカスレベルの設定</summary>
	 * <param name='directionFocusLevel'>方向センサのフォーカスレベル</param>
	 * <remarks>
	 * <para header='説明'>方向センサのフォーカスレベルを設定します。<br/>
	 * 方向センサは、3Dポジショニング計算のうち、定位計算の基準となる位置を表します。
	 * 距離減衰を無視して定位のみを感知するマイク、といった扱いです。<br/>
	 * 方向センサの向きについては、リスナーの向き（SetOrientation 関数で設定）をそのまま使用します。<br/>
	 * フォーカスレベルは、注目点に対してどれだけセンサ（マイク）を近づけるかを表します。
	 * センサ（マイク）は、リスナー位置と注目点の間を結んだ直線上で動かすことができ、
	 * 0.0fがリスナー位置、1.0fが注目点と同じ位置になります。<br/>
	 * 例えば、距離センサのフォーカスレベルを1.0f、方向センサのフォーカスレベルを0.0fとすることで、
	 * 注目点を基準に距離減衰を適用し、リスナー位置を基準に定位を決定します。<br/>
	 * デフォルト値は0.0fです。距離センサや方向センサのフォーカスレベルを設定しない状況では、
	 * 従来どおり、全ての3Dポジショニング計算をリスナー位置基準で行います。<br/></para>
	 * <para header='注意'>設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dListener::Update'/>
	 * <seealso cref='CriAtomEx3dListener::SetFocusPoint'/>
	 * <seealso cref='CriAtomEx3dListener::SetDistanceFocusLevel'/>
	 */
	public void SetDirectionFocusLevel(float directionFocusLevel)
	{
		if (this.handle != IntPtr.Zero)
			criAtomEx3dListener_SetDirectionFocusLevel(this.handle, directionFocusLevel);
	}

	/**
	 * <summary>3Dリージョンの設定</summary>
	 * <remarks>
	 * <para header='説明'>3Dリスナーに対して3Dリージョンを設定します。</para>
	 * <para header='注意'>同一のExPlayerに設定されている3D音源と3Dリスナーに設定されているリージョンが異なり、<br/>
	 * かつ3D音源と同じリージョンが設定されている3Dトランシーバーがない場合、音声はミュートされます。<br/>
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。</para>
	 * </remarks>
	 * <seealso cref='CriAtomEx3dRegion::Create'/>
	 * <seealso cref='CriAtomEx3dListener::Update'/>
	 */
	public void Set3dRegion(CriAtomEx3dRegion region3d)
	{
		if (this.handle == IntPtr.Zero)
			return;

		IntPtr region3dHandle = (region3d == null) ? IntPtr.Zero : region3d.nativeHandle;
		criAtomEx3dListener_Set3dRegionHn(this.handle, region3dHandle);
	}

	#region Internal Members

	~CriAtomEx3dListener()
	{
		this.Dispose(false);
	}

	private IntPtr handle = IntPtr.Zero;

	#endregion

	#region DLL Import

#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomEx3dListener_Create(ref Config config, IntPtr work, int work_size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_Destroy(IntPtr ex_3d_listener);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_Update(IntPtr ex_3d_listener);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_ResetParameters(IntPtr ex_3d_listener);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_SetPosition(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector position);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_SetVelocity(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector velocity);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_SetOrientation(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector front, ref CriAtomEx.NativeVector top);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_SetDistanceFactor(IntPtr ex_3d_listener, float distance_factor);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_SetDopplerMultiplier(IntPtr ex_3d_listener, float doppler_multiplier);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_SetFocusPoint(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector focus_point);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_SetDistanceFocusLevel(IntPtr ex_3d_listener, float distance_focus_level);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_SetDirectionFocusLevel(IntPtr ex_3d_listener, float direction_focus_level);
#else
	private static IntPtr criAtomEx3dListener_Create(ref Config config, IntPtr work, int work_size) { return IntPtr.Zero; }
	private static void criAtomEx3dListener_Destroy(IntPtr ex_3d_listener) { }
	private static void criAtomEx3dListener_Update(IntPtr ex_3d_listener) { }
	private static void criAtomEx3dListener_ResetParameters(IntPtr ex_3d_listener) { }
	private static void criAtomEx3dListener_SetPosition(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector position) { }
	private static void criAtomEx3dListener_SetVelocity(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector velocity) { }
	private static void criAtomEx3dListener_SetOrientation(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector front, ref CriAtomEx.NativeVector top) { }
	private static void criAtomEx3dListener_SetDistanceFactor(IntPtr ex_3d_listener, float distance_factor) { }
	private static void criAtomEx3dListener_SetDopplerMultiplier(IntPtr ex_3d_listener, float doppler_multiplier) { }
	private static void criAtomEx3dListener_SetFocusPoint(IntPtr ex_3d_listener, ref CriAtomEx.NativeVector focus_point) { }
	private static void criAtomEx3dListener_SetDistanceFocusLevel(IntPtr ex_3d_listener, float distance_focus_level) { }
	private static void criAtomEx3dListener_SetDirectionFocusLevel(IntPtr ex_3d_listener, float direction_focus_level) { }
#endif

#if !CRIWARE_ENABLE_HEADLESS_MODE && CRIWARE_TRANSCEIVER_N_ELEVATIONANGLEAISAC_SUPPORT
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomEx3dListener_Set3dRegionHn(IntPtr ex_3d_listener, IntPtr ex_3d_region);
#else
	private static void criAtomEx3dListener_Set3dRegionHn(IntPtr ex_3d_listener, IntPtr ex_3d_region) { }
#endif

	#endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
