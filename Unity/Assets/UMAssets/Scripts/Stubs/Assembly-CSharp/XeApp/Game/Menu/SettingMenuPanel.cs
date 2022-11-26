using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SettingMenuPanel : TransitionRoot
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private ActionButton[] m_menuButtons;
		[SerializeField]
		private SettingMenuRuntime m_settingMenu;
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
	}
}
