using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class EventStoryWindowLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private EventStorySeriestabLayout m_mcrs_tab_btn;
		[SerializeField]
		private EventStorySeriestabLayout m_mcrs_seven_tab_btn;
		[SerializeField]
		private EventStorySeriestabLayout m_mcrs_frontier_tab_btn;
		[SerializeField]
		private EventStorySeriestabLayout m_mcrs_delta_tab_btn;
		[SerializeField]
		private EventStorySeriestabLayout m_other_tab_btn;
		[SerializeField]
		private EventStorySeriestabLayout m_plate_tab_btn;
		[SerializeField]
		private ActionButton m_close_btn;
		[SerializeField]
		private Text m_title_text;
		[SerializeField]
		private SwapScrollList m_scrollList;
	}
}
