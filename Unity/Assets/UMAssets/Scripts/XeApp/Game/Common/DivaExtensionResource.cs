using UnityEngine;
using XeApp.Game;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaExtensionResource : MonoBehaviour
	{
		public bool isUnused = true; // 0xC
		public MusicExtensionPrefabParam param; // 0x10
		public List<GameObject> prefabList; // 0x14
		public int divaId; // 0x18
		public AnimationClip clip; // 0x1C
		public RuntimeAnimatorController animatorController; // 0x20

		public bool isLoaded { get; private set; } // 0x24
		public bool isAllLoaded { get { return isUnused || isLoaded; } private set { } } //0x1BEF430 0x1BEF454

		// // RVA: 0x1BEF140 Offset: 0x1BEF140 VA: 0x1BEF140
		// public void OnDestroy() { }

		// // RVA: 0x1BEF15C Offset: 0x1BEF15C VA: 0x1BEF15C
		// public void LoadResouces(int wavId, int assetId, int divaId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x737D38 Offset: 0x737D38 VA: 0x737D38
		// // RVA: 0x1BEF194 Offset: 0x1BEF194 VA: 0x1BEF194
		// private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x737DB0 Offset: 0x737DB0 VA: 0x737DB0
		// // RVA: 0x1BEF28C Offset: 0x1BEF28C VA: 0x1BEF28C
		// private IEnumerator Co_LoadBasicResouces() { }

		// [IteratorStateMachineAttribute] // RVA: 0x737E28 Offset: 0x737E28 VA: 0x737E28
		// // RVA: 0x1BEF338 Offset: 0x1BEF338 VA: 0x1BEF338
		// private IEnumerator Co_LoadMusicResouces(int wavId, int assetId, int stageDivaNum) { }
	}
}
