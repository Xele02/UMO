using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.DownLoad
{
	public class LayoutQuestionaryButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ToggleButton m_toggleButton;
		[SerializeField]
		private Text m_buttonLabel;
		[SerializeField]
		private string m_rootExId;
	}
}
