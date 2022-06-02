using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class NoiseAndScratches : MonoBehaviour
	{
		public bool monochrome;
		public float grainIntensityMin;
		public float grainIntensityMax;
		public float grainSize;
		public float scratchIntensityMin;
		public float scratchIntensityMax;
		public float scratchFPS;
		public float scratchJitter;
		public Texture grainTexture;
		public Texture scratchTexture;
		public Shader shaderRGB;
		public Shader shaderYUV;
	}
}
