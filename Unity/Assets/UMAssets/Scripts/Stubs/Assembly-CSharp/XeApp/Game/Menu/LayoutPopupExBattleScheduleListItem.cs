using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupExBattleScheduleListItem : SwapScrollListContent
	{
		[SerializeField]
		private Text m_textDate;
		[SerializeField]
		private RawImageEx[] m_imageJacket;
	}
}
