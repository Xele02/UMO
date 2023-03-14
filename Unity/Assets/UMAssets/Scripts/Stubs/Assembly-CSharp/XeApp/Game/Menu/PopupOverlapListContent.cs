using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupOverlapListContent : LayoutUGUIScriptBase, IPopupContent
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }

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
		private LayoutUGUIRuntime m_runtime;
		[SerializeField]
		private ScrollRect[] m_scrollRect;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private Text m_textLimit;

		public Transform Parent => null; //throw new System.NotImplementedException();
	}
}
