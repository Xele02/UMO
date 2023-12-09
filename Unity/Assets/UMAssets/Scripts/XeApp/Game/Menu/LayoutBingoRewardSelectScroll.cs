using XeSys.Gfx;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutBingoRewardSelectScroll : LayoutUGUIScriptBase, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
	{
		public delegate void SelectionChangedCallback(int offset);

		public delegate void ScrollRepeatedCallback(int repeatDelta, bool isSelectionFlipped);

		private const float OffsetEpsilon = 0.05f;
		[SerializeField]
		private float m_offsetLength; // 0x14
		[SerializeField]
		private int m_selectionFlipFrame; // 0x18
		[SerializeField]
		private float m_flickTime; // 0x1C
		[SerializeField]
		private float m_flickLength; // 0x20
		[SerializeField]
		private RectTransform m_hitRect; // 0x24
		private AbsoluteLayout ScrollAnim; // 0x28
		private float RightMaxFrame; // 0x2C
		private float RightMinFrame; // 0x30
		private float LeftMaxFrame; // 0x34
		private float LeftMinFrame; // 0x38
		private float WaitFrame; // 0x3C
		private float m_scrollOffsetX; // 0x40
		private float m_scrollRepeatedX; // 0x44
		private int m_savedFrame; // 0x48
		private bool m_inputEnable = true; // 0x50
		private bool m_isDragScroll; // 0x51
		private PointerEventData m_dragEventData; // 0x54
		private float scrolled; // 0x58
		private float scrollTimer; // 0x5C
		private float scrollPerSec; // 0x60
		private float scrollEndLength; // 0x64
		private float scrollEndSec; // 0x68
		private Action onAutoScrollEnd; // 0x6C
		private float flickStartTime = -1; // 0x70
		private Vector2 flickStartPos = Vector2.zero; // 0x74
		private bool m_enableLimit; // 0x7C
		private int m_leftLimitPage; // 0x80
		private int m_rightLimitPage; // 0x84
		private float m_leftOffsetLimit; // 0x88
		private float m_rightOffsetLimit; // 0x8C

		private Action updater { get; set; } // 0x4C
		private bool isAutoScroll { get { return updater == UpdateAutoScroll; } } //0x14C9B54
		public SelectionChangedCallback onSelectionChanged { private get; set; } // 0x90
		public ScrollRepeatedCallback onScrollRepeated { private get; set; } // 0x94
		public Action<bool> onScrollStarted { private get; set; } // 0x98
		public Action<bool> onScrollUpdated { private get; set; } // 0x9C
		public Action<bool> onScrollEnded { private get; set; } // 0xA0

		// RVA: 0x14C8FA4 Offset: 0x14C8FA4 VA: 0x14C8FA4
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

		//// RVA: 0x14C9CD4 Offset: 0x14C9CD4 VA: 0x14C9CD4
		//public void SetLimit(int leftLimitPage, int rightLimitPage) { }

		//// RVA: 0x14C9D14 Offset: 0x14C9D14 VA: 0x14C9D14
		//public void ClearLimit() { }

		//// RVA: 0x14C9D2C Offset: 0x14C9D2C VA: 0x14C9D2C
		//public bool CheckOnLeftLimitPage() { }

		//// RVA: 0x14C9D64 Offset: 0x14C9D64 VA: 0x14C9D64
		//public bool CheckOnRightLimitPage() { }

		//// RVA: 0x14C7FE0 Offset: 0x14C7FE0 VA: 0x14C7FE0
		public void InputEnable()
		{
			m_inputEnable = true;
		}

		//// RVA: 0x14C7FAC Offset: 0x14C7FAC VA: 0x14C7FAC
		public void InputDisable()
		{
			m_inputEnable = false;
		}

		// RVA: 0x14C9D9C Offset: 0x14C9D9C VA: 0x14C9D9C
		private void Update()
		{
			if (updater != null)
				updater();
		}

		// RVA: 0x14C9DB0 Offset: 0x14C9DB0 VA: 0x14C9DB0
		private void OnApplicationPause(bool pauseStatus)
		{
			if (!pauseStatus)
				return;
			if (m_dragEventData == null)
				return;
			OnEndDrag(m_dragEventData);
		}

		//// RVA: 0x14C9E94 Offset: 0x14C9E94 VA: 0x14C9E94
		private void UpdateIdle()
		{
			return;
		}

		//// RVA: 0x14C9E98 Offset: 0x14C9E98 VA: 0x14C9E98
		private void UpdateDrag()
		{
			return;
		}

		//// RVA: 0x14C9E9C Offset: 0x14C9E9C VA: 0x14C9E9C
		private void UpdateAutoScroll()
		{
			scrolled += scrollPerSec * TimeWrapper.deltaTime;
			scrollTimer += TimeWrapper.deltaTime;
			if(Mathf.Abs(scrollEndLength) <= Mathf.Abs(scrolled) ||
				scrollEndSec <= scrollTimer)
			{
				EndScroll();
				if (onAutoScrollEnd != null)
					onAutoScrollEnd();
				if (onScrollEnded != null)
					onScrollEnded(true);
				updater = UpdateIdle;
			}
			else
			{
				UpdateScroll(scrolled);
				if (onScrollUpdated != null)
					onScrollUpdated(true);
			}
		}

		//// RVA: 0x14CA2D0 Offset: 0x14CA2D0 VA: 0x14CA2D0
		//private static int Repeat(ref float value, float min, float max) { }

		//// RVA: 0x14C9C14 Offset: 0x14C9C14 VA: 0x14C9C14
		private void StartScroll(bool isAuto)
		{
			m_scrollOffsetX = 0;
			m_scrollRepeatedX = 0;
			m_savedFrame = 0;
			updater = UpdateDrag;
			if (onScrollStarted != null)
				onScrollStarted(isAuto);
		}

		//// RVA: 0x14CA038 Offset: 0x14CA038 VA: 0x14CA038
		private void UpdateScroll(float deltaX)
		{
			if(m_enableLimit)
			{
				float f = m_scrollOffsetX + deltaX;
				if(deltaX >= 0)
				{
					if (m_rightOffsetLimit < f)
						deltaX = m_rightOffsetLimit - f + deltaX;
				}
				else
				{
					if (f < m_leftOffsetLimit)
						deltaX = m_leftOffsetLimit - f + deltaX;
				}
			}
			m_scrollOffsetX = deltaX + m_scrollOffsetX;
			m_scrollRepeatedX = deltaX + m_scrollRepeatedX;
			int repeatDelta = 0;
			if (m_scrollRepeatedX < 0)
			{
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
				} while (m_offsetLength < m_scrollRepeatedX);
			}
			int a2 = Mathf.RoundToInt(m_scrollRepeatedX / (m_offsetLength / RightMaxFrame));
			SetScrollFrame(RightMinFrame + a2);
			int f2 = 0;
			if (m_selectionFlipFrame < a2)
				f2 = -1;
			if (m_selectionFlipFrame < m_savedFrame)
				f2 = a2 <= m_selectionFlipFrame ? 1 : 0;
			if(f2 - repeatDelta != 0)
			{
				if (onSelectionChanged != null)
					onSelectionChanged(f2 - repeatDelta);
				CancelFlick();
			}
			if(repeatDelta != 0 && onScrollRepeated != null)
			{
				onScrollRepeated(repeatDelta, m_selectionFlipFrame < a2);
			}
			m_savedFrame = a2;
		}

		//// RVA: 0x14CA208 Offset: 0x14CA208 VA: 0x14CA208
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
			SetScrollFrame(WaitFrame);
		}

		//// RVA: 0x14CAD08 Offset: 0x14CAD08 VA: 0x14CAD08
		//private void StartFlick(Vector2 position) { }

		//// RVA: 0x14CAD2C Offset: 0x14CAD2C VA: 0x14CAD2C
		private void EndFlick(Vector2 position)
		{
			if(flickStartTime >= 0)
			{
				Vector2 diff = position - flickStartPos;
				int v = 0;
				if(Time.realtimeSinceStartup - flickStartTime < m_flickTime && m_flickLength <= diff.magnitude)
				{
					v = 1;
					if (diff.x >= 0)
						v = -1;
				}
				if(m_enableLimit)
				{
					v = Mathf.Clamp(v, m_leftLimitPage, m_rightLimitPage);
				}
				if(v != 0)
				{
					if (onSelectionChanged != null)
						onSelectionChanged(v);
					if (onScrollRepeated != null)
						onScrollRepeated(0, false);
				}
			}
		}

		//// RVA: 0x14CA7E0 Offset: 0x14CA7E0 VA: 0x14CA7E0
		private void CancelFlick()
		{
			flickStartTime = -1;
			flickStartPos = Vector2.zero;
		}

		//// RVA: 0x14CAEE0 Offset: 0x14CAEE0 VA: 0x14CAEE0
		//public void initialize() { }

		// RVA: 0x14CAEE8 Offset: 0x14CAEE8 VA: 0x14CAEE8 Slot: 6
		public void OnBeginDrag(PointerEventData eventData)
		{
			if(m_inputEnable && !isAutoScroll)
			{
				if (CheckTouchId(eventData))
				{
					m_dragEventData = eventData;
					m_isDragScroll = true;
					StartScroll(false);
					flickStartPos = eventData.pressPosition;
					flickStartTime = Time.realtimeSinceStartup;
				}
			}
		}

		// RVA: 0x14CAFD0 Offset: 0x14CAFD0 VA: 0x14CAFD0 Slot: 7
		public void OnEndDrag(PointerEventData eventData)
		{
			if(m_isDragScroll)
			{
				if (CheckTouchId(eventData))
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

		// RVA: 0x14CB0BC Offset: 0x14CB0BC VA: 0x14CB0BC Slot: 8
		public void OnDrag(PointerEventData eventData)
		{
			if(m_isDragScroll)
			{
				if(CheckTouchId(eventData))
				{
					m_dragEventData = eventData;
					UpdateScroll(eventData.delta.x);
					if (onScrollUpdated != null)
						onScrollUpdated(false);
				}
			}
		}

		//// RVA: 0x14CAF94 Offset: 0x14CAF94 VA: 0x14CAF94
		private bool CheckTouchId(PointerEventData eventData)
		{
			return
#if UNITY_ANDROID
				eventData.pointerId == 0
#else
				eventData.pointerId == -1 || eventData.pointerId == 0
#endif
			;
		}

		//// RVA: 0x14CA338 Offset: 0x14CA338 VA: 0x14CA338
		private void SetScrollFrame(float frame)
		{
			ScrollAnim.StartSiblingAnimGoStop((int)frame, (int)frame);
		}

		// RVA: 0x14CB198 Offset: 0x14CB198 VA: 0x14CB198 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			ScrollAnim = layout.FindViewByExId("sw_sdel_bingo_swipe_anim_sw_sel_bingo_frame_01") as AbsoluteLayout;
			RightMaxFrame = ScrollAnim.FrameAnimation.SearchLabelFrame("st_act_01");
			RightMinFrame = ScrollAnim.FrameAnimation.SearchLabelFrame("go_act_01");
			LeftMaxFrame = ScrollAnim.FrameAnimation.SearchLabelFrame("st_act_02");
			LeftMinFrame = ScrollAnim.FrameAnimation.SearchLabelFrame("go_act_02");
			WaitFrame = ScrollAnim.FrameAnimation.SearchLabelFrame("st_wait");
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
