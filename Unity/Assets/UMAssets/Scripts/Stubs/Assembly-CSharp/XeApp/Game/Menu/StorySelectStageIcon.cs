using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class StorySelectStageIcon : LayoutUGUIScriptBase
	{
		[SerializeField]
		private bool m_is_large;
		[SerializeField]
		private RawImageEx m_jacket;
		[SerializeField]
		private ActionButton m_action_btn;
		[SerializeField]
		private GameObject m_newPos;
		[SerializeField]
		private RawImageEx[] m_stamp;
		[SerializeField]
		private RawImage m_noizeImage;
	}
}
