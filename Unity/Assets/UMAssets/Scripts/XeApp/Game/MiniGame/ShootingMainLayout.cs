using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingMainLayout : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x664548 Offset: 0x664548 VA: 0x664548
		[SerializeField]
		private ShootingMainGameClear m_gameClear; // 0xC
		//[HeaderAttribute] // RVA: 0x6645A4 Offset: 0x6645A4 VA: 0x6645A4
		[SerializeField]
		private ShootingMainGameOver m_gameOver; // 0x10
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x664600 Offset: 0x664600 VA: 0x664600
		private ShootingMainScore m_score; // 0x14
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x66465C Offset: 0x66465C VA: 0x66465C
		private ShootingMainUseCommand m_useCommand; // 0x18

		// RVA: 0xC8D438 Offset: 0xC8D438 VA: 0xC8D438
		public void Awake()
		{
			Leave();
		}

		// RVA: 0xC8D494 Offset: 0xC8D494 VA: 0xC8D494
		public void Enter(bool isCommand)
		{
			m_score.Enter();
			m_useCommand.Enter(isCommand);
		}

		// RVA: 0xC8D43C Offset: 0xC8D43C VA: 0xC8D43C
		public void Leave()
		{
			m_score.Leave();
			GameClearLeave();
			GameOverLeave();
			m_useCommand.Leave();
		}

		//// RVA: 0xC8D60C Offset: 0xC8D60C VA: 0xC8D60C
		public void LayoutUpdate(int score)
		{
			m_score.SetNum(score);
		}

		//// RVA: 0xC8D670 Offset: 0xC8D670 VA: 0xC8D670
		public void GameClearEnter()
		{
			m_gameClear.Enter();
		}

		//// RVA: 0xC8D588 Offset: 0xC8D588 VA: 0xC8D588
		public void GameClearLeave()
		{
			m_gameClear.Leave();
		}

		//// RVA: 0xC8D698 Offset: 0xC8D698 VA: 0xC8D698
		public void GameOverEnter()
		{
			m_gameOver.Enter();
		}

		//// RVA: 0xC8D5B0 Offset: 0xC8D5B0 VA: 0xC8D5B0
		public void GameOverLeave()
		{
			m_gameOver.Leave();
		}
	}
}
