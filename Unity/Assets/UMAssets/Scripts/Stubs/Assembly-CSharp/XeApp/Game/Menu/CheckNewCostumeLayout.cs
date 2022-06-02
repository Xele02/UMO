using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class CheckNewCostumeLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_btn;
		[SerializeField]
		private RawImageEx m_divaIcon;
		[SerializeField]
		private RawImageEx m_costumeImage;
		[SerializeField]
		private Text m_episodeText;
		[SerializeField]
		private Text m_skillText;
		[SerializeField]
		private Text m_costumeInfoText;
		[SerializeField]
		private Text m_costumeNameText;
		[SerializeField]
		private Text m_episodeDesc1Text;
		[SerializeField]
		private Text m_episodeDesc2Text;
	}
}
