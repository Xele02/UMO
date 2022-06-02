using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutBingoRewardSelect : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutBingoRewardSelectScroll m_scroll;
		[SerializeField]
		private List<BingoRewardContents> contentList;
		[SerializeField]
		private ActionButton SelectButton;
		[SerializeField]
		private List<BingoRewardSelectButton> m_sideButton;
		[SerializeField]
		private Text Desc1Text;
		[SerializeField]
		private Text Desc2Text;
		[SerializeField]
		private Text Desc3Text;
		[SerializeField]
		private Text RewardCountText;
	}
}
