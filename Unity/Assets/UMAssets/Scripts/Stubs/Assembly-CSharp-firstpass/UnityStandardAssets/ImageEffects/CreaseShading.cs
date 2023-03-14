using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class CreaseShading : PostEffectsBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		public float intensity;
		public int softness;
		public float spread;
		public Shader blurShader;
		public Shader depthFetchShader;
		public Shader creaseApplyShader;
	}
}
