using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutShopProductListItem : LayoutShopListElemBase
	{
		[SerializeField]
		private Text m_textLimit;
		[SerializeField]
		private Text m_textReset;
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
		private Text m_textContainDecoSet;
		[SerializeField]
		private RawImageEx[] m_imageItem;
		[SerializeField]
		private ActionButton m_button;
		[SerializeField]
		private ActionButton m_buttonItem;
	}
}
