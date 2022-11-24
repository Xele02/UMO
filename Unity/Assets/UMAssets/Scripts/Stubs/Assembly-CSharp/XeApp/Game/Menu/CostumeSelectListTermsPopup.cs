using XeSys.Gfx;
using UnityEngine.UI;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CostumeSelectListTermsPopup : LayoutUGUIScriptBase, IPopupContent
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

		public Text m_text;
		public RawImageEx m_image_diva_cos;
		public RawImageEx m_image_ul_cos_plate;

		public Transform Parent => null; //throw new System.NotImplementedException();
	}
}
