using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class DivaStatusParam : LayoutUGUIScriptBase
	{
		[Serializable]
		public class DivaStatusSelectScene : UnityEvent<int>
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
		private StayButton[] m_sceneButtons;
		[SerializeField]
		private InfoButton m_changeStatusButton;
		[SerializeField]
		private RegulationButton[] m_regulationButtons;
		[SerializeField]
		private ActionButton[] m_skillDetailsButtons;
		[SerializeField]
		private RawImageEx m_divaIconImage;
		[SerializeField]
		private RawImageEx m_logoIconImage;
		[SerializeField]
		private RawImageEx[] m_sceneIconImage;
		[SerializeField]
		private RawImageEx[] m_skillRankIconImages;
		[SerializeField]
		private RawImageEx[] m_skillDetailIconImages;
		[SerializeField]
		private RawImageEx[] m_liveSkillTypeImages;
		[SerializeField]
		private DivaStatusSelectScene m_onSceneSelectEvent;
		[SerializeField]
		private DivaStatusSelectScene m_onShowStatusEvent;
	}
}
