using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class BloomOptimized : PostEffectsBase
	{
		public enum BlurType
		{
			Standard = 0,
			Sgx = 1,
		}

		public float threshold;
		public float intensity;
		public float blurSize;
		public int blurIterations;
		public BlurType blurType;
		public Shader fastBloomShader;
	}
}
