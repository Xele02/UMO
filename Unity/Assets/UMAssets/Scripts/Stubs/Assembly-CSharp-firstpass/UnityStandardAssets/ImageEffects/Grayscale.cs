using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class Grayscale : ImageEffectBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		public Texture textureRamp;
		public float rampOffset;
	}
}
