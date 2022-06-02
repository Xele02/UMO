using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class OfferSelectList : LayoutUGUIScriptBase
	{
		public enum OfferSelectTab
		{
			DivaTab = 0,
			WeeklyTab = 1,
			DaylyTab = 2,
			DebutTab = 3,
			MAX = 4,
		}

		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport;
		[SerializeField]
		private Text[] m_times;
		[SerializeField]
		private Text nonListItemtext;
		[SerializeField]
		private ActionButton[] operationTabList;
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private Transform ListContent;
		[SerializeField]
		private NumberBase m_MaxDebutNum;
		[SerializeField]
		private NumberBase m_ClearDebutNum;
		[SerializeField]
		private GameObject m_scrollBar;
		public OfferSelectTab SelectTab;
		public bool IsExitBefore;
	}
}
