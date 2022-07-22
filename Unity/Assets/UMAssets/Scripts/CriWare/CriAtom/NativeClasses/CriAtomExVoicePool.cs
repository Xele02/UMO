/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2011 CRI Middleware Co., Ltd.
 *
 * Library  : CRI Atom
 * Module   : CRI Atom Native Wrapper
 * File     : CriAtomExVoicePool.cs
 *
 ****************************************************************************/
using System;
using System.Runtime.InteropServices;

/*==========================================================================
 *      CRI Atom Native Wrapper
 *=========================================================================*/
/**
 * \addtogroup CRIATOM_NATIVE_WRAPPER
 * @{
 */


/**
 * <summary>ボイスプールの制御を行うためのクラスです。</summary>
 * \par 説明:
 * ボイスプールの制御を行うためのクラスです。<br/>
 */
public class CriAtomExVoicePool
{
	/* @cond DOXYGEN_IGNORE */
	public const int StandardMemoryAsrVoicePoolId		= 0;	/**< ASRによる標準メモリ再生ボイスプールID */
	public const int StandardStreamingAsrVoicePoolId	= 1;	/**< ASRによる標準ストリーミング再生ボイスプールをID */
	public const int StandardMemoryNsrVoicePoolId		= 2;	/**< NSRによる標準メモリ再生ボイスプールID */
	public const int StandardStreamingNsrVoicePoolId	= 3;	/**< NSRによる標準ストリーミング再生ボイスプールID */
	/* @endcond */
	
	/**
	 * <summary>プラグイン内部で生成するボイスプールへアクセスするためのID</summary>
	 * \sa CriAtomExVoicePool.GetNumUsedVoices
	 */
	public enum VoicePoolId
	{
		/* 機種共通のボイスプールID */
#if UNITY_EDITOR || UNITY_STANDALONE_WIN  || UNITY_STANDALONE_OSX || UNITY_ANDROID || UNITY_IOS || UNITY_TVOS || UNITY_WIIU || UNITY_PS3 || UNITY_PS4 || UNITY_WINRT || UNITY_WEBGL
		StandardMemory			= StandardMemoryAsrVoicePoolId,		/**< 機種標準のメモリ再生ボイスプールID */
		StandardStreaming		= StandardStreamingAsrVoicePoolId,	/**< 機種標準のストリーミング再生ボイスプールID */
#elif UNITY_PSP2
		StandardMemory			= StandardMemoryNsrVoicePoolId,		/**< 機種標準のメモリ再生ボイスプールID */
		StandardStreaming		= StandardStreamingNsrVoicePoolId,	/**< 機種標準のストリーミング再生ボイスプールID */
#else
		#error unsupported platform
#endif
		HcaMxMemory				= 4,								/**< HCA-MXメモリ再生ボイスプールID */
		HcaMxStreaming			= 5,								/**< HCA-MXストリーミング再生ボイスプールID */
		
		/* 機種固有のボイスプールID */
#if UNITY_EDITOR || UNITY_STANDALONE_WIN  || UNITY_STANDALONE_OSX || UNITY_IOS || UNITY_TVOS || UNITY_PS3 || UNITY_WINRT || UNITY_WEBGL
#elif UNITY_ANDROID
		LowLatencyMemory		= StandardMemoryNsrVoicePoolId,		/**< [Android] 低遅延メモリ再生ボイスプールID */
		LowLatencyStreaming		= StandardStreamingNsrVoicePoolId,	/**< [Android] 低遅延ストリーミング再生ボイスプールID */
#elif UNITY_WIIU
		StandardMemoryNsr		= StandardMemoryNsrVoicePoolId,		/**< [Wii U] NSRによる標準メモリ再生ボイスプールID */
		StandardStreamingNsr	= StandardStreamingNsrVoicePoolId,	/**< [Wii U] NSRによる標準ストリーミング再生ボイスプールID */
		AdpcmMemory				= 6,								/**< [Wii U] ADPCMメモリ再生ボイスプールID */
#elif UNITY_PSP2
		Atrac9Memory			= 6,								/**< [VITA] ATRAC9メモリ再生ボイスプールID */	
		Atrac9Streaming			= 7,								/**< [VITA] ATRAC9ストリーミング再生ボイスプールID */
#elif UNITY_PS4
		Atrac9Memory			= 6,								/**< [PS4] ATRAC9メモリ再生ボイスプールID */	
		Atrac9Streaming			= 7,								/**< [PS4] ATRAC9ストリーミング再生ボイスプールID */
#else
		#error unsupported platform
#endif
	}
	
	/**
	 * <summary>ボイスプールのボイス使用状況を表すための構造体</summary>
	 * \sa CriAtomExVoicePool.GetNumUsedVoices
	 */
	public struct UsedVoicesInfo
	{
		public int numUsedVoices;	/**< 使用中のボイス数 */
		public int numPoolVoices;	/**< ボイスプールのボイス数 */
	}
	
	/**
	 * <summary>ボイスプールのボイス使用状況取得</summary>
	 * <param name="voicePoolId">DSPバス設定の名前</param>
	 * <returns>ボイス使用状況</returns>
	 * \par 説明:
	 * 指定されたボイスプールのボイス使用状況を取得します。
	 * \attention
	 * 本関数はデバッグ目的でのみ使用してください。
	 * \sa CriAtomExVoicePool::VoicePoolId, CriAtomExVoicePool::UsedVoicesInfo
	 */
	static public UsedVoicesInfo GetNumUsedVoices(VoicePoolId voicePoolId)
	{
		UsedVoicesInfo info;
		criAtomUnity_GetNumUsedVoices((int)voicePoolId, out info.numUsedVoices, out info.numPoolVoices);
		return info;
	}

	#region DLL Import

	[DllImport(CriWare.pluginName)]
	private static extern void criAtomUnity_GetNumUsedVoices(int voice_pool_id, out int num_used_voices, out int num_pool_voices);

	[DllImport(CriWare.pluginName)]
	public static extern void criAtomExVoicePool_Free(IntPtr pool);

	#endregion
}

/**
 * @}
 */

/* --- end of file --- */
