using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutQuestComplete : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private NumberBase m_mol;
		[SerializeField]
		private NumberBase m_den;
		[SerializeField]
		private NumberBase m_itemNum;
		[SerializeField]
		private RawImageEx m_iconImage;
	}
}
