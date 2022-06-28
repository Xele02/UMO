using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationStorageWindow : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private SwapScrollList m_swapScrollList;
		[SerializeField]
		private Text m_titleText;
		[SerializeField]
		private Text m_numberText;
		[SerializeField]
		private Text m_nothingText;
	}
}
