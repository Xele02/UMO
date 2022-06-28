using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LobbyMembersListWindow : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_windowMessage;
		[SerializeField]
		private Text m_countValues;
		[SerializeField]
		private Text m_groupName;
	}
}
