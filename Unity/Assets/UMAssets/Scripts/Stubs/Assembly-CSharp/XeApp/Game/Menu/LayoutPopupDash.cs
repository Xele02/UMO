using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupDash : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton[] m_buttons;
		[SerializeField]
		private ToggleButtonGroup m_toggleButtonGroup;
		[SerializeField]
		private Text[] m_textButton;
		[SerializeField]
		private Text m_textCost;
		[SerializeField]
		private Text m_textOwn;
		[SerializeField]
		private Text[] m_textCaution;
		[SerializeField]
		private Text m_textCostOver;
		[SerializeField]
		private RawImageEx m_imageCostOver;
	}
}
