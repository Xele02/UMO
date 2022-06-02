using UnityEngine;
using System;
using UnityEngine.Events;

namespace XeApp.Game.Common
{
	public class UGUIToggleButtonGroup : MonoBehaviour
	{
		[Serializable]
		public class SelectButtonEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private short m_gropId;
		[SerializeField]
		private UGUIToggleButton[] m_toggleButtons;
		[SerializeField]
		private SelectButtonEvent m_onSelectToggleButtonEvent;
	}
}
