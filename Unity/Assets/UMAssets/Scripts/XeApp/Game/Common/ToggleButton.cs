using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class ToggleButton : ActionButton
	{
		[SerializeField]
		private short m_gropId = -1; // 0x80
		[SerializeField]
		private bool m_isNotRepeat; // 0x82
		[SerializeField]
		private ToggleButtonGroup m_parent; // 0x84
		private bool m_isSet; // 0x88

		// public short GropID { get; } 0x1CCF1EC
		public bool IsOn { get { return m_isSet; } } //0x1CCF1F4

		// RVA: 0x1CCF1FC Offset: 0x1CCF1FC VA: 0x1CCF1FC Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			if(Hidden || Disable || IsInputOff || IsInputLock || !IsEnableTouchId(eventData))
				return;
			if(m_gropId > -1)
			{
				if(m_parent != null)
				{
					if(!m_isSet)
						base.OnPointerClick(eventData);
					m_parent.SelectGroupButton(this, m_parent.GetM_toggleButtons());
					return;
				}
			}
			if(!m_isNotRepeat)
			{
				if(m_isSet)
					SetOff();
				else
					SetOn();
			}
			else if(m_isSet)
				return;
			else
				SetOn();
			m_isClick = true;
			OnClickEvent();
		}

		// RVA: 0x1CCF620 Offset: 0x1CCF620 VA: 0x1CCF620 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0x1CCF624 Offset: 0x1CCF624 VA: 0x1CCF624 Slot: 19
		public override void OnPointerUp(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0x1CCF628 Offset: 0x1CCF628 VA: 0x1CCF628 Slot: 16
		public override void OnPointerEnter(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0x1CCF62C Offset: 0x1CCF62C VA: 0x1CCF62C Slot: 17
		public override void OnPointerExit(PointerEventData eventData)
		{
			return;
		}

		// RVA: 0x1CCF630 Offset: 0x1CCF630 VA: 0x1CCF630 Slot: 21
		public override void SetOff()
		{
			if(!Hidden && !Disable)
			{
				base.SetOff();
				m_isSet = false;
			}
		}

		// RVA: 0x1CCF678 Offset: 0x1CCF678 VA: 0x1CCF678 Slot: 20
		public override void SetOn()
		{
			if(!Hidden && !Disable)
			{
				base.SetOn();
				m_isSet = true;
			}
		}
	}
}
