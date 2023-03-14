using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaPopupBonusClose : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_textMain;
		[SerializeField]
		private CheckboxButton m_checkHidden;
		[SerializeField]
		private Text m_textHidden;
	}
}
