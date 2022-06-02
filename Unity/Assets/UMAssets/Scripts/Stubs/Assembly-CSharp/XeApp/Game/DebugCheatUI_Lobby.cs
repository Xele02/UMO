using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugCheatUI_Lobby : DebugCheatUIBase
	{
		[SerializeField]
		private Text m_infoText;
		[SerializeField]
		private DebugCheatIntInputField m_idInput;
		[SerializeField]
		private Toggle m_afterToggle;
		[SerializeField]
		private Button m_setButton;
		[SerializeField]
		private Button m_resetButton;
		[SerializeField]
		private Text m_resultText;
		[SerializeField]
		private DebugCheatIntInputField[] m_raidItemInput;
		[SerializeField]
		private Button m_eventResetButton;
		[SerializeField]
		private Button m_tutorialResetButton;
		[SerializeField]
		private Toggle m_CommentCountToggle;
		[SerializeField]
		private Toggle m_ConnectionError;
		[SerializeField]
		private Button m_lobbyHelpResetButton;
		[SerializeField]
		private Button m_lobbyPushHelpResetButton;
		[SerializeField]
		private Toggle m_viewingTextToggle;
		[SerializeField]
		private Text m_hlpeInfoText;
		[SerializeField]
		private DebugCheatIntInputField m_helpIdInput;
		[SerializeField]
		private Text m_helpIdText;
		[SerializeField]
		private Button m_helpIdSave;
		[SerializeField]
		private Toggle m_helpToggle;
	}
}
