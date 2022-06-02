using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class ListSortButtonGroup : LayoutUGUIScriptBase
	{
		public enum SortOrder
		{
			Small = 0,
			Big = 1,
		}

		[SerializeField]
		private ActionButton m_sortListButton;
		[SerializeField]
		private ActionButton m_sortUpDownChangeButton;
		[SerializeField]
		private ActionButton m_limitOverListButton;
		[SerializeField]
		private ToggleButtonGroup m_toggleGroup;
		[SerializeField]
		private ToggleButton[] m_bonusToggleButtons;
		[SerializeField]
		private RawImageEx m_sortItemText;
		[SerializeField]
		private RawImageEx m_updownText;
		[SerializeField]
		private ListSortEvent m_onListSortEvent;
		[SerializeField]
		private UnityEvent m_onLimitOverListEvent;
		[SerializeField]
		private PopupSortMenu.SortPlace m_sortPlace;
		[SerializeField]
		private bool m_useSortFontExtendTexture;
	}
}
