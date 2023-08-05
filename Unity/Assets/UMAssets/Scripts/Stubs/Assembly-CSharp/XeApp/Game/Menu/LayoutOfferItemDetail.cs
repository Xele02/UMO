using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutOfferItemDetail : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text ItemNameText;
		[SerializeField]
		private Text ItemDetailText;
		[SerializeField]
		private RawImageEx ItemImage;
	}
}
