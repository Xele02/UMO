using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingScrollBg : ShootingTask
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private SpriteRenderer m_sprite;
		[SerializeField]
		private float m_speed;
	}
}
