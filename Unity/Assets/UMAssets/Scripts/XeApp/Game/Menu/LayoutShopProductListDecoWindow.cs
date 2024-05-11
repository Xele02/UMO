using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using XeApp.Game;
using System.Collections.Generic;
using System;
using XeSys;
using System.Linq;
using mcrs;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class LayoutShopProductListDecoWindow : LayoutShopListBase
	{
		private static readonly EKLNMHFCAOI.FKGCBLHOOCL_Category[] s_DecoItemTypeIndex = new EKLNMHFCAOI.FKGCBLHOOCL_Category[5]
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara,
			EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif,
			EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj,
			EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem,
			EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp
		}; // 0x0
		[SerializeField]
		private Text m_textTitle; // 0x1C
		[SerializeField]
		private Text m_textWarning; // 0x20
		[SerializeField]
		private Text m_textMedal; // 0x24
		[SerializeField]
		private Text m_textMedalNum; // 0x28
		[SerializeField]
		private RawImageEx[] m_imageMedal; // 0x2C
		[SerializeField]
		private ActionButton m_button; // 0x30
		[SerializeField]
		private Text m_noProductText; // 0x34
		[SerializeField]
		private TextureListSupport m_texListSupport; // 0x38
		private AbsoluteLayout m_layoutRoot; // 0x3C
		private AbsoluteLayout m_layoutWarning; // 0x40
		private AbsoluteLayout m_layoutMedal; // 0x44
		private TexUVListManager m_uvMan; // 0x48
		[SerializeField]
		private RawImageEx m_filterButtonLabel; // 0x4C
		private AbsoluteLayout m_layoutKyrr; // 0x50
		private AbsoluteLayout m_ballon; // 0x54
		private AbsoluteLayout m_tabs; // 0x58
		[SerializeField] // RVA: 0x67DA5C Offset: 0x67DA5C VA: 0x67DA5C
		private List<ActionButton> m_DecoTypeButtons = new List<ActionButton>(); // 0x5C
		[SerializeField] // RVA: 0x67DA6C Offset: 0x67DA6C VA: 0x67DA6C
		private ActionButton m_extraTabButton; // 0x60
		private AODFBGCCBPE m_view; // 0x64

		protected override AbsoluteLayout layoutRoot { get { return m_layoutRoot; } } //0x1941480
		public Action<int, FJGOKILCBJA> OnChangeEvent { get; set; } // 0x68
		public Action OnClickPopupEvent { get; set; } // 0x6C

		// RVA: 0x19414A8 Offset: 0x19414A8 VA: 0x19414A8
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingChildren();
		}

		// // RVA: 0x19414D4 Offset: 0x19414D4 VA: 0x19414D4
		// public bool IsLoading() { }

		// RVA: 0x19414E8 Offset: 0x19414E8 VA: 0x19414E8
		private void Update()
		{
			return;
		}

		// // RVA: 0x19414EC Offset: 0x19414EC VA: 0x19414EC
		public void IsFilterOn(bool isFilter)
		{
			m_texListSupport.SetImage(m_filterButtonLabel, isFilter ? "sel_shop_btn_mozi_p" : "sel_shop_btn_mozi");
		}

		// RVA: 0x194158C Offset: 0x194158C VA: 0x194158C
		public bool IsLoadedProductImage()
		{
			for(int i = 0; i < List.ScrollObjectCount; i++)
			{
				LayoutShopProductListItem c = List.ScrollObjects[i] as LayoutShopProductListItem;
				if(c != null)
				{
					if(!c.IsLoaded())
						return false;
				}
				else if(!List.ScrollObjects[i].IsLoaded())
					return false;
			}
			return true;
		}

		// RVA: 0x19417F8 Offset: 0x19417F8 VA: 0x19417F8
		public void SetStatus(AODFBGCCBPE view, bool resetScroll = true)
		{
			m_view = view;
			SetupList(view.MHKCPJDNJKI.Count, resetScroll);
			m_noProductText.enabled = view.MHKCPJDNJKI.Count < 1;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textTitle.text = view.NEMKDKDIIDK_ShopName;
			m_layoutWarning.enabled = false;
			m_layoutKyrr.StartChildrenAnimGoStop("01", "01");
			for(int i = 0; i < m_imageMedal.Length; i++)
			{
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.EAHPLCJMPHD_PayItemId);
				int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.EAHPLCJMPHD_PayItemId);
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
				{
					if(id == 7)
					{
						m_texListSupport.SetImage(m_imageMedal[i], "cmn_raid_icon");
					}
					else if(id == 8)
					{
						m_texListSupport.SetImage(m_imageMedal[i], "cmn_deco_icon");
					}
				}
            }
			m_textMedalNum.text = view.JJPAFPIOBCK_GetCount().ToString();
			for(int i = 0; i < List.ScrollObjects.Count; i++)
			{
				(List.ScrollObjects[i] as LayoutShopProductListItem).OnClickDetailButton = OnClickDetailButton;
			}
		}

		// RVA: 0x1941D28 Offset: 0x1941D28 VA: 0x1941D28
		public void SetTabsButtonCallBack(Action<EKLNMHFCAOI.FKGCBLHOOCL_Category> action)
		{
			for(int i = 0; i < m_DecoTypeButtons.Count; i++)
			{
				int index = i;
				m_DecoTypeButtons[i].ClearOnClickCallback();
				m_DecoTypeButtons[i].AddOnClickCallback(() =>
				{
					//0x19453B4
					action(s_DecoItemTypeIndex[index]);
					ApplySelectSeriesButton(index);
				});
				if(i == 1)
				{
					m_extraTabButton.ClearOnClickCallback();
					m_extraTabButton.AddOnClickCallback(() =>
					{
						//0x19454F8
						action(s_DecoItemTypeIndex[index]);
						ApplySelectSeriesButton(index);
					});
				}
			}
		}

		// RVA: 0x1942000 Offset: 0x1942000 VA: 0x1942000
		public void ChangeSelectTypes(int SelectSeries)
		{
			ApplySelectSeriesButton(SelectSeries);
		}

		// // RVA: 0x1942004 Offset: 0x1942004 VA: 0x1942004
		public void ApplySelectSeriesButton(int SelectSeries)
		{
			for(int i = 0; i < m_DecoTypeButtons.Count; i++)
			{
				if(!m_DecoTypeButtons[i].Disable)
				{
					if(SelectSeries == i)
					{
						m_DecoTypeButtons[i].enabled = false;
						m_DecoTypeButtons[i].SetOn();
						if(i == 1)
						{
							m_extraTabButton.enabled = false;
							m_extraTabButton.SetOn();
						}
					}
					else
					{
						m_DecoTypeButtons[i].enabled = true;
						m_DecoTypeButtons[i].SetOff();
						if(i == 1)
						{
							m_extraTabButton.enabled = true;
							m_extraTabButton.SetOff();
						}
					}
				}
			}
		}

		// // RVA: 0x19422C0 Offset: 0x19422C0 VA: 0x19422C0
		public void KyrrAnimation()
		{
			this.StartCoroutineWatched(Co_KyrrAnimation());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x726644 Offset: 0x726644 VA: 0x726644
		// // RVA: 0x19422E4 Offset: 0x19422E4 VA: 0x19422E4
		private IEnumerator Co_KyrrAnimation()
		{
			//0x1945714
			m_layoutKyrr.StartChildrenAnimGoStop("02", "02");
			m_ballon.StartChildrenAnimGoStop("go_in", "st_in");
			yield return null;
			while(m_ballon.IsPlaying())
				yield return null;
			yield return new WaitForSeconds(1);
			m_ballon.StartChildrenAnimGoStop("go_out", "st_out");
			yield return null;
			while(m_ballon.IsPlaying())
				yield return null;
			yield return new WaitForSeconds(0.2f);
			m_layoutKyrr.StartChildrenAnimGoStop("01", "01");
		}

		// // RVA: 0x1942390 Offset: 0x1942390 VA: 0x1942390
		private void OnClickDetailButton(FJGOKILCBJA view)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.KIJAPOFAGPN_ItemFullId);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
			{
				OpenPopupListItem(view, false);
				return;
			}
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				GCIJNCFDNON_SceneInfo data = new GCIJNCFDNON_SceneInfo();
				data.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.KIJAPOFAGPN_ItemFullId), null, null, 0, 0, 0, false, 0, 0);
				MenuScene.Instance.ShowSceneStatusPopupWindow(data, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, true, true, SceneStatusParam.PageSave.None, false);
				return;
			}
			MenuScene.Instance.ShowItemDetail(view.KIJAPOFAGPN_ItemFullId, MessageManager.Instance.GetBank("menu").GetMessageByLabel("item_detail_popup_title_00"), EKLNMHFCAOI.ILKGBGOCLAO_GetItemDesc(cat, EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.KIJAPOFAGPN_ItemFullId)), true);
        }

		// // RVA: 0x19427C8 Offset: 0x19427C8 VA: 0x19427C8
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
				//0x194563C
				buy = num;
			};
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1945644
				if(type != PopupButton.ButtonType.Positive)
					return;
				if(OnChangeEvent != null)
					OnChangeEvent(buy, view);
			}, null, null, null);
		}

		// RVA: 0x1942CAC Offset: 0x1942CAC VA: 0x1942CAC Slot: 7
		protected override void OnSelectListItem(int value, SwapScrollListContent content)
		{
			LayoutShopProductListItem c = content as LayoutShopProductListItem;
			if(c != null)
			{
				OpenPopupListItem(c.View, true);
			}
		}

		// // RVA: 0x1942DB0 Offset: 0x1942DB0 VA: 0x1942DB0 Slot: 8
		protected override void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutShopProductListItem c = content as LayoutShopProductListItem;
			if(c != null)
			{
				c.SetStatus(m_view.INDDJNMPONH_Type, m_view.MHKCPJDNJKI[index]);
			}
		}

		// RVA: 0x1944D14 Offset: 0x1944D14 VA: 0x1944D14
		public void SetTabNum(bool isChara = true)
		{
			m_tabs.StartChildrenAnimGoStop(isChara ? "04" : "03");
		}

		// RVA: 0x1944DAC Offset: 0x1944DAC VA: 0x1944DAC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_texListSupport = GetComponent<TextureListSupport>();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textMedal.text = bk.GetMessageByLabel("item_popup_shop_text_01");
			m_layoutRoot = layout.FindViewById("sw_sel_shop_window_anim_03") as AbsoluteLayout;
			m_layoutWarning = layout.FindViewById("swtbl_wintext_02") as AbsoluteLayout;
			m_layoutMedal = layout.FindViewById("swtbl_window_coin") as AbsoluteLayout;
			m_tabs = layout.FindViewById("swtbl_btn_tab_02") as AbsoluteLayout;
			m_layoutKyrr = layout.FindViewById("swtbl_sel_shop_kyrr") as AbsoluteLayout;
			m_ballon = m_layoutKyrr.FindViewById("kyrr_item") as AbsoluteLayout;
			m_button.ClearOnClickCallback();
			m_button.AddOnClickCallback(() =>
			{
				//0x19453A0
				if(OnClickPopupEvent != null)
					OnClickPopupEvent();
			});
			m_noProductText.text = bk.GetMessageByLabel("shop_no_product_desc");
			Loaded();
			return true;
		}
    }
}
