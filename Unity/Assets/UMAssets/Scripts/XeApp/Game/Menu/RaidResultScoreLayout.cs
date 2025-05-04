using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using System.Collections;
using CriWare;
using XeSys;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class RaidResultScoreLayout : LayoutUGUIScriptBase
	{
		public Action onFinished; // 0x14
		public IEnumerator onCheckScoreUpdate; // 0x18
		public Action onClickButton; // 0x1C
		private FLCAECNBMML m_view; // 0x20
		private Matrix23 m_identity; // 0x24
		private Coroutine m_coroutine; // 0x3C
		private AbsoluteLayout m_layoutRoot; // 0x40
		private AbsoluteLayout m_layoutMain; // 0x44
		private AbsoluteLayout m_layoutAct; // 0x48
		private AbsoluteLayout m_layoutMissionComp; // 0x4C
		private AbsoluteLayout m_layoutMissionAnim; // 0x50
		private AbsoluteLayout m_layoutIsSupBonusMax; // 0x54
		private AbsoluteLayout m_layoutPointUpAnim; // 0x58
		private AbsoluteLayout m_layoutDivaUpAnim; // 0x5C
		private AbsoluteLayout m_layoutSupportUpAnim; // 0x60
		[SerializeField]
		private Text m_scorePointText; // 0x64
		[SerializeField]
		private Text m_valkyriePointText; // 0x68
		[SerializeField]
		private Text m_pointBonusText; // 0x6C
		[SerializeField]
		private Text m_divaBonusText; // 0x70
		[SerializeField]
		private Text m_supportBonusText; // 0x74
		[SerializeField]
		private Text m_totalPointText; // 0x78
		[SerializeField]
		private Text m_damageText; // 0x7C
		[SerializeField]
		private Text m_missionText; // 0x80
		[SerializeField]
		private NumberBase m_supportBonusNum; // 0x84
		[SerializeField]
		private NumberBase m_singBonusNum; // 0x88
		[SerializeField]
		private NumberBase m_missionBonusNum; // 0x8C
		private bool m_isSkiped; // 0x90
		private CriAtomExPlayback m_countUpSEPlayback; // 0x94

		// RVA: 0x18123EC Offset: 0x18123EC VA: 0x18123EC
		private void OnDisable()
		{
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1812440 Offset: 0x1812440 VA: 0x1812440 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_g_r_r_scr_01_cc_sw_g_r_r_scr_01_cc_inout_anim") as AbsoluteLayout;
			m_layoutMain = layout.FindViewByExId("sw_g_r_r_scr_01_cc_all_sw_g_r_r_scr_01_cc_count_anim") as AbsoluteLayout;
			m_layoutAct = layout.FindViewByExId("sw_g_r_r_act_set_g_r_r_fnt_act_set1") as AbsoluteLayout;
			m_layoutMissionComp = layout.FindViewByExId("swtbl_g_r_r_act_set_02_swtbl_g_r_r_ach") as AbsoluteLayout;
			m_layoutIsSupBonusMax = layout.FindViewByExId("sw_g_r_r_scr_01_cc_count_anim_swtbl_max") as AbsoluteLayout;
			m_layoutPointUpAnim = layout.FindViewByExId("sw_g_r_r_scr_01_cc_count_anim_swtbl_up_01") as AbsoluteLayout;
			m_layoutDivaUpAnim = layout.FindViewByExId("sw_g_r_r_scr_01_cc_count_anim_swtbl_up_02") as AbsoluteLayout;
			m_layoutSupportUpAnim = layout.FindViewByExId("sw_g_r_r_scr_01_cc_count_anim_swtbl_up_03") as AbsoluteLayout;
			m_layoutMissionAnim = layout.FindViewByExId("swtbl_g_r_r_act_set_02_sw_g_r_r_act_all_01") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x18128D8 Offset: 0x18128D8 VA: 0x18128D8
		public void Setup(FLCAECNBMML view)
		{
			m_view = view;
			if(view.CFLEMFADGLG == 3)
			{
				m_layoutAct.StartChildrenAnimGoStop("02");
			}
			else if(view.CFLEMFADGLG == 1)
			{
				m_layoutAct.StartChildrenAnimGoStop("01");
			}
			m_scorePointText.text = view.JBJJFDIHKMB_ScorePoint.ToString();
			m_valkyriePointText.text = view.PPAOKOFHIFB_ValkyriePoint.ToString();
			m_pointBonusText.text = view.LMHDHAJOJDA_PointBonus.ToString();
			m_divaBonusText.text = view.NEMLFENEBPM_DivaBonus.ToString();
			m_supportBonusText.text = view.JNPLLCCIPNC_SupportBonus.ToString();
			m_totalPointText.text = view.AHOKAPCGJMA_TotalPoint.ToString();
			m_damageText.text = "";
			m_missionText.text = view.BLFHMNHMDHF_Mission;
			m_layoutPointUpAnim.StartChildrenAnimGoStop(view.LMHDHAJOJDA_PointBonus > 0 ? "01" : "02");
			m_layoutDivaUpAnim.StartChildrenAnimGoStop(view.NEMLFENEBPM_DivaBonus > 0 ? "01" : "02");
			m_layoutSupportUpAnim.StartChildrenAnimGoStop(view.JNPLLCCIPNC_SupportBonus > 0 ? "01" : "02");
			m_supportBonusNum.SetNumber(view.GKJNCAEIKHE_SupportBonusNum, 0);
			m_singBonusNum.SetNumber(view.GGPIKGAAKFP_SingleBonusNum, 0);
			m_missionBonusNum.SetNumber(view.NFOOOBMJINC_MissionBonusNum, 0);
			m_layoutMissionComp.StartChildrenAnimGoStop(view.GGLJDBHDAJN_MissionCompleted ? "02" : "01");
			m_layoutIsSupBonusMax.StartChildrenAnimGoStop(view.KOOPHLLHEFM_IsSupBonusMax ? "01" : "02");
			m_layoutMissionAnim.StartChildrenAnimGoStop(view.MPKBLMCNHOM_MissionIsSpecial ? "02" : "01");
			UnityEngine.Debug.Log("StringLiteral_19963");
			UnityEngine.Debug.Log(string.Format("StringLiteral_19964 {0}", view.MPKBLMCNHOM_MissionIsSpecial ? "sp" : "normal"));
			UnityEngine.Debug.Log(string.Format("StringLiteral_19965 {0}", view.BLFHMNHMDHF_Mission));
			UnityEngine.Debug.Log(string.Format("StringLiteral_19966 {0}", view.NFOOOBMJINC_MissionBonusNum));
			UnityEngine.Debug.Log(string.Format("StringLiteral_19967 {0}", view.GGLJDBHDAJN_MissionCompleted));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720ADC Offset: 0x720ADC VA: 0x720ADC
		// // RVA: 0x18131D8 Offset: 0x18131D8 VA: 0x18131D8
		// private IEnumerator Co_Countup(int startNum, int endNum, float accelPer, Action<int> onChangeNumberCallback) { }

		// // RVA: 0x18132F4 Offset: 0x18132F4 VA: 0x18132F4
		public void SkipBeginAnim()
		{
			m_isSkiped = true;
			if(m_coroutine != null)
				return;
			StartBeginAnim();
		}

		// // RVA: 0x1813334 Offset: 0x1813334 VA: 0x1813334
		public void StartBeginAnim()
		{
			m_coroutine = this.StartCoroutineWatched(Co_BeginAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720B54 Offset: 0x720B54 VA: 0x720B54
		// // RVA: 0x181335C Offset: 0x181335C VA: 0x181335C
		private IEnumerator Co_BeginAnim()
		{
			//0x1813988
			this.StartCoroutineWatched(Co_EnterTitle());
			yield return Co.R(Co_EnterPoint());
			yield return Co.R(Co_CountUpGetPoint());
			yield return Co.R(Co_EnterTotalPoint());
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720BCC Offset: 0x720BCC VA: 0x720BCC
		// // RVA: 0x1813408 Offset: 0x1813408 VA: 0x1813408
		private IEnumerator Co_EnterTitle()
		{
			//0x181448C
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(Co_WaitAnim(m_layoutRoot, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720C44 Offset: 0x720C44 VA: 0x720C44
		// // RVA: 0x18134B4 Offset: 0x18134B4 VA: 0x18134B4
		private IEnumerator Co_EnterPoint()
		{
			AbsoluteLayout layout;

			//0x1814184
			layout = m_layoutMain;
			m_layoutMain.StartAllAnimGoStop("go_bonus", "st_pt");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_035);
			yield return Co.R(Co_WaitLabel(layout, "start_win_pt", true));
			yield return Co.R(Co_WaitLabel(layout, "start_score", true));
			yield return Co.R(Co_WaitLabel(layout, "start_winning", true));
			yield return Co.R(Co_WaitLabel(layout, "start_episode", true));
			yield return Co.R(Co_WaitAnim(m_layoutRoot, true));
		}

		// // RVA: 0x1813560 Offset: 0x1813560 VA: 0x1813560
		private void SetPoint(int point)
		{
			m_damageText.text = point.ToString();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720CBC Offset: 0x720CBC VA: 0x720CBC
		// // RVA: 0x18135B4 Offset: 0x18135B4 VA: 0x18135B4
		private IEnumerator Co_CountUpGetPoint()
		{
			AbsoluteLayout layout; // 0x18
			Coroutine co; // 0x1C

			//0x1813B6C
			layout = m_layoutMain;
			if(m_view.HALIDDHLNEG_Point < 1)
			{
				SetPoint(m_view.HALIDDHLNEG_Point);
			}
			else
			{
				bool isEnd = false;
				List<float> f = new List<float>();
				NumberAnimationUtility.MakeAccelerationTimeList(8, 0.24f, 0.02f, ref f);
				PlayCountUpLoopSE();
				co = this.StartCoroutineWatched(NumberAnimationUtility.Co_FakeCountup(m_view.HALIDDHLNEG_Point, f, (int num) =>
				{
					//0x181396C
					SetPoint(num);
				}, () =>
				{
					//0x1813978
					isEnd = true;
				}, null));
				while(!isEnd && !m_isSkiped)
					yield return null;
				this.StopCoroutineWatched(co);
				m_countUpSEPlayback.Stop(false);
				SetPoint(m_view.HALIDDHLNEG_Point);
				layout.StartChildrenAnimGoStop("act_pt", "acten_pt");
				yield return Co.R(Co_WaitAnim(layout, true));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720D34 Offset: 0x720D34 VA: 0x720D34
		// // RVA: 0x1813660 Offset: 0x1813660 VA: 0x1813660
		private IEnumerator Co_EnterTotalPoint()
		{
			//0x1814610
			m_layoutMain.StartChildrenAnimGoStop("act_pt", "st_pt");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_036);
			yield return Co.R(Co_WaitAnim(m_layoutMain, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720DAC Offset: 0x720DAC VA: 0x720DAC
		// // RVA: 0x181370C Offset: 0x181370C VA: 0x181370C
		private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip/* = True*/)
		{
			//0x18149E4
			while(!m_isSkiped || !enableSkip)
			{
				if(layout.GetView(0).FrameAnimation.FrameCount >= layout.GetView(0).FrameAnimation.SearchLabelFrame(label))
					break;
				yield return null;
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x720E24 Offset: 0x720E24 VA: 0x720E24
		// // RVA: 0x1813804 Offset: 0x1813804 VA: 0x1813804
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			//0x18147E0
			while(layout.IsPlayingChildren())
			{
				if(!m_isSkiped || !enableSkip)
				{
					yield return null;
				}
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
					layout.UpdateAll(m_identity, Color.white);
				}
			}
		}

		// // RVA: 0x18138E4 Offset: 0x18138E4 VA: 0x18138E4
		private void PlayCountUpLoopSE()
		{
			if(m_countUpSEPlayback.GetStatus() == CriAtomExPlayback.Status.Playing)
				return;
			m_countUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(0);
		}

		// // RVA: 0x1813958 Offset: 0x1813958 VA: 0x1813958
		// private void StopCountUpLoopSE() { }
	}
}
