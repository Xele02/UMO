using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	internal class GlobalFog : PostEffectsBase
	{
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
