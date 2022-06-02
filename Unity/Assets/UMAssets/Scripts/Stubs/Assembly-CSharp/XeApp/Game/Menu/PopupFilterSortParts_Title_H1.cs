using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortParts_Title_H1 : PopupFilterSortPartsBase
	{
		[SerializeField]
		private Text m_title_text;
		[SerializeField]
		private ActionButton[] m_btn;
		[SerializeField]
		private Text[] m_btn_text;
	}
}
