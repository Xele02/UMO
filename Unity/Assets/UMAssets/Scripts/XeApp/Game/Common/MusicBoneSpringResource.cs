using UnityEngine;

namespace XeApp.Game.Common
{
	public class MusicBoneSpringResource : MonoBehaviour
	{
		private static readonly int CutinLimit = 3; // 0x0
		public bool isUnused = true; // 0xC
		public RuntimeAnimatorController animatorController; // 0x10
		public AnimationClip clip; // 0x14

		public bool isLoaded { get; private set; } // 0x18
		// public bool isAllLoaded { get; private set; } 0x1118AB4 0x1118AD8

		// // RVA: 0x111878C Offset: 0x111878C VA: 0x111878C
		// public void OnDestroy() { }

		// // RVA: 0x11187A8 Offset: 0x11187A8 VA: 0x11187A8
		public void LoadMusicResouces(int wavId, int primeId, int stageDivaNum, int positionId = 0)
		{
			UnityEngine.Debug.LogError("TODO LoadMusicResouces");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x739BEC Offset: 0x739BEC VA: 0x739BEC
		// // RVA: 0x11187E0 Offset: 0x11187E0 VA: 0x11187E0
		// private IEnumerator Co_LoadAllResouces(int wavId, int primeId, int stageDivaNum, int positionId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x739C64 Offset: 0x739C64 VA: 0x739C64
		// // RVA: 0x11188F4 Offset: 0x11188F4 VA: 0x11188F4
		// private IEnumerator Co_LoadAnimatorResouces() { }

		// [IteratorStateMachineAttribute] // RVA: 0x739CDC Offset: 0x739CDC VA: 0x739CDC
		// // RVA: 0x11189A0 Offset: 0x11189A0 VA: 0x11189A0
		// private IEnumerator Co_LoadMusicResouces(int wavId, int primeId, int stageDivaNum, int positionId) { }
	}
}
