using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupShopSetItem : SwapScrollListContent
	{
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textNum;
		[SerializeField]
		private RawImageEx m_imageItem;
		[SerializeField]
		private StayButton m_button;
	}
}
