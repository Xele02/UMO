using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class LayoutLoginBonusMonthlyPass : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
		[SerializeField]
		private Text[] m_textRarityUpGet;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private NumberBase m_numberRemain;
		[SerializeField]
		private ActionButton m_buttonAbout;
		[SerializeField]
		private ActionButton[] m_buttonClose;
		[SerializeField]
		private List<LayoutLoginBonusMonthlyPassItemButton> m_buttonItems;
		[SerializeField]
		private LayoutLoginBonusMonthlyPassItemButton m_buttonNextItem;
	}
}
