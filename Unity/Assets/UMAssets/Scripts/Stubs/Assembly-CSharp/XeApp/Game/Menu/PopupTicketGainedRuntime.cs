using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupTicketGainedRuntime : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_textTitle;
		[SerializeField]
		private Text m_textLabel01;
		[SerializeField]
		private Text m_textLabel02;
		[SerializeField]
		private RawImageEx m_itemImage;
	}
}
