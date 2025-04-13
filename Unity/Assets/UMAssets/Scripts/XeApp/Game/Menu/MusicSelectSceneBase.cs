using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Core;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeApp.Game.Tutorial;
using XeSys;
using XeSys.uGUI;

namespace XeApp.Game.Menu
{
	public abstract class MusicSelectSceneBase : TransitionRoot
	{
		public delegate bool CheckMatchMusicFilterFunc(IBJAKJJICBC musicData, long currentTime);
		public delegate void OnCallback_LoginBonusPopup();
		private class PlayButton : PlayButtonWrapper
		{
			public override MusicSelectCDSelect baseUI { get; protected set; } // 0x8

			// RVA: 0xF3AB18 Offset: 0xF3AB18 VA: 0xF3AB18
			public PlayButton(MusicSelectCDSelect ui)
			{
				baseUI = ui;
			}

			// // RVA: 0xF52748 Offset: 0xF52748 VA: 0xF52748 Slot: 6
			public override void Enter(bool immediate/* = False*/)
			{
				baseUI.EnterPlayButton(immediate);
			}

			// // RVA: 0xF5278C Offset: 0xF5278C VA: 0xF5278C Slot: 7
			public override void Leave(bool immediate/* = False*/)
			{
				baseUI.LeavePlayButton(immediate);
			}

			// // RVA: 0xF527D0 Offset: 0xF527D0 VA: 0xF527D0 Slot: 8
			public override void SetDisable(bool disable)
			{
				baseUI.SetPlayButtonDisable(disable);
			}

			// // RVA: 0xF52814 Offset: 0xF52814 VA: 0xF52814 Slot: 9
			public override void SetType(Type type)
			{
				switch(type)
				{
					case Type.PlayEn:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.PlayEn);
						break;
					case Type.Play:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Play);
						break;
					case Type.Event:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Event);
						break;
					case Type.Download:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Download);
						break;
					case Type.Live:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Live);
						break;
					case Type.Ok:
						baseUI.SetPlayButtonType(MusicSelectCDSelect.PlayButtonType.Ok);
						break;
					default:
						break;
				}
			}

			// // RVA: 0xF52974 Offset: 0xF52974 VA: 0xF52974 Slot: 10
			public override void SetNeedEnergy(int en)
			{
				baseUI.SetNeedEnergy(en);
			}
		}

		private const int s_musicSelectSeId = 5;
		private const float s_bgmFadeOutSec = 0.3f;
		private const float s_cdScrollSec = 0.2f;
		protected MusicSelectMusicInfo m_musicInfo; // 0x48
		protected MusicSelectCDSelect m_cdSelect; // 0x4C
		protected MusicSelectCDArrow m_cdArrow; // 0x50
		protected MusicSelectButtonSet m_buttonSet; // 0x54
		protected MusicSelectEventBanner m_eventBanner; // 0x58
		protected MusicSelectMusicRate m_musicRate; // 0x5C
		private PopupAchieveRewardSetting m_rewardPopupSetting = new PopupAchieveRewardSetting(); // 0x60
		private FPGEMAIAMBF_RewardData m_rewardData; // 0x64
		private List<MusicRewardStat> m_rewardStats; // 0x68
		private EJKBKMBJMGL_EnemyData m_enemyData = new EJKBKMBJMGL_EnemyData(); // 0x6C
		protected bool m_isInitialized; // 0x74
		protected bool m_isSimulationLive; // 0x75
		private bool m_isConfirmedUnitDance; // 0x76
		protected bool m_isLine6Mode; // 0x77
		protected bool m_isListEmptyByFilter; // 0x78
		protected string m_missionText = string.Empty; // 0x7C
		protected int m_overrideEnemyCenterSkill; // 0x80
		protected int m_overrideEnemyLiveSkill; // 0x84
		protected MusicSelectButtonSet.OptionStyle m_overrideButtonStyle; // 0x88
		protected GameSetupData.MusicInfo.InitFreeMusicParam m_initParam; // 0x8C
		private PopupUnitDanceWarning m_popupUnitDanceWarning = new PopupUnitDanceWarning(); // 0x94
		protected IKDICBBFBMI_EventBase m_eventCtrl; // 0x98
		protected IKDICBBFBMI_EventBase m_scoreEventCtrl; // 0x9C
		private List<FKMOKDCJFEN> m_questList; // 0xA0
		private FDDIIKBJNNA m_snsData = new FDDIIKBJNNA(); // 0xA4
		protected MMOLNAHHDOM m_unitLiveLocalSaveData; // 0xA8
		protected int m_eventId; // 0xAC
		protected int m_eventIndex; // 0xB0
		protected int m_eventTicketId; // 0xB4
		protected OHCAABOMEOF.KGOGMKMBCPP_EventType m_currentEventType; // 0xB8
		protected List<int> m_eventHelpId = new List<int>(2); // 0xBC
		protected KGCNCBOKCBA.GNENJEHKMHD_EventStatus m_eventStatus; // 0xC0
		protected bool m_isEventTimeLimit; // 0xC4
		protected bool m_isScoreEventTimeLimit; // 0xC5
		protected bool m_isShowFirstHelp; // 0xC6
		protected LimitTimeWatcher m_musicTimeWatcher = new LimitTimeWatcher(); // 0xC8
		protected LimitTimeWatcher m_bannerTimeWatcher = new LimitTimeWatcher(); // 0xCC
		protected bool m_isEndActivateScene; // 0xD0
		private bool m_muteSelectionSe; // 0xD1
		private bool m_requestFadeOutBgm; // 0xD2
		private int m_changeToTrialBgmId = -1; // 0xD4
		private bool m_showTicketGainedPopup; // 0xD9
		private bool m_showitemReceivePopup; // 0xDA
		private bool m_loadingTicketGainedPopup; // 0xDB
		private TicketGainedPopupSetting m_ticketGainedPopupSetting; // 0xDC
		private PopupItemGetSetting m_itemReceivePopupSetting = new PopupItemGetSetting(); // 0xE0
		private TeamSlectSceneArgs m_teamSelectSceneArgs = new TeamSlectSceneArgs(); // 0xE4
		private List<Action> NoticeActionList = new List<Action>(); // 0xF4

		protected abstract int musicListCount { get; }  //Slot: 31
		protected abstract MusicDataList currentMusicList { get; } //Slot: 33
		protected PlayButtonWrapper playButtonUI { get; private set; } // 0x70
		protected bool isBgChanging { get; private set; } // 0xD8
		// protected float bgmFadeOutSec { get; } 0xF3946C
		public int list_no { get; set; } // 0xE8
		public Difficulty.Type diff { get; set; } // 0xEC
		protected IBJAKJJICBC selectMusicData { get { return currentMusicList.Get(list_no, m_isLine6Mode, m_isSimulationLive); } } //0xF39498
		protected bool listIsEmpty { get { return currentMusicList.GetCount(m_isLine6Mode, m_isSimulationLive) < 1; } } //0xF39510
		// protected bool listisEmptyByFilter { get; } 0xF39584
		protected virtual bool scrollIsClamp { get { return currentMusicList.GetCount(m_isLine6Mode, m_isSimulationLive) > 1 && currentMusicList.GetCount(m_isLine6Mode, m_isSimulationLive) < 5; } } //0xF3958C
		public int freeMusicId { get { return !listIsEmpty ? selectMusicData.GHBPLHBNMBK_FreeMusicId : 0; } } //0xF39660
		public int gameEventType { get { return !listIsEmpty ? selectMusicData.MNNHHJBBICA_GameEventType : 0; } } //0xF396A8
		public int musicId { get { return !listIsEmpty ? selectMusicData.DLAEJOBELBH_MusicId : 0; } } //0xF396F0
		// public bool isEventGame { get; set; } // 0xF0
		public bool IsEventCounting { get { return m_eventStatus == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6; } } //0xF39748
		public bool IsEventEndChallengePeriod { get { return m_eventStatus > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5; } } //0xF3975C
		// public bool IsEventRankingEnd { get; } 0xF39770

		// RVA: -1 Offset: -1 Slot: 32
		protected abstract MusicDataList GetMusicList(int i);

		// // RVA: 0xF39784 Offset: 0xF39784 VA: 0xF39784
		public bool IsNewStory()
		{
			if(m_eventCtrl != null)
			{
				for(int i = 0; i < m_eventCtrl.PFPJHJJAGAG_Rewards.Count; i++)
				{
					for(int j = 0; j < m_eventCtrl.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_Items.Count; j++)
					{
						if(m_eventCtrl.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_Items[j].NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.KNHFAHFCCBK_SnsItem)
						{
							for(int k = 0; k < m_snsData.NPKPBDIDBBG_RoomData.Count; k++)
							{
								for(int l = 0; l < m_snsData.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA.Count; l++)
								{
									if(m_snsData.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA[l].AIPLIEMLHGC == m_eventCtrl.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId)
									{
										if(!m_snsData.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA[l].EDCBHGECEBE_Read)
										{
											if(m_snsData.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA[l].GAIEHFCHAOK_New)
												return true;
										}
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		// // RVA: 0xF39CEC Offset: 0xF39CEC VA: 0xF39CEC Slot: 4
		protected override void Awake()
		{
			base.Awake();
			m_isSimulationLive = false;
			SetupViewMusicData();
			this.StartCoroutineWatched(Co_LoadResources());
		}

		// RVA: 0xF39DC4 Offset: 0xF39DC4 VA: 0xF39DC4 Slot: 16
		protected override void OnPreSetCanvas()
		{
			CheckTryInstall();
			m_unitLiveLocalSaveData = new MMOLNAHHDOM();
			m_unitLiveLocalSaveData.PCODDPDFLHK_Read();
			m_isConfirmedUnitDance = false;
		}

		// RVA: 0xF39E6C Offset: 0xF39E6C VA: 0xF39E6C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xF39F0C Offset: 0xF39F0C VA: 0xF39F0C Slot: 18
		protected override void OnPostSetCanvas()
		{
			this.StartCoroutineWatched(Co_Initialize());
		}

		// RVA: 0xF39F40 Offset: 0xF39F40 VA: 0xF39F40 Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			return m_isInitialized;
		}

		// RVA: 0xF39F48 Offset: 0xF39F48 VA: 0xF39F48 Slot: 23
		protected override void OnActivateScene()
		{
			this.StartCoroutineWatched(Co_OnActivateScene());
		}

		// RVA: 0xF39F7C Offset: 0xF39F7C VA: 0xF39F7C Slot: 24
		protected override bool IsEndActivateScene()
		{
			return m_isEndActivateScene;
		}

		// RVA: 0xF39F84 Offset: 0xF39F84 VA: 0xF39F84 Slot: 20
		protected override bool OnBgmStart()
		{
			DelayedApplyMusicInfo();
			return true;
		}

		// RVA: 0xF39FA4 Offset: 0xF39FA4 VA: 0xF39FA4
		private void Update()
		{
			m_musicTimeWatcher.Update();
			m_bannerTimeWatcher.Update();
		}

		// RVA: 0xF39FF4 Offset: 0xF39FF4 VA: 0xF39FF4 Slot: 14
		protected override void OnDestoryScene()
		{
			Release();
			m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
		}

		// RVA: 0xF3A03C Offset: 0xF3A03C VA: 0xF3A03C Slot: 15
		protected override void OnDeleteCache()
		{
			if(m_popupUnitDanceWarning != null)
				m_popupUnitDanceWarning.Release();
		}

		// RVA: 0xF3A050 Offset: 0xF3A050 VA: 0xF3A050 Slot: 30
		protected override void InputDisable()
		{
			base.InputDisable();
			if(m_cdSelect != null)
				m_cdSelect.ScrollDisable();
		}

		// RVA: 0xF3A110 Offset: 0xF3A110 VA: 0xF3A110 Slot: 29
		protected override void InputEnable()
		{
			base.InputEnable();
			if(m_cdSelect != null)
				m_cdSelect.ScrollEnable();
		}

		// // RVA: -1 Offset: -1 Slot: 35
		protected abstract void CheckTryInstall();

		// // RVA: 0xF3A1E8 Offset: 0xF3A1E8 VA: 0xF3A1E8
		// protected void TryInstall(StringBuilder bundleName, MusicDataList musicList) { }

		// // RVA: 0xF3A504 Offset: 0xF3A504 VA: 0xF3A504
		// protected void TryInstall(StringBuilder bundleName) { }

		// // RVA: -1 Offset: -1 Slot: 36
		protected abstract IEnumerator Co_Initialize();

		// // RVA: -1 Offset: -1 Slot: 37
		protected abstract IEnumerator Co_OnActivateScene();

		// // RVA: 0xF3A5D0 Offset: 0xF3A5D0 VA: 0xF3A5D0
		protected void CrateQuestList()
		{
			if(m_eventCtrl == null)
				m_questList = new List<FKMOKDCJFEN>();
			else
				m_questList = FKMOKDCJFEN.KJHKBBBDBAL(m_eventCtrl.JOPOPMLFINI_QuestId, false, -1);
		}

		// // RVA: 0xF3A678 Offset: 0xF3A678 VA: 0xF3A678
		protected void CreateSnsList()
		{
			if(m_eventCtrl == null)
				return;
			m_snsData.KHEKNNFCAOI(false, false, -1);
		}

		// // RVA: 0xF3A6C8 Offset: 0xF3A6C8 VA: 0xF3A6C8
		protected void SetupHelp()
		{
			m_eventHelpId.Clear();
			if(!m_eventCtrl.BELBNINIOIE)
			{
				if(m_eventCtrl.CMPEJEHCOEI)
				{
					int helpId = m_eventCtrl.HLOGNJNGDJO_GetHelpId(m_eventCtrl.NJHPPOFBCMA() ? 1 : 0);
					if(helpId > 0)
					{
						m_eventHelpId.Add(helpId);
					}
				}
			}
			else
			{
				if(m_eventCtrl.CMPEJEHCOEI)
				{
					int helpId = m_eventCtrl.HLOGNJNGDJO_GetHelpId(m_eventCtrl.NJHPPOFBCMA() ? 1 : 0);
					if(helpId > 0)
					{
						m_eventHelpId.Add(helpId);
					}
				}
				if(m_eventCtrl.LPFJADHHLHG)
				{
					int helpId = m_eventCtrl.HLOGNJNGDJO_GetHelpId(2);
					if(helpId > 0)
					{
						m_eventHelpId.Add(helpId);
					}
				}
			}
			//LAB_00f3a92c
			if(m_eventCtrl.GHAFMPBPJME())
			{
				if(m_eventCtrl.OGPMLMDPGJA > 0)
				{
					m_eventHelpId.Add(m_eventCtrl.OGPMLMDPGJA);
				}
			}
			m_isShowFirstHelp = true;
			if(!m_eventCtrl.CMPEJEHCOEI)
			{
				if(!m_eventCtrl.LPFJADHHLHG)
				{
					m_isShowFirstHelp = m_eventCtrl.GHAFMPBPJME();
				}
			}
			m_eventCtrl.CMPEJEHCOEI = false;
			m_eventCtrl.LPFJADHHLHG = false;
			m_eventCtrl.MMIMJPNLKBK();
		}

		// // RVA: 0xF3AA8C Offset: 0xF3AA8C VA: 0xF3AA8C Slot: 38
		protected virtual PlayButtonWrapper CreatePlayButtonWrapper()
		{
			return new PlayButton(m_cdSelect);
		}

		// // RVA: -1 Offset: -1 Slot: 39
		protected abstract void Release();

		// // RVA: -1 Offset: -1 Slot: 40
		protected abstract void SetupViewMusicData();

		// // RVA: 0xF3AB4C Offset: 0xF3AB4C VA: 0xF3AB4C Slot: 41
		protected virtual void ApplyBasicInfo()
		{
			string str = MessageManager.Instance.GetMessage("menu", "music_event_remain_prefix");
			m_eventBanner.SetMusicEventRemainPrefix(str);
			m_cdSelect.ApplyEventRemainTimePrefix(str);
			m_cdArrow.SetStyle(MusicSelectCDArrow.Style.Default);
			GHLGEECLCMH g = new GHLGEECLCMH();
			g.KHEKNNFCAOI(null, null);
			if(m_musicRate != null)
			{
				m_musicRate.ApplyHighScoreRating(g.LLNHMMBFPMA_ScoreRatingRanking, g.ECMFBEHEGEH_UtaRateTotal);
				m_musicRate.onClickButton = () =>
				{
					//0xF4A25C
					GameManager.Instance.CloseSnsNotice();
					GameManager.Instance.CloseOfferNotice();
					SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
					MenuScene.Instance.Call(TransitionList.Type.MUSIC_RATE, null, true);
				};
			}
		}

		// // RVA: 0xF3AE70 Offset: 0xF3AE70 VA: 0xF3AE70 Slot: 42
		protected virtual void ApplyMusicListInfo()
		{
			int cnt = currentMusicList.GetCount(m_isLine6Mode, m_isSimulationLive);
			if(cnt == 0)
			{
				m_cdSelect.SetStyleType(MusicSelectCDSelect.StyleType.None);
			}
			else if(cnt == 1)
			{
				m_cdSelect.SetStyleType(MusicSelectCDSelect.StyleType.Single);
			}
			else
			{
				m_cdSelect.SetStyleType(MusicSelectCDSelect.StyleType.Multi);
			}
			m_cdSelect.RefreshJackets();
			UpdateScrollLimit();
			UpdateScrollArrow();
			
		}

		// // RVA: 0xF3B180 Offset: 0xF3B180 VA: 0xF3B180 Slot: 43
		protected virtual void ApplyMusicInfo()
		{
			m_musicTimeWatcher.WatchStop();
			MenuScene.Instance.BgControl.ChangeTilingType(m_isSimulationLive ? BgBehaviour.TilingType.Cross : BgBehaviour.TilingType.Dot);
			if(m_isListEmptyByFilter)
			{
				MenuScene.Instance.BgControl.ChangeAttribute(GameAttribute.Type.None);
				ApplyFilterMusicInfoNone();
			}
			else if(listIsEmpty)
			{
				MenuScene.Instance.BgControl.ChangeAttribute(GameAttribute.Type.None);
				ApplyMusicInfoNone();
			}
			else if(selectMusicData.AJGCPCMLGKO_IsEvent)
			{
				MenuScene.Instance.BgControl.ChangeAttribute(GameAttribute.Type.None);
				ApplyMusicInfoExEvent(selectMusicData);
			}
			else if(selectMusicData.BNIAJAKIAJC_IsEventMinigame)
			{
				MenuScene.Instance.BgControl.ChangeAttribute(GameAttribute.Type.None);
				ApplyMusicInfoMiniGame(selectMusicData);
			}
			else if(selectMusicData.POEGGBGOKGI_IsInfoLiveEntrance)
			{
				MenuScene.Instance.BgControl.ChangeAttribute(GameAttribute.Type.None);
				ApplyMusicInfoLiveEntrance(selectMusicData);
			}
			else
			{
				ApplyMusicInfoNormal(selectMusicData);
			}
		}

		// // RVA: 0xF3E720 Offset: 0xF3E720 VA: 0xF3E720 Slot: 44
		protected virtual void DelayedApplyMusicInfo()
		{
			if(!listIsEmpty)
			{
				if(!selectMusicData.AJGCPCMLGKO_IsEvent)
				{
					if(!selectMusicData.BNIAJAKIAJC_IsEventMinigame)
					{
						if(!selectMusicData.IFNPBIJEPBO_IsDlded)
						{
							FadeOutBGM();
							return;
						}
						//LAB_00f3e7c8
						ChangeTrialMusic(selectMusicData.KKPAHLMJKIH_WavId);
						return;
					}
				}
				if(selectMusicData.KKPAHLMJKIH_WavId > 0)
				{
					//LAB_00f3e7c8
					ChangeTrialMusic(selectMusicData.KKPAHLMJKIH_WavId);
					return;
				}
			}
			//LAB_00f3e830
			FadeOutBGM();
		}

		// // RVA: 0xF3EB0C Offset: 0xF3EB0C VA: 0xF3EB0C
		private void SetDifficultyButton()
		{
			if(!m_isLine6Mode)
			{
				m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N5, false, m_isSimulationLive);
			}
			else
			{
				m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N3, true, m_isSimulationLive);
				if(diff < Difficulty.Type.Hard)
					diff = Difficulty.Type.Hard;
			}
			m_musicInfo.ChangeSelectedDiff(diff);
			if(m_rewardStats == null)
			{
				m_rewardStats = new List<MusicRewardStat>(5);
				for(int i = 4; i >= 0; i--)
				{
					m_rewardStats.Add(new MusicRewardStat());
				}
			}
			//LAB_00f3ec94
			for(int i = 0; i < 5; i++)
			{
				m_rewardStats[i].Clear();
			}
			for(int i = 0; i < 5; i++)
			{
				m_musicInfo.SetDiffLock((Difficulty.Type)i, false, true);
				m_musicInfo.SetDiffStatus((Difficulty.Type)i, false, false, RhythmGameConsts.ResultComboType.Illegal);
			}
		}

		// // RVA: 0xF3B5E8 Offset: 0xF3B5E8 VA: 0xF3B5E8
		protected void ApplyFilterMusicInfoNone()
		{
			m_musicInfo.SetInfoStyle(MusicSelectMusicInfo.InfoStyle.FilterNone, m_isLine6Mode);
			m_buttonSet.SetOptionStyle(0, false, false, false, false);
			playButtonUI.SetupUnitLive(null, null);
			SetDifficultyButton();
		}

		// // RVA: 0xF3B69C Offset: 0xF3B69C VA: 0xF3B69C
		protected void ApplyMusicInfoNone()
		{
			m_musicInfo.SetInfoStyle(MusicSelectMusicInfo.InfoStyle.None, m_isLine6Mode);
			m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.None, false, false, false, false);
			playButtonUI.SetupUnitLive(null, null);
		}

		// // RVA: 0xF3C8AC Offset: 0xF3C8AC VA: 0xF3C8AC
		protected void ApplyMusicInfoNormal(IBJAKJJICBC musicData)
		{
            MessageBank bk = MessageManager.Instance.GetBank("menu");
			MusicSelectMusicInfo.InfoStyle style;
			MusicSelectButtonSet.OptionStyle optionStyle;
			bool hasRanking, withoutReward, withoutEvRanking, withoutMission;
			withoutEvRanking = false;
			hasRanking = musicData.BJANNALFGGA_HasRanking;
			if(!m_isSimulationLive)
			{
				if(!musicData.LEBDMNIGOJB_IsScoreEvent)
				{
					optionStyle = MusicSelectButtonSet.OptionStyle.Basic;
					if(musicData.MNNHHJBBICA_GameEventType == 6)
					{
						style = MusicSelectMusicInfo.InfoStyle.Music;
						withoutReward = false;
						if(musicData.DEPGBBJMFED_CategoryId == 5)
						{
							style = MusicSelectMusicInfo.InfoStyle.NoReward;
							if(musicData.LHONOILACFL_IsWeeklyEvent)
							{
								style = MusicSelectMusicInfo.InfoStyle.Music;
							}
							withoutReward = !musicData.LHONOILACFL_IsWeeklyEvent;
						}
						withoutMission = !IsEnableEvMission();
						withoutEvRanking = !m_eventCtrl.IBNKPMPFLGI_IsRankReward;
						optionStyle = MusicSelectButtonSet.OptionStyle.Basic;
					}
					else if(musicData.MNNHHJBBICA_GameEventType == 3)
					{
						withoutMission = !IsEnableEvMission();
						style = MusicSelectMusicInfo.InfoStyle.BattleEvent;
						withoutEvRanking = !m_eventCtrl.IBNKPMPFLGI_IsRankReward;
						withoutReward = true;
						optionStyle = MusicSelectButtonSet.OptionStyle.BattleEvent;
					}
					else
					{
						withoutEvRanking = false;
						withoutMission = false;
						style = MusicSelectMusicInfo.InfoStyle.Music;
						withoutReward = false;
						if(musicData.MNNHHJBBICA_GameEventType == 1)
						{
							withoutMission = !IsEnableEvMission();
							optionStyle = MusicSelectButtonSet.OptionStyle.CollectEvent;
							withoutEvRanking = !m_eventCtrl.IBNKPMPFLGI_IsRankReward;
							withoutReward = true;
							style = MusicSelectMusicInfo.InfoStyle.NoReward;
						}
					}
				}
				else
				{
					optionStyle = MusicSelectButtonSet.OptionStyle.ScoreEvent;
					withoutEvRanking = false;
					withoutMission = false;
					withoutReward = false;
					style = MusicSelectMusicInfo.InfoStyle.Music;
				}
			}
			else
			{
				style = MusicSelectMusicInfo.InfoStyle.SimulationLive;
				withoutReward = true;
				optionStyle = MusicSelectButtonSet.OptionStyle.SimulationLive;
				withoutMission = false;
			}
			m_musicInfo.SetInfoStyle(style, m_isLine6Mode);
			m_buttonSet.SetOptionStyle(optionStyle, hasRanking, withoutReward, withoutEvRanking, withoutMission);
			m_buttonSet.SetEventRankingCountin(m_eventStatus == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6);
			if(musicData.IFNPBIJEPBO_IsDlded)
			{
				if(!m_isSimulationLive)
				{
					if(!musicData.HDPMAJKGIOI)
					{
						playButtonUI.SetType(PlayButtonWrapper.Type.PlayEn);
					}
					// else LAB_00f3ccb4
				}
				else
				{
					playButtonUI.SetType(PlayButtonWrapper.Type.Play);
				}
			}
			else if(!musicData.HDPMAJKGIOI)
			{
				playButtonUI.SetType(PlayButtonWrapper.Type.Download);
			}
			//LAB_00f3ccb4
			if(!m_isLine6Mode)
			{
				if(musicData.PJLNJJIBFBN_HasExtremeDiff)
				{
					m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N5, m_isLine6Mode, m_isSimulationLive);
				}
				else
				{
					m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N4, m_isLine6Mode, m_isSimulationLive);
					if(diff < Difficulty.Type.VeryHard)
						diff = Difficulty.Type.VeryHard;
				}
			}
			else
			{
				m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N3, true, m_isSimulationLive);
				if(diff < Difficulty.Type.Hard)
					diff = Difficulty.Type.Hard;
			}
			for(int i = musicData.MGJKEJHEBPO_DiffInfos.Count - 1; i >= 0; i--)
			{
				if(musicData.MGJKEJHEBPO_DiffInfos[i].POOMOBGPCNE_IsLocked && i <= (int)diff)
				{
					diff = (Difficulty.Type)(i - 1);
				}
			}
			if(!m_isSimulationLive)
			{
				if(!musicData.HDPMAJKGIOI)
				{
					playButtonUI.SetNeedEnergy(musicData.MGJKEJHEBPO_DiffInfos[(int)diff].BPLOEAHOPFI_Energy);
				}
			}
			m_buttonSet.SetEnemyHasSkill(musicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.CDEFLIHHNAB_HasSkills);
			m_buttonSet.SetBadge(MusicSelectOptionButton.OptionType.EvMission, IsReceiveMission());
			m_buttonSet.SetBadge(MusicSelectOptionButton.OptionType.EvStory, IsNewStory());
			if(musicData.LEBDMNIGOJB_IsScoreEvent && !m_isSimulationLive)
			{
				m_cdSelect.ApplyEventCounting(m_isScoreEventTimeLimit);
			}
			else
			{
				m_cdSelect.ApplyEventCounting(false);
			}
			m_musicInfo.ChangeSelectedDiff(diff);
			m_musicInfo.SetMusicTitle(musicData.NEDBBJDAFBH_MusicName, GameAttributeTextColor.Colors[musicData.FKDCCLPGKDK_JacketAttr - 1], m_isSimulationLive);
			m_musicInfo.SetSingerName(musicData.LJCEDBBNPBB_VocalName, m_isSimulationLive);
			if(musicData.MGJKEJHEBPO_DiffInfos[(int)diff].HHMLMKAEJBJ_Score != null)
			{
				StringBuilder str = new StringBuilder(8);
				str.Set(musicData.MGJKEJHEBPO_DiffInfos[(int)diff].HHMLMKAEJBJ_Score.ANAJIAENLNB_MusicLevel.ToString());
				if(m_isLine6Mode)
					str.Append("+");
				m_musicInfo.SetMusicLevel(str.ToString());
			}
			SetupRewardStat(musicData);
			for(int i = 0; i < musicData.MGJKEJHEBPO_DiffInfos.Count; i++)
			{
				m_musicInfo.SetDiffLock((Difficulty.Type)i, musicData.MGJKEJHEBPO_DiffInfos[i].POOMOBGPCNE_IsLocked, true);
				m_musicInfo.SetDiffStatus((Difficulty.Type)i, musicData.MGJKEJHEBPO_DiffInfos[i].CADENLBDAEB_IsNew && !m_isSimulationLive, musicData.MGJKEJHEBPO_DiffInfos[i].BCGLDMKODLC_IsClear && !m_isSimulationLive, (RhythmGameConsts.ResultComboType)musicData.MGJKEJHEBPO_DiffInfos[i].LCOHGOIDMDF_ComboRank);
			}
			if(!musicData.HDPMAJKGIOI)
			{
				m_cdSelect.ApplyCursorNew(musicData.LDGOHPAPBMM_IsNew  && !m_isSimulationLive);
			}
			if(!musicData.HDPMAJKGIOI)
			{
				if(withoutReward)
				{
					m_cdSelect.HideCursorRewardMark();
				}
				else
				{
					m_musicInfo.SetReward(m_rewardStats[(int)diff].allAchievedNum, m_rewardStats[(int)diff].allRewardNum);
					m_cdSelect.ShowCursorRewardMark(m_rewardStats[(int)diff].isScoreComplete, m_rewardStats[(int)diff].isComboComplete, m_rewardStats[(int)diff].isClearCountComplete);
				}
			}
			if(!m_isSimulationLive)
			{
				if(!musicData.HDPMAJKGIOI)
				{
					if(musicData.MGJKEJHEBPO_DiffInfos[(int)diff].BCGLDMKODLC_IsClear)
					{
						m_musicInfo.SetHighscore(musicData.MGJKEJHEBPO_DiffInfos[(int)diff].KNIFCANOHOC_Score);
						m_musicInfo.SetMusicScoreRank((ResultScoreRank.Type)musicData.MGJKEJHEBPO_DiffInfos[(int)diff].BAKLKJLPLOJ.DLPBHJALHCK_GetScoreRank(musicData.MGJKEJHEBPO_DiffInfos[(int)diff].KNIFCANOHOC_Score));
					}
					else
					{
						m_musicInfo.SetHighscore(0);
						m_musicInfo.SetMusicScoreRank(ResultScoreRank.Type.Illegal);
					}
					m_musicInfo.SetMusicAttr((GameAttribute.Type)musicData.FKDCCLPGKDK_JacketAttr);
					m_cdSelect.ApplyCursorAttr((GameAttribute.Type)musicData.FKDCCLPGKDK_JacketAttr);
					if(m_eventStatus <= KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
					{
						MenuScene.Instance.BgControl.ChangeAttribute((GameAttribute.Type)musicData.FKDCCLPGKDK_JacketAttr);
					}
					else
					{
						//LAB_00f3dae8
						MenuScene.Instance.BgControl.ChangeAttribute(GameAttribute.Type.None);
					}
				}
				else
				{
					MenuScene.Instance.BgControl.ChangeAttribute(GameAttribute.Type.None);
				}
			}
			else
			{
				m_musicInfo.SetMusicAttr(GameAttribute.Type.None);
				m_cdSelect.ApplyCursorSLiveFrame();
				//LAB_00f3dae8
				MenuScene.Instance.BgControl.ChangeAttribute(GameAttribute.Type.None);
			}
			if(!musicData.HDPMAJKGIOI)
			{
				m_musicInfo.SetMusicComboRank((RhythmGameConsts.ResultComboType)musicData.MGJKEJHEBPO_DiffInfos[(int)diff].LCOHGOIDMDF_ComboRank, musicData.MGJKEJHEBPO_DiffInfos[(int)diff].NLKEBAOBJCM_Combo);
			}
			if(!musicData.HDPMAJKGIOI)
			{
				playButtonUI.SetDisable(false);
				m_cdSelect.ApplyEventBonus(musicData.DBJOBFIGGEE_EventBonusPercent);
				m_cdSelect.ApplyMusicRatio(selectMusicData.AKAPOCOIECA_GetMusicRatio(), selectMusicData.DEPGBBJMFED_CategoryId != 5 && !m_isSimulationLive);
				m_cdSelect.ApplyCursorWeekRecoveryIcon(false);
				m_cdSelect.EnableEventMusicRank(false);
				m_cdSelect.ApplyEventMusicRank(0);
			}
			m_cdSelect.ApplyCursorEventRemainCount(-1, false);
			m_cdSelect.ApplyCursorStepCount(musicData.JJEFMIHJMHC_CursorStepCount);
			if(!musicData.AJGCPCMLGKO_IsEvent && !musicData.POEGGBGOKGI_IsInfoLiveEntrance && musicData.JOJPMFNJJPD_HasEventMusicRank)
			{
				m_cdSelect.EnableEventMusicRank(true);
				m_cdSelect.ApplyEventMusicRank(musicData.OPPBIOEJAND_EventMusicRank);
			}
			else
			{
				m_cdSelect.EnableEventMusicRank(false);
			}
			m_cdSelect.EnableEventGoDivaExpBonus(false);
			m_cdSelect.EnableEventGoDivaRanking(false);
			m_cdSelect.HideEventFoDivaExp();
			if(musicData.LHONOILACFL_IsWeeklyEvent && !m_isSimulationLive)
			{
				m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.Weekly, false);
				if(musicData.MOJMEFIENDM_WeeklyEventCount < 1)
				{
					m_cdSelect.ApplyEventEndMessage(bk.GetMessageByLabel("music_week_play_count_limit"));
					m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.Disable, false);
					m_cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.None);
					m_cdSelect.ApplyCursorWeekRecoveryIcon(true);
				}
				else
				{
					ApplyRemainTime(musicData.NKEIFPPGNLH_WeeklyendTime, true, null);
					ApplyTicletDropIcon();
					m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.Weekly, false);
				}
				m_cdSelect.ApplyCursorEventRemainCount(musicData.MOJMEFIENDM_WeeklyEventCount, musicData.GDLNCHCPMCK_HasBoost);
				List<int> l = new List<int>(3);
				for(int i = 0; i < 3; i++)
				{
					int v = musicData.ICHJBDPJNMA_GetWeeklyItem(musicData.IHKFMJDOBAH_WeekDayAttr, i);
					if(v > 0)
						l.Add(v);
				}
				m_cdSelect.ApplyEventItems(l);
			}
			else
			{
				if(musicData.LEBDMNIGOJB_IsScoreEvent && !m_isSimulationLive)
				{
					m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.Score, false);
					m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.ScoreEvent, false);
					m_cdSelect.ApplyEventRank(m_scoreEventCtrl.CDINKAANIAA_Rank[0]);
					if(!m_isScoreEventTimeLimit)
					{
						ApplyRemainTime(m_scoreEventCtrl.DPJCPDKALGI_End1, false, null);
					}
					else
					{
						m_cdSelect.ApplyEventEndMessage(bk.GetMessageByLabel("music_event_end_score_rank"));
						m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.Disable, false);
						playButtonUI.SetDisable(true);
					}
				}
				else
				{
					if(musicData.AJGCPCMLGKO_IsEvent && m_isSimulationLive)
					{
						ApplyMusicInfoExEvent(musicData);
					}
					else
					{
						if(musicData.BNIAJAKIAJC_IsEventMinigame && !m_isSimulationLive)
						{
							ApplyMusicInfoMiniGame(musicData);
						}
						else
						{
							ApplyMusicInfoBasic(musicData);
							if(musicData.KCKBOIDCPCK_CdSelectEvenType > 0)
							{
								m_cdSelect.ApplyCursorEventType((MusicSelectCDSelect.EventType)musicData.KCKBOIDCPCK_CdSelectEvenType - 1, false);
							}
						}
					}
				}
			}
			playButtonUI.SetupUnitLive(musicData, m_unitLiveLocalSaveData);
			m_cdSelect.ApplyCursorLimited(musicData.NNJNNCGGKMC_IsLimited);
			if(musicData.NNJNNCGGKMC_IsLimited)
			{
				ApplyRemainTime(musicData.IHPCKOMBGKJ_End, true, null);
			}
        }

		// // RVA: 0xF3B748 Offset: 0xF3B748 VA: 0xF3B748
		protected void ApplyMusicInfoExEvent(IBJAKJJICBC musicData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_musicInfo.SetInfoStyle(MusicSelectMusicInfo.InfoStyle.Event, m_isLine6Mode);
			m_buttonSet.SetEventRankingCountin(false);
			m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.None, false, false, false, false);
			playButtonUI.SetType(PlayButtonWrapper.Type.Event);
			m_musicInfo.SetEventTitle(musicData.AFCMIOIGAJN_EventInfo.OPFGFINHFCE_EventName);
			m_musicInfo.SetEventDesc(musicData.AFCMIOIGAJN_EventInfo.KLMPFGOCBHC_EventDesc);
			m_cdSelect.ApplyCursorNew(musicData.LDGOHPAPBMM_IsNew);
			m_cdSelect.ApplyCursorAttr(GameAttribute.Type.None);
			m_cdSelect.ApplyCursorEventType(m_eventCtrl.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid ? MusicSelectCDSelect.EventType.Raid : MusicSelectCDSelect.EventType.Special, false);
			m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.ExEvent,false);
			m_cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.None);
			m_cdSelect.ApplyCursorEventRemainCount(-1, false);
			m_cdSelect.ApplyCursorWeekRecoveryIcon(false);
			m_cdSelect.ApplyCursorLimited(false);
			m_cdSelect.EnableEventMusicRank(false);
			m_cdSelect.EnableEventGoDivaExpBonus(false);
			m_cdSelect.EnableEventGoDivaRanking(false);
			m_cdSelect.HideEventFoDivaExp();
			m_cdSelect.ApplyCursorStepCount(0);
			m_cdSelect.HideCursorRewardMark();
			playButtonUI.SetupUnitLive(null, null);
			playButtonUI.SetDisable(false);
			m_cdSelect.ApplyEventBonus(0);
			m_cdSelect.ApplyMusicRatio(0, false);
			int y, m, d, M, S;
			ExtractDateTime(musicData.AFCMIOIGAJN_EventInfo.KINJOEIAHFK_OpenTime, out y, out m, out d, out M, out S);
			string s = MakeDateTime(y, m, d, M, S);
			ExtractDateTime(musicData.AFCMIOIGAJN_EventInfo.PCCFAKEOBIC_CloseTime, out y, out m, out d, out M, out S);
			string s2 = MakeDateTime(y, m, d, M, S);
			m_musicInfo.SetEventPeriod(string.Format(RichTextUtility.MakeColorTagString(bk.GetMessageByLabel("music_event_period"), SystemTextColor.ImportantColor), s, s2));
			if(!m_isEventTimeLimit)
			{
				ApplyRemainTime(musicData.AFCMIOIGAJN_EventInfo.PCCFAKEOBIC_CloseTime, true, null);
				m_cdSelect.ApplyEventCounting(false);
			}
			else
			{
				m_cdSelect.ApplyEventEndMessage(bk.GetMessageByLabel("music_event_end_attain"));
				m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.Disable, musicData.AJGCPCMLGKO_IsEvent);
				m_cdSelect.ApplyEventCounting(true);
				playButtonUI.SetDisable(!musicData.AJGCPCMLGKO_IsEvent);
			}
		}

		// // RVA: 0xF3BEE4 Offset: 0xF3BEE4 VA: 0xF3BEE4
		protected void ApplyMusicInfoMiniGame(IBJAKJJICBC musicData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_musicInfo.SetInfoStyle(MusicSelectMusicInfo.InfoStyle.Event, m_isLine6Mode);
			m_buttonSet.SetEventRankingCountin(false);
			m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.None, false, false, false, false);
			playButtonUI.SetType(PlayButtonWrapper.Type.Play);
			m_musicInfo.SetEventTitle(musicData.NOKBLCDMLPP_MinigameEventInfo.OPFGFINHFCE_EventName);
			m_musicInfo.SetEventDesc(musicData.NOKBLCDMLPP_MinigameEventInfo.KLMPFGOCBHC_EventDesc);
			m_cdSelect.ApplyCursorNew(musicData.LDGOHPAPBMM_IsNew);
			m_cdSelect.ApplyCursorAttr(GameAttribute.Type.None);
			m_cdSelect.ApplyCursorEventType(musicData.KCKBOIDCPCK_CdSelectEvenType < 1 ? MusicSelectCDSelect.EventType.Special : (MusicSelectCDSelect.EventType)(musicData.KCKBOIDCPCK_CdSelectEvenType - 1), false);
			m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.ExEvent, false);
			m_cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.None);
			m_cdSelect.ApplyCursorEventRemainCount(-1, false);
			m_cdSelect.ApplyCursorWeekRecoveryIcon(false);
			m_cdSelect.ApplyCursorLimited(false);
			m_cdSelect.EnableEventMusicRank(false);
			m_cdSelect.EnableEventGoDivaExpBonus(false);
			m_cdSelect.EnableEventGoDivaRanking(false);
			m_cdSelect.HideEventFoDivaExp();
			m_cdSelect.ApplyCursorStepCount(0);
			m_cdSelect.HideCursorRewardMark();
			playButtonUI.SetupUnitLive(null, null);
			playButtonUI.SetDisable(false);
			m_cdSelect.ApplyEventBonus(0);
			m_cdSelect.ApplyMusicRatio(0, false);
			int y, m, d, M, S;
			ExtractDateTime(musicData.NOKBLCDMLPP_MinigameEventInfo.KINJOEIAHFK_OpenTime, out y, out m, out d, out M, out S);
			string s = MakeDateTime(y, m, d, M, S);
			ExtractDateTime(musicData.NOKBLCDMLPP_MinigameEventInfo.PCCFAKEOBIC_CloseTime, out y, out m, out d, out M, out S);
			string s2 = MakeDateTime(y, m, d, M, S);
			m_musicInfo.SetEventPeriod(string.Format(RichTextUtility.MakeColorTagString(bk.GetMessageByLabel("music_event_period"), SystemTextColor.ImportantColor), s, s2));
			ApplyRemainTime(musicData.NOKBLCDMLPP_MinigameEventInfo.PCCFAKEOBIC_CloseTime, true, null);
			m_cdSelect.ApplyEventCounting(false);
		}

		// // RVA: 0xF3C588 Offset: 0xF3C588 VA: 0xF3C588
		protected void ApplyMusicInfoLiveEntrance(IBJAKJJICBC musicData)
		{
			m_musicInfo.SetInfoStyle(MusicSelectMusicInfo.InfoStyle.None, m_isLine6Mode);
			m_buttonSet.SetOptionStyle(MusicSelectButtonSet.OptionStyle.None, false, false, false, false);
			playButtonUI.SetType(PlayButtonWrapper.Type.Live);
			m_musicInfo.SetNoInfoMessage(GetLiveEntranceMessage(musicData), null);
			m_cdSelect.ApplyCursorNew(false);
			m_cdSelect.ApplyCursorAttr(GameAttribute.Type.None);
			m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.None, false);
			m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.None, false);
			m_cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.None);
			m_cdSelect.HideCursorRewardMark();
			m_cdSelect.EnableEventMusicRank(false);
			m_cdSelect.EnableEventGoDivaExpBonus(false);
			m_cdSelect.EnableEventGoDivaRanking(false);
			m_cdSelect.HideEventFoDivaExp();
			m_cdSelect.ApplyEventMusicRank(0);
			playButtonUI.SetupUnitLive(null, null);
			playButtonUI.SetDisable(false);
			m_cdSelect.ApplyEventBonus(0);
			m_cdSelect.ApplyMusicRatio(0, false);
		}

		// // RVA: 0xF3FAA0 Offset: 0xF3FAA0 VA: 0xF3FAA0 Slot: 45
		protected virtual string GetLiveEntranceMessage(IBJAKJJICBC musicData)
		{
			return "";
		}

		// // RVA: 0xF3FB04 Offset: 0xF3FB04 VA: 0xF3FB04 Slot: 46
		protected virtual void ApplyMusicInfoBasic(IBJAKJJICBC musicData)
		{
			if(m_isSimulationLive)
			{
				ApplyMusicInfoSimulationLive(musicData);
			}
			else
			{
				ApplyTicletDropIcon();
				m_cdSelect.ApplyCursorEventType(musicData.OGHOPBAKEFE_IsEventSpecial ? MusicSelectCDSelect.EventType.Special : MusicSelectCDSelect.EventType.None, false);
				m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.None, false);
			}
		}

		// // RVA: 0xF3FBC0 Offset: 0xF3FBC0 VA: 0xF3FBC0 Slot: 47
		protected virtual void ApplyMusicInfoSimulationLive(IBJAKJJICBC musicData)
		{
			if(musicData.DEPGBBJMFED_CategoryId == 5)
			{
				if(musicData.LHONOILACFL_IsWeeklyEvent)
				{
					m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.Weekly, m_isSimulationLive);
				}
				else
				{
					if(musicData.LEBDMNIGOJB_IsScoreEvent)
					{
						m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.Score, m_isSimulationLive);
					}
					else
					{
						if(!musicData.LGIGMPBHJCI)
						{
							if(musicData.KCKBOIDCPCK_CdSelectEvenType < 1)
							{
								m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.None, false);
							}
							else
							{
								m_cdSelect.ApplyCursorEventType((MusicSelectCDSelect.EventType)musicData.KCKBOIDCPCK_CdSelectEvenType - 1, false);
							}
						}
						else
						{
							m_cdSelect.ApplyCursorEventType(m_eventCtrl.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid ? MusicSelectCDSelect.EventType.Raid : MusicSelectCDSelect.EventType.Special, m_isSimulationLive);
						}
					}
				}
			}
			else
			{
				m_cdSelect.ApplyCursorEventType(MusicSelectCDSelect.EventType.None, false);
			}
			if((!m_isScoreEventTimeLimit || musicData.LEBDMNIGOJB_IsScoreEvent) && !(m_isEventTimeLimit && musicData.LGIGMPBHJCI))
			{
				ApplyRemainTime(musicData.ALMOMLMCHNA_OtherEndTime, true, null);
				m_cdSelect.ApplyEventCounting(false);
				m_cdSelect.ApplyCursorEventStyle(musicData.AHAEGEHKONB_GetOtherTimeLeft() < 0 ? MusicSelectCDSelect.EventStyle.SimulationLive : MusicSelectCDSelect.EventStyle.ExTicket, false);
			}
			else
			{
				//LAB_00f3fe50
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				m_cdSelect.ApplyEventEndMessage(bk.GetMessageByLabel("music_event_end_attain"));
				m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.Disable, false);
				m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.None, m_isLine6Mode, m_isSimulationLive);
				m_cdSelect.ApplyEventCounting(true);
				playButtonUI.SetDisable(true);
			}
			m_cdSelect.EventTicketEnable(false);
			m_cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.None);
			m_cdSelect.SetEventItemIcon(null);
			GameManager.Instance.ItemTextureCache.Load(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IGIFMNJADEC_MvTicket, 1), (IiconTexture image) =>
			{
				//0xF496BC
				m_cdSelect.EventTicketEnable(true);
				m_cdSelect.SetEventItemIcon(image);
			});
			m_cdSelect.ApplyEventTicketCount(1);
		}

		// // RVA: 0xF40200 Offset: 0xF40200 VA: 0xF40200 Slot: 48
		protected virtual void ApplyUnitLiveButtonSetting(bool isUnit)
		{
			m_unitLiveLocalSaveData.IAGAAOKODPM_SetMultiDiva(selectMusicData.GHBPLHBNMBK_FreeMusicId, isUnit);
			playButtonUI.SetupUnitLive(selectMusicData, m_unitLiveLocalSaveData);
		}

		// // RVA: 0xF3F2E8 Offset: 0xF3F2E8 VA: 0xF3F2E8
		protected void ApplyRemainTime(long endTime, bool makeColor, LimitTimeWatcher.OnEndCallback endCallback)
		{
			m_musicTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
			{
				//0xF4B33C
				ApplyEventRemainTime(remain, makeColor);
			};
			m_musicTimeWatcher.onEndCallback = endCallback;
			m_musicTimeWatcher.WatchStart(endTime, true);
		}

		// // RVA: 0xF402A4 Offset: 0xF402A4 VA: 0xF402A4
		protected void ApplyEventRemainTime(long remainSec, bool makeColor)
		{
			int days = (int)(remainSec % 86400);
			remainSec -= days * 86400;
			int hours = (int)(remainSec % 3600);
			remainSec -= hours * 3600;
			int min = (int)(remainSec % 60);
			remainSec -= min * 60;
			string str = MakeRemainTime(days, hours, min, (int)remainSec);
			if(makeColor)
				str = RichTextUtility.MakeColorTagString(str, SystemTextColor.ImportantColor);
			m_cdSelect.ApplyEventRemainTime(str);
		}

		// // RVA: 0xF4066C Offset: 0xF4066C VA: 0xF4066C
		// protected void ApplyEventBannerRemainTime(long remainSec, bool makeColor) { }

		// // RVA: 0xF3F448 Offset: 0xF3F448 VA: 0xF3F448
		protected void ApplyTicletDropIcon()
		{
			m_cdSelect.EventTicketEnable(false);
			if(m_eventTicketId < 1)
			{
				m_cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.None);
			}
			else
			{
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_eventTicketId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
					m_cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.FoldRadar);
				else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(m_eventTicketId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
					m_cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.Ticket);
				GameManager.Instance.ItemTextureCache.Load(m_eventTicketId, (IiconTexture image) =>
				{
					//0xF49718
					m_cdSelect.EventTicketEnable(true);
					m_cdSelect.SetEventTicketIcon(image);
				});
			}
		}

		// // RVA: 0xF407DC Offset: 0xF407DC VA: 0xF407DC
		protected void DownloadCurrentMusic()
		{
			m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
			this.StartCoroutineWatched(Co_DownloadMusic(selectMusicData));
		}

		// // RVA: 0xF408DC Offset: 0xF408DC VA: 0xF408DC
		protected void GotoEventMusicSelect(int eventId)
		{
			if(eventId > 0)
			{
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventId);
				if(ev != null && ev.FBLGGLDPFDF_CanShowStartAdventure())
				{
                    GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(ev.GFIBLLLHMPD_StartAdventureId);
					if(adv != null)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(ev.GFIBLLLHMPD_StartAdventureId);
						ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(ev.GFIBLLLHMPD_StartAdventureId, OAGBCBBHMPF.DKAMMIHBINF.IDINJDEBPKP_6);
						Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
						Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTMUSICSELECT, new AdvSetupParam() { eventUniqueId = eventId });
						MenuScene.Instance.GotoAdventure(false);
						return;
					}
				}
            }
			MenuScene.Instance.Mount(TransitionUniqueId.EVENTMUSICSELECT, new EventMusicSelectSceneArgs(eventId, m_isLine6Mode, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0xF40D2C Offset: 0xF40D2C VA: 0xF40D2C
		protected void GotoMiniGame(int miniGameId)
		{
			MenuScene.Instance.GotoMiniGame(miniGameId);
		}

		// // RVA: 0xF40DD0 Offset: 0xF40DD0 VA: 0xF40DD0
		// protected void GotoEventQuest(int eventId) { }

		// // RVA: 0xF41220 Offset: 0xF41220 VA: 0xF41220
		protected void GotoEventBattle(int eventId)
		{
			if(eventId > 0)
			{
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventId);
				if(ev != null && ev.FBLGGLDPFDF_CanShowStartAdventure())
				{
                    GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(ev.GFIBLLLHMPD_StartAdventureId);
					if(adv != null)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(ev.GFIBLLLHMPD_StartAdventureId);
						ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(ev.GFIBLLLHMPD_StartAdventureId, OAGBCBBHMPF.DKAMMIHBINF.IDINJDEBPKP_6);
						Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
						Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTBATTLE, new AdvSetupParam() { eventUniqueId = eventId });
						MenuScene.Instance.GotoAdventure(false);
						return;
					}
                }
            }
			MenuScene.Instance.Mount(TransitionUniqueId.EVENTBATTLE, new EventMusicSelectSceneArgs(eventId, m_isLine6Mode, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0xF41670 Offset: 0xF41670 VA: 0xF41670
		// protected void GotoEventRaid(int eventId) { }

		// // RVA: 0xF41DD0 Offset: 0xF41DD0 VA: 0xF41DD0
		protected void GotoEventGoDiva(int eventId)
		{
			if(eventId > 0)
			{
                IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(eventId);
				if(ev != null && ev.FBLGGLDPFDF_CanShowStartAdventure())
				{
                    GPMHOAKFALE_Adventure.NGDBKCKMDHE_AdventureData adv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFMAIKAHFEK_Adventure.GCINIJEMHFK_GetAdventure(ev.GFIBLLLHMPD_StartAdventureId);
					if(adv != null)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HBPPNFHOMNB_Adventure.GFANLIOMMNA_SetReleased(ev.GFIBLLLHMPD_StartAdventureId);
						ILCCJNDFFOB.HHCJCDFCLOB.LIIJEGOIKDP(ev.GFIBLLLHMPD_StartAdventureId, OAGBCBBHMPF.DKAMMIHBINF.IDINJDEBPKP_6);
						Database.Instance.advSetup.Setup(adv.KKPPFAHFOJI_FileId);
						Database.Instance.advResult.Setup("Menu", TransitionUniqueId.EVENTGODIVA, new AdvSetupParam() { eventUniqueId = eventId });
						MenuScene.Instance.GotoAdventure(false);
						return;
					}
				}
            }
			MenuScene.Instance.Mount(TransitionUniqueId.EVENTGODIVA, new EventMusicSelectSceneArgs(eventId, m_isLine6Mode, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0xF42220 Offset: 0xF42220 VA: 0xF42220
		protected void GotoRegularMusicSelect()
		{
			MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}

		// // RVA: 0xF422D8 Offset: 0xF422D8 VA: 0xF422D8
		private void CheckBoostData(Action endCallback, Action cancelCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_CheckBoostData(endCallback, cancelCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F425C Offset: 0x6F425C VA: 0x6F425C
		// // RVA: 0xF42398 Offset: 0xF42398 VA: 0xF42398
		private IEnumerator Co_CheckBoostData(Action endCallback, Action cancelCallback)
		{
			MKIKFJKPEHK viewBoostData;

			//0xF4BB10
			Database.Instance.gameSetup.ResetSelectedDashIndex();
			if(m_eventCtrl != null)
				m_eventCtrl.OJGHCKMPJFP();
			viewBoostData = new MKIKFJKPEHK();
			bool doCheck = false;
			if(viewBoostData.DPICLLJJPAC(selectMusicData, (int)diff, m_isLine6Mode))
			{
                MessageBank bk = MessageManager.Instance.GetBank("menu");
				LayoutPopupDash.CostType v = LayoutPopupDash.CostType.Energy;
				string s = "popup_dash_energy_title";
				if(viewBoostData.NMKDLINPAFM_UseTicket)
				{
					v = LayoutPopupDash.CostType.Ticket;
					s = "popup_dash_ticket_title";
				}
				PopupDashContentSetting.InitParam[] p = new PopupDashContentSetting.InitParam[viewBoostData.KLOOIJIDKGO_Cost.Count];
				for(int i = 0; i < viewBoostData.KLOOIJIDKGO_Cost.Count; i++)
				{
					p[i] = new PopupDashContentSetting.InitParam();
					p[i].Rate = viewBoostData.BGIKOPLLDJB_Rate[i];
					p[i].Cost = viewBoostData.KLOOIJIDKGO_Cost[i];
				}
				PopupDashContentSetting setting = new PopupDashContentSetting();
				setting.EventId = m_eventId;
				setting.CostType = v;
				setting.OwnValue = viewBoostData.DCLKMNGMIKC();
				setting.Param = p;
				setting.WindowSize = SizeType.Middle;
				setting.TitleText = bk.GetMessageByLabel(s);
				setting.Buttons = new ButtonInfo[2]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Cancel, Type = PopupButton.ButtonType.Negative },
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Play, Type = PopupButton.ButtonType.Live }
				};
				setting.OnSelectCallback = (int index) =>
				{
					//0xF4A490
					Database.Instance.gameSetup.SetSelectedDashIndex(index);
				};
				bool done = false;
				bool cancel = false;
				PopupWindowManager.Show(setting, (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
				{
					//0xF4B394
					if(type == PopupButton.ButtonType.Negative)
						cancel = true;
				}, null, null, null, true, true, false, null, () =>
				{
					//0xF4B3A4
					done = true;
				});
				//LAB_00f4c590
				while(!done)
					yield return null;
				if(cancel)
				{
					if(cancelCallback != null)
						cancelCallback();
					yield break;
				}
				MenuScene.Instance.InputDisable();
				viewBoostData.PPCLCOPGBBK(Database.Instance.gameSetup.SelectedDashIndex);
				if(!CurrentMusicDecisionCheck(cancelCallback, viewBoostData, Database.Instance.gameSetup.SelectedDashIndex))
				{
					//LAB_00f4c0cc
					while(!MenuScene.Instance.DirtyChangeScene)
						yield return null;
					MenuScene.Instance.InputEnable();
					yield break;
				}
				doCheck = true;
            }
			else
			{
				if(!CurrentMusicDecisionCheck(cancelCallback, null, 0))
					yield break;
				doCheck = false;
			}
			if(endCallback != null)
				endCallback();
			if(!doCheck)
				yield break;
			//LAB_00f4c0cc
			while(!MenuScene.Instance.DirtyChangeScene)
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xF42478 Offset: 0xF42478 VA: 0xF42478
		private void CheckSimulationLive(Action endCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_CheckSimulationLive(endCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F42D4 Offset: 0x6F42D4 VA: 0x6F42D4
		// // RVA: 0xF42528 Offset: 0xF42528 VA: 0xF42528
		private IEnumerator Co_CheckSimulationLive(Action endCallback)
		{
            //0xF4C8BC
            MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GKKDNOFMJJN_NumTicket > 0)
			{
				if(endCallback != null)
					endCallback();
				yield break;
			}
			bool done = false;
			PopupWindowManager.Show(PopupWindowManager.CrateTextContent(bk.GetMessageByLabel("mvmode_check_popup_title"), SizeType.Small, string.Format(bk.GetMessageByLabel("mvmode_check_popup_text"), 1), new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			}, false, true), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xF4A528
				return;
			}, null, null, null, true, true, false, null, () =>
			{
				//0xF4B3B8
				done = true;
			});
			while(!done)
				yield return null;
			
        }

		// // RVA: 0xF425D4 Offset: 0xF425D4 VA: 0xF425D4 Slot: 49
		protected virtual int GetDanceDivaCount()
		{
			return m_cdSelect.GetDanceDivaCount();
		}

		// // RVA: 0xF42600 Offset: 0xF42600 VA: 0xF42600
		private void CheckUnitLive(Action endCallback)
		{
			GameManager.Instance.StartCoroutineWatched(Co_CheckUnitLive(endCallback));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F434C Offset: 0x6F434C VA: 0x6F434C
		// // RVA: 0xF426B8 Offset: 0xF426B8 VA: 0xF426B8
		private IEnumerator Co_CheckUnitLive(Action endCallback)
		{
			int danceDivaCount; // 0x20
			bool isUnitOnly; // 0x24
			UnityAction<bool> positiveAction; // 0x28
			UnityAction<bool> negativeAction; // 0x2C
			UnityAction toggleAction; // 0x30
			GameManager.PushBackButtonHandler handler; // 0x34

			//0xF4CE7C
			danceDivaCount = GetDanceDivaCount();
			if(danceDivaCount >= 2)
			{
				int c = 0;
				for(int i = 0; i < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
				{
					c += CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_Have;
				}
				if(c < danceDivaCount)
				{
					bool done = false;
					PopupWindowManager.Show(PopupWindowManager.CrateTextContent("", SizeType.Small, string.Format(MessageManager.Instance.GetMessage("menu", "unit_multi_dance_popup_03"), danceDivaCount), new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					}, false, false), (PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
					{
						//0xF4A52C
						return;
					}, null, null, null, true, true, false, null, () =>
					{
						//0xF4B3D4
						done = true;
					});
					//LAB_00f4d3b4
					while(!done)
						yield return null;
					yield break;
				}
                ILDKBCLAFPB.JCFNHPMBPLJ_UnitDance saveData = GameManager.Instance.localSave.EPJOACOONAC_GetSave().EGNEDJLCMAI_UnitDance;
				if(!saveData.KBAMKMDJMJC_DisableWarning)
				{
					if(!m_isConfirmedUnitDance)
					{
						MenuScene.Instance.InputDisable();
						if(!m_popupUnitDanceWarning.IsLoaded)
						{
							yield return Co.R(m_popupUnitDanceWarning.Co_Load(transform.parent));
						}
						isUnitOnly = (selectMusicData.BNCMJNMIDIN_AvaiableDivaModes & 1) == 0;
						m_popupUnitDanceWarning.WarningWindow.Initialize(danceDivaCount, isUnitOnly);
						m_popupUnitDanceWarning.WarningWindow.transform.SetAsLastSibling();
						m_popupUnitDanceWarning.WarningWindow.Show();
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_000);
						//LAB_00f4d5a8
						while(m_popupUnitDanceWarning.WarningWindow.IsPlaying())
							yield return null;
						bool done = false;
						positiveAction = (bool isOn) =>
						{
							//0xF4B3E8
							SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
							saveData.KBAMKMDJMJC_DisableWarning = isOn;
							done = true;
						};
						negativeAction = (bool isOn) =>
						{
							//0xF4B47C
							SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
							ApplyUnitLiveButtonSetting(false);
							saveData.KBAMKMDJMJC_DisableWarning = isOn;
							done = true;
						};
						toggleAction = () =>
						{
							//0xF4A530
							SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
						};
						m_popupUnitDanceWarning.WarningWindow.PositiveListener += positiveAction;
						m_popupUnitDanceWarning.WarningWindow.NegativeListener += negativeAction;
						m_popupUnitDanceWarning.WarningWindow.ToggleButtonListener += toggleAction;
						handler = DummyBackButton;
						if(isUnitOnly)
						{
							handler = UnitDanceOnlyBackButton;
						}
						GameManager.Instance.AddPushBackButtonHandler(handler);
						MenuScene.Instance.InputEnable();
						while(!done)
							yield return null;
						MenuScene.Instance.InputDisable();
						m_popupUnitDanceWarning.WarningWindow.PositiveListener -= positiveAction;
						m_popupUnitDanceWarning.WarningWindow.NegativeListener -= negativeAction;
						m_popupUnitDanceWarning.WarningWindow.ToggleButtonListener -= toggleAction;
						GameManager.Instance.RemovePushBackButtonHandler(handler);
						m_popupUnitDanceWarning.WarningWindow.Close();
						SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_WND_001);
						while(m_popupUnitDanceWarning.WarningWindow.IsPlaying())
							yield return null;
						GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
						m_unitLiveLocalSaveData.HJMKBCFJOOH_Write(false);
						MenuScene.Instance.InputEnable();
						m_isConfirmedUnitDance = true;
						positiveAction = null;
						negativeAction = null;
						toggleAction = null;
						handler = null;
					}
					//LAB_00f4dd0c
				}
				//LAB_00f4dd0c
            }
			//LAB_00f4dd0c
			if(endCallback != null)
				endCallback();
		}

		// // RVA: 0xF42780 Offset: 0xF42780 VA: 0xF42780
		private void DummyBackButton()
		{
			return;
		}

		// // RVA: 0xF42784 Offset: 0xF42784 VA: 0xF42784
		private void UnitDanceOnlyBackButton()
		{
			m_popupUnitDanceWarning.WarningWindow.PerformClickOk();
		}

		// // RVA: 0xF427D0 Offset: 0xF427D0 VA: 0xF427D0
		// protected bool IsEventMissionSupport() { }

		// // RVA: 0xF3EE10 Offset: 0xF3EE10 VA: 0xF3EE10
		protected bool IsReceiveMission()
		{
			if(m_questList != null)
			{
				return m_questList.FindIndex((FKMOKDCJFEN x) =>
				{
					//0xF4A588
					return x.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved;
				}) > -1;
			}
			return false;
		}
		// // RVA: 0xF3ED84 Offset: 0xF3ED84 VA: 0xF3ED84
		private bool IsEnableEvMission()
		{
			return m_questList != null && m_eventCtrl != null && m_questList.Count > 0;
		}

		// // RVA: 0xF4286C Offset: 0xF4286C VA: 0xF4286C
		private void DecideCurrentMusic()
		{
			if(selectMusicData.OEILJHENAHN_PlayEventType == 10)
			{
				m_overrideEnemyCenterSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.DCOALMMJDJK_OverrideCenterSkill;
				m_overrideEnemyLiveSkill = selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData.KKPLDFNDFDE_OverrideLiveSkill;
				m_eventCtrl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(selectMusicData.EKANGPODCEP_EventId);
			}
			OnDecideCurrentMusic();
			Database.Instance.gameSetup.musicInfo.SetupInfoByFreeMusic(freeMusicId, diff ,!selectMusicData.MNDFBBMNJGN_NoEnergy, m_initParam, (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_GameEventType,
            	(OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MFJKNCACBDG_OpenEventType, (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.OEILJHENAHN_PlayEventType, m_isSimulationLive, m_isLine6Mode, m_missionText,
            	m_overrideEnemyCenterSkill, m_overrideEnemyLiveSkill, selectMusicData.ALMOMLMCHNA_OtherEndTime, selectMusicData.IHPCKOMBGKJ_End, m_eventCtrl != null ? m_eventCtrl.PGIIDPEGGPI_EventId : 0,
            	GetDanceDivaCount(), 0);
			Database.Instance.selectedMusic.SetMusicData(selectMusicData);
			if(selectMusicData.MNNHHJBBICA_GameEventType > 0 && selectMusicData.MNNHHJBBICA_GameEventType <= 2 || selectMusicData.MNNHHJBBICA_GameEventType == 11)
			{
				//LAB_00f42dac
				MenuScene.Instance.Call(TransitionList.Type.FRIEND_SELECT, null, true);
			}
			else
			{
				if(selectMusicData.MNNHHJBBICA_GameEventType == 3)
				{
					MenuScene.Instance.Call(TransitionList.Type.TEAM_SELECT, m_teamSelectSceneArgs, true);
				}
				else
				{
					MenuScene.Instance.Call(m_isSimulationLive ? TransitionList.Type.SIMULATIONLIVE_SETTING : TransitionList.Type.FRIEND_SELECT, null, true);
				}
			}
		}

		// // RVA: 0xF42F08 Offset: 0xF42F08 VA: 0xF42F08 Slot: 50
		protected virtual bool CurrentMusicDecisionCheck(Action cancelCallback, MKIKFJKPEHK viewBoostData, int selectIndex/* = 0*/)
		{
			if(viewBoostData == null)
			{
				if(selectMusicData.LHONOILACFL_IsWeeklyEvent)
				{
					if(selectMusicData.MOJMEFIENDM_WeeklyEventCount < 1)
					{
						OpenWeekRecoveryWindow((int recovery) =>
						{
							//0xF49774
							selectMusicData.IEBGBOBPJMB(recovery);
							ApplyMusicInfoNormal(selectMusicData);
							IBJAKJJICBC s = currentMusicList.Find(selectMusicData.GHBPLHBNMBK_FreeMusicId, !m_isLine6Mode, m_isSimulationLive);
							if(s != null)
								s.IEBGBOBPJMB(recovery);
						}, cancelCallback);
						return false;
					}
				}
				if(selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].BPLOEAHOPFI_Energy <= CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCLKMNGMIKC_GetCurrent())
					return true;
				OpenStaminaWindow(() =>
				{
					//0xF49870
					OnClickPlayButton();
				}, cancelCallback);
				return false;
			}
			else
			{
				OpenStaminaWindow(() =>
				{
					//0xF49874
					DecideCurrentMusic();
				}, cancelCallback);
				return false;
			}
		}

		// // RVA: 0xF4388C Offset: 0xF4388C VA: 0xF4388C Slot: 51
		protected virtual void OnDecideCurrentMusic()
		{
			return;
		}

		// // RVA: 0xF3E83C Offset: 0xF3E83C VA: 0xF3E83C
		protected void FadeOutBGM()
		{
			m_changeToTrialBgmId = -1;
			if(SoundManager.Instance.bgmPlayer.isPlaying && !m_requestFadeOutBgm)
			{
				m_requestFadeOutBgm = true;
				SoundManager.Instance.bgmPlayer.FadeOut(0.3f, OnEndFadeOutBGM);
			}
		}

		// // RVA: 0xF3E954 Offset: 0xF3E954 VA: 0xF3E954
		protected void ChangeTrialMusic(int wavId)
		{
			int bgmId = BgmPlayer.MENU_TRIAL_ID_BASE + wavId;
			if(!SoundManager.Instance.bgmPlayer.isPlaying)
			{
				SoundManager.Instance.bgmPlayer.Play(bgmId, 1.0f);
				m_changeToTrialBgmId = -1;
			}
			else
			{
				if(!m_requestFadeOutBgm)
				{
					if(SoundManager.Instance.bgmPlayer.currentBgmId != bgmId)
					{
						m_changeToTrialBgmId = bgmId;
						m_requestFadeOutBgm = true;
						SoundManager.Instance.bgmPlayer.FadeOut(0.3f, OnEndFadeOutBGM);
					}
				}
				else
				{
					m_changeToTrialBgmId = bgmId;
				}
			}
		}

		// // RVA: 0xF43890 Offset: 0xF43890 VA: 0xF43890
		private void OnEndFadeOutBGM()
		{
			m_requestFadeOutBgm = false;
			if(m_changeToTrialBgmId < 0)
				return;
			SoundManager.Instance.bgmPlayer.Play(m_changeToTrialBgmId, 1.0f);
			m_changeToTrialBgmId = -1;
		}

		// // RVA: 0xF43910 Offset: 0xF43910 VA: 0xF43910
		// protected void MuteSelectionSe(bool isMute) { }

		// // RVA: 0xF43918 Offset: 0xF43918 VA: 0xF43918 Slot: 52
		protected virtual void LeaveForScrollStart()
		{
			if(m_buttonSet != null)
				m_buttonSet.Leave();
		}

		// // RVA: 0xF439CC Offset: 0xF439CC VA: 0xF439CC Slot: 53
		protected virtual void EnterForScrollEnd()
		{
			if(m_buttonSet != null)
				m_buttonSet.Enter();
		}

		// // RVA: 0xF43A80 Offset: 0xF43A80 VA: 0xF43A80
		protected void CheckSnsNotice()
		{
			if(!BIFNGFAIEIL.HHCJCDFCLOB.DNFPMBFNDCA())
				return;
			int snsId = BIFNGFAIEIL.HHCJCDFCLOB.FGGDEKAJCIF();
			if(snsId == 0)
				return;
			MenuScene.Instance.ShowSnsNotice(snsId, null);
			BIFNGFAIEIL.HHCJCDFCLOB.ALIANOFCAEI();
		}

		// // RVA: 0xF43BC8 Offset: 0xF43BC8 VA: 0xF43BC8
		protected void CheckOfferNotice()
		{
			if(KDHGBOOECKC.HHCJCDFCLOB.IOCBOGFFHFE.OAFPGJLCNFM_Cond == BOPFPIHGJMD.LEIPFJHOFPC.HJNNKCMLGFL_0)
				return;
			MenuScene.Instance.ShowOfferNotice(null);
		}

		// // RVA: 0xF3870C Offset: 0xF3870C VA: 0xF3870C
		protected void AddNotice(Action action)
		{
			NoticeActionList.Add(action);
		}

		// // RVA: 0xF3878C Offset: 0xF3878C VA: 0xF3878C
		protected void ShowNotice()
		{
			this.StartCoroutineWatched(Co_ShowNotice());
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F43C4 Offset: 0x6F43C4 VA: 0x6F43C4
		// // RVA: 0xF43CB0 Offset: 0xF43CB0 VA: 0xF43CB0
		private IEnumerator Co_ShowNotice()
		{
			int i;

			//0xF505E4
			for(i = 0; i < NoticeActionList.Count; i++)
			{
				NoticeActionList[i]();
				GameManager.Instance.snsNotification.DirtyClose = false;
				while(GameManager.Instance.snsNotification.isActiveAndEnabled)
					yield return null;
				if(GameManager.Instance.snsNotification.DirtyClose)
					break;
			}
			NoticeActionList.Clear();
		}

		// // RVA: 0xF43D5C Offset: 0xF43D5C VA: 0xF43D5C
		private void OnWebViewClose()
		{
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xF43DF8 Offset: 0xF43DF8 VA: 0xF43DF8
		private void OnNetErrorToTitle()
		{
			MenuScene.Instance.GotoTitle();
		}

		// // RVA: 0xF43E94 Offset: 0xF43E94 VA: 0xF43E94
		protected void ReviseDifficulty()
		{
			if(!listIsEmpty)
			{
				if(selectMusicData.MGJKEJHEBPO_DiffInfos != null && selectMusicData.MGJKEJHEBPO_DiffInfos.Count > 0)
				{
					int idx = (int)diff;
					if(selectMusicData.MGJKEJHEBPO_DiffInfos.Count <= idx)
					{
						idx = selectMusicData.MGJKEJHEBPO_DiffInfos.Count - 1;
					}
					diff = (Difficulty.Type)idx;
					if(idx > -1)
					{
						do
						{
							diff = (Difficulty.Type)idx;
							idx--;
						} while(selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].POOMOBGPCNE_IsLocked && idx >= 0);
					}
				}
			}
		}

		// // RVA: 0xF440D8 Offset: 0xF440D8 VA: 0xF440D8
		protected int RepeatIndex(int index)
		{
			return XeSys.Math.Repeat(index, 0, currentMusicList.GetCount(m_isLine6Mode, m_isSimulationLive) - 1);
		}

		// // RVA: 0xF44154 Offset: 0xF44154 VA: 0xF44154
		protected bool IsRangeOver(int index)
		{
			if(index < 0)
				return true;
			else
			{
				return currentMusicList.GetCount(m_isLine6Mode, m_isSimulationLive) <= index;
			}
		}

		// // RVA: 0xF40414 Offset: 0xF40414 VA: 0xF40414
		public static void ExtractRemainTime(int totalSec, out int days, out int hours, out int minutes, out int seconds)
		{
			days = totalSec / 86400;
			hours = (totalSec - days * 86400) / 3600;
			minutes = (totalSec - days * 86400 - hours * 3600) / 60;
			seconds = (totalSec - days * 86400 - hours * 3600 - minutes * 60);
		}

		// // RVA: 0xF40494 Offset: 0xF40494 VA: 0xF40494
		public static string MakeRemainTime(int days, int hours, int minutes, int seconds)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			if(days < 1)
			{
				if(hours < 1)
				{
					if(minutes < 1)
					{
						return string.Format(bk.GetMessageByLabel("music_event_remain_second"), seconds);
					}
					else
					{
						return string.Format(bk.GetMessageByLabel("music_event_remain_minute"), minutes);
					}
				}
				else
				{
					return string.Format(bk.GetMessageByLabel("music_event_remain_hour"), hours);
				}
			}
			else
			{
				return string.Format(bk.GetMessageByLabel("music_event_remain_day"), days);
			}
		}

		// // RVA: 0xF3F63C Offset: 0xF3F63C VA: 0xF3F63C
		public static void ExtractDateTime(long unixTime, out int years, out int months, out int days, out int hours, out int minutes)
		{
			DateTime dt = Utility.GetLocalDateTime(unixTime);
			years = dt.Year;
			months = dt.Month;
			days = dt.Day;
			hours = dt.Hour;
			minutes = dt.Minute;
		}

		// // RVA: 0xF3F758 Offset: 0xF3F758 VA: 0xF3F758
		public static string MakeDateTime(int years, int months, int days, int hours, int minutes)
		{
			return string.Format(MessageManager.Instance.GetMessage("menu", "music_event_period_date"), new object[5]
			{
				years, months, days, hours, minutes
			});
		}

		// // RVA: 0xF3EF78 Offset: 0xF3EF78 VA: 0xF3EF78
		private void SetupRewardStat(IBJAKJJICBC musicData)
		{
			if(m_rewardData == null)
				m_rewardData = new FPGEMAIAMBF_RewardData();
			if(m_rewardStats == null)
			{
				m_rewardStats = new List<MusicRewardStat>(5);
				for(int i = 0; i < 5; i++)
				{
					m_rewardStats.Add(new MusicRewardStat());
				}
			}
			if(musicData.HDPMAJKGIOI)
			{
				for(int i = 0; i < 5; i++)
				{
					m_rewardStats[i].Clear();
				}
			}
			else
			{
				int i = 0;
				for(; i < musicData.MGJKEJHEBPO_DiffInfos.Count; i++)
				{
					m_rewardData.JMHCEMHPPCM(musicData.GHBPLHBNMBK_FreeMusicId, i, m_isLine6Mode, musicData.MNNHHJBBICA_GameEventType);
					m_rewardStats[i].Init(m_rewardData);
				}
				for(; i < 5; i++)
				{
					m_rewardStats[i].Clear();
				}
			}
		}

		// // RVA: 0xF441DC Offset: 0xF441DC VA: 0xF441DC
		protected bool CheckEventLimit()
		{
			if(MenuScene.CheckDatelineAndAssetUpdate())
				return true;
			if(selectMusicData.LEBDMNIGOJB_IsScoreEvent)
			{
				TodoLogger.LogError(TodoLogger.EventScore_4, "Check Event Limit");
			}
			return MenuScene.Instance.CheckEventLimit(selectMusicData, true, true, m_eventStatus < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6 ? KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 : KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, m_eventId);
		}

		// // RVA: 0xF444D4 Offset: 0xF444D4 VA: 0xF444D4
		// protected bool CheckCurrentEventLimit(KGCNCBOKCBA.GNENJEHKMHD term = 5) { }

		// // RVA: 0xF445EC Offset: 0xF445EC VA: 0xF445EC
		public static void CreateFilteredMusicDataList(List<MusicDataList> filteredMusicList, List<MusicDataList> originalMusicList, long currentTime, MusicSelectSceneBase.CheckMatchMusicFilterFunc checkFunc)
		{
			filteredMusicList.Clear();
			for(int i = 0; i < originalMusicList.Count; i++)
			{
				List<IBJAKJJICBC> l1 = new List<IBJAKJJICBC>();
				List<IBJAKJJICBC> l2 = new List<IBJAKJJICBC>();
				List<IBJAKJJICBC> l3 = new List<IBJAKJJICBC>();
				List<IBJAKJJICBC> l4 = new List<IBJAKJJICBC>();
				MusicDataList music = originalMusicList[i];
                List<IBJAKJJICBC> musicList = music.GetList(false, false);
                List<IBJAKJJICBC> musicList2 = music.GetList(true, false);
                List<IBJAKJJICBC> musicList3 = music.GetList(false, true);
                List<IBJAKJJICBC> musicList4 = music.GetList(true, true);
				foreach(var m in musicList)
				{
					if(checkFunc(m, currentTime))
					{
						l1.Add(m);
					}
				}
				foreach(var m in musicList2)
				{
					if(checkFunc(m, currentTime))
					{
						l2.Add(m);
					}
				}
				foreach(var m in musicList3)
				{
					l3.Add(m);
				}
				foreach(var m in musicList4)
				{
					l4.Add(m);
				}
				filteredMusicList.Add(new MusicDataList(l1, l2, l3, l4));
            }
		}

		// // RVA: 0xF45870 Offset: 0xF45870 VA: 0xF45870
		protected void OnSelectedDifficulty(Difficulty.Type difficulty)
		{
			diff = difficulty;
			ApplyMusicInfo();
			OnChangedDifficulty();
		}

		// // RVA: 0xF458AC Offset: 0xF458AC VA: 0xF458AC Slot: 54
		protected virtual void OnChangedDifficulty()
		{
			return;
		}

		// // RVA: 0xF458B0 Offset: 0xF458B0 VA: 0xF458B0
		protected void OnClickRankingButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			MenuScene.Instance.Call(TransitionList.Type.REGULAR_RANKING, new RegularRankingSceneArgs(selectMusicData), true);
		}

		// // RVA: 0xF459E4 Offset: 0xF459E4 VA: 0xF459E4
		protected void OnClickRewardButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			OpenRewardWindow();
		}

		// // RVA: 0xF45E74 Offset: 0xF45E74 VA: 0xF45E74
		protected void OnClickDetailButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			OpenMusicDetailWindow();
		}

		// // RVA: 0xF460FC Offset: 0xF460FC VA: 0xF460FC
		// protected void OnClickEnemyDetailButton() { }

		// // RVA: 0xF46368 Offset: 0xF46368 VA: 0xF46368
		protected void OnClickEventRankingButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!CheckEventLimit())
			{
				if(selectMusicData.LEBDMNIGOJB_IsScoreEvent)
				{
					MenuScene.Instance.Call(TransitionList.Type.EVENT_RANKING, new EventRankingSceneArgs(m_scoreEventCtrl, false, 0, 0), true);
				}
				else
				{
					MenuScene.Instance.Call(TransitionList.Type.EVENT_RANKING, new EventRankingSceneArgs(m_eventCtrl, false, 0, 0), true);
				}
			}
		}

		// // RVA: 0xF46528 Offset: 0xF46528 VA: 0xF46528
		protected void OnClickEventRewardButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(CheckEventLimit())
				return;
			this.StartCoroutineWatched(PopupRewardEvCheck.Co_ShowPopup(selectMusicData.LEBDMNIGOJB_IsScoreEvent ? m_scoreEventCtrl : m_eventCtrl, transform, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xF4A654
				return;
			}));
		}

		// // RVA: 0xF467D4 Offset: 0xF467D4 VA: 0xF467D4
		protected void OnClickEnemyInfoButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			MenuScene.Instance.MusicPopupWindowControl.ShowEnemyInfo(this, MusicPopupWindowControl.CallType.MusicSelect, selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData, null);
		}

		// // RVA: 0xF469EC Offset: 0xF469EC VA: 0xF469EC
		protected void OnClickStoryButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!CheckEventLimit())
			{
				CCAAJNJGNDO d = new CCAAJNJGNDO();
				d.KHEKNNFCAOI_InitFromCurrentEvent(m_eventCtrl);
				MenuScene.Instance.Call(TransitionList.Type.EVENT_STORY, new EventStoryArgs(d), true);
			}
		}

		// // RVA: 0xF46B68 Offset: 0xF46B68 VA: 0xF46B68
		protected void OnClickMissionButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			if(!CheckEventLimit())
			{
				CGJKNOCAPII d = new CGJKNOCAPII();
				d = d.BJKJLDPDEFA(m_eventCtrl, true);
				MenuScene.Instance.Call(TransitionList.Type.QUEST_SELECT, new QuestTopFormQuestListArgs(d), true);
			}
		}

		// // RVA: 0xF46CEC Offset: 0xF46CEC VA: 0xF46CEC
		protected void OnClickPlayButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_001);
			GameManager.Instance.CloseSnsNotice();
			GameManager.Instance.CloseOfferNotice();
			if(!CheckEventLimit())
			{
				if(selectMusicData.AJGCPCMLGKO_IsEvent)
				{
					if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory < OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore)
					{
						if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory != OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection && selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
						{
							GotoEventBattle(selectMusicData.EKANGPODCEP_EventId);
							return;
						}
					}
					else if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					{
						GotoEventGoDiva(selectMusicData.EKANGPODCEP_EventId);
						return;
					}
					else if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid)
					{
						TodoLogger.LogError(TodoLogger.EventRaid_11_13, "OnClickPlayButton");
						return;
					}
					else if(selectMusicData.AFCMIOIGAJN_EventInfo.HIDHLFCBIDE_EventCategory == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest)
					{
						TodoLogger.LogError(TodoLogger.EventQuest_6, "OnClickPlayButton");
						return;
					}
					GotoEventMusicSelect(selectMusicData.EKANGPODCEP_EventId);
					return;
				}
				if(selectMusicData.BNIAJAKIAJC_IsEventMinigame)
				{
					Database.Instance.gameSetup.musicInfo.SetupInfoByFreeMusic(1, diff, false, m_initParam, (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_GameEventType, 
						(OHCAABOMEOF.KGOGMKMBCPP_EventType) selectMusicData.MFJKNCACBDG_OpenEventType, (OHCAABOMEOF.KGOGMKMBCPP_EventType) selectMusicData.OEILJHENAHN_PlayEventType, m_isSimulationLive, m_isLine6Mode, 
						m_missionText, m_overrideEnemyCenterSkill, m_overrideEnemyLiveSkill, selectMusicData.ALMOMLMCHNA_OtherEndTime, selectMusicData.IHPCKOMBGKJ_End, 
						m_eventCtrl != null ? m_eventCtrl.PGIIDPEGGPI_EventId : 0, 1, 0);
					GotoMiniGame(selectMusicData.NOKBLCDMLPP_MinigameEventInfo.OOCBPMNHLPM_MusicId);
					return;
				}
				if(selectMusicData.POEGGBGOKGI_IsInfoLiveEntrance)
				{
					GotoRegularMusicSelect();
					return;
				}
				if(!selectMusicData.IFNPBIJEPBO_IsDlded)
				{
					DownloadCurrentMusic();
					return;
				}
				if(!m_isSimulationLive)
				{
					if(!MenuScene.Instance.TryMusicPeriod(selectMusicData.IHPCKOMBGKJ_End, m_eventCtrl != null ? m_eventCtrl.PGIIDPEGGPI_EventId : 0, (OHCAABOMEOF.KGOGMKMBCPP_EventType) selectMusicData.MNNHHJBBICA_GameEventType, m_isSimulationLive, MenuScene.MusicPeriodMess.MusicSelect))
					{
						CheckUnitLive(() =>
						{
							//0xF49908
							CheckBoostData(DecideCurrentMusic, ClearUnitDanceConfirm);
						});
						return;
					}
				}
				else
				{
					if(!MenuScene.Instance.TryMusicPeriod(selectMusicData.NNJNNCGGKMC_IsLimited ? selectMusicData.IHPCKOMBGKJ_End : selectMusicData.ALMOMLMCHNA_OtherEndTime, m_eventCtrl != null ? m_eventCtrl.PGIIDPEGGPI_EventId : 0, (OHCAABOMEOF.KGOGMKMBCPP_EventType)selectMusicData.MNNHHJBBICA_GameEventType, m_isSimulationLive, MenuScene.MusicPeriodMess.MusicSelect))
					{
						CheckUnitLive(() =>
						{
							//0xF49878
							CheckSimulationLive(DecideCurrentMusic);
						});
						return;
					}
				}
			}
		}

		// // RVA: 0xF3AF60 Offset: 0xF3AF60 VA: 0xF3AF60
		protected void UpdateScrollLimit()
		{
			if(!scrollIsClamp)
			{
				m_cdSelect.ClearScrollLimit();
			}
			else
			{
				int cnt = currentMusicList.GetCount(m_isLine6Mode, m_isSimulationLive);
				m_cdSelect.SetScrollLimit(-list_no, cnt - 1 - list_no);
			}
		}

		// // RVA: 0xF3B040 Offset: 0xF3B040 VA: 0xF3B040
		protected void UpdateScrollArrow()
		{
			int cnt = currentMusicList.GetCount(m_isLine6Mode, m_isSimulationLive);
			if(cnt < 2)
			{
				m_cdArrow.SetLeftArrowVisible(false);
				m_cdArrow.SetRightArrowVisible(false);
			}
			else
			{
				m_cdArrow.SetLeftArrowVisible(!m_cdSelect.CheckLeftLimitPage());
				m_cdArrow.SetRightArrowVisible(!m_cdSelect.CheckRightLimitPage());
			}
		}

		// // RVA: 0xF47554 Offset: 0xF47554 VA: 0xF47554
		protected void OnClickEventDetailButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_003);
			if(!CheckEventLimit())
			{
				if(selectMusicData.LHONOILACFL_IsWeeklyEvent)
				{
					MenuScene.Instance.InputDisable();
					MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(selectMusicData.CIOCOOMCMKO(selectMusicData.IHKFMJDOBAH_WeekDayAttr), OnWebViewClose, OnNetErrorToTitle);
				}
				if(selectMusicData.LEBDMNIGOJB_IsScoreEvent)
				{
					MenuScene.Instance.InputDisable();
					TodoLogger.LogError(TodoLogger.EventScore_4, "OnClickEventDetailButton");
				}
			}
		}

		// // RVA: 0xF478B8 Offset: 0xF478B8 VA: 0xF478B8
		protected void OnClickFlowButton(int offset)
		{
			if(offset < 0)
			{
				MenuScene.Instance.InputDisable();
				m_cdSelect.RequestLeftFlow(-offset, 0.2f, () =>
				{
					//0xF4A658
					MenuScene.Instance.InputEnable();
				});
			}
			else if(offset != 0)
			{
				MenuScene.Instance.InputDisable();
				m_cdSelect.RequestRightFlow(offset, 0.2f, () =>
				{
					//0xF4A6F4
					MenuScene.Instance.InputEnable();
				});
			}
		}

		// // RVA: 0xF47BD4 Offset: 0xF47BD4 VA: 0xF47BD4
		protected void OnSelectionChanged(int offset)
		{
			if(offset != 0 && !m_muteSelectionSe)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_004);
			}
			list_no = RepeatIndex(list_no + offset);
			ApplyMusicInfo();
		}

		// // RVA: 0xF47C70 Offset: 0xF47C70 VA: 0xF47C70
		protected void OnScrollRepeated(int repeatDelta, int beginIndex, int endIndex)
		{
			if(!listIsEmpty)
			{
				if(beginIndex <= endIndex)
				{
					for(int order = 0; beginIndex + order <= endIndex; order++)
					{
						if(scrollIsClamp && IsRangeOver(list_no + beginIndex + order))
						{
							m_cdSelect.HideJacket(order);
						}
						else
						{
							int idx = RepeatIndex(list_no + beginIndex + order);
                            IBJAKJJICBC song = currentMusicList.Get(idx, m_isLine6Mode, m_isSimulationLive);
							int jacket = song.JNCPEGJGHOG_JacketId;
							bool isEvntMinigame = song.BNIAJAKIAJC_IsEventMinigame;
							bool isEvent;
							if(!song.AJGCPCMLGKO_IsEvent)
							{
								isEvent = false;
								isEvntMinigame = false;
								if(song.BNIAJAKIAJC_IsEventMinigame)
								{
									jacket = song.NOKBLCDMLPP_MinigameEventInfo.GOAPADIHAHG_EventId;
									isEvntMinigame = true;
									isEvent = false;
								}
							}
							else
							{
								isEvent = true;
								jacket = song.AFCMIOIGAJN_EventInfo.GOAPADIHAHG_EventId;
							}
							GameAttribute.Type attr = GameAttribute.Type.None;
							if(!isEvent && !isEvntMinigame)
							{
								attr = (GameAttribute.Type)song.FKDCCLPGKDK_JacketAttr;
							}
							m_cdSelect.ChangeJacket(order, jacket, attr, isEvntMinigame || isEvent);
                        }
					}
				}
			}
			else
			{
				m_cdSelect.ChangeJacket(0, 0, 0, false);
			}
		}

		// // RVA: 0xF47F40 Offset: 0xF47F40 VA: 0xF47F40
		protected void OnScrollStarted(bool isAuto)
		{
			if(!isAuto)
			{
				LeaveForScrollStart();
			}
			if(m_cdSelect != null)
			{
				playButtonUI.Leave(true);
			}
		}

		// // RVA: 0xF48020 Offset: 0xF48020 VA: 0xF48020
		protected void OnScrollUpdated(bool isAuto)
		{
			UpdateScrollArrow();
		}

		// // RVA: 0xF48024 Offset: 0xF48024 VA: 0xF48024
		protected void OnScrollEnded(bool isAuto)
		{
			if(!isAuto)
			{
				EnterForScrollEnd();
			}
			if(m_cdSelect != null)
			{
				playButtonUI.Enter(false);
			}
			UpdateScrollLimit();
			UpdateScrollArrow();
			DelayedApplyMusicInfo();
		}

		// // RVA: 0xF45B00 Offset: 0xF45B00 VA: 0xF45B00
		private void OpenRewardWindow()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_rewardPopupSetting.TitleText = bk.GetMessageByLabel("popup_music_select_02");
			m_rewardPopupSetting.SetParent(transform);
			m_rewardPopupSetting.WindowSize = SizeType.Large;
			m_rewardPopupSetting.diff = diff;
			m_rewardPopupSetting.mode = LayoutPopupAchieveReward.eMode.MusicSelect;
			m_rewardPopupSetting.selectMusicId = musicId;
			m_rewardPopupSetting.selectFreeMusicId = freeMusicId;
			m_rewardPopupSetting.gameEventType = gameEventType;
			m_rewardPopupSetting.isLine6Mode = m_isLine6Mode;
			m_rewardPopupSetting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			PopupWindowManager.Show(m_rewardPopupSetting, null, null, null, null);
		}

		// // RVA: 0xF45F90 Offset: 0xF45F90 VA: 0xF45F90
		private void OpenMusicDetailWindow()
		{
			MenuScene.Instance.MusicPopupWindowControl.Show(this, MusicPopupWindowControl.CallType.MusicSelect, musicId, selectMusicData.MGJKEJHEBPO_DiffInfos[(int)diff].HPBPDHPIBGN_EnemyData, null, m_isSimulationLive);
		}

		// // RVA: 0xF46218 Offset: 0xF46218 VA: 0xF46218
		// private void OpenEnemyDetailWindow() { }

		// // RVA: 0xF48128 Offset: 0xF48128 VA: 0xF48128
		// private void OpenFirstClearRewardWindow() { }

		// // RVA: 0xF4812C Offset: 0xF4812C VA: 0xF4812C
		// private void OpenClearRewardWindow(int type, int no) { }

		// // RVA: 0xF48130 Offset: 0xF48130 VA: 0xF48130
		private void ClearUnitDanceConfirm()
		{
			m_isConfirmedUnitDance = false;
		}

		// // RVA: 0xF431BC Offset: 0xF431BC VA: 0xF431BC
		protected void OpenWeekRecoveryWindow(Action<int> recoveryCallback, Action cancelCallback)
		{
			MenuScene.Instance.InputDisable();
			PopupWindowManager.OpenWeekRecoveryWindow(freeMusicId, (int recovery) =>
			{
				//0xF4B550
				MenuScene.Instance.InputEnable();
				if(recoveryCallback != null)
					recoveryCallback(recovery);
			}, () =>
			{
				//0xF4B618
				MenuScene.Instance.InputEnable();
				if(cancelCallback != null)
					cancelCallback();
			}, () =>
			{
				//0xF4A790
				MenuScene.Instance.GotoTitle();
			}, (TransitionList.Type gotoSceneType) =>
			{
				//0xF4A82C
				if(gotoSceneType == TransitionList.Type.TITLE)
				{
					MenuScene.Instance.GotoTitle();
				}
				else if(gotoSceneType == TransitionList.Type.LOGIN_BONUS)
				{
					MenuScene.Instance.GotoLoginBonus();
				}
				MenuScene.Instance.InputEnable();
			});
		}

		// // RVA: 0xF4351C Offset: 0xF4351C VA: 0xF4351C
		private void OpenStaminaWindow(Action recoveryCallback, Action cancelCallback)
		{
			MenuScene.Instance.InputDisable();
			PopupWindowManager.OpenStaminaWindow(MenuScene.Instance.DenomControl, () =>
			{
				//0xF4B6CC
				MenuScene.Instance.InputEnable();
				if(recoveryCallback != null)
					recoveryCallback();
			}, () =>
			{
				//0xF4B780
				MenuScene.Instance.InputEnable();
				if(cancelCallback != null)
					cancelCallback();
			}, () =>
			{
				//0xF4A988
				//MenuScene.Instance.
			}, (TransitionList.Type gotoSceneType) =>
			{
				//0xF4AA24
				if(gotoSceneType == TransitionList.Type.TITLE)
				{
					return;
				}
				else if(gotoSceneType == TransitionList.Type.LOGIN_BONUS)
				{
					MenuScene.Instance.GotoLoginBonus();
				}
				MenuScene.Instance.InputEnable();
			});
		}

		// // RVA: 0xF4814C Offset: 0xF4814C VA: 0xF4814C
		// private void OpenUseAccountingItemWindow() { }

		// // RVA: 0xF48214 Offset: 0xF48214 VA: 0xF48214
		// private void OpenUseGameItemWindow() { }

		// // RVA: 0xF482DC Offset: 0xF482DC VA: 0xF482DC
		// private void OpenCompletionWindow() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F443C Offset: 0x6F443C VA: 0x6F443C
		// // RVA: 0xF39D38 Offset: 0xF39D38 VA: 0xF39D38
		private IEnumerator Co_LoadResources()
		{
			//0xF50008
			yield return Co.R(Co_LoadLayout());

			m_rewardPopupSetting.SetParent(transform);

			yield return Co.R(Co_WaitForLoaded());

			playButtonUI = CreatePlayButtonWrapper();

			IsReady = true;
		}

		// // RVA: -1 Offset: -1 Slot: 55
		protected abstract IEnumerator Co_LoadLayout();

		// [IteratorStateMachineAttribute] // RVA: 0x6F44B4 Offset: 0x6F44B4 VA: 0x6F44B4
		// // RVA: 0xF48510 Offset: 0xF48510 VA: 0xF48510 Slot: 56
		protected virtual IEnumerator Co_WaitForLoaded()
		{
			//0xF519C8
			while(m_musicInfo == null)
				yield return null;
			while(!m_musicInfo.IsLoaded())
				yield return null;
			while(m_cdSelect == null)
				yield return null;
			while(!m_cdSelect.IsLoaded())
				yield return null;
			while(m_cdArrow == null)
				yield return null;
			while(!m_cdArrow.IsLoaded())
				yield return null;
			while(m_buttonSet == null)
				yield return null;
			while(!m_buttonSet.IsLoaded())
				yield return null;
			while(m_eventBanner == null)
				yield return null;
			while(!m_eventBanner.IsLoaded())
				yield return null;
			while(m_loadingTicketGainedPopup)
				yield return null;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F452C Offset: 0x6F452C VA: 0x6F452C
		// // RVA: 0xF485BC Offset: 0xF485BC VA: 0xF485BC
		protected IEnumerator Co_CheckUnlock(Action<int> callback)
		{
			//0xF4E0B8
			yield return Co.R(PopupUnlock.Show(PopupUnlock.eSceneType.MusicSelect, callback, true, null));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F45A4 Offset: 0x6F45A4 VA: 0x6F45A4
		// // RVA: 0xF385F4 Offset: 0xF385F4 VA: 0xF385F4
		// protected IEnumerator Co_CheckUnlockAndAddMusic() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F461C Offset: 0x6F461C VA: 0x6F461C
		// // RVA: 0xF48688 Offset: 0xF48688 VA: 0xF48688 Slot: 57
		protected virtual IEnumerator Co_WaitForAnimEnd(Action onEnd)
		{
			//0xF51718
			while(m_musicInfo.IsPlaying())
				yield return null;
			while(m_cdSelect.IsPlaying())
				yield return null;
			while(m_cdArrow.IsPlaying())
				yield return null;
			while(m_buttonSet.IsPlaying())
				yield return null;
			while(m_eventBanner.IsPlaying())
				yield return null;
			if(onEnd != null)
				onEnd();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F4694 Offset: 0x6F4694 VA: 0x6F4694
		// // RVA: 0xF48750 Offset: 0xF48750 VA: 0xF48750
		protected IEnumerator Co_ChangeBg(BgType bgType, int bgId)
		{
			BgControl bgControl;

			//0xF4B8E4
			isBgChanging = true;
			bgControl = MenuScene.Instance.BgControl;
			yield return Co.R(bgControl.ChangeBgCoroutine(bgType, bgId, SceneGroupCategory.UNDEFINED, TransitionList.Type.UNDEFINED, -1));
			bgControl.ChangeTilingType(m_isSimulationLive ? BgBehaviour.TilingType.Cross : BgBehaviour.TilingType.Dot);
			isBgChanging = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F470C Offset: 0x6F470C VA: 0x6F470C
		// // RVA: 0xF40834 Offset: 0xF40834 VA: 0xF40834
		private IEnumerator Co_DownloadMusic(IBJAKJJICBC musicData)
		{
			UGUIFader fader; // 0x18
			TipsControl tipsCtrl; // 0x1C
			int musicId; // 0x20
			ILCCJNDFFOB lw; // 0x24
			float pre; // 0x28

			//0xF4E7F0
			fader = GameManager.Instance.fullscreenFader;
			tipsCtrl = TipsControl.Instance;
			MenuScene.Instance.InputDisable();
			fader.Fade(0.5f, new Color(0, 0, 0, 0.5f));
			tipsCtrl.Show(musicData);
			while(fader.isFading)
				yield return null;
			yield return TipsControl.Instance.WaitLoadingYield;
			while(TipsControl.Instance.isPlayingAnime())
				yield return null;
			musicId = musicData.DLAEJOBELBH_MusicId;
			int v = 0;
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.PMGMMMGCEEI_Video == 0)
			{
				v = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.CBLEFELBNDN_GetVideoQuality();
			}
			KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP = 0;
			lw = ILCCJNDFFOB.HHCJCDFCLOB;
			ILCCJNDFFOB.HHCJCDFCLOB.OJOLFJGNEMO(0, musicId);
			pre = 0;
			KDLPEDBKMID.HHCJCDFCLOB.OKJCGCOGDIA_DownloadSongDatas(musicData.KKPAHLMJKIH_WavId, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(musicData.GHBPLHBNMBK_FreeMusicId).KEFGPJBKAOD_WavId, v, GetDanceDivaCount());
			while(KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning)
			{
				if(pre < 50)
				{
					if(50 <= KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP)
					{
						lw.OJOLFJGNEMO(1, musicId);
					}
				}
				pre = KDLPEDBKMID.HHCJCDFCLOB.HANBBBBLLGP;
			}
			lw.OJOLFJGNEMO(2, musicId);
			for(int i = 0; i < musicListCount; i++)
			{
				GetMusicList(i).UpdateDownloadState(musicId);
			}
			ApplyMusicInfo();
			DelayedApplyMusicInfo();
			fader.Fade(0.5f, 0);
			tipsCtrl.Close();
			while(fader.isFading)
				yield return null;
			while(tipsCtrl.isPlayingAnime())
				yield return null;
			MenuScene.Instance.InputEnable();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F4784 Offset: 0x6F4784 VA: 0x6F4784
		// // RVA: 0xF48850 Offset: 0xF48850 VA: 0xF48850
		protected IEnumerator Co_ShowHelp()
		{
			int i;

			//0xF50218
			for(i = 0; i < m_eventHelpId.Count; i++)
			{
				if(m_eventHelpId[i] != 0)
				{
					MenuScene.Instance.InputDisable();
					yield return this.StartCoroutineWatched(TutorialManager.ShowTutorial(m_eventHelpId[i], () =>
					{
						//0xF4B2A0
						MenuScene.Instance.InputEnable();
					}));
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F47FC Offset: 0x6F47FC VA: 0x6F47FC
		// // RVA: 0xF488FC Offset: 0xF488FC VA: 0xF488FC
		protected IEnumerator Co_LoadAssetBundle_LoginBonusPopup()
		{
			FontInfo systemFont; // 0x14
			AssetBundleLoadLayoutOperationBase lytOp; // 0x18

			//0xF4FC1C
			m_loadingTicketGainedPopup = true;
			m_ticketGainedPopupSetting = new TicketGainedPopupSetting();
			systemFont = GameManager.Instance.GetSystemFont();
			lytOp = AssetBundleManager.LoadLayoutAsync(m_ticketGainedPopupSetting.BundleName, m_ticketGainedPopupSetting.AssetName);
			yield return lytOp;
			yield return Co.R(lytOp.InitializeLayoutCoroutine(systemFont, (GameObject instance) =>
			{
				//0xF4A1AC
				m_ticketGainedPopupSetting.SetContent(instance);
			}));
			m_ticketGainedPopupSetting.SetParent(transform);
			AssetBundleManager.UnloadAssetBundle(m_ticketGainedPopupSetting.BundleName, false);
			m_loadingTicketGainedPopup = false;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F4874 Offset: 0x6F4874 VA: 0x6F4874
		// // RVA: 0xF489A8 Offset: 0xF489A8 VA: 0xF489A8
		protected IEnumerator Co_Initialize_LoginBonusPopup(IKDICBBFBMI_EventBase a_controller)
		{
			int itemId; // 0x1C
			int itemCount; // 0x20

			//0xF4F300
			if(m_ticketGainedPopupSetting == null || a_controller == null)
				yield break;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			m_showTicketGainedPopup = false;
			itemId = 0;
			itemCount = 0;
			if(a_controller.GJMGKBDGMOP(t))
			{
				m_showTicketGainedPopup = true;
				itemId = a_controller.BHABCGJCGNO.JJBGOIMEIPF_ItemId;
				itemCount = a_controller.BHABCGJCGNO.MBJIFDBEDAC_Cnt;
				bool done = false;
				CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
				{
					//0xF4B878
					done = true;
				}, () =>
				{
					//0xF4B884
					done = true;
					GotoTitle();
				}, null);
				//LAB_00f4f608
				while(!done)
					yield return null;
			}
			if(m_showTicketGainedPopup)
			{
                MessageBank bk = MessageManager.Instance.GetBank("menu");
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
				{
					m_ticketGainedPopupSetting.title = string.Format(bk.GetMessageByLabel("popup_event_login_item01_title_msg"), itemCount);
					m_ticketGainedPopupSetting.label01 = bk.GetMessageByLabel("popup_event_login_item01_label00_msg");
					m_ticketGainedPopupSetting.label01 = bk.GetMessageByLabel("popup_event_login_item01_label01_msg");
					m_ticketGainedPopupSetting.layoutType = 0;
				}
				else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
				{
					m_ticketGainedPopupSetting.title = string.Format(bk.GetMessageByLabel("popup_event_login_item00_title_msg"), itemCount);
					m_ticketGainedPopupSetting.label01 = bk.GetMessageByLabel("popup_event_login_item00_label00_msg");
					m_ticketGainedPopupSetting.label01 = bk.GetMessageByLabel("popup_event_login_item00_label01_msg");
					m_ticketGainedPopupSetting.layoutType = 1;
				}
				else
				{
					m_showTicketGainedPopup = false;
					//LAB_00f4fae8
				}
				if(m_showTicketGainedPopup)
				{
					m_ticketGainedPopupSetting.TitleText = "";
					m_ticketGainedPopupSetting.IsCaption = false;
					m_ticketGainedPopupSetting.WindowSize = SizeType.Small;
					m_ticketGainedPopupSetting.itemId = itemId;
					m_ticketGainedPopupSetting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
				}
            }
			//LAB_00f4fae8
			if(a_controller.JBPPMMMFGCA_HasRewardItems())
				m_showitemReceivePopup = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F48EC Offset: 0x6F48EC VA: 0x6F48EC
		// // RVA: 0xF48A70 Offset: 0xF48A70 VA: 0xF48A70
		protected IEnumerator Co_ShowReciveLoginAchievement()
		{
			int i;

			//0xF5097C
			if(m_eventCtrl.JBPPMMMFGCA_HasRewardItems())
			{
				bool isWait = false;
				for(i = 0; i < m_eventCtrl.KGBCKPKLKHM_RewardItems.Count; i++)
				{
					m_itemReceivePopupSetting.TitleText = MessageManager.Instance.GetMessage("menu", m_eventCtrl.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6 ? "popup_event_login_prologue_title" : "popup_event_login_epilogue_title");
					m_itemReceivePopupSetting.ItemId = m_eventCtrl.KGBCKPKLKHM_RewardItems[i].JJBGOIMEIPF_ItemId;
					m_itemReceivePopupSetting.Count = m_eventCtrl.KGBCKPKLKHM_RewardItems[i].MBJIFDBEDAC_Cnt;
					m_itemReceivePopupSetting.IsPresentBox = true;
					m_itemReceivePopupSetting.Buttons = new ButtonInfo[1]
					{
						new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					isWait = true;
					PopupWindowManager.Show(m_itemReceivePopupSetting, (PopupWindowControl type, PopupButton.ButtonType label, PopupButton.ButtonLabel control) =>
					{
						//0xF4B8C0
						isWait = false;
					}, null, null, null);
					while(isWait)
						yield return null;
				}
				m_eventCtrl.KGBCKPKLKHM_RewardItems.Clear();
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F4964 Offset: 0x6F4964 VA: 0x6F4964
		// // RVA: 0xF48B1C Offset: 0xF48B1C VA: 0xF48B1C
		protected IEnumerator Co_Show_LoginBonusPopup(OnCallback_LoginBonusPopup a_callback)
		{
			//0xF50FA4
			if(m_ticketGainedPopupSetting == null || !m_showTicketGainedPopup)
				yield break;
			MenuScene.Instance.InputDisable();
			bool isClosed = false;
			PopupWindowManager.Show(m_ticketGainedPopupSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0xF4B8D4
				isClosed = true;
			}, null, null, null);
			while(!isClosed)
				yield return null;
			if(a_callback != null)
				a_callback();
			MenuScene.Instance.InputEnable();
		}

		// // RVA: 0xF3843C Offset: 0xF3843C VA: 0xF3843C
		protected bool CanDoUnitDanceFocus(bool line6Mode/* = False*/)
		{
			return !GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.INEAGJMJLFG_TutorialAlreadyFlags.ODKIHPBEOEC_IsTrue(48) && IsEnableUnitDance(line6Mode);
		}

		// // RVA: 0xF48BE4 Offset: 0xF48BE4 VA: 0xF48BE4
		private bool IsEnableUnitDance(bool line6Mode/* = False*/)
		{
			if(TransitionName == TransitionList.Type.EVENT_QUEST)
			{
				if(m_eventCtrl != null && m_eventCtrl.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6 && selectMusicData != null)
				{
					return selectMusicData.JAPLKHPLOOF(m_eventCtrl.HIDHLFCBIDE_EventType);
				}
			}
			else
			{
				OHCAABOMEOF.KGOGMKMBCPP_EventType v = OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0;
				if(TransitionName == TransitionList.Type.EVENT_BATTLE)
					v = OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle;
				if(TransitionName == TransitionList.Type.EVENT_MUSIC_SELECT)
					v = OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection;
				if(v == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0 || m_eventCtrl == null || m_eventCtrl.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
				{
					for(int i = 0; i < musicListCount; i++)
					{
						List<IBJAKJJICBC> list = GetMusicList(i).GetList(line6Mode, false);
						for(int j = 0; j < list.Count; j++)
						{
							if(list[i].JAPLKHPLOOF(v))
							{
								return true;
							}
						}
						if(m_isSimulationLive)
						{
							list = GetMusicList(i).GetList(line6Mode, true);
							for(int j = 0; j < list.Count; j++)
							{
								if(list[i].JAPLKHPLOOF(v))
								{
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// // RVA: 0xF48F34 Offset: 0xF48F34 VA: 0xF48F34
		protected bool SelectUnitDanceFocus(out int freeMusicId, out FreeCategoryId.Type category, ref bool line6Mode, bool isSimulation, OHCAABOMEOF.KGOGMKMBCPP_EventType eventCategory)
		{
			freeMusicId = 0;
			category = 0;
			if(!CanDoUnitDanceFocus(line6Mode))
			{
				if(!CanDoUnitDanceFocus(!line6Mode))
					return false;
				line6Mode = !line6Mode;
			}
			bool b28 = false;
			for(int i = 0; i < musicListCount; i++)
			{
				for(int j = 0; j < GetMusicList(i).GetCount(line6Mode, isSimulation); j++)
				{
                    IBJAKJJICBC song = GetMusicList(i).Get(j, line6Mode, isSimulation);
                	if(song.JAPLKHPLOOF(eventCategory))
					{
						if(freeMusicId != 0)
						{
							if(freeMusicId <= song.GHBPLHBNMBK_FreeMusicId)
							{
								b28 = true;
								continue;
							}
						}
						freeMusicId = song.GHBPLHBNMBK_FreeMusicId;
						category = (FreeCategoryId.Type)(i + 1);
						b28 = true;
					}
				}
			}
			return b28;
		}

		// // RVA: 0xF49150 Offset: 0xF49150 VA: 0xF49150
		// protected bool CanShow6LineHelp() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F49DC Offset: 0x6F49DC VA: 0x6F49DC
		// // RVA: 0xF38568 Offset: 0xF38568 VA: 0xF38568
		protected IEnumerator TryShowUnitDanceTutorial()
		{
			//0xF520C0
			MenuScene.Instance.InputDisable();
			MenuScene.Instance.RaycastDisable();
			yield return Co.R(TutorialManager.TryShowTutorialCoroutine(CheckTutorialFunc_UnitDance));
			MenuScene.Instance.InputEnable();
			MenuScene.Instance.RaycastEnable();
		}

		// // RVA: 0xF49178 Offset: 0xF49178 VA: 0xF49178
		protected bool CheckTutorialFunc_UnitDance(TutorialConditionId conditionId)
		{
			return conditionId == TutorialConditionId.Condition60 && !GameManager.Instance.IsTutorial && IsEnableUnitDance(false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F4A54 Offset: 0x6F4A54 VA: 0x6F4A54
		// // RVA: 0xF4923C Offset: 0xF4923C VA: 0xF4923C
		// protected IEnumerator TryShow6LineModeTutorial() { }

		// // RVA: 0xF492E8 Offset: 0xF492E8 VA: 0xF492E8
		// protected bool CheckTutorialFunc_6Line(TutorialConditionId conditionId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F4ACC Offset: 0x6F4ACC VA: 0x6F4ACC
		// // RVA: 0xF38680 Offset: 0xF38680 VA: 0xF38680
		// protected IEnumerator TryShowUtaRateTutorial() { }

		// // RVA: 0xF493C4 Offset: 0xF493C4 VA: 0xF493C4
		// protected bool CheckTutorialFunc_UtaRate(TutorialConditionId conditionId) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4BB4 Offset: 0x6F4BB4 VA: 0x6F4BB4
		// // RVA: 0xF499C8 Offset: 0xF499C8 VA: 0xF499C8
		// private void <OpenUseAccountingItemWindow>b__219_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4BC4 Offset: 0x6F4BC4 VA: 0x6F4BC4
		// // RVA: 0xF49DB0 Offset: 0xF49DB0 VA: 0xF49DB0
		// private void <OpenUseAccountingItemWindow>b__219_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4BD4 Offset: 0x6F4BD4 VA: 0x6F4BD4
		// // RVA: 0xF49DB4 Offset: 0xF49DB4 VA: 0xF49DB4
		// private void <OpenUseAccountingItemWindow>b__219_5() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4BE4 Offset: 0x6F4BE4 VA: 0x6F4BE4
		// // RVA: 0xF49DB8 Offset: 0xF49DB8 VA: 0xF49DB8
		// private void <OpenUseGameItemWindow>b__220_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4BF4 Offset: 0x6F4BF4 VA: 0x6F4BF4
		// // RVA: 0xF4A1A0 Offset: 0xF4A1A0 VA: 0xF4A1A0
		// private void <OpenUseGameItemWindow>b__220_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4C04 Offset: 0x6F4C04 VA: 0x6F4C04
		// // RVA: 0xF4A1A4 Offset: 0xF4A1A4 VA: 0xF4A1A4
		// private void <OpenUseGameItemWindow>b__220_5() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4C14 Offset: 0x6F4C14 VA: 0x6F4C14
		// // RVA: 0xF4A1A8 Offset: 0xF4A1A8 VA: 0xF4A1A8
		// private void <OpenCompletionWindow>b__221_0(PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4C24 Offset: 0x6F4C24 VA: 0x6F4C24
		// // RVA: 0xF4A1AC Offset: 0xF4A1AC VA: 0xF4A1AC
		// private void <Co_LoadAssetBundle_LoginBonusPopup>b__232_0(GameObject instance) { }
	}
}
