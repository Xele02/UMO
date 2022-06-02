using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class RaidBossInfoLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_bossNameText;
		[SerializeField]
		private Text m_missionText;
		[SerializeField]
		private Text m_freePlayText;
		[SerializeField]
		private NumberBase m_bossNum;
		[SerializeField]
		private NumberBase m_songBonusNum;
		[SerializeField]
		private List<RawImageEx> m_logoImages;
	}
}
