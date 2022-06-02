using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class ContrastEnhance : PostEffectsBase
	{
		public float intensity;
		public float threshold;
		public float blurSpread;
		public Shader separableBlurShader;
		public Shader contrastCompositeShader;
	}
}
