/****************************************************************************
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
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
 * <summary>ACB、AWBデータ</summary>
 * <remarks>
 * <para header='説明'>キュー情報を管理するクラスです。<br/>
 * ACB、AWBファイルのロード、アンロードやキュー情報等を取得します。<br/></para>
 * </remarks>
 */
public class CriAtomExAcb : CriDisposable
{
	public IntPtr nativeHandle {get {return this.handle;} }

	public bool isAvailable {get {return this.handle != IntPtr.Zero;} }

	/**
	 * <summary>ACBファイルのロード</summary>
	 * <param name='binder'>バインダオブジェクト</param>
	 * <param name='acbPath'>ACBファイルのパス</param>
	 * <param name='awbPath'>AWBファイルのパス</param>
	 * <returns>CriAtomExAcbオブジェクト</returns>
	 * <remarks>
	 * <para header='説明'>ACBファイルをロードし、キュー再生に必要な情報を取り込みます。<br/>
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
	 * 本関数は戻り値として null を返します。<br/></para>
	 * <para header='注意'>本関数を実行する前に、ライブラリを初期化しておく必要があります。<br/>
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
	 * タイミングで行うようお願いいたします。<br/></para>
	 * </remarks>
	 * <seealso cref='criAtomExAcb_CalculateWorkSizeForLoadAcbFile'/>
	 * <seealso cref='CriAtomExAcbHn'/>
	 * <seealso cref='criAtomExPlayer_SetCueId'/>
	 */
	public static CriAtomExAcb LoadAcbFile(CriFsBinder binder, string acbPath, string awbPath)
	{
		/* バージョン番号が不正なライブラリではキューシートをロードしない */
		/* 備考）不正に差し替えられたsoファイルを使用している可能性あり。 */
		bool isCorrectVersion = CriWare.Common.CheckBinaryVersionCompatibility();
		if (isCorrectVersion == false) {
			return null;
		}

		IntPtr binderHandle = (binder != null) ? binder.nativeHandle : IntPtr.Zero;
		IntPtr handle = criAtomExAcb_LoadAcbFile(
			binderHandle, acbPath, binderHandle, awbPath, IntPtr.Zero, 0);
		if (handle == IntPtr.Zero) {
			return null;
		}
		return new CriAtomExAcb(handle, null);
	}

	/**
	 * <summary>ACBデータのロード</summary>
	 * <param name='acbData'>ACBデータのバイト配列</param>
	 * <param name='awbBinder'>AWB用バインダオブジェクト</param>
	 * <param name='awbPath'>AWBファイルのパス</param>
	 * <returns>CriAtomExAcbオブジェクト</returns>
	 * <remarks>
	 * <para header='説明'>メモリ上に配置されたACBデータをロードし、キュー再生に必要な情報を取り込みます。<br/>
	 * <br/>
	 * 第2引数の awbPath にはストリーム再生用のAWBファイルのパスを、それぞれ指定します。<br/>
	 * （オンメモリ再生のみのACBデータをロードする場合、
	 * awbPath にセットした値は無視されます。）<br/>
	 * <br/>
	 * AWBファイルをCPKファイルにパッキングしている場合、
	 * 第2引数（ binder ）にCPKファイルをバインドしたCriFsBinderオブジェクトを指定する必要があります。<br/>
	 * <br/>
	 * ACBデータをロードすると、ACBデータにアクセスするためのCriAtomExAcbオブジェクト
	 * （ ::CriAtomExAcb ）が返されます。<br/>
	 * AtomExプレーヤに対し、 ::CriAtomExPlayer::SetCue 関数でACBハンドル、
	 * および再生するキュー名を指定することで、
	 * ACBファイル内のキューを再生することが可能です。<br/>
	 * <br/>
	 * リードエラー等によりACBファイルのロードに失敗した場合、
	 * 本関数は戻り値として null を返します。<br/></para>
	 * <para header='注意'>本関数を実行する前に、ライブラリを初期化しておく必要があります。<br/>
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
	 * タイミングで行うようお願いいたします。<br/></para>
	 * </remarks>
	 * <seealso cref='criAtomExAcb_CalculateWorkSizeForLoadAcbFile'/>
	 * <seealso cref='CriAtomExAcbHn'/>
	 * <seealso cref='criAtomExPlayer_SetCueId'/>
	 */
	public static CriAtomExAcb LoadAcbData(byte[] acbData, CriFsBinder awbBinder, string awbPath)
	{
		/* バージョン番号が不正なライブラリではキューシートをロードしない */
		/* 備考）不正に差し替えられたsoファイルを使用している可能性あり。 */
		bool isCorrectVersion = CriWare.Common.CheckBinaryVersionCompatibility();
		if (isCorrectVersion == false) {
			return null;
		}

		IntPtr binderHandle = (awbBinder != null) ? awbBinder.nativeHandle : IntPtr.Zero;
		GCHandle gch = GCHandle.Alloc(acbData, GCHandleType.Pinned);
		IntPtr handle = criAtomExAcb_LoadAcbData(
			gch.AddrOfPinnedObject(), acbData.Length, binderHandle, awbPath, IntPtr.Zero, 0);
		if (handle == IntPtr.Zero) {
			return null;
		}
		return new CriAtomExAcb(handle, gch);
	}

	/**
	 * <summary>ACBファイルのアンロード</summary>
	 * <remarks>
	 * <para header='説明'>ロード済みのACBファイルをアンロードします。<br/></para>
	 * <para header='備考'>本関数を実行すると、
	 * アンロードするACBファイルを参照しているキューは全て停止されます。<br/>
	 * （本関数実行後に、ACBハンドルの作成に使用したワーク領域や、
	 * ACBデータが配置されていた領域が参照されることはありません。）<br/></para>
	 * <para header='注意'>本関数を実行すると、破棄しようとしているACBデータを参照している
	 * Atomプレーヤが存在しないか、ライブラリ内で検索処理が行われます。<br/>
	 * そのため、本関数実行中に他スレッドでAtomプレーヤの作成／破棄を行うと、
	 * アクセス違反やデッドロック等の重大な不具合を誘発する恐れがあります。</para>
	 * </remarks>
	 * <seealso cref='criAtomExAcb_LoadAcbData'/>
	 * <seealso cref='criAtomExAcb_LoadAcbFile'/>
	 */
	public override void Dispose()
	{
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		CriDisposableObjectManager.Unregister(this);

		if (this.isAvailable) {
			criAtomExAcb_Release(this.handle);
			this.handle = IntPtr.Zero;
		}

		if (disposing && this.dataHandle.IsAllocated) {
			this.dataHandle.Free();
		}
	}

	/**
	 * <summary>キューの存在確認（キュー名指定）</summary>
	 * <param name='cueName'>キュー名</param>
	 * <returns>キューが存在するかどうか（存在する：true、存在しない：false）</returns>
	 * <remarks>
	 * <para header='説明'>指定した名前のキューが存在するかどうかを取得します。<br/>
	 * 存在した場合にはtrueを返します。<br/></para>
	 * </remarks>
	 */
	public bool Exists(string cueName)
	{
		return criAtomExAcb_ExistsName(this.handle, cueName);
	}

	/**
	 * <summary>キューの存在確認（キューID指定）</summary>
	 * <param name='cueId'>キューID</param>
	 * <returns>キューが存在するかどうか（存在する：true、存在しない：false）</returns>
	 * <remarks>
	 * <para header='説明'>指定したIDのキューが存在するかどうかを取得します。<br/>
	 * 存在した場合にはtrueを返します。<br/></para>
	 * </remarks>
	 */
	public bool Exists(int cueId)
	{
		return criAtomExAcb_ExistsId(this.handle, cueId);
	}

	/**
	 * <summary>キュー情報の取得（キュー名指定）</summary>
	 * <param name='cueName'>キュー名</param>
	 * <param name='info'>キュー情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * <remarks>
	 * <para header='説明'>キュー名を指定して、キュー情報を取得します。<br/>
	 * 指定した名前のキューが存在しない場合、falseが返ります。<br/></para>
	 * </remarks>
	 * <seealso cref='criAtomExAcb_GetCueInfoById'/>
	 * <seealso cref='criAtomExAcb_GetCueInfoByIndex'/>
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
	 * <param name='cueId'>キューID</param>
	 * <param name='info'>キュー情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * <remarks>
	 * <para header='説明'>キューIDを指定して、キュー情報を取得します。<br/>
	 * 指定したIDのキューが存在しない場合、falseが返ります。<br/></para>
	 * </remarks>
	 * <seealso cref='criAtomExAcb_GetCueInfoById'/>
	 * <seealso cref='criAtomExAcb_GetCueInfoByIndex'/>
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
	 * <param name='index'>キューインデックス</param>
	 * <param name='info'>キュー情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * <remarks>
	 * <para header='説明'>キューインデックスを指定して、キュー情報を取得します。<br/>
	 * 指定したインデックスのキューが存在しない場合、falseが返ります。<br/></para>
	 * </remarks>
	 * <seealso cref='criAtomExAcb_GetCueInfoById'/>
	 * <seealso cref='criAtomExAcb_GetCueInfoByIndex'/>
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
	 * <param name='cueName'>キュー名</param>
	 * <param name='info'>音声波形情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * <remarks>
	 * <para header='説明'>キュー名を指定して、そのキューで再生される音声波形の情報を取得します。<br/>
	 * そのキューで再生される音声波形が複数ある場合、
	 * 初めのトラックで初めに再生される音声波形の情報が取得されます。
	 * 指定した名前のキューが存在しない場合、falseが返ります。<br/></para>
	 * </remarks>
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
	 * <param name='cueId'>キューID</param>
	 * <param name='info'>音声波形情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * <remarks>
	 * <para header='説明'>キューIDを指定して、そのキューで再生される音声波形の情報を取得します。<br/>
	 * そのキューで再生される音声波形が複数ある場合、
	 * 初めのトラックで初めに再生される音声波形の情報が取得されます。
	 * 指定したIDのキューが存在しない場合、falseが返ります。<br/></para>
	 * </remarks>
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
	 * <param name='name'>キュー名</param>
	 * <returns>発音数（キューリミットが設定されていないキューを指定した場合-1が帰ります）</returns>
	 * <remarks>
	 * <para header='説明'>キュー名を指定して、キューリミットが設定されているキューの発音数を取得します。<br/>
	 * 指定した名前のキューが存在しない場合や、キューリミットが設定されていないキューを指定した場合は-1が返ります。<br/></para>
	 * </remarks>
	 */
	public int GetNumCuePlaying(string name)
	{
		return criAtomExAcb_GetNumCuePlayingCountByName(this.handle, name);
	}

	/**
	 * <summary>キューリミットが設定されているキューの発音数の取得（キューID指定）</summary>
	 * <param name='id'>キューID</param>
	 * <returns>発音数（キューリミットが設定されていないキューを指定した場合-1が帰ります）</returns>
	 * <remarks>
	 * <para header='説明'>キューIDを指定して、キューリミットが設定されているキューの発音数を取得します。<br/>
	 * 指定したIDのキューが存在しない場合や、キューリミットが設定されていないキューを指定した場合は-1が返ります。<br/></para>
	 * </remarks>
	 */
	public int GetNumCuePlaying(int id)
	{
		return criAtomExAcb_GetNumCuePlayingCountById(this.handle, id);
	}

	/**
	 * <summary>ブロックインデックスの取得（キュー名指定）</summary>
	 * <param name='cueName'>キュー名</param>
	 * <param name='blockName'>ブロック名</param>
	 * <returns>ブロックインデックス</returns>
	 * <remarks>
	 * <para header='説明'>キュー名とブロック名からブロックインデックスを取得します。<br/>
	 * 指定した名前のキューが存在しない場合やブロック名が存在しない場合は、
	 * 0xFFFFFFFF が返ります。</para>
	 * </remarks>
	 */
	public int GetBlockIndex(string cueName, string blockName)
	{
		return criAtomExAcb_GetBlockIndexByName(this.handle, cueName, blockName);
	}

	/**
	 * <summary>ブロックインデックスの取得（キューID指定）</summary>
	 * <param name='cueId'>キューID</param>
	 * <param name='blockName'>ブロック名</param>
	 * <returns>ブロックインデックス</returns>
	 * <remarks>
	 * <para header='説明'>キューIDとブロック名からブロックインデックスを取得します。<br/>
	 * 指定したIDのキューが存在しない場合やブロック名が存在しない場合は、
	 * 0xFFFFFFFF が返ります。</para>
	 * </remarks>
	 */
	public int GetBlockIndex(int cueId, string blockName)
	{
		return criAtomExAcb_GetBlockIndexById(this.handle, cueId, blockName);
	}

	/**
	 * <summary>キューでコントロール可能なAISAC Controlの個数の取得（キュー名指定）</summary>
	 * <param name='cueName'>キュー名</param>
	 * <returns>AISAC Controlの個数</returns>
	 * <remarks>
	 * <para header='説明'>キュー名を指定して、キューでコントロール可能なAISAC Controlの個数を取得します。<br/>
	 * 指定した名前のキューが存在しない場合は、-1が返ります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcb::GetUsableAisacControl'/>
	 */
	public int GetNumUsableAisacControls(string cueName)
	{
		return criAtomExAcb_GetNumUsableAisacControlsByName(this.handle, cueName);
	}

	/**
	 * <summary>キューでコントロール可能なAISAC Controlの個数の取得（キューID指定）</summary>
	 * <param name='cueId'>キューID</param>
	 * <returns>AISAC Controlの個数</returns>
	 * <remarks>
	 * <para header='説明'>キューIDを指定して、キューでコントロール可能なAISAC Controlの個数を取得します。<br/>
	 * 指定したIDのキューが存在しない場合は、-1が返ります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcb::GetUsableAisacControl'/>
	 */
	public int GetNumUsableAisacControls(int cueId)
	{
		return criAtomExAcb_GetNumUsableAisacControlsById(this.handle, cueId);
	}

	/**
	 * <summary>キューでコントロール可能なAISAC Controlの取得（キュー名指定）</summary>
	 * <param name='cueName'>キュー名</param>
	 * <param name='index'>AISAC Controlインデックス</param>
	 * <param name='info'>AISAC Control情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * <remarks>
	 * <para header='説明'>キュー名とAISAC Controlインデックスを指定して、AISAC Control情報を取得します。<br/>
	 * 指定した名前のキューが存在しない場合は、falseが返ります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcb::GetNumUsableAisacControls'/>
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
	 * <param name='cueId'>キューID</param>
	 * <param name='index'>AISAC Controlインデックス</param>
	 * <param name='info'>AISAC Control情報</param>
	 * <returns>取得に成功したかどうか（成功：true、失敗：false）</returns>
	 * <remarks>
	 * <para header='説明'>キューIDとAISAC Controlインデックスを指定して、AISAC Control情報を取得します。<br/>
	 * 指定したIDのキューが存在しない場合は、falseが返ります。<br/></para>
	 * </remarks>
	 * <seealso cref='CriAtomExAcb::GetNumUsableAisacControls'/>
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
	 * <param name='cueName'>キュー名</param>
	 * <remarks>
	 * <para header='説明'>キュー名を指定して、キュータイプステートをリセットします。<br/></para>
	 * <para header='注意'>リセット対象は指定したキューのステートのみです。キューに含まれるサブシンセやキューリンク先の
	 * ステートはリセットされません。</para>
	 * <para header='備考'>キュータイプステートは、ポリフォニックタイプキュー以外のキュー再生時の前回再生トラックを
	 * ステートとして管理する仕組みです。<br/>
	 * 本関数は、ステート管理領域をリセットしACBロード直後の状態に戻します。</para>
	 * </remarks>
	 */
	public void ResetCueTypeState(string cueName)
	{
		criAtomExAcb_ResetCueTypeStateByName(this.handle, cueName);
	}

	/**
	 * <summary>キュータイプステートのリセット（キューID指定）</summary>
	 * <param name='cueId'>キュー名</param>
	 * <remarks>
	 * <para header='説明'>キュー名を指定して、キュータイプステートをリセットします。<br/></para>
	 * <para header='注意'>リセット対象は指定したキューのステートのみです。キューに含まれるサブシンセやキューリンク先の
	 * ステートはリセットされません。</para>
	 * <para header='備考'>キュータイプステートは、ポリフォニックタイプキュー以外のキュー再生時の前回再生トラックを
	 * ステートとして管理する仕組みです。<br/>
	 * 本関数は、ステート管理領域をリセットしACBロード直後の状態に戻します。</para>
	 * </remarks>
	 */
	public void ResetCueTypeState(int cueId)
	{
		criAtomExAcb_ResetCueTypeStateById(this.handle, cueId);
	}

	/**
	 * <summary>ストリーム用AWBファイルのアタッチ</summary>
	 * <param name='awb_binder'>AWBファイルを含むバインダのハンドル</param>
	 * <param name='awb_path'>AWBファイルのパス</param>
	 * <param name='awb_name'>AWB名</param>
	 * <remarks>
	 * <para header='説明'>ACBハンドルに対してストリーム用のAWBファイルをアタッチします。
	 * 第1引数の awb_binder 、および第2引数の awb_path には、ストリーム再生用
	 * のAWBファイルを指定します。<br/>
	 * 第3引数の awb_name はAWBをアタッチするスロットを指定するために使用します。
	 * このため、AtomCraftが出力したAWB名（ファイル名から拡張子を取り除いた部分）を変更している場合
	 * はオリジナルのAWB名を指定してください。<br/>
	 * AWBファイルのアタッチに失敗した場合、エラーコールバックが発生します。<br/>
	 * 失敗の理由については、エラーコールバックのメッセージで確認可能です。<br/></para>
	 * <para header='備考'>AWBファイルをアタッチするとライブラリ内部的にバインダ（ CriFsBinderHn ）とローダ（ CriFsLoaderHn ）
	 * を確保します。<br/>
	 * 追加でAWBファイルをアタッチする場合、追加数分のバインダとローダが確保できる設定で
	 * Atomライブラリ（またはCRI File Systemライブラリ）を初期化する必要があります。<br/></para>
	 * </remarks>
	 */
	public void AttachAwbFile(CriFsBinder awb_binder, string awb_path, string awb_name)
	{
		if (this.isAvailable) {
			IntPtr binderHandle = (awb_binder != null) ? awb_binder.nativeHandle : IntPtr.Zero;
			criAtomExAcb_AttachAwbFile(this.handle, binderHandle, awb_path, awb_name, IntPtr.Zero, 0);
		}
	}

	/**
	 * <summary>ストリーム用AWBファイルのデタッチ</summary>
	 * <param name='awb_name'>AWB名</param>
	 * <remarks>
	 * <para header='説明'>ACBハンドルにアタッチされているストリーム用のAWBファイルをデタッチします。
	 * 第1引数の awb_name はAWBをアタッチ時に指定したものと同じAWB名を指定指定ください。<br/></para>
	 * </remarks>
	 */
	public void DetachAwbFile(string awb_name)
	{
		if (this.isAvailable) {
			criAtomExAcb_DetachAwbFile(this.handle, awb_name);
		}
	}

	/**
	 * <summary>ACBハンドルの即時解放状態の取得</summary>
	 * <returns>ACBの状態（true = 即時解放可能、false = 再生中のプレーヤあり）</returns>
	 * <remarks>
	 * <para header='説明'>ACBハンドルを即座に解放可能かどうかをチェックします。<br/>
	 * 本関数が false を返すタイミングで criAtomExAcb.Dispose 関数を実行すると、
	 * ACBハンドルを参照しているプレーヤに対する停止処理が行われます。<br/>
	 * （ストリーム再生用のACBハンドルの場合、ファイル読み込み完了を待つため、
	 * criAtomExAcb.Dispose 関数内で長時間処理がブロックされる可能性があります。）<br/></para>
	 * </remarks>
	 */
	public bool IsReadyToRelease()
	{
		if (this.isAvailable) {
			bool result = criAtomExAcb_IsReadyToRelease(this.handle);
			return result;
		} else {
			return false;
		}
	}



	#region Internal Members

	internal CriAtomExAcb(IntPtr handle, GCHandle? dataHandle)
	{
		this.handle = handle;
		if (dataHandle.HasValue) {
			this.dataHandle = dataHandle.Value;
		}
		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
	}

	~CriAtomExAcb()
	{
		this.Dispose(false);
	}

	private IntPtr handle = IntPtr.Zero;
	private GCHandle dataHandle;
	#endregion

	#region DLL Import
	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomExAcb_LoadAcbFile(IntPtr acb_binder, string acb_path,
		IntPtr awb_binder, string awb_path, IntPtr work, int work_size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomExAcb_LoadAcbData(IntPtr acb_data, int acb_data_size,
		IntPtr awb_binder, string awb_path, IntPtr work, int work_size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAcb_Release(IntPtr acb_hn);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomExAcb_GetNumCues(IntPtr acb_hn);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcb_ExistsId(IntPtr acb_hn, int id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcb_ExistsName(IntPtr acb_hn, string name);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomExAcb_GetNumUsableAisacControlsById(IntPtr acb_hn, int id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomExAcb_GetNumUsableAisacControlsByName(IntPtr acb_hn, string name);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcb_GetUsableAisacControlById(
		IntPtr acb_hn, int id, ushort index, IntPtr info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcb_GetUsableAisacControlByName(
		IntPtr acb_hn, string name, ushort index, IntPtr info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcb_GetWaveformInfoById(
		IntPtr acb_hn, int id, IntPtr waveform_info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcb_GetWaveformInfoByName(
		IntPtr acb_hn, string name, IntPtr waveform_info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcb_GetCueInfoByName(IntPtr acb_hn, string name, IntPtr info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcb_GetCueInfoById(IntPtr acb_hn, int id, IntPtr info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcb_GetCueInfoByIndex(IntPtr acb_hn, int index, IntPtr info);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomExAcb_GetNumCuePlayingCountByName(IntPtr acb_hn, string name);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomExAcb_GetNumCuePlayingCountById(IntPtr acb_hn, int id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomExAcb_GetBlockIndexById(IntPtr acb_hn, int id, string block_name);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern int criAtomExAcb_GetBlockIndexByName(IntPtr acb_hn, string name, string block_name);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAcb_ResetCueTypeStateByName(IntPtr acb_hn, string name);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAcb_ResetCueTypeStateById(IntPtr acb_hn, int id);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAcb_AttachAwbFile(IntPtr acb_hn, IntPtr awb_binder,
									string awb_path, string awb_name, IntPtr work, int work_size);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAcb_DetachAwbFile(IntPtr acb_hn, string awb_name);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcb_IsReadyToRelease(IntPtr acb_hn);

	#else
	private static IntPtr criAtomExAcb_LoadAcbFile(IntPtr acb_binder, string acb_path,
		IntPtr awb_binder, string awb_path, IntPtr work, int work_size) { return new IntPtr(1); }
	private static IntPtr criAtomExAcb_LoadAcbData(IntPtr acb_data, int acb_data_size,
		IntPtr awb_binder, string awb_path, IntPtr work, int work_size) { return new IntPtr(1); }
	private static void criAtomExAcb_Release(IntPtr acb_hn) { }
	private static int criAtomExAcb_GetNumCues(IntPtr acb_hn) { return 0; }
	private static bool criAtomExAcb_ExistsId(IntPtr acb_hn, int id) { return false; }
	private static bool criAtomExAcb_ExistsName(IntPtr acb_hn, string name) { return false; }
	private static int criAtomExAcb_GetNumUsableAisacControlsById(IntPtr acb_hn, int id) { return 0; }
	private static int criAtomExAcb_GetNumUsableAisacControlsByName(IntPtr acb_hn, string name) { return 0; }
	private static bool criAtomExAcb_GetUsableAisacControlById(
		IntPtr acb_hn, int id, ushort index, IntPtr info) { return false; }
	private static bool criAtomExAcb_GetUsableAisacControlByName(
		IntPtr acb_hn, string name, ushort index, IntPtr info) { return false; }
	private static bool criAtomExAcb_GetWaveformInfoById(
		IntPtr acb_hn, int id, IntPtr waveform_info) { return false; }
	private static bool criAtomExAcb_GetWaveformInfoByName(
		IntPtr acb_hn, string name, IntPtr waveform_info) { return false; }
	private static bool criAtomExAcb_GetCueInfoByName(IntPtr acb_hn, string name, IntPtr info) { return false; }
	private static bool criAtomExAcb_GetCueInfoById(IntPtr acb_hn, int id, IntPtr info) { return false; }
	private static bool criAtomExAcb_GetCueInfoByIndex(IntPtr acb_hn, int index, IntPtr info) { return false; }
	private static int criAtomExAcb_GetNumCuePlayingCountByName(IntPtr acb_hn, string name) { return 0; }
	private static int criAtomExAcb_GetNumCuePlayingCountById(IntPtr acb_hn, int id) { return 0; }
	private static int criAtomExAcb_GetBlockIndexById(IntPtr acb_hn, int id, string block_name) { return -1; }
	private static int criAtomExAcb_GetBlockIndexByName(IntPtr acb_hn, string name, string block_name) { return -1; }
	private static void criAtomExAcb_ResetCueTypeStateByName(IntPtr acb_hn, string name) { }
	private static void criAtomExAcb_ResetCueTypeStateById(IntPtr acb_hn, int id) { }
	private static void criAtomExAcb_AttachAwbFile(IntPtr acb_hn, IntPtr awb_binder,
									string awb_path, string awb_name, IntPtr work, int work_size) { }
	private static void criAtomExAcb_DetachAwbFile(IntPtr acb_hn, string awb_name) { }
	private static bool criAtomExAcb_IsReadyToRelease(IntPtr acb_hn) { return false; }
	#endif
	#endregion
}

/**
 * <summary>ACB、AWBデータの非同期ローダ</summary>
 * <remarks>
 * <para header='説明'>ACB、AWBファイルを非同期でロードするためのクラスです。<br/></para>
 * </remarks>
 */
public class CriAtomExAcbLoader : CriDisposable
{
	/**
	 * <summary>ステータス</summary>
	 * <remarks>
	 * <para header='説明'>非同期ローダの状態です。<br/></para>
	 * </remarks>
	 */
	public enum Status
	{
		Stop,
		Loading,
		Complete,
		Error
	}

	/**
	 * <summary>ACBファイルの非同期ロード</summary>
	 * <param name='binder'>バインダオブジェクト</param>
	 * <param name='acbPath'>ACBファイルのパス</param>
	 * <param name='awbPath'>AWBファイルのパス</param>
	 * <param name='loadAwbOnMemory'>AWBファイルをメモリ上にロードするか(オプション)</param>
	 * <returns>CriAtomExAcbLoaderオブジェクト</returns>
	 * <remarks>
	 * <para header='説明'>ACBファイルの非同期ロードを開始します。<br/>
	 * 戻り値に対して ::CriAtomExAcbLoader::GetStatus を呼び出してロード状態を確認し、
	 * 状態が Complete に遷移したら、 ::CriAtomExAcbLoader::MoveAcb により ::CriAtomExAcb オブジェクトが取得可能です。<br/></para>
	 * </remarks>
	 */
	public static CriAtomExAcbLoader LoadAcbFileAsync(CriFsBinder binder, string acbPath, string awbPath, bool loadAwbOnMemory = false)
	{
		/* バージョン番号が不正なライブラリではキューシートをロードしない */
		/* 備考）不正に差し替えられたsoファイルを使用している可能性あり。 */
		bool isCorrectVersion = CriWare.Common.CheckBinaryVersionCompatibility();
		if (isCorrectVersion == false) {
			return null;
		}

		IntPtr binderHandle = (binder != null) ? binder.nativeHandle : IntPtr.Zero;
		LoaderConfig config = new LoaderConfig();
		config.shouldLoadAwbOnMemory = loadAwbOnMemory;
		IntPtr handle = criAtomExAcbLoader_Create(ref config);
		if (handle == IntPtr.Zero) { return null; }
		bool result = criAtomExAcbLoader_LoadAcbFileAsync(handle, binderHandle, acbPath, binderHandle, awbPath);
		if (result == false) { return null; }
		return new CriAtomExAcbLoader(handle, null);
	}

	/**
	 * <summary>ACBデータの非同期ロード</summary>
	 * <param name='acbData'>ACBデータのバイト配列</param>
	 * <param name='awbBinder'>AWB用バインダオブジェクト</param>
	 * <param name='awbPath'>AWBファイルのパス</param>
	 * <param name='loadAwbOnMemory'>AWBファイルをメモリ上にロードするか(オプション)</param>
	 * <returns>CriAtomExAcbLoaderオブジェクト</returns>
	 * <remarks>
	 * <para header='説明'>ACBデータの非同期ロードを開始します。<br/>
	 * 戻り値に対して ::CriAtomExAcbLoader::GetStatus を呼び出してロード状態を確認し、
	 * 状態が Complete に遷移したら、 ::CriAtomExAcbLoader::MoveAcb により ::CriAtomExAcb が取得可能です。<br/></para>
	 * </remarks>
	 */
	public static CriAtomExAcbLoader LoadAcbDataAsync(byte[] acbData, CriFsBinder awbBinder, string awbPath, bool loadAwbOnMemory = false)
	{
		/* バージョン番号が不正なライブラリではキューシートをロードしない */
		/* 備考）不正に差し替えられたsoファイルを使用している可能性あり。 */
		bool isCorrectVersion = CriWare.Common.CheckBinaryVersionCompatibility();
		if (isCorrectVersion == false) {
			return null;
		}

		IntPtr binderHandle = (awbBinder != null) ? awbBinder.nativeHandle : IntPtr.Zero;
		LoaderConfig config = new LoaderConfig();
		config.shouldLoadAwbOnMemory = loadAwbOnMemory;
		IntPtr handle = criAtomExAcbLoader_Create(ref config);
		if (handle == IntPtr.Zero) { return null; }
		GCHandle dataHandle = GCHandle.Alloc(acbData, GCHandleType.Pinned);
		bool result = criAtomExAcbLoader_LoadAcbDataAsync(handle, dataHandle.AddrOfPinnedObject(), acbData.Length, binderHandle, awbPath);
		if (result == false) { return null; }
		return new CriAtomExAcbLoader(handle, dataHandle);
	}

	/**
	 * <summary>ステータスの取得</summary>
	 * <returns>非同期ローダのロード状態</returns>
	 * <remarks>
	 * <para header='説明'>非同期ローダの状態を取得します。<br/>
	 * 本関数の戻り値が Complete に遷移したら、 ::CriAtomExAcbLoader::MoveAcb により ::CriAtomExAcb の取得が可能です。<br/></para>
	 * </remarks>
	 */
	public Status GetStatus()
	{
		return criAtomExAcbLoader_GetStatus(this.handle);
	}

	/**
	 * <summary>ACBデータの取得</summary>
	 * <returns>CriAtomExAcbオブジェクト</returns>
	 * <remarks>
	 * <para header='説明'>非同期にロードしたACBデータを取得します。<br/>
	 * 本関数は、 ::CriAtomExAcbLoader::GetStatus の戻り値が Complete に遷移してから呼び出してください。<br/></para>
	 * </remarks>
	 */
	public CriAtomExAcb MoveAcb()
	{
		IntPtr movedAcbHandle = criAtomExAcbLoader_MoveAcbHandle(this.handle);
		if (movedAcbHandle != IntPtr.Zero) {
			CriAtomExAcb movedAcb = new CriAtomExAcb(movedAcbHandle, this.gch);
			this.gch = null;
			return movedAcb;
		}
		return null;
	}

	/**
	 * <summary>非同期ローダの破棄</summary>
	 * <remarks>
	 * <para header='説明'>非同期ローダを破棄します。<br/></para>
	 * </remarks>
	 */
	public override void Dispose()
	{
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	private void Dispose(bool disposing)
	{
		CriDisposableObjectManager.Unregister(this);

		if (this.handle != IntPtr.Zero) {
			criAtomExAcbLoader_Destroy(this.handle);
			this.handle = IntPtr.Zero;
		}

		if (disposing && this.gch.HasValue && this.gch.Value.IsAllocated) {
			this.gch.Value.Free();
		}
	}

	#region Internal Members
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	private struct LoaderConfig
	{
		public bool shouldLoadAwbOnMemory;
	}

	private IntPtr handle = IntPtr.Zero;
	private GCHandle? gch;

	private CriAtomExAcbLoader(IntPtr handle, GCHandle? dataHandle)
	{
		this.handle = handle;
		if (dataHandle.HasValue) {
			this.gch = dataHandle.Value;
		}
		CriDisposableObjectManager.Register(this, CriDisposableObjectManager.ModuleType.Atom);
	}

	~CriAtomExAcbLoader()
	{
		this.Dispose(false);
	}
	#endregion

	#region DLL Import
	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomExAcbLoader_Create([In] ref LoaderConfig config);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern void criAtomExAcbLoader_Destroy(IntPtr acb_loader);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcbLoader_LoadAcbFileAsync(IntPtr acb_loader, IntPtr acb_binder, string acb_path, IntPtr awb_binder, string awb_path);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcbLoader_LoadAcbDataAsync(IntPtr acb_loader, IntPtr acb_data, int acb_size, IntPtr awb_binder, string awb_path);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern Status criAtomExAcbLoader_GetStatus(IntPtr acb_loader);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern bool criAtomExAcbLoader_WaitForCompletion(IntPtr acb_loader);

	[DllImport(CriWare.Common.pluginName, CallingConvention = CriWare.Common.pluginCallingConvention)]
	private static extern IntPtr criAtomExAcbLoader_MoveAcbHandle(IntPtr acb_loader);
	#else
	private static IntPtr criAtomExAcbLoader_Create([In] ref LoaderConfig config) { return new IntPtr(1); }
	private static void criAtomExAcbLoader_Destroy(IntPtr acb_loader) { }
	private static bool criAtomExAcbLoader_LoadAcbFileAsync(IntPtr acb_loader, IntPtr acb_binder, string acb_path, IntPtr awb_binder, string awb_path)
	{ return false; }
	private static bool criAtomExAcbLoader_LoadAcbDataAsync(IntPtr acb_loader, IntPtr acb_data, int acb_size, IntPtr awb_binder, string awb_path)
	{ return false; }
	private static Status criAtomExAcbLoader_GetStatus(IntPtr acb_loader) { return Status.Complete; }
	private static bool criAtomExAcbLoader_WaitForCompletion(IntPtr acb_loader) { return true; }
	private static IntPtr criAtomExAcbLoader_MoveAcbHandle(IntPtr acb_loader) { return IntPtr.Zero; }
	#endif
	#endregion
}

} //namespace CriWare
/**
 * @}
 */

/* --- end of file --- */
