using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyTrackingCharacter : ShootingEnemyCharacter
	{
		[SerializeField]
		private int m_angleLimit;
		[SerializeField]
		private float m_angleElapsedTimeMax;
		[SerializeField]
		private float m_trackingTimeMax;
	}
}
