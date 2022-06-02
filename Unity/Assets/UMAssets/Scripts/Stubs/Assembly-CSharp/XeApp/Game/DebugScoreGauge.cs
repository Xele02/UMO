using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugScoreGauge : DebugCheatUIBase
	{
		[SerializeField]
		private Text _textArea;
		[SerializeField]
		private Button _resetButton;
	}
}
