using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class PopupItemList : LayoutUGUIScriptBase, IPopupContent
	{
		public Transform Parent => null; //throw new System.NotImplementedException();

		public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }

		public void CallOpenEnd()
		{
			//throw new System.NotImplementedException();
		}

		public void Hide()
		{
			//throw new System.NotImplementedException();
		}

		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			//throw new System.NotImplementedException();
		}

		public bool IsReady()
		{
			//throw new System.NotImplementedException();
			return true;
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
	}
}
