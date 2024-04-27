using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public abstract class LayoutPopupLoginBonusPackListBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ScrollRect m_scrollRect; // 0x14
		[SerializeField]
		private Scrollbar m_scrollbarV; // 0x18
		[SerializeField]
		private Scrollbar m_scrollbarH; // 0x1C
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x20

		public SwapScrollList List { get { return m_scrollList; } } //0x1732B9C

		//// RVA: -1 Offset: -1 Slot: 6
		protected abstract void OnUpdateListItem(int index, SwapScrollListContent content);

		//// RVA: 0x1731898 Offset: 0x1731898 VA: 0x1731898
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
		}

		// RVA: 0x1731A7C Offset: 0x1731A7C VA: 0x1731A7C
		protected void SetScrollResize(Vector2 scrollSize, RawImageEx frameBottom)
		{
			(m_scrollRect.transform as RectTransform).sizeDelta = scrollSize;
			(m_scrollbarV.transform as RectTransform).sizeDelta = new Vector2((m_scrollbarV.transform as RectTransform).sizeDelta.x, scrollSize.y);
			(m_scrollbarH.transform as RectTransform).sizeDelta = new Vector2(scrollSize.x, (m_scrollbarV.transform as RectTransform).sizeDelta.y);
			if(frameBottom != null)
			{
				frameBottom.rectTransform.anchoredPosition = new Vector2(frameBottom.rectTransform.anchoredPosition.x, -scrollSize.y);
			}
		}
	}
}
