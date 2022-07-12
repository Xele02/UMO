using UnityEngine;

namespace XeApp.Game.Common
{
	public class DivaCutinResource : MonoBehaviour
	{
		public static readonly int CutinLimit = 3; // 0x0
		public bool isUnused = true; // 0xC
		public AnimationClip clip; // 0x10
		public AnimationClip clipBoneSpring; // 0x14
		public RuntimeAnimatorController animatorController; // 0x18
		public AnimationClip[] cutinBodyClips; // 0x1C
		public AnimationClip[] cutinFaceClips; // 0x20
		public AnimationClip[] cutinMouthClips; // 0x24
		public AnimationClip[] cutinMikeClips; // 0x28
		public AnimationClip[] cutinBoneSpringClips; // 0x2C
		public int divaId; // 0x30

		public bool isLoaded { get; private set; } // 0x34
		public bool isAllLoaded { get { return isUnused || isLoaded; } private set {} } //0x1BE79DC 0x1BE7A00

		// RVA: 0x1BE76EC Offset: 0x1BE76EC VA: 0x1BE76EC
		// public void OnDestroy() { }

		// // RVA: 0x1BE7708 Offset: 0x1BE7708 VA: 0x1BE7708
		// public void LoadResouces(int wavId, int assetId, int divaId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7379F8 Offset: 0x7379F8 VA: 0x7379F8
		// // RVA: 0x1BE7740 Offset: 0x1BE7740 VA: 0x1BE7740
		// private IEnumerator Co_LoadAllResouces(int wavId, int assetId, int stageDivaNum) { }

		// [IteratorStateMachineAttribute] // RVA: 0x737A70 Offset: 0x737A70 VA: 0x737A70
		// // RVA: 0x1BE7838 Offset: 0x1BE7838 VA: 0x1BE7838
		// private IEnumerator Co_LoadBasicResouces() { }

		// [IteratorStateMachineAttribute] // RVA: 0x737AE8 Offset: 0x737AE8 VA: 0x737AE8
		// // RVA: 0x1BE78E4 Offset: 0x1BE78E4 VA: 0x1BE78E4
		// private IEnumerator Co_LoadMusicResouces(int wavId, int assetId, int stageDivaNum) { }
	}
}
