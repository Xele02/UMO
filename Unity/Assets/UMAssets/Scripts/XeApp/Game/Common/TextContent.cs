using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class TextContent : UIBehaviour, IPopupContent
	{
		private Text m_text; // 0xC
		private bool m_scrollable; // 0x10
		private const int FontSize = 24;

		public Text Text { get {
				if (m_text == null)
					m_text = GetComponent<Text>();
				return m_text;
			} } //0x1CCE6C0
		public Transform Parent { get { return null; } } //0x1CCE734

		//// RVA: 0x1CCE73C Offset: 0x1CCE73C VA: 0x1CCE73C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			TextPopupSetting textSetting = setting as TextPopupSetting;
			GetComponent<RectTransform>().sizeDelta = size;
			Text.fontSize = 24;
			Text.alignment = textSetting.Alignment;
			Text.color = SystemTextColor.GetNormalColor();
			SetText(textSetting.Text);
			m_scrollable = textSetting.Scrollable;
			if(m_scrollable)
			{
				int numLine = 0;
				for(int i = 0; i < textSetting.Text.Length; i++)
				{
					if (textSetting.Text[i] == '\n')
						numLine++;
				}
				RectTransform r = GetComponent<RectTransform>();
				Vector2 s = r.sizeDelta;
				float h = m_text.lineSpacing * m_text.font.fontSize * m_text.fontSize * numLine;
				if (s.y < h)
				{
					r.anchorMax = new Vector2(0.5f, 1.0f);
					r.anchorMin = new Vector2(0.5f, 1.0f);
					r.pivot = new Vector2(0.5f, 1.0f);
					r.sizeDelta = new Vector2(s.x, h);
					r.anchoredPosition = Vector2.zero;
				}
			}
		}

		//// RVA: 0x1CCEC38 Offset: 0x1CCEC38 VA: 0x1CCEC38
		public void SetText(string text)
		{
			Text.text = text;
		}

		//// RVA: 0x1CCEC80 Offset: 0x1CCEC80 VA: 0x1CCEC80 Slot: 18
		public bool IsScrollable()
		{
			return m_scrollable;
		}

		// RVA: 0x1CCEC88 Offset: 0x1CCEC88 VA: 0x1CCEC88 Slot: 19
		public void Show()
		{
			return;
		}

		// RVA: 0x1CCEC8C Offset: 0x1CCEC8C VA: 0x1CCEC8C Slot: 20
		public void Hide()
		{
			return;
		}

		//// RVA: 0x1CCEC90 Offset: 0x1CCEC90 VA: 0x1CCEC90 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1CCEC98 Offset: 0x1CCEC98 VA: 0x1CCEC98 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
