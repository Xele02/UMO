using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RaidActSelectLaneButton : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private ActionButton[] m_buttons;
		[SerializeField]
		private RawImageEx[] m_frameImages;
		[SerializeField]
		private RawImageEx[] m_textImages;
		[SerializeField]
		private RawImageEx[] m_bgImages;
		[SerializeField]
		private NumberBase m_unlockNumber;
	}
}
