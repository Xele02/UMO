using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupSnsInheritingSetting : LayoutPopupSnsSetting
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		[SerializeField]
		private ActionButton m_button;
	}
}
