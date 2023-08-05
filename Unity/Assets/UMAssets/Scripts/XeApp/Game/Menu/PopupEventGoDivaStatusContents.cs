using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEventGoDivaStatusContents : UIBehaviour, IPopupContent
	{
		private RectTransform m_rectTransform; // 0x10
		private LayoutPopupEventGoDivaStatus m_status; // 0x14
		private PopupWindowControl m_popupControl; // 0x18

		public Transform Parent { get; set; } // 0xC

		// RVA: 0xF8CABC Offset: 0xF8CABC VA: 0xF8CABC
		private void Awake()
		{
			m_rectTransform = transform as RectTransform;
		}

		// RVA: 0xF8CB44 Offset: 0xF8CB44 VA: 0xF8CB44 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupEventGoDivaStatusSetting s = setting as PopupEventGoDivaStatusSetting;
			m_popupControl = control;
			Parent = s.m_parent;
			m_status = GetComponent<LayoutPopupEventGoDivaStatus>();
			if(m_status != null)
			{
				m_status.Setup(s.m_statusParamSet);
			}
			gameObject.SetActive(true);
		}

		// RVA: 0xF8CD50 Offset: 0xF8CD50 VA: 0xF8CD50 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF8CD58 Offset: 0xF8CD58 VA: 0xF8CD58 Slot: 19
		public void Show()
		{
			if(m_status != null)
			{
				m_status.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0xF8CE3C Offset: 0xF8CE3C VA: 0xF8CE3C Slot: 20
		public void Hide()
		{
			if(m_status != null)
			{
				m_status.Hide();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0xF8CF20 Offset: 0xF8CF20 VA: 0xF8CF20 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0xF8CF28 Offset: 0xF8CF28 VA: 0xF8CF28 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
