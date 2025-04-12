using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Common.uGUI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class MusicSelectUISupporter
	{
		public struct ApplyInfoData
		{
			public MusicSelectButtonSet.OptionStyle buttonSetStyle; // 0x0
			public bool withoutRanking; // 0x4
			public bool withoutReward; // 0x5
			public bool withoutMission; // 0x6
			public bool withoutEvRanking; // 0x7
			public bool isEventCounting; // 0x8
			public bool enemyHasSkill; // 0x9
			public bool isReceiveMission; // 0xA
			public bool isNewStory; // 0xB
		}

		public delegate string GetLiveEntranceMessageDelegate(IBJAKJJICBC musicData);

		public class MusicSelectBGMControler
		{
			private const float s_bgmFadeOutSec = 0.3f;
			private bool m_requestFadeOutBgm; // 0x8
			private int m_changeToTrialBgmId = -1; // 0xC

			// // RVA: 0x15117E0 Offset: 0x15117E0 VA: 0x15117E0
			public void FadeOutBGM()
			{
				m_changeToTrialBgmId = -1;
				if(SoundManager.Instance.bgmPlayer.isPlaying && !m_requestFadeOutBgm)
				{
					m_requestFadeOutBgm = true;
					SoundManager.Instance.bgmPlayer.FadeOut(0.3f, OnEndFadeOutBGM);
				}
			}

			// // RVA: 0x15118F8 Offset: 0x15118F8 VA: 0x15118F8
			public void ChangeTrialMusic(int wavId)
			{
				int bgmId = BgmPlayer.MENU_TRIAL_ID_BASE + wavId;
				if(SoundManager.Instance.bgmPlayer.isPlaying)
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
						m_changeToTrialBgmId = bgmId;
				}
				else
				{
					SoundManager.Instance.bgmPlayer.Play(bgmId, 1);
					m_changeToTrialBgmId = -1;
				}
			}

			// // RVA: 0x1511AB0 Offset: 0x1511AB0 VA: 0x1511AB0
			public void OnEndFadeOutBGM()
			{
				m_requestFadeOutBgm = false;
				if(m_changeToTrialBgmId < 0)
					return;
				SoundManager.Instance.bgmPlayer.Play(m_changeToTrialBgmId, 1);
				m_changeToTrialBgmId = -1;
			}
		}

		private const int s_musicSelectSeId = 5;
		private const float s_cdScrollSec = 0.2f;
		private MusicSelectMusicInfo m_musicInfo; // 0x8
		private MusicSelectCDSelect m_cdSelect; // 0xC
		private MusicSelectCDArrow m_cdArrow; // 0x10
		private PlayButtonWrapper m_playButtonUI; // 0x14
		private IKDICBBFBMI_EventBase m_eventCtrl; // 0x18
		private MMOLNAHHDOM m_unitLiveLocalSaveData; // 0x1C
		private Action<IBJAKJJICBC> OnApplyMusicInfoBasic; // 0x20
		private IMCBBOAFION OnWebViewClose; // 0x24
		private DJBHIFLHJLK OnNetErrorToTitle; // 0x28
		private Action LeaveForScrollStart; // 0x2C
		private Action EnterForScrollEnd; // 0x30
		private Action DelayedApplyMusicInfo; // 0x34
		public Action OnApplyMusicInfoNoneListener; // 0x38
		public Action<IBJAKJJICBC> OnApplyMusicInfoExEventListener; // 0x3C
		public Action<IBJAKJJICBC> OnApplyMusicInfoLiveEntranceListener; // 0x40
		public Action<IBJAKJJICBC, ApplyInfoData> OnApplyMusicInfoNormalListener; // 0x44
		public GetLiveEntranceMessageDelegate GetLiveEntranceMessageListener; // 0x48
		public Action OnChangedDifficultyListener; // 0x4C
		public bool ForceScrollClamp; // 0x50
		public MusicDataList currentMusicList; // 0x54
		public bool isLine6Mode; // 0x58
		public bool isEventTimeLimit; // 0x59
		public MusicSelectButtonSet.OptionStyle overrideButtonStyle; // 0x5C
		public KGCNCBOKCBA.GNENJEHKMHD_EventStatus eventStatus; // 0x60
		public int eventId; // 0x64
		public int eventTicketId; // 0x68
		public bool listIsEmptyByFilter; // 0x6C
		private int m_listNo; // 0x70
		private Difficulty.Type m_difficulty; // 0x74
		private LimitTimeWatcher m_musicTimeWatcher = new LimitTimeWatcher(); // 0x78
		private List<FKMOKDCJFEN> m_questList; // 0x7C
		private FDDIIKBJNNA m_snsData = new FDDIIKBJNNA(); // 0x80
		private FPGEMAIAMBF_RewardData m_rewardData; // 0x84
		private List<MusicRewardStat> m_rewardStats; // 0x88
		private MusicSelectBGMControler m_bgmControler = new MusicSelectBGMControler(); // 0x8C

		public int listNo { get { return m_listNo; } } //0xF53A48
		public Difficulty.Type difficulty { get { return m_difficulty; } } //0xF53A50
		// public MusicSelectBGMControler bgmControler { get; } 0xF53A58
		// public LimitTimeWatcher musicTimeWatcher { get; } 0xF53A60
		private bool listIsEmpty { get { return currentMusicList.GetCount(isLine6Mode, false) < 1; } } //0xF541D4
		private IBJAKJJICBC selectMusicData { get { return currentMusicList.Get(m_listNo, isLine6Mode, false); } } //0xF54224
		// private OHCAABOMEOF.KGOGMKMBCPP eventType { get; } 0xF57D8C
		private bool scrollIsClamp { get { 
			if(!ForceScrollClamp)
			{
				if(currentMusicList.GetCount(isLine6Mode, false) > 1)
				{
					return currentMusicList.GetCount(isLine6Mode, false) < 5;
				}
				return false;
			}
			return true;
		 } } //0xF57DAC
		public bool IsEventCounting { get { return eventStatus == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6; } } //0xF58044
		public bool IsEventEndChallengePeriod { get { return eventStatus > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5; } } //0xF585C0

		// // RVA: 0xF53A68 Offset: 0xF53A68 VA: 0xF53A68
		public void Setup(MusicSelectMusicInfo musicInfo, MusicSelectCDSelect cdSelect, MusicSelectCDArrow cdArrow, PlayButtonWrapper playButtonUI, IKDICBBFBMI_EventBase eventCtrl, MMOLNAHHDOM unitLiveLocalSaveData, Action<IBJAKJJICBC> OnApplyMusicInfoBasic, IMCBBOAFION OnWebViewClose, DJBHIFLHJLK OnNetErrorToTitle, Action LeaveForScrollStart, Action EnterForScrollEnd, Action DelayedApplyMusicInfo)
		{
			m_musicInfo = musicInfo;
			m_musicInfo.onChangedDifficulty = OnSelectedDifficulty;
			m_cdSelect = cdSelect;
			m_cdSelect.onClickEventDetailButton = OnClickEventDetailButton;
			m_cdSelect.onClickFlowButton = OnClickFlowButton;
			m_cdSelect.onSelectionChanged = OnSelectionChanged;
			m_cdSelect.onScrollRepeated = OnScrollRepeated;
			m_cdSelect.onScrollStarted = OnScrollStarted;
			m_cdSelect.onScrollUpdated = OnScrollUpdated;
			m_cdSelect.onScrollEnded = OnScrollEnded;
			m_cdArrow = cdArrow;
			m_playButtonUI = playButtonUI;
			m_eventCtrl = eventCtrl;
			m_unitLiveLocalSaveData = unitLiveLocalSaveData;
			this.OnApplyMusicInfoBasic = OnApplyMusicInfoBasic;
			this.OnWebViewClose = OnWebViewClose;
			this.OnNetErrorToTitle = OnNetErrorToTitle;
			this.LeaveForScrollStart = LeaveForScrollStart;
			this.EnterForScrollEnd = EnterForScrollEnd;
			this.DelayedApplyMusicInfo = DelayedApplyMusicInfo;
			CrateQuestList(eventCtrl);
			CreateSnsList(eventCtrl);
		}

		// // RVA: 0xF53E6C Offset: 0xF53E6C VA: 0xF53E6C
		private void CrateQuestList(IKDICBBFBMI_EventBase eventCtrl)
		{
			m_questList = eventCtrl != null ? FKMOKDCJFEN.KJHKBBBDBAL(eventCtrl.JOPOPMLFINI_QuestId, false, -1) : new List<FKMOKDCJFEN>();
		}

		// // RVA: 0xF53F14 Offset: 0xF53F14 VA: 0xF53F14
		private void CreateSnsList(IKDICBBFBMI_EventBase eventCtrl)
		{
			if(m_eventCtrl != null)
			{
				m_snsData.KHEKNNFCAOI(false, false, -1);
			}
		}

		// // RVA: 0xF53F64 Offset: 0xF53F64 VA: 0xF53F64
		public void Update()
		{
			m_musicTimeWatcher.Update();
		}

		// // RVA: 0xF53F90 Offset: 0xF53F90 VA: 0xF53F90
		// public void ReviseDifficulty() { }

		// // RVA: 0xF54278 Offset: 0xF54278 VA: 0xF54278
		public void SetListNo(int no)
		{
			m_listNo = no;
		}

		// // RVA: 0xF54280 Offset: 0xF54280 VA: 0xF54280
		public void SetDifficulty(Difficulty.Type difficulty)
		{
			m_difficulty = difficulty;
		}

		// // RVA: 0xF54288 Offset: 0xF54288 VA: 0xF54288
		public void ApplyBGM()
		{
			if(listIsEmpty)
			{
				m_bgmControler.FadeOutBGM();
			}
			else
			{
				if(!selectMusicData.AJGCPCMLGKO_IsEvent && !selectMusicData.BNIAJAKIAJC_IsEventMinigame)
				{
					if(!selectMusicData.IFNPBIJEPBO_IsDlded)
						m_bgmControler.FadeOutBGM();
					else
						m_bgmControler.ChangeTrialMusic(selectMusicData.KKPAHLMJKIH_WavId);
				}
				else if(selectMusicData.KKPAHLMJKIH_WavId > 0)
				{
					m_bgmControler.ChangeTrialMusic(selectMusicData.KKPAHLMJKIH_WavId);
				}
				else
				{
					m_bgmControler.FadeOutBGM();
				}
			}
		}

		// // RVA: 0xF543F4 Offset: 0xF543F4 VA: 0xF543F4
		public bool CurrentMusicDecideProcess(Action cancelCallback, Action OnClickPlayButton, Action DecideCurrentMusic, MKIKFJKPEHK viewBoostData, int boostSelectIndex/* = 0*/)
		{
			return MusicDecideProcess(selectMusicData, m_difficulty, (int recovery) =>
			{
				//0xF59CC4
				selectMusicData.IEBGBOBPJMB(recovery);
				ApplyMusicInfoNormal(selectMusicData);
				IBJAKJJICBC ib = currentMusicList.Find(selectMusicData.GHBPLHBNMBK_FreeMusicId, !isLine6Mode, false);
				if(ib != null)
					ib.IEBGBOBPJMB(recovery);
			}, cancelCallback, OnClickPlayButton, DecideCurrentMusic, viewBoostData, boostSelectIndex);
		}

		// // RVA: 0xF544D4 Offset: 0xF544D4 VA: 0xF544D4
		public static bool MusicDecideProcess(IBJAKJJICBC musicData, Difficulty.Type difficulty, Action<int> OnWeekRecovery, Action cancelCallback, Action OnClickPlayButton, Action DecideCurrentMusic, MKIKFJKPEHK viewBoostData, int boostSelectIndex /*= 0*/)
		{
			if(musicData != null)
			{
				if(viewBoostData == null)
				{
					if(musicData.LHONOILACFL_IsWeeklyEvent && musicData.MOJMEFIENDM_WeeklyEventCount < 1)
					{
						EventMusicSelectSceneBase.OpenWeekRecoveryWindow(musicData, OnWeekRecovery, cancelCallback);
						return false;
					}
					if(CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCLKMNGMIKC_GetCurrent() >= musicData.MGJKEJHEBPO_DiffInfos[(int)difficulty].BPLOEAHOPFI_Energy)
						return true;
					EventMusicSelectSceneBase.OpenStaminaWindow(() =>
					{
						//0x1510E28
						OnClickPlayButton();
					}, cancelCallback);
				}
				else
				{
					if(viewBoostData.EFFBJDMGIGO(boostSelectIndex) != MKIKFJKPEHK.IMIDFBNGHCG.CNAMHABEOPF_1)
						return true;
					EventMusicSelectSceneBase.OpenStaminaWindow(() =>
					{
						//0x1510E54
						DecideCurrentMusic();
					}, cancelCallback);
				}
			}
			return false;
		}

		// // RVA: 0xF54758 Offset: 0xF54758 VA: 0xF54758
		public void ApplyMusicListInfo(MusicDataList musicList)
		{
			currentMusicList = musicList;
			int cnt = musicList.GetCount(isLine6Mode, false);
			if(cnt > 1)
			{
				m_cdSelect.SetStyleType(MusicSelectCDSelect.StyleType.Multi);
			}
			else if(cnt == 1)
			{
				m_cdSelect.SetStyleType(MusicSelectCDSelect.StyleType.Single);
			}
			else
			{
				m_cdSelect.SetStyleType(MusicSelectCDSelect.StyleType.None);
			}
			m_cdSelect.RefreshJackets();
			UpdateScrollLimit();
			UpdateScrollArrow();
		}

		// // RVA: 0xF549FC Offset: 0xF549FC VA: 0xF549FC
		public void ApplyMusicInfo()
		{
			m_musicTimeWatcher.WatchStop();
			MenuScene.Instance.BgControl.ChangeTilingType(BgBehaviour.TilingType.Dot);
			if(listIsEmptyByFilter)
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

		// // RVA: 0xF57C1C Offset: 0xF57C1C VA: 0xF57C1C
		public void ApplyEventRemainTime(long remainSec, bool makeColor)
		{
			int d = (int)(remainSec / 86400);
			remainSec -= d * 86400;
			int h = (int)(remainSec / 3600);
			remainSec -= h * 3600;
			int mn = (int)(remainSec / 60);
			remainSec -= mn * 60;
			string s = MusicSelectSceneBase.MakeRemainTime(d, h, mn, (int)remainSec);
			if(makeColor)
			{
				s = RichTextUtility.MakeColorTagString(s, SystemTextColor.ImportantColor);
			}
			m_cdSelect.ApplyEventRemainTime(s);
		}

		// // RVA: 0xF57E50 Offset: 0xF57E50 VA: 0xF57E50
		public bool IsReceiveMission()
		{
			if(m_questList != null)
			{
				return m_questList.FindIndex((FKMOKDCJFEN x) =>
				{
					//0x1510CB8
					return x.CMCKNKKCNDK_Status == FKMOKDCJFEN.ADCPCCNCOMD_Status.FJGFAPKLLCL_Achieved;
				}) > -1;
			}
			return false;
		}

		// // RVA: 0xF57FB8 Offset: 0xF57FB8 VA: 0xF57FB8
		private bool IsEnableEvMission()
		{
			if(m_questList != null && m_eventCtrl != null)
				return m_questList.Count > 0;
			return false;
		}

		// // RVA: 0xF58058 Offset: 0xF58058 VA: 0xF58058
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
								for(int kk = 0; kk < m_snsData.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA.Count; kk++)
								{
									if(m_snsData.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA[kk].AIPLIEMLHGC == m_eventCtrl.PFPJHJJAGAG_Rewards[i].HBHMAKNGKFK_Items[j].NNFNGLJOKKF_ItemId)
									{
										if(!m_snsData.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA[kk].EDCBHGECEBE_Read)
										{
											if(!m_snsData.NPKPBDIDBBG_RoomData[k].CNEOPOINCBA[kk].GAIEHFCHAOK_New)
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

		// // RVA: 0xF585D4 Offset: 0xF585D4 VA: 0xF585D4
		private bool IsRangeOver(int index)
		{
			if(index < 0)
				return true;
			else
			{
				return currentMusicList.GetCount(isLine6Mode, false) <= index;
			}
		}

		// // RVA: 0xF58638 Offset: 0xF58638 VA: 0xF58638
		public bool CheckEventLimit()
		{
			return EventMusicSelectSceneBase.CheckEventLimit(listIsEmpty ? null : selectMusicData, m_eventCtrl.HIDHLFCBIDE_EventType, eventStatus, eventId);
		}

		// // RVA: 0xF586B0 Offset: 0xF586B0 VA: 0xF586B0
		private void SetupRewardStat(IBJAKJJICBC musicData)
		{
			if(m_rewardData == null)
				m_rewardData = new FPGEMAIAMBF_RewardData();
			if(m_rewardStats == null)
			{
				m_rewardStats = new List<MusicRewardStat>();
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
					m_rewardData.JMHCEMHPPCM(musicData.GHBPLHBNMBK_FreeMusicId, i, isLine6Mode, musicData.MNNHHJBBICA_GameEventType);
					m_rewardStats[i].Init(m_rewardData);
				}
				for(; i < 5; i++)
				{
					m_rewardStats[i].Clear();
				}
			}
		}

		// // RVA: 0xF58A20 Offset: 0xF58A20 VA: 0xF58A20
		private void ClearDifficultyButton()
		{
			if(!isLine6Mode)
			{
				m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N5, false, false);
				m_musicInfo.ChangeSelectedDiff(m_difficulty);
			}
			else
			{
				m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N3, true, false);
				m_musicInfo.ChangeSelectedDiff(m_difficulty < Difficulty.Type.Hard ? Difficulty.Type.Hard : m_difficulty);
			}
			if(m_rewardStats == null)
			{
				m_rewardStats = new List<MusicRewardStat>(5);
				for(int i = 0; i < 5; i++)
				{
					m_rewardStats.Add(new MusicRewardStat());
				}
			}
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

		// // RVA: 0xF54E58 Offset: 0xF54E58 VA: 0xF54E58
		private void ApplyFilterMusicInfoNone()
		{
			m_musicInfo.SetInfoStyle(MusicSelectMusicInfo.InfoStyle.FilterNone, isLine6Mode);
			m_playButtonUI.SetupUnitLive(null, null);
			ClearDifficultyButton();
			if(OnApplyMusicInfoNoneListener != null)
				OnApplyMusicInfoNoneListener();
		}

		// // RVA: 0xF54EE0 Offset: 0xF54EE0 VA: 0xF54EE0
		private void ApplyMusicInfoNone()
		{
			m_musicInfo.SetInfoStyle(MusicSelectMusicInfo.InfoStyle.None, isLine6Mode);
			m_playButtonUI.SetupUnitLive(null, null);
			if(OnApplyMusicInfoNoneListener != null)
				OnApplyMusicInfoNoneListener();
		}

		// // RVA: 0xF54F60 Offset: 0xF54F60 VA: 0xF54F60
		private void ApplyMusicInfoExEvent(IBJAKJJICBC musicData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_musicInfo.SetInfoStyle(MusicSelectMusicInfo.InfoStyle.Event, isLine6Mode);
			m_playButtonUI.SetType(PlayButtonWrapper.Type.Event);
			m_musicInfo.SetEventTitle(musicData.AFCMIOIGAJN_EventInfo.OPFGFINHFCE_EventName);
			m_musicInfo.SetEventDesc(musicData.AFCMIOIGAJN_EventInfo.KLMPFGOCBHC_EventDesc);
			m_cdSelect.ApplyCursorNew(musicData.LDGOHPAPBMM_IsNew);
			m_cdSelect.ApplyCursorAttr(GameAttribute.Type.None);
			m_cdSelect.ApplyCursorEventType(m_eventCtrl.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid ? MusicSelectCDSelect.EventType.Raid : MusicSelectCDSelect.EventType.Special, false);
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
			m_playButtonUI.SetupUnitLive(null, null);
			m_playButtonUI.SetDisable(false);
			m_cdSelect.ApplyEventBonus(0);
			m_cdSelect.ApplyMusicRatio(0, false);
			int y, m, d, h, mn;
			MusicSelectSceneBase.ExtractDateTime(musicData.AFCMIOIGAJN_EventInfo.KINJOEIAHFK_OpenTime, out y, out m, out d, out h, out mn);
			string d1 = MusicSelectSceneBase.MakeDateTime(y, m, d, h, mn);
			MusicSelectSceneBase.ExtractDateTime(musicData.AFCMIOIGAJN_EventInfo.PCCFAKEOBIC_CloseTime, out y, out m, out d, out h, out mn);
			string d2 = MusicSelectSceneBase.MakeDateTime(y, m, d, h, mn);
			m_musicInfo.SetEventPeriod(string.Format(RichTextUtility.MakeColorTagString(bk.GetMessageByLabel("music_event_period"), SystemTextColor.ImportantColor), d1, d2));
			if(!isEventTimeLimit)
			{
				ApplyRemainTime(musicData.AFCMIOIGAJN_EventInfo.PCCFAKEOBIC_CloseTime, true, null);
				m_cdSelect.ApplyEventCounting(false);
			}
			else
			{
				m_cdSelect.ApplyEventEndMessage(bk.GetMessageByLabel("music_event_end_attain"));
				m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.Disable, musicData.AJGCPCMLGKO_IsEvent);
				m_cdSelect.ApplyEventCounting(true);
				m_playButtonUI.SetDisable(!musicData.AJGCPCMLGKO_IsEvent);
				if(OnApplyMusicInfoExEventListener != null)
					OnApplyMusicInfoExEventListener(musicData);
			}
		}

		// // RVA: 0xF556C8 Offset: 0xF556C8 VA: 0xF556C8
		protected void ApplyMusicInfoMiniGame(IBJAKJJICBC musicData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_musicInfo.SetInfoStyle(MusicSelectMusicInfo.InfoStyle.Event, isLine6Mode);
			m_playButtonUI.SetType(PlayButtonWrapper.Type.Play);
			m_musicInfo.SetEventTitle(musicData.NOKBLCDMLPP_MinigameEventInfo.OPFGFINHFCE_EventName);
			m_musicInfo.SetEventDesc(musicData.NOKBLCDMLPP_MinigameEventInfo.KLMPFGOCBHC_EventDesc);
			m_cdSelect.ApplyCursorNew(musicData.LDGOHPAPBMM_IsNew);
			m_cdSelect.ApplyCursorAttr(GameAttribute.Type.None);
			m_cdSelect.ApplyCursorEventType(musicData.KCKBOIDCPCK_CdSelectEvenType < 1 ? MusicSelectCDSelect.EventType.Special : (MusicSelectCDSelect.EventType)musicData.KCKBOIDCPCK_CdSelectEvenType - 1, false);
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
			m_playButtonUI.SetupUnitLive(null, null);
			m_playButtonUI.SetDisable(false);
			m_cdSelect.ApplyEventBonus(0);
			m_cdSelect.ApplyMusicRatio(0, false);
			int y, m, d, h, mn;
			MusicSelectSceneBase.ExtractDateTime(musicData.NOKBLCDMLPP_MinigameEventInfo.KINJOEIAHFK_OpenTime, out y, out m, out d, out h, out mn);
			string d1 = MusicSelectSceneBase.MakeDateTime(y, m, d, h, mn);
			MusicSelectSceneBase.ExtractDateTime(musicData.NOKBLCDMLPP_MinigameEventInfo.PCCFAKEOBIC_CloseTime, out y, out m, out d, out h, out mn);
			string d2 = MusicSelectSceneBase.MakeDateTime(y, m, d, h, mn);
			m_musicInfo.SetEventPeriod(string.Format(RichTextUtility.MakeColorTagString(bk.GetMessageByLabel("music_event_period"), SystemTextColor.ImportantColor), d1, d2));
			ApplyRemainTime(musicData.NOKBLCDMLPP_MinigameEventInfo.PCCFAKEOBIC_CloseTime, true, null);
			m_cdSelect.ApplyEventCounting(false);
		}

		// // RVA: 0xF55D10 Offset: 0xF55D10 VA: 0xF55D10
		private void ApplyMusicInfoLiveEntrance(IBJAKJJICBC musicData)
		{
			m_musicInfo.SetInfoStyle(MusicSelectMusicInfo.InfoStyle.None, isLine6Mode);
			m_playButtonUI.SetType(PlayButtonWrapper.Type.Live);
			if(GetLiveEntranceMessageListener != null)
			{
				m_musicInfo.SetNoInfoMessage(GetLiveEntranceMessageListener(musicData), null);
			}
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
			m_playButtonUI.SetupUnitLive(null, null);
			m_playButtonUI.SetDisable(false);
			m_cdSelect.ApplyEventBonus(0);
			m_cdSelect.ApplyMusicRatio(0, false);
			if(OnApplyMusicInfoLiveEntranceListener != null)
				OnApplyMusicInfoLiveEntranceListener(musicData);
		}

		// // RVA: 0xF56054 Offset: 0xF56054 VA: 0xF56054
		private void ApplyMusicInfoNormal(IBJAKJJICBC musicData)
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			ApplyInfoData data = new ApplyInfoData();
			data.withoutRanking = !musicData.BJANNALFGGA_HasRanking;
			MusicSelectMusicInfo.InfoStyle style;
			if(!musicData.LEBDMNIGOJB_IsScoreEvent)
			{
				if(musicData.MNNHHJBBICA_GameEventType < 4)
				{
					if(musicData.MNNHHJBBICA_GameEventType == 1)
					{
						data.withoutMission = !IsEnableEvMission();
						style = MusicSelectMusicInfo.InfoStyle.NoReward;
						data.withoutEvRanking = !m_eventCtrl.IBNKPMPFLGI_IsRankReward;
						data.withoutReward = true;
						data.buttonSetStyle = MusicSelectButtonSet.OptionStyle.CollectEvent;
					}
					else if(musicData.MNNHHJBBICA_GameEventType == 3)
					{
						data.withoutMission = !IsEnableEvMission();
						style = MusicSelectMusicInfo.InfoStyle.BattleEvent;
						data.withoutEvRanking = !m_eventCtrl.IBNKPMPFLGI_IsRankReward;
						data.withoutReward = true;
						data.buttonSetStyle = MusicSelectButtonSet.OptionStyle.BattleEvent;
					}
					else
					{
						data.buttonSetStyle = MusicSelectButtonSet.OptionStyle.Basic;
						//LAB_00f561d4
						style = MusicSelectMusicInfo.InfoStyle.Music;
						data.withoutEvRanking = false;
						data.withoutMission = false;
						data.withoutReward = false;
					}
				}
				else
				{
					data.buttonSetStyle = MusicSelectButtonSet.OptionStyle.Basic;
					if(musicData.MNNHHJBBICA_GameEventType == 6)
					{
						style = MusicSelectMusicInfo.InfoStyle.Music;
						data.withoutReward = false;
						if(musicData.DEPGBBJMFED_CategoryId == 5)
						{
							style = MusicSelectMusicInfo.InfoStyle.NoReward;
							if(musicData.LHONOILACFL_IsWeeklyEvent)
								style = MusicSelectMusicInfo.InfoStyle.Music;
							data.withoutReward = !musicData.LHONOILACFL_IsWeeklyEvent;
						}
						data.withoutMission = !IsEnableEvMission();
						data.withoutEvRanking = !m_eventCtrl.IBNKPMPFLGI_IsRankReward;
					}
					else if(musicData.MNNHHJBBICA_GameEventType == 14)
					{
						data.withoutEvRanking = false;
						data.withoutReward = musicData.OGHOPBAKEFE_IsEventSpecial;
						style = data.withoutReward ? MusicSelectMusicInfo.InfoStyle.NoReward : MusicSelectMusicInfo.InfoStyle.Music;
						data.withoutMission = false;
					}
					else
					{
						//LAB_00f561d4
						style = MusicSelectMusicInfo.InfoStyle.Music;
						data.withoutEvRanking = false;
						data.withoutMission = false;
						data.withoutReward = false;
					}
				}
			}
			else
			{
				data.buttonSetStyle = MusicSelectButtonSet.OptionStyle.ScoreEvent;
				//LAB_00f561d4
				style = MusicSelectMusicInfo.InfoStyle.Music;
				data.withoutEvRanking = false;
				data.withoutMission = false;
				data.withoutReward = false;
			}
			if(overrideButtonStyle != MusicSelectButtonSet.OptionStyle.None)
			{
				data.buttonSetStyle = overrideButtonStyle;
			}
			m_musicInfo.SetInfoStyle(style, isLine6Mode);
			if(!musicData.IFNPBIJEPBO_IsDlded)
			{
				if(!musicData.HDPMAJKGIOI)
				{
					m_playButtonUI.SetType(PlayButtonWrapper.Type.Download);
				}
			}
			else if(!musicData.HDPMAJKGIOI)
			{
				m_playButtonUI.SetType(PlayButtonWrapper.Type.PlayEn);
			}
			if(!isLine6Mode)
			{
				if(musicData.PJLNJJIBFBN_HasExtremeDiff)
				{
					m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N5, isLine6Mode, false);
				}
				else
				{
					m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N4, isLine6Mode, false);
					if(m_difficulty > Difficulty.Type.VeryHard)
						m_difficulty = Difficulty.Type.VeryHard;
				}
			}
			else
			{
				m_musicInfo.SetDiffTabStyle(MusicSelectMusicInfo.DiffTabStyle.N3, isLine6Mode, false);
				if(m_difficulty < Difficulty.Type.Hard)
					m_difficulty = Difficulty.Type.Hard;
			}
			for(int i = musicData.MGJKEJHEBPO_DiffInfos.Count - 1; i >= 0; i--)
			{
				if(musicData.MGJKEJHEBPO_DiffInfos[i].POOMOBGPCNE_IsLocked && i <= (int)m_difficulty)
					m_difficulty = (Difficulty.Type)i - 1;
			}
			if(!musicData.HDPMAJKGIOI)
			{
				m_playButtonUI.SetNeedEnergy(musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].BPLOEAHOPFI_Energy);
			}
			data.enemyHasSkill = musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].HPBPDHPIBGN_EnemyData.CDEFLIHHNAB_HasSkills;
			data.isReceiveMission = IsReceiveMission();
			data.isNewStory = IsNewStory();
			if(musicData.LEBDMNIGOJB_IsScoreEvent)
			{
				Debug.LogError("StringLiteral_18744");
			}
			m_cdSelect.ApplyEventCounting(false);
			m_musicInfo.ChangeSelectedDiff(m_difficulty);
			m_musicInfo.SetMusicTitle(musicData.NEDBBJDAFBH_MusicName, GameAttributeTextColor.Colors[musicData.FKDCCLPGKDK_JacketAttr - 1], false);
			m_musicInfo.SetSingerName(musicData.LJCEDBBNPBB_VocalName, false);
			if(musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].HHMLMKAEJBJ_Score != null)
			{
				StringBuilder str = new StringBuilder(8);
				str.Set(musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].HHMLMKAEJBJ_Score.ANAJIAENLNB_MusicLevel.ToString());
				if(isLine6Mode)
				{
					str.Append("+");
				}
				m_musicInfo.SetMusicLevel(str.ToString());
			}
			SetupRewardStat(musicData);
			for(int i = 0; i < musicData.MGJKEJHEBPO_DiffInfos.Count; i++)
			{
				m_musicInfo.SetDiffLock((Difficulty.Type)i, musicData.MGJKEJHEBPO_DiffInfos[i].POOMOBGPCNE_IsLocked, true);
				m_musicInfo.SetDiffStatus((Difficulty.Type)i, musicData.MGJKEJHEBPO_DiffInfos[i].CADENLBDAEB_IsNew, musicData.MGJKEJHEBPO_DiffInfos[i].BCGLDMKODLC_IsClear, 
					(RhythmGameConsts.ResultComboType)musicData.MGJKEJHEBPO_DiffInfos[i].LCOHGOIDMDF_ComboRank);
			}
			if(!musicData.HDPMAJKGIOI)
			{
				m_cdSelect.ApplyCursorNew(musicData.LDGOHPAPBMM_IsNew);
				if(data.withoutReward)
				{
					m_cdSelect.HideCursorRewardMark();
				}
				else
				{
					m_musicInfo.SetReward(m_rewardStats[(int)m_difficulty].allAchievedNum, m_rewardStats[(int)m_difficulty].allRewardNum);
					m_cdSelect.ShowCursorRewardMark(m_rewardStats[(int)m_difficulty].isScoreComplete, m_rewardStats[(int)m_difficulty].isComboComplete, m_rewardStats[(int)m_difficulty].isClearCountComplete);
				}
				if(musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].BCGLDMKODLC_IsClear)
				{
					m_musicInfo.SetHighscore(musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].KNIFCANOHOC_Score);
					m_musicInfo.SetMusicScoreRank((ResultScoreRank.Type)musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].BAKLKJLPLOJ.DLPBHJALHCK_GetScoreRank(musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].KNIFCANOHOC_Score));
				}
				else
				{
					m_musicInfo.SetHighscore(0);
					m_musicInfo.SetMusicScoreRank(ResultScoreRank.Type.Illegal);
				}
				m_musicInfo.SetMusicAttr((GameAttribute.Type)musicData.FKDCCLPGKDK_JacketAttr);
				m_cdSelect.ApplyCursorAttr((GameAttribute.Type)musicData.FKDCCLPGKDK_JacketAttr);
				if(eventStatus > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5)
				{
					MenuScene.Instance.BgControl.ChangeAttribute(GameAttribute.Type.None);
				}
				else
				{
					MenuScene.Instance.BgControl.ChangeAttribute((GameAttribute.Type)musicData.FKDCCLPGKDK_JacketAttr);
					m_musicInfo.SetMusicComboRank((RhythmGameConsts.ResultComboType)musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].LCOHGOIDMDF_ComboRank, Mathf.Max(0, musicData.MGJKEJHEBPO_DiffInfos[(int)m_difficulty].NLKEBAOBJCM_Combo));
					m_playButtonUI.SetDisable(false);
					m_cdSelect.ApplyEventBonus(musicData.DBJOBFIGGEE_EventBonusPercent);
					m_cdSelect.ApplyMusicRatio(selectMusicData.AKAPOCOIECA_GetMusicRatio(), selectMusicData.DEPGBBJMFED_CategoryId != 5);
					m_cdSelect.ApplyCursorWeekRecoveryIcon(false);
					m_cdSelect.EnableEventMusicRank(false);
					m_cdSelect.ApplyEventMusicRank(0);
				}
			}
			else
			{
				MenuScene.Instance.BgControl.ChangeAttribute(GameAttribute.Type.None);
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
			m_cdSelect.HideEventFoDivaExp();
			m_cdSelect.EnableEventGoDivaRanking(false);
			m_cdSelect.EnableEventGoDivaExpBonus(false);
			if(musicData.LHONOILACFL_IsWeeklyEvent)
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
					ApplyTicletDropIcon(m_cdSelect, eventTicketId);
					m_cdSelect.ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle.Weekly, false);
				}
				m_cdSelect.ApplyCursorEventRemainCount(musicData.MOJMEFIENDM_WeeklyEventCount, musicData.GDLNCHCPMCK_HasBoost);
				List<int> l = new List<int>(3);
				for(int i = 0; i < 3; i++)
				{
					if(musicData.ICHJBDPJNMA_GetWeeklyItem(musicData.IHKFMJDOBAH_WeekDayAttr, i) > 0)
					{
						l.Add(musicData.ICHJBDPJNMA_GetWeeklyItem(musicData.IHKFMJDOBAH_WeekDayAttr, i));
					}
				}
				m_cdSelect.ApplyEventItems(l);
				//LAB_00f57988
			}
			else if(musicData.LEBDMNIGOJB_IsScoreEvent)
			{
				Debug.LogError("StringLiteral_18744");
				ApplyMusicInfoBasic(musicData);
				if(musicData.KCKBOIDCPCK_CdSelectEvenType > 0)
				{
					m_cdSelect.ApplyCursorEventType((MusicSelectCDSelect.EventType)musicData.KCKBOIDCPCK_CdSelectEvenType - 1, false);
				}
			}
			else if(musicData.AJGCPCMLGKO_IsEvent)
			{
				ApplyMusicInfoExEvent(musicData);
				//LAB_00f57988
			}
			else if(musicData.BNIAJAKIAJC_IsEventMinigame)
			{
				ApplyMusicInfoMiniGame(musicData);
				//LAB_00f57988
			}
			else
			{
				ApplyMusicInfoBasic(musicData);
				if(musicData.KCKBOIDCPCK_CdSelectEvenType > 0)
				{
					m_cdSelect.ApplyCursorEventType((MusicSelectCDSelect.EventType)musicData.KCKBOIDCPCK_CdSelectEvenType - 1, false);
				}
			}
			//LAB_00f57988
			m_playButtonUI.SetupUnitLive(musicData, m_unitLiveLocalSaveData);
			m_cdSelect.ApplyCursorLimited(musicData.NNJNNCGGKMC_IsLimited);
			if(musicData.NNJNNCGGKMC_IsLimited)
			{
				ApplyRemainTime(musicData.IHPCKOMBGKJ_End, true, null);
			}
			if(OnApplyMusicInfoNormalListener != null)
				OnApplyMusicInfoNormalListener(musicData, data);
		}

		// // RVA: 0xF58C84 Offset: 0xF58C84 VA: 0xF58C84
		private void ApplyRemainTime(long endTime, bool makeColor, LimitTimeWatcher.OnEndCallback endCallback)
		{
			m_musicTimeWatcher.onElapsedCallback = (long current, long limit, long remain) =>
			{
				//0x1510E88
				ApplyEventRemainTime(remain, makeColor);
			};
			m_musicTimeWatcher.onEndCallback = endCallback;
			m_musicTimeWatcher.WatchStart(endTime, true);
		}

		// // RVA: 0xF58DE4 Offset: 0xF58DE4 VA: 0xF58DE4
		// private void ApplyTicletDropIcon() { }

		// // RVA: 0xF58E68 Offset: 0xF58E68 VA: 0xF58E68
		public static void ApplyTicletDropIcon(MusicSelectCDSelect cdSelect, int eventTicketId)
		{
			cdSelect.EventTicketEnable(false);
			if(eventTicketId < 1)
			{
				cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.None);
			}
			else
			{
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(eventTicketId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
				{
					cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.FoldRadar);
				}
				else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(eventTicketId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
				{
					cdSelect.ApplyDropItemType(MusicSelectCDSelect.DropType.Ticket);
				}
				GameManager.Instance.ItemTextureCache.Load(eventTicketId, (IiconTexture image) =>
				{
					//0x1510EE8
					cdSelect.EventTicketEnable(true);
					cdSelect.SetEventTicketIcon(image);
				});
			}
		}

		// // RVA: 0xF58DF4 Offset: 0xF58DF4 VA: 0xF58DF4
		private void ApplyMusicInfoBasic(IBJAKJJICBC musicData)
		{
			if(OnApplyMusicInfoBasic != null)
				OnApplyMusicInfoBasic(musicData);
		}

		// // RVA: 0xF590D4 Offset: 0xF590D4 VA: 0xF590D4
		private void OnSelectedDifficulty(Difficulty.Type difficulty)
		{
			m_difficulty = difficulty;
			ApplyMusicInfo();
			OnChangedDifficultyListener();
		}

		// // RVA: 0xF5482C Offset: 0xF5482C VA: 0xF5482C
		private void UpdateScrollLimit()
		{
			if(!scrollIsClamp)
			{
				m_cdSelect.ClearScrollLimit();
			}
			else
			{
				m_cdSelect.SetScrollLimit(-m_listNo, currentMusicList.GetCount(isLine6Mode, false) - 1 - m_listNo);
			}
		}

		// // RVA: 0xF548DC Offset: 0xF548DC VA: 0xF548DC
		private void UpdateScrollArrow()
		{
			if(currentMusicList.GetCount(isLine6Mode, false) < 2)
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

		// // RVA: 0xF5910C Offset: 0xF5910C VA: 0xF5910C
		private void OnClickEventDetailButton()
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
					Debug.LogError("StringLiteral_18744");
				}
			}
		}

		// // RVA: 0xF59358 Offset: 0xF59358 VA: 0xF59358
		private void OnClickFlowButton(int offset)
		{
			if(offset < 0)
			{
				MenuScene.Instance.InputDisable();
				m_cdSelect.RequestLeftFlow(-offset, 0.2f, () =>
				{
					//0x1510CE8
					MenuScene.Instance.InputEnable();
				});
			}
			else if(offset != 0)
			{
				MenuScene.Instance.InputDisable();
				m_cdSelect.RequestRightFlow(offset, 0.2f, () =>
				{
					//0x1510D84
					MenuScene.Instance.InputEnable();
				});
			}
		}

		// // RVA: 0xF59674 Offset: 0xF59674 VA: 0xF59674
		private void OnSelectionChanged(int offset)
		{
			if(offset != 0)
			{
				SoundManager.Instance.sePlayerBoot.Play((int)mcrs.cs_se_boot.SE_BTN_004);
			}
			m_listNo = RepeatIndex(m_listNo + offset);
			ApplyMusicInfo();
		}

		// // RVA: 0xF59750 Offset: 0xF59750 VA: 0xF59750
		private void OnScrollRepeated(int repeatDelta, int beginIndex, int endIndex)
		{
			if(!listIsEmpty)
			{
				if(beginIndex <= endIndex)
				{
					for(int order = 0; beginIndex + order <= endIndex; order++)
					{
						int idx = beginIndex + order + m_listNo;
						if(scrollIsClamp && IsRangeOver(idx))
						{
							m_cdSelect.HideJacket(order);
						}
						else
						{
							int idx2 = RepeatIndex(idx);
                            IBJAKJJICBC ib = currentMusicList.Get(idx2, isLine6Mode, false);
							bool b2 = ib.BNIAJAKIAJC_IsEventMinigame;
							bool b3;
							int id = ib.JNCPEGJGHOG_JacketId;
							if(!ib.AJGCPCMLGKO_IsEvent)
							{
								b3 = false;
								if(b2)
								{
									id = ib.NOKBLCDMLPP_MinigameEventInfo.GOAPADIHAHG_EventId;
									b2 = true;
									b3 = false;
								}
							}
							else
							{
								id = ib.AFCMIOIGAJN_EventInfo.GOAPADIHAHG_EventId;
								b3 = true;
							}
							int i4 = 0;
							if(!b3 && !b2)
							{
								i4 = ib.FKDCCLPGKDK_JacketAttr;
							}
							m_cdSelect.ChangeJacket(order, id, (GameAttribute.Type)i4, b3 || b2);
                        }
					}
				}
			}
			else
			{
				m_cdSelect.ChangeJacket(0, 0, 0, false);
			}
		}

		// // RVA: 0xF599F4 Offset: 0xF599F4 VA: 0xF599F4
		private void OnScrollStarted(bool isAuto)
		{
			if(!isAuto)
			{
				LeaveForScrollStart();
			}
			if(m_cdSelect != null)
				m_playButtonUI.Leave(true);
		}

		// // RVA: 0xF59AE0 Offset: 0xF59AE0 VA: 0xF59AE0
		private void OnScrollUpdated(bool isAuto)
		{
			UpdateScrollArrow();
		}

		// // RVA: 0xF59AE4 Offset: 0xF59AE4 VA: 0xF59AE4
		private void OnScrollEnded(bool isAuto)
		{
			if(!isAuto)
			{
				EnterForScrollEnd();
			}
			if(m_cdSelect != null)
			{
				m_playButtonUI.Enter(false);
			}
			UpdateScrollLimit();
			UpdateScrollArrow();
			DelayedApplyMusicInfo();
		}

		// // RVA: 0xF596F8 Offset: 0xF596F8 VA: 0xF596F8
		private int RepeatIndex(int index)
		{
			return XeSys.Math.Repeat(index, 0, currentMusicList.GetCount(isLine6Mode, false) - 1);
		}
	}
}
