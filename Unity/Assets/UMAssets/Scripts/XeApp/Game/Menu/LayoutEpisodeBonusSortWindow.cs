using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.Events;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutEpisodeBonusSortWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_episodePointNoteText; // 0x14
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x18

		public SwapScrollList ScrollList { get { return m_scrollList; } } //0x18C8A50
		public int ScrollItemCount { get; set; } // 0x1C
		public UnityAction<int, SwapScrollListContent> UpdateList { get; set; } // 0x20

		// RVA: 0x18C8A78 Offset: 0x18C8A78 VA: 0x18C8A78 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}

		// // RVA: 0x18C8A90 Offset: 0x18C8A90 VA: 0x18C8A90
		public void Setup()
		{
			m_episodePointNoteText.text = MessageManager.Instance.GetMessage("menu", "popup_episodebonus_note_02");
			SetupList(ScrollItemCount, UpdateList);
		}

		// // RVA: 0x18C8B70 Offset: 0x18C8B70 VA: 0x18C8B70
		public void SetupList(int count, UnityAction<int, SwapScrollListContent> UpdateList)
		{
			m_scrollList.ScrollRect.enabled = true;
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(UpdateList);
			m_scrollList.ResetScrollVelocity();
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}
	}
}
