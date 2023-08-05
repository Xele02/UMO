using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutPopupItemGet : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text m_ItemName;
		[SerializeField]
		private Text m_ItemContent;
		[SerializeField]
		private RawImageEx m_imageItem;
	}
}
