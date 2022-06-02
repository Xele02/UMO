using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class Bloom : PostEffectsBase
	{
		public enum TweakMode
		{
			Basic = 0,
			Complex = 1,
		}

		public enum BloomScreenBlendMode
		{
			Screen = 0,
			Add = 1,
		}

		public enum HDRBloomMode
		{
			Auto = 0,
			On = 1,
			Off = 2,
		}

		public enum BloomQuality
		{
			Cheap = 0,
			High = 1,
		}

		public enum LensFlareStyle
		{
			Ghosting = 0,
			Anamorphic = 1,
			Combined = 2,
		}

		public TweakMode tweakMode;
		public BloomScreenBlendMode screenBlendMode;
		public HDRBloomMode hdr;
		public float sepBlurSpread;
		public BloomQuality quality;
		public float bloomIntensity;
		public float bloomThreshold;
		public Color bloomThresholdColor;
		public int bloomBlurIterations;
		public int hollywoodFlareBlurIterations;
		public float flareRotation;
		public LensFlareStyle lensflareMode;
		public float hollyStretchWidth;
		public float lensflareIntensity;
		public float lensflareThreshold;
		public float lensFlareSaturation;
		public Color flareColorA;
		public Color flareColorB;
		public Color flareColorC;
		public Color flareColorD;
		public Texture2D lensFlareVignetteMask;
		public Shader lensFlareShader;
		public Shader screenBlendShader;
		public Shader blurAndFlaresShader;
		public Shader brightPassFilterShader;
	}
}
