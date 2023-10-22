using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDecoSpItemRemove : UIBehaviour, IPopupContent
	{
		private Transform m_parent; // 0xC

		public Transform Parent { get { return m_parent; } } // 0xF7B1F4

		// RVA: 0xF7AEE0 Offset: 0xF7AEE0 VA: 0xF7AEE0 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			DocorationSpItemRemovePopupSetting s = setting as DocorationSpItemRemovePopupSetting;
			LayoutDecorationSpItemRemoveContent c = setting.Content.GetComponent<LayoutDecorationSpItemRemoveContent>();
			c.GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize(setting.WindowSize, true);
			c.SetIcon(s.itemList);
			c.SetMessage(s.isReplaceRoom);
			m_parent = setting.m_parent;
		}

		// RVA: 0xF7B0D8 Offset: 0xF7B0D8 VA: 0xF7B0D8 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF7B0E0 Offset: 0xF7B0E0 VA: 0xF7B0E0 Slot: 19
		public void Show()
		{ 
			gameObject.SetActive(true);
		}

		// RVA: 0xF7B118 Offset: 0xF7B118 VA: 0xF7B118 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF7B150 Offset: 0xF7B150 VA: 0xF7B150 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xF7B1F0 Offset: 0xF7B1F0 VA: 0xF7B1F0 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
