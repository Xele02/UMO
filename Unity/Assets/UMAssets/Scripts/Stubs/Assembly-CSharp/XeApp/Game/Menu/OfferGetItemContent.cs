using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class OfferGetItemContent : SwapScrollListContent
	{
		[SerializeField]
		private RawImageEx m_itemIcon;
		[SerializeField]
		private Text m_itemNum;
		[SerializeField]
		private RawImageEx[] imageRarityFrame;
		[SerializeField]
		private RawImageEx[] imageitem;
		[SerializeField]
		private Text[] textCounts;
		[SerializeField]
		private Text[] textBonus;
		[SerializeField]
		private ActionButton m_ItemDetailsButton;
	}
}
