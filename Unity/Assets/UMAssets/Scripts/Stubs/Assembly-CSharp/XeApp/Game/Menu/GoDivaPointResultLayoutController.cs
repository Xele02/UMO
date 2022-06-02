using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class GoDivaPointResultLayoutController : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_imageDiff;
		[SerializeField]
		private RawImageEx m_imageDivaIcon;
		[SerializeField]
		private NumberBase m_ScorePoint;
		[SerializeField]
		private Text m_scoreBonusText;
		[SerializeField]
		private Text m_basePointText;
		[SerializeField]
		private Text m_textEpisodeCount;
		[SerializeField]
		private Text m_textEpisodeRate;
		[SerializeField]
		private Text m_textPoint;
		[SerializeField]
		private Text m_textPointTotal;
		[SerializeField]
		private Text m_textMedalNum;
		[SerializeField]
		private RawImageEx m_imageMedal;
		[SerializeField]
		private Text m_textBonusMusicProbability;
		[SerializeField]
		private Text m_textHiScore;
		[SerializeField]
		private Text m_textScoreRanking;
		[SerializeField]
		private ActionButton m_rankingButton;
	}
}
