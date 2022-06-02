using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class DivaList : LayoutUGUIScriptBase
	{
		[Serializable]
		public class SelectDivaEvent : UnityEvent<int>
		{
		}

		[SerializeField]
		private RawImageEx[] m_divaIconImage;
		[SerializeField]
		private RawImageEx[] m_centerIconImage;
		[SerializeField]
		private RawImageEx[] m_unitIconImage;
		[SerializeField]
		private StayButton[] m_stayButton;
		[SerializeField]
		private SelectDivaEvent m_onPushIconEvent;
		[SerializeField]
		private SelectDivaEvent m_onStayIconEvent;
	}
}
