using UnityEngine.UI;
using UnityEngine;
using XeSys.Gfx;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutShopProductListItem2 : LayoutShopListElemBase
	{
		[SerializeField]
		private Text m_textName; // 0x20
		[SerializeField]
		private Text m_textRemain; // 0x24
		[SerializeField]
		private Text m_textOwn; // 0x28
		[SerializeField]
		private Text m_textCost; // 0x2C
		[SerializeField]
		private Text m_textCost2; // 0x30
		[SerializeField]
		private Text m_textWarning; // 0x34
		[SerializeField]
		private RawImageEx[] m_imageItem = new RawImageEx[2]; // 0x38
		[SerializeField]
		private ActionButton m_button; // 0x3C
		[SerializeField]
		private ActionButton m_buttonItem; // 0x40
		private AbsoluteLayout m_layoutCost; // 0x44
		private List<AbsoluteLayout> m_list_layout = new List<AbsoluteLayout>(); // 0x48
		private FJGOKILCBJA m_view; // 0x4C
		private int[] m_itemIdList = new int[2]; // 0x54

		public FJGOKILCBJA View { get { return m_view; } } //0x1946514
		protected override ButtonBase selectButton { get { return m_button; } } //0x194651C
		public Action<FJGOKILCBJA> OnClickDetailButton { get; set; } // 0x50

		// // RVA: 0x1946534 Offset: 0x1946534 VA: 0x1946534
		// public bool IsLoaded() { }

		// // RVA: 0x19465DC Offset: 0x19465DC VA: 0x19465DC
		public void SetStatus(AODFBGCCBPE.NJMPLEENNPO type, FJGOKILCBJA view)
		{
			m_view = view;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.KIJAPOFAGPN_ItemFullId);
			string name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(view.KIJAPOFAGPN_ItemFullId);
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.KIJAPOFAGPN_ItemFullId);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
			{
				name += "(" + NCPPAHHCCAO.EFNHFKLKNHJ(id) + ")";
			}
			m_textName.text = name + " " + view.JDLJPNMLFID.ToString() + EKLNMHFCAOI.NDBLEADIDLA(cat, id);
			int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
			{
				m_textOwn.text = "";
			}
			else
			{
				m_textOwn.text = string.Format(bk.GetMessageByLabel("item_popup_text_00"), num);
			}
			int remain = view.EAIJAAEKDAB_GetNumRemain();
			if(remain < 0)
				m_textRemain.text = "";
			else
				m_textRemain.text = string.Format(bk.GetMessageByLabel("item_popup_shop_text_04"), remain != 0 ? remain.ToString() : "<color=#8E0529FF>0</color>");
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
					m_textCost.text = view.DKEPCPPCIKA_Price + s;
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
			GameManager.Instance.SceneIconCache.Load(EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.KIJAPOFAGPN_ItemFullId), 1, (IiconTexture image) =>
			{
				//0x1947C6C
				if(m_itemIdList[1] != view.KIJAPOFAGPN_ItemFullId)
					return;
				m_imageItem[1].enabled = true;
				image.Set(m_imageItem[1]);
			});
			m_itemIdList[0] = view.JPJMHLNOIAJ_ItemCostFullId;
			m_imageItem[0].enabled = false;
			GameManager.Instance.ItemTextureCache.Load(view.JPJMHLNOIAJ_ItemCostFullId, (IiconTexture image) =>
			{
				//0x1947E68
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
			ForceAnimationUpdate();
       }

		// RVA: 0x194792C Offset: 0x194792C VA: 0x194792C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutCost = layout.FindViewById("swtbl_needitem_txt") as AbsoluteLayout;
			m_list_layout.Add(m_layoutCost);
			m_list_layout.Add(layout.FindViewById("cont_btn01") as AbsoluteLayout);
			m_buttonItem.AddOnClickCallback(() =>
			{
				//0x1947BFC
				if(OnClickDetailButton != null)
					OnClickDetailButton(m_view);
			});
			Loaded();
			return true;
		}

		// // RVA: 0x1947744 Offset: 0x1947744 VA: 0x1947744
		public void ForceAnimationUpdate()
		{
			for(int i = 0; i < m_list_layout.Count; i++)
			{
				if(m_list_layout[i] != null)
				{
					m_list_layout[i].UpdateAllAnimation(2 * TimeWrapper.deltaTime, false);
					m_list_layout[i].Update(new Matrix23(), Color.white);
				}
			}
		}
	}
}
