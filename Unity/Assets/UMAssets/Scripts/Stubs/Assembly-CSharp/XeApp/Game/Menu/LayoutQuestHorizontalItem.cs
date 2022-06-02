using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutQuestHorizontalItem : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_bg;
		[SerializeField]
		private RawImageEx m_imageFont;
		[SerializeField]
		private Text m_time;
		[SerializeField]
		private Text m_count;
		[SerializeField]
		private Text m_next;
		[SerializeField]
		private ActionButton m_button;
	}
}
