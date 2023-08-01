using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MenuButtonNewIcon : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private int m_iconId;
		[SerializeField]
		private RawImageEx m_iconImage;
	}
}
