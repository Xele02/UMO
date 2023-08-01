using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigOther_02 : LayoutPopupConfigBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}

		public override int GetContentsHeight()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
			return 0;
		}

		public override bool IsShow()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
			return false;
		}
		[SerializeField]
		private Text m_title;
		[SerializeField]
		private Text m_desc2;
		[SerializeField]
		private Text m_desc4;
		[SerializeField]
		private ToggleButtonGroup m_toggleGroup;
	}
}
