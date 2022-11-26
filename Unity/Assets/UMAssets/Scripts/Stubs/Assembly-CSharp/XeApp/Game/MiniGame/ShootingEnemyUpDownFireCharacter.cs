using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyUpDownFireCharacter : ShootingEnemyCharacter
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private float m_fireLenght;
		[SerializeField]
		private float m_radius;
		[SerializeField]
		private float m_angleSpeed;
	}
}
