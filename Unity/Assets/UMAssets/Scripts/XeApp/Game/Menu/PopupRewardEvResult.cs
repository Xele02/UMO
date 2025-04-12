using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using mcrs;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRewardEvResult : UIBehaviour, IPopupContent
	{
		public enum Type
		{
			NONE = -1,
			CumulativePoint = 0,
			Rankings = 1,
			RankingsEventHiScore = 2,
			RankingsEventBattleHiScore = 3,
			RankingGoDivaEvent = 4,
			NUM = 5,
		}

		public class ScrollListItem : IFlexibleListItem
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

			//// RVA: 0x1141B0C Offset: 0x1141B0C VA: 0x1141B0C
			public void OnShowItemDetails()
			{
				if(Item != null)
				{
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(Item.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
					{
						if(sceneData == null)
							sceneData = new GCIJNCFDNON_SceneInfo();
						sceneData.KHEKNNFCAOI(EKLNMHFCAOI.DEACAHNLMNI_getItemId(Item.JJBGOIMEIPF_ItemId), null, null, 0, 0, 0, false, 0, 0);
						MenuScene.Instance.ShowSceneStatusPopupWindow(sceneData, GameManager.Instance.ViewPlayerData, false, TransitionList.Type.UNDEFINED, null, true, true, SceneStatusParam.PageSave.None, false);
					}
					else
					{
						MenuScene.Instance.ShowItemDetail(Item.JJBGOIMEIPF_ItemId, Item.MBJIFDBEDAC_Cnt, null);
					}
				}
			}
		}

		public class HeaderItem : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public ViewRewardEvResultData Data { get; set; } // 0x1C
		}
		
		public class RankingHeader : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public string RankingMess { get; set; } // 0x1C
		}

		public class PopupRewardEvResultSetting : PopupSetting
		{
			private ViewRewardEvResultData m_ViewData; // 0x34

			public ViewRewardEvResultData GetViewData { get { return m_ViewData; } } //0x1A7D548
			public Type PopupType { get; set; } // 0x38
			public int DivaId { get; set; } // 0x3C
			public override string PrefabPath { get { return ""; } } //0x1A80178
			public override string BundleName { get { return "ly/053.xab"; } } //0x1A801D4
			public override string AssetName { get { return "PopupRewardEvResult"; } } //0x1A80230
			public override bool IsAssetBundle { get { return true; } } //0x1A8028C
			public override bool IsPreload { get { return true; } } //0x1A80294
			public override GameObject Content { get { return m_content; } } //0x1A8029C

			//// RVA: 0x1A802A4 Offset: 0x1A802A4 VA: 0x1A802A4
			//public void SetContent(GameObject obj) { }

			//// RVA: 0x1A7F9D8 Offset: 0x1A7F9D8 VA: 0x1A7F9D8
			public void Init(IKDICBBFBMI_EventBase eventController, OHCAABOMEOF.KGOGMKMBCPP_EventType debugEventType = 0)
			{
				if(m_ViewData == null)
					m_ViewData = new ViewRewardEvResultData();
				if(PopupType == Type.RankingsEventBattleHiScore)
				{
					m_ViewData.InitializeRanking(eventController, 1, debugEventType);
				}
				else if(PopupType == Type.RankingsEventHiScore)
				{
					m_ViewData.InitializeEvHighScoreRanking(eventController, debugEventType);
				}
				else if(PopupType == Type.CumulativePoint)
				{
					m_ViewData.InitializeCumulativePoint(eventController);
				}
				else if(PopupType == Type.RankingGoDivaEvent)
				{
					m_ViewData.InitializeRanking(eventController, 0, debugEventType);
				}
				else
				{
					m_ViewData.InitializeEvHighScoreRanking(eventController, debugEventType);
				}
			}

			//[IteratorStateMachineAttribute] // RVA: 0x70EBEC Offset: 0x70EBEC VA: 0x70EBEC
			// RVA: 0x1A802AC Offset: 0x1A802AC VA: 0x1A802AC Slot: 4
			public override IEnumerator LoadAssetBundlePrefab(Transform parent)
			{
				//0x1141888
				if(m_content == null)
				{
					yield return Co.R(Co_LoadPopupResource());
				}
			}

			//[IteratorStateMachineAttribute] // RVA: 0x70EC64 Offset: 0x70EC64 VA: 0x70EC64
			//// RVA: 0x1A80334 Offset: 0x1A80334 VA: 0x1A80334
			public IEnumerator Co_LoadPopupResource()
			{
				int loadCount; // 0x24
				PopupRewardEvResultLayout popupBaseLayout; // 0x28
				AssetBundleLoadLayoutOperationBase operation; // 0x2C

				//0x1A8042C
				loadCount = 0;
				popupBaseLayout = null;
				if(m_content == null)
				{
					operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvResult");
					yield return operation;
					yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
					{
						//0x1A803E0
						m_content = instance;
					}));
					loadCount++;
					yield return null;
				}
				//LAB_01a806a4
				popupBaseLayout = m_content.GetComponent<PopupRewardEvResultLayout>();
				GameObject item_inst = null;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvPointItem");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1A803F0
					item_inst = instance;
				}));
				popupBaseLayout.FxScrollView.AddLayoutCache(4, item_inst.GetComponent<LayoutUGUIRuntime>(), 7);
				Destroy(item_inst);
				loadCount++;
				item_inst = null;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvItem");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1A80400
					item_inst = instance;
				}));
				popupBaseLayout.FxScrollView.AddLayoutCache(3, item_inst.GetComponent<LayoutUGUIRuntime>(), 14);
				Destroy(item_inst);
				loadCount++;
				item_inst = null;
				GameObject goInstance = null;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvResultBanner");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1A80410
					goInstance = instance;
				}));
				popupBaseLayout.FxScrollView.AddLayoutCache(1, goInstance.GetComponent<LayoutUGUIRuntime>(), 1);
				Destroy(goInstance);
				loadCount++;
				goInstance = null;
				operation = AssetBundleManager.LoadLayoutAsync(BundleName, "PopupRewardEvCheckHeader");
				yield return operation;
				yield return Co.R(operation.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
				{
					//0x1A80420
					goInstance = instance;
				}));
				popupBaseLayout.FxScrollView.AddLayoutCache(2, goInstance.GetComponent<LayoutUGUIRuntime>(), 1);
				Destroy(goInstance);
				loadCount++;
				goInstance = null;
				for(int i = 0; i < loadCount; i++)
				{
					AssetBundleManager.UnloadAssetBundle(BundleName, false);
				}
			}
		}

		public class ViewRewardEvResultData
		{
			public List<IHAEIOAKEMG> total_data_list = new List<IHAEIOAKEMG>(); // 0x8
			public List<MFDJIFIIPJD> rankingRewardList = new List<MFDJIFIIPJD>(); // 0xC
			public Type data_type = Type.NONE; // 0x10

			public int EventId { get; private set; } // 0x14
			public int Rank { get; private set; } // 0x18
			public int RewardHighRank { get; private set; } // 0x1C
			public int RewardLowRank { get; private set; } // 0x20
			public long CurrentPoint { get; private set; } // 0x28
			public string EventName { get; private set; } // 0x30
			public OHCAABOMEOF.KGOGMKMBCPP_EventType EventType { get; private set; } // 0x34
			public string MusicName { get; private set; } // 0x38
			public int CoverId { get; private set; } // 0x3C
			public int evHighScore { get; private set; } // 0x40
			public int evScoreRank { get; private set; } // 0x44

			//// RVA: 0x1141EB8 Offset: 0x1141EB8 VA: 0x1141EB8
			//public void Reset() { }

			//// RVA: 0x1141F64 Offset: 0x1141F64 VA: 0x1141F64
			public void InitializeCumulativePoint(IKDICBBFBMI_EventBase eventController)
			{
				data_type = Type.CumulativePoint;
				CurrentPoint = eventController.FBGDBGKNKOD_GetCurrentPoint();
				for(int i = 0; i < eventController.JOFBHHHLBBN.Count; i++)
				{
					total_data_list.Add(eventController.PFPJHJJAGAG_Rewards[eventController.JOFBHHHLBBN[i]]);
				}
			}

			//// RVA: 0x11420D0 Offset: 0x11420D0 VA: 0x11420D0
			public void InitializeRanking(IKDICBBFBMI_EventBase eventController, int rankingIndex, OHCAABOMEOF.KGOGMKMBCPP_EventType debugEventType = 0)
			{
				data_type = Type.Rankings;
				rankingRewardList.Clear();
				Rank = eventController.HLFHJIDHJMP.FJOLNJLLJEJ_Rank;
				CurrentPoint = eventController.HLFHJIDHJMP.DNBFMLBNAEE_CurrentPoint;
				evHighScore = 0;
				evScoreRank = 0;
				EventId = eventController.PGIIDPEGGPI_EventId;
				EventName = eventController.DGCOMDILAKM_EventName;
				EventType = eventController.HIDHLFCBIDE_EventType;
				if(EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.PMKBMGNAJIL(eventController as HLEBAINCOME_EventScore, false);
					MusicName = ib.NEDBBJDAFBH_MusicName;
					CoverId = ib.JNCPEGJGHOG_JacketId;
				}
				for(int i = 0; i < eventController.HLFHJIDHJMP.HBHMAKNGKFK.Count; i++)
				{
					rankingRewardList.Add(eventController.HLFHJIDHJMP.HBHMAKNGKFK[i]);
				}
				int r = Rank;
				for(int i = 0; i < eventController.EGIPGHCDMII_RankData[rankingIndex].Count; i++)
				{
					if(eventController.EGIPGHCDMII_RankData[rankingIndex][i].JBDGBPAAAEF_HighRank <= r && r <= eventController.EGIPGHCDMII_RankData[rankingIndex][i].GHANKNIBALB_LowRank)
					{
						RewardHighRank = eventController.EGIPGHCDMII_RankData[rankingIndex][i].JBDGBPAAAEF_HighRank;
						RewardLowRank = eventController.EGIPGHCDMII_RankData[rankingIndex][i].GHANKNIBALB_LowRank;
					}
				}
			}

			//// RVA: 0x11424F4 Offset: 0x11424F4 VA: 0x11424F4
			public void InitializeEvHighScoreRanking(IKDICBBFBMI_EventBase eventController, OHCAABOMEOF.KGOGMKMBCPP_EventType debugEventType = 0)
			{
				data_type = Type.Rankings;
				rankingRewardList.Clear();
				evScoreRank = eventController.HLFHJIDHJMP.FJOLNJLLJEJ_Rank;
				CurrentPoint = eventController.HLFHJIDHJMP.DNBFMLBNAEE_CurrentPoint;
				Rank = evScoreRank;
				evHighScore = (int)CurrentPoint;
				EventId = eventController.PGIIDPEGGPI_EventId;
				EventName = eventController.DGCOMDILAKM_EventName;
				EventType = eventController.HIDHLFCBIDE_EventType;
				if(EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.KHEKNNFCAOI(eventController.HEACCHAKMFG_GetMusicsList()[0], false, 0, 0, 0, false, false, false);
					MusicName = ib.NEDBBJDAFBH_MusicName;
					CoverId = ib.JNCPEGJGHOG_JacketId;
				}
				else if(EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
				{
					IBJAKJJICBC ib = new IBJAKJJICBC();
					ib.KHEKNNFCAOI(eventController.HEACCHAKMFG_GetMusicsList()[0], false, 0, 0, 0, false, false, false);
					MusicName = ib.NEDBBJDAFBH_MusicName;
					CoverId = ib.JNCPEGJGHOG_JacketId;
				}
				//LAB_011427dc
				for(int i = 0; i < eventController.HLFHJIDHJMP.HBHMAKNGKFK.Count; i++)
				{
					rankingRewardList.Add(eventController.HLFHJIDHJMP.HBHMAKNGKFK[i]);
				}
				int r = Rank;
				for(int i = 0; i < eventController.EGIPGHCDMII_RankData[1].Count; i++)
				{
					if(eventController.EGIPGHCDMII_RankData[1][i].JBDGBPAAAEF_HighRank <= r && r <= eventController.EGIPGHCDMII_RankData[1][i].GHANKNIBALB_LowRank)
					{
						RewardHighRank = eventController.EGIPGHCDMII_RankData[1][i].JBDGBPAAAEF_HighRank;
						RewardLowRank = eventController.EGIPGHCDMII_RankData[1][i].GHANKNIBALB_LowRank;
					}
				}
			}
		}

		private List<IFlexibleListItem> m_scrollItemList = new List<IFlexibleListItem>(); // 0xC
		private static readonly List<ButtonInfo>[] BUTTON_LIST = new List<ButtonInfo>[5]
		{
			new List<ButtonInfo>() {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			},
			new List<ButtonInfo>() {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.FinalRankings, Type = PopupButton.ButtonType.Other },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			},
			new List<ButtonInfo>() {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.FinalRankings, Type = PopupButton.ButtonType.Other },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			},
			new List<ButtonInfo>() {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.FinalRankings, Type = PopupButton.ButtonType.Other },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			},
			new List<ButtonInfo>() {
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive },
			}
		}; // 0x0
		private static PopupRewardEvResultSetting sm_Setting; // 0x4
		private PopupRewardEvResultSetting m_setting; // 0x14
		private PopupRewardEvResultLayout m_MainLayout; // 0x18
		private PopupRewardEvResultBannerLayout m_BannerLayout; // 0x1C
		private PopupRewardEvResultRankHeaderLayout m_RankHeaderLayout; // 0x20
		private bool m_isReady; // 0x24

		public Transform Parent { get; private set; } // 0x10

		// RVA: 0x1A7C468 Offset: 0x1A7C468 VA: 0x1A7C468 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupRewardEvResultSetting s = setting as PopupRewardEvResultSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = Vector3.zero;
			Parent = setting.m_parent;
			m_setting = s;
			m_MainLayout = transform.GetComponent<PopupRewardEvResultLayout>();
			m_MainLayout.SetType = s.PopupType;
			m_isReady = false;
			MakeScrollItem();
			gameObject.SetActive(true);
		}

		//// RVA: 0x1A7C6E4 Offset: 0x1A7C6E4 VA: 0x1A7C6E4
		private void MakeScrollItem()
		{
			m_scrollItemList.Clear();
			float f = 0;
			if(m_setting.PopupType >= Type.Rankings && m_setting.PopupType <= Type.RankingGoDivaEvent)
			{
				HeaderItem it = new HeaderItem();
				it.Top = new Vector2(0, 0);
				it.ResourceType = 1;
				it.Height = m_setting.GetViewData.EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore ? 135 : 93;
				it.Data = m_setting.GetViewData;
				m_scrollItemList.Add(it);
				f = it.Height;
				RankingHeader header = new RankingHeader();
				header.Top = new Vector2(0, -f);
				header.ResourceType = 2;
				header.RankingMess = PopupRewardEvCheck.MakeRakingMessage(m_setting.GetViewData.RewardHighRank, m_setting.GetViewData.RewardLowRank);
				header.Height = 55;
				m_scrollItemList.Add(header);
				f += 55;
			}
			if(m_setting.GetViewData.data_type == 0)
			{
				for(int i = 0; i < m_setting.GetViewData.total_data_list.Count; i++)
				{
					for(int j = 0; j < m_setting.GetViewData.total_data_list[i].HBHMAKNGKFK_Items.Count; j++)
					{
						ScrollListItem scrollItem = new ScrollListItem();
						scrollItem.Top = new Vector2(0, -(f + m_scrollItemList.Count * 104 + 10));
						scrollItem.Height = 104;
						scrollItem.NeedPoint = m_setting.GetViewData.total_data_list[i].FIOIKMOIJGK_Point;
						scrollItem.Item = m_setting.GetViewData.total_data_list[i].HBHMAKNGKFK_Items[j];
						scrollItem.isGoldFrame = m_setting.GetViewData.total_data_list[i].HBHMAKNGKFK_Items[j].JOPPFEHKNFO_IsGold;
						scrollItem.ResourceType = 4;
						m_scrollItemList.Add(scrollItem);
					}
				}
			}
			else
			{
				for(int i = 0; i < m_setting.GetViewData.rankingRewardList.Count; i++)
				{
					ScrollListItem scrollItem = new ScrollListItem();
					scrollItem.Top = new Vector2((i / 2) * 480 + 10, -(f + (i % 2) * 108 + 4));
					scrollItem.Height = 108;
					scrollItem.Item = m_setting.GetViewData.rankingRewardList[i];
					scrollItem.isGoldFrame = m_setting.GetViewData.rankingRewardList[i].JOPPFEHKNFO_IsGold;
					scrollItem.ResourceType = 3;
					m_scrollItemList.Add(scrollItem);
				}
			}
			for(int i = 0; i < m_scrollItemList.Count; i++)
			{
				if(m_scrollItemList[i] != null)
				{
					if(m_scrollItemList[i] is ScrollListItem)
					{
						KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath((m_scrollItemList[i] as ScrollListItem).Item.JJBGOIMEIPF_ItemId, 0));
					}
					else if(m_scrollItemList[i] is HeaderItem)
					{
						HeaderItem h = m_scrollItemList[i] as HeaderItem;
						if(h.Data.EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
						{
							KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(MusicJacketTextureCache.MakeJacketTexturePath(h.Data.CoverId));
						}
						else
						{
							KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(EventBannerTextureCache.MakeBannerPath(h.Data.EventId));
						}
					}
				}
			}
		}

		// RVA: 0x1A7D58C Offset: 0x1A7D58C VA: 0x1A7D58C
		public void OnDestroy()
		{
			sm_Setting = null;
		}

		//// RVA: 0x1A7D61C Offset: 0x1A7D61C VA: 0x1A7D61C
		private void SetupScrollContent()
		{
			m_MainLayout = transform.GetComponent<PopupRewardEvResultLayout>();
			//RectTrasnform rt = m_MainLayout.GetScrollContent.Find("Range").GetComponent<RectTrasnform>();
			m_MainLayout.FxScrollView.SetupListItem(m_scrollItemList);
			m_MainLayout.FxScrollView.SetlistTop(0);
		}

		// RVA: 0x1A7D7AC Offset: 0x1A7D7AC VA: 0x1A7D7AC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1A7D7B4 Offset: 0x1A7D7B4 VA: 0x1A7D7B4 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			m_MainLayout.Setup(m_setting.PopupType, m_setting.GetViewData);
			m_MainLayout.SetPopupType(m_setting.PopupType, m_setting.GetViewData);
			m_MainLayout.FxScrollView.UpdateItemListener += UpdateContent;
			SetupScrollContent();
			this.StartCoroutineWatched(Co_Show());
			m_MainLayout.FxScrollView.LockScroll();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70E78C Offset: 0x70E78C VA: 0x70E78C
		//// RVA: 0x1A7D9CC Offset: 0x1A7D9CC VA: 0x1A7D9CC
		private IEnumerator Co_Show()
		{
			//0x1A7F550
			while(m_MainLayout.IsPlayTitleAnime(m_setting.PopupType))
				yield return null;
			m_MainLayout.StartTitleLoop(m_setting.PopupType);
		}

		// RVA: 0x1A7DA78 Offset: 0x1A7DA78 VA: 0x1A7DA78 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			m_MainLayout.FxScrollView.AllFree();
			m_scrollItemList.Clear();
			m_MainLayout.FxScrollView.UpdateItemListener -= UpdateContent;
			m_MainLayout.FxScrollView.LockScroll();
			OnDestroy();
		}

		// RVA: 0x1A7DC2C Offset: 0x1A7DC2C VA: 0x1A7DC2C Slot: 21
		public bool IsReady()
		{
			return GetComponent<PopupRewardEvResultLayout>().IsLoaded() && !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x1A7DD18 Offset: 0x1A7DD18 VA: 0x1A7DD18 Slot: 22
		public void CallOpenEnd()
		{
			this.StartCoroutineWatched(Co_DelayOpenEnd());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70E804 Offset: 0x70E804 VA: 0x70E804
		//// RVA: 0x1A7DD3C Offset: 0x1A7DD3C VA: 0x1A7DD3C
		private IEnumerator Co_DelayOpenEnd()
		{
			//0x1A7F36C
			yield return new WaitForSeconds(0.1f);
			m_MainLayout.FxScrollView.SetZeroVelocity();
			m_MainLayout.FxScrollView.UnLockScroll();
		}

		//// RVA: 0x1A7DDE8 Offset: 0x1A7DDE8 VA: 0x1A7DDE8
		private void UpdateContent(IFlexibleListItem item)
		{
			if(item != null)
			{
				if(item.Layout != null)
				{
					if(item is ScrollListItem)
					{
						PopupRewardEvItemLayout r = item.Layout.GetComponent<PopupRewardEvItemLayout>();
						if(r != null)
						{
							ScrollListItem s = item as ScrollListItem;
							r.SetItemData(s.Item, s.IsGet, s.isGoldFrame);
							r.SetRequiredPoint(s.NeedPoint);
							r.SetButtonEvent(() =>
							{
								//0x1A7F204
								SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
								s.OnShowItemDetails();
							});
						}
					}
					else if(item is HeaderItem)
					{
						PopupRewardEvResultBannerLayout r = item.Layout.GetComponent<PopupRewardEvResultBannerLayout>();
						if(r != null)
						{
							r.Set((item as HeaderItem).Data, m_setting.PopupType, m_setting.DivaId);
						}
					}
					else if(item is RankingHeader)
					{
						PopupRewardEvSeparatorLayout r = item.Layout.GetComponent<PopupRewardEvSeparatorLayout>();
						if(r != null)
							r.SetRunk((item as RankingHeader).RankingMess);
					}
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70E87C Offset: 0x70E87C VA: 0x70E87C
		//// RVA: 0x1A7E4C0 Offset: 0x1A7E4C0 VA: 0x1A7E4C0
		public static IEnumerator Co_ShowPopup_CumulativePoint(Transform parent, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack)
		{
			//0x1A7F6DC
			ApplySetting(Type.CumulativePoint, parent, 0);
			sm_Setting.Init(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false), OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0);
			GameManager.Instance.ResetViewPlayerData();
			PopupWindowManager.Show(sm_Setting, buttonCallBack, null, null, null, playSeEvent:(PopupWindowControl.SeType type) =>
			{
				//0x1A7F12C
				if(type != PopupWindowControl.SeType.WindowOpen)
					return false;
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_004);
				return true;
			});
			yield break;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70E8F4 Offset: 0x70E8F4 VA: 0x70E8F4
		//// RVA: 0x1A7E588 Offset: 0x1A7E588 VA: 0x1A7E588
		public static IEnumerator Co_ShowPopup_Ranking(int a_index, IKDICBBFBMI_EventBase controller, Transform parent, int divaId, Action<PopupWindowControl, PopupButton.ButtonType, PopupButton.ButtonLabel> buttonCallBack, Action finishCallBack)
		{
			//0x1A7FBD0
			if(controller.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
			{
				if(a_index == 0)
					ApplySetting(Type.Rankings, parent, 0);
				else
					ApplySetting(Type.RankingsEventBattleHiScore, parent, 0);
			}
			else if(controller.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
			{
				ApplySetting(Type.RankingGoDivaEvent, parent, divaId);
			}
			else
			{
				if(a_index != 1)
					ApplySetting(Type.Rankings, parent, 0);
				else
					ApplySetting(Type.RankingsEventHiScore, parent, 0);
			}
			bool isWait = true;
			sm_Setting.Init(controller, 0);
			PopupWindowManager.Show(sm_Setting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1A7F290
				if(buttonCallBack != null)
					buttonCallBack(control, type, label);
				isWait = false;
			}, null, null, null, playSeEvent:(PopupWindowControl.SeType type) =>
			{
				//0x1A7F198
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
				return true;
			});
			yield return null;
			while(isWait)
				yield return null;
			if(finishCallBack != null)
				finishCallBack();
		}

		//// RVA: 0x1A7E6B4 Offset: 0x1A7E6B4 VA: 0x1A7E6B4
		private static void ApplySetting(Type popup_type, Transform parent, int divaId = 0)
		{
			if(sm_Setting == null)
			{
				sm_Setting = new PopupRewardEvResultSetting();
				sm_Setting.WindowSize = SizeType.Large2;
				sm_Setting.IsCaption = false;
			}
			sm_Setting.PopupType = popup_type;
			sm_Setting.SetParent(parent);
			sm_Setting.Buttons = BUTTON_LIST[(int)popup_type].ToArray();
			sm_Setting.DivaId = divaId;
		}
	}
}
