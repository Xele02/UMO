using System;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingEnemyCharacter : ShootingTask
	{
		[Serializable]
		public class SpriteEnemyAnim
		{
			public SpriteRendererAnime[] spriteAnim;
			public SpriteRendererAnime damegeAnim;
		}

		[SerializeField]
		private ShootingStageData.StageEnemyType m_enemyType;
		[SerializeField]
		private ShootingStageData.StageItemType m_dropItemType;
		[SerializeField]
		protected ShootingCollision m_collision;
		[SerializeField]
		protected SpriteEnemyAnim[] m_anime;
		[SerializeField]
		private ShootingSpriteAlphaAnime m_damegeAlpha;
		[SerializeField]
		protected int m_deathScore;
		[SerializeField]
		protected int m_damegeScore;
		[SerializeField]
		protected int m_hpMax;
		[SerializeField]
		protected float m_speed;
	}
}
