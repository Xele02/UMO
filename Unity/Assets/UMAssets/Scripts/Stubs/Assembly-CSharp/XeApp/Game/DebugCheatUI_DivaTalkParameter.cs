using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugCheatUI_DivaTalkParameter : DebugCheatUIBase
	{
		[SerializeField]
		private Text m_divaStats;
		[SerializeField]
		private Text m_divaMotionStats;
		[SerializeField]
		private Text m_divaTalkStats;
		[SerializeField]
		private Dropdown m_autoTalk_Dropdown;
		[SerializeField]
		private Button m_autoTalk_IntervalButton;
		[SerializeField]
		private Dropdown m_touchReaction_Dropdown;
	}
}
