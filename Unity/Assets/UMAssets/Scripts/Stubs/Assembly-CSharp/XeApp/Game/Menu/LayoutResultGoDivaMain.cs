using UnityEngine;

namespace XeApp.Game.Menu
{
	internal class LayoutResultGoDivaMain : MonoBehaviour
	{
		public GoDivaPointResultLayoutController m_pointResultLayoutController;
		public GoDivaGrowResultLayoutController m_growResultLayoutController;
		public GoDivaResultBalloonLayoutController m_balloonLayoutController;
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement Monobehaviour");
		}
	}
}
