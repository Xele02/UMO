/****************************************************************************
 *
 * Copyright (c) 2017 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

/*==========================================================================
 *      CRI Atom Native Wrapper
 *=========================================================================*/
/**
 * \addtogroup CRIATOM_NATIVE_WRAPPER
 * @{
 */

namespace CriWare {

/**
 * <summary>AtomExサウンドオブジェクト</summary>
 * <remarks>
 * <para header='説明'>サウンドオブジェクトクラスです。<br/>
 * アプリケーション内の「物体」や「空間」、「状況」等に関連付けて、登録された
 * プレーヤに対して一括での音声コントロールを行うことができます。<br/></para>
 * </remarks>
 */
public class CriAtomExSoundObject : CriDisposable
{
	public IntPtr nativeHandle {get {return this.handle;} }

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	private struct Config {
		public bool enableVoiceLimitScope;
		public bool enableCategoryCueLimitScope;
	}

	/**
	 * <summary>サウンドオブジェクトの作成</summary>
	 * <param name='enableVoiceLimitScope'>ボイスリミットスコープを有効化するか</param>
	 * <param name='enableCategoryCueLimitScope'>カテゴリキューリミットスコープを有効化するか</param>
	 * <returns>サウンドオブジェクト</returns>
	 * <remarks>
	 * <para header='説明'>サウンドオブジェクトを作成します。<br/>
	 * enableVoiceLimitScope に true を指定すると、このサウンドオブジェクトに
	 * 関連付けられたExプレーヤから再生した音声の発音数について、このサウンド
	 * オブジェクト内でのみカウントし、ボイスリミットグループによる発音数制御を
	 * 行います。<br/>
	 * enableCategoryCueLimit に true を指定すると、このサウンドオブジェクトに
	 * 関連付けられたExプレーヤから再生したキューのカテゴリ再生数について、この
	 * サウンドオブジェクト内でのみカウントし、再生数制御を行います。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExSoundObject::Dispose'/>
	 */
	public CriAtomExSoundObject(bool enableVoiceLimitScope, bool enableCategoryCueLimitScope)
	{
		if (!CriAtomPlugin.IsLibraryInitialized()) {
			throw new Exception("CriAtomPlugin is not initialized.");
		}

		Config config;
		config.enableVoiceLimitScope = enableVoiceLimitScope;
		config. enableCategoryCueLimitScope = enableCategoryCueLimitScope;

		this.handle = criAtomExSoundObject_Create(ref config, IntPtr.Zero, 0);

		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
	}

	/**
	 * <summary>サウンドオブジェクトの破棄</summary>
	 * <remarks>
	 * <para header='説明'>サウンドオブジェクトを破棄します。<br/>
	 * 本関数を実行した時点で、サウンドオブジェクト作成時にDLL内で確保された
	 * リソースが全て解放されます。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExSoundObject::CriAtomExSoundObject'/>
	 */
	public override void Dispose()
	{
		CriDisposableObjectManager.Unregister(this);
		if (this.handle != IntPtr.Zero) {
			criAtomExSoundObject_Destroy(this.handle);
			this.handle = IntPtr.Zero;
		}
		GC.SuppressFinalize(this);
	}

	/**
	 * <summary>AtomExプレーヤの追加</summary>
	 * <param name='player'>AtomExプレーヤ</param>
	 * <remarks>
	 * <para header='説明'>サウンドオブジェクトにAtomExプレーヤを追加します。<br/>
	 * 追加したAtomExプレーヤはサウンドオブジェクトと関連付けられ、 サウンドオブジェクト
	 * による以下の影響を受けるようになります。<br/>
	 * - 発音数制限やイベント機能が影響する範囲（スコープ）の限定<br/>
	 * - 再生コントロール（停止、ポーズ等）<br/>
	 * - パラメータコントロール<br/>
	 * 追加したAtomExプレーヤをサウンドオブジェクトから削除する場合は、
	 * CriAtomExSoundObject::DeletePlayer 関数を呼び出してください。<br/></para>
	 * <para header='注意'>本関数の呼び出しは、追加しようとしているAtomExプレーヤで音声を再生していない状態で行ってください。<br/>
	 * 再生中のAtomExプレーヤが指定された場合、 追加時に再生停止が行われます。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExSoundObject::DeletePlayer'/>
	 * <seealso cref='CriAtomExSoundObject::DeleteAllPlayers'/>
	 * <seealso cref='CriAtomExPlayer::nativeHandle'/>
	 */
	public void AddPlayer(CriAtomExPlayer player)
	{
		criAtomExSoundObject_AddPlayer(this.handle, player.nativeHandle);
	}

	/**
	 * <summary>AtomExプレーヤの削除</summary>
	 * <param name='player'>AtomExプレーヤのネイティブハンドル</param>
	 * <remarks>
	 * <para header='説明'>サウンドオブジェクトからAtomExプレーヤを削除します。<br/>
	 * 削除したAtomExプレーヤはサウンドオブジェクトとの関連付けが切られ、 サウンドオブジェクト
	 * による影響を受けなくなります。<br/></para>
	 * <para header='注意'>本関数の呼び出しは、削除しようとしているAtomExプレーヤで音声を再生していない状態で行ってください。<br/>
	 * 再生中のAtomExプレーヤが指定された場合、 削除時に再生停止が行われます。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExSoundObject::AddPlayer'/>
	 * <seealso cref='CriAtomExSoundObject::DeleteAllPlayers'/>
	 * <seealso cref='CriAtomExPlayer::nativeHandle'/>
	 */
	public void DeletePlayer(CriAtomExPlayer player)
	{
		criAtomExSoundObject_DeletePlayer(this.handle, player.nativeHandle);
	}

	/**
	 * <summary>すべてのAtomExプレーヤの削除</summary>
	 * <remarks>
	 * <para header='説明'>サウンドオブジェクトに関連付けられているすべてのAtomExプレーヤを削除します。<br/>
	 * 削除したAtomExプレーヤはサウンドオブジェクトとの関連付けが切られ、 サウンドオブジェクト
	 * による影響を受けなくなります。<br/></para>
	 * <para header='注意'>本関数の呼び出しは、削除しようとしているAtomExプレーヤで音声を再生していない状態で行ってください。<br/>
	 * 再生中のAtomExプレーヤが指定された場合、 削除時に再生停止が行われます。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExSoundObject::AddPlayer'/>
	 * <seealso cref='CriAtomExSoundObject::DeletePlayer'/>
	 */
	public void DeleteAllPlayers()
	{
		criAtomExSoundObject_DeleteAllPlayers(this.handle);
	}

	#region Internal Members

	~CriAtomExSoundObject()
	{
		this.Dispose();
	}

	private IntPtr handle = IntPtr.Zero;

	#endregion

	#region DLL Import
	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomExSoundObject_Create(ref Config config, IntPtr work, int work_size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExSoundObject_Destroy(IntPtr soundObject);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExSoundObject_AddPlayer(IntPtr soundObject, IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExSoundObject_DeletePlayer(IntPtr soundObject, IntPtr player);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExSoundObject_DeleteAllPlayers(IntPtr soundObject);
	#else
	private static IntPtr criAtomExSoundObject_Create(ref Config config, IntPtr work, int work_size) { return IntPtr.Zero; }
	private static void criAtomExSoundObject_Destroy(IntPtr soundObject) { }
	private static void criAtomExSoundObject_AddPlayer(IntPtr soundObject, IntPtr player) { }
	private static void criAtomExSoundObject_DeletePlayer(IntPtr soundObject, IntPtr player) { }
	private static void criAtomExSoundObject_DeleteAllPlayers(IntPtr soundObject) { }
	#endif
	#endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
