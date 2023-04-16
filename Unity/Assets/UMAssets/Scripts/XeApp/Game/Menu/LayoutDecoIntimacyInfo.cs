using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine;
using CriWare;

namespace XeApp.Game.Menu
{
	public class LayoutDecoIntimacyInfo : LayoutUGUIScriptBase
	{
		[Serializable]
		private class Variables
		{
			public NumberBase m_numExpNow; // 0x8
			public NumberBase m_numExpNext; // 0xC
			public NumberBase m_numLevel; // 0x10
			public NumberBase[] m_numPoint; // 0x14
			public AbsoluteLayout m_layoutPoint; // 0x18
			public AbsoluteLayout m_layoutPointAnim; // 0x1C
			public AbsoluteLayout[] m_layoutPointAnimTbl; // 0x20
			public AbsoluteLayout m_layoutExpDigit; // 0x24
			public AbsoluteLayout m_layoutLevel; // 0x28
			public AbsoluteLayout m_layoutLevelMax; // 0x2C
			public AbsoluteLayout m_layoutGauge; // 0x30
		}

		[SerializeField]
		private Variables m_left; // 0x14
		[SerializeField]
		private Variables m_right; // 0x18
		[SerializeField]
		private RectTransform m_RightFarthest; // 0x1C
		private float m_RightFarthestRelativePos; // 0x20
		private NumberBase m_numExpNow; // 0x24
		private NumberBase m_numExpNext; // 0x28
		private NumberBase m_numLevel; // 0x2C
		private NumberBase[] m_numPoint; // 0x30
		private AbsoluteLayout m_layoutRoot_; // 0x34
		private AbsoluteLayout m_layoutRoot; // 0x38
		private AbsoluteLayout m_layoutPoint; // 0x3C
		private AbsoluteLayout m_layoutPointAnim; // 0x40
		private AbsoluteLayout[] m_layoutPointAnimTbl; // 0x44
		private AbsoluteLayout m_layoutExpDigit; // 0x48
		private AbsoluteLayout m_layoutLevel; // 0x4C
		private AbsoluteLayout m_layoutLevelMax; // 0x50
		private AbsoluteLayout m_layoutGauge; // 0x54
		private JJOELIOGMKK_DivaIntimacyInfo m_viewData; // 0x58
		private CriAtomExPlayback m_countUpSEPlayback; // 0x5C

		// RVA: 0x19E7F84 Offset: 0x19E7F84 VA: 0x19E7F84
		private void OnDisable()
		{
			m_countUpSEPlayback.Stop();
		}

		// // RVA: 0x19E7F9C Offset: 0x19E7F9C VA: 0x19E7F9C
		// public void Setup(JJOELIOGMKK viewData, DecorationChara chara, Camera cam) { }

		// // RVA: 0x19E8864 Offset: 0x19E8864 VA: 0x19E8864
		// public void Enter() { }

		// // RVA: 0x19E88F0 Offset: 0x19E88F0 VA: 0x19E88F0
		// public void Leave() { }

		// // RVA: 0x19E897C Offset: 0x19E897C VA: 0x19E897C
		// public void Show() { }

		// // RVA: 0x19E89F8 Offset: 0x19E89F8 VA: 0x19E89F8
		public void Hide()
		{
			m_layoutRoot.StartAllAnimGoStop("st_wait");
		}

		// // RVA: 0x19E8A74 Offset: 0x19E8A74 VA: 0x19E8A74
		// public void StartPointUp(Action callback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6D0E9C Offset: 0x6D0E9C VA: 0x6D0E9C
		// // RVA: 0x19E8A98 Offset: 0x19E8A98 VA: 0x19E8A98
		// private IEnumerator Co_StartPointUp(Action callback) { }

		// // RVA: 0x19E8B60 Offset: 0x19E8B60 VA: 0x19E8B60
		// public bool IsLayoutLevelPlayingEnd() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6D0F14 Offset: 0x6D0F14 VA: 0x6D0F14
		// // RVA: 0x19E8B90 Offset: 0x19E8B90 VA: 0x19E8B90
		// private IEnumerator Co_CountPoint(List<Coroutine> coutupCoroutines, int point, int bonus) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6D0F8C Offset: 0x6D0F8C VA: 0x6D0F8C
		// // RVA: 0x19E8C88 Offset: 0x19E8C88 VA: 0x19E8C88
		// private IEnumerator Co_CountBonus(List<Coroutine> coutupCoroutines, int point, int bonus) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6D1004 Offset: 0x6D1004 VA: 0x6D1004
		// // RVA: 0x19E8D7C Offset: 0x19E8D7C VA: 0x19E8D7C
		// private IEnumerator Co_CountUpAnim(int point, int bonus) { }

		// // RVA: 0x19E87A0 Offset: 0x19E87A0 VA: 0x19E87A0
		// private void UpdateGaugePosition(float normalizePos) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6D107C Offset: 0x6D107C VA: 0x6D107C
		// // RVA: 0x19E8E5C Offset: 0x19E8E5C VA: 0x19E8E5C
		// private IEnumerator Co_ExpGaugeAnim(Action<bool> callback) { }

		// // RVA: 0x19E8F24 Offset: 0x19E8F24 VA: 0x19E8F24
		// private void LevelupProcess(int level) { }

		// // RVA: 0x19E8FB4 Offset: 0x19E8FB4 VA: 0x19E8FB4
		// private void LevelMaxProcess(int level) { }

		// // RVA: 0x19E8640 Offset: 0x19E8640 VA: 0x19E8640
		// private void SetLevel(int value) { }

		// // RVA: 0x19E8680 Offset: 0x19E8680 VA: 0x19E8680
		// private void SetExp(int now, int next) { }

		// // RVA: 0x19E9058 Offset: 0x19E9058 VA: 0x19E9058
		// private string GetDigitLabel(int num) { }

		// // RVA: 0x19E9134 Offset: 0x19E9134 VA: 0x19E9134
		// private void SetUpPoint(int value) { }

		// // RVA: 0x19E91D8 Offset: 0x19E91D8 VA: 0x19E91D8
		// private void SetUpBonus(int value) { }

		// // RVA: 0x19E91DC Offset: 0x19E91DC VA: 0x19E91DC
		// private void PlayCountUpLoopSE() { }

		// // RVA: 0x19E7F90 Offset: 0x19E7F90 VA: 0x19E7F90
		// private void StopCountUpLoopSE() { }

		// // RVA: 0x19E8630 Offset: 0x19E8630 VA: 0x19E8630
		// public void SetRightSide() { }

		// // RVA: 0x19E8638 Offset: 0x19E8638 VA: 0x19E8638
		// public void SetLeftSide() { }

		// // RVA: 0x19E923C Offset: 0x19E923C VA: 0x19E923C
		// private void Setup(LayoutDecoIntimacyInfo.Variables variables) { }

		// RVA: 0x19E9384 Offset: 0x19E9384 VA: 0x19E9384 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			TodoLogger.Log(0, "InitializeFromLayout");
			return true;
		}
	}
}
