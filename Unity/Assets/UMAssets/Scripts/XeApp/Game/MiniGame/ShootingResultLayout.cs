using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultLayout : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x66486C Offset: 0x66486C VA: 0x66486C
		[SerializeField]
		private ShootingResultTitleLayout m_resultTitle; // 0xC
		//[HeaderAttribute] // RVA: 0x6648C0 Offset: 0x6648C0 VA: 0x6648C0
		[SerializeField]
		private ShootingResultTitleScoreLayout m_resultScoreTitle; // 0x10
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x66491C Offset: 0x66491C VA: 0x66491C
		private ShootingResultScoreNumLayout m_resultScore; // 0x14
		//[HeaderAttribute] // RVA: 0x664974 Offset: 0x664974 VA: 0x664974
		[SerializeField]
		private ShootingResultTitleHighScoreLayout m_resultHighScoreTitle; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x6649D8 Offset: 0x6649D8 VA: 0x6649D8
		private ShootingResultHighScoreNumLayout m_resultHighScore; // 0x1C
		//[HeaderAttribute] // RVA: 0x664A30 Offset: 0x664A30 VA: 0x664A30
		[SerializeField]
		private ShootingResultTouchScreenLayout m_resultTouchScreen; // 0x20
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664A78 Offset: 0x664A78 VA: 0x664A78
		private ShootingResultPlayerLayout m_resultPlayer; // 0x24
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664AD0 Offset: 0x664AD0 VA: 0x664AD0
		private ShootingResultHighScoreUseCommand m_resultHighScoreUseCommand; // 0x28
		//[HeaderAttribute] // RVA: 0x664B34 Offset: 0x664B34 VA: 0x664B34
		[SerializeField]
		private ShootingResultScoreUseCommand m_resultScoreUseCommand; // 0x2C

		// RVA: 0xC901C8 Offset: 0xC901C8 VA: 0xC901C8
		public void Awake()
		{
			Leave();
		}

		// RVA: 0xC901CC Offset: 0xC901CC VA: 0xC901CC
		public void Leave()
		{
			ResultLeave();
			ScoreLeave();
			HighScoreLeave();
			TouchScreenLeave();
			PlayerLeave();
		}

		//// RVA: 0xC90340 Offset: 0xC90340 VA: 0xC90340
		public void ResultEnter()
		{
			m_resultTitle.Enter();
		}

		//// RVA: 0xC90200 Offset: 0xC90200 VA: 0xC90200
		public void ResultLeave()
		{
			m_resultTitle.Leave();
		}

		//// RVA: 0xC903D0 Offset: 0xC903D0 VA: 0xC903D0
		public void ScoreEnter(int score, bool isCommand)
		{
			m_resultScoreTitle.Enter();
			m_resultScore.Enter();
			m_resultScore.SetScore(score);
			m_resultScoreUseCommand.Enter(isCommand);
		}

		//// RVA: 0xC90228 Offset: 0xC90228 VA: 0xC90228
		public void ScoreLeave()
		{
			m_resultScoreTitle.Leave();
			m_resultScore.Leave();
			m_resultScoreUseCommand.Leave();
		}

		//// RVA: 0xC905D4 Offset: 0xC905D4 VA: 0xC905D4
		public void HighScoreEnter(int highScore, bool isCommand)
		{
			m_resultHighScoreTitle.Enter();
			m_resultHighScore.Enter();
			m_resultHighScore.SetScore(highScore);
			m_resultHighScoreUseCommand.Enter(isCommand);
		}

		//// RVA: 0xC9028C Offset: 0xC9028C VA: 0xC9028C
		public void HighScoreLeave()
		{
			m_resultHighScoreTitle.Leave();
			m_resultHighScore.Leave();
			m_resultHighScoreUseCommand.Leave();
		}

		//// RVA: 0xC906CC Offset: 0xC906CC VA: 0xC906CC
		public void TouchScreenEnter()
		{
			m_resultTouchScreen.Enter();
		}

		//// RVA: 0xC902F0 Offset: 0xC902F0 VA: 0xC902F0
		public void TouchScreenLeave()
		{
			m_resultTouchScreen.Leave();
		}

		//// RVA: 0xC907B0 Offset: 0xC907B0 VA: 0xC907B0
		public void PlayerEnter()
		{
			m_resultPlayer.Enter();
		}

		//// RVA: 0xC90318 Offset: 0xC90318 VA: 0xC90318
		public void PlayerLeave()
		{
			m_resultPlayer.Leave();
		}
	}
}
