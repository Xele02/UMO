using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class CbtWindow : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx m_image;
		[SerializeField]
		private ActionButton m_btn;
	}
}
