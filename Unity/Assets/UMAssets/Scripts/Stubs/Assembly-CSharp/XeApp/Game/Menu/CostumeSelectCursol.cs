using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class CostumeSelectCursol : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_up_btn;
		[SerializeField]
		private ActionButton m_down_btn;
		[SerializeField]
		private ActionButton m_ok_btn;
		[SerializeField]
		private int UP_DOWN_ANIM_FRAME;
		[SerializeField]
		private int UP_DOWN_ANIM_TIME;
		[SerializeField]
		private List<ActionButton> m_color_change_btn;
		public List<int> m_costume_color_index;
	}
}
