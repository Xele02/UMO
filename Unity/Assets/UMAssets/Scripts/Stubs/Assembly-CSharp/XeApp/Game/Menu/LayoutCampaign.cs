using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutCampaign : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private Text m_textAppPeriod;
		[SerializeField]
		private Text m_textGetPeriod;
		[SerializeField]
		private Text m_textCaution1;
		[SerializeField]
		private Text m_textCaution2;
		[SerializeField]
		private Text m_textCaution3;
		[SerializeField]
		private Text m_textCount;
		[SerializeField]
		private ActionButton m_buttonPrizeList;
		[SerializeField]
		private ActionButton m_buttonRegist;
		[SerializeField]
		private ActionButton m_buttonEntry;
		[SerializeField]
		private ActionButton m_buttonContract;
	}
}
