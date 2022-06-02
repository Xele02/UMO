using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Tutorial
{
	public class TutorialWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_titleText;
		[SerializeField]
		private Text[] m_messageText;
		[SerializeField]
		private Text[] m_pageNumbers;
		[SerializeField]
		private ActionButton[] m_sendButton;
		[SerializeField]
		private ActionButton[] m_okButton;
		[SerializeField]
		private ActionButton[] m_arrowButtons;
		[SerializeField]
		private RawImageEx[] m_image;
		[SerializeField]
		private float m_buttonWaitSec;
	}
}
