using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutResultPopupGoDivaLevelup : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_textBeforeValue;
		[SerializeField]
		private Text m_textAfterValue;
		[SerializeField]
		private Text m_textBeforeLevel;
		[SerializeField]
		private Text m_textAfterLevel;
	}
}
