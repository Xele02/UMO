using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CommonMenuExpGauge : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private float m_usingRangeLow;
		[SerializeField]
		private float m_usingRangeHigh;
	}
}
