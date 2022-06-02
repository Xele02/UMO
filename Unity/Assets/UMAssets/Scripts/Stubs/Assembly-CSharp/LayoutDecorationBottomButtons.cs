using XeSys.Gfx;
using System;
using System.Collections.Generic;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

public class LayoutDecorationBottomButtons : LayoutUGUIScriptBase
{
	[Serializable]
	public class BottomButtons
	{
		public List<ActionButton> m_buttons;
		public List<RawImageEx> m_font;
	}

	[SerializeField]
	private List<LayoutDecorationBottomButtons.BottomButtons> m_bottomButtons;
	[SerializeField]
	private Text m_text;
}
