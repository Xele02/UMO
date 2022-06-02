using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupMigration : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton[] m_buttons;
		[SerializeField]
		private Text m_desc;
	}
}
