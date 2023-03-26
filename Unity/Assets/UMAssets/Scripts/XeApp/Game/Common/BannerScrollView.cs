using System;
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
			// public void Update() { }

			// // RVA: 0xE5FC44 Offset: 0xE5FC44 VA: 0xE5FC44
			// public void Init(float wait) { }
		}

		private RepeatTimer m_repeatTimer = new RepeatTimer(); // 0x12C

		// RVA: 0xE5FA38 Offset: 0xE5FA38 VA: 0xE5FA38 Slot: 48
		protected override void LateUpdate()
		{
			TodoLogger.Log(0, "BannerScrollView.LateUpdate");
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
		// public void SetAutoScroll(float autoScrollWait) { }

		// [CompilerGeneratedAttribute] // RVA: 0x73D414 Offset: 0x73D414 VA: 0x73D414
		// // RVA: 0xE5FCE0 Offset: 0xE5FCE0 VA: 0xE5FCE0
		// private void <SetAutoScroll>b__5_0() { }
	}
}
