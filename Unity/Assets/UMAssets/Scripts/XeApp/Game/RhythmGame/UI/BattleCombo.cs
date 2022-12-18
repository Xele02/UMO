using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class BattleCombo : MonoBehaviour
	{
		[SerializeField]
		private Animator m_comboRootAnimator; // 0xC
		[SerializeField]
		private Animator m_comboAnimator; // 0x10
		[SerializeField]
		private Animator m_attackUpRootAnimator; // 0x14
		private int m_prevLevel; // 0x18
		private static readonly int attack_up_start_Hash = Animator.StringToHash("attack_up_start"); // 0x0
		private static readonly int attack_up_end_Hash = Animator.StringToHash("attack_up_end"); // 0x4
		private static readonly int combo_lvMAX_add_Hash = Animator.StringToHash("combo_lvMAX_add"); // 0x8
		private static readonly int[] ComboLevelAnimeStates = new int[5] {
			Animator.StringToHash("combo_lv0_ON"), Animator.StringToHash("combo_lv1_ON"),
			Animator.StringToHash("combo_lv2_ON"), Animator.StringToHash("combo_lv3_ON"),
			Animator.StringToHash("combo_lv4_ON")
		}; // 0xC
		private static readonly int[] ComboLevelCloseAnimeStates = new int[4] {
			Animator.StringToHash("combo_lv1_OFF"), Animator.StringToHash("combo_lv2_OFF"),
			Animator.StringToHash("combo_lv3_OFF"), Animator.StringToHash("combo_lv4_OFF")
		}; // 0x10
		private static readonly int[] ComboLevelFaildCloseAnimeStates = new int[4] {
			Animator.StringToHash("combo_lv1_kaijo_OFF"), Animator.StringToHash("combo_lv2_kaijo_OFF"),
			Animator.StringToHash("combo_lv3_kaijo_OFF"), Animator.StringToHash("combo_lv4_kaijo_OFF")
		}; // 0x14
		private static readonly int LoopEndTriggerHash = Animator.StringToHash("LoopEnd"); // 0x18
		private static readonly int ComboMax = -1; // 0x1C

		// RVA: 0x155870C Offset: 0x155870C VA: 0x155870C
		public void Initialize()
		{
			m_comboAnimator.Play(ComboLevelAnimeStates[0], 0, 0);
			if(m_comboRootAnimator != null)
			{
				m_comboRootAnimator.Play(combo_lvMAX_add_Hash, 0, 1);
			}
			m_prevLevel = 0;
		}

		// // RVA: 0x15588C8 Offset: 0x15588C8 VA: 0x15588C8
		// public void Show() { }

		// // RVA: 0x15588CC Offset: 0x15588CC VA: 0x15588CC
		// public void Hide(bool isFaild = False) { }

		// // RVA: 0x1558B98 Offset: 0x1558B98 VA: 0x1558B98
		// public bool UpdateCombo(int combo) { }
	}
}
