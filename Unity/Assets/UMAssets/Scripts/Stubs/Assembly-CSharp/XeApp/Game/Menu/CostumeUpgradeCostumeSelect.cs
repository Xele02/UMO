using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class CostumeUpgradeCostumeSelect : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_divaSelectButton;
		[SerializeField]
		private ActionButton m_checkRewardButton;
		[SerializeField]
		private ActionButton m_useItemButton;
		[SerializeField]
		private ActionButton m_rankUpUnlockButton;
		[SerializeField]
		private ActionButton m_conditionCheckButton;
		[SerializeField]
		private ActionButton m_leftArrowButton;
		[SerializeField]
		private ActionButton m_rightArrowButton;
		[SerializeField]
		private ActionButton m_itemDetailButton;
		[SerializeField]
		private List<CostumeUpgradeCostumeButton> m_costumeButton;
		[SerializeField]
		public CostumeUpgradeSelectScroller m_scroller;
		public bool isPrevCostumeSelect;
	}
}
