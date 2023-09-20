using System;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

namespace XeApp
{
	public class DecorationScrollController : DecorationControllerBase
	{
		private TouchInfo m_beginTouchInfo; // 0x14
		private Vector2 m_prevTouchPostion; // 0x18
		private Rect m_screenRect; // 0x20
		private Rect m_scrollRect; // 0x30
		private Action m_update; // 0x44

		public Camera m_decorationCamera { get; private set; } // 0x40
		public bool IsFollowTouch { get; set; } // 0x48
		public Vector2 DeltaPosition { get; private set; } // 0x4C
		public override bool Active { protected get { return base.Active; } set { base.Active = value; m_update = ScrollTouchWait; } } //0xBB145C 0xBB1464

		// RVA: 0xBB1500 Offset: 0xBB1500 VA: 0xBB1500
		public DecorationScrollController(List<ControlData> controlDataList, DecorationScrollControllerArgs args) : base(controlDataList, args)
		{
			IsFollowTouch = true;
			m_screenRect = args.m_screenRect;
			m_scrollRect = args.m_scrollRect;
			m_decorationCamera = args.m_decorationCamera;
			m_update = ScrollTouchWait;
			m_beginTouchInfo = InputManager.Instance.GetBeganTouchInfo(0);
		}

		//// RVA: 0xBB166C Offset: 0xBB166C VA: 0xBB166C Slot: 6
		//public override void Update() { }

		//// RVA: 0xBB1670 Offset: 0xBB1670 VA: 0xBB1670
		public bool Translate(Vector3 translate)
		{
			bool b = false;
			foreach(var k in m_controlDataList)
			{
				Vector2 p = k.transform.localPosition + translate;
				float f = 0;
				if(SystemManager.isLongScreenDevice)
				{
					if (SystemManager.HasSafeArea)
						f = (SystemManager.longScreenSizeWithSafeArea.y - SystemManager.longScreenReferenceResolution.y) * 0.5f;
				}
				Limit(ref p.x, m_scrollRect.min.x, m_scrollRect.max.x, m_scrollRect.width, m_screenRect.width, k.scaler.scaleFactor, 0);
				Limit(ref p.y, m_scrollRect.min.y, -(m_scrollRect.height - m_scrollRect.max.y), m_scrollRect.height, m_screenRect.height, k.scaler.scaleFactor, f);
				if(!b)
				{
					DeltaPosition = Vector2.zero;
				}
				k.transform.localPosition = p;
				b = true;
			}
			return true;
		}

		//// RVA: 0xBB1C98 Offset: 0xBB1C98 VA: 0xBB1C98
		public void Limit(ref float position, float bgMinPos, float bgMaxPos, float limitSize, float scrennSize, float scale, float screenOffset)
		{
			float f = (limitSize - scrennSize / scale) * 0.5f;
			float f2 = limitSize * 0.5f - Mathf.Abs(bgMinPos);
			if(f >= 0)
			{
				f2 += Mathf.Abs(f) + screenOffset;
				float f3 = -Mathf.Abs(f) - (limitSize * 0.5f - Mathf.Abs(bgMaxPos)) + screenOffset;
				f = position;
				if (position < f3)
				{
					position = f3;
					f = f3;
				}
				if (f2 <= f)
					position = f2;
			}
			else
			{
				position = f2 + f + screenOffset;
			}
		}

		//// RVA: 0xBB1DDC Offset: 0xBB1DDC VA: 0xBB1DDC
		private void ScrollTouchWait()
		{
			if(InputManager.Instance.touchCount == 1)
			{
				if(InputManager.Instance.GetCurrentTouchInfo(0).time - InputManager.Instance.GetBeganTouchInfo(0).time >= 0)
				{
					m_prevTouchPostion = InputManager.Instance.GetCurrentTouchInfo(0).GetSceneInnerPosition();
					m_update = Scroll;
				}
			}
		}

		//// RVA: 0xBB1FC8 Offset: 0xBB1FC8 VA: 0xBB1FC8
		private void Scroll()
		{
			if(InputManager.Instance.touchCount == 1)
			{
				Vector2 p = InputManager.Instance.GetCurrentTouchInfo(0).GetSceneInnerPosition();
				Vector3 p2;
				if(!IsFollowTouch)
				{
					Vector3 p4 = m_decorationCamera.ViewportToScreenPoint(p);
					Vector3 p3 = m_decorationCamera.ViewportToScreenPoint(new Vector3(0.0225f, 0.03f, 0));
					p2 = p;
					if (p4.x <= 0.075f)
						p2.x += p3.x;
					else if (0.925f <= p4.x)
						p2.x -= p3.x;
					if (p4.y <= 0.1f)
						p2.y += p3.y;
					else if (0.9f <= p4.y)
						p2.y -= p3.y;
				}
				else
				{
					p2 = p - m_prevTouchPostion;
				}
				Translate(p2);
				m_prevTouchPostion = p;
			}
			else
			{
				m_update = ScrollEnd;
			}
		}

		//// RVA: 0xBB23C8 Offset: 0xBB23C8 VA: 0xBB23C8
		private void ScrollEnd()
		{
			m_update = ScrollTouchWait;
		}
	}
}
