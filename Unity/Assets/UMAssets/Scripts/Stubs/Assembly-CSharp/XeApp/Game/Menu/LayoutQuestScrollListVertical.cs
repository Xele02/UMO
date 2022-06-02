using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutQuestScrollListVertical : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private ActionButton m_buttonReceiveAll;
		[SerializeField]
		private Text m_textReceiveDesc;
	}
}
