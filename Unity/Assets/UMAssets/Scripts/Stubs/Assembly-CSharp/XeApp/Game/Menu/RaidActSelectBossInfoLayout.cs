using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RaidActSelectBossInfoLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_bossNameText;
		[SerializeField]
		private NumberBase m_joinNum;
		[SerializeField]
		private NumberBase m_assistBonusNum;
		[SerializeField]
		private NumberBase m_bossHpNum;
	}
}
