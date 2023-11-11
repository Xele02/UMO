using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class GachaRateEpItem : GachaRateItem
	{
		private AbsoluteLayout m_animStarNum; // 0x38

		// RVA: 0xEE45A0 Offset: 0xEE45A0 VA: 0xEE45A0
		public void SetStarNum(int starNum)
		{
			m_animStarNum.StartChildrenAnimGoStop(starNum.ToString("D2"));
		}

		// RVA: 0xEE463C Offset: 0xEE463C VA: 0xEE463C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_animStarNum = layout.FindViewByExId("sw_ep_list_record_swtbl_ep_list_rarity") as AbsoluteLayout;
			base.InitializeFromLayout(layout, uvMan);
			return true;
		}
	}
}
