using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSerifAttacher : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx m_chara;
		[SerializeField]
		private RawImageEx m_serifFrame;
		[SerializeField]
		private List<Text> m_serifText;
	}
}
