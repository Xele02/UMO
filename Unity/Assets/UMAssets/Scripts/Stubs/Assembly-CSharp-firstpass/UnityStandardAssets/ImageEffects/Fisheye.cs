using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class Fisheye : PostEffectsBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public float strengthX;
		public float strengthY;
		public Shader fishEyeShader;
	}
}
