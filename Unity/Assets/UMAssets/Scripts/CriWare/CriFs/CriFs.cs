/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 * Library  : CRI File System
 * Module   : CRI File System for Unity
 * File     : CriFs.cs
 *
 ****************************************************************************/
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;

/*==========================================================================
 *      CRI File System Native Wrapper
 *=========================================================================*/
/**
 * \addtogroup CRIFS_NATIVE_WRAPPER
 * @{
 */

/**
 * <summary>ファイルをメモリにロードするためのモジュールです。</summary>
 * \par 説明:
 * ファイルをメモリにロードするためのモジュールです。<br/>
 * ::CriFsBinder を併用することで、CPKファイル内のコンテンツを読み込むことも可能です。<br/>
 * \sa CriFsBinder
 */
public class CriFsLoader : IDisposable
{
	/**
	 * <summary>ローダの状態を示す値です。</summary>
	 * \sa CriFsLoader::GetStatus
	 */
	public enum Status
	{
		Stop,		/**< 停止中			*/
		Loading,	/**< ロード中		*/
		Complete,	/**< ロード完了		*/
		Error		/**< エラーが発生	*/
	}
	
	public CriFsLoader()
	{
		/* 初期化処理 */
		CriFsPlugin.InitializeLibrary();
		
		/* ハンドルの作成 */
		this.handle = IntPtr.Zero;
		criFsLoader_Create(out this.handle);
		if (this.handle == IntPtr.Zero) {
			CriFsPlugin.FinalizeLibrary();
			throw new Exception("criFsLoader_Create() failed.");
		}
	}
	
	/**
	 * <summary>ローダを破棄します。</summary>
	 * \attention
	 * ロード処理中にローダを破棄した場合、
	 * 本関数内で処理が長時間ブロックされる可能性があります。<br/>
	 */
	public void Dispose()
	{
		/* ハンドルの有無をチェック */
		if (this.handle == IntPtr.Zero) {
			return;
		}
		
		/* ハンドルの破棄 */
		criFsLoader_Destroy(this.handle);
		this.handle = IntPtr.Zero;
		if (this.gch.IsAllocated) {
			this.gch.Free();
		}
		
		/* 終了処理 */
		CriFsPlugin.FinalizeLibrary();
		GC.SuppressFinalize(this);
	}
	
	/**
	 * <summary>データのロードを開始します。</summary>
	 * <param name="binder">バインダ</param>
	 * <param name="path">ファイルパス名</param>
	 * <param name="fileOffset">ファイルの先頭からのオフセット位置（単位はバイト）</param>
	 * <param name="loadSize">ロード要求サイズ（単位はバイト）</param>
	 * <param name="buffer">ロード先バッファ</param>
	 * \par 説明:
	 * 指定されたバインダとファイル名で、データの読み込みを開始します。<br/>
	 * ファイル内のfileOffsetバイト目から、loadSizeバイト分読み込みます。<br/>
	 * 本関数は即時復帰関数です。<br/>
	 * ロードの完了状態を取得するには ::CriFsLoader::GetStatus 関数を使用してください。<br/>
	 * \sa CriFsLoader::GetStatus
	 */
	public void Load(CriFsBinder binder, string path, long fileOffset, long loadSize, byte[] buffer)
	{
		this.gch = GCHandle.Alloc(buffer, GCHandleType.Pinned);

	#if !UNITY_EDITOR && UNITY_PSP2
		criFsLoader_LoadWorkaroundForVITA(this.handle,
		                  (binder != null) ? binder.nativeHandle : IntPtr.Zero, fileOffset, 
		                  path, loadSize, this.gch.AddrOfPinnedObject(), buffer.Length);
	#else
		criFsLoader_Load(this.handle,
		                 (binder != null) ? binder.nativeHandle : IntPtr.Zero, path,
		                 fileOffset, loadSize, this.gch.AddrOfPinnedObject(), buffer.Length);
	#endif
	}
	
	/**
	 * <summary>データのロードを開始します。</summary>
	 * <param name="binder">バインダ</param>
	 * <param name="id">ファイルID</param>
	 * <param name="fileOffset">ファイルの先頭からのオフセット位置（単位はバイト）</param>
	 * <param name="loadSize">ロード要求サイズ（単位はバイト）</param>
	 * <param name="buffer">ロード先バッファ</param>
	 * \par 説明:
	 * 指定されたバインダとファイルIDで、データの読み込みを開始します。<br/>
	 * ファイル内のfileOffsetバイト目から、loadSizeバイト分読み込みます。<br/>
	 * 本関数は即時復帰関数です。<br/>
	 * ロードの完了状態を取得するには ::CriFsLoader::GetStatus 関数を使用してください。<br/>
	 * \sa CriFsLoader::GetStatus
	 */
	public void LoadById(CriFsBinder binder, int id, long fileOffset, long loadSize, byte[] buffer)
	{
		this.gch = GCHandle.Alloc(buffer, GCHandleType.Pinned);
		criFsLoader_LoadById(this.handle,
			(binder != null) ? binder.nativeHandle : IntPtr.Zero, id,
			fileOffset, loadSize, this.gch.AddrOfPinnedObject(), buffer.Length);
	}
	
	/**
	 * <summary>ロード処理を停止します。</summary>
	 * \par 説明：
	 * ロード処理を停止します。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * 停止状態を取得するには ::CriFsLoader::GetStatus 関数を使用してください。<br/>
	 * \attention
	 * 本関数を実行しても、ローダのステータスが ::CriFsLoader::Status::Stop に変わるまでは、
	 * バッファへのデータ転送が続いている可能性があります。<br/>
	 * \sa
	 * CriFsLoader::GetStatus
	 */
	public void Stop()
	{
		criFsLoader_Stop(this.handle);
	}
	
	/**
	 * <summary>ローダのステータスを取得します。</summary>
	 * <returns>ステータス</returns>
	 * \par 説明：
	 * ローダのステータスを取得します。<br/>
	 * \sa CriFsLoader::Status
	 */
	public Status GetStatus()
	{
		Status status = Status.Stop;
		criFsLoader_GetStatus(this.handle, out status);
		if ((status != Status.Loading) && this.gch.IsAllocated) {
			this.gch.Free();
		}
		return status;
	}

	/**
	 * <summary>単位読み込みサイズの設定</summary>
	 * <param name="unit_size">単位読み込みサイズ</param>
	 * \par 説明：
	 * 単位読み込みサイズを設定します。
	 * CriFsLoaderは、大きなサイズのリード要求を処理する際、それを複数の小さな単位のリード処理に分割して連続実行します。<br/>
	 * この関数を使用することで単位リード処理サイズを変更することが可能です。<br/>
	 * リード要求のキャンセルや、高プライオリティのリード処理の割り込み等は、単位リードサイズ境界でのみ処理されます。<br/>
	 * そのため、ユニットサイズを小さく設定すると、I/O処理のレスポンスが向上します。<br/>
	 * 逆に、ユニットサイズを大きく設定すると、ファイル単位の読み込み速度が向上します。<br/>
	 * \sa CriFsLoader::Status
	 */
	public void SetReadUnitSize(int unit_size)
	{
		criFsLoader_SetReadUnitSize(this.handle, unit_size);
	}
	
	#region Internal Member
	IntPtr handle;
	private GCHandle gch;
	
	~CriFsLoader()
	{
		this.Dispose();
	}
	#endregion
	
	#region DLLImport
	[DllImport(CriWare.pluginName)]
	private static extern int criFsLoader_Create(out IntPtr loader);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsLoader_Destroy(IntPtr loader);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsLoader_Load(IntPtr loader, IntPtr binder, string path, long offset, long load_size, IntPtr buffer, long buffer_size);
    
#if !UNITY_EDITOR && UNITY_PSP2
	[DllImport(CriWare.pluginName)]
	private static extern int criFsLoader_LoadWorkaroundForVITA(IntPtr loader, IntPtr binder, long offset, string path, long load_size, IntPtr buffer, long buffer_size);
#endif

	[DllImport(CriWare.pluginName)]
	private static extern int criFsLoader_LoadById(IntPtr loader, IntPtr binder, int id, long offset, long load_size, IntPtr buffer, long buffer_size);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsLoader_Stop(IntPtr loader);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criFsLoader_GetStatus(IntPtr loader, out Status status);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criFsLoader_SetReadUnitSize(IntPtr loader, long unit_size);
	#endregion
}

/**
 * <summary>ファイルのインストールを行うためのモジュールです。</summary>
 * \par 説明:
 * ファイルのインストールを行うためのモジュールです。<br/>
 * サーバ上のコンテンツをローカルストレージにインストールするために使用します。<br/>
 * \attention
 * ネットワーク接続がタイムアウトした場合、CriFsInstallerは無限リトライを行います。
 * ただし以下の場合はエラーとなり、リトライは行いません。
 * - インストール元のファイルの存在を確認中、ネットワーク接続がタイムアウトした
 * - インストール元のファイルが存在しなかった
 * 本クラスでは、無限リトライを中断するタイミングを判定しません。<br>
 * \par 備考：
 * どのタイミングで無限リトライを中断するかについては、アプリケーション側の実装に任されます。<br>
 * 例えば、以下の手順による中断処理が考えられます。
 * -# ::CriFsInstaller::GetProgress 関数でインストール進捗状況の値を取得する。
 * -# 一定時間後、再びインストール進捗状況の値を取得する。
 * -# 手順1.と手順2.で得た値が等しい場合、::CriFsInstaller::Stop 関数でインストールを停止する。
 */
public class CriFsInstaller : IDisposable
{
	/**
	 * <summary>インストーラの状態を示す値です。</summary>
	 * \sa CriFsInstaller::GetStatus
	 */
	public enum Status
	{
		Stop,		/**< 停止中				*/
		Busy,		/**< インストール中		*/
		Complete,	/**< インストール完了	*/
		Error		/**< エラーが発生		*/
	}
	
	private byte[] installBuffer = null;
	private GCHandle installBufferGch;
	
	public CriFsInstaller()
	{
		/* 初期化処理 */
		CriFsPlugin.InitializeLibrary();
		
		/* ハンドルの作成 */
		this.handle = IntPtr.Zero;
		#pragma warning disable 162
		if (CriWare.supportsCriFsInstaller == true) {
			criFsInstaller_Create(out this.handle, CopyPolicy.Always);
			if (this.handle == IntPtr.Zero) {
				CriFsPlugin.FinalizeLibrary();
				throw new Exception("criFsInstaller_Create() failed.");
			}
		} else {
			CriFsPlugin.FinalizeLibrary();
			throw new Exception("CriFsInstaller is not supported on this platform");
		}
		#pragma warning restore 162
	}
	
	/**
	 * <summary>インストーラを破棄します。</summary>
	 * \attention
	 * インストール処理中にインストーラを破棄した場合、
	 * 本関数内で処理が長時間ブロックされる可能性があります。<br/>
	 */
	public void Dispose()
	{
		/* ハンドルの有無をチェック */
		if (this.handle == IntPtr.Zero) {
			return;
		}
		
		/* ハンドルの破棄 */
		criFsInstaller_Destroy(this.handle);
		this.handle = IntPtr.Zero;
		
		/* コピーバッファを解放 */
		if (this.installBuffer != null) {
			this.installBufferGch.Free();
			this.installBuffer = null;
		}
		
		/* 終了処理 */
		CriFsPlugin.FinalizeLibrary();
		GC.SuppressFinalize(this);
	}
	
	
	/**
	 * <summary>ファイルをコピーします。</summary>
	 * <param name="binder">バインダ</param>
	 * <param name="srcPath">コピー元ファイルパス名</param>
	 * <param name="dstPath">コピー先ファイルパス名</param>
	 * \par 説明:
	 * ファイルのコピーを開始します。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * コピーの完了状態を取得するには ::CriFsInstaller::GetStatus 関数を使用してください。
	 * \sa CriFsInstaller::GetStatus
	 */
	public void Copy(CriFsBinder binder, string srcPath, string dstPath, int installBufferSize)
	{
		string copySrcPath = srcPath;
		if (copySrcPath.StartsWith("http:") || copySrcPath.StartsWith("https:")) {
			/* HTTP I/Oを使用したインストールはセカンダリ HTTP I/O デバイスを使用する */
			copySrcPath = "net2:" + copySrcPath;
		}
		if (installBufferSize > 0) {
			this.installBuffer    = new byte[installBufferSize];
        	this.installBufferGch = GCHandle.Alloc(this.installBuffer, GCHandleType.Pinned);
			criFsInstaller_Copy(this.handle,
				(binder != null) ? binder.nativeHandle : IntPtr.Zero, 
				copySrcPath, dstPath, this.installBufferGch.AddrOfPinnedObject(), this.installBuffer.Length);
		}
		else {
			criFsInstaller_Copy(this.handle,
				(binder != null) ? binder.nativeHandle : IntPtr.Zero, 
				copySrcPath, dstPath, IntPtr.Zero, 0);
		}	
	}
	
	/**
	 * <summary>インストール処理を停止します。</summary>
	 * \par 説明:
	 * 処理を停止します。<br>
	 * <br>
	 * 本関数は即時復帰関数です。<br>
	 * 停止の完了状態を取得するには ::CriFsInstaller::GetStatus 関数を使用してください。
	 * \sa
	 * CriFsInstaller::GetStatus
	 */
	public void Stop()
	{
		criFsInstaller_Stop(this.handle);
	}
	
	/**
	 * <summary>インストーラのステータスを取得します。</summary>
	 * <returns>ステータス</returns>
	 * \sa CriFsInstaller::Status
	 */
	public Status GetStatus()
	{
		Status status;
		criFsInstaller_GetStatus(this.handle, out status);
		return status;
	}
	
	/**
	 * <summary>インストール処理の進捗状況を取得します。</summary>
	 * <returns>進捗状況</returns>
	 * \par 説明:
	 * 処理の進捗状況を取得します。<br/>
	 * 進捗状況は0.0?1.0の32ビット浮動小数点数です。<br/>
	 */
	public float GetProgress()
	{
		float progress;
		criFsInstaller_GetProgress(this.handle, out progress);
		return progress;
	}
	
	/**
	 * <summary>定期実行関数</summary>
	 * \par 説明:
	 * インストール処理を進めます。定期的に実行する必要があります。<br/>
	 */
	public static void ExecuteMain()
	{
		criFsInstaller_ExecuteMain();
	}
	
	#region Internal Member
	IntPtr handle;
	enum CopyPolicy
	{
		Always
	}
	
	~CriFsInstaller()
	{
		this.Dispose();
	}
	#endregion
	
	#region DLLImport
	[DllImport(CriWare.pluginName)]
	private static extern void criFsInstaller_ExecuteMain();

	[DllImport(CriWare.pluginName)]
	private static extern int criFsInstaller_Create(out IntPtr installer, CopyPolicy option);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsInstaller_Destroy(IntPtr installer);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsInstaller_Copy(IntPtr installer, IntPtr binder, 
		string src_path, string dst_path, IntPtr buffer, long buffer_size);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsInstaller_Stop(IntPtr installer);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsInstaller_GetStatus(IntPtr installer, out Status status);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsInstaller_GetProgress(IntPtr installer, out float progress);
	#endregion
}

/**
 * <summary>CPKファイル内のコンテンツへのアクセスを行うためのモジュールです。</summary>
 * \par 説明：
 * CriFsBinder（バインダ）は、ファイルを効率良く扱うためのデータベースモジュールです。<br/>
 * CPKファイルやディレクトリをバインダに結びつける（バインドする）ことで、
 * CPKファイルやディレクトリ内のコンテンツ情報が取得可能となります。<br/>
 */
public class CriFsBinder : IDisposable
{
	/**
	 * <summary>バインダの状態を示す値です。</summary>
	 * \sa CriFsBinder::GetStatus
	 */
	public enum Status
	{
		None,		/**< 停止中				*/
		Analyze,	/**< バインド処理中		*/
		Complete,	/**< バインド完了		*/
		Unbind,		/**< アンバインド処理中	*/
		Removed,	/**< アンバインド完了	*/
		Invalid,	/**< バインド無効		*/
		Error		/**< バインド失敗		*/
	}

	public CriFsBinder()
	{
		/* 初期化処理 */
		CriFsPlugin.InitializeLibrary();
		
		/* ハンドルの作成 */
		this.handle = IntPtr.Zero;
		criFsBinder_Create(out this.handle);
		if (this.handle == IntPtr.Zero) {
			CriFsPlugin.FinalizeLibrary();
			throw new Exception("criFsBinder_Create() failed.");
		}
	}
	
	/**
	 * <summary>バインダを破棄します。</summary>
	 * \attention
	 * バインド処理中にバインダを破棄したり、Unbind処理を行わずにバインダを破棄した場合、
	 * 本関数内で処理が長時間ブロックされる可能性があります。<br/>
	 */
	public void Dispose()
	{
		/* ハンドルの有無をチェック */
		if (this.handle == IntPtr.Zero) {
			return;
		}
		
		/* ハンドルの破棄 */
		criFsBinder_Destroy(this.handle);
		this.handle = IntPtr.Zero;
		
		/* 終了処理 */
		CriFsPlugin.FinalizeLibrary();
		GC.SuppressFinalize(this);
	}

	/**
	 * <summary>CPKファイルをバインドします。</summary>
	 * <param name="srcBinder">バインドするCPKファイルにアクセスするためのバインダ</param>
	 * <param name="path">バインドするCPKファイルのパス名</param>
	 * <returns>バインドID</returns>
	 * \par 説明：
	 * CPKファイルを利用するには、CPKファイルをバインドする必要があります。<br/>
	 * 本関数は、バインダにCPKファイルをバインドし、バインドIDを返します。<br/>
	 * <br/>
	 * srcBinderには、CPKファイルを検索するためのバインダを指定します。<br/>
	 * srcBinderがnullの場合、デフォルトデバイスを使用します。<br/>
	 * <br/>
	 * バインドを開始できない場合、バインドIDは0が返されます。<br/>
	 * バインドIDに0以外が返された場合は内部リソースを確保していますので、<br/>
	 * 不要になったバインドIDは必ずアンバインドしてください。<br/>
	 * （バインド中のCPKファイルは、オープンされた状態で保持されます。）<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * 本関数から復帰した直後は、CPKのバインドはまだ完了しておらず、
	 * CPKのコンテンツファイルへのアクセスは行えません。<br/>
	 * バインド状態が完了（ Complete ）となった後に、
	 * CPKは利用可能となります。<br/>
	 * バインド状態は ::CriFsBinder::GetStatus 関数で取得します。<br/>
	 * \sa CriFsBinder::GetStatus, CriFsBinder::Unbind
	 */
	public uint BindCpk(CriFsBinder srcBinder, string path)
	{
		uint bindId;
		criFsBinder_BindCpk(this.handle, 
			(srcBinder != null) ? srcBinder.nativeHandle : IntPtr.Zero, 
			path, IntPtr.Zero, 0, out bindId);
		return bindId;
	}
	
	/**
	 * <summary>ディレクトリパスをバインドします。</summary>
	 * <param name="srcBinder">バインドするディレクトリにアクセスするためのバインダ</param>
	 * <param name="path">バインドするディレクトリのパス名</param>
	 * \par 説明：
	 * ディレクトリパス名をバインドします。<br/>
	 * バインドするディレクトリ名は絶対パスで指定してください。<br/>
	 * <br/>
	 * バインド時に指定されたディレクトリが存在するか否かはチェックしていません。<br/>
	 * バインダ内に保持されるのはディレクトリパスだけで、
	 * 指定されたディレクトリ内のファイルをオープン状態にするものではありません。<br/>
	 * よってバインドに失敗しない限り、本関数から復帰時にはバインドIDのバインド状態は完了
	 * （ Complete ）となります。<br/>
	 * <br/>
	 * バインドを開始できない場合、バインドIDは0が返されます。<br/>
	 * バインドIDに0以外が返された場合は内部リソースを確保していますので、<br/>
	 * 不要になったバインドIDは必ずアンバインドしてください。<br/>
	 * \attention
	 * 本関数は開発支援用のデバッグ関数です。<br/>
	 * 本関数を使用した場合、以下の問題が発生する可能性があります。<br/>
	 * - ::CriFsLoader::Load 関数や ::CriFsBinder::GetFileSize 関数内で処理が長時間ブロックされる。<br/>
	 * - バインドしたディレクトリ内のファイルにアクセスする際、音声やムービーのストリーム再生が途切れる。<br/>
	 * \attention
	 * マスターアップ時には本関数をアプリケーション中で使用しないようご注意ください。<br/>
	 * （ディレクトリ内のデータをCPKファイル化して ::CriFsBinder::BindCpk 関数でバインドするか、
	 * またはディレクトリ内のファイルを全て ::CriFsBinder::BindFile 関数でバインドしてください。）<br/>
	 * \sa CriFsBinder::GetStatus, CriFsBinder::Unbind, CriFsBinder::BindCpk, CriFsBinder::BindFile
	 */
	public uint BindDirectory(CriFsBinder srcBinder, string path)
	{
		uint bindId;
		criFsBinder_BindDirectory(this.handle, 
			(srcBinder != null) ? srcBinder.nativeHandle : IntPtr.Zero,
			path, IntPtr.Zero, 0, out bindId);
		return bindId;
	}
	
	/**
	 * <summary>ファイルをバインドします。</summary>
	 * <param name="srcBinder">バインドするファイルにアクセスするためのバインダ</param>
	 * <param name="path">バインドするファイルのパス名</param>
	 * <returns>バインドID</returns>
	 * \par 説明：
	 * ファイルをバインドし、バインドIDを返します。<br/>
	 * （srcBinderのバインダからpathで指定されたファイルを検索してバインドします。）<br/>
	 * srcBinderがnullの場合、デフォルトデバイスを使用します。<br/>
	 * <br/>
	 * バインドを開始できない場合、バインドIDは0が返されます。<br/>
	 * バインドIDに0以外が返された場合は内部リソースを確保していますので、<br/>
	 * 不要になったバインドIDは必ずアンバインドしてください。<br/>
	 * （バインド中のCPKファイルは、オープンされた状態で保持されます。）<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * 本関数から復帰した直後はファイルのバインドはまだ完了しておらず、
	 * バインドIDを利用したファイルへのアクセスは行えません。<br/>
	 * バインドIDのバインド状態が完了（ Complete ）となった後に、
	 * ファイルは利用可能となります。<br/>
	 * バインド状態は ::CriFsBinder::GetStatus 関数で取得します。<br/>
	 * \sa CriFsBinder::GetStatus, CriFsBinder::Unbind
	 */
	public uint BindFile(CriFsBinder srcBinder, string path)
	{
		uint bindId;
		criFsBinder_BindFile(this.handle, 
			(srcBinder != null) ? srcBinder.nativeHandle : IntPtr.Zero, 
			path, IntPtr.Zero, 0, out bindId);
		return bindId;
	}
	
	/**
	 * <summary>バインド済みのコンテンツをアンバインドします。<summary>
	 * <param name="bindId">バインドID</param>
	 * \par 説明：
	 * バインド済みのコンテンツをアンバインドします。<br/>
	 * どのコンテンツをアンバインドするかは、バインドIDで指定します。<br/>
	 * \attention
	 * 本関数は完了復帰関数です。<br/>
	 * 必要に応じてファイルのクローズ処理を行いますので、
	 * 実行環境により数msecかかる場合があります。<br/>
	 * <br/>
	 * アンバインドするバインドIDに依存している他のバインドIDも、
	 * 同時にアンバインドされます（暗黙的アンバインド）。<br/>
	 * 例えば、CPKバインドIDのコンテンツファイルをファイルバインドしているバインドIDは、
	 * 参照元のCPKバインドIDがアンバインドされると、暗黙的にアンバインドされます。<br/>
	 * \sa ::CriFsBinder::BindCpk, CriFsBinder::BindFile
	 */
	public static void Unbind(uint bindId)
	{
		criFsBinder_Unbind(bindId);
	}
	
	/**
	 * <summary>バインダのステータスを取得します。</summary>
	 * <returns>ステータス</returns>
	 * \sa CriFsBinder::Status
	 */
	public static Status GetStatus(uint bindId)
	{
		Status status;
		criFsBinder_GetStatus(bindId, out status);
		return status;
	}
	
	/**
	 * <summary>ファイルサイズを取得します。</summary>
	 * <param name="path">ファイルのフルパス</param>
	 * <returns>ファイルのサイズ</returns>
	 * \par 説明:
	 * 指定されたファイルのファイルサイズを取得します。<br/>
	 * バインド状態が Complete であるバインドIDが検索対象となります。<br/>
	 * <br/>
	 * 指定されたファイルが存在しない場合、負値が返されます。
	 * \attention
	 * ::CriFsBinder::BindDirectory 関数でディレクトリをバインドした場合、
	 * 本関数内で長時間処理がブロックされる場合があります。
	 * \sa CriFsBinder::GetFileSize(int)
	 */
	public long GetFileSize(string path)
	{
		int err;
		long size;
		err = criFsBinder_GetFileSize(this.handle, path, out size);
		if (err != 0) {
			return (-1);
		}
		return size;
	}
	
	/**
	 * <summary>ファイルサイズを取得します。</summary>
	 * <param name="id">ファイルID</param>
	 * <returns>ファイルのサイズ</returns>
	 * \par 説明：
	 * ファイルサイズを取得します。<br>
	 * ID情報つきCPKファイルがバインドされている必要があります。<br>
	 * バインド状態が Complete であるバインドIDが検索対象となります。<br/>
	 * <br/>
	 * 指定されたファイルが存在しない場合、負値が返されます。
	 * \sa CriFsBinder::GetFileSize(string)
	 */
	public long GetFileSize(int id)
	{
		int err;
		long size;
		err = criFsBinder_GetFileSizeById(this.handle, id, out size);
		if (err != 0) {
			return (-1);
		}
		return size;
	}

	/**
	 * <summary>バインドIDに対して検索優先度を設定します。</summary>
	 * <param name="bindId">バインドID</param>
	 * <param name="priority">優先度</param>
	 * \par 説明：
	 * バインドIDに対し、バインダ内での検索優先度を設定します。<br/>
	 * 優先度は 0 が最低で、値が大きくなるほど検索優先度は高くなります。<br/>
	 * 同じ優先度のバインドIDは先にバインドした方が優先して検索対象になります。<br/>
	 * 優先度未設定の場合、デフォルトの優先度は 0 です。<br/>
	 * バインド状態が Complete であるバインドIDが対象となります。<br/>
	 */
	public static void SetPriority(uint bindId, int priority)
	{
		criFsBinder_SetPriority(bindId, priority);
	}
	
	public IntPtr nativeHandle {
		get { return this.handle; }
	}
	
	#region Internal Member
	IntPtr handle;

	~CriFsBinder()
	{
		this.Dispose();
	}	
	#endregion
	
	#region DLLImport
	[DllImport(CriWare.pluginName)]
	private static extern uint criFsBinder_Create(out IntPtr binder);

	[DllImport(CriWare.pluginName)]
	private static extern uint criFsBinder_Destroy(IntPtr binder);

	[DllImport(CriWare.pluginName)]
	private static extern uint criFsBinder_BindCpk(IntPtr binder, 
		IntPtr srcBinder, string path, IntPtr work, int worksize, out uint bindId);

	[DllImport(CriWare.pluginName)]
	private static extern uint criFsBinder_BindDirectory(IntPtr binder, 
		IntPtr srcBinder, string path, IntPtr work, int worksize, out uint bindId);

	[DllImport(CriWare.pluginName)]
	private static extern uint criFsBinder_BindFile(IntPtr binder, 
		IntPtr srcBinder, string path, IntPtr work, int worksize, out uint bindId);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsBinder_Unbind(uint bindId);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsBinder_GetStatus(uint bindId, out Status status);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criFsBinder_GetFileSize(IntPtr binder, string path, out long size);
	
	[DllImport(CriWare.pluginName)]
	private static extern int criFsBinder_GetFileSizeById(IntPtr binder, int id, out long size);

	[DllImport(CriWare.pluginName)]
	private static extern int criFsBinder_SetPriority(uint bindId, int priority);

	#endregion
}

/**
 * @}
 */


/*==========================================================================
 *     CRI File System Unity Component
 *=========================================================================*/
/**
 * \addtogroup CRIFS_UNITY_COMPONENT
 * @{
 */

/**
 * <summary>非同期処理の進捗状況の確認や、処理結果を取得するためのモジュールです。</summary>
 * \par 説明:
 * 非同期処理の進捗状況の確認や、非同期処理結果を取得するためのモジュールです。<br/>
 * 非同期処理が完了すると、isDoneの値がtrueになります。<br/>
 * 非同期処理中にエラーが発生した場合、errorにエラー情報が格納されます。<br/>
 */
public class CriFsRequest : IDisposable
{
	public delegate void DoneDelegate(CriFsRequest request);

	/**
	 * <summary>処理が完了したときのデリゲート。</summary>
	 * \par 説明:
	 * 非同期処理の完了をチェックするためのパラメータです。<br/>
	 * 非同期処理中はisDoneの値はfalseです。<br/>
	 * 非同期処理が完了すると、isDoneの値がtrueになります。<br/>
	 */
	public DoneDelegate doneDelegate { get; protected set; }

	/**
	 * <summary>処理が完了したかどうか。</summary>
	 * \par 説明:
	 * 非同期処理の完了をチェックするためのパラメータです。<br/>
	 * 非同期処理中はisDoneの値はfalseです。<br/>
	 * 非同期処理が完了すると、isDoneの値がtrueになります。<br/>
	 */
	public bool isDone  { get; private set; }

	/**
	 * <summary>エラー情報。</summary>
	 * \par 説明:
	 * 非同期処理中のエラーが起きたかどうかをチェックするためのパラメータです。<br/>
	 * 非同期処理が正常に完了した場合、errorの値はnullです。<br/>
	 * 非同期処理中にエラーが発生すると、エラー情報が格納されます。<br/>
	 */
	public string error { get; protected set; }
	
	/**
	 * <summary>破棄情報。</summary>
	 * \par 説明:
	 * リクエストが破棄されたかどうかをチェックするためのパラメータです。<br/>
	 */
	public bool isDisposed { get; protected set; }
	
	/**
	 * <summary>非同期処理を停止させます。</summary>
	 * \par 説明:
	 * 非同期処理を停止させます。<br>
	 */
	virtual public void Stop()
	{
	}
	
	/**
	 * <summary>非同期処理の完了を待ちます。</summary>
	 * \par 説明:
	 * 非同期処理が完了するまで、コルーチンの実行をサスペンドします。<br/>
	 * <br>
	 * 本関数はコルーチン内のyieldステートメントでのみ利用可能です。<br/>
	 * 具体的には、以下のような書式で使用する必要があります。<br/>
	 * \code
	 * 		：
	 * 	// 非同期処理の開始
	 * 	CriFsRequest request = CriFsUtility.?
	 * 	
	 * 	// 非同期処理の完了まで待機
	 * 	yield return request.WaitForDone(this);
	 * 		：
	 * \endcode
	 */
	public YieldInstruction WaitForDone(MonoBehaviour mb)
	{
		return mb.StartCoroutine(CheckDone());
	}
	
	#region Internal Methods

	virtual public void Update()
	{
	}
	
	protected void Done()
	{
		this.isDone = true;
		if (this.doneDelegate != null) {
			this.doneDelegate(this);
		}
	}

	IEnumerator CheckDone()
	{
		while (!this.isDone) {
			yield return null;
		}
	}
	
	virtual public void Dispose()
	{
	}
	
	~CriFsRequest()
	{
		this.Dispose();
	}
	#endregion
}

/**
 * <summary>ロード処理の進捗状況の確認や、ロード処理結果を取得するためのモジュールです。</summary>
 * \par 説明:
 * ロード処理の進捗状況の確認や、ロード処理結果を取得するためのモジュールです。<br/>
 * ::CriFsUtility::LoadFile 関数の戻り値として返されます。<br/>
 * <br/>
 * ロード処理が完了すると、isDoneの値がtrueになります。<br/>
 * ロード結果はbytesに格納されます。<br/>
 * ロード処理中にエラーが発生した場合、errorにエラー情報が格納されます。<br/>
 * \sa CriFsUtility::LoadFile
 */
public class CriFsLoadFileRequest : CriFsRequest
{
	/**
	 * <summary>ロードするファイルのパスです。</summary>
	 * \par 説明：
	 * ロードするファイルのパスです。<br/>
	 * ::CriFsUtility::LoadFile 関数実行時に指定したパスが格納されています。<br/>
	 * \sa
	 * CriFsUtility::LoadFile
	 */
	public string path { get; private set; }

	/**
	 * <summary>ロード結果を格納したバッファです。</summary>
	 * \par 説明：
	 * ロード結果を格納したバッファです。<br/>
	 * ロード処理を ::CriFsLoadFileRequest::Stop 関数で停止した場合や、
	 * ロード中にエラーが発生した場合、値がnullになります。<br/>
	 */
	public byte[] bytes { get; private set; }

	#region Internal Methods

	public CriFsLoadFileRequest(CriFsBinder srcBinder, string path, CriFsRequest.DoneDelegate doneDelegate, int readUnitSize)
	{
		/* パスの保存 */
		this.path = path;

		/* 完了コールバック指定 */
		this.doneDelegate = doneDelegate;
		
		/* readUnitSizeの保存 */
		this.readUnitSize = readUnitSize;
		
		/* ファイルのバインド要求 */
		if (srcBinder == null) {
			this.newBinder = new CriFsBinder();
			this.refBinder = this.newBinder;
			this.bindId = this.newBinder.BindFile(srcBinder, path);
			this.phase = Phase.Bind;
		} else {
			this.newBinder = null;
			this.refBinder = srcBinder;
			this.fileSize = srcBinder.GetFileSize(path);
			if (this.fileSize < 0) {
				this.phase = Phase.Error;
			} else {
				this.phase = Phase.Load;
			}
		}
	}
	
	override public void Dispose()
	{
		if (this.isDisposed) {
			return;
		}
		
		/* ローダの破棄 */
		if (this.loader != null) {
			this.loader.Dispose();
			this.loader = null;
		}
		
		/* バインダの破棄 */
		if (this.newBinder != null) {
			this.newBinder.Dispose();
			this.newBinder = null;
		}
		
		/* メモリの解放 */
		this.bytes = null;
		
		GC.SuppressFinalize(this);
		this.isDisposed = true;
	}
	
	public override void Stop()
	{
		/* ローダに停止要求を発行 */
		if (this.phase == Phase.Load) {
			if (this.loader != null) {
				this.loader.Stop();
			}
		}
	}
	
	public override void Update()
	{
		if (this.phase == Phase.Bind) {
			this.UpdateBinder();
		}
		if (this.phase == Phase.Load) {
			this.UpdateLoader();
		}
		if (this.phase == Phase.Error) {
			this.OnError();
		}
	}
	
	private void UpdateBinder()
	{
		/* バインダのステータスをチェック */
		CriFsBinder.Status binderStatus = CriFsBinder.GetStatus(this.bindId);
		if (binderStatus == CriFsBinder.Status.Analyze) {
			/* バインド中は何もしない */
			return;
		}
		
		switch (binderStatus) {
			/* バインド完了 */
			case CriFsBinder.Status.Complete:
			this.fileSize = this.refBinder.GetFileSize(this.path);
			break;
			
			/* 上記以外はエラー扱い */
			default:
			this.fileSize = -1;
			break;
		}
		
		/* エラーチェック */
		if (this.fileSize < 0) {
			/* エラー状態に遷移してそっちで後始末 */
			this.phase = Phase.Error;
			return;
		}
		
		/* フェーズの更新 */
		this.phase = Phase.Load;
	}
	
	private void UpdateLoader()
	{
		/* ローダが確保済みかどうかチェック */
		if (this.loader == null) {
			/* ロード要求の発行 */
			this.loader = new CriFsLoader();
			this.loader.SetReadUnitSize(readUnitSize);
			this.bytes = new byte[this.fileSize];
			this.loader.Load(this.refBinder, this.path, 0, this.fileSize, this.bytes);
		}
		
		/* ローダのステータスをチェック */
		CriFsLoader.Status loaderStatus = this.loader.GetStatus();
		if (loaderStatus == CriFsLoader.Status.Loading) {
			/* ロード中は何もしない */
			return;
		}
		
		/* エラーチェック */
		switch (loaderStatus) {
			case CriFsLoader.Status.Stop:
			this.bytes = null;
			break;
			
			case CriFsLoader.Status.Error:
			/* エラーに遷移 */
			this.phase = Phase.Error;
			return;
			
			default:
			break;
		}
		
		/* フェーズの更新 */
		this.phase = Phase.Done;
		
		/* ローダの破棄 */
		this.loader.Dispose();
		this.loader = null;
		
		/* バインダの破棄 */
		if (this.newBinder != null) {
			this.newBinder.Dispose();
			this.newBinder = null;
		}
		
		/* 処理の完了を通知 */
		this.Done();
	}

	private void OnError()
	{
		this.bytes = null;
		this.error = "Error occurred.";
		this.refBinder = null;
		/* バインダの破棄 */
		if (this.newBinder != null) {
			this.newBinder.Dispose();
			this.newBinder = null;
		}
		/* ローダの破棄 */
		if (this.loader != null) {
			this.loader.Dispose();
			this.loader = null;
		}
		this.phase = Phase.Done;
		this.Done();
		
		return;
	}
	
	#endregion

	#region Internal Fields

	private enum Phase
	{
		Stop,
		Bind,
		Load,
		Done,
		Error
	};
	
	private Phase phase = Phase.Stop;
	private CriFsBinder refBinder = null;
	private CriFsBinder newBinder = null;
	private uint bindId = 0;
	private CriFsLoader loader = null;
	private int readUnitSize = 0;
	private long fileSize = 0;

	#endregion
}

/**
 * <summary>アセットバンドル処理の進捗状況の確認や、アセットバンドル処理結果を取得するためのモジュールです。</summary>
 * \par 説明:
 * アセットバンドル処理の進捗状況の確認や、アセットバンドル処理結果を取得するためのモジュールです。<br/>
 * ::CriFsUtility::LoadAssetBundle 関数の戻り値として返されます。<br/>
 * <br/>
 * アセットバンドル処理が完了すると、isDoneの値がtrueになります。<br/>
 * アセットバンドル結果はassetBundleに格納されます。<br/>
 * アセットバンドル処理中にエラーが発生した場合、errorにエラー情報が格納されます。<br/>
 * \sa CriFsUtility::LoadAssetBundle
 */
public class CriFsLoadAssetBundleRequest : CriFsRequest
{
	/**
	 * <summary>ロードするアセットバンドルファイルのパスです。</summary>
	 * \par 説明：
	 * ロードするアセットバンドルファイルのパスです。<br/>
	 * ::CriFsUtility::LoadAssetBundle 関数実行時に指定したパスが格納されています。<br/>
	 * \sa
	 * CriFsUtility::LoadAssetBundle
	 */
	public string path { get; private set; }
	
	/**
	 * <summary>ロード結果のアセットバンドルです。</summary>
	 * \par 説明：
	 * ロード結果を格納したアセットバンドルのインスタンスです。<br/>
	 * ロード処理を ::CriFsLoadFileRequest::Stop 関数で停止した場合や、
	 * ロード中にエラーが発生した場合、値がnullになります。<br/>
	 */
	public AssetBundle assetBundle { get; private set; }
	
	#region Internal Methods

	public CriFsLoadAssetBundleRequest(CriFsBinder binder, string path, int readUnitSize)
	{
		this.path = path;
		this.loadFileReq = CriFsUtility.LoadFile(binder, path, readUnitSize);
	}

	override public void Update()
	{
		if (this.loadFileReq != null) {
			if (this.loadFileReq.isDone) {
				if (this.loadFileReq.error != null) {
					this.error = "Error occurred.";
					this.Done();
				} else {
#if UNITY_4_0 || UNITY_4_0_1 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_5_0 || UNITY_5_1 || UNITY_5_2
					this.assetBundleReq = AssetBundle.CreateFromMemory(this.loadFileReq.bytes);
#else
					this.assetBundleReq = AssetBundle.LoadFromMemoryAsync(this.loadFileReq.bytes);
#endif
				}
				this.loadFileReq = null;
			}
		} else if (this.assetBundleReq != null) {
			if (this.assetBundleReq.isDone) {
				this.assetBundle = this.assetBundleReq.assetBundle;
				this.Done();
			}
		} else {
			this.Done();
		}
	}
	
	override public void Dispose()
	{
		if (this.isDisposed) {
			return;
		}
		
		/* ローダの破棄 */
		if (this.loadFileReq != null) {
			this.loadFileReq.Dispose();
			this.loadFileReq = null;
		}
		
		GC.SuppressFinalize(this);
		this.isDisposed = true;
	}
	
	#endregion

	#region Internal Fields

	private CriFsLoadFileRequest loadFileReq;
	private AssetBundleCreateRequest assetBundleReq;

	#endregion
}

/**
 * <summary>インストール処理の進捗状況の確認や、インストール処理結果を取得するためのモジュールです。</summary>
 * \par 説明:
 * インストール処理の進捗状況の確認や、インストール処理結果を取得するためのモジュールです。<br/>
 * ::CriFsUtility::Install 関数の戻り値として返されます。<br/>
 * <br/>
 * インストール処理が完了すると、isDoneの値がtrueになります。<br/>
 * インストール処理中にエラーが発生した場合、errorにエラー情報が格納されます。<br/>
 * 明示的に ::CriFsInstallRequest::Stop を呼び出さない限り、無限リトライを行います。<br/>
 * タイムアウト処理を行う場合は、 ::CriFsInstallRequest::progress の値を監視して、十分な時間が経っても値に変化がなければ、
 * ::CriFsInstallRequest::Stop でインストール処理を停止するなどしてください。<br/>
 * \sa CriFsUtility::Install
 */
public class CriFsInstallRequest : CriFsRequest
{
	/**
	 * <summary>インストール元のファイルパスです。</summary>
	 * \par 説明：
	 * インストール元のファイルパスです。<br/>
	 * ::CriFsUtility::Install 関数実行時に指定したパスが格納されています。<br/>
	 * \sa
	 * CriFsUtility::LoadAssetBundle
	 */
	public string sourcePath { get; private set; }
	
	/**
	 * <summary>インストール先のファイルパスです。</summary>
	 * \par 説明：
	 * インストール先のファイルパスです。<br/>
	 * ::CriFsUtility::Install 関数実行時に指定したパスが格納されています。<br/>
	 * \sa
	 * CriFsUtility::LoadAssetBundle
	 */
	public string destinationPath { get; private set; }
	
	/**
	 * <summary>インストール処理の進捗状況です。</summary>
	 * <returns>進捗状況</returns>
	 * \par 説明:
	 * 処理の進捗状況を取得します。<br/>
	 * 進捗状況は0.0?1.0の32ビット浮動小数点数です。<br/>
	 * <br/>
	 * ::CriFsInstallRequest::Stop 関数で処理を停止した場合、停止時点での進捗状況が保存されています。<br/>
	 * インストール処理中にエラーが発生した場合、値が負値になります。<br/>
	 * 値が更新されるタイミングは、 CriWareInitializer.fileSystemConfig.installBufferSize
	 * の大きさのバッファが満たされた時です。<br>
	 * インストールバッファのサイズが大きすぎると、インストールが進行しているにも関わらず、値の更新頻度が低くなくなります。<br>
	 * タイムアウト処理などを行う場合には、インストールバッファのサイズに注意してください。
	 */
	public float progress { get; private set; }

	/**
	 * <summary>インストール処理を停止します。</summary>
	 * \par 説明:
	 * 処理を停止します。<br>
	 * <br>
	 * 本関数は即時復帰関数です。<br>
	 * 本関数を実行してからインストール処理が停止するまでには、最大20秒程度の時間がかかることがあります。<br>
	 * インストール処理が停止すると、コルーチンとして動作している ::CriFsInstallRequest::WaitForDone 関数が復帰します。<br>
	 */
	public override void Stop()
	{
		if (this.installer != null) {
			this.installer.Stop();
		}
	}
	
	#region Internal Methods
	
	public CriFsInstallRequest(CriFsBinder srcBinder, string srcPath, string dstPath, CriFsRequest.DoneDelegate doneDelegate, int installBufferSize)
	{
		this.sourcePath = srcPath;
		this.destinationPath = dstPath;
		this.doneDelegate = doneDelegate;
		this.progress = 0.0f;
		this.installer = new CriFsInstaller();
		this.installer.Copy(srcBinder, srcPath, dstPath, installBufferSize);
	}

	override public void Update()
	{
		/* インストーラの有無をチェック */
		if (this.installer == null) {
			return;
		}
		
		/* 進捗状況の更新 */
		this.progress = this.installer.GetProgress();
		
		/* ステータスのチェック */
		CriFsInstaller.Status status = this.installer.GetStatus();
		if (status == CriFsInstaller.Status.Busy) {
			return;
		}
		
		/* エラーチェック */
		if (status == CriFsInstaller.Status.Error) {
			this.progress = -1.0f;
			this.error = "Error occurred.";
		}
		
		/* インストーラの破棄 */
		this.installer.Dispose();
		this.installer = null;
		
		/* 処理の完了を通知 */
		this.Done();
	}

	#endregion

	#region Internal Fields

	private CriFsInstaller installer;
	
	override public void Dispose()
	{
		if (this.isDisposed) {
			return;
		}
		
		if (this.installer != null) {
			this.installer.Dispose();
			this.installer = null;
		}
		
		GC.SuppressFinalize(this);
		this.isDisposed = true;
	}

	#endregion
}

/**
 * <summary>バインド処理の進捗状況の確認や、バインド処理結果を取得するためのモジュールです。</summary>
 * \par 説明:
 * バインド処理の進捗状況の確認や、バインド処理結果を取得するためのモジュールです。<br/>
 * CriFsUtility::BindCpk 関数の戻り値として返されます。<br/>
 * <br/>
 * バインド処理が完了すると、isDoneの値がtrueになります。<br/>
 * バインド処理中にエラーが発生した場合、errorにエラー情報が格納されます。<br/>
 * \sa CriFsUtility::BindCpk
 */
public class CriFsBindRequest : CriFsRequest
{
	public enum BindType
	{
		Cpk,
		Directory,
		File
	}
	
	/**
	 * <summary>バインドするファイルのパスです。</summary>
	 * \par 説明：
	 * バインドするファイルのパスです。<br/>
	 * ::CriFsUtility::BindCpk 関数等の実行時に指定したパスが格納されています。<br/>
	 * \sa
	 * CriFsUtility::BindCp, CriFsUtility::BindFile, CriFsUtility::BindDirectory
	 */
	public string path { get; private set; }

	/**
	 * <summary>バインド処理を識別するIDです。</summary>
	 * \par 説明：
	 * バインド処理を識別するIDです。<br/>
	 * マルチバインド後に特定のバインドのみを解除する場合に使用します。<br/>
	 * \sa
	 * CriFsBinder::Unbind
	 */
	public uint bindId { get; private set; }

	public CriFsBindRequest(BindType type, CriFsBinder targetBinder, CriFsBinder srcBinder, string path)
	{
		/* パスの保存 */
		this.path = path;
		
		/* バインド種別のチェック */
		switch (type) {
			case BindType.Cpk:
			this.bindId = targetBinder.BindCpk(srcBinder, path);
			break;
			
			case BindType.Directory:
			this.bindId = targetBinder.BindDirectory(srcBinder, path);
			break;
			
			case BindType.File:
			this.bindId = targetBinder.BindFile(srcBinder, path);
			break;
			
			default:
			throw new Exception("Invalid bind type.");
		}
	}
	
	public override void Stop()
	{
	}

	override public void Update()
	{
		/* バインド処理中かどうかチェック */
		if (this.isDone) {
			/* バインド処理中以外は何もしない */
			return;
		}
		
		/* ステータスのチェック */
		CriFsBinder.Status status = CriFsBinder.GetStatus(this.bindId);
		if (status == CriFsBinder.Status.Analyze) {
			return;
		}
		
		/* エラーチェック */
		if (status == CriFsBinder.Status.Error) {
			this.error = "Error occurred.";
		}
		
		/* 完了の通知 */
		this.Done();
	}
	
	override public void Dispose()
	{
		if (this.isDisposed) {
			return;
		}
		
		GC.SuppressFinalize(this);
		this.isDisposed = true;
	}
}

/**
 * <summary>CPKファイルのバインドや、ファイルのロード等の操作を簡単に行うための、ユーティリティクラスです。</summary>
 * \par 説明:
 * CPKファイルのバインドや、ファイルのロード等の操作を簡単に行うための、ユーティリティクラスです。<br/>
 */
public static class CriFsUtility
{
	/**
	 * <summary>各ロードリクエストのデフォルトの読み込み単位サイズです。</summary>
	 * \par 説明:
	 * 各ロードリクエストの最後の引数のデフォルト値です。<br/>
	 * \sa ::CriFsUtility::LoadFile, ::CriFsUtility::LoadAssetBundle, ::CriFsUtility::LoadAssetBundle
	 */
	public const int DefaultReadUnitSize = (1024 * 1024);	// 1.0 Mb

	/**
	 * <summary>
	 * ファイルのロードを開始します。</summary>
	 * <param name="path">ファイルパス</param>
	 * <param name="readUnitSize">内部で使用するCriFsLoaderの読み込み単位サイズ</param>
	 * <returns>CriFsLoadFileRequest</returns>
	 * \par 説明:
	 * 指定されたファイルの読み込みを開始します。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * ロードの完了をチェックするには、 ::CriFsLoadFileRequest::isDone を確認する必要があります。<br/>
	 * ロード処理中にエラーが発生した場合、 ::CriFsLoadFileRequest::error にエラー情報が格納されます。<br/>
	 * \par 例:
	 * ::CriFsUtility::LoadFile 関数を用いてファイルを読み込むコードは以下のとおりです。<br/>
	 * \code
	 * IEnumerator UserLoadFile(string path)
	 * {
	 * 	// ファイルの読み込みを開始
	 * 	CriFsLoadFileRequest request = CriFsUtility.LoadFile(path);
	 * 	
	 * 	// 読み込み完了を待つ
	 * 	yield return request.WaitForDone(this);
	 * 	
	 * 	// エラーチェック
	 * 	if (request.error != null) {
	 * 		// エラー発生時の処理
	 * 		…
	 * 		yield break;
	 * 	}
	 * 	
	 * 	// 備考）ロードされたファイルの内容は request.bytes 内に格納されています。
	 * }
	 * \endcode
	 * <br/>
	 * StreamingAssetsフォルダ以下のデータを読み込む場合は、 ::CriWare::streamingAssetsPath を
	 * ファイルパスの前に連結してください。
	 * \code
	 * 	string path = Path.Combine(CriWare.streamingAssetsPath, "sample_text.txt");
	 * 	CriFsLoadFileRequest request = CriFsUtility.LoadFile(path);
	 * \endcode
	 * \par 備考:
	 * CPKファイル内のデータをロードする場合には、
	 * 本関数の代わりに ::CriFsUtility::LoadFile(CriFsBinder, string) を使用し、
	 * データ読み込み元となるバインダを指定する必要があります。<br/>
	 * <br/>
	 * パスにURLを指定することで、ネットワーク経由でファイルをロードすることも可能です。<br/>
	 * \code
	 * // crimot.comからFMPRO_Intro_e.txtをダウンロード
	 * CriFsLoadFileRequest request = CriFsUtility.LoadFile(
	 * 	"http://crimot.com/sdk/sampledata/crifilesystem/FMPRO_Intro_e.txt");
	 * \endcode
	 * \sa
	 * CriFsLoadFileRequest, CriFsUtility::LoadFile(CriFsBinder, string)
	 */
	public static CriFsLoadFileRequest LoadFile(string path, int readUnitSize = DefaultReadUnitSize)
	{
		return CriFsServer.instance.LoadFile(null, path, null, readUnitSize);
	}
	public static CriFsLoadFileRequest LoadFile(string path, CriFsRequest.DoneDelegate doneDelegate, int readUnitSize = DefaultReadUnitSize)
	{
		return CriFsServer.instance.LoadFile(null, path, doneDelegate, readUnitSize);
	}
	
	/**
	 * <summary>ファイルのロードを開始します。</summary>
	 * <param name="binder">バインダ</param>
	 * <param name="path">ファイルパス</param>
	 * <param name="readUnitSize">内部で使用するCriFsLoaderの読み込み単位サイズ</param>
	 * <returns>CriFsLoadFileRequest</returns>
	 * \par 説明:
	 * バインド済みのファイルの読み込みを開始します。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * ロードの完了をチェックするには、 ::CriFsLoadFileRequest::isDone を確認する必要があります。<br/>
	 * ロード処理中にエラーが発生した場合、 ::CriFsLoadFileRequest::error にエラー情報が格納されます。<br/>
	 * \par 備考:
	 * 第一引数にバインダを指定する点以外は、 ::CriFsUtility::LoadFile(string) 関数と同じです。<br/>
	 * \sa
	 * CriFsLoadFileRequest, CriFsUtility::LoadFile(string)
	 */
	public static CriFsLoadFileRequest LoadFile(CriFsBinder binder, string path, int readUnitSize = DefaultReadUnitSize)
	{
		return CriFsServer.instance.LoadFile(binder, path, null, readUnitSize);
	}
	
	/**
	 * <summary>アセットバンドルファイルのロードを開始します。</summary>
	 * <param name="path">ファイルパス</param>
	 * <param name="readUnitSize">内部で使用するCriFsLoaderの読み込み単位サイズ</param>
	 * <returns>CriFsLoadAssetBundleRequest</returns>
	 * \par 説明:
	 * 指定されたアセットバンドルファイルの読み込みを開始します。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * ロードの完了をチェックするには、 ::CriFsLoadAssetBundleRequest::isDone を確認する必要があります。<br/>
	 * ロード処理中にエラーが発生した場合、 ::CriFsLoadFileRequest::error にエラー情報が格納されます。<br/>
	 * \par 例:
	 * ::CriFsUtility::LoadAssetBundle 関数を用いてアセットバンドルを読み込むコードは以下のとおりです。<br/>
	 * \code
	 * IEnumerator UserLoadAssetBundle(string path)
	 * {
	 * 	// アセットバンドルの読み込みを開始
	 * 	CriFsLoadAssetBundleRequest request = CriFsUtility.LoadAssetBundle(path);
	 * 	
	 * 	// 読み込み完了を待つ
	 * 	yield return request.WaitForDone(this);
	 * 	
	 * 	// エラーチェック
	 * 	if (request.error != null) {
	 * 		// エラー発生時の処理
	 * 		…
	 * 		yield break;
	 * 	}
	 * 	
	 * 	// インスタンスの作成
	 * 	var obj = GameObject.Instantiate(request.assetBundle.mainAsset, 
	 * 			new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
	 * 		：
	 * }
	 * \endcode
	 * <br/>
	 * StreamingAssetsフォルダ以下のデータを読み込む場合は、 ::CriWare::streamingAssetsPath を
	 * ファイルパスの前に連結してください。
	 * \code
	 * 	string path = Path.Combine(CriWare.streamingAssetsPath, "sample.assetbundle");
	 * 	CriFsLoadAssetBundleRequest request = CriFsUtility.LoadAssetBundle(path);
	 * \endcode
	 * \par 備考:
	 * CPKファイル内のアセットデータをロードする場合には、
	 * 本関数の代わりに ::CriFsUtility::LoadAssetBundle(CriFsBinder, string) を使用し、
	 * データ読み込み元となるバインダを指定する必要があります。<br/>
	 * <br/>
	 * パスにURLを指定することで、ネットワーク経由でファイルをロードすることも可能です。<br/>
	 * \code
	 * // crimot.comからCharaMomo.unity3dをダウンロード
	 * CriFsLoadFileRequest request = CriFsUtility.LoadAssetBundle(
	 * 	"http://crimot.com/sdk/sampledata/crifilesystem/CharaMomo.unity3d");
	 * \endcode
	 * \sa
	 * CriFsLoadAssetBundleRequest, CriFsUtility::LoadAssetBundle(CriFsBinder, string)
	 */
	public static CriFsLoadAssetBundleRequest LoadAssetBundle(string path, int readUnitSize = DefaultReadUnitSize)
	{
		return CriFsUtility.LoadAssetBundle(null, path, readUnitSize);
	}
	
	/**
	 * <summary>アセットバンドルファイルのロードを開始します。</summary>
	 * <param name="binder">バインダ</param>
	 * <param name="path">ファイルパス</param>
	 * <param name="readUnitSize">内部で使用するCriFsLoaderの読み込み単位サイズ</param>
	 * <returns>CriFsLoadAssetBundleRequest</returns>
	 * \par 説明:
	 * バインド済みのアセットバンドルファイルの読み込みを開始します。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * ロードの完了をチェックするには、 ::CriFsLoadAssetBundleRequest::isDone を確認する必要があります。<br/>
	 * ロード処理中にエラーが発生した場合、 ::CriFsLoadFileRequest::error にエラー情報が格納されます。<br/>
	 * \par 備考:
	 * 第一引数にバインダを指定する点以外は、 ::CriFsUtility::LoadAssetBundle(string) 関数と同じです。<br/>
	 * \sa
	 * CriFsLoadAssetBundleRequest, CriFsUtility::LoadAssetBundle(string)
	 */
	public static CriFsLoadAssetBundleRequest LoadAssetBundle(CriFsBinder binder, string path, int readUnitSize = DefaultReadUnitSize)
	{
		return CriFsServer.instance.LoadAssetBundle(binder, path, readUnitSize);
	}
	
	/**
	 * <summary>ファイルのインストールを開始します。</summary>
	 * <param name="srcPath">インストール元ファイルパス</param>
	 * <param name="dstPath">インストール先ファイルパス</param>
	 * <returns>CriFsInstallRequest</returns>
	 * \par 説明:
	 * 指定されたファイルのインストールを開始します。<br/>
	 * インストール元ファイルパスをsrcPath、インストール先ファイルパスをdstPathで指定します。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * インストールの完了をチェックするには、 ::CriFsInstallRequest::isDone を確認する必要があります。<br/>
	 * インストール処理中にエラーが発生した場合、 ::CriFsInstallRequest::error にエラー情報が格納されます。<br/>
	 * <br/>
	 * StreamingAssetsフォルダ以下のデータをインストール元として指定する場合は、 ::CriWare::streamingAssetsPath を
	 * ファイルパスの前に連結してください。
	 * \par 備考:
	 * パスにURLを指定することで、ネットワーク経由でファイルをロードすることも可能です。<br/>
	 * \par 例:
	 * ::CriFsUtility::Install 関数を用いてファイルをインストールするコードは以下のとおりです。<br/>
	 * \code
	 * private IEnumerator UserInstallFile(string url, string path)
	 * {
	 * 	// インストールの開始
	 * 	CriFsInstallRequest request = CriFsUtility.Install(url, path);
	 * 	
	 * 	// インストール完了待ち
	 * 	yield return request.WaitForDone(this);
	 * 	
	 * 	// エラーチェック
	 * 	if (request.error != null) {
	 * 		// エラー発生時の処理
	 * 		…
	 * 		yield break;
	 * 	}
	 * 		：
	 * }
	 * \endcode
	 * \sa
	 * CriFsInstallRequest
	 */
	public static CriFsInstallRequest Install(string srcPath, string dstPath)
	{
		return CriFsUtility.Install(null, srcPath, dstPath, null);
	}
	public static CriFsInstallRequest Install(string srcPath, string dstPath, CriFsRequest.DoneDelegate doneDeleagate)
	{
		return CriFsUtility.Install(null, srcPath, dstPath, doneDeleagate);
	}
	
	/**
	 * <summary>ファイルのインストールを開始します。</summary>
	 * <param name="srcBinder">インストール元バインダ</param>
	 * <param name="srcPath">インストール元ファイルパス</param>
	 * <param name="dstPath">インストール先ファイルパス</param>
	 * <returns>CriFsInstallRequest</returns>
	 * \par 説明:
	 * バインド済のファイルのインストールを開始します。<br/>
	 * インストール元ファイルパスをsrcPath、インストール先ファイルパスをdstPathで指定します。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * インストールの完了をチェックするには、 ::CriFsInstallRequest::isDone を確認する必要があります。<br/>
	 * インストール処理中にエラーが発生した場合、 ::CriFsInstallRequest::error にエラー情報が格納されます。<br/>
	 * \par 備考:
	 * 第一引数にバインダを指定する点以外は、 ::CriFsUtility::Install(string, string) 関数と同じです。<br/>
	 * （本関数は、CPKファイル内のコンテンツを、ファイルとして書き出す際にのみ使用します。）<br/>
	 * \sa
	 * CriFsInstallRequest, CriFsUtility::Install(string, string)
	 */
	public static CriFsInstallRequest Install(CriFsBinder srcBinder, string srcPath, string dstPath)
	{
		return CriFsServer.instance.Install(srcBinder, srcPath, dstPath, null);
	}
	public static CriFsInstallRequest Install(CriFsBinder srcBinder, string srcPath, string dstPath, CriFsRequest.DoneDelegate doneDeleagate)
	{
		return CriFsServer.instance.Install(srcBinder, srcPath, dstPath, doneDeleagate);
	}
	
	/**
	 * <summary>CPKファイルのバインドを開始します。</summary>
	 * <param name="targetBinder">バインド先バインダ</param>
	 * <param name="srcPath">CPKファイルパス</param>
	 * <returns>CriFsBindRequest</returns>
	 * \par 説明:
	 * CPKファイルのバインドを開始します。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * バインドの完了をチェックするには、 ::CriFsBindRequest::isDone を確認する必要があります。<br/>
	 * バインド処理中にエラーが発生した場合、 ::CriFsBindRequest::error にエラー情報が格納されます。<br/>
	 * <br/>
	 * StreamingAssetsフォルダ以下のデータをバインドする場合は、 ::CriWare::streamingAssetsPath を
	 * ファイルパスの前に連結してください。
	 * \par 例:
	 * ::CriFsUtility::BindCpk 関数、および ::CriFsUtility::LoadFile 
	 * 関数を用いてCPKファイル内のコンテンツを読み込むコードは以下のとおりです。<br/>
	 * \code
	 * private CriFsBinder binder = null;	// バインダ
	 * private uint bindId = 0;				// バインドID
	 * 
	 * void OnEnable()
	 * {
	 * 	// バインダの作成
	 * 	this.binder = new CriFsBinder();
	 * }
	 * 
	 * void OnDisable()
	 * {
	 * 	// アンバインド処理の実行
	 * 	if (this.bindId > 0) {
	 * 		CriFsBinder.Unbind(this.bindId);
	 * 		this.bindId = 0;
	 * 	}
	 * 	
	 * 	// バインダの破棄
	 * 	this.binder.Dispose();
	 * 	this.binder = null;
	 * }
	 * 
	 * IEnumerator UserLoadFileFromCpk(string cpk_path, string content_path)
	 * {
	 * 	// CPKファイルのバインドを開始
	 * 	CriFsBindRequest bind_request = CriFsUtility.BindCpk(this.binder, cpk_path);
	 * 	
	 * 	// バインドの完了を待つ
	 * 	yield return bind_request.WaitForDone(this);
	 * 	
	 * 	// エラーチェック
	 * 	if (bind_request.error != null) {
	 * 		// エラー発生時の処理
	 * 		…
	 * 		yield break;
	 * 	}
	 * 	
	 * 	// CPK内のコンテンツの読み込みを開始
	 * 	CriFsLoadFileRequest load_request = CriFsUtility.LoadFile(this.binder, content_path);
	 * 	
	 * 	// 読み込み完了を待つ
	 * 	yield return load_request.WaitForDone(this);
	 * 	
	 * 	// エラーチェック
	 * 	if (load_request.error != null) {
	 * 		// エラー発生時の処理
	 * 		…
	 * 		yield break;
	 * 	}
	 * 	
	 * 	// 備考）ロードされたファイルの内容は request.bytes 内に格納されています。
	 * }
	 * \endcode
	 * \par 備考:
	 * マルチバインド機能を使用する場合や、CPKファイル内のCPKデータをバインドする場合には、
	 * 本関数の代わりに ::CriFsUtility::BindCpk(CriFsBinder, CriFsBinder, string) 
	 * を使用する必要があります。<br/>
	 * <br/>
	 * パスにURLを指定することで、ネットワーク上のCPKファイルをバインドすることも可能です。<br/>
	 * \code
	 * // crimot.comのsample.cpkをバインド
	 * CriFsLoadFileRequest request = CriFsUtility.LoadFile(
	 * 	"http://crimot.com/sdk/sampledata/crifilesystem/sample.cpk");
	 * \endcode
	 * \attention
	 * CPKコンテンツの情報を取得するタイミングは、バインド時のみです。<br/>
	 * そのため、ネットワーク上のCPKファイルをバインドした場合、
	 * サーバ側でファイルが更新されたとしても、クライアント側では更新を検知することはできません。<br/>
	 * （更新後のCPKファイルに対し意図としないアクセスが発生する可能性があります。）<br/>
	 * \sa
	 * CriFsBindRequest, CriFsUtility::BindCpk(CriFsBinder, CriFsBinder, string)
	 */
	public static CriFsBindRequest BindCpk(CriFsBinder targetBinder, string srcPath)
	{
		return CriFsUtility.BindCpk(targetBinder, null, srcPath);
	}
	
	/**
	 * <summary>CPKファイルのバインドを開始します。</summary>
	 * <param name="targetBinder">バインド先バインダ</param>
	 * <param name="srcBinder">バインドするCPKファイルにアクセスするためのバインダ</param>
	 * <param name="srcPath">CPKファイルパス</param>
	 * <returns>CriFsBindRequest</returns>
	 * \par 説明:
	 * CPKファイルのバインドを開始します。<br/>
	 * ::CriFsUtility::BindCpk(CriFsBinder, string) に加え、
	 * CPKファイル内のサブCPKにアクセスするためのバインダが指定可能です。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * バインドの完了をチェックするには、 ::CriFsBindRequest::isDone を確認する必要があります。<br/>
	 * バインド処理中にエラーが発生した場合、 ::CriFsBindRequest::error にエラー情報が格納されます。<br/>
	 * \sa
	 * CriFsBindRequest, CriFsUtility::BindCpk(CriFsBinder, string)
	 */
	public static CriFsBindRequest BindCpk(CriFsBinder targetBinder, CriFsBinder srcBinder, string srcPath)
	{
		return CriFsServer.instance.BindCpk(targetBinder, srcBinder, srcPath);
	}
	
	/**
	 * <summary>ディレクトリパスのバインドを開始します。</summary>
	 * <param name="targetBinder">バインド先バインダ</param>
	 * <param name="srcPath">バインドするディレクトリのパス名</param>
	 * \par 説明：
	 * ディレクトリパス名をバインドします。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * バインドの完了をチェックするには、 ::CriFsBindRequest::isDone を確認する必要があります。<br/>
	 * バインド処理中にエラーが発生した場合、 ::CriFsBindRequest::error にエラー情報が格納されます。<br/>
	 * <br/>
	 * StreamingAssetsフォルダ以下のディレクトリをバインドする場合は、 ::CriWare::streamingAssetsPath を
	 * ファイルパスの前に連結してください。
	 * \par 備考：
	 * バインド時に指定されたディレクトリが存在するか否かはチェックしていません。<br/>
	 * バインダ内に保持されるのはディレクトリパスだけで、
	 * 指定されたディレクトリ内のファイルをオープン状態にするものではありません。<br/>
	 * \attention
	 * 本関数は開発支援用のデバッグ関数です。<br/>
	 * 本関数を使用した場合、以下の問題が発生する可能性があります。<br/>
	 * - ::CriFsLoader::Load 関数や ::CriFsBinder::GetFileSize 関数内で処理が長時間ブロックされる。<br/>
	 * - バインドしたディレクトリ内のファイルにアクセスする際、音声やムービーのストリーム再生が途切れる。<br/>
	 * \attention
	 * マスターアップ時には本関数をアプリケーション中で使用しないようご注意ください。<br/>
	 * （ディレクトリ内のデータをCPKファイル化して ::CriFsUtility::BindCpk 関数でバインドするか、
	 * またはディレクトリ内のファイルを全て ::CriFsUtility::BindFile 関数でバインドしてください。）<br/>
	 * \sa
	 * CriFsBindRequest, CriFsUtility::BindCpk, CriFsUtility::BindFile
	 */
	public static CriFsBindRequest BindDirectory(CriFsBinder targetBinder, string srcPath)
	{
		return CriFsServer.instance.BindDirectory(targetBinder, null, srcPath);
	}
	
	/**
	 * <summary>ディレクトリパスのバインドを開始します。</summary>
	 * <param name="targetBinder">バインド先バインダ</param>
	 * <param name="srcBinder">バインドするディレクトリにアクセスするためのバインダ</param>
	 * <param name="srcPath">CPKファイルパス</param>
	 * <returns>CriFsBindRequest</returns>
	 * \par 説明:
	 * ディレクトリパスのバインドを開始します。<br/>
	 * ::CriFsUtility::BindDirectory(CriFsBinder, string) に加え、
	 * CPKファイル内のディレクトリにアクセスするためのバインダが指定可能です。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * バインドの完了をチェックするには、 ::CriFsBindRequest::isDone を確認する必要があります。<br/>
	 * バインド処理中にエラーが発生した場合、 ::CriFsBindRequest::error にエラー情報が格納されます。<br/>
	 * \sa
	 * CriFsBindRequest, CriFsUtility::BindDirectory(CriFsBinder, string)
	 */
	public static CriFsBindRequest BindDirectory(CriFsBinder targetBinder, CriFsBinder srcBinder, string srcPath)
	{
		return CriFsServer.instance.BindDirectory(targetBinder, srcBinder, srcPath);
	}
	
	/**
	 * <summary>ファイルをバインドします。</summary>
	 * <param name="targetBinder">バインド先バインダ</param>
	 * <param name="srcPath">バインドするファイルのパス名</param>
	 * <returns>バインドID</returns>
	 * \par 説明:
	 * ファイルのバインドを開始します。<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * バインドの完了をチェックするには、 ::CriFsBindRequest::isDone を確認する必要があります。<br/>
	 * バインド処理中にエラーが発生した場合、 ::CriFsBindRequest::error にエラー情報が格納されます。<br/>
	 * <br/>
	 * StreamingAssetsフォルダ以下のファイルをバインドする場合は、 ::CriWare::streamingAssetsPath を
	 * ファイルパスの前に連結してください。
	 * \par 備考：
	 * 本関数は、ファイルをロードせずにファイルサイズだけを取得したい場合に使用します。<br/>
	 * ファイルをバインド後、 ::CriFsBinder::GetFileSize 関数を実行することで、
	 * ファイルサイズの取得を非同期で行うことが可能となります。<br/>
	 * \par 例：
	 * ::CriFsUtility::BindFile 関数と ::CriFsBinder::GetFileSize 
	 * 関数を用いてファイルサイズを取得するコードは以下のとおりです。<br/>
	 * \code
	 * IEnumerator UserGetFileSize(string path, out long fileSize)
	 * {
	 * 	// ファイルのバインドを開始
	 * 	CriFsBindRequest bind_request = CriFsUtility.BindFile(path);
	 * 	
	 * 	// バインドの完了を待つ
	 * 	yield return bind_request.WaitForDone(this);
	 * 	
	 * 	// エラーチェック
	 * 	if (bind_request.error != null) {
	 * 		// エラー発生時の処理
	 * 		…
	 * 		yield break;
	 * 	}
	 * 	
	 * 	// ファイルサイズの取得
	 * 	fileSize = bind_request.binder.GetFileSize();
	 * }
	 * \endcode
	 * \sa
	 * CriFsBindRequest, CriFsBinder::GetFileSize
	 */
	public static CriFsBindRequest BindFile(CriFsBinder targetBinder, string srcPath)
	{
		return CriFsServer.instance.BindFile(targetBinder, null, srcPath);
	}
	
	/**
	 * <summary>ファイルのバインドを開始します。</summary>
	 * <param name="targetBinder">バインド先バインダ</param>
	 * <param name="srcBinder">バインドするファイルにアクセスするためのバインダ</param>
	 * <param name="srcPath">ファイルパス</param>
	 * <returns>CriFsBindRequest</returns>
	 * \par 説明:
	 * ファイルのバインドを開始します。<br/>
	 * ::CriFsUtility::BindFile(CriFsBinder, string) に加え、
	 * CPKファイル内のファイルにアクセスするためのバインダが指定可能です<br/>
	 * <br/>
	 * 本関数は即時復帰関数です。<br/>
	 * バインドの完了をチェックするには、 ::CriFsBindRequest::isDone を確認する必要があります。<br/>
	 * バインド処理中にエラーが発生した場合、 ::CriFsBindRequest::error にエラー情報が格納されます。<br/>
	 * \sa
	 * CriFsBindRequest, CriFsUtility::BindFile(CriFsBinder, string)
	 */
	public static CriFsBindRequest BindFile(CriFsBinder targetBinder, CriFsBinder srcBinder, string srcPath)
	{
		return CriFsServer.instance.BindFile(targetBinder, srcBinder, srcPath);
	}
	
	/**
	 * <summary>HTTPリクエストで使用するUser-Agent文字列を指定します。</summary>
	 * <param name="userAgentString">User-Agent文字</param>
	 * \par 説明:
	 * HTTPリクエスト時のUser-Agent文字列を指定します。<br/>
	 * 未指定の場合、下位ファイルシステムモジュールのバージョン文字が指定されています。<br/>
	 * User-Agent文字は255文字(255バイト)以下で指定してください。<br/>
     */
	public static void SetUserAgentString(string userAgentString)
	{
		/* 初期化処理 */
		CriFsPlugin.InitializeLibrary();
		/* User-Agent文字列を指定 */
		criFsUnity_SetUserAgentString(userAgentString);
	}
	
	/**
	 * <summary>HTTPリクエストで使用するプロキシサーバを指定します。</summary>
	 * <param name="proxyPath">プロキシサーバアドレス</param>
	 * <param name="proxy_port">プロキシサーバポート番号</param>
	 * \par 説明：
	 * HTTP I/OのHTTPリクエスト時に利用するプロキシサーバアドレスを指定します。<br>
	 * proxyPathは256文字以下で指定してください。<br>
	 */
	public static void SetProxyServer(string proxyPath, UInt16 proxyPort)
	{
		/* 初期化処理 */
		CriFsPlugin.InitializeLibrary();
		/* プロキシ設定 */
		criFsUnity_SetProxyServer(proxyPath, proxyPort);
	}

	#region Native API Definition (DLL)
	// CRI File System Unity

	[DllImport(CriWare.pluginName)]
	private static extern bool criFsUnity_SetUserAgentString(string userAgentString);
	
	[DllImport(CriWare.pluginName)]
	private static extern bool criFsUnity_SetProxyServer(string proxyPath, UInt16 proxyPort);
	#endregion
}

public static class CriFsPlugin
{
	/* 初期化カウンタ */
	private static int initializationCount = 0;
	
	
	public static int defaultInstallBufferSize   = (4 * 1024 * 1024); // 4.0 Mb
	public static int installBufferSize         = defaultInstallBufferSize;
	
	public static bool isInitialized { get { return initializationCount > 0; } }
	
	public static void SetConfigParameters(
		int num_loaders, int num_binders, int num_installers, int argInstallBufferSize, int max_path, bool minimize_file_descriptor_usage)
	{
		CriFsPlugin.criFsUnity_SetConfigParameters(
			num_loaders, num_binders, num_installers, max_path, minimize_file_descriptor_usage);
		installBufferSize = argInstallBufferSize;
	}

	public static void SetConfigAdditionalParameters_ANDROID(
		int device_read_bps)
	{
#if !UNITY_EDITOR && UNITY_ANDROID
		CriFsPlugin.criFsUnity_SetConfigAdditionalParameters_ANDROID(device_read_bps);
#endif
	}

	public static void SetMemoryFileSystemThreadPriorityExperimentalAndroid(int prio)
	{
#if !UNITY_EDITOR && UNITY_ANDROID
		CriFsPlugin.criFsUnity_SetMemoryFileSystemThreadPriority_ANDROID(prio);
#endif
	}

	public static void SetDataDecompressionThreadPriorityExperimentalAndroid(int prio)
	{
#if !UNITY_EDITOR && UNITY_ANDROID
		CriFsPlugin.criFsUnity_SetDataDecompressionThreadPriority_ANDROID(prio);
#endif
	}

	public static void InitializeLibrary()
	{
		/* 初期化カウンタの更新 */
		CriFsPlugin.initializationCount++;
		if (CriFsPlugin.initializationCount != 1) {
			return;
		}
		
		/* CriWareInitializerが実行済みかどうかを確認 */
		bool initializerWorking = CriWareInitializer.IsInitialized();
		if (initializerWorking == false) {
			Debug.Log("[CRIWARE] CriWareInitializer is not working. "
				+ "Initializes FileSystem by default parameters.");
		}

		/* ライブラリの初期化 */
		CriFsPlugin.criFsUnity_Initialize();
	}

	public static void FinalizeLibrary()
	{
		/* 初期化カウンタの更新 */
		CriFsPlugin.initializationCount--;
		if (CriFsPlugin.initializationCount < 0) {
			Debug.LogError("[CRIWARE] ERROR: FileSystem library is already finalized.");
			return;
		}
		if (CriFsPlugin.initializationCount != 0) {
			return;
		}
		
		/* CriFsServerのインスタンスが存在すれば破棄 */
		CriFsServer.DestroyInstance();
		
		/* パラメータを初期値に戻す */
		installBufferSize = defaultInstallBufferSize;
		
		/* ライブラリの終了 */
		CriFsPlugin.criFsUnity_Finalize();
	}
	
    #region Native API Definition (DLL)
	// CRI File System Unity
	[DllImport(CriWare.pluginName)]
	private static extern void criFsUnity_SetConfigParameters(
		int num_loaders, int num_binders, int num_installers, int max_path, bool minimize_file_descriptor_usage);

	[DllImport(CriWare.pluginName)]
	private static extern void criFsUnity_Initialize();

	[DllImport(CriWare.pluginName)]
	private static extern void criFsUnity_Finalize();
	
	[DllImport(CriWare.pluginName)]
	public static extern uint criFsUnity_GetAllocatedHeapSize();

	[DllImport(CriWare.pluginName)]
	public static extern UInt32 criFsLoader_GetRetryCount();

	#if !UNITY_EDITOR && UNITY_ANDROID
	[DllImport(CriWare.pluginName)]
	private static extern void criFsUnity_SetConfigAdditionalParameters_ANDROID(int device_read_bps);

	[DllImport(CriWare.pluginName)]
	public static extern void criFsUnity_SetMemoryFileSystemThreadPriority_ANDROID(int prio);

	[DllImport(CriWare.pluginName)]
	public static extern void criFsUnity_SetDataDecompressionThreadPriority_ANDROID(int prio);
	#endif

    #endregion
}

/**
 * @}
 */

/* --- end of file --- */
