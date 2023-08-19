using System;
using System.IO;
using UnityEngine;
using XeApp.Game.Menu;

namespace CriWare.CriMana.Detail
{
    public static partial class AutoResisterRendererResourceFactories
	{
        [RendererResourceFactoryPriority(5060)]
        public class RendererResourceFactoryAndroidSofdecPrimeYuvLegacyGles2 : RendererResourceFactory // TypeDefIndex: 5870
        {
            // RVA: 0x294FBEC Offset: 0x294FBEC VA: 0x294FBEC Slot: 7
            public override RendererResource CreateRendererResource(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
            {
                bool hasCodec = (movieInfo.codecType == CodecType.SofdecPrime || movieInfo.codecType == CodecType.VP9);
                bool hasDevice = SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.OpenGLES2 || SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Vulkan;
                if(hasCodec || hasDevice)
                {
                    return new RendererResourceAndroidSofdecPrimeYuvLegacyGles2(playerId, movieInfo, additive, userShader);
                }
                return null;
            }

            // RVA: 0x2950B90 Offset: 0x2950B90 VA: 0x2950B90 Slot: 5
            protected override void OnDisposeManaged()
            {
                return;
            }

            // RVA: 0x2950B94 Offset: 0x2950B94 VA: 0x2950B94 Slot: 6
            protected override void OnDisposeUnmanaged()
            {
                return;
            }
        }
    }

    public class RendererResourceAndroidSofdecPrimeYuvLegacyGles2 : RendererResource
    {
        private int width; // 0x18
        private int height; // 0x1C
        private int chromaWidth; // 0x20
        private int chromaHeight; // 0x24
        private int alphaWidth; // 0x28
        private int alphaHeight; // 0x2C
        private bool useUserShader; // 0x30
        private CodecType codecType; // 0x34
        private Vector4 movieTextureST = Vector4.zero; // 0x38
        private Vector4 movieChromaTextureST = Vector4.zero; // 0x48
        private Vector4 movieAlphaTextureST = Vector4.zero; // 0x58
        private Texture2D[][] textures; // 0x68
        private RenderTexture[] renderTextures; // 0x6C
        private IntPtr[][] nativeTextures; // 0x70
        private int numTextureSets = 2; // 0x74
        private int currentTextureSet; // 0x78
        private int drawTextureSet = -1; // 0x7C
        private int playerID; // 0x80
        private bool isStoppingForSeek; // 0x84

        // RVA: 0x294FCD4 Offset: 0x294FCD4 VA: 0x294FCD4
        public RendererResourceAndroidSofdecPrimeYuvLegacyGles2(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
        {
            this.additive = additive;
            hasAlpha = movieInfo.hasAlpha;
            useUserShader = userShader != null;
            if(movieInfo.codecType == CodecType.VP9)
            {
                TodoLogger.LogError(0, "Codec VP9");
            }
            else if(movieInfo.codecType == CodecType.SofdecPrime)
            {
                width = Ceiling256((int)movieInfo.width);//(int)(((movieInfo.width + 7 & 0xfffffff8) + 0xf & 0xfffffff0) + 0x1f & 0xffffffe0);
                height = Ceiling16((int)movieInfo.width);//(int)((movieInfo.height + 7) & 0xfffffff8);
            }
            CalculateTextureSize(ref chromaWidth, ref chromaHeight, (int)movieInfo.width, (int)movieInfo.height, movieInfo.codecType, true);
            if(hasAlpha)
            {
                if(movieInfo.codecType == CodecType.VP9)
                {
                    TodoLogger.LogError(0, "Codec VP9");
                }
                else if(movieInfo.codecType == CodecType.SofdecPrime)
                {
                    alphaWidth = Ceiling256((int)movieInfo.width);//(int)(((movieInfo.width + 7 & 0xfffffff8) + 0xf & 0xfffffff0) + 0x1f & 0xffffffe0);
                    alphaHeight = Ceiling16((int)movieInfo.width);//(int)((movieInfo.height + 7) & 0xfffffff8);
                }
            }
            if(userShader == null)
            {
                userShader = Shader.Find("CriMana/SofdecPrimeYuv");
            }
            shader = userShader;
            UpdateMovieTextureST(movieInfo.dispWidth, movieInfo.dispHeight);
            textures = new Texture2D[4][];
            for(int i = 0; i < numTextureSets; i++)
            {
                textures[i] = new Texture2D[4];
            }
            nativeTextures = new IntPtr[numTextureSets][];
            for(int i = 0; i < numTextureSets; i++)
            {
                textures[i][0] = new Texture2D(width, height, TextureFormat.Alpha8, false, true);
                textures[i][0].wrapMode = TextureWrapMode.Clamp;
                textures[i][1] = new Texture2D(chromaWidth, chromaHeight, TextureFormat.Alpha8, false, true);
                textures[i][1].wrapMode = TextureWrapMode.Clamp;
                textures[i][2] = new Texture2D(chromaWidth, chromaHeight, TextureFormat.Alpha8, false, true);
                textures[i][2].wrapMode = TextureWrapMode.Clamp;
                nativeTextures[i] = new IntPtr[4];
                nativeTextures[i][0] = textures[i][0].GetNativeTexturePtr();
                nativeTextures[i][1] = textures[i][1].GetNativeTexturePtr();
                nativeTextures[i][2] = textures[i][2].GetNativeTexturePtr();
                if(!hasAlpha)
                {
                    textures[i][3] = null;
                    nativeTextures[i][3] = IntPtr.Zero;
                }
                else
                {
                    textures[i][3] = new Texture2D(alphaWidth, alphaHeight, TextureFormat.Alpha8, false, true);
                    textures[i][3].wrapMode = TextureWrapMode.Clamp;
                    nativeTextures[i][3] = textures[i][3].GetNativeTexturePtr();
                }
            }
            codecType = movieInfo.codecType;
            playerID = playerId;
        }

        // RVA: 0x2955228 Offset: 0x2955228 VA: 0x2955228 Slot: 7
        protected override void OnDisposeManaged()
        {
            return;
        }

        // RVA: 0x295522C Offset: 0x295522C VA: 0x295522C Slot: 8
        protected override void OnDisposeUnmanaged()
        {
            for(int i = 0; i < numTextureSets; i++)
            {
                DisposeTextures(textures[i]);
            }
            nativeTextures = null;
            textures = null;
        }

        // RVA: 0x29552A4 Offset: 0x29552A4 VA: 0x29552A4 Slot: 9
        public override bool IsPrepared()
        {
            return true;
        }

        // // RVA: 0x29552AC Offset: 0x29552AC VA: 0x29552AC Slot: 10
        // public override bool ContinuePreparing() { }

        // RVA: 0x29552B4 Offset: 0x29552B4 VA: 0x29552B4 Slot: 15
        public override bool IsSuitable(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
        {
            int x = 0;
            int y = 0;
            if(movieInfo.codecType == CodecType.VP9)
            {
                /*x = (((movieInfo.width + 1) & 0xfffffffe) + 7) & 0xfffffff8;
                y = (((movieInfo.height + 1) & 0xfffffffe) + 7) & 0xfffffff8;*/
                TodoLogger.LogError(0, "VP9");
            }
            else if(movieInfo.codecType == CodecType.SofdecPrime)
            {
                x = (Ceiling256((int)movieInfo.width));//(((((movieInfo.width + 7) & 0xfffffff8) + 15) & 0xfffffff0) + 31) & 0xffffffe0;
                y = (Ceiling16((int)movieInfo.height));//(movieInfo.height + 7) & 0xfffffff8;
            }
            bool b = false;
            if(width == x && height == y)
                b = true;
            bool b2 = false;
            if(!useUserShader)
                b2 = true;
            else
                b2 = shader == userShader;
            return b && movieInfo.codecType == codecType && hasAlpha == movieInfo.hasAlpha && this.additive == additive && b2;
        }

        // RVA: 0x2955470 Offset: 0x2955470 VA: 0x2955470 Slot: 17
        // public override bool OnPlayerStopForSeek()
        // {
        //     isStoppingForSeek = drawTextureSet >= 0;
        //     return true;
        // }

        // RVA: 0x2955488 Offset: 0x2955488 VA: 0x2955488 Slot: 11
        public override void AttachToPlayer(int playerId)
        {
            drawTextureSet = -1;
        }

        // RVA: 0x2955494 Offset: 0x2955494 VA: 0x2955494 Slot: 12
        public override bool UpdateFrame(int playerId, FrameInfo frameInfo, ref bool frameDrop)
        {
            bool b = CRIWARED6D2B5F7(playerId, 0, null, frameInfo, ref frameDrop);
            if(b)
            {
                if(!frameDrop)
                {
                    UpdateMovieTextureST(frameInfo.dispWidth, frameInfo.dispHeight);
                    isStoppingForSeek = false;
                    drawTextureSet = currentTextureSet;
                    currentTextureSet = (drawTextureSet + 1) % numTextureSets;
                }
                return true;
            }
            return false;
        }

        // RVA: 0x2955544 Offset: 0x2955544 VA: 0x2955544 Slot: 13
        public override bool UpdateMaterial(Material material)
        {
            bool res = true;
            if(!isStoppingForSeek)
            {
                if(drawTextureSet < 0)
                {
                    res = false;
                }
                else
                {
                    if(material != null)
                    {
                        currentMaterial = material;
                        SetupStaticMaterialProperties();
                    }
                    material.SetTexture("_TextureY", textures[drawTextureSet][0]);
                    material.SetTexture("_TextureU", textures[drawTextureSet][1]);
                    material.SetTexture("_TextureV", textures[drawTextureSet][2]);
                    material.SetVector("_MovieTexture_ST", movieTextureST);
                    material.SetVector("_MovieChromaTexture_ST", movieChromaTextureST);
                    if(hasAlpha)
                    {
                        material.SetTexture("_TextureA", textures[drawTextureSet][3]);
                        material.SetVector("_MovieAlphaTexture_ST", movieAlphaTextureST);
                    }
                }
            }
            return res;
        }

        // RVA: 0x2955074 Offset: 0x2955074 VA: 0x2955074
        private void UpdateMovieTextureST(uint dispWidth, uint dispHeight)
        {
            float scaleX = 1;
            float scaleY = 1;
            if(dispWidth != width || width < 0)
                scaleX = (dispWidth - 1) * 1.0f / width;
            if(dispHeight != height || height < 0)
                scaleY = (dispHeight - 1) * 1.0f / height;
            movieTextureST = new Vector4(scaleX, -scaleY, 0, scaleY);
            scaleX = 1;
            scaleY = 1;
            if(dispWidth != (chromaWidth * 2) || (chromaWidth * 2) < 0)
            {
                scaleX = ((dispWidth / 2) - 1) * 1.0f / (chromaWidth * 2);
                scaleX *= 2;
            }
            if(dispHeight != (chromaHeight * 2) || (chromaHeight * 2) < 0)
            {
                scaleY = ((dispHeight / 2) - 1) * 1.0f / (chromaHeight * 2);
                scaleY *= 2;
            }
            movieChromaTextureST = new Vector4(scaleX, -scaleY, 0, scaleY);
            if(!hasAlpha)
                return;
            scaleX = 1;
            scaleY = 1;
            if(dispWidth != alphaWidth || alphaWidth < 0)
                scaleX = (dispWidth - 1) * 1.0f / alphaWidth;
            if(dispHeight != alphaHeight || alphaHeight < 0)
                scaleY = (dispHeight - 1) * 1.0f / alphaHeight;
            movieAlphaTextureST = new Vector4(scaleX, -scaleY, 0, scaleY);
        }

        // RVA: 0x2955978 Offset: 0x2955978 VA: 0x2955978 Slot: 14
        public override void UpdateTextures()
        {
            if(drawTextureSet < 0)
                return;
            int numTex = 3;
            if(hasAlpha)
                numTex = 4;
            CRIWARE14DB4020(playerID, numTex, nativeTextures[drawTextureSet]);
        }

        // // RVA: 0x2954FB0 Offset: 0x2954FB0 VA: 0x2954FB0
        private static void CalculateTextureSize(ref int w, ref int h, int videoWidth, int videoHeight, CodecType type, bool isChroma)
        {
            if(type == CodecType.VP9)
            {
                TodoLogger.LogError(0, "VP9");
            }
            else if(type == CodecType.SofdecPrime)
            {
                if (!isChroma) {
					w = Ceiling32(Ceiling16(CeilingWith(videoWidth, 8)));
					h = CeilingWith(videoHeight, 8);
				} else {
					w = Ceiling32(Ceiling16(CeilingWith(videoWidth, 8)) / 2);
					h = CeilingWith(videoHeight, 8) / 2;
				}
            }
        }
    }

}