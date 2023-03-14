using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecoIntimacyMessage : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_textInfo;
		[SerializeField]
		private Text m_textInfoLocked;
		[SerializeField]
		private RawImageEx m_imageTipsWindow;
		[SerializeField]
		private RawImageEx m_imageTipsWindowLocked;
	}
}
