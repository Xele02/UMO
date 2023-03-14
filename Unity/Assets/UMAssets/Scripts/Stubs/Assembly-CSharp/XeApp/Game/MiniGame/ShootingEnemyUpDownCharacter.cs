using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyUpDownCharacter : ShootingEnemyCharacter
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private float m_radius;
		[SerializeField]
		private float m_angleSpeed;
	}
}
