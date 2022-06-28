using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutIntimacyMessage : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_textInfo;
		[SerializeField]
		private Text m_textSerif;
		[SerializeField]
		private Text m_textTips;
		[SerializeField]
		private RawImageEx m_imageTipsWindow;
	}
}
