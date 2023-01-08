using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class RepeatButton : ActionButton
	{
		public delegate void OnRepeatCallback();

		public RepeatButton.OnRepeatCallback m_repeatEvent = () => {
			//0x138B124
			return;
		}; // 0x80
		private float m_interval = 0.4f; // 0x84
		private float m_repeat = 0.1f; // 0x88
		private float m_nextTime; // 0x8C
		private Action m_updater; // 0x90
		private bool m_isLongPressed; // 0x94
		private bool m_isRepeatDisable; // 0x95

		// public bool IsRepeatDisable { get; set; } 0x138A79C 0x138A7A4

		// RVA: 0x138A7AC Offset: 0x138A7AC VA: 0x138A7AC Slot: 11
		protected override void Start()
		{
			base.Start();
			m_updater = UpdateIdel;
		}

		// RVA: 0x138A840 Offset: 0x138A840 VA: 0x138A840
		private void Update()
		{
			m_updater();
		}

		// // RVA: 0x138A86C Offset: 0x138A86C VA: 0x138A86C
		private void UpdateIdel()
		{
			return;
		}

		// // RVA: 0x138A870 Offset: 0x138A870 VA: 0x138A870
		private void UpdatePressed()
		{
			if(IsPressed())
			{
				if(!Disable && !m_isRepeatDisable && !IsInputOff)
				{
					Debug.Log("RB.UpdatePressed");
					if(Time.realtimeSinceStartup <= m_nextTime)
						return;
					m_nextTime = Time.realtimeSinceStartup + m_repeat;
					PlayNormal();
					if(m_repeatEvent != null)
					{
						m_repeatEvent();
						m_isLongPressed = true;
						return;
					}
				}
			}
			m_updater = UpdateIdel;
		}

		// RVA: 0x138AE34 Offset: 0x138AE34 VA: 0x138AE34 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if(IsEventProcessed && m_repeatEvent != null)
			{
				m_isClick = false;
				m_nextTime = m_interval + Time.realtimeSinceStartup;
				m_updater = UpdatePressed;
			}
			m_isLongPressed = false;
		}

		// RVA: 0x138AF18 Offset: 0x138AF18 VA: 0x138AF18 Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			if(m_isLongPressed)
				return;
			base.OnPointerClick(eventData);
		}

		// // RVA: 0x138AF2C Offset: 0x138AF2C VA: 0x138AF2C
		public void AddOnRepeatCallback(RepeatButton.OnRepeatCallback callback)
		{
			m_repeatEvent += callback;
		}

		// // RVA: 0x138AF30 Offset: 0x138AF30 VA: 0x138AF30
		// public void RemoveOnRepeatCallback(RepeatButton.OnRepeatCallback callback) { }

		// // RVA: 0x138AF34 Offset: 0x138AF34 VA: 0x138AF34
		// public void ClearOnRepeatCallback() { }
	}
}
