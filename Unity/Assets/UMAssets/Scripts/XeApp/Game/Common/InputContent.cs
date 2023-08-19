using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using System.Text;
using XeSys;

namespace XeApp.Game.Common
{
	public class InputContent : UIBehaviour, IPopupContent
	{
		private const float MultiLineTextOffsetY = -7;
		[SerializeField]
		private InputField m_input; // 0xC
		[SerializeField]
		private Text m_descriptionText; // 0x10
		[SerializeField]
		private Text m_notesText; // 0x14
		private StringBuilder m_strBuilder = new StringBuilder(); // 0x18
		private int _characterLimit; // 0x1C
		private bool disableRegex = false;

		public string Text { get; private set; } // 0x20
		public Transform Parent { get { return null; } } //0x1100964

		// RVA: 0x1100970 Offset: 0x1100970 VA: 0x1100970 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			InputPopupSetting s = setting as InputPopupSetting;
			m_input.characterLimit = 0;
			m_input.text = s.InputText;
			disableRegex = s.DisableRegex;
			_characterLimit = s.CharacterLimit;
			if (s.InputLineCount < 2)
			{
				m_input.lineType = InputField.LineType.SingleLine;
				m_input.contentType = s.ContentType;
				m_input.textComponent.alignment = TextAnchor.MiddleCenter;
				m_input.textComponent.rectTransform.anchoredPosition = new Vector2(m_input.textComponent.rectTransform.anchoredPosition.x, 0);
			}
			else
			{
				m_input.lineType = InputField.LineType.MultiLineSubmit;
				m_input.contentType = s.ContentType;
				m_input.textComponent.alignment = TextAnchor.UpperLeft;
				m_input.textComponent.rectTransform.anchoredPosition = new Vector2(m_input.textComponent.rectTransform.anchoredPosition.x, -7);
			}
			Text t = m_input.placeholder.GetComponent<Text>();
			t.alignment = m_input.textComponent.alignment;
			ModifyRectTransform(m_input.GetComponent<RectTransform>(), (int)(m_input.textComponent.fontSize + m_input.textComponent.fontSize * 0.7f), s.InputLineCount);
			m_descriptionText.text = s.Description;
			ModifyTextAreaHeight(m_descriptionText);
			m_notesText.text = s.Notes;
			ModifyTextAreaHeight(m_notesText);
			m_input.onEndEdit.AddListener((string value) =>
			{
				//0x1101ABC
				Text = m_input.text;
				m_input.textComponent.text = Text;
				ValidateText(control);
			});
			m_input.onValueChanged.AddListener(OnChangeContent);
			ModifyCharacterLimit(m_input, _characterLimit);
			Text = m_input.text;
			ValidateText(control);
		}

		//// RVA: 0x110161C Offset: 0x110161C VA: 0x110161C
		private void OnChangeContent(string value)
		{
			m_strBuilder.Set(value);
			m_strBuilder.Replace('<', '＜');
			m_strBuilder.Replace('>', '＞');
			m_strBuilder.Replace(JpStringLiterals.StringLiteral_14024, "");
			m_strBuilder.Replace(JpStringLiterals.StringLiteral_5812, "");
			if(!disableRegex)
			{
				GameMessageManager.ReplaceInvalidFont(ref m_strBuilder, m_strBuilder.ToString());
			}
			m_input.onValueChanged.RemoveListener(OnChangeContent);
			m_input.text = m_strBuilder.ToString();
			m_input.onValueChanged.AddListener(OnChangeContent);
		}

		//// RVA: 0x1101204 Offset: 0x1101204 VA: 0x1101204
		public void ModifyTextAreaHeight(Text text)
		{
			int lineCount = 1;
			for(int i = 0; i < text.text.Length; i++)
			{
				if (text.text[i] == '\n')
					lineCount++;
			}
			ModifyRectTransform(text.rectTransform, text.fontSize, lineCount);
		}

		//// RVA: 0x1101184 Offset: 0x1101184 VA: 0x1101184
		public void ModifyRectTransform(RectTransform rt, int fontSize, int lineCount)
		{
			rt.sizeDelta = new Vector2(rt.sizeDelta.x, lineCount * fontSize);
		}

		//// RVA: 0x11012EC Offset: 0x11012EC VA: 0x11012EC
		private void ModifyCharacterLimit(InputField input, int characterLimit)
		{
			m_strBuilder.Set(input.text);
			if (m_strBuilder.Length < characterLimit)
				return;
			m_strBuilder.Remove(characterLimit, m_strBuilder.Length - characterLimit);
			m_input.onValueChanged.RemoveListener(OnChangeContent);
			m_input.text = m_strBuilder.ToString();
			m_input.onValueChanged.AddListener(OnChangeContent);
		}

		// RVA: 0x1101938 Offset: 0x1101938 VA: 0x1101938 Slot: 19
		public void Show()
		{
			return;
		}

		// RVA: 0x110193C Offset: 0x110193C VA: 0x110193C Slot: 20
		public void Hide()
		{
			return;
		}

		// RVA: 0x1101940 Offset: 0x1101940 VA: 0x1101940 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1101948 Offset: 0x1101948 VA: 0x1101948 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1101950 Offset: 0x1101950 VA: 0x1101950 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0x1101564 Offset: 0x1101564 VA: 0x1101564
		public void ValidateText(PopupWindowControl control)
		{
			PopupButton b = control.FindButton(PopupButton.ButtonLabel.Ok);
			if(Text.Length > 0 && !IsWhiteSpace(Text))
			{
				b.SetOff();
			}
			else
			{
				b.Disable = true;
			}
		}

		//// RVA: 0x1101954 Offset: 0x1101954 VA: 0x1101954
		private bool IsWhiteSpace(string str)
		{
			for(int i = 0; i < str.Length; i++)
			{
				if (!char.IsWhiteSpace(str[i]))
					return false;
			}
			return true;
		}
	}
}
