using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System;
using XeSys;

namespace XeApp.Game.Common
{
	public class ScrollText : LayoutUGUIScriptBase
	{
		private enum State
		{
			In = 0,
			Wait = 1,
			Out = 2,
		}

		[SerializeField]
		private Text m_text; // 0x14
		//[HeaderAttribute] // RVA: 0x688CC4 Offset: 0x688CC4 VA: 0x688CC4
		[SerializeField]
		private float m_startDelay = 1; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x688D3C Offset: 0x688D3C VA: 0x688D3C
		private float m_speed = 20; // 0x1C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x688D94 Offset: 0x688D94 VA: 0x688D94
		private float m_distance = 20; // 0x20
		//[HeaderAttribute] // RVA: 0x688DF8 Offset: 0x688DF8 VA: 0x688DF8
		[SerializeField]
		private bool m_stop; // 0x24
		[SerializeField]
		private Text m_copyText; // 0x28
		[SerializeField]
		private Vector2 m_basePos = Vector2.zero; // 0x2C
		[SerializeField]
		private Vector2 m_baseSize = Vector2.zero; // 0x34
		private ScrollText.State m_state = State.Wait; // 0x3C
		private float m_time; // 0x40

		//// RVA: 0x138E85C Offset: 0x138E85C VA: 0x138E85C
		public void StartScroll()
		{
			m_stop = false;
		}

		//// RVA: 0x138E868 Offset: 0x138E868 VA: 0x138E868
		public void StopScroll()
		{
			m_stop = true;
		}

		//// RVA: 0x138E874 Offset: 0x138E874 VA: 0x138E874
		public void ResetScroll()
		{
			m_text.rectTransform.anchoredPosition = m_basePos;
			Vector2 size = new Vector2(m_text.preferredWidth, m_baseSize.y);
			if (size.x < m_baseSize.x)
				size.x = m_baseSize.x;
			m_text.rectTransform.sizeDelta = size;
			m_state = State.Wait;
			m_time = 0;
		}

		//// RVA: 0x138E984 Offset: 0x138E984 VA: 0x138E984
		private void Start()
		{
			m_text.RegisterDirtyLayoutCallback(this.SetCopyText);
			m_basePos = m_text.rectTransform.anchoredPosition;
			m_baseSize = m_text.rectTransform.sizeDelta;
		}

		//// RVA: 0x138EAB4 Offset: 0x138EAB4 VA: 0x138EAB4
		private void OnDestroy()
		{
			m_text.UnregisterDirtyLayoutCallback(this.SetCopyText);
		}

		//// RVA: 0x138EB5C Offset: 0x138EB5C VA: 0x138EB5C
		private void LateUpdate()
		{
			if (string.IsNullOrEmpty(m_text.text))
				return;
			Vector2 size = new Vector2(m_text.preferredWidth, m_baseSize.y);
			if(m_baseSize.x <= size.x)
			{
				if (m_stop)
					return;
				if(m_state == State.Out)
				{
					Vector2 pos = m_text.rectTransform.anchoredPosition;
					if (!Single.IsNaN(m_text.rectTransform.anchoredPosition.x) && !Single.IsNaN(m_text.rectTransform.anchoredPosition.y))
					{
						;
					}
					else
					{
						pos.x = m_basePos.x;
						pos.y = m_basePos.y;
					}
					float x = pos.x - TimeWrapper.deltaTime * m_speed;
					if(x < (m_basePos.x - size.x))
					{
						m_state = State.In;
						pos.y = m_basePos.y;
						x = m_distance + m_basePos.x;
					}
					m_text.rectTransform.sizeDelta = size;
					m_text.rectTransform.anchoredPosition = new Vector2(x, pos.y);
				}
				else if(m_state == State.Wait)
				{
					if(m_time < m_startDelay)
					{
						m_time += TimeWrapper.deltaTime;
					}
					else
					{
						m_time = 0;
						m_state = State.Out;
					}
					m_text.rectTransform.sizeDelta = size;
				}
				else
				{
					Vector2 pos = m_text.rectTransform.anchoredPosition;
					if (!Single.IsNaN(m_text.rectTransform.anchoredPosition.x) && !Single.IsNaN(m_text.rectTransform.anchoredPosition.y))
					{
						;
					}
					else
					{
						pos.x = m_basePos.x;
						pos.y = m_basePos.y;
					}
					float x = pos.x - TimeWrapper.deltaTime * m_speed;
					if (x < (m_basePos.x))
					{
						m_state = State.Wait;
						pos.y = m_basePos.y;
						x = m_basePos.x;
					}
					m_text.rectTransform.anchoredPosition = new Vector2(x, pos.y);
					m_text.rectTransform.sizeDelta = size;
				}
			}
			else
			{
				m_text.rectTransform.anchoredPosition = m_basePos;
				m_text.rectTransform.sizeDelta = m_baseSize;
			}
		}

		//// RVA: 0x138EF04 Offset: 0x138EF04 VA: 0x138EF04
		public void SetCopyText()
		{
			if(m_copyText.text != m_text.text)
			{
				m_copyText.text = m_text.text;
			}
			m_copyText.rectTransform.anchoredPosition = new Vector2(m_text.rectTransform.sizeDelta.x + m_distance, 0);
			m_copyText.rectTransform.sizeDelta = m_text.rectTransform.sizeDelta;
		}

		//// RVA: 0x138F0E0 Offset: 0x138F0E0 VA: 0x138F0E0
		//public void CopyText(Text from, Text to) { }
	}
}
