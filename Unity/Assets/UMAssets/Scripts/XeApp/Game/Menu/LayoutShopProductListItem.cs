using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutShopProductListItem : LayoutShopListElemBase
	{
		[SerializeField]
		private Text m_textLimit; // 0x20
		[SerializeField]
		private Text m_textReset; // 0x24
		[SerializeField]
		private Text m_textName; // 0x28
		[SerializeField]
		private Text m_textRemain; // 0x2C
		[SerializeField]
		private Text m_textOwn; // 0x30
		[SerializeField]
		private Text m_textCost; // 0x34
		[SerializeField]
		private Text m_textCost2; // 0x38
		[SerializeField]
		private Text m_textWarning; // 0x3C
		[SerializeField]
		private Text m_textContainDecoSet; // 0x40
		[SerializeField]
		private RawImageEx[] m_imageItem; // 0x44
		[SerializeField]
		private ActionButton m_button; // 0x48
		[SerializeField]
		private ActionButton m_buttonItem; // 0x4C
		private AbsoluteLayout m_layoutLimit; // 0x50
		private AbsoluteLayout m_layoutCost; // 0x54
		private AbsoluteLayout m_layoutDecoSet; // 0x58
		private List<AbsoluteLayout> m_list_layout = new List<AbsoluteLayout>(); // 0x5C
		private FJGOKILCBJA m_view; // 0x60
		private int[] m_itemIdList = new int[2]; // 0x68

		public FJGOKILCBJA View { get { return m_view; } } //0x1942DA8
		protected override ButtonBase selectButton { get { return m_button; } } //0x1945AA0
		public Action<FJGOKILCBJA> OnClickDetailButton { get; set; } // 0x64

		// // RVA: 0x1941750 Offset: 0x1941750 VA: 0x1941750
		// public bool IsLoaded() { }

		// // RVA: 0x1942F18 Offset: 0x1942F18 VA: 0x1942F18
		public void SetStatus(AODFBGCCBPE.NJMPLEENNPO type, FJGOKILCBJA view)
		{
			m_view = view;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(view.FPJBMCDMAMO == 3)
			{
				object[] obj = new object[4]
				{
					view.JIHKOPIENAC.Month, view.JIHKOPIENAC.Day, 
					view.JIHKOPIENAC.Hour, view.JIHKOPIENAC.Minute
				};
				m_textReset.text = string.Format(bk.GetMessageByLabel("item_shop_reset_period"), obj);
				m_layoutLimit.StartChildrenAnimGoStop("limit_on_02");
			}
			else if(view.FPJBMCDMAMO == 2)
			{
				object[] obj = new object[4]
				{
					view.JIHKOPIENAC.Month, view.JIHKOPIENAC.Day, 
					view.JIHKOPIENAC.Hour, view.JIHKOPIENAC.Minute
				};
				m_textLimit.text = string.Format(bk.GetMessageByLabel("item_shop_limit_period"), obj);
				m_layoutLimit.StartChildrenAnimGoStop("limit_on");
			}
			else if(view.FPJBMCDMAMO == 1)
			{
				if(view.ELEPHBOKIGK_BuyLimit < 1)
				{
					object[] obj = new object[4]
					{
						view.JIHKOPIENAC.Month, view.JIHKOPIENAC.Day, 
						view.JIHKOPIENAC.Hour, view.JIHKOPIENAC.Minute
					};
					m_textLimit.text = string.Format(bk.GetMessageByLabel("item_shop_limit_period"), obj);
					m_layoutLimit.StartChildrenAnimGoStop("limit_on");
				}
				else
				{
					object[] obj = new object[4]
					{
						view.JIHKOPIENAC.Month, view.JIHKOPIENAC.Day, 
						view.JIHKOPIENAC.Hour, view.JIHKOPIENAC.Minute
					};
					m_textReset.text = string.Format(bk.GetMessageByLabel("item_shop_reset_period"), obj);
					m_layoutLimit.StartChildrenAnimGoStop("limit_on_02");
				}
			}
			else
			{
				m_layoutLimit.StartChildrenAnimGoStop("limit_off");
			}
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.KIJAPOFAGPN_ItemFullId);
			string name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(view.KIJAPOFAGPN_ItemFullId);
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.KIJAPOFAGPN_ItemFullId);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
			{
				name += "(" + NCPPAHHCCAO.EFNHFKLKNHJ(id) + ")";
			}
			name += " " + view.JDLJPNMLFID.ToString() + EKLNMHFCAOI.NDBLEADIDLA(cat, id);
			m_textName.text = name;
			int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
				m_textOwn.text = "";
			else
				m_textOwn.text = string.Format(bk.GetMessageByLabel("item_popup_text_00"), num);
			int remain = m_view.EAIJAAEKDAB_GetNumRemain();
			if(remain < 0)
			{
				m_textRemain.text = "";
			}
			else
			{
				m_textRemain.text = string.Format(bk.GetMessageByLabel("item_popup_shop_text_04"), remain != 0 ? remain.ToString() : "<color=#8E0529FF>0</color>");
			}
            cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.JPJMHLNOIAJ_ItemCostFullId);
			name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(view.JPJMHLNOIAJ_ItemCostFullId);
			id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.JPJMHLNOIAJ_ItemCostFullId);
			string s = EKLNMHFCAOI.NDBLEADIDLA(cat, id);
			if(type == AODFBGCCBPE.NJMPLEENNPO.FNLODOLMLML_3)
			{
				m_textCost.text = name;
				m_textCost2.text = string.Format(bk.GetMessageByLabel("item_popup_shop_text_02") + "{0, 4}" + s + " / " + bk.GetMessageByLabel("item_popup_shop_text_01") + "{1, 4}" + s, view.DKEPCPPCIKA_Price, view.DPFOJKHBBEH_GetNumCostItem());
			}
			else
			{
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
				{
					m_textCost.text = view.DKEPCPPCIKA_Price.ToString() + s;
				}
				else
				{
					m_textCost.text = string.Concat(new object[4]
					{
						name, " ", view.DKEPCPPCIKA_Price, s
					});
				}
			}
			m_itemIdList[1] = view.KIJAPOFAGPN_ItemFullId;
			m_imageItem[1].enabled = false;
			GameManager.Instance.ItemTextureCache.Load(view.KIJAPOFAGPN_ItemFullId, (IiconTexture image) =>
			{
				//0x194611C
				if(m_itemIdList[1] != view.KIJAPOFAGPN_ItemFullId)
					return;
				m_imageItem[1].enabled = true;
				image.Set(m_imageItem[1]);
			});
			m_itemIdList[0] = view.JPJMHLNOIAJ_ItemCostFullId;
			m_imageItem[0].enabled = false;
			GameManager.Instance.ItemTextureCache.Load(view.JPJMHLNOIAJ_ItemCostFullId, (IiconTexture image) =>
			{
				//0x1946318
				if(m_itemIdList[0] != view.JPJMHLNOIAJ_ItemCostFullId)
					return;
				m_imageItem[0].enabled = true;
				image.Set(m_imageItem[0]);
			});
			m_button.Disable = remain == 0 || view.CMOPCCPOEBA() == 0 || view.EMLHKJAPACA_IsAddOverflow(1);
			if(view.EMLHKJAPACA_IsAddOverflow(1))
			{
				m_layoutCost.StartChildrenAnimGoStop(type == AODFBGCCBPE.NJMPLEENNPO.FNLODOLMLML_3 ? "04" : "02");
				m_textWarning.text = bk.GetMessageByLabel("item_shop_caution_max");
			}
			else
			{
				if(view.CMOPCCPOEBA() != 0)
				{
					m_layoutCost.StartChildrenAnimGoStop(type == AODFBGCCBPE.NJMPLEENNPO.FNLODOLMLML_3 ? "03" : "01");
				}
				else
				{
					m_layoutCost.StartChildrenAnimGoStop(type == AODFBGCCBPE.NJMPLEENNPO.FNLODOLMLML_3 ? "04" : "02");
					m_textWarning.text = bk.GetMessageByLabel("item_shop_caution");
				}
			}
			m_textContainDecoSet.text = bk.GetMessageByLabel("shop_product_deco_set_contain_text");
			m_layoutDecoSet.StartChildrenAnimGoStop(view.PBNCFGDPJKG_DecoItemSet == 0 ? "02" : "01");
			ForceAnimationUpdate();
        }

		// RVA: 0x1945CA0 Offset: 0x1945CA0 VA: 0x1945CA0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutLimit = layout.FindViewById("swtbl_limit") as AbsoluteLayout;
			m_layoutCost = layout.FindViewById("swtbl_needitem_txt") as AbsoluteLayout;
			m_layoutDecoSet = layout.FindViewById("swtbl_shop_window_limit_set") as AbsoluteLayout;
			m_list_layout.Add(m_layoutLimit);
			m_list_layout.Add(m_layoutCost);
			m_list_layout.Add(m_layoutDecoSet);
			m_list_layout.Add(layout.FindViewById("cont_btn01") as AbsoluteLayout);
			m_buttonItem.AddOnClickCallback(() =>
			{
				//0x19460AC
				if(OnClickDetailButton != null)
					OnClickDetailButton(m_view);
			});
			Loaded();
			return true;
		}

		// // RVA: 0x1945AB8 Offset: 0x1945AB8 VA: 0x1945AB8
		public void ForceAnimationUpdate()
		{
			for(int i = 0; i < m_list_layout.Count; i++)
			{
				if(m_list_layout[i] != null)
				{
					m_list_layout[i].UpdateAllAnimation(TimeWrapper.deltaTime * 2, false);
					m_list_layout[i].UpdateAll(new Matrix23(), Color.white);
				}
			}
		}
	}
}
