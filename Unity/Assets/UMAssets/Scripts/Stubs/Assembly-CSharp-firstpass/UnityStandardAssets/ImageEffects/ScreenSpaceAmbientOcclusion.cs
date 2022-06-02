using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class ScreenSpaceAmbientOcclusion : MonoBehaviour
	{
		public enum SSAOSamples
		{
			Low = 0,
			Medium = 1,
			High = 2,
		}

		public float m_Radius;
		public SSAOSamples m_SampleCount;
		public float m_OcclusionIntensity;
		public int m_Blur;
		public int m_Downsampling;
		public float m_OcclusionAttenuation;
		public float m_MinZ;
		public Shader m_SSAOShader;
		public Texture2D m_RandomTexture;
	}
}
