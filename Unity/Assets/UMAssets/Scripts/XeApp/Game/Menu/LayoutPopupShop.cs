using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using XeApp.Game.Common;
using System;
using XeSys;
using System.Collections;
using XeApp.Core;
using mcrs;
using System.Linq;

namespace XeApp.Game.Menu
{
	public class LayoutPopupShop : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textName; // 0x14
		[SerializeField]
		private Text m_textRemain; // 0x18
		[SerializeField]
		private Text m_textCount; // 0x1C
		[SerializeField]
		private Text[] m_textOwn4d = new Text[3]; // 0x20
		[SerializeField]
		private Text[] m_textOwn8d = new Text[3]; // 0x24
		[SerializeField]
		private Text[] m_textContent = new Text[2]; // 0x28
		[SerializeField]
		private Text m_textOwnCoin; // 0x2C
		[SerializeField]
		private Text m_textOwnCoinNum; // 0x30
		[SerializeField]
		private Text m_textCostCoin; // 0x34
		[SerializeField]
		private Text m_textCostCoinNum; // 0x38
		[SerializeField]
		private Text[] m_textWarning = new Text[2]; // 0x3C
		[SerializeField]
		private RawImageEx[] m_imageItem = new RawImageEx[2]; // 0x40
		[SerializeField]
		private RawImageEx m_imagePlate; // 0x44
		[SerializeField]
		private RawImageEx m_imageCost; // 0x48
		[SerializeField]
		private ActionButton m_buttonItem; // 0x4C
		[SerializeField]
		private ActionButton m_buttonPlate; // 0x50
		[SerializeField]
		private ActionButton m_buttonPuls1; // 0x54
		[SerializeField]
		private ActionButton m_buttonPuls10; // 0x58
		[SerializeField]
		private ActionButton m_buttonMinus1; // 0x5C
		[SerializeField]
		private ActionButton m_buttonMinus10; // 0x60
		private AbsoluteLayout m_layoutItem; // 0x64
		private AbsoluteLayout m_layoutDigit; // 0x68
		private AbsoluteLayout m_layoutWarning; // 0x6C
		private AbsoluteLayout m_layoutAction; // 0x70
		private FJGOKILCBJA m_view; // 0x74
		private BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo m_decoSetItem; // 0x78
		private int m_count; // 0x7C
		private int m_ownItemNum; // 0x80
		private int m_ownNeedItemNum; // 0x84
		private bool m_initialized; // 0x88
		[SerializeField] // RVA: 0x67B3CC Offset: 0x67B3CC VA: 0x67B3CC
		private SwapScrollList m_swapScrollList; // 0x90

		public Action<int, bool> OnChangeCallback { get; set; } // 0x8C

		// RVA: 0x178502C Offset: 0x178502C VA: 0x178502C
		private void Update()
		{
			return;
		}

		// // RVA: 0x1785030 Offset: 0x1785030 VA: 0x1785030
		public bool IsLoading()
		{
			if(m_initialized)
			{
				if(m_imagePlate.enabled)
				{
					if(m_imageItem[0].enabled)
					{
						if(m_imageItem[1].enabled)
						{
							if(m_imageCost.enabled)
								return !IsLoaded();
						}
					}
				}
			}
			return true;
		}

		// // RVA: 0x1785164 Offset: 0x1785164 VA: 0x1785164
		public void SetStatus(FJGOKILCBJA view, bool isBuy)
		{
			m_view = view;
			string name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(view.KIJAPOFAGPN_ItemFullId);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.KIJAPOFAGPN_ItemFullId);
            int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.KIJAPOFAGPN_ItemFullId);
			m_textName.text = name + " " + view.JDLJPNMLFID_Count + EKLNMHFCAOI.NDBLEADIDLA(cat, id);
			m_ownItemNum = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
			m_textOwn4d[1].text = m_ownItemNum.ToString();
			m_textOwn8d[1].text = m_ownItemNum.ToString();
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				name = bk.GetMessageByLabel("item_episode_plate");
			}
			m_textContent[0].text = string.Format(bk.GetMessageByLabel("item_popup_shop_text_03"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(view.JPJMHLNOIAJ_ItemCostFullId), name);
			m_textContent[1].text = bk.GetMessageByLabel("popup_deco_set_item_detaile_list");
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				GCIJNCFDNON_SceneInfo sceneData = new GCIJNCFDNON_SceneInfo();
				sceneData.KHEKNNFCAOI(id, null, null, 0, 0, 0, false, 0, 0);
				m_imagePlate.enabled = false;
				GameManager.Instance.SceneIconCache.Load(sceneData.BCCHOBPJJKE_SceneId, sceneData.JOKJBMJBLBB_Single ? 2 : 1, (IiconTexture image) =>
				{
					//0x1787C24
					m_layoutItem.StartChildrenAnimGoStop("plate");
					m_imagePlate.enabled = true;
					image.Set(m_imagePlate);
				});
			}
			else
			{
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
				{
					m_imageItem[1].enabled = false;
					GameManager.Instance.ItemTextureCache.Load(view.KIJAPOFAGPN_ItemFullId, (IiconTexture image) =>
					{
						//0x1787D58
						m_imageItem[1].enabled = true;
						image.Set(m_imageItem[1]);
					});
				}
				else
				{
					m_imageItem[0].enabled = false;
					GameManager.Instance.ItemTextureCache.Load(view.KIJAPOFAGPN_ItemFullId, (IiconTexture image) =>
					{
						//0x1787EBC
						m_layoutItem.StartChildrenAnimGoStop("item");
						m_imageItem[0].enabled = true;
						image.Set(m_imageItem[0]);
					});
				}
			}
			m_imageCost.enabled = false;
			GameManager.Instance.ItemTextureCache.Load(view.JPJMHLNOIAJ_ItemCostFullId, (IiconTexture image) =>
			{
				//0x1788050
				m_imageCost.enabled = true;
				image.Set(m_imageCost);
			});
			UpdateCount(0);
			m_buttonPuls1.AddOnClickCallback(() =>
			{
				//0x1788154
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				UpdateCount(1);
			});
			m_buttonPuls10.AddOnClickCallback(() =>
			{
				//0x17881BC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				UpdateCount(10);
			});
			m_buttonMinus1.AddOnClickCallback(() =>
			{
				//0x1788224
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				UpdateCount(-1);
			});
			m_buttonMinus10.AddOnClickCallback(() =>
			{
				//0x178828C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
				UpdateCount(-10);
			});
			m_buttonItem.AddOnClickCallback(() =>
			{
				//0x17882F4
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				OpenPopupItemDetail(m_view.KIJAPOFAGPN_ItemFullId);
			});
			m_buttonPlate.AddOnClickCallback(() =>
			{
				//0x178837C
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				OpenPopupPlateDetail(EKLNMHFCAOI.DEACAHNLMNI_getItemId(m_view.KIJAPOFAGPN_ItemFullId));
			});
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
			{
				UpdateCount(1);
				m_layoutAction.StartChildrenAnimGoStop(isBuy ? "02" : "03");
				m_decoSetItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA[id - 1];
				m_swapScrollList.Apply();
				m_swapScrollList.SetContentEscapeMode(false);
				m_swapScrollList.SetItemCount(m_decoSetItem.JJBNDDDGEAN_GetNumItems());
				m_swapScrollList.OnUpdateItem.RemoveAllListeners();
				m_swapScrollList.OnUpdateItem.AddListener(OnUpdateListItem);
				m_swapScrollList.SetPosition(0, 0, 0, false);
				m_swapScrollList.VisibleRegionUpdate();
			}
			else
			{
				m_layoutAction.StartChildrenAnimGoStop("01");
			}
			m_layoutWarning.StartChildrenAnimGoStop(m_view.PBNCFGDPJKG_DecoItemSet == 0 ? "cau_off" : "cau_on_02");
			m_initialized = true;
		}

		// // RVA: 0x17861BC Offset: 0x17861BC VA: 0x17861BC
		private void UpdateCount(int count = 0)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int[] l = new int[4]
			{
				m_view.EAIJAAEKDAB_GetNumRemain(),
				m_view.CMOPCCPOEBA(),
				m_view.PHBCFNIJLJH(),
				m_view.JNLPLBJKGDC
			};
			int max = Mathf.Min(l);
			m_count = Mathf.Clamp(m_count + count, 0, max);
			m_textCount.text = m_count.ToString();
			if(l[0] == -1)
			{
				m_textRemain.text = "";
			}
			else
			{
				m_textRemain.text = string.Format(bk.GetMessageByLabel("item_popup_shop_text_04"), l[0] - m_count);
			}
			m_textOwn4d[2].text = (m_ownItemNum + m_view.JDLJPNMLFID_Count * m_count).ToString();
			m_textOwn8d[2].text = (m_ownItemNum + m_view.JDLJPNMLFID_Count * m_count).ToString();
			m_layoutDigit.StartChildrenAnimGoStop(m_ownItemNum + m_view.JDLJPNMLFID_Count * m_count < 10000 ? "4digits" : "8digits");
			m_textCostCoinNum.text = (m_count * m_view.DKEPCPPCIKA_Price).ToString();
			m_ownNeedItemNum = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_view.JPJMHLNOIAJ_ItemCostFullId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(m_view.JPJMHLNOIAJ_ItemCostFullId), null);
			m_textOwnCoinNum.text = m_ownNeedItemNum.ToString();
			m_buttonPuls1.Disable = max - 1 - m_count < 0;
			m_buttonPuls10.Disable = max - 1 - m_count < 0;
			m_buttonMinus1.Disable = m_count - 1 < 0;
			m_buttonMinus10.Disable = m_count - 1 < 0;
			if(OnChangeCallback != null)
				OnChangeCallback(m_count, false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70F114 Offset: 0x70F114 VA: 0x70F114
		// // RVA: 0x1786A54 Offset: 0x1786A54 VA: 0x1786A54
		public IEnumerator Co_LoadScrollItemContent()
		{
			AssetBundleLoadLayoutOperationBase layout;

			//0x178848C
			GameObject source = null;
			layout = AssetBundleManager.LoadLayoutAsync("ly/106.xab", "root_pop_deco_item_layout_root");
			yield return layout;
			yield return Co.R(layout.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject obj) =>
			{
				//0x1788480
				source = obj;
			}));
			AssetBundleManager.UnloadAssetBundle("ly/106.xab", false);
			LayoutUGUIRuntime runtime = source.GetComponent<LayoutUGUIRuntime>();
			for(int i = 0; i < m_swapScrollList.ScrollObjectCount; i++)
			{
				GameObject g = Instantiate(source);
				LayoutUGUIRuntime r = g.GetComponent<LayoutUGUIRuntime>();
				r.Layout = runtime.Layout.DeepClone();
				r.UvMan = runtime.UvMan;
				r.LoadLayout();
				LayoutPopupShopSetItem s = g.GetComponent<LayoutPopupShopSetItem>();
				s.OnSelectCallback = OnSelectListItem;
				m_swapScrollList.AddScrollObject(s);
			}
			yield return null;
			Destroy(source);
		}

		// // RVA: 0x1786B00 Offset: 0x1786B00 VA: 0x1786B00
		private void OpenPopupItemDetail(int itemId)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
			{
				PopupDecoSetItemDetaileSetting s = new PopupDecoSetItemDetaileSetting();
				s.TitleText = bk.GetMessageByLabel("popup_deco_set_item_detaile_title");
				s.View = m_view;
				s.WindowSize = SizeType.Middle;
				s.SetParent(transform);
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				PopupWindowManager.Show(s, null, null, null, null);
			}
			else
			{
				MenuScene.Instance.ShowItemDetail(itemId, bk.GetMessageByLabel("item_detail_popup_title_00"), EKLNMHFCAOI.ILKGBGOCLAO_GetItemDesc(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId)), false);
			}
		}

		// // RVA: 0x1786EFC Offset: 0x1786EFC VA: 0x1786EFC
		private void OpenPopupPlateDetail(int sceneId)
		{
			GCIJNCFDNON_SceneInfo sceneData = new GCIJNCFDNON_SceneInfo();
			sceneData.KHEKNNFCAOI(sceneId, null, null, 0, 0, 0, false, 0, 0);
			MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, false, true, SceneStatusParam.PageSave.None, false);
		}

		// // RVA: 0x1787090 Offset: 0x1787090 VA: 0x1787090
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			LayoutPopupShopSetItem c = content as LayoutPopupShopSetItem;
			if(c != null)
			{
				c.SetStatus(m_decoSetItem, index);
			}
		}

		// // RVA: 0x1787564 Offset: 0x1787564 VA: 0x1787564
		private void OnSelectListItem(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			OpenPopupItemDetail(m_decoSetItem.FKNBLDPIPMC_GetItemCode(index));
		}

		// RVA: 0x17875F4 Offset: 0x17875F4 VA: 0x17875F4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutItem = layout.FindViewById("swtbl_exchange_item") as AbsoluteLayout;
			m_layoutDigit = layout.FindViewById("swtbl_digits") as AbsoluteLayout;
			m_layoutWarning = layout.FindViewById("swtbl_pop_cau_txt") as AbsoluteLayout;
			m_layoutAction = layout.FindViewById("swtbl_shop_pop_c") as AbsoluteLayout;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_textOwn4d[0].text = bk.GetMessageByLabel("item_popup_shop_text_01");
			m_textOwn8d[0].text = bk.GetMessageByLabel("item_popup_shop_text_01");
			m_textOwnCoin.text = bk.GetMessageByLabel("item_popup_shop_text_01");
			m_textCostCoin.text = bk.GetMessageByLabel("item_popup_shop_text_02");
			m_textWarning[0].text = bk.GetMessageByLabel("deco_set_buy_warn_text");
			m_textWarning[1].text = bk.GetMessageByLabel("popup_deco_set_item_detaile_caution");
			Loaded();
			return true;
		}
	}
}
