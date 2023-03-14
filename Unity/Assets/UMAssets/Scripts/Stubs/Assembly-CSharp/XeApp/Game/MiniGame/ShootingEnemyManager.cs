using System.Collections.Generic;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyManager : ShootingTask
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		public List<ShootingEnemyPoolCharacter> m_enemyPoolObj;
	}
}
