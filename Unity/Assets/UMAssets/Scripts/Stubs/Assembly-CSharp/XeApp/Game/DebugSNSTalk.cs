using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugSNSTalk : DebugCheatUIBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_isSaveFlagText;
		[SerializeField]
		private Text m_allText;
	}
}
