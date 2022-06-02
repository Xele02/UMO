using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class EpisodeSceneIconCreater : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_swapScroll;
		[SerializeField]
		private ActionButton m_left_btn;
		[SerializeField]
		private ActionButton m_right_btn;
		[SerializeField]
		private RawImageEx m_left_btn_image;
		[SerializeField]
		private RawImageEx m_right_btn_image;
		[SerializeField]
		private Text m_text_empty;
	}
}
