/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2015 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/
#if !UNITY_EDITOR && (UNITY_WIIU || UNITY_PS3 || UNITY_WINRT)

using UnityEngine;
using System.Runtime.InteropServices;


namespace CriMana.Detail
{
	public static partial class AutoResisterRendererResourceFactories
	{
		[RendererResourceFactoryPriority(5050)]
		public class RendererResourceFactorySofdecPrimeRgb : RendererResourceFactory
		{
			public override RendererResource CreateRendererResource(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
			{
				bool isCodecSuitable = movieInfo.codecType == CodecType.SofdecPrime;
				bool isSuitable      = isCodecSuitable;
				return isSuitable
					? new RendererResourceSofdecPrimeRgb(playerId, movieInfo, additive, userShader)
					: null;
			}

			protected override void OnDisposeManaged()
			{
			}

			protected override void OnDisposeUnmanaged()
			{
			}
		}
	}




	public class RendererResourceSofdecPrimeRgb : RendererResource
	{
		private int		width;
		private int		height;
		private bool	hasAlpha;
		private bool	additive;
		private bool	useUserShader;
		
		private Shader		shader;

		private Matrix4x4	movieUvTransform = Matrix4x4.identity;

		private Texture2D	texture;
		private Color32[]	pixels;
		private GCHandle	pixelsHandle;


		public RendererResourceSofdecPrimeRgb(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
		{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_PSP2 || UNITY_PS4 || UNITY_PS3 || UNITY_WINRT
			width  = Ceiling64((int)movieInfo.width);
			height = Ceiling64((int)movieInfo.height);
#elif UNITY_ANDROID || UNITY_IOS || UNITY_TVOS
			width  = NextPowerOfTwo((int)movieInfo.width);
			height = NextPowerOfTwo((int)movieInfo.height);
#else
	#error unsupported platform
#endif
			hasAlpha		= movieInfo.hasAlpha;
			this.additive	= additive;
			useUserShader	= userShader != null;

			if (userShader != null) {
				shader = userShader;
			} else {
				string shaderName = 
					hasAlpha	? additive	? "CriMana/SofdecPrimeRgbaAdditive"
											: "CriMana/SofdecPrimeRgba"
								: additive	? "CriMana/SofdecPrimeRgbAdditive"
											: "CriMana/SofdecPrimeRgb";
				shader = Shader.Find(shaderName);
			}
			
			UpdateMatrix(movieInfo.dispWidth, movieInfo.dispHeight);

			texture				= new Texture2D(width, height, TextureFormat.ARGB32, false);
			texture.wrapMode	= TextureWrapMode.Clamp;
			pixels				= texture.GetPixels32(0);
			pixelsHandle		= GCHandle.Alloc(pixels, GCHandleType.Pinned);
		}
		


		protected override void OnDisposeManaged()
		{
		}


		protected override void OnDisposeUnmanaged()
		{
			if (texture != null) {
				if (pixelsHandle.IsAllocated == true) {
					pixelsHandle.Free();
				}
			}
			if (texture != null) {
				Texture2D.Destroy(texture);
			}
			texture	= null;
			pixels	= null;
		}
		
		
		public override bool IsPrepared()
		{ return true; }
		
		
		public override bool ContinuePreparing()
		{ return true; }
		
		
		public override bool IsSuitable(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
		{
			bool isCodecSuitable    = movieInfo.codecType == CodecType.SofdecPrime;
			bool isSizeSuitable     = (width >= (int)movieInfo.width) && (height >= (int)movieInfo.height);
			bool isAlphaSuitable    = hasAlpha == movieInfo.hasAlpha;
			bool isAdditiveSuitable = this.additive == additive;
			bool isShaderSuitable   = this.useUserShader ? (userShader == shader) : true;
			return isCodecSuitable && isSizeSuitable && isAlphaSuitable && isAdditiveSuitable && isShaderSuitable;
		}

		
		public override void AttachToPlayer(int playerId)
		{}
		
		
		public override bool UpdateFrame(int playerId, FrameInfo frameInfo)
		{
			bool isFrameUpdated = criManaUnityPlayer_UpdateTexture(
				playerId,
				pixelsHandle.AddrOfPinnedObject(),
				frameInfo
				);
			if (isFrameUpdated) {
				texture.SetPixels32(pixels, 0);
				texture.Apply();
				UpdateMatrix(frameInfo.dispWidth, frameInfo.dispHeight);
			}
			return isFrameUpdated;
		}
		
		
		public override bool UpdateMaterial(Material material)
		{
			material.shader = shader;
			
			material.mainTexture = texture;
			material.SetTexture("TextureRgba", texture);
			material.SetMatrix("MovieUvTransform", movieUvTransform);
			return true;
		}
		
		
		private void UpdateMatrix(System.UInt32 dispWidth, System.UInt32 dispHeight)
		{
			float uScale = (float)(dispWidth) / width;
			float vScale = (float)(dispHeight) / height;
			movieUvTransform.m00 = uScale;
			movieUvTransform.m11 = -vScale;
			movieUvTransform.m13 = vScale;
		}


		#region Native API Definitions
		[DllImport(CriWare.pluginName)]
		private static extern bool criManaUnityPlayer_UpdateTexture(
			int player_id,
			System.IntPtr texbuf,
			[In, Out] FrameInfo frame_info
			);
		#endregion
	}
}


#endif
