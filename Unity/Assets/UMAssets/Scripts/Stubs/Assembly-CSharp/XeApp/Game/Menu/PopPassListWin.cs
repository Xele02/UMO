using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopPassListWin : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ScrollRect m_scrollRect;
		[SerializeField]
		private ActionButton m_btn_law_1;
		[SerializeField]
		private ActionButton m_btn_law_2;
		[SerializeField]
		private ActionButton m_btn_cancel;
		[SerializeField]
		private ActionButton m_btn_buy;
		[SerializeField]
		private ActionButton m_btn_agre;
		[SerializeField]
		private Text m_text_title;
		[SerializeField]
		private Text m_text_money;
	}
}
