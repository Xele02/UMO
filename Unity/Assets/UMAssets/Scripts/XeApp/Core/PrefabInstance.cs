using UnityEngine;

namespace XeApp.Core
{
	public class PrefabInstance : MonoBehaviour
	{
		[SerializeField]
		private GameObject prefab; // 0xC

		public GameObject Instance { get; private set; } // 0x10

		// RVA: 0x1D74A70 Offset: 0x1D74A70 VA: 0x1D74A70
		public void Initialize()
		{
			if (Instance != null)
				return;
			Instance = Instantiate(prefab);
			Instance.transform.SetParent(transform, false);
		}
	}
}
