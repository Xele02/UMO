using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SNSTitleBar : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_backButton;
		[SerializeField]
		private ActionButton m_exitButton;
		[SerializeField]
		private ActionButton m_nextButton;
		[SerializeField]
		private ActionButton m_prevButton;
		[SerializeField]
		private ActionButton m_newTalkButton;
		[SerializeField]
		private ActionButton m_pushLButton;
		[SerializeField]
		private ActionButton m_pushRButton;
		[SerializeField]
		private Text m_roomName;
		[SerializeField]
		private Text m_roomEntranceName;
	}
}
