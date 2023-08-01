using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class ColorCorrectionLookup : PostEffectsBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public Shader shader;
		public Texture3D converted3DLut;
		public string basedOnTempTex;
	}
}
