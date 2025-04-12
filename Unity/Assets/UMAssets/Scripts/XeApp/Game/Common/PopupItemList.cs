using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Core;
using XeApp.Game.Menu;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class PopupItemList : LayoutUGUIScriptBase, IPopupContent
	{
		public enum ItemType
		{
			Growth = 0,
			Other = 1,
			LimitOver = 2,
		}
		
		public struct ItemInfo
		{
			public int id; // 0x0
			public int count; // 0x4
			public EKLNMHFCAOI.FKGCBLHOOCL_Category type; // 0x8

			// RVA: 0x7FAA7C Offset: 0x7FAA7C VA: 0x7FAA7C
			public ItemInfo(int id, int count, EKLNMHFCAOI.FKGCBLHOOCL_Category type)
			{
				this.id = id;
				this.count = count;
				this.type = type;
			}
		}

		private struct ItemOrder
		{
			public EKLNMHFCAOI.FKGCBLHOOCL_Category type; // 0x0
			public int id; // 0x4
			public int order; // 0x8
		}

		public class PopupItemIconItem : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public int Id { get; set; } // 0x1C
			public int Count { get; set; } // 0x20
		}

		public class PopupGrowItemIconItem : IFlexibleListItem
		{
			private List<int> itemIds = new List<int>(); // 0x1C
			private List<int> count = new List<int>(); // 0x20

			// Properties
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public List<int> ItemIds { get { return itemIds; } } //0xAFFE84
			public List<int> Count { get { return count; } } //0xAFFE8C
		}

		public class PopupItemListSetting : PopupSetting
		{
			private const int MinGrowItemIcon = 11;
			private const int ItemIcon = 45;
			private const int LimitOverItemIcon = 1;

			public ItemType ItemType { get; set; } // 0x34
			public override bool IsPreload { get { return true; } } //0xB0087C
			public override string PrefabPath { get { return ""; } } //0xB00884
			public override bool IsAssetBundle { get { return true; } } //0xB008E0

			//[IteratorStateMachineAttribute] // RVA: 0x73E01C Offset: 0x73E01C VA: 0x73E01C
			// RVA: 0xB008E8 Offset: 0xB008E8 VA: 0xB008E8 Slot: 4
			public override IEnumerator LoadAssetBundlePrefab(Transform parent)
			{
				PopupItemList popupItemList; // 0x20
				int loadCount; // 0x24
				AssetBundleLoadLayoutOperationBase layOp; // 0x28

				//0xB009D8
				loadCount = 0;
				layOp = AssetBundleManager.LoadLayoutAsync("ly/060.xab", "root_pop_mask_shoji_layout_root");
				yield return layOp;
				yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xB0099C
					m_content = instance;
				}));
				loadCount++;
				popupItemList = Content.GetComponent<PopupItemList>();
				layOp = null;
				GameObject sourceInstance = null;
				layOp = AssetBundleManager.LoadLayoutAsync("ly/060.xab", "root_pop_item_shoji_layout_root");
				yield return layOp;
				yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xB009AC
					sourceInstance = instance;
				}));
				popupItemList.m_flexibleScrollView.AddLayoutCache(0, sourceInstance.GetComponent<LayoutUGUIRuntime>(), 11);
				Destroy(sourceInstance);
				loadCount++;
				layOp = null;
				sourceInstance = null;
				layOp = AssetBundleManager.LoadLayoutAsync("ly/060.xab", "root_pop_item_shoji_02_layout_root");
				yield return layOp;
				yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xB009BC
					sourceInstance = instance;
				}));
				popupItemList.m_flexibleScrollView.AddLayoutCache(2, sourceInstance.GetComponent<LayoutUGUIRuntime>(), 1);
				Destroy(sourceInstance);
				loadCount++;
				layOp = null;
				sourceInstance = null;
				layOp = AssetBundleManager.LoadLayoutAsync("ly/060.xab", "root_pop_item_layout_root");
				yield return layOp;
				yield return Co.R(layOp.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0xB009CC
					sourceInstance = instance;
				}));
				popupItemList.m_flexibleScrollView.AddLayoutCache(1, sourceInstance.GetComponent<LayoutUGUIRuntime>(), 45);
				Destroy(sourceInstance);
				layOp = null;
				loadCount++;
				yield return null;
				for(int i = 0; i < loadCount; i++)
				{
					AssetBundleManager.UnloadAssetBundle("ly/060.xab", false);
				}
			}
		}

		private const int GachaTicketId = 1;
		private MNDAMOGGJBJ m_growItemData; // 0x14
		private FlexibleItemScrollView m_flexibleScrollView = new FlexibleItemScrollView(); // 0x18
		private List<IFlexibleListItem> m_growthList = new List<IFlexibleListItem>(); // 0x1C
		private List<IFlexibleListItem> m_otherList = new List<IFlexibleListItem>(); // 0x20
		private List<ItemInfo> m_itemList = new List<ItemInfo>(); // 0x24
		private ItemType m_dispItemType; // 0x28
		private const int GrowthItemRow = 4;
		private const int GrowthItemColumn = 3;
		private const int OtherItemRow = 5;
		private const int OtherItemColumn = 9;
		private const int OtherItemCountDispMax = 9999;
		private static readonly Vector2 LeftTopOffset = new Vector2(3, 5); // 0x0

		public Transform Parent { get { return MenuScene.Instance.transform; } } //0xAFCDA0

		// RVA: 0xAFCE3C Offset: 0xAFCE3C VA: 0xAFCE3C
		private void Awake()
		{
			m_flexibleScrollView.Initialize(GetComponentInChildren<ScrollRect>());
		}

		// RVA: 0xAFCEC8 Offset: 0xAFCEC8 VA: 0xAFCEC8 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_growItemData = new MNDAMOGGJBJ();
			m_growItemData.KHEKNNFCAOI(null);
			ListupItem();
			m_flexibleScrollView.UpdateItemListener += OnUpdateGrowItemScrollList;
			if (setting.DefaultTab == PopupTabButton.ButtonLabel.GrowItem)
				ShowGrowthItemList();
			else
				ShowOtherItemList();
		}

		// RVA: 0xAFFC80 Offset: 0xAFFC80 VA: 0xAFFC80 Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xAFFC88 Offset: 0xAFFC88 VA: 0xAFFC88 Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xAFFCC0 Offset: 0xAFFCC0 VA: 0xAFFCC0 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
			m_flexibleScrollView.AllFree();
			m_flexibleScrollView.UpdateItemListener -= OnUpdateGrowItemScrollList;
		}

		// RVA: 0xAFFDC4 Offset: 0xAFFDC4 VA: 0xAFFDC4 Slot: 10
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0xAFFDCC Offset: 0xAFFDCC VA: 0xAFFDCC Slot: 11
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0xAFFDD0 Offset: 0xAFFDD0 VA: 0xAFFDD0
		public void ChangeList(PopupTabButton.ButtonLabel label)
		{
			if (label == PopupTabButton.ButtonLabel.GrowItem)
				ShowGrowthItemList();
			else
				ShowOtherItemList();
		}

		//// RVA: 0xAFF00C Offset: 0xAFF00C VA: 0xAFF00C
		private void ShowGrowthItemList()
		{
			m_dispItemType = ItemType.Growth;
			m_growthList.Clear();
			int a = 0;
			PopupGrowItemIconItem prev = null;
			for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NKDGLGCAPEI_GrowItem.CDENCMNHNGA_GrowItemList.Count; i++)
			{
				KEEKEFEPKFN_GrowItem.MDFGLOIGAFE_GrowItemData item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NKDGLGCAPEI_GrowItem.CDENCMNHNGA_GrowItemList[i];
				if(item.PPEGAKEIEGM > 1)
				{
					if(item.INDDJNMPONH != a)
					{
						if (prev != null)
							m_growthList.Add(prev);
						prev = new PopupGrowItemIconItem();
						a = item.INDDJNMPONH;
					}
					PCKLFFNPPLF p = new PCKLFFNPPLF();
					p.NCMOCCDGKBP(m_growItemData, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem, item.PPFNGGCBJKC));
					prev.ItemIds.Add(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem, item.PPFNGGCBJKC));
					prev.Count.Add(m_growItemData.JPLMJPGDPAN(item.PPFNGGCBJKC));
				}
			}
			if(prev != null)
			{
				m_growthList.Add(prev);
			}
			int v1 = 0;
			int v2 = 0;
			for (int i = 0; i < m_growthList.Count; i++)
			{
				PopupGrowItemIconItem p = m_growthList[i] as PopupGrowItemIconItem;
				int v3 = v2 + p.ItemIds.Count;
				if (v3 > 9)
					v2 = 0;
				v1 += v3 > 9 ? 1 : 0;
				if(p.ItemIds.Count == 2)
				{
					// ?
					p.Top = new Vector2(Mathf.Abs(v2 / 3) * 331 + 3, -(v1 * 148 + 5));
					p.Height = 148;
					p.ResourceType = 2;
				}
				else if(p.ItemIds.Count == 3)
				{
					p.Top = new Vector2(Mathf.Abs(v2 / 3) * 331 + 3, -(v1 * 148 + 5));
					p.Height = 148;
					p.ResourceType = 0;
				}
				else
				{
					p.Top = new Vector2(Mathf.Abs(v2 / 3) * 331 + 3 + 8, -(v1 * 148 + 5 + 8));
					p.Height = 140;
					p.ResourceType = 2;
				}
				v2 += p.ItemIds.Count;
			}
			m_flexibleScrollView.SetupListItem(m_growthList);
			m_flexibleScrollView.SetlistTop(0);
			m_flexibleScrollView.SetZeroVelocity();
		}

		//// RVA: 0xAFF93C Offset: 0xAFF93C VA: 0xAFF93C
		private void ShowOtherItemList()
		{
			m_dispItemType = ItemType.Other;
			m_otherList.Clear();
			for(int i = 0; i < m_itemList.Count; i++)
			{
				PopupItemIconItem item = new PopupItemIconItem();
				item.Id = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(m_itemList[i].type, m_itemList[i].id);
				item.Count = m_itemList[i].count;
				item.Top = new Vector2((i % 9) * 111 + 3, -(i / 9 * 142 + 5));
				item.Height = 142;
				item.ResourceType = 1;
				m_otherList.Add(item);
			}
			m_flexibleScrollView.SetupListItem(m_otherList);
			m_flexibleScrollView.SetlistTop(0);
			m_flexibleScrollView.SetZeroVelocity();
		}

		//// RVA: 0xAFFEE4 Offset: 0xAFFEE4 VA: 0xAFFEE4
		private void OnUpdateGrowItemScrollList(IFlexibleListItem item)
		{
			if(item != null)
			{
				if(item.Layout != null)
				{
					if(item is PopupItemIconItem)
					{
						PopupItemIconItem p = item as PopupItemIconItem;
						PopupItemListItemIcon d = item.Layout as PopupItemListItemIcon;
						if(d != null)
						{
							d.UpdateContent(p.Id, p.Count, 0);
						}
					}
					else if(item is PopupGrowItemIconItem)
					{
						PopupGrowItemIconItem p = item as PopupGrowItemIconItem;
						PopupItemListGrowItemIcon d = item.Layout as PopupItemListGrowItemIcon;
						if(d != null)
						{
							for(int i = 0; i < p.ItemIds.Count; i++)
							{
								d.UpdateContent(p.ItemIds[i], p.Count[i], i);
							}
						}
						else
						{
							PopupItemListItemIcon d2 = item.Layout as PopupItemListItemIcon;
							if(d2 != null)
							{
								for (int i = 0; i < p.ItemIds.Count; i++)
								{
									d2.UpdateContent(p.ItemIds[i], p.Count[i], i);
								}
							}
						}
					}
				}
			}
		}

		//// RVA: 0xAFD004 Offset: 0xAFD004 VA: 0xAFD004
		private void ListupItem()
		{
			m_itemList.Clear();
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
			if(ev != null)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event");
			}
			List<ViewEnergyItemData> l1 = ViewEnergyItemData.CreateList();
			for(int i = 0; i < l1.Count; i++)
			{
				m_itemList.Add(new ItemInfo(l1[i].id, l1[i].haveCount, EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem));
			}
			List<EEDBNJAEKBI> l2 = EEDBNJAEKBI.FKDIMODKKJD();
			for(int i = 0; i < l2.Count; i++)
			{
				m_itemList.Add(new ItemInfo(EKLNMHFCAOI.DEACAHNLMNI_getItemId(l2[i].INFIBMLIHLO_ItemFullId), l2[i].HMFFHLPNMPH_Count, EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem));
			}
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGKEEAFKHP_MvTicket.CDENCMNHNGA.Count; i++)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NEGKEEAFKHP_MvTicket.CDENCMNHNGA[i].PLALNIIBLOF_Enabled == 2)
				{
					m_itemList.Add(new ItemInfo(EKLNMHFCAOI.DEACAHNLMNI_getItemId(160001), CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket, EKLNMHFCAOI.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket));
				}
			}
			List<ItemOrder> lOrder = new List<ItemOrder>();
			lOrder.Clear();
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OOEPHOEFBNL_SpItem.CDENCMNHNGA.Count; i++)
			{
				PPNFHHPJOKK_SpItem.JBBIPIAABOJ SpItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OOEPHOEFBNL_SpItem.CDENCMNHNGA[i];
				if(SpItem.PLALNIIBLOF_Enabled == 2)
				{
					if(SpItem.EILKGEADKGH_Order != 0)
					{
						if(SpItem.PPFNGGCBJKC_Id != 14)
						{
							lOrder.Add(new ItemOrder() { type = EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, id = SpItem.PPFNGGCBJKC_Id, order = SpItem.EILKGEADKGH_Order });
						}
					}
				}
			}
			lOrder.Add(new ItemOrder() { type = EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem, id = 1, order = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[1].EILKGEADKGH_Order });
			if(lOrder.Count > 0)
			{
				lOrder.Sort((ItemOrder a, ItemOrder b) =>
				{
					//0xB00784
					int res = a.order.CompareTo(b.order);
					if (res == 0)
						res = a.id.CompareTo(b.id);
					return res;
				});
				for(int i = 0; i < lOrder.Count; i++)
				{
					if(lOrder[i].type == EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
					{
						m_itemList.Add(new ItemInfo(lOrder[i].id, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JJKEDPHDEDO_GetSpItemCount(lOrder[i].id), lOrder[i].type));
					}
					else if(lOrder[i].type == EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem)
					{
						m_itemList.Add(new ItemInfo(lOrder[i].id, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GJCOJBDOOJG_LimitedCompoItem.ODHBHOGFNAA[0].LFOEBPPAAFJ(lOrder[i].id, time), lOrder[i].type));
					}
				}
			}
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.MIGONIENGBF_GetItemsCount(); i++)
			{
				PLPBJOFICEJ_CosItem.IBEMFIAFIKH_ItemInfo cosItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GOGFKAECFIP_CosItem.LOOANCFLPMP_GetItemByIdx(i);
				m_itemList.Add(new ItemInfo(cosItem.PPFNGGCBJKC_Id, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.EFBKCNNFIPJ(cosItem.PPFNGGCBJKC_Id).BFINGCJHOHI_Cnt, EKLNMHFCAOI.FKGCBLHOOCL_Category.NEIIGCODGBA_CostumeItem));
			}
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FBGKBGNIHGC_ValItem.CDENCMNHNGA.Count; i++)
			{
				INDEPDKCJDD_ValItem.NHJLDENJKBE valItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FBGKBGNIHGC_ValItem.CDENCMNHNGA[i];
				int valId = valItem.PPFNGGCBJKC_Id;
				EGOLBAPFHHD_Common.GHOADMJCPFK saveItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MJAIFKFOPPI_ValItem.Find((EGOLBAPFHHD_Common.GHOADMJCPFK item) =>
				{
					//0xB007C0
					return valId == item.PPFNGGCBJKC_Id;
				});
				m_itemList.Add(new ItemInfo(valId, saveItem.BFINGCJHOHI_Cnt, EKLNMHFCAOI.FKGCBLHOOCL_Category.MABCLBNIOFA_ValkyrieItem));
			}
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG.Count; i++)
			{
				if(i != 0)
				{
					JHAAHJNEBOG_LimitedCompoItem.AOBHKONKIPF lItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OCMMLAOEPIG[i];
					m_itemList.Add(new ItemInfo(lItem.PPFNGGCBJKC_Id, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GJCOJBDOOJG_LimitedCompoItem.ODHBHOGFNAA[lItem.PENIOLJHIPK - 1].LFOEBPPAAFJ(lItem.PPFNGGCBJKC_Id, time), EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem));
				}
			}
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OOEPHOEFBNL_SpItem.CDENCMNHNGA.Count; i++)
			{
				PPNFHHPJOKK_SpItem.JBBIPIAABOJ SpItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OOEPHOEFBNL_SpItem.CDENCMNHNGA[i];
				if(SpItem.PLALNIIBLOF_Enabled == 2)
				{
					if(SpItem.EILKGEADKGH_Order != 0)
					{
						if(SpItem.PPFNGGCBJKC_Id == 14)
						{
							m_itemList.Add(new ItemInfo(SpItem.PPFNGGCBJKC_Id, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JJKEDPHDEDO_GetSpItemCount(SpItem.PPFNGGCBJKC_Id), EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem));
						}
					}
				}
			}
		}
	}
}
