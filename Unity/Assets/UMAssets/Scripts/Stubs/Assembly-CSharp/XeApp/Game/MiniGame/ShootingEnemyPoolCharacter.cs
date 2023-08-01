using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyPoolCharacter : ShootingTask
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private int m_createNum;
		public ShootingEnemyCharacter m_taskObject;
	}
}
