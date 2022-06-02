using UnityEngine;
using System;
using UnityEngine.Events;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class AutoSettingToggles : MonoBehaviour
	{
		[Serializable]
		public class AutoTypeToggleEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private UGUIToggleButtonGroup m_autoGroup;
		[SerializeField]
		private AutoTypeToggleEvent m_onAutoTypeEvent;
	}
}
