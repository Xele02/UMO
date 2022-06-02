using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class SortMenuWindow : LayoutUGUIScriptBase
	{
		[Serializable]
		public class SortButtonEvent : UnityEvent<int>
		{
		}

		[Serializable]
		public class FilterButtonEvent : UnityEvent<uint>
		{
		}

		[Serializable]
		public class CompatibleDivaButtonEvent : UnityEvent<bool>
		{
		}

		[SerializeField]
		private RawImageEx[] m_sortItemLabel;
		[SerializeField]
		private RawImageEx[] m_assistSlotLabel;
		[SerializeField]
		private RawImageEx[] m_divaIconImages;
		[SerializeField]
		private RawImageEx[] m_rareIconImages;
		[SerializeField]
		private RawImageEx[] m_seriesIconImages;
		[SerializeField]
		private RawImageEx[] m_centerSkillIconImages;
		[SerializeField]
		private RawImageEx[] m_interiorIconImages;
		[SerializeField]
		private ActionButton m_resetButton;
		[SerializeField]
		private ToggleButtonGroup m_sortGroupButton;
		[SerializeField]
		private ToggleButton[] m_sortToggleButtons;
		[SerializeField]
		private ToggleButtonGroup m_assistGroupButton;
		[SerializeField]
		private ToggleButton[] m_assistToggleButtons;
		[SerializeField]
		private ToggleButton[] m_rareFilterToggleButtons;
		[SerializeField]
		private ToggleButton[] m_attributeToggleButtons;
		[SerializeField]
		private ToggleButton[] m_seriesToggleButtons;
		[SerializeField]
		private ToggleButton[] m_centerSkillToggleButtons;
		[SerializeField]
		private ToggleButton m_compatibleToggleButton;
		[SerializeField]
		private ToggleButton[] m_divaToggleButtons;
		[SerializeField]
		private ToggleButton[] m_InteriorToggleButtons;
		[SerializeField]
		private Text m_compatibleText;
		[SerializeField]
		private Text m_assistText;
		[SerializeField]
		private SortButtonEvent m_pushSortButtonEvent;
		[SerializeField]
		private SortButtonEvent m_pushAssistButtonEvent;
		[SerializeField]
		private FilterButtonEvent m_pushRareButtonEvent;
		[SerializeField]
		private FilterButtonEvent m_pushAttributeButtonEvent;
		[SerializeField]
		private FilterButtonEvent m_pushSeriesButtonEvent;
		[SerializeField]
		private FilterButtonEvent m_pushCenterSkillButtonEvent;
		[SerializeField]
		private FilterButtonEvent m_pushDivaButtonEvent;
		[SerializeField]
		private FilterButtonEvent m_pushInteriorButtonEvent;
		[SerializeField]
		private CompatibleDivaButtonEvent m_pushComatibleDivaButtonEvent;
	}
}
