using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDecoSentGift : UIBehaviour, IPopupContent
	{
		private Transform m_parent; // 0xC

		public Transform Parent { get { return m_parent; } } //0xF78624

		// RVA: 0xF78300 Offset: 0xF78300 VA: 0xF78300 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupDecoSentGiftSetting s = setting as PopupDecoSentGiftSetting;
			LayoutDecorationSentGiftContent l = setting.Content.GetComponent<LayoutDecorationSentGiftContent>();
			l.GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize(setting.WindowSize, true);
			l.UpdateContent(s.itemId, s.count, s.sentCount);
			m_parent = setting.m_parent;
		}

		// RVA: 0xF78508 Offset: 0xF78508 VA: 0xF78508 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF78510 Offset: 0xF78510 VA: 0xF78510 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF78548 Offset: 0xF78548 VA: 0xF78548 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF78580 Offset: 0xF78580 VA: 0xF78580 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xF78620 Offset: 0xF78620 VA: 0xF78620 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
