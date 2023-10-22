using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public abstract class LayoutShopListBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		private int m_selectIndex; // 0x18

		public SwapScrollList List { get { return m_scrollList; } } //0x193F274
		protected abstract AbsoluteLayout layoutRoot { get; } // RVA: -1 Offset: -1 Slot: 6
		// public int selectIndex { get; } 0x193F27C

		// RVA: 0x193F284 Offset: 0x193F284 VA: 0x193F284
		private void Awake()
		{
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener((int value, SwapScrollListContent content) =>
				{
					//0x193FC40
					if(!MenuScene.CheckDatelineAndAssetUpdate() && value == 0)
					{
						m_selectIndex = content.Index;
						OnSelectListItem(0, content);
					}
				});
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
			}
		}

		// RVA: 0x193F4F8 Offset: 0x193F4F8 VA: 0x193F4F8
		private void Update()
		{
			return;
		}

		// RVA: 0x193F4FC Offset: 0x193F4FC VA: 0x193F4FC
		public void Enter()
		{
			layoutRoot.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x193F59C Offset: 0x193F59C VA: 0x193F59C
		public void Leave()
		{
			layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x193F63C Offset: 0x193F63C VA: 0x193F63C
		// public void Show() { }

		// RVA: 0x193F6D0 Offset: 0x193F6D0 VA: 0x193F6D0
		public void Hide()
		{
			layoutRoot.StartChildrenAnimGoStop("st_out", "st_out");
		}

		// RVA: 0x193F764 Offset: 0x193F764 VA: 0x193F764
		public bool IsPlaying()
		{
			return layoutRoot.IsPlayingAll();
		}

		// // RVA: 0x193F7A0 Offset: 0x193F7A0 VA: 0x193F7A0
		// public bool IsLoaded() { }

		// // RVA: 0x193F288 Offset: 0x193F288 VA: 0x193F288
		// private void InitializeList() { }

		// // RVA: -1 Offset: -1 Slot: 7
		protected abstract void OnSelectListItem(int value, SwapScrollListContent content);

		// // RVA: 0x193F8A4 Offset: 0x193F8A4 VA: 0x193F8A4
		protected void SetupList(int count, bool resetScroll)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
			if(resetScroll)
				m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
		}

		// // RVA: -1 Offset: -1 Slot: 8
		protected abstract void OnUpdateListItem(int index, SwapScrollListContent content);
	}
}
