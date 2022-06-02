using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LobbyFooterTransButtonLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_preRaidButton;
		[SerializeField]
		private ActionButton m_RaidButton;
		[SerializeField]
		private ActionButton m_missionButton;
		[SerializeField]
		private ActionButton m_cannonGaugeButton;
		[SerializeField]
		private NumberBase m_foldRadarNum;
		[SerializeField]
		private Text m_dayText;
		[SerializeField]
		private Text m_BossContText;
	}
}
