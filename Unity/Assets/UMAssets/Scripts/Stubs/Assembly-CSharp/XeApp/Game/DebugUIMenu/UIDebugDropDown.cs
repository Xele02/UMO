using UnityEngine.UI;
using UnityEngine.Events;

namespace XeApp.Game.DebugUIMenu
{
	public class UIDebugDropDown : Dropdown
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		public UnityEvent OnShowList;
	}
}
