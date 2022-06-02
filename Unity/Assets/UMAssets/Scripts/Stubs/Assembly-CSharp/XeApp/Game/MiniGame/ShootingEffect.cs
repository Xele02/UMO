using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingEffect : ShootingTask
	{
		[SerializeField]
		private EffectId m_effectId;
		[SerializeField]
		protected SpriteRendererAnime m_spriteAnim;
	}
}
