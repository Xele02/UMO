using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_Skill : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		private UGUIToggleButton[] m_btn;
		[SerializeField]
		private Image[] m_image;
		[SerializeField]
		private Text[] m_text;
	}
}
