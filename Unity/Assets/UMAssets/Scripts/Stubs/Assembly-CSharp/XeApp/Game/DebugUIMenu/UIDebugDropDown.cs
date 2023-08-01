using UnityEngine.UI;
using UnityEngine.Events;

namespace XeApp.Game.DebugUIMenu
{
	public class UIDebugDropDown : Dropdown
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public UnityEvent OnShowList;
	}
}
