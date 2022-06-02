using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopPassSelect : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textDesc;
		[SerializeField]
		private ActionButton m_buttonNormal;
		[SerializeField]
		private ActionButton m_buttonLoginBonus;
		[SerializeField]
		private ActionButton m_buttonSpecial;
	}
}
