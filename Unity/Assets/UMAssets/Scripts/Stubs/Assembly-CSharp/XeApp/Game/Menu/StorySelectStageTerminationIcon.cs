using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class StorySelectStageTerminationIcon : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton m_action_btn;
		[SerializeField]
		private GameObject m_newPos;
	}
}
