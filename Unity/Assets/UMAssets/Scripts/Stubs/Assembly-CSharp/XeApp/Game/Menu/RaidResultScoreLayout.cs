using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class RaidResultScoreLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_scorePointText;
		[SerializeField]
		private Text m_valkyriePointText;
		[SerializeField]
		private Text m_pointBonusText;
		[SerializeField]
		private Text m_divaBonusText;
		[SerializeField]
		private Text m_supportBonusText;
		[SerializeField]
		private Text m_totalPointText;
		[SerializeField]
		private Text m_damageText;
		[SerializeField]
		private Text m_missionText;
		[SerializeField]
		private NumberBase m_supportBonusNum;
		[SerializeField]
		private NumberBase m_singBonusNum;
		[SerializeField]
		private NumberBase m_missionBonusNum;
	}
}
