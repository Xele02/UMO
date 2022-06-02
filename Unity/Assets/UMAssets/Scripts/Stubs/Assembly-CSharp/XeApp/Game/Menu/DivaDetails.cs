using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class DivaDetails : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_divaName;
		[SerializeField]
		private StatusLabelSet m_totalStatus;
		[SerializeField]
		private StatusLabelSet m_divaStatus;
		[SerializeField]
		private StatusLabelSet m_mainSceneStatus;
		[SerializeField]
		private StatusLabelSet m_subScene1Status;
		[SerializeField]
		private StatusLabelSet m_subScene2Status;
		[SerializeField]
		private Text m_centerSkillDescription;
		[SerializeField]
		private Text m_activeSkillDescription;
		[SerializeField]
		private Text[] m_liveSkillDescription;
		[SerializeField]
		private RawImageEx m_divaIconRawImageEx;
		[SerializeField]
		private RawImageEx[] m_sceneIconRawImageEx;
		[SerializeField]
		private RawImageEx m_centerIconRawImageEx;
		[SerializeField]
		private RawImageEx[] m_skillTypeIconImages;
		[SerializeField]
		private StayButton m_divaStayButton;
		[SerializeField]
		private StayButton m_mainSceneStayButton;
		[SerializeField]
		private StayButton[] m_subSceneStayButtons;
		[SerializeField]
		private StayButton[] m_skillDetailButtons;
		[SerializeField]
		private RawImageEx[] m_skillDetailIconImages;
		[SerializeField]
		private RawImageEx[] m_skillCompatibleMaskImages;
		[SerializeField]
		private RawImageEx[] m_skillCompatibleFontImages;
		[SerializeField]
		private string[] m_exId;
		[SerializeField]
		private DivaSelectEvent m_onDivaClickEvent;
		[SerializeField]
		private DivaSelectEvent m_onDivaStayEvent;
		[SerializeField]
		private SceneSelectEvent m_onSceneClickEvent;
		[SerializeField]
		private SceneSelectEvent m_onSceneStayEvent;
		[SerializeField]
		private ShowSkillDetailsEvent m_onShowSkillDetailsEvent;
	}
}
