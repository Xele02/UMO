using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class SetDeckGaugePopup : UIBehaviour
	{
		[SerializeField]
		private Text[] m_nameText;
		[SerializeField]
		private Text[] m_descText;
		[SerializeField]
		private Text[] m_cautionText;
		[SerializeField]
		private SetDeckExpectedScoreGauge m_scoreGauge;
	}
}
