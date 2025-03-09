using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Tutorial;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EventBattleScene : MusicSelectSceneBase
	{
		private MusicSelectEventInfo m_eventInfo; // 0xF8
		private MusicSelectBattleInfo m_battleInfo; // 0xFC
		private MusicSelectBattleMatch m_battleMatch; // 0x100
		private MusicSelectBattleLimit m_battleLimit; // 0x104
		private MusicSelectBattleExButton m_battleExButton; // 0x108
		private MusicSelectBattleExGauge m_battleExGauge; // 0x10C
		private EventTimeLimitMessage m_timeLimitMessage; // 0x110
		private MusicSelectLineButton m_lineButton; // 0x114
		private LayoutPopupExBattleScore m_ExBattleScore; // 0x118
		private LayoutPopupExBattleScoreTotal m_ExBattleScoreTotal; // 0x11C
		private LayoutBattleClassListWindow m_battleClassSelect; // 0x120
		private MusicDataList m_musicList; // 0x124
		private DivaIconDecoration m_selfDivaDeco; // 0x128
		private DivaIconDecoration m_rivalDivaDeco; // 0x12C
		private SceneIconDecoration m_selfSceneDeco; // 0x130
		private SceneIconDecoration m_rivalSceneDeco; // 0x134
		private bool m_isEventChecked; // 0x138
		private bool m_isMatched; // 0x139
		private bool m_isClassSelected; // 0x13A
		private ConfigMenu m_gameSettingMenu; // 0x13C

		protected override int musicListCount { get { return 1; } } //0xF0F120
		protected override MusicDataList currentMusicList { get {  return m_musicList;} } //0xF0F130
		protected override bool scrollIsClamp { get { return true; } } //0xF0F138

		// // RVA: 0xF0F128 Offset: 0xF0F128 VA: 0xF0F128 Slot: 32
		protected override MusicDataList GetMusicList(int i)
		{
			return m_musicList;
		}

		// RVA: 0xF0F140 Offset: 0xF0F140 VA: 0xF0F140 Slot: 5
		protected override void Start()
		{
			list_no = 0;
		}

		// RVA: 0xF0F14C Offset: 0xF0F14C VA: 0xF0F14C Slot: 16
		protected override void OnPreSetCanvas()
		{
			GameManager.Instance.SelectedGuestData = null;
			this.StartCoroutineWatched(Co_PreSetCanvas());
			m_gameSettingMenu = ConfigMenu.Create(null);
		}

		// RVA: 0xF0F2A0 Offset: 0xF0F2A0 VA: 0xF0F2A0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			if(isBgChanging || !m_isEventChecked)
				return false;
			m_musicInfo.Hide();
			m_cdSelect.Hide();
			m_cdArrow.Hide();
			m_buttonSet.Hide();
			m_eventBanner.Hide();
			m_eventInfo.Hide();
			m_battleInfo.Hide();
			m_battleMatch.Hide();
			m_battleLimit.Hide();
			m_battleExButton.Hide();
			m_battleExGauge.Hide();
			m_timeLimitMessage.Hide();
			m_lineButton.Hide();
			return base.IsEndPreSetCanvas();
		}

		// RVA: 0xF0F480 Offset: 0xF0F480 VA: 0xF0F480 Slot: 20
		protected override bool OnBgmStart()
		{
			if(!m_isEventTimeLimit)
			{
				if(!m_isMatched || !m_isClassSelected)
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

		// RVA: 0xF0F4FC Offset: 0xF0F4FC VA: 0xF0F4FC Slot: 9
		protected override void OnStartEnterAnimation()
		{
			if(!m_isEventTimeLimit)
			{
				m_eventBanner.Enter();
				if(IsEventEndChallengePeriod)
				{
					m_buttonSet.Enter();
					m_eventInfo.Enter();
					m_timeLimitMessage.Enter(IsEventCounting);
					return;
				}
				m_battleLimit.Enter();
				if(m_isMatched && m_isClassSelected)
				{
					m_buttonSet.Enter();
					m_musicInfo.Enter();
					m_eventInfo.Enter();
					m_cdSelect.Enter();
					m_cdArrow.Enter();
					m_battleInfo.Enter();
					m_battleExButton.Enter();
					m_battleExGauge.Enter();
					if(currentMusicList.GetCount(true, false) > 0)
					{
						m_lineButton.Enter(m_isLine6Mode);
					}
				}
			}
		}

		// RVA: 0xF0F770 Offset: 0xF0F770 VA: 0xF0F770 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			return !m_musicInfo.IsPlaying() && !m_cdSelect.IsPlaying() && !m_cdArrow.IsPlaying() && !m_buttonSet.IsPlaying() && !m_eventBanner.IsPlaying() && 
				!m_eventInfo.IsPlaying() && !m_battleInfo.IsPlaying() && !m_battleLimit.IsPlaying() && !m_battleExButton.IsPlaying() && !m_battleExGauge.IsPlaying() && 
				!m_timeLimitMessage.IsPlaying() && !m_lineButton.IsPlaying();
		}

		// RVA: 0xF0F964 Offset: 0xF0F964 VA: 0xF0F964 Slot: 12
		protected override void OnStartExitAnimation()
		{
			if(!m_isEventTimeLimit)
			{
				m_buttonSet.TryLeave();
				m_musicInfo.TryLeave();
				m_eventInfo.TryLeave();
				m_eventBanner.TryLeave();
				m_timeLimitMessage.TryLeave();
				m_cdSelect.TryLeave();
				m_cdArrow.TryLeave();
				m_battleInfo.TryLeave();
				m_battleLimit.TryLeave();
				m_battleExButton.TryLeave();
				m_battleExGauge.TryLeave();
				m_battleClassSelect.TryLeave();
				m_lineButton.TryLeave();
			}
		}

		// RVA: 0xF0FB20 Offset: 0xF0FB20 VA: 0xF0FB20 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			return !m_musicInfo.IsPlaying() && !m_cdSelect.IsPlaying() && !m_cdArrow.IsPlaying() && !m_buttonSet.IsPlaying() && !m_eventBanner.IsPlaying() && 
				!m_eventInfo.IsPlaying() && !m_battleInfo.IsPlaying() && !m_battleLimit.IsPlaying() && !m_battleExButton.IsPlaying() && !m_battleExGauge.IsPlaying() && 
				!m_timeLimitMessage.IsPlaying() && !m_lineButton.IsPlaying();
		}

		// RVA: 0xF0FD14 Offset: 0xF0FD14 VA: 0xF0FD14 Slot: 51
		protected override void OnDecideCurrentMusic()
		{
			m_overrideEnemyCenterSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.DCOALMMJDJK_CenterSkill;
			m_overrideEnemyLiveSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.KKPLDFNDFDE_LiveSkill;
			base.OnDecideCurrentMusic();
		}

		// RVA: 0xF0FEA4 Offset: 0xF0FEA4 VA: 0xF0FEA4 Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_battleClassSelect != null)
			{
				Destroy(m_battleClassSelect.gameObject);
				m_battleClassSelect = null;
			}
		}

		// RVA: 0xF0FF9C Offset: 0xF0FF9C VA: 0xF0FF9C Slot: 14
		protected override void OnDestoryScene()
		{
			base.OnDestoryScene();
			m_gameSettingMenu.Dispose();
		}

		// RVA: 0xF0FFD4 Offset: 0xF0FFD4 VA: 0xF0FFD4 Slot: 35
		protected override void CheckTryInstall()
		{
			return;
		}

		// // RVA: 0xF0FFD8 Offset: 0xF0FFD8 VA: 0xF0FFD8
		// private void TryInstall() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EDB9C Offset: 0x6EDB9C VA: 0x6EDB9C
		// // RVA: 0xF100B4 Offset: 0xF100B4 VA: 0xF100B4
		private IEnumerator Co_Save()
		{
			//0x1060678
			MenuScene.Instance.RaycastDisable();
			bool done = false;
			bool err = false;
			MenuScene.Save(() =>
			{
				//0x105603C
				done = true;
			}, () =>
			{
				//0x1056048
				done = true; // Fix umo
				err = true;
			});
			while(!done)
				yield return null;
			MenuScene.Instance.RaycastEnable();
			if(err)
			{
				MenuScene.Instance.GotoTitle();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDC14 Offset: 0x6EDC14 VA: 0x6EDC14
		// // RVA: 0xF10124 Offset: 0xF10124 VA: 0xF10124 Slot: 36
		protected override IEnumerator Co_Initialize()
		{
			//0x1059E80
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
				//0x105605C
				done = true;
			}, () =>
			{
				//0x1056068
				done = true;
				err = true;
			});
			while(!done)
				yield return null;
			if(err)
			{
				m_isInitialized = true;
				GotoTitle();
				yield break;
			}
			done = false;
			err = false;
			JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.LFOBIPKFOEF(OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle, 0, () =>
			{
				//0x1056074
				done = true;
			}, () =>
			{
				//0x1056080
				done = true;
				err = true;
			}, false);
			while(!done)
				yield return null;
			if(err)
			{
				m_isInitialized = true;
				GotoTitle();
				yield break;
			}
			done = false;
			err = false;
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0x105608C
				done = true;
			}, () =>
			{
				//0x1056098
				done = true;
				err = true;
			}, null);
			while(!done)
				yield return null;
			if(err)
			{
				m_isInitialized = true;
				GotoTitle();
				yield break;
			}
			CrateQuestList();
			CreateSnsList();
			SetupHelp();
			m_cdSelect.transform.SetAsLastSibling();
			m_cdArrow.transform.SetAsLastSibling();
			m_battleInfo.transform.SetAsLastSibling();
			m_battleExButton.transform.SetAsLastSibling();
			m_musicInfo.transform.SetAsLastSibling();
			m_buttonSet.transform.SetAsLastSibling();
			m_eventInfo.transform.SetAsLastSibling();
			m_eventBanner.transform.SetAsLastSibling();
			m_battleLimit.transform.SetAsLastSibling();
			m_battleMatch.transform.SetAsLastSibling();
			m_timeLimitMessage.transform.SetAsLastSibling();
			m_lineButton.transform.SetAsLastSibling();
			m_musicInfo.onChangedDifficulty = OnSelectedDifficulty;
			m_cdSelect.onClickFlowButton = OnClickFlowButton;
			m_cdSelect.onSelectionChanged = OnSelectionChanged;
			m_cdSelect.onScrollRepeated = OnScrollRepeated;
			m_cdSelect.onScrollStarted = OnScrollStarted;
			m_cdSelect.onScrollUpdated = OnScrollUpdated;
			m_cdSelect.onScrollEnded = OnScrollEnded;
			m_cdSelect.onClickPlayButton = null;
			m_buttonSet.onClickRankingButton = OnClickRankingButton;
			m_buttonSet.onClickRewardButton = OnClickRewardButton;
			m_buttonSet.onClickDetailButton = OnClickDetailButton;
			m_buttonSet.onClickEventRankingButton = OnClickEventRankingButton;
			m_buttonSet.onClickEventRewardButton = OnClickEventRewardButton;
			m_buttonSet.onClickEnemyInfoButton = OnClickEnemyInfoButton;
			m_buttonSet.onClickStoryButton = OnClickStoryButton;
			m_buttonSet.onClickMissionButton = OnClickMissionButton;
			m_battleInfo.onClickPlayButton = OnClickPlayButton;
			m_battleExButton.onClickHiScore = OnClickExBattleScore;
			m_battleExButton.onClickReSelect = OnClickSelectClassButton;
			m_lineButton.onClickButton = OnChangeLineMode;
			InitializeDecos();
			m_musicInfo.MakeCache();
			m_cdSelect.MakeCache();
            MessageBank bk = MessageManager.Instance.GetBank("menu");
        	m_musicInfo.SetNoInfoMessage(bk.GetMessageByLabel("music_not_exist_text_00"), bk.GetMessageByLabel("music_not_exist_line6_text_00"));
			m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N4, false, false);
			m_musicInfo.ChangeSelectedDiff(Difficulty.Type.Normal);
			m_eventInfo.SetStyle(MusicSelectEventInfo.Style.Battle);
			m_eventInfo.SetCurrentValueLabel(bk.GetMessageByLabel("music_event_battle_current_point_label"));
			m_eventInfo.SetNextValueLabel(bk.GetMessageByLabel("music_event_battle_next_point_label"));
			m_eventInfo.SetValueUnitLabel(bk.GetMessageByLabel("music_event_battle_point_unit"));
			m_eventInfo.SetRewardLabel(bk.GetMessageByLabel("music_event_battle_reward_label"));
			m_eventInfo.SetRankUnitLabel(bk.GetMessageByLabel("music_event_battle_rank_unit"), 0);
			m_eventInfo.SetRankUnitLabel(bk.GetMessageByLabel("music_event_battle_rank_unit"), 1);
			if(IsEventEndChallengePeriod)
			{
				m_eventInfo.SetRankLabel(bk.GetMessageByLabel("music_event_battle_rank_total_counting_label"), 0);
				m_eventInfo.SetRankLabel(bk.GetMessageByLabel("music_event_battle_rank_hiscore_counting_label"), 1);
			}
			else
			{
				m_eventInfo.SetRankLabel(bk.GetMessageByLabel("music_event_battle_rank_total_label"), 0);
				m_eventInfo.SetRankLabel(bk.GetMessageByLabel("music_event_battle_rank_hiscore_label"), 1);
			}
			m_eventInfo.SetBpValueLabel(bk.GetMessageByLabel("music_event_battle_bp_counting_label"));
			m_eventInfo.SetBpValueUnitLabel(bk.GetMessageByLabel("music_event_battle_bp_unit"));
			HAEDCCLHEMN_EventBattle btlEv = m_eventCtrl as HAEDCCLHEMN_EventBattle;
			if(btlEv.KCHPPLMMDGD_GetStep() == OKMHOFEJPCF.CBOHLHCMGJJ_Steps.OLCLJKOKJCD_7)
			{
				m_isMatched = true;
				m_isClassSelected = true;
			}
			else
			{
				m_isMatched = btlEv.KCHPPLMMDGD_GetStep() == OKMHOFEJPCF.CBOHLHCMGJJ_Steps.CNLOFIHPBMP_4 && btlEv.KKMFHMGIIKN_GetCls() > 0;
				m_isClassSelected = btlEv.KKMFHMGIIKN_GetCls() > 0;
			}
			if(IsEventEndChallengePeriod)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				m_overrideButtonStyle = MusicSelectButtonSet.OptionStyle.EndEventHome;
				m_musicList = new MusicDataList(IBJAKJJICBC.GCCBCAKFJMF(5, t, m_eventCtrl.PGIIDPEGGPI_EventId, false), IBJAKJJICBC.GCCBCAKFJMF(5, t, m_eventCtrl.PGIIDPEGGPI_EventId, true));
				list_no = 0;
				m_isMatched = true;
				m_isLine6Mode = false;
			}
			else
			{
				if(m_isMatched)
				{
					long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
                    List<IBJAKJJICBC> l = IBJAKJJICBC.EHNABCEGAHO(t, false, false);
                    m_musicList = new MusicDataList(l, IBJAKJJICBC.EHNABCEGAHO(t, false, true));
					OverrideEnemySkill();
					m_initParam.isDisableBattleEventIntermediateResult = !GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KPFAFLBICLA_IsNotBattleEventInfo;
					diff = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.MFFAIIDJPBL_BattleEvent.FFACBDAJJJP_GetDifficulty();
					yield return this.StartCoroutineWatched(Co_BattleAssetDownLoad(l));
				}
				else
				{
					m_musicList = new MusicDataList();
				}
			}
			//LAB_0105b8a0
			m_lineButton.SetUnlock(IBJAKJJICBC.KGJJCAKCMLO());
			m_lineButton.SetUnlockNumber(IBJAKJJICBC.POPLHDKHIIM());
			ApplyBasicInfo();
			if(m_isMatched)
			{
				ApplyMusicListInfo();
				ApplyMusicInfo();
			}
			ApplyEventInfo();
			Database.Instance.bonusData.SetEpisodeBonus(m_eventCtrl.LMDENICBIIB_GetEpisodesBonusList(0, 0));
			m_isInitialized = true;
		}

		// RVA: 0xF101AC Offset: 0xF101AC VA: 0xF101AC Slot: 38
		protected override PlayButtonWrapper CreatePlayButtonWrapper()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene CreatePlayButtonWrapper");
			return null;
		}

		// RVA: 0xF1022C Offset: 0xF1022C VA: 0xF1022C Slot: 39
		protected override void Release()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene Release");
		}

		// RVA: 0xF10300 Offset: 0xF10300 VA: 0xF10300 Slot: 40
		protected override void SetupViewMusicData()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene SetupViewMusicData");
		}

		// RVA: 0xF10450 Offset: 0xF10450 VA: 0xF10450 Slot: 41
		protected override void ApplyBasicInfo()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "MusicSelectScene* ApplyBasicInfo");
		}

		// RVA: 0xF1048C Offset: 0xF1048C VA: 0xF1048C Slot: 42
		protected override void ApplyMusicListInfo()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "MusicSelectScene* ApplyMusicListInfo");
		}

		// RVA: 0xF104F4 Offset: 0xF104F4 VA: 0xF104F4 Slot: 44
		protected override void DelayedApplyMusicInfo()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene DelayedApplyMusicInfo");
		}

		// RVA: 0xF10658 Offset: 0xF10658 VA: 0xF10658 Slot: 46
		protected override void ApplyMusicInfoBasic(IBJAKJJICBC musicData)
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene ApplyMusicInfoBasic");
		}

		// // RVA: 0xF117A8 Offset: 0xF117A8 VA: 0xF117A8
		private void ApplyEventInfo()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene ApplyEventInfo");
		}

		// RVA: 0xF121FC Offset: 0xF121FC VA: 0xF121FC Slot: 52
		protected override void LeaveForScrollStart()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene LeaveForScrollStart");
		}

		// RVA: 0xF12254 Offset: 0xF12254 VA: 0xF12254 Slot: 53
		// protected override void EnterForScrollEnd() { }

		// RVA: 0xF122AC Offset: 0xF122AC VA: 0xF122AC Slot: 54
		protected override void OnChangedDifficulty()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene OnChangedDifficulty");
		}

		// // RVA: 0xF123E4 Offset: 0xF123E4 VA: 0xF123E4
		private void InitializeDecos()
		{
			m_selfDivaDeco = new DivaIconDecoration(m_battleInfo.GetSelfDivaIconObject(), DivaIconDecoration.Size.S, true, false, null, null);
			m_rivalDivaDeco = new DivaIconDecoration(m_battleInfo.GetRivalDivaIconObject(), DivaIconDecoration.Size.S, true, false, null, null);
			m_selfSceneDeco = new SceneIconDecoration(m_battleInfo.GetSelfSceneIconObject(), SceneIconDecoration.Size.M, null, null);
			m_rivalSceneDeco = new SceneIconDecoration(m_battleInfo.GetRivalSceneIconObject(), SceneIconDecoration.Size.M, null, null);
		}

		// // RVA: 0xF10280 Offset: 0xF10280 VA: 0xF10280
		// private void ReleaseDecos() { }

		// // RVA: 0xF108D8 Offset: 0xF108D8 VA: 0xF108D8
		private void ApplyBattleInfo(IBJAKJJICBC musicData)
		{
			HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
			{
				bool isKira = false;
				int sceneId = 0;
				int rank = 0;
				GCIJNCFDNON_SceneInfo scene = null;
				if(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId > 0)
				{
					sceneId = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId;
					scene = GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[sceneId - 1];
					rank = scene.CGIELKDLHGE_GetEvolveId();
					isKira = scene.MBMFJILMOBP_IsKira();
				}
				m_battleInfo.ApplySelfTitle(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName);
				GameManager.Instance.DivaIconCache.Load(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId, 
					GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, 
					GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].EKFONBFDAAP_ColorId, m_battleInfo.ApplySelfDivaIcon);
				GameManager.Instance.SceneIconCache.Load(sceneId, rank, (IiconTexture texture) =>
				{
					//0x10560AC
					m_battleInfo.ApplySelfSceneIcon(texture, isKira);
				});
				m_selfDivaDeco.SetActive(true);
				m_selfDivaDeco.Change(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0], GameManager.Instance.ViewPlayerData, DisplayType.Level);
				m_selfSceneDeco.SetActive(true);
				m_selfSceneDeco.Change(scene, DisplayType.Level);
			}
			{
				bool isKira = false;
				int sceneId = 0;
				int rank = 0;
				if(musicData.DACLONHOFLA.AFBMEMCHJCL_Scene != null)
				{
					sceneId = musicData.DACLONHOFLA.AFBMEMCHJCL_Scene.BCCHOBPJJKE_SceneId;
					rank = musicData.DACLONHOFLA.AFBMEMCHJCL_Scene.CGIELKDLHGE_GetEvolveId();
					isKira = musicData.DACLONHOFLA.AFBMEMCHJCL_Scene.MBMFJILMOBP_IsKira();
				}
				int str = musicData.DACLONHOFLA.BHCIFFILAKJ_Str;
				if(str > 2)
					str = 3;
				ev.ECFNKBGDJCA(list_no, musicData.DACLONHOFLA.OIPCCBHIKIA_RivalIdx, musicData.DACLONHOFLA.BHCIFFILAKJ_Str);
				m_battleInfo.ApplyRivalRank((MusicSelectBattleInfo.RivalRankType)musicData.DACLONHOFLA.BHCIFFILAKJ_Str);
				m_battleInfo.ApplyRivalTitle(musicData.DACLONHOFLA.OPFGFINHFCE_Name);
				m_battleInfo.ApplyRivalScore(ev.HOJNMALLCME_GetClassMaxScore(musicData.DACLONHOFLA.BHCIFFILAKJ_Str, 0));
				GameManager.Instance.DivaIconCache.Load(musicData.DACLONHOFLA.FDBOPFEOENF_RivalData.AHHJLDLAPAN_DivaId, 
					musicData.DACLONHOFLA.FDBOPFEOENF_RivalData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, 
					musicData.DACLONHOFLA.FDBOPFEOENF_RivalData.EKFONBFDAAP_ColorId, m_battleInfo.ApplyRivalDivaIcon);
				GameManager.Instance.SceneIconCache.Load(sceneId, rank, (IiconTexture texture) =>
				{
					//0x1056110
					m_battleInfo.ApplyRivalSceneIcon(texture, isKira);
				});
				m_rivalDivaDeco.SetActive(true);
				m_rivalDivaDeco.Change(musicData.DACLONHOFLA.FDBOPFEOENF_RivalData, DisplayType.Level);
				m_rivalSceneDeco.SetActive(true);
				m_rivalSceneDeco.Change(musicData.DACLONHOFLA.AFBMEMCHJCL_Scene, DisplayType.Level);
				m_battleExGauge.Setup(ev.HEOGGKBILIA_GetCurrentClassEmblemId(), ev.NJDPMDCIFBP_GetResultPoint(musicData.DACLONHOFLA.BHCIFFILAKJ_Str, true), ev.NJDPMDCIFBP_GetResultPoint(musicData.DACLONHOFLA.BHCIFFILAKJ_Str, false), ev.GGBNNMCLDMO_GetExPoint(), 100);
				if(m_eventTicketId < 1)
				{
					m_battleInfo.SetDropIconType(false);
				}
				else
				{
					m_battleInfo.SetDropIconType(true);
					GameManager.Instance.ItemTextureCache.Load(m_eventTicketId, m_battleInfo.ApplyDropItemIcon);
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDC8C Offset: 0x6EDC8C VA: 0x6EDC8C
		// // RVA: 0xF0F218 Offset: 0xF0F218 VA: 0xF0F218
		private IEnumerator Co_PreSetCanvas()
		{
			//0x105FCA4
			EventMusicSelectSceneArgs EventArg = Args as EventMusicSelectSceneArgs;
			EventMusicSelectSceneArgs EventArgsReturn = ArgsReturn as EventMusicSelectSceneArgs;
			m_isEventTimeLimit = false;
			m_isEventChecked = false;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_eventCtrl = null;
			if(EventArg == null)
			{
				if(EventArgsReturn != null)
				{
					m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(EventArgsReturn.EventUniqueId);
					m_isLine6Mode = EventArgsReturn.isLine6Mode;
				}
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(m_eventId);
			}
			else
			{
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(EventArg.EventUniqueId);
				m_isLine6Mode = EventArg.isFromRhythmGame && EventArg.isLine6Mode;
			}
			if(m_eventCtrl != null)
			{
				m_eventCtrl.HCDGELDHFHB_UpdateStatus(t);
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
				HAEDCCLHEMN_EventBattle evBtl = m_eventCtrl as HAEDCCLHEMN_EventBattle;
				if(evBtl != null)
				{
					for(int i = 0; i < evBtl.CJOBENJJCLD(); i++)
					{
						int embl = evBtl.IECGGHJHJGB_GetClassEmblemId(i);
						if(embl > 0)
						{
							GameManager.Instance.ItemTextureCache.TryInstallEmblem(embl);
						}
					}
					while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
						yield return null;
				}
				//LAB_01060444
				m_isEventChecked = false;
				base.OnPreSetCanvas();
				yield break;
			}
			GameManager.Instance.fullscreenFader.Fade(0, Color.black);
			while(!PopupWindowManager.IsActivePopupWindow())
				yield return null;
			while(PopupWindowManager.IsActivePopupWindow())
				yield return null;
			AutoFadeFlag = false;
			m_isEventTimeLimit = true;
			m_isEventChecked = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDD04 Offset: 0x6EDD04 VA: 0x6EDD04
		// // RVA: 0xF125B0 Offset: 0xF125B0 VA: 0xF125B0 Slot: 55
		protected override IEnumerator Co_LoadLayout()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene Co_LoadLayout");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDD7C Offset: 0x6EDD7C VA: 0x6EDD7C
		// // RVA: 0xF12638 Offset: 0xF12638 VA: 0xF12638 Slot: 56
		protected override IEnumerator Co_WaitForLoaded()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventBattleScene Co_WaitForLoaded");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDDF4 Offset: 0x6EDDF4 VA: 0x6EDDF4
		// // RVA: 0xF126C0 Offset: 0xF126C0 VA: 0xF126C0 Slot: 57
		protected override IEnumerator Co_WaitForAnimEnd(Action onEnd)
		{
			//0x1062C20
			while(m_eventInfo.IsPlaying())
				yield return null;
			while(m_battleInfo.IsPlaying())
				yield return null;
			while(m_battleLimit.IsPlaying())
				yield return null;
			while(m_battleExButton.IsPlaying())
				yield return null;
			while(m_battleExGauge.IsPlaying())
				yield return null;
			while(m_battleClassSelect.IsPlaying())
				yield return null;
			yield return Co.R(base.Co_WaitForAnimEnd(onEnd));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDE6C Offset: 0x6EDE6C VA: 0x6EDE6C
		// // RVA: 0xF12764 Offset: 0xF12764 VA: 0xF12764 Slot: 37
		protected override IEnumerator Co_OnActivateScene()
		{
			//0x105E5C4
			m_isEndActivateScene = false;
			if(m_isEventTimeLimit)
			{
				m_isEndActivateScene = true;
				yield break;
			}
			MenuScene.Instance.RaycastDisable();
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_ShowReciveLoginAchievement());
			}
			if(!MenuScene.Instance.DirtyChangeScene && m_isShowFirstHelp)
			{
				yield return Co.R(Co_ShowHelp());
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_Show_LoginBonusPopup(null));
			}
			if(!MenuScene.Instance.DirtyChangeScene && TutorialProc.CanBeginnerMissionLiveClearLiveHelp())
			{
				MenuScene.Instance.RaycastEnable();
				yield return Co.R(TutorialProc.Co_BeginnerMissionLiveClear(m_cdSelect, null));
				MenuScene.SaveRequest();
				//LAB_0105eb84
				m_isEndActivateScene = true;
				yield break;
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(KDHGBOOECKC.HHCJCDFCLOB.LOCAIBNPKDL_IsPlayerLevelOk() && !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.MLBBKNLPBBD_HasShowTuto(BOPFPIHGJMD.PDLKAKEABDP.EILIAPKFCEO_0))
				{
					MenuScene.Instance.RaycastEnable();
					yield return Co.R(TutorialProc.Co_OffeReleaseTutorial(InputLimitButton.VOP, MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.VOP), () =>
					{
						//0x1055EA4
						return;
					}, BasicTutorialMessageId.Id_OfferRelease, true, m_cdSelect, null));
					//LAB_0105eb84
					m_isEndActivateScene = true;
					yield break;
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(SettingMenuPanel.IsValkyrieTuneUpUnlock() && !CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ADKJDHPEAJH(Common.GPFlagConstant.ID.IsValkyrieUpgrade))
				{
					MenuScene.Instance.RaycastEnable();
					yield return Co.R(TutorialProc.Co_ValkyrieUpgrade(MenuScene.Instance.FooterMenu.FindButton(MenuFooterControl.Button.Setting), BasicTutorialMessageId.Id_ValkyrieUpgradeHome, InputLimitButton.Setting, TutorialPointer.Direction.Down, m_cdSelect, null));
					//LAB_0105eb84
					m_isEndActivateScene = true;
					yield break;
				}
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_CheckUnlock(null));
			}
			m_isEndActivateScene = true;
			PMFBBLGPLLJ p = new PMFBBLGPLLJ();
			p.KHEKNNFCAOI();
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_UnlockedClass(p));
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				yield return Co.R(Co_Matching());
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				if(CanDoUnitDanceFocus(false))
				{
					yield return Co.R(TryShowUnitDanceTutorial());
				}
				yield return Co.R(TryShowExRivalTutorial());
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				AddNotice(() =>
				{
					//0xF1382C
					CheckSnsNotice();
				});
			}
			if(!MenuScene.Instance.DirtyChangeScene)
			{
				AddNotice(() =>
				{
					//0xF13834
					CheckOfferNotice();
				});
			}
			ShowNotice();
			MenuScene.Instance.RaycastEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDEE4 Offset: 0x6EDEE4 VA: 0x6EDEE4
		// // RVA: 0xF127EC Offset: 0xF127EC VA: 0xF127EC
		private IEnumerator Co_UnlockedClass(PMFBBLGPLLJ viewSelectData)
		{
			MessageBank msgBank; // 0x1C
			List<IHGLIHBAOII> list; // 0x20

			//0x1061854
			msgBank = MessageManager.Instance.GetBank("menu");
			list = viewSelectData.LHDNIHOAMFH(0, 0);
			if(list.Count > 0)
			{
				string s2;
				if(list.Count < 3)
				{
					s2 = msgBank.GetMessageByLabel("music_event_battle_class_get_emblem_01");
				}
				else
				{
					s2 = msgBank.GetMessageByLabel("music_event_battle_class_get_emblem_02");
				}
				PopupItemGetSetting s = new PopupItemGetSetting();
				s.TitleText = msgBank.GetMessageByLabel("popup_ar_marker_emblem_title");
				s.WindowSize = Common.SizeType.Middle;
				s.ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem, list[1].MDPKLNFFDBO_EmblemId);
				s.ItemContent = RichTextUtility.MakeColorTagString(string.Format(s2, list[1].GIDPPGJPOJA), SystemTextColor.NormalColor);
				s.IsPresentBox = false;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Type = PopupButton.ButtonType.Positive, Label = PopupButton.ButtonLabel.Ok }
				};
				bool isClosed = false;
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1055EA8
					return;
				}, null, null, null, true, true, false, null, () =>
				{
					//0x10572EC
					isClosed = true;
				}, (PopupWindowControl.SeType seType) =>
				{
					//0x1055EAC
					if(seType != PopupWindowControl.SeType.WindowOpen)
						return false;
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_004);
					return true;
				});
				yield return new WaitWhile(() =>
				{
					//0x10572F8
					return !isClosed;
				});
				yield return Co.R(Co_Save());
				bool isChallengeNewClass = false;
				HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
				if(list.Count > 0)
				{
					if(list[0].GIDPPGJPOJA != ev.KKMFHMGIIKN_GetCls())
					{
						PopupClassUnlockSetting s4 = new PopupClassUnlockSetting();
						s4.View = list[0];
						s4.WindowSize = SizeType.Small;
						s4.IsCaption = false;
						isClosed = false;
						s4.Buttons = new ButtonInfo[2]
						{
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
							new ButtonInfo() { Label = PopupButton.ButtonLabel.Challenge, Type = PopupButton.ButtonType.Positive },
						};
						PopupWindowManager.Show(s4, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
						{
							//0x10572D4
							if(label == PopupButton.ButtonLabel.Challenge)
								isChallengeNewClass = true;
						}, null, null, null, true, true, false, null, () =>
						{
							//0x1057314
							isClosed = true;
						}, (PopupWindowControl.SeType seType) =>
						{
							//0x1055F18
							if(seType != PopupWindowControl.SeType.WindowOpen)
								return false;
							SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_004);
							return true;
						});
						yield return new WaitWhile(() =>
						{
							//0x1057320
							return !isClosed;
						});
						if(IsEventEndChallengePeriod)
						{
							TextPopupSetting s3 = PopupWindowManager.CrateTextContent(msgBank.GetMessageByLabel("popup_event_end_title"), SizeType.Small, msgBank.GetMessageByLabel("popup_event_end_text_3"), 
								new ButtonInfo[1] { new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive } }, false, true);
							PopupWindowManager.Show(s3, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
							{
								//0x1055F84
								return;
							}, null, null, null, true, true, false);
							//LAB_01061fd0
						}
						//LAB_01061fd0
					}
					//LAB_01061fd0
				}
				//LAB_01061fd0
				if(!IsEventEndChallengePeriod)
				{
					if(isChallengeNewClass)
					{
						yield return Co.R(Co_ChallengeNewClass(viewSelectData));
					}
					if(!m_isClassSelected)
					{
						MenuScene.Instance.RaycastEnable();
						yield return Co.R(Co_SelectClass(viewSelectData));
						MenuScene.Instance.RaycastDisable();
					}
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDF5C Offset: 0x6EDF5C VA: 0x6EDF5C
		// // RVA: 0xF12890 Offset: 0xF12890 VA: 0xF12890
		private IEnumerator Co_SelectClass(PMFBBLGPLLJ viewSelectData)
		{
			//0x10609F4
			MenuScene.Instance.RaycastDisable();
			m_battleClassSelect.Setup(viewSelectData, true);
			m_eventInfo.TryEnter();
			m_battleClassSelect.TryEnter();
			MenuScene.Instance.HelpButton.TryEnter();
			m_musicInfo.TryLeave();
			m_battleInfo.TryLeave();
			m_buttonSet.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_battleExButton.TryLeave();
			m_battleExGauge.TryLeave();
			m_lineButton.TryLeave();
			MenuScene.Instance.HeaderMenu.Leave(false);
			while(m_battleClassSelect.IsPlaying())
				yield return null;
			while(m_eventInfo.IsPlaying())
				yield return null;
			while(m_musicInfo.IsPlaying())
				yield return null;
			while(m_battleInfo.IsPlaying())
				yield return null;
			while(m_buttonSet.IsPlaying())
				yield return null;
			while(m_cdSelect.IsPlaying())
				yield return null;
			while(m_battleExButton.IsPlaying())
				yield return null;
			while(m_battleExGauge.IsPlaying())
				yield return null;
			while(m_lineButton.IsPlaying())
				yield return null;
			MenuScene.Instance.RaycastEnable();
			ChangeTrialMusic(m_eventCtrl.EDNMFMBLCGF_GetWavId());
			bool isClosed = false;
			bool isUpdate = false;
			m_battleClassSelect.OnSelectEvent = (IHGLIHBAOII viewClassData) =>
			{
				//0x105733C
				if(MenuScene.CheckDatelineAndAssetUpdate())
					isUpdate = true;
				HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
				ev.HGCIBMLAAMI_SetClsAndResetExPoint(viewClassData.AIMCAJDBNOI);
				isClosed = true;
			};
			yield return new WaitWhile(() =>
			{
				//0x1057550
				return !isClosed;
			});
			m_battleClassSelect.TryLeave();
			while(isUpdate)
				yield return null;
			m_isMatched = false;
			yield return Co.R(Co_Matching());
			m_musicInfo.TryEnter();
			m_battleInfo.TryEnter();
			m_buttonSet.TryEnter();
			m_cdSelect.TryEnter();
			m_cdArrow.TryEnter();
			m_battleExButton.TryEnter();
			m_battleExGauge.TryEnter();
			if(currentMusicList.GetCount(true, false) > 0)
			{
				m_lineButton.TryEnter(m_isLine6Mode);
			}
			MenuScene.Instance.HelpButton.TryEnter();
			MenuScene.Instance.HeaderMenu.Enter(false);
			while(m_battleClassSelect.IsPlaying())
				yield return null;
			while(m_musicInfo.IsPlaying())
				yield return null;
			while(m_battleInfo.IsPlaying())
				yield return null;
			while(m_buttonSet.IsPlaying())
				yield return null;
			while(m_cdSelect.IsPlaying())
				yield return null;
			while(m_battleExButton.IsPlaying())
				yield return null;
			while(m_battleExGauge.IsPlaying())
				yield return null;
			while(m_lineButton.IsPlaying())
				yield return null;
			if(CanDoUnitDanceFocus(false))
			{
				yield return Co.R(TryShowUnitDanceTutorial());
			}
			yield return Co.R(TryShowExRivalTutorial());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDFD4 Offset: 0x6EDFD4 VA: 0x6EDFD4
		// // RVA: 0xF12934 Offset: 0xF12934 VA: 0xF12934
		private IEnumerator Co_ChallengeNewClass(PMFBBLGPLLJ viewSelectData)
		{
			//0x1058098
			m_eventInfo.TryLeave();
			m_musicInfo.TryLeave();
			m_battleInfo.TryLeave();
			m_buttonSet.TryLeave();
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_battleExButton.TryLeave();
			m_battleExGauge.TryLeave();
			MenuScene.Instance.HelpButton.TryLeave();
			MenuScene.Instance.HeaderMenu.Leave(false);
			while(m_eventInfo.IsPlaying())
				yield return null;
			while(m_musicInfo.IsPlaying())
				yield return null;
			while(m_battleInfo.IsPlaying())
				yield return null;
			while(m_buttonSet.IsPlaying())
				yield return null;
			while(m_cdSelect.IsPlaying())
				yield return null;
			while(m_battleExButton.IsPlaying())
				yield return null;
			while(m_battleExGauge.IsPlaying())
				yield return null;
			if(MenuScene.CheckDatelineAndAssetUpdate())
			{
				while(true)
					yield return null;
			}
			List<IHGLIHBAOII> l = viewSelectData.KBHCHFDAHGL();
			int v = 0;
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].MNAKKLEJBFG_IsUnlocked)
				{
					v = l[i].AIMCAJDBNOI;
					break;
				}
			}
			HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
			ev.HGCIBMLAAMI_SetClsAndResetExPoint(v);
			m_isMatched = false;
			yield return Co.R(Co_Matching());
			m_eventInfo.TryEnter();
			m_musicInfo.TryEnter();
			m_battleInfo.TryEnter();
			m_buttonSet.TryEnter();
			m_cdSelect.TryEnter();
			m_cdArrow.TryEnter();
			m_battleExButton.TryEnter();
			m_battleExGauge.TryEnter();
			MenuScene.Instance.HelpButton.TryEnter();
			MenuScene.Instance.HeaderMenu.Enter(false);
			while(m_eventInfo.IsPlaying())
				yield return null;
			while(m_musicInfo.IsPlaying())
				yield return null;
			while(m_battleInfo.IsPlaying())
				yield return null;
			while(m_buttonSet.IsPlaying())
				yield return null;
			while(m_cdSelect.IsPlaying())
				yield return null;
			while(m_battleExButton.IsPlaying())
				yield return null;
			while(m_battleExGauge.IsPlaying())
				yield return null;
			if(CanDoUnitDanceFocus(false))
			{
				yield return Co.R(TryShowUnitDanceTutorial());
			}
			yield return Co.R(TryShowExRivalTutorial());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EE04C Offset: 0x6EE04C VA: 0x6EE04C
		// // RVA: 0xF129D8 Offset: 0xF129D8 VA: 0xF129D8
		private IEnumerator Co_Matching()
		{
			//0x105D73C
			if(m_isMatched)
				yield break;
			m_battleMatch.Enter();
			MenuScene.Instance.HelpButton.TryLeave();
			MenuScene.Instance.HeaderMenu.Leave(false);
			MenuScene.Instance.FooterMenu.Leave(false);
			bool done = false;
			bool err = false;
			(m_eventCtrl as HAEDCCLHEMN_EventBattle).MPPGMNOOGIL_Matching(() =>
			{
				//0x105756C
				done = true;
			}, () =>
			{
				//0x1057578
				done = true;
				err = true;
			});
			while(m_battleMatch.IsPlaying())
				yield return null;
			m_battleMatch.Active();
			while(!done)
				yield return null;
			if(err)
			{
				MenuScene.Instance.InputEnable();
				MenuScene.Instance.GotoTitle();
				yield break;
			}
			m_isMatched = true;
			m_battleMatch.Leave();
			while(m_battleMatch.IsPlaying())
				yield return null;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			List<IBJAKJJICBC> l = IBJAKJJICBC.EHNABCEGAHO(t, false, false);
			m_musicList = new MusicDataList(l, IBJAKJJICBC.EHNABCEGAHO(t, false, true));
			OverrideEnemySkill();
			m_isLine6Mode = false;
			m_lineButton.SetUnlock(IBJAKJJICBC.KGJJCAKCMLO());
			m_lineButton.SetUnlockNumber(IBJAKJJICBC.POPLHDKHIIM());
			yield return this.StartCoroutineWatched(Co_BattleAssetDownLoad(l));
			MenuScene.Instance.HelpButton.TryEnter();
			MenuScene.Instance.HeaderMenu.Enter(false);
			MenuScene.Instance.FooterMenu.Enter(false);
			m_initParam.isDisableBattleEventIntermediateResult = !GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KPFAFLBICLA_IsNotBattleEventInfo;
			diff = GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.MFFAIIDJPBL_BattleEvent.FFACBDAJJJP_GetDifficulty();
			list_no = 0;
			int fmid = 0;
			FreeCategoryId.Type cat = FreeCategoryId.Type.None;
			if(SelectUnitDanceFocus(out fmid, out cat, ref m_isLine6Mode, false, OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle))
			{
				int idx = m_musicList.FindIndex(fmid, false, false);
				if(idx > -1)
					list_no = idx;
			}
			ApplyMusicListInfo();
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
			ApplyBattleInfo(selectMusicData);
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
			m_musicInfo.TryEnter();
			m_eventInfo.TryEnter();
			m_cdSelect.TryEnter();
			m_cdArrow.TryEnter();
			m_buttonSet.TryEnter();
			m_battleInfo.TryEnter();
			m_battleExButton.TryEnter();
			m_battleExGauge.TryEnter();
			if(currentMusicList.GetCount(true, false) > 0)
			{
				m_lineButton.TryEnter(m_isLine6Mode);
			}
			yield return Co.R(Co_WaitForAnimEnd(() =>
			{
				//0x1055F88
				return;
			}));
		}

		// // RVA: 0xF12A60 Offset: 0xF12A60 VA: 0xF12A60
		private void OnClickExBattleScore()
		{
			GameManager.Instance.CloseSnsNotice();
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			m_ExBattleScoreTotal.SetUp(null, false);
			m_ExBattleScoreTotal.OpenWindow(() =>
			{
				//0xF1383C
				m_ExBattleScoreTotal.ButtonDisable();
				PopupExBattleScheduleSetting s = new PopupExBattleScheduleSetting();
				s.View = new CDDODEHEKGB();
				s.WindowSize = SizeType.Large;
				s.IsCaption = false;
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				PopupWindowManager.Show(s, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0x1055F8C
					return;
				}, null, null, () =>
				{
					//0xF13B9C
					m_ExBattleScoreTotal.ButtonEnable();
				}, true, true, false);
			}, (EMGOCNMMPHC view) =>
			{
				//0xF13BC8
				m_ExBattleScore.Setup(view);
				m_ExBattleScore.TryEnter(false);
			}, -1);
		}

		// // RVA: 0xF12C28 Offset: 0xF12C28 VA: 0xF12C28
		private void OverrideEnemySkill()
		{
			IBJAKJJICBC.BDNIEPMOHDI(m_musicList.GetList(false, false));
			IBJAKJJICBC.BDNIEPMOHDI(m_musicList.GetList(true, false));
		}

		// // RVA: 0xF12C98 Offset: 0xF12C98 VA: 0xF12C98
		private void OnClickSelectClassButton()
		{
			GameManager.Instance.CloseSnsNotice();
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			this.StartCoroutineWatched(Co_OpenBattleEventPopup());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EE0C4 Offset: 0x6EE0C4 VA: 0x6EE0C4
		// // RVA: 0xF12D9C Offset: 0xF12D9C VA: 0xF12D9C
		private IEnumerator Co_OpenBattleEventPopup()
		{
			//0x105F424
			bool isClosed = false;
			bool isDirty = false;
			bool isConfirm = false;
			PopupConfigBattleEventSetting s = new PopupConfigBattleEventSetting();
			s.IsCaption = false;
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			s.WindowSize = SizeType.Middle;
			s.OnClickClassSelect = () =>
			{
				//0x105758C
				isConfirm = true;
			};
			s.OnClickBattleInfo = (bool isDisable) =>
			{
				//0x1057598
				isDirty = true;
				m_initParam.isDisableBattleEventIntermediateResult = isDisable;
			};
            PopupWindowControl popupControl = PopupWindowManager.Show(s, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1055F90
				return;
			}, null, null, null, true, true, false, null, () =>
			{
				//0x10575C8
				isClosed = true;
			});
			bool isSelectClass = false;
			while(!isClosed)
			{
				if(isConfirm)
				{
					popupControl.InputDisable();
					yield return Co.R(Co_ConfirmSelectClass((bool isReSelect) =>
					{
						//0x10575D4
						if(!isReSelect)
							return;
						popupControl.Close(() =>
						{
							//0x1055F94
							return;
						}, null);
						isSelectClass = true;
					}));
					popupControl.InputEnable();
					isConfirm = false;
				}
				yield return null;
			}
			if(isDirty)
			{
				bool done = false;
				ConfigManager.Instance.ApplyValue(true, () =>
				{
					//0x1057734
					done = true;
				});
				while(!done)
					yield return null;
			}
			if(isSelectClass)
			{
				PMFBBLGPLLJ p = new PMFBBLGPLLJ();
				p.KHEKNNFCAOI();
				yield return Co.R(Co_SelectClass(p));
			}
        }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE13C Offset: 0x6EE13C VA: 0x6EE13C
		// // RVA: 0xF12E24 Offset: 0xF12E24 VA: 0xF12E24
		private IEnumerator Co_ConfirmSelectClass(Action<bool> onEnd)
		{
			//0x105978C
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			bool isClosed = false;
			bool isCancel = false;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("music_event_battle_class_reselect_01"), SizeType.Small, bk.GetMessageByLabel("music_event_battle_class_reselect_02") + Environment.NewLine + bk.GetMessageByLabel("music_event_battle_class_reselect_03"), new ButtonInfo[2]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x1057748
				if(label == PopupButton.ButtonLabel.Cancel)
					isCancel = true;
			}, null, null, null, true, true, false, null, () =>
			{
				//0x1057758
				isClosed = true;
			});
			yield return new WaitWhile(() =>
			{
				//0x1057764
				return !isClosed;
			});
			if(isCancel)
			{
				if(onEnd != null)
					onEnd(false);
				yield break;
			}
			(m_eventCtrl as HAEDCCLHEMN_EventBattle).PIKBPBCNIOD();
			yield return Co.R(Co_Save());
			if(onEnd != null)
				onEnd(true);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EE1B4 Offset: 0x6EE1B4 VA: 0x6EE1B4
		// // RVA: 0xF12EC8 Offset: 0xF12EC8 VA: 0xF12EC8
		protected IEnumerator TryShowExRivalTutorial()
		{
			//0x10634C0
			if(CheckExRivalHelpFunc())
			{
				HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
				if(ev != null && ev.GCNAICGAEPF_GetExRivalHelpId() != 0)
				{
					MenuScene.Instance.RaycastDisable();
					MenuScene.Instance.InputDisable();
					yield return this.StartCoroutineWatched(TutorialManager.ShowTutorial(ev.GCNAICGAEPF_GetExRivalHelpId(), () =>
					{
						//0x1057780
						ev.MJKEIBCDFJB_SetExRivalTutoShown();
						MenuScene.Instance.InputEnable();
						MenuScene.Instance.RaycastEnable();
					}));
				}
			}
		}

		// // RVA: 0xF12F50 Offset: 0xF12F50 VA: 0xF12F50
		private bool CheckExRivalHelpFunc()
		{
			HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
			if(ev != null)
			{
				if(!ev.LDIMNGFBKHL_GetExRivalTutoShown())
				{
					for(int i = 0; i < musicListCount; i++)
					{
						for(int j = 0; j < GetMusicList(i).GetCount(false, false); j++)
						{
							IBJAKJJICBC m = GetMusicList(i).Get(j, false, false);
							if(m != null && m.DACLONHOFLA != null && m.DACLONHOFLA.BHCIFFILAKJ_Str > 2)
								return true;
						}
					}
				}
			}
			return false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EE22C Offset: 0x6EE22C VA: 0x6EE22C
		// // RVA: 0xF13108 Offset: 0xF13108 VA: 0xF13108
		private IEnumerator Co_BattleAssetDownLoad(List<IBJAKJJICBC> musicList)
		{
			//0x1057910
			for(int i = 0; i < musicList.Count; i++)
			{
				GameManager.Instance.DivaIconCache.TryInstall(musicList[i].DACLONHOFLA.FDBOPFEOENF_RivalData.AHHJLDLAPAN_DivaId,
					musicList[i].DACLONHOFLA.FDBOPFEOENF_RivalData.FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId, 
					musicList[i].DACLONHOFLA.FDBOPFEOENF_RivalData.EKFONBFDAAP_ColorId);
				if(musicList[i].DACLONHOFLA.AFBMEMCHJCL_Scene != null)
				{
					GameManager.Instance.SceneIconCache.TryInstall(musicList[i].DACLONHOFLA.AFBMEMCHJCL_Scene.BCCHOBPJJKE_SceneId, 
						musicList[i].DACLONHOFLA.AFBMEMCHJCL_Scene.CGIELKDLHGE_GetEvolveId());
				}
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(MusicJacketTextureCache.MakeJacketTexturePath(musicList[i].JNCPEGJGHOG_JacketId));
			}
			GameManager.Instance.DivaIconCache.TryInstall(GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].AHHJLDLAPAN_DivaId,
				GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].FFKMJNHFFFL_Costume.DAJGPBLEEOB_PrismCostumeId,
				GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0].EKFONBFDAAP_ColorId);
            FFHPBEPOMAK_DivaInfo diva = GameManager.Instance.ViewPlayerData.NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[0];
            if (diva.FGFIBOBAPIA_SceneId > 0)
			{
				GameManager.Instance.SceneIconCache.TryInstall(diva.FGFIBOBAPIA_SceneId, 
					GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[diva.FGFIBOBAPIA_SceneId - 1].CGIELKDLHGE_GetEvolveId());
			}
			yield return null;
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
				yield return null;
        }

		// // RVA: 0xF13190 Offset: 0xF13190 VA: 0xF13190
		protected void OnChangeLineMode(int style)
		{
			MenuScene.Instance.RaycastDisable();
			m_isLine6Mode = style == 1;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.BCOIACHCMLA_Live.HPDBEKAGKOD_SetIsLine6(m_isLine6Mode);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			this.StartCoroutineWatched(Co_ChangeLineMode(selectMusicData.GHBPLHBNMBK_FreeMusicId, selectMusicData.DACLONHOFLA.BHCIFFILAKJ_Str, () =>
			{
				//0x1055F98
				MenuScene.Instance.RaycastEnable();
			}));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EE2A4 Offset: 0x6EE2A4 VA: 0x6EE2A4
		// // RVA: 0xF134C8 Offset: 0xF134C8 VA: 0xF134C8
		private IEnumerator Co_ChangeLineMode(int freeMusicId, int strength, Action callback)
		{
			bool isPlaying;

			//0x1058D48
			m_cdSelect.TryLeave();
			m_cdArrow.TryLeave();
			m_musicInfo.TryLeave();
			m_buttonSet.TryLeave();
			m_eventInfo.TryLeave();
			m_eventBanner.TryLeave();
			m_battleLimit.TryLeave();
			m_battleExGauge.TryLeave();
			m_battleInfo.TryLeave();
			m_battleExButton.TryLeave();
			MenuScene.Instance.HelpButton.TryLeave();
			isPlaying = true;
			while(isPlaying)
			{
				isPlaying = m_cdSelect.IsPlaying() || m_cdArrow.IsPlaying() || m_musicInfo.IsPlaying() || m_buttonSet.IsPlaying() || m_eventInfo.IsPlaying() || 
					m_eventBanner.IsPlaying() || m_battleLimit.IsPlaying() || m_battleExGauge.IsPlaying() || m_battleInfo.IsPlaying() || m_battleExButton.IsPlaying();
				yield return null;
			}
			int idx = m_musicList.FindIndex((IBJAKJJICBC _) =>
			{
				//0x1057870
				return _.GHBPLHBNMBK_FreeMusicId == freeMusicId && _.DACLONHOFLA.BHCIFFILAKJ_Str == strength;
			}, m_isLine6Mode, false);
			if(idx < 0)
				idx = 0;
			list_no = idx;
			ApplyMusicListInfo();
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
			ApplyBasicInfo();
			ApplyBattleInfo(selectMusicData);
			m_cdSelect.Enter();
			m_cdArrow.Enter();
			m_musicInfo.Enter();
			m_buttonSet.Enter();
			m_eventInfo.Enter();
			m_eventBanner.Enter();
			m_battleLimit.Enter();
			m_battleExGauge.Enter();
			m_battleInfo.Enter();
			m_battleExButton.Enter();
			MenuScene.Instance.HelpButton.TryEnter();
			isPlaying = true;
			while(isPlaying)
			{
				isPlaying = m_cdSelect.IsPlaying() || m_cdArrow.IsPlaying() || m_musicInfo.IsPlaying() || m_buttonSet.IsPlaying() || m_eventInfo.IsPlaying() || 
					m_eventBanner.IsPlaying() || m_battleLimit.IsPlaying() || m_battleExGauge.IsPlaying() || m_battleInfo.IsPlaying() || m_battleExButton.IsPlaying();
				yield return null;
			}
			if(callback != null)
				callback();
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6EE31C Offset: 0x6EE31C VA: 0x6EE31C
		// // RVA: 0xF135A4 Offset: 0xF135A4 VA: 0xF135A4
		// private void <ApplyMusicInfoBasic>b__48_0(long current, long limit, long remain) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE32C Offset: 0x6EE32C VA: 0x6EE32C
		// // RVA: 0xF135D0 Offset: 0xF135D0 VA: 0xF135D0
		// private void <ApplyEventInfo>b__49_0(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE33C Offset: 0x6EE33C VA: 0x6EE33C
		// // RVA: 0xF1362C Offset: 0xF1362C VA: 0xF1362C
		// private void <ApplyEventInfo>b__49_2(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE34C Offset: 0x6EE34C VA: 0x6EE34C
		// // RVA: 0xF13660 Offset: 0xF13660 VA: 0xF13660
		// private void <ApplyEventInfo>b__49_1(long current, long limit, long remain) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE35C Offset: 0x6EE35C VA: 0x6EE35C
		// [DebuggerHiddenAttribute] // RVA: 0x6EE35C Offset: 0x6EE35C VA: 0x6EE35C
		// // RVA: 0xF13814 Offset: 0xF13814 VA: 0xF13814
		// private void <>n__0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE38C Offset: 0x6EE38C VA: 0x6EE38C
		// [DebuggerHiddenAttribute] // RVA: 0x6EE38C Offset: 0x6EE38C VA: 0x6EE38C
		// // RVA: 0xF1381C Offset: 0xF1381C VA: 0xF1381C
		// private IEnumerator <>n__1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE3BC Offset: 0x6EE3BC VA: 0x6EE3BC
		// [DebuggerHiddenAttribute] // RVA: 0x6EE3BC Offset: 0x6EE3BC VA: 0x6EE3BC
		// // RVA: 0xF13824 Offset: 0xF13824 VA: 0xF13824
		// private IEnumerator <>n__2(Action onEnd) { }
	}
}
