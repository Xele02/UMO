using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupDivaSkillInfoItem : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_level;
		[SerializeField]
		private NumberBase m_nowExp;
		[SerializeField]
		private NumberBase m_maxExp;
		[SerializeField]
		private Text m_divaName;
		[SerializeField]
		private Text m_unlockText;
		[SerializeField]
		private GameObject m_divaIcon;
		[SerializeField]
		private ActionButton m_conditionsButton;
		[SerializeField]
		private NumberBase m_levelLock;
	}
}
