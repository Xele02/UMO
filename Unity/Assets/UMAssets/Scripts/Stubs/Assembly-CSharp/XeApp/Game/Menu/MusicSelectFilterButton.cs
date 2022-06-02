using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class MusicSelectFilterButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_button;
		[SerializeField]
		private Text m_text;
		[SerializeField]
		private RawImageEx[] m_imageBase;
	}
}
