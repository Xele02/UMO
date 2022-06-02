using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupLimitOverListContent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private Text m_textTotal;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private RawImageEx m_imgSortUpDown;
		[SerializeField]
		private ActionButton m_btnSortUpDown;
	}
}
