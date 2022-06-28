using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidConfirmLayout : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private Button musicSelectBtn;
		[SerializeField]
		private Button musicPlayBtn;
		[SerializeField]
		private Text actionText;
		[SerializeField]
		private RawImageEx musicImage;
	}
}
