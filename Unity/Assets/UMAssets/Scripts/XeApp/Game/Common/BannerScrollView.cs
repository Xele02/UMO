using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class BannerScrollView : SelectScrollView
	{
		public class RepeatTimer
		{
			private float m_wait; // 0x8
			private float m_time; // 0xC

			public Action OnRepeatTiming { get; set; } // 0x10

			// // RVA: 0xE5FAEC Offset: 0xE5FAEC VA: 0xE5FAEC
			public void Update()
			{
				if(m_wait > 0)
				{
					if(m_wait <= m_time)
					{
						m_wait = 0;
						if (OnRepeatTiming != null)
						{
							OnRepeatTiming();
							return;
						}
					}
					else
					{
						m_time += Time.deltaTime;
					}
				}
			}

			// // RVA: 0xE5FC44 Offset: 0xE5FC44 VA: 0xE5FC44
			public void Init(float wait)
			{
				m_wait = wait;
				m_time = 0;
			}
		}

		private RepeatTimer m_repeatTimer = new RepeatTimer(); // 0x12C

		// RVA: 0xE5FA38 Offset: 0xE5FA38 VA: 0xE5FA38 Slot: 48
		protected override void LateUpdate()
		{
			base.LateUpdate();
			if (scrollObjects.Count < 1)
				return;
			m_repeatTimer.Update();
		}

		// RVA: 0xE5FB60 Offset: 0xE5FB60 VA: 0xE5FB60 Slot: 46
		public override void OnDrag(PointerEventData eventData)
		{
			base.OnDrag(eventData);
		}

		// RVA: 0xE5FB68 Offset: 0xE5FB68 VA: 0xE5FB68 Slot: 44
		public override void OnBeginDrag(PointerEventData eventData)
		{
			base.OnBeginDrag(eventData);
		}

		// RVA: 0xE5FB70 Offset: 0xE5FB70 VA: 0xE5FB70 Slot: 45
		public override void OnEndDrag(PointerEventData eventData)
		{
			base.OnEndDrag(eventData);
		}

		// RVA: 0xE5FB78 Offset: 0xE5FB78 VA: 0xE5FB78
		public void SetAutoScroll(float autoScrollWait)
		{
			m_repeatTimer.Init(autoScrollWait);
			m_repeatTimer.OnRepeatTiming = () =>
			{
				//0xE5FCE0
				if (isDrag)
					return;
				SetPosition((index + 1) % scrollObjects.Count, 1);
			};
		}
	}
}
