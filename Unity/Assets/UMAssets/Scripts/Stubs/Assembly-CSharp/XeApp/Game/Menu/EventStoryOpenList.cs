using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class EventStoryOpenList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_swapScrollList;
		[SerializeField]
		private RawImageEx m_logImage;
		[SerializeField]
		private Text m_message;
	}
}
