using UnityEngine.EventSystems;
using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupUnitSaveListContent : UIBehaviour
	{
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport;
		[SerializeField]
		private LayoutUGUIRuntime[] m_runtimes;
		[SerializeField]
		private ShowSaveUnitDetailsEvent m_onSaveUnitDetailsEvent;
		[SerializeField]
		private UnitSaveLoadPanel[] m_scrollPanels;
	}
}
