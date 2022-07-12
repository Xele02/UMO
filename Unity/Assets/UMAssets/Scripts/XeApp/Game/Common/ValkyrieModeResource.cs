using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieModeResource : MonoBehaviour
	{
		public GameObject mainPrefab { get; private set; } // 0xC
		public ValkyrieColorParam paramColor { get; private set; } // 0x10
		public AnimationClip changeCameraBeginAnimClip { get; private set; } // 0x14
		public bool isLoadedMain { get; private set; } // 0x18
		// public bool isAllLoaded { get; } 0xD27000

		// // RVA: 0xD27008 Offset: 0xD27008 VA: 0xD27008
		// public void OnDestroy() { }

		// // RVA: 0xD27018 Offset: 0xD27018 VA: 0xD27018
		public void LoadResources(int id, int valkyrie_id)
		{
			UnityEngine.Debug.LogError("TODO LoadResources");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73CB00 Offset: 0x73CB00 VA: 0x73CB00
		// // RVA: 0xD27048 Offset: 0xD27048 VA: 0xD27048
		// private IEnumerator Co_LoadResources(int id, int valkyrie_id) { }
	}
}
