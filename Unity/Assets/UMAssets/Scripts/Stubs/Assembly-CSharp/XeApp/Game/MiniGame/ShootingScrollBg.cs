using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingScrollBg : ShootingTask
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private SpriteRenderer m_sprite;
		[SerializeField]
		private float m_speed;
	}
}
