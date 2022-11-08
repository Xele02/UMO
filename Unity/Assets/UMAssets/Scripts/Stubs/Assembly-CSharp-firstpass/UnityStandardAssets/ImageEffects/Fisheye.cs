using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class Fisheye : PostEffectsBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		public float strengthX;
		public float strengthY;
		public Shader fishEyeShader;
	}
}
