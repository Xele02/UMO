using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationVisitButton : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton m_sortButton;
		[SerializeField]
		private ActionButton m_sortOrderButton;
		[SerializeField]
		private ActionButton m_memberReloadButton;
		[SerializeField]
		private RawImageEx m_sortImage;
	}
}
