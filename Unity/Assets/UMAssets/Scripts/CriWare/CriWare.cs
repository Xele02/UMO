/****************************************************************************
 *
 * Copyright (c) 2012 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/

using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using System.IO;

/**
 * \addtogroup CRIWARE_COMMON_CLASS
 * @{
 */

namespace CriWare {

/**
 * <summary>CRIWAREプラグインに関する補助的な機能を提供するクラスです。</summary>
 * <remarks>
 * <para header='説明'>各プラットフォーム共通で利用できる補助メソッドを提供します。<br/>
 * 本クラスのプロパティやメソッドを利用すれば、特殊なデータフォルダへのパス取得や
 * CRIWAREプラグインによるCPU / メモリの使用状況を確認できます。</para>
 * </remarks>
 */

public class Common
{
	/* スクリプトバージョン */
	private const string scriptVersionString = "2.37.13LE";
	private const int scriptVersionNumber = 0x02371300;

	/**
	 * <summary>CriFsInstaller APIをサポートしているか</summary>
	 * <remarks>
	 * <para header='説明'>CriFsInstaller APIが実行環境上で使用可能かどうかを判定するために使用します。</para>
	 * </remarks>
	 */
	public const bool supportsCriFsInstaller =
	#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_IOS || UNITY_TVOS || UNITY_ANDROID || UNITY_WINRT
		true;
	#else
		false;
	#endif

	/**
	 * <summary>CriFsWebInstaller APIをサポートしているか</summary>
	 * <remarks>
	 * <para header='説明'>CriFsWebInstaller APIが実行環境上で使用可能かどうかを判定するために使用します。</para>
	 * </remarks>
	 */
	public const bool supportsCriFsWebInstaller =
	#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_ANDROID
		true;
	#else
		false;
	#endif

	/* ネイティブライブラリ */
	#if UNITY_EDITOR
		public const string pluginName = "cri_ware_unity";
	#elif UNITY_IOS || UNITY_TVOS || UNITY_WEBGL
		public const string pluginName = "__Internal";
	#else
		public const string pluginName = "cri_ware_unity";
	#endif

    #if ENABLE_IL2CPP && (UNITY_STANDALONE_WIN || UNITY_WINRT)
        public const CallingConvention pluginCallingConvention = CallingConvention.Cdecl;
    #else
        public const CallingConvention pluginCallingConvention = CallingConvention.Winapi;  /* default */
    #endif

	/**
	 * <summary>StreamingAssetsフォルダのパスです。</summary>
	 * <remarks>
	 * <para header='説明'>本プロパティはStreamingAssetsフォルダのパスを返します。値のsetはできません。</para>
	 * <para header='注意'>Android環境の場合、本プロパティは空文字列を返します。
	 * CRIWAREプラグインの機能でStreamingAssets内のファイルにアクセスする際は
	 * Android環境に限り、StreamingAssets以下の相対パスを直接指定してください。
	 * この時、パスの先頭に"/"が入らないよう注意してください。</para>
	 * </remarks>
	 */
	public static string streamingAssetsPath
	{
		get {
			if (Application.platform == RuntimePlatform.Android) {
				return "";
			}
			else {
				return Application.streamingAssetsPath;
			}
		}
	}

	/**
	 * <summary>データフォルダのパスです。</summary>
	 * <remarks>
	 * <para header='説明'>本プロパティはデータフォルダのパスを返します。値のsetはできません。</para>
	 * <para header='注意'>iOS環境の場合、本フォルダへファイルの書き込みは、
	 * AppStoreの審査で問題になる可能性があります。<br/></para>
	 * </remarks>
	 */
	public static string installTargetPath
	{
		get {
			if (Application.platform == RuntimePlatform.IPhonePlayer) {
				return Application.temporaryCachePath;
			} else {
	#if UNITY_EDITOR
				return Application.persistentDataPath;
	#else
				return null;
	#endif
			}
		}
	}

	/**
	 * <summary>StreamingAssetsフォルダからの相対パスとして利用されるかを判定します。</summary>
	 * <param name='path'>ファイルパス</param>
	 * <returns>StreamingAssetsフォルダからの相対パスとして利用されるか</returns>
	 * <remarks>
	 * <para header='説明'>pathがCRIWAREプラグインでStreamingAssetsフォルダからの相対パスとして利用されるかを判定します。<br/>
	 * CRIWAREプラグインでは以下の条件をすべて満たすものをStreamingAssetsフォルダからの相対パスとして利用します。
	 *   - 絶対パスではない
	 *   - ':'を含まない</para>
	 * <para header='注意'>実際にStreamingAssetsフォルダからの相対パスとして利用されるかは、各APIのリファレンスを参照してください。</para>
	 * </remarks>
	 */
	public static bool IsStreamingAssetsPath(string path)
	{
		return !Path.IsPathRooted(path) && (path.IndexOf(':') < 0);
	}

	private static GameObject _managerObject = null;
	public static GameObject managerObject
	{
		get {
			if (_managerObject == null) {
				_managerObject = GameObject.Find("/CRIWARE");
				if (_managerObject == null) {
					_managerObject = new GameObject("CRIWARE");
				}
			}
			return _managerObject;
		}
	}

	/**
	 * <summary>スクリプトバージョン文字列の取得</summary>
	 * <remarks>
	 * <para header='説明'>本メソッドはCRIWAREのスクリプトバージョン文字列を返します。</para>
	 * </remarks>
	 */
	 public static string GetScriptVersionString() {
		return scriptVersionString;
	}

	/**
	 * <summary>スクリプトバージョン番号の取得</summary>
	 * <remarks>
	 * <para header='説明'>本メソッドはCRIWAREのスクリプトバージョン番号を返します。</para>
	 * </remarks>
	 */
	public static int GetScriptVersionNumber() {
		return scriptVersionNumber;
	}

	/**
	 * <summary>バイナリバージョン番号の取得</summary>
	 * <remarks>
	 * <para header='説明'>本メソッドはCRIWAREのバイナリバージョン番号を返します。
	 * ここでのバイナリとは、CRIWAREプラグインに含まれるライブラリファイル(.dll等)を指します。</para>
	 * </remarks>
	 */
	public static int GetBinaryVersionNumber() {
		return criWareUnity_GetVersionNumber();
	}

	/**
	 * <summary>スクリプトが要求するバイナリバージョンの取得</summary>
	 * <remarks>
	 * <para header='説明'>本メソッドはCRIWAREスクリプトが要求するランタイムバージョン番号を返します。</para>
	 * </remarks>
	 */
	public static int GetRequiredBinaryVersionNumber() {
#if true
		return 0x02371300;
#else
#if UNITY_EDITOR
		switch (Application.platform) {
			case RuntimePlatform.WindowsEditor:
				return 0x02371300;
			case RuntimePlatform.OSXEditor:
				return 0x02371300;
			default:
				return 0x02371300;
		}
#elif UNITY_STANDALONE_WIN
		return 0x02371300;
#elif UNITY_STANDALONE_OSX
		return 0x02371300;
#elif UNITY_IOS
		return 0x02371300;
#elif UNITY_TVOS
		return 0x02371300;
#elif UNITY_ANDROID
		return 0x02371300;
#else
		return 0x02371300
#endif
#endif
    }

    /**
	 * <summary>バイナリバージョンとスクリプトバージョンの整合性チェック</summary>
	 * <remarks>
	 * <para header='説明'>本メソッドは現在のバイナリがスクリプトの要求するバージョン番号と一致するかチェックします。<br/>
	 * 一致していれば整合性チェックに成功とみなし、trueを返します。<br/>
	 * 不一致であれば失敗とみなし、コンソールにエラーメッセージを出力した後でfalseを返します。</para>
	 * </remarks>
	 */
    public static bool CheckBinaryVersionCompatibility() {
		if (GetBinaryVersionNumber() == GetRequiredBinaryVersionNumber()) {
			return true;
		} else {
			Debug.LogError("CRI runtime library is not compatible. Confirm the version number.");
			return false;
		}
	}

	/**
	 * <summary>CRI FileSystemのメモリ使用量の取得</summary>
	 * <remarks>
	 * <para header='説明'>本メソッドはCRI FileSystemのメモリ使用量を返します。</para>
	 * </remarks>
	 */
	public static uint GetFsMemoryUsage()
	{
		return CriFsPlugin.criFsUnity_GetAllocatedHeapSize();
	}

	/**
	 * <summary>CRI Atomのメモリ使用量の取得</summary>
	 * <remarks>
	 * <para header='説明'>本メソッドはCRI Atomのメモリ使用量を返します。</para>
	 * </remarks>
	 */
	public static uint GetAtomMemoryUsage()
	{
		return CriAtomPlugin.criAtomUnity_GetAllocatedHeapSize();
	}

	/**
	 * <summary>CRI Manaのメモリ使用量の取得</summary>
	 * <remarks>
	 * <para header='説明'>本メソッドはCRI Manaのメモリ使用量を返します。</para>
	 * </remarks>
	 */
	public static uint GetManaMemoryUsage()
	{
#if !UNITY_EDITOR && UNITY_WEBGL
		return 0;
#else
		return CriManaPlugin.criManaUnity_GetAllocatedHeapSize();
#endif
	}

	/**
	 * <summary>CRIWAREプラグインのCPU使用状況</summary>
	 */
	public struct CpuUsage
	{
		public float last;
		public float average;
		public float peak;
	}

	/**
	 * <summary>CRIWAREプラグインのCPU使用状況の取得</summary>
	 * <remarks>
	 * <para header='説明'>本メソッドはCRIWAREプラグインのネイティブライブラリによる
	 * CPU使用状況を返します。戻り値はCpuUsage構造体です。</para>
	 * </remarks>
	 */
	 public static CpuUsage GetAtomCpuUsage()
	{
		return CriAtomPlugin.GetCpuUsage();
	}

	#region DLL Import
	#if !CRIWARE_ENABLE_HEADLESS_MODE
	[DllImport(pluginName, CallingConvention = pluginCallingConvention)]
	public static extern int criWareUnity_GetVersionNumber();

	#else
	public static int criWareUnity_GetVersionNumber() { return GetRequiredBinaryVersionNumber(); }
	#endif
	#endregion

} // end of class

} //namespace CriWare
/** @} */

/* --- end of file --- */
