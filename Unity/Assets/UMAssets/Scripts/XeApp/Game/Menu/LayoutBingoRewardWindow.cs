using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutBingoRewardWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		private bool m_isItemIconLoad; // 0x18
		private List<bool> ItemIconLoadedList = new List<bool>(); // 0x1C
		private Action<int> OnClickIcon; // 0x20
		private JJPEIELNEJB.JLHHGLANHGE[] ItemList; // 0x24
		private int m_receivedBingoCount; // 0x28

		public SwapScrollList List { get { return m_scrollList; } } //0x14CB64C

		// RVA: 0x14CB654 Offset: 0x14CB654 VA: 0x14CB654
		private void Start()
		{
			return;
		}

		// RVA: 0x14CB658 Offset: 0x14CB658 VA: 0x14CB658
		private void Update()
		{
			return;
		}

		//// RVA: 0x14CB65C Offset: 0x14CB65C VA: 0x14CB65C
		//public bool ILayoutLoaded() { }

		//// RVA: 0x14CB664 Offset: 0x14CB664 VA: 0x14CB664
		public void SetUp(int _receivedCount)
		{
			m_receivedBingoCount = _receivedCount;
			for(int i = 0; i < m_scrollList.ScrollObjectCount; i++)
			{
				ItemIconLoadedList.Add(false);
			}
			InitializeList();
			SetupList(m_scrollList.ScrollObjectCount, true);
		}

		//// RVA: 0x14CBA14 Offset: 0x14CBA14 VA: 0x14CBA14
		public void SettingButton(Action<int> act)
		{
			OnClickIcon = (int i) =>
			{
				//0x14CBEC4
				act(i);
			};
		}

		//// RVA: 0x14CBAE8 Offset: 0x14CBAE8 VA: 0x14CBAE8
		public void SettingItemList(JJPEIELNEJB.JLHHGLANHGE[] _itemlist)
		{
			ItemList = _itemlist;
		}

		//// RVA: 0x14CB754 Offset: 0x14CB754 VA: 0x14CB754
		private void InitializeList()
		{
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
			}
		}

		//// RVA: 0x14CB844 Offset: 0x14CB844 VA: 0x14CB844
		private void SetupList(int count, bool resetScroll)
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

		//// RVA: 0x14CBAF0 Offset: 0x14CBAF0 VA: 0x14CBAF0
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutBingoRewardContents c = content as LayoutBingoRewardContents;
			if(c != null)
			{
				c.SetUp(ItemList[index], () =>
				{
					//0x14CBF44
					ItemIconLoadedList[index] = true;
				}, (int itemId) =>
				{
					//0x14CBFDC
					if (OnClickIcon != null)
						OnClickIcon(itemId);
				});
				c.ClearIconEnable(index < m_receivedBingoCount);
			}
		}

		//// RVA: 0x14CBD3C Offset: 0x14CBD3C VA: 0x14CBD3C
		public new bool IsLoaded()
		{
			for(int i = 0; i < ItemIconLoadedList.Count; i++)
			{
				if (!ItemIconLoadedList[i])
					return false;
			}
			return true;
		}

		// RVA: 0x14CBE04 Offset: 0x14CBE04 VA: 0x14CBE04 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
