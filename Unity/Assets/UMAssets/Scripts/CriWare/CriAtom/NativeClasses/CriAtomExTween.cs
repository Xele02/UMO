/****************************************************************************
 *
 * Copyright (c) 2020 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using System.Runtime.InteropServices;
using System;

/*==========================================================================
 *      CRI Atom Native Wrapper
 *=========================================================================*/

/**
 * \addtogroup CRIATOM_NATIVE_WRAPPER
 * @{
 */

namespace CriWare {

/**
 * <summary>AtomExTweenクラス</summary>
 * <remarks>
 * <para header='説明'>プレイヤーにアタッチすることで、パラメータのアニメーションを行います。</para>
 * </remarks>
 * <seealso cref='CriAtomExPlayer.AttachTween(CriAtomExTween)'/>
 * <seealso cref='CriAtomExPlayer.DetachTween(CriAtomExTween)'/>
 * <seealso cref='CriAtomExPlayer.DetachTweenAll'/>
 */
public class CriAtomExTween : CriDisposable
{
    internal IntPtr nativeHandle { get { return this.handle; } }

    /**
     * <summary>Tweenパラメータ種別</summary>
     */
    public enum ParameterType : System.Int32
    {
        /**
         * <summary>ボリューム、ピッチなど基本的なパラメータの操作</summary>
         * <seealso cref='CriAtomEx.Parameter'/>
         */
        Basic,
        /**
         * <summary>AISACコントロール値の操作</summary>
         */
        Aisac
    }

    [StructLayout(LayoutKind.Sequential)]
    struct Config
    {
        public Target target;
        public ParameterType parameterType;
        [StructLayout(LayoutKind.Explicit)]
        public struct Target
        {
            [FieldOffset(0)]
            public CriAtomEx.Parameter parameterId;
            [FieldOffset(0)]
            public UInt32 aisacIds;
        }
    }

    /**
     * <summary>AtomExTweenの作成</summary>
     * <returns>AtomExTweenオブジェクト</returns>
     * <remarks>
     * <para header='備考'>このコンストラクタによって作成されたAtomExTweenはボリュームの操作を行います。</para>
     * </remarks>
     */
    public CriAtomExTween() : this(CriAtomEx.Parameter.Volume) { }

    /**
     * <summary>AtomExTweenの作成(基本パラメータ操作)</summary>
     * <returns>AtomExTweenオブジェクト</returns>
     * <param name='parameterId'>パラメータのID</param>
     * <seealso cref='CriAtomEx.Parameter'/>
     */
    public CriAtomExTween(CriAtomEx.Parameter parameterId) : this(ParameterType.Basic, (UInt32)parameterId) { }

    /**
     * <summary>AtomExTweenの作成(AISAC操作)</summary>
     * <returns>AtomExTweenオブジェクト</returns>
     * <param name='aisacId'>AISACコントロールID</param>
     */
    public CriAtomExTween(uint aisacId) : this(ParameterType.Aisac, aisacId) { }

    public CriAtomExTween(ParameterType parameterType, UInt32 targetId)
    {
        /*  Initialize Library  */
        if (!CriAtomPlugin.IsLibraryInitialized())
            throw new Exception("CriAtomPlugin is not initialized.");
        /* aplly config */
        Config config = new Config();
        config.parameterType = parameterType;
        config.target.parameterId = (CriAtomEx.Parameter)targetId;
        /* create instance */
        handle = criAtomExTween_Create(ref config, IntPtr.Zero, 0);

        CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
    }

    /**
     * <summary>AtomExTweenの破棄</summary>
     * <remarks>
     * <para header='注意'>AtomExTweenをアタッチしたAtomExPlayerが音声を再生している状態で本関数を実行すると、<br/>
	 * 破棄済みのAtomExTweenへの参照が発生します。 <br/>
	 * 必ずAtomExPlayerからデタッチした後に本関数を実行してください。</para>
     * </remarks>
     */
    public override void Dispose()
    {
        CriDisposableObjectManager.Unregister(this);
        /* destroy instance */
        criAtomExTween_Destroy(handle);
        handle = IntPtr.Zero;

        GC.SuppressFinalize(this);
    }

    /**
     * <summary>AtomExTweenが持っているパラメータの現在値を取得</summary>
     * <returns>パラメータの現在値</returns>
     */
    public float Value
    {
        get
        {
            return criAtomExTween_GetValue(handle);
        }
    }

    /**
     * <summary>現在変化中であるかを取得</summary>
     * <returns>パラメータが変化中であるかどうか</returns>
     */
    public bool IsActive
    {
        get
        {
            return criAtomExTween_IsActive(handle);
        }
    }

    /**
     * <summary>パラメータを現在値から指定値に変化</summary>
     * <remarks>
     * <para header='説明'>指定した時間をかけて、パラメータを呼び出し時の現在値から指定値まで変化させます。<br/>
	 * 変化カーブタイプはリニア(線形)です。</para>
     * </remarks>
     * <param name='durationMs'>変化に要する時間 (ミリ秒)</param>
     * <param name='value'>変化後の最終値</param>
     */
    public void MoveTo(ushort durationMs, float value)
    {
        criAtomExTween_MoveTo(handle, durationMs, value);
    }

    /**
     * <summary>パラメータを指定値から現在値に変化</summary>
     * <remarks>
     * <para header='説明'>指定した時間をかけて、パラメータを指定値から呼び出し時の現在値まで変化させます。<br/>
	 * 変化カーブタイプはリニア(線形)です。</para>
     * </remarks>
     * <param name='durationMs'>変化に要する時間 (ミリ秒)</param>
     * <param name='value'>変化前の開始値</param>
     */
    public void MoveFrom(ushort durationMs, float value)
    {
        criAtomExTween_MoveFrom(handle, durationMs, value);
    }

    /**
     * <summary>AtomExTweenの停止</summary>
     * <remarks>
     * <para header='説明'>AtomExTweenによるパラメータの時間変化を停止します。 <br/>
	 * パラメータの値は停止時の現在値となります。</para>
     * </remarks>
     */
    public void Stop()
    {
        criAtomExTween_Stop(handle);
    }

    /**
     * <summary>AtomExTweenのリセット</summary>
     * <remarks>
     * <para header='説明'>AtomExTweenを停止してパラメータを初期値にリセットします。<br/>
	 * 基本パラメータの場合  :   各パラメータの初期値<br/>
	 * AISACコントロール値の場合 :   0.0</para>
     * </remarks>
     */
    public void Reset()
    {
        criAtomExTween_Reset(handle);
    }

    #region Internal

    ~CriAtomExTween()
    {
        Dispose();
    }

    IntPtr handle = IntPtr.Zero;

    #endregion

    #region DLL Import
#if !CRIWARE_ENABLE_HEADLESS_MODE
    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern IntPtr criAtomExTween_Create(ref Config config, IntPtr work, int work_size);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern void criAtomExTween_Destroy(IntPtr tween);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern Single criAtomExTween_GetValue(IntPtr tween);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern void criAtomExTween_MoveTo(IntPtr tween, UInt16 time_ms, Single value);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern void criAtomExTween_MoveFrom(IntPtr tween, UInt16 time_ms, Single value);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern void criAtomExTween_Stop(IntPtr tween);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern void criAtomExTween_Reset(IntPtr tween);

    [DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
    private static extern bool criAtomExTween_IsActive(IntPtr tween);
#else
    private static IntPtr criAtomExTween_Create(ref Config config, IntPtr work, int work_size) { return IntPtr.Zero; }
    private static void criAtomExTween_Destroy(IntPtr tween) { }
    private static Single criAtomExTween_GetValue(IntPtr tween) { return 0f; }
    private static void criAtomExTween_MoveTo(IntPtr tween, UInt16 time_ms, Single value) { }
    private static void criAtomExTween_MoveFrom(IntPtr tween, UInt16 time_ms, Single value) { }
    private static void criAtomExTween_Stop(IntPtr tween) { }
    private static void criAtomExTween_Reset(IntPtr tween) { }
    private static bool criAtomExTween_IsActive(IntPtr tween) { return false; }
#endif
    #endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
