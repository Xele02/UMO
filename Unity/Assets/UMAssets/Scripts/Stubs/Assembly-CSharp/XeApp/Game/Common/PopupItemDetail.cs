using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupItemDetail : LayoutUGUIScriptBase, IPopupContent
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
		private RawImageEx m_itemIconImage;
		[SerializeField]
		private Text m_itemNameText;
		[SerializeField]
		private Text m_itemDescriptionText;
		[SerializeField]
		private Text m_decoSetCautionText;

		public Transform Parent => null; //throw new System.NotImplementedException();
	}
}
