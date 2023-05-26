using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutPopupConfigDetailSLive : LayoutPopupConfigDetailBase
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}

		public override void SetStatus()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}

		public override void SetTextTitle(string text)
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}

		public override void SetTextOher3D(string text)
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}

		public override void SetToggleButtonOher3DEnable(int index)
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}

		public override void SetTextDescDiva3D(string text)
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}

		public override void SetToggleButtonDiva3DEnable(int index)
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}

		[SerializeField]
		private Text m_title;
		[SerializeField]
		private Text m_descDiva3d;
		[SerializeField]
		private Text m_descOher3d;
		[SerializeField]
		private ToggleButtonGroup m_toggleGroupDiva3d;
		[SerializeField]
		private ToggleButtonGroup m_toggleGroupOher3d;
		[SerializeField]
		private ActionButton m_defaultButton;
	}
}
