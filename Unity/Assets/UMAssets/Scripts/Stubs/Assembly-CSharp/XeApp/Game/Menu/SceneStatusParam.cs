using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SceneStatusParam : LayoutUGUIScriptBase
	{
		[Serializable]
		public class SceneAbilityButtonEvent : UnityEvent<int>
		{
		}

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
		private ActionButton m_sceneButton;
		[SerializeField]
		private InfoButton m_changeStatusButton;
		[SerializeField]
		private ActionButton[] m_skillDetailsButtons;
		[SerializeField]
		private ActionButton m_luckLeafButton;
		[SerializeField]
		private ActionButton m_episodeButton;
		[SerializeField]
		private ActionButton m_rareChangeButton;
		[SerializeField]
		private RegulationButton[] m_regulationButtons;
		[SerializeField]
		private RawImageEx m_sceneIconImage;
		[SerializeField]
		private RawImageEx m_seriesIconImage;
		[SerializeField]
		private RawImageEx[] m_liveSkillTypeImages;
		[SerializeField]
		private RawImageEx[] m_compatibleDivaIconImages;
		[SerializeField]
		private RawImageEx[] m_compatibleMaskIconImages;
		[SerializeField]
		private RawImageEx[] m_skillDetailIconImages;
		[SerializeField]
		private RawImageEx[] m_skillRankIconImages;
		[SerializeField]
		private SceneAbilityButtonEvent m_onSceneAbilityEvent;
		[SerializeField]
		private RawImage m_backImage;
		[SerializeField]
		private RawImageEx m_zoomSceneImage;
		[SerializeField]
		private RawImageEx m_KiraImage;
		[SerializeField]
		private RawImageEx m_KiraOverlayImage;
		[SerializeField]
		private SceneImageViewer m_viewer;
	}
}
