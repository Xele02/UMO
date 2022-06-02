using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutGachaDrawButtonGroup : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textTelop;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private Text m_textSetSale;
		[SerializeField]
		private Text m_textTicketName;
		[SerializeField]
		private Text m_textTicketNum;
		[SerializeField]
		private Text m_textTicketPeriod;
		[SerializeField]
		private Text m_textEvTicketName;
		[SerializeField]
		private Text m_textEvTicketNum;
		[SerializeField]
		private LayoutGachaDrawButton[] m_button;
		[SerializeField]
		private RawImageEx m_imageTicketIcon;
		[SerializeField]
		private RawImageEx m_imageEvTicketIcon;
		[SerializeField]
		private NumberBase m_numberStepNum;
		[SerializeField]
		private NumberBase m_numberStepMax;
		[SerializeField]
		private ActionButton m_buttonSetSale;
		[SerializeField]
		private ActionButton m_buttonPeriod;
	}
}
