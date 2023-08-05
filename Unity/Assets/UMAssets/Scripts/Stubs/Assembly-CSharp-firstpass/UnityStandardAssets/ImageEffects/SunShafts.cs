using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class SunShafts : PostEffectsBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public enum SunShaftsResolution
		{
			Low = 0,
			Normal = 1,
			High = 2,
		}

		public enum ShaftsScreenBlendMode
		{
			Screen = 0,
			Add = 1,
		}

		public SunShaftsResolution resolution;
		public ShaftsScreenBlendMode screenBlendMode;
		public Transform sunTransform;
		public int radialBlurIterations;
		public Color sunColor;
		public Color sunThreshold;
		public float sunShaftBlurRadius;
		public float sunShaftIntensity;
		public float maxRadius;
		public bool useDepthTexture;
		public Shader sunShaftsShader;
		public Shader simpleClearShader;
	}
}
