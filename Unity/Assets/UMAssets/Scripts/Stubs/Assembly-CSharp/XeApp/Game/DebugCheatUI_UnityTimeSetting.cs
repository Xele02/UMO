using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugCheatUI_UnityTimeSetting : DebugCheatUIBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Dropdown m_fpsDropdown;
	}
}
