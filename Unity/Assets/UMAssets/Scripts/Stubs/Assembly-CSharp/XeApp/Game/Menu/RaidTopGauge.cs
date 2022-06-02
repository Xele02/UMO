using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class RaidTopGauge : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_apNowNum;
		[SerializeField]
		private NumberBase m_apMaxNum;
		[SerializeField]
		private NumberBase m_paidStoneNum;
		[SerializeField]
		private Text m_timeText;
		[SerializeField]
		private Text m_balloonText;
		[SerializeField]
		private ActionButton m_apPlusButton;
		[SerializeField]
		private ActionButton m_vcPlusButton;
		[SerializeField]
		private ActionButton m_chargeButton;
	}
}
