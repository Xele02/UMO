using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupOverlapHeader : FlexibleListItemLayout
	{
		private AbsoluteLayout m_root; // 0x18
		private bool m_isLoadingImage; // 0x1C

		// // RVA: 0x173AD40 Offset: 0x173AD40 VA: 0x173AD40
		// public bool IsLoading() { }

		// RVA: 0x173ADEC Offset: 0x173ADEC VA: 0x173ADEC
		public void SetStatus(GONMPHKGKHI_RewardView.CECMLGBLHHG type)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(type == GONMPHKGKHI_RewardView.CECMLGBLHHG.INJNLJHGGKB_4)
			{
				m_root.StartChildrenAnimGoStop("02");
			}
			else if(type == GONMPHKGKHI_RewardView.CECMLGBLHHG.NNEOHGFGLKM_3)
			{
				m_root.StartChildrenAnimGoStop("01");
			}
		}

		// RVA: 0x173AEE4 Offset: 0x173AEE4 VA: 0x173AEE4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_root = layout.FindViewById("swtbl_pop_overlap_title") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
