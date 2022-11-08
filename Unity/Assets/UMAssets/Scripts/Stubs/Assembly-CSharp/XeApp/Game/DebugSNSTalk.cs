using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugSNSTalk : DebugCheatUIBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private Text m_isSaveFlagText;
		[SerializeField]
		private Text m_allText;
	}
}
