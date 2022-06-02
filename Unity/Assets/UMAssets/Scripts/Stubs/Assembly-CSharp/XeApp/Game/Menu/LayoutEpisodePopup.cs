using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutEpisodePopup : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_EpisodeTitleText;
		[SerializeField]
		private Text m_EpisodeDescText;
		[SerializeField]
		private ActionButton m_EpisodeButton;
		[SerializeField]
		private RawImageEx m_EpisodeValkyrieImage;
	}
}
