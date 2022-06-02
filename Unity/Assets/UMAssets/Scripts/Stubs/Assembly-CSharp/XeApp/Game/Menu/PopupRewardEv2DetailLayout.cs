using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupRewardEv2DetailLayout : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text[] m_paramTexts;
		[SerializeField]
		private Text[] m_nortsTexts;
		[SerializeField]
		private Text[] m_skillNameTexts;
		[SerializeField]
		private Text[] m_skillDescriptTexts;
		[SerializeField]
		private Text[] m_skillLevelTexts;
		[SerializeField]
		private Text m_sceneDetails;
		[SerializeField]
		private Text m_episodeName;
		[SerializeField]
		private InfoButton m_changeStatusButton;
		[SerializeField]
		private ActionButton[] m_skillDetailsButtons;
		[SerializeField]
		private ActionButton m_episodeButton;
		[SerializeField]
		private RegulationButton m_regulationButton;
		[SerializeField]
		private RawImageEx m_sceneIconImage;
		[SerializeField]
		private RawImageEx m_seriesIconImage;
		[SerializeField]
		private RawImageEx m_liveSkillTypeImage;
		[SerializeField]
		private RawImageEx[] m_compatibleDivaIconImages;
		[SerializeField]
		private RawImageEx[] m_compatibleMaskIconImages;
		[SerializeField]
		private RawImageEx[] m_skillDetailIconImages;
		[SerializeField]
		private RawImageEx[] m_skillRankIconImages;
		[SerializeField]
		private ActionButton m_changePlateButton;
	}
}
