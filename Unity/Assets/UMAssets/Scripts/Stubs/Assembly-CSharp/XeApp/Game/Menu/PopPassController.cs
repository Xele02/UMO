using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopPassController : MonoBehaviour
	{
		public enum Result
		{
			None = 0,
			Buy = 1,
			Close = 2,
			Error = 3,
		}

		public Result m_result;
		public bool m_open_window;
		public NHPDPKHMFEP.GGNEBJEIFCP m_plan;
		public PopPassListWin m_layout_window;
		public PopPassPurchaseConfirmationPopup m_layout_popup;
	}
}
