using XeApp.Game.Common;
using UnityEngine;
using XeSys.Gfx;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSpItemListPopup : FlexibleListItemLayout
	{
		[SerializeField]
		private ActionButton m_itemButton;
		[SerializeField]
		private RawImageEx m_itemImage;
		[SerializeField]
		private Text m_nameText;
		[SerializeField]
		private Text m_numText;
	}
}
