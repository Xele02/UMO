using XeSys.Gfx;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class RaidBossSelectReelScroller : LayoutLabelScriptBase, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
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
		private float m_scrollOffsetY; // 0x34
		private float m_scrollRepeatedY; // 0x38
		private int m_savedFrame; // 0x3C
		private bool m_inputEnable = true; // 0x44
		private bool m_scrollLock; // 0x45
		private bool m_isDragScroll; // 0x46
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
		private int m_bottomLimitPage; // 0x74
		private int m_topLimitPage; // 0x78
		private float m_bottomOffsetLimit; // 0x7C
		private float m_topOffsetLimit; // 0x80

		private Action updater { get; set; } // 0x40
		private bool isAutoScroll { get { return updater == UpdateAutoScroll; } } //0x1464658
		public SelectionChangedCallback onSelectionChanged { private get; set; } // 0x84
		public ScrollRepeatedCallback onScrollRepeated { private get; set; } // 0x88
		public Action<bool> onScrollStarted { private get; set; } // 0x8C
		public Action<bool> onScrollUpdated { private get; set; } // 0x90
		public Action<bool> onScrollEnded { private get; set; } // 0x94

		// // RVA: 0x1461E3C Offset: 0x1461E3C VA: 0x1461E3C
		// public void RequestFlow(int pageOffset, float flowSec, Action onEnd) { }

		// // RVA: 0x1462810 Offset: 0x1462810 VA: 0x1462810
		public void SetLimit(int bottomLimitPage, int topLimitPage)
		{
			m_enableLimit = true;
			m_bottomLimitPage = topLimitPage;
			m_topLimitPage = bottomLimitPage;
			m_bottomOffsetLimit = m_offsetLength * -bottomLimitPage;
			m_topOffsetLimit = m_offsetLength * -topLimitPage;
		}

		// // RVA: 0x1462884 Offset: 0x1462884 VA: 0x1462884
		// public void ClearLimit() { }

		// // RVA: 0x14647D8 Offset: 0x14647D8 VA: 0x14647D8
		// public bool CheckOnTopLimitPage() { }

		// // RVA: 0x1464810 Offset: 0x1464810 VA: 0x1464810
		// public bool CheckOnBottomLimitPage() { }

		// // RVA: 0x1462A60 Offset: 0x1462A60 VA: 0x1462A60
		public void SetLock(bool scrollLock)
		{
			m_scrollLock = scrollLock;
		}

		// RVA: 0x1461F88 Offset: 0x1461F88 VA: 0x1461F88
		public void InputEnable()
		{
			m_inputEnable = true;
		}

		// // RVA: 0x1461FBC Offset: 0x1461FBC VA: 0x1461FBC
		public void InputDisable()
		{
			m_inputEnable = false;
		}

		// RVA: 0x1464848 Offset: 0x1464848 VA: 0x1464848
		private void Update()
		{
			if(updater != null)
				updater();
		}

		// RVA: 0x146485C Offset: 0x146485C VA: 0x146485C
		private void OnApplicationPause(bool pauseStatus)
		{
			if(!pauseStatus)
				return;
			if(m_dragEventData == null)
				return;
			OnEndDrag(m_dragEventData);
		}

		// // RVA: 0x1464940 Offset: 0x1464940 VA: 0x1464940
		private void UpdateIdle()
		{
			return;
		}

		// // RVA: 0x1464944 Offset: 0x1464944 VA: 0x1464944
		private void UpdateDrag()
		{
			return;
		}

		// // RVA: 0x1464948 Offset: 0x1464948 VA: 0x1464948
		private void UpdateAutoScroll()
		{
			float off = TimeWrapper.deltaTime * scrollPerSec;
			scrolled += off;
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
				UpdateScroll(off);
				if(onScrollUpdated != null);
					onScrollUpdated(true);
			}
		}

		// // RVA: 0x1464DD8 Offset: 0x1464DD8 VA: 0x1464DD8
		// private static int Repeat(ref float value, float min, float max) { }

		// // RVA: 0x1464718 Offset: 0x1464718 VA: 0x1464718
		private void StartScroll(bool isAuto)
		{
			m_scrollOffsetY = 0;
			m_scrollRepeatedY = 0;
			m_savedFrame = 0;
			updater = UpdateDrag;
			if(onScrollStarted != null)
				onScrollStarted(isAuto);
		}

		// // RVA: 0x1464AE4 Offset: 0x1464AE4 VA: 0x1464AE4
		private void UpdateScroll(float deltaY)
		{
			float f6 = -deltaY;
			if(m_enableLimit)
			{
				float f7 = m_scrollOffsetY - deltaY;
				float f8;
				bool b;
				if(deltaY <= 0)
				{
					f8 = m_bottomOffsetLimit;
					b = f8 < f7;
				}
				else
				{
					f8 = m_topOffsetLimit;
					b = f7 < f8;
				}
				if(b)
					f6 = f8 - f7 - deltaY;
			}
			int repeatDelta = 0;
			m_scrollRepeatedY += f6;
			m_scrollOffsetY += f6;
			if(m_scrollRepeatedY < 0)
			{
				do
				{
					m_scrollRepeatedY += m_offsetLength;
					repeatDelta--;
				} while(m_scrollRepeatedY < 0);
			}
			if(m_offsetLength < m_scrollRepeatedY)
			{
				do
				{
					m_scrollRepeatedY -= m_offsetLength;
					repeatDelta++;
				} while(m_offsetLength < m_scrollRepeatedY);
			}
			int frame = Mathf.RoundToInt(m_scrollRepeatedY / (m_offsetLength / m_scrollMaxFrame));
			m_symbolScroll.GoToLabelFrame("bottom", frame);
			int u2;
			if(m_selectionFlipFrame < m_savedFrame)
				u2 = -1;
			else
				u2 = frame <= m_selectionFlipFrame ? 1 : 0;
			if(u2 != 0)
			{
				if(onSelectionChanged != null)
					onSelectionChanged(u2 - repeatDelta);
				CancelFlick();
			}
			if(repeatDelta != 0 && onScrollRepeated != null)
			{
				onScrollRepeated(repeatDelta, m_selectionFlipFrame < frame);
			}
			m_savedFrame = frame;
		}

		// // RVA: 0x1464CE4 Offset: 0x1464CE4 VA: 0x1464CE4
		private void EndScroll()
		{
			updater = UpdateIdle;
			if(m_selectionFlipFrame < m_savedFrame && onScrollRepeated != null)
			{
				onScrollRepeated(0, false);
			}
			m_scrollOffsetY = 0;
			m_scrollRepeatedY = 0;
			m_savedFrame = 0;
			m_symbolScroll.StartAnim("wait");
		}

		// // RVA: 0x1464EE4 Offset: 0x1464EE4 VA: 0x1464EE4
		// private void StartFlick(Vector2 position) { }

		// // RVA: 0x1464F08 Offset: 0x1464F08 VA: 0x1464F08
		private void EndFlick(Vector2 position)
		{
			if(flickStartTime >= 0)
			{
				Vector2 d = position - flickStartPos;
				float m = d.magnitude;
				int v = 0;
				if(Time.realtimeSinceStartup - flickStartTime < m_flickTime && m_flickLength < m)
				{
					v = d.y >= 0 ? 1 : -1;
				}
				if(m_enableLimit)
				{
					v = Mathf.Clamp(v, m_topLimitPage, m_bottomLimitPage);
				}
				if(v != 0)
				{
					if(onSelectionChanged != null)
						onSelectionChanged(v);
					if(onScrollRepeated != null)
						onScrollRepeated(0, false);
				}
			}
		}

		// // RVA: 0x1464E40 Offset: 0x1464E40 VA: 0x1464E40
		private void CancelFlick()
		{
			flickStartTime = -1;
			flickStartPos = Vector2.zero;
		}

		// RVA: 0x14650CC Offset: 0x14650CC VA: 0x14650CC Slot: 6
		public void OnBeginDrag(PointerEventData eventData)
		{
			if(!m_scrollLock && m_inputEnable && !isAutoScroll)
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

		// RVA: 0x14651C4 Offset: 0x14651C4 VA: 0x14651C4 Slot: 7
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

		// RVA: 0x14652B0 Offset: 0x14652B0 VA: 0x14652B0 Slot: 8
		public void OnDrag(PointerEventData eventData)
		{
			if(m_isDragScroll)
			{
				if(CheckTouchId(eventData))
				{
					m_dragEventData = eventData;
					UpdateScroll(eventData.delta.y);
					if(onScrollUpdated != null)
						onScrollUpdated(false);
				}
			}
		}

		// // RVA: 0x1465188 Offset: 0x1465188 VA: 0x1465188
		private bool CheckTouchId(PointerEventData eventData)
		{
			return eventData.pointerId == 0 || eventData.pointerId == -1;
		}

		// RVA: 0x146538C Offset: 0x146538C VA: 0x146538C Slot: 5
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
