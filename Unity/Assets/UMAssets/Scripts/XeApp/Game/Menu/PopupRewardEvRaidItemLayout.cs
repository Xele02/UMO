using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvRaidItemLayout : FlexibleListItemLayout
	{
		private RawImageEx m_ItemImage; // 0x18
		private RawImageEx m_GetIconImage; // 0x1C
		private RawImageEx[] m_goldFrame; // 0x20
		private StayButton m_button; // 0x24
		private Text m_ItemNameText; // 0x28
		private Text m_ItemCountText; // 0x2C
		private Text m_RequiredPointText; // 0x30
		private Rect[] m_uvData; // 0x34
		private AbsoluteLayout m_medamaLayout; // 0x38
		private int m_iconId; // 0x3C

		// RVA: 0x1A78230 Offset: 0x1A78230 VA: 0x1A78230 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			LayoutUGUIRuntime lt = GetComponent<LayoutUGUIRuntime>();
			RawImageEx[] imgs = lt.GetComponentsInChildren<RawImageEx>();
			m_ItemImage = imgs.Where((RawImageEx _) =>
			{
				//0x1A78EAC
				return _.name == "swtexc_cmn_item (ImageView)";
			}).First();
			m_GetIconImage = imgs.Where((RawImageEx _) =>
			{
				//0x1A78F2C
				return _.name == "pop_reward_ev_get (ImageView)";
			}).First();
			m_goldFrame = imgs.Where((RawImageEx _) =>
			{
				//0x1A78FAC
				return _.name.Contains("pop_reward_ev_fr_0");
			}).ToArray();
			m_GetIconImage.enabled = false;
			Text[] txts = lt.GetComponentsInChildren<Text>();
			m_ItemNameText = txts.Where((Text _) =>
			{
				//0x1A79044
				return _.name == "item_name (TextView)";
			}).First();
			m_ItemCountText = txts.Where((Text _) =>
			{
				//0x1A790C4
				return _.name == "item_num (TextView)";
			}).First();
			m_RequiredPointText = txts.Where((Text _) =>
			{
				//0x1A79144
				return _.name == "required_pt (TextView)";
			}).First();
			m_ItemNameText.resizeTextForBestFit = true;
			m_ItemNameText.resizeTextMaxSize = 22;
			m_ItemNameText.horizontalOverflow = HorizontalWrapMode.Wrap;
			m_ItemNameText.verticalOverflow = VerticalWrapMode.Truncate;
			m_button = lt.GetComponentInChildren<StayButton>();
			m_medamaLayout = layout.FindViewByExId("sw_pop_reward_ev_raid_mvp_s_m_r_icon_medama") as AbsoluteLayout;
			string[] s = new string[4]
			{
				"pop_reward_ev_fr_02", "pop_reward_ev_fr_03", "pop_reward_ev_frg2_02", "pop_reward_ev_frg2_03"
			};
			m_uvData = new Rect[4];
			for(int i = 0; i < s.Length; i++)
			{
				m_uvData[i] = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(s[i]));
			}
			Loaded();
			return true;
		}

		// // RVA: 0x1A69840 Offset: 0x1A69840 VA: 0x1A69840
		// public void SetItemData(MFDJIFIIPJD info, bool isPickup, float rate) { }

		// // RVA: 0x1A69FBC Offset: 0x1A69FBC VA: 0x1A69FBC
		// public void SetButtonEvent(Action action) { }
	}
}
