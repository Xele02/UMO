using UnityEngine.UI;
using System;
using UnityEngine.Events;
using UnityEngine;

namespace TMPro
{
	public class TMP_InputField : Selectable
	{
		[Serializable]
		public class SubmitEvent : UnityEvent<string>
		{
		}

		[Serializable]
		public class SelectionEvent : UnityEvent<string>
		{
		}

		[Serializable]
		public class TextSelectionEvent : UnityEvent<string, int, int>
		{
		}

		[Serializable]
		public class OnChangeEvent : UnityEvent<string>
		{
		}

		[Serializable]
		public class TouchScreenKeyboardEvent : UnityEvent<TouchScreenKeyboard.Status>
		{
		}

		public enum ContentType
		{
			Standard = 0,
			Autocorrected = 1,
			IntegerNumber = 2,
			DecimalNumber = 3,
			Alphanumeric = 4,
			Name = 5,
			EmailAddress = 6,
			Password = 7,
			Pin = 8,
			Custom = 9,
		}

		public enum InputType
		{
			Standard = 0,
			AutoCorrect = 1,
			Password = 2,
		}

		public enum LineType
		{
			SingleLine = 0,
			MultiLineSubmit = 1,
			MultiLineNewline = 2,
		}

		public enum CharacterValidation
		{
			None = 0,
			Digit = 1,
			Integer = 2,
			Decimal = 3,
			Alphanumeric = 4,
			Name = 5,
			Regex = 6,
			EmailAddress = 7,
			CustomValidator = 8,
		}

		[SerializeField]
		protected RectTransform m_TextViewport;
		[SerializeField]
		protected TMP_Text m_TextComponent;
		[SerializeField]
		protected Graphic m_Placeholder;
		[SerializeField]
		protected Scrollbar m_VerticalScrollbar;
		[SerializeField]
		protected TMP_ScrollbarEventHandler m_VerticalScrollbarEventHandler;
		[SerializeField]
		protected float m_ScrollSensitivity;
		[SerializeField]
		private ContentType m_ContentType;
		[SerializeField]
		private InputType m_InputType;
		[SerializeField]
		private char m_AsteriskChar;
		[SerializeField]
		private TouchScreenKeyboardType m_KeyboardType;
		[SerializeField]
		private LineType m_LineType;
		[SerializeField]
		private bool m_HideMobileInput;
		[SerializeField]
		private bool m_HideSoftKeyboard;
		[SerializeField]
		private CharacterValidation m_CharacterValidation;
		[SerializeField]
		private string m_RegexValue;
		[SerializeField]
		private float m_GlobalPointSize;
		[SerializeField]
		private int m_CharacterLimit;
		[SerializeField]
		private SubmitEvent m_OnEndEdit;
		[SerializeField]
		private SubmitEvent m_OnSubmit;
		[SerializeField]
		private SelectionEvent m_OnSelect;
		[SerializeField]
		private SelectionEvent m_OnDeselect;
		[SerializeField]
		private TextSelectionEvent m_OnTextSelection;
		[SerializeField]
		private TextSelectionEvent m_OnEndTextSelection;
		[SerializeField]
		private OnChangeEvent m_OnValueChanged;
		[SerializeField]
		private TouchScreenKeyboardEvent m_OnTouchScreenKeyboardStatusChanged;
		[SerializeField]
		private Color m_CaretColor;
		[SerializeField]
		private bool m_CustomCaretColor;
		[SerializeField]
		private Color m_SelectionColor;
		[SerializeField]
		protected string m_Text;
		[SerializeField]
		private float m_CaretBlinkRate;
		[SerializeField]
		private int m_CaretWidth;
		[SerializeField]
		private bool m_ReadOnly;
		[SerializeField]
		private bool m_RichText;
		[SerializeField]
		protected TMP_FontAsset m_GlobalFontAsset;
		[SerializeField]
		protected bool m_OnFocusSelectAll;
		[SerializeField]
		protected bool m_ResetOnDeActivation;
		[SerializeField]
		private bool m_RestoreOriginalTextOnEscape;
		[SerializeField]
		protected bool m_isRichTextEditingAllowed;
		[SerializeField]
		protected int m_LineLimit;
		[SerializeField]
		protected TMP_InputValidator m_InputValidator;
	}
}
