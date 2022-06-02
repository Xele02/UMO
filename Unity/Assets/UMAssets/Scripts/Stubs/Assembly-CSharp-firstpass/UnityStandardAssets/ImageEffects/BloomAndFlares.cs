using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class BloomAndFlares : PostEffectsBase
	{
		public TweakMode34 tweakMode;
		public BloomScreenBlendMode screenBlendMode;
		public HDRBloomMode hdr;
		public float sepBlurSpread;
		public float useSrcAlphaAsMask;
		public float bloomIntensity;
		public float bloomThreshold;
		public int bloomBlurIterations;
		public bool lensflares;
		public int hollywoodFlareBlurIterations;
		public LensflareStyle34 lensflareMode;
		public float hollyStretchWidth;
		public float lensflareIntensity;
		public float lensflareThreshold;
		public Color flareColorA;
		public Color flareColorB;
		public Color flareColorC;
		public Color flareColorD;
		public Texture2D lensFlareVignetteMask;
		public Shader lensFlareShader;
		public Shader vignetteShader;
		public Shader separableBlurShader;
		public Shader addBrightStuffOneOneShader;
		public Shader screenBlendShader;
		public Shader hollywoodFlaresShader;
		public Shader brightPassFilterShader;
	}
}
