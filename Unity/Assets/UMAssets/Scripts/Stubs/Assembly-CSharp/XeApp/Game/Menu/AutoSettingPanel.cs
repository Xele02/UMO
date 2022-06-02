using UnityEngine;
using System;
using UnityEngine.Events;
using XeApp.Game.Common;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class AutoSettingPanel : MonoBehaviour
	{
		[Serializable]
		public class SelectButtonEvent : UnityEvent<int>
		{
		}

		[Serializable]
		public class TobbleButtonEvent : UnityEvent<bool>
		{
		}

		[SerializeField]
		private UGUIToggleButtonGroup m_attributeButtonGroup;
		[SerializeField]
		private UGUIToggleButtonGroup m_statusButtonGroup;
		[SerializeField]
		private UGUIToggleButton m_keepCenterSkill;
		[SerializeField]
		private UGUIToggleButton m_compatibleDiva;
		[SerializeField]
		private Text[] m_texts;
		[SerializeField]
		private SelectButtonEvent m_onSelectAttributeEvent;
		[SerializeField]
		private SelectButtonEvent m_onSelectStatusEvent;
		[SerializeField]
		private TobbleButtonEvent m_onSelectkeepCenterSkillEvent;
		[SerializeField]
		private TobbleButtonEvent m_onSelectCompatibleDivaEvent;
	}
}
