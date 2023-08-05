using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupLimitOverListContent : LayoutUGUIScriptBase, IPopupContent
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			//throw new System.NotImplementedException();
		}

		public bool IsScrollable()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public void Show()
		{
			//throw new System.NotImplementedException();
		}

		public void Hide()
		{
			//throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			//throw new System.NotImplementedException();
			return true;
		}

		public void CallOpenEnd()
		{
			//throw new System.NotImplementedException();
		}

		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private Text m_textTotal;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private RawImageEx m_imgSortUpDown;
		[SerializeField]
		private ActionButton m_btnSortUpDown;

		public Transform Parent => null; //throw new System.NotImplementedException();
	}
}
