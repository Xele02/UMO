using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class ColorCorrectionLookup : PostEffectsBase
	{
		public Shader shader;
		public Texture3D converted3DLut;
		public string basedOnTempTex;
	}
}
