using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferTransformationScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private CharTouchHitCheck m_hitCheck_1;
		[SerializeField]
		private CharTouchHitCheck m_hitCheck_2;
	}
}
