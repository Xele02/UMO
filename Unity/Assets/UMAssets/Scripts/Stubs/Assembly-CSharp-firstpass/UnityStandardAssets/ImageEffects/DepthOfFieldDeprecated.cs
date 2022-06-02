using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class DepthOfFieldDeprecated : PostEffectsBase
	{
		public enum Dof34QualitySetting
		{
			OnlyBackground = 1,
			BackgroundAndForeground = 2,
		}

		public enum DofResolution
		{
			High = 2,
			Medium = 3,
			Low = 4,
		}

		public enum DofBlurriness
		{
			Low = 1,
			High = 2,
			VeryHigh = 4,
		}

		public enum BokehDestination
		{
			Background = 1,
			Foreground = 2,
			BackgroundAndForeground = 3,
		}

		public Dof34QualitySetting quality;
		public DofResolution resolution;
		public bool simpleTweakMode;
		public float focalPoint;
		public float smoothness;
		public float focalZDistance;
		public float focalZStartCurve;
		public float focalZEndCurve;
		public Transform objectFocus;
		public float focalSize;
		public DofBlurriness bluriness;
		public float maxBlurSpread;
		public float foregroundBlurExtrude;
		public Shader dofBlurShader;
		public Shader dofShader;
		public bool visualize;
		public BokehDestination bokehDestination;
		public bool bokeh;
		public bool bokehSupport;
		public Shader bokehShader;
		public Texture2D bokehTexture;
		public float bokehScale;
		public float bokehIntensity;
		public float bokehThresholdContrast;
		public float bokehThresholdLuminance;
		public int bokehDownsample;
	}
}
