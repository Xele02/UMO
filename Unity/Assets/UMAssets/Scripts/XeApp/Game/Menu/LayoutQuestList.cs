using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using XeSys;
using UnityEngine.Localization.SmartFormat;

namespace XeApp.Game.Menu
{
	public class LayoutQuestList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		[SerializeField]
		private ActionButton m_buttonReceiveAll; // 0x18
		[SerializeField]
		private RawImageEx m_imageFont; // 0x1C
		[SerializeField]
		private Text m_textTime; // 0x20
		[SerializeField]
		private Text m_textNoneText; // 0x24
		[SerializeField]
		private Text m_textReceiveDesc; // 0x28
		private List<FKMOKDCJFEN> m_viewList = new List<FKMOKDCJFEN>(); // 0x30
		private int m_frameCount; // 0x34
		private CGJKNOCAPII m_entranceViewData; // 0x38
		private AbsoluteLayout m_root; // 0x3C
		public Action<FKMOKDCJFEN> OnSelectedQuestCallback; // 0x44

		public SwapScrollList List { get { return m_scrollList; } } //0x18798EC
		public Action OnClickReceiveAll { get; set; } // 0x2C
		public bool IsOpen { get; private set; } // 0x40

		// RVA: 0x1879914 Offset: 0x1879914 VA: 0x1879914
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x187991C Offset: 0x187991C VA: 0x187991C
		public new bool IsLoaded()
		{
			for(int i = 0; i < m_scrollList.ScrollObjectCount; i++)
			{
				if(!m_scrollList.ScrollObjects[i].IsLoaded())
					return false;
			}
			return true;
		}

		// RVA: 0x1879A20 Offset: 0x1879A20 VA: 0x1879A20
		private void Update()
		{
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				if(m_scrollList.ScrollObjects[i].IsLoaded())
					(m_scrollList.ScrollObjects[i] as LayoutQuestVerticalItem).SetDailyAnimFrame(m_frameCount);
			}
			m_frameCount++;
		}

		// // RVA: 0x1879C00 Offset: 0x1879C00 VA: 0x1879C00
		private void SetupScrollList(int count, bool resetScroll)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
			if(resetScroll)
				m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		// // RVA: 0x1879DD0 Offset: 0x1879DD0 VA: 0x1879DD0
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutQuestVerticalItem c = content as LayoutQuestVerticalItem;
			if(c != null)
			{
				c.SetStatus(m_viewList[index]);
			}
		}

		// RVA: 0x187A170 Offset: 0x187A170 VA: 0x187A170
		public void Setup(List<FKMOKDCJFEN> viewData, CGJKNOCAPII entranceViewData)
		{
			m_viewList.Clear();
			if(viewData != null)
			{
				for(int i = 0; i < viewData.Count; i++)
				{
					m_viewList.Add(viewData[i]);
				}
				m_entranceViewData = entranceViewData;
			}
		}

		// RVA: 0x187A2A8 Offset: 0x187A2A8 VA: 0x187A2A8
		public void SetStatus()
		{
			int quest_lump_receive_max_num = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("quest_lump_receive_max_num", 30);
			m_textReceiveDesc.text = Smart.Format(MessageManager.Instance.GetMessage("menu", "quest_receive_all_desc"), quest_lump_receive_max_num);
			m_buttonReceiveAll.Disable = !QuestUtility.FindAchievedQuestList(m_viewList);
			SetTextTimerInner();
			SetImageFont(m_entranceViewData.LFCOJABLOEN_EventId);
			UpdateList();
		}

		// // RVA: 0x187A88C Offset: 0x187A88C VA: 0x187A88C
		private string GetStringDay(string label, long startTime, long endTime)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			DateTime date = Utility.GetLocalDateTime(startTime);
			string str1 = string.Format(bk.GetMessageByLabel("quest_tiemr_e003"), new object[5]
			{
				date.Year, date.Month, date.Day, date.Hour, date.Minute
			});
			date = Utility.GetLocalDateTime(endTime);
			string str2 = string.Format(bk.GetMessageByLabel("quest_tiemr_e003"), new object[5]
			{
				date.Year, date.Month, date.Day, date.Hour, date.Minute
			});
			return string.Format(bk.GetMessageByLabel(label), str1, str2);
		}

		// // RVA: 0x187AFD0 Offset: 0x187AFD0 VA: 0x187AFD0
		public void SwitchNoneText(bool enable)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(m_textNoneText != null)
			{
				if(enable)
					m_textNoneText.text = bk.GetMessageByLabel("quest_reward_none_list");
				else
					m_textNoneText.text = "";
			}
		}

		// // RVA: 0x187A4F0 Offset: 0x187A4F0 VA: 0x187A4F0
		private void SetTextTimerInner()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			SetTextTimer(GetStringDay(m_entranceViewData.PNFDMBHDPAJ ? "quest_tiemr_e002" : "quest_tiemr_e001", m_entranceViewData.KINJOEIAHFK_Start, m_entranceViewData.PCCFAKEOBIC_End));
		}

		// // RVA: 0x187B124 Offset: 0x187B124 VA: 0x187B124
		public void SetTextTimer(string text)
		{
			if(m_textTime != null)
				m_textTime.text = text;
		}

		// // RVA: 0x187A640 Offset: 0x187A640 VA: 0x187A640
		public void SetImageFont(int id)
		{
			if(m_imageFont != null)
			{
				m_imageFont.enabled = false;
				GameManager.Instance.QuestEventTextureCache.LoadFont(id, (IiconTexture texture) =>
				{
					//0x187B7A8
					if(m_imageFont != null)
					{
						if(texture != null)
						{
							texture.Set(m_imageFont);
						}
						m_imageFont.enabled = true;
					}
				});
			}
		}

		// // RVA: 0x187B1E4 Offset: 0x187B1E4 VA: 0x187B1E4
		private void SortViewList()
		{
			int[] sortTbl = new int[4] {
				4, 2, 1, 3
			};
			m_viewList.Sort((FKMOKDCJFEN a, FKMOKDCJFEN b) =>
			{
				//0x187B900
				int res = sortTbl[(int)a.CMCKNKKCNDK_Status] - sortTbl[(int)b.CMCKNKKCNDK_Status];
				if(res == 0)
					res = a.EEFLOOBOAGF - b.EEFLOOBOAGF;
				return res;
			});
		}

		// RVA: 0x187A7BC Offset: 0x187A7BC VA: 0x187A7BC
		public void UpdateList()
		{
			SortViewList();
			SetupScrollList(m_viewList.Count, true);
			SwitchNoneText(m_viewList.Count == 0);
		}

		// RVA: 0x187B318 Offset: 0x187B318 VA: 0x187B318
		public void Enter()
		{
			if(m_root != null && !IsOpen)
			{
				IsOpen = true;
				m_root.StartAllAnimGoStop("go_in", "st_in");
			}
		}

		// RVA: 0x187B3B0 Offset: 0x187B3B0 VA: 0x187B3B0
		public void Leave()
		{
			if(m_root != null && IsOpen)
			{
				IsOpen = false;
				m_root.StartAllAnimGoStop("go_out", "st_out");
			}
		}

		// // RVA: 0x187B444 Offset: 0x187B444 VA: 0x187B444
		// public void Show() { }

		// // RVA: 0x187B4D0 Offset: 0x187B4D0 VA: 0x187B4D0
		// public void Hide() { }

		// RVA: 0x187B558 Offset: 0x187B558 VA: 0x187B558
		public bool IsPlaying()
		{
			return m_root.IsPlayingChildren();
		}

		// RVA: 0x187B584 Offset: 0x187B584 VA: 0x187B584 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.Root[0] as AbsoluteLayout;
			m_imageFont.raycastTarget = false;
			m_buttonReceiveAll.AddOnClickCallback(() =>
			{
				//0x187B8EC
				if(OnClickReceiveAll != null)
					OnClickReceiveAll();
			});
			SetTextTimer("");
			SwitchNoneText(false);
			Loaded();
			return true;
		}
	}
}
