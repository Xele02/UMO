using UnityEngine;
using System;
using UnityEngine.Events;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SimpleAutoSettingPanel : MonoBehaviour
	{
		[Serializable]
		public class SelectAttrEvent : UnityEvent<int>
		{
		}

		[Serializable]
		public class SelectStyleEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private UGUIToggleButtonGroup m_AttrTypeGroup;
		[SerializeField]
		private UGUIToggleButtonGroup m_PlayStyleGroup;
		[SerializeField]
		private SelectAttrEvent m_onSelectAttributeEvent;
		[SerializeField]
		private SelectStyleEvent m_onSelectStyleEvent;
	}
}
