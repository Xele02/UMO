using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDecoCountPopup : UIBehaviour, IPopupContent
	{
		private Transform m_parent; // 0xC

		public Transform Parent { get { return m_parent; } } //0x1345E30

		// RVA: 0x1345B48 Offset: 0x1345B48 VA: 0x1345B48 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupDecoCountSetting s = setting as PopupDecoCountSetting;
			LayoutDecorationCountContent l = s.Content.GetComponent<LayoutDecorationCountContent>();
			l.GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize(s.WindowSize, true);
			l.UpdateContent(s.decoCount);
			m_parent = s.m_parent;
		}

		// RVA: 0x1345D14 Offset: 0x1345D14 VA: 0x1345D14 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1345D1C Offset: 0x1345D1C VA: 0x1345D1C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1345D54 Offset: 0x1345D54 VA: 0x1345D54 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1345D8C Offset: 0x1345D8C VA: 0x1345D8C Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x1345E2C Offset: 0x1345E2C VA: 0x1345E2C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
