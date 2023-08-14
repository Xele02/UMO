using XeSys.Gfx;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class CostumeUpgradeSelectScroller : LayoutLabelScriptBase, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
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
		private float flickStartTime = -1; // 0x64
		private Vector2 flickStartPos = Vector2.zero; // 0x68
		private bool m_enableLimit; // 0x70
		private int m_leftLimitPage; // 0x74
		private int m_rightLimitPage; // 0x78
		private float m_leftOffsetLimit; // 0x7C
		private float m_rightOffsetLimit; // 0x80

		private Action updater { get; set; } // 0x40
		private bool isAutoScroll { get { return updater == UpdateAutoScroll; } } //0x16F90D8
		public SelectionChangedCallback onSelectionChanged { private get; set; } // 0x84
		public ScrollRepeatedCallback onScrollRepeated { private get; set; } // 0x88
		public Action<bool> onScrollStarted { private get; set; } // 0x8C
		public Action<bool> onScrollUpdated { private get; set; } // 0x90
		public Action<bool> onScrollEnded { private get; set; } // 0x94

		//// RVA: 0x16F0864 Offset: 0x16F0864 VA: 0x16F0864
		public void RequestFlow(int pageOffset, float flowSec, Action onEnd)
		{
			onAutoScrollEnd = onEnd;
			scrolled = 0;
			scrollTimer = 0;
			scrollPerSec = m_offsetLength * -pageOffset / flowSec;
			scrollEndLength = m_offsetLength * -pageOffset;
			scrollEndSec = flowSec;
			StartScroll(true);
			updater = UpdateAutoScroll;
		}

		//// RVA: 0x16EBD30 Offset: 0x16EBD30 VA: 0x16EBD30
		public void SetLimit(int leftLimitPage, int rightLimitPage)
		{
			m_enableLimit = true;
			m_leftLimitPage = leftLimitPage;
			m_rightLimitPage = rightLimitPage;
			m_leftOffsetLimit = m_offsetLength * -rightLimitPage;
			m_rightOffsetLimit = m_offsetLength * -leftLimitPage;
		}

		//// RVA: 0x16EBD70 Offset: 0x16EBD70 VA: 0x16EBD70
		public void ClearLimit()
		{
			m_enableLimit = false;
			m_leftLimitPage = 0;
			m_rightLimitPage = 0;
			m_leftOffsetLimit = 0;
			m_rightOffsetLimit = 0;
		}

		//// RVA: 0x16EB8EC Offset: 0x16EB8EC VA: 0x16EB8EC
		public bool CheckOnLeftLimitPage()
		{
			return m_enableLimit ? m_rightOffsetLimit <= m_scrollOffsetX + 0.05f : false;
		}

		//// RVA: 0x16EB924 Offset: 0x16EB924 VA: 0x16EB924
		public bool CheckOnRightLimitPage()
		{
			return m_enableLimit ? m_leftOffsetLimit >= m_scrollOffsetX - 0.05f : false;
		}

		//// RVA: 0x16EED70 Offset: 0x16EED70 VA: 0x16EED70
		public void InputEnable()
		{
			m_inputEnable = true;
		}

		//// RVA: 0x16EED7C Offset: 0x16EED7C VA: 0x16EED7C
		public void InputDisable()
		{
			m_inputEnable = false;
		}

		// RVA: 0x16F9258 Offset: 0x16F9258 VA: 0x16F9258
		private void Update()
		{
			if (updater != null)
				updater();
		}

		// RVA: 0x16F926C Offset: 0x16F926C VA: 0x16F926C
		private void OnApplicationPause(bool pauseStatus)
		{
			if (!pauseStatus)
				return;
			if (m_dragEventData == null)
				return;
			OnEndDrag(m_dragEventData);
		}

		//// RVA: 0x16F9350 Offset: 0x16F9350 VA: 0x16F9350
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0x16F9354 Offset: 0x16F9354 VA: 0x16F9354
		private void UpdateDrag()
		{
			return;
		}

		//// RVA: 0x16F9358 Offset: 0x16F9358 VA: 0x16F9358
		private void UpdateAutoScroll()
		{
			float t = scrollPerSec * TimeWrapper.deltaTime;
			scrolled += t;
			scrollTimer += TimeWrapper.deltaTime;
			if(Mathf.Abs(scrollEndLength) <= Mathf.Abs(scrolled) || scrollEndSec <= scrollTimer)
			{
				EndScroll();
				if (onAutoScrollEnd != null)
					onAutoScrollEnd();
				if (onScrollEnded != null)
					onScrollEnded(false);
				updater = UpdateIdle;
			}
			else
			{
				UpdateScroll(t);
				if (onScrollUpdated != null)
					onScrollUpdated(true);
			}
		}

		//// RVA: 0x16F97CC Offset: 0x16F97CC VA: 0x16F97CC
		//private static int Repeat(ref float value, float min, float max) { }

		//// RVA: 0x16F9198 Offset: 0x16F9198 VA: 0x16F9198
		private void StartScroll(bool isAuto)
		{
			m_scrollOffsetX = 0;
			m_scrollRepeatedX = 0;
			m_savedFrame = 0;
			updater = UpdateDrag;
			if (onScrollStarted != null)
				onScrollStarted(isAuto);
		}

		//// RVA: 0x16F94F4 Offset: 0x16F94F4 VA: 0x16F94F4
		private void UpdateScroll(float deltaX)
		{
			if(m_enableLimit)
			{
				float f = m_scrollOffsetX + deltaX;
				if(deltaX >= 0)
				{
					if (m_rightLimitPage < f)
						deltaX += m_rightOffsetLimit - f;
				}
				else
				{
					if (f < m_leftLimitPage)
						deltaX += m_leftLimitPage - f;
				}
			}
			m_scrollOffsetX += deltaX;
			m_scrollRepeatedX += deltaX;
			int rDelta = 0;
			if (m_scrollRepeatedX < 0)
			{
				do
				{
					m_scrollRepeatedX += m_offsetLength;
					rDelta--;
				} while (m_scrollRepeatedX < 0);
			}
			if(m_offsetLength <= m_scrollRepeatedX)
			{
				do
				{
					m_scrollRepeatedX -= m_offsetLength;
					rDelta++;
				} while (m_offsetLength <= m_scrollRepeatedX);
			}
			int frame = Mathf.RoundToInt(m_scrollRepeatedX / (m_offsetLength / m_scrollMaxFrame));
			m_symbolScroll.GoToLabelFrame("right", frame);
			int b = 0;
			if (m_selectionFlipFrame < frame)
				b = -1;
			if (m_selectionFlipFrame < m_savedFrame)
				b = frame <= m_selectionFlipFrame ? 1 : 0;
			if(b - rDelta != 0)
			{
				if (onSelectionChanged != null)
					onSelectionChanged(b - rDelta);
				CancelFlick();
			}
			if (rDelta != 0 && onScrollRepeated != null)
				onScrollRepeated(rDelta, b < frame);
			m_savedFrame = frame;
		}

		//// RVA: 0x16F96E0 Offset: 0x16F96E0 VA: 0x16F96E0
		private void EndScroll()
		{
			updater = UpdateIdle;
			if(m_selectionFlipFrame < m_savedFrame && onScrollRepeated != null)
			{
				onScrollRepeated(0, false);
			}
			m_scrollOffsetX = 0;
			m_scrollRepeatedX = 0;
			m_savedFrame = 0;
			m_symbolScroll.StartAnim("wait");
		}

		//// RVA: 0x16FA1C0 Offset: 0x16FA1C0 VA: 0x16FA1C0
		//private void StartFlick(Vector2 position) { }

		//// RVA: 0x16FA1E4 Offset: 0x16FA1E4 VA: 0x16FA1E4
		private void EndFlick(Vector2 position)
		{
			if(flickStartTime >= 0)
			{
				Vector2 delta = position - flickStartPos;
				float f = delta.magnitude;
				int a = 0;
				if((Time.realtimeSinceStartup - flickStartTime) < m_flickTime && m_flickLength <= f)
				{
					a = delta.x <= 0 ? -1 : 1;
				}
				if(m_enableLimit)
				{
					a = Mathf.Clamp(a, m_leftLimitPage, m_rightLimitPage);
				}
				if(a != 0)
				{
					if(onSelectionChanged != null)
						onSelectionChanged(a);
					if (onScrollRepeated != null)
						onScrollRepeated(0, false);
				}
			}
		}

		//// RVA: 0x16F9C98 Offset: 0x16F9C98 VA: 0x16F9C98
		private void CancelFlick()
		{
			flickStartTime = -1;
			flickStartPos = Vector2.zero;
		}

		// RVA: 0x16FA398 Offset: 0x16FA398 VA: 0x16FA398 Slot: 6
		public void OnBeginDrag(PointerEventData eventData)
		{
			if(m_inputEnable && !isAutoScroll)
			{
				if(eventData.pointerId == 0)
				{
					m_dragEventData = eventData;
					m_isDragScroll = true;
					StartScroll(false);
					flickStartPos = eventData.pressPosition;
					flickStartTime = Time.realtimeSinceStartup;
				}
			}
		}

		// RVA: 0x16FA480 Offset: 0x16FA480 VA: 0x16FA480 Slot: 7
		public void OnEndDrag(PointerEventData eventData)
		{
			if(m_isDragScroll)
			{
				if(eventData.pointerId == 0)
				{
					EndScroll();
					EndFlick(eventData.position);
					if (onScrollEnded != null)
						onScrollEnded(false);
					m_isDragScroll = false;
					m_dragEventData = null;
				}
			}
		}

		// RVA: 0x16FA56C Offset: 0x16FA56C VA: 0x16FA56C Slot: 8
		public void OnDrag(PointerEventData eventData)
		{
			if(m_isDragScroll)
			{
				if(eventData.pointerId == 0)
				{
					m_dragEventData = eventData;
					UpdateScroll(eventData.delta.x);
					if (onScrollUpdated != null)
						onScrollUpdated(false);
				}
			}
		}

		//// RVA: 0x16FA444 Offset: 0x16FA444 VA: 0x16FA444
		//private bool CheckTouchId(PointerEventData eventData) { }

		// RVA: 0x16FA648 Offset: 0x16FA648 VA: 0x16FA648 Slot: 5
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
