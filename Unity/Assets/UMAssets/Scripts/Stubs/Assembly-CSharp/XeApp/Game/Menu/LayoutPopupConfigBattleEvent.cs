using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigBattleEvent : LayoutPopupConfigBase
	{
		[SerializeField]
		private Text m_classDesc;
		[SerializeField]
		private Text m_classCaution;
		[SerializeField]
		private Text m_battleInfoDesc;
		[SerializeField]
		private Text m_battleInfoCaution;
		[SerializeField]
		private ActionButton m_buttonReSelect;
		[SerializeField]
		private ToggleButtonGroup m_toggleGroupBattleInfo;
	}
}
