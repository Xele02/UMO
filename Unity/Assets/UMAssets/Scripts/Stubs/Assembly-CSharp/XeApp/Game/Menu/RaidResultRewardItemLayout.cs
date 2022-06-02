using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class RaidResultRewardItemLayout : LayoutUGUIScriptBase
	{
		[Serializable]
		private class ItemCell
		{
			public RawImageEx[] itemImage;
			public NumberBase[] itemNum;
			public ActionButton[] itemIcon;
		}

		[SerializeField]
		private ItemCell mvpItemCell;
		[SerializeField]
		private ItemCell firstItemCell;
		[SerializeField]
		private ItemCell defeatItemCell;
		[SerializeField]
		private Text m_bossNameText;
		[SerializeField]
		private ActionButton m_memberListButton;
	}
}
