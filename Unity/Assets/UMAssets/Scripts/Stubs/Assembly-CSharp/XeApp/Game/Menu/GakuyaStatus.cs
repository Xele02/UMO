using UnityEngine;
using TMPro;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class GakuyaStatus : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI m_textDivaLevel;
		[SerializeField]
		private TextMeshProUGUI m_textIntimacyLevel;
		[SerializeField]
		private TextMeshProUGUI m_textCostumeCount;
		[SerializeField]
		private TextMeshProUGUI m_textDivaRanking;
		[SerializeField]
		private TextMeshProUGUI m_textTotal;
		[SerializeField]
		private TextMeshProUGUI m_textDivaStatus;
		[SerializeField]
		private TextMeshProUGUI m_textSoulTotalStatus;
		[SerializeField]
		private TextMeshProUGUI m_textVoiceTotalStatus;
		[SerializeField]
		private TextMeshProUGUI m_textCharmTotalStatus;
		[SerializeField]
		private TextMeshProUGUI m_textCostumeStatus;
		[SerializeField]
		private UGUIButton m_buttonDivaRanking;
		[SerializeField]
		private ScrollRect m_scroll;
	}
}
