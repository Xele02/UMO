using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	internal class GlobalFog : PostEffectsBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		public bool distanceFog;
		public bool excludeFarPixels;
		public bool useRadialDistance;
		public bool heightFog;
		public float height;
		public float heightDensity;
		public float startDistance;
		public Shader fogShader;
	}
}
