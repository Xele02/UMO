using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class StayButton : ActionButton
	{
		public delegate void OnStayCallback();

		//[CompilerGeneratedAttribute] // RVA: 0x688EE0 Offset: 0x688EE0 VA: 0x688EE0
		private OnStayCallback m_stayEvent = () =>
			{
				//0x1CCAFC8
				return;
			}; // 0x80
		private float m_interval = 0.4f; // 0x84
		private float m_nextTime; // 0x88
		private Action m_updater; // 0x8C
		private bool m_isLongPressed; // 0x90
		private bool m_isStayDisable; // 0x91

		//public bool IsStayDisable { get; set; } 0x1CCA62C 0x1CCA634

		// RVA: 0x1CCA63C Offset: 0x1CCA63C VA: 0x1CCA63C Slot: 11
		protected override void Start()
		{
			base.Start();
			m_updater = UpdateIdel;
		}

		// RVA: 0x1CCA6D0 Offset: 0x1CCA6D0 VA: 0x1CCA6D0
		private void Update()
		{
			m_updater();
		}

		//// RVA: 0x1CCA6FC Offset: 0x1CCA6FC VA: 0x1CCA6FC
		private void UpdateIdel()
		{
			return;
		}

		//// RVA: 0x1CCA700 Offset: 0x1CCA700 VA: 0x1CCA700
		private void UpdatePressed()
		{
			if(IsPressed())
			{
				if(!Disable && !m_isStayDisable && !IsInputOff)
				{
					Debug.Log("SB.UpdatePressed");
					if(Time.realtimeSinceStartup <= m_nextTime)
						return;
					SetOff();
					PlayNormal();
					m_stayEvent();
					m_isLongPressed = true;
				}
			}
			m_updater = UpdateIdel;
		}

		//// RVA: 0x1CCACE4 Offset: 0x1CCACE4 VA: 0x1CCACE4 Slot: 18
		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if(IsEventProcessed && m_stayEvent != null)
			{
				m_isClick = false;
				m_nextTime = Time.realtimeSinceStartup + m_interval;
				m_updater = UpdatePressed;
			}
			m_isLongPressed = false;
		}

		//// RVA: 0x1CCADC8 Offset: 0x1CCADC8 VA: 0x1CCADC8 Slot: 15
		public override void OnPointerClick(PointerEventData eventData)
		{
			if(m_isLongPressed)
				return;
			base.OnPointerClick(eventData);
		}

		//// RVA: 0x1CCADDC Offset: 0x1CCADDC VA: 0x1CCADDC
		public void AddOnStayCallback(OnStayCallback callback)
		{
			m_stayEvent += callback;
		}

		//// RVA: 0x1CCADE0 Offset: 0x1CCADE0 VA: 0x1CCADE0
		//public void RemoveOnStayCallback(StayButton.OnStayCallback callback) { }

		//// RVA: 0x1CCADE4 Offset: 0x1CCADE4 VA: 0x1CCADE4
		public void ClearOnStayCallback()
		{
			m_stayEvent = null;
		}
	}
}
