using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class EdgeDetection : PostEffectsBase
	{
		public enum EdgeDetectMode
		{
			TriangleDepthNormals = 0,
			RobertsCrossDepthNormals = 1,
			SobelDepth = 2,
			SobelDepthThin = 3,
			TriangleLuminance = 4,
		}

		public EdgeDetectMode mode;
		public float sensitivityDepth;
		public float sensitivityNormals;
		public float lumThreshold;
		public float edgeExp;
		public float sampleDist;
		public float edgesOnly;
		public Color edgesOnlyBgColor;
		public Shader edgeDetectShader;
	}
}
