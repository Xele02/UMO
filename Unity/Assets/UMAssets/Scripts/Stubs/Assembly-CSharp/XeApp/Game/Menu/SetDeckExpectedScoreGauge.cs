using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SetDeckExpectedScoreGauge : MonoBehaviour
	{
		[SerializeField]
		private UGUIRepeatButton m_minusButton;
		[SerializeField]
		private UGUIRepeatButton m_plusButton;
		[SerializeField]
		private Text m_scaleText;
		[SerializeField]
		private List<UGUIGauge> m_scoreGauges;
		[SerializeField]
		private List<UGUIGauge> m_rankGauges;
		[SerializeField]
		private Image m_rankImage;
		[SerializeField]
		private List<Sprite> m_rankSprites;
	}
}
