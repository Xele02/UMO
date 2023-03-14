using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferSelectScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private CharTouchHitCheck hitCheckPanel;
	}
}
