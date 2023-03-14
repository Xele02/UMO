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
		[SerializeField]
		private ToggleButton[] m_toggleButtons;
	}
}
