using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigBattleEvent : LayoutPopupConfigBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}

		public override int GetContentsHeight()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
			return 0;
		}

		public override bool IsShow()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
			return false;
		}

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
