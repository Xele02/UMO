using XeSys;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game
{
	internal class DebugCheatMenu : SingletonBehaviour<DebugCheatMenu>
	{
		[SerializeField]
		private GameObject m_root;
		[SerializeField]
		private DebugCheatMenuContent m_contentPrefab;
		[SerializeField]
		private Text m_versionText;
		[SerializeField]
		private Text m_playerIdText;
		[SerializeField]
		private Text m_serverIdText;
		[SerializeField]
		private Text m_versionDataText;
		[SerializeField]
		private RectTransform m_exceptionArea;
		[SerializeField]
		private Text m_exceptionText;
		[SerializeField]
		private Image m_exceptionIcon;
		[SerializeField]
		private Button m_exceptionClear;
		[SerializeField]
		private Toggle m_exceptionToggle;
		[SerializeField]
		private Text m_exceptionToggleLabel;
		[SerializeField]
		private Button m_debugCloseButton;
		[SerializeField]
		private Text m_memoryText;
		[SerializeField]
		private Text m_advertisingIdText;
	}
}
