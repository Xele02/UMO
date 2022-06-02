using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingBullet : ShootingTask
	{
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
