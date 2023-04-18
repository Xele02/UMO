using System.Collections;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public abstract class MusicSelectSceneBase : TransitionRoot
	{
		public delegate bool CheckMatchMusicFilterFunc(IBJAKJJICBC musicData, long currentTime);
		private class PlayButton : PlayButtonWrapper
		{
			public override MusicSelectCDSelect baseUI { get; protected set; } // 0x8

			// RVA: 0xF3AB18 Offset: 0xF3AB18 VA: 0xF3AB18
			public PlayButton(MusicSelectCDSelect ui)
			{
				baseUI = ui;
			}

			// // RVA: 0xF52748 Offset: 0xF52748 VA: 0xF52748 Slot: 6
			// public override void Enter(bool immediate = False) { }

			// // RVA: 0xF5278C Offset: 0xF5278C VA: 0xF5278C Slot: 7
			// public override void Leave(bool immediate = False) { }

			// // RVA: 0xF527D0 Offset: 0xF527D0 VA: 0xF527D0 Slot: 8
			// public override void SetDisable(bool disable) { }

			// // RVA: 0xF52814 Offset: 0xF52814 VA: 0xF52814 Slot: 9
			// public override void SetType(PlayButtonWrapper.Type type) { }

			// // RVA: 0xF52974 Offset: 0xF52974 VA: 0xF52974 Slot: 10
			// public override void SetNeedEnergy(int en) { }
		}

		// private const int s_musicSelectSeId = 5;
		// private const float s_bgmFadeOutSec = 0.3f;
		// private const float s_cdScrollSec = 0.2f;
		protected MusicSelectMusicInfo m_musicInfo; // 0x48
		protected MusicSelectCDSelect m_cdSelect; // 0x4C
		protected MusicSelectCDArrow m_cdArrow; // 0x50
		protected MusicSelectButtonSet m_buttonSet; // 0x54
		protected MusicSelectEventBanner m_eventBanner; // 0x58
		protected MusicSelectMusicRate m_musicRate; // 0x5C
		private PopupAchieveRewardSetting m_rewardPopupSetting = new PopupAchieveRewardSetting(); // 0x60
		// private FPGEMAIAMBF m_rewardData; // 0x64
		// private List<MusicRewardStat> m_rewardStats; // 0x68
		// private EJKBKMBJMGL m_enemyData = new EJKBKMBJMGL(); // 0x6C
		protected bool m_isInitialized; // 0x74
		protected bool m_isSimulationLive; // 0x75
		private bool m_isConfirmedUnitDance; // 0x76
		protected bool m_isLine6Mode; // 0x77
		// protected bool m_isListEmptyByFilter; // 0x78
		// protected string m_missionText = string.Empty; // 0x7C
		// protected int m_overrideEnemyCenterSkill; // 0x80
		// protected int m_overrideEnemyLiveSkill; // 0x84
		// protected MusicSelectButtonSet.OptionStyle m_overrideButtonStyle; // 0x88
		// protected GameSetupData.MusicInfo.InitFreeMusicParam m_initParam; // 0x8C
		// private PopupUnitDanceWarning m_popupUnitDanceWarning = new PopupUnitDanceWarning(); // 0x94
		protected IKDICBBFBMI_EventBase m_eventCtrl; // 0x98
		protected IKDICBBFBMI_EventBase m_scoreEventCtrl; // 0x9C
		// private List<FKMOKDCJFEN> m_questList; // 0xA0
		// private FDDIIKBJNNA m_snsData = new FDDIIKBJNNA(); // 0xA4
		protected MMOLNAHHDOM m_unitLiveLocalSaveData; // 0xA8
		protected int m_eventId; // 0xAC
		protected int m_eventIndex; // 0xB0
		protected int m_eventTicketId; // 0xB4
		// protected OHCAABOMEOF.KGOGMKMBCPP m_currentEventType; // 0xB8
		// protected List<int> m_eventHelpId = new List<int>(2); // 0xBC
		// protected KGCNCBOKCBA.GNENJEHKMHD m_eventStatus; // 0xC0
		// protected bool m_isEventTimeLimit; // 0xC4
		// protected bool m_isScoreEventTimeLimit; // 0xC5
		// protected bool m_isShowFirstHelp; // 0xC6
		protected LimitTimeWatcher m_musicTimeWatcher = new LimitTimeWatcher(); // 0xC8
		protected LimitTimeWatcher m_bannerTimeWatcher = new LimitTimeWatcher(); // 0xCC
		protected bool m_isEndActivateScene; // 0xD0
		// private bool m_muteSelectionSe; // 0xD1
		// private bool m_requestFadeOutBgm; // 0xD2
		// private int m_changeToTrialBgmId = -1; // 0xD4
		// private bool m_showTicketGainedPopup; // 0xD9
		// private bool m_showitemReceivePopup; // 0xDA
		private bool m_loadingTicketGainedPopup; // 0xDB
		// private TicketGainedPopupSetting m_ticketGainedPopupSetting; // 0xDC
		// private PopupItemGetSetting m_itemReceivePopupSetting = new PopupItemGetSetting(); // 0xE0
		// private TeamSlectSceneArgs m_teamSelectSceneArgs = new TeamSlectSceneArgs(); // 0xE4
		// private List<Action> NoticeActionList = new List<Action>(); // 0xF4

		// protected abstract int musicListCount { get; }  Slot: 31
		// protected abstract MusicDataList currentMusicList { get; } Slot: 33
		protected PlayButtonWrapper playButtonUI { get; private set; } // 0x70
		protected bool isBgChanging { get; private set; } // 0xD8
		// protected float bgmFadeOutSec { get; } 0xF3946C
		public int list_no { get; set; } // 0xE8
		public Difficulty.Type diff { get; set; } // 0xEC
		// protected IBJAKJJICBC selectMusicData { get; } 0xF39498
		// protected bool listIsEmpty { get; } 0xF39510
		// protected bool listisEmptyByFilter { get; } 0xF39584
		// protected virtual bool scrollIsClamp { get; } 0xF3958C
		// public int freeMusicId { get; } 0xF39660
		// public int gameEventType { get; } 0xF396A8
		// public int musicId { get; } 0xF396F0
		// public bool isEventGame { get; set; } // 0xF0
		// public bool IsEventCounting { get; } 0xF39748
		// public bool IsEventEndChallengePeriod { get; } 0xF3975C
		// public bool IsEventRankingEnd { get; } 0xF39770

		// RVA: -1 Offset: -1 Slot: 32
		// protected abstract MusicDataList GetMusicList(int i);

		// // RVA: 0xF39784 Offset: 0xF39784 VA: 0xF39784
		// public bool IsNewStory() { }

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
			TodoLogger.Log(0, "MusicSelectSceneBase OnDeleteCache");
		}

		// RVA: 0xF3A050 Offset: 0xF3A050 VA: 0xF3A050 Slot: 30
		protected override void InputDisable()
		{
			TodoLogger.Log(0, "MusicSelectSceneBase InputDisable");
		}

		// RVA: 0xF3A110 Offset: 0xF3A110 VA: 0xF3A110 Slot: 29
		protected override void InputEnable()
		{
			TodoLogger.Log(0, "MusicSelectSceneBase InputEnable");
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
		// protected void CrateQuestList() { }

		// // RVA: 0xF3A678 Offset: 0xF3A678 VA: 0xF3A678
		// protected void CreateSnsList() { }

		// // RVA: 0xF3A6C8 Offset: 0xF3A6C8 VA: 0xF3A6C8
		// protected void SetupHelp() { }

		// // RVA: 0xF3AA8C Offset: 0xF3AA8C VA: 0xF3AA8C Slot: 38
		protected virtual PlayButtonWrapper CreatePlayButtonWrapper()
		{
			return new MusicSelectSceneBase.PlayButton(m_cdSelect);
		}

		// // RVA: -1 Offset: -1 Slot: 39
		protected abstract void Release();

		// // RVA: -1 Offset: -1 Slot: 40
		protected abstract void SetupViewMusicData();

		// // RVA: 0xF3AB4C Offset: 0xF3AB4C VA: 0xF3AB4C Slot: 41
		protected virtual void ApplyBasicInfo()
		{
			TodoLogger.Log(0, "MusicSelectScene* ApplyBasicInfo");
		}

		// // RVA: 0xF3AE70 Offset: 0xF3AE70 VA: 0xF3AE70 Slot: 42
		protected virtual void ApplyMusicListInfo()
		{
			TodoLogger.Log(0, "MusicSelectScene* ApplyMusicListInfo");
			m_cdSelect.SetStyleType(MusicSelectCDSelect.StyleType.Single);
		}

		// // RVA: 0xF3B180 Offset: 0xF3B180 VA: 0xF3B180 Slot: 43
		protected virtual void ApplyMusicInfo()
		{
			TodoLogger.Log(0, "MusicSelectScene* ApplyMusicInfo");
		}

		// // RVA: 0xF3E720 Offset: 0xF3E720 VA: 0xF3E720 Slot: 44
		protected virtual void DelayedApplyMusicInfo()
		{
			TodoLogger.Log(0, "MusicSelectSceneBase DelayedApplyMusicInfo");
		}

		// // RVA: 0xF3EB0C Offset: 0xF3EB0C VA: 0xF3EB0C
		// private void SetDifficultyButton() { }

		// // RVA: 0xF3B5E8 Offset: 0xF3B5E8 VA: 0xF3B5E8
		// protected void ApplyFilterMusicInfoNone() { }

		// // RVA: 0xF3B69C Offset: 0xF3B69C VA: 0xF3B69C
		// protected void ApplyMusicInfoNone() { }

		// // RVA: 0xF3C8AC Offset: 0xF3C8AC VA: 0xF3C8AC
		// protected void ApplyMusicInfoNormal(IBJAKJJICBC musicData) { }

		// // RVA: 0xF3B748 Offset: 0xF3B748 VA: 0xF3B748
		// protected void ApplyMusicInfoExEvent(IBJAKJJICBC musicData) { }

		// // RVA: 0xF3BEE4 Offset: 0xF3BEE4 VA: 0xF3BEE4
		// protected void ApplyMusicInfoMiniGame(IBJAKJJICBC musicData) { }

		// // RVA: 0xF3C588 Offset: 0xF3C588 VA: 0xF3C588
		// protected void ApplyMusicInfoLiveEntrance(IBJAKJJICBC musicData) { }

		// // RVA: 0xF3FAA0 Offset: 0xF3FAA0 VA: 0xF3FAA0 Slot: 45
		// protected virtual string GetLiveEntranceMessage(IBJAKJJICBC musicData) { }

		// // RVA: 0xF3FB04 Offset: 0xF3FB04 VA: 0xF3FB04 Slot: 46
		// protected virtual void ApplyMusicInfoBasic(IBJAKJJICBC musicData) { }

		// // RVA: 0xF3FBC0 Offset: 0xF3FBC0 VA: 0xF3FBC0 Slot: 47
		// protected virtual void ApplyMusicInfoSimulationLive(IBJAKJJICBC musicData) { }

		// // RVA: 0xF40200 Offset: 0xF40200 VA: 0xF40200 Slot: 48
		// protected virtual void ApplyUnitLiveButtonSetting(bool isUnit) { }

		// // RVA: 0xF3F2E8 Offset: 0xF3F2E8 VA: 0xF3F2E8
		// protected void ApplyRemainTime(long endTime, bool makeColor, LimitTimeWatcher.OnEndCallback endCallback) { }

		// // RVA: 0xF402A4 Offset: 0xF402A4 VA: 0xF402A4
		// protected void ApplyEventRemainTime(long remainSec, bool makeColor) { }

		// // RVA: 0xF4066C Offset: 0xF4066C VA: 0xF4066C
		// protected void ApplyEventBannerRemainTime(long remainSec, bool makeColor) { }

		// // RVA: 0xF3F448 Offset: 0xF3F448 VA: 0xF3F448
		// protected void ApplyTicletDropIcon() { }

		// // RVA: 0xF407DC Offset: 0xF407DC VA: 0xF407DC
		// protected void DownloadCurrentMusic() { }

		// // RVA: 0xF408DC Offset: 0xF408DC VA: 0xF408DC
		// protected void GotoEventMusicSelect(int eventId) { }

		// // RVA: 0xF40D2C Offset: 0xF40D2C VA: 0xF40D2C
		// protected void GotoMiniGame(int miniGameId) { }

		// // RVA: 0xF40DD0 Offset: 0xF40DD0 VA: 0xF40DD0
		// protected void GotoEventQuest(int eventId) { }

		// // RVA: 0xF41220 Offset: 0xF41220 VA: 0xF41220
		// protected void GotoEventBattle(int eventId) { }

		// // RVA: 0xF41670 Offset: 0xF41670 VA: 0xF41670
		// protected void GotoEventRaid(int eventId) { }

		// // RVA: 0xF41DD0 Offset: 0xF41DD0 VA: 0xF41DD0
		// protected void GotoEventGoDiva(int eventId) { }

		// // RVA: 0xF42220 Offset: 0xF42220 VA: 0xF42220
		// protected void GotoRegularMusicSelect() { }

		// // RVA: 0xF422D8 Offset: 0xF422D8 VA: 0xF422D8
		// private void CheckBoostData(Action endCallback, Action cancelCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F425C Offset: 0x6F425C VA: 0x6F425C
		// // RVA: 0xF42398 Offset: 0xF42398 VA: 0xF42398
		// private IEnumerator Co_CheckBoostData(Action endCallback, Action cancelCallback) { }

		// // RVA: 0xF42478 Offset: 0xF42478 VA: 0xF42478
		// private void CheckSimulationLive(Action endCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F42D4 Offset: 0x6F42D4 VA: 0x6F42D4
		// // RVA: 0xF42528 Offset: 0xF42528 VA: 0xF42528
		// private IEnumerator Co_CheckSimulationLive(Action endCallback) { }

		// // RVA: 0xF425D4 Offset: 0xF425D4 VA: 0xF425D4 Slot: 49
		// protected virtual int GetDanceDivaCount() { }

		// // RVA: 0xF42600 Offset: 0xF42600 VA: 0xF42600
		// private void CheckUnitLive(Action endCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F434C Offset: 0x6F434C VA: 0x6F434C
		// // RVA: 0xF426B8 Offset: 0xF426B8 VA: 0xF426B8
		// private IEnumerator Co_CheckUnitLive(Action endCallback) { }

		// // RVA: 0xF42780 Offset: 0xF42780 VA: 0xF42780
		// private void DummyBackButton() { }

		// // RVA: 0xF42784 Offset: 0xF42784 VA: 0xF42784
		// private void UnitDanceOnlyBackButton() { }

		// // RVA: 0xF427D0 Offset: 0xF427D0 VA: 0xF427D0
		// protected bool IsEventMissionSupport() { }

		// // RVA: 0xF3EE10 Offset: 0xF3EE10 VA: 0xF3EE10
		// protected bool IsReceiveMission() { }

		// // RVA: 0xF3ED84 Offset: 0xF3ED84 VA: 0xF3ED84
		// private bool IsEnableEvMission() { }

		// // RVA: 0xF4286C Offset: 0xF4286C VA: 0xF4286C
		// private void DecideCurrentMusic() { }

		// // RVA: 0xF42F08 Offset: 0xF42F08 VA: 0xF42F08 Slot: 50
		// protected virtual bool CurrentMusicDecisionCheck(Action cancelCallback, MKIKFJKPEHK viewBoostData, int selectIndex = 0) { }

		// // RVA: 0xF4388C Offset: 0xF4388C VA: 0xF4388C Slot: 51
		// protected virtual void OnDecideCurrentMusic() { }

		// // RVA: 0xF3E83C Offset: 0xF3E83C VA: 0xF3E83C
		// protected void FadeOutBGM() { }

		// // RVA: 0xF3E954 Offset: 0xF3E954 VA: 0xF3E954
		// protected void ChangeTrialMusic(int wavId) { }

		// // RVA: 0xF43890 Offset: 0xF43890 VA: 0xF43890
		// private void OnEndFadeOutBGM() { }

		// // RVA: 0xF43910 Offset: 0xF43910 VA: 0xF43910
		// protected void MuteSelectionSe(bool isMute) { }

		// // RVA: 0xF43918 Offset: 0xF43918 VA: 0xF43918 Slot: 52
		// protected virtual void LeaveForScrollStart() { }

		// // RVA: 0xF439CC Offset: 0xF439CC VA: 0xF439CC Slot: 53
		// protected virtual void EnterForScrollEnd() { }

		// // RVA: 0xF43A80 Offset: 0xF43A80 VA: 0xF43A80
		// protected void CheckSnsNotice() { }

		// // RVA: 0xF43BC8 Offset: 0xF43BC8 VA: 0xF43BC8
		// protected void CheckOfferNotice() { }

		// // RVA: 0xF3870C Offset: 0xF3870C VA: 0xF3870C
		// protected void AddNotice(Action action) { }

		// // RVA: 0xF3878C Offset: 0xF3878C VA: 0xF3878C
		// protected void ShowNotice() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F43C4 Offset: 0x6F43C4 VA: 0x6F43C4
		// // RVA: 0xF43CB0 Offset: 0xF43CB0 VA: 0xF43CB0
		// private IEnumerator Co_ShowNotice() { }

		// // RVA: 0xF43D5C Offset: 0xF43D5C VA: 0xF43D5C
		// private void OnWebViewClose() { }

		// // RVA: 0xF43DF8 Offset: 0xF43DF8 VA: 0xF43DF8
		// private void OnNetErrorToTitle() { }

		// // RVA: 0xF43E94 Offset: 0xF43E94 VA: 0xF43E94
		protected void ReviseDifficulty()
		{
			TodoLogger.Log(0, "ReviseDifficulty");
		}

		// // RVA: 0xF440D8 Offset: 0xF440D8 VA: 0xF440D8
		// protected int RepeatIndex(int index) { }

		// // RVA: 0xF44154 Offset: 0xF44154 VA: 0xF44154
		// protected bool IsRangeOver(int index) { }

		// // RVA: 0xF40414 Offset: 0xF40414 VA: 0xF40414
		public static void ExtractRemainTime(int totalSec, out int days, out int hours, out int minutes, out int seconds)
		{
			days = totalSec / 86400;
			hours = (totalSec - days * 86400) / 3600;
			minutes = (totalSec - days * 86400 - hours * 3600) / 60;
			seconds = (totalSec - days * 86400 - hours * 3600 - minutes * 60);
		}

		// // RVA: 0xF40494 Offset: 0xF40494 VA: 0xF40494
		// public static string MakeRemainTime(int days, int hours, int minutes, int seconds) { }

		// // RVA: 0xF3F63C Offset: 0xF3F63C VA: 0xF3F63C
		// public static void ExtractDateTime(long unixTime, out int years, out int months, out int days, out int hours, out int minutes) { }

		// // RVA: 0xF3F758 Offset: 0xF3F758 VA: 0xF3F758
		// public static string MakeDateTime(int years, int months, int days, int hours, int minutes) { }

		// // RVA: 0xF3EF78 Offset: 0xF3EF78 VA: 0xF3EF78
		// private void SetupRewardStat(IBJAKJJICBC musicData) { }

		// // RVA: 0xF441DC Offset: 0xF441DC VA: 0xF441DC
		// protected bool CheckEventLimit() { }

		// // RVA: 0xF444D4 Offset: 0xF444D4 VA: 0xF444D4
		// protected bool CheckCurrentEventLimit(KGCNCBOKCBA.GNENJEHKMHD term = 5) { }

		// // RVA: 0xF445EC Offset: 0xF445EC VA: 0xF445EC
		public static void CreateFilteredMusicDataList(List<MusicDataList> filteredMusicList, List<MusicDataList> originalMusicList, long currentTime, MusicSelectSceneBase.CheckMatchMusicFilterFunc checkFunc)
		{
			TodoLogger.Log(0, "CreateFilteredMusicDataList");
			filteredMusicList.Clear();
			for(int i = 0; i < originalMusicList.Count; i++)
			{
				filteredMusicList.Add(originalMusicList[i]);
			}
		}

		// // RVA: 0xF45870 Offset: 0xF45870 VA: 0xF45870
		protected void OnSelectedDifficulty(Difficulty.Type difficulty)
		{
			TodoLogger.Log(0, "OnSelectedDifficulty");
		}

		// // RVA: 0xF458AC Offset: 0xF458AC VA: 0xF458AC Slot: 54
		// protected virtual void OnChangedDifficulty() { }

		// // RVA: 0xF458B0 Offset: 0xF458B0 VA: 0xF458B0
		protected void OnClickRankingButton()
		{
			TodoLogger.Log(0, "OnClickRankingButton");
		}

		// // RVA: 0xF459E4 Offset: 0xF459E4 VA: 0xF459E4
		protected void OnClickRewardButton()
		{
			TodoLogger.Log(0, "OnClickRewardButton");
		}

		// // RVA: 0xF45E74 Offset: 0xF45E74 VA: 0xF45E74
		protected void OnClickDetailButton()
		{
			TodoLogger.Log(0, "OnClickDetailButton");
		}

		// // RVA: 0xF460FC Offset: 0xF460FC VA: 0xF460FC
		// protected void OnClickEnemyDetailButton() { }

		// // RVA: 0xF46368 Offset: 0xF46368 VA: 0xF46368
		protected void OnClickEventRankingButton()
		{
			TodoLogger.Log(0, "OnClickEventRankingButton");
		}

		// // RVA: 0xF46528 Offset: 0xF46528 VA: 0xF46528
		protected void OnClickEventRewardButton()
		{
			TodoLogger.Log(0, "OnClickEventRewardButton");
		}

		// // RVA: 0xF467D4 Offset: 0xF467D4 VA: 0xF467D4
		protected void OnClickEnemyInfoButton()
		{
			TodoLogger.Log(0, "OnClickEnemyInfoButton");
		}

		// // RVA: 0xF469EC Offset: 0xF469EC VA: 0xF469EC
		// protected void OnClickStoryButton() { }

		// // RVA: 0xF46B68 Offset: 0xF46B68 VA: 0xF46B68
		// protected void OnClickMissionButton() { }

		// // RVA: 0xF46CEC Offset: 0xF46CEC VA: 0xF46CEC
		protected void OnClickPlayButton()
		{
			TodoLogger.Log(0, "OnClickPlayButton");
		}

		// // RVA: 0xF3AF60 Offset: 0xF3AF60 VA: 0xF3AF60
		// protected void UpdateScrollLimit() { }

		// // RVA: 0xF3B040 Offset: 0xF3B040 VA: 0xF3B040
		// protected void UpdateScrollArrow() { }

		// // RVA: 0xF47554 Offset: 0xF47554 VA: 0xF47554
		protected void OnClickEventDetailButton()
		{
			TodoLogger.Log(0, "OnClickEventDetailButton");
		}

		// // RVA: 0xF478B8 Offset: 0xF478B8 VA: 0xF478B8
		protected void OnClickFlowButton(int offset)
		{
			TodoLogger.Log(0, "OnClickFlowButton");
		}

		// // RVA: 0xF47BD4 Offset: 0xF47BD4 VA: 0xF47BD4
		protected void OnSelectionChanged(int offset)
		{
			TodoLogger.Log(0, "OnSelectionChanged");
		}

		// // RVA: 0xF47C70 Offset: 0xF47C70 VA: 0xF47C70
		protected void OnScrollRepeated(int repeatDelta, int beginIndex, int endIndex)
		{
			TodoLogger.Log(0, "OnScrollRepeated");
		}

		// // RVA: 0xF47F40 Offset: 0xF47F40 VA: 0xF47F40
		protected void OnScrollStarted(bool isAuto)
		{
			TodoLogger.Log(0, "OnScrollStarted");
		}

		// // RVA: 0xF48020 Offset: 0xF48020 VA: 0xF48020
		protected void OnScrollUpdated(bool isAuto)
		{
			TodoLogger.Log(0, "OnScrollUpdated");
		}

		// // RVA: 0xF48024 Offset: 0xF48024 VA: 0xF48024
		protected void OnScrollEnded(bool isAuto)
		{
			TodoLogger.Log(0, "OnScrollEnded");
		}

		// // RVA: 0xF45B00 Offset: 0xF45B00 VA: 0xF45B00
		// private void OpenRewardWindow() { }

		// // RVA: 0xF45F90 Offset: 0xF45F90 VA: 0xF45F90
		// private void OpenMusicDetailWindow() { }

		// // RVA: 0xF46218 Offset: 0xF46218 VA: 0xF46218
		// private void OpenEnemyDetailWindow() { }

		// // RVA: 0xF48128 Offset: 0xF48128 VA: 0xF48128
		// private void OpenFirstClearRewardWindow() { }

		// // RVA: 0xF4812C Offset: 0xF4812C VA: 0xF4812C
		// private void OpenClearRewardWindow(int type, int no) { }

		// // RVA: 0xF48130 Offset: 0xF48130 VA: 0xF48130
		// private void ClearUnitDanceConfirm() { }

		// // RVA: 0xF431BC Offset: 0xF431BC VA: 0xF431BC
		// protected void OpenWeekRecoveryWindow(Action<int> recoveryCallback, Action cancelCallback) { }

		// // RVA: 0xF4351C Offset: 0xF4351C VA: 0xF4351C
		// private void OpenStaminaWindow(Action recoveryCallback, Action cancelCallback) { }

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
		// protected IEnumerator Co_CheckUnlock(Action<int> callback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F45A4 Offset: 0x6F45A4 VA: 0x6F45A4
		// // RVA: 0xF385F4 Offset: 0xF385F4 VA: 0xF385F4
		// protected IEnumerator Co_CheckUnlockAndAddMusic() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F461C Offset: 0x6F461C VA: 0x6F461C
		// // RVA: 0xF48688 Offset: 0xF48688 VA: 0xF48688 Slot: 57
		// protected virtual IEnumerator Co_WaitForAnimEnd(Action onEnd) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F4694 Offset: 0x6F4694 VA: 0x6F4694
		// // RVA: 0xF48750 Offset: 0xF48750 VA: 0xF48750
		// protected IEnumerator Co_ChangeBg(BgType bgType, int bgId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F470C Offset: 0x6F470C VA: 0x6F470C
		// // RVA: 0xF40834 Offset: 0xF40834 VA: 0xF40834
		// private IEnumerator Co_DownloadMusic(IBJAKJJICBC musicData) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F4784 Offset: 0x6F4784 VA: 0x6F4784
		// // RVA: 0xF48850 Offset: 0xF48850 VA: 0xF48850
		// protected IEnumerator Co_ShowHelp() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F47FC Offset: 0x6F47FC VA: 0x6F47FC
		// // RVA: 0xF488FC Offset: 0xF488FC VA: 0xF488FC
		// protected IEnumerator Co_LoadAssetBundle_LoginBonusPopup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F4874 Offset: 0x6F4874 VA: 0x6F4874
		// // RVA: 0xF489A8 Offset: 0xF489A8 VA: 0xF489A8
		// protected IEnumerator Co_Initialize_LoginBonusPopup(IKDICBBFBMI a_controller) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F48EC Offset: 0x6F48EC VA: 0x6F48EC
		// // RVA: 0xF48A70 Offset: 0xF48A70 VA: 0xF48A70
		// protected IEnumerator Co_ShowReciveLoginAchievement() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F4964 Offset: 0x6F4964 VA: 0x6F4964
		// // RVA: 0xF48B1C Offset: 0xF48B1C VA: 0xF48B1C
		// protected IEnumerator Co_Show_LoginBonusPopup(MusicSelectSceneBase.OnCallback_LoginBonusPopup a_callback) { }

		// // RVA: 0xF3843C Offset: 0xF3843C VA: 0xF3843C
		// protected bool CanDoUnitDanceFocus(bool line6Mode = False) { }

		// // RVA: 0xF48BE4 Offset: 0xF48BE4 VA: 0xF48BE4
		// private bool IsEnableUnitDance(bool line6Mode = False) { }

		// // RVA: 0xF48F34 Offset: 0xF48F34 VA: 0xF48F34
		protected bool SelectUnitDanceFocus(out int freeMusicId, out FreeCategoryId.Type category, ref bool line6Mode, bool isSimulation, OHCAABOMEOF.KGOGMKMBCPP_EventType eventCategory)
		{
			TodoLogger.Log(0, "SelectUnitDanceFocus");
			freeMusicId = 0;
			category = 0;
			line6Mode = false;
			isSimulation = true;
			return true;
		}

		// // RVA: 0xF49150 Offset: 0xF49150 VA: 0xF49150
		// protected bool CanShow6LineHelp() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F49DC Offset: 0x6F49DC VA: 0x6F49DC
		// // RVA: 0xF38568 Offset: 0xF38568 VA: 0xF38568
		// protected IEnumerator TryShowUnitDanceTutorial() { }

		// // RVA: 0xF49178 Offset: 0xF49178 VA: 0xF49178
		// protected bool CheckTutorialFunc_UnitDance(TutorialConditionId conditionId) { }

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

		// [CompilerGeneratedAttribute] // RVA: 0x6F4B44 Offset: 0x6F4B44 VA: 0x6F4B44
		// // RVA: 0xF496BC Offset: 0xF496BC VA: 0xF496BC
		// private void <ApplyMusicInfoSimulationLive>b__135_0(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4B54 Offset: 0x6F4B54 VA: 0x6F4B54
		// // RVA: 0xF49718 Offset: 0xF49718 VA: 0xF49718
		// private void <ApplyTicletDropIcon>b__140_0(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4B64 Offset: 0x6F4B64 VA: 0x6F4B64
		// // RVA: 0xF49774 Offset: 0xF49774 VA: 0xF49774
		// private void <CurrentMusicDecisionCheck>b__162_2(int recovery) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4B74 Offset: 0x6F4B74 VA: 0x6F4B74
		// // RVA: 0xF49870 Offset: 0xF49870 VA: 0xF49870
		// private void <CurrentMusicDecisionCheck>b__162_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4B84 Offset: 0x6F4B84 VA: 0x6F4B84
		// // RVA: 0xF49874 Offset: 0xF49874 VA: 0xF49874
		// private void <CurrentMusicDecisionCheck>b__162_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4B94 Offset: 0x6F4B94 VA: 0x6F4B94
		// // RVA: 0xF49878 Offset: 0xF49878 VA: 0xF49878
		// private void <OnClickPlayButton>b__201_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F4BA4 Offset: 0x6F4BA4 VA: 0x6F4BA4
		// // RVA: 0xF49908 Offset: 0xF49908 VA: 0xF49908
		// private void <OnClickPlayButton>b__201_1() { }

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
