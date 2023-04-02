using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using CriWare;

namespace XeApp.Game.Menu
{
	public class LayoutIntimacyInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_numExpNow; // 0x14
		[SerializeField]
		private NumberBase m_numExpNext; // 0x18
		[SerializeField]
		private NumberBase m_numLevel; // 0x1C
		[SerializeField]
		private NumberBase[] m_numPoint; // 0x20
		[SerializeField]
		private NumberBase m_numBonus; // 0x24
		private AbsoluteLayout m_layoutRoot; // 0x28
		private AbsoluteLayout m_layoutPoint; // 0x2C
		private AbsoluteLayout m_layoutPointAnim; // 0x30
		private AbsoluteLayout[] m_layoutPointAnimTbl; // 0x34
		private AbsoluteLayout m_layoutExpDigit; // 0x38
		private AbsoluteLayout m_layoutLevel; // 0x3C
		private AbsoluteLayout m_layoutLevelMax; // 0x40
		private AbsoluteLayout m_layoutGauge; // 0x44
		private JJOELIOGMKK_DivaIntimacyInfo m_viewData; // 0x48
		private CriAtomExPlayback m_countUpSEPlayback; // 0x4C
		private bool m_isShown; // 0x50

		// RVA: 0x1D5201C Offset: 0x1D5201C VA: 0x1D5201C
		private void OnDisable()
		{
			m_countUpSEPlayback.Stop();
		}

		// // RVA: 0x1D52034 Offset: 0x1D52034 VA: 0x1D52034
		// public void Setup(JJOELIOGMKK viewData, bool isHome) { }

		// // RVA: 0x1D5246C Offset: 0x1D5246C VA: 0x1D5246C
		// public void TryEnter() { }

		// // RVA: 0x1D5253C Offset: 0x1D5253C VA: 0x1D5253C
		// public void TryLeave() { }

		// // RVA: 0x1D5247C Offset: 0x1D5247C VA: 0x1D5247C
		// public void Enter() { }

		// // RVA: 0x1D5254C Offset: 0x1D5254C VA: 0x1D5254C
		// public void Leave() { }

		// // RVA: 0x1D525E0 Offset: 0x1D525E0 VA: 0x1D525E0
		// public void Show() { }

		// // RVA: 0x1D52664 Offset: 0x1D52664 VA: 0x1D52664
		// public void Hide() { }

		// // RVA: 0x1D526E8 Offset: 0x1D526E8 VA: 0x1D526E8
		// public void StartPointUp(Action callback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E762C Offset: 0x6E762C VA: 0x6E762C
		// // RVA: 0x1D5270C Offset: 0x1D5270C VA: 0x1D5270C
		// private IEnumerator Co_StartPointUp(Action callback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E76A4 Offset: 0x6E76A4 VA: 0x6E76A4
		// // RVA: 0x1D527D4 Offset: 0x1D527D4 VA: 0x1D527D4
		// private IEnumerator Co_CountPoint(List<Coroutine> coutupCoroutines, int point, int bonus) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E771C Offset: 0x6E771C VA: 0x6E771C
		// // RVA: 0x1D528CC Offset: 0x1D528CC VA: 0x1D528CC
		// private IEnumerator Co_CountBonus(List<Coroutine> coutupCoroutines, int point, int bonus) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E7794 Offset: 0x6E7794 VA: 0x6E7794
		// // RVA: 0x1D529C0 Offset: 0x1D529C0 VA: 0x1D529C0
		// private IEnumerator Co_CountUpAnim(int point, int bonus) { }

		// // RVA: 0x1D523A8 Offset: 0x1D523A8 VA: 0x1D523A8
		// private void UpdateGaugePosition(float normalizePos) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6E780C Offset: 0x6E780C VA: 0x6E780C
		// // RVA: 0x1D52AA0 Offset: 0x1D52AA0 VA: 0x1D52AA0
		// private IEnumerator Co_ExpGaugeAnim(Action<bool> callback) { }

		// // RVA: 0x1D52B68 Offset: 0x1D52B68 VA: 0x1D52B68
		// private void LevelupProcess(int level) { }

		// // RVA: 0x1D52BF8 Offset: 0x1D52BF8 VA: 0x1D52BF8
		// private void LevelMaxProcess(int level) { }

		// // RVA: 0x1D52248 Offset: 0x1D52248 VA: 0x1D52248
		// private void SetLevel(int value) { }

		// // RVA: 0x1D52288 Offset: 0x1D52288 VA: 0x1D52288
		// private void SetExp(int now, int next) { }

		// // RVA: 0x1D52C9C Offset: 0x1D52C9C VA: 0x1D52C9C
		// private string GetDigitLabel(int num) { }

		// // RVA: 0x1D52D78 Offset: 0x1D52D78 VA: 0x1D52D78
		// private void SetUpPoint(int value) { }

		// // RVA: 0x1D52E1C Offset: 0x1D52E1C VA: 0x1D52E1C
		// private void SetUpBonus(int value) { }

		// // RVA: 0x1D52E5C Offset: 0x1D52E5C VA: 0x1D52E5C
		// private void PlayCountUpLoopSE() { }

		// // RVA: 0x1D52028 Offset: 0x1D52028 VA: 0x1D52028
		// private void StopCountUpLoopSE() { }

		// RVA: 0x1D52EBC Offset: 0x1D52EBC VA: 0x1D52EBC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("swtbl_gauge_pos") as AbsoluteLayout;
			m_layoutPoint = layout.FindViewById("swtbl_fs_p_01") as AbsoluteLayout;
			m_layoutExpDigit = layout.FindViewById("swtbl_fs_num") as AbsoluteLayout;
			m_layoutLevel = layout.FindViewById("sw_gauge_fs_anim_01") as AbsoluteLayout;
			m_layoutLevelMax = layout.FindViewById("swtbl_fs_lv_max") as AbsoluteLayout;
			m_layoutGauge = layout.FindViewById("swfrm_fs") as AbsoluteLayout;
			m_layoutPointAnimTbl = new AbsoluteLayout[2];
			m_layoutPointAnimTbl[0] = layout.FindViewById("sw_fs_p_anim_01") as AbsoluteLayout;
			m_layoutPointAnimTbl[1] = layout.FindViewById("sw_fs_p_anim_02") as AbsoluteLayout;
			m_layoutRoot.StartAllAnimGoStop("st_wait");
			Loaded();
			return true;
		}
	}
}
