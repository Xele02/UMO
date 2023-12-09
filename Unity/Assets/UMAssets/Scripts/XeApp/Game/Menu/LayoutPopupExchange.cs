using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class LayoutPopupExchange : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textName; // 0x14
		[SerializeField]
		private Text m_textRemain; // 0x18
		[SerializeField]
		private Text[] m_textOwn4d = new Text[3]; // 0x1C
		[SerializeField]
		private Text[] m_textOwn8d = new Text[3]; // 0x20
		[SerializeField]
		private Text m_textContent; // 0x24
		[SerializeField]
		private Text m_textOwnCoin; // 0x28
		[SerializeField]
		private Text m_textOwnCoinNum; // 0x2C
		[SerializeField]
		private Text m_textCostCoin; // 0x30
		[SerializeField]
		private Text m_textCostCoinNum; // 0x34
		[SerializeField]
		private Text m_textWarning; // 0x38
		[SerializeField]
		private RawImageEx m_imageItem; // 0x3C
		[SerializeField]
		private RawImageEx m_imagePlate; // 0x40
		[SerializeField]
		private RawImageEx m_imageCost; // 0x44
		[SerializeField]
		private ActionButton m_buttonItem; // 0x48
		[SerializeField]
		private ActionButton m_buttonPlate; // 0x4C
		private AbsoluteLayout m_layoutItem; // 0x50
		private AbsoluteLayout m_layoutDigit; // 0x54
		private AbsoluteLayout m_layoutWarning; // 0x58
		private FJGOKILCBJA m_view; // 0x5C
		private int m_count = 1; // 0x60
		private int m_ownItemNum; // 0x64
		private int m_ownNeedItemNum; // 0x68
		private bool m_initialized; // 0x6C

		public Action<int> OnChangeCallback { get; set; } // 0x70

		// RVA: 0x1728E7C Offset: 0x1728E7C VA: 0x1728E7C
		private void Update()
		{
			return;
		}

		// // RVA: 0x1728E80 Offset: 0x1728E80 VA: 0x1728E80
		public bool IsLoading()
		{
			if(m_initialized)
			{
				if(m_imagePlate.enabled)
				{
					if(m_imageItem.enabled)
					{
						if(m_imageCost.enabled)
							return !IsLoaded();
					}
				}
			}
			return true;
		}

		// // RVA: 0x1728F2C Offset: 0x1728F2C VA: 0x1728F2C
		public void SetStatus(FJGOKILCBJA view)
		{
			m_view = view;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.KIJAPOFAGPN_ItemFullId);
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.KIJAPOFAGPN_ItemFullId);
            m_textName.text = EKLNMHFCAOI.INCKKODFJAP_GetItemName(view.KIJAPOFAGPN_ItemFullId) + " " + view.JDLJPNMLFID_Count.ToString() + EKLNMHFCAOI.NDBLEADIDLA(cat, id);
			m_ownItemNum = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
			m_textOwn4d[1].text = m_ownItemNum.ToString();
			m_textOwn8d[1].text = m_ownItemNum.ToString();
			m_textContent.text = string.Format(bk.GetMessageByLabel("pop_exchange_need_item"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(view.JPJMHLNOIAJ_ItemCostFullId));
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
				scene.KHEKNNFCAOI(id, null, null, 0, 0, 0, false, 0, 0);
				m_imagePlate.enabled = false;
				int rank = scene.JOKJBMJBLBB_Single ? 2 : 1;
				GameManager.Instance.SceneIconCache.Load(id, rank, (IiconTexture image) =>
				{
					//0x172A5E4
					m_layoutItem.StartChildrenAnimGoStop("plate");
					m_imagePlate.enabled = true;
					image.Set(m_imagePlate);
				});
			}
			else
			{
				m_imageItem.enabled = false;
				GameManager.Instance.ItemTextureCache.Load(view.KIJAPOFAGPN_ItemFullId, (IiconTexture image) =>
				{
					//0x172A754
					m_layoutItem.StartChildrenAnimGoStop("item");
					m_imageItem.enabled = true;
					image.Set(m_imageItem);
				});
			}
			m_imageCost.enabled = false;
			GameManager.Instance.ItemTextureCache.Load(view.KIJAPOFAGPN_ItemFullId, (IiconTexture image) =>
			{
				//0x172A8C4
				m_imageCost.enabled = true;
				image.Set(m_imageCost);
			});
			UpdateCount(0);
			m_buttonItem.AddOnClickCallback(() =>
			{
				//0x172A9F0
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				MenuScene.Instance.ShowItemDetail(m_view.KIJAPOFAGPN_ItemFullId, m_view.JDLJPNMLFID_Count, null);
			});
			m_buttonPlate.AddOnClickCallback(() =>
			{
				//0x172AB64
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				GCIJNCFDNON_SceneInfo scene = new GCIJNCFDNON_SceneInfo();
				scene.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(m_view.KIJAPOFAGPN_ItemFullId), null, null, 0, 0, 0, false, 0, 0);
				MenuScene.Instance.ShowSceneStatusPopupWindow(scene, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, false, true, SceneStatusParam.PageSave.None, false);
			});
			m_initialized = true;
		}

		// // RVA: 0x1729970 Offset: 0x1729970 VA: 0x1729970
		private void UpdateCount(int count = 0)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int[] li = new int[4];
			li[0] = m_view.EAIJAAEKDAB_GetNumRemain();
			li[1] = m_view.CMOPCCPOEBA();
			li[2] = m_view.PHBCFNIJLJH();
			li[3] = m_view.JNLPLBJKGDC;
			if(li[0] == -1)
				li[0] = li[1];
			m_count = Mathf.Clamp(m_count + count, 0, Mathf.Min(li));
			if(li[0] == -1)
			{
				m_textRemain.text = "";
			}
			else
			{
				m_textRemain.text = string.Format(bk.GetMessageByLabel("item_popup_shop_text_04"), li[0]);
			}
			int cnt = m_ownItemNum + (m_count * m_view.JDLJPNMLFID_Count);
			m_textOwn4d[2].text = cnt.ToString();
			m_textOwn8d[2].text = m_textOwn4d[2].text;
			m_layoutDigit.StartChildrenAnimGoStop(cnt < 10000 ? "4digits" : "8digits");
			m_textCostCoinNum.text = m_view.DKEPCPPCIKA_Price.ToString();
			m_ownNeedItemNum = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_view.JPJMHLNOIAJ_ItemCostFullId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(m_view.JPJMHLNOIAJ_ItemCostFullId), null);
			m_layoutWarning.enabled = false;
			m_textOwnCoinNum.text = m_ownNeedItemNum.ToString();
			if(OnChangeCallback != null)
				OnChangeCallback(m_count);
		}

		// RVA: 0x172A11C Offset: 0x172A11C VA: 0x172A11C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutItem = layout.FindViewById("swtbl_exchange_item") as AbsoluteLayout;
			m_layoutDigit = layout.FindViewById("swtbl_digits") as AbsoluteLayout;
			m_layoutWarning = layout.FindViewById("swtbl_pop_cau_txt") as AbsoluteLayout;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textOwn4d[0].text = bk.GetMessageByLabel("item_popup_shop_text_01");
			m_textOwn8d[0].text = bk.GetMessageByLabel("item_popup_shop_text_01");
			m_textOwnCoin.text = bk.GetMessageByLabel("item_popup_shop_text_01");
			m_textCostCoin.text = bk.GetMessageByLabel("item_popup_shop_text_02");
			m_textWarning.text = bk.GetMessageByLabel("growth_popup_text05");
			Loaded();
			return true;
		}
	}
}
