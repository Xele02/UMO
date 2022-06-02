using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugCheatUI_PlayerRank : DebugCheatUIBase
	{
		[SerializeField]
		private Text text_rank_log;
		[SerializeField]
		private Text text_exp_log;
		[SerializeField]
		private Text text_log;
		[SerializeField]
		private Button button_rank_add_one;
		[SerializeField]
		private Button button_rank_add_ten;
		[SerializeField]
		private Button button_rank_subtract_one;
		[SerializeField]
		private Button button_rank_subtract_ten;
		[SerializeField]
		private Button button_rank_max;
		[SerializeField]
		private Button button_rank_one;
		[SerializeField]
		private Button button_exp_add_100;
		[SerializeField]
		private Button button_exp_add_10000;
		[SerializeField]
		private Button button_rank_save;
		[SerializeField]
		private InputField inputField_rank;
		[SerializeField]
		private Button button_rank_add_input_value;
		[SerializeField]
		private InputField inputField_exp;
		[SerializeField]
		private Button button_exp_add_input_value;
	}
}
