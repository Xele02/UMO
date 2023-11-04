using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutGachaLegalButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textDesc1; // 0x14
		[SerializeField]
		private Text m_textDesc2; // 0x18
		[SerializeField]
		private Text m_textNormal; // 0x1C
		[SerializeField]
		private ActionButton m_buttonPickup; // 0x20
		[SerializeField]
		private ActionButton m_buttonDetail; // 0x24
		[SerializeField]
		private ActionButton m_buttonEpisode; // 0x28
		[SerializeField]
		private ActionButton m_buttonMovie; // 0x2C
		[SerializeField]
		private ActionButton m_buttonRarity; // 0x30
		[SerializeField]
		private ActionButton m_buttonPassPurchase; // 0x34
		private AbsoluteLayout m_layoutInOut; // 0x38
		private AbsoluteLayout m_layoutType; // 0x3C
		private AbsoluteLayout m_layoutRarity; // 0x40
		private AbsoluteLayout m_layoutEpisode; // 0x44
		private AbsoluteLayout m_layoutPickup; // 0x48
		private BEPHBEGDFFK m_view; // 0x4C

		public Action OnClickPickupButton { private get; set; } // 0x50
		public Action OnClickDetailButton { private get; set; } // 0x54
		public Action OnClickEpisodeButton { private get; set; } // 0x58
		public Action OnClickMovieButton { private get; set; } // 0x5C
		public Action OnClickRarityButton { private get; set; } // 0x60
		public Action OnClickPassPurchaseButton { private get; set; } // 0x64

		// RVA: 0x1D4CBC8 Offset: 0x1D4CBC8 VA: 0x1D4CBC8
		public void Setup(BEPHBEGDFFK view)
		{
			m_view = view;
			if(view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
			{
				m_layoutType.StartChildrenAnimGoStop("02");
				m_textDesc2.text = MessageManager.Instance.GetMessage("menu", "gacha_desc_04");
				m_textNormal.text = MessageManager.Instance.GetMessage("menu", "gacha_desc_05");
			}
			else if(view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
			{
				m_layoutType.StartChildrenAnimGoStop("04");
				m_buttonPassPurchase.Hidden = true;
				if (m_view.DPBDFPPMIPH_Gacha.MJNOAMAFNHA_CostItemId == EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem, 1))
				{
					m_buttonPassPurchase.Hidden = NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ() != 3 && NHPDPKHMFEP.HHCJCDFCLOB.MENKMJPCELJ() != 0;
				}
			}
			else if(view.DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.ANFKBNLLJFN_7)
			{
				m_layoutType.StartChildrenAnimGoStop("03");
			}
			else
			{
				m_layoutType.StartChildrenAnimGoStop("01");
			}
			m_layoutPickup.StartChildrenAnimGoStop("02");
			SwitchEpisode(m_view.BADFIKBADNH_PickupId);
			SwitchRarity(m_view.EFCJADAPOMN);
			m_buttonRarity.Hidden = m_view.BADFIKBADNH_PickupId < 1;
		}

		//// RVA: 0x1D4CFF0 Offset: 0x1D4CFF0 VA: 0x1D4CFF0
		public void SwitchEpisode(int sceneId)
		{
			if(sceneId < 1)
			{
				m_buttonEpisode.Hidden = true;
				m_buttonMovie.Hidden = true;
			}
			else
			{
				m_buttonMovie.Hidden = m_view.BMJOENJMFEL(sceneId).Count < 1;
				GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
				scene.KHEKNNFCAOI(sceneId, null, null, 0, 0, 0, false, 0, 0);
				LGMEPLIJLNB l = LGMEPLIJLNB.BMFKMFNPGPC(scene.KELFCMEOPPM_EpisodeId, true);
				if(l != null)
				{
					m_layoutEpisode.StartChildrenAnimGoStop(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(l.GOOIIPFHOIG.JJBGOIMEIPF_ItemFullId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_Costume ? "01" : "02");
					m_buttonEpisode.Hidden = false;
				}
				else
				{
					m_buttonEpisode.Hidden = true;
				}
			}
		}

		//// RVA: 0x1D4D294 Offset: 0x1D4D294 VA: 0x1D4D294
		public void SwitchRarity(bool rarity)
		{
			m_textDesc1.text = MessageManager.Instance.GetMessage("menu", string.Format("gacha_rarity_desc_{0}", rarity ? "02" : "01"));
			m_layoutRarity.StartChildrenAnimGoStop(rarity ? "01" : "02");
		}

		// RVA: 0x1D4D3DC Offset: 0x1D4D3DC VA: 0x1D4D3DC
		public void Enter()
		{
			m_layoutInOut.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// RVA: 0x1D4D468 Offset: 0x1D4D468 VA: 0x1D4D468
		public void Leave()
		{
			m_layoutInOut.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// RVA: 0x1D4D4F4 Offset: 0x1D4D4F4 VA: 0x1D4D4F4
		public bool IsPlaying()
		{
			return gameObject.activeSelf && m_layoutInOut.IsPlayingChildren();
		}

		// RVA: 0x1D4D558 Offset: 0x1D4D558 VA: 0x1D4D558 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutInOut = layout.FindViewById("sw_gacha_legal_inout_anim") as AbsoluteLayout;
			m_layoutType = layout.FindViewById("swtbl_gacha_legal") as AbsoluteLayout;
			m_layoutRarity = layout.FindViewById("gacha_switch_frame") as AbsoluteLayout;
			m_layoutEpisode = layout.FindViewById("gacha_fnt_02") as AbsoluteLayout;
			m_layoutPickup = layout.FindViewById("gacha_fnt_01") as AbsoluteLayout;
			m_buttonPickup.AddOnClickCallback(() =>
			{
				//0x1D4DA40
				if (OnClickPickupButton != null)
					OnClickPickupButton();
			});
			m_buttonDetail.AddOnClickCallback(() =>
			{
				//0x1D4DA54
				if (OnClickDetailButton != null)
					OnClickDetailButton();
			});
			m_buttonEpisode.AddOnClickCallback(() =>
			{
				//0x1D4DA68
				if (OnClickEpisodeButton != null)
					OnClickEpisodeButton();
			});
			m_buttonMovie.AddOnClickCallback(() =>
			{
				//0x1D4DA7C
				if (OnClickMovieButton != null)
					OnClickMovieButton();
			});
			m_buttonRarity.AddOnClickCallback(() =>
			{
				//0x1D4DA90
				if (OnClickRarityButton != null)
					OnClickRarityButton();
			});
			m_buttonPassPurchase.AddOnClickCallback(() =>
			{
				//0x1D4DAA4
				if (OnClickPassPurchaseButton != null)
					OnClickPassPurchaseButton();
			});
			Loaded();
			return true;
		}
	}
}
