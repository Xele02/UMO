using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferFormationScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private OfferFormationController m_offerFormationController;
		public int SelectSeries;
		public int Select;
	}
}
