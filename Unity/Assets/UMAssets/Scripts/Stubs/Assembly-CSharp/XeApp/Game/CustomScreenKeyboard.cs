using XeSys.Gfx;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game
{
	public class CustomScreenKeyboard : LayoutUGUIScriptBase
	{
		[SerializeField]
		private List<ButtonBase> CustomInputList;
		public int InputFieldCount;
		public bool IsOpenKeyboard;
	}
}
