using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class EpisodeSortBtn : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_btn_01;
		[SerializeField]
		private ActionButton m_btn_02;
		[SerializeField]
		private RawImageEx m_image_01;
		[SerializeField]
		private RawImageEx m_image_02;
		public SortItem m_sort;
		public int m_order;
	}
}
