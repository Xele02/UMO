using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingMainLayout : MonoBehaviour
	{
		[SerializeField]
		private ShootingMainGameClear m_gameClear;
		[SerializeField]
		private ShootingMainGameOver m_gameOver;
		[SerializeField]
		private ShootingMainScore m_score;
		[SerializeField]
		private ShootingMainUseCommand m_useCommand;
	}
}
