using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationOptionContent : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ToggleButton[] buttons;
		[SerializeField]
		private ToggleButtonGroup group;
		[SerializeField]
		private Text descText;
	}
}
