using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutQuestEvent2MissionSelect : LayoutUGUIScriptBase
	{
		[SerializeField]
		private MusicSelectCDCursor m_cdCursor;
		[SerializeField]
		private MusicSelectPlayButton m_playButton;
		[SerializeField]
		private ActionButton m_musicChangeButton;
		[SerializeField]
		private ActionButton m_returnMissionButton;
		[SerializeField]
		private ActionButton m_boxGachaButton;
		[SerializeField]
		private NumberBase m_boxGachaItemNumber;
		[SerializeField]
		private ActionButton m_eventInfoButton;
		[SerializeField]
		private RawImageEx m_jacketImage;
		[SerializeField]
		private RawImageEx m_dropItemIconImage;
		[SerializeField]
		private LayoutMissionCardButton[] m_cardlevel1Buttons;
		[SerializeField]
		private LayoutMissionCardButton[] m_cardlevel2Buttons;
		[SerializeField]
		private LayoutMissionCardButton[] m_cardlevel3Buttons;
		[SerializeField]
		private MusicSelectUnitButton m_unitButton;
	}
}
