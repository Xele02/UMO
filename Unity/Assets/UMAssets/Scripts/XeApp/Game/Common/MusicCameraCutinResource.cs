using UnityEngine;

namespace XeApp.Game.Common
{
	public class MusicCameraCutinResource : MonoBehaviour
	{
		private static readonly int CutinLimit = 3; // 0x0
		public bool isUnused = true; // 0xC
		public AnimationClip clip; // 0x10
		public RuntimeAnimatorController animatorController; // 0x14
		public AnimationClip[] cutinClips; // 0x18
		
		public bool isLoaded { get; private set; } // 0x1C
		public bool isAllLoaded { get { return isUnused || isLoaded; } private set {} } //0x111A5A4 0x111A5C8

		// // RVA: 0x111A2C0 Offset: 0x111A2C0 VA: 0x111A2C0
		// public void OnDestroy() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A10C Offset: 0x73A10C VA: 0x73A10C
		// // RVA: 0x111A2CC Offset: 0x111A2CC VA: 0x111A2CC
		// public bool get_isLoaded() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73A11C Offset: 0x73A11C VA: 0x73A11C
		// // RVA: 0x111A2D4 Offset: 0x111A2D4 VA: 0x111A2D4
		// private void set_isLoaded(bool value) { }

		// // RVA: 0x111A2DC Offset: 0x111A2DC VA: 0x111A2DC
		// public void LoadResouces(int wavId, int assetId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73A12C Offset: 0x73A12C VA: 0x73A12C
		// // RVA: 0x111A308 Offset: 0x111A308 VA: 0x111A308
		// private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73A1A4 Offset: 0x73A1A4 VA: 0x73A1A4
		// // RVA: 0x111A400 Offset: 0x111A400 VA: 0x111A400
		// private IEnumerator Co_LoadBasicResouces() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73A21C Offset: 0x73A21C VA: 0x73A21C
		// // RVA: 0x111A4AC Offset: 0x111A4AC VA: 0x111A4AC
		// private IEnumerator Co_LoadMusicResouces(int wavId, int assetId, int stageDivaNum) { }
	}
}
