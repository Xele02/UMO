using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSerifAttacher : LayoutUGUIScriptBase
	{
    public void Awake() { UnityEngine.Debug.LogError("Immplement LayoutUGUIScriptBase"); }
		[SerializeField]
		private RawImageEx m_chara;
		[SerializeField]
		private RawImageEx m_serifFrame;
		[SerializeField]
		private List<Text> m_serifText;
	}
}
