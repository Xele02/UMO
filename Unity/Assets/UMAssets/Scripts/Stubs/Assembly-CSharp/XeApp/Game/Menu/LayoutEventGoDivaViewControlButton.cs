using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaViewControlButton : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton m_ctrlButton;
		[SerializeField]
		private RawImageEx m_imageCtrlButton;
	}
}
