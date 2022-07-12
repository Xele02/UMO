using UnityEngine;
using XeApp.Game;

namespace XeApp.Game.Common
{
	public class MusicCameraResource : MonoBehaviour
	{
		public RuntimeAnimatorController animator; // 0xC
		public AnimationClip clip; // 0x10
		public MusicCameraParam m_param; // 0x14

		public bool isAllLoaded { get { return isLoadedAnimator && isLoadedMusicClip && isLoadedParam; } private set {} } //0xAE547C 0xAE54C0
		private bool isLoadedAnimator { get; set; } // 0x18
		private bool isLoadedMusicClip { get; set; } // 0x19
		private bool isLoadedParam { get; set; } // 0x1A

		// // RVA: 0xAE534C Offset: 0xAE534C VA: 0xAE534C
		// public void OnDestroy() { }

		// // RVA: 0xAE535C Offset: 0xAE535C VA: 0xAE535C
		public void LoadResource(int wavId, int primeId, int stageDivaNum)
		{
			UnityEngine.Debug.LogError("TODO LoadResource");
		}

		// // RVA: 0xAE5414 Offset: 0xAE5414 VA: 0xAE5414
		// private void LoadAnimatorResouces() { }

		// [IteratorStateMachineAttribute] // RVA: 0x739E64 Offset: 0x739E64 VA: 0x739E64
		// // RVA: 0xAE54CC Offset: 0xAE54CC VA: 0xAE54CC
		// private IEnumerator Co_LoadAnimator() { }

		// // RVA: 0xAE5444 Offset: 0xAE5444 VA: 0xAE5444
		// private void LoadMusicClipResouces(int wavId, int primeId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x739EFC Offset: 0x739EFC VA: 0x739EFC
		// // RVA: 0xAE5580 Offset: 0xAE5580 VA: 0xAE5580
		// private IEnumerator Co_LoadMusicClipResouces(int wavId, int primeId, int stageDivaNum) { }

		// // RVA: 0xAE53E4 Offset: 0xAE53E4 VA: 0xAE53E4
		// private void LoadParam(int wavId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x739F94 Offset: 0x739F94 VA: 0x739F94
		// // RVA: 0xAE5680 Offset: 0xAE5680 VA: 0xAE5680
		// private IEnumerator Co_LoadParam(int waveId, int stageDivaNum) { }
	}
}
