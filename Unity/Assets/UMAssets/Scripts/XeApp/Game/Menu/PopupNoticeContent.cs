using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupNoticeContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupConfigOther_01 m_notice; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x169D6C4 Offset: 0x169D6C4 VA: 0x169D6C4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupNoticeSetting s = setting as PopupNoticeSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_notice = GetComponent<LayoutPopupConfigOther_01>();
			if (m_notice != null)
				m_notice.SetStatus(null);
			gameObject.SetActive(true);
		}

		// RVA: 0x169D8F4 Offset: 0x169D8F4 VA: 0x169D8F4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x169D8FC Offset: 0x169D8FC VA: 0x169D8FC
		public void Update()
		{
			return;
		}

		// RVA: 0x169D900 Offset: 0x169D900 VA: 0x169D900 Slot: 19
		public void Show()
		{
			if (m_notice != null)
				m_notice.Show();
			gameObject.SetActive(true);
		}

		// RVA: 0x169D9E4 Offset: 0x169D9E4 VA: 0x169D9E4 Slot: 20
		public void Hide()
		{
			if (m_notice != null)
				m_notice.Hide();
			gameObject.SetActive(false);
		}

		// RVA: 0x169DAC8 Offset: 0x169DAC8 VA: 0x169DAC8 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x169DAD0 Offset: 0x169DAD0 VA: 0x169DAD0 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
