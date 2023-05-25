using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigOther_01 : LayoutPopupConfigBase
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
		private ToggleButton[] m_toggleButtons;
	}
}
