using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingPlayerCharacter : ShootingTask
	{
		[SerializeField]
		private ShootingPlayerHpLayout m_hpLayout;
		[SerializeField]
		private SpriteRenderer m_playerRenderer;
		[SerializeField]
		private ShootingCollision m_collision;
		[SerializeField]
		public float m_speed;
		[SerializeField]
		private float m_fireTimeMax;
		[SerializeField]
		private float m_invincibleTimeMax;
		[SerializeField]
		private float m_damegeMoveTime;
		[SerializeField]
		private float m_damegeEntryTimeMax;
		[SerializeField]
		private int m_hpMax;
		[SerializeField]
		private int m_hpSecretMax;
		[SerializeField]
		private float m_startEntryTimeMax;
		[SerializeField]
		private float[] m_spreadBulletAngle;
	}
}
