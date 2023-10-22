using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Text.RegularExpressions;
using System;

namespace XeApp.Game.Menu
{
	public class PopupPlayerSearchRuntime : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_myIdText; // 0x14
		[SerializeField]
		private Text m_friendIdText; // 0x18
		[SerializeField]
		private InputField m_friendIdTextField; // 0x1C
		[SerializeField]
		private Text m_friendIdPlaceholder; // 0x20
		[SerializeField]
		private ActionButton m_copyButton; // 0x24
		[SerializeField]
		private ActionButton m_searchButton; // 0x28
		private Regex m_regex = new Regex("[^0-9]"); // 0x2C

		public Action<string> onClickCopyButton { private get; set; } // 0x30
		public Action<string> onClickSearchButton { private get; set; } // 0x34

		//// RVA: 0x160B154 Offset: 0x160B154 VA: 0x160B154
		public void SetMyId(string myId)
		{
			m_myIdText.text = myId;
		}

		//// RVA: 0x160B190 Offset: 0x160B190 VA: 0x160B190
		public void SetFriendId(string friendId)
		{
			m_friendIdTextField.text = friendId;
		}

		//// RVA: 0x160B1C4 Offset: 0x160B1C4 VA: 0x160B1C4
		public void SetFriendIdPlaceholder(string placeholder)
		{
			m_friendIdPlaceholder.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_friendIdPlaceholder.text = placeholder;
		}

		//// RVA: 0x160B310 Offset: 0x160B310 VA: 0x160B310
		private char OnValidateInput(string text, int charIndex, char addedChar)
		{
			return char.IsNumber(addedChar) ? addedChar : '0';
		}

		//// RVA: 0x160B39C Offset: 0x160B39C VA: 0x160B39C
		private void OnValueChanged(string text)
		{
			m_friendIdTextField.text = m_regex.Replace(text, "");
		}

		//// RVA: 0x160B448 Offset: 0x160B448 VA: 0x160B448
		private void OnEndEdit(string text)
		{
			if(!string.IsNullOrEmpty(text))
			{
				long t;
				if(long.TryParse(text, out t))
				{
					if (t >= 0x80000000)
						t = 0x7fffffff;
					m_friendIdTextField.text = t.ToString();
				}
			}
		}

		// RVA: 0x160B4F4 Offset: 0x160B4F4 VA: 0x160B4F4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_friendIdTextField.onValidateInput = OnValidateInput;
			m_friendIdTextField.onValueChanged.AddListener(OnValueChanged);
			m_friendIdTextField.onEndEdit.AddListener(OnEndEdit);
			m_copyButton.AddOnClickCallback(() =>
			{
				//0x160B838
				if(onClickCopyButton != null)
				{
					onClickCopyButton(m_myIdText.text);
				}
			});
			m_searchButton.AddOnClickCallback(() =>
			{
				//0x160B8D4
				if(onClickSearchButton != null)
				{
					onClickSearchButton(m_friendIdText.text);
				}
			});
			Loaded();
			return true;
		}
	}
}
