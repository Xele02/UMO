using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class RaidActSelectPanel : LayoutUGUIScriptBase
	{
		public enum PanelType
		{
			PanelRight = 0,
			PanelLeft = 1,
		}

		[SerializeField]
		private PanelType m_panelType;
		[SerializeField]
		private RaidActPlayButton m_playButton;
		[SerializeField]
		private Transform m_downloadInfo;
		[SerializeField]
		private ButtonBase m_panelButton;
		[SerializeField]
		private NumberBase m_bonusNum;
		[SerializeField]
		private NumberBase m_apCostNum;
		[SerializeField]
		private Text m_textDesc;
	}
}
