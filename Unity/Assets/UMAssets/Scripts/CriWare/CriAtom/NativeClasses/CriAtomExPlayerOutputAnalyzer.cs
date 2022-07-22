/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2014 CRI Middleware Co., Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom Native Wrapper
 * File     : CriAtomExPlayerOutputAnalyzer.cs
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
 * <summary>音声出力データ解析モジュール（プレーヤ/ソース単位)</summary>
 * \par 説明:
 * CriAtomSource/CriAtomExPlayerごとの音声出力の解析を行います。<br/>
 * レベルメータ機能などを提供します。<br/>
 */
public class CriAtomExPlayerOutputAnalyzer : IDisposable
{
	public IntPtr nativeHandle {get {return this.handle;} }

	/**
	 * <summary>解析処理種別</summary>
	 * \par 説明：
	 * 解析モジュール作成時に指定する解析処理の種別を示す値です。
	 * \sa CriAtomExPlayerOutputAnalyzer
	 */
	public enum Type {
		LevelMeter = 0,		/**< レベルメーター(RMSレベル計測)	**/
	}

	/**
	 * <summary>音声出力データ解析モジュールの作成</summary>
	 * <returns>音声出力データ解析モジュール</returns>
	 * \par 説明：
	 * CriAtomSource/CriAtomExPlayerの出力音声データの解析モジュールを作成します。<br/>
	 * 作成した解析モジュールは、CriAtomSourceまたはCriAtomExPlayerにアタッチして使用します。<br/>
	 * アタッチしている音声出力に対し、レベルメータなどの解析を行います。</br>
	 * \par 備考：
	 * 解析モジュールにアタッチ可能なCriAtomSource/CriAtomExPlayerは一つのみです。<br>
	 * 解析モジュールを使いまわす場合は、デタッチを行ってください。
	 */
	public CriAtomExPlayerOutputAnalyzer(Type[] types)
	{
		/* ネイティブリソースの作成 */
		this.handle = criAtomExPlayerOutputAnalyzer_Create(types.Length, types);
		if (this.handle == IntPtr.Zero) {
			throw new Exception("criAtomExPlayerOutputAnalyzer_Create() failed.");
		}
	}

	/**
	 * <summary>AtomExプレーヤ出力データ解析モジュールの破棄</summary>
	 * \par 説明:
	 * AtomExプレーヤ出力データ解析モジュールを破棄します。<br/>
	 * 本関数を実行した時点で、AtomExプレーヤ出力データ解析モジュール作成時にプラグイン内で確保されたリソースが全て解放されます。<br/>
	 * \attention
	 * 本関数は完了復帰型の関数です。<br/>
	 * 音声再生中のAtomExプレーヤを破棄しようとした場合、本関数内で再生停止を
	 * \sa CriAtomExPlayerOutputAnalyzer::CriAtomExPlayerOutputAnalyzer
	 */
	public void Dispose()
	{
		if (this.handle == IntPtr.Zero) {
			return;
		}

		/* ネイティブリソースの破棄 */
		criAtomExPlayerOutputAnalyzer_Destroy(this.handle);
		GC.SuppressFinalize(this);
	}

	/**
	 * <summary>AtomExプレーヤのアタッチ</summary>
	 * \par 説明:
	 * 出力データ解析を行うAtomExプレーヤをアタッチします。<br/>
	 * 複数のAtomExプレーヤをアタッチすることは出来ません。
	 * アタッチ中に別のAtomExプレーヤをアタッチした場合、アタッチ中のAtomExプレーヤはデタッチされます。<br/>
	 * <br/>
	 * CriAtomSourceをアタッチする場合、CriAtomSource::AttachToOutputAnalyzerを使用してください。
	 * \attention
	 * アタッチは再生開始前に行う必要があります。再生開始後のアタッチは失敗します。<br/>
	 * \sa CriAtomExPlayerOutputAnalyzer::DetachExPlayer, CriAtomSource::AttachToOutputAnalyzer
	 */
	public void AttachExPlayer(CriAtomExPlayer player)
	{
		if (player == null || this.handle == IntPtr.Zero) {
			return;
		}

		/* アタッチ済みのプレーヤがあればデタッチ */
		this.DetachExPlayer();

		criAtomExPlayerOutputAnalyzer_AttachExPlayer(this.handle, player.nativeHandle);
		this.player = player;
	}

	/**
	 * <summary>AtomExプレーヤのデタッチ</summary>
	 * \par 説明:
	 * 出力データ解析を行うAtomExプレーヤをデタッチします。<br/>
	 * デタッチを行うと、以降の解析処理は行われなくなります。
	 * \attention
	 * \sa CriAtomExPlayerOutputAnalyzer::AttachExPlayer
	 */
	public void DetachExPlayer()
	{
		if (this.player == null || this.handle == IntPtr.Zero) {
			return;
		}

		criAtomExPlayerOutputAnalyzer_DetachExPlayer(this.handle, this.player.nativeHandle);
	}

	/**
	 * <summary>アタッチ中の音声出力のRMSレベルの取得</summary>
	 * <param name="id">チャンネル番号</param>
	 * <returns>RMSレベル</returns>
	 * \par 説明:
	 * アタッチ中の音声出力のRMSレベルを取得します。<br/>
	 * \sa CriAtomExPlayerOutputAnalyzer::AttachExPlayer
	 */
	public float GetRms(int channel)
	{
		if (this.player == null || this.handle == IntPtr.Zero) {
			return 0.0f;
		}

		/* プレーヤが再生状態でなければレベルを落とす */
		if (this.player.GetStatus() != CriAtomExPlayer.Status.Playing && 
			this.player.GetStatus() != CriAtomExPlayer.Status.Prep) {
			return 0.0f;
		}

		return criAtomExPlayerOutputAnalyzer_GetRms(this.handle, channel);
	}

	#region Internal Members
	~CriAtomExPlayerOutputAnalyzer()
	{
		this.Dispose();
	}

	private IntPtr handle = IntPtr.Zero;
	private CriAtomExPlayer player = null;
	#endregion

	#region DLL Import
	
	[DllImport(CriWare.pluginName)]
	private static extern IntPtr criAtomExPlayerOutputAnalyzer_Create(int numTypes, Type[] types);

	[DllImport(CriWare.pluginName)]
	private static extern IntPtr criAtomExPlayerOutputAnalyzer_Destroy(IntPtr analyzer);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExPlayerOutputAnalyzer_AttachExPlayer(IntPtr analyzer, IntPtr player);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExPlayerOutputAnalyzer_DetachExPlayer(IntPtr analyzer, IntPtr player);

	[DllImport(CriWare.pluginName)]
	private static extern float criAtomExPlayerOutputAnalyzer_GetRms(IntPtr analyzer, int channel);

	#endregion
}

/**
 * @}
 */

/* --- end of file --- */
