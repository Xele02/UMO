using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using TMPro;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectDifficultyButton : MonoBehaviour
	{
		[SerializeField]
		private MusicSelectDifficultScriptableObject m_difficultSprite;
		[SerializeField]
		private Image m_onDifficultIcon;
		[SerializeField]
		private Image m_offDifficultIcon;
		[SerializeField]
		private UGUIToggleButton m_toggleButton;
		[SerializeField]
		private TextMeshProUGUI[] m_musicLevel;
		[SerializeField]
		private GameObject m_clearObj;
		[SerializeField]
		private GameObject m_fullComboObj;
		[SerializeField]
		private GameObject m_perfectFullComboObj;
	}
}
