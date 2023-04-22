using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class CheckboxButton : ActionButton
	{
		private bool m_isChecked; // 0x80

		public bool IsChecked { get { return m_isChecked; } } //0xE652B8

		// RVA: 0xE652C0 Offset: 0xE652C0 VA: 0xE652C0 Slot: 20
		public override void SetOn()
		{
			base.SetOn();
			m_isChecked = true;
		}

		// RVA: 0xE652DC Offset: 0xE652DC VA: 0xE652DC Slot: 21
		public override void SetOff()
		{
			base.SetOff();
			m_isChecked = false;
		}

		// RVA: 0xE652F8 Offset: 0xE652F8 VA: 0xE652F8 Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			if(!IsInputOff)
			{
				if(!Disable && !Hidden)
				{
#if UNITY_ANDROID
					if(eventData.pointerId == 0)
#else
					if (eventData.pointerId == -1)
#endif
					{
						m_isChecked = !m_isChecked;
						if(m_isChecked)
						{
							PlayDecide();
						}
						else
						{
							PlayNormal();
						}
						OnClickEvent();
						m_isClick = true;
						return;
					}
				}
			}
		}

		// RVA: 0xE653AC Offset: 0xE653AC VA: 0xE653AC Slot: 16
		public override void OnPointerEnter(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0xE653B0 Offset: 0xE653B0 VA: 0xE653B0 Slot: 17
		public override void OnPointerExit(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0xE653B4 Offset: 0xE653B4 VA: 0xE653B4 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0xE653B8 Offset: 0xE653B8 VA: 0xE653B8 Slot: 19
		public override void OnPointerUp(PointerEventData eventData)
		{
			return;
		}
	}
}
