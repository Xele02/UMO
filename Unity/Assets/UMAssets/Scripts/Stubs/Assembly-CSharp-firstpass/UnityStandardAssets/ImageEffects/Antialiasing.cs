using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class Antialiasing : PostEffectsBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public AAMode mode;
		public bool showGeneratedNormals;
		public float offsetScale;
		public float blurRadius;
		public float edgeThresholdMin;
		public float edgeThreshold;
		public float edgeSharpness;
		public bool dlaaSharp;
		public Shader ssaaShader;
		public Shader dlaaShader;
		public Shader nfaaShader;
		public Shader shaderFXAAPreset2;
		public Shader shaderFXAAPreset3;
		public Shader shaderFXAAII;
		public Shader shaderFXAAIII;
	}
}
