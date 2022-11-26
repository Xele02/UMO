using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingEffect : ShootingTask
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private EffectId m_effectId;
		[SerializeField]
		protected SpriteRendererAnime m_spriteAnim;
	}
}
