using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvBgLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		public ActionButton m_okButton;
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private GameObject m_scrollBar;
	}
}
