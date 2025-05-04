using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LobbyGroupSelectSearchScene : TransitionRoot
	{
		private const float m_statusChangeSec = 3;
		private GuestListWindow m_windowUi; // 0x48
		private SwapScrollList m_scrollList; // 0x4C
		private List<DivaIconDecoration> m_divaDecos = new List<DivaIconDecoration>(); // 0x50
		private List<SceneIconDecoration> m_sceneDecos = new List<SceneIconDecoration>(); // 0x54
		private GeneralListButtonRuntime m_buttonRuntime; // 0x58
		private GeneralList.SortOrder m_sortOrder; // 0x5C
		private PopupSortMenu.SortPlace sortPlace = PopupSortMenu.SortPlace.LobbyMemberList; // 0x60
		private SortItem m_sortType; // 0x64
		private SortItem defaultSortType = SortItem.LastPlayDate; // 0x68
		private uint m_rarityFilter; // 0x6C
		private uint m_attrFilter; // 0x70
		private uint m_seriesFilter; // 0x74
		private TeamSlectSceneArgs m_teamSelectSceneArgs = new TeamSlectSceneArgs(); // 0x78
		private string m_guestNotFoundMessage; // 0x7C
		private string m_guestAllFilteredMessage; // 0x80
		private RankingSceneBase.WaitForFrame waitForFrame; // 0x84
		private bool m_monitorReloadCoolingTime; // 0x88
		private List<MembersListElem> m_elems = new List<MembersListElem>(); // 0x8C
		private List<MemberListInfo> m_guestInfoAllList = new List<MemberListInfo>(); // 0x90
		private List<MemberListInfo> m_guestInfoList = new List<MemberListInfo>(); // 0x94
		private List<EAJCBFGKKFA_FriendInfo> friends = new List<EAJCBFGKKFA_FriendInfo>(); // 0x98
		private GuestListWindow.CounterStyle listCounterSyle; // 0x9C
		private SelectLobbyInfo m_returnArgs; // 0xA0
		private Action m_updater; // 0xA4
		private CompatibleLayoutAnimeParam animParam; // 0xA8

		public ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList sortSaveData { get { return GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.ACCNCHJBDHM_UserList; } } //0x128D260

		// RVA: 0x128D348 Offset: 0x128D348 VA: 0x128D348 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			waitForFrame = new RankingSceneBase.WaitForFrame(3);
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0x128D46C Offset: 0x128D46C VA: 0x128D46C
		public void Update()
		{
			if(m_updater != null)
				m_updater();
		}

		// RVA: 0x128D480 Offset: 0x128D480 VA: 0x128D480 Slot: 16
		protected override void OnPreSetCanvas()
		{
			base.OnPreSetCanvas();
			m_returnArgs = null;
			m_buttonRuntime.Hide();
			this.StartCoroutineWatched(MenuScene.Instance.BgControl.ChangeBgCoroutine(BgType.LobbyMain, 3, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			Initialize();
			m_updater = IconAnimUpdate;
			m_windowUi.Hide();
		}

		// RVA: 0x128DCEC Offset: 0x128DCEC VA: 0x128DCEC Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !m_buttonRuntime.IsPlaying() && base.IsEndPreSetCanvas();
		}

		// RVA: 0x128DD34 Offset: 0x128DD34 VA: 0x128DD34 Slot: 18
		protected override void OnPostSetCanvas()
		{
			m_buttonRuntime.transform.SetAsLastSibling();
		}

		// RVA: 0x128DD80 Offset: 0x128DD80 VA: 0x128DD80 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			m_windowUi.transform.SetAsLastSibling();
			return true;
		}

		// RVA: 0x128DDD0 Offset: 0x128DDD0 VA: 0x128DDD0 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_buttonRuntime.Enter();
			m_windowUi.Enter();
			m_buttonRuntime.SetFriendButtonLock(true);
		}

		// RVA: 0x128DE44 Offset: 0x128DE44 VA: 0x128DE44 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_windowUi.IsPlaying();
		}

		// RVA: 0x128DE74 Offset: 0x128DE74 VA: 0x128DE74 Slot: 23
		protected override void OnActivateScene()
		{
			base.OnActivateScene();
			InitializeList();
		}

		// RVA: 0x128DF5C Offset: 0x128DF5C VA: 0x128DF5C Slot: 14
		protected override void OnDestoryScene()
		{
			for(int i = 0; i < m_divaDecos.Count; i++)
			{
				m_divaDecos[i].Release();
			}
			m_divaDecos.Clear();
			for(int i = 0; i < m_sceneDecos.Count; i++)
			{
				m_sceneDecos[i].Release();
			}
			m_sceneDecos.Clear();
		}

		// RVA: 0x128E104 Offset: 0x128E104 VA: 0x128E104 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_monitorReloadCoolingTime = false;
			m_buttonRuntime.Leave();
			m_windowUi.Leave();
		}

		// RVA: 0x128E15C Offset: 0x128E15C VA: 0x128E15C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_windowUi.IsPlaying() && !m_buttonRuntime.IsPlaying() && base.IsEndExitAnimation();
		}

		// RVA: 0x128E1D0 Offset: 0x128E1D0 VA: 0x128E1D0 Slot: 7
		protected override void OnDisable()
		{
			NKOBMDPHNGP_EventRaidLobby ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			ev.NGKIBBIEAAD();
		}

		// RVA: 0x128E31C Offset: 0x128E31C VA: 0x128E31C Slot: 28
		protected override TransitionArgs GetCallArgsReturn()
		{
			return m_returnArgs;
		}

		// RVA: 0x128E324 Offset: 0x128E324 VA: 0x128E324 Slot: 20
		protected override bool OnBgmStart()
		{
			SoundManager.Instance.bgmPlayer.ContinuousPlay(MenuScene.Instance.GetDefaultBgmId(SceneGroupCategory.LOBBY), 1);
			return true;
		}

		// // RVA: 0x128E41C Offset: 0x128E41C VA: 0x128E41C
		// private bool CheckTransitByReturn() { }

		// // RVA: 0x128E44C Offset: 0x128E44C VA: 0x128E44C
		// protected bool CheckEventLimit() { }

		// // RVA: 0x128D60C Offset: 0x128D60C VA: 0x128D60C
		private void Initialize()
		{
			InitializeSortSetting();
			if(TutorialProc.CanBeginnerAssistSelect())
			{
				m_sortOrder = GeneralList.SortOrder.Descend;
				m_sortType = SortItem.Rarity;
			}
			m_divaDecos.Capacity = m_elems.Count;
			m_sceneDecos.Capacity = m_elems.Count;
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetButtonAnimaiton(MembersListElem.ButtonType.Select, true);
				m_divaDecos.Add(new DivaIconDecoration(m_elems[i].GetDivaIconObject(), DivaIconDecoration.Size.S, false, true, null, null));
				m_sceneDecos.Add(new SceneIconDecoration(m_elems[i].GetSceneIconObject(), SceneIconDecoration.Size.M, null, null));
			}
			m_windowUi.SetMessageVisible(false);
			m_windowUi.SetCautionVisible(false);
			m_windowUi.SetCounterStyle(GuestListWindow.CounterStyle.Count);
			UpdateListCounter(0);
			m_guestNotFoundMessage = "";
			m_guestAllFilteredMessage = "";
			for(int i = 0; i < m_scrollList.ScrollObjectCount; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			m_monitorReloadCoolingTime = true;
			m_scrollList.SetItemCount(0);
			m_scrollList.VisibleRegionUpdate();
		}

		// // RVA: 0x128DE94 Offset: 0x128DE94 VA: 0x128DE94
		private void InitializeList()
		{
			SearchFriend();
			animParam = new CompatibleLayoutAnimeParam();
			animParam.Initialize(DivaIconDecoration.FriendFanFadeAnimStartFrame, DivaIconDecoration.FriendFanFadeAnimEndFrame);
		}

		// // RVA: 0x128DF60 Offset: 0x128DF60 VA: 0x128DF60
		// private void Release() { }

		// // RVA: 0x128EC60 Offset: 0x128EC60 VA: 0x128EC60
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			if(value == 3)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
				ProfilDateArgs arg = new ProfilDateArgs();
				arg.data = m_guestInfoList[content.Index].friend;
				arg.infoType = ProfilMenuLayout.InfoType.PLAYER;
				MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
			}
			else if(value == 4)
			{
				OnClickElemButton(content.Index);
			}
		}

		// // RVA: 0x128E9AC Offset: 0x128E9AC VA: 0x128E9AC
		private void SearchFriend()
		{
			NKOBMDPHNGP_EventRaidLobby cont = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			MenuScene.Instance.InputDisable();
			friends.Clear();
			cont.NLIJCLIGIFC(() =>
			{
				//0x1290DC4
				UpdateListCounter(cont.ACCNCHJBDHM_Users.Count);
				m_buttonRuntime.SetReloadButtonLock(cont.ACCNCHJBDHM_Users.Count < 1);
				m_windowUi.SetMessageVisible(cont.ACCNCHJBDHM_Users.Count < 1);
				for(int i = 0; i < cont.ACCNCHJBDHM_Users.Count; i++)
				{
					EAJCBFGKKFA_FriendInfo f = new EAJCBFGKKFA_FriendInfo();
					f.KHEKNNFCAOI(cont.ACCNCHJBDHM_Users[i]);
					friends.Add(f);
				}
				this.StartCoroutineWatched(OnSuccessSearchFriend());
			}, () =>
			{
				//0x1291198
				Debug.LogError("StringLiteral_18344");
				if(MenuScene.Instance.IsTransition())
				{
					GotoTitle();
				}
				else
				{
					MenuScene.Instance.GotoTitle();
				}
			});
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB7BC Offset: 0x6EB7BC VA: 0x6EB7BC
		// // RVA: 0x128F27C Offset: 0x128F27C VA: 0x128F27C
		private IEnumerator OnSuccessSearchFriend()
		{
			//0x12924F4
			m_guestInfoAllList.Clear();
			for(int i = 0; i < friends.Count; i++)
			{
				MemberListInfo info = new MemberListInfo((short)i, true, friends[i]);
				m_guestInfoAllList.Add(info);
				info.TryInstall();
			}
			waitForFrame.Reset(3);
			yield return waitForFrame;
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			SortGuestList();
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x128E89C Offset: 0x128E89C VA: 0x128E89C
		private void UpdateListCounter(int _groupNum)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("{0}", _groupNum);
			m_windowUi.SetCount(str.ToString());
		}

		// // RVA: 0x128EE64 Offset: 0x128EE64 VA: 0x128EE64
		private void OnClickElemButton(int elemIndex)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			Debug.Log("StringLiteral_18342");
			Debug.Log(m_guestInfoList[elemIndex].name);
			NKOBMDPHNGP_EventRaidLobby ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			SelectLobbyInfo arg = new SelectLobbyInfo();
			arg.selectIndex = ev.EEJNPNOADGC(m_guestInfoList[elemIndex].LobbyData);
			arg.isSearchPlayer = true;
			arg.data = m_guestInfoList[elemIndex].LobbyData;
			m_returnArgs = arg;
			MenuScene.Instance.Return();
		}

		// // RVA: 0x128F328 Offset: 0x128F328 VA: 0x128F328
		// private void OnClickReloadButton() { }

		// // RVA: 0x128F3D0 Offset: 0x128F3D0 VA: 0x128F3D0
		private void SortGuestList()
		{
			m_guestInfoAllList.Sort(SortDelegate);
			m_guestInfoList.Clear();
			m_guestInfoList.Capacity = m_guestInfoAllList.Count;
			for(int i = 0; i < m_guestInfoAllList.Count; i++)
			{
				if(PopupSortMenu.IsRarityFilterOn(m_guestInfoAllList[i].sceneRarity, m_rarityFilter))
				{
					if(PopupSortMenu.IsAttributeFilterOn((int)m_guestInfoAllList[i].sceneAttr, m_attrFilter))
					{
						if(PopupSortMenu.IsSerializeFilterOn((int)m_guestInfoAllList[i].sceneSeries, m_seriesFilter))
						{
							m_guestInfoList.Add(m_guestInfoAllList[i]);
						}
					}
				}
			}
			m_scrollList.SetItemCount(m_guestInfoList.Count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener((int index, SwapScrollListContent content) =>
			{
				//0x1290A98
				OnUpdateListItem(index, content as MembersListContent, m_guestInfoList[index]);
			});
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
		}

		// // RVA: 0x128F858 Offset: 0x128F858 VA: 0x128F858
		private void OnUpdateListItem(int index, MembersListContent content, MemberListInfo info)
		{
			MembersListElem m = content.GetElemUI<MembersListElem>();
			m.SetName(info.name);
			m.SetLoginDate(info.login);
			m.SetTotal(info.total.ToString());
			m.SetSoul(info.soul.ToString());
			m.SetVoice(info.voice.ToString());
			m.SetCharm(info.charm.ToString());
			m.SetLife(info.life.ToString());
			m.SetSupport(info.support.ToString());
			m.SetFold(info.fold.ToString());
			m.SetLuck(UnitWindowConstant.MakeLuckText(info.luck));
			m.SetMcannonPower(info.mcannonPowerMes);
			m.SetFunCount(info.funCount);
			m.SetMusicRank(info.scoreRatingRank);
			m.SetComment(info.GetBelongsGroupName());
			m.SetDivaIconDelegate(info.GetGuestDivaIconTex);
			m.SetSceneIconDelegate(info.GetGuestSceneIconTex);
			m.UpdateLayoutAnimation();
			int idx = m_elems.IndexOf(m);
			m_divaDecos[idx].SetActive(true);
			m_divaDecos[idx].Change(info.friend.JIGONEMPPNP_Diva, info.friend, info.isFavorite, DisplayType.Level);
			m_sceneDecos[idx].SetActive(true);
			m_sceneDecos[idx].Change(info.friend.AFBMEMCHJCL_MainScene, DisplayType.Level);
		}

		// // RVA: 0x128E7C4 Offset: 0x128E7C4 VA: 0x128E7C4
		private void InitializeSortSetting()
		{
			m_sortType = (SortItem) sortSaveData.LHPDCGNKPHD_sortItem;
			m_sortOrder = (GeneralList.SortOrder) sortSaveData.EILKGEADKGH_order;
			m_rarityFilter = (uint)sortSaveData.ACCHOFLOOEC_filter;
			m_attrFilter = (uint)sortSaveData.BOFFOHHLLFG_attributeFilter;
			m_seriesFilter = (uint)sortSaveData.BBIIHLNBHDE_seriaseFilter;
			m_buttonRuntime.ChangePreset(GeneralListButtonRuntime.Preset.FriendList);
			OnChangeSortOrder();
			OnChangeSortType();
		}

		// // RVA: 0x128FF78 Offset: 0x128FF78 VA: 0x128FF78
		private void OnClickOrderButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_sortOrder = m_sortOrder == GeneralList.SortOrder.Ascend ? GeneralList.SortOrder.Descend : GeneralList.SortOrder.Ascend;
			OnChangeSortOrder();
			SortGuestList();
		}

		// // RVA: 0x128FE1C Offset: 0x128FE1C VA: 0x128FE1C
		private void OnChangeSortOrder()
		{
			m_buttonRuntime.SetSortOrder(m_sortOrder);
		}

		// // RVA: 0x128FFF8 Offset: 0x128FFF8 VA: 0x128FFF8
		private void OnClickSortButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowSortWindow(sortPlace, m_sortType, (PopupSortMenu popup) =>
			{
				//0x1290BD0
				m_sortType = popup.SortItem;
				m_rarityFilter = popup.GetRarityFilter();
				m_attrFilter = popup.GetAttributeFilter();
				m_seriesFilter = popup.GetSeriaseFilter();
				OnChangeSortType();
				SortGuestList();
			}, null);
		}

		// // RVA: 0x128FE50 Offset: 0x128FE50 VA: 0x128FE50
		private void OnChangeSortType()
		{
			m_buttonRuntime.SetSortType(m_sortType);
			SortItem sortBy = m_sortType;
			if(sortBy == SortItem.Rarity || 
				sortBy == SortItem.Level || 
					sortBy == SortItem.PlayerRunk || 
						sortBy == SortItem.MainCannnonPower || 
							sortBy == SortItem.Fan) // 0xc0020060U 5/6/17/30/31
				sortBy = defaultSortType;
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetParamTable(sortBy);
			}
		}

		// // RVA: 0x129014C Offset: 0x129014C VA: 0x129014C
		private int SortDelegate(MemberListInfo a, MemberListInfo b)
		{
			int res = 0;
			switch(m_sortType)
			{
				case SortItem.Total:
					res = a.total.CompareTo(b.total);
					break;
				case SortItem.Soul:
					res = a.soul.CompareTo(b.soul);
					break;
				case SortItem.Voice:
					res = a.voice.CompareTo(b.voice);
					break;
				case SortItem.Charm:
					res = a.charm.CompareTo(b.charm);
					break;
				default:
					break;
				case SortItem.Rarity:
					res = a.sceneRarity.CompareTo(b.sceneRarity);
					break;
				case SortItem.Level:
					res = a.sceneLevel.CompareTo(b.sceneLevel);
					break;
				case SortItem.Life:
					res = a.life.CompareTo(b.life);
					break;
				case SortItem.Luck:
					res = a.luck.CompareTo(b.luck);
					break;
				case SortItem.Support:
					res = a.support.CompareTo(b.support);
					break;
				case SortItem.Fold:
					res = a.fold.CompareTo(b.fold);
					break;
				case SortItem.LastPlayDate:
					res = a.lastLogin.CompareTo(b.lastLogin);
					break;
				case SortItem.PlayerRunk:
					res = a.playerRank.CompareTo(b.playerRank);
					break;
				case SortItem.HighScoreRating:
					res = a.musicRatio.CompareTo(b.musicRatio);
					break;
				case SortItem.MainCannnonPower:
					res = a.mcannonPower.CompareTo(b.mcannonPower);
					break;
				case SortItem.Fan:
					res = a.funCount.CompareTo(b.funCount);
					break;
			}
			if(res == 0)
			{
				res = GetBaseRaritySortValue(a, b);
				if(res == 0)
				{
					res = b.sceneId.CompareTo(a.sceneId);
					if(res == 0)
					{
						res = b.sceneLevel.CompareTo(a.sceneLevel);
						if(res == 0)
							res = a.ListIndex.CompareTo(b.ListIndex);
					}
					return res;
				}
			}
			if(m_sortOrder == GeneralList.SortOrder.Descend)
				res = -res;
			return res;
		}

		// // RVA: 0x1290588 Offset: 0x1290588 VA: 0x1290588
		private int GetBaseRaritySortValue(MemberListInfo a, MemberListInfo b)
		{
			int v1 = a.friend.AFBMEMCHJCL_MainScene != null ? a.friend.AFBMEMCHJCL_MainScene.JKGFBFPIMGA_Rarity : 0;
			int v2 = b.friend.AFBMEMCHJCL_MainScene != null ? b.friend.AFBMEMCHJCL_MainScene.JKGFBFPIMGA_Rarity : 0;
			int res = v1.CompareTo(v2);
			if(res == 0)
			{
				v1 = a.friend.AFBMEMCHJCL_MainScene != null ? a.friend.AFBMEMCHJCL_MainScene.KELFCMEOPPM_EpisodeId : 0;
				v2 = b.friend.AFBMEMCHJCL_MainScene != null ? b.friend.AFBMEMCHJCL_MainScene.KELFCMEOPPM_EpisodeId : 0;
				res = v1.CompareTo(v2);
			}
			return res;
		}

		// // RVA: 0x1290718 Offset: 0x1290718 VA: 0x1290718
		private void IconAnimUpdate()
		{
			if(m_divaDecos != null)
			{
				int f = animParam.UpdateFrame(Time.deltaTime);
				for(int i = 0; i < m_divaDecos.Count; i++)
				{
					m_divaDecos[i].FadeFrienFanAnimationSetFrame(f);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB834 Offset: 0x6EB834 VA: 0x6EB834
		// // RVA: 0x128D3E0 Offset: 0x128D3E0 VA: 0x128D3E0
		private IEnumerator Co_LoadResources()
		{
			//0x12923CC
			yield return Co.R(Co_LoadLayout());
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EB8AC Offset: 0x6EB8AC VA: 0x6EB8AC
		// // RVA: 0x1290840 Offset: 0x1290840 VA: 0x1290840
		private IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x18
			FontInfo systemFont; // 0x1C
			int bundleLoadCount; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			int poolSize; // 0x28
			int i; // 0x2C

			//0x1291864
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/039.xab");
			bundleLoadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GuestListWindow");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1291304
				instance.transform.SetParent(transform, false);
				m_windowUi = instance.GetComponent<GuestListWindow>();
				m_scrollList = instance.GetComponentInChildren<SwapScrollList>(true);
				m_windowUi.SetCounterStyle(GuestListWindow.CounterStyle.Count);
			}));
			bundleLoadCount++;
			poolSize = m_scrollList.ScrollObjectCount;
			operation = AssetBundleManager.LoadLayoutAsync("ly/203.xab", "root_sel_lobby_list_01_layout_root");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1291480
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format("GuestListElem {0:D2}", 0);
				m_scrollList.AddScrollObject(instance.GetComponent<SwapScrollListContent>());
				m_elems.Add(instance.GetComponent<MembersListElem>());
			}));
			bundleLoadCount++;
			for(i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format("GuestListElem {0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_scrollList.AddScrollObject(r.GetComponent<SwapScrollListContent>());
				m_elems.Add(r.GetComponent<MembersListElem>());
			}
			for(i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			while(!m_windowUi.IsLoaded())
				yield return null;
			for(i = 0; i < m_elems.Count; i++)
			{
				while(!m_elems[i].IsLoaded())
					yield return null;
			}
			bundleName.Set("ly/039.xab");
			bundleLoadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GeneralListButton");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x129163C
				instance.transform.SetParent(transform, false);
				m_buttonRuntime = instance.GetComponent<GeneralListButtonRuntime>();
				m_buttonRuntime.ChangePreset(GeneralListButtonRuntime.Preset.FriendList);
				m_buttonRuntime.onClickSortButton = OnClickSortButton;
				m_buttonRuntime.onClickOrderButton = OnClickOrderButton;
			}));
			bundleLoadCount++;
			for(i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
		}
	}
}
