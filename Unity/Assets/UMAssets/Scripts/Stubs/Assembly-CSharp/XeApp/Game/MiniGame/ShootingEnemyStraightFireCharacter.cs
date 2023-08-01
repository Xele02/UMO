using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyStraightFireCharacter : ShootingEnemyCharacter
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private float m_readyPos;
		[SerializeField]
		private int m_fireCountMax;
		[SerializeField]
		private float m_fireTimeMax;
	}
}
