using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationFrameButton : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton m_flipButon;
		[SerializeField]
		private ActionButton m_serifButon;
		[SerializeField]
		private ActionButton m_priorityDownButon;
		[SerializeField]
		private ActionButton m_priorityUpButon;
		[SerializeField]
		private ActionButton m_kiraButon;
	}
}
