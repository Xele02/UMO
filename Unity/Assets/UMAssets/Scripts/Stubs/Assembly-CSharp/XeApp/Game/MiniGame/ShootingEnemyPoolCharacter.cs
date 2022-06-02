using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyPoolCharacter : ShootingTask
	{
		[SerializeField]
		private int m_createNum;
		public ShootingEnemyCharacter m_taskObject;
	}
}
