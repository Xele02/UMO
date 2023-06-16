using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupCostumeItemDetail : UIBehaviour, IPopupContent
	{
		private LFAFJCNKLML m_data; // 0x10
		private int m_lv; // 0x14
		private PopupWindowControl m_control; // 0x18

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1342F74 Offset: 0x1342F74 VA: 0x1342F74 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			CostumeItemDetailPopupSetting s = setting as CostumeItemDetailPopupSetting;
			m_control = control;
			Parent = setting.m_parent;
			m_data = s.data;
			m_lv = s.lv;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0x13431A4 Offset: 0x13431A4 VA: 0x13431A4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x13431AC Offset: 0x13431AC VA: 0x13431AC Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x13431E4 Offset: 0x13431E4 VA: 0x13431E4 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x134321C Offset: 0x134321C VA: 0x134321C Slot: 21
		public bool IsReady()
		{
			transform.GetComponent<CostumeItemDetailWindow>().Initialize(m_data, m_lv);
			return true;
		}

		// RVA: 0x13432D4 Offset: 0x13432D4 VA: 0x13432D4 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
