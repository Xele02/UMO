using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupConfigDetailContent : UIBehaviour, IPopupContent
	{
		private LayoutPopupConfigDetailBase m_detail; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x133F730 Offset: 0x133F730 VA: 0x133F730 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupConfigDetailSetting s = setting as PopupConfigDetailSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			m_detail = GetComponent<LayoutPopupConfigDetailBase>();
			if(m_detail != null)
			{
				m_detail.SetStatus();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x133F95C Offset: 0x133F95C VA: 0x133F95C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x133F964 Offset: 0x133F964 VA: 0x133F964
		public void Update()
		{
			return;
		}

		// RVA: 0x133F968 Offset: 0x133F968 VA: 0x133F968 Slot: 19
		public void Show()
		{
			if(m_detail != null)
			{
				m_detail.Show();
			}
			gameObject.SetActive(true);
		}

		// RVA: 0x133FA54 Offset: 0x133FA54 VA: 0x133FA54 Slot: 20
		public void Hide()
		{
			if(m_detail != null)
			{
				m_detail.Hide();
			}
			gameObject.SetActive(false);
		}

		// RVA: 0x133FB40 Offset: 0x133FB40 VA: 0x133FB40 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x133FB48 Offset: 0x133FB48 VA: 0x133FB48 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
