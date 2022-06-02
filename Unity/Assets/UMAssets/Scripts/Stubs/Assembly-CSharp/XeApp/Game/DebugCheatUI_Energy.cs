using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugCheatUI_Energy : DebugCheatUIBase
	{
		[SerializeField]
		private Text info_text;
		[SerializeField]
		private Text result_text;
		[SerializeField]
		private Button button_heal_1;
		[SerializeField]
		private Button button_heal_10;
		[SerializeField]
		private Button button_heal_max;
		[SerializeField]
		private Button button_consume_1;
		[SerializeField]
		private Button button_consume_10;
	}
}
