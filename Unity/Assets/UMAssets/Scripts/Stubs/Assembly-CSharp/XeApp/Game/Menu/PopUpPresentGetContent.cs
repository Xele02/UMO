using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopUpPresentGetContent : UIBehaviour, IPopupContent, ILayoutUGUIPaste
	{
		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
		public Transform Parent => null; //throw new System.NotImplementedException();

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

		public bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			//throw new System.NotImplementedException();
			return true;
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
