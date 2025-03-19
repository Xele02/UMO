using XeSys.Gfx;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDScroller : LayoutLabelScriptBase, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
	{
		public delegate void SelectionChangedCallback(int offset);
		public delegate void ScrollRepeatedCallback(int repeatDelta, bool isSelectionFlipped);

		private const float OffsetEpsilon = 0.05f;
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
		private LayoutSymbolData m_symbolScroll; // 0x30
		private float m_scrollOffsetX; // 0x34
		private float m_scrollRepeatedX; // 0x38
		private int m_savedFrame; // 0x3C
		private bool m_inputEnable = true; // 0x44
		private bool m_isDragScroll; // 0x45
		private PointerEventData m_dragEventData; // 0x48
		private float scrolled; // 0x4C
		private float scrollTimer; // 0x50
		private float scrollPerSec; // 0x54
		private float scrollEndLength; // 0x58
		private float scrollEndSec; // 0x5C
		private Action onAutoScrollEnd; // 0x60
		private float flickStartTime = -1.0f; // 0x64
		private Vector2 flickStartPos = Vector2.zero; // 0x68
		private bool m_enableLimit; // 0x70
		private int m_leftLimitPage; // 0x74
		private int m_rightLimitPage; // 0x78
		private float m_leftOffsetLimit; // 0x7C
		private float m_rightOffsetLimit; // 0x80

		private Action updater { get; set; } // 0x40
		private bool isAutoScroll { get { return updater == UpdateAutoScroll; } } //0x166E650
		public SelectionChangedCallback onSelectionChanged { private get; set; } // 0x84
		public ScrollRepeatedCallback onScrollRepeated { private get; set; } // 0x88
		public Action<bool> onScrollStarted { private get; set; } // 0x8C
		public Action<bool> onScrollUpdated { private get; set; } // 0x90
		public Action<bool> onScrollEnded { private get; set; } // 0x94

		// // RVA: 0x166E738 Offset: 0x166E738 VA: 0x166E738
		public void RequestFlow(int pageOffset, float flowSec, Action onEnd)
		{
			onAutoScrollEnd = onEnd;
			scrolled = 0;
			scrollTimer = 0;
			scrollEndLength = m_offsetLength * -pageOffset;
			scrollPerSec = scrollEndLength / flowSec;
			scrollEndSec = flowSec;
			StartScroll(true);
			updater = UpdateAutoScroll;
		}

		// // RVA: 0x166E8D4 Offset: 0x166E8D4 VA: 0x166E8D4
		public void SetLimit(int leftLimitPage, int rightLimitPage)
		{
			m_enableLimit = true;
			m_leftLimitPage = leftLimitPage;
			m_rightLimitPage = rightLimitPage;
			m_leftOffsetLimit = m_offsetLength * -rightLimitPage;
			m_rightOffsetLimit = m_offsetLength * -leftLimitPage;
		}

		// // RVA: 0x166E914 Offset: 0x166E914 VA: 0x166E914
		public void ClearLimit()
		{
			m_enableLimit = false;
			m_leftLimitPage = 0;
			m_rightLimitPage = 0;
			m_leftOffsetLimit = 0;
			m_rightOffsetLimit = 0;
		}

		// // RVA: 0x166E92C Offset: 0x166E92C VA: 0x166E92C
		public bool CheckOnLeftLimitPage()
		{
			if(m_enableLimit)
				return m_rightOffsetLimit <= m_scrollOffsetX + 0.05f;
			return false;
		}

		// // RVA: 0x166E964 Offset: 0x166E964 VA: 0x166E964
		public bool CheckOnRightLimitPage()
		{
			if(m_enableLimit)
				return m_scrollOffsetX - 0.05f <= m_leftOffsetLimit;
			return false;
		}

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
		private void UpdateIdle()
		{
			return;
		}

		// // RVA: 0x166EAB0 Offset: 0x166EAB0 VA: 0x166EAB0
		private void UpdateDrag()
		{
			return;
		}

		// // RVA: 0x166EAB4 Offset: 0x166EAB4 VA: 0x166EAB4
		private void UpdateAutoScroll()
		{
			float f = scrollPerSec * TimeWrapper.deltaTime;
			scrolled += f;
			scrollTimer += TimeWrapper.deltaTime;
			if(Mathf.Abs(scrollEndLength) <= Mathf.Abs(scrolled) || scrollEndSec <= scrollTimer)
			{
				EndScroll();
				if(onAutoScrollEnd != null)
					onAutoScrollEnd();
				if(onScrollEnded != null)
					onScrollEnded(true);
				updater = UpdateIdle;
			}
			else
			{
				UpdateScroll(f);
				if(onScrollUpdated != null)
					onScrollUpdated(true);
			}
		}

		// // RVA: 0x166EF28 Offset: 0x166EF28 VA: 0x166EF28
		// private static int Repeat(ref float value, float min, float max) { }

		// // RVA: 0x166E814 Offset: 0x166E814 VA: 0x166E814
		private void StartScroll(bool isAuto)
		{
			m_scrollOffsetX = 0;
			m_scrollRepeatedX = 0;
			m_savedFrame = 0;
			updater = UpdateDrag;
			if(onScrollStarted != null)
				onScrollStarted(isAuto);
		}

		// // RVA: 0x166EC50 Offset: 0x166EC50 VA: 0x166EC50
		private void UpdateScroll(float deltaX) 
		{
			if(m_enableLimit)
			{
				if(deltaX >= 0)
				{
					if(m_rightOffsetLimit < m_scrollOffsetX + deltaX)
						deltaX += m_rightOffsetLimit - (m_scrollOffsetX + deltaX);
				}
				else
				{
					if(m_scrollOffsetX + deltaX < m_leftOffsetLimit)
						deltaX += m_leftOffsetLimit - (m_scrollOffsetX + deltaX);
				}
			}
			m_scrollOffsetX += deltaX;
			m_scrollRepeatedX += deltaX;
			int repeatDelta = 0;
			if(m_scrollRepeatedX < 0)
			{
				repeatDelta = 0;
				do
				{
					m_scrollRepeatedX += m_offsetLength;
					repeatDelta--;
				} while(m_scrollRepeatedX < 0);
			}
			if(m_offsetLength < m_scrollRepeatedX)
			{
				do
				{
					m_scrollRepeatedX -= m_offsetLength;
					repeatDelta++;
				} while(m_offsetLength < m_scrollRepeatedX);
			}
			int frame = Mathf.RoundToInt(m_scrollRepeatedX / (m_offsetLength / m_scrollMaxFrame));
			m_symbolScroll.GoToLabelFrame("right", frame);
			int v = 0;
			if(m_selectionFlipFrame < frame)
				v = -1;
			if(m_selectionFlipFrame < m_savedFrame)
				v = frame <= m_selectionFlipFrame ? 1 : 0;
			if(v - repeatDelta != 0)
			{
				if(onSelectionChanged != null)
					onSelectionChanged(v - repeatDelta);
				CancelFlick();
			}
			if(repeatDelta != 0 && onScrollRepeated != null)
			{
				onScrollRepeated(repeatDelta, m_selectionFlipFrame < frame);
			}
			m_savedFrame = frame;
		}

		// // RVA: 0x166EE3C Offset: 0x166EE3C VA: 0x166EE3C
		private void EndScroll()
		{
			updater = UpdateIdle;
			if(m_selectionFlipFrame < m_savedFrame && onScrollRepeated != null)
				onScrollRepeated(0, false);
			m_scrollOffsetX = 0;
			m_scrollRepeatedX = 0;
			m_savedFrame = 0;
			m_symbolScroll.StartAnim("wait");
		}

		// // RVA: 0x166F91C Offset: 0x166F91C VA: 0x166F91C
		// private void StartFlick(Vector2 position) { }

		// // RVA: 0x166F940 Offset: 0x166F940 VA: 0x166F940
		private void EndFlick(Vector2 position)
		{
			if(flickStartTime > 0)
			{
				int value = 0;
				Vector2 dist = position - flickStartPos;
				if(Time.realtimeSinceStartup - flickStartTime < m_flickTime && m_flickLength <= dist.magnitude)
				{
					value = 1;
					if(dist.x >= 0)
						value = -1;
				}
				if(m_enableLimit)
				{
					value = Mathf.Clamp(value, m_leftLimitPage, m_rightLimitPage);
				}
				if(value != 0)
				{
					if(onSelectionChanged != null)
						onSelectionChanged(value);
					if(onScrollRepeated != null)
						onScrollRepeated(0, false);
				}
			}
		}

		// // RVA: 0x166F3F4 Offset: 0x166F3F4 VA: 0x166F3F4
		private void CancelFlick()
		{
			flickStartTime = -1;
			flickStartPos = Vector2.zero;
		}

		// // RVA: 0x166FAF4 Offset: 0x166FAF4 VA: 0x166FAF4 Slot: 6
		public void OnBeginDrag(PointerEventData eventData)
		{
			if(m_inputEnable && !isAutoScroll)
			{
				if(CheckTouchId(eventData))
				{
					m_dragEventData = eventData;
					m_isDragScroll = true;
					StartScroll(false);
					flickStartPos = eventData.pressPosition;
					flickStartTime = Time.realtimeSinceStartup;
				}
			}
		}

		// // RVA: 0x166FBDC Offset: 0x166FBDC VA: 0x166FBDC Slot: 7
		public void OnEndDrag(PointerEventData eventData)
		{
			if(m_isDragScroll)
			{
				if(CheckTouchId(eventData))
				{
					EndScroll();
					EndFlick(eventData.position);
					if(onScrollEnded != null)
						onScrollEnded(false);
					m_isDragScroll = false;
					m_dragEventData = null;
				}
			}
		}

		// // RVA: 0x166FCC8 Offset: 0x166FCC8 VA: 0x166FCC8 Slot: 8
		public void OnDrag(PointerEventData eventData)
		{
			if(m_isDragScroll)
			{
				if(CheckTouchId(eventData))
				{
					m_dragEventData = eventData;
					UpdateScroll(eventData.delta.x);
					if(onScrollUpdated != null)
						onScrollUpdated(false);
				}
			}
		}

		// // RVA: 0x166FBA0 Offset: 0x166FBA0 VA: 0x166FBA0
		private bool CheckTouchId(PointerEventData eventData)
		{
			return eventData.pointerId == 0 || eventData.pointerId == -1;
		}

		// // RVA: 0x166FDA4 Offset: 0x166FDA4 VA: 0x166FDA4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolScroll = CreateSymbol("m_scroll", layout);
			updater = UpdateIdle;
			Loaded();
			return true;
		}
	}
}
