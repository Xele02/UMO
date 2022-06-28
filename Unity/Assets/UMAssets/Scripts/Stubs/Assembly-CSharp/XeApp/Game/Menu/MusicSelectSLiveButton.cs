using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MusicSelectSLiveButton : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton button;
		[SerializeField]
		private RawImageEx imageBg;
		[SerializeField]
		private RawImageEx imageFont;
	}
}
