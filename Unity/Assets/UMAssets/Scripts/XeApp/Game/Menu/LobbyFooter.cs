using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game;
using System;
using XeSys;
using System.Text;

namespace XeApp.Game.Menu
{
	public class LobbyFooter : LayoutUGUIScriptBase
	{
		public enum FooterButtonAnimType
		{
			Main = 0,
			BattleLog = 1,
			Age = 2,
			Live = 3,
			DecoChat = 4,
		}

		private const int MessgeLength = 40;
		//[HeaderAttribute] // RVA: 0x6710B8 Offset: 0x6710B8 VA: 0x6710B8
		[SerializeField]
		private ActionButton m_sendButton; // 0x14
		//[HeaderAttribute] // RVA: 0x671108 Offset: 0x671108 VA: 0x671108
		[SerializeField]
		private ActionButton m_stampButton; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x671160 Offset: 0x671160 VA: 0x671160
		private ActionButton m_memberButton; // 0x1C
		//[HeaderAttribute] // RVA: 0x6711B0 Offset: 0x6711B0 VA: 0x6711B0
		[SerializeField]
		private InputField m_textTextField; // 0x20
		//[HeaderAttribute] // RVA: 0x671208 Offset: 0x671208 VA: 0x671208
		[SerializeField]
		private RectTransform InputFieldPos; // 0x24
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x671264 Offset: 0x671264 VA: 0x671264
		private Text AttentionText; // 0x28
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6712B8 Offset: 0x6712B8 VA: 0x6712B8
		private Text m_DisplayInputText; // 0x2C
		//[HeaderAttribute] // RVA: 0x67132C Offset: 0x67132C VA: 0x67132C
		[SerializeField]
		private CustomScreenKeyboard m_keyBoard; // 0x30
		private AbsoluteLayout m_footerBaseAnim; // 0x34
		private AbsoluteLayout m_footerButtonSwitch; // 0x38
		private bool IsEnableSendButton = true; // 0x3C
		private string ChangeText = ""; // 0x40
		private string PreText = ""; // 0x44
		private bool IsLoaded; // 0x48

		public bool IsKeyBoardOpen { get { return m_keyBoard.IsOpenKeyboard; } private set { return; } } //0x154FDB0 0x154FDD4
		public Action onSendClickButton { private get; set; } // 0x4C
		public Action onStampClickButton { private get; set; } // 0x50
		public Action<string, bool> onMessgeSend { get; set; } // 0x54
		public Action onMemberClickButton { get; set; } // 0x58

		// RVA: 0x154FE18 Offset: 0x154FE18 VA: 0x154FE18
		public void InputEnable()
		{
			m_textTextField.enabled = true;
		}

		// RVA: 0x154FE48 Offset: 0x154FE48 VA: 0x154FE48
		public void InputDisable()
		{
			m_textTextField.enabled = false;
		}

		// RVA: 0x154FE78 Offset: 0x154FE78 VA: 0x154FE78
		public void LateUpdate()
		{
			if(m_keyBoard != null && IsLoaded)
			{
				if (!m_keyBoard.IsOpenKeyboard)
					return;
				ChangeText = m_keyBoard.GetKeyboardText();
				if(ChangeText != PreText)
				{
					PreText = ChangeText;
					OnChangeContent(ChangeText);
				}
			}
		}

		// RVA: 0x1550200 Offset: 0x1550200 VA: 0x1550200 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_footerBaseAnim = layout.FindViewById("sw_lb_footer_anim_01") as AbsoluteLayout;
			m_footerButtonSwitch = layout.FindViewById("swtbl_lb_footer_01") as AbsoluteLayout;
			m_footerBaseAnim.StartChildrenAnimGoStop("st_wait");
			m_sendButton.ClearOnClickCallback();
			m_sendButton.AddOnClickCallback(() =>
			{
				//0x155122C
				if (m_sendButton != null)
					onSendClickButton();
			});
			m_stampButton.ClearOnClickCallback();
			m_stampButton.AddOnClickCallback(() =>
			{
				//0x15512E0
				if (m_stampButton != null)
					onStampClickButton();
			});
			m_memberButton.ClearOnClickCallback();
			m_memberButton.AddOnClickCallback(() =>
			{
				//0x1551394
				if (m_memberButton != null)
					onMemberClickButton();
			});
			if(m_keyBoard != null)
			{
				for(int i = 0; i < m_keyBoard.InputFieldCount; i++)
				{
					m_keyBoard.SetOnClickInputField(i, () =>
					{
						//0x1551448
						if(IsLoaded)
						{
							m_keyBoard.OpenKeyboard(m_textTextField.text, 40, 0, false, false, false, false, "");
						}
					});
				}
			}
			SetPlaceholder();
			SetInputSendMessge(InputField.ContentType.Standard);
			AttentionText.text = MessageManager.Instance.GetMessage("menu", "deco_chat_footer_attention_text");
			Loaded();
			IsLoaded = true;
			return true;
		}

		// RVA: 0x15509F0 Offset: 0x15509F0 VA: 0x15509F0
		public void Enter(bool IsMember)
		{
			if(IsMember)
			{
				if (m_footerBaseAnim != null)
					m_footerBaseAnim.StartChildrenAnimGoStop("go_in", "st_in");
			}
			else
			{
				Hide();
			}
		}

		// RVA: 0x1550AF8 Offset: 0x1550AF8 VA: 0x1550AF8
		public void Leave(bool IsMember)
		{
			if(IsMember)
			{
				if (m_footerBaseAnim != null)
					m_footerBaseAnim.StartChildrenAnimGoStop("go_out", "st_out");
			}
			else
			{
				Hide();
			}
		}

		//// RVA: 0x1550A88 Offset: 0x1550A88 VA: 0x1550A88
		public void Hide()
		{
			if (m_footerBaseAnim != null)
				m_footerBaseAnim.StartChildrenAnimGoStop("st_wait");
		}

		// RVA: 0x1550B90 Offset: 0x1550B90 VA: 0x1550B90
		public bool IsPlayingChild()
		{
			return m_footerBaseAnim.IsPlayingChildren();
		}

		//// RVA: 0x1550BBC Offset: 0x1550BBC VA: 0x1550BBC
		public void SetEnableMemberButton(bool _enable)
		{
			m_memberButton.Hidden = !enabled;
		}

		//// RVA: 0x1550BF0 Offset: 0x1550BF0 VA: 0x1550BF0
		public void SetFooterSwitchButtonAnimation(FooterButtonAnimType _type)
		{
			switch(_type)
			{
				case FooterButtonAnimType.Main:
					m_footerButtonSwitch.StartChildrenAnimGoStop("01");
					break;
				case FooterButtonAnimType.BattleLog:
					m_footerButtonSwitch.StartChildrenAnimGoStop("02");
					break;
				case FooterButtonAnimType.Age:
					m_footerButtonSwitch.StartChildrenAnimGoStop("03");
					break;
				case FooterButtonAnimType.Live:
					m_footerButtonSwitch.StartChildrenAnimGoStop("04");
					break;
				case FooterButtonAnimType.DecoChat:
					m_footerButtonSwitch.StartChildrenAnimGoStop("05");
					break;
				default:
					break;
			}
		}

		//// RVA: 0x1550D2C Offset: 0x1550D2C VA: 0x1550D2C
		public void Setting()
		{
			IsEnableSendButton = true;
			m_sendButton.Disable = true;
			SetMessgeInputOut();
		}

		//// RVA: 0x1550664 Offset: 0x1550664 VA: 0x1550664
		private void SetPlaceholder()
		{
			if(m_textTextField != null)
			{
				string msg = MessageManager.Instance.GetMessage("menu", "bulletin_board_limit_input_text");
				Text ph = m_textTextField.placeholder.GetComponent<Text>();
				ph.alignment = m_textTextField.textComponent.alignment;
				ph.text = msg;
			}
		}

		//// RVA: 0x155087C Offset: 0x155087C VA: 0x155087C
		private void SetInputSendMessge(InputField.ContentType contentType = 0)
		{
			if(m_textTextField != null)
			{
				m_textTextField.contentType = contentType;
				m_textTextField.characterLimit = 40;
				m_textTextField.onEndEdit.AddListener((string value) =>
				{
					//0x1551520
					OnChangeContent(value);
				});
			}
		}

		//// RVA: 0x154FF84 Offset: 0x154FF84 VA: 0x154FF84
		private void OnChangeContent(string value)
		{
			string str = convertText(value);
			m_textTextField.onValueChanged.RemoveListener(OnChangeContent);
			m_textTextField.text = str;
			m_textTextField.onValueChanged.AddListener(OnChangeContent);
			if (onMessgeSend != null)
				onMessgeSend(str, !(string.IsNullOrEmpty(str) || IsWhiteSpace(str)));
			IsEnableSendButton = string.IsNullOrEmpty(str) || IsWhiteSpace(str);
			m_sendButton.Disable = IsEnableSendButton;
			TextGeneratorUtility.SetTextRectangleMessage(m_DisplayInputText, str, 1, "...");
		}

		//// RVA: 0x1550E34 Offset: 0x1550E34 VA: 0x1550E34
		private string convertText(string value)
		{
			StringBuilder str = new StringBuilder();
			str.Set(value);
			str.Replace('<', (char)0xff1c);
			str.Replace('>', (char)0xff1e);
			str.Replace("\r", "");
			str.Replace("\n", "");
			GameMessageManager.ReplaceInvalidFont(ref str, str.ToString());
			return str.ToString();
		}

		//// RVA: 0x155114C Offset: 0x155114C VA: 0x155114C
		public void IsButtonDisable(bool isDisable)
		{
			if(!IsEnableSendButton)
			{
				m_sendButton.Disable = isDisable;
			}
			m_stampButton.Disable = isDisable;
		}

		//// RVA: 0x1550D70 Offset: 0x1550D70 VA: 0x1550D70
		public void SetMessgeInputOut()
		{
			if (m_textTextField != null)
				m_textTextField.text = "";
		}

		//// RVA: 0x1551060 Offset: 0x1551060 VA: 0x1551060
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
