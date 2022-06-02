using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_UnitLive : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private Text[] m_btn_text;
		[SerializeField]
		private Image[] m_btn_image;
	}
}
