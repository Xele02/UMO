using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSerifAttacher : LayoutUGUIScriptBase
	{
		[SerializeField]
		private RawImageEx m_chara;
		[SerializeField]
		private RawImageEx m_serifFrame;
		[SerializeField]
		private List<Text> m_serifText;
	}
}
