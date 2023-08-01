using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyStraightPlayerFireCharacter : ShootingEnemyCharacter
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private int m_fireCountMax;
		[SerializeField]
		private float m_fireTimeMax;
	}
}
