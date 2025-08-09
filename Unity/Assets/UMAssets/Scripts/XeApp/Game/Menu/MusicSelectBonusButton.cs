using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MusicSelectBonusButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_button; // 0x14
		private AbsoluteLayout m_layoutRoot; // 0x18
		private AbsoluteLayout m_layoutBonus; // 0x1C
		private AbsoluteLayout m_layoutBonusIcon; // 0x20
		private bool m_isEntered; // 0x24

		public Action onClickButton { private get; set; } // 0x28

		// // RVA: 0x1669430 Offset: 0x1669430 VA: 0x1669430
		// public void TryEnter() { }

		// RVA: 0x16694D4 Offset: 0x16694D4 VA: 0x16694D4
		public void TryLeave()
		{
			if(m_isEntered)
			{
				Leave();
			}
		}

		// RVA: 0x1669440 Offset: 0x1669440 VA: 0x1669440
		public void Enter()
		{
			m_isEntered = true;
			m_layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x16694E4 Offset: 0x16694E4 VA: 0x16694E4
		public void Leave()
		{
			m_isEntered = false;
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x1669578 Offset: 0x1669578 VA: 0x1669578
		// public void Show() { }

		// // RVA: 0x16695FC Offset: 0x16695FC VA: 0x16695FC
		public void Hide()
		{
			m_isEntered = false;
			m_layoutRoot.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x1669680 Offset: 0x1669680 VA: 0x1669680
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingChildren();
		}

		// RVA: 0x16696AC Offset: 0x16696AC VA: 0x16696AC
		public void SetBonusButton(List<KPJHLACKGJF_EventMission.HLMINENBCKO> scheduleList)
		{
			if(scheduleList == null || scheduleList.Count == 0)
			{
				m_button.Hidden = true;
			}
			else
			{
				List<KPJHLACKGJF_EventMission.HLMINENBCKO> l = scheduleList.FindAll((KPJHLACKGJF_EventMission.HLMINENBCKO _) =>
				{
					//0x1669FC4
					return _.IPJMPBANBPP;
				});
				l.Sort((KPJHLACKGJF_EventMission.HLMINENBCKO a, KPJHLACKGJF_EventMission.HLMINENBCKO b) =>
				{
					//0x1669FD4
					return a.AAMJNIDEAHC.CompareTo(b.AAMJNIDEAHC);
				});
				if(l.Count > 0)
				{
					m_button.Hidden = false;
					ApplyBonusType(l[0]);
					m_button.ClearOnClickCallback();
					m_button.AddOnClickCallback(() =>
					{
						//0x1669F34
						if(onClickButton != null)
							onClickButton();
					});
				}
				else
				{
					m_button.Hidden = true;
				}
			}
		}

		// // RVA: 0x1669A94 Offset: 0x1669A94 VA: 0x1669A94
		private void ApplyBonusType(KPJHLACKGJF_EventMission.HLMINENBCKO schedule)
		{
			m_layoutBonus.StartChildrenAnimGoStop(schedule.CIANOCNPIFF_Type == KPJHLACKGJF_EventMission.MNIIDKPECMD.HIFIGCJNJDO_0_MusicId ? "01" : "02");
			switch(schedule.CIANOCNPIFF_Type)
			{
				case KPJHLACKGJF_EventMission.MNIIDKPECMD.HIFIGCJNJDO_0_MusicId:
					m_layoutBonusIcon.StartChildrenAnimGoStop("01");
					break;
				case KPJHLACKGJF_EventMission.MNIIDKPECMD.LNAOAANJGDM_1_SerieAttr:
					switch(schedule.IIAAIPNHJFJ_Value)
					{
						case 1:
							m_layoutBonusIcon.StartChildrenAnimGoStop("10");
							break;
						case 2:
							m_layoutBonusIcon.StartChildrenAnimGoStop("09");
							break;
						case 3:
							m_layoutBonusIcon.StartChildrenAnimGoStop("08");
							break;
						case 4:
							m_layoutBonusIcon.StartChildrenAnimGoStop("07");
							break;
						case 5:
							m_layoutBonusIcon.StartChildrenAnimGoStop("11");
							break;
						default:
							break;
					}
					break;
				case KPJHLACKGJF_EventMission.MNIIDKPECMD.OLFDHLDEPKO_2_MusicAttr:
					switch(schedule.IIAAIPNHJFJ_Value)
					{
						case 1:
							m_layoutBonusIcon.StartChildrenAnimGoStop("02");
							break;
						case 2:
							m_layoutBonusIcon.StartChildrenAnimGoStop("03");
							break;
						case 3:
							m_layoutBonusIcon.StartChildrenAnimGoStop("04");
							break;
						case 4:
							m_layoutBonusIcon.StartChildrenAnimGoStop("05");
							break;
						default:
							break;
					}
					break;
				case KPJHLACKGJF_EventMission.MNIIDKPECMD.CEPMMEKKNGC_3_All:
					m_layoutBonusIcon.StartChildrenAnimGoStop("06");
					break;
			}
		}

		// RVA: 0x1669D4C Offset: 0x1669D4C VA: 0x1669D4C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_layoutRoot = layout.FindViewById("sw_sel_music_btn_bns_transition_anim") as AbsoluteLayout;
			m_layoutBonus = layout.FindViewById("sw_s_m_btn_bns_trans_anim") as AbsoluteLayout;
			m_layoutBonusIcon = layout.FindViewById("swtbl_s_m_btn_bns_icn") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
