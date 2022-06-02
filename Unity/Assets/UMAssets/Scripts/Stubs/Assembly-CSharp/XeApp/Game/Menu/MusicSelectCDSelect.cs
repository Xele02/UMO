using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDSelect : LayoutLabelScriptBase
	{
		[SerializeField]
		private ActionButton m_eventDetailButton;
		[SerializeField]
		private List<MusicSelectCDButton> m_cdSelectButtons;
		[SerializeField]
		private List<MusicSelectCDJacket> m_jacketImages;
		[SerializeField]
		private List<MusicSelectCDJacket> m_singleJacketImages;
		[SerializeField]
		private MusicSelectCDScroller m_scroller;
		[SerializeField]
		private MusicSelectCDCursor m_cdCursor;
		[SerializeField]
		private MusicSelectPlayButton m_playButton;
		[SerializeField]
		private MusicSelectUnitButton m_unitButton;
	}
}
