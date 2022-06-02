using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	internal class LayoutDecorationVisitWindow : LayoutUGUIScriptBase
	{
		[Serializable]
		private struct TabLayoutData
		{
			public ButtonBase m_button;
		}

		[SerializeField]
		private TabLayoutData[] m_tabList;
		[SerializeField]
		private Text m_windowText;
		[SerializeField]
		private Text m_memberNumText;
		[SerializeField]
		private Text m_giftText;
		[SerializeField]
		private Text m_giftNumText;
		[SerializeField]
		private ActionButton m_allGiftButton;
		[SerializeField]
		private RawImageEx m_allGiftButtonFont;
		[SerializeField]
		private SwapScrollList m_swapScrollList;
	}
}
