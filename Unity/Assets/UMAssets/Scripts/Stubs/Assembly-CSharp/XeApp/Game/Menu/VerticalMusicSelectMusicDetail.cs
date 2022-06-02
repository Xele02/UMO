using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using TMPro;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectMusicDetail : MonoBehaviour
	{
		[SerializeField]
		private Color m_invalidDigitColor;
		[SerializeField]
		private RawImage m_imageJacket;
		[SerializeField]
		private UGUIButton m_jacketSelectButton;
		[SerializeField]
		private TextMeshProUGUI m_highScore;
		[SerializeField]
		private GameObject m_scoreObj;
		[SerializeField]
		private Image m_scoreRnak;
		[SerializeField]
		private Sprite[] m_changeScoreRank;
		[SerializeField]
		private GameObject m_musicUtaRateObj;
		[SerializeField]
		private TextMeshProUGUI m_musicUtaRate;
		[SerializeField]
		private GameObject m_musicTimeObj;
		[SerializeField]
		private TextMeshProUGUI m_musicTime;
		[SerializeField]
		private CanvasGroup m_bookMarkObj;
		[SerializeField]
		private GameObject m_bookMarkSaveObj;
		[SerializeField]
		private GameObject m_bookMarkNotSaveObj;
		[SerializeField]
		private UGUIButton m_bookMarakButton;
		[SerializeField]
		private CanvasGroup m_unitToggleButtonGroupObj;
		[SerializeField]
		private UGUIToggleButtonGroup m_unitToggleButtonGroup;
		[SerializeField]
		private UGUIToggleButton[] m_unitToggleButton;
		[SerializeField]
		private InOutAnime m_inOut;
		[SerializeField]
		private Image m_backImage;
		[SerializeField]
		private Sprite[] m_changeBackImage;
		[SerializeField]
		private CanvasGroup m_lockObj;
		[SerializeField]
		private Image m_lockIcon;
		[SerializeField]
		private CanvasGroup m_weeklyObj;
		[SerializeField]
		private RawImageEx[] m_weeklyItemImage;
		[SerializeField]
		private TextMeshProUGUI m_weeklyRemainTime;
		[SerializeField]
		private TextMeshProUGUI m_weeklyRemainCount;
		[SerializeField]
		private UGUIButton m_weeklyDescButton;
		[SerializeField]
		private CanvasGroup m_highLevelFrmObj;
		[SerializeField]
		private CanvasGroup m_highLevelRemainTimeObj;
		[SerializeField]
		private Text m_highLevelRemainTime;
		[SerializeField]
		private CanvasGroup m_highLevelClearStateObj;
		[SerializeField]
		private Image m_highLevelClearStateImage;
		[SerializeField]
		private Sprite[] m_highLevelClearStateSprites;
		[SerializeField]
		private GameObject m_ScoreRankingObj;
		[SerializeField]
		private TextMeshProUGUI m_ScoreRankingNum;
		[SerializeField]
		private UGUIButton m_ScoreRankingDescButton;
		[SerializeField]
		private UGUIButton m_ScoreRankingEventRewardButton;
		[SerializeField]
		private CanvasGroup m_eventObj;
		[SerializeField]
		private CanvasGroup m_eventCountingObj;
		[SerializeField]
		private TextMeshProUGUI m_eventRemainTime;
	}
}
