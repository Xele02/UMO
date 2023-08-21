using System;
using UnityEngine;

#if (UNITY_EDITOR || UNITY_STANDALONE) && !UNITY_ANDROID
namespace CriWare.CriMana.Detail
{
    public static partial class AutoResisterRendererResourceFactories
	{
        [RendererResourceFactoryPriority(1)]
        public class RendererResourceFactoryEditorUnityTheora : RendererResourceFactory
        {
            // Slot: 7
            public override RendererResource CreateRendererResource(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
            {
                if(movieInfo.codecType == CodecType.Theora && VLCManager.Instance != null)
                {
                    return new RendererResourceEditorUnityTheora(playerId, movieInfo, additive, userShader);
                }
                return null;
            }

            // RVA: 0x294FB60 Offset: 0x294FB60 VA: 0x294FB60 Slot: 5
            protected override void OnDisposeManaged()
            {
                return;
            }

            // RVA: 0x294FB64 Offset: 0x294FB64 VA: 0x294FB64 Slot: 6
            protected override void OnDisposeUnmanaged()
            {
                return;
            }
        }
    }

    public class RendererResourceEditorUnityTheora : RendererResource
    {
        private int width; // 0x18
        private int height; // 0x1C
        private int chromaWidth; // 0x20
        private int chromaHeight; // 0x24
        private int alphaWidth; // 0x28
        private int alphaHeight; // 0x2C
        private bool useUserShader; // 0x30
        private CodecType codecType; // 0x34
        private const TextureFormat format = TextureFormat.R8;
        private Vector4 movieTextureST = Vector4.zero; // 0x38
        private Vector4 movieChromaTextureST = Vector4.zero; // 0x48
        private Vector4 movieAlphaTextureST = Vector4.zero; // 0x58
        private Texture2D[] textures; // 0x68
        private RenderTexture[] renderTextures; // 0x6C
        private IntPtr[] nativePtrs; // 0x70
        private int playerID; // 0x74
        private bool areTexturesUpdated; // 0x78
        private bool isFrameUpdated; // 0x79
        private bool isStoppingForSeek; // 0x7A
        private bool isStartTriggered = true; // 0x7B

        // // RVA: 0x294F81C Offset: 0x294F81C VA: 0x294F81C
        public RendererResourceEditorUnityTheora(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
        {
            /*if(movieInfo.codecType == CodecType.SofdecPrime)
            {
                CalculateTextureSize(ref chromaWidth, ref chromaHeight, (int)movieInfo.width, (int)movieInfo.height, movieInfo.codecType, true);
            }*/
            width = (int)movieInfo.width;
            height = (int)movieInfo.height;
            chromaWidth = (int)movieInfo.width;
            chromaHeight = (int)movieInfo.height;
            this.additive = additive;
            this.hasAlpha = movieInfo.hasAlpha;
            useUserShader = userShader != null;
            codecType = movieInfo.codecType;
            if(userShader == null)
                userShader = Shader.Find("CriMana/EditorTheora");
            shader = userShader;
            /*if(hasAlpha)
            {
                if((int)movieInfo.alphaCodecType == (int)AlphaType.CompoAlphaFull)
                {
                    CalculateTextureSize(ref alphaWidth, ref alphaHeight, (int)movieInfo.width, (int)movieInfo.height, movieInfo.codecType, false);
                }
            }*/
            UpdateMovieTextureST(movieInfo.dispWidth, movieInfo.dispHeight);
            /*textures = new Texture2D[hasAlpha ? 4 : 3];
            nativePtrs = new IntPtr[hasAlpha ? 4 : 3];*/
            playerID = playerId;
        }

        // RVA: 0x2953D38 Offset: 0x2953D38 VA: 0x2953D38 Slot: 7
        protected override void OnDisposeManaged()
        {
            return;
        }

        // RVA: 0x2953D3C Offset: 0x2953D3C VA: 0x2953D3C Slot: 8
        protected override void OnDisposeUnmanaged()
        {
            /*RendererResource.DisposeTextures(textures);
            RendererResource.DisposeTextures(renderTextures);
            textures = null;
            renderTextures = null;*/
        }

        // RVA: 0x2953D68 Offset: 0x2953D68 VA: 0x2953D68 Slot: 9
        public override bool IsPrepared()
        {
            return areTexturesUpdated && isFrameUpdated;
        }

        // // RVA: 0x2953D88 Offset: 0x2953D88 VA: 0x2953D88 Slot: 10
        // public override bool ContinuePreparing() { }

        // RVA: 0x2953D90 Offset: 0x2953D90 VA: 0x2953D90 Slot: 15
        public override bool IsSuitable(int playerId, MovieInfo movieInfo, bool additive, Shader userShader)
        {
            /*int srcWidth = 0;
            int srcHeight = 0;
            if(movieInfo.codecType == CodecType.VP9)
            {
                TodoLogger.Log(0, "VP9 codec");
            }
            else
            {
                CalculateTextureSize(ref srcWidth, ref srcHeight, (int)movieInfo.width, (int)movieInfo.height, movieInfo.codecType, false);
            }
            bool sizeValid = width == srcWidth && height == srcHeight;
            return sizeValid && codecType == movieInfo.codecType && hasAlpha == movieInfo.hasAlpha && this.additive == additive && (!useUserShader || userShader == shader);*/
            return true;
        }

        // // RVA: 0x2953F44 Offset: 0x2953F44 VA: 0x2953F44 Slot: 17
        // public override bool OnPlayerStopForSeek() { }

        // RVA: 0x295442C Offset: 0x295442C VA: 0x295442C Slot: 18
        public override void OnPlayerStart()
        {
            isStartTriggered = true;
        }

        // RVA: 0x2954224 Offset: 0x2954224 VA: 0x2954224
        private void forceUpdateMaterialTextures(Texture[] newTextures)
        {
            /*if(currentMaterial == null)
                return;
            currentMaterial.SetTexture("_TextureY", newTextures[0]);
            currentMaterial.SetTexture("_TextureU", newTextures[1]);
            currentMaterial.SetTexture("_TextureV", newTextures[2]);
            if(hasAlpha)
                currentMaterial.SetTexture("_TextureA", newTextures[3]);*/
        }

        // RVA: 0x2954438 Offset: 0x2954438 VA: 0x2954438 Slot: 11
        public override void AttachToPlayer(int playerId)
        {
            /*RendererResource.DisposeTextures(textures);
            areTexturesUpdated = false;*/
        }

        // RVA: 0x2954458 Offset: 0x2954458 VA: 0x2954458 Slot: 12
        public override bool UpdateFrame(int playerId, FrameInfo frameInfo, ref bool frameDrop)
        {
            //int numTexture = hasAlpha ? 4 : 3;
            bool res = RendererResource.CRIWARED6D2B5F7(playerId, 1, null, frameInfo, ref frameDrop);
            if(res && !frameDrop)
            {
                UpdateMovieTextureST(frameInfo.dispWidth, frameInfo.dispHeight);
            }
            /*isFrameUpdated |= res;
            return res;*/
            frameDrop = false;
            return true;
        }

        // RVA: 0x2954504 Offset: 0x2954504 VA: 0x2954504 Slot: 13
        public override bool UpdateMaterial(Material material)
        {
            if(currentMaterial != material)
            {
                currentMaterial = material;
                SetupStaticMaterialProperties();
            }
            material.mainTexture = ExternLib.LibCriWare.GetVLCTexture(playerID);
            material.SetVector("_MovieTexture_ST", movieTextureST);
            /*if(!areTexturesUpdated)
                return renderTextures != null;
            if(textures[0] != null)
            {
                if(currentMaterial != material)
                    currentMaterial = material;
                material.SetVector("_MovieTexture_ST", movieTextureST);
                material.SetVector("_MovieChromaTexture_ST", movieChromaTextureST);
                if(!isStoppingForSeek)
                {
                    material.SetTexture("_TextureY", textures[0]);
                    material.SetTexture("_TextureU", textures[1]);
                    material.SetTexture("_TextureV", textures[2]);
                    if(hasAlpha)
                    {
                        material.SetVector("_MovieAlphaTexture_ST", movieAlphaTextureST);
                        material.SetTexture("_TextureA", textures[3]);
                    }
                    RendererResource.DisposeTextures(renderTextures);
                    renderTextures = null;
                }
                return true;
            }
            return false;*/
            return material.mainTexture != null;
        }

        // // RVA: 0x2953B84 Offset: 0x2953B84 VA: 0x2953B84
        private void UpdateMovieTextureST(uint dispWidth, uint dispHeight)
        {
            movieTextureST.z = 0;
            movieTextureST.w = dispHeight == height ? 1 : (dispHeight - 1) / height;
            movieTextureST.x = dispWidth == width ? 1 : (dispWidth - 1) / width;
            movieTextureST.y = -movieTextureST.w;
            /*movieChromaTextureST.z = 0;
            movieChromaTextureST.w = dispHeight == (chromaHeight << 1) ? 1 : (((dispHeight >> 1) - 1) / (chromaHeight << 2)) * 2;
            movieChromaTextureST.x = dispWidth == (chromaWidth << 1) ? 1 : (((dispWidth >> 1) - 1) / (chromaWidth << 1)) * 2;
            movieChromaTextureST.y = - movieChromaTextureST.w;
            if(!hasAlpha)
                return;
            movieAlphaTextureST.z = 0;
            movieAlphaTextureST.w = dispHeight == alphaHeight ? 1 : (dispHeight - 1) / alphaHeight;
            movieAlphaTextureST.x = dispWidth == alphaWidth ? 1 : (dispWidth - 1) / alphaWidth;
            movieAlphaTextureST.y = - movieAlphaTextureST.w;*/
        }

        // RVA: 0x29548EC Offset: 0x29548EC VA: 0x29548EC Slot: 14
        public override void UpdateTextures()
        {
            /*int numTextures = hasAlpha ? 4 : 3;
            bool updated = RendererResource.CRIWARE14DB4020(playerID, numTextures, nativePtrs);
            areTexturesUpdated |= updated;
            if(updated)
            {
                if(nativePtrs[0] != IntPtr.Zero && isStartTriggered)
                {
                    if(textures[0] != null)
                    {
                        for(int i = 0; i < textures.Length; i++)
                        {
                            textures[i].UpdateExternalTexture(nativePtrs[i]);
                        }
                    }
                    else
                    {
                        textures[0] = Texture2D.CreateExternalTexture(width, height, TextureFormat.R8, false, false, nativePtrs[0]);
                        textures[0].wrapMode = TextureWrapMode.Clamp;
                        textures[1] = Texture2D.CreateExternalTexture(chromaWidth, chromaHeight, TextureFormat.R8, false, false, nativePtrs[1]);
                        textures[1].wrapMode = TextureWrapMode.Clamp;
                        textures[2] = Texture2D.CreateExternalTexture(chromaWidth, chromaHeight, TextureFormat.R8, false, false, nativePtrs[2]);
                        textures[2].wrapMode = TextureWrapMode.Clamp;
                        if(hasAlpha)
                        {
                            textures[3] = Texture2D.CreateExternalTexture(alphaWidth, alphaHeight, TextureFormat.R8, false, false, nativePtrs[3]);
                            textures[3].wrapMode = TextureWrapMode.Clamp;
                        }
                    }
                    isStoppingForSeek = false;
                }
            }*/
        }

        // // RVA: 0x2953AC0 Offset: 0x2953AC0 VA: 0x2953AC0
        private static void CalculateTextureSize(ref int w, ref int h, int videoWidth, int videoHeight, CodecType type, bool isChroma)
        {
            /*if(type == CodecType.VP9)
            {
                TodoLogger.Log(0, "VP9 codec");
            }
            else
            {
                if(!isChroma)
                {
                    w = (int)((((((videoWidth + 7) & 0xfffffff8) + 0xf) & 0xfffffff0) + 0x1f) & 0xffffffe0);
                    h = (int)((videoHeight + 7) & 0xfffffff8);
                }
                else
                {
                    w = (int)(((((((((videoWidth + 7) & 0xfffffff8) + 0xf) & 0xfffffff0) - ((((videoWidth + 7) & 0xfffffff8) + 0xf) >> 0x1f)) >> 1) + 0x1fU) & 0xffffffe0));
                    h = (int)((videoHeight + 7) & 0xfffffff8) >> 1;
                }
            }*/
        }
    }
}
#endif
