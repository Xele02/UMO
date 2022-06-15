using UnityEngine;

namespace XeApp.Game.Common
{
	public class MusicIntroResource : MonoBehaviour
	{
		// public MusicIntroResource.OverrideAnimationClip m_override_anim = new MusicIntroResource.OverrideAnimationClip(); // 0x1C

		public GameObject runwayPrefab { get; private set; } // 0xC
		public GameObject enviromentPrefab { get; private set; } // 0x10
		public ValkyrieColorParam paramColor { get; private set; } // 0x14
		// public ValkyrieIntroParam paramIntro { get; private set; } // 0x18
		public bool isLoadedRunway { get; private set; } // 0x20
		public bool isLoadedEnviroment { get; private set; } // 0x21
		public bool isLoadedAnimator { get; private set; } // 0x22
		// public bool isAllLoaded { get; } 0xAEA888

		// // RVA: 0xAEA8B4 Offset: 0xAEA8B4 VA: 0xAEA8B4
		// public void OnDestroy() { }

		// // RVA: 0xAEA8CC Offset: 0xAEA8CC VA: 0xAEA8CC
		// public void LoadResources(int runwayId, int enviromentId, int valkyrieId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x7395B4 Offset: 0x7395B4 VA: 0x7395B4
		// // RVA: 0xAEA904 Offset: 0xAEA904 VA: 0xAEA904
		// private IEnumerator Co_LoadResources(int runwayId, int enviromentId, int valkyrieId) { }

		// // RVA: 0xAEA9FC Offset: 0xAEA9FC VA: 0xAEA9FC
		public void OverrideMusicStartTime(ref float a_sec)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xAEAAD4 Offset: 0xAEAAD4 VA: 0xAEAAD4
		// public void OverrideIntroEndTime(ref int a_msec) { }
	}
}
