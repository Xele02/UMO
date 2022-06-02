using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game;

namespace XeApp.Game.Menu
{
	public class LobbyFooter : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_sendButton;
		[SerializeField]
		private ActionButton m_stampButton;
		[SerializeField]
		private ActionButton m_memberButton;
		[SerializeField]
		private InputField m_textTextField;
		[SerializeField]
		private RectTransform InputFieldPos;
		[SerializeField]
		private Text AttentionText;
		[SerializeField]
		private Text m_DisplayInputText;
		[SerializeField]
		private CustomScreenKeyboard m_keyBoard;
	}
}
