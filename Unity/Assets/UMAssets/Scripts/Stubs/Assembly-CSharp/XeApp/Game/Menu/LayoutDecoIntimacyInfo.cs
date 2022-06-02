using XeSys.Gfx;
using System;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutDecoIntimacyInfo : LayoutUGUIScriptBase
	{
		[Serializable]
		private class Variables
		{
			public NumberBase m_numExpNow;
			public NumberBase m_numExpNext;
			public NumberBase m_numLevel;
			public NumberBase[] m_numPoint;
		}

		[SerializeField]
		private Variables m_left;
		[SerializeField]
		private Variables m_right;
		[SerializeField]
		private RectTransform m_RightFarthest;
	}
}
