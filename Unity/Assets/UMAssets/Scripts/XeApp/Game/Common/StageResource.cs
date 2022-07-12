using System;
using UnityEngine;
using XeApp.Game;

namespace XeApp.Game.Common
{
	public class StageResource : MonoBehaviour
	{
		public GameObject prefab; // 0xC
		public StageParam param; // 0x10

		public bool isLoadedPrefab { get; private set; } // 0x14
		public bool isAllLoaded { get { return isLoadedPrefab; } private set {} } //0x1CC95FC 0x1CC9604


		// // RVA: 0x1CC94D0 Offset: 0x1CC94D0 VA: 0x1CC94D0
		// public void OnDestroy() { }

		// // RVA: 0x1CC94EC Offset: 0x1CC94EC VA: 0x1CC94EC
		public void LoadResouces(int stageId, Func<int> getSpecialStageId)
		{
			UnityEngine.Debug.LogError("TODO LoadResouces");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73B5C0 Offset: 0x73B5C0 VA: 0x73B5C0
		// // RVA: 0x1CC951C Offset: 0x1CC951C VA: 0x1CC951C
		// private IEnumerator Co_LoadResouces(int stageId, Func<int> getSpecialStageId) { }
	}
}
