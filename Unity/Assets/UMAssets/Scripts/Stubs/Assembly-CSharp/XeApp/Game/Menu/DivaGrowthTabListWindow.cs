using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class DivaGrowthTabListWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton[] m_tabButtons;
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private RawImageEx[] m_logImages;
		[SerializeField]
		private OnDivaGrowthPushTabActionEvent m_onPushTabActionEvent;
		[SerializeField]
		private Text m_noClearText;
	}
}
