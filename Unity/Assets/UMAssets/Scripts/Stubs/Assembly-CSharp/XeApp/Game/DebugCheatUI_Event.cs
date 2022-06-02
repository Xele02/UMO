using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game
{
	public class DebugCheatUI_Event : DebugCheatUIBase
	{
		[SerializeField]
		private InputField inputField_Point;
		[SerializeField]
		private InputField inputField_Ticket;
		[SerializeField]
		private InputField inputField_RankingEnd;
		[SerializeField]
		private InputField inputField_QuestForce;
		[SerializeField]
		private InputField inputField_ForceRank;
		[SerializeField]
		private InputField inputField_ForceScore;
		[SerializeField]
		private Button button_Reset;
		[SerializeField]
		private Button button_Logbo;
		[SerializeField]
		private Text text_Name;
		[SerializeField]
		private bool scoreRanking;
		[SerializeField]
		private InputField inputField_Gnum;
		[SerializeField]
		private InputField inputField_Cwin;
		[SerializeField]
		private InputField inputField_BattleClass;
		[SerializeField]
		private InputField inputField_ExGaugePoint;
		[SerializeField]
		private DebugCheatUI_EventGoDiva eventGoDiva;
	}
}
