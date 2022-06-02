using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class CostumeSelectListWin : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_swapScrollList;
		[SerializeField]
		private ScrollRect m_scrollRect;
		[SerializeField]
		private ActionButton m_btn_cos_change;
		[SerializeField]
		private ActionButton m_btn_cos_build;
		public int m_diva_id;
		public int m_index_set;
		public int m_index_try;
	}
}
