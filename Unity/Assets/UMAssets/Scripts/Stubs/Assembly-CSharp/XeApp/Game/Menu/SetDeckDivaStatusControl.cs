using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SetDeckDivaStatusControl : MonoBehaviour
	{
		[SerializeField]
		private List<SetDeckSkillIconControl> m_skillIcons;
		[SerializeField]
		private Text m_statusTitleText;
		[SerializeField]
		private Image m_statusValueBackImage;
		[SerializeField]
		private Text m_statusValueText;
		[SerializeField]
		private GameObject m_musicExpObject;
		[SerializeField]
		private Text m_musicExpLevelText;
		[SerializeField]
		private UGUIGauge m_musicExpGauge;
		[SerializeField]
		private GameObject m_musicExpGaugeBandObject;
		[SerializeField]
		private Image m_musicExpGaugeBandHeadImage;
		[SerializeField]
		private Image m_musicExpGaugeMaxImage;
	}
}
