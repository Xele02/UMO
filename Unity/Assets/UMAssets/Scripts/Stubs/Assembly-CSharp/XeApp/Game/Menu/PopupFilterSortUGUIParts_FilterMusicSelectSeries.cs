using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterMusicSelectSeries : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIToggleButtonGroup m_btnGroup;
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private RawImageEx[] m_seriesImage;
	}
}
