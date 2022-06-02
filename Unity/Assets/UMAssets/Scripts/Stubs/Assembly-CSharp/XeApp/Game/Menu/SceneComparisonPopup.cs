using UnityEngine.EventSystems;
using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SceneComparisonPopup : UIBehaviour
	{
		[SerializeField]
		private SceneComparisonParam[] m_params;
		[SerializeField]
		private InfoButton m_infoButton;
		[SerializeField]
		private RepeatButton m_scorePlusButton;
		[SerializeField]
		private RepeatButton m_scoreMinusButton;
		[SerializeField]
		private UnitExpectedScore[] m_scoreGauges;
		[SerializeField]
		private RawImageEx m_scoreTotalArrowImage;
		[SerializeField]
		private RawImageEx m_scorePlusImage;
		[SerializeField]
		private Text[] m_textGaugeNames;
		[SerializeField]
		private Text m_gaugeRateText;
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
	}
}
