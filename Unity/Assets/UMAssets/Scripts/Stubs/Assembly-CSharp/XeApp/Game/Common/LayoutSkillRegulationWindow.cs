using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class LayoutSkillRegulationWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_skillLevelTexts;
		[SerializeField]
		private Text[] m_skillDetails;
		[SerializeField]
		private Text[] m_skillNames;
		[SerializeField]
		private Text[] m_logoSeriesExceptText;
		[SerializeField]
		private RawImageEx[] m_logoSeriesImages;
		[SerializeField]
		private RawImageEx[] m_skillRankImages;
		[SerializeField]
		private RawImageEx[] m_skilllimitAttributeImages;
	}
}
