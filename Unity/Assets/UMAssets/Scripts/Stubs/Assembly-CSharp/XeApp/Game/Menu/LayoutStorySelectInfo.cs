using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutStorySelectInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_closeButton;
		[SerializeField]
		private ActionButton m_playorDLButton;
		[SerializeField]
		private ActionButton m_liveButton;
		[SerializeField]
		private Text m_desc;
		[SerializeField]
		private Text m_musicName;
		[SerializeField]
		private Text m_storyOne;
		[SerializeField]
		private Text m_storyMain;
		[SerializeField]
		private RawImageEx m_bgImage;
		[SerializeField]
		private RawImageEx m_seriesImage;
		[SerializeField]
		private RawImageEx m_divaImage;
		[SerializeField]
		private RawImageEx m_divaNameImage;
		[SerializeField]
		private RawImageEx m_buttonLabel;
	}
}
