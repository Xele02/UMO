using XeSys.Gfx;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDScroller : LayoutLabelScriptBase, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
	{
		public delegate void SelectionChangedCallback(int offset);
		public delegate void ScrollRepeatedCallback(int repeatDelta, bool isSelectionFlipped);

		// private const float OffsetEpsilon = 0,05;
		[SerializeField]
		private RectTransform m_hitRect; // 0x18
		[SerializeField]
		private int m_scrollMaxFrame; // 0x1C
		[SerializeField]
		private float m_offsetLength; // 0x20
		[SerializeField]
		private int m_selectionFlipFrame; // 0x24
		[SerializeField]
		private float m_flickTime; // 0x28
		[SerializeField]
		private float m_flickLength; // 0x2C
		// private LayoutSymbolData m_symbolScroll; // 0x30
		// private float m_scrollOffsetX; // 0x34
		// private float m_scrollRepeatedX; // 0x38
		// private int m_savedFrame; // 0x3C
		private bool m_inputEnable = true; // 0x44
		// private bool m_isDragScroll; // 0x45
		private PointerEventData m_dragEventData; // 0x48
		// private float scrolled; // 0x4C
		// private float scrollTimer; // 0x50
		// private float scrollPerSec; // 0x54
		// private float scrollEndLength; // 0x58
		// private float scrollEndSec; // 0x5C
		// private Action onAutoScrollEnd; // 0x60
		// private float flickStartTime = -1.0f; // 0x64
		// private Vector2 flickStartPos = Vector2.zero; // 0x68
		// private bool m_enableLimit; // 0x70
		// private int m_leftLimitPage; // 0x74
		// private int m_rightLimitPage; // 0x78
		// private float m_leftOffsetLimit; // 0x7C
		// private float m_rightOffsetLimit; // 0x80

		private Action updater { get; set; } // 0x40
		// private bool isAutoScroll { get; } 0x166E650
		public MusicSelectCDScroller.SelectionChangedCallback onSelectionChanged { private get; set; } // 0x84
		public MusicSelectCDScroller.ScrollRepeatedCallback onScrollRepeated { private get; set; } // 0x88
		public Action<bool> onScrollStarted { private get; set; } // 0x8C
		public Action<bool> onScrollUpdated { private get; set; } // 0x90
		public Action<bool> onScrollEnded { private get; set; } // 0x94

		// // RVA: 0x166E738 Offset: 0x166E738 VA: 0x166E738
		// public void RequestFlow(int pageOffset, float flowSec, Action onEnd) { }

		// // RVA: 0x166E8D4 Offset: 0x166E8D4 VA: 0x166E8D4
		// public void SetLimit(int leftLimitPage, int rightLimitPage) { }

		// // RVA: 0x166E914 Offset: 0x166E914 VA: 0x166E914
		// public void ClearLimit() { }

		// // RVA: 0x166E92C Offset: 0x166E92C VA: 0x166E92C
		// public bool CheckOnLeftLimitPage() { }

		// // RVA: 0x166E964 Offset: 0x166E964 VA: 0x166E964
		// public bool CheckOnRightLimitPage() { }

		// // RVA: 0x166E99C Offset: 0x166E99C VA: 0x166E99C
		public void InputEnable()
		{
			m_inputEnable = true;
		}

		// // RVA: 0x166E9A8 Offset: 0x166E9A8 VA: 0x166E9A8
		public void InputDisable()
		{
			m_inputEnable = false;
		}

		// // RVA: 0x166E9B4 Offset: 0x166E9B4 VA: 0x166E9B4
		private void Update()
		{
			if(updater != null)
				updater();
		}

		// // RVA: 0x166E9C8 Offset: 0x166E9C8 VA: 0x166E9C8
		private void OnApplicationPause(bool pauseStatus)
		{
			if(!pauseStatus)
				return;
			if(m_dragEventData == null)
				return;
			OnEndDrag(m_dragEventData);
		}

		// // RVA: 0x166EAAC Offset: 0x166EAAC VA: 0x166EAAC
		// private void UpdateIdle() { }

		// // RVA: 0x166EAB0 Offset: 0x166EAB0 VA: 0x166EAB0
		// private void UpdateDrag() { }

		// // RVA: 0x166EAB4 Offset: 0x166EAB4 VA: 0x166EAB4
		// private void UpdateAutoScroll() { }

		// // RVA: 0x166EF28 Offset: 0x166EF28 VA: 0x166EF28
		// private static int Repeat(ref float value, float min, float max) { }

		// // RVA: 0x166E814 Offset: 0x166E814 VA: 0x166E814
		// private void StartScroll(bool isAuto) { }

		// // RVA: 0x166EC50 Offset: 0x166EC50 VA: 0x166EC50
		// private void UpdateScroll(float deltaX) { }

		// // RVA: 0x166EE3C Offset: 0x166EE3C VA: 0x166EE3C
		// private void EndScroll() { }

		// // RVA: 0x166F91C Offset: 0x166F91C VA: 0x166F91C
		// private void StartFlick(Vector2 position) { }

		// // RVA: 0x166F940 Offset: 0x166F940 VA: 0x166F940
		// private void EndFlick(Vector2 position) { }

		// // RVA: 0x166F3F4 Offset: 0x166F3F4 VA: 0x166F3F4
		// private void CancelFlick() { }

		// // RVA: 0x166FAF4 Offset: 0x166FAF4 VA: 0x166FAF4 Slot: 6
		public void OnBeginDrag(PointerEventData eventData)
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectCDScroller OnBeginDrag");
		}

		// // RVA: 0x166FBDC Offset: 0x166FBDC VA: 0x166FBDC Slot: 7
		public void OnEndDrag(PointerEventData eventData)
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectCDScroller OnEndDrag");
		}

		// // RVA: 0x166FCC8 Offset: 0x166FCC8 VA: 0x166FCC8 Slot: 8
		public void OnDrag(PointerEventData eventData)
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "MusicSelectCDScroller OnDrag");
		}

		// // RVA: 0x166FBA0 Offset: 0x166FBA0 VA: 0x166FBA0
		// private bool CheckTouchId(PointerEventData eventData) { }

		// // RVA: 0x166FDA4 Offset: 0x166FDA4 VA: 0x166FDA4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			TodoLogger.LogError(TodoLogger.OldMusicSelect, "InitializeFromLayout MusicSelectCDScroller");
			return true;
		}
	}
}
