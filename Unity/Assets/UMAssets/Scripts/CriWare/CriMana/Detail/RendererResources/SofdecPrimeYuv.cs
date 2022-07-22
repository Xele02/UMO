/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2015 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_PSP2 || UNITY_PS4 || UNITY_ANDROID || UNITY_IOS || UNITY_TVOS

using UnityEngine;
using System.Runtime.InteropServices;


namespace CriMana.Detail
{
	public static partial class AutoResisterRendererResourceFactories
	{
		[RendererResourceFactoryPriority(5000)]
		public class RendererResourceFactorySofdecPrimeYuv : RendererResourceFactory
		{
			public override RendererResource CreateRendererResource(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
			{
				bool isCodecSuitable = movieInfo.codecType == CodecType.SofdecPrime;
				bool isSuitable      = isCodecSuitable;
				return isSuitable
					? new RendererResourceSofdecPrimeYuv(playerId, movieInfo, additive, userShader)
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




	public class RendererResourceSofdecPrimeYuv : RendererResource
	{
		private int		width;
		private int		height;
		private bool	hasAlpha;
		private bool	additive;
		private bool	useUserShader;
		
		private Shader		shader;

		private Matrix4x4	movieUvTransform = Matrix4x4.identity;

		private Texture2D	textureY;
		private Texture2D	textureU;
		private Texture2D	textureV;
		private Texture2D	textureA;

		
		public RendererResourceSofdecPrimeYuv(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
		{
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_PSP2 || UNITY_PS4 || UNITY_WINRT
			width  = Ceiling256((int)movieInfo.width);
			height = Ceiling16((int)movieInfo.height);
#elif UNITY_ANDROID || UNITY_IOS || UNITY_TVOS
			width  = NextPowerOfTwo(Ceiling64((int)movieInfo.width));
			height = NextPowerOfTwo(Ceiling16((int)movieInfo.height));
#else
	#error unsupported platform
#endif
			hasAlpha		= movieInfo.hasAlpha;
			this.additive	= additive;
			useUserShader	= userShader != null;

			if (useUserShader) {
				shader = userShader;
			} else {
				string shaderName = 
					hasAlpha	? additive	? "CriMana/SofdecPrimeYuvaAdditive"
											: "CriMana/SofdecPrimeYuva"
								: additive	? "CriMana/SofdecPrimeYuvAdditive"
											: "CriMana/SofdecPrimeYuv";
				shader = Shader.Find(shaderName);
			}
			
			UpdateMatrix(movieInfo.dispWidth, movieInfo.dispHeight);
			
			textureY = new Texture2D(width    , height    , TextureFormat.Alpha8, false);
			textureY.wrapMode = TextureWrapMode.Clamp;
			textureU = new Texture2D(width / 2, height / 2, TextureFormat.Alpha8, false);
			textureU.wrapMode = TextureWrapMode.Clamp;
			textureV = new Texture2D(width / 2, height / 2, TextureFormat.Alpha8, false);
			textureV.wrapMode = TextureWrapMode.Clamp;
			if (hasAlpha) {
				textureA = new Texture2D(width    , height    , TextureFormat.Alpha8, false);
				textureA.wrapMode = TextureWrapMode.Clamp;
			}
		}
		

		protected override void OnDisposeManaged()
		{
		}


		protected override void OnDisposeUnmanaged()
		{
			if (textureY != null) {
				Texture2D.Destroy(textureY);
				textureY = null;
			}
			if (textureU != null) {
				Texture2D.Destroy(textureU);
				textureU = null;
			}
			if (textureV != null) {
				Texture2D.Destroy(textureV);
				textureV = null;
			}
			if (textureA != null) {
				Texture2D.Destroy(textureA);
				textureA = null;
			}
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
			bool isFrameUpdated;
			if (hasAlpha) {
				isFrameUpdated = criManaUnityPlayer_UpdateTextureYuvaByPtr(
					playerId,
					textureY.GetNativeTexturePtr(),
					textureU.GetNativeTexturePtr(),
					textureV.GetNativeTexturePtr(),
					textureA.GetNativeTexturePtr(),
					frameInfo
					);
			} else {
				isFrameUpdated = criManaUnityPlayer_UpdateTextureYuvByPtr(
					playerId,
					textureY.GetNativeTexturePtr(),
					textureU.GetNativeTexturePtr(),
					textureV.GetNativeTexturePtr(),
					frameInfo
					);
			}
			if (isFrameUpdated) {
				UpdateMatrix(frameInfo.dispWidth, frameInfo.dispHeight);
			}
			return isFrameUpdated;
		}
		
		
		public override bool UpdateMaterial(Material material)
		{
			material.shader = shader;
			material.SetTexture("TextureY", textureY);
			material.SetTexture("TextureU", textureU);
			material.SetTexture("TextureV", textureV);
			if (hasAlpha) {
				material.SetTexture("TextureA", textureA);
			}
			material.SetMatrix("MovieUvTransform", movieUvTransform);
			return true;
		}
		
		
		private void UpdateMatrix(System.UInt32 dispWidth, System.UInt32 dispHeight)
		{
			float uScale = (float)(dispWidth - 1) / width;
			float vScale = (float)(dispHeight - 1) / height;
			movieUvTransform.m00 = uScale;
			movieUvTransform.m11 = -vScale;
			movieUvTransform.m13 = vScale;
		}


		#region Native API Definitions
		[DllImport(CriWare.pluginName)]
		private static extern bool criManaUnityPlayer_UpdateTextureYuvByPtr(
			int player_id,
			System.IntPtr texid_y,
			System.IntPtr texid_u,
			System.IntPtr texid_v,
			[In, Out] FrameInfo frame_info
			);

		[DllImport(CriWare.pluginName)]
		private static extern bool criManaUnityPlayer_UpdateTextureYuvaByPtr(
			int player_id,
			System.IntPtr texid_y,
			System.IntPtr texid_u,
			System.IntPtr texid_v,
			System.IntPtr texid_a,
			[In, Out] FrameInfo frame_info
			);
		#endregion
	}
}


#endif
