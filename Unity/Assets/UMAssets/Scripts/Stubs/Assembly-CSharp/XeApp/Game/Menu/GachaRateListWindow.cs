using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class GachaRateListWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textContent;
		[SerializeField]
		private ActionButton m_buttonPrev;
		[SerializeField]
		private ActionButton m_buttonNext;
		[SerializeField]
		private RawImageEx m_imageNext;
		[SerializeField]
		private ScrollRect m_scrollRect;
	}
}
