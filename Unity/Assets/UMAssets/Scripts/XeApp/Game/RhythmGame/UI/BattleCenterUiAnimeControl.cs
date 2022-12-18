using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class BattleCenterUiAnimeControl : MonoBehaviour
	{
		public enum AnimationLayers
		{
			BaseLayer = 0,
			Ring = 1,
			Loop = 2,
			Out = 3,
		}

		[SerializeField]
		private Animator m_animator; // 0xC
		[SerializeField]
		private BattleCenterRingUvChanger[] m_ringUvChanger; // 0x10
		private readonly int AnimatorParamIsMax = Animator.StringToHash("IsMax"); // 0x14
		private readonly int AnimatorStateIn = Animator.StringToHash("C_UI_B_IN"); // 0x18
		private readonly int AnimatorStateOut = Animator.StringToHash("C_UI_B_OUT"); // 0x1C
		private readonly int AnimatorStateFailed = Animator.StringToHash("OUT"); // 0x20

		// // RVA: 0x1558420 Offset: 0x1558420 VA: 0x1558420
		public void Initialize()
		{
			m_animator.Play(AnimatorStateFailed, 3, 1);
		}

		// // RVA: 0x1558468 Offset: 0x1558468 VA: 0x1558468
		// public void SetComboMax(bool isMax) { }

		// // RVA: 0x15584A4 Offset: 0x15584A4 VA: 0x15584A4
		// public void Show() { }

		// // RVA: 0x1558520 Offset: 0x1558520 VA: 0x1558520
		// public void Hide() { }

		// // RVA: 0x1558568 Offset: 0x1558568 VA: 0x1558568
		// public void TargetLost() { }

		// // RVA: 0x15585B0 Offset: 0x15585B0 VA: 0x15585B0
		// public bool IsPlayingTargetLost() { }
	}
}
