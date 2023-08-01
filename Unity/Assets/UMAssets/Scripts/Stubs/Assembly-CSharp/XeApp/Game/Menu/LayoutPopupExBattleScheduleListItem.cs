using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupExBattleScheduleListItem : SwapScrollListContent
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
		[SerializeField]
		private Text m_textDate;
		[SerializeField]
		private RawImageEx[] m_imageJacket;
	}
}
