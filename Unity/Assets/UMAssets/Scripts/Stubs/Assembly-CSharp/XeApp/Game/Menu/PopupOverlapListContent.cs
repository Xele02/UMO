using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupOverlapListContent : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
		[SerializeField]
		private ScrollRect[] m_scrollRect;
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private Text m_textLimit;
	}
}
