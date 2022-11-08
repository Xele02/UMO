using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugTipsMenu : DebugCheatUIBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private Toggle m_toggle;
	}
}
