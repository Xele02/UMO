using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvItemContent : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_itemImage;
		[SerializeField]
		private Text m_itemCountText;
		[SerializeField]
		private RawImageEx[] m_itemFrame;
		[SerializeField]
		private ActionButton m_ItemDetailsButton;
	}
}
