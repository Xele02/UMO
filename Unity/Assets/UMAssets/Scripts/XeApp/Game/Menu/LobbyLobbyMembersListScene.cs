using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LobbyLobbyMembersListScene : TransitionRoot
	{
		private LobbyMembersListWindow m_lobbyMenberWindow; // 0x48
		private SwapScrollList m_scrollList; // 0x4C
		private List<MembersListElem> m_elems = new List<MembersListElem>(); // 0x50
		private List<EAJCBFGKKFA_FriendInfo> friends = new List<EAJCBFGKKFA_FriendInfo>(100); // 0x54
		protected List<DivaIconDecoration> m_divaDecos = new List<DivaIconDecoration>(); // 0x58
		protected List<SceneIconDecoration> m_sceneDecos = new List<SceneIconDecoration>(); // 0x5C
		private List<MemberListInfo> m_guestInfoAllList = new List<MemberListInfo>(); // 0x60
		private List<MemberListInfo> m_guestInfoList = new List<MemberListInfo>(); // 0x64
		private int m_myId; // 0x68
		private bool m_isInitialized; // 0x6C
		private bool m_isInitializeMemerList; // 0x6D
		private string m_groupName = ""; // 0x70
		private GeneralListButtonRuntime m_buttonRuntime; // 0x74
		private GeneralList.SortOrder m_sortOrder; // 0x78
		private PopupSortMenu.SortPlace sortPlace = PopupSortMenu.SortPlace.LobbyMemberList; // 0x7C
		private SortItem m_sortType; // 0x80
		private SortItem defaultSortType = SortItem.LastPlayDate; // 0x84
		private uint m_rarityFilter; // 0x88
		private uint m_attrFilter; // 0x8C
		private uint m_seriesFilter; // 0x90
		private int m_favoritCount; // 0x94
		private bool m_isDeco = true; // 0x98
		private Action m_updater; // 0x9C
		private CompatibleLayoutAnimeParam animParam; // 0xA0

		public ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MMALELPFEBH_UserList sortSaveData { get { return GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.ACCNCHJBDHM_UserList; } } //0x129997C

		// RVA: 0x1299A64 Offset: 0x1299A64 VA: 0x1299A64 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			animParam = new CompatibleLayoutAnimeParam();
			animParam.Initialize(DivaIconDecoration.FriendFanFadeAnimStartFrame, DivaIconDecoration.FriendFanFadeAnimEndFrame);
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0x1299BD8 Offset: 0x1299BD8 VA: 0x1299BD8
		private void Update()
		{
			if(m_updater != null)
				m_updater();
		}

		// // RVA: 0x1299BEC Offset: 0x1299BEC VA: 0x1299BEC
		// private void IconUpdater() { }

		// RVA: 0x1299CF4 Offset: 0x1299CF4 VA: 0x1299CF4 Slot: 16
		protected override void OnPreSetCanvas()
		{
			m_myId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
			InitializeSortSetting();
			base.OnPreSetCanvas();
			m_buttonRuntime.Hide();
			m_isDeco = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("deco_player_level", 0) != 0;
			this.StartCoroutineWatched(Co_Initialize());
			m_favoritCount = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GAAOPEGIPKA_FavoritePlayer.EFNAAHDHCEL();
			m_updater = () =>
			{
				//0x129E4E4
				if(m_divaDecos != null)
				{
					int t = animParam.UpdateFrame(Time.deltaTime);
					for(int i = 0; i < m_divaDecos.Count; i++)
					{
						m_divaDecos[i].FadeFrienFanAnimationSetFrame(t);
					}
				}
			};
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EA53C Offset: 0x6EA53C VA: 0x6EA53C
		// // RVA: 0x129A044 Offset: 0x129A044 VA: 0x129A044
		private IEnumerator Co_Initialize()
		{
			//0x129FDB8
			m_isInitialized = false;
			m_isInitializeMemerList = false;
			m_lobbyMenberWindow.Leave();
			this.StartCoroutineWatched(Initialize());
			InitializeList();
			yield break;
		}

		// RVA: 0x129A0F0 Offset: 0x129A0F0 VA: 0x129A0F0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !m_buttonRuntime.IsPlaying() && !m_lobbyMenberWindow.GetIsPlaying() && m_isInitialized && m_isInitializeMemerList;
		}

		// RVA: 0x129A174 Offset: 0x129A174 VA: 0x129A174 Slot: 18
		protected override void OnPostSetCanvas()
		{
			m_buttonRuntime.transform.SetAsLastSibling();
		}

		// RVA: 0x129A1C0 Offset: 0x129A1C0 VA: 0x129A1C0 Slot: 23
		protected override void OnActivateScene()
		{
			base.OnActivateScene();
		}

		// RVA: 0x129A1C8 Offset: 0x129A1C8 VA: 0x129A1C8 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return true;
		}

		// RVA: 0x129A1D0 Offset: 0x129A1D0 VA: 0x129A1D0 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			m_buttonRuntime.Enter();
			m_lobbyMenberWindow.Enter();
		}

		// RVA: 0x129A220 Offset: 0x129A220 VA: 0x129A220 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return base.IsEndEnterAnimation();
		}

		// RVA: 0x129A228 Offset: 0x129A228 VA: 0x129A228 Slot: 12
		protected override void OnStartExitAnimation()
		{
			m_buttonRuntime.Leave();
			m_lobbyMenberWindow.Leave();
		}

		// RVA: 0x129A278 Offset: 0x129A278 VA: 0x129A278 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_buttonRuntime.IsPlaying();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EA5B4 Offset: 0x6EA5B4 VA: 0x6EA5B4
		// // RVA: 0x129A2A8 Offset: 0x129A2A8 VA: 0x129A2A8
		// private IEnumerator Co_UpdateFanRegist() { }

		// RVA: 0x129A33C Offset: 0x129A33C VA: 0x129A33C Slot: 7
		protected override void OnDisable()
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

		// RVA: 0x129A4E4 Offset: 0x129A4E4 VA: 0x129A4E4 Slot: 15
		protected override void OnDeleteCache()
		{
			base.OnDestoryScene();
		}

		// RVA: 0x129A4EC Offset: 0x129A4EC VA: 0x129A4EC Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			m_updater = null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EA62C Offset: 0x6EA62C VA: 0x6EA62C
		// // RVA: 0x1299B4C Offset: 0x1299B4C VA: 0x1299B4C
		private IEnumerator Co_LoadResources()
		{
			//0x12A0A4C
			yield return Co.R(Co_LoadLayOutData());
			IsReady = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EA6A4 Offset: 0x6EA6A4 VA: 0x6EA6A4
		// // RVA: 0x129A52C Offset: 0x129A52C VA: 0x129A52C
		private IEnumerator Co_LoadLayOutData()
		{
			StringBuilder bundleName; // 0x18
			FontInfo systemFont; // 0x1C
			int bundleLoadCount; // 0x20
			AssetBundleLoadLayoutOperationBase operation; // 0x24
			int poolSize; // 0x28

			//0x129FF00
			bundleName = new StringBuilder(64);
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/203.xab");
			bundleLoadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_list_win_01_layout_root");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x129EA54
				instance.transform.SetParent(transform, false);
				m_lobbyMenberWindow = instance.GetComponent<LobbyMembersListWindow>();
				m_scrollList = instance.GetComponentInChildren<SwapScrollList>();
			}));
			bundleLoadCount++;
			poolSize = m_scrollList.ScrollObjectCount;
			Debug.Log(" **** poolSize *** = "+poolSize);
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_lobby_list_01_layout_root");
			yield return operation;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x129EB94
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format("MemberListElem {0:D2}", 0);
				m_scrollList.AddScrollObject(baseRuntime.GetComponent<SwapScrollListContent>());
				m_elems.Add(instance.GetComponent<MembersListElem>());
			}));
			bundleLoadCount++;
			for(int i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format("MemberListElem {0:D2}", i + 1);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_scrollList.AddScrollObject(r.GetComponent<SwapScrollListContent>());
				m_elems.Add(r.GetComponent<MembersListElem>());
			}
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_scrollList.Apply();
			m_scrollList.SetContentEscapeMode(true);
			while(!m_lobbyMenberWindow.IsLoaded())
				yield return null;
			bundleName.Set("ly/039.xab");
			bundleLoadCount = 0;
			operation = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_GeneralListButton");
			yield return operation;
			yield return Co.R(operation.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x129ED50
				instance.transform.SetParent(transform, false);
				m_buttonRuntime = instance.GetComponent<GeneralListButtonRuntime>();
				m_buttonRuntime.ChangePreset(GeneralListButtonRuntime.Preset.FriendList);
				m_buttonRuntime.onClickSortButton = OnClickSortButton;
				m_buttonRuntime.onClickOrderButton = OnClickOrderButton;
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EA71C Offset: 0x6EA71C VA: 0x6EA71C
		// // RVA: 0x129A5D8 Offset: 0x129A5D8 VA: 0x129A5D8
		private IEnumerator Initialize()
		{
			//0x12A1018
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_elems[i].SetButtonAnimaiton(MembersListElem.ButtonType.Guest, true);
			}
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
			if(PrevTransition != TransitionList.Type.TEAM_SELECT && PrevTransition != TransitionList.Type.PROFIL && PrevTransition != TransitionList.Type.DECO_VISIT_LIST)
			{
				m_scrollList.SetItemCount(0);
				m_scrollList.VisibleRegionUpdate();
			}
			InitializeDecos();
			m_isInitialized = true;
			yield return null;
		}

		// // RVA: 0x129A684 Offset: 0x129A684 VA: 0x129A684
		private void InitializeList()
		{
			m_lobbyMenberWindow.SetWindowGroupName(GetGroupName());
			if(PrevTransition != TransitionList.Type.TEAM_SELECT && PrevTransition != TransitionList.Type.PROFIL && PrevTransition != TransitionList.Type.DECO_VISIT_LIST)
			{
				m_scrollList.SetItemCount(0);
			}
			m_scrollList.VisibleRegionUpdate();
			FindMemberList();
		}

		// // RVA: 0x129AA88 Offset: 0x129AA88 VA: 0x129AA88
		// private bool CheckTransitByReturn() { }

		// // RVA: 0x129AAC0 Offset: 0x129AAC0 VA: 0x129AAC0
		private void FindMemberList()
		{
			NKOBMDPHNGP_EventRaidLobby cont = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			MenuScene.Instance.InputDisable();
			friends.Clear();
			cont.IIBLJMMGMPD(() =>
			{
				//0x129EF74
				UpdateListCounter(cont.ACCNCHJBDHM_Users.Count);
				for(int i = 0; i < cont.ACCNCHJBDHM_Users.Count; i++)
				{
					EAJCBFGKKFA_FriendInfo f = new EAJCBFGKKFA_FriendInfo();
					f.KHEKNNFCAOI(cont.ACCNCHJBDHM_Users[i]);
					friends.Add(f);
				}
				this.StartCoroutineWatched(OnSuccessSearchFriend());
			}, () =>
			{
				//0x129F29C
				Debug.LogError("StringLiteral_18344");
				if(!MenuScene.Instance.IsTransition())
				{
					MenuScene.Instance.GotoTitle();
				}
				else
				{
					GotoTitle();
					m_isInitializeMemerList = true;
				}
			});
		}

		// // RVA: 0x129A814 Offset: 0x129A814 VA: 0x129A814
		private string GetGroupName()
		{
			NKOBMDPHNGP_EventRaidLobby ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			return ev.OFAKIAJNPDF(ev.HJJBDFCMJJM()) + JpStringLiterals.StringLiteral_367 + string.Format(bk.GetMessageByLabel("lobby_room_num_format"), ev.GAHICKBDHFO());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EA794 Offset: 0x6EA794 VA: 0x6EA794
		// // RVA: 0x129AE10 Offset: 0x129AE10 VA: 0x129AE10
		private IEnumerator OnSuccessSearchFriend()
		{
			//0x12A1440
			m_guestInfoAllList.Clear();
			for(int i = 0; i < friends.Count; i++)
			{
				MemberListInfo m = new MemberListInfo((short)i, true, friends[i]);
				m_guestInfoAllList.Add(m);
				m.TryInstall();
			}
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			SortGuestList();
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0x129AEBC Offset: 0x129AEBC VA: 0x129AEBC
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
				//0x129E4E8
				OnUpdateListItem(index, content as MembersListContent, m_guestInfoList[index]);
			});
			m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
			m_isInitializeMemerList = true;
		}

		// // RVA: 0x129B34C Offset: 0x129B34C VA: 0x129B34C
		private void OnUpdateListItem(int index, MembersListContent content, MemberListInfo info)
		{
			MembersListElem m = content.GetElemUI<MembersListElem>();
			m.SetName(info.name);
			m.SetLoginDate(info.login);
			m.SetComment(info.comment);
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
			m.UpdateLayoutAnimation();
			if(info.playerId == m_myId)
			{
				m.SetButtonAnimaiton(MembersListElem.ButtonType.Me, m_isDeco);
			}
			else
			{
				if(info.isFavorite)
					m.SetButtonAnimaiton(MembersListElem.ButtonType.Fan, m_isDeco);
				else
					m.SetButtonAnimaiton(MembersListElem.ButtonType.Guest, m_isDeco);
			}
			m.SetDivaIconDelegate(info.GetGuestDivaIconTex);
			m.SetSceneIconDelegate(info.GetGuestSceneIconTex);
			m.SetKira(info.isKira);
			int idx = m_elems.IndexOf(m);
			m_divaDecos[idx].SetActive(true);
			m_divaDecos[idx].Change(info.friend.JIGONEMPPNP_Diva, info.friend, info.isFavorite, DisplayType.Level);
			m_sceneDecos[idx].SetActive(true);
			m_sceneDecos[idx].Change(info.friend.AFBMEMCHJCL_MainScene, DisplayType.Level);
		}

		// // RVA: 0x129BAD8 Offset: 0x129BAD8 VA: 0x129BAD8
		private void OnSelectListItem(int value, SwapScrollListContent content)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			switch(value)
			{
				case 0:
					OnMemberFunEnetry(content.Index);
					break;
				case 1:
					OnMemberFunFunVisit(content.Index);
					break;
				case 2:
					OnMemberFunFunCancel(content.Index);
					break;
				case 3:
					JumpToProfile(content.Index);
					break;
				default:
					break;
			}
		}

		// // RVA: 0x129BE34 Offset: 0x129BE34 VA: 0x129BE34
		private void OnMemberFunEnetry(int elemIndex)
		{
			if(m_favoritCount < PIGBKEIAMPE_FriendManager.DJHFILDBOFG_GetMaxFanPossible())
				FanRegister(elemIndex);
			else
				FanRegisterLimit();
		}

		// // RVA: 0x129C890 Offset: 0x129C890 VA: 0x129C890
		private void FanRegisterLimit()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_lobby_member_fan_capacityover_title");
			s.Text = bk.GetMessageByLabel("pop_lobby_member_capacityover_desc");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0x129E75C
				return;
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x129C464 Offset: 0x129C464 VA: 0x129C464
		private void FanRegister(int index)
		{
			int select = 0;
			MenuScene.Instance.InputDisable();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_lobby_member_fanregister_title");
			s.Text = string.Format(bk.GetMessageByLabel("pop_lobby_member_fanregister_desc"), m_guestInfoList[index].name);
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0x129F41C
				if(t == PopupButton.ButtonType.Negative)
				{
					MenuScene.Instance.InputEnable();
				}
				else if(t == PopupButton.ButtonType.Positive)
				{
					NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
					for(int i = 0; i < friends.Count; i++)
					{
						if(i == index)
						{
							select = i;
							FanIncrement(i);
							break;
						}
					}
					evLobby.KCAJBLICFPJ(() =>
					{
						//0x129F738
						MenuScene.Instance.InputEnable();
						m_scrollList.VisibleRegionUpdate();
					}, () =>
					{
						//0x129E760
						MenuScene.Instance.GotoTitle();
					});
				}
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x129C1FC Offset: 0x129C1FC VA: 0x129C1FC
		private void OnMemberFunFunCancel(int elemIndex)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			FanUnregister(elemIndex);
		}

		// // RVA: 0x129CBEC Offset: 0x129CBEC VA: 0x129CBEC
		private void FanUnregister(int index)
		{
			MenuScene.Instance.InputDisable();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = bk.GetMessageByLabel("pop_lobby_member_fan_unregister_title");
			s.Text = string.Format(bk.GetMessageByLabel("pop_lobby_member_fan_unregister_desc"), m_guestInfoList[index].name);
			s.Buttons = new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			PopupWindowManager.Show(s, (PopupWindowControl c, PopupButton.ButtonType t, PopupButton.ButtonLabel l) =>
			{
				//0x129F80C
				if(t == PopupButton.ButtonType.Negative)
				{
					MenuScene.Instance.InputEnable();
				}
				else if(t == PopupButton.ButtonType.Positive)
				{
					int select = 0;
					NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
					for(int i = 0; i < friends.Count; i++)
					{
						if(i == index)
						{
							select = i;
							FanDecrement(i);
							break;
						}
					}
					evLobby.KCAJBLICFPJ(() =>
					{
						//0x129FB28
						MenuScene.Instance.InputEnable();
						m_scrollList.VisibleRegionUpdate();
					}, () =>
					{
						//0x129E7FC
						MenuScene.Instance.GotoTitle();
					});
				}
			}, null, null, null, true, true, false);
		}

		// // RVA: 0x129D020 Offset: 0x129D020 VA: 0x129D020
		private void FanIncrement(int select)
		{
			m_guestInfoList[select].isFavorite = true;
			NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			NKOBMDPHNGP_EventRaidLobby.ELKMKCNPDFO f = evLobby.ACCNCHJBDHM_Users.Find((NKOBMDPHNGP_EventRaidLobby.ELKMKCNPDFO data) =>
			{
				//0x129FBFC
				return m_guestInfoList[select].playerId == data.MLPEHNBNOGD_Id;
			});
			if(f != null)
			{
				f.BBNAEPGAMMA_IsFavorite = true;
				f.AGDBNNEAIIC_FanNum ++;
				m_favoritCount++;
			}
		}

		// // RVA: 0x129D350 Offset: 0x129D350 VA: 0x129D350
		private void FanDecrement(int select)
		{
			m_guestInfoList[select].isFavorite = false;
			NKOBMDPHNGP_EventRaidLobby evLobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			NKOBMDPHNGP_EventRaidLobby.ELKMKCNPDFO f = evLobby.ACCNCHJBDHM_Users.Find((NKOBMDPHNGP_EventRaidLobby.ELKMKCNPDFO data) =>
			{
				//0x129FCD8
				return m_guestInfoList[select].playerId == data.MLPEHNBNOGD_Id;
			});
			if(f != null)
			{
				f.BBNAEPGAMMA_IsFavorite = false;
				f.AGDBNNEAIIC_FanNum--;
				m_favoritCount--;
			}
		}

		// // RVA: 0x129BED8 Offset: 0x129BED8 VA: 0x129BED8
		private void OnMemberFunFunVisit(int elemIndex)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			VisitDecoSceneArgs arg = new VisitDecoSceneArgs();
			arg.friendData = m_guestInfoList[elemIndex].friend;
			ILCCJNDFFOB.HHCJCDFCLOB.CLGHLKLHEAK("StringLiteral_18383", arg.friendData.MLPEHNBNOGD_Id);
			ILCCJNDFFOB.HHCJCDFCLOB.PFBIHCIFFKM(arg.friendData.MLPEHNBNOGD_Id, CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.PDEACDHIJJJ_IsFriend(arg.friendData.MLPEHNBNOGD_Id), true, 0);
			DecoVisitScene.transitionType = DecoVisitScene.TransitionType.None;
			MenuScene.Instance.Mount(TransitionUniqueId.DECO_DECOVISIT, arg, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0x129C268 Offset: 0x129C268 VA: 0x129C268
		private void JumpToProfile(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			ProfilDateArgs arg = new ProfilDateArgs();
			arg.data = m_guestInfoList[index].friend;
			arg.infoType = ProfilMenuLayout.InfoType.PLAYER;
			arg.btnType = m_guestInfoList[index].playerId == m_myId ? ProfilMenuLayout.ButtonType.None : ProfilMenuLayout.ButtonType.Fan_NoLobby;
			MenuScene.Instance.Call(TransitionList.Type.PROFIL, arg, true);
		}

		// // RVA: 0x129D680 Offset: 0x129D680 VA: 0x129D680
		private void UpdateListCounter(int _mnberNum)
		{
			StringBuilder str = new StringBuilder(32);
			str.SetFormat("{0}", _mnberNum);
			m_lobbyMenberWindow.SetMemberListCount(str.ToString());
		}

		// // RVA: 0x129D784 Offset: 0x129D784 VA: 0x129D784
		private void InitializeDecos()
		{
			m_divaDecos.Capacity = m_elems.Count;
			m_sceneDecos.Capacity = m_elems.Count;
			for(int i = 0; i < m_elems.Count; i++)
			{
				m_divaDecos.Add(new DivaIconDecoration(m_elems[i].GetDivaIconObject(), DivaIconDecoration.Size.S, true, true, null, null));
				m_sceneDecos.Add(new SceneIconDecoration(m_elems[i].GetSceneIconObject(), SceneIconDecoration.Size.M, null, null));
			}
		}

		// // RVA: 0x129A340 Offset: 0x129A340 VA: 0x129A340
		// private void ReleaseDecos() { }

		// // RVA: 0x1299F6C Offset: 0x1299F6C VA: 0x1299F6C
		private void InitializeSortSetting()
		{
			m_sortType = (SortItem) sortSaveData.LHPDCGNKPHD_sortItem;
			m_sortOrder = (GeneralList.SortOrder) sortSaveData.EILKGEADKGH_order;
			m_rarityFilter = (uint) sortSaveData.ACCHOFLOOEC_filter;
			m_attrFilter = (uint)sortSaveData.BOFFOHHLLFG_attributeFilter;
			m_seriesFilter = (uint)sortSaveData.BBIIHLNBHDE_seriaseFilter;
			m_buttonRuntime.ChangePreset(GeneralListButtonRuntime.Preset.FriendList);
			OnChangeSortType();
			OnChangeSortOrder();
		}

		// // RVA: 0x129DBA0 Offset: 0x129DBA0 VA: 0x129DBA0
		private void OnClickOrderButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_sortOrder = m_sortOrder == GeneralList.SortOrder.Ascend ? GeneralList.SortOrder.Descend : GeneralList.SortOrder.Ascend;
			OnChangeSortOrder();
			SortGuestList();
		}

		// // RVA: 0x129DB6C Offset: 0x129DB6C VA: 0x129DB6C
		private void OnChangeSortOrder()
		{
			m_buttonRuntime.SetSortOrder(m_sortOrder);
		}

		// // RVA: 0x129DC20 Offset: 0x129DC20 VA: 0x129DC20
		private void OnClickSortButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			MenuScene.Instance.ShowSortWindow(sortPlace, m_sortType, (PopupSortMenu popup) =>
			{
				//0x129E620
				m_sortType = popup.SortItem;
				m_rarityFilter = popup.GetRarityFilter();
				m_attrFilter = popup.GetAttributeFilter();
				m_seriesFilter = popup.GetSeriaseFilter();
				OnChangeSortType();
				SortGuestList();
			}, null);
		}

		// // RVA: 0x129DA44 Offset: 0x129DA44 VA: 0x129DA44
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

		// // RVA: 0x129DD74 Offset: 0x129DD74 VA: 0x129DD74
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

		// // RVA: 0x129E1B0 Offset: 0x129E1B0 VA: 0x129E1B0
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
	}
}
