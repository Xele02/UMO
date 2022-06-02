using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationEnergyChargePopup : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textMain;
		[SerializeField]
		private Text m_textAttention;
		[SerializeField]
		private NumberBase[] m_chargeNum;
	}
}
