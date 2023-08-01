using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyLaserCharacte : ShootingEnemyCharacter
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private float m_readyLength;
		[SerializeField]
		private int m_fireCountMax;
		[SerializeField]
		private float m_fireTimeMax;
		[SerializeField]
		private float m_setFireDirTimeMax;
	}
}
