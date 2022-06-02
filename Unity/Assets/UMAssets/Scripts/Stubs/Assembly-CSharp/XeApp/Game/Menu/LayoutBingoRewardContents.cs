using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutBingoRewardContents : SwapScrollListContent
	{
		[SerializeField]
		private Text BingoCountText;
		[SerializeField]
		private Text ItemNameText;
		[SerializeField]
		private Text ItemCountText;
		[SerializeField]
		private RawImageEx ItemIcon;
		[SerializeField]
		private ActionButton m_button;
		[SerializeField]
		private RawImageEx Fr03;
		[SerializeField]
		private RawImageEx Fr02;
	}
}
