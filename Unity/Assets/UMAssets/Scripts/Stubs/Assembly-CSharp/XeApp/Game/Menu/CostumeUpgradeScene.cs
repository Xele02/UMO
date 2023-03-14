using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CostumeUpgradeScene : TransitionRoot
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private CharTouchHitCheck m_charTouch;
	}
}
