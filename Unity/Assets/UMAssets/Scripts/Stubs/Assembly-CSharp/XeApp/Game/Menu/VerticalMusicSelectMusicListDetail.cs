using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicListDetail : MonoBehaviour
	{
		[SerializeField]
		private Text m_musicName;
		[SerializeField]
		private Text m_musicLevel;
		[SerializeField]
		private UGUIButton m_rewardButton;
		[SerializeField]
		private UGUIButton m_rankingButton;
		[SerializeField]
		private UGUIButton m_specialPerformButton;
		[SerializeField]
		private Image m_rewardScore;
		[SerializeField]
		private Image m_rewardConbo;
		[SerializeField]
		private Image m_rewardClear;
		[SerializeField]
		private InOutAnime m_inOut;
	}
}
