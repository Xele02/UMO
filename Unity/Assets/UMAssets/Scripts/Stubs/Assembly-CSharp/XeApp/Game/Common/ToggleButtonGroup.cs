using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ToggleButtonGroup : LayoutUGUIScriptBase
	{
		[Serializable]
		public class SelectButtonEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private short m_gropId;
		[SerializeField]
		private ToggleButton[] m_toggleButtons;
		[SerializeField]
		private SelectButtonEvent m_onSelectToggleButtonEvent;
	}
}
