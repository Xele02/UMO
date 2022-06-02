using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationWindow01 : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_leftButton;
		[SerializeField]
		private RawImageEx m_leftButtonFont;
		[SerializeField]
		private List<ActionButton> m_rightButton;
		[SerializeField]
		private List<RawImageEx> m_rightButtonFont;
		[SerializeField]
		private RawImageEx[] logoFirst;
		[SerializeField]
		private RawImageEx[] logoSeven;
		[SerializeField]
		private RawImageEx[] logoFrontia;
		[SerializeField]
		private RawImageEx[] logoDelta;
		[SerializeField]
		private RawImageEx[] logoOther;
		[SerializeField]
		private List<ButtonBase> m_tabButtons;
		[SerializeField]
		private SwapScrollList m_swapScrollList;
		[SerializeField]
		private Text m_windowText;
		[SerializeField]
		private Vector2 m_windowSize;
		[SerializeField]
		private ScrollRect m_scrollRect;
		public bool IsEnter;
	}
}
