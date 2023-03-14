using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferSelectController : MonoBehaviour
	{
		public OfferHaveItemCheck ItemCheck;
		public float MOTION_WAIT_TIME;
		public bool IsLayoutAssetLoad;
		public bool IsGoToHome;
		public bool IsOrderInduction;
		private void Awake()
		{
			TodoLogger.Log(0, "Implement Monobehaviour");
		}
	}
}
