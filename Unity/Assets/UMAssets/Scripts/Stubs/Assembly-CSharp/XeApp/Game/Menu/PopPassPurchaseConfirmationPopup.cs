using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopPassPurchaseConfirmationPopup : LayoutUGUIScriptBase
	{
		public enum Result
		{
			None = 0,
			Cancel = 1,
			Error = 2,
			Buy = 3,
			Close = 4,
		}

		[SerializeField]
		public ActionButton m_btn_agre;
		[SerializeField]
		public ActionButton m_btn_buy;
		[SerializeField]
		public ActionButton m_btn_cancel;
		[SerializeField]
		public ToggleButton m_btn_check;
		[SerializeField]
		public Text m_text_title;
		[SerializeField]
		public Text m_text_01;
		[SerializeField]
		public Text m_text_02;
		[SerializeField]
		public Text m_text_03;
		[SerializeField]
		public RawImageEx m_image_button;
		public Result m_result;
		public NHPDPKHMFEP.GGNEBJEIFCP m_plan;
	}
}
