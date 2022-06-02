using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.DownLoad
{
	public class LayoutQuestionaryWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutQuestionaryButton[] m_radioButtons;
		[SerializeField]
		private LayoutQuestionaryButton[] m_checkButtons;
		[SerializeField]
		private ActionButton m_okButton;
		[SerializeField]
		private Text m_questionText;
		[SerializeField]
		private Text[] m_notification1Text;
		[SerializeField]
		private Text m_notification2Text;
		[SerializeField]
		private Text m_denText;
		[SerializeField]
		private Text m_numText;
	}
}
