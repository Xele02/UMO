using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class LayoutPopupExBattleScheduleListWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		[SerializeField]
		private Text m_textCaution_01; // 0x18
		[SerializeField]
		private Text m_textCaution_02; // 0x1C
		private CDDODEHEKGB m_view; // 0x20

		public SwapScrollList List { get { return m_scrollList; } } //0x1723810

		// // RVA: 0x1723818 Offset: 0x1723818 VA: 0x1723818
		// public bool IsLoading() { }

		// // RVA: 0x1723830 Offset: 0x1723830 VA: 0x1723830
		// public void Setup(CDDODEHEKGB view, bool resetScroll = True) { }

		// // RVA: 0x1723BB0 Offset: 0x1723BB0 VA: 0x1723BB0
		// protected void OnUpdateListItem(int index, SwapScrollListContent content) { }

		// // RVA: 0x17239E0 Offset: 0x17239E0 VA: 0x17239E0
		// private void SetupList(int count, bool resetScroll) { }

		// RVA: 0x1723D3C Offset: 0x1723D3C VA: 0x1723D3C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return true;
		}
	}
}
