using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutNotReceiveItem : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Text DescText;
		[SerializeField]
		private Text ItemText;
		[SerializeField]
		private RawImageEx ItemImage;
	}
}
