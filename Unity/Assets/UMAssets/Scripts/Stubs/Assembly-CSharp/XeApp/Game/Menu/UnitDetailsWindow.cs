using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class UnitDetailsWindow : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_unitNameText;
		[SerializeField]
		private ActionButton m_statusChangeButton;
		[SerializeField]
		private ActionButton m_nameChangeButton;
		[SerializeField]
		private ShowUnitNameInputEvent m_onPushNameChangeButton;
		[SerializeField]
		private ScrollRect m_scrollRect;
	}
}
