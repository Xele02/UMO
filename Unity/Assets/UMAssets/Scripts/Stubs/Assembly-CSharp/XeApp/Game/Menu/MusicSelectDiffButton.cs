using XeApp.Game.Common;
using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MusicSelectDiffButton : ActionButton
	{
		public enum IconType
		{
			ILLEGAL = 0,
			EASY = 1,
			NORMAL = 2,
			HARD = 3,
			VERY_HARD = 4,
			EXTREME = 5,
			HARD_PLUS = 6,
			VERY_HARD_PLUS = 7,
			EXTREME_PLUS = 8,
		}

		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
		[SerializeField]
		private IconType m_iconType;
		[SerializeField]
		private List<RawImageEx> m_basicFonts;
		[SerializeField]
		private RawImageEx m_selectedFont;
		[SerializeField]
		private RawImageEx m_lockedFont;
		[SerializeField]
		private List<RawImageEx> m_lockIcons;
		[SerializeField]
		private GameObject m_newIconParent;
		[SerializeField]
		private RectTransform[] m_rectFrame;
	}
}
