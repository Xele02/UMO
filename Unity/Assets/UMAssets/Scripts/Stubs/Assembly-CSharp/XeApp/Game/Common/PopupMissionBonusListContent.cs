using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Common
{
	public class PopupMissionBonusListContent : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList;
		[SerializeField]
		private Text m_textDesc;
	}
}
