using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationEnergyChargePopup : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_textMain;
		[SerializeField]
		private Text m_textAttention;
		[SerializeField]
		private NumberBase[] m_chargeNum;
	}
}
