using UnityEngine;
using XeApp.Game;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class StageExtensionResource : MonoBehaviour
	{
		public bool isUnused = true; // 0xC
		public MusicExtensionPrefabParam param; // 0x10
		public MusicExtensionPrefabMovieParam paramMovie; // 0x14
		public List<GameObject> prefabList; // 0x18
		public AnimationClip clip; // 0x1C
		public RuntimeAnimatorController animatorController; // 0x20
		public CriManaMovieController moviePlayer; // 0x24
		public Material movieMaterial; // 0x28
		private bool isMovieMaterialAdd; // 0x2C

		public bool isLoaded { get; private set; } // 0x2D
		public bool isAllLoaded { get { return isUnused || isLoaded; } private set {} } //0x13A3864 0x13A3888

		// // RVA: 0x13A3454 Offset: 0x13A3454 VA: 0x13A3454
		// public void OnDestroy() { }

		// // RVA: 0x13A3474 Offset: 0x13A3474 VA: 0x13A3474
		// public void LoadResouces(int wavId, int divaId, int assetId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73B7B0 Offset: 0x73B7B0 VA: 0x73B7B0
		// // RVA: 0x13A34AC Offset: 0x13A34AC VA: 0x13A34AC
		// private IEnumerator Co_LoadAllResouces(int wavId, int divaId, int assetId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73B828 Offset: 0x73B828 VA: 0x73B828
		// // RVA: 0x13A35C0 Offset: 0x13A35C0 VA: 0x13A35C0
		// private IEnumerator Co_LoadBasicResouces() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73B8A0 Offset: 0x73B8A0 VA: 0x73B8A0
		// // RVA: 0x13A366C Offset: 0x13A366C VA: 0x13A366C
		// private IEnumerator Co_LoadMusicResouces(int wavId, int divaId, int assetId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73B918 Offset: 0x73B918 VA: 0x73B918
		// // RVA: 0x13A3784 Offset: 0x13A3784 VA: 0x13A3784
		// private IEnumerator Co_LoadMovieResource(int wavId, int divaId) { }
	}
}
