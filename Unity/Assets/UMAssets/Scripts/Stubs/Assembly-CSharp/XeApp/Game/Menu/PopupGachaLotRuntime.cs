using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupGachaLotRuntime : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx m_holdLabelImage;
		[SerializeField]
		private Text m_messageText;
		[SerializeField]
		private Text m_holdCurrencyText;
		[SerializeField]
		private ActionButton m_legalDescButton;
	}
}
