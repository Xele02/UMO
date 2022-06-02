using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SceneSelectList : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private SceneListSelectEvent m_onSelectSceneEvent;
		[SerializeField]
		private UnityEvent m_onRemoveSceneEvent;
		[SerializeField]
		private SceneListSelectEvent m_onShowSceneStatusEvent;
		[SerializeField]
		private string m_windowExId;
		[SerializeField]
		private NumberBase[] m_episodeNumber;
		[SerializeField]
		private Text m_invalidText;
		[SerializeField]
		private Text m_gaugeRateText;
		[SerializeField]
		private UnitExpectedScore m_scoreGauge;
		[SerializeField]
		private List<Text> m_gaugeNameTexts;
		[SerializeField]
		private RawImageEx m_jacketImage;
		[SerializeField]
		private RawImageEx m_musicAttributeImage;
		[SerializeField]
		private RawImageEx m_difficultImage;
		[SerializeField]
		private RawImageEx m_scorePlusImage;
		[SerializeField]
		private RepeatButton m_scorePlusButton;
		[SerializeField]
		private RepeatButton m_scoreMinusButton;
	}
}
