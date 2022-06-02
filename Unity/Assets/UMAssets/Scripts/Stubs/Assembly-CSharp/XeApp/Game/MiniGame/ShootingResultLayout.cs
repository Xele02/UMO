using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultLayout : MonoBehaviour
	{
		[SerializeField]
		private ShootingResultTitleLayout m_resultTitle;
		[SerializeField]
		private ShootingResultTitleScoreLayout m_resultScoreTitle;
		[SerializeField]
		private ShootingResultScoreNumLayout m_resultScore;
		[SerializeField]
		private ShootingResultTitleHighScoreLayout m_resultHighScoreTitle;
		[SerializeField]
		private ShootingResultHighScoreNumLayout m_resultHighScore;
		[SerializeField]
		private ShootingResultTouchScreenLayout m_resultTouchScreen;
		[SerializeField]
		private ShootingResultPlayerLayout m_resultPlayer;
		[SerializeField]
		private ShootingResultHighScoreUseCommand m_resultHighScoreUseCommand;
		[SerializeField]
		private ShootingResultScoreUseCommand m_resultScoreUseCommand;
	}
}
