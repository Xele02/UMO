using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyTrackingCharacter : ShootingEnemyCharacter
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private int m_angleLimit;
		[SerializeField]
		private float m_angleElapsedTimeMax;
		[SerializeField]
		private float m_trackingTimeMax;
	}
}
