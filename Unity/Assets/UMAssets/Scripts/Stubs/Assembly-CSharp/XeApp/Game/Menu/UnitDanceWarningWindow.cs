using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class UnitDanceWarningWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_okButton;
		[SerializeField]
		private ActionButton m_unitLiveButton;
		[SerializeField]
		private ActionButton m_soloLiveButton;
		[SerializeField]
		private ToggleButton m_toggleButton;
		[SerializeField]
		private RawImageEx m_unitDanceIconImage;
		[SerializeField]
		private Text m_title;
		[SerializeField]
		private Text m_content;
		[SerializeField]
		private Text m_checkLabel;
	}
}
