using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupExBattleScoreTotal : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_totalScore;
		[SerializeField]
		private Text m_rank;
		[SerializeField]
		private ActionButton m_schedule;
		[SerializeField]
		private ActionButton m_OKButton;
		[SerializeField]
		private ExBattleScoreContents[] m_musicRecordList;
	}
}
