using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectDifficultyButtonGroup : MonoBehaviour
	{
		[SerializeField]
		private GridLayoutGroup m_layoutGroup;
		[SerializeField]
		private float m_4LineWidth;
		[SerializeField]
		private float m_6LineWidth;
		[SerializeField]
		private UGUIToggleButtonGroup m_toggleButtonGroup;
		[SerializeField]
		private VerticalMusicSelectDifficultyButton[] m_diffityButton;
		[SerializeField]
		private InOutAnime m_inOut;
	}
}
