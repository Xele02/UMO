using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CostumeDivaSelectWindow : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ToggleButton[] m_divaToggleButton;
		[SerializeField]
		private RawImageEx[] m_divaIconImages;
	}
}
