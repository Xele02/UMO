using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupQuestRewardListContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupQuestRewardList m_layout; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1611A34 Offset: 0x1611A34 VA: 0x1611A34 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupQuestRewardListSetting s = setting as PopupQuestRewardListSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_layout = GetComponent<LayoutPopupQuestRewardList>();
			m_layout.SetStatus(s.PopupType, s.ItemList, s.IsLimit);
			gameObject.SetActive(true);
		}

		// RVA: 0x1611C4C Offset: 0x1611C4C VA: 0x1611C4C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1611C54 Offset: 0x1611C54 VA: 0x1611C54 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1611C8C Offset: 0x1611C8C VA: 0x1611C8C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1611CC4 Offset: 0x1611CC4 VA: 0x1611CC4 Slot: 21
		public bool IsReady()
		{
			return m_layout != null && m_layout.IsReady();
		}

		// RVA: 0x1611D7C Offset: 0x1611D7C VA: 0x1611D7C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
