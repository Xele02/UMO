/****************************************************************************
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
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

namespace CriWare {

/**
 * <summary>再生音オブジェクト</summary>
 * <remarks>
 * <para header='説明'>::CriAtomExPlayer::Start 関数実行時に返されるオブジェクトです。<br/>
 * プレーヤ単位ではなく、 ::CriAtomExPlayer::Start 関数で再生した個々の音声に対して
 * パラメータ変更や状態取得を行いたい場合、本オブジェクトを使用して制御を行う必要があります。<br/></para>
 * </remarks>
 * <seealso cref='CriAtomExPlayer::Start'/>
 */
public struct CriAtomExPlayback
{
	/**
	 * <summary>再生ステータス</summary>
	 * <remarks>
	 * <para header='説明'>AtomExプレーヤで再生済みの音声のステータスです。<br/>
	 * ::CriAtomExPlayback::GetStatus 関数で取得可能です。<br/>
	 * <br/>
	 * 再生状態は、通常以下の順序で遷移します。<br/>
	 * -# Prep
	 * -# Playing
	 * -# Removed
	 * .</para>
	 * <para header='備考'>StatusはAtomExプレーヤのステータスではなく、
	 * プレーヤで再生を行った（ ::CriAtomExPlayer::Start 関数を実行した）
	 * 音声のステータスです。<br/>
	 * <br/>
	 * 再生中の音声リソースは、発音が停止された時点で破棄されます。<br/>
	 * そのため、以下のケースで再生音のステータスが Removed に遷移します。<br/>
	 * - 再生が完了した場合。
	 * - Stop 関数で再生中の音声を停止した場合。
	 * - 高プライオリティの発音リクエストにより再生中のボイスが奪い取られた場合。
	 * - 再生中にエラーが発生した場合。
	 * .</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayback::GetStatus'/>
	 * <seealso cref='CriAtomExPlayback::Stop'/>
	 */
	public enum Status {
		Prep = 1,   /**< 再生準備中 */
		Playing,    /**< 再生中 */
		Removed     /**< 削除された */
	}

	/**
	 * <summary>再生トラック情報</summary>
	 * <remarks>
	 * <para header='説明'>再生中のキューのトラック情報を取得するための構造体です。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayback::GetTrackInfo'/>
	 */
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct TrackInfo {
		public uint id;                         /**< 再生ID */
		public CriAtomEx.CueType sequenceType;  /**< 親シーケンスタイプ */
		public IntPtr playerHn;                 /**< プレーヤハンドル */
		public ushort trackNo;                  /**< トラック番号 */
		public ushort reserved;                 /**< 予約領域 */
	}

	public CriAtomExPlayback(uint id)
		: this()
	{
		this.id = id;
	#if CRIWARE_ENABLE_HEADLESS_MODE
		this._dummyStatus = Status.Prep;
	#endif
	}

	/**
	 * <summary>再生音の停止</summary>
	 * <param name='ignoresReleaseTime'>リリース時間を無視するかどうか
	 * （false = リリース処理を行う、ture = リリース時間を無視して即座に停止する）</param>
	 * <remarks>
	 * <para header='説明'>再生音単位で停止処理を行います。<br/>
	 * 本関数を使用することで、プレーヤによって再生された音声を、プレーヤ単位ではなく、
	 * 個別に停止させることが可能です。<br/></para>
	 * <para header='備考'>AtomEx プレーヤによって再生された全ての音声を停止したい場合、
	 * 本関数ではなく ::CriAtomExPlayer::Stop 関数をご利用ください。<br/>
	 * （ ::CriAtomExPlayer::Stop 関数は、そのプレーヤで再生中の全ての音声を停止します。）<br/></para>
	 * <para header='注意'>本関数で再生音の停止を行うと、再生中の音声のステータスは Removed に遷移します。<br/>
	 * 停止時にボイスリソースも破棄されるため、一旦 Removed 状態に遷移した再生オブジェクトからは、
	 * 以降情報を取得できなくなります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Stop'/>
	 * <seealso cref='CriAtomExPlayback::GetStatus'/>
	 */
	public void Stop(bool ignoresReleaseTime)
	{
		if (CriAtomPlugin.IsLibraryInitialized() == false) { return; }

		if (ignoresReleaseTime == false) {
			criAtomExPlayback_Stop(this.id);
		} else {
			criAtomExPlayback_StopWithoutReleaseTime(this.id);
		}
	}

	/**
	 * <summary>再生音のポーズ</summary>
	 * <remarks>
	 * <para header='説明'>再生音単位でポーズを行います。<br/>
	 * <br/>
	 * 本関数を使用することで、プレーヤによって再生された音声を、プレーヤ単位ではなく、
	 * 個別にポーズさせることが可能です。<br/></para>
	 * <para header='備考'>プレーヤによって再生された全ての音声をポーズしたい場合、
	 * 本関数ではなく ::CriAtomExPlayer::Pause 関数をご利用ください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayback::IsPaused'/>
	 * <seealso cref='CriAtomExPlayer::Pause'/>
	 * <seealso cref='CriAtomExPlayback::Resume'/>
	 */
	public void Pause()
	{
		criAtomExPlayback_Pause(this.id, true);
	}

	/**
	 * <summary>再生音のポーズ解除</summary>
	 * <param name='mode'>ポーズ解除対象</param>
	 * <remarks>
	 * <para header='説明'>再生音単位で一時停止状態の解除を行います。<br/>
	 * 引数（mode）に PausedPlayback を指定して本関数を実行すると、
	 * ユーザが ::CriAtomExPlayer::Pause 関数（または ::CriAtomExPlayback::Pause
	 * 関数）で一時停止状態になった音声の再生が再開されます。<br/>
	 * 引数（mode）に PreparedPlayback を指定して本関数を実行すると、
	 * ユーザが ::CriAtomExPlayer::Prepare 関数で再生準備を指示した音声の再生が開始されます。<br/></para>
	 * <para header='備考'>::CriAtomExPlayer::Pause 関数でポーズ状態のプレーヤに対して ::CriAtomExPlayer::Prepare
	 * 関数で再生準備を行った場合、その音声は PausedPlayback 指定のポーズ解除処理と、
	 * PreparedPlayback 指定のポーズ解除処理の両方が行われるまで、再生が開始されません。<br/>
	 * <br/>
	 * ::CriAtomExPlayer::Pause 関数か ::CriAtomExPlayer::Prepare 関数かに関係なく、
	 * 常に再生を開始したい場合には、引数（mode）に AllPlayback を指定して本関数を実行してください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayback::IsPaused'/>
	 * <seealso cref='CriAtomExPlayer::Resume'/>
	 * <seealso cref='CriAtomExPlayer::Pause'/>
	 */
	public void Resume(CriAtomEx.ResumeMode mode)
	{
		criAtomExPlayback_Resume(this.id, mode);
	}

	/**
	 * <summary>再生音のポーズ状態の取得</summary>
	 * <returns>ポーズ中かどうか（false = ポーズされていない、true = ポーズ中）</returns>
	 * <remarks>
	 * <para header='説明'>再生中の音声がポーズ中かどうかを返します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayback::Pause'/>
	 */
	public bool IsPaused()
	{
		return criAtomExPlayback_IsPaused(this.id);
	}

	/**
	 * <summary>再生音のフォーマット情報の取得</summary>
	 * <param name='info'>フォーマット情報</param>
	 * <returns>情報が取得できたかどうか（ true = 取得できた、 false = 取得できなかった）</returns>
	 * <remarks>
	 * <para header='説明'>::CriAtomExPlayer::Start 関数で再生された音声のフォーマット情報を取得します。<br/>
	 * <br/>
	 * フォーマット情報が取得できた場合、本関数は true を返します。<br/>
	 * 指定したボイスが既に消去されている場合等には、本関数は false を返します。<br/></para>
	 * <para header='備考'>複数の音声データを含むキューを再生した場合、最初に見つかった音声
	 * データの情報が返されます。<br/></para>
	 * <para header='注意'>本関数は、音声再生中のみフォーマット情報を取得可能です。<br/>
	 * 再生準備中や再生終了後、発音数制御によりボイスが消去された場合には、
	 * フォーマット情報の取得に失敗します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::GetStatus'/>
	 */
	public bool GetFormatInfo(out CriAtomEx.FormatInfo info)
	{
		return criAtomExPlayback_GetFormatInfo(this.id, out info);
	}

	/**
	 * <summary>再生ステータスの取得</summary>
	 * <returns>再生ステータス</returns>
	 * <remarks>
	 * <para header='説明'>::CriAtomExPlayer::Start 関数で再生された音声のステータスを取得します。<br/></para>
	 * <para header='備考'>::CriAtomExPlayer::GetStatus 関数がAtomExプレーヤのステータスを返すのに対し、
	 * 本関数は再生済みの個々の音声のステータスを取得します。<br/>
	 * <br/>
	 * 再生中の音声のボイスリソースは、以下の場合に削除されます。<br/>
	 * - 再生が完了した場合。
	 * - Stop 関数で再生中の音声を停止した場合。
	 * - 高プライオリティの発音リクエストにより再生中のボイスが奪い取られた場合。
	 * - 再生中にエラーが発生した場合。
	 * .
	 * そのため、 ::CriAtomExPlayback::Stop 関数を使用して明示的に再生を停止したか、
	 * その他の要因によって再生が停止されたかの違いに関係なく、
	 * 再生音のステータスはいずれの場合も Removed に遷移します。<br/>
	 * （エラーの発生を検知する必要がある場合には、本関数ではなく、 ::CriAtomExPlayer::GetStatus
	 * 関数で AtomEx プレーヤのステータスをチェックする必要があります。）<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::GetStatus'/>
	 * <seealso cref='CriAtomExPlayback::Stop'/>
	 */
	public Status GetStatus()
	{
		return criAtomExPlayback_GetStatus(this.id);
	}

	/**
	 * <summary>再生時刻の取得</summary>
	 * <returns>再生時刻（ミリ秒単位）</returns>
	 * <remarks>
	 * <para header='説明'>::CriAtomExPlayer::Start 関数で再生された音声の再生時刻を取得します。<br/>
	 * <br/>
	 * 再生時刻が取得できた場合、本関数は 0 以上の値を返します。<br/>
	 * 指定したボイスが既に消去されている場合等には、本関数は負値を返します。<br/></para>
	 * <para header='備考'>本関数が返す再生時刻は「再生開始後からの経過時間」です。<br/>
	 * ループ再生時や、シームレス連結再生時を行った場合でも、
	 * 再生位置に応じて時刻が巻き戻ることはありません。<br/>
	 * <br/>
	 * ::CriAtomExPlayer::Pause 関数でポーズをかけた場合、
	 * 再生時刻のカウントアップも停止します。<br/>
	 * （ポーズを解除すれば再度カウントアップが再開されます。）
	 * <br/>
	 * 本関数で取得可能な時刻の精度は、サーバ処理の周波数に依存します。<br/>
	 * （時刻の更新はサーバ処理単位で行われます。）<br/>
	 * より精度の高い時刻を取得する必要がある場合には、本関数の代わりに
	 * ::CriAtomExPlayback::GetNumPlayedSamples 関数を使用し、
	 * 再生済みサンプル数を取得してください。<br/></para>
	 * <para header='注意'>戻り値の型は long ですが、現状、32bit以上の精度はありません。<br/>
	 * 再生時刻を元に制御を行う場合、約24日で再生時刻が異常になる点に注意が必要です。<br/>
	 * （ 2147483647 ミリ秒を超えた時点で、再生時刻がオーバーフローし、負値になります。）<br/>
	 * <br/>
	 * 本関数は、音声再生中のみ時刻を取得可能です。<br/>
	 * （ ::CriAtomExPlayer::GetTime 関数と異なり、本関数は再生中の音声ごとに時刻を
	 * 取得可能ですが、再生終了時刻を取ることができません。）<br/>
	 * 再生終了後や、発音数制御によりボイスが消去された場合には、
	 * 再生時刻の取得に失敗します。<br/>
	 * （負値が返ります。）<br/>
	 * <br/>
	 * デバイスのリードリトライ処理等により、音声データの供給が一時的に途切れた場合でも、
	 * 再生時刻のカウントアップが途切れることはありません。<br/>
	 * （データ供給停止により再生が停止した場合でも、時刻は進み続けます。）<br/>
	 * そのため、本関数で取得した時刻を元に映像との同期を行った場合、
	 * リードリトライ発生毎に同期が大きくズレる可能性があります。<br/>
	 * 波形データと映像の同期を厳密に取る必要がある場合は、本関数の代わりに
	 * ::CriAtomExPlayback::GetNumPlayedSamples 関数を使用し、
	 * 再生済みサンプル数との同期を取ってください。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::GetTime'/>
	 * <seealso cref='CriAtomExPlayback::GetNumPlayedSamples'/>
	 */
	public long GetTime()
	{
		return criAtomExPlayback_GetTime(this.id);
	}

	/**
	 * <summary>音声に同期した再生時刻の取得</summary>
	 * <returns>再生時刻（ミリ秒単位）</returns>
	 * <remarks>
	 * <para header='説明'>::CriAtomExPlayer::Start 関数で再生された音声の再生時刻を取得します。<br/>
	 * <br/>
	 * 再生時刻が取得できた場合、本関数は 0 以上の値を返します。<br/>
	 * 指定したボイスが既に消去されている場合等には、本関数は負値を返します。<br/></para>
	 * <para header='備考'>::CriAtomExPlayback::GetTime 関数が返す「再生開始後からの経過時間」とは
	 * 異なり、本関数からは再生中の音声に同期した再生時刻を取得することが
	 * 可能です。<br/>
	 * デバイスのリードリトライ処理等により、音声データの供給が途切れて
	 * 再生が停止した場合、再生時刻のカウントアップが一時的に停止します。<br/>
	 * 再生された音声に厳密に同期した処理を行いたい場合は、本関数で
	 * 取得した再生時刻を用いてください。<br/>
	 * ただし、ループ再生時や、シームレス連結再生時を行った場合でも、
	 * 再生位置に応じて時刻が巻き戻ることはありません。<br/>
	 * また、波形の詰まっていないシーケンスキューや
	 * 再生波形が切り替わるブロックシーケンスキューに対しては、正常に再生時刻を
	 * 取得することができません。<br/>
	 * <br/>
	 * ::CriAtomExPlayer::Pause 関数でポーズをかけた場合、
	 * 再生時刻のカウントアップも停止します。<br/>
	 * （ポーズを解除すれば再度カウントアップが再開されます。）<br/>
	 * <br/>
	 * 本関数を用いて再生時刻を取得するには、 ::CriAtomExPlayer::CriAtomExPlayer(bool) 関数を
	 * 用いて、音声同期タイマを有効にするフラグを指定してプレーヤの作成を行ってください。
	 * <br/></para>
	 * <para header='注意'>戻り値の型は long ですが、現状、32bit以上の精度はありません。<br/>
	 * 再生時刻を元に制御を行う場合、約24日で再生時刻が異常になる点に注意が必要です。<br/>
	 * （ 2147483647 ミリ秒を超えた時点で、再生時刻がオーバーフローし、負値になります。）<br/>
	 * <br/>
	 * 本関数は、音声再生中のみ時刻を取得可能です。<br/>
	 * （ ::CriAtomExPlayer::GetTime 関数と異なり、本関数は再生中の音声ごとに時刻を
	 * 取得可能ですが、再生終了時刻を取ることができません。）<br/>
	 * 再生終了後や、発音数制御によりボイスが消去された場合には、
	 * 再生時刻の取得に失敗します。<br/>
	 * （負値が返ります。）<br/>
	 * <br/>
	 * 本関数は内部で時刻計算を行っており、プラットフォームによっては処理負荷が
	 * 問題になる可能性があります。また、アプリケーションの同じフレーム内であっても、
	 * 呼び出し毎に更新された時刻を返します。<br/>
	 * アプリケーションによる再生時刻の利用方法にもよりますが、基本的に本関数を用いた
	 * 時刻取得は1フレームにつき一度のみ行うようにしてください。<br/>
	 * <br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayback::GetTime'/>
	 * <seealso cref='CriAtomExPlayback::GetNumPlayedSamples'/>
	 * <seealso cref='CriAtomExPlayer::CriAtomExPlayer(bool)'/>
	 */
	public long GetTimeSyncedWithAudio()
	{
		return criAtomExPlayback_GetTimeSyncedWithAudio(this.id);
	}

	/**
	 * <summary>再生サンプル数の取得</summary>
	 * <param name='numSamples'>再生済みサンプル数</param>
	 * <param name='samplingRate'>サンプリングレート</param>
	 * <returns>サンプル数が取得できたかどうか（ true = 取得できた、 false = 取得できなかった）</returns>
	 * <remarks>
	 * <para header='説明'>::CriAtomExPlayer::Start 関数で再生された音声の再生サンプル数、
	 * およびサンプリングレートを返します。<br/>
	 * <br/>
	 * 再生サンプル数が取得できた場合、本関数は true を返します。<br/>
	 * 指定したボイスが既に消去されている場合等には、本関数は false を返します。<br/>
	 * （エラー発生時は numSamples や samplingRate の値も負値になります。）<br/></para>
	 * <para header='備考'>再生済みサンプル数の値の精度は、プラットフォーム SDK
	 * のサウンドライブラリに依存します。<br/>
	 * （プラットフォームによって、再生済みサンプル数の正確さは異なります。）<br/>
	 * <br/>
	 * 複数の音声データを含むキューを再生した場合、最初に見つかった音声
	 * データの情報が返されます。<br/></para>
	 * <para header='注意'>デバイスのリードリトライ処理等により、音声データの供給が途切れた場合、
	 * 再生サンプル数のカウントアップが停止します。<br/>
	 * （データ供給が再開されれば、カウントアップが再開されます。）<br/>
	 * <br/>
	 * 本関数は、音声再生中のみ再生サンプル数を取得可能です。<br/>
	 * 再生終了後や、発音数制御によりボイスが消去された場合には、
	 * 再生サンプル数の取得に失敗します。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public bool GetNumPlayedSamples(out long numSamples, out int samplingRate)
	{
		return criAtomExPlayback_GetNumPlayedSamples(this.id, out numSamples, out samplingRate);
	}

	/**
	 * <summary>シーケンス再生位置の取得</summary>
	 * <returns>シーケンス再生位置（ミリ秒単位）</returns>
	 * <remarks>
	 * <para header='説明'>::CriAtomExPlayer::Start 関数で再生された音声のシーケンス再生位置を取得します。<br/>
	 * <br/>
	 * 再生位置が取得できた場合、本関数は 0 以上の値を返します。<br/>
	 * 指定したシーケンスが既に消去されている場合等には、本関数は負値を返します。<br/></para>
	 * <para header='備考'>本関数が返す再生時刻は「シーケンスデータ上の再生位置」です。<br/>
	 * シーケンスループや、ブロック遷移を行った場合は、巻き戻った値が返ります。<br/>
	 * <br/>
	 * キュー指定以外での再生ではシーケンサーが動作しません。キュー再生以外の再生に対して
	 * 本関数は負値を返します。<br/>
	 * <br/>
	 * ::CriAtomExPlayer::Pause 関数でポーズをかけた場合、再生位置の更新も停止します。<br/>
	 * （ポーズを解除すれば再度更新が再開されます。）
	 * <br/>
	 * 本関数で取得可能な時刻の精度は、サーバ処理の周波数に依存します。<br/>
	 * （時刻の更新はサーバ処理単位で行われます。）<br/></para>
	 * <para header='注意'>戻り値の型は long ですが、現状、32bit以上の精度はありません。<br/>
	 * 再生位置を元に制御を行う場合、シーケンスループ等の設定がないデータでは
	 * 約24日で再生位置が異常になる点に注意が必要です。<br/>
	 * （ 2147483647 ミリ秒を超えた時点で、再生位置がオーバーフローし、負値になります。）<br/>
	 * <br/>
	 * 本関数は、音声再生中のみ位置を取得可能です。<br/>
	 * 再生終了後や、発音数制御によりシーケンスが消去された場合には、
	 * 再生位置の取得に失敗します。<br/>
	 * （負値が返ります。）<br/></para>
	 * </remarks>
	 *
	 */
	public long GetSequencePosition()
	{
		return criAtomExPlayback_GetSequencePosition(this.id);
	}

	/**
	 * <summary>再生音のカレントブロックインデックスの取得</summary>
	 * <returns>カレントブロックインデックス</returns>
	 * <remarks>
	 * <para header='説明'>::CriAtomExPlayer::Start 関数で再生されたブロックシーケンスの、
	 * カレントブロックインデックスを取得します。<br/></para>
	 * <para header='備考'>再生IDにより再生しているデータがブロックシーケンスではない場合は、 0xFFFFFFFF が返ります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 * <seealso cref='CriAtomExPlayer::SetFirstBlockIndex'/>
	 * <seealso cref='CriAtomExPlayback::SetNextBlockIndex'/>
	 */
	public int GetCurrentBlockIndex()
	{
		return criAtomExPlayback_GetCurrentBlockIndex(this.id);
	}

	/**
	 * <summary>再生トラック情報の取得</summary>
	 * <param name='info'>再生トラック情報</param>
	 * <returns>取得に成功したか</returns>
	 * <remarks>
	 * <para header='説明'>::CriAtomExPlayer::Start 関数で再生されたキューのトラック情報を取得します。<br/>
	 * 取得できるトラック情報はキュー直下の情報だけです、サブシーケンスやキューリンクの情報は取得できません。<br/></para>
	 * <para header='備考'>以下に該当するデータを再生中の場合、トラック情報の取得に失敗します。<br/>
	 * - キュー以外のデータを再生している。（トラック情報が存在しないため）<br/>
	 * - 再生中のキューがポリフォニックタイプ、またはセレクタ参照のスイッチタイプである。
	 *   （トラック情報が複数存在する可能性があるため）<br/>
	 * - 再生中のキューがトラック遷移タイプである。（遷移により再生トラックが変わるため）<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public bool GetTrackInfo(out TrackInfo info)
	{
		return criAtomExPlayback_GetPlaybackTrackInfo(this.id, out info);
	}

	/**
	 * <summary>ビート同期情報の取得</summary>
	 * <param name='info'>ビート同期情報</param>
	 * <returns>取得に成功したか</returns>
	 * <remarks>
	 * <para header='説明'>::CriAtomExPlayer::Start 関数で再生されたキューのビート同期情報を取得します。<br/>
	 * 現在のBPM、小節のカウント、拍のカウント、拍の進捗割合(0.0～1.0)を取得することができます。<br/>
	 * キューにはビート同期情報が設定されている必要があります。<br/>
	 * キューリンクやスタートアクションで再生しているキューの情報は取得できません。<br/></para>
	 * <para header='備考'>以下に該当するデータを再生中の場合、ビート同期情報の取得に失敗します。<br/>
	 * - キュー以外のデータを再生している。（ビート同期情報が存在しないため）<br/>
	 * - ビート同期情報が設定されていないキューを再生している。<br/>
	 * - ビート同期情報が設定されているキューを"間接的"に再生している。
	 *   （キューリンクやスタートアクションで再生している）<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::Start'/>
	 */
	public bool GetBeatSyncInfo(out CriAtomExBeatSync.Info info)
	{
		return criAtomExPlayback_GetBeatSyncInfo(this.id, out info);
	}

	/**
	 * <summary>再生音のブロック遷移</summary>
	 * <param name='index'>ブロックインデックス</param>
	 * <remarks>
	 * <para header='説明'>再生音単位でブロック遷移を行います。<br/>
	 * 本関数を実行すると、指定したIDの音声がブロックシーケンスの場合はデータの
	 * 設定に従った任意の遷移タイミングで指定ブロックに遷移します。<br/></para>
	 * <para header='備考'>再生開始ブロックの指定は ::CriAtomExPlayer::SetFirstBlockIndex 関数を使用して行い、
	 * 再生中のブロックインデックス取得は ::CriAtomExPlayback::GetCurrentBlockIndex 関数を使用します。</para>
	 * </remarks>
	 * <seealso cref='CriAtomExPlayer::SetFirstBlockIndex'/>
	 * <seealso cref='CriAtomExPlayback::GetCurrentBlockIndex'/>
	 */
	public void SetNextBlockIndex(int index)
	{
		criAtomExPlayback_SetNextBlockIndex(this.id, index);
	}

	public uint id
	{
		get;
		private set;
	}

	public Status status
	{
		get {
			return this.GetStatus();
		}
	}

	public long time
	{
		get {
			return this.GetTime();
		}
	}

	public long timeSyncedWithAudio
	{
		get {
			return this.GetTimeSyncedWithAudio();
		}
	}

	public const uint invalidId = 0xFFFFFFFF;

	/* Old APIs */
	public void Stop() {
		if (CriAtomPlugin.IsLibraryInitialized() == false) { return; }
		criAtomExPlayback_Stop(this.id);
	}
	public void StopWithoutReleaseTime() {
		if (CriAtomPlugin.IsLibraryInitialized() == false) { return; }
		criAtomExPlayback_StopWithoutReleaseTime(this.id);
	}
	public void Pause(bool sw) { criAtomExPlayback_Pause(this.id, sw); }


	#region DLL Import
	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayback_Stop(uint id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayback_StopWithoutReleaseTime(uint id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayback_Pause(uint id, bool sw);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayback_Resume(uint id, CriAtomEx.ResumeMode mode);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExPlayback_IsPaused(uint id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern Status criAtomExPlayback_GetStatus(uint id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExPlayback_GetFormatInfo(
		uint id, out CriAtomEx.FormatInfo info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern long criAtomExPlayback_GetTime(uint id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern long criAtomExPlayback_GetTimeSyncedWithAudio(uint id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExPlayback_GetNumPlayedSamples(
		uint id, out long num_samples, out int sampling_rate);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern long criAtomExPlayback_GetSequencePosition(uint id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExPlayback_SetNextBlockIndex(uint id, int index);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomExPlayback_GetCurrentBlockIndex(uint id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExPlayback_GetPlaybackTrackInfo(uint id, out TrackInfo info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExPlayback_GetBeatSyncInfo(uint id, out CriAtomExBeatSync.Info info);
	#else
	private Status _dummyStatus;
	private bool _dummyPaused;
	private void criAtomExPlayback_Stop(uint id) { _dummyStatus = Status.Removed; }
	private void criAtomExPlayback_StopWithoutReleaseTime(uint id) { _dummyStatus = Status.Removed; }
	private void criAtomExPlayback_Pause(uint id, bool sw) { _dummyPaused = sw; }
	private static void criAtomExPlayback_Resume(uint id, CriAtomEx.ResumeMode mode) { }
	private bool criAtomExPlayback_IsPaused(uint id) { return _dummyPaused; }
	private Status criAtomExPlayback_GetStatus(uint id)
	{
		if (_dummyStatus != Status.Removed) {
			_dummyStatus = _dummyStatus + 1;
		}
		return _dummyStatus;
	}
	private static bool criAtomExPlayback_GetFormatInfo(
		uint id, out CriAtomEx.FormatInfo info) { info = new CriAtomEx.FormatInfo(); return false; }
	private static long criAtomExPlayback_GetTime(uint id) { return 0; }
	private static long criAtomExPlayback_GetTimeSyncedWithAudio(uint id) { return 0; }
	private static bool criAtomExPlayback_GetNumPlayedSamples(
		uint id, out long num_samples, out int sampling_rate) { num_samples = sampling_rate = 0; return false; }
	private static long criAtomExPlayback_GetSequencePosition(uint id) { return 0; }
	private static void criAtomExPlayback_SetNextBlockIndex(uint id, int index) { }
	private static int criAtomExPlayback_GetCurrentBlockIndex(uint id) { return -1; }
	private static bool criAtomExPlayback_GetPlaybackTrackInfo(uint id, out TrackInfo info) { info = new TrackInfo(); return false; }
	private static bool criAtomExPlayback_GetBeatSyncInfo(uint id, out CriAtomExBeatSync.Info info) { info = new CriAtomExBeatSync.Info(); return false; }
	#endif
	#endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
