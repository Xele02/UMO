using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupConfigScrollListContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupConfigScrollList m_scrollList; // 0x10
		private ScrollRect m_scrollRect; // 0x14

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x13407C4 Offset: 0x13407C4 VA: 0x13407C4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupConfigScrollListSetting s = setting as PopupConfigScrollListSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_scrollList = GetComponent<LayoutPopupConfigScrollList>();
			if(m_scrollList != null)
			{
				m_scrollList.Parent = Parent;
				m_scrollList.AddView(s.ListContents, size, s.LayoutType, s.ConfigType);
				m_scrollList.SetStatus();
			}
			m_scrollRect = m_scrollList.GetComponentInChildren<ScrollRect>(true);
			m_scrollRect.vertical = false;
			gameObject.SetActive(true);
		}

		// RVA: 0x1340AC4 Offset: 0x1340AC4 VA: 0x1340AC4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1340ACC Offset: 0x1340ACC VA: 0x1340ACC
		public void Update()
		{
			return;
		}

		// RVA: 0x1340AD0 Offset: 0x1340AD0 VA: 0x1340AD0 Slot: 19
		public void Show()
		{
			if(m_scrollList != null)
			{
				m_scrollList.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x1340BB4 Offset: 0x1340BB4 VA: 0x1340BB4 Slot: 20
		public void Hide()
		{
			if(m_scrollList != null)
			{
				m_scrollList.Hide();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0x1340C98 Offset: 0x1340C98 VA: 0x1340C98 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1340CA0 Offset: 0x1340CA0 VA: 0x1340CA0
		public void SetScrollPosition()
		{
			m_scrollList.SetScrollPosition();
		}

		// RVA: 0x1340CCC Offset: 0x1340CCC VA: 0x1340CCC Slot: 22
		public void CallOpenEnd()
		{
			m_scrollRect.vertical = true;
			m_scrollRect.velocity = Vector2.zero;
		}
	}
}
