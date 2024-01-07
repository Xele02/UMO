using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mcrs;
using UnityEditor;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class ShopProductScene : TransitionRoot
	{
		public class ShopProductArgs : TransitionArgs
		{
			public AODFBGCCBPE view { get; set; } // 0x8
		}
		
		public enum SortOrder
		{
			Small = 0,
			Big = 1,
		}

		private static readonly EKLNMHFCAOI.FKGCBLHOOCL_Category[] s_DecoItemTypeIndex = new EKLNMHFCAOI.FKGCBLHOOCL_Category[5]
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara, 
			EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif, 
			EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj, 
			EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem, 
			EKLNMHFCAOI.FKGCBLHOOCL_Category.BMMBLLOKNPF_DecoItemSp
		}; // 0x0
		private LayoutShopProductListWindow m_listProduct; // 0x4C
		private LayoutShopProductListDecoWindow m_listDecoProduct; // 0x50
		private List<FJGOKILCBJA> m_productDatas; // 0x54
		private List<FJGOKILCBJA>[] m_productData; // 0x58
		private List<SwapScrollListContent>[] m_listContent = new List<SwapScrollListContent>[2]
		{
			new List<SwapScrollListContent>(),
			new List<SwapScrollListContent>()
		}; // 0x5C
		public int Select; // 0x60
		private PopupSortMenu.SortPlace sortPlace = PopupSortMenu.SortPlace.DecoShopList; // 0x64
		private uint m_seriesFilter; // 0x68
		private uint m_interiorFilter; // 0x6C
		private bool isLoadError; // 0x70
		private List<FJGOKILCBJA> m_productFilterData = new List<FJGOKILCBJA>(); // 0x74
		private const DisplayType DefaultDisplayType = 0;
		private SortItem m_sortType; // 0x78
		private SortOrder m_order = SortOrder.Big; // 0x7C
		private List<FJGOKILCBJA> m_productSortList = new List<FJGOKILCBJA>(); // 0x80
		private int m_rarityMin = -1; // 0x84
		private int m_rarityMax = -1; // 0x88
		private GCIJNCFDNON_SceneInfo leftScene = new GCIJNCFDNON_SceneInfo(); // 0x8C
		private GCIJNCFDNON_SceneInfo rightScene = new GCIJNCFDNON_SceneInfo(); // 0x90

		private ShopProductArgs myArgs { get; set; } // 0x48
		// public static SortOrder DefaultSortOrder { get; } 0xC44140

		// RVA: 0xC3EDE8 Offset: 0xC3EDE8 VA: 0xC3EDE8 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_productDatas = new List<FJGOKILCBJA>();
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0xC3EF18 Offset: 0xC3EF18 VA: 0xC3EF18 Slot: 16
		protected override void OnPreSetCanvas()
		{
			if(isLoadError)
				return;
			base.OnPreSetCanvas();
			InitializeSortSetting();
			myArgs = Args as ShopProductArgs;
			Select = 0;
			m_listProduct.List.RemoveScrollObject();
			if(myArgs.view.INDDJNMPONH >= AODFBGCCBPE.NJMPLEENNPO.MGEGNNJLJII_7)
			{
				for(int i = 0; i < m_listContent[0].Count; i++)
				{
					m_listContent[0][i].transform.SetParent(null);
				}
				for(int i = 0; i < m_listContent[1].Count; i++)
				{
					m_listProduct.List.AddScrollObject(m_listContent[1][i]);
				}
			}
			else
			{
				for(int i = 0; i < m_listContent[0].Count; i++)
				{
					m_listProduct.List.AddScrollObject(m_listContent[0][i]);
				}
				for(int i = 0; i < m_listContent[1].Count; i++)
				{
					m_listContent[1][i].transform.SetParent(null);
				}
			}
			m_listProduct.List.Apply();
			m_listProduct.List.SetContentEscapeMode(true);
			m_listProduct.Hide();
			int num = 0;
			if(myArgs.view.INDDJNMPONH <= AODFBGCCBPE.NJMPLEENNPO.ACFEDNPIJKM_8)
			{
				num = 1;
				if(((1 << (int)myArgs.view.INDDJNMPONH) & 0x1deU) == 0)
				{
					if(myArgs.view.INDDJNMPONH != AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5)
						Debug.Log("shop data shoptype erorr...");
					else
					{
						num = s_DecoItemTypeIndex.Length;
					}
				}
			}
			else
			{
				Debug.Log("shop data shoptype erorr...");
			}
			m_productData = new List<FJGOKILCBJA>[num];
			for(int i = 0; i < m_productData.Length; i++)
			{
				m_productData[i] = new List<FJGOKILCBJA>();
			}
			m_productDatas = new List<FJGOKILCBJA>(myArgs.view.MHKCPJDNJKI);
			if(myArgs.view.INDDJNMPONH <= AODFBGCCBPE.NJMPLEENNPO.ACFEDNPIJKM_8)
			{
				if(((1 << (int)myArgs.view.INDDJNMPONH) & 0x1deU) == 0)
				{
					if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5)
					{
						for(int i = 0; i < m_productDatas.Count; i++)
						{
							m_productData[ConvertDecoItemTypeIndex(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(myArgs.view.MHKCPJDNJKI[i].KIJAPOFAGPN_ItemFullId))].Add(myArgs.view.MHKCPJDNJKI[i]);
						}
					}
				}
				else
				{
					m_productData[0] = m_productDatas;
				}
			}
			if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5)
			{
				for(int i = 0; i < m_productData.Length; i++)
				{
					SortDecoItemCommon(m_productData[i]);
				}
				myArgs.view.MHKCPJDNJKI = FilterList();
			}
			else
			{
				myArgs.view.MHKCPJDNJKI = m_productData[Select];
			}
			Initialize();
		}

		// RVA: 0xC419A0 Offset: 0xC419A0 VA: 0xC419A0
		private void Update()
		{
			return;
		}

		// // RVA: 0xC3FCF0 Offset: 0xC3FCF0 VA: 0xC3FCF0
		private int ConvertDecoItemTypeIndex(EKLNMHFCAOI.FKGCBLHOOCL_Category type)
		{
			for(int i = 0; i < s_DecoItemTypeIndex.Length; i++)
			{
				if(s_DecoItemTypeIndex[i] == type)
					return i;
			}
			return 0;
		}

		// // RVA: 0xC3FE48 Offset: 0xC3FE48 VA: 0xC3FE48
		private void SortDecoItemCommon(List<FJGOKILCBJA> shopProductDataList)
		{
			List<FJGOKILCBJA> l = new List<FJGOKILCBJA>();
			int end = shopProductDataList.Count;
			for(int i = 0; i < end; i++)
			{
				EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(shopProductDataList[i].KIJAPOFAGPN_ItemFullId);
				int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(shopProductDataList[i].KIJAPOFAGPN_ItemFullId);
				if(cat < EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
				{
					if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj)
					{
						NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj.Find((NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem item) =>
						{
							//0xC4587C
							return id == item.PPFNGGCBJKC_Id;
						});
						if(it.CPKMLLNADLJ != 0)
							continue;
					}
					if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
					{
						NDBFKHKMMCE_DecoItem.CCHHGIJMLBN_CharaItem it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KHCACDIKJLG_ItemsChara.Find((NDBFKHKMMCE_DecoItem.CCHHGIJMLBN_CharaItem item) =>
						{
							//0xC457F4
							return id == item.PPFNGGCBJKC_Id;
						});
						if(it.CPKMLLNADLJ != 0)
							continue;
					}
				}
				else
				{
					if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
					{
                        IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
						{
							//0xC45838
							return id == item.PPFNGGCBJKC;
						});
                        if (it.CPKMLLNADLJ != 0)
							continue;
					}
					if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
					{
                        BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA.Find((BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo item) =>
						{
							//0xC458C0
							return id == item.PPFNGGCBJKC_Id;
						});
                        if (it.CPKMLLNADLJ != 0)
							continue;
					}
				}
				//LAB_00c40024
				FJGOKILCBJA data = new FJGOKILCBJA();
				data.CLCJHOIDENO(shopProductDataList[i].OPKDAIMPJBH_ShopId, cat, id, shopProductDataList[i].ELEPHBOKIGK_BuyLimit, shopProductDataList[i].DKEPCPPCIKA_Price);
				shopProductDataList.Remove(shopProductDataList[i]);
				shopProductDataList.Add(data);
				end--;
				i--;
			}
		}

		// RVA: 0xC419AC Offset: 0xC419AC VA: 0xC419AC Slot: 18
		protected override void OnPostSetCanvas()
		{
			base.OnPostSetCanvas();
		}

		// RVA: 0xC419B4 Offset: 0xC419B4 VA: 0xC419B4 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xC41A54 Offset: 0xC41A54 VA: 0xC41A54 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5)
			{
				MenuScene.Instance.FooterLeave();
				m_listDecoProduct.Enter();
			}
			else
			{
				m_listProduct.Enter();
			}
		}

		// RVA: 0xC41B50 Offset: 0xC41B50 VA: 0xC41B50 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			if(myArgs.view.INDDJNMPONH != AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5)
				return !m_listProduct.IsPlaying();
			return !m_listDecoProduct.IsPlaying();
		}

		// RVA: 0xC41BE0 Offset: 0xC41BE0 VA: 0xC41BE0 Slot: 12
		protected override void OnStartExitAnimation()
		{
			if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5)
			{
				m_listDecoProduct.Leave();
			}
			else
			{
				m_listProduct.Leave();
			}
		}

		// RVA: 0xC41C44 Offset: 0xC41C44 VA: 0xC41C44 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			if(myArgs.view.INDDJNMPONH != AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5)
				return !m_listProduct.IsPlaying();
			return !m_listDecoProduct.IsPlaying() && m_listDecoProduct.IsLoadedProductImage();
		}

		// RVA: 0xC41CFC Offset: 0xC41CFC VA: 0xC41CFC Slot: 14
		protected override void OnDestoryScene()
		{
			return;
		}

		// // RVA: 0xC4111C Offset: 0xC4111C VA: 0xC4111C
		private void Initialize()
		{
			if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5)
			{
				int deco_tab_num = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.LPJLEHAJADA("deco_tab_num", 4);
				m_listDecoProduct.SetTabNum(deco_tab_num == 4);
				m_listDecoProduct.OnChangeEvent = OnBuyItem;
				m_listDecoProduct.Hide();
				m_listDecoProduct.SetTabsButtonCallBack((EKLNMHFCAOI.FKGCBLHOOCL_Category type) =>
				{
					//0xC453E0
					int idx = ConvertDecoItemTypeIndex(type);
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					Select = idx;
					sortPlace = type == EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj ? PopupSortMenu.SortPlace.DecoInteriorList : PopupSortMenu.SortPlace.DecoShopList;
					FilterCheck();
					myArgs.view.MHKCPJDNJKI = FilterList();
					m_listDecoProduct.SetStatus(myArgs.view, true);
				});
				if(deco_tab_num != 4)
				{
					Select = ConvertDecoItemTypeIndex(EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif);
					myArgs.view.MHKCPJDNJKI = FilterList();
				}
				m_listDecoProduct.ChangeSelectTypes(Select);
				m_listDecoProduct.SetStatus(myArgs.view, true);
			}
			else 
			{
				int sortType = 0;
				if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.MGEGNNJLJII_7)
				{
					m_rarityMin = 1;
					m_rarityMax = 4;
					sortType = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CCJMAIPBELA_ShopProduct1_4.LHPDCGNKPHD_SortItem;
				}
				else if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.ACFEDNPIJKM_8)
				{
					m_rarityMin = 5;
					m_rarityMax = 6;
					sortType = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.HDKDFCCJEEP_ShopProduct5_6.LHPDCGNKPHD_SortItem;
				}
				else
				{
					m_rarityMin = -1;
					m_rarityMax = -1;
					sortType = -1;
				}
				if(myArgs.view.INDDJNMPONH != AODFBGCCBPE.NJMPLEENNPO.MGEGNNJLJII_7 && 
					myArgs.view.INDDJNMPONH != AODFBGCCBPE.NJMPLEENNPO.ACFEDNPIJKM_8)
				{
					m_listProduct.SetStatus(myArgs.view, myArgs.view.MHKCPJDNJKI);
					m_listProduct.SetSortButtonEnable(false);
				}
				else
				{
					CreateFilterList(myArgs.view.MHKCPJDNJKI);
					SetOrder(m_order != 0 ? SortOrder.Big : SortOrder.Small);
					SetSort((SortItem)sortType);
					m_listProduct.SetStatus(myArgs.view, m_productSortList);
					m_listProduct.SetSortButtonEnable(true);
					UpdateSortText();
				}
				m_listProduct.OnChangeEvent = OnBuyItem;
				m_listProduct.OnClickPopupEvent = OnOpenCautionPopup;
				m_listProduct.OnClickFilterEvent = OnClickFilterEvent;
				m_listProduct.OnClickOrderEvent = OnClickOrderEvent;
				m_listProduct.Hide();
			}
		}

		// // RVA: 0xC42FD4 Offset: 0xC42FD4 VA: 0xC42FD4
		// private void OnClickTabsButton(EKLNMHFCAOI.FKGCBLHOOCL type) { }

		// // RVA: 0xC43150 Offset: 0xC43150 VA: 0xC43150
		private void OnBuyItem(int value, FJGOKILCBJA view)
		{
			if(MenuScene.CheckDatelineAndAssetUpdate())
				return;
			this.StartCoroutineWatched(Co_OnBuyItemConfirm(value, view));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7269FC Offset: 0x7269FC VA: 0x7269FC
		// // RVA: 0xC43200 Offset: 0xC43200 VA: 0xC43200
		private IEnumerator Co_OnBuyItemConfirm(int value, FJGOKILCBJA view)
		{
			int period; // 0x20
			PopupItemUseConfirmSetting setting; // 0x24

			//0xC485D8
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			period = CheckLimitedItem(view.KIJAPOFAGPN_ItemFullId, time);
			if(period > 0)
			{
				MenuScene.Instance.InputDisable();
				setting = new PopupItemUseConfirmSetting();
				if(!setting.ISLoaded())
				{
					yield return this.StartCoroutineWatched(setting.LoadAssetBundlePrefab(transform));
				}
				MenuScene.Instance.InputEnable();
				MessageBank bk = MessageManager.Instance.GetBank("menu");
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.KIJAPOFAGPN_ItemFullId);
                int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.KIJAPOFAGPN_ItemFullId);
				string name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(view.KIJAPOFAGPN_ItemFullId);
				int numItem = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
				setting.TitleText = bk.GetMessageByLabel("item_popup_shop_text_00");
				setting.WindowSize = SizeType.Middle;
				setting.TypeItemId = view.KIJAPOFAGPN_ItemFullId;
				setting.Cost = value;
				setting.OwnCount = numItem;
				setting.Period = period;
				setting.HideDetail = true;
				setting.OverrideText = string.Format(bk.GetMessageByLabel("item_popup_shop_text_08"), name);
				setting.OverrideCaution_2 = string.Format(bk.GetMessageByLabel("item_popup_shop_text_09"), name);
				setting.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				bool isCancel = false;
				bool isClose = false;
				PopupWindowManager.Show(setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xC4590C
					if(type == PopupButton.ButtonType.Negative)
						isCancel = true;
					isClose = true;
				}, null, null, null);
				while(!isClose)
					yield return null;
				if(isCancel)
					yield break;
			}
			//UnityEngine.Debug.LogError(view.OPKDAIMPJBH_ShopId+" "+view.AFKAGFOFAHM_ProductId+" "+view.GJGNOFAPFJD+" "+view.KIJAPOFAGPN_ItemFullId+" "+view.KAPMOPMDHJE);
			//LAB_00c48f00
			this.StartCoroutineWatched(Co_OnBuyItem(value, view));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x726A74 Offset: 0x726A74 VA: 0x726A74
		// // RVA: 0xC432E0 Offset: 0xC432E0 VA: 0xC432E0
		private IEnumerator Co_OnBuyItem(int value, FJGOKILCBJA view)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category itemType;

			//0xC4793C
			MenuScene.Instance.InputDisable();
			bool done = false;
			bool cancel = false;
			view.PFIBEGFOBEG_Buy(value, () =>
			{
				//0xC4592C
				done = true;
			}, () =>
			{
				//0xC45938
				done = true;
				cancel = true;
			}, () =>
			{
				//0xC45944
				NetErrorToTitle();
			});
			yield return new WaitWhile(() =>
			{
				//0xC4596C
				return !done;
			});
			if(cancel)
			{
				//LAB_00c47dd8
				MenuScene.Instance.InputEnable();
				yield break;
			}
			if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5)
			{
				m_listDecoProduct.SetStatus(myArgs.view, false);
			}
			else if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.MGEGNNJLJII_7
				|| myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.ACFEDNPIJKM_8)
			{
				//LAB_00c47f18
				m_listProduct.SetStatus(myArgs.view, m_productSortList, false);
			}
			else
			{
				m_listProduct.SetStatus(myArgs.view, myArgs.view.MHKCPJDNJKI, false);
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			itemType = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(view.KIJAPOFAGPN_ItemFullId);
			TextPopupSetting s = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("item_popup_shop_text_05"), SizeType.Middle, 
				string.Format(bk.GetMessageByLabel("pbox_text_03"), EKLNMHFCAOI.INCKKODFJAP_GetItemName(view.KIJAPOFAGPN_ItemFullId) + " " + (value * view.JDLJPNMLFID_Count).ToString() + EKLNMHFCAOI.NDBLEADIDLA(itemType, EKLNMHFCAOI.DEACAHNLMNI_getItemId(view.KIJAPOFAGPN_ItemFullId))), new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				}, false, true);
			done = false;
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xC457EC
				return;
			}, null, null, null, true, true, false, null, () =>
			{
				//0xC45980
				done = true;
			});
			yield return new WaitWhile(() =>
			{
				//0xC4598C
				return !done;
			});
			GameManager.Instance.ResetViewPlayerData();
			if(itemType == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				done = false;
				this.StartCoroutineWatched(PopupRecordPlate.Show(RecordPlateUtility.eSceneType.Shop, view.JANMJPOKLFL, () =>
				{
					//0xC459A0
					done = true;
				}, false));
				yield return new WaitWhile(() =>
				{
					//0xC459AC
					return !done;
				});
			}
			if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.BJNAMAANNMB_5)
			{
				m_listDecoProduct.KyrrAnimation();
			}
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xC433C0 Offset: 0xC433C0 VA: 0xC433C0
		private void OnOpenCautionPopup(AODFBGCCBPE view)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			DateTime date = Utility.GetLocalDateTime(view.GJFPFFBAKGK);
			object[] obj = new object[6]
			{
				EKLNMHFCAOI.INCKKODFJAP_GetItemName(view.OCGCPJHDJEN),
				date.Year, date.Month, date.Day, date.Hour, date.Minute
			};
			string str = string.Format(bk.GetMessageByLabel(view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.AOMIBCNBBOD_1 ? "item_popup_shop_text_07" : "item_popup_shop_text_06"), obj);
			TextPopupSetting s = PopupWindowManager.CrateTextContent("", SizeType.Small, str, new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			}, false, false);
			PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xC457F0
				return;
			}, null, null, null);
		}

		// // RVA: 0xC43AE8 Offset: 0xC43AE8 VA: 0xC43AE8
		private void NetErrorToTitle()
		{
			if(MenuScene.Instance.IsTransition())
				GotoTitle();
			else
				MenuScene.Instance.GotoTitle();
		}

		// // RVA: 0xC43BF4 Offset: 0xC43BF4 VA: 0xC43BF4
		private static int CheckLimitedItem(int itemId, long currentTime)
		{
            EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId);
            int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId);
			int a = 0;
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem)
			{
				a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IHPFCIJKFIC_LimitedItem.CDENCMNHNGA[id - 1].EMIJNAFJFJO;
			}
			else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem)
			{
				a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KKIMFMKOHFH_RareUpItem.CDENCMNHNGA[id - 1].EIGNPDFHIJA;
			}
			else
				return 0;
			if(a > 0)
			{
				DateTime date = Utility.GetLocalDateTime(currentTime + a * 86400 - 1);
				return (int)Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 23, 59, 59);
			}
			return 0;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x726AEC Offset: 0x726AEC VA: 0x726AEC
		// // RVA: 0xC3EE8C Offset: 0xC3EE8C VA: 0xC3EE8C
		private IEnumerator Co_LoadResources()
		{
			//0xC47814
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x726B64 Offset: 0x726B64 VA: 0x726B64
		// // RVA: 0xC43EFC Offset: 0xC43EFC VA: 0xC43EFC
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName;
			Font systemFont;
			AssetBundleLoadLayoutOperationBase operation;
			int poolSize;
			AssetBundleLoadLayoutOperationBase operationDeco;

			//0xC462C8
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/106.xab");
			yield return AssetBundleManager.LoadUnionAssetBundle(bundleName.ToString());
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_shop_window_02_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xC459C8
				instance.transform.SetParent(transform, false);
				m_listProduct = instance.GetComponent<LayoutShopProductListWindow>();
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			poolSize = m_listProduct.List.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_shop_list_02_layout_root");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xC45DD8
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format(baseRuntime.name + "_{0:D2}", 0);
				m_listContent[0].Add(baseRuntime.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			for(int i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format(r.name + "_{0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_listContent[0].Add(r.GetComponent<SwapScrollListContent>());
			}
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_shop_list_03_layout_root");
			yield return operation;
			baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xC45FA8
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format(baseRuntime + "_{0:D2}", 0);
				m_listContent[1].Add(baseRuntime.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			for(int i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format(r.name + "_{0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_listContent[1].Add(r.GetComponent<SwapScrollListContent>());
			}
			operationDeco = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_shop_window_03_layout_root");
			yield return operationDeco;
			yield return Co.R(operationDeco.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xC45AC4
				instance.transform.SetParent(transform, false);
				m_listDecoProduct = instance.GetComponent<LayoutShopProductListDecoWindow>();
				m_listDecoProduct.OnClickPopupEvent = OnClickSortButton;
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			poolSize = m_listDecoProduct.List.ScrollObjectCount;
			operationDeco = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_shop_list_02_layout_root");
			yield return operationDeco;
			LayoutUGUIRuntime baseRuntimeDeco = null;
			yield return Co.R(operationDeco.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xC45C38
				baseRuntimeDeco = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntimeDeco.name = string.Format(baseRuntimeDeco.name + "_{0:D2}", 0);
				m_listDecoProduct.List.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
			}));
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			for(int i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntimeDeco);
				r.name = string.Format(r.name + "_{0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntimeDeco.Layout.DeepClone();
				r.UvMan = baseRuntimeDeco.UvMan;
				r.LoadLayout();
				m_listDecoProduct.List.AddScrollObject(r.GetComponent<SwapScrollListContent>());
			}
			AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			m_listDecoProduct.List.Apply();
			m_listDecoProduct.List.SetContentEscapeMode(true);
			m_listDecoProduct.Hide();
			while(!m_listDecoProduct.IsLoaded())
				yield return null;
		}

		// // RVA: 0xC3FB70 Offset: 0xC3FB70 VA: 0xC3FB70
		private void InitializeSortSetting()
		{
			m_seriesFilter = (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.MOOHKFCHJPO_shopListSeriaseFilter;
			m_interiorFilter = (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.PJDCJKHMNNM_interiorListFilter;
			sortPlace = PopupSortMenu.SortPlace.DecoShopList;
			FilterCheck();
		}

		// // RVA: 0xC430D0 Offset: 0xC430D0 VA: 0xC430D0
		// private void TabChengedItemCheck(EKLNMHFCAOI.FKGCBLHOOCL type) { }

		// // RVA: 0xC43FA8 Offset: 0xC43FA8 VA: 0xC43FA8
		private void OnClickSortButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			Debug.Log(JpStringLiterals.StringLiteral_20406);
			MenuScene.Instance.ShowSortWindow(sortPlace, (PopupSortMenu popup) =>
			{
				//0xC453E4
				m_seriesFilter = popup.GetSeriaseFilter();
				if(sortPlace == PopupSortMenu.SortPlace.DecoInteriorList)
				{
					m_interiorFilter = popup.GetInteriorFilter();
				}
				myArgs.view.MHKCPJDNJKI = FilterList();
				m_listDecoProduct.SetStatus(myArgs.view, true);
				FilterCheck();
			}, null);
		}

		// // RVA: 0xC430E4 Offset: 0xC430E4 VA: 0xC430E4
		public void FilterCheck()
		{
			if(sortPlace == PopupSortMenu.SortPlace.DecoShopList)
			{
				m_listDecoProduct.IsFilterOn(m_seriesFilter != 0);
			}
			else
			{
				m_listDecoProduct.IsFilterOn(m_seriesFilter != 0 || m_interiorFilter != 0);
			}
		}

		// // RVA: 0xC406C4 Offset: 0xC406C4 VA: 0xC406C4
		private List<FJGOKILCBJA> FilterList()
		{
			m_productFilterData.Clear();
			m_productFilterData.Capacity = m_productData[Select].Count;
			for(int i = 0; i < m_productData[Select].Count; i++)
			{
				EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_productData[Select][i].KIJAPOFAGPN_ItemFullId);
				int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(m_productData[Select][i].KIJAPOFAGPN_ItemFullId);
				int a = 0;
				if(cat < EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
				{
					if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj)
					{
						NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj.Find((NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem item) =>
						{
							//0xC461F8
							return item.PPFNGGCBJKC_Id == id;
						});
						a = it.CPKMLLNADLJ;
					}
					else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara)
					{
						NDBFKHKMMCE_DecoItem.CCHHGIJMLBN_CharaItem it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.KHCACDIKJLG_ItemsChara.Find((NDBFKHKMMCE_DecoItem.CCHHGIJMLBN_CharaItem item) =>
						{
							//0xC46170
							return item.PPFNGGCBJKC_Id == id;
						});
						a = it.CPKMLLNADLJ;
					}
					else
					{
						//LAB_00c40fe8
						m_productFilterData.Add(m_productData[Select][i]);
						continue;
					}
				}
				else
				{
					if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif)
					{
                        IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Find((IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item) =>
						{
							//0xC461B4
							return item.PPFNGGCBJKC == id;
						});
						a = it.CPKMLLNADLJ;
					}
					else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
					{
                        BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA.Find((BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo item) =>
						{
							//0xC4623C
							return item.PPFNGGCBJKC_Id == id;
						});
						a = it.CPKMLLNADLJ;
					}
					else
					{
						//LAB_00c40fe8
						m_productFilterData.Add(m_productData[Select][i]);
						continue;
					}
				}
				//LAB_00c40e54
				if(a == 0 || PopupSortMenu.IsSerializeFilterOn(a, m_seriesFilter))
				{
					if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj && sortPlace == PopupSortMenu.SortPlace.DecoInteriorList)
					{
						NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GHOLIPLDMPJ_ItemsObj.Find((NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem item) =>
						{
							//0xC46280
							return item.PPFNGGCBJKC_Id == id;
						});
						if(!PopupSortMenu.IsInteriorTypeFilterOn(it.GBJFNGCDKPM_SpType, m_interiorFilter))
							continue;
					}
					//LAB_00c40fe8
					m_productFilterData.Add(m_productData[Select][i]);
				}
			}
			return m_productFilterData;
		}

		// // RVA: 0xC44148 Offset: 0xC44148 VA: 0xC44148
		private void OnClickOrderEvent()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			SetOrder(m_order == SortOrder.Small ? SortOrder.Big : SortOrder.Small);
			m_listProduct.SetStatus(myArgs.view, m_productSortList);
			UpdateSortText();
		}

		// // RVA: 0xC4421C Offset: 0xC4421C VA: 0xC4421C
		private void OnClickFilterEvent()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			PopupFilterSortUGUIInitParam s = new PopupFilterSortUGUIInitParam();
			s.SetShopProductParam(m_rarityMin, m_rarityMax, true);
			MenuScene.Instance.ShowSortWindow(s, (PopupFilterSortUGUI content) =>
			{
				//0xC454C4
				CreateFilterList(myArgs.view.MHKCPJDNJKI);
				ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.POCEANNLGLP_ShopProduct sp = null;
				if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.MGEGNNJLJII_7)
				{
					sp = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CCJMAIPBELA_ShopProduct1_4;
				}
				else if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.ACFEDNPIJKM_8)
				{
					sp = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.HDKDFCCJEEP_ShopProduct5_6;
				}
				SetSort((SortItem)sp.LHPDCGNKPHD_SortItem);
				m_listProduct.SetStatus(myArgs.view, m_productSortList);
				UpdateSortText();
			}, null);
		}

		// // RVA: 0xC42E50 Offset: 0xC42E50 VA: 0xC42E50
		private void UpdateSortText()
		{
			m_listProduct.SetSortType(PopupSortMenu.GetMsg_SortItem(m_sortType));
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_listProduct.SetOrderType(bk.GetMessageByLabel(m_order == SortOrder.Big ? "popup_sort_item_bigorder" : "popup_sort_item_smallorder"));
		}

		// // RVA: 0xC42930 Offset: 0xC42930 VA: 0xC42930
		private void SetOrder(SortOrder order)
		{
			m_order = order;
			m_productSortList.Sort(SortCallback);
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.POCEANNLGLP_ShopProduct sp = null;
			if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.MGEGNNJLJII_7)
			{
				sp = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CCJMAIPBELA_ShopProduct1_4;
			}
			else if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.ACFEDNPIJKM_8)
			{
				sp = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.HDKDFCCJEEP_ShopProduct5_6;
			}
			sp.MLMHPBOKJCL_SortOrder = (int)m_order;
		}

		// // RVA: 0xC42BC0 Offset: 0xC42BC0 VA: 0xC42BC0
		private void SetSort(SortItem sortType)
		{
			m_sortType = sortType;
			m_productSortList.Sort(SortCallback);
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.POCEANNLGLP_ShopProduct sp = null;
			if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.MGEGNNJLJII_7)
			{
				sp = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CCJMAIPBELA_ShopProduct1_4;
			}
			else if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.ACFEDNPIJKM_8)
			{
				sp = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.HDKDFCCJEEP_ShopProduct5_6;
			}
			sp.LHPDCGNKPHD_SortItem = (int)m_sortType;
		}

		// // RVA: 0xC41D00 Offset: 0xC41D00 VA: 0xC41D00
		private void CreateFilterList(List<FJGOKILCBJA> products)
		{
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.POCEANNLGLP_ShopProduct sp = null;
			if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.MGEGNNJLJII_7)
			{
				sp = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CCJMAIPBELA_ShopProduct1_4;
			}
			else if(myArgs.view.INDDJNMPONH == AODFBGCCBPE.NJMPLEENNPO.ACFEDNPIJKM_8)
			{
				sp = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.HDKDFCCJEEP_ShopProduct5_6;
			}
			GCIJNCFDNON_SceneInfo sceneData = new GCIJNCFDNON_SceneInfo();
			m_productSortList.Clear();
			for(int i = 0; i < products.Count; i++)
			{
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(products[i].KIJAPOFAGPN_ItemFullId);
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					sceneData.IJIKIPDKCPP = 1;
					sceneData.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(products[i].KIJAPOFAGPN_ItemFullId), null, null, 0, 0, 0, false, 0, 0);
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(sceneData.BCCHOBPJJKE_SceneId) && !sceneData.MCCIFLKCNKO_Feed)
					{
						if(m_rarityMin >= 1 && m_rarityMin > sceneData.JKGFBFPIMGA_Rarity)
							continue;
						if(m_rarityMax >= 1 && m_rarityMax > sceneData.JKGFBFPIMGA_Rarity)
							continue;
						GCIJNCFDNON_SceneInfo d2 = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[sceneData.BCCHOBPJJKE_SceneId - 1];
						if(PopupSortMenu.IsHaveFilterOn(d2.CGKAEMGLHNK_IsUnlocked(), (uint)sp.EGBPCFOGOCK_HaveFilter) && 
							PopupSortMenu.IsRarityFilterOn(d2.EKLIPGELKCL_SceneRarity, (uint)sp.ACCHOFLOOEC_RarityFilter) && 
							PopupSortMenu.IsAttributeFilterOn(d2.JGJFIJOCPAG_SceneAttr, (uint)sp.BOFFOHHLLFG_AttrFilter) && 
							PopupSortMenu.IsSerializeFilterOn((int)d2.AIHCEGFANAM_SceneSeries, (uint)sp.BBIIHLNBHDE_SerieFilter) && 
							PopupSortMenu.IsCompatibleFilterOn(d2.AOLIJKMIJJE_DivaCompatible, (uint)sp.ABLBLOEKBKA_CompatibleFilter) && 
							PopupSortMenu.IsNotesFilterOn(d2.IGPMJPPAILL_Note, (uint)sp.NLLEDCOAPIG_NoteExpectedFilter) && 
							PopupSortMenu.IsSkillRangeFilterOn(d2.BJJNCCGPBGN, (uint)sp.OAJNACDACDF_LiveSkillRangeFilter) && 
							PopupSortMenu.IsSkillRankFilterOn(d2.DHEFMEGKKDN_CenterSkillRank, d2.FFDCGHDNDFJ_CenterSkillRank2, (uint)sp.PFNPLBNHDJK_CenterSkillRankFilter) && 
							PopupSortMenu.IsSkillRankFilterOn(d2.BEKGEAMJGEN_ActiveSkillRank, d2.BEKGEAMJGEN_ActiveSkillRank, (uint)sp.DNLJMMBEKAA_ActiveSkillRankFilter) && 
							PopupSortMenu.IsSkillRankFilterOn(d2.OAHMFMJIENM_LiveSkillRank, d2.ELNJADBILOM_LiveSkillRank2, (uint)sp.EAPCPNGAPBB_LiveSkillRankFilter) && 
							PopupSortMenu.IsCenterSkillFilterOn(d2, (ulong)sp.LKPCKPJGJKN_CenterSkillFilter) && 
							PopupSortMenu.IsActiveSkillFilterOn(d2, (ulong)sp.LACACEBKHCM_ActiveSkillFilter) && 
							PopupSortMenu.IsLiveSkillFilterOn(d2, (ulong)sp.PPEFJBBGGHI_LiveSkillFilter))
						{
							m_productSortList.Add(products[i]);
						}
					}
				}
            }
		}

		// // RVA: 0xC443B8 Offset: 0xC443B8 VA: 0xC443B8
		private int SortCallback(FJGOKILCBJA left, FJGOKILCBJA right)
		{
			leftScene.IJIKIPDKCPP = 1;
			leftScene.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(left.KIJAPOFAGPN_ItemFullId), null, null, 0, 0, 0, false, 0, 0);
			rightScene.IJIKIPDKCPP = 1;
			rightScene.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(right.KIJAPOFAGPN_ItemFullId), null, null, 0, 0, 0, false, 0, 0);
			long a = 0;
			long b = 0;
			switch(m_sortType)
			{
				case SortItem.Total:
					a = leftScene.CMCKNKKCNDK_Status.Total;
					b = rightScene.CMCKNKKCNDK_Status.Total;
					break;
				case SortItem.Soul:
					a = leftScene.CMCKNKKCNDK_Status.soul;
					b = rightScene.CMCKNKKCNDK_Status.soul;
					break;
				case SortItem.Voice:
					a = leftScene.CMCKNKKCNDK_Status.vocal;
					b = rightScene.CMCKNKKCNDK_Status.vocal;
					break;
				case SortItem.Charm:
					a = leftScene.CMCKNKKCNDK_Status.charm;
					b = rightScene.CMCKNKKCNDK_Status.charm;
					break;
				case SortItem.Get:
					a = leftScene.NPHOIEOPIJO;
					b = rightScene.NPHOIEOPIJO;
					break;
				case SortItem.Rarity:
					a = leftScene.EKLIPGELKCL_SceneRarity;
					b = rightScene.EKLIPGELKCL_SceneRarity;
					break;
				case SortItem.Level:
					a = leftScene.CIEOBFIIPLD_SceneLevel;
					b = rightScene.CIEOBFIIPLD_SceneLevel;
					break;
				case SortItem.Life:
					a = leftScene.CMCKNKKCNDK_Status.life;
					b = rightScene.CMCKNKKCNDK_Status.life;
					break;
				case SortItem.Luck:
					a = leftScene.MJBODMOLOBC_Luck;
					b = rightScene.MJBODMOLOBC_Luck;
					break;
				case SortItem.Support:
					a = leftScene.CMCKNKKCNDK_Status.support;
					b = rightScene.CMCKNKKCNDK_Status.support;
					break;
				case SortItem.Fold:
					a = leftScene.CMCKNKKCNDK_Status.fold;
					b = rightScene.CMCKNKKCNDK_Status.fold;
					break;
				case SortItem.RecoveryNotes:
				case SortItem.ItemNotes:
				case SortItem.ScoreUpNotes:
				case SortItem.SupportNotes:
				case SortItem.FoldNotes:
					a = leftScene.CMCKNKKCNDK_Status.spNoteExpected[(int)m_sortType - 10];
					b = rightScene.CMCKNKKCNDK_Status.spNoteExpected[(int)m_sortType - 10];
					break;
				default:
					break;
				case SortItem.ActiveSkill:
					if(leftScene.HGONFBDIBPM_ActiveSkillId > 0)
					{
						a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[leftScene.HGONFBDIBPM_ActiveSkillId - 1].GIEFBAHPMMM;
					}
					if(rightScene.HGONFBDIBPM_ActiveSkillId > 0)
					{
						b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[rightScene.HGONFBDIBPM_ActiveSkillId - 1].GIEFBAHPMMM;
					}
					break;
				case SortItem.LiveSkill:
					if(leftScene.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) > 0)
					{
						a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[leftScene.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) - 1].GIEFBAHPMMM;
					}
					if(rightScene.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) > 0)
					{
						b = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[rightScene.FILPDDHMKEJ_GetLiveSkillId(false, 0, 0) - 1].GIEFBAHPMMM;
					}
					break;
				case SortItem.Episode:
					a = leftScene.KELFCMEOPPM_EpisodeId;
					b = rightScene.KELFCMEOPPM_EpisodeId;
					break;
				case SortItem.SecretBoard:
					a = leftScene.JPIPENJGGDD_NumBoard - 1;
					b = rightScene.JPIPENJGGDD_NumBoard - 1;
					break;
				case SortItem.LuckyLeaf:
					a = leftScene.MKHFCGPJPFI_LimitOverCount;
					b = rightScene.MKHFCGPJPFI_LimitOverCount;
					break;
				case SortItem.NotesExpectation:
					a = leftScene.KMFADKEKPOM_Nx;
					b = rightScene.KMFADKEKPOM_Nx;
					break;
			}
			long res = 0;
			res = a - b;
			if(res == 0)
			{
				res = SortMenuWindow.SortSecondPriority(leftScene, rightScene);
				if(res == 0)
				{
					return SortMenuWindow.SortThirdPriority(leftScene, rightScene);
				}
			}
			if(m_order != SortOrder.Small)
				res *= -1;
			return (int)res;
		}
	}
}
