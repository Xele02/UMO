using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class NoiseAndGrain : PostEffectsBase
	{
		public float intensityMultiplier;
		public float generalIntensity;
		public float blackIntensity;
		public float whiteIntensity;
		public float midGrey;
		public bool dx11Grain;
		public float softness;
		public bool monochrome;
		public Vector3 intensities;
		public Vector3 tiling;
		public float monochromeTiling;
		public FilterMode filterMode;
		public Texture2D noiseTexture;
		public Shader noiseShader;
		public Shader dx11NoiseShader;
	}
}
