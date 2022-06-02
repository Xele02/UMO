using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_ExclusiveToggleButtons : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private int m_columnCount;
		[SerializeField]
		private UGUIToggleButtonGroup m_group;
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private Text[] m_text;
	}
}
