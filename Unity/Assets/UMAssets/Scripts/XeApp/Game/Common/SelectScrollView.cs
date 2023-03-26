using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class SelectScrollView : ScrollRect
	{
		public bool isSingleTouch; // 0xF0
		private bool isEnableTouch; // 0xF1
		private Coroutine m_coroutine; // 0xF4
		public AnimationCurve curve; // 0xF8
		public int m_itemCount; // 0xFC
		public float selectVelocity; // 0x100
		public Vector2 itemSize; // 0x104
		public Vector2 spacing; // 0x10C

		public List<SelectScrollViewContent> scrollObjects { get; private set; } // 0x114
		public int index { get; private set; } // 0x118
		public bool isDrag { get; private set; } // 0x11C
		public Action<int> OnChangeItem { private get; set; } // 0x120
		public Action<int> OnChangeEndItem { private get; set; } // 0x124
		public Action<bool> OnSwipe { private get; set; } // 0x128

		// // RVA: 0x13900D0 Offset: 0x13900D0 VA: 0x13900D0
		// public void SetItemCount(int count) { }

		// // RVA: 0x13900D8 Offset: 0x13900D8 VA: 0x13900D8 Slot: 61
		// public virtual void AddScrollObject(SelectScrollViewContent obj) { }

		// // RVA: 0x13901AC Offset: 0x13901AC VA: 0x13901AC Slot: 62
		// public virtual void RemoveScrollObject(SelectScrollViewContent obj) { }

		// // RVA: 0x1390284 Offset: 0x1390284 VA: 0x1390284 Slot: 63
		// public virtual void ClearScrollObject() { }

		// // RVA: 0x13903C0 Offset: 0x13903C0 VA: 0x13903C0
		// public void SetPosition(SelectScrollViewContent content, float animTime = 0) { }

		// // RVA: 0x13904EC Offset: 0x13904EC VA: 0x13904EC Slot: 64
		// public virtual void SetPosition(int pos, float animTime = 0) { }

		// [IteratorStateMachineAttribute] // RVA: 0x73D2AC Offset: 0x73D2AC VA: 0x73D2AC
		// // RVA: 0x1390688 Offset: 0x1390688 VA: 0x1390688
		// private IEnumerator Co_SetPosition(int pos, float animTime) { }

		// // RVA: 0x1390774 Offset: 0x1390774 VA: 0x1390774
		// public bool IsEnableTouchId(PointerEventData eventData) { }

		// RVA: 0x13907B0 Offset: 0x13907B0 VA: 0x13907B0 Slot: 4
		protected override void Awake()
		{
			TodoLogger.Log(0, "Awake()");
		}

		// RVA: 0x1390AA0 Offset: 0x1390AA0 VA: 0x1390AA0 Slot: 6
		protected override void Start()
		{
			TodoLogger.Log(0, "Start()");
		}

		// RVA: 0x1390CB0 Offset: 0x1390CB0 VA: 0x1390CB0 Slot: 48
		protected override void LateUpdate()
		{
			TodoLogger.Log(0, "LateUpdate()");
		}

		// RVA: 0x1391018 Offset: 0x1391018 VA: 0x1391018 Slot: 42
		public override void OnScroll(PointerEventData eventData)
		{
			TodoLogger.Log(0, "OnScroll()");
		}

		// RVA: 0x139102C Offset: 0x139102C VA: 0x139102C Slot: 46
		public override void OnDrag(PointerEventData eventData)
		{
			TodoLogger.Log(0, "OnDrag()");
		}

		// RVA: 0x1391040 Offset: 0x1391040 VA: 0x1391040 Slot: 44
		public override void OnBeginDrag(PointerEventData eventData)
		{
			TodoLogger.Log(0, "OnBeginDrag()");
		}

		// RVA: 0x1391124 Offset: 0x1391124 VA: 0x1391124 Slot: 45
		public override void OnEndDrag(PointerEventData eventData)
		{
			TodoLogger.Log(0, "OnEndDrag()");
		}

		// RVA: 0x1391584 Offset: 0x1391584 VA: 0x1391584
		public SelectScrollView()
		{
			TodoLogger.Log(0, "SelectScrollView()");
		}
	}
}
