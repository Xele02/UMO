using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class ColorCorrectionCurves : PostEffectsBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public enum ColorCorrectionMode
		{
			Simple = 0,
			Advanced = 1,
		}

		public AnimationCurve redChannel;
		public AnimationCurve greenChannel;
		public AnimationCurve blueChannel;
		public bool useDepthCorrection;
		public AnimationCurve zCurve;
		public AnimationCurve depthRedChannel;
		public AnimationCurve depthGreenChannel;
		public AnimationCurve depthBlueChannel;
		public float saturation;
		public bool selectiveCc;
		public Color selectiveFromColor;
		public Color selectiveToColor;
		public ColorCorrectionMode mode;
		public bool updateTextures;
		public Shader colorCorrectionCurvesShader;
		public Shader simpleColorCorrectionCurvesShader;
		public Shader colorCorrectionSelectiveShader;
	}
}
