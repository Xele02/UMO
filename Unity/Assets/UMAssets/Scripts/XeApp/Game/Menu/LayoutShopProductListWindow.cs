using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using XeApp.Game;
using System.Collections.Generic;
using System;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutShopProductListWindow : LayoutShopListBase
	{
		[SerializeField]
		private Text m_textTitle; // 0x1C
		[SerializeField]
		private Text m_textWarning; // 0x20
		[SerializeField]
		private Text m_textMedal; // 0x24
		[SerializeField]
		private Text m_textMedalNum; // 0x28
		[SerializeField]
		private Text m_textInvalid; // 0x2C
		[SerializeField]
		private RawImageEx[] m_imageMedal; // 0x30
		[SerializeField]
		private ActionButton m_button; // 0x34
		[SerializeField]
		private Text m_textFilter; // 0x38
		[SerializeField]
		private Text m_textOrder; // 0x3C
		[SerializeField]
		private ActionButton m_buttonFilter; // 0x40
		[SerializeField]
		private ActionButton m_buttonOrder; // 0x44
		private AbsoluteLayout m_layoutRoot; // 0x48
		private AbsoluteLayout m_layoutWarning; // 0x4C
		private AbsoluteLayout m_layoutMedal; // 0x50
		private AbsoluteLayout m_layoutSortOnOff; // 0x54
		private AbsoluteLayout m_layoutInvalidOnOff; // 0x58
		private TexUVListManager m_uvMan; // 0x5C
		[SerializeField] // RVA: 0x67DCBC Offset: 0x67DCBC VA: 0x67DCBC
		private TextureListSupport m_texListSupport; // 0x60
		private AODFBGCCBPE m_view; // 0x64
		private List<FJGOKILCBJA> m_productList = new List<FJGOKILCBJA>(); // 0x68

		protected override AbsoluteLayout layoutRoot { get { return m_layoutRoot; } } //0x1948064
		public Action<int, FJGOKILCBJA> OnChangeEvent { get; set; } // 0x6C
		public Action<AODFBGCCBPE> OnClickPopupEvent { get; set; } // 0x70
		public Action OnClickFilterEvent { get; set; } // 0x74
		public Action OnClickOrderEvent { get; set; } // 0x78

		// // RVA: 0x19480AC Offset: 0x19480AC VA: 0x19480AC
		// public bool IsLoading() { }

		// // RVA: 0x19480C0 Offset: 0x19480C0 VA: 0x19480C0
		public void SetStatus(AODFBGCCBPE view, List<FJGOKILCBJA> products, bool resetScroll = true)
		{
			m_view = view;
			m_productList.Clear();
			m_productList.AddRange(products);
			SetupList(m_productList.Count, resetScroll);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textTitle.text = view.NEMKDKDIIDK;
			m_button.Disable = view.INDDJNMPONH_Type == AODFBGCCBPE.NJMPLEENNPO.HJNNKCMLGFL_0 || view.INDDJNMPONH_Type > AODFBGCCBPE.NJMPLEENNPO.BDMFENCIPEB_2_Medal;
			m_layoutWarning.StartChildrenAnimGoStop("cau_off");
			if(products.Count < 1)
			{
				m_textInvalid.text = bk.GetMessageByLabel("scenelist_not_listed_up");
				m_layoutInvalidOnOff.StartChildrenAnimGoStop("01");
			}
			else
			{
				m_layoutInvalidOnOff.StartChildrenAnimGoStop("02");
			}
			m_layoutMedal.StartChildrenAnimGoStop(view.INDDJNMPONH_Type == AODFBGCCBPE.NJMPLEENNPO.FNLODOLMLML_3 ? "coin_off" : "coin_on");
			for(int i = 0; i < m_imageMedal.Length; i++)
			{
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.EAHPLCJMPHD_PayItemId);
                int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.EAHPLCJMPHD_PayItemId);
				switch(cat)
				{
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem:
						m_texListSupport.SetImage(m_imageMedal[i], "cmn_set_tri_l_icon");
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.DLBHNNOHLMM_PresentItem:
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal:
						m_texListSupport.SetImage(m_imageMedal[i],string.Format("cmn_evecoin_icon_{0:D2}", id));
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC:
						m_texListSupport.SetImage(m_imageMedal[i],string.Format("cmn_sphere_icon_{0:D2}", id));
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem:
						if(id == 16)
						{
							m_texListSupport.SetImage(m_imageMedal[i], "cmn_sphere_icon_18");
						}
						else if(id == 15)
						{
							m_texListSupport.SetImage(m_imageMedal[i], "cmn_ticket_icon_05");
						}
						else if(id == 7)
						{
							m_texListSupport.SetImage(m_imageMedal[i], "cmn_raid_icon");
						}
						break;
					default:
						m_texListSupport.SetImage(m_imageMedal[i], "cmn_coin_icon");
						break;
				}
			}
			m_textMedalNum.text = view.JJPAFPIOBCK_GetCount().ToString();
			UnityEngine.Debug.Log("Shop : "+view.INDDJNMPONH_Type+" "+view.JPGALGPNJAI_VcId+" "+view.OCGCPJHDJEN+" "+view.EAHPLCJMPHD_PayItemId);
			for(int i = 0; i < List.ScrollObjects.Count; i++)
			{
				if(List.ScrollObjects[i] != null)
				{
					if(List.ScrollObjects[i] is LayoutShopProductListItem)
					{
						(List.ScrollObjects[i] as LayoutShopProductListItem).OnClickDetailButton = OnClickDetailButton;
					}
					else if(List.ScrollObjects[i] is LayoutShopProductListItem2)
					{
						(List.ScrollObjects[i] as LayoutShopProductListItem2).OnClickDetailButton = OnClickDetailButton;
					}
				}
			}
		}

		// // RVA: 0x1948B18 Offset: 0x1948B18 VA: 0x1948B18
		public void SetSortType(string text)
		{
			m_textFilter.text = text;
		}

		// // RVA: 0x1948B54 Offset: 0x1948B54 VA: 0x1948B54
		public void SetOrderType(string text)
		{
			m_textOrder.text = text;
		}

		// // RVA: 0x1948B90 Offset: 0x1948B90 VA: 0x1948B90
		public void SetSortButtonEnable(bool enable)
		{
			m_layoutSortOnOff.StartChildrenAnimGoStop(enable ? "01" : "02");
		}

		// // RVA: 0x1948C28 Offset: 0x1948C28 VA: 0x1948C28
		private void OnClickDetailButton(FJGOKILCBJA view)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.KIJAPOFAGPN_ItemFullId);
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.KIJAPOFAGPN_ItemFullId);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
			{
				OpenPopupListItem(view, false);
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				if(m_view.INDDJNMPONH_Type != AODFBGCCBPE.NJMPLEENNPO.MGEGNNJLJII_7_EpisodePlate1_4)
				{
					if(m_view.INDDJNMPONH_Type != AODFBGCCBPE.NJMPLEENNPO.ACFEDNPIJKM_8_EpisodePlate5_6)
					{
						GCIJNCFDNON_SceneInfo sceneData = new GCIJNCFDNON_SceneInfo();
						sceneData.KHEKNNFCAOI(id, null, null, 0, 0, 0, false, 0, 0);
						MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, true, true, 0, false);
						return;
					}
				}
				GCIJNCFDNON_SceneInfo[] scenes = new GCIJNCFDNON_SceneInfo[2];
				scenes[0] = new GCIJNCFDNON_SceneInfo();
				scenes[1] = new GCIJNCFDNON_SceneInfo();
				scenes[0].IJIKIPDKCPP = 1;
				scenes[1].IJIKIPDKCPP = 2;
				scenes[0].KHEKNNFCAOI(id, null, null, 0, 0, 0, false, 0, 0);
				scenes[1].KHEKNNFCAOI(id, null, null, 1, 0, 0, false, 0, 0);
				PopupRewardEv2DetailSetting s = new PopupRewardEv2DetailSetting();
				s.TitleText = scenes[0].OPFGFINHFCE_SceneName;
				s.Scene = scenes;
				s.WindowSize = SizeType.Large;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				s.SetParent(MenuScene.Instance.transform);
				PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x194A480
					return;
				}, null, null, null);
			}
			else
			{
				MenuScene.Instance.ShowItemDetail(view.KIJAPOFAGPN_ItemFullId, MessageManager.Instance.GetBank("menu").GetMessageByLabel("item_detail_popup_title_00"), EKLNMHFCAOI.ILKGBGOCLAO_GetItemDesc(cat, id), true);
			}
        }

		// // RVA: 0x194960C Offset: 0x194960C VA: 0x194960C
		private void OpenPopupListItem(FJGOKILCBJA view, bool isBuy)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			ButtonInfo[] btns;
			string str;
			if(isBuy)
			{
				btns = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				str = "item_popup_shop_text_00";
			}
			else
			{
				btns = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				str = "item_detail_popup_title_00";
			}
			PopupShopItemSetting s = new PopupShopItemSetting();
			s.TitleText = bk.GetMessageByLabel(str);
			s.Buttons = btns;
			s.WindowSize = SizeType.Large;
			s.View = view;
			s.IsBuy = isBuy;
			int buy = 1;
			s.OnChangeCallback = (int num) =>
			{
				//0x194A484
				buy = num;
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x194A48C
				if(type != PopupButton.ButtonType.Positive)
					return;
				if(OnChangeEvent != null)
					OnChangeEvent(buy, view);
			}, null, null, null);
		}

		// // RVA: 0x1949AF0 Offset: 0x1949AF0 VA: 0x1949AF0 Slot: 7
		protected override void OnSelectListItem(int value, SwapScrollListContent content)
		{
			if(content != null)
			{
				if(content is LayoutShopProductListItem)
				{
					OpenPopupListItem((content as LayoutShopProductListItem).View, true);
				}
				if(content is LayoutShopProductListItem2)
				{
					OpenPopupListItem((content as LayoutShopProductListItem2).View, true);
				}
			}
		}

		// // RVA: 0x1949BDC Offset: 0x1949BDC VA: 0x1949BDC Slot: 8
		protected override void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			if(content != null)
			{
				{
					LayoutShopProductListItem item = content as LayoutShopProductListItem;
					if(item != null)
						item.SetStatus(m_view.INDDJNMPONH_Type, m_productList[index]);
				}
				{
					LayoutShopProductListItem2 item = content as LayoutShopProductListItem2;
					if(item != null)
						item.SetStatus(m_view.INDDJNMPONH_Type, m_productList[index]);
				}
			}
		}

		// RVA: 0x1949E68 Offset: 0x1949E68 VA: 0x1949E68 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textMedal.text = bk.GetMessageByLabel("item_popup_shop_text_01");
			m_layoutRoot = layout.FindViewById("sw_sel_shop_window_anim_02") as AbsoluteLayout;
			m_layoutWarning = layout.FindViewById("swtbl_wintext_02") as AbsoluteLayout;
			m_layoutMedal = layout.FindViewById("swtbl_window_coin") as AbsoluteLayout;
			m_layoutSortOnOff = layout.FindViewById("swtbl_btn") as AbsoluteLayout;
			m_layoutInvalidOnOff = layout.FindViewById("swtbl_wintext_01") as AbsoluteLayout;
			m_button.AddOnClickCallback(() =>
			{
				//0x194A36C
				OnClickPopupEvent(m_view);
			});
			m_buttonFilter.AddOnClickCallback(() =>
			{
				//0x194A3DC
				if(OnClickFilterEvent != null)
					OnClickFilterEvent();
			});
			m_buttonOrder.AddOnClickCallback(() =>
			{
				//0x194A3F0
				if(OnClickOrderEvent != null)
					OnClickOrderEvent();
			});
			Loaded();
			return true;
		}
	}
}
