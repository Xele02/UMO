using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutIntimacyInfo : LayoutUGUIScriptBase
	{
		[SerializeField]
		private NumberBase m_numExpNow;
		[SerializeField]
		private NumberBase m_numExpNext;
		[SerializeField]
		private NumberBase m_numLevel;
		[SerializeField]
		private NumberBase[] m_numPoint;
		[SerializeField]
		private NumberBase m_numBonus;
	}
}
