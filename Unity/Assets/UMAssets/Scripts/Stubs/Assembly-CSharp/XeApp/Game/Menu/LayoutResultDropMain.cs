using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutResultDropMain : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		public float nextItemMoveSec;
		public float backItemMoveSec;
		[SerializeField]
		public float itemBonusCountupSec;
	}
}
