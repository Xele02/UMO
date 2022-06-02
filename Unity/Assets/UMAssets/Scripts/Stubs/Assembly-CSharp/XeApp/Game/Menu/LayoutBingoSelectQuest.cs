using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutBingoSelectQuest : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx ItemIcon;
		[SerializeField]
		private Text ItemName;
		[SerializeField]
		private Text QuestText;
		[SerializeField]
		private ActionButton ItemButton;
	}
}
