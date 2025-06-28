using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public abstract class LayoutGachaBoxListBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		private int m_selectIndex; // 0x18
		public SwapScrollList List { get { return m_scrollList; } } //0x19A38DC
		// protected abstract AbsoluteLayout layoutRoot { get; } // Slot: 6
		// public int selectIndex { get; } 0x19A38E4

		// RVA: 0x19A38EC Offset: 0x19A38EC VA: 0x19A38EC
		private void Awake()
		{
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener((int value, SwapScrollListContent content) =>
				{
					//0x19A3E0C
					if(value == 0 && !MenuScene.CheckDatelineAndAssetUpdate())
					{
						m_selectIndex = content.Index;
						OnSelectListItem(0, content);
					}
				});
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
			}
		}

		// // RVA: 0x19A3B60 Offset: 0x19A3B60 VA: 0x19A3B60
		// public void Enter() { }

		// // RVA: 0x19A3C00 Offset: 0x19A3C00 VA: 0x19A3C00
		// public void Leave() { }

		// // RVA: 0x19A3CA0 Offset: 0x19A3CA0 VA: 0x19A3CA0
		// public void Show() { }

		// // RVA: 0x19A3D34 Offset: 0x19A3D34 VA: 0x19A3D34
		// public void Hide() { }

		// // RVA: 0x19A3DC8 Offset: 0x19A3DC8 VA: 0x19A3DC8
		// public bool IsPlaying() { }

		// // RVA: 0x19A38F0 Offset: 0x19A38F0 VA: 0x19A38F0
		// private void InitializeList() { }

		// // RVA: -1 Offset: -1 Slot: 7
		protected abstract void OnSelectListItem(int value, SwapScrollListContent content);

		// RVA: 0x19A3050 Offset: 0x19A3050 VA: 0x19A3050
		protected void SetupList(int count, bool resetScroll)
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
