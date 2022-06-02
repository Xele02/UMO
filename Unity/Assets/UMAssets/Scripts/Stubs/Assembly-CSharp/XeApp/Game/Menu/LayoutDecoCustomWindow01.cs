using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecoCustomWindow01 : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_leftButton;
		[SerializeField]
		private RawImageEx m_leftButtonFont;
		[SerializeField]
		private ActionButton m_rightButton;
		[SerializeField]
		private RawImageEx m_rightButtonFont;
		[SerializeField]
		private List<ButtonBase> m_tab;
		[SerializeField]
		private SwapScrollList m_swapScrollList;
		[SerializeField]
		private Text m_windowText;
		[SerializeField]
		private Vector2 m_windowSize;
	}
}
