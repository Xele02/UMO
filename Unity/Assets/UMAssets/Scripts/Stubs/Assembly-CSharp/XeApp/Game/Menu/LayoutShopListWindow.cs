using System;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutShopListWindow : LayoutShopListBase
	{
		private AbsoluteLayout m_layoutRoot; // 0x1C
		private List<AODFBGCCBPE> m_viewList; // 0x20

		protected override AbsoluteLayout layoutRoot { get { return m_layoutRoot; } } //0x194109C
		public Action<AODFBGCCBPE> OnSelectEvent { get; set; } // 0x24

		//// RVA: 0x19410B4 Offset: 0x19410B4 VA: 0x19410B4
		//public bool IsLoading() { }

		// RVA: 0x19410C8 Offset: 0x19410C8 VA: 0x19410C8
		public void SetStatus(List<AODFBGCCBPE> list, bool resetScroll = true)
		{
			m_viewList = list;
			SetupList(list.Count, resetScroll);
		}

		// RVA: 0x1941158 Offset: 0x1941158 VA: 0x1941158 Slot: 7
		protected override void OnSelectListItem(int value, SwapScrollListContent content)
		{
			LayoutShopListItem c = content as LayoutShopListItem;
			if (c != null && OnSelectEvent != null)
			{
				OnSelectEvent(c.View);
			}
		}

		// RVA: 0x1941270 Offset: 0x1941270 VA: 0x1941270 Slot: 8
		protected override void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutShopListItem c = content as LayoutShopListItem;
			if(c != null)
			{
				c.SetStatus(m_viewList[index]);
			}
		}

		// RVA: 0x19413A0 Offset: 0x19413A0 VA: 0x19413A0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("sw_sel_shop_window_anim_01") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
