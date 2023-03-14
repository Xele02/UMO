using UnityEngine;

namespace XeApp.Game.MiniGame
{
	public class ShootingFrameUIMainLayout : MonoBehaviour
	{
		[SerializeField]
		private ShootingPauseBotton m_pauseButton;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
