using UnityEngine.UI;
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace TMPro
{
	public class TMP_Dropdown : Selectable
	{
		[Serializable]
		public class OptionData
		{
			[SerializeField]
			private string m_Text;
			[SerializeField]
			private Sprite m_Image;
		}

		[Serializable]
		public class OptionDataList
		{
			[SerializeField]
			private List<TMP_Dropdown.OptionData> m_Options;
		}

		[Serializable]
		public class DropdownEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private RectTransform m_Template;
		[SerializeField]
		private TMP_Text m_CaptionText;
		[SerializeField]
		private Image m_CaptionImage;
		[SerializeField]
		private TMP_Text m_ItemText;
		[SerializeField]
		private Image m_ItemImage;
		[SerializeField]
		private int m_Value;
		[SerializeField]
		private OptionDataList m_Options;
		[SerializeField]
		private DropdownEvent m_OnValueChanged;
	}
}
