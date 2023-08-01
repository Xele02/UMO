using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferValkyrieSelectScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private ValkyrieSelectController m_valkyrieSelectController;
	}
}
