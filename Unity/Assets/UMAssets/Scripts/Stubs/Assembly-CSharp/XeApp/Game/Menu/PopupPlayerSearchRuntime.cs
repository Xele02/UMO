using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupPlayerSearchRuntime : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_myIdText;
		[SerializeField]
		private Text m_friendIdText;
		[SerializeField]
		private InputField m_friendIdTextField;
		[SerializeField]
		private Text m_friendIdPlaceholder;
		[SerializeField]
		private ActionButton m_copyButton;
		[SerializeField]
		private ActionButton m_searchButton;
	}
}
