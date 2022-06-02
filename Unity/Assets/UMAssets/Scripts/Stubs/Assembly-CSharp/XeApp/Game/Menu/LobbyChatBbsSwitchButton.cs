using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LobbyChatBbsSwitchButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ToggleButton m_chatButton;
		[SerializeField]
		private ToggleButton m_battleLogButton;
		[SerializeField]
		private ToggleButton m_captureButton;
		[SerializeField]
		private RawImageEx m_stateChangeTex;
		[SerializeField]
		private ActionButton m_stateChangeButton;
	}
}
