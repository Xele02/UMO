using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class Tonemapping : PostEffectsBase
	{
		public enum TonemapperType
		{
			SimpleReinhard = 0,
			UserCurve = 1,
			Hable = 2,
			Photographic = 3,
			OptimizedHejiDawson = 4,
			AdaptiveReinhard = 5,
			AdaptiveReinhardAutoWhite = 6,
		}

		public enum AdaptiveTexSize
		{
			Square16 = 16,
			Square32 = 32,
			Square64 = 64,
			Square128 = 128,
			Square256 = 256,
			Square512 = 512,
			Square1024 = 1024,
		}

		public TonemapperType type;
		public AdaptiveTexSize adaptiveTextureSize;
		public AnimationCurve remapCurve;
		public float exposureAdjustment;
		public float middleGrey;
		public float white;
		public float adaptionSpeed;
		public Shader tonemapper;
		public bool validRenderTextureFormat;
	}
}
