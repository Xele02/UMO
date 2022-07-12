using UnityEngine;

namespace XeApp.Game.Common
{
	public class StageLightingResource : MonoBehaviour
	{
		public static readonly int MAX_CLIP_ADD = 5; // 0x0
		public bool isUnused = true; // 0xC
		public AnimationClip clip; // 0x10
		public AnimationClip[] clip_add = new AnimationClip[MAX_CLIP_ADD]; // 0x14
		public RuntimeAnimatorController animatorController; // 0x18
		private int targetDivaId; // 0x1C
		
		public bool isLoadedAnim { get; private set; } // 0x20
		public bool isAllLoaded { get { return isUnused || isLoadedAnim; } private set {} } //0x1CC7D9C 0x1CC7DC0

		// // RVA: 0x1CC79E0 Offset: 0x1CC79E0 VA: 0x1CC79E0
		// public void OnDestroy() { }

		// // RVA: 0x1CC7AD4 Offset: 0x1CC7AD4 VA: 0x1CC7AD4
		// public void LoadResouces(int wavId, int assetId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73BAF0 Offset: 0x73BAF0 VA: 0x73BAF0
		// // RVA: 0x1CC7B00 Offset: 0x1CC7B00 VA: 0x1CC7B00
		// private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73BB68 Offset: 0x73BB68 VA: 0x73BB68
		// // RVA: 0x1CC7BF8 Offset: 0x1CC7BF8 VA: 0x1CC7BF8
		// private IEnumerator Co_LoadBasicResouces() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73BBE0 Offset: 0x73BBE0 VA: 0x73BBE0
		// // RVA: 0x1CC7CA4 Offset: 0x1CC7CA4 VA: 0x1CC7CA4
		// private IEnumerator Co_LoadMusicResouces(int wavId, int assetId, int stageDivaNum) { }
	}
}
