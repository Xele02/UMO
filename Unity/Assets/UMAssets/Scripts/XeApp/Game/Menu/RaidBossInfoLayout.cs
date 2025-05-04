using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidBossInfoLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_bossNameText; // 0x14
		[SerializeField]
		private Text m_missionText; // 0x18
		[SerializeField]
		private Text m_freePlayText; // 0x1C
		[SerializeField]
		private NumberBase m_bossNum; // 0x20
		[SerializeField]
		private NumberBase m_songBonusNum; // 0x24
		[SerializeField]
		private List<RawImageEx> m_logoImages; // 0x28
		private bool m_isShow; // 0x2C
		private AbsoluteLayout m_bossInfoAnim; // 0x30
		private AbsoluteLayout m_switchSeriesAnim; // 0x34
		private AbsoluteLayout m_announceAnim; // 0x38
		private AbsoluteLayout m_missionWindowAnim; // 0x3C
		private AbsoluteLayout m_freePlayAnim; // 0x40

		// RVA: 0x145C240 Offset: 0x145C240 VA: 0x145C240 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = true;
			m_bossInfoAnim = layout.FindViewByExId("sw_sel_music_raid_boss_select_tl_anim_sw_sel_music_raid_boss_select_tl_set") as AbsoluteLayout;
			m_switchSeriesAnim = layout.FindViewByExId("sw_sel_music_raid_boss_info_sw_raid_boss_logo") as AbsoluteLayout;
			m_announceAnim = layout.FindViewByExId("sw_sel_music_raid_boss_select_tl_set_raid_announce_l_set") as AbsoluteLayout;
			m_missionWindowAnim = layout.FindViewByExId("sw_sel_music_raid_boss_select_tl_set_s_m_r_frm_mi_01") as AbsoluteLayout;
			m_freePlayAnim = layout.FindViewByExId("sw_ap_message2_onoff_anim") as AbsoluteLayout;
			m_freePlayAnim.StartChildrenAnimGoStop("02");
			Hide();
			return true;
		}

		// // RVA: 0x145C5B0 Offset: 0x145C5B0 VA: 0x145C5B0
		// public void ShowBossInfo() { }

		// // RVA: 0x145C690 Offset: 0x145C690 VA: 0x145C690
		// public void HideBossInfo() { }

		// // RVA: 0x145C8D0 Offset: 0x145C8D0 VA: 0x145C8D0
		public void SetBossName(int bossType)
		{
			m_bossNameText.text = (JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid).AGEJGHGEGFF_GetBossName(bossType);
		}

		// RVA: 0x145C818 Offset: 0x145C818 VA: 0x145C818
		public void SetBossName(string name)
		{
			m_bossNameText.text = name;
		}

		// RVA: 0x145CA14 Offset: 0x145CA14 VA: 0x145CA14
		public void SetSeries(SeriesAttr.Type type)
		{
			switch(type)
			{
				case SeriesAttr.Type.Delta:
					m_switchSeriesAnim.StartChildrenAnimGoStop("01", "01");
					break;
				case SeriesAttr.Type.Frontia:
					m_switchSeriesAnim.StartChildrenAnimGoStop("02", "02");
					break;
				case SeriesAttr.Type.Seven:
					m_switchSeriesAnim.StartChildrenAnimGoStop("03", "03");
					break;
				case SeriesAttr.Type.First:
					m_switchSeriesAnim.StartChildrenAnimGoStop("04", "04");
					break;
				default:
					break;
			}
		}

		// // RVA: 0x145CB30 Offset: 0x145CB30 VA: 0x145CB30
		public void SetBossNum(int num)
		{
			if(num == 0)
				m_announceAnim.StartSiblingAnimGoStop("01", "01");
			else
				m_announceAnim.StartSiblingAnimGoStop("02", "02");
			m_bossNum.SetNumber(num, 0);
		}

		// RVA: 0x145C854 Offset: 0x145C854 VA: 0x145C854
		public void SetSongBonus(int num)
		{
			m_songBonusNum.SetNumber(num, 0);
		}

		// RVA: 0x145C894 Offset: 0x145C894 VA: 0x145C894
		public void SetMissionInfoText(string str)
		{
			m_missionText.text = str;
		}

		// RVA: 0x145CC10 Offset: 0x145CC10 VA: 0x145CC10
		public void SetSp(bool isSp)
		{
			m_missionWindowAnim.StartChildrenAnimGoStop(isSp ? "02" : "01", isSp ? "02" : "01");
		}

		// // RVA: 0x145CCAC Offset: 0x145CCAC VA: 0x145CCAC
		// public void SetFreePlay(bool isFreePlay) { }

		// RVA: 0x145CDC4 Offset: 0x145CDC4 VA: 0x145CDC4
		public void SetAssistPlay(bool isAssistPlay)
		{
			m_freePlayAnim.StartChildrenAnimGoStop(isAssistPlay ? "01" : "02");
			m_freePlayText.text = MessageManager.Instance.GetMessage("menu", "raid_assist_attack_skip_01");
		}

		// // RVA: 0x145CEDC Offset: 0x145CEDC VA: 0x145CEDC
		// public void Show() { }

		// // RVA: 0x145C528 Offset: 0x145C528 VA: 0x145C528
		public void Hide()
		{
			m_isShow = false;
			m_bossInfoAnim.StartSiblingAnimGoStop("st_out", "st_out");
		}

		// // RVA: 0x145CF64 Offset: 0x145CF64 VA: 0x145CF64
		public void Enter()
		{
			if(!m_isShow)
			{
				m_bossInfoAnim.StartSiblingAnimGoStop("go_in", "st_in");
			}
			m_isShow = true;
		}

		// // RVA: 0x145D004 Offset: 0x145D004 VA: 0x145D004
		public void Leave()
		{
			if(m_isShow)
			{
				m_bossInfoAnim.StartSiblingAnimGoStop("go_out", "st_out");
			}
			m_isShow = false;
		}

		// // RVA: 0x145D0A4 Offset: 0x145D0A4 VA: 0x145D0A4
		public bool IsPlaying()
		{
			return m_bossInfoAnim.IsPlayingSibling();
		}
	}
}
