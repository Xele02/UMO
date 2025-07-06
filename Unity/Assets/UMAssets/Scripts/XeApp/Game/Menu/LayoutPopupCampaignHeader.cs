using System.Linq;
using UnityEngine.UI;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutPopupCampaignHeader : FlexibleListItemLayout
	{
		private Text m_text; // 0x18
		private AbsoluteLayout m_layoutRoot; // 0x1C

		// RVA: 0x15E9A90 Offset: 0x15E9A90 VA: 0x15E9A90
		public void SetRank(int rank)
		{
			m_layoutRoot.StartChildrenAnimGoStop(rank.ToString("D2"));
		}

		// RVA: 0x15E9B2C Offset: 0x15E9B2C VA: 0x15E9B2C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewById("swtbl_pop_reward_ev_header") as AbsoluteLayout;
			Text[] txts = GetComponentsInChildren<Text>(true);
			m_text = txts.Where((Text x) =>
			{
				//0x15E9E5C
				return x.name == "desc (TextView)";
			}).FirstOrDefault();
			m_text.text = MessageManager.Instance.GetMessage("menu", "campaign_live_3rd_coution_07");
			Loaded();
			return true;
		}
	}
}
