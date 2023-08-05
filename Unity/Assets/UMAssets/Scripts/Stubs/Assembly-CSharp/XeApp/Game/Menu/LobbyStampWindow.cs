using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LobbyStampWindow : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private SwapScrollList m_swapScrollList;
		[SerializeField]
		private ActionButton m_stampEditButton;
		[SerializeField]
		private Button m_btnHide;
		[SerializeField]
		private Text m_haveNotStampText;
		public bool IsShow;
	}
}
