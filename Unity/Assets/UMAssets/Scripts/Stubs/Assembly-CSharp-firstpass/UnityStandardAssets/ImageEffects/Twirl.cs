using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class Twirl : ImageEffectBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		public Vector2 radius;
		public float angle;
		public Vector2 center;
	}
}
