using UnityEngine.EventSystems;
using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupUnitSaveListContent : UIBehaviour, IPopupContent
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

		public Transform Parent => throw new System.NotImplementedException();

		public void CallOpenEnd()
		{
			throw new System.NotImplementedException();
		}

		public void Hide()
		{
			throw new System.NotImplementedException();
		}

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			throw new System.NotImplementedException();
		}

		public bool IsScrollable()
		{
			throw new System.NotImplementedException();
		}

		public void Show()
		{
			throw new System.NotImplementedException();
		}
	}
}
