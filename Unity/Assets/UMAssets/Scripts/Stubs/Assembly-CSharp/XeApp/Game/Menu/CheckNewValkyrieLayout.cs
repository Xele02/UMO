using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class CheckNewValkyrieLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_btn;
		[SerializeField]
		private RawImageEx m_pilotIcon;
		[SerializeField]
		private Text m_EpisodeText;
		[SerializeField]
		private Text m_pilotNameText;
		[SerializeField]
		private Text m_nickNameText;
		[SerializeField]
		private Text m_ValkyrieNameText;
		[SerializeField]
		private Text m_ValkyrieInfoText;
		[SerializeField]
		private Text m_episodeDesc1Text;
		[SerializeField]
		private Text m_episodeDesc2Text;
	}
}
