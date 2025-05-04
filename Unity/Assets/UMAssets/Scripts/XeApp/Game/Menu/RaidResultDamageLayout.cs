using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using System.Collections;
using CriWare;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidResultDamageLayout : LayoutUGUIScriptBase
	{
		public Action onFinished; // 0x14
		public IEnumerator onCheckScoreUpdate; // 0x18
		public Action onClickButton; // 0x1C
		private GJMCHHCPFDL m_view; // 0x20
		private Matrix23 m_identity; // 0x24
		private Coroutine m_coroutine; // 0x3C
		private AbsoluteLayout m_layoutRoot; // 0x40
		private AbsoluteLayout m_layoutSwitch; // 0x44
		private AbsoluteLayout m_layoutMain; // 0x48
		private AbsoluteLayout m_layoutRank; // 0x4C
		private AbsoluteLayout m_isSp; // 0x50
		private AbsoluteLayout m_bossHpGauge; // 0x54
		private AbsoluteLayout m_bossHpGaugeAnim; // 0x58
		[SerializeField]
		private Text m_nameText; // 0x5C
		[SerializeField]
		private Text m_pointText; // 0x60
		[SerializeField]
		private Text m_damageText; // 0x64
		[SerializeField]
		private NumberBase m_numDamage; // 0x68
		private bool m_isSkiped; // 0x6C
		private CriAtomExPlayback m_countUpSEPlayback; // 0x70

		// RVA: 0x1BDCDFC Offset: 0x1BDCDFC VA: 0x1BDCDFC
		private void OnDisable()
		{
			if(SoundManager.Instance.sePlayerResultLoop.status != CriAtomSource.Status.Playing)
				return;
			SoundManager.Instance.sePlayerResultLoop.Stop();
		}

		// RVA: 0x1BDCEA0 Offset: 0x1BDCEA0 VA: 0x1BDCEA0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_g_r_r_pt_res_bc_01_sw_g_r_r_pt_res_inout_01_anim") as AbsoluteLayout;
			m_layoutSwitch = layout.FindViewByExId("sw_g_r_r_pt_res_inout_01_anim_sw_g_r_r_pt_res_all") as AbsoluteLayout;
			m_layoutMain = layout.FindViewByExId("sw_g_r_r_pt_res_all_sw_g_r_r_pt_res_count_anim") as AbsoluteLayout;
			m_layoutRank = layout.FindViewByExId("raid_b_r_icon_base_set2_sw_raid_boss_rank") as AbsoluteLayout;
			m_isSp = layout.FindViewByExId("sw_g_r_r_pt_res_count_anim_sw_raid_boss_sp_min") as AbsoluteLayout;
			m_bossHpGauge = layout.FindViewByExId("sw_g_r_r_pt_res_count_anim_sw_boss_bar_anim") as AbsoluteLayout;
			m_bossHpGaugeAnim = layout.FindViewByExId("sw_boss_bar_anim_sw_bar_ef_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// // RVA: 0x1BDC204 Offset: 0x1BDC204 VA: 0x1BDC204
		public void Setup(bool isCannon, GJMCHHCPFDL view)
		{
			m_view = view;
			m_isSp.StartChildrenAnimGoStop(view.MPKBLMCNHOM_MissionIsSpecial ? "01" : "02");
			m_layoutSwitch.StartChildrenAnimGoStop(isCannon ? "02" : "01");
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_nameText.text = view.OPFGFINHFCE_Name;
			m_pointText.text = view.ENMEKLHFMDE_Point.ToString();
			m_damageText.text = bk.GetMessageByLabel("raid_damage_result_text");
			m_layoutRank.StartChildrenAnimGoStop(m_view.FJOLNJLLJEJ_Rank.ToString("D2"));
			m_bossHpGauge.StartChildrenAnimGoStop((int)m_view.LBEIIEKJFPA_DamageBefore, (int)m_view.LBEIIEKJFPA_DamageBefore);
			m_bossHpGaugeAnim.StartChildrenAnimGoStop("st_stop");
			m_numDamage.SetNumber(m_view.FCIBJNKGMOB_Damage, 0);
		}

		// // RVA: 0x1BDC838 Offset: 0x1BDC838 VA: 0x1BDC838
		public void SkipBeginAnim()
		{
			m_isSkiped = true;
			if(m_coroutine != null)
				return;
			StartBeginAnim();
		}

		// // RVA: 0x1BDCD0C Offset: 0x1BDCD0C VA: 0x1BDCD0C
		public void StartBeginAnim()
		{
			m_coroutine = this.StartCoroutineWatched(Co_BeginAnim());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71F31C Offset: 0x71F31C VA: 0x71F31C
		// // RVA: 0x1BDD248 Offset: 0x1BDD248 VA: 0x1BDD248
		private IEnumerator Co_BeginAnim()
		{
			//0x1BDD808
			yield return Co.R(Co_EnterTitle());
			yield return new WaitForSeconds(0.5f);
			yield return Co.R(Co_EnterDamage());
			if(m_view.FCIBJNKGMOB_Damage != m_view.GKHMIECGPJO_HpAfter)
			{
				yield return Co.R(Co_DamageGauge());
			}
			//LAB_01bdd9a8
			if(onFinished != null)
				onFinished();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71F394 Offset: 0x71F394 VA: 0x71F394
		// // RVA: 0x1BDD2F4 Offset: 0x1BDD2F4 VA: 0x1BDD2F4
		private IEnumerator Co_EnterTitle()
		{
			//0x1BDE0E4
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
			yield return Co.R(Co_WaitAnim(m_layoutRoot, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71F40C Offset: 0x71F40C VA: 0x71F40C
		// // RVA: 0x1BDD3A0 Offset: 0x1BDD3A0 VA: 0x1BDD3A0
		private IEnumerator Co_EnterDamage()
		{
			//0x1BDDF14
			m_layoutMain.StartAllAnimGoStop("go_dmg", "st_dmg");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_035);
			yield return Co.R(Co_WaitAnim(m_layoutMain, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71F484 Offset: 0x71F484 VA: 0x71F484
		// // RVA: 0x1BDD44C Offset: 0x1BDD44C VA: 0x1BDD44C
		private IEnumerator Co_OverDamage()
		{
			//0x1BDE268
			m_layoutMain.StartAllAnimGoStop("start_over", "st_over");
			SoundManager.Instance.sePlayerResult.Play((int)mcrs.cs_se_result.SE_RESULT_035);
			yield return Co.R(Co_WaitAnim(m_layoutMain, true));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71F4FC Offset: 0x71F4FC VA: 0x71F4FC
		// // RVA: 0x1BDD4F8 Offset: 0x1BDD4F8 VA: 0x1BDD4F8
		private IEnumerator Co_DamageGauge()
		{
			float startValue; // 0x14
			float endValue; // 0x18
			int bossMaxHp; // 0x1C
			int bossHp; // 0x20
			float currentTime; // 0x24
			float timeLength; // 0x28

			//0x1BDDA74
			startValue = m_view.LBEIIEKJFPA_DamageBefore;
			endValue = m_view.ODFNMNDFEFN_DamageAfter;
			bossMaxHp = m_view.BDNGBCKEADA_MaxHp;
			currentTime = 0;
			bossHp = m_view.GKHMIECGPJO_HpAfter;
			timeLength = 1.5f;
			PlayCountUpLoopSE();
			m_bossHpGaugeAnim.StartChildrenAnimLoop("logo_act", "loen_act");
			while(true)
			{
				currentTime += TimeWrapper.deltaTime;
				float r = XeSys.Math.Tween.EasingInOutCubic(startValue, endValue, currentTime / timeLength);
				if(r <= 0 || timeLength <= currentTime)
					break;
				m_bossHpGauge.StartChildrenAnimGoStop((int)r, (int)r);
				m_numDamage.SetNumber((int)r * bossMaxHp / 100, 0);
				if(!m_isSkiped)
					yield return null;
			}
			m_bossHpGauge.StartChildrenAnimGoStop((int)endValue, (int)endValue);
			m_numDamage.SetNumber(bossHp, 0);
			if(bossHp < 1)
			{
				this.StartCoroutineWatched(Co_OverDamage());
			}
			m_bossHpGaugeAnim.StartChildrenAnimGoStop("st_stop");
			m_countUpSEPlayback.Stop(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x71F574 Offset: 0x71F574 VA: 0x71F574
		// // RVA: 0x1BDD5A4 Offset: 0x1BDD5A4 VA: 0x1BDD5A4
		// private IEnumerator Co_WaitLabel(AbsoluteLayout layout, string label, bool enableSkip = True) { }

		// [IteratorStateMachineAttribute] // RVA: 0x71F5EC Offset: 0x71F5EC VA: 0x71F5EC
		// // RVA: 0x1BDD69C Offset: 0x1BDD69C VA: 0x1BDD69C
		private IEnumerator Co_WaitAnim(AbsoluteLayout layout, bool enableSkip/* = True*/)
		{
			while(layout.IsPlayingChildren())
			{
				if(!m_isSkiped || !enableSkip)
					yield return null;
				else
				{
					layout.UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
					layout.UpdateAll(m_identity, Color.white);
				}
			}
		}

		// // RVA: 0x1BDD77C Offset: 0x1BDD77C VA: 0x1BDD77C
		private void PlayCountUpLoopSE()
		{
			if(m_countUpSEPlayback.GetStatus() == CriAtomExPlayback.Status.Playing)
				return;
			m_countUpSEPlayback = SoundManager.Instance.sePlayerResultLoop.Play(0);
		}

		// // RVA: 0x1BDD7F0 Offset: 0x1BDD7F0 VA: 0x1BDD7F0
		// private void StopCountUpLoopSE() { }
	}
}
