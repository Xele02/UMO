using System.Collections.Generic;
using UnityEngine;

namespace XeSys.Gfx
{
	public class ScrollText : TextView
	{
		public enum EMode
		{
			auto = 0,
			manual = 1,
		}

		public enum EScrollType
		{
			normal = 0,
			start_end_stop = 1,
		}

		public enum EState
		{
			wait = 0,
			scroll = 1,
		}

		private enum EStartEndWaitStep
		{
			start_wait = 0,
			scroll = 1,
			end_wait = 2,
			toStart = 3,
		}

		private ScrollText.EMode m_mode; // 0xCC
		private ScrollText.EScrollType m_ScrollType; // 0xD0
		private ScrollText.EState m_state; // 0xD4
		private float m_WaitTime = 2.5f; // 0xD8
		private float m_WaitCount; // 0xDC
		private ScrollText.EStartEndWaitStep m_SEWaitStep; // 0xE0
		private bool m_IsAutoScroll = true; // 0xE4
		private float m_AutoScrollSpeedX = 1.0f; // 0xE8
		private float m_AutoScrollSpeedY = 0.25f; // 0xEC
		private bool m_IsXScroll = true; // 0xF0
		private float m_scrollX; // 0xF4
		private float m_scrollY; // 0xF8
		private float m_TextWidth; // 0xFC
		private float m_WrapTextWidth; // 0x100
		private float m_WrapTextHeight; // 0x104

		//public ScrollText.EMode Mode { get; set; } 0x1F1182C 0x1F11834
		//public ScrollText.EScrollType ScrollType { get; set; } 0x1F1183C 0x1F11844
		//public ScrollText.EState State { get; set; } 0x1F1184C 0x1F11854
		//public float WaitTime { get; set; } 0x1F1185C 0x1F11864
		//public bool IsAutoScroll { get; set; } 0x1F1186C 0x1F11874
		//public float AutoScrollSpeedX { get; set; } 0x1F1187C 0x1F11884
		//public float AutoScrollSpeedY { get; set; } 0x1F1188C 0x1F11894
		//public bool IsXScroll { get; set; } 0x1F1189C 0x1F118A4
		//public float scrollX { get; set; } 0x1F118AC 0x1F118B4
		//public float scrollY { get; set; } 0x1F118BC 0x1F118C4

		// RVA: 0x1F118CC Offset: 0x1F118CC VA: 0x1F118CC
		public ScrollText()
		{
			m_IsXScroll = true;
			m_IsAutoScroll = true;
			WordWrap = false;
		}

		// RVA: 0x1F11990 Offset: 0x1F11990 VA: 0x1F11990
		public void StartScroll()
		{
			m_state = EState.scroll;
		}

		// RVA: 0x1F1199C Offset: 0x1F1199C VA: 0x1F1199C
		//public bool IsScroll() { }

		// RVA: 0x1F119BC Offset: 0x1F119BC VA: 0x1F119BC
		private float GetOffsetX()
		{
			if(TextAlignH == EAlignH.right)
			{
				return Width - m_TextWidth;
			}
			else if(TextAlignH == EAlignH.center)
			{
				return (Width - m_TextWidth) * 0.5f;
			}
			else
			{
				return 0;
			}
		}

		// RVA: 0x1F11A30 Offset: 0x1F11A30 VA: 0x1F11A30
		public void NomalScroll(float fontScale, float fontScaleInv)
		{
			if(!m_IsXScroll)
			{
				if(m_WrapTextHeight <= Height)
				{
					m_state = EState.wait;
					m_scrollY = 0;
					return;
				}
				m_scrollY -= m_AutoScrollSpeedY;
				if (-m_WrapTextHeight <= m_scrollY)
					return;
				m_scrollY = Height * fontScaleInv;
			}
			else
			{
				if(m_TextWidth <= Width)
				{
					m_state = EState.wait;
					m_scrollX = 0;
					return;
				}
				m_scrollX -= m_AutoScrollSpeedX;
				if (-m_TextWidth * fontScaleInv <= m_scrollX - GetOffsetX())
					return;
				m_scrollX = Width * fontScaleInv;
			}
			if (m_mode == EMode.manual)
				m_state = EState.wait;
		}

		// RVA: 0x1F11B54 Offset: 0x1F11B54 VA: 0x1F11B54
		public void StartEndStopScroll(float fontScale, float fontScaleInv)
		{
			switch(m_SEWaitStep)
			{
				case EStartEndWaitStep.start_wait:
					m_WaitCount += TimeWrapper.deltaTime;
					if (m_WaitCount < m_WaitTime)
						return;
					m_WaitCount = 0;
					m_SEWaitStep = EStartEndWaitStep.scroll;
					break;
				case EStartEndWaitStep.scroll:
					if(!m_IsXScroll)
					{
						if(m_WrapTextHeight <= Height)
						{
							m_SEWaitStep = EStartEndWaitStep.toStart;
							m_scrollY = 0;
							return;
						}
						m_scrollY -= m_AutoScrollSpeedY;
						if (!(m_scrollY < (0 - (m_WrapTextHeight - Height * fontScaleInv))))
							return;
					}
					else
					{
						if(m_TextWidth <= Width)
						{
							m_SEWaitStep = EStartEndWaitStep.toStart;
							m_scrollX = 0;
							return;
						}
						m_scrollX -= m_AutoScrollSpeedX;
						if (!((m_scrollX - GetOffsetX()) < (0 - (m_TextWidth * fontScaleInv - m_WrapTextWidth))))
							return;
					}
					m_SEWaitStep = EStartEndWaitStep.end_wait;
					break;
				case EStartEndWaitStep.end_wait:
					m_WaitCount += TimeWrapper.deltaTime;
					if (m_WaitCount < m_WaitTime)
						return;
					m_WaitCount = 0;
					m_SEWaitStep = EStartEndWaitStep.toStart;
					break;
				case EStartEndWaitStep.toStart:
					if(!m_IsXScroll)
					{
						m_scrollY = 0;
					}
					else
					{
						m_scrollX = 0;
					}
					if (m_mode == EMode.manual)
						m_state = EState.wait;
					m_SEWaitStep = EStartEndWaitStep.start_wait;
					break;
				default:
					return;
			}
		}

		// RVA: 0x1F11D1C Offset: 0x1F11D1C VA: 0x1F11D1C
		public void AutoScroll()
		{
			m_ContentWork.text = m_Text;
			Vector2 size = m_Style.CalcSize(m_ContentWork);
			float fontScale = (TextSize * 1.0f / m_fontSize);
			float invFontScale = 1.0f / fontScale;
			m_TextWidth = fontScale * size.x;
			m_WrapTextWidth = invFontScale * Width;
			m_WrapTextHeight = m_Style.CalcHeight(m_ContentWork, m_WrapTextWidth);
			if((m_mode != EMode.manual || m_state != EState.wait) && m_IsAutoScroll)
			{
				if (m_ScrollType == EScrollType.start_end_stop)
					StartEndStopScroll(fontScale, invFontScale);
				else
					NomalScroll(fontScale, invFontScale);
			}
		}

		// RVA: 0x1F11E6C Offset: 0x1F11E6C VA: 0x1F11E6C Slot: 7
		public override void Update(Matrix23 parentMat, Color parentCol)
		{
			if(enabled)
			{
				AutoScroll();
			}
			base.Update(parentMat, parentCol);
		}

		// RVA: 0x1F11F14 Offset: 0x1F11F14 VA: 0x1F11F14 Slot: 10
		public override void CopyTo(ViewBase view)
		{
			base.CopyTo(view);
			ScrollText st = view as ScrollText;
			st.m_IsAutoScroll = m_IsAutoScroll;
			st.m_AutoScrollSpeedX = m_AutoScrollSpeedX;
			st.m_AutoScrollSpeedY = m_AutoScrollSpeedY;
			st.m_IsXScroll = m_IsXScroll;
			st.m_scrollX = m_scrollX;
			st.m_scrollY = m_scrollY;
		}

		// RVA: 0x1F120A4 Offset: 0x1F120A4 VA: 0x1F120A4 Slot: 11
		public override ViewBase DeepClone()
		{
			ScrollText st = new ScrollText();
			CopyTo(st);
			return st;
		}

		// RVA: 0x1F12128 Offset: 0x1F12128 VA: 0x1F12128 Slot: 15
		//public override void Serialize(List<SerializableView> list, int parent) { }
	}
}
