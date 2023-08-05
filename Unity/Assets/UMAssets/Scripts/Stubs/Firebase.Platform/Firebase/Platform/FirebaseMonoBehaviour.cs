using UnityEngine;

namespace Firebase.Platform
{
	internal class FirebaseMonoBehaviour : MonoBehaviour
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
