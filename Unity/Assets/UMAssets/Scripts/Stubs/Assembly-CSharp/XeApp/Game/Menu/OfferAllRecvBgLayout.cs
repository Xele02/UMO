using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvBgLayout : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.LogError(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		public ActionButton m_okButton;
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private GameObject m_scrollBar;
	}
}
