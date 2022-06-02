using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LobbyGroupSelctCheckWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_okButton;
		[SerializeField]
		private ActionButton m_cancelButton;
		[SerializeField]
		private RawImageEx m_bannerImage;
		[SerializeField]
		private Text m_upText;
		[SerializeField]
		private Text m_downText;
	}
}
