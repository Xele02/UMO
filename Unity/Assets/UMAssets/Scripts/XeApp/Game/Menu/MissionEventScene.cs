using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MissionEventMusicSelectButton : PlayButtonWrapper
	{
		public override MusicSelectCDSelect baseUI { get; protected set; } // 0x8

		// RVA: 0xB426F8 Offset: 0xB426F8 VA: 0xB426F8
		public MissionEventMusicSelectButton(MusicSelectCDSelect ui)
		{
			baseUI = ui;
		}

		// RVA: 0xB4272C Offset: 0xB4272C VA: 0xB4272C Slot: 6
		public override void Enter(bool immediate/* = False*/)
		{
			baseUI.EnterPlayButton(immediate);
		}

		// RVA: 0xB42770 Offset: 0xB42770 VA: 0xB42770 Slot: 7
		public override void Leave(bool immediate/* = False*/)
		{
			baseUI.LeavePlayButton(immediate);
		}

		// RVA: 0xB427B4 Offset: 0xB427B4 VA: 0xB427B4 Slot: 8
		public override void SetDisable(bool disable)
		{
			baseUI.SetPlayButtonDisable(disable);
		}

		// RVA: 0xB427F8 Offset: 0xB427F8 VA: 0xB427F8 Slot: 9
		public override void SetType(Type type)
		{
			baseUI.SetPlayButtonType(type != Type.Download ? MusicSelectCDSelect.PlayButtonType.Ok : MusicSelectCDSelect.PlayButtonType.Download);
		}

		// RVA: 0xB42844 Offset: 0xB42844 VA: 0xB42844 Slot: 10
		public override void SetNeedEnergy(int en)
		{
			baseUI.SetNeedEnergy(en);
		}
	}

	public class MissionEventScene : MusicSelectSceneBase
	{
		private enum Step
		{
			None = 0,
			MissionSelect = 1,
			MissionConfirm = 2,
			SelectMusicList = 3,
			EndEventHome = 4,
		}

		private const int EVENT_POINT_MAX = 99999999;
		private MusicSelectSeriesInfo m_seriesInfo; // 0xF8
		private MusicSelectEventInfo m_eventInfo; // 0xFC
		private EventTimeLimitMessage m_timeLimitMessage; // 0x100
		private LayoutQuestEvent2MissionSelect m_LayoutMissonSelect; // 0x104
		private LayoutQuestEvent2EventBtn m_LayoutEventSettingBtn; // 0x108
		private MusicSelectLineButton m_lineButton; // 0x10C
		private MusicSelectBonusButton m_bonusButton; // 0x110
		private MusicSelectMusicFilterButton m_filterButton; // 0x114
		private LayoutQuestPopupMissionSettingSetting m_popMissionSetting = new LayoutQuestPopupMissionSettingSetting(); // 0x118
		private PopupMissionMusicChangeAlertSetting m_popMusicChangeAlertSetting = new PopupMissionMusicChangeAlertSetting(); // 0x11C
		private IAFDICLEOPF m_missionSetData = new IAFDICLEOPF(); // 0x120
		private StringBuilder m_strBuilder = new StringBuilder(128); // 0x124
		private Step m_showingStep; // 0x128
		private Step m_currentStep; // 0x12C
		private int m_selectedCardIndex; // 0x130
		private bool m_isEventChecked; // 0x134
		private Step m_cambackRankingStep; // 0x138
		private List<MusicDataList> m_originalMusicDataList = new List<MusicDataList>(5); // 0x13C
		private List<MusicDataList> m_filteredMusicDataList = new List<MusicDataList>(5); // 0x140

		public int categoryId { get; set; } // 0x144
		protected override int musicListCount { get { return m_filteredMusicDataList.Count; } } //0xB42898
		protected override MusicDataList currentMusicList { get { return m_filteredMusicDataList[categoryId - 1]; } } //0xB42990

		// // RVA: 0xB42910 Offset: 0xB42910 VA: 0xB42910 Slot: 32
		protected override MusicDataList GetMusicList(int i)
		{
			return m_filteredMusicDataList[i];
		}

		// // RVA: 0xB42A10 Offset: 0xB42A10 VA: 0xB42A10 Slot: 35
		protected override void CheckTryInstall()
		{
			return;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2144 Offset: 0x6F2144 VA: 0x6F2144
		// // RVA: 0xB42A14 Offset: 0xB42A14 VA: 0xB42A14 Slot: 36
		protected override IEnumerator Co_Initialize()
		{
			//0x103ACA4
			if(m_isEventTimeLimit || IsRequestGotoTitle)
			{
				m_isInitialized = true;
				yield break;
			}
			m_isInitialized = false;
			bool done = false;
			bool err = false;
			m_eventCtrl.ADACMHAHHKC_PreSetupEventHome(() =>
			{
				//0x10382EC
				done = true;
			}, () =>
			{
				//0x10382F8
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(!err)
			{
				done = false;
				err = false;
				JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LFOBIPKFOEF(OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventMission, 0, () =>
				{
					//0x1038304
					done = true;
				}, () =>
				{
					//0x1038310
					done = true;
					err = true;
				}, false);
				while(!done)
					yield return null;
				if(!err)
				{
					done = false;
					err= false;
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0x103831C
						done = true;
					}, () =>
					{
						//0x1038328
						done = true;
						err = true;
					}, null);
					while(!done)
						yield return null;
					if(!err)
					{
						KPJHLACKGJF_EventMission ev = m_eventCtrl as KPJHLACKGJF_EventMission;
						if(IsEventEndChallengePeriod)
						{
							if(m_missionSetData.GAAHOOBMDEE_Missions != null)
							{
								m_missionSetData.GAAHOOBMDEE_Missions.Clear();
							}
						}
						else
						{
							m_missionSetData.KHEKNNFCAOI(ev);
						}
						CrateQuestList();
						CreateSnsList();
						SetupHelp();
						ApplyFilterButtonStatus();
						m_isListEmptyByFilter = false;
						m_cdSelect.transform.SetAsLastSibling();
						m_cdArrow.transform.SetAsLastSibling();
						m_musicInfo.transform.SetAsLastSibling();
						m_buttonSet.transform.SetAsLastSibling();
						m_eventBanner.transform.SetAsLastSibling();
						m_seriesInfo.transform.SetAsLastSibling();
						m_eventInfo.transform.SetAsLastSibling();
						m_musicRate.transform.SetAsLastSibling();
						m_timeLimitMessage.transform.SetAsLastSibling();
						m_lineButton.transform.SetAsLastSibling();
						m_filterButton.transform.SetAsLastSibling();
						m_cdSelect.onClickFlowButton = OnClickFlowButton;
						m_cdSelect.onSelectionChanged = OnSelectionChanged;
						m_cdSelect.onScrollRepeated = OnScrollRepeated;
						m_cdSelect.onScrollStarted = OnScrollStarted;
						m_cdSelect.onScrollUpdated = OnScrollUpdated;
						m_cdSelect.onScrollEnded = OnScrollEnded;
						m_cdSelect.onClickPlayButton = OnClickOkButton;
						m_cdSelect.onClickEventDetailButton = OnClickEventDetailButton;
						m_buttonSet.onClickRankingButton = OnClickRankingButton;
						m_buttonSet.onClickRewardButton = OnClickRewardButton;
						m_buttonSet.onClickDetailButton = OnClickDetailButton;
						m_buttonSet.onClickEventRankingButton = OnClickEventRankingButton;
						m_buttonSet.onClickEventRewardButton = OnClickEventRewardButton;
						m_buttonSet.onClickEnemyInfoButton = OnClickEnemyInfoButton;
						m_buttonSet.onClickStoryButton = OnClickStoryButton;
						m_buttonSet.onClickMissionButton = OnClickMissionButton;
						m_seriesInfo.onChangedSeries = OnChangedSeries;
						m_lineButton.onClickButton = OnChangeLineMode;
						m_bonusButton.onClickButton = OnClickEventBonusButton;
						m_filterButton.OnClickButtonListener = OnClickMusicFilterButton;
						m_LayoutMissonSelect.PushPlayButtonListener += OnClickPlayButton;
						m_LayoutMissonSelect.PushEventInfoButtonListner += OnClickEventDetailButton;
						m_LayoutMissonSelect.PushMusicChangeButtonListner += OnChangeMusic;
						m_LayoutMissonSelect.SelectedMissionListener += SelectedMission;
						m_LayoutMissonSelect.PushReturnMissionListner += ReturnMissionSelect;
						m_LayoutMissonSelect.PushBoxGachaListner += GotoBoxGacha;
						m_LayoutEventSettingBtn.PushButtonListener += OnClickEventSettingButton;
						m_musicInfo.MakeCache();
						m_cdSelect.MakeCache();
						MessageBank bk = MessageManager.Instance.GetBank("menu");
						m_musicInfo.SetNoInfoMessage(bk.GetMessageByLabel("music_not_exist_text_00"), bk.GetMessageByLabel("music_not_exist_line6_text_00"));
						m_eventInfo.SetStyle(MusicSelectEventInfo.Style.Mission);
						m_eventInfo.SetTicketCountLabel(bk.GetMessageByLabel("music_event_collect_ticket_label"));
						m_eventInfo.SetCurrentValueLabel(bk.GetMessageByLabel("music_event_collect_current_point_label"));
						m_eventInfo.SetNextValueLabel(bk.GetMessageByLabel("music_event_collect_next_point_label"));
						m_eventInfo.SetValueUnitLabel(bk.GetMessageByLabel("music_event_collect_point_unit"));
						m_eventInfo.SetRewardLabel(bk.GetMessageByLabel("music_event_collect_reward_label"));
						m_eventInfo.SetRankUnitLabel(bk.GetMessageByLabel("music_event_collect_rank_unit"), 0);
						m_eventInfo.SetRankLabel(bk.GetMessageByLabel(IsEventEndChallengePeriod ? "music_event_collect_rank_counting_label" : "music_event_collect_rank_label"), 0);
						m_LayoutMissonSelect.SetMissionSetData(m_missionSetData, null, false, Difficulty.Type.Illegal);
						long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						CreateFilteredMusicDataList(m_filteredMusicDataList, m_originalMusicDataList, t, (IBJAKJJICBC m, long ct) =>
						{
							//0x10382BC
							return true;
						});
						int fmId = 0;
						if(IsEventEndChallengePeriod)
						{
							m_isLine6Mode = false;
							m_showingStep = Step.EndEventHome;
						}
						else
						{
							if(m_cambackRankingStep == Step.None)
							{
								if(ev.KCHMKLPHOEB_GetStep() >= DJDJHGJHAJA.IOPLHHNPLGM.EHPECKJANLI_2 && ev.KCHMKLPHOEB_GetStep() < DJDJHGJHAJA.IOPLHHNPLGM.NCDPEOOJEKL_5)
								{
									m_showingStep = Step.MissionSelect;
									fmId = ev.LLCOKGMCNAF();
								}
								else if(ev.KCHMKLPHOEB_GetStep() == DJDJHGJHAJA.IOPLHHNPLGM.NCDPEOOJEKL_5)
								{
									m_showingStep = Step.MissionConfirm;
									fmId = ev.IGBPFGPPJOE();
								}
							}
							else
							{
								m_showingStep = m_cambackRankingStep;
								fmId = selectMusicData.GHBPLHBNMBK_FreeMusicId;
							}
						}
						categoryId = FindCategoryId(fmId, m_isLine6Mode);
						if(categoryId > 0)
						{
							list_no = FindMusicListIndex(categoryId, fmId);
							if(m_isLine6Mode && list_no < 0)
							{
								m_isLine6Mode = false;
								list_no = FindMusicListIndex(categoryId, fmId);
							}
						}
						if(categoryId < 0 || list_no < 0)
						{
							SetDefaultCategoryAndIndex();
						}
						m_currentStep = Step.None;
						m_cambackRankingStep = Step.None;
						m_selectedCardIndex = ev.BHNEJEDEHJA_SelectedCardIdx();
						bool b = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KIKCCBMOLDM_MissionEvent.FKEJBAHCMGC_CheckEventId(m_eventId);
						diff = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KIKCCBMOLDM_MissionEvent.FFACBDAJJJP_GetDifficulty();
						if(b)
						{
							GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
						}
						ApplyBasicInfo();
						ApplyMusicListInfo();
						ApplyMusicInfo();
						ApplyEventInfo();
						Database.Instance.bonusData.SetEpisodeBonus(m_eventCtrl.LMDENICBIIB_GetEpisodesBonusList(0, 0));
						m_isInitialized = true;
						yield break;
					}
				}
			}
			m_isInitialized = true;
			GotoTitle();
		}

		// RVA: 0xB42A9C Offset: 0xB42A9C VA: 0xB42A9C Slot: 39
		protected override void Release()
		{
			m_musicInfo.ReleaseCache();
			m_cdSelect.ReleaseCache();
			m_LayoutMissonSelect.ReleaseCache();
			m_LayoutMissonSelect.PushPlayButtonListener -= OnClickPlayButton;
			m_LayoutMissonSelect.PushEventInfoButtonListner -= OnClickEventDetailButton;
			m_LayoutMissonSelect.PushMusicChangeButtonListner -= OnChangeMusic;
			m_LayoutMissonSelect.SelectedMissionListener -= SelectedMission;
			m_LayoutEventSettingBtn.PushButtonListener -= OnClickEventSettingButton;
			m_LayoutMissonSelect.PushReturnMissionListner -= ReturnMissionSelect;
			m_LayoutMissonSelect.PushBoxGachaListner -= GotoBoxGacha;
		}

		// RVA: 0xB42DD8 Offset: 0xB42DD8 VA: 0xB42DD8 Slot: 40
		protected override void SetupViewMusicData()
		{
			NKOBMDPHNGP_EventRaidLobby evRaid = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			if(evRaid != null)
			{
				if(evRaid.AKNOOLKMEGJ())
				{
					m_eventTicketId = NKOBMDPHNGP_EventRaidLobby.ADPMLOEOAFD_GetTicketId();
				}
			}
		}

		// RVA: 0xB42F28 Offset: 0xB42F28 VA: 0xB42F28 Slot: 38
		protected override PlayButtonWrapper CreatePlayButtonWrapper()
		{
			return new MissionEventMusicSelectButton(m_cdSelect);
		}

		// RVA: 0xB42FB4 Offset: 0xB42FB4 VA: 0xB42FB4 Slot: 51
		protected override void OnDecideCurrentMusic()
		{
			m_missionText = GameMessageManager.ReplaceMessageTag(m_missionSetData.GAAHOOBMDEE_Missions[m_selectedCardIndex].FEMMDNIELFC_Desc, (string tag) =>
			{
				//0xB48280
				int fmId = 0;
				if(selectMusicData != null)
					fmId = selectMusicData.GHBPLHBNMBK_FreeMusicId;
				return GameMessageManager.MissionMessageTagFunc(m_strBuilder, tag, fmId, m_isLine6Mode, diff);
			});
			if(RuntimeSettings.CurrentSettings.Language != "en" && RuntimeSettings.CurrentSettings.Language != "fr" )
				m_missionText = m_missionText.Replace(JpStringLiterals.StringLiteral_5812, "");
			else
				m_missionText = m_missionText.Replace(JpStringLiterals.StringLiteral_5812, " ").Replace("  ", " ");
			m_overrideEnemyCenterSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.DCOALMMJDJK_OverrideCenterSkill;
			m_overrideEnemyLiveSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.KKPLDFNDFDE_OverrideLiveSkill;
			SaveDifficulty();
			base.OnDecideCurrentMusic();
		}

		// RVA: 0xB4339C Offset: 0xB4339C VA: 0xB4339C Slot: 46
		protected override void ApplyMusicInfoBasic(IBJAKJJICBC musicData)
		{
			if(musicData.NNJNNCGGKMC_IsLimited)
			{
				m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.Special, false);
				m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.ExEvent, false);
			}
			else
			{
				base.ApplyMusicInfoBasic(musicData);
			}
			m_LayoutMissonSelect.SetMusicInfo(musicData, diff, m_unitLiveLocalSaveData, null);
			if(m_eventTicketId > 0)
				m_LayoutMissonSelect.SetDropItemIconType(m_eventTicketId);
		}

		// RVA: 0xB434C0 Offset: 0xB434C0 VA: 0xB434C0 Slot: 41
		protected override void ApplyBasicInfo() 
		{
			base.ApplyBasicInfo();
			for(int i = 0; i < 6; i++)
			{
				m_seriesInfo.SetTabNew((FreeCategoryId.Type)i, m_filteredMusicDataList[i].ContainsNew(false));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F21BC Offset: 0x6F21BC VA: 0x6F21BC
		// // RVA: 0xB435A8 Offset: 0xB435A8 VA: 0xB435A8 Slot: 57
		protected override IEnumerator Co_WaitForAnimEnd(Action onEnd)
		{
			//0x1040AF4
			while(IsPlayingLayout())
				yield return null;
			if(onEnd != null)
				onEnd();
		}

		// // RVA: 0xB4364C Offset: 0xB4364C VA: 0xB4364C Slot: 42
		protected override void ApplyMusicListInfo()
		{
			if(!m_isInitialized)
			{
				m_seriesInfo.ChangeSelectedTab((FreeCategoryId.Type)categoryId, true);
			}
			else
			{
				m_seriesInfo.ChangeSelectedTab((FreeCategoryId.Type)categoryId, false);
				MenuScene.Instance.InputDisable();
				this.StartCoroutineWatched(Co_WaitForAnimEnd(() =>
				{
					//0xB48388
					MenuScene.Instance.InputEnable();
					m_seriesInfo.ResetLockTabs();
				}));
			}
			base.ApplyMusicListInfo();
		}

		// RVA: 0xB43798 Offset: 0xB43798 VA: 0xB43798 Slot: 52
		protected override void LeaveForScrollStart()
		{
			base.LeaveForScrollStart();
			m_seriesInfo.Leave();
		}

		// RVA: 0xB437D0 Offset: 0xB437D0 VA: 0xB437D0 Slot: 53
		protected override void EnterForScrollEnd()
		{
			base.EnterForScrollEnd();
			m_seriesInfo.Enter();
		}

		// RVA: 0xB43808 Offset: 0xB43808 VA: 0xB43808 Slot: 44
		protected override void DelayedApplyMusicInfo()
		{
			if(m_isEventTimeLimit)
				return;
			base.DelayedApplyMusicInfo();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KIKCCBMOLDM_MissionEvent.NGNECOFAMKP_SetCategoryId((FreeCategoryId.Type)categoryId);
			if(!listIsEmpty)
			{
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KIKCCBMOLDM_MissionEvent.HJHBGHMNGKL_SetDifficulty(diff);
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KIKCCBMOLDM_MissionEvent.ACGKEJKPFIA_SetMusicIdForCategory((FreeCategoryId.Type)categoryId, freeMusicId);
				m_LayoutMissonSelect.UpdatePlayButton(selectMusicData, diff);
			}
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2234 Offset: 0x6F2234 VA: 0x6F2234
		// // RVA: 0xB43A10 Offset: 0xB43A10 VA: 0xB43A10 Slot: 55
		protected override IEnumerator Co_LoadLayout()
		{
			StringBuilder bundleName; // 0x14
			FontInfo systemFont; // 0x18
			int bundleLoadCount; // 0x1C
			AssetBundleLoadLayoutOperationBase lytOp; // 0x20
			AssetBundleLoadUGUIOperationBase uguiOp; // 0x24

			//0x103CAA0
			bundleName = new StringBuilder();
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/038.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicInfo");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48440
				instance.transform.SetParent(transform, false);
				m_musicInfo = instance.GetComponent<MusicSelectMusicInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicCD");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48510
				instance.transform.SetParent(transform, false);
				m_cdSelect = instance.GetComponent<MusicSelectCDSelect>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicCDArrow");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB485E0
				instance.transform.SetParent(transform, false);
				m_cdArrow = instance.GetComponent<MusicSelectCDArrow>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_ButtonSet");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB486B0
				instance.transform.SetParent(transform, false);
				m_buttonSet = instance.GetComponent<MusicSelectButtonSet>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventBanner");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48780
				instance.transform.SetParent(transform, false);
				m_eventBanner = instance.GetComponent<MusicSelectEventBanner>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_SeriesInfo");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48850
				instance.transform.SetParent(transform, false);
				m_seriesInfo = instance.GetComponent<MusicSelectSeriesInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventInfo");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48920
				instance.transform.SetParent(transform, false);
				m_eventInfo = instance.GetComponent<MusicSelectEventInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicRate");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB489F0
				instance.transform.SetParent(transform, false);
				m_musicRate = instance.GetComponent<MusicSelectMusicRate>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventEnd");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48AC0
				instance.transform.SetParent(transform, false);
				m_timeLimitMessage = instance.GetComponent<EventTimeLimitMessage>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_LineButton");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48B90
				instance.transform.SetParent(transform, false);
				m_lineButton = instance.GetComponent<MusicSelectLineButton>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_BonusButton");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48C60
				instance.transform.SetParent(transform, false);
				m_bonusButton = instance.GetComponent<MusicSelectBonusButton>();
			}));
			bundleLoadCount++;
			uguiOp = AssetBundleManager.LoadUGUIAsync(bundleName.ToString(), "UGUI_FilterButton");
			yield return uguiOp;
			yield return Co.R(uguiOp.InitializeUGUICoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48D30
				instance.transform.SetParent(transform, false);
				m_filterButton = instance.GetComponent<MusicSelectMusicFilterButton>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			bundleName.Set("ly/107.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "MissionSelect");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48E00
				instance.transform.SetParent(transform, false);
				m_LayoutMissonSelect = instance.GetComponent<LayoutQuestEvent2MissionSelect>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "EventSettingBtn");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xB48ED0
				instance.transform.SetParent(transform, false);
				m_LayoutEventSettingBtn = instance.GetComponent<LayoutQuestEvent2EventBtn>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			m_popMissionSetting.TitleText = MessageManager.Instance.GetMessage("menu", "event_mission_setting_title");
			m_popMissionSetting.WindowSize = SizeType.Middle;
			m_popMissionSetting.m_parent = transform;
			m_popMissionSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			yield return Co.R(Co_LoadAssetBundle_LoginBonusPopup());
		}

		// RVA: 0xB43A98 Offset: 0xB43A98 VA: 0xB43A98 Slot: 49
		protected override int GetDanceDivaCount()
		{
			if(m_currentStep != Step.MissionConfirm)
			{
				return m_cdSelect.GetDanceDivaCount();
			}
			else
			{
				return m_LayoutMissonSelect.GetDanceDivaCount();
			}
		}

		// RVA: 0xB43AF4 Offset: 0xB43AF4 VA: 0xB43AF4 Slot: 48
		protected override void ApplyUnitLiveButtonSetting(bool isUnit)
		{
			m_unitLiveLocalSaveData.IAGAAOKODPM_SetMultiDiva(selectMusicData.GHBPLHBNMBK_FreeMusicId, isUnit);
			m_LayoutMissonSelect.SetupUnitLive(selectMusicData, m_unitLiveLocalSaveData);
		}

		// // RVA: 0xB43B98 Offset: 0xB43B98 VA: 0xB43B98
		private bool IsFilter()
		{
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.KLIBOIEIMBA_EventMission save = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.BPFEOJEAEGK_EventMission;
			int music_level_limitmin = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmin", 1);
			int music_level_limitmax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmax", 25);
			return (save.KHAJGNDEPMG_FilterMusicLevelMin != 0 && save.KHAJGNDEPMG_FilterMusicLevelMin != music_level_limitmin) || 
				(save.IKFKKJLBBBN_FilterMusicLevelMax != 0 && save.IKFKKJLBBBN_FilterMusicLevelMax != music_level_limitmax) ||
				save.DPDBMECAIIO_FilterUnit != 0 || save.PGMJCBIHNHK_FilterReward != 0 || save.JGOJDHFAHHE_FilterScoreRank != 0 || 
				save.JJNLEPEKNDO_FilterCombo != 0 || save.EOCPIGDIFNB_FilterMusicAttr != 0 || save.GMMPGHKIDEK_FilterBonus != 0;
        }

		// // RVA: 0xB43ED8 Offset: 0xB43ED8 VA: 0xB43ED8
		private void CheckListEpmtyByFilter()
		{
			m_isListEmptyByFilter = false;
			if(IsFilter())
			{
				m_isListEmptyByFilter = currentMusicList.GetCount(m_isLine6Mode, m_isSimulationLive) == 0;
			}
		}

		// // RVA: 0xB43F5C Offset: 0xB43F5C VA: 0xB43F5C
		private bool CheckMatchMusicFilter(IBJAKJJICBC musicData, long currentTime)
		{
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.KLIBOIEIMBA_EventMission save = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.BPFEOJEAEGK_EventMission;
			int music_level_limitmin = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmin", 1);
			int music_level_limitmax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmax", 25);
			return CheckMusicFilter_MusicLevel(save.KHAJGNDEPMG_FilterMusicLevelMin == 0 ? music_level_limitmin : save.KHAJGNDEPMG_FilterMusicLevelMin, 
				save.IKFKKJLBBBN_FilterMusicLevelMax == 0 ? music_level_limitmax : save.IKFKKJLBBBN_FilterMusicLevelMax, musicData, diff) && 
				CheckMusicFilter_MusicAttr(save.EOCPIGDIFNB_FilterMusicAttr, musicData) && 
				CheckMusicFilter_Combo(save.JJNLEPEKNDO_FilterCombo, musicData, diff) && 
				CheckMusicFilter_Reward(save.PGMJCBIHNHK_FilterReward, musicData, diff, m_isLine6Mode) && 
				CheckMusicFilter_Unit(save.DPDBMECAIIO_FilterUnit, musicData) && 
				CheckMusicFilter_Bonus(save.GMMPGHKIDEK_FilterBonus, musicData);
       }

		// // RVA: 0xB44300 Offset: 0xB44300 VA: 0xB44300
		private bool CheckMusicFilter_MusicLevel(int levelMin, int levelMax, IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			return PopupSortMenu.IsMusicLevelFilter(levelMin, levelMax, musicData, difficulty);
		}

		// // RVA: 0xB443A8 Offset: 0xB443A8 VA: 0xB443A8
		private bool CheckMusicFilter_MusicAttr(int filterBit, IBJAKJJICBC musicData)
		{
			if(filterBit != 0)
			{
				return PopupSortMenu.IsAttributeFilterOn(musicData.FKDCCLPGKDK_JacketAttr, (uint)filterBit);
			}
			return true;
		}

		// // RVA: 0xB44464 Offset: 0xB44464 VA: 0xB44464
		private bool CheckMusicFilter_Combo(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty)
		{
			if(filterBit != 0)
			{
				if((filterBit & 1) != 0)
				{
					if(musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].LCOHGOIDMDF_ComboRank > 0)
						return false;
				}
				if((filterBit & 2) != 0)
				{
					if(musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].LCOHGOIDMDF_ComboRank < 2)
						return true;
					return false;
				}
			}
			return true;
		}

		// // RVA: 0xB445D0 Offset: 0xB445D0 VA: 0xB445D0
		private bool CheckMusicFilter_Reward(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty, bool isLine6Mode)
		{
			if(filterBit != 0)
			{
				if(musicData.DEPGBBJMFED_CategoryId == 5)
				{
					if(!musicData.LHONOILACFL_IsWeeklyEvent)
						return false;
				}
				FPGEMAIAMBF_RewardData f = new FPGEMAIAMBF_RewardData();
				f.JMHCEMHPPCM(musicData.GHBPLHBNMBK_FreeMusicId, (int)difficulty, isLine6Mode, musicData.MNNHHJBBICA_GameEventType);
				if((filterBit & 1) != 0)
				{
					if(PopupSortMenu.IsAllRewardAchievedFilter(f.PDONJHCHBAE_ScoreReward))
						return false;
				}
				if((filterBit & 2) != 0)
				{
					if(PopupSortMenu.IsAllRewardAchievedFilter(f.HFPMKBAANFO_ComboReward))
						return false;
				}
				if((filterBit & 4) != 0)
				{
					if(PopupSortMenu.IsAllRewardAchievedFilter(f.IOCLNNCJFKA_ClearReward))
						return false;
				}
			}
			return true;
		}

		// // RVA: 0xB4484C Offset: 0xB4484C VA: 0xB4484C
		private bool CheckMusicFilter_Unit(int filterBit, IBJAKJJICBC musicData)
		{
			if(filterBit != 0)
			{
				bool res = false;
				bool b = musicData.PNKKJEABNFF(IBJAKJJICBC.AAADDDFCKLF.ALNCPFNNBLH_0);
				if((filterBit & 1) != 0)
				{
					res |= musicData.BENDFLDLIAG_IsAvaiableForNumDiva(1);
				}
				if((filterBit & 2) != 0)
				{
					res |= b && musicData.BENDFLDLIAG_IsAvaiableForNumDiva(2);
				}
				if((filterBit & 4) != 0)
				{
					res |= b && musicData.BENDFLDLIAG_IsAvaiableForNumDiva(3);
				}
				if((filterBit & 8) != 0)
				{
					res |= b && musicData.BENDFLDLIAG_IsAvaiableForNumDiva(5);
				}
				return res;
			}
			return true;
		}

		// // RVA: 0xB44964 Offset: 0xB44964 VA: 0xB44964
		private bool CheckMusicFilter_Bonus(int filterBit, IBJAKJJICBC musicData)
		{
			if(filterBit != 0)
			{
				if((filterBit & 1) != 0)
				{
					if(musicData.DBJOBFIGGEE_EventBonusPercent > 0)
						return true;
				}
				if((filterBit & 2) != 0)
				{
					if(musicData.DBJOBFIGGEE_EventBonusPercent == 0)
						return true;
				}
				return false;
			}
			return true;
		}

		// // RVA: 0xB449F4 Offset: 0xB449F4 VA: 0xB449F4
		private void OnClickMusicFilterButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			PopupFilterSortUGUIInitParam initParam = new PopupFilterSortUGUIInitParam();
			initParam.SetMissionMusicSelectParam(diff, m_isLine6Mode, true);
			MenuScene.Instance.ShowSortWindow(initParam, (PopupFilterSortUGUI content) =>
			{
				//0x103833C
				ApplyFilterButtonStatus();
				OnSelectedDifficulty(initParam.MissionMusicSelectParam.Difficulty);
			}, null);
		}

		// // RVA: 0xB44BD4 Offset: 0xB44BD4 VA: 0xB44BD4
		private void OnChangeMusicFilter(bool isClear)
		{
			int gameEventType = 0;
			int freeMusicId = 0;
			if(!listIsEmpty)
			{
				freeMusicId = selectMusicData.GHBPLHBNMBK_FreeMusicId;
				gameEventType = selectMusicData.MNNHHJBBICA_GameEventType;
			}
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(!isClear)
			{
				CreateFilteredMusicDataList(m_filteredMusicDataList, m_originalMusicDataList, t, CheckMatchMusicFilter);
			}
			else
			{
				CreateFilteredMusicDataList(m_filteredMusicDataList, m_originalMusicDataList, t, (IBJAKJJICBC m, long ct) =>
				{
					//0x10382C4
					return true;
				});
			}
			int v = 0;
			if(currentMusicList != null)
			{
				v = currentMusicList.FindIndex(freeMusicId, (OHCAABOMEOF.KGOGMKMBCPP_EventType)gameEventType, m_isLine6Mode, false);
				if(v < 0)
					v = 0;
			}
			OnChangedSeries((FreeCategoryId.Type)categoryId, v);
		}

		// // RVA: 0xB44F88 Offset: 0xB44F88 VA: 0xB44F88
		private void ApplyFilterButtonStatus()
		{
			m_filterButton.SetButtonStatus(IsFilter() ? MusicSelectMusicFilterButton.ButtonStatusType.FilterOn : MusicSelectMusicFilterButton.ButtonStatusType.FilterOff);
		}

		// // RVA: 0xB44FCC Offset: 0xB44FCC VA: 0xB44FCC
		private void OnChangedSeries(FreeCategoryId.Type seriesId)
		{
			int a;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KIKCCBMOLDM_MissionEvent.FKJBADIPKHK_GetMusicIdForCategory(seriesId, out a);
			int idx = FindMusicListIndex((int)seriesId, a);
			if(idx < 0)
				idx = 0;
			OnChangedSeries(seriesId, idx);
		}

		// // RVA: 0xB44F24 Offset: 0xB44F24 VA: 0xB44F24
		private void OnChangedSeries(FreeCategoryId.Type seriesId, int initListNo)
		{
			categoryId = (int)seriesId;
			list_no = initListNo;
			CheckListEpmtyByFilter();
			ApplyMusicListInfo();
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
		}

		// // RVA: 0xB451F0 Offset: 0xB451F0 VA: 0xB451F0
		// private void OnClickRankingButton() { }

		// // RVA: 0xB45200 Offset: 0xB45200 VA: 0xB45200
		private void OnClickOkButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			this.StartCoroutineWatched(Co_OnClickOkButton());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F22AC Offset: 0x6F22AC VA: 0x6F22AC
		// // RVA: 0xB45274 Offset: 0xB45274 VA: 0xB45274
		private IEnumerator Co_OnClickOkButton()
		{
			//0x103EEB4
			if(!CheckEventLimit())
			{
				if(!selectMusicData.IFNPBIJEPBO_IsDlded)
				{
					DownloadCurrentMusic();
				}
				else
				{
					if(selectMusicData.LHONOILACFL_IsWeeklyEvent && selectMusicData.MOJMEFIENDM_WeeklyEventCount < 1)
					{
						bool isClose = false;
						OpenWeekRecoveryWindow((int recovery) =>
						{
							//0x10383DC
							isClose = true;
							selectMusicData.IEBGBOBPJMB(recovery);
							ApplyMusicInfoNormal(selectMusicData);
                            IBJAKJJICBC s = currentMusicList.Find(selectMusicData.GHBPLHBNMBK_FreeMusicId, !m_isLine6Mode, m_isSimulationLive);
                            if (s != null)
							{
								s.IEBGBOBPJMB(recovery);
							}
						}, () =>
						{
							//0x103867C
							isClose = true;
						});
						while(!isClose)
							yield return null;
					}
					else
					{
						KPJHLACKGJF_EventMission ev = m_eventCtrl as KPJHLACKGJF_EventMission;
						ev.DCNEHOMHOJL(selectMusicData.GHBPLHBNMBK_FreeMusicId);
						SaveDifficulty();
						this.StartCoroutineWatched(Co_ChangeMode(Step.MissionConfirm));
					}
				}
			}
		}

		// // RVA: 0xB452FC Offset: 0xB452FC VA: 0xB452FC
		private void OnClickEventBonusButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			KPJHLACKGJF_EventMission ev = m_eventCtrl as KPJHLACKGJF_EventMission;
			if(ev != null)
			{
				PopupMissionBonusListSetting s = new PopupMissionBonusListSetting();
				s.TitleText = bk.GetMessageByLabel("missionevent_bonus_popup_title");
				s.SetParent(transform);
				s.WindowSize = SizeType.Middle;
				s.List = ev.AFOIGLCEBAE.FindAll((KPJHLACKGJF_EventMission.HLMINENBCKO _) =>
				{
					//0x10382CC
					return _.CIANOCNPIFF_Type != KPJHLACKGJF_EventMission.MNIIDKPECMD.HIFIGCJNJDO_0_MusicId;
				});
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				PopupWindowManager.Show(s, null, null, null, null, true, true, false);
			}
		}

		// // RVA: 0xB4580C Offset: 0xB4580C VA: 0xB4580C
		private void ApplyEventInfo()
		{
			m_eventBanner.SetStyle(IsEventEndChallengePeriod ? MusicSelectEventBanner.Style.Enable : MusicSelectEventBanner.Style.Period);
			m_eventBanner.ChangeEventBanner(m_eventId);
			m_bannerTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
			{
				//0xB48FA0
				ApplyEventBannerRemainTime(remain, true);
			};
			m_bannerTimeWatcher.onEndCallback = null;
			m_bannerTimeWatcher.WatchStart(m_eventCtrl.DPJCPDKALGI_RankingEnd);
			if(m_eventCtrl.MNDFBBMNJGN_IsUsingTicket)
			{
				m_cdSelect.EventTicketEnable(false);
				GameManager.Instance.ItemTextureCache.Load(m_eventCtrl.JKIADEKHGLC_TicketItemId, (IiconTexture image) =>
				{
					//0xB48FCC
					m_cdSelect.EventTicketEnable(true);
					m_cdSelect.SetEventTicketIcon(image);
					m_eventBanner.SetEventTicket(image);
					m_eventInfo.SetTicketImage(image);
				});
			}
			m_eventInfo.SetTicketCount(m_eventCtrl.AELBIEDNPGB_GetTicketCount(null));
			if(IsEventCounting)
			{
				m_eventInfo.SetRankCouting(MessageManager.Instance.GetMessage("menu", "music_event_collect_rank_counting"), 0);
			}
			else
			{
				if(m_eventCtrl.CDINKAANIAA_Rank[0] < 1)
				{
					m_eventInfo.SetRankOrder(TextConstant.InvalidText, 0);
				}
				else
				{
					m_eventInfo.SetRankOrder(m_eventCtrl.CDINKAANIAA_Rank[0].ToString(), 0);
				}
			}
			m_eventInfo.SetCurrentValue(EP_ToString(m_eventCtrl.FBGDBGKNKOD_GetCurrentPoint()));
            IHAEIOAKEMG rwd = m_eventCtrl.ILICNKILFKJ_GetNextReward();
            if (rwd == null || IsEventEndChallengePeriod)
			{
				m_eventInfo.SetRewardValid(false);
				m_eventInfo.SetNextValue(TextConstant.InvalidText);
				m_eventInfo.SetRewardEndLabel(TextConstant.InvalidText);
			}
			else
			{
				m_eventInfo.SetRewardValid(true);
				m_eventInfo.SetNextValue(EP_ToString(rwd.OJELCGDDAOM_MissingPoint));
				GameManager.Instance.ItemTextureCache.Load(rwd.HBHMAKNGKFK_Items[0].JJBGOIMEIPF_ItemId, (IiconTexture image) =>
				{
					//0xB49070
					m_eventInfo.SetRewardIcon(image);
				});
			}
		}

		// // RVA: 0xB45FA0 Offset: 0xB45FA0 VA: 0xB45FA0
		private static string EP_ToString(long point)
		{
			return Mathf.Min(99999999, point).ToString();
		}

		// // RVA: 0xB46000 Offset: 0xB46000 VA: 0xB46000
		private void OnClickEventSettingButton()
		{
			KPJHLACKGJF_EventMission missionEventCtrl = m_eventCtrl as KPJHLACKGJF_EventMission;
			m_popMissionSetting.DefaultSelectButton = missionEventCtrl.MLNOLKKHBDC_IsSelectPrevSong() ? LayoutQuestPopupMissionSettingWindow.SelectType.PrevMusic : LayoutQuestPopupMissionSettingWindow.SelectType.Random;
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			PopupWindowManager.Show(m_popMissionSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1038690
				if(type != PopupButton.ButtonType.Positive)
					return;
				LayoutQuestPopupMissionSetting c = control.Content as LayoutQuestPopupMissionSetting;
				if(c != null)
				{
					missionEventCtrl.BMNPDFHNLOM_SetIsSelectPrevSong(c.IsPrevSelectMusic());
				}
			}, (IPopupContent content, PopupTabButton.ButtonLabel label) =>
			{
				//0x10382DC
				return;
			}, null, null, true, true, false);
		}

		// // RVA: 0xB46358 Offset: 0xB46358 VA: 0xB46358
		private void SelectedMission(int index)
		{
			if(m_currentStep != Step.MissionSelect)
				return;
			KPJHLACKGJF_EventMission ev = m_eventCtrl as KPJHLACKGJF_EventMission;
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			GameManager.Instance.CloseSnsNotice();
			if(ev.KCHMKLPHOEB_GetStep() == DJDJHGJHAJA.IOPLHHNPLGM.EHPECKJANLI_2
				|| ev.KCHMKLPHOEB_GetStep() == DJDJHGJHAJA.IOPLHHNPLGM.NHGCLAGKEOO_3)
			{
				//LAB_00b464d0
				m_selectedCardIndex = index;
				ev.NAJMELNNCAN_SetSelectedCardIdx(index);
				ev.PNKKJJFBBIH_SetStep(DJDJHGJHAJA.IOPLHHNPLGM.NCDPEOOJEKL_5);
				ev.ACJFIFPCJDP();
			}
			else
			{
				m_selectedCardIndex = index;
				ev.NAJMELNNCAN_SetSelectedCardIdx(index);
				ev.PNKKJJFBBIH_SetStep(DJDJHGJHAJA.IOPLHHNPLGM.NCDPEOOJEKL_5);
			}
			categoryId = FindCategoryId(ev.IGBPFGPPJOE(), m_isLine6Mode);
			if(categoryId < 1)
			{
				categoryId = FindCategoryId(ev.IGBPFGPPJOE(), !m_isLine6Mode);
				if(categoryId > 0)
					m_isLine6Mode = !m_isLine6Mode;
			}
			if(categoryId > 0)
			{
				list_no = FindMusicListIndex(categoryId, ev.IGBPFGPPJOE());
			}
			if(categoryId < 1 || list_no < 0)
				SetDefaultCategoryAndIndex();
			DelayedApplyMusicInfo();
			this.StartCoroutineWatched(Co_WaitButtonAnime(() =>
			{
				//0xB490A4
				this.StartCoroutineWatched(Co_ChangeMode(Step.MissionConfirm));
			}));
		}

		// // RVA: 0xB46A38 Offset: 0xB46A38 VA: 0xB46A38
		private void ReturnMissionSelect()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			GameManager.Instance.CloseSnsNotice();
			this.StartCoroutineWatched(Co_WaitButtonAnime(() =>
			{
				//0xB490CC
				(m_eventCtrl as KPJHLACKGJF_EventMission).PNKKJJFBBIH_SetStep(DJDJHGJHAJA.IOPLHHNPLGM.EBEFOHNCAJD_4);
				this.StartCoroutineWatched(Co_ChangeMode(Step.MissionSelect));
			}));
		}

		// // RVA: 0xB46B74 Offset: 0xB46B74 VA: 0xB46B74
		private void GotoBoxGacha()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!CheckEventLimit())
			{
				int id = m_eventCtrl.BAEPGOAMBDK("gacha_box_event_id", 0);
				if(id > 0)
				{
					MenuScene.Instance.Mount(TransitionUniqueId.EVENTQUEST_GACHABOXQUEST, new GachaBoxScene.GachaBoxArgs(id), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2324 Offset: 0x6F2324 VA: 0x6F2324
		// // RVA: 0xB469B0 Offset: 0xB469B0 VA: 0xB469B0
		private IEnumerator Co_WaitButtonAnime(Action end)
		{
			//0x10408C4
			MenuScene.Instance.InputDisable();
			yield return new WaitForSeconds(0.1f);
			MenuScene.Instance.InputEnable();
			if(end != null)
				end();
		}

		// // RVA: 0xB46CF8 Offset: 0xB46CF8 VA: 0xB46CF8
		private void OnChangeMusic()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			this.StartCoroutineWatched(Co_ChangeMode(Step.SelectMusicList));
		}

		// // RVA: 0xB46EA4 Offset: 0xB46EA4 VA: 0xB46EA4
		// private void OnSelectedDifficulty(Difficulty.Type difficulty) { }

		// // RVA: 0xB43264 Offset: 0xB43264 VA: 0xB43264
		private void SaveDifficulty()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.KIKCCBMOLDM_MissionEvent.HJHBGHMNGKL_SetDifficulty(diff);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}

		// // RVA: 0xB4701C Offset: 0xB4701C VA: 0xB4701C Slot: 16
		protected override void OnPreSetCanvas()
		{
			GameManager.Instance.SelectedGuestData = null;
			m_LayoutMissonSelect.MakeCache();
			base.OnPreSetCanvas();
			this.StartCoroutineWatched(Co_OnPresetCanvas());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F239C Offset: 0x6F239C VA: 0x6F239C
		// // RVA: 0xB47104 Offset: 0xB47104 VA: 0xB47104
		private IEnumerator Co_OnPresetCanvas()
		{
			long currentTime;

			//0x103F3B0
			EventMusicSelectSceneArgs args = Args as EventMusicSelectSceneArgs;
			EventMusicSelectSceneArgs rargs = ArgsReturn as EventMusicSelectSceneArgs;
			m_isEventChecked = false;
			m_isEventTimeLimit = false;
			m_eventStatus = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0;
			currentTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_eventCtrl = null;
			if(args != null)
			{
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(args.EventUniqueId);
				m_isLine6Mode = args.isFromRhythmGame && args.isLine6Mode;
			}
			else if(rargs != null)
			{
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(rargs.EventUniqueId);
				m_isLine6Mode = rargs.isFromRhythmGame && rargs.isLine6Mode;
			}
			else
			{
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(m_eventId);
			}
			if(m_eventCtrl != null)
			{
				m_eventCtrl.HCDGELDHFHB_UpdateStatus(currentTime);
				m_eventStatus = m_eventCtrl.NGOFCFJHOMI_Status;
			}
			if(!MenuScene.Instance.CheckEventLimit(m_eventCtrl, false, true))
			{
				m_eventId = m_eventCtrl.PGIIDPEGGPI_EventId;
				yield return Co.R(Co_Initialize_LoginBonusPopup(m_eventCtrl));
				if(MenuScene.Instance.BgControl.GetCurrentType() != BgType.MusicEvent)
				{
					this.StartCoroutineWatched(Co_ChangeBg(BgType.MusicEvent, m_eventId));
				}
				m_originalMusicDataList.Clear();
				if(!IsEventEndChallengePeriod)
				{
					for(int i = 1; i < 7; i++)
					{
						m_originalMusicDataList.Add(new MusicDataList(IBJAKJJICBC.FMHFMIMDOCM(i, currentTime, false), IBJAKJJICBC.FMHFMIMDOCM(i, currentTime, true)));
					}
				}
				else
				{
					for(int i = 1; i < 7; i++)
					{
						m_originalMusicDataList.Add(new MusicDataList(IBJAKJJICBC.GCCBCAKFJMF(i, currentTime, m_eventCtrl.PGIIDPEGGPI_EventId, false), IBJAKJJICBC.GCCBCAKFJMF(i, currentTime, m_eventCtrl.PGIIDPEGGPI_EventId, true)));
					}
				}
				m_lineButton.SetUnlock(IBJAKJJICBC.KGJJCAKCMLO());
				m_lineButton.SetUnlockNumber(IBJAKJJICBC.POPLHDKHIIM());
				StringBuilder str = new StringBuilder(32);
				str.SetFormat("ct/mc/{0:D3}.xab", 0);
				TryInstall(str);
				for(int i = 0; i < m_originalMusicDataList.Count; i++)
				{
					TryInstall(str, m_originalMusicDataList[i]);
				}
				while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
					yield return null;
				m_musicInfo.Hide();
				m_cdSelect.Hide();
				m_cdArrow.Hide();
				m_buttonSet.Hide();
				m_seriesInfo.Hide();
				m_eventInfo.Hide();
				m_musicRate.Hide();
				m_eventBanner.Hide();
				m_LayoutMissonSelect.Hide();
				m_LayoutEventSettingBtn.Hide();
				m_timeLimitMessage.Hide();
				m_lineButton.Hide();
				m_bonusButton.Hide();
				m_filterButton.Hide();
				while(IsPlayingLayout())
					yield return null;
				m_isEventChecked = true;
				base.OnPreSetCanvas();
			}
			else
			{
				GameManager.Instance.fullscreenFader.Fade(0, Color.black);
				while(!PopupWindowManager.IsActivePopupWindow())
					yield return null;
				while(PopupWindowManager.IsActivePopupWindow())
					yield return null;
				AutoFadeFlag = false;
				m_isEventTimeLimit = true;
				m_isEventChecked = true;
			}
		}

		// // RVA: 0xB4718C Offset: 0xB4718C VA: 0xB4718C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !isBgChanging && m_isEventChecked && base.IsEndPreSetCanvas();
		}

		// RVA: 0xB471CC Offset: 0xB471CC VA: 0xB471CC Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(m_isEventTimeLimit)
				return;
			m_eventBanner.Enter();
			base.OnStartEnterAnimation();
		}

		// RVA: 0xB47214 Offset: 0xB47214 VA: 0xB47214 Slot: 12
		protected override void OnStartExitAnimation()
		{
			if(m_isEventTimeLimit)
				return;
			switch(m_currentStep)
			{
				case Step.MissionSelect:
					m_LayoutMissonSelect.LeaveMission();
					m_LayoutEventSettingBtn.Leave();
					m_buttonSet.Leave();
					m_eventInfo.Leave();
					break;
				case Step.MissionConfirm:
					m_buttonSet.Leave();
					m_eventInfo.Leave();
					m_musicInfo.Leave();
					m_LayoutMissonSelect.LeaveMissionConfirm();
					m_LayoutEventSettingBtn.Leave();
					//LAB_00b47424
					m_lineButton.TryLeave();
					break;
				case Step.SelectMusicList:
					m_musicInfo.Leave();
					m_cdSelect.Leave();
					m_cdArrow.Leave();
					m_buttonSet.Leave();
					m_seriesInfo.Leave();
					//LAB_00b47424
					m_lineButton.TryLeave();
					break;
				case Step.EndEventHome:
					m_buttonSet.Leave();
					m_eventInfo.Leave();
					m_LayoutMissonSelect.LeaveGachaButton();
					m_timeLimitMessage.Leave();
					break;
			}
			m_eventBanner.Leave();
			m_lineButton.TryLeave();
			m_bonusButton.TryLeave();
			m_filterButton.TryLeave();
		}

		// RVA: 0xB4754C Offset: 0xB4754C VA: 0xB4754C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !IsPlayingLayout();
		}

		// RVA: 0xB47A70 Offset: 0xB47A70 VA: 0xB47A70 Slot: 15
		protected override void OnDeleteCache()
		{
			MenuScene.Instance.BgControl.DestroyCacheBg();
			base.OnDeleteCache();
		}

		// RVA: 0xB47B34 Offset: 0xB47B34 VA: 0xB47B34 Slot: 20
		protected override bool OnBgmStart()
		{
			if(m_eventCtrl != null && m_eventCtrl is KPJHLACKGJF_EventMission)
			{
				if(m_showingStep == Step.MissionSelect)
				{
					ChangeTrialMusic(m_eventCtrl.EDNMFMBLCGF_GetWavId());
				}
				else
				{
					base.OnBgmStart();
				}
			}
			return true;
		}

		// // RVA: 0xB47560 Offset: 0xB47560 VA: 0xB47560
		private bool IsPlayingLayout()
		{
			if(m_LayoutMissonSelect.gameObject.activeSelf && m_LayoutMissonSelect.IsPlaying())
				return true;
			if(m_LayoutEventSettingBtn.gameObject.activeSelf && m_LayoutEventSettingBtn.IsPlaying())
				return true;
			if(m_musicInfo.gameObject.activeSelf && m_musicInfo.IsPlaying())
				return true;
			if(m_cdSelect.gameObject.activeSelf && m_cdSelect.IsPlaying())
				return true;
			if(m_cdArrow.gameObject.activeSelf && m_cdArrow.IsPlaying())
				return true;
			if(m_buttonSet.gameObject.activeSelf && m_buttonSet.IsPlaying())
				return true;
			if(m_eventBanner.gameObject.activeSelf && m_eventBanner.IsPlaying())
				return true;
			if(m_seriesInfo.gameObject.activeSelf && m_seriesInfo.IsPlaying())
				return true;
			if(m_eventInfo.gameObject.activeSelf && m_eventInfo.IsPlaying())
				return true;
			if(m_musicRate.gameObject.activeSelf && m_musicRate.IsPlaying())
				return true;
			if(m_timeLimitMessage.IsPlaying())
				return true;
			if(m_lineButton.IsPlaying())
				return true;
			if(m_bonusButton.IsPlaying())
				return true;
			return m_filterButton.IsPlaying();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2414 Offset: 0x6F2414 VA: 0x6F2414
		// // RVA: 0xB47C1C Offset: 0xB47C1C VA: 0xB47C1C Slot: 37
		protected override IEnumerator Co_OnActivateScene()
		{
			//0x103DF70
			m_isEndActivateScene = false;
			if(m_isEventTimeLimit)
			{
				m_isEndActivateScene = true;
				yield break;
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_ShowReciveLoginAchievement());
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(m_isShowFirstHelp)
				{
					yield return Co.R(Co_ShowHelp());
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_Show_LoginBonusPopup(null));
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				MenuScene.Instance.InputDisable();
				yield return this.StartCoroutineWatched(Co_ChangeMode(m_showingStep));
				MenuScene.Instance.InputEnable();
			}
			if(!MenuScene.Instance.DirtyChangeScene && TutorialProc.CanBeginnerMissionLiveClearLiveHelp())
			{
				yield return Co.R(TutorialProc.Co_BeginnerMissionLiveClear(null, null));
				MenuScene.SaveRequest();
			}
			else
			{
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MLBBKNLPBBD_HasShowTuto(BOPFPIHGJMD.PDLKAKEABDP.EILIAPKFCEO_0) && KDHGBOOECKC.HHCJCDFCLOB.LOCAIBNPKDL_IsPlayerLevelOk())
					{
						yield return Co.R(TutorialProc.Co_OffeReleaseTutorial(InputLimitButton.VOP, MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.VOP), () =>
						{
							//0x10382E0
							return;
						}, BasicTutorialMessageId.Id_OfferRelease, true, null, null));
						//LAB_0103ecb4
						m_isEndActivateScene = true;
						yield break;
					}
				}
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					if(!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(Common.GPFlagConstant.ID.IsValkyrieUpgrade) && SettingMenuPanel.IsValkyrieTuneUpUnlock())
					{
						yield return Co.R(TutorialProc.Co_ValkyrieUpgrade(MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Setting), BasicTutorialMessageId.Id_ValkyrieUpgradeHome, InputLimitButton.Setting, TutorialPointer.Direction.Down, null, null));
						//LAB_0103ecb4
						m_isEndActivateScene = true;
						yield break;
					}
				}
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					MenuScene.Instance.InputDisable();
					yield return Co.R(Co_CheckUnlock(null));
					MenuScene.Instance.InputEnable();
				}
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					AddNotice(() =>
					{
						//0x10387E4
						CheckSnsNotice();
					});
				}
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					AddNotice(() =>
					{
						//0x1038810
						CheckOfferNotice();
					});
				}
				ShowNotice();
				MenuScene.Instance.InputDisable();
				bool isWait = true;
				bool isErr = false;
				MenuScene.Save(() =>
				{
					//0x103883C
					isWait = false;
					isErr = false;
				}, () =>
				{
					//0x1038848
					isWait = false;
					isErr = true;
				});
				while(isWait)
					yield return null;
				if(isErr)
				{
					MenuScene.Instance.GotoTitle();
					yield break;
				}
				MenuScene.Instance.InputEnable();
			}
			//LAB_0103ecb4
			m_isEndActivateScene = true;

		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F248C Offset: 0x6F248C VA: 0x6F248C
		// // RVA: 0xB46E00 Offset: 0xB46E00 VA: 0xB46E00
		private IEnumerator Co_ChangeMode(Step nextStep)
		{
			KPJHLACKGJF_EventMission missionEventCtrl;

			//0x1038F20
			MenuScene.Instance.InputDisable();
			missionEventCtrl = m_eventCtrl as KPJHLACKGJF_EventMission;
			if(nextStep == Step.MissionConfirm && m_currentStep != Step.None)
			{
				bool isWait = true;
				bool isErr = false;
				MenuScene.Save(() =>
				{
					//0x103885C
					isWait = false;
					isErr = false;
				}, () =>
				{
					//0x1038868
					isWait = false;
					isErr = true;
				});
				while(isWait)
					yield return null;
				if(isErr)
				{
					MenuScene.Instance.GotoTitle();
					yield break;
				}
			}
			m_bonusButton.SetBonusButton(missionEventCtrl.AFOIGLCEBAE);
			if(m_currentStep == Step.SelectMusicList)
			{
				m_musicInfo.Leave();
				m_cdSelect.Leave();
				m_cdArrow.Leave();
				m_buttonSet.Leave();
				m_seriesInfo.Leave();
				m_musicRate.Leave();
				//LAB_01039940
				m_lineButton.TryLeave();
				m_bonusButton.TryLeave();
				m_filterButton.TryLeave();
			}
			else if(m_currentStep == Step.MissionConfirm)
			{
				m_LayoutMissonSelect.LeaveMissionConfirm();
				m_buttonSet.Leave();
				m_eventInfo.Leave();
				m_musicInfo.Leave();
				m_musicRate.Leave();
				m_LayoutEventSettingBtn.Leave();
				//LAB_01039940
				m_lineButton.TryLeave();
				m_bonusButton.TryLeave();
				m_filterButton.TryLeave();
			}
			else if(m_currentStep == Step.MissionSelect)
			{
				m_LayoutMissonSelect.GotoMissionConfirm(m_selectedCardIndex);
				m_buttonSet.Leave();
				m_eventInfo.Leave();
				m_LayoutEventSettingBtn.Leave();
			}
			m_musicInfo.onChangedDifficulty = null;
			//LAB_010399c8
			while(IsPlayingLayout())
				yield return null;
			switch(nextStep)
			{
				case Step.MissionSelect:
					m_musicInfo.gameObject.SetActive(false);
					m_cdSelect.gameObject.SetActive(false);
					m_cdArrow.gameObject.SetActive(false);
					m_seriesInfo.gameObject.SetActive(false);
					m_buttonSet.gameObject.SetActive(true);
					m_eventInfo.gameObject.SetActive(true);
					m_LayoutMissonSelect.gameObject.SetActive(true);
					m_LayoutEventSettingBtn.gameObject.SetActive(true);
					m_LayoutMissonSelect.SetGahcaItemCount(missionEventCtrl.KFGOHDKANAC_GetDecoItemCount());
					if(missionEventCtrl.KCHMKLPHOEB_GetStep() == DJDJHGJHAJA.IOPLHHNPLGM.EHPECKJANLI_2)
					{
						m_LayoutMissonSelect.Enter();
						missionEventCtrl.PNKKJJFBBIH_SetStep(DJDJHGJHAJA.IOPLHHNPLGM.NHGCLAGKEOO_3);
					}
					else if(missionEventCtrl.KCHMKLPHOEB_GetStep() == DJDJHGJHAJA.IOPLHHNPLGM.NHGCLAGKEOO_3 || missionEventCtrl.KCHMKLPHOEB_GetStep() == DJDJHGJHAJA.IOPLHHNPLGM.EBEFOHNCAJD_4)
					{
						m_LayoutMissonSelect.EnterMission();
					}
					m_eventInfo.Enter();
					m_LayoutEventSettingBtn.Enter();
					m_buttonSet.Enter();
					m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.QuestEvent, false, false, !missionEventCtrl.IBNKPMPFLGI_IsRankReward, !IsEventMissionSupport());
					m_buttonSet.SetBadge(MusicSelectOptionButton.OptionType.EvStory, IsNewStory());
					m_buttonSet.SetBadge(MusicSelectOptionButton.OptionType.EvMission, IsReceiveMission());
					m_overrideButtonStyle = MusicSelectButtonSet.OptionStyle.None;
					m_LayoutMissonSelect.SetMissionSetData(m_missionSetData, null, false, Difficulty.Type.Illegal);
					ChangeTrialMusic(missionEventCtrl.EDNMFMBLCGF_GetWavId());
					break;
				case Step.MissionConfirm:
					bool isLoaded = false;
					m_LayoutMissonSelect.SetMusicInfo(selectMusicData, diff, m_unitLiveLocalSaveData, () =>
					{
						//0x103887C
						isLoaded = true;
					});
					m_LayoutMissonSelect.SetMissionSetData(m_missionSetData, selectMusicData, m_isLine6Mode, diff);
					OverrideEnemySkill();
					ApplyMusicInfo();
					m_cdSelect.gameObject.SetActive(false);
					m_cdArrow.gameObject.SetActive(false);
					m_seriesInfo.gameObject.SetActive(false);
					m_musicInfo.gameObject.SetActive(true);
					m_buttonSet.gameObject.SetActive(true);
					m_eventInfo.gameObject.SetActive(true);
					m_LayoutMissonSelect.gameObject.SetActive(true);
					m_LayoutEventSettingBtn.gameObject.SetActive(true);
					while(!isLoaded)
						yield return null;
					m_eventInfo.Enter();
					m_buttonSet.Enter();
					m_musicInfo.Enter();
					m_musicRate.Enter();
					m_bonusButton.Enter();
					m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.QuestEventInfo, !selectMusicData.BJANNALFGGA_HasRanking, false, false, !IsEventMissionSupport());
					m_overrideButtonStyle = MusicSelectButtonSet.OptionStyle.QuestEventInfo;
					if(missionEventCtrl.KCHMKLPHOEB_GetStep() == DJDJHGJHAJA.IOPLHHNPLGM.NCDPEOOJEKL_5)
					{
						m_LayoutMissonSelect.EnterNormal(m_selectedCardIndex);
					}
					else
					{
						m_LayoutMissonSelect.EnterMissionConfirm();
					}
					m_LayoutEventSettingBtn.Enter();
					m_musicInfo.onChangedDifficulty = OnSelectedDifficulty;
					ApplyMusicInfo();
					if(!selectMusicData.GBNOALJPOBM)
					{
						m_lineButton.TryLeave();
					}
					else
					{
						m_lineButton.TryEnter(m_isLine6Mode);
					}
					yield return Co.R(Co_ShowChangeMusicAlert());
					break;
				case Step.SelectMusicList:
					OverrideEnemySkill();
					m_musicInfo.gameObject.SetActive(true);
					m_cdSelect.gameObject.SetActive(true);
					m_cdArrow.gameObject.SetActive(true);
					m_seriesInfo.gameObject.SetActive(true);
					m_buttonSet.gameObject.SetActive(true);
					m_eventInfo.gameObject.SetActive(false);
					m_LayoutMissonSelect.gameObject.SetActive(false);
					m_LayoutEventSettingBtn.gameObject.SetActive(false);
					m_musicInfo.Enter();
					m_cdSelect.Enter();
					m_cdArrow.Enter();
					m_buttonSet.Enter();
					m_seriesInfo.Enter();
					m_musicRate.Enter();
					m_bonusButton.Enter();
					m_filterButton.Enter();
					OnChangedSeries((FreeCategoryId.Type)categoryId, list_no);
					m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.QuestEventSelect, false, false, false, false);
					m_overrideButtonStyle = MusicSelectButtonSet.OptionStyle.QuestEventSelect;
					m_musicInfo.onChangedDifficulty = OnSelectedDifficulty;
					ApplyMusicInfo();
					m_lineButton.Enter(m_isLine6Mode);
					OnChangeMusicFilter(false);
					break;
				case Step.EndEventHome:
					m_musicInfo.gameObject.SetActive(false);
					m_cdSelect.gameObject.SetActive(false);
					m_cdArrow.gameObject.SetActive(false);
					m_seriesInfo.gameObject.SetActive(false);
					m_buttonSet.gameObject.SetActive(true);
					m_eventInfo.gameObject.SetActive(true);
					m_LayoutMissonSelect.gameObject.SetActive(true);
					m_LayoutEventSettingBtn.gameObject.SetActive(false);
					m_LayoutMissonSelect.SetGahcaItemCount(missionEventCtrl.KFGOHDKANAC_GetDecoItemCount());
					m_buttonSet.Enter();
					m_eventInfo.Enter();
					m_LayoutMissonSelect.EnterGachaButton();
					m_timeLimitMessage.Enter(IsEventCounting);
					m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.Basic, false, false, false, false);
					m_overrideButtonStyle = MusicSelectButtonSet.OptionStyle.EndEventHome;
					ApplyMusicInfo();
					break;
				default:
					break;
			}
			while(IsPlayingLayout())
				yield return null;
			if(nextStep == Step.MissionConfirm)
			{
				if(!MenuScene.Instance.DirtyChangeScene)
				{
					yield return TryShowUnitDanceTutorial();
				}
			}
			m_currentStep = nextStep;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xB466D4 Offset: 0xB466D4 VA: 0xB466D4
		private int FindCategoryId(int freeMusicId, bool line6Mode)
		{
			for(int i = 0; i < m_filteredMusicDataList.Count; i++)
			{
				for(int j = 0; j < m_filteredMusicDataList[i].GetCount(line6Mode, false); j++)
				{
					if(m_filteredMusicDataList[i].Get(j, line6Mode, false).GHBPLHBNMBK_FreeMusicId == freeMusicId)
					{
						return i + 1;
					}
				}
			}
			return -1;
		}

		// // RVA: 0xB4511C Offset: 0xB4511C VA: 0xB4511C
		private int FindMusicListIndex(int categoryId, int freeMusicId)
		{
			return m_filteredMusicDataList[categoryId - 1].FindIndex(freeMusicId, m_isLine6Mode, m_isSimulationLive);
		}

		// // RVA: 0xB4688C Offset: 0xB4688C VA: 0xB4688C
		private void SetDefaultCategoryAndIndex()
		{
			for(int i = 0; i < m_filteredMusicDataList.Count; i++)
			{
				if(m_filteredMusicDataList[i].GetCount(m_isLine6Mode, m_isSimulationLive) > 0)
				{
					categoryId = i + 1;
					list_no = 0;
				}
			}
		}

		// // RVA: 0xB47CA4 Offset: 0xB47CA4 VA: 0xB47CA4
		private void OverrideEnemySkill()
		{
			for(int i = 0; i < m_originalMusicDataList.Count; i++)
			{
				IBJAKJJICBC.GNNIJFBOBAJ(m_originalMusicDataList[i].GetList(false, false));
				IBJAKJJICBC.GNNIJFBOBAJ(m_originalMusicDataList[i].GetList(true, false));
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2504 Offset: 0x6F2504 VA: 0x6F2504
		// // RVA: 0xB47DF0 Offset: 0xB47DF0 VA: 0xB47DF0
		private IEnumerator Co_ShowChangeMusicAlert()
		{
			KPJHLACKGJF_EventMission missionEventCtrl;

			//0x10402B4
			missionEventCtrl = m_eventCtrl as KPJHLACKGJF_EventMission;
			if(!missionEventCtrl.EGOJLOEFMOH_IsUpdateLimitedMusic && !missionEventCtrl.EEIKDIHGJAD_IsUpdateBonusSchedule)
			{
				yield break;
			}
			m_popMusicChangeAlertSetting.SetParent(transform);
			m_popMusicChangeAlertSetting.WindowSize = SizeType.Small;
			m_popMusicChangeAlertSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			m_popMusicChangeAlertSetting.TitleText = MessageManager.Instance.GetMessage("menu", missionEventCtrl.EGOJLOEFMOH_IsUpdateLimitedMusic ? "event_mission_changemusic_title" : "event_mission_changemusic_title2");
			bool isWait = true;
			m_popMusicChangeAlertSetting.DescType = missionEventCtrl.BCBCODAKIDN_DescType;
			m_popMusicChangeAlertSetting.isUpdateLimitedMusic = missionEventCtrl.EGOJLOEFMOH_IsUpdateLimitedMusic;
			m_popMusicChangeAlertSetting.isUpdateBonusSchedule = missionEventCtrl.EEIKDIHGJAD_IsUpdateBonusSchedule;
			m_popMusicChangeAlertSetting.isExclusionBonusMusic = missionEventCtrl.CGEAAEPEFIE_ExclusiveBonusMusic > 0;
			PopupWindowManager.Show(m_popMusicChangeAlertSetting, (PopupWindowControl control, PopupButton.ButtonType label, PopupButton.ButtonLabel type) =>
			{
				//0x1038890
				isWait = false;
			}, null, null, null, true, true, false);
			while(isWait)
				yield return null;
			missionEventCtrl.EGOJLOEFMOH_IsUpdateLimitedMusic = false;
			missionEventCtrl.EEIKDIHGJAD_IsUpdateBonusSchedule = false;
		}

		// // RVA: 0xB47E78 Offset: 0xB47E78 VA: 0xB47E78
		protected void OnChangeLineMode(int style)
		{
			MenuScene.Instance.RaycastDisable();
			m_isLine6Mode = style == 1;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.HPDBEKAGKOD_SetIsLine6(m_isLine6Mode);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			this.StartCoroutineWatched(Co_ChangeLiveMode(() =>
			{
				//0xB491E8
				if(currentMusicList.GetCount(m_isLine6Mode, false) > 0)
				{
					m_LayoutMissonSelect.SetMissionSetData(m_missionSetData, selectMusicData, m_isLine6Mode, diff);
				}
				MenuScene.Instance.RaycastEnable();
			}));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F257C Offset: 0x6F257C VA: 0x6F257C
		// // RVA: 0xB4809C Offset: 0xB4809C VA: 0xB4809C
		private IEnumerator Co_ChangeLiveMode(Action callback)
		{
			bool isPlaying;

			//0x10388C0
			if(m_currentStep == Step.MissionConfirm)
			{
				m_musicInfo.TryLeave();
			}
			else if(m_currentStep == Step.SelectMusicList)
			{
				m_musicInfo.TryLeave();
				m_cdSelect.TryLeave();
				m_cdArrow.TryLeave();
				m_buttonSet.TryLeave();
				m_eventBanner.TryLeave();
				m_seriesInfo.TryLeave();
				m_musicRate.TryLeave();
				m_filterButton.TryLeave();
				MenuScene.Instance.HelpButton.TryLeave();
			}
			isPlaying = true;
			while(isPlaying)
			{
				isPlaying = IsPlayingLayout();
				yield return null;
			}
			OnChangedSeries((FreeCategoryId.Type)categoryId);
			OnChangeMusicFilter(false);
			ApplyBasicInfo();
			if(m_currentStep == Step.MissionConfirm)
			{
				m_musicInfo.Enter();
			}
			else
			{
				m_musicInfo.Enter();
				m_cdSelect.Enter();
				m_cdArrow.Enter();
				m_buttonSet.Enter();
				m_eventBanner.Enter();
				m_seriesInfo.Enter();
				m_musicRate.Enter();
				m_filterButton.Enter();
				MenuScene.Instance.HelpButton.TryEnter();
			}
			isPlaying = true;
			while(isPlaying)
			{
				isPlaying = IsPlayingLayout();
				yield return null;
			}
			if(callback != null)
				callback();
		}

		// [DebuggerHiddenAttribute] // RVA: 0x6F2744 Offset: 0x6F2744 VA: 0x6F2744
		// [CompilerGeneratedAttribute] // RVA: 0x6F2744 Offset: 0x6F2744 VA: 0x6F2744
		// // RVA: 0xB491E0 Offset: 0xB491E0 VA: 0xB491E0
		// private void <>n__0() { }
	}
}
