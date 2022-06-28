using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSentGiftContent : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx m_itemImage;
		[SerializeField]
		private StayButton m_button;
		[SerializeField]
		private Text m_message;
		[SerializeField]
		private Text m_resultMessage;
	}
}
