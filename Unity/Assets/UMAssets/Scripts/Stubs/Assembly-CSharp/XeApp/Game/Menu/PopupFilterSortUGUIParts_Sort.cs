using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_Sort : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private int m_columnCount;
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private Text[] m_text;
		[SerializeField]
		private Text[] m_text_wide;
	}
}
