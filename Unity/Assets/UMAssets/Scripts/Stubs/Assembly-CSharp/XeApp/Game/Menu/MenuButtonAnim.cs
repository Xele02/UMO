using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class MenuButtonAnim : ActionButton
	{
		public enum ButtonType
		{
			NONE = -1,
			HOME = 0,
			SETTING = 1,
			VOP = 2,
			LIVE = 3,
			GACHA = 4,
			QUEST = 5,
			MENU = 6,
			BUTTON_TYPE_MAX = 7,
		}

		[SerializeField]
		private int m_buttonId;
		[SerializeField]
		private ButtonType m_buttonType;
		[SerializeField]
		private MenuBarPrefab m_menu;
		[SerializeField]
		private List<RawImageEx> m_typeImages;
		[SerializeField]
		private List<RawImageEx> m_selectedTypeImages;
	}
}
