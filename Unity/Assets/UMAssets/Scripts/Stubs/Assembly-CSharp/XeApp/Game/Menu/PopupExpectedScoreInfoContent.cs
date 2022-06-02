using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupExpectedScoreInfoContent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_textName;
		[SerializeField]
		private Text[] m_textDesc;
		[SerializeField]
		private Text[] m_textCaution;
		[SerializeField]
		private UnitExpectedScore m_scoreGauge;
		[SerializeField]
		private RepeatButton m_buttonScorePlus;
		[SerializeField]
		private RepeatButton m_buttonScoreMinus;
		[SerializeField]
		private RawImageEx m_imageScorePlus;
		[SerializeField]
		private Text m_textGaugeRate;
	}
}
