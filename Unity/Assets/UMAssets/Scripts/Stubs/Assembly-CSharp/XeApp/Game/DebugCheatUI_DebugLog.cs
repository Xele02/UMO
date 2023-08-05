using UnityEngine.UI;

namespace XeApp.Game
{
	public class DebugCheatUI_DebugLog : DebugCheatUIBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		public Button m_button;
		public Text m_text;
		public ScrollRect m_scroll_rect;
	}
}
