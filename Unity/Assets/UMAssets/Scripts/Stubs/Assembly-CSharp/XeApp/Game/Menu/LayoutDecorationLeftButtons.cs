using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationLeftButtons : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton m_returnHomeButton;
		[SerializeField]
		private ActionButton m_returnDecoButton;
		[SerializeField]
		private ActionButton m_returnLobbyButton;
		[SerializeField]
		private ActionButton m_visitButton;
		[SerializeField]
		private ActionButton m_boardButton;
		[SerializeField]
		private ActionButton m_allGetButton;
	}
}
