using mcrs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	internal class DecoVisitListScene : TransitionRoot
	{
		private struct SortData
		{
			public SortItem item; // 0x0
			public bool desc; // 0x4
		}

		[Flags()] // RVA: 0x63FFE0 Offset: 0x63FFE0 VA: 0x63FFE0
		private enum SearchPlayerFilter
		{
			Frined = 1,
			Favorite = 2,
		}

		private LayoutDecorationVisitWindow m_layoutDecorationVisitWindow; // 0x48
		private LayoutDecorationVisitButton m_layoutDecorationVisitButtons; // 0x4C
		private PopupDecoSentGiftSetting m_sentGiftPopupSetting = new PopupDecoSentGiftSetting(); // 0x50
		private TextPopupSetting m_sentGiftErrorPopupSetting; // 0x54
		private ButtonInfo[] m_popupButtons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		}; // 0x58
		private SortData m_sort; // 0x5C
		private SortData[] m_sortList = new SortData[3]; // 0x64
		private bool m_monitorReloadCoolingTime; // 0x68
		private SakashoPlayerCriteria m_showPlayerCriteria; // 0x6C
		private SakashoPlayerCriteria m_listupFriendAndFavoriteCriteria; // 0x70
		private List<EAJCBFGKKFA_FriendInfo> m_friendPlayerData = new List<EAJCBFGKKFA_FriendInfo>(); // 0x74
		private LayoutDecorationVisitWindow.VisitTabType m_type; // 0x78
		private DecorationCanvas m_decorationCanvas; // 0x7C
		private DAJBODHMLAB_DecoPublicSet m_decoPublicData; // 0x80
		private DAJBODHMLAB_DecoPublicSet m_visitDecoPublicData; // 0x84
		private HNKMEOKCNBI m_netDecoVisitControl = new HNKMEOKCNBI(); // 0x88
		private List<int> m_presentSentPlayerIdList = new List<int>(); // 0x8C
		private List<IBIGBMDANNM> m_cashFriendPlayerData_Other; // 0x90
		private List<IBIGBMDANNM> m_friendPlayerData_OtherRandomList = new List<IBIGBMDANNM>(); // 0x94
		private bool m_reloadSearchMember; // 0x98
		private Action m_decorationUpdater; // 0x9C
		private CompatibleLayoutAnimeParam animParam; // 0xA0

		// RVA: 0x11CFC2C Offset: 0x11CFC2C VA: 0x11CFC2C Slot: 4
		protected override void Awake()
		{
			base.Awake();
			string deco_visit_search_key = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_visit_search_key", "");
			int v;
			int? deco_visit_search_from_value = null;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMKNPOJDIPP("deco_visit_search_from_value", out v))
				deco_visit_search_from_value = v;
			int? deco_visit_search_to_value = null;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.GMKNPOJDIPP("deco_visit_search_to_value", out v))
				deco_visit_search_to_value = v;
			m_listupFriendAndFavoriteCriteria = SakashoPlayerCriteria.NewCriteriaFromTo(deco_visit_search_key, deco_visit_search_from_value, deco_visit_search_to_value);
			m_showPlayerCriteria = SakashoPlayerCriteria.NewCriteriaFromTo(deco_visit_search_key, deco_visit_search_from_value, deco_visit_search_to_value);
			m_decorationCanvas = GameObject.Find(DecorationConstants.CanvasName).GetComponent<DecorationCanvas>();
			m_sort.item = SortItem.LastPlayDate;
			m_sort.desc = true;
			for(int i = 0; i < m_sortList.Length; i++)
			{
				m_sortList[i].item = m_sort.item;
				m_sortList[i].desc = m_sort.desc;
			}
			this.StartCoroutineWatched(Co_LoadResource());
		}

		// RVA: 0x11D0034 Offset: 0x11D0034 VA: 0x11D0034
		private void Update()
		{
			if(m_monitorReloadCoolingTime && m_type == LayoutDecorationVisitWindow.VisitTabType.Other)
			{
				m_layoutDecorationVisitButtons.SetReloadButtonLock(CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.CDOBDJFJLPG_GetRecheckTime() > 0);
			}
			if (m_decorationUpdater != null)
				m_decorationUpdater();
		}

		// RVA: 0x11D0150 Offset: 0x11D0150 VA: 0x11D0150 Slot: 14
		protected override void OnDestoryScene()
		{
			m_layoutDecorationVisitWindow.Release();
			m_decorationUpdater = null;
		}

		// RVA: 0x11D0188 Offset: 0x11D0188 VA: 0x11D0188 Slot: 15
		protected override void OnDeleteCache()
		{
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		// RVA: 0x11D0250 Offset: 0x11D0250 VA: 0x11D0250 Slot: 16
		protected override void OnPreSetCanvas()
		{
			Initialize();
		}

		//// RVA: 0x11D0254 Offset: 0x11D0254 VA: 0x11D0254
		private void Initialize()
		{
			m_monitorReloadCoolingTime = true;
			UpdateGiftCount();
			m_layoutDecorationVisitWindow.SettingMember(0);
			m_layoutDecorationVisitWindow.SettingTab();
			m_layoutDecorationVisitWindow.Initilize();
			animParam.Initialize(0, 0);
			m_decorationUpdater = () =>
			{
				//0x11D24A8
				int f = animParam.UpdateFrame(Time.deltaTime);
				m_layoutDecorationVisitWindow.IconAnimUpdate(f);
			};
			if(Args != null && Args is DecoVisitArgs)
			{
				DecoVisitArgs arg = Args as DecoVisitArgs;
				m_layoutDecorationVisitWindow.ChangeTab(0);
				m_type = 0;
				if (arg.reloadSearchMember)
					m_cashFriendPlayerData_Other = null;
			}
			else
			{
				m_layoutDecorationVisitWindow.ChangeTab(m_type);
			}
			m_layoutDecorationVisitButtons.UpdateSortOrder(m_sort.desc);
		}

		//// RVA: 0x11D04AC Offset: 0x11D04AC VA: 0x11D04AC
		private void UpdateGiftCount()
		{
			int present_max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("present_max", 1);
			m_layoutDecorationVisitWindow.SettingGiftNum(m_netDecoVisitControl.OIONBFLLDIB_GetPresentCountLeftToSend(), present_max);
			m_layoutDecorationVisitWindow.UpdateScrollList();
		}

		// RVA: 0x11D0610 Offset: 0x11D0610 VA: 0x11D0610 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_layoutDecorationVisitWindow.Enter();
			m_layoutDecorationVisitButtons.Enter();
		}

		// RVA: 0x11D0660 Offset: 0x11D0660 VA: 0x11D0660 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_monitorReloadCoolingTime = false;
			m_layoutDecorationVisitWindow.Leave();
			m_layoutDecorationVisitButtons.Leave();
		}

		// RVA: 0x11D06B8 Offset: 0x11D06B8 VA: 0x11D06B8 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return m_layoutDecorationVisitWindow.IsPlayingEnd() && m_layoutDecorationVisitButtons.IsPlayingEnd();
		}

		// RVA: 0x11D0718 Offset: 0x11D0718 VA: 0x11D0718 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return m_layoutDecorationVisitWindow.IsPlayingEnd() && m_layoutDecorationVisitButtons.IsPlayingEnd();
		}

		//// RVA: 0x11D06BC Offset: 0x11D06BC VA: 0x11D06BC
		//private bool IsPlayingEnd() { }

		// RVA: 0x11D071C Offset: 0x11D071C VA: 0x11D071C Slot: 23
		protected override void OnActivateScene()
		{
			TabCallback(m_type);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D510C Offset: 0x6D510C VA: 0x6D510C
		//// RVA: 0x11CFFA8 Offset: 0x11CFFA8 VA: 0x11CFFA8
		private IEnumerator Co_LoadResource()
		{
			//0x11D4DA0
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_sentGiftPopupSetting.TitleText = bk.GetMessageByLabel("pop_deco_gift_success_title");
			m_sentGiftPopupSetting.SetParent(transform);
			m_sentGiftPopupSetting.WindowSize = SizeType.Small;
			m_sentGiftPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_sentGiftErrorPopupSetting = PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("pop_deco_gift_failed_title"), SizeType.Small, bk.GetMessageByLabel("pop_deco_gift_failed_message"), m_popupButtons, false, true);
			yield return this.StartCoroutineWatched(Co_LoadLayout());
			IsReady = true;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D5184 Offset: 0x6D5184 VA: 0x6D5184
		//// RVA: 0x11D079C Offset: 0x11D079C VA: 0x11D079C
		private IEnumerator Co_LoadLayout()
		{
			//0x11D4500
			yield return this.StartCoroutineWatched(Co_LoadLayoutVisitWindow());
			yield return this.StartCoroutineWatched(Co_LoadLayoutVisitButton());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D51FC Offset: 0x6D51FC VA: 0x6D51FC
		//// RVA: 0x11D0848 Offset: 0x11D0848 VA: 0x11D0848
		private IEnumerator Co_LoadLayoutVisitWindow()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x11D49DC
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, "root_deco_window_02_layout_root");
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x11D24F8
				instance.transform.SetParent(transform, false);
				m_layoutDecorationVisitWindow = instance.GetComponent<LayoutDecorationVisitWindow>();
				m_layoutDecorationVisitWindow.OnClickAllGiftButtonCallback = OnClickAllGiftButton;
				m_layoutDecorationVisitWindow.OnClickGiftButton = OnClickGiftButton;
				m_layoutDecorationVisitWindow.OnClickVisitButton = OnClickVisitButton;
				m_layoutDecorationVisitWindow.OnClickDivaIcon = OnClickDivaIcon;
				m_layoutDecorationVisitWindow.TabCallback = TabCallback;
				m_layoutDecorationVisitWindow.Hide();
			}));
			yield return new WaitUntil(() =>
			{
				//0x11D279C
				return m_layoutDecorationVisitWindow.IsLoadedList;
			});
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName, false);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D5274 Offset: 0x6D5274 VA: 0x6D5274
		//// RVA: 0x11D08F4 Offset: 0x11D08F4 VA: 0x11D08F4
		private IEnumerator Co_LoadLayoutVisitButton()
		{
			AssetBundleLoadLayoutOperationBase op;

			//0x11D467C
			op = AssetBundleManager.LoadLayoutAsync(DecorationConstants.BundleName, LayoutDecorationVisitButton.AssetName);
			yield return op;
			yield return Co.R(op.InitializeLayoutCoroutine(GameManager.Instance.GetSystemFont(), (GameObject instance) =>
			{
				//0x11D27C8
				instance.transform.SetParent(transform, false);
				m_layoutDecorationVisitButtons = instance.GetComponent<LayoutDecorationVisitButton>();
				m_layoutDecorationVisitButtons.ClickSortButtonCallback = OnClickSortButton;
				m_layoutDecorationVisitButtons.ClickSortOrderButtonCallback = OnClickSortOrderButton;
				m_layoutDecorationVisitButtons.ClickMemberReloadButtonCallback = OnClickMemberReloadButton;
				m_layoutDecorationVisitButtons.Hide();
			}));
			AssetBundleManager.UnloadAssetBundle(DecorationConstants.BundleName);
		}

		//// RVA: 0x11D09A0 Offset: 0x11D09A0 VA: 0x11D09A0
		private void OnClickSortButton()
		{
			MenuScene.Instance.ShowSortWindow(PopupSortMenu.SortPlace.VisitList, m_sort.item, (PopupSortMenu content) =>
			{
				//0x11D29A8
				if (content.SortItem == m_sort.item)
					return;
				m_sort.item = content.SortItem;
				m_layoutDecorationVisitButtons.UpdateSortImage(m_sort.item);
				m_sort.desc = true;
				GenerateFriendList(true);
				UpdateFriendList();
				m_layoutDecorationVisitButtons.UpdateSortOrder(m_sort.desc);
				m_sortList[(int)m_type].item = m_sort.item;
			}, null);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0x11D0AF0 Offset: 0x11D0AF0 VA: 0x11D0AF0
		private void ChangeSort(SortItem sortItem, List<IBIGBMDANNM> list, bool isOrder)
		{
			if(sortItem == SortItem.LastPlayDate)
			{
				list.Sort((IBIGBMDANNM lhs, IBIGBMDANNM rhs) =>
				{
					//0x11D2BBC
					int res = lhs.AJECHDLMKOE_LastLogin.CompareTo(rhs.AJECHDLMKOE_LastLogin);
					if (res == 0)
						res = lhs.MLPEHNBNOGD_Id.CompareTo(rhs.MLPEHNBNOGD_Id);
					if (isOrder)
						res = -res;
					return res;
				});
			}
			else if(sortItem == SortItem.FanNum)
			{
				list.Sort((IBIGBMDANNM lhs, IBIGBMDANNM rhs) =>
				{
					//0x11D2CA0
					IFICNCAHIGI a = lhs as IFICNCAHIGI;
					IFICNCAHIGI b = rhs as IFICNCAHIGI;
					int res = a.AGDBNNEAIIC_FanNum.CompareTo(b.AGDBNNEAIIC_FanNum);
					if (res == 0)
						res = lhs.MLPEHNBNOGD_Id.CompareTo(rhs.MLPEHNBNOGD_Id);
					if (isOrder)
						res = -res;
					return res;
				});
			}
			else if(sortItem == SortItem.PlayerRunk)
			{
				list.Sort((IBIGBMDANNM lhs, IBIGBMDANNM rhs) =>
				{
					//0x11D2AB8
					int res = lhs.ADFIHAPELAN_PLevel.CompareTo(rhs.ADFIHAPELAN_PLevel);
					if (res == 0)
						res = lhs.MLPEHNBNOGD_Id.CompareTo(rhs.MLPEHNBNOGD_Id);
					if (isOrder)
						res = -res;
					return res;
				});
			}
		}

		//// RVA: 0x11D0CD0 Offset: 0x11D0CD0 VA: 0x11D0CD0
		private void OnClickSortOrderButton()
		{
			m_sort.desc = !m_sort.desc;
			m_sortList[(int)m_type].desc = m_sort.desc;
			m_layoutDecorationVisitButtons.UpdateSortOrder(m_sort.desc);
			GenerateFriendList(true);
			UpdateFriendList();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0x11D1098 Offset: 0x11D1098 VA: 0x11D1098
		private void OnClickMemberReloadButton()
		{
			if (m_type != LayoutDecorationVisitWindow.VisitTabType.Other)
				return;
			m_cashFriendPlayerData_Other = null;
			m_layoutDecorationVisitButtons.SetReloadButtonLock(true);
			this.StartCoroutineWatched(Co_SearchMember());
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//// RVA: 0x11D11D0 Offset: 0x11D11D0 VA: 0x11D11D0
		private void OnClickDivaIcon(EAJCBFGKKFA_FriendInfo player)
		{
			ProfilDateArgs arg = new ProfilDateArgs();
			arg.data = player;
			arg.infoType = ProfilMenuLayout.InfoType.PLAYER;
			arg.btnType = ProfilMenuLayout.ButtonType.Fan;
			MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, false);
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_001);
		}

		//// RVA: 0x11D133C Offset: 0x11D133C VA: 0x11D133C
		private void OnClickVisitButton(EAJCBFGKKFA_FriendInfo player, IiconTexture texture, MusicRatioTextureCache.MusicRatioTexture musicRatioTexture)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			VisitDecoSceneArgs arg = new VisitDecoSceneArgs();
			arg.friendData = player;
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK(JpStringLiterals.StringLiteral_15546, player.MLPEHNBNOGD_Id);
			ILCCJNDFFOB.HHCJCDFCLOB.PFBIHCIFFKM(player.MLPEHNBNOGD_Id, CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PDEACDHIJJJ_IsFriend(player.MLPEHNBNOGD_Id), true, 0);
			MenuScene.Instance.MountWithFade(TransitionUniqueId.DECO_DECOVISIT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		//// RVA: 0x11D15C8 Offset: 0x11D15C8 VA: 0x11D15C8
		private void OnClickAllGiftButton()
		{
			this.StartCoroutineWatched(Co_ClickAllGift());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D52EC Offset: 0x6D52EC VA: 0x6D52EC
		//// RVA: 0x11D15EC Offset: 0x11D15EC VA: 0x11D15EC
		private IEnumerator Co_ClickAllGift()
		{
			//0x11D3308
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			int present_max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("present_max", 1);
			m_presentSentPlayerIdList.Clear();
			for(int i = 0; i < present_max && i < m_friendPlayerData.Count; i++)
			{
				m_presentSentPlayerIdList.Add(m_friendPlayerData[i].MLPEHNBNOGD_Id);
			}
			yield return this.StartCoroutineWatched(Co_Gift(m_presentSentPlayerIdList));
		}

		//// RVA: 0x11D1698 Offset: 0x11D1698 VA: 0x11D1698
		private void OnClickGiftButton(EAJCBFGKKFA_FriendInfo player)
		{
			m_presentSentPlayerIdList.Clear();
			m_presentSentPlayerIdList.Add(player.MLPEHNBNOGD_Id);
			this.StartCoroutineWatched(Co_Gift(m_presentSentPlayerIdList));
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D5364 Offset: 0x6D5364 VA: 0x6D5364
		//// RVA: 0x11D17C0 Offset: 0x11D17C0 VA: 0x11D17C0
		private IEnumerator Co_Gift(List<int> playerIdList)
		{
			BBHNACPENDM_ServerSaveData pd; // 0x20
			int i; // 0x24

			//0x11D3658
			if(NKGJPJPHLIF.HHCJCDFCLOB.DPJBHHIHJJK)
			{
				yield return this.StartCoroutineWatched(DecoScene.Co_UpdateDirtyTime());
			}
			if (MenuScene.CheckDatelineAndAssetUpdate())
				yield break;
			PIGBKEIAMPE_FriendManager fm = CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager;
			MenuScene.Instance.InputDisable();
			pd = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			bool isDone = false;
			bool isExcess = false;
			bool isError = false;
			bool isAlreadySent = false;
			int _itemId = 0;
			int _itemCount = 0;
			int _sentCount = 0;
			for(i = 0; i < playerIdList.Count; i++)
			{
				isDone = false;
				isExcess = false;
				isError = false;
				int playerId = playerIdList[i];
				m_netDecoVisitControl.KCKOFIIHDBJ_SendGift(playerId, (int itemId, int count) =>
				{
					//0x11D2ED0
					ILCCJNDFFOB.HHCJCDFCLOB.PFBIHCIFFKM(playerId, fm.PDEACDHIJJJ_IsFriend(playerId), false, itemId);
					isDone = true;
					_itemId = itemId;
					_itemCount += count;
					_sentCount++;
				}, () =>
				{
					//0x11D2E74
					isExcess = true;
					isDone = true;
				}, () =>
				{
					//0x11D2E84
					isAlreadySent = true;
					isDone = true;
				}, () =>
				{
					//0x11D2E94
					isError = true;
					isDone = true;
				});
				while (!isDone)
					yield return null;
				if(isError)
				{
					MenuScene.Instance.GotoTitle();
					yield break;
				}
				if (isExcess)
					break;
			}
			if(isExcess && _sentCount == 0)
			{
				isDone = false;
				PopupWindowManager.Show(m_sentGiftErrorPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x11D2EA4
					isDone = true;
				}, null, null, null);
				while (!isDone)
					yield return null;
			}
			else
			{
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.JCHLONCMPAJ();
				CIOECGOMILE.HHCJCDFCLOB.JANMJPOKLFL.CPIICACGNBH_AddItem(pd, _itemId, _itemCount, null, 0);
				m_sentGiftPopupSetting.itemId = _itemId;
				m_sentGiftPopupSetting.count = _itemCount;
				m_sentGiftPopupSetting.sentCount = _sentCount;
				isDone = false;
				MenuScene.Save(() =>
				{
					//0x11D2EB0
					isDone = true;
				}, null);
				while (!isDone)
					yield return null;
				isDone = false;
				PopupWindowManager.Show(m_sentGiftPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x11D2EBC
					isDone = true;
				}, null, null, null);
				while(!isDone)
					yield return null;
			}
			//LAB_011d424c
			UpdateGiftCount();
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0x11D0724 Offset: 0x11D0724 VA: 0x11D0724
		private void TabCallback(LayoutDecorationVisitWindow.VisitTabType type)
		{
			m_type = type;
			this.StartCoroutineWatched(Co_SearchMember());
			if (m_type == LayoutDecorationVisitWindow.VisitTabType.Other)
				return;
			m_layoutDecorationVisitButtons.SetReloadButtonLock(true);
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D53DC Offset: 0x6D53DC VA: 0x6D53DC
		//// RVA: 0x11D1144 Offset: 0x11D1144 VA: 0x11D1144
		private IEnumerator Co_SearchMember()
		{
			//0x11D5620
			MenuScene.Instance.InputDisable();
			if(m_type == LayoutDecorationVisitWindow.VisitTabType.Friend)
			{
				yield return this.StartCoroutineWatched(Co_SearchFriendFavoritePlayer(SearchPlayerFilter.Frined));
			}
			else if(m_type == LayoutDecorationVisitWindow.VisitTabType.Fan)
			{
				yield return this.StartCoroutineWatched(Co_SearchFriendFavoritePlayer(SearchPlayerFilter.Favorite));
			}
			else if(m_type == LayoutDecorationVisitWindow.VisitTabType.Other)
			{
				yield return this.StartCoroutineWatched(Co_SearchPlayerOther());
			}
			GenerateFriendList(true);
			UpdateFriendList();
			MenuScene.Instance.InputEnable();
		}

		//// RVA: 0x11D18A8 Offset: 0x11D18A8 VA: 0x11D18A8
		private void GenerateOtherRandomList()
		{
			int deco_visit_search_random_count = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("deco_visit_search_random_count", 2);
			m_friendPlayerData_OtherRandomList.Clear();
			List<int> l = new List<int>();
			for (int i = 0; i < m_cashFriendPlayerData_Other.Count && i < deco_visit_search_random_count; i++)
			{
				int a = UnityEngine.Random.Range(0, m_cashFriendPlayerData_Other.Count);
				if(!l.Contains(a))
				{
					m_friendPlayerData_OtherRandomList.Add(m_cashFriendPlayerData_Other[a]);
					l.Add(a);
				}
				else
				{
					if (m_cashFriendPlayerData_Other.Count <= l.Count)
						return;
				}
			}
		}

		//// RVA: 0x11D0E24 Offset: 0x11D0E24 VA: 0x11D0E24
		private void UpdateFriendList()
		{
			m_layoutDecorationVisitWindow.UpdateList(m_friendPlayerData, m_type, m_friendPlayerData.Count);
			if(m_type == LayoutDecorationVisitWindow.VisitTabType.Other)
			{
				m_layoutDecorationVisitWindow.SettingMember(m_friendPlayerData.Count);
			}
			else if(m_type == LayoutDecorationVisitWindow.VisitTabType.Fan)
			{
				m_layoutDecorationVisitWindow.SettingMember(m_friendPlayerData.Count, PIGBKEIAMPE_FriendManager.DJHFILDBOFG());
			}
			else if(m_type == LayoutDecorationVisitWindow.VisitTabType.Friend)
			{
				m_layoutDecorationVisitWindow.SettingMember(m_friendPlayerData.Count, CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.JPEIBHJIHPI_FriendLimit);
			}
		}

		//// RVA: 0x11D0DBC Offset: 0x11D0DBC VA: 0x11D0DBC
		private void GenerateFriendList(bool isChangeOrder)
		{
			int max;
			bool random;
			List<IBIGBMDANNM> l = GetList(out max, out random);
			if(isChangeOrder)
			{
				ChangeSort(m_sort.item, l, m_sort.desc);
			}
			AddFriendList(max, false, l);
		}

		//// RVA: 0x11D1BF4 Offset: 0x11D1BF4 VA: 0x11D1BF4
		private List<IBIGBMDANNM> GetList(out int max, out bool random)
		{
			max = -1;
			random = false;
			if(m_type < LayoutDecorationVisitWindow.VisitTabType.Other)
			{
				return CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.BFDEHIANFOG;
			}
			else
			{
				max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("deco_visit_list_count", 1);
				return m_friendPlayerData_OtherRandomList;
			}
		}

		//// RVA: 0x11D1D94 Offset: 0x11D1D94 VA: 0x11D1D94
		private void AddFriendList(int max, bool isRandom, List<IBIGBMDANNM> list)
		{
			m_friendPlayerData.Clear();
			int cnt = list.Count;
			if(max != -1)
			{
				cnt = Mathf.Min(max, cnt);
			}
			for(int i = 0; i < cnt; i++)
			{
				EAJCBFGKKFA_FriendInfo f = new EAJCBFGKKFA_FriendInfo();
				f.KHEKNNFCAOI(list[i]);
				m_friendPlayerData.Add(f);
			}
		}

		//// RVA: 0x11D1F58 Offset: 0x11D1F58 VA: 0x11D1F58
		//private void RandomSort(List<IBIGBMDANNM> list) { }

		//[IteratorStateMachineAttribute] // RVA: 0x6D5454 Offset: 0x6D5454 VA: 0x6D5454
		//// RVA: 0x11D214C Offset: 0x11D214C VA: 0x11D214C
		private IEnumerator Co_SearchFriendFavoritePlayer(SearchPlayerFilter a_filter)
		{
			//0x11D519C
			bool isConnected = false;
			PIGBKEIAMPE_FriendManager.KIELKOCLIGG k = new PIGBKEIAMPE_FriendManager.KIELKOCLIGG();
			k.IPKCADIAAPG = m_listupFriendAndFavoriteCriteria;
			k.BBCOJEPJNMO = (IBIGBMDANNM player) =>
			{
				//0x11D308C
				IFICNCAHIGI p = player as IFICNCAHIGI;
				bool b = false;
				if((a_filter & SearchPlayerFilter.Favorite) != 0)
				{
					b = p.BBNAEPGAMMA;
				}
				return b || (a_filter & SearchPlayerFilter.Frined) != 0;
			};
			k.PHCKPOKKBGD = (IFICNCAHIGI player) =>
			{
				//0x11D3160
				return (a_filter & SearchPlayerFilter.Favorite) != 0;
			};
			bool isError = false;
			CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.EGLFECJOPPP_SearchFriendAndFavoritePlayer(k, () =>
			{
				//0x11D316C
				isConnected = true;
			}, () =>
			{
				//0x11D3178
				isConnected = true;
				isError = false;
			});
			yield return new WaitUntil(() =>
			{
				return isConnected;
			});
			if(isError)
			{
				MenuScene.Instance.GotoTitle();
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6D54CC Offset: 0x6D54CC VA: 0x6D54CC
		//// RVA: 0x11D2214 Offset: 0x11D2214 VA: 0x11D2214
		private IEnumerator Co_SearchPlayerOther()
		{
			//0x11D5974
			if(m_cashFriendPlayerData_Other == null)
			{
				bool isConnected = false;
				bool isError = false;
				int deco_visit_search_random_count = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("deco_visit_search_random_count", 1);
				CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.CPEHDILBIJA_SearchPlayerWithoutFriendAndFavorite(deco_visit_search_random_count, m_showPlayerCriteria, () =>
				{
					//0x11D3194
					isConnected = true;
					m_cashFriendPlayerData_Other = new List<IBIGBMDANNM>();
					m_cashFriendPlayerData_Other.AddRange(CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.BFDEHIANFOG);
				}, () =>
				{
					//0x11D32EC
					isError = true;
					isConnected = true;
				});
				yield return new WaitUntil(() =>
				{
					//0x11D32FC
					return isConnected;
				});
				if(!isError)
				{
					GenerateOtherRandomList();
				}
				else
				{
					MenuScene.Instance.GotoTitle();
				}
			}
			else
			{
				for(int i = 0; i < m_cashFriendPlayerData_Other.Count; i++)
				{
					IFICNCAHIGI it = m_cashFriendPlayerData_Other[i] as IFICNCAHIGI;
					it.BBNAEPGAMMA = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(it.MLPEHNBNOGD_Id);
				}
			}
		}
	}
}
