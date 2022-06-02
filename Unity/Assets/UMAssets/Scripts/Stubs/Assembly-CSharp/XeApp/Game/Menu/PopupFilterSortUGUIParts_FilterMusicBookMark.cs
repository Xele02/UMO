using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterMusicBookMark : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIToggleButtonGroup m_btnGroup;
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private Text[] m_text;
		[SerializeField]
		private Text[] m_text_wide;
	}
}
