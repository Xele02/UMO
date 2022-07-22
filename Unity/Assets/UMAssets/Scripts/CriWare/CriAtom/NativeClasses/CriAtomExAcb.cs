/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom Native Wrapper
 * File     : CriAtomExAcb.cs
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
 * <summary>ACB、AWBデータ</summary>
 * \par 説明:
 * キュー情報を管理するクラスです。<br/>
 * ACB、AWBファイルのロード、アンロードやキュー情報等を取得します。<br/>
 */
public class CriAtomExAcb : IDisposable
{
	public IntPtr nativeHandle {get {return this.handle;} }

	/**
	 * <summary>ACBファイルのロード</summary>
	 * <param name="binder">バインダオブジェクト</param>
	 * <param name="acbPath">ACBファイルのパス</param>
	 * <param name="awbPath">AWBファイルのパス</param>
	 * <returns>CriAtomExAcbオブジェクト</returns>
	 * \par 説明:
	 * ACBファイルをロードし、キュー再生に必要な情報を取り込みます。<br/>
	 * <br/>
	 * 第2引数の acbPath にはオンメモリ再生用のACBファイルのパスを、
	 * 第3引数の awbPath にはストリーム再生用のAWBファイルのパスを、それぞれ指定します。<br/>
	 * （オンメモリ再生のみのACBデータをロードする場合、
	 * awbPath にセットした値は無視されます。）<br/>
	 * <br/>
	 * ACBファイルとAWBファイルを一つのCPKファイルにパッキングしている場合、
	 * 第1引数（ binder ）にCPKファイルをバインドしたCriFsBinderオブジェクトを指定する必要があります。<br/>
	 * <br/>
	 * ACBファイルをロードすると、ACBデータにアクセスするためのCriAtomExAcbオブジェクト
	 * （ ::CriAtomExAcb ）が返されます。<br/>
	 * AtomExプレーヤに対し、 ::CriAtomExPlayer::SetCue 関数でACBハンドル、
	 * および再生するキュー名を指定することで、
	 * ACBファイル内のキューを再生することが可能です。<br/>
	 * <br/>
	 * リードエラー等によりACBファイルのロードに失敗した場合、
	 * 本関数は戻り値として null を返します。<br/>
	 * \attention
	 * 本関数を実行する前に、ライブラリを初期化しておく必要があります。<br/>
	 * <br/>
	 * ACBハンドルは内部的にバインダ（ CriFsBinder ）を確保します。<br/>
	 * ACBファイルをロードする場合、
	 * ACBファイル数分のバインダが確保できる設定でライブラリを初期化する必要があります。<br/>
	 * <br/>
	 * 本関数は完了復帰型の関数です。<br/>
	 * ACBファイルのロードにかかる時間は、プラットフォームによって異なります。<br/>
	 * ゲームループ等の画面更新が必要なタイミングで本関数を実行するとミリ秒単位で
	 * 処理がブロックされ、フレーム落ちが発生する恐れがあります。<br/>
	 * ACBファイルのロードは、シーンの切り替わり等、負荷変動を許容できる
	 * タイミングで行うようお願いいたします。<br/>
	 * \sa criAtomExAcb_CalculateWorkSizeForLoadAcbFile, CriAtomExAcbHn, criAtomExPlayer_SetCueId
	 */
	public static CriAtomExAcb LoadAcbFile(CriFsBinder binder, string acbPath, string awbPath)
	{
		IntPtr binderHandle = (binder != null) ? binder.nativeHandle : IntPtr.Zero;
		IntPtr handle = criAtomExAcb_LoadAcbFile(
			binderHandle, acbPath, binderHandle, awbPath, IntPtr.Zero, 0);
		if (handle == IntPtr.Zero) {
			return null;
		}
		return new CriAtomExAcb(handle);
	}

	/**
	 * <summary>ACBデータのロード</summary>
	 * <param name="acbData">ACBファイルのパス</param>
	 * <param name="awbBinder">AWB用バインダオブジェクト</param>
	 * <param name="awbPath">AWBファイルのパス</param>
	 * <returns>CriAtomExAcbオブジェクト</returns>
	 * \par 説明:
	 * メモリ上に配置されたACBデータをロードし、キュー再生に必要な情報を取り込みます。<br/>
	 * <br/>
	 * 第2引数の awbPath にはストリーム再生用のAWBファイルのパスを、それぞれ指定します。<br/>
	 * （オンメモリ再生のみのACBデータをロードする場合、
	 * awbPath にセットした値は無視されます。）<br/>
	 * <br/>
	 * AWBファイルをCPKファイルにパッキングしている場合、
	 * 第1引数（ binder ）にCPKファイルをバインドしたCriFsBinderオブジェクトを指定する必要があります。<br/>
	 * <br/>
	 * ACBデータをロードすると、ACBデータにアクセスするためのCriAtomExAcbオブジェクト
	 * （ ::CriAtomExAcb ）が返されます。<br/>
	 * AtomExプレーヤに対し、 ::CriAtomExPlayer::SetCue 関数でACBハンドル、
	 * および再生するキュー名を指定することで、
	 * ACBファイル内のキューを再生することが可能です。<br/>
	 * <br/>
	 * リードエラー等によりACBファイルのロードに失敗した場合、
	 * 本関数は戻り値として null を返します。<br/>
	 * \attention
	 * 本関数を実行する前に、ライブラリを初期化しておく必要があります。<br/>
	 * <br/>
	 * ACBハンドルは内部的にバインダ（ CriFsBinder ）を確保します。<br/>
	 * ACBファイルをロードする場合、
	 * ACBファイル数分のバインダが確保できる設定でライブラリを初期化する必要があります。<br/>
	 * <br/>
	 * 本関数は完了復帰型の関数です。<br/>
	 * ACBファイルのロードにかかる時間は、プラットフォームによって異なります。<br/>
	 * ゲームループ等の画面更新が必要なタイミングで本関数を実行するとミリ秒単位で
	 * 処理がブロックされ、フレーム落ちが発生する恐れがあります。<br/>
	 * ACBファイルのロードは、シーンの切り替わり等、負荷変動を許容できる
	 * タイミングで行うようお願いいたします。<br/>
	 * \sa criAtomExAcb_CalculateWorkSizeForLoadAcbFile, CriAtomExAcbHn, criAtomExPlayer_SetCueId
	 */
	public static CriAtomExAcb LoadAcbData(byte[] acbData, CriFsBinder awbBinder, string awbPath)
	{
		IntPtr binderHandle = (awbBinder != null) ? awbBinder.nativeHandle : IntPtr.Zero;
		IntPtr handle = criAtomExAcb_LoadAcbData(
			acbData, acbData.Length, binderHandle, awbPath, IntPtr.Zero, 0);
		if (handle == IntPtr.Zero) {
			return null;
		}
		return new CriAtomExAcb(handle);
	}

	/**
	 * <summary>ACBファイルのアンロード</summary>
	 * \par 説明:
	 * ロード済みのACBファイルをアンロードします。<br/>
	 * \par 備考:
	 * 本関数を実行すると、
	 * アンロードするACBファイルを参照しているキューは全て停止されます。<br/>
	 * （本関数実行後に、ACBハンドルの作成に使用したワーク領域や、
	 * ACBデータが配置されていた領域が参照されることはありません。）<br/>
	 * \attention
	 * 本関数を実行すると、破棄しようとしているACBデータを参照している
	 * Atomプレーヤが存在しないか、ライブラリ内で検索処理が行われます。<br/>
	 * そのため、本関数実行中に他スレッドでAtomプレーヤの作成／破棄を行うと、
	 * アクセス違反やデッドロック等の重大な不具合を誘発する恐れがあります。<br/>
	 * 本関数実行時にAtomプレーヤの作成／破棄を他スレッドで行う必要がある場合、
	 * Atomプレーヤの作成／破棄を ::criAtomEx_Lock 関数でロックしてから実行ください。<br/>
	 * \sa criAtomExAcb_LoadAcbData, criAtomExAcb_LoadAcbFile
	 */
	public void Dispose()
	{
		criAtomExAcb_Release(this.handle);
		GC.SuppressFinalize(this);
	}

	/**
	 * <summary>キューの存在確認（キュー名指定）</summary>
	 * <param name="cueName">キュー名</param>
	 * <returns>キューが存在するかどうか（存在する：true、存在しない：false）</returns>
	 * \par 説明:
	 * 指定した名前のキューが存在するかどうかを取得します。<br/>
	 * 存在した場合にはtrueを返します。<br/>
	 */
	public bool Exists(string cueName)
	{
		return criAtomExAcb_ExistsName(this.handle, cueName);
	}

	/**
	 * <summary>キューの存在確認（キューID指定）</summary>
	 * <param name="cueId">キューID</param>
	 * <returns>キューが存在するかどうか（存在する：true、存在しない：false）</returns>
	 * \par 説明:
	 * 指定したIDのキューが存在するかどうかを取得します。<br/>
	 * 存在した場合にはtrueを返します。<br/>
	 */
	public bool Exists(int cueId)
	{
		return criAtomExAcb_ExistsId(this.handle, cueId);
	}

	/**
	 * <summary>キュー情報の取得（キュー名指定）</summary>
	 * <param name="cueName">キュー名</param>
	 * <param name="info">キュー情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * \par 説明:
	 * キュー名を指定して、キュー情報を取得します。<br/>
	 * 指定した名前のキューが存在しない場合、falseが返ります。<br/>
	 * \sa criAtomExAcb_GetCueInfoById, criAtomExAcb_GetCueInfoByIndex
	 */
	public bool GetCueInfo(string cueName, out CriAtomEx.CueInfo info)
	{
		using (var mem = new CriStructMemory<CriAtomEx.CueInfo>()) {
			bool result = criAtomExAcb_GetCueInfoByName(this.handle, cueName, mem.ptr);
			info = new CriAtomEx.CueInfo(mem.bytes, 0);
			return result;
		}
	}
	
	/**
	 * <summary>キュー情報の取得（キューID指定）</summary>
	 * <param name="cueId">キューID</param>
	 * <param name="info">キュー情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * \par 説明:
	 * キューIDを指定して、キュー情報を取得します。<br/>
	 * 指定したIDのキューが存在しない場合、falseが返ります。<br/>
	 * \sa criAtomExAcb_GetCueInfoById, criAtomExAcb_GetCueInfoByIndex
	 */
	public bool GetCueInfo(int cueId, out CriAtomEx.CueInfo info)
	{
		using (var mem = new CriStructMemory<CriAtomEx.CueInfo>()) {
			bool result = criAtomExAcb_GetCueInfoById(this.handle, cueId, mem.ptr);
			info = new CriAtomEx.CueInfo(mem.bytes, 0);
			return result;
		}
	}

	/**
	 * <summary>キュー情報の取得（キューインデックス指定）</summary>
	 * <param name="index">キューインデックス</param>
	 * <param name="info">キュー情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * \par 説明:
	 * キューインデックスを指定して、キュー情報を取得します。<br/>
	 * 指定したインデックスのキューが存在しない場合、falseが返ります。<br/>
	 * \sa criAtomExAcb_GetCueInfoById, criAtomExAcb_GetCueInfoByIndex
	 */
	public bool GetCueInfoByIndex(int index, out CriAtomEx.CueInfo info)
	{
		using (var mem = new CriStructMemory<CriAtomEx.CueInfo>()) {
			bool result = criAtomExAcb_GetCueInfoByIndex(this.handle, index, mem.ptr);
			info = new CriAtomEx.CueInfo(mem.bytes, 0);
			return result;
		}
	}

	public CriAtomEx.CueInfo[] GetCueInfoList()
	{
		int numCues = criAtomExAcb_GetNumCues(this.handle);
		var infoList = new CriAtomEx.CueInfo[numCues];
		for (int i = 0; i < numCues; i++) {
			this.GetCueInfoByIndex(i, out infoList[i]);
		}
		return infoList;
	}

	/**
	 * <summary>音声波形情報の取得（キュー名指定）</summary>
	 * <param name="cueId">キュー名</param>
	 * <param name="info>音声波形情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * \par 説明:
	 * キュー名を指定して、そのキューで再生される音声波形の情報を取得します。<br/>
	 * そのキューで再生される音声波形が複数ある場合、
	 * 初めのトラックで初めに再生される音声波形の情報が取得されます。
	 * 指定した名前のキューが存在しない場合、falseが返ります。<br/>
	 */
	public bool GetWaveFormInfo(string cueName, out CriAtomEx.WaveformInfo info)
	{
		using (var mem = new CriStructMemory<CriAtomEx.WaveformInfo>()) {
			bool result = criAtomExAcb_GetWaveformInfoByName(this.handle, cueName, mem.ptr);
			info = new CriAtomEx.WaveformInfo(mem.bytes, 0);
			return result;
		}
	}

	/**
	 * <summary>音声波形情報の取得（キューID指定）</summary>
	 * <param name="cueId">キューID</param>
	 * <param name="info>音声波形情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * \par 説明:
	 * キューIDを指定して、そのキューで再生される音声波形の情報を取得します。<br/>
	 * そのキューで再生される音声波形が複数ある場合、
	 * 初めのトラックで初めに再生される音声波形の情報が取得されます。
	 * 指定したIDのキューが存在しない場合、falseが返ります。<br/>
	 */
	public bool GetWaveFormInfo(int cueId, out CriAtomEx.WaveformInfo info)
	{
		using (var mem = new CriStructMemory<CriAtomEx.WaveformInfo>()) {
			bool result = criAtomExAcb_GetWaveformInfoById(this.handle, cueId, mem.ptr);
			info = new CriAtomEx.WaveformInfo(mem.bytes, 0);
			return result;
		}
	}
	
	/**
	 * <summary>キューリミットが設定されているキューの発音数の取得（キュー名指定）</summary>
	 * <param name="name">キュー名</param>
	 * <returns>発音数（キューリミットが設定されていないキューを指定した場合-1が帰ります）</returns>
	 * \par 説明:
	 * キュー名を指定して、キューリミットが設定されているキューの発音数を取得します。<br/>
	 * 指定した名前のキューが存在しない場合や、キューリミットが設定されていないキューを指定した場合は-1が返ります。<br/>
	 */
	public int GetNumCuePlaying(string name)
	{
		return criAtomExAcb_GetNumCuePlayingCountByName(this.handle, name);
	}

	/**
	 * <summary>キューリミットが設定されているキューの発音数の取得（キューID指定）</summary>
	 * <param name="id">キューID</param>
	 * <returns>発音数（キューリミットが設定されていないキューを指定した場合-1が帰ります）</returns>
	 * \par 説明:
	 * キューIDを指定して、キューリミットが設定されているキューの発音数を取得します。<br/>
	 * 指定したIDのキューが存在しない場合や、キューリミットが設定されていないキューを指定した場合は-1が返ります。<br/>
	 */
	public int GetNumCuePlaying(int id)
	{
		return criAtomExAcb_GetNumCuePlayingCountById(this.handle, id);
	}

	/**
	 * <summary>ブロックインデックスの取得（キュー名指定）</summary>
	 * <param name="cueName">キュー名</param>
	 * <param name="blockName">ブロック名</param>
	 * <returns>ブロックインデックス</returns>
	 * \par 説明:
	 * キュー名とブロック名からブロックインデックスを取得します。<br/>
	 * 指定した名前のキューが存在しない場合やブロック名が存在しない場合は、
	 * 0xFFFFFFFF が返ります。
	 */
	public int GetBlockIndex(string cueName, string blockName)
	{
		return criAtomExAcb_GetBlockIndexByName(this.handle, cueName, blockName);
	}

	/**
	 * <summary>ブロックインデックスの取得（キューID指定）</summary>
	 * <param name="cueId">キューID</param>
	 * <param name="blockName">ブロック名</param>
	 * <returns>ブロックインデックス</returns>
	 * \par 説明:
	 * キューIDとブロック名からブロックインデックスを取得します。<br/>
	 * 指定したIDのキューが存在しない場合やブロック名が存在しない場合は、
	 * 0xFFFFFFFF が返ります。
	 */
	public int GetBlockIndex(int cueId, string blockName)
	{
		return criAtomExAcb_GetBlockIndexById(this.handle, cueId, blockName);
	}

	/**
	 * <summary>キューでコントロール可能なAISAC Controlの個数の取得（キュー名指定）</summary>
	 * <param name="cueName">キュー名</param>
	 * <returns>AISAC Controlの個数</returns>
	 * \par 説明:
	 * キュー名を指定して、キューでコントロール可能なAISAC Controlの個数を取得します。<br/>
	 * 指定した名前のキューが存在しない場合は、-1が返ります。<br/>
	 * \sa CriAtomExAcb::GetUsableAisacControl
	 */
	public int GetNumUsableAisacControls(string cueName)
	{
		return criAtomExAcb_GetNumUsableAisacControlsByName(this.handle, cueName);
	}

	/**
	 * <summary>キューでコントロール可能なAISAC Controlの個数の取得（キューID指定）</summary>
	 * <param name="cueId">キューID</param>
	 * <returns>AISAC Controlの個数</returns>
	 * \par 説明:
	 * キューIDを指定して、キューでコントロール可能なAISAC Controlの個数を取得します。<br/>
	 * 指定したIDのキューが存在しない場合は、-1が返ります。<br/>
	 * \sa CriAtomExAcb::GetUsableAisacControl
	 */
	public int GetNumUsableAisacControls(int cueId)
	{
		return criAtomExAcb_GetNumUsableAisacControlsById(this.handle, cueId);
	}
	
	/**
	 * <summary>キューでコントロール可能なAISAC Controlの取得（キュー名指定）</summary>
	 * <param name="cueName">キュー名</param>
	 * <param name="index">AISAC Controlインデックス</param>
	 * <param name="info">AISAC Control情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * \par 説明:
	 * キュー名とAISAC Controlインデックスを指定して、AISAC Control情報を取得します。<br/>
	 * 指定した名前のキューが存在しない場合は、falseが返ります。<br/>
	 * \sa CriAtomExAcb::GetNumUsableAisacControls
	 */
	public bool GetUsableAisacControl(string cueName, int index, out CriAtomEx.AisacControlInfo info)
	{
		using (var mem = new CriStructMemory<CriAtomEx.AisacControlInfo>()) {
			bool result = criAtomExAcb_GetUsableAisacControlByName(this.handle, cueName, (ushort)index, mem.ptr);
			info = new CriAtomEx.AisacControlInfo(mem.bytes, 0);
			return result;
		}
	}
	
	/**
	 * <summary>キューでコントロール可能なAISAC Controlの取得（キューID指定）</summary>
	 * <param name="cueId">キューID</param>
	 * <param name="index">AISAC Controlインデックス</param>
	 * <param name="info">AISAC Control情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * \par 説明:
	 * キューIDとAISAC Controlインデックスを指定して、AISAC Control情報を取得します。<br/>
	 * 指定したIDのキューが存在しない場合は、falseが返ります。<br/>
	 * \sa CriAtomExAcb::GetNumUsableAisacControls
	 */
	public bool GetUsableAisacControl(int cueId, int index, out CriAtomEx.AisacControlInfo info)
	{
		using (var mem = new CriStructMemory<CriAtomEx.AisacControlInfo>()) {
			bool result = criAtomExAcb_GetUsableAisacControlById(this.handle, cueId, (ushort)index, mem.ptr);
			info = new CriAtomEx.AisacControlInfo(mem.bytes, 0);
			return result;
		}
	}
	
	public CriAtomEx.AisacControlInfo[] GetUsableAisacControlList(string cueName)
	{
		int numControls = GetNumUsableAisacControls(cueName);
		var infoList = new CriAtomEx.AisacControlInfo[numControls];
		for (int i = 0; i < numControls; i++) {
			this.GetUsableAisacControl(cueName, i, out infoList[i]);
		}
		return infoList;
	}

	public CriAtomEx.AisacControlInfo[] GetUsableAisacControlList(int cueId)
	{
		int numControls = GetNumUsableAisacControls(cueId);
		var infoList = new CriAtomEx.AisacControlInfo[numControls];
		for (int i = 0; i < numControls; i++) {
			this.GetUsableAisacControl(cueId, i, out infoList[i]);
		}
		return infoList;
	}

	/**
	 * <summary>キュータイプステートのリセット（キュー名指定）</summary>
	 * <param name="cueName">キュー名</param>
	 * \par 説明:
	 * キュー名を指定して、キュータイプステートをリセットします。<br>
	 * \attention
	 * リセット対象は指定したキューのステートのみです。キューに含まれるサブシンセやキューリンク先の
	 * ステートはリセットされません。
	 * \par 備考:
	 * キュータイプステートは、ポリフォニックタイプキュー以外のキュー再生時の前回再生トラックを
	 * ステートとして管理する仕組みです。<br>
	 * 本関数は、ステート管理領域をリセットしACBロード直後の状態に戻します。
	 */
	public void ResetCueTypeState(string cueName)
	{
		criAtomExAcb_ResetCueTypeStateByName(this.handle, cueName);
	}
	
	/**
	 * <summary>キュータイプステートのリセット（キューID指定）</summary>
	 * <param name="cueName">キュー名</param>
	 * \par 説明:
	 * キュー名を指定して、キュータイプステートをリセットします。<br>
	 * \attention
	 * リセット対象は指定したキューのステートのみです。キューに含まれるサブシンセやキューリンク先の
	 * ステートはリセットされません。
	 * \par 備考:
	 * キュータイプステートは、ポリフォニックタイプキュー以外のキュー再生時の前回再生トラックを
	 * ステートとして管理する仕組みです。<br>
	 * 本関数は、ステート管理領域をリセットしACBロード直後の状態に戻します。
	 */
	public void ResetCueTypeState(int cueId)
	{
		criAtomExAcb_ResetCueTypeStateById(this.handle, cueId);
	}

    /**
	 * <summary>ストリーム用AWBファイルのアタッチ</summary>
	 * <param name="awb_binder">AWBファイルを含むバインダのハンドル</param>
	 * <param name="awb_path">AWBファイルのパス</param>
	 * <param name="awb_name">AWB名</param>
	 * \par 説明:
	 * ACBハンドルに対してストリーム用のAWBファイルをアタッチします。
	 * 第1引数の awb_binder 、および第2引数の awb_path には、ストリーム再生用
	 * のAWBファイルを指定します。<br>
	 * 第3引数の awb_name はAWBをアタッチするスロットを指定するために使用します。
	 * このため、AtomCraftが出力したAWB名（ファイル名から拡張子を取り除いた部分）を変更している場合
	 * はオリジナルのAWB名を指定してください。<br>
	 * AWBファイルのアタッチに失敗した場合、エラーコールバックが発生します。<br>
	 * 失敗の理由については、エラーコールバックのメッセージで確認可能です。<br>
	 * \par 備考:
	 * AWBファイルをアタッチするとライブラリ内部的にバインダ（ CriFsBinderHn ）とローダ（ CriFsLoaderHn ）
	 * を確保します。<br>
	 * 追加でAWBファイルをアタッチする場合、追加数分のバインダとローダが確保できる設定で
	 * Atomライブラリ（またはCRI File Systemライブラリ）を初期化する必要があります。<br>
	 */
	public void AttachAwbFile(CriFsBinder awb_binder, string awb_path, string awb_name)
	{
		IntPtr binderHandle = (awb_binder != null) ? awb_binder.nativeHandle : IntPtr.Zero;
		criAtomExAcb_AttachAwbFile(this.handle, binderHandle, awb_path, awb_name, IntPtr.Zero, 0);
	}
	
    /**
	 * <summary>ストリーム用AWBファイルのデタッチ</summary>
	 * <param name="awb_name">AWB名</param>
	 * \par 説明:
	 * ACBハンドルにアタッチされているストリーム用のAWBファイルをデタッチします。
	 * 第1引数の awb_name はAWBをアタッチ時に指定したものと同じAWB名を指定指定ください。<br>
	 */
	public void DetachAwbFile(string awb_name)
	{
		criAtomExAcb_DetachAwbFile(this.handle, awb_name);
	}

	#region Internal Members

	private CriAtomExAcb(IntPtr handle)
	{
		this.handle = handle;
	}

	~CriAtomExAcb()
	{
		this.Dispose();
	}

	private IntPtr handle = IntPtr.Zero;
	#endregion

	#region DLL Import

	[DllImport(CriWare.pluginName)]
	private static extern IntPtr criAtomExAcb_LoadAcbFile(IntPtr acb_binder, string acb_path, 
		IntPtr awb_binder, string awb_path, IntPtr work, int work_size);

	[DllImport(CriWare.pluginName)]
	private static extern IntPtr criAtomExAcb_LoadAcbData(byte[] acb_data, int acb_data_size,
		IntPtr awb_binder, string awb_path, IntPtr work, int work_size);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAcb_Release(IntPtr acb_hn);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criAtomExAcb_GetNumCues(IntPtr acb_hn);
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExAcb_ExistsId(IntPtr acb_hn, int id);
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExAcb_ExistsName(IntPtr acb_hn, string name);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criAtomExAcb_GetNumUsableAisacControlsById(IntPtr acb_hn, int id);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criAtomExAcb_GetNumUsableAisacControlsByName(IntPtr acb_hn, string name);
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExAcb_GetUsableAisacControlById(
		IntPtr acb_hn, int id, ushort index, IntPtr info);
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExAcb_GetUsableAisacControlByName(
		IntPtr acb_hn, string name, ushort index, IntPtr info);
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExAcb_GetWaveformInfoById(
		IntPtr acb_hn, int id, IntPtr waveform_info);
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExAcb_GetWaveformInfoByName(
		IntPtr acb_hn, string name, IntPtr waveform_info);
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExAcb_GetCueInfoByName(IntPtr acb_hn, string name, IntPtr info);
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExAcb_GetCueInfoById(IntPtr acb_hn, int id, IntPtr info);
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criAtomExAcb_GetCueInfoByIndex(IntPtr acb_hn, int index, IntPtr info);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criAtomExAcb_GetNumCuePlayingCountByName(IntPtr acb_hn, string name);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criAtomExAcb_GetNumCuePlayingCountById(IntPtr acb_hn, int id);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criAtomExAcb_GetBlockIndexById(IntPtr acb_hn, int id, string block_name);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criAtomExAcb_GetBlockIndexByName(IntPtr acb_hn, string name, string block_name);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAcb_ResetCueTypeStateByName(IntPtr acb_hn, string name);
	
	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAcb_ResetCueTypeStateById(IntPtr acb_hn, int id);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAcb_AttachAwbFile(IntPtr acb_hn, IntPtr awb_binder,
	                                string awb_path, string awb_name, IntPtr work, int work_size);

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomExAcb_DetachAwbFile(IntPtr acb_hn, string awb_name);

	#endregion
}

/**
 * @}
 */

/* --- end of file --- */
