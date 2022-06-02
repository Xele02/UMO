using XeSys.Gfx;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutBingoMission : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx[] CompItemList;
		[SerializeField]
		private NumberBase[] CompItemCountList;
		[SerializeField]
		private Text[] ContentTextList;
		[SerializeField]
		private Text[] ContentNumTextList;
		[SerializeField]
		private ActionButton[] ContentButtonList;
		[SerializeField]
		private RawImageEx BingoItemImage;
		[SerializeField]
		private RawImageEx BingoCostumeImage;
		[SerializeField]
		private RawImageEx DivaIcon;
		[SerializeField]
		private ActionButton CompConfButton;
		[SerializeField]
		private Text RibbonText;
		[SerializeField]
		private NumberBase BingoCount;
		[SerializeField]
		private NumberBase MaxBingoCount;
	}
}
