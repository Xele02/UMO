using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	internal class ScreenSpaceAmbientObscurance : PostEffectsBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		public float intensity;
		public float radius;
		public int blurIterations;
		public float blurFilterDistance;
		public int downsample;
		public Texture2D rand;
		public Shader aoShader;
	}
}
