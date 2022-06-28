using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MenuButtonNewIcon : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private int m_iconId;
		[SerializeField]
		private RawImageEx m_iconImage;
	}
}
