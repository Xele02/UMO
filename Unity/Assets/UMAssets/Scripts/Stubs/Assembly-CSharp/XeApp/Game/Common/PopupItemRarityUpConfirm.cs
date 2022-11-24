using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupItemRarityUpConfirm : LayoutUGUIScriptBase, IPopupContent
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }

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
		private RawImageEx m_imageBefore;
		[SerializeField]
		private RawImageEx m_imageAfter;
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textDesc;

		public Transform Parent => null; //throw new System.NotImplementedException();
	}
}
