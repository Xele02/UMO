/****************************************************************************
 *
 * CRI Middleware SDK
 *
 * Copyright (c) 2015 CRI Middleware Co., Ltd.
 *
 ****************************************************************************/
#if !UNITY_EDITOR && UNITY_IOS

using UnityEngine;
using System.Runtime.InteropServices;


namespace CriMana.Detail
{
	public static partial class AutoResisterRendererResourceFactories
	{
		[RendererResourceFactoryPriority(7000)]
		public class RendererResourceFactoryIOSH264Yuv : RendererResourceFactory
		{
			public override RendererResource CreateRendererResource(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
			{
				bool isCodecSuitable = movieInfo.codecType == CodecType.H264;
				bool isAlphaSuitable = !movieInfo.hasAlpha;	/* アルファムービは非対応 */
				bool isSuitable      = isCodecSuitable && isAlphaSuitable;
				return isSuitable
					? new RendererResourceIOSH264Yuv(playerId, movieInfo, additive, userShader)
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




	public class RendererResourceIOSH264Yuv : RendererResource
	{
		struct NativeContext
		{
			public System.IntPtr value1;
			public System.IntPtr value2;
			public System.IntPtr value3;
			public System.IntPtr textureY;
			public System.IntPtr textureUV;
		}
		
		private int 	playerId;
		private bool	hasAlpha;
		private bool	additive;
		private bool	useUserShader;
		
		private Shader			shader;
		
		private Matrix4x4		movieUvTransform = Matrix4x4.identity;
		private Texture2D		textureY;
		private Texture2D		textureUV;

		private NativeContext	nativeContext = new NativeContext();
		
		public RendererResourceIOSH264Yuv(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
		{
			if (movieInfo.hasAlpha) {
				UnityEngine.Debug.LogError("[CRIWARE] H.264 with Alpha is unsupported");
			}
			
			this.playerId	= playerId;
			hasAlpha		= movieInfo.hasAlpha;
			this.additive	= additive;
			useUserShader	= userShader != null;
			
			if (userShader != null) {
				shader = userShader;
			} else {
				string shaderName = 
					hasAlpha	? additive	? "Diffuse"
											: "Diffuse"
								: additive	? "CriMana/IOSH264YuvAdditive"
											: "CriMana/IOSH264Yuv";
				shader = Shader.Find(shaderName);
			}

			movieUvTransform.m11 = -1.0f;
			movieUvTransform.m13 = 1.0f;

			criManaUnityPlayer_VideoToolboxCreateContext_IOS(playerId, out nativeContext);
		}
		
		
		protected override void OnDisposeManaged()
		{
		}
		
		
		protected override void OnDisposeUnmanaged()
		{
			if (textureY != null) {
				Texture2D.Destroy(textureY);
			}
			if (textureUV != null) {
				Texture2D.Destroy(textureUV);
			}
			criManaUnityPlayer_VideoToolboxDestroyContext_IOS(playerId, ref nativeContext);
			textureY	= null;
			textureUV	= null;
		}
		
		
		public override bool IsPrepared()
		{ return true; }
		
		
		public override bool ContinuePreparing()
		{ return true; }
		
		
		public override bool IsSuitable(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
		{
			bool isCodecSuitable    = movieInfo.codecType == CodecType.H264;
			bool isAlphaSuitable    = hasAlpha == movieInfo.hasAlpha;
			bool isAdditiveSuitable = this.additive == additive;
			bool isShaderSuitable   = this.useUserShader ? (userShader == shader) : true;
			return isCodecSuitable && isAlphaSuitable && isAdditiveSuitable && isShaderSuitable;
		}
		
		
		public override void AttachToPlayer(int playerId)
		{
		}


		public override bool UpdateFrame(int playerId, FrameInfo frameInfo)
		{
			bool isFrameUpdated = criManaUnityPlayer_VideoToolboxUpdateTexture_IOS(
				playerId,
				frameInfo,
				ref nativeContext
				);
			if (isFrameUpdated) {
				int width  = (int)frameInfo.width;
				int height = (int)frameInfo.height;
				if (textureY == null) {
					textureY  = Texture2D.CreateExternalTexture(width, height, TextureFormat.Alpha8, false, false, nativeContext.textureY);
					textureUV = Texture2D.CreateExternalTexture(width / 2, height / 2, TextureFormat.Alpha8, false, false, nativeContext.textureUV);
					textureY.wrapMode = TextureWrapMode.Clamp;
					textureUV.wrapMode = TextureWrapMode.Clamp;
				} else {
					Texture2D tmpTextureY  = Texture2D.CreateExternalTexture(width, height, TextureFormat.Alpha8, false, false, nativeContext.textureY);
					Texture2D tmpTextureUV = Texture2D.CreateExternalTexture(width / 2, height / 2, TextureFormat.Alpha8, false, false, nativeContext.textureUV);
					tmpTextureY.wrapMode = TextureWrapMode.Clamp;
					tmpTextureUV.wrapMode = TextureWrapMode.Clamp;
					textureY.UpdateExternalTexture(tmpTextureY.GetNativeTexturePtr());
					textureUV.UpdateExternalTexture(tmpTextureUV.GetNativeTexturePtr());
					Texture2D.Destroy(tmpTextureY);
					Texture2D.Destroy(tmpTextureUV);
				}
			}
			return isFrameUpdated;
		}
		
		
		public override bool UpdateMaterial(Material material)
		{
			material.shader = shader;

			material.SetTexture("TextureY", textureY);
			material.SetTexture("TextureUV", textureUV);
			material.SetMatrix("MovieUvTransform", movieUvTransform);
			return true;
		}
		
		
		#region Native API Definitions
		[DllImport(CriWare.Common.pluginName)]
		private static extern bool criManaUnityPlayer_VideoToolboxCreateContext_IOS(
			int   player_id,
			[Out] out NativeContext native_context
			);

		[DllImport(CriWare.Common.pluginName)]
		private static extern void criManaUnityPlayer_VideoToolboxDestroyContext_IOS(
			int   player_id,
			[In, Out] ref NativeContext native_context
			);

		[DllImport(CriWare.Common.pluginName)]
		private static extern bool criManaUnityPlayer_VideoToolboxUpdateTexture_IOS(
			int   player_id,
			[In, Out] FrameInfo frame_info,
			[In, Out] ref NativeContext native_context
			);
		#endregion
	}
}


#endif
