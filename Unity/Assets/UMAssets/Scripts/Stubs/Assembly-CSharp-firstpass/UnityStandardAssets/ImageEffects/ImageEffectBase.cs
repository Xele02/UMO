using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class ImageEffectBase : MonoBehaviour
	{
		public Shader shader;
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement Monobehaviour");
		}
	}
}
