using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidBossSortWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_resetButton;
		[SerializeField]
		private ToggleButtonGroup m_toggleBtnGroup;
		[SerializeField]
		private ToggleButton[] m_sortToggles;
		[SerializeField]
		private ToggleButton[] m_bossToggles;
		[SerializeField]
		private ToggleButton[] m_rankToggles;
		[SerializeField]
		private ToggleButton[] m_joinToggles;
	}
}
