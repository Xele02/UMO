
using UnityEngine;

namespace XeApp
{ 
	internal class ReactionPhrase : MonoBehaviour
	{
		private GameObject glad; // 0xC
		private GameObject angry; // 0x10

		//// RVA: 0x1924038 Offset: 0x1924038 VA: 0x1924038
		//public static ReactionPhrase Instantiate(Transform scaled, DecorationChara chara) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6ABB38 Offset: 0x6ABB38 VA: 0x6ABB38
		//// RVA: 0x19244D4 Offset: 0x19244D4 VA: 0x19244D4
		//private IEnumerator Co_LoadPhrase(int id, Transform parent, Transform scaled, Action<GameObject> receive) { }

		// RVA: 0x19245CC Offset: 0x19245CC VA: 0x19245CC
		public void SetGlad(bool active)
		{
			if (glad != null)
				glad.SetActive(active);
		}

		//// RVA: 0x1924684 Offset: 0x1924684 VA: 0x1924684
		public void SetAngry(bool active)
		{
			if (angry != null)
				angry.SetActive(active);
		}

		//// RVA: 0x192473C Offset: 0x192473C VA: 0x192473C
		public void HideAll()
		{
			SetGlad(false);
			SetAngry(false);
		}
	}
}
