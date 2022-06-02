using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutQuestList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private ActionButton m_buttonReceiveAll;
		[SerializeField]
		private RawImageEx m_imageFont;
		[SerializeField]
		private Text m_textTime;
		[SerializeField]
		private Text m_textNoneText;
		[SerializeField]
		private Text m_textReceiveDesc;
	}
}
