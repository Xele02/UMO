using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyStraightPlayerFireCharacter : ShootingEnemyCharacter
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private int m_fireCountMax;
		[SerializeField]
		private float m_fireTimeMax;
	}
}
