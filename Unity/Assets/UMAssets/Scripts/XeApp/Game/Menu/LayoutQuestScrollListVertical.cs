using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutQuestScrollListVertical : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		[SerializeField]
		private ActionButton m_buttonReceiveAll; // 0x18
		[SerializeField]
		private Text m_textReceiveDesc; // 0x1C
		private AbsoluteLayout m_root; // 0x24
		private List<FKMOKDCJFEN> m_viewList = new List<FKMOKDCJFEN>(); // 0x28

		public SwapScrollList List { get { return m_scrollList; } } //0x187ED38
		public Action OnClickReceiveAll { get; set; } // 0x20
		public bool IsOpen { get; private set; } // 0x2C

		//// RVA: 0x187ED60 Offset: 0x187ED60 VA: 0x187ED60
		//public ActionButton GetChallengeButton(int index) { }

		//// RVA: 0x187EEF8 Offset: 0x187EEF8 VA: 0x187EEF8
		private void SetupScrollList(int count, bool resetScroll)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
			if(resetScroll)
			{
				m_scrollList.SetPosition(0, 0, 0, false);
			}
			m_scrollList.VisibleRegionUpdate();
		}

		//// RVA: 0x187F0C8 Offset: 0x187F0C8 VA: 0x187F0C8
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutQuestVerticalItem c = content as LayoutQuestVerticalItem;
			if(c != null)
			{
				c.SetStatus(m_viewList[index]);
			}
		}

		// RVA: 0x187F1F8 Offset: 0x187F1F8 VA: 0x187F1F8
		public void SetStatus(LayoutQuestTab.eTabType type)
		{
			bool b = false;
			bool isBegin = false;
			switch(type)
			{
				case LayoutQuestTab.eTabType.Normal:
					m_viewList = QuestUtility.m_normalViewList;
					b = !QuestUtility.FindAchievedQuestList(m_viewList);
					break;
				case LayoutQuestTab.eTabType.Daily:
					m_viewList = QuestUtility.m_dailyViewList;
					b = !QuestUtility.FindAchievedQuestList(m_viewList);
					break;
				case LayoutQuestTab.eTabType.Diva:
					m_viewList = QuestUtility.m_snsViewList;
					b = !QuestUtility.FindAchievedQuestList(m_viewList);
					break;
				case LayoutQuestTab.eTabType.Beginner:
					m_viewList = QuestUtility.m_beginnerViewList;
					b = false;
					isBegin = true;
					break;
				default:
					b = false;
					break;
			}
			SetupScrollList(m_viewList.Count, true);
			if(isBegin)
			{
				m_textReceiveDesc.text = "";
			}
			else
			{
				m_textReceiveDesc.text = string.Format(MessageManager.Instance.GetMessage("menu", "quest_receive_all_desc"), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("quest_lump_receive_max_num", 30));
			}
			m_buttonReceiveAll.Disable = b;
			m_buttonReceiveAll.Hidden = isBegin;
		}

		// RVA: 0x187F5E8 Offset: 0x187F5E8 VA: 0x187F5E8
		public void Enter()
		{
			if (IsOpen)
				return;
			IsOpen = true;
			m_root.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x187F688 Offset: 0x187F688 VA: 0x187F688
		public void Leave()
		{
			if (!IsOpen)
				return;
			IsOpen = false;
			m_root.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x187F728 Offset: 0x187F728 VA: 0x187F728
		public void Show()
		{
			if (IsOpen)
				return;
			IsOpen = true;
			m_root.StartChildrenAnimGoStop("st_in", "st_in");
		}

		//// RVA: 0x187F7BC Offset: 0x187F7BC VA: 0x187F7BC
		public void Hide()
		{
			if (!IsOpen)
				return;
			IsOpen = false;
			m_root.StartChildrenAnimGoStop("st_out", "st_out");
		}

		// RVA: 0x187F850 Offset: 0x187F850 VA: 0x187F850
		public bool IsPlaying()
		{
			return m_root.IsPlayingChildren();
		}

		// RVA: 0x187F87C Offset: 0x187F87C VA: 0x187F87C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewById("sw_sel_que_list") as AbsoluteLayout;
			m_buttonReceiveAll.AddOnClickCallback(() =>
			{
				//0x187FA3C
				if (OnClickReceiveAll != null)
					OnClickReceiveAll();
			});
			Loaded();
			return true;
		}
	}
}
