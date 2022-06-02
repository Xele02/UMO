using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game
{
	[Serializable]
	public class DebugCheatUI_EventGoDiva : MonoBehaviour
	{
		[SerializeField]
		private List<InputField> inputField_DivaSoLv;
		[SerializeField]
		private List<InputField> inputField_DivaVoLv;
		[SerializeField]
		private List<InputField> inputField_DivaChLv;
		[SerializeField]
		private List<InputField> inputField_ExpSoNum;
		[SerializeField]
		private List<InputField> inputField_ExpVoNum;
		[SerializeField]
		private List<InputField> inputField_ExpChNum;
		[SerializeField]
		private InputField inputField_GetStatusExp;
		[SerializeField]
		private InputField inputField_BonusRate;
		[SerializeField]
		private InputField inputField_BonusItem;
		[SerializeField]
		private Dropdown dropdown_NormalBonus;
		[SerializeField]
		private Dropdown dropdown_DailyBonus;
		[SerializeField]
		private InputField inputField_DailyBonusNum;
		[SerializeField]
		private Button button_FeverReset;
		[SerializeField]
		private InputField inputField_RankingRank;
		[SerializeField]
		private Toggle toggel_RankingRank;
	}
}
