using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutResultDropFoldRadar : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_text01;
		[SerializeField]
		private NumberBase m_itemNum;
		[SerializeField]
		private ActionButton m_okButton;
	}
}
