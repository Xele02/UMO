using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidBossSortLayout : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton m_sortInfoBtn;
		[SerializeField]
		private ActionButton m_sortOrderBtn;
		[SerializeField]
		private ActionButton m_updateBtn;
	}
}
