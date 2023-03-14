using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigOther_02 : LayoutPopupConfigBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
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
