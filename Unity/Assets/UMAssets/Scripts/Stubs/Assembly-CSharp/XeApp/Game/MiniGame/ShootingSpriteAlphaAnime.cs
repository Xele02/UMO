using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingSpriteAlphaAnime : MonoBehaviour
	{
		public enum StartType
		{
			Show = 0,
			Hide = 1,
		}

		[SerializeField]
		protected StartType m_startAlpha;
		[SerializeField]
		private SpriteRenderer[] m_spriteRenderer;
		[SerializeField]
		private float m_animTimMax;
		[SerializeField]
		private float m_blinkingTimeMax;
	}
}
