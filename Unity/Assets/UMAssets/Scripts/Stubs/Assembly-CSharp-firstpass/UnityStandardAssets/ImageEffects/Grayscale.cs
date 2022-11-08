using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class Grayscale : ImageEffectBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		public Texture textureRamp;
		public float rampOffset;
	}
}
