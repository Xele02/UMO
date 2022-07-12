using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class UGUIStayButton : UGUIButton
	{
		public delegate void OnStayCallback();

		// [CompilerGeneratedAttribute] // RVA: 0x68CEA8 Offset: 0x68CEA8 VA: 0x68CEA8
		private UGUIStayButton.OnStayCallback m_stayEvent = () => {
			//0x1CDC1F4
			return;
		}; // 0x38
		private float m_interval = 0.4f; // 0x3C
		private float m_nextTime; // 0x40
		private Action m_updater; // 0x44
		private bool m_isLongPressed; // 0x48
		private bool m_isStayDisable; // 0x49

		// public bool IsStayDisable { get; set; } 0x1CDB870 0x1CDB878

		// [CompilerGeneratedAttribute] // RVA: 0x740664 Offset: 0x740664 VA: 0x740664
		// // RVA: 0x1CDB658 Offset: 0x1CDB658 VA: 0x1CDB658
		// private void add_m_stayEvent(UGUIStayButton.OnStayCallback value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x740674 Offset: 0x740674 VA: 0x740674
		// // RVA: 0x1CDB764 Offset: 0x1CDB764 VA: 0x1CDB764
		// private void remove_m_stayEvent(UGUIStayButton.OnStayCallback value) { }

		// RVA: 0x1CDB880 Offset: 0x1CDB880 VA: 0x1CDB880 Slot: 11
		protected override void Start()
		{
			base.Start();
			m_updater = this.UpdateIdel;
		}

		// RVA: 0x1CDB914 Offset: 0x1CDB914 VA: 0x1CDB914
		private void Update()
		{
			if (m_updater != null)
				m_updater();
		}

		// // RVA: 0x1CDB940 Offset: 0x1CDB940 VA: 0x1CDB940
		private void UpdateIdel()
		{
			return;
		}

		// // RVA: 0x1CDB944 Offset: 0x1CDB944 VA: 0x1CDB944
		private void UpdatePressed()
		{
			if(IsPressed())
			{
				if (!Disable && !m_isStayDisable && !IsInputOff)
				{
					if (Time.realtimeSinceStartup <= m_nextTime)
						return;
					SetOff();
					PlayNormal();
					m_stayEvent();
					m_isLongPressed = true;
				}
			}
			m_updater = this.UpdateIdel;
		}

		// RVA: 0x1CDBEE4 Offset: 0x1CDBEE4 VA: 0x1CDBEE4 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if(IsEventProcessed && m_stayEvent != null)
			{
				m_isClick = false;
				m_nextTime = Time.realtimeSinceStartup + m_interval;
				m_updater = this.UpdatePressed;
			}
			m_isLongPressed = false;
		}

		// RVA: 0x1CDBFC8 Offset: 0x1CDBFC8 VA: 0x1CDBFC8 Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			if (m_isLongPressed)
				return;
			base.OnPointerClick(eventData);
		}

		// // RVA: 0x1CDBFDC Offset: 0x1CDBFDC VA: 0x1CDBFDC
		public void AddOnStayCallback(UGUIStayButton.OnStayCallback callback)
		{
			m_stayEvent += callback;
		}

		// // RVA: 0x1CDBFE0 Offset: 0x1CDBFE0 VA: 0x1CDBFE0
		// public void RemoveOnStayCallback(UGUIStayButton.OnStayCallback callback) { }

		// // RVA: 0x1CDBFE4 Offset: 0x1CDBFE4 VA: 0x1CDBFE4
		// public void ClearOnStayCallback() { }
	}
}
