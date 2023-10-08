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
		public void Setup(JJOELIOGMKK_DivaIntimacyInfo viewData, DecorationChara chara, Camera cam)
		{
			transform.SetParent(chara.GetObject().transform, false);
			transform.localPosition = new Vector3(0, chara.bottomOfs.y * 0, 0);
			m_viewData = viewData;
			if(m_RightFarthestRelativePos == 0)
			{
				m_RightFarthestRelativePos = m_RightFarthest.transform.position.x - transform.position.x + m_RightFarthest.rect.width;
			}
			float f = 1;
			if(chara.decorationController.scrollController.m_controlDataList.Count > 0)
			{
				f = chara.decorationController.scrollController.m_controlDataList[0].scaler.scaleFactor;
			}
			Vector3 v = cam.WorldToViewportPoint(transform.position + new Vector3(0, f * m_RightFarthestRelativePos, 0));
			if(v.x >= 1)
			{
				m_layoutRoot.StartChildrenAnimGoStop("02");
				m_layoutRoot_.StartChildrenAnimGoStop("02");
				Setup(m_left);
			}
			else
			{
				m_layoutRoot.StartChildrenAnimGoStop("01");
				m_layoutRoot_.StartChildrenAnimGoStop("01");
				Setup(m_right);
			}
			m_layoutLevelMax.StartChildrenAnimGoStop(viewData.HBODCMLFDOB.PFIILLOIDIL ? "01" : "02");
			m_numLevel.SetNumber(m_viewData.HEKJGCMNJAB_CurrentLevel, 0);
			if(!m_viewData.HBODCMLFDOB.PFIILLOIDIL)
			{
				SetExp(m_viewData.KPEAGFJHNDP_CurrentLevelExp, m_viewData.KOKCFJDMJLI);
				UpdateGaugePosition(m_viewData.KPEAGFJHNDP_CurrentLevelExp * 1.0f / m_viewData.KOKCFJDMJLI);
			}
			else
			{
				SetExp(0, 0);
				UpdateGaugePosition(1);
			}
		}

		// // RVA: 0x19E8864 Offset: 0x19E8864 VA: 0x19E8864
		public void Enter()
		{
			m_layoutLevel.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x19E88F0 Offset: 0x19E88F0 VA: 0x19E88F0
		public void Leave()
		{
			m_layoutLevel.StartChildrenAnimGoStop("go_out", "st_out");
		}

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
		public bool IsLayoutLevelPlayingEnd()
		{
			return !m_layoutLevel.IsPlayingChildren();
		}

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
		private void UpdateGaugePosition(float normalizePos)
		{
			int pos = (int)((m_layoutGauge.GetView(0).FrameAnimation.FrameNum + 1) * normalizePos);
			m_layoutGauge.StartChildrenAnimGoStop(pos, pos);
		}

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
		private void SetExp(int now, int next)
		{
			if(next < 1)
			{
				m_layoutExpDigit.StartChildrenAnimGoStop("max");
			}
			else
			{
				m_layoutExpDigit.StartChildrenAnimGoStop(GetDigitLabel(next));
				m_numExpNow.SetNumber(now, 0);
				m_numExpNext.SetNumber(next, 0);
			}
		}

		// // RVA: 0x19E9058 Offset: 0x19E9058 VA: 0x19E9058
		private string GetDigitLabel(int num)
		{
			int a = 1;
			if(num != 0)
				a = (int)Mathf.Log10(num) + 1;
			if(a == 3)
				return "02";
			if(a > 0 && a < 3)
				return "01";
			return "03";
		}

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
		private void Setup(Variables variables)
		{
			m_numExpNow = variables.m_numExpNow;
			m_numExpNext = variables.m_numExpNext;
			m_numLevel = variables.m_numLevel;
			m_numPoint = variables.m_numPoint;
			m_layoutPoint = variables.m_layoutPoint;
			m_layoutPointAnim = variables.m_layoutPointAnim;
			m_layoutPointAnimTbl = variables.m_layoutPointAnimTbl;
			m_layoutExpDigit = variables.m_layoutExpDigit;
			m_layoutLevel = variables.m_layoutLevel;
			m_layoutLevelMax = variables.m_layoutLevelMax;
			m_layoutGauge = variables.m_layoutGauge;
		}

		// RVA: 0x19E9384 Offset: 0x19E9384 VA: 0x19E9384 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("swtbl_deco_present") as AbsoluteLayout;
			m_layoutRoot_ = layout.FindViewById("swtbl_fs_p_ga_anim") as AbsoluteLayout;
			m_right.m_layoutLevel = layout.FindViewByExId("swtbl_fs_p_ga_anim_sw_fs_p_ga_anim_01") as AbsoluteLayout;
			m_right.m_layoutExpDigit = m_right.m_layoutLevel.FindViewByExId("deco_fs_ga_swtbl_fs_num") as AbsoluteLayout;
			m_right.m_layoutLevelMax = m_right.m_layoutLevel.FindViewByExId("deco_fs_ga_swtbl_fs_lv_num_max") as AbsoluteLayout;
			m_right.m_layoutGauge = m_right.m_layoutLevel.FindViewByExId("deco_fs_ga_sw_ga_anim") as AbsoluteLayout;
			m_right.m_layoutPointAnimTbl = new AbsoluteLayout[2];
			m_right.m_layoutPointAnimTbl[0] = layout.FindViewByExId("swtbl_deco_present_sw_fs_p_num_s_anim") as AbsoluteLayout;
			m_left.m_layoutLevel = layout.FindViewByExId("swtbl_fs_p_ga_anim_sw_fs_p_ga_anim_02") as AbsoluteLayout;
			m_left.m_layoutExpDigit = m_left.m_layoutLevel.FindViewByExId("deco_fs_ga_swtbl_fs_num") as AbsoluteLayout;
			m_left.m_layoutLevelMax = m_left.m_layoutLevel.FindViewByExId("deco_fs_ga_swtbl_fs_lv_num_max") as AbsoluteLayout;
			m_left.m_layoutGauge = m_left.m_layoutLevel.FindViewByExId("deco_fs_ga_sw_ga_anim") as AbsoluteLayout;
			m_left.m_layoutPointAnimTbl = new AbsoluteLayout[2];
			m_left.m_layoutPointAnimTbl[0] = layout.FindViewByExId("swtbl_deco_present_sw_fs_p_num_s_anim") as AbsoluteLayout;
			m_layoutRoot.StartAllAnimGoStop("st_wait");
			Setup(m_right);
			Loaded();
			return true;
		}
	}
}
