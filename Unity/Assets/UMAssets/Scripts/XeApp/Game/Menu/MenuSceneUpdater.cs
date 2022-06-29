using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MenuSceneUpdater : MonoBehaviour
	{
		public delegate void MenuUpdate();

		public MenuUpdate updater; // 0xC

		// RVA: 0xB4225C Offset: 0xB4225C VA: 0xB4225C
		private void Update()
		{
			if(updater != null)
				updater();
		}
	}
}
