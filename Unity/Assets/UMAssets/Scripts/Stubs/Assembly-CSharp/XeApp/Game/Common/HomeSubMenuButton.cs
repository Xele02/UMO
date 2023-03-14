using UnityEngine;

namespace XeApp.Game.Common
{
	public class HomeSubMenuButton : UGUIButton
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private GameObject badgeIcon;
	}
}
