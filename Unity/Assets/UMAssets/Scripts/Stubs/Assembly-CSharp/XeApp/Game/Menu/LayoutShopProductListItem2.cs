using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutShopProductListItem2 : LayoutShopListElemBase
	{
		[SerializeField]
		private Text m_textName;
		[SerializeField]
		private Text m_textRemain;
		[SerializeField]
		private Text m_textOwn;
		[SerializeField]
		private Text m_textCost;
		[SerializeField]
		private Text m_textCost2;
		[SerializeField]
		private Text m_textWarning;
		[SerializeField]
		private RawImageEx[] m_imageItem;
		[SerializeField]
		private ActionButton m_button;
		[SerializeField]
		private ActionButton m_buttonItem;
	}
}
