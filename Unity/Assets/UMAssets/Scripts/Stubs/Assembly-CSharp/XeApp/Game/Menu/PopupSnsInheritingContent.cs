using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupSnsInheritingContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupSnsInheritingSetting m_layoutPopupSnsSetting; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1149130 Offset: 0x1149130 VA: 0x1149130 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupSnsInheritingSetting s = setting as PopupSnsInheritingSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(setting.WindowSize, setting.IsCaption);
			transform.localPosition = Vector3.zero;
			m_layoutPopupSnsSetting = GetComponent<LayoutPopupSnsInheritingSetting>();
			if(m_layoutPopupSnsSetting != null)
			{
				m_layoutPopupSnsSetting.OnButtonCallbackTwitter = s.ButtonCallbackTwitter;
				m_layoutPopupSnsSetting.OnButtonCallbackFacebook = s.ButtonCallbackFacebook;
				m_layoutPopupSnsSetting.OnButtonCallbackLine = s.ButtonCallbackLine;
				m_layoutPopupSnsSetting.OnButtonCallbackApple = s.ButtonCallbackApple;
				m_layoutPopupSnsSetting.OnButtonCallbackCaution = s.ButtonCallbackCaution;
				m_layoutPopupSnsSetting.IsTitle = s.IsTitle;
				m_layoutPopupSnsSetting.IsPreparation = s.IsPreparation;
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x11495A0 Offset: 0x11495A0 VA: 0x11495A0 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x11495A8 Offset: 0x11495A8 VA: 0x11495A8
		public void Update()
		{
			return;
		}

		// RVA: 0x11495AC Offset: 0x11495AC VA: 0x11495AC
		public void SetButtonSnsStatus(LayoutPopupSnsSetting.eButtonType buttonType, LayoutPopupSnsSetting.eButtonStatus status = 0)
		{
			if (m_layoutPopupSnsSetting != null)
				m_layoutPopupSnsSetting.SetButtonSnsStatus(buttonType, status);
		}

		// RVA: 0x1149670 Offset: 0x1149670 VA: 0x1149670 Slot: 19
		public void Show()
		{
			if (m_layoutPopupSnsSetting != null)
				m_layoutPopupSnsSetting.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x1149754 Offset: 0x1149754 VA: 0x1149754 Slot: 20
		public void Hide()
		{
			if (m_layoutPopupSnsSetting != null)
				m_layoutPopupSnsSetting.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x1149838 Offset: 0x1149838 VA: 0x1149838 Slot: 21
		public bool IsReady()
		{
			return m_layoutPopupSnsSetting.IsLoaded();
		}

		// RVA: 0x1149864 Offset: 0x1149864 VA: 0x1149864 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
