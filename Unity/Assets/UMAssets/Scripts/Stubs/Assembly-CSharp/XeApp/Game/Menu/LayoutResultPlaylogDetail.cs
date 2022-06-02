using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class LayoutResultPlaylogDetail : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ScrollRect m_ScrollRect;
		[SerializeField]
		private RectTransform m_ScrollContent;
		[SerializeField]
		private RectTransform m_scoreBarRange;
		[SerializeField]
		private SwapScrollList m_SwapScroll;
	}
}
