using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyLaserCharacte : ShootingEnemyCharacter
	{
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
