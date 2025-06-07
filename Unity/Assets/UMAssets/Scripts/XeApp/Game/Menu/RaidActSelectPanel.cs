using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidActSelectPanel : LayoutUGUIScriptBase
	{
		public enum PanelType
		{
			PanelRight = 0,
			PanelLeft = 1,
		}

		public enum PlayButtonType
		{
			PlayEn = 0,
			Play = 1,
			Event = 2,
			Download = 3,
			Live = 4,
			Ok = 5,
		}

		[SerializeField]
		private PanelType m_panelType; // 0x14
		[SerializeField]
		private RaidActPlayButton m_playButton; // 0x18
		[SerializeField]
		private Transform m_downloadInfo; // 0x1C
		[SerializeField]
		private ButtonBase m_panelButton; // 0x20
		[SerializeField]
		private NumberBase m_bonusNum; // 0x24
		[SerializeField]
		private NumberBase m_apCostNum; // 0x28
		[SerializeField]
		private Text m_textDesc; // 0x2C
		private AbsoluteLayout m_panelAnim; // 0x30
		private AbsoluteLayout m_typeTextAnim; // 0x34
		private AbsoluteLayout m_playButtonTextAnim; // 0x38
		private AbsoluteLayout m_flashAnim; // 0x3C
		private AbsoluteLayout m_descTableAnim; // 0x40
		private bool m_isShow; // 0x44
		private bool m_isOpen; // 0x45
		private JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH m_attackType; // 0x48
		//[CompilerGeneratedAttribute] // RVA: 0x67C36C Offset: 0x67C36C VA: 0x67C36C
		public UnityAction OnClickPanelListner; // 0x4C
		//[CompilerGeneratedAttribute] // RVA: 0x67C37C Offset: 0x67C37C VA: 0x67C37C
		public UnityAction<JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH> OnClickPlayButtonListner; // 0x50

		public bool IsOpen { get { return m_isOpen; } } //0x1454628

		// RVA: 0x1454848 Offset: 0x1454848 VA: 0x1454848 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_isShow = false;
			m_isOpen = false;
			AbsoluteLayout lyt;
			if(m_panelType == PanelType.PanelRight)
			{
				lyt = layout.FindViewById("sw_sel_music_raid_act_r_anim") as AbsoluteLayout;
				m_panelAnim = lyt.FindViewByExId("sw_sel_music_raid_act_r_anim_sw_sel_music_raid_act_set_r_anim") as AbsoluteLayout;
				m_flashAnim = lyt.FindViewByExId("sw_sel_music_raid_act_set_r_anim_sw_sel_music_raid_act_ef_anim") as AbsoluteLayout;
			}
			else
			{
				lyt = layout.FindViewById("sw_sel_music_raid_act_l_anim") as AbsoluteLayout;
				m_panelAnim = lyt.FindViewByExId("sw_sel_music_raid_act_l_anim_sw_sel_music_raid_act_set_l_anim") as AbsoluteLayout;
				m_flashAnim = lyt.FindViewByExId("sw_sel_music_raid_act_set_l_anim_sw_sel_music_raid_act_ef_anim") as AbsoluteLayout;
			}
			m_typeTextAnim = lyt.FindViewByExId("raid_act_frm_set_t_raid_act_fnt_set_a") as AbsoluteLayout;
			m_playButtonTextAnim = lyt.FindViewByExId("sw_sel_music_btn_play_anim_swtbl_set_deck_btn_play_en") as AbsoluteLayout;
			m_descTableAnim = lyt.FindViewById("sw_fnt_support_onoff_anim") as AbsoluteLayout;
			m_panelButton.AddOnClickCallback(() =>
			{
				//0x1455244
				if(OnClickPanelListner != null)
					OnClickPanelListner();
			});
			m_playButton.AddOnClickCallback(() =>
			{
				//0x1455258
				if(OnClickPlayButtonListner != null)
					OnClickPlayButtonListner(m_attackType);
			});
			m_flashAnim.StartChildrenAnimLoop("go_act");
			Loaded();
			return true;
		}

		// // RVA: 0x1449738 Offset: 0x1449738 VA: 0x1449738
		public void SetActType(JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH type, int ap)
		{
			m_attackType = type;
			m_apCostNum.SetNumber(ap, 0);
			if(type == JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.OOEHFFBHCIC_3_FullPower)
			{
				m_typeTextAnim.StartChildrenAnimGoStop("02");
				m_descTableAnim.StartChildrenAnimGoStop("01");
				m_textDesc.text = MessageManager.Instance.GetMessage("menu", "raid_act_fullpower_desc_text");
			}
			else if(type == JLOGEHCIBEJ_EventRaid.JJAFLOEBLDH.CCAPCGPIIPF_1_Support)
			{
				m_typeTextAnim.StartChildrenAnimGoStop("01");
				m_descTableAnim.StartChildrenAnimGoStop("01");
				m_textDesc.text = MessageManager.Instance.GetMessage("menu", "raid_act_support_desc_text");
			}
		}

		// // RVA: 0x144995C Offset: 0x144995C VA: 0x144995C
		public void SetBonusNum(int num)
		{
			m_bonusNum.SetNumber(num, 0);
		}

		// RVA: 0x1454D98 Offset: 0x1454D98 VA: 0x1454D98
		public void SetPlayButtonType(PlayButtonType type)
		{
			bool isVisible = false;
			switch(type)
			{
				case PlayButtonType.PlayEn:
					m_playButtonTextAnim.StartChildrenAnimGoStop("01", "01");
					break;
				case PlayButtonType.Play:
					m_playButtonTextAnim.StartChildrenAnimGoStop("02", "02");
					break;
				case PlayButtonType.Event:
					m_playButtonTextAnim.StartChildrenAnimGoStop("03", "03");
					break;
				case PlayButtonType.Download:
					isVisible = true;
					m_playButtonTextAnim.StartChildrenAnimGoStop("04", "04");
					break;
				case PlayButtonType.Live:
					m_playButtonTextAnim.StartChildrenAnimGoStop("05", "05");
					break;
				case PlayButtonType.Ok:
					m_playButtonTextAnim.StartChildrenAnimGoStop("06", "06");
					break;
				default:
					m_playButtonTextAnim.StartChildrenAnimGoStop("", "");
					break;
			}
			m_playButton.SetDLMessage(isVisible);
		}

		// RVA: 0x1454EE4 Offset: 0x1454EE4 VA: 0x1454EE4
		public void SetNeedAp(int ap)
		{
			m_playButton.SetNeedAp(ap);
		}

		// // RVA: 0x1454F18 Offset: 0x1454F18 VA: 0x1454F18
		// private void OnClickPanel() { }

		// // RVA: 0x1454F2C Offset: 0x1454F2C VA: 0x1454F2C
		// private void OnClickPlayButton() { }

		// RVA: 0x14493BC Offset: 0x14493BC VA: 0x14493BC
		public void Open(bool isAnimation/* = True*/)
		{
			if(isAnimation)
			{
				if(!m_isOpen)
				{
					m_panelAnim.StartChildrenAnimGoStop("go_in", "st_in");
				}
			}
			else
			{
				m_panelAnim.StartChildrenAnimGoStop("st_in", "st_in");
			}
			m_isOpen = true;
		}

		// RVA: 0x14494A8 Offset: 0x14494A8 VA: 0x14494A8
		public void Close(bool isAnimation/* = True*/)
		{
			if(isAnimation)
			{
				if(m_isOpen)
				{
					m_panelAnim.StartChildrenAnimGoStop("go_out", "st_out");
				}
			}
			else
			{
				m_panelAnim.StartChildrenAnimGoStop("st_out", "st_out");
			}
			m_isOpen = false;
		}

		// // RVA: 0x1454F9C Offset: 0x1454F9C VA: 0x1454F9C
		// public void Show() { }

		// RVA: 0x1455024 Offset: 0x1455024 VA: 0x1455024
		public void Hide()
		{
			m_isShow = false;
			m_panelAnim.StartSiblingAnimGoStop("st_out", "st_out");
		}

		// RVA: 0x14550AC Offset: 0x14550AC VA: 0x14550AC
		public void Enter(bool isFreePlay/* = False*/)
		{
			if(!m_isShow)
			{
				if(isFreePlay)
				{
					m_panelAnim.StartSiblingAnimGoStop("go_in2", "st_in2");
				}
				else
				{
					m_panelAnim.StartSiblingAnimGoStop("go_in", "st_in");
				}
			}
			m_isShow = true;
		}

		// RVA: 0x1455174 Offset: 0x1455174 VA: 0x1455174
		public void Leave(bool isFreePlay/* = False*/)
		{
			if(m_isShow)
			{
				if(isFreePlay)
				{
					m_panelAnim.StartSiblingAnimGoStop("go_out2", "st_out2");
				}
				else
				{
					m_panelAnim.StartSiblingAnimGoStop("go_out", "st_out");
				}
			}
			m_isShow = false;
		}
	}
}
