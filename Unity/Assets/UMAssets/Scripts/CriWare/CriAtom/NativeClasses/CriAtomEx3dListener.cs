/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom Native Wrapper
 * File     : CriAtomEx3dListener.cs
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
 * <summary>3Dリスナー</summary>
 * \par 説明:
 * 3Dリスナーを扱うためのオブジェクトです。<br>
 * 3Dポジショニング機能に使用します。<br>
 * <br>
 * 3Dリスナーのパラメータ、位置情報の設定等は、3Dリスナーオブジェクトを介して実行されます。
*/
public class CriAtomEx3dListener : IDisposable
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct Config {
		public int reserved;
	}

	/**
	 * <summary>3Dリスナーの作成</summary>
	 * \par 説明:
	 * 3Dリスナーオブジェクトを作成します。<br>
	 * \attention
	 * 本関数を実行する前に、ライブラリを初期化しておく必要があります。<br>
	 */
	public CriAtomEx3dListener()
	{
		Config config = new Config();
		this.handle = criAtomEx3dListener_Create(ref config, IntPtr.Zero, 0);
	}

	/**
	 * <summary>3Dリスナーオブジェクトの破棄</summary>
	 * \par 説明:
	 * 3Dリスナーオブジェクトを破棄します。<br>
	 * 本関数を実行した時点で、3Dリスナー作成時にDLL内で確保されたリソースが全て解放されます。<br>
	 * 3DリスナーオブジェクトをセットしたAtomExプレーヤで再生している音声がある場合、
	 * 本関数を実行する前に、それらの音声を停止するか、そのAtomExプレーヤを破棄してください。
	 */
	public void Dispose()
	{
		criAtomEx3dListener_Destroy(this.handle);
		GC.SuppressFinalize(this);
	}

	public IntPtr nativeHandle
	{
		get {return this.handle;}
	}
	
	/**
	 * <summary>3Dリスナーの更新</summary>
	 * \par 説明:
	 * 3Dリスナーに設定されているパラメータを使用して、3Dリスナーを更新します。<br>
	 * 本関数では、3Dリスナーに設定されているすべてのパラメータを更新します。
	 * パラメータをひとつ変更する度に本関数にて更新処理を行うよりも、
	 * 複数のパラメータを変更してから更新処理を行った方が効率的です。
	 * \par 例:
	 * \code
	 * 	：
	 * // リスナーの作成
	 * CriAtomExListener listener = new CriAtomEx3dListener();
	 * 	：
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
	 * 	：
	 * \endcode
	 * \attention
	 * 本関数はAtomExプレーヤのパラメータ更新（ ::CriAtomExPlayer::UpdateAll, ::CriAtomExPlayer::Update ）
	 * とは独立して動作します。<br>
	 * 3Dリスナーのパラメータを変更した際は、本関数にて更新処理を行ってください。
	 */
	public void Update()
	{
		criAtomEx3dListener_Update(this.handle);
	}

	/**
	 * <summary>3D音源パラメータの初期化</summary>
	 * \par 説明:
	 * 3Dリスナーに設定されているパラメータをクリアし、初期値に戻します。<br>
	 * \attention
	 * クリアしたパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。
	 */
	public void ResetParameters()
	{
		criAtomEx3dListener_ResetParameters(this.handle);
	}

	/**
	 * <summary>3Dリスナーの位置の設定</summary>
	 * <param name="x">X座標</param>
	 * <param name="y">Y座標</param>
	 * <param name="z">Z座標</param>
	 * \par 説明:
	 * 3Dリスナーの位置を設定します。<br>
	 * 位置は、距離減衰、および定位計算に使用されます。<br>
	 * 位置は、3次元ベクトルで指定します。<br>
	 * 位置の単位がいくつであるかは、3Dリスナーの距離計数
	 * （ ::CriAtomEx3dListener::SetDistanceFactor 関数で設定）で決まります。<br>
	 * デフォルト値は(0.0f, 0.0f, 0.0f)です。<br>
	 * データ側には位置は設定できないため、常に本関数での設定値が使用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dListener::Update
	 */
	public void SetPosition(float x, float y, float z)
	{
		CriAtomExVector position;
		position.x = x;
		position.y = y;
		position.z = z;
		criAtomEx3dListener_SetPosition(this.handle, ref position);
	}
	
	/**
	 * <summary>3Dリスナーの速度の設定</summary>
	 * <param name="x">X軸方向の速度</param>
	 * <param name="y">Y軸方向の速度</param>
	 * <param name="z">Z軸方向の速度</param>
	 * \par 説明:
	 * 3Dリスナーの速度を設定します。<br>
	 * 速度は、ドップラー効果の計算に使用されます。<br>
	 * 速度は、3次元ベクトルで指定します。<br>
	 * 速度の単位は、1秒あたりの移動距離です。<br>
	 * 距離の単位がいくつであるかは、3Dリスナーの距離計数
	 * （ ::CriAtomEx3dListener::SetDistanceFactor 関数で設定）で決まります。<br>
	 * デフォルト値は(0.0f, 0.0f, 0.0f)です。<br>
	 * データ側には速度は設定できないため、常に本関数での設定値が使用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dListener::Update
	 */
	public void SetVelocity(float x, float y, float z)
	{
		CriAtomExVector velocity;
		velocity.x = x;
		velocity.y = y;
		velocity.z = z;
		criAtomEx3dListener_SetVelocity(this.handle, ref velocity);
	}
	
	/**
	 * <summary>3Dリスナーの向きの設定</summary>
	 * <param name="fx">前方ベクトルのX方向の値</param>
	 * <param name="fy">前方ベクトルのY方向の値</param>
	 * <param name="fz">前方ベクトルのZ方向の値</param>
	 * <param name="ux">上方ベクトルのX方向の値</param>
	 * <param name="uy">上方ベクトルのY方向の値</param>
	 * <param name="uz">上方ベクトルのZ方向の値</param>
	 * \par 説明:
	 * 3Dリスナーの向きを前方ベクトルと上方ベクトルで設定します。<br>
	 * 向きは、3次元ベクトルで指定します。<br>
	 * 設定された向きベクトルは、ライブラリ内部で正規化して使用されます。<br>
	 * デフォルト値以下のとおりです。<br>
	 * 	- 前方ベクトル：(0.0f, 0.0f, 1.0f)
	 * 	- 上方ベクトル：(0.0f, 1.0f, 0.0f)
	 * 	.
	 * データ側にはリスナーの向きは設定できないため、常に本関数での設定値が使用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dListener::Update
	 */
	public void SetOrientation(float fx, float fy, float fz, float ux, float uy, float uz)
	{
		CriAtomExVector front, top;
		front.x = fx;
		front.y = fy;
		front.z = fz;
		top.x = ux;
		top.y = uy;
		top.z = uz;
		criAtomEx3dListener_SetOrientation(this.handle, ref front, ref top);
	}
	
	/**
	 * <summary>3Dリスナーの距離係数の設定</summary>
	 * <param name="distanceFactor">距離係数</param>
	 * \par 説明:
	 * 3Dリスナーの距離係数を設定します。<br>
	 * 距離係数はベクトルの単位となるメートル数です。ドップラー効果の計算に使用されます。<br>
	 * 例えば、distanceFactorに10.0fを指定すると、位置や速度等の1.0fを10メートルとして扱います。<br>
	 * デフォルト値は1.0fです。<br>
	 * データ側にはリスナーの距離係数は設定できないため、常に本関数での設定値が使用されます。<br>
	 * \attention
	 * 設定したパラメータを実際に適用するには、 ::CriAtomEx3dListener::Update 関数を呼び出す必要があります。
	 * \sa CriAtomEx3dListener::Update
	 */
	public void SetDistanceFactor(float distanceFactor)
	{
		criAtomEx3dListener_SetDistanceFactor(this.handle, distanceFactor);
	}

	public void SetFocusPoint(float x, float y, float z)
	{
		CriAtomExVector focus;
		focus.x = x;
		focus.y = y;
		focus.z = z;
		criAtomEx3dListener_SetFocusPoint(this.handle, ref focus);
	}

	public void SetDistanceFocusLevel(float distanceFocusLevel)
	{
		criAtomEx3dListener_SetDistanceFocusLevel(this.handle, distanceFocusLevel);
	}

	public void SetDirectionFocusLevel(float directionFocusLevel)
	{
		criAtomEx3dListener_SetDirectionFocusLevel(this.handle, directionFocusLevel);
	}

	#region Internal Members
	
	~CriAtomEx3dListener()
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
	private static extern IntPtr criAtomEx3dListener_Create(ref Config config, IntPtr work, int work_size);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dListener_Destroy(IntPtr ex_3d_listener);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dListener_Update(IntPtr ex_3d_listener);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dListener_ResetParameters(IntPtr ex_3d_listener);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dListener_SetPosition(IntPtr ex_3d_listener, ref CriAtomExVector position);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dListener_SetVelocity(IntPtr ex_3d_listener, ref CriAtomExVector velocity);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dListener_SetOrientation(IntPtr ex_3d_listener, ref CriAtomExVector front, ref CriAtomExVector top);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dListener_SetDistanceFactor(IntPtr ex_3d_listener, float distance_factor);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dListener_SetFocusPoint(IntPtr ex_3d_listener, ref CriAtomExVector focus_point);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dListener_SetDistanceFocusLevel(IntPtr ex_3d_listener, float distance_focus_level);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomEx3dListener_SetDirectionFocusLevel(IntPtr ex_3d_listener, float direction_focus_level);

	#endregion
}

/**
 * @}
 */

/* --- end of file --- */
