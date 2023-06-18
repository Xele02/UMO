using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class UGUIRepeatButton : UGUIButton
	{
		public delegate void OnRepeatCallback();

		//[CompilerGeneratedAttribute] // RVA: 0x68CDA0 Offset: 0x68CDA0 VA: 0x68CDA0
		public OnRepeatCallback m_repeatEvent = () => { /*0x1CDB590*/ return;  }; // 0x38
		private float m_interval = 0.4f; // 0x3C
		private float m_repeat = 0.1f; // 0x40
		private float m_nextTime; // 0x44
		private Action m_updater; // 0x48
		private bool m_isLongPressed; // 0x4C
		private bool m_isRepeatDisable; // 0x4D

		//public bool IsRepeatDisable { get; set; } 0x1CDABF0 0x1CDABF8

		// RVA: 0x1CDAC00 Offset: 0x1CDAC00 VA: 0x1CDAC00 Slot: 11
		protected override void Start()
		{
			base.Start();
			m_updater = UpdateIdel;
		}

		// RVA: 0x1CDAC94 Offset: 0x1CDAC94 VA: 0x1CDAC94
		private void Update()
		{
			m_updater();
		}

		//// RVA: 0x1CDACC0 Offset: 0x1CDACC0 VA: 0x1CDACC0
		private void UpdateIdel()
		{
			return;
		}

		//// RVA: 0x1CDACC4 Offset: 0x1CDACC4 VA: 0x1CDACC4
		private void UpdatePressed()
		{
			if(IsPressed())
			{
				if(!Disable && !m_isRepeatDisable)
				{
					if(!IsInputOff)
					{
						Debug.Log("RB.UpdatePressed");
						if (Time.realtimeSinceStartup <= m_nextTime)
							return;
						m_nextTime = Time.realtimeSinceStartup + m_repeat;
						m_repeatEvent();
						m_isLongPressed = true;
						return;
					}
				}
			}
			m_updater = UpdateIdel;
		}

		// RVA: 0x1CDB274 Offset: 0x1CDB274 VA: 0x1CDB274 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if(IsEventProcessed && m_repeatEvent != null)
			{
				m_isClick = false;
				m_nextTime = Time.realtimeSinceStartup + m_interval;
				m_updater = UpdatePressed;
			}
			m_isLongPressed = false;
		}

		// RVA: 0x1CDB358 Offset: 0x1CDB358 VA: 0x1CDB358 Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			if (m_isLongPressed)
				return;
			base.OnPointerClick(eventData);
		}

		//// RVA: 0x1CDB36C Offset: 0x1CDB36C VA: 0x1CDB36C
		public void AddOnRepeatCallback(UGUIRepeatButton.OnRepeatCallback callback)
		{
			m_repeatEvent += callback;
		}

		//// RVA: 0x1CDB370 Offset: 0x1CDB370 VA: 0x1CDB370
		//public void RemoveOnRepeatCallback(UGUIRepeatButton.OnRepeatCallback callback) { }

		//// RVA: 0x1CDB374 Offset: 0x1CDB374 VA: 0x1CDB374
		//public void ClearOnRepeatCallback() { }
	}
}
