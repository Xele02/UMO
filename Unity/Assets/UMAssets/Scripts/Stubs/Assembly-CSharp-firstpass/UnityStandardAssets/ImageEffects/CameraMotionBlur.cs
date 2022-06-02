using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class CameraMotionBlur : PostEffectsBase
	{
		public enum MotionBlurFilter
		{
			CameraMotion = 0,
			LocalBlur = 1,
			Reconstruction = 2,
			ReconstructionDX11 = 3,
			ReconstructionDisc = 4,
		}

		public MotionBlurFilter filterType;
		public bool preview;
		public Vector3 previewScale;
		public float movementScale;
		public float rotationScale;
		public float maxVelocity;
		public float minVelocity;
		public float velocityScale;
		public float softZDistance;
		public int velocityDownsample;
		public LayerMask excludeLayers;
		public Shader shader;
		public Shader dx11MotionBlurShader;
		public Shader replacementClear;
		public Texture2D noiseTexture;
		public float jitter;
		public bool showVelocity;
		public float showVelocityScale;
	}
}
