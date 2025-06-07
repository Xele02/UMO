using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RaidActSelectArgs : TransitionArgs
	{
		public TransitionUniqueId ReturnTransitionUniqueId { get; private set; } // 0x8
		public EventMusicSelectSceneArgs EventMusicSelectSceneArgs { get; private set; } // 0xC

		// RVA: 0x144B2F4 Offset: 0x144B2F4 VA: 0x144B2F4
		public RaidActSelectArgs(TransitionUniqueId _returnTransitionUniqueId, EventMusicSelectSceneArgs _eventMusicSelectSceneArgs)
		{
			ReturnTransitionUniqueId = _returnTransitionUniqueId;
			EventMusicSelectSceneArgs = _eventMusicSelectSceneArgs;
		}
	}

	public class RaidActSelectBossInfoLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_bossNameText; // 0x14
		[SerializeField]
		private NumberBase m_joinNum; // 0x18
		[SerializeField]
		private NumberBase m_assistBonusNum; // 0x1C
		[SerializeField]
		private NumberBase m_bossHpNum; // 0x20
		private AbsoluteLayout m_bossInfoAnim; // 0x24
		private AbsoluteLayout m_bossSpAnim; // 0x28
		private AbsoluteLayout m_bossHpGaugeAnim; // 0x2C
		private AbsoluteLayout m_bossRankAnim; // 0x30
		private AbsoluteLayout m_assistBonusMax; // 0x34
		private AbsoluteLayout m_plusAnim; // 0x38
		private bool m_isShow; // 0x3C

		// RVA: 0x144B31C Offset: 0x144B31C VA: 0x144B31C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = false;
			m_bossInfoAnim = layout.FindViewByExId("sw_sel_music_raid_act_tl_anim_sw_sel_music_raid_act_set_tl") as AbsoluteLayout;
			m_bossSpAnim = layout.FindViewByExId("sw_sel_music_raid_act_stats_set_sw_raid_boss_sp_min") as AbsoluteLayout;
			m_bossHpGaugeAnim = layout.FindViewByExId("sw_sel_music_raid_act_stats_set_sw_boss_bar_anim") as AbsoluteLayout;
			m_bossRankAnim = layout.FindViewByExId("raid_b_r_icon_base_set2_sw_raid_boss_rank") as AbsoluteLayout;
			m_assistBonusMax = layout.FindViewByExId("sw_sel_music_raid_act_join_set_swtbl_max") as AbsoluteLayout;
			m_plusAnim = layout.FindViewByExId("swtbl_g_r_r_num_buff_plus_g_r_r_num_buff_plus") as AbsoluteLayout;
			Loaded();
			return true;
		}

		// RVA: 0x1449594 Offset: 0x1449594 VA: 0x1449594
		public void InitLayout(PKNOKJNLPOE_EventRaid.MJFMOPMOFDJ bossInfo, string bossName, int assistBonusMax)
		{
			SetSp(bossInfo.IKICLMGFFPB_IsSpecial);
			SetHp((int)(bossInfo.BCCOMAODPJI_HpCurrent * 100.0f / bossInfo.PIKKHCGNGNN_HpMax));
			m_bossHpNum.SetNumber(bossInfo.BCCOMAODPJI_HpCurrent, 0);
			SetRank(bossInfo.FJOLNJLLJEJ_Rank);
			m_bossNameText.text = bossName;
			m_joinNum.SetNumber(bossInfo.MHABJOMJCFI_JoinedMember, 0);
			SetAssistNum(bossInfo.CLNPBIJBIIJ_CoopBonus);
			SetAssistIsMax(assistBonusMax <= bossInfo.CLNPBIJBIIJ_CoopBonus);
		}

		// // RVA: 0x144B650 Offset: 0x144B650 VA: 0x144B650
		private void SetSp(bool isSp)
		{
			m_bossSpAnim.StartChildrenAnimGoStop(isSp ? "01" : "02", isSp ? "01" : "02");
		}

		// // RVA: 0x144B6EC Offset: 0x144B6EC VA: 0x144B6EC
		private void SetHp(int val)
		{
			m_bossHpGaugeAnim.StartAllAnimGoStop(val, val);
		}

		// // RVA: 0x144B724 Offset: 0x144B724 VA: 0x144B724
		// private void SetHpNum(int num) { }

		// // RVA: 0x144B764 Offset: 0x144B764 VA: 0x144B764
		private void SetRank(int rank)
		{
			string lbl = string.Format("{0:D2}", rank);
			m_bossRankAnim.StartChildrenAnimGoStop(lbl, lbl);
		}

		// // RVA: 0x144B820 Offset: 0x144B820 VA: 0x144B820
		// private void SetName(string name) { }

		// // RVA: 0x144B85C Offset: 0x144B85C VA: 0x144B85C
		// private void SetJoinNum(int num) { }

		// // RVA: 0x144B89C Offset: 0x144B89C VA: 0x144B89C
		private void SetAssistNum(int num)
		{
			m_assistBonusNum.SetNumber(num, 0);
			m_plusAnim.StartSiblingAnimGoStop(num == 0 ? "02" : "01");
		}

		// // RVA: 0x144B960 Offset: 0x144B960 VA: 0x144B960
		private void SetAssistIsMax(bool isMax)
		{
			m_assistBonusMax.StartChildrenAnimGoStop(isMax ? "01" : "02", isMax ? "01" : "02");
		}

		// // RVA: 0x144B9FC Offset: 0x144B9FC VA: 0x144B9FC
		// public void Show() { }

		// // RVA: 0x144BA84 Offset: 0x144BA84 VA: 0x144BA84
		// public void Hide() { }

		// RVA: 0x144BB0C Offset: 0x144BB0C VA: 0x144BB0C
		public void Enter()
		{
			if(!m_isShow)
			{
				m_bossInfoAnim.StartSiblingAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// RVA: 0x144BBAC Offset: 0x144BBAC VA: 0x144BBAC
		public void Leave()
		{
			if(m_isShow)
			{
				m_bossInfoAnim.StartSiblingAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}
	}
}
