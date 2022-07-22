/****************************************************************************
  *
  * CRI Middleware SDK
  *
  * Copyright (c) 2011-2015 CRI Middleware Co., Ltd.
  *
  * Library  : CRI Mana
  * Module   : CRI Mana for Unity
  * File     : CriManaPlayerTextureHolder.cs
  *
  ****************************************************************************/

/*--------------------
 * Rendering Defines
 *--------------------*/
#if (UNITY_3_1 || UNITY_3_2 || UNITY_3_3 || UNITY_3_4 || UNITY_3_5)
	#error unsupported unity version
#else
	#if UNITY_EDITOR || UNITY_STANDALONE_WIN  || UNITY_STANDALONE_OSX || UNITY_ANDROID || UNITY_IOS || UNITY_TVOS || UNITY_PSP2 || UNITY_PS4 || UNITY_WEBGL
		#define CRIMANAPLAYER_USE_TEXTURE_HOLDER_BY_TEX_PTR
	#elif UNITY_WIIU || UNITY_PS3 || UNITY_WINRT
		#define CRIMANAPLAYER_USE_TEXTURE_HOLDER_FORWARD_RGB
	#else
		#error unsupported platform
	#endif
#endif


using UnityEngine;
using System;
using System.Collections;
using System.Runtime.InteropServices;


namespace CriManaPlayerDetail
{




	public abstract class TextureHolder
	{
		public    readonly int   width;
		public    readonly int   height;
		public    readonly bool  isAlphaMode;
		
		private            float offsetTexels;

		protected readonly uint  texNumber;
		protected          uint  texIndex = 0;
		
		protected TextureHolder(int argWidth, int argHeight, uint argTexNumber, bool alphaMode, float argOffsetTexels)
		{
			/* aligne texture size */
			#if CRIMANAPLAYER_USE_TEXTURE_HOLDER_FORWARD_RGB
			width  = ceiling8(argWidth);
			height = ceiling8(argHeight); 
			#elif CRIMANAPLAYER_USE_TEXTURE_HOLDER_BY_TEX_PTR
				#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_PSP2 || UNITY_PS4 || UNITY_WINRT || UNITY_WEBGL
				width  = ceiling256(argWidth);
				height = ceiling16(argHeight);
				#elif UNITY_ANDROID || UNITY_IOS || UNITY_TVOS
				width  = next_pot_size(ceiling64(argWidth));
				height = next_pot_size(ceiling16(argHeight));
				#else
					#error unsupported platform
				#endif
			#else
				#error unsupported platform
			#endif

			texNumber    = argTexNumber;
			isAlphaMode  = alphaMode;
			offsetTexels = argOffsetTexels;
		}

		public bool IsAvailable(int argWidth, int argHeight, uint argTexNumber, bool alphaMode)
		{
			return (width >= argWidth) && (height >= argHeight) && (texNumber == argTexNumber) && (isAlphaMode == alphaMode);
		}

		public void SetTextureConfig(Material material, int argWidth, int argHeight, bool flipTopBottom, bool flipLeftRight)
		{
			float offsetU = offsetTexels / width;
			float offsetV = offsetTexels / height;
			float sizeU   = (float)argWidth  / width;
			float sizeV   = (float)argHeight / height;
			float scaleX, scaleY, offsetX, offsetY;
			if (flipLeftRight) {
				offsetX = sizeU - offsetU;
				scaleX  = -sizeU + offsetU;
			} else {
				offsetX = 0.0f;
				scaleX  = sizeU - offsetU;
			}
			if (flipTopBottom) {
				offsetY = 0.0f;
				scaleY  = sizeV - offsetV;
			} else {
				offsetY = sizeV - offsetV;
				scaleY  = -sizeV + offsetV;
			}
			material.mainTextureScale  = new Vector2(scaleX, scaleY);
			material.mainTextureOffset = new Vector2(offsetX, offsetY);
		}
		
		public abstract IEnumerator CreateTexture();
		public abstract bool UpdateTexture(UnityEngine.Material material, int playerId, CriManaPlayer.FrameInfo frameInfo);
		public abstract void DestroyTexture();

		private static uint next_pot_size(uint x)
		{
			x = x - 1;
			x = x | (x >> 1);
			x = x | (x >> 2);
			x = x | (x >> 4);
			x = x | (x >> 8);
			x = x | (x >>16);
			return x + 1;
		}
		
		private static int next_pot_size(int x)
		{
			return (int)next_pot_size((uint)x);
		}
		
		private static int ceiling8(int x)
		{
			return (x+7)& -8;
		}
		
		private static int ceiling16(int x)
		{
			return (x+15)& -16;
		}
		
		private static int ceiling64(int x)
		{
			return (x+63)& -64;
		}

		private static int ceiling256(int x)
		{
			return (x+255)& -256;
		}
		
		public static TextureHolder Create(int reservedWidth, int reservedHeight, uint texNumber, bool alphaMode)
		{
		#if CRIMANAPLAYER_USE_TEXTURE_HOLDER_FORWARD_RGB
			return new TextureHolderForwardRgb(reservedWidth, reservedHeight, texNumber, alphaMode);
		#elif CRIMANAPLAYER_USE_TEXTURE_HOLDER_BY_TEX_PTR
			if (alphaMode) {
				return new TextureHolderByTexPtrWithAlpha(reservedWidth, reservedHeight, texNumber, alphaMode);
			}
			else {
				return new TextureHolderByTexPtr(reservedWidth, reservedHeight, texNumber, alphaMode);
			}
		#else
			#error unsupported platform
		#endif
		}
	}




	#if CRIMANAPLAYER_USE_TEXTURE_HOLDER_BY_TEX_PTR
	class TextureHolderByTexPtr : TextureHolder
	{
		/*
		 * bilinear補間を使うと、画像の縁の部分で領域外の値を用いて補間を行ってしまいます。
		 * 領域外の値で補間されないようにするには、0.5ピクセル分クリップする必要があります。
		 * また、シェーダを用いたYUV422からの色変換では、UチャネルおよびVチャネルのサイズが
		 * Yチャネルの半分であるため、UチャネルおよびVチャネルが領域外の値で補間されないために、
		 * Yチャネルで1ピクセル分クリップする必要があります。
		 */
		const float constOffsetTexels = 1.0f;

		private Texture2D[] m_Texture_y;
		private Texture2D[] m_Texture_u;
		private Texture2D[] m_Texture_v;

		public TextureHolderByTexPtr(int argWidth, int argHeight, uint argTexNumber, bool alphaMode)
			: base(argWidth, argHeight, argTexNumber, false, constOffsetTexels)
		{}

		public override IEnumerator CreateTexture()
		{
			m_Texture_y = new Texture2D[texNumber];
			m_Texture_u = new Texture2D[texNumber];
			m_Texture_v = new Texture2D[texNumber];

			for (int i = 0; i < texNumber; i++) {
				m_Texture_u[i] = new Texture2D(width / 2, height / 2, TextureFormat.Alpha8, false);
				m_Texture_u[i].wrapMode = TextureWrapMode.Clamp;
				m_Texture_v[i] = new Texture2D(width / 2, height / 2, TextureFormat.Alpha8, false);
				m_Texture_v[i].wrapMode = TextureWrapMode.Clamp;
				yield return false;
				m_Texture_y[i] = new Texture2D(width, height, TextureFormat.Alpha8, false);
				m_Texture_y[i].wrapMode = TextureWrapMode.Clamp;
				if ((i + 1) != texNumber) {
					yield return false;
				}
			}
		}

		public override bool UpdateTexture(UnityEngine.Material material, int playerId, CriManaPlayer.FrameInfo frameInfo)
		{
			bool updated = CriManaPlayer.criManaUnityPlayer_UpdateTextureYuvByPtr_APIv1(
						 playerId,
						 m_Texture_y[texIndex].GetNativeTexturePtr(),
						 m_Texture_u[texIndex].GetNativeTexturePtr(),
						 m_Texture_v[texIndex].GetNativeTexturePtr(),
						 frameInfo
				);
			if (updated) {
				// Set the writtern texture as the target
				material.SetTexture("Texture_y", m_Texture_y[texIndex]);
				material.SetTexture("Texture_u", m_Texture_u[texIndex]);
				material.SetTexture("Texture_v", m_Texture_v[texIndex]);
				// Switch the write index of texture to the next
				texIndex = (texIndex + 1) % texNumber;
			}
			return updated;
		}

		public override void DestroyTexture()
		{
			for (int i = 0; i < texNumber; i++) {
				Texture2D.Destroy(m_Texture_y[i]);
				Texture2D.Destroy(m_Texture_u[i]);
				Texture2D.Destroy(m_Texture_v[i]);
			}
			m_Texture_y = null;
			m_Texture_u = null;
			m_Texture_v = null;
		}
	}




	class TextureHolderByTexPtrWithAlpha : TextureHolder
	{
		/*
		 * bilinear補間を使うと、画像の縁の部分で領域外の値を用いて補間を行ってしまいます。
		 * 領域外の値で補間されないようにするには、0.5ピクセル分クリップする必要があります。
		 * また、シェーダを用いたYUV422からの色変換では、UチャネルおよびVチャネルのサイズが
		 * Yチャネルの半分であるため、UチャネルおよびVチャネルが領域外の値で補間されないために、
		 * Yチャネルで1ピクセル分クリップする必要があります。
		 */
		const float constOffsetTexels = 1.0f;

		private Texture2D[] m_Texture_y;
		private Texture2D[] m_Texture_u;
		private Texture2D[] m_Texture_v;
		private Texture2D[] m_Texture_a;

		public TextureHolderByTexPtrWithAlpha(int argWidth, int argHeight, uint argTexNumber, bool alphaMode)
			: base(argWidth, argHeight, argTexNumber, true, constOffsetTexels)
		{}

		public override IEnumerator CreateTexture()
		{
			m_Texture_y = new Texture2D[texNumber];
			m_Texture_u = new Texture2D[texNumber];
			m_Texture_v = new Texture2D[texNumber];
			m_Texture_a = new Texture2D[texNumber];

			for (int i = 0; i < texNumber; i++) {
				m_Texture_u[i] = new Texture2D(width / 2, height / 2, TextureFormat.Alpha8, false);
				m_Texture_u[i].wrapMode = TextureWrapMode.Clamp;
				m_Texture_v[i] = new Texture2D(width / 2, height / 2, TextureFormat.Alpha8, false);
				m_Texture_v[i].wrapMode = TextureWrapMode.Clamp;
				yield return false;
				m_Texture_y[i] = new Texture2D(width, height, TextureFormat.Alpha8, false);
				m_Texture_y[i].wrapMode = TextureWrapMode.Clamp;
				yield return false;
				m_Texture_a[i] = new Texture2D(width, height, TextureFormat.Alpha8, false);
				m_Texture_a[i].wrapMode = TextureWrapMode.Clamp;
				if ((i + 1) != texNumber) {
					yield return false;
				}
			}
		}

		public override bool UpdateTexture(UnityEngine.Material material, int playerId, CriManaPlayer.FrameInfo frameInfo)
		{
			bool updated = CriManaPlayer.criManaUnityPlayer_UpdateTextureYuvaByPtr_APIv1(
						 playerId,
						 m_Texture_y[texIndex].GetNativeTexturePtr(),
						 m_Texture_u[texIndex].GetNativeTexturePtr(),
						 m_Texture_v[texIndex].GetNativeTexturePtr(),
						 m_Texture_a[texIndex].GetNativeTexturePtr(),
						 frameInfo
				);
			if (updated) {
				// Set the writtern texture as the target
				material.SetTexture("Texture_y", m_Texture_y[texIndex]);
				material.SetTexture("Texture_u", m_Texture_u[texIndex]);
				material.SetTexture("Texture_v", m_Texture_v[texIndex]);
				material.SetTexture("Texture_a", m_Texture_a[texIndex]);
				// Switch the write index of texture to the next
				texIndex = (texIndex + 1) % texNumber;
			}
			return updated;
		}

		public override void DestroyTexture()
		{
			for (int i = 0; i < texNumber; i++) {
				Texture2D.Destroy(m_Texture_y[i]);
				Texture2D.Destroy(m_Texture_u[i]);
				Texture2D.Destroy(m_Texture_v[i]);
				Texture2D.Destroy(m_Texture_a[i]);
			}
			m_Texture_y = null;
			m_Texture_u = null;
			m_Texture_v = null;
			m_Texture_a = null;
		}
	}
	#endif




	#if CRIMANAPLAYER_USE_TEXTURE_HOLDER_FORWARD_RGB
	class TextureHolderForwardRgb : TextureHolder
	{
		/*
		 * bilinear補間を使うと、画像の縁の部分で領域外の値を用いて補間を行ってしまいます。
		 * 領域外の値で補間されないようにするには、0.5ピクセル分クリップする必要があります。
		 */
		const float constOffsetTexels = 0.5f;

		private Texture2D[] m_Texture;
		private Color32[][] m_Pixels;
		private GCHandle[]  m_PixelsHandle;

		public TextureHolderForwardRgb(int argWidth, int argHeight, uint argTexNumber, bool alphaMode)
			: base(argWidth, argHeight, argTexNumber, alphaMode, constOffsetTexels)
		{}
		
		public override IEnumerator CreateTexture()
		{
			m_Texture	   = new Texture2D[texNumber];
			m_Pixels	   = new Color32[texNumber][];
			m_PixelsHandle = new GCHandle[texNumber];

			for (int i = 0; i < texNumber; i++) {
				m_Texture[i] = new Texture2D(width, height, TextureFormat.ARGB32, false);
				m_Texture[i].wrapMode = TextureWrapMode.Clamp;
				// "pin" the array in memory, so we can pass direct pointer to it's data to the plugin,
				// without costly marshaling of array of structures.
				m_Pixels[i] = m_Texture[i].GetPixels32(0);
				m_PixelsHandle[i] = GCHandle.Alloc(m_Pixels[i], GCHandleType.Pinned);
				if ((i + 1) != texNumber) {
					yield return false;
				}
			}
		}

		public override bool UpdateTexture(UnityEngine.Material material, int playerId, CriManaPlayer.FrameInfo frameInfo)
		{
			bool updated = CriManaPlayer.criManaUnityPlayer_UpdateTexture_APIv1(
						 playerId,
						 m_PixelsHandle[texIndex].AddrOfPinnedObject(),
						 frameInfo
				);
			if (updated) {
				m_Texture[texIndex].SetPixels32(m_Pixels[texIndex], 0);
				m_Texture[texIndex].Apply();
				// Set the writtern texture as the target
				material.mainTexture = m_Texture[texIndex];
				material.SetTexture("Texture_rgba", m_Texture[texIndex]);
				// Switch the write index of texture to the next
				texIndex = (texIndex + 1) % texNumber;
			}
			return updated;
		}

		public override void DestroyTexture()
		{
			for (int i = 0; i < texNumber; i++) {
				if (m_PixelsHandle[i].IsAllocated == true) {
					m_PixelsHandle[i].Free();
					Texture2D.Destroy(m_Texture[i]);
				}
			}
			m_Texture      = null;
			m_Pixels       = null;
			m_PixelsHandle = null;
		}
	}
	#endif




}

