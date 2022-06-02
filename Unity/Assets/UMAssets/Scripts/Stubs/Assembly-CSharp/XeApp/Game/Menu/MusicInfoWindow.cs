using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class MusicInfoWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_font;
		[SerializeField]
		private Text m_title;
		[SerializeField]
		private Text m_info;
		[SerializeField]
		private RawImageEx m_cd;
		[SerializeField]
		private ActionButton m_music_buy_btn;
	}
}
