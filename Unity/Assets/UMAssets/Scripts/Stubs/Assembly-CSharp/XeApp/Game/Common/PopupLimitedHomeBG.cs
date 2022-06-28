using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupLimitedHomeBG : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx m_image_00;
		[SerializeField]
		private Text m_text_00;
		[SerializeField]
		private Text m_text_01;
	}
}
