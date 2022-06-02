using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class ComparisonParamBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		protected LayoutUGUIRuntime m_runtime;
		[SerializeField]
		protected Text m_nameText;
		[SerializeField]
		protected Text[] m_paramTexts;
		[SerializeField]
		protected RawImageEx m_iconImage;
		[SerializeField]
		protected RawImageEx[] m_arrowImages;
		[SerializeField]
		protected Text[] m_notesTitle;
		[SerializeField]
		protected ComparisonNotesBase[] m_notes;
		[SerializeField]
		protected ComparisonSkillInfo[] m_skillInfos;
	}
}
