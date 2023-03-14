using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugCheatUI_LoginBonus : DebugCheatUIBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Dropdown m_dropdown;
	}
}
