using UnityEngine;

namespace Firebase.Platform
{
	internal class FirebaseMonoBehaviour : MonoBehaviour
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
