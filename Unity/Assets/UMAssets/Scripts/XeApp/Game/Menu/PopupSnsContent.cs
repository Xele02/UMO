using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupSnsContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupSnsSetting m_layoutPopupSnsSetting; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1148AA8 Offset: 0x1148AA8 VA: 0x1148AA8 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupSnsSetting s = setting as PopupSnsSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
			m_layoutPopupSnsSetting = GetComponent<LayoutPopupSnsSetting>();
			if(m_layoutPopupSnsSetting != null)
			{
				m_layoutPopupSnsSetting.OnButtonCallbackTwitter = s.ButtonCallbackTwitter;
				m_layoutPopupSnsSetting.OnButtonCallbackFacebook = s.ButtonCallbackFacebook;
				m_layoutPopupSnsSetting.OnButtonCallbackLine = s.ButtonCallbackLine;
				m_layoutPopupSnsSetting.OnButtonCallbackApple = s.ButtonCallbackApple;
				m_layoutPopupSnsSetting.OnButtonCallbackShow = s.ButtonCallbackShow;
				m_layoutPopupSnsSetting.IsTitle = s.IsTitle;
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x1148E50 Offset: 0x1148E50 VA: 0x1148E50 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1148E58 Offset: 0x1148E58 VA: 0x1148E58
		public void Update()
		{
			return;
		}

		// RVA: 0x1148E5C Offset: 0x1148E5C VA: 0x1148E5C
		public void SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType buttonType, LayoutPopupSnsSetting.eButtonStatus status)
		{
			if(m_layoutPopupSnsSetting != null)
			{
				m_layoutPopupSnsSetting.SetButtonSnsStatus(buttonType, status);
			}
		}

		// RVA: 0x1148F20 Offset: 0x1148F20 VA: 0x1148F20 Slot: 19
		public void Show()
		{
			if(m_layoutPopupSnsSetting != null)
			{
				m_layoutPopupSnsSetting.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x1149004 Offset: 0x1149004 VA: 0x1149004 Slot: 20
		public void Hide()
		{
			if (m_layoutPopupSnsSetting != null)
			{
				m_layoutPopupSnsSetting.Hide();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0x11490E8 Offset: 0x11490E8 VA: 0x11490E8 Slot: 21
		public bool IsReady()
		{
			return m_layoutPopupSnsSetting.IsLoaded();
		}

		// RVA: 0x1149114 Offset: 0x1149114 VA: 0x1149114 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
