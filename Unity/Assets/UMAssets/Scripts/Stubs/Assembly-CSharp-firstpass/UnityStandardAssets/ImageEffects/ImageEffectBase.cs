using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class ImageEffectBase : MonoBehaviour
	{
		public Shader shader;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
