using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class HelpListElemBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_labelText;
		[SerializeField]
		private ScrollListButton m_selectButton;
	}
}
