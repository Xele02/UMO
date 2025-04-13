using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Localization.SmartFormat;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class EventBattleScene : MusicSelectSceneBase
	{
		private class PlayButton : PlayButtonWrapper
		{
			private MusicSelectBattleInfo battleUI; // 0xC

			public override MusicSelectCDSelect baseUI { get; protected set; } // 0x8

			// RVA: 0x10637E0 Offset: 0x10637E0 VA: 0x10637E0
			public PlayButton(MusicSelectCDSelect baseUI, MusicSelectBattleInfo battleUI)
			{
				this.baseUI = baseUI;
				this.battleUI = battleUI;
			}

			// RVA: 0x106381C Offset: 0x106381C VA: 0x106381C Slot: 6
			public override void Enter(bool immediate/* = False*/)
			{
				HideBasePlayButton();
			}

			// RVA: 0x1063860 Offset: 0x1063860 VA: 0x1063860 Slot: 7
			public override void Leave(bool immediate/* = False*/)
			{
				HideBasePlayButton();
			}

			// RVA: 0x1063864 Offset: 0x1063864 VA: 0x1063864 Slot: 8
			public override void SetDisable(bool disable)
			{
				HideBasePlayButton();
				battleUI.SetPlayButtonDisable(disable);
			}

			// RVA: 0x10638A0 Offset: 0x10638A0 VA: 0x10638A0 Slot: 9
			public override void SetType(Type type)
			{
				HideBasePlayButton();
				if(type == Type.Download)
				{
					battleUI.SetPlayButtonType(MusicSelectBattleInfo.PlayButtonType.Download);
				}
				else if(type == Type.Play)
				{
					battleUI.SetPlayButtonType(MusicSelectBattleInfo.PlayButtonType.Play);
				}
				else if(type == Type.PlayEn)
				{
					battleUI.SetPlayButtonType(MusicSelectBattleInfo.PlayButtonType.PlayEn);
				}
			}

			// RVA: 0x1063934 Offset: 0x1063934 VA: 0x1063934 Slot: 10
			public override void SetNeedEnergy(int en)
			{
				battleUI.SetNeedEnergy(en);
			}

			// // RVA: 0x1063820 Offset: 0x1063820 VA: 0x1063820
			private void HideBasePlayButton()
			{
				baseUI.LeavePlayButton(true);
			}
		}

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
			m_overrideEnemyCenterSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.DCOALMMJDJK_OverrideCenterSkill;
			m_overrideEnemyLiveSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.KKPLDFNDFDE_OverrideLiveSkill;
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
			return new PlayButton(m_cdSelect, m_battleInfo);
		}

		// RVA: 0xF1022C Offset: 0xF1022C VA: 0xF1022C Slot: 39
		protected override void Release()
		{
			ReleaseDecos();
			m_musicInfo.ReleaseCache();
			m_cdSelect.ReleaseCache();
		}

		// RVA: 0xF10300 Offset: 0xF10300 VA: 0xF10300 Slot: 40
		protected override void SetupViewMusicData()
		{
			NKOBMDPHNGP_EventRaidLobby ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			if(ev != null)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "SetupViewMusicData");
			}
		}

		// RVA: 0xF10450 Offset: 0xF10450 VA: 0xF10450 Slot: 41
		protected override void ApplyBasicInfo()
		{
			base.ApplyBasicInfo();
			m_cdArrow.SetStyle(MusicSelectCDArrow.Style.Battle);
		}

		// RVA: 0xF1048C Offset: 0xF1048C VA: 0xF1048C Slot: 42
		protected override void ApplyMusicListInfo()
		{
			if(selectMusicData.POEGGBGOKGI_IsInfoLiveEntrance)
			{
				list_no++;
			}
			base.ApplyMusicListInfo();
		}

		// RVA: 0xF104F4 Offset: 0xF104F4 VA: 0xF104F4 Slot: 44
		protected override void DelayedApplyMusicInfo()
		{
			if(!m_isEventTimeLimit)
			{
				base.DelayedApplyMusicInfo();
				if(!listIsEmpty)
				{
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.MFFAIIDJPBL_BattleEvent.HJHBGHMNGKL_SetDifficulty(diff);
				}
				GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
			}
		}

		// RVA: 0xF10658 Offset: 0xF10658 VA: 0xF10658 Slot: 46
		protected override void ApplyMusicInfoBasic(IBJAKJJICBC musicData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			//musicData.BJANNALFGGA_HasRanking
			m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.None, false);
			m_cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.None);
			m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.None, false);
			playButtonUI.SetType(musicData.IFNPBIJEPBO_IsDlded ? PlayButtonWrapper.Type.PlayEn : PlayButtonWrapper.Type.Download);
			m_musicTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
			{
				//0xF135A4
				ApplyEventRemainTime(remain, true);
			};
			m_musicTimeWatcher.onEndCallback = null;
			m_musicTimeWatcher.WatchStart(m_eventCtrl.DPJCPDKALGI_End1, false);
			if(!IsEventEndChallengePeriod)
			{
				ApplyBattleInfo(musicData);
			}
		}

		// // RVA: 0xF117A8 Offset: 0xF117A8 VA: 0xF117A8
		private void ApplyEventInfo()
		{
			m_eventBanner.SetStyle(IsEventEndChallengePeriod ? MusicSelectEventBanner.Style.Enable : MusicSelectEventBanner.Style.Period);
			m_eventBanner.ChangeEventBanner(m_eventId);
			if(m_eventCtrl.MNDFBBMNJGN_IsUsingTicket)
			{
				GameManager.Instance.ItemTextureCache.Load(m_eventCtrl.JKIADEKHGLC_TicketItemId, (IiconTexture image) =>
				{
					//0xF135D0
					m_eventBanner.SetEventTicket(image);
					m_eventInfo.SetTicketImage(image);
				});
			}
			m_eventInfo.SetTicketCount(m_eventCtrl.AELBIEDNPGB_GetTicketCount(null));
			if(IsEventCounting)
			{
				m_eventInfo.SetRankCouting(MessageManager.Instance.GetMessage("menu", "music_event_battle_rank_counting"), 0);
				m_eventInfo.SetRankCouting(MessageManager.Instance.GetMessage("menu", "music_event_battle_rank_counting"), 1);
			}
			else
			{
				if(m_eventCtrl.CDINKAANIAA_Rank[0] < 1)
				{
					m_eventInfo.SetRankOrder(TextConstant.InvalidText, 0);
					if(RuntimeSettings.CurrentSettings.Language != "jp")
						m_eventInfo.SetRankUnitLabel(Smart.Format(MessageManager.Instance.GetMessage("menu", "music_event_battle_rank_unit"), 0), 0);
				}
				else
				{
					m_eventInfo.SetRankOrder(m_eventCtrl.CDINKAANIAA_Rank[0].ToString(), 0);
					if(RuntimeSettings.CurrentSettings.Language != "jp")
						m_eventInfo.SetRankUnitLabel(Smart.Format(MessageManager.Instance.GetMessage("menu", "music_event_battle_rank_unit"), m_eventCtrl.CDINKAANIAA_Rank[0]), 0);
				}
				if(m_eventCtrl.CDINKAANIAA_Rank[1] < 1)
				{
					m_eventInfo.SetRankOrder(TextConstant.InvalidText, 1);
					if(RuntimeSettings.CurrentSettings.Language != "jp")
						m_eventInfo.SetRankUnitLabel(Smart.Format(MessageManager.Instance.GetMessage("menu", "music_event_battle_rank_unit"), 0), 1);
				}
				else
				{
					m_eventInfo.SetRankOrder(m_eventCtrl.CDINKAANIAA_Rank[1].ToString(), 1);
					if(RuntimeSettings.CurrentSettings.Language != "jp")
						m_eventInfo.SetRankUnitLabel(Smart.Format(MessageManager.Instance.GetMessage("menu", "music_event_battle_rank_unit"), m_eventCtrl.CDINKAANIAA_Rank[1]), 1);
				}
				m_eventInfo.SetCurrentValue(m_eventCtrl.FBGDBGKNKOD_GetCurrentPoint().ToString());
				HAEDCCLHEMN_EventBattle btl = m_eventCtrl as HAEDCCLHEMN_EventBattle;
				m_eventInfo.SetBpValue(btl.GFNODPDPNMJ_GetSumExHighScore().ToString());
				if(m_eventCtrl.ILICNKILFKJ_GetNextReward() == null || IsEventEndChallengePeriod)
				{
					m_eventInfo.SetRewardValid(false);
					m_eventInfo.SetNextValue(TextConstant.InvalidText);
					m_eventInfo.SetRewardEndLabel(TextConstant.InvalidText);
				}
				else
				{
					m_eventInfo.SetRewardValid(true);
					m_eventInfo.SetNextValue(m_eventCtrl.ILICNKILFKJ_GetNextReward().OJELCGDDAOM_MissingPoint.ToString());
					GameManager.Instance.ItemTextureCache.Load(m_eventCtrl.ILICNKILFKJ_GetNextReward().HBHMAKNGKFK_Items[0].JJBGOIMEIPF_ItemId, (IiconTexture image) =>
					{
						//0xF1362C
						m_eventInfo.SetRewardIcon(image);
					});
				}
				m_bannerTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
				{
					//0xF13660
					int d, h, m, s;
					ExtractRemainTime((int)remain, out d, out h, out m, out s);
					m_battleLimit.SetLimitText(MessageManager.Instance.GetMessage("menu", "music_event_remain_prefix") + RichTextUtility.MakeColorTagString(MakeRemainTime(d, h, m, s), SystemTextColor.ImportantColor));
				};
				m_bannerTimeWatcher.WatchStart(m_eventCtrl.DPJCPDKALGI_End1, false);
			}
		}

		// RVA: 0xF121FC Offset: 0xF121FC VA: 0xF121FC Slot: 52
		protected override void LeaveForScrollStart()
		{
			base.LeaveForScrollStart();
			m_eventInfo.Leave();
			m_battleInfo.Leave();
		}

		// RVA: 0xF12254 Offset: 0xF12254 VA: 0xF12254 Slot: 53
		protected override void EnterForScrollEnd()
		{
			base.EnterForScrollEnd();
			m_eventInfo.Enter();
			m_battleInfo.Enter();
		}

		// RVA: 0xF122AC Offset: 0xF122AC VA: 0xF122AC Slot: 54
		protected override void OnChangedDifficulty()
		{
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.MFFAIIDJPBL_BattleEvent.HJHBGHMNGKL_SetDifficulty(diff);
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
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
		private void ReleaseDecos()
		{
			if(m_selfDivaDeco != null)
			{
				m_selfDivaDeco.Release();
				m_selfDivaDeco = null;
			}
			if(m_rivalDivaDeco != null)
			{
				m_rivalDivaDeco.Release();
				m_rivalDivaDeco = null;
			}
			if(m_selfSceneDeco != null)
			{
				m_selfSceneDeco.Release();
				m_selfSceneDeco = null;
			}
			if(m_rivalSceneDeco != null)
			{
				m_rivalSceneDeco.Release();
				m_rivalSceneDeco = null;
			}
		}

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
				ev.ECFNKBGDJCA(list_no, musicData.DACLONHOFLA.OIPCCBHIKIA_RivalIdx, str);
				m_battleInfo.ApplyRivalRank((MusicSelectBattleInfo.RivalRankType)str);
				m_battleInfo.ApplyRivalTitle(musicData.DACLONHOFLA.OPFGFINHFCE_Name);
				m_battleInfo.ApplyRivalScore(ev.HOJNMALLCME_GetClassMaxScore(str, 0));
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
				m_battleExGauge.Setup(ev.HEOGGKBILIA_GetCurrentClassEmblemId(), ev.NJDPMDCIFBP_GetResultExPoint(musicData.DACLONHOFLA.BHCIFFILAKJ_Str, true), ev.NJDPMDCIFBP_GetResultExPoint(musicData.DACLONHOFLA.BHCIFFILAKJ_Str, false), ev.GGBNNMCLDMO_GetExPoint(), 100);
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
					for(int i = 0; i < evBtl.CJOBENJJCLD_GetLastAvailableClassId(); i++)
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
				m_isEventChecked = true;
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
			StringBuilder bundleName; // 0x18
			FontInfo systemFont; // 0x1C
			int bundleLoadCount; // 0x20
			AssetBundleLoadLayoutOperationBase lytOp; // 0x24
			int poolSize; // 0x28

			//0x105BB94
			bundleName = new StringBuilder();
			systemFont = GameManager.Instance.GetSystemFont();
			bundleName.Set("ly/038.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicInfo");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056174
				instance.transform.SetParent(transform, false);
				m_musicInfo = instance.GetComponent<MusicSelectMusicInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicCD");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056270
				instance.transform.SetParent(transform, false);
				m_cdSelect = instance.GetComponent<MusicSelectCDSelect>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_MusicCDArrow");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x105636C
				instance.transform.SetParent(transform, false);
				m_cdArrow = instance.GetComponent<MusicSelectCDArrow>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_ButtonSet");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056468
				instance.transform.SetParent(transform, false);
				m_buttonSet = instance.GetComponent<MusicSelectButtonSet>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventBanner");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056564
				instance.transform.SetParent(transform, false);
				m_eventBanner = instance.GetComponent<MusicSelectEventBanner>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventInfo");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056660
				instance.transform.SetParent(transform, false);
				m_eventInfo = instance.GetComponent<MusicSelectEventInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_EventEnd");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x105675C
				instance.transform.SetParent(transform, false);
				m_timeLimitMessage = instance.GetComponent<EventTimeLimitMessage>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_LineButton");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056858
				instance.transform.SetParent(transform, false);
				m_lineButton = instance.GetComponent<MusicSelectLineButton>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			bundleName.Set("ly/063.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_BattleInfo");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056954
				instance.transform.SetParent(transform, false);
				m_battleInfo = instance.GetComponent<MusicSelectBattleInfo>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_BattleMatch");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056A50
				instance.transform.SetParent(transform, false);
				m_battleMatch = instance.GetComponent<MusicSelectBattleMatch>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_BattleLimit");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056B4C
				instance.transform.SetParent(transform, false);
				m_battleLimit = instance.GetComponent<MusicSelectBattleLimit>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_BattleExButton");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056C48
				instance.transform.SetParent(transform, false);
				m_battleExButton = instance.GetComponent<MusicSelectBattleExButton>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "UI_BattleExGauge");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056D44
				instance.transform.SetParent(transform, false);
				m_battleExGauge = instance.GetComponent<MusicSelectBattleExGauge>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_btl_cl_window_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056E40
				instance.transform.SetParent(transform, false);
				m_battleClassSelect = instance.GetComponent<LayoutBattleClassListWindow>();
			}));
			bundleLoadCount++;
			poolSize = m_battleClassSelect.List.ScrollObjectCount;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_sel_music_btl_cl_list_01_layout_root");
			yield return lytOp;
			LayoutUGUIRuntime baseRuntime = null;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x1056F3C
				baseRuntime = instance.GetComponent<LayoutUGUIRuntime>();
				baseRuntime.name = string.Format(baseRuntime.name + "_{0:D2}", 0);
				m_battleClassSelect.List.AddScrollObject(baseRuntime.GetComponent<SwapScrollListContent>());
			}));
			bundleLoadCount++;
			for(int i = 1; i < poolSize; i++)
			{
				LayoutUGUIRuntime r = Instantiate(baseRuntime);
				r.name = string.Format(r.name + "_{0:D2}", i);
				r.IsLayoutAutoLoad = false;
				r.Layout = baseRuntime.Layout.DeepClone();
				r.UvMan = baseRuntime.UvMan;
				r.LoadLayout();
				m_battleClassSelect.List.AddScrollObject(r.GetComponent<SwapScrollListContent>());
			}
			m_battleClassSelect.List.Apply();
			m_battleClassSelect.List.SetContentEscapeMode(true);
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			bundleName.Set("ly/122.xab");
			bundleLoadCount = 0;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_ex_btl_win_scr_01_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10570D4
				instance.transform.SetParent(transform, false);
				m_ExBattleScore = instance.GetComponent<LayoutPopupExBattleScore>();
			}));
			bundleLoadCount++;
			lytOp = AssetBundleManager.LoadLayoutAsync(bundleName.ToString(), "root_pop_ex_btl_win_scr_02_layout_root");
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0x10571D0
				instance.transform.SetParent(transform, false);
				m_ExBattleScoreTotal = instance.GetComponent<LayoutPopupExBattleScoreTotal>();
			}));
			bundleLoadCount++;
			for(int i = 0; i < bundleLoadCount; i++)
			{
				AssetBundleManager.UnloadAssetBundle(bundleName.ToString(), false);
			}
			yield return Co.R(Co_LoadAssetBundle_LoginBonusPopup());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDD7C Offset: 0x6EDD7C VA: 0x6EDD7C
		// // RVA: 0xF12638 Offset: 0xF12638 VA: 0xF12638 Slot: 56
		protected override IEnumerator Co_WaitForLoaded()
		{
			//0x1062F1C
			yield return Co.R(base.Co_WaitForLoaded());
			while(m_eventInfo == null || !m_eventInfo.IsLoaded())
				yield return null;
			while(m_battleInfo == null || !m_battleInfo.IsLoaded())
				yield return null;
			while(m_battleMatch == null || !m_battleMatch.IsLoaded())
				yield return null;
			while(m_battleLimit == null || !m_battleLimit.IsLoaded())
				yield return null;
			while(m_battleExButton == null || !m_battleExButton.IsLoaded())
				yield return null;
			while(m_battleExGauge == null || !m_battleExGauge.IsLoaded())
				yield return null;
			while(m_battleClassSelect == null || !m_battleClassSelect.IsLoaded())
				yield return null;
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
			if(list.Count > 1)
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
				s.ItemContent = RichTextUtility.MakeColorTagString(string.Format(s2, list[1].GIDPPGJPOJA_Id), SystemTextColor.NormalColor);
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
			}
			bool isChallengeNewClass = false;
			HAEDCCLHEMN_EventBattle ev = m_eventCtrl as HAEDCCLHEMN_EventBattle;
			if(list.Count > 0)
			{
				if(list[0].GIDPPGJPOJA_Id != ev.KKMFHMGIIKN_GetCls())
				{
					PopupClassUnlockSetting s4 = new PopupClassUnlockSetting();
					s4.View = list[0];
					s4.WindowSize = SizeType.Small;
					s4.IsCaption = false;
					bool isClosed = false;
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
				ev.HGCIBMLAAMI_SetClsAndResetExPoint(viewClassData.AIMCAJDBNOI_ClassId);
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
					v = l[i].AIMCAJDBNOI_ClassId;
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
