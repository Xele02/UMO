using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingItem : ShootingTask
	{
		[SerializeField]
		private ShootingStageData.StageItemType m_itemType;
		[SerializeField]
		protected ShootingCollision m_collision;
		[SerializeField]
		protected SpriteRendererAnime m_spriteAnim;
		[SerializeField]
		protected float m_speed;
		[SerializeField]
		protected int m_score;
	}
}
