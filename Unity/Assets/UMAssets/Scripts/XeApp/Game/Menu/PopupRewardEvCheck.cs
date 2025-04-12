using System;
using System.Collections;
using System.Collections.Generic;
using mcrs;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvCheck : UIBehaviour, IPopupContent
	{
		public class PointListItem : IFlexibleListItem
		{
			private GCIJNCFDNON_SceneInfo sceneData; // 0x28

			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public MFDJIFIIPJD Item { get; set; } // 0x1C
			public int NeedPoint { get; set; } // 0x20
			public bool IsGet { get; set; } // 0x24
			public bool isGoldFrame { get; set; } // 0x25

			// RVA: 0x1A6AE7C Offset: 0x1A6AE7C VA: 0x1A6AE7C
			public void OnShowItemDetails(Action closeCallback)
			{
				if(Item != null)
				{
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(Item.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
					{
						if(sceneData == null)
							sceneData = new GCIJNCFDNON_SceneInfo();
						sceneData.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(Item.JJBGOIMEIPF_ItemId), null, null, 0, 0, 0, false, 0, 0);
						MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, closeCallback, true, true, SceneStatusParam.PageSave.None, false);
					}
					else
					{
						MenuScene.Instance.ShowItemDetail(Item.JJBGOIMEIPF_ItemId, Item.MBJIFDBEDAC_Cnt, closeCallback);
					}
				}
			}
		}

		public class RankingListSeparator : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public string Label { get; set; } // 0x1C
		}

		public class RankingListItem : IFlexibleListItem
		{
			private GCIJNCFDNON_SceneInfo sceneData; // 0x24

			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public MFDJIFIIPJD Data { get; set; } // 0x1C
			public bool IsGet { get; set; } // 0x20
			public bool isGoldFrame { get; set; } // 0x21

			// // RVA: 0x1A6B2A8 Offset: 0x1A6B2A8 VA: 0x1A6B2A8
			public void OnShowItemDetails(Action closeCallback)
			{
				if(Data != null)
				{
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(Data.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
					{
						if(sceneData == null)
							sceneData = new GCIJNCFDNON_SceneInfo();
						sceneData.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(Data.JJBGOIMEIPF_ItemId), null, null, 0, 0, 0, false, 0, 0);
						MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, closeCallback, true, true, SceneStatusParam.PageSave.None, false);
					}
					else
					{
						MenuScene.Instance.ShowItemDetail(Data.JJBGOIMEIPF_ItemId, Data.MBJIFDBEDAC_Cnt, closeCallback);
					}
				}
			}
		}

		public class RaidRewardListSeparator : IFlexibleListItem
		{
			public Vector2 Top { get; set; }  // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public string BossName { get; set; } // 0x1C
		}
 
		public class RaidRewardListItem : IFlexibleListItem
		{
			private GCIJNCFDNON_SceneInfo sceneData; // 0x28

			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public MFDJIFIIPJD Item { get; set; } // 0x1C
			public bool IsPickupItem { get; set; } // 0x20
			public float Rate { get; set; } // 0x24

			// // RVA: 0x1A6B6D4 Offset: 0x1A6B6D4 VA: 0x1A6B6D4
			// public void OnShowItemDetails(Action closeCallback) { }
		}

		public class ScrollObject
		{
			public enum Type
			{
				NONE = -1,
				HEADER = 0,
				ITEM = 1,
				NUM = 2,
			}

			public GameObject obj; // 0x8
			public Type type = Type.NONE; // 0xC
		}

		public class PopupRewardEvCheckSetting : PopupSetting
		{
			private IKDICBBFBMI_EventBase m_EventCtrl; // 0x34
			private ViewRewardEvCheckData m_ViewData; // 0x38
			public bool isRaidBossSelect; // 0x3C

			public IKDICBBFBMI_EventBase EventCtrl { get { return m_EventCtrl; } set { m_EventCtrl = value; } } //0x1A6C1E0 0x1A66E0C
			public ViewRewardEvCheckData GetViewData { get { return m_ViewData; } } //0x1A64AF8
			public override string PrefabPath { get { return ""; } } //0x1A6CA78
			public override string BundleName { get { return "ly/053.xab"; } } //0x1A6CAD4
			public override string AssetName { get { return "PopupRewardEvCheck"; } } //0x1A6CB30
			public override bool IsAssetBundle { get { return true; } } //0x1A6CB8C
			public override bool IsPreload { get { return true; } } //0x1A6CB94
			public override GameObject Content { get { return m_content; } } //0x1A6CB9C

			// // RVA: 0x1A6CBA4 Offset: 0x1A6CBA4 VA: 0x1A6CBA4
			// public void SetContent(GameObject obj) { }

			// [IteratorStateMachineAttribute] // RVA: 0x70E0CC Offset: 0x70E0CC VA: 0x70E0CC
			// RVA: 0x1A6CBAC Offset: 0x1A6CBAC VA: 0x1A6CBAC Slot: 4
			public override IEnumerator LoadAssetBundlePrefab(Transform parent)
			{
				//0x1A6FBF0
				m_parent = parent;
				if(m_content == null)
				{
					yield return Co.R(Co_LoadPopupResource());
				}
			}

			// // RVA: 0x1A6C1E8 Offset: 0x1A6C1E8 VA: 0x1A6C1E8
			public void InitializeView()
			{
				m_ViewData = new ViewRewardEvCheckData();
				m_ViewData.Init(m_EventCtrl, isRaidBossSelect);
			}

			// [IteratorStateMachineAttribute] // RVA: 0x70E144 Offset: 0x70E144 VA: 0x70E144
			// // RVA: 0x1A6E860 Offset: 0x1A6E860 VA: 0x1A6E860
			public IEnumerator Co_LoadPopupResource()
			{
				int loadCount; // 0x18
				PopupRewardEvCheckLayout popupBaseLayout; // 0x1C
				AssetBundleLoadLayoutOperationBase operation; // 0x20

				//0x1A6E968
				loadCount = 0;
				if(m_content == null)
				{
					operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvCheck");
					yield return operation;
					yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
					{
						//0x1A6E914
						m_content = instance;
					}));
					loadCount++;
				}
				//LAB_01a6ec30
				popupBaseLayout = m_content.transform.Find("PopupRewardEvCheck").GetComponent<PopupRewardEvCheckLayout>();
				GameObject header_inst = null;
				GameObject item_inst = null;
				GameObject pointItemInst = null;
				GameObject raidItem = null;
				GameObject raidHeader = null;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvCheckHeader");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1A6E93C
					header_inst = instance;
				}));
				popupBaseLayout.FxScrollView.AddLayoutCache(1, header_inst.GetComponent<LayoutUGUIRuntime>(), 6);
				operation = null;
				loadCount++;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvItem");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1A6E944
					item_inst = instance;
				}));
				popupBaseLayout.FxScrollView.AddLayoutCache(2, item_inst.GetComponent<LayoutUGUIRuntime>(), 16);
				loadCount++;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvPointItem");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1A6E94C
					pointItemInst = instance;
				}));
				popupBaseLayout.FxScrollView.AddLayoutCache(3, pointItemInst.GetComponent<LayoutUGUIRuntime>(), 7);
				loadCount++;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvRaidItem");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1A6E954
					raidItem = instance;
				}));
				popupBaseLayout.FxScrollView.AddLayoutCache(4, raidItem.GetComponent<LayoutUGUIRuntime>(), 12);
				loadCount++;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvCheckRaidHeader");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1A6E95C
					raidHeader = instance;
				}));
				popupBaseLayout.FxScrollView.AddLayoutCache(5, raidHeader.GetComponent<LayoutUGUIRuntime>(), 7);
				loadCount++;
				Destroy(header_inst);
				Destroy(item_inst);
				Destroy(pointItemInst);
				Destroy(raidItem);
				Destroy(raidHeader);
				yield return null;
				for(int i = 0; i < loadCount; i++)
				{
					AssetBundleManager.UnloadAssetBundle(BundleName, false);
				}
				PopupRewardEv2ItemLayout layout = m_content.transform.Find("PopupRewardEv2Item").GetComponent<PopupRewardEv2ItemLayout>();
				yield return Co.R(layout.CO_LoadResource(m_ViewData));
				PopupRewardEvRaidLayout layout2 = m_content.transform.Find("PopupRewardEvCheckRaid").GetComponent<PopupRewardEvRaidLayout>();
				yield return Co.R(layout2.Co_LoadResource(m_ViewData));

			}
		}

		public class ViewRewardEvCheckData
		{
			public bool is_point_reward; // 0x8
			public bool is_rank_reward; // 0x9
			public bool is_counting; // 0xA
			public bool isRaidBossSelect; // 0xB
			public int curr_point; // 0xC
			public int curr_rank; // 0x10
			public int curr_score; // 0x14
			public int curr_score_rank; // 0x18
			public List<IHAEIOAKEMG> total_data_list; // 0x1C
			public List<EJFIKLONGDD> total_feature_list; // 0x20
			public List<MAOCCKFAOPC> rank_data_list; // 0x24
			public List<MAOCCKFAOPC> rank_data_list2; // 0x28
			public List<HOOEJMGLGFO> mvp_reward_list; // 0x2C
			public List<HOOEJMGLGFO> attack1st_reward_list; // 0x30
			public List<HOOEJMGLGFO> disempowerment_reward_list; // 0x34
			public List<FDPJBEAKPMA> normal_raidboss_info_list; // 0x38
			public List<FDPJBEAKPMA> ex_raidboss_info_list; // 0x3C
			public List<int> dropList; // 0x40
			public bool is_enable_score_ranking; // 0x44
			public string pickup_music_name; // 0x48
			public int pickup_free_music_id; // 0x4C
			public int pickup_cover_id; // 0x50
			public int select_diva_id; // 0x54
			public OHCAABOMEOF.KGOGMKMBCPP_EventType eventType; // 0x58
			public IKDICBBFBMI_EventBase contExt; // 0x5C

			// // RVA: 0x1A6CC7C Offset: 0x1A6CC7C VA: 0x1A6CC7C
			public void Init(IKDICBBFBMI_EventBase cont, bool isRaidBossSelect = false)
			{
				if(cont == null)
					return;
				is_point_reward = cont.LEPALMDKEOK_IsPointReward;
				is_rank_reward = cont.IBNKPMPFLGI_IsRankReward;
				is_counting = cont.NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6;
				curr_point = (int)cont.FBGDBGKNKOD_GetCurrentPoint();
				curr_rank = cont.CDINKAANIAA_Rank[0];
				total_data_list = cont.PFPJHJJAGAG_Rewards;
				total_feature_list = cont.MGEIBMIGILL();
				rank_data_list = cont.EGIPGHCDMII_RankData[0];
				this.isRaidBossSelect = isRaidBossSelect;
				rank_data_list2 = cont.EGIPGHCDMII_RankData[1];
				if(cont.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
				{
					TodoLogger.LogError(TodoLogger.EventCollection_1, "Event Collection");
				}
				else if(cont.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
				{
					HAEDCCLHEMN_EventBattle battleEv = cont as HAEDCCLHEMN_EventBattle;
					curr_score_rank = battleEv.CDINKAANIAA_Rank[1];
					curr_score = battleEv.GFNODPDPNMJ_GetSumExHighScore();
					pickup_free_music_id = 0;
					is_enable_score_ranking = true;
				}
				else if(cont.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
				{
					TodoLogger.LogError(TodoLogger.EventQuest_6, "Event Quest");
				}
				else if(cont.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event Raid");
				}
				else if(cont.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.KHEKNNFCAOI(cont.HEACCHAKMFG_GetMusicsList()[0], false, 0, 0, 0, false, false, false);
					pickup_free_music_id = ib.GHBPLHBNMBK_FreeMusicId;
					pickup_music_name = ib.NEDBBJDAFBH_MusicName;
					pickup_cover_id = ib.JNCPEGJGHOG_JacketId;
					select_diva_id = (cont as MANPIONIGNO_EventGoDiva).CLELOGKMNCE_GetEventSaveData().AFKMGCLEPGA_SelDiva;
					if(select_diva_id < 1 || cont.EGIPGHCDMII_RankData.Length < select_diva_id)
					{
						//LAB_01a6e4b0
						select_diva_id = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId;
					}
					rank_data_list = cont.EGIPGHCDMII_RankData[select_diva_id - 1];
					is_enable_score_ranking = true;
					rank_data_list2 = cont.EGIPGHCDMII_RankData[select_diva_id - 1];
					curr_score_rank = cont.CDINKAANIAA_Rank[select_diva_id - 1];
					curr_score = (int)(cont as MANPIONIGNO_EventGoDiva).AFCIIKDOMHN_GetCurrentScore(select_diva_id);
				}
				else
				{
					is_enable_score_ranking = false;
					curr_score = 0;
					curr_score_rank = 0;
					pickup_free_music_id = 0;
				}
				dropList = cont.AEGDKBNNDBC_GetDrops();
				eventType = cont.HIDHLFCBIDE_EventType;
			}
		}

		public static readonly PopupTabButton.ButtonLabel DEFAULT_TAB = PopupTabButton.ButtonLabel.CumulativePoint; // 0x0
		public static readonly PopupTabButton.ButtonLabel[] TAB_LIST = new PopupTabButton.ButtonLabel[6]
		{
			PopupTabButton.ButtonLabel.CumulativePoint, 
			PopupTabButton.ButtonLabel.Rankings, 
			PopupTabButton.ButtonLabel.RewardMVP, 
			PopupTabButton.ButtonLabel.RewardAttack1st, 
			PopupTabButton.ButtonLabel.RewardDisempowerment, 
			PopupTabButton.ButtonLabel.RewardDisempowermentItems
		}; // 0x4
		private static PopupRewardEvCheckSetting sm_Setting = null; // 0x8
		private PopupRewardEvCheckLayout m_MainLayout; // 0x10
		private PopupRewardEv2ItemLayout m_PlateLayout; // 0x14
		private PopupRewardEvRaidLayout m_RaidLayout; // 0x18
		private PopupWindowControl m_windowControl; // 0x1C
		private PopupRewardEvCheckSetting m_setting; // 0x20
		private Dictionary<PopupTabButton.ButtonLabel, float> m_ScrollAreaHeight = new Dictionary<PopupTabButton.ButtonLabel, float>(); // 0x24
		private List<IFlexibleListItem> m_pointList = new List<IFlexibleListItem>(); // 0x28
		private List<IFlexibleListItem> m_rankingList = new List<IFlexibleListItem>(); // 0x2C
		private List<IFlexibleListItem> m_rankingList2 = new List<IFlexibleListItem>(); // 0x30
		private List<IFlexibleListItem> m_rewardMvpList = new List<IFlexibleListItem>(); // 0x34
		private List<IFlexibleListItem> m_rewardAttack1stList = new List<IFlexibleListItem>(); // 0x38
		private List<IFlexibleListItem> m_rewardDisempowermentList = new List<IFlexibleListItem>(); // 0x3C
		private List<IFlexibleListItem> m_normalRewardLotCountList = new List<IFlexibleListItem>(); // 0x40
		private List<IFlexibleListItem> m_exRewardLotCountList = new List<IFlexibleListItem>(); // 0x44
		private Transform m_RewardEvCheck; // 0x48
		private Transform m_RewardEvPlate; // 0x4C
		private Transform m_RewardEvRaid; // 0x50
		private bool m_isChanging; // 0x54

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1A64680 Offset: 0x1A64680 VA: 0x1A64680 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_RewardEvCheck = transform.Find("PopupRewardEvCheck");
			m_RewardEvPlate = transform.Find("PopupRewardEv2Item");
			m_RewardEvRaid = transform.Find("PopupRewardEvCheckRaid");
			m_RewardEvCheck.GetComponent<RectTransform>().sizeDelta = size;
			m_RewardEvCheck.localPosition = Vector3.zero;
			m_RewardEvPlate.GetComponent<RectTransform>().sizeDelta = size;
			m_RewardEvPlate.localPosition = Vector3.zero;
			m_RewardEvRaid.GetComponent<RectTransform>().sizeDelta = size;
			m_RewardEvRaid.localPosition = Vector3.zero;
			Parent = setting.m_parent;
			m_windowControl = control;
			m_setting = setting as PopupRewardEvCheckSetting;
			MakeScrollItem(m_setting.GetViewData);
			gameObject.SetActive(true);
			m_RewardEvPlate.gameObject.SetActive(false);
			m_isChanging = false;
		}

		// // RVA: 0x1A64B00 Offset: 0x1A64B00 VA: 0x1A64B00
		private void MakeScrollItem(ViewRewardEvCheckData viewData)
		{
			m_pointList.Clear();
			m_rankingList.Clear();
			m_rankingList2.Clear();
			m_rewardMvpList.Clear();
			m_rewardAttack1stList.Clear();
			m_rewardDisempowermentList.Clear();
			m_normalRewardLotCountList.Clear();
			m_exRewardLotCountList.Clear();
			int a1 = 0;
			for(int i = 0; i < viewData.total_data_list.Count; i++)
			{
				for(int j = 0; j < viewData.total_data_list[i].HBHMAKNGKFK_Items.Count; j++)
				{
					PointListItem it = new PointListItem();
					it.Top = new Vector2(0, -(a1 * 104 + 10));
					it.Height = 104;
					it.ResourceType = 3;
					it.Item = viewData.total_data_list[i].HBHMAKNGKFK_Items[j];
					it.NeedPoint = viewData.total_data_list[i].FIOIKMOIJGK_Point;
					it.IsGet = viewData.total_data_list[i].HMEOAKCLKJE_IsReceived;
					it.isGoldFrame = it.Item.JOPPFEHKNFO_IsGold;
					m_pointList.Add(it);
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(it.Item.JJBGOIMEIPF_ItemId));
					a1++;
				}
			}
			float f1 = 0;
			for(int i = 0; i < viewData.rank_data_list.Count; i++)
			{
				RankingListSeparator s = new RankingListSeparator();
				s.Top = new Vector2(0, -f1);
				s.Height = 55;
				s.ResourceType = 1;
				s.Label = MakeRankingSeparatorLabel(viewData.rank_data_list[i]);
				m_rankingList.Add(s);
				f1 += 55;
				for(int j = 0; j < viewData.rank_data_list[i].HBHMAKNGKFK_Items.Count; j++)
				{
					RankingListItem it = new RankingListItem();
					it.Top = new Vector2((j & 1) * 480 + 10, -(f1 + (j >> 1) * 108 + 4));
					it.Height = 108;
					it.ResourceType = 2;
					it.Data = viewData.rank_data_list[i].HBHMAKNGKFK_Items[j];
					it.IsGet = false;
					it.isGoldFrame = it.Data.JOPPFEHKNFO_IsGold;
					m_rankingList.Add(it);
					KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(it.Data.JJBGOIMEIPF_ItemId, 0));
				}
				if(viewData.rank_data_list[i].HBHMAKNGKFK_Items.Count > 0)
					f1 += (viewData.rank_data_list[i].HBHMAKNGKFK_Items.Count >> 1) * 104 + 104;
			}
			if(viewData.is_enable_score_ranking)
			{
				f1 = 0;
				for(int i = 0; i < viewData.rank_data_list2.Count; i++)
				{
					RankingListSeparator s = new RankingListSeparator();
					s.Top = new Vector2(0, -f1);
					s.Height = 55;
					s.ResourceType = 1;
					s.Label = MakeRankingSeparatorLabel(viewData.rank_data_list2[i]);
					m_rankingList2.Add(s);
					f1 += 55;
					for(int j = 0; j < viewData.rank_data_list2[i].HBHMAKNGKFK_Items.Count; j++)
					{
						RankingListItem it = new RankingListItem();
						it.Top = new Vector2((j & 1) * 480 + 10, -(f1 + (j >> 1) * 108 + 4));
						it.Height = 108;
						it.ResourceType = 2;
						it.Data = viewData.rank_data_list2[i].HBHMAKNGKFK_Items[j];
						it.IsGet = false;
						it.isGoldFrame = it.Data.JOPPFEHKNFO_IsGold;
						m_rankingList.Add(it);
						KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(it.Data.JJBGOIMEIPF_ItemId, 0));
					}
					if(viewData.rank_data_list2[i].HBHMAKNGKFK_Items.Count > 0)
						f1 += (viewData.rank_data_list2[i].HBHMAKNGKFK_Items.Count >> 1) * 104 + 104;
				}
			}
			if(viewData.eventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Raid");
			}
		}

		// // RVA: 0x1A6634C Offset: 0x1A6634C VA: 0x1A6634C
		private string MakeRankingSeparatorLabel(MAOCCKFAOPC data)
		{
			return MakeRakingMessage(data.JBDGBPAAAEF_HighRank, data.GHANKNIBALB_LowRank);
		}

		// // RVA: 0x1A664A8 Offset: 0x1A664A8 VA: 0x1A664A8
		public static string MakeRakingMessage(int high, int low)
		{
			if(high == low)
			{
				return string.Format(MessageManager.Instance.GetMessage("menu", "popup_event_reward_needrank_unit"), high);
			}
			else
			{
				return string.Format(MessageManager.Instance.GetMessage("menu", "popup_event_reward_needrankrange_unit"), high, low);
			}
		}

		// RVA: 0x1A665F4 Offset: 0x1A665F4 VA: 0x1A665F4
		public void OnDestroy()
		{
			sm_Setting = null;
		}

		// // RVA: 0x1A66684 Offset: 0x1A66684 VA: 0x1A66684
		private void Setup()
		{
			m_MainLayout = m_RewardEvCheck.GetComponent<PopupRewardEvCheckLayout>();
			m_PlateLayout = m_RewardEvPlate.GetComponent<PopupRewardEv2ItemLayout>();
			m_RaidLayout = m_RewardEvRaid.GetComponent<PopupRewardEvRaidLayout>();
			m_MainLayout.SetUp(m_setting.GetViewData);
			m_MainLayout.SetCallbackChangeRankingType(CallbackChangeRankingType);
			m_MainLayout.FxScrollView.UpdateItemListener += UpdateContent;
			PopupTabButton.ButtonLabel label;
			if(m_setting.GetViewData.is_point_reward && m_setting.GetViewData.is_rank_reward)
			{
				label = m_setting.DefaultTab;
			}
			else
			{
				label = PopupTabButton.ButtonLabel.CumulativePoint;
				if(!m_setting.GetViewData.is_point_reward)
				{
					label = PopupTabButton.ButtonLabel.None;
					if(m_setting.GetViewData.is_rank_reward)
					{
						label = PopupTabButton.ButtonLabel.Rankings;
					}
				}
			}
			if(m_setting.EventCtrl != null)
			{
				PKNOKJNLPOE_EventRaid p = m_setting.EventCtrl as PKNOKJNLPOE_EventRaid;
				if(p != null)
				{
					label = PopupTabButton.ButtonLabel.RewardMVP;
					if(m_setting.isRaidBossSelect)
						label = PopupTabButton.ButtonLabel.Rankings;
				}
			}
			SetupScrollContent(label);
		}

		// // RVA: 0x1A66E14 Offset: 0x1A66E14 VA: 0x1A66E14
		private void SetupScrollContent(PopupTabButton.ButtonLabel label)
		{
			//m_MainLayout.m_ScrollContent.Find("Range").GetComponent<RectTransform>().
			ChangeTab(label);
		}

		// RVA: 0x1A67464 Offset: 0x1A67464 VA: 0x1A67464 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1A6746C Offset: 0x1A6746C VA: 0x1A6746C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			Setup();
			m_MainLayout.FxScrollView.LockScroll();
		}

		// RVA: 0x1A674E4 Offset: 0x1A674E4 VA: 0x1A674E4 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			m_MainLayout.FxScrollView.AllFree();
			m_MainLayout.FxScrollView.UpdateItemListener -= UpdateContent;
		}

		// RVA: 0x1A67610 Offset: 0x1A67610 VA: 0x1A67610 Slot: 21
		public bool IsReady()
		{
			PopupRewardEvCheckLayout p = m_RewardEvCheck.GetComponent<PopupRewardEvCheckLayout>();
			if(p.IsLoaded())
			{
				return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
			}
			return false;
		}

		// RVA: 0x1A67710 Offset: 0x1A67710 VA: 0x1A67710 Slot: 22
		public void CallOpenEnd()
		{
			this.StartCoroutineWatched(Co_DelayOpenEnd());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70DB34 Offset: 0x70DB34 VA: 0x70DB34
		// // RVA: 0x1A67734 Offset: 0x1A67734 VA: 0x1A67734
		private IEnumerator Co_DelayOpenEnd()
		{
			//0x1A6B9C8
			yield return new WaitForSeconds(0.1f);
			m_MainLayout.FxScrollView.SetZeroVelocity();
			m_MainLayout.FxScrollView.UnLockScroll();
		}

		// // RVA: 0x1A677E0 Offset: 0x1A677E0 VA: 0x1A677E0
		private void CallbackChangeRankingType(PopupRewardEvCheckLayout.RankingType a_type)
		{
			ChangeScrollContent(PopupTabButton.ButtonLabel.Rankings);
		}

		// // RVA: 0x1A66EE8 Offset: 0x1A66EE8 VA: 0x1A66EE8
		public void ChangeTab(PopupTabButton.ButtonLabel label)
		{
			if(m_isChanging)
				return;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			string title = "";
			bool isPlate = false;
			bool isRaidReward = false;
			bool b = false;
			if(label == PopupTabButton.ButtonLabel.CumulativePoint)
			{
				title = bk.GetMessageByLabel("popup_event_reward_check_pt_title");
				m_MainLayout.FxScrollView.SetupListItem(m_pointList);
				b = true;
			}
			else if(label == PopupTabButton.ButtonLabel.Rankings)
			{
				title = bk.GetMessageByLabel("popup_event_reward_check_rank_title");
				if(m_MainLayout.GetRankingType() != 0)
				{
					if(m_MainLayout.GetRankingType() == PopupRewardEvCheckLayout.RankingType.BattleScore || m_MainLayout.GetRankingType() == PopupRewardEvCheckLayout.RankingType.Music)
					{
						m_MainLayout.FxScrollView.SetupListItem(m_rankingList2);
					}
					else
					{
						m_MainLayout.FxScrollView.SetupListItem(m_rankingList);
					}
				}
				b = true;
			}
			else if(label == PopupTabButton.ButtonLabel.Plate)
			{
				title = bk.GetMessageByLabel("popup_event_reward_check_plate_info_title");
				isPlate = true;
				m_PlateLayout.Setup();
			}
			else if(label == PopupTabButton.ButtonLabel.RewardMVP)
			{
				isRaidReward = true;
				title = bk.GetMessageByLabel("popup_event_reward_check_mvp_title");
				b = true;
			}
			else if(label == PopupTabButton.ButtonLabel.RewardAttack1st)
			{
				isRaidReward = true;
				title = bk.GetMessageByLabel("popup_event_reward_check_attack1st_title");
				b = true;
			}
			else if(label == PopupTabButton.ButtonLabel.RewardDisempowerment)
			{
				isRaidReward = true;
				title = bk.GetMessageByLabel("popup_event_reward_check_disempowerment_title");
				b = true;
			}
			else if(label == PopupTabButton.ButtonLabel.RewardDisempowermentItems)
			{
				title = bk.GetMessageByLabel("popup_event_reward_check_lotcount_title");
				m_MainLayout.FxScrollView.SetupListItem(m_rewardDisempowermentList);
				b = true;
			}
			else
			{
				m_MainLayout.ChangeTab(label);
				ChangeScrollContent(label);
			}
			if(b)
			{
				if(!isPlate)
				{
					if(!isRaidReward)
					{
						m_MainLayout.ChangeTab(label);
						ChangeScrollContent(label);
					}
					else
					{
						m_RaidLayout.Setup(label);
					}
				}
				else
				{
					m_PlateLayout.Setup();
				}
			}
			if(!isRaidReward)
			{
				SwitchWindow(isPlate, false, title);
			}
			else
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Raid");
			}
		}

		// // RVA: 0x1A67E54 Offset: 0x1A67E54 VA: 0x1A67E54
		private void SwitchWindow(bool isPlate, bool isRaidReward, string title)
		{
			m_RewardEvPlate.gameObject.SetActive(isPlate);
			RectTransform rt = m_RewardEvCheck.gameObject.transform.GetComponent<RectTransform>();
			Vector3 v;
			if(isPlate || isRaidReward)
			{
				v = new Vector3(10000.0f, rt.localPosition.y, 0);
			}
			else
			{
				v = new Vector3(0, rt.localPosition.y, 0);
			}
			rt.localPosition = v;
			rt = m_RewardEvRaid.gameObject.transform.GetComponent<RectTransform>();
			if(isRaidReward)
			{
				v = new Vector3(0, rt.localPosition.y, 0);
			}
			else
			{
				v = new Vector3(10000.0f, rt.localPosition.y, 0);
			}
			rt.localPosition = v;
			m_windowControl.m_titleText.text = title;
		}

		// // RVA: 0x1A68204 Offset: 0x1A68204 VA: 0x1A68204
		private void UpdateContent(IFlexibleListItem item)
		{
			if(item.Layout != null)
			{
				if(item is PointListItem)
				{
					PointListItem pointList = item as PointListItem;
					PopupRewardEvItemLayout l = item.Layout.GetComponent<PopupRewardEvItemLayout>();
					if(l != null)
					{
						l.SetItemData(pointList.Item, pointList.IsGet, pointList.isGoldFrame);
						l.SetRequiredPoint(pointList.NeedPoint);
						l.SetButtonEvent(() =>
						{
							//0x1A6AD40
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
							m_MainLayout.FxScrollView.LockScroll();
							pointList.OnShowItemDetails(() =>
							{
								//0x1A6A87C
								m_MainLayout.FxScrollView.UnLockScroll();
							});
						});
					}
				}
				else if(item is RankingListSeparator)
				{
					PopupRewardEvSeparatorLayout l = item.Layout.GetComponent<PopupRewardEvSeparatorLayout>();
					if(l != null)
					{
						l.SetRunk((item as RankingListSeparator).Label);
					}
				}
				else if(item is RankingListItem)
				{
					RankingListItem rankingList = item as RankingListItem;
					PopupRewardEvItemLayout l = item.Layout.GetComponent<PopupRewardEvItemLayout>();
					if(l != null)
					{
						l.SetItemData(rankingList.Data, rankingList.IsGet, rankingList.isGoldFrame);
						l.SetButtonEvent(() =>
						{
							//0x1A6B16C
							SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
							m_MainLayout.FxScrollView.LockScroll();
							rankingList.OnShowItemDetails(() =>
							{
								//0x1A6A8BC
								m_MainLayout.FxScrollView.UnLockScroll();
							});
						});
					}
				}
				else if(item is RaidRewardListSeparator)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Raid");
				}
				else if(item is RaidRewardListItem)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Raid");
				}
			}
		}

		// // RVA: 0x1A677E8 Offset: 0x1A677E8 VA: 0x1A677E8
		private void ChangeScrollContent(PopupTabButton.ButtonLabel type)
		{
			if(type == PopupTabButton.ButtonLabel.Rankings)
			{
				if(m_MainLayout.GetRankingType() == PopupRewardEvCheckLayout.RankingType.BattleScore || m_MainLayout.GetRankingType() == PopupRewardEvCheckLayout.RankingType.Music)
				{
					m_MainLayout.FxScrollView.SetupListItem(m_rankingList2);
				}
				else
				{
					m_MainLayout.FxScrollView.SetupListItem(m_rankingList);
				}
				m_MainLayout.FxScrollView.SetlistTop(0);
			}
			else
			{
				m_MainLayout.FxScrollView.SetupListItem(m_pointList);
				if(type == PopupTabButton.ButtonLabel.CumulativePoint)
				{
					int p = m_pointList.Count - 1;
					if(p < 0)
						p = 0;
					bool b = false;
					for(int i = 0; i < p; i++)
					{
						if(m_pointList[p] is PointListItem)
						{
							if((m_pointList[p] as PointListItem).IsGet)
							{
								b = true;
								p = i;
								break;
							}
						}
					}
					m_MainLayout.FxScrollView.SetlistTop(b ? p : 0);
				}
				else if(type == PopupTabButton.ButtonLabel.RewardDisempowermentItems)
				{
					m_MainLayout.FxScrollView.SetupListItem(m_rewardDisempowermentList);
					m_MainLayout.FxScrollView.SetlistTop(0);
				}
			}
			m_MainLayout.FxScrollView.SetZeroVelocity();
			m_MainLayout.FxScrollView.VisibleRangeUpdate();
		}

		// // RVA: 0x1A6A144 Offset: 0x1A6A144 VA: 0x1A6A144
		private static bool IsCreateSetting(IKDICBBFBMI_EventBase eventCtrl)
		{
			if(sm_Setting == null)
				return true;
			if(eventCtrl != null)
			{
				if(sm_Setting.EventCtrl == null)
					return true;
				if(sm_Setting.EventCtrl.PGIIDPEGGPI_EventId != eventCtrl.PGIIDPEGGPI_EventId)
					return true;
				if(eventCtrl is MANPIONIGNO_EventGoDiva)
				{
					return sm_Setting.GetViewData.select_diva_id != (eventCtrl as MANPIONIGNO_EventGoDiva).CLELOGKMNCE_GetEventSaveData().AFKMGCLEPGA_SelDiva;
				}
			}
			return false;
		}

		// // RVA: 0x1A6A390 Offset: 0x1A6A390 VA: 0x1A6A390
		// private static bool IsCreateRiadSetting(IKDICBBFBMI eventCtrl, bool isRaidBossSelect) { }

		// [IteratorStateMachineAttribute] // RVA: 0x70DBAC Offset: 0x70DBAC VA: 0x70DBAC
		// // RVA: 0x1A6A488 Offset: 0x1A6A488 VA: 0x1A6A488
		public static IEnumerator Co_ShowPopup(IKDICBBFBMI_EventBase eventCtrl, Transform parent, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallback)
		{
			//0x1A6BB94
			if(IsCreateSetting(eventCtrl))
			{
				PopupRewardEvCheckSetting s = new PopupRewardEvCheckSetting();
				s.WindowSize = SizeType.Large;
				s.TitleText = "";
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				sm_Setting = s;
				sm_Setting.EventCtrl = eventCtrl;
				sm_Setting.InitializeView();
				sm_Setting.SetParent(parent);
				if(sm_Setting.GetViewData.is_point_reward)
				{
					if(!sm_Setting.GetViewData.is_rank_reward)
					{
						sm_Setting.Tabs = new PopupTabButton.ButtonLabel[2]
						{
							PopupTabButton.ButtonLabel.CumulativePoint,
							PopupTabButton.ButtonLabel.Plate
						};
					}
					else
					{
						sm_Setting.Tabs = new PopupTabButton.ButtonLabel[3]
						{
							PopupTabButton.ButtonLabel.CumulativePoint,
							PopupTabButton.ButtonLabel.Rankings,
							PopupTabButton.ButtonLabel.Plate
						};
					}
				}
				sm_Setting.DefaultTab = DEFAULT_TAB;
			}
			PopupWindowManager.Show(sm_Setting, buttonCallback, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x1A6A9B8
				(content as PopupRewardEvCheck).ChangeTab(label);
			}, null, null);
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x70DC24 Offset: 0x70DC24 VA: 0x70DC24
		// // RVA: 0x1A6A568 Offset: 0x1A6A568 VA: 0x1A6A568
		// public static IEnumerator Co_ShowPopupRaidEvent(IKDICBBFBMI eventCtrl, bool isRaidBossSelect, Transform parent, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallback) { }

		// [CompilerGeneratedAttribute] // RVA: 0x70DCBC Offset: 0x70DCBC VA: 0x70DCBC
		// // RVA: 0x1A6A8FC Offset: 0x1A6A8FC VA: 0x1A6A8FC
		// private void <UpdateContent>b__46_5() { }
	}
}
