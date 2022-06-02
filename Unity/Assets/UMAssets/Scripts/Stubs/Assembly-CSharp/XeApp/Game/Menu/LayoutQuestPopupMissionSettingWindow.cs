using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutQuestPopupMissionSettingWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_btnText;
		[SerializeField]
		private Text m_musicSettingText;
		[SerializeField]
		private Text m_Info1;
		[SerializeField]
		private Text m_Info2;
		[SerializeField]
		private Text m_Info3;
		[SerializeField]
		private ToggleButton[] m_toggleButtons;
		[SerializeField]
		private ToggleButtonGroup m_toggleButtonGrp;
	}
}
