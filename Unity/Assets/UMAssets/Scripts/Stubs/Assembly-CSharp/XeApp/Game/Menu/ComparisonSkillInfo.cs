using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class ComparisonSkillInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutUGUIRuntime m_runtime;
		[SerializeField]
		private Text[] m_levelTexts;
		[SerializeField]
		private Text[] m_detailsTexts;
		[SerializeField]
		private RawImageEx[] m_rankImages;
		[SerializeField]
		private RawImageEx[] m_descDetailsImage;
		[SerializeField]
		private ActionButton[] m_descDetailsButton;
		[SerializeField]
		private RegulationButton m_regulationButton;
		[SerializeField]
		private string m_maskLayoutExId;
		[SerializeField]
		private string m_typeLayoutExId;
		[SerializeField]
		private string m_skillCrossFadeExId;
	}
}
