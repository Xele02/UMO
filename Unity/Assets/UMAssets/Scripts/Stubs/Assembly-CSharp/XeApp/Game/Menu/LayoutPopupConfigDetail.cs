using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigDetail : LayoutPopupConfigDetailBase
	{
		[SerializeField]
		private Text m_title;
		[SerializeField]
		private Text m_descDiva3d;
		[SerializeField]
		private Text m_descOher3d;
		[SerializeField]
		private Text m_desc2d;
		[SerializeField]
		private ToggleButtonGroup m_toggleGroupDiva3d;
		[SerializeField]
		private ToggleButtonGroup m_toggleGroupOher3d;
		[SerializeField]
		private ToggleButtonGroup m_toggleGroup2d;
		[SerializeField]
		private ActionButton m_defaultButton;
	}
}
