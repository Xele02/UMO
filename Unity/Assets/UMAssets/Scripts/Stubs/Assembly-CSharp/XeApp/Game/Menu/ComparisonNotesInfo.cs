using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class ComparisonNotesInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
		[SerializeField]
		protected Text m_notesValue;
		[SerializeField]
		private RawImageEx m_noteIcon;
		[SerializeField]
		private RawImageEx m_noteName;
	}
}
