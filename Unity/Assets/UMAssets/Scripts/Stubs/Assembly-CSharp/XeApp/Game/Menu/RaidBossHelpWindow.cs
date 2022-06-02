using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RaidBossHelpWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_text01;
		[SerializeField]
		private Text m_text02;
		[SerializeField]
		private Text m_text03;
		[SerializeField]
		private Text m_text04;
		[SerializeField]
		private ToggleButtonGroup m_toggleBtnGroup;
		[SerializeField]
		private CheckboxButton m_checkboxButton;
	}
}
