using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class RaidActSelectRootPanel : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RaidActSelectPanel m_layoutPanelL;
		[SerializeField]
		private RaidActSelectPanel m_layoutPanelR;
		[SerializeField]
		private Text m_textFreePlay;
	}
}
