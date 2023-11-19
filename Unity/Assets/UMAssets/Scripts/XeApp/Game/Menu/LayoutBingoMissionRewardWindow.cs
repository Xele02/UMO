using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutBingoMissionRewardWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		public List<GNGMCIAIKMA.JCIFAFBDALP> itemInfoList; // 0x18
		public List<string> missionTextList; // 0x1C

		public SwapScrollList List { get { return m_scrollList; } } //0x14C6134

		// RVA: 0x14C613C Offset: 0x14C613C VA: 0x14C613C
		private void Start()
		{
			return;
		}

		// RVA: 0x14C6140 Offset: 0x14C6140 VA: 0x14C6140
		private void Update()
		{
			return;
		}

		// // RVA: 0x14C6144 Offset: 0x14C6144 VA: 0x14C6144
		public void SetUp()
		{
			InitializeList();
			SetupList(itemInfoList.Count, true);
		}

		// // RVA: 0x14C6494 Offset: 0x14C6494 VA: 0x14C6494
		public void SetItemInfo(List<GNGMCIAIKMA.JCIFAFBDALP> itemlist, List<string> textList)
		{
			itemInfoList = itemlist;
			missionTextList = textList;
		}

		// // RVA: 0x14C61D4 Offset: 0x14C61D4 VA: 0x14C61D4
		private void InitializeList()
		{
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
			}
		}

		// // RVA: 0x14C62C4 Offset: 0x14C62C4 VA: 0x14C62C4
		private void SetupList(int count, bool resetScroll)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
			if(resetScroll)
				m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		// // RVA: 0x14C64A0 Offset: 0x14C64A0 VA: 0x14C64A0
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutBingoMissionRewardContents c = content as LayoutBingoMissionRewardContents;
			if(c != null)
			{
				c.Setup(itemInfoList[index].PPFNGGCBJKC_Id, itemInfoList[index].BFINGCJHOHI_Cnt, missionTextList[index].Replace("\n", ""), (int idx) =>
				{
					//0x14C6844
					return;
				});
			}
		}

		// RVA: 0x14C67A8 Offset: 0x14C67A8 VA: 0x14C67A8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
