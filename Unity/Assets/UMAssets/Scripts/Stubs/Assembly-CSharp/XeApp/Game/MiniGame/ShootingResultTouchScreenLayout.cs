using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.MiniGame
{
	public class ShootingResultTouchScreenLayout : MonoBehaviour
	{
		[SerializeField]
		private InOutAnime m_inOutAnim;
		[SerializeField]
		private SpriteAnime m_spriteAnime;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
