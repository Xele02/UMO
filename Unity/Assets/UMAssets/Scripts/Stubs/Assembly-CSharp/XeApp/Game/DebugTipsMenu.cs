using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugTipsMenu : DebugCheatUIBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Toggle m_toggle;
	}
}
