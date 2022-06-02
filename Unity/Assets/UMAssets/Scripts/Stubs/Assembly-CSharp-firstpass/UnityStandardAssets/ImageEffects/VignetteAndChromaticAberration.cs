using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class VignetteAndChromaticAberration : PostEffectsBase
	{
		public enum AberrationMode
		{
			Simple = 0,
			Advanced = 1,
		}

		public AberrationMode mode;
		public float intensity;
		public float chromaticAberration;
		public float axialAberration;
		public float blur;
		public float blurSpread;
		public float luminanceDependency;
		public float blurDistance;
		public Shader vignetteShader;
		public Shader separableBlurShader;
		public Shader chromAberrationShader;
	}
}
