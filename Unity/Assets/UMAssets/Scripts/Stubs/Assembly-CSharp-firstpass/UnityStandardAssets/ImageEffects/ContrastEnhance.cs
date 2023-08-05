using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class ContrastEnhance : PostEffectsBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public float intensity;
		public float threshold;
		public float blurSpread;
		public Shader separableBlurShader;
		public Shader contrastCompositeShader;
	}
}
