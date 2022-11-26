using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingBullet : ShootingTask
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private BulletId m_bulletId;
		[SerializeField]
		protected ShootingCollision m_collision;
		[SerializeField]
		protected SpriteRendererAnime m_spriteAnim;
		[SerializeField]
		protected float m_speed;
	}
}
