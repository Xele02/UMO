using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutOfferItemDetail : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text ItemNameText;
		[SerializeField]
		private Text ItemDetailText;
		[SerializeField]
		private RawImageEx ItemImage;
	}
}
