using System.Collections;
using System.Collections.Generic;
using XeApp.Game.Common;
using XeApp.Game.MusicSelect;

namespace XeApp.Game.Menu
{
	public abstract class VerticalMusicSelectSceneBase : TransitionRoot
	{

		protected struct MusicDecideInfo
		{
			public long overrideCurrentTime; // 0x0
			public string missionText; // 0x8
			public int overrideEnemyCenterSkill; // 0xC
			public int overrideEnemyLiveSkill; // 0x10
			public GameSetupData.MusicInfo.InitFreeMusicParam initParam; // 0x14
			public static MusicDecideInfo Empty = new MusicDecideInfo(0, string.Empty, 0, 0); // 0x0

			// RVA: 0x7FAA44 Offset: 0x7FAA44 VA: 0x7FAA44
			public MusicDecideInfo(long overrideCurrentTime, string missionText, int overrideEnemyCenterSkill, int overrideEnemyLiveSkill)
			{
				this.overrideCurrentTime = overrideCurrentTime;
				this.missionText = missionText;
				this.overrideEnemyCenterSkill = overrideEnemyCenterSkill;
				this.overrideEnemyLiveSkill = overrideEnemyLiveSkill;
				initParam.isDisableBattleEventIntermediateResult = false;
			}
		}

		protected class MusicLockData
		{
			public string lockDetail = ""; // 0x8
			public int freeMusicId = 0; // 0xC
			public bool isLock = false; // 0x10
		}

		protected struct EventHelpInfo
		{
			public List<int> helpIds; // 0x0
			public bool isShowFirstHelp; // 0x4
		}

		public delegate bool CheckMatchMusicFilterFunc(VerticalMusicDataList.MusicListData musicData, int series, long currentTime);

		// protected IKDICBBFBMI m_scoreEventCtrl; // 0x50
		// private VerticalMusicSelectSceneBase.MusicDecideInfo m_musicDecideInfo = MusicDevideInfo.Empty; // 0x68
		 private PopupAchieveRewardSetting m_rewardPopupSetting = new PopupAchieveRewardSetting(); // 0x88
		// private PopupUnitDanceWarning m_popupUnitDanceWarning = new PopupUnitDanceWarning(); // 0x8C
		// private PopupMusicBookMarkSetting m_musicBookMarkSetting = new PopupMusicBookMarkSetting(); // 0x90
		// private bool m_isConfirmedUnitDance; // 0x94
		// private TeamSlectSceneArgs m_teamSelectSceneArgs = new TeamSlectSceneArgs(); // 0x98
		// private const float BGM_FADE_OUT_SEC = 0,3;
		// private List<Action> NoticeActionList = new List<Action>(); // 0xAC

		// protected bool m_isEndPresetCanvas { get; set; } // 0x45
		// protected bool m_isEndPostSetCanvas { get; set; } // 0x46
		// protected bool m_isEndActivateScene { get; set; } // 0x47
		// protected abstract Difficulty.Type diff { get; }  //Slot: 31
		// protected abstract MusicSelectConsts.SeriesType series { get; } //Slot: 32
		// protected abstract int list_no { get; set; } //Slot: 34 Slot: 33
		// protected bool openSimulationLive { get; set; } // 0x48
		// protected abstract bool isLine6Mode { get; } // Slot: 35
		// protected abstract int musicListCount { get; } // Slot: 36
		// protected abstract VerticalMusicDataList currentMusicList { get; } //  Slot: 38
		// protected abstract List<VerticalMusicDataList> originalMusicList { get; } //  Slot: 39
		// protected IKDICBBFBMI m_eventCtrl { get; set; } // 0x4C
		// protected int m_eventId { get; set; } // 0x54
		// protected MMOLNAHHDOM m_unitLiveLocalSaveData { get; private set; } // 0x58
		protected LimitTimeWatcher m_musicTimeWatcher { get; private set; } = new LimitTimeWatcher(); // 0x5C
		protected LimitTimeWatcher m_bannerTimeWatcher { get; private set; } = new LimitTimeWatcher(); // 0x60
		// protected abstract IBJAKJJICBC selectMusicData { get; } // Slot: 40
		// protected abstract VerticalMusicDataList.MusicListData selectMusicListData { get; } // Slot: 41
		// protected bool listIsEmpty { get; } 0xAC8AD4
		// protected bool listIsEmptyByFilter { get; } 0xAC8B48
		// protected bool isExistSelectMusicData { get; } 0xAC8B50
		// protected int musicId { get; } 0xAC8B58
		// protected int freeMusicId { get; } 0xAC8BAC
		// protected int gameEventType { get; } 0xAC8C00
		// protected int m_eventTicketId { get; set; } // 0x9C
		// protected KGCNCBOKCBA.GNENJEHKMHD m_eventStatus { get; set; } // 0xA0
		// protected bool m_isEventTimeLimit { get; set; } // 0xA4
		// private bool m_muteSelectionSe { get; set; } // 0xA5
		// private bool m_requestFadeOutBgm { get; set; } // 0xA6
		// private int m_changeToTrialBgmId { get; set; } // 0xA8
		// private float bgmFadeOutSec { get; } 0xAC8CAC
		// public bool IsEventCounting { get; } 0xACFD7C
		// public bool IsEventEndChallengePeriod { get; } 0xACFD90
		// public bool IsEventRankingEnd { get; } 0xACFDA4

		// // RVA: -1 Offset: -1 Slot: 37
		// protected abstract VerticalMusicDataList GetMusicList(int index);

		// // RVA: 0xAC8CB8 Offset: 0xAC8CB8 VA: 0xAC8CB8 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			StartCoroutine(Co_Awake());
		}

		// // RVA: 0xAC8D74 Offset: 0xAC8D74 VA: 0xAC8D74
		protected void Update()
		{
			m_bannerTimeWatcher.Update();
			m_musicTimeWatcher.Update();
			OnUpdate();
		}

		// RVA: 0xAC8DD8 Offset: 0xAC8DD8 VA: 0xAC8DD8 Slot: 16
		protected override void OnPreSetCanvas()
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		// RVA: 0xAC8EA4 Offset: 0xAC8EA4 VA: 0xAC8EA4 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			UnityEngine.Debug.LogError("TODO !!!");
			return true;
		}

		// RVA: 0xAC8F58 Offset: 0xAC8F58 VA: 0xAC8F58 Slot: 18
		protected override void OnPostSetCanvas()
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		// RVA: 0xAC8F8C Offset: 0xAC8F8C VA: 0xAC8F8C Slot: 19
		protected override bool IsEndPostSetCanvas()
		{
			UnityEngine.Debug.LogError("TODO !!!");
			return true;
		}

		// RVA: 0xAC8F94 Offset: 0xAC8F94 VA: 0xAC8F94 Slot: 23
		protected override void OnActivateScene()
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		// RVA: 0xAC8FC8 Offset: 0xAC8FC8 VA: 0xAC8FC8 Slot: 24
		protected override bool IsEndActivateScene()
		{
			UnityEngine.Debug.LogError("TODO !!!");
			return true;
		}

		// RVA: 0xAC8FD0 Offset: 0xAC8FD0 VA: 0xAC8FD0 Slot: 20
		protected override bool OnBgmStart()
		{
			UnityEngine.Debug.LogError("TODO !!!");
			return true;
		}

		// RVA: 0xAC8FF0 Offset: 0xAC8FF0 VA: 0xAC8FF0 Slot: 14
		protected override void OnDestoryScene()
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		// RVA: 0xAC9038 Offset: 0xAC9038 VA: 0xAC9038 Slot: 15
		protected override void OnDeleteCache()
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		// RVA: 0xAC9070 Offset: 0xAC9070 VA: 0xAC9070 Slot: 30
		//protected override void InputDisable()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// RVA: 0xAC909C Offset: 0xAC909C VA: 0xAC909C Slot: 29
		//protected override void InputEnable()
		//{
		//	UnityEngine.Debug.LogError("TODO !!!");
		//}

		// [IteratorStateMachineAttribute] // RVA: 0x6F6914 Offset: 0x6F6914 VA: 0x6F6914
		// // RVA: 0xAC8CE8 Offset: 0xAC8CE8 VA: 0xAC8CE8
		private IEnumerator Co_Awake()
		{
			//0xAD45C0
			yield return Co_LoadResourceOnAwake();
			m_rewardPopupSetting.SetParent(transform);
			yield return Co_WaitForLoaded();
			IsReady = true;
		}

		// // RVA: -1 Offset: -1 Slot: 42
		// protected abstract IEnumerator Co_OnPreSetCanvas();

		// // RVA: -1 Offset: -1 Slot: 43
		// protected abstract IEnumerator Co_OnPostSetCanvas();

		// // RVA: -1 Offset: -1 Slot: 44
		// protected abstract IEnumerator Co_ActivateScene();

		// // RVA: -1 Offset: -1 Slot: 45
		protected abstract IEnumerator Co_LoadResourceOnAwake();

		// // RVA: -1 Offset: -1 Slot: 46
		protected abstract IEnumerator Co_WaitForLoaded();

		// // RVA: -1 Offset: -1 Slot: 47
		protected abstract void OnUpdate();

		// // RVA: -1 Offset: -1 Slot: 48
		// protected abstract void ReleaseScene();

		// // RVA: -1 Offset: -1 Slot: 49
		// protected abstract void ReleaseCache();

		// // RVA: -1 Offset: -1 Slot: 50
		// protected abstract void OnInputDisable();

		// // RVA: -1 Offset: -1 Slot: 51
		// protected abstract void OnInputEnable();

		// // RVA: -1 Offset: -1 Slot: 52
		// protected abstract void ApplyCommonInfo();

		// // RVA: -1 Offset: -1 Slot: 53
		// protected abstract void ApplyMusicInfo();

		// // RVA: -1 Offset: -1 Slot: 54
		// protected abstract void DelayedApplyMusicInfo();

		// [IteratorStateMachineAttribute] // RVA: 0x6F698C Offset: 0x6F698C VA: 0x6F698C
		// // RVA: 0xAC83B4 Offset: 0xAC83B4 VA: 0xAC83B4
		// protected IEnumerator Co_ChangeBg(BgType bgType, int bgId, Action endCallBack, bool isFade) { }

		// // RVA: -1 Offset: -1 Slot: 55
		// protected abstract int GetDanceDivaCount();

		// // RVA: 0xAC8E10 Offset: 0xAC8E10 VA: 0xAC8E10
		// private void LoadUnitLiveSaveData() { }

		// // RVA: 0xAC9108 Offset: 0xAC9108 VA: 0xAC9108
		// private void ApplyUnitLiveButtonSetting(bool isUnit) { }

		// // RVA: -1 Offset: -1 Slot: 56
		// protected abstract void OnApplyUnitLiveButtonSetting(bool isUnit);

		// // RVA: 0xAC9194 Offset: 0xAC9194 VA: 0xAC9194
		// private void UnitDanceOnlyBackButton() { }

		// // RVA: 0xAC91E0 Offset: 0xAC91E0 VA: 0xAC91E0
		// private void CheckUnitLive(Action endCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6A04 Offset: 0x6F6A04 VA: 0x6F6A04
		// // RVA: 0xAC9298 Offset: 0xAC9298 VA: 0xAC9298
		// private IEnumerator Co_CheckUnitLive(Action endCallback) { }

		// // RVA: -1 Offset: -1 Slot: 57
		// protected abstract void OnClickDifficultyButton(int index);

		// // RVA: 0xAC9360 Offset: 0xAC9360 VA: 0xAC9360
		// protected void DownloadCurrentMusic() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6A7C Offset: 0x6F6A7C VA: 0x6F6A7C
		// // RVA: 0xAC93C4 Offset: 0xAC93C4 VA: 0xAC93C4
		// private IEnumerator Co_DownloadMusic(IBJAKJJICBC musicData) { }

		// // RVA: 0xAC948C Offset: 0xAC948C VA: 0xAC948C
		// private void CheckSimulationLive(Action<bool> endCallBack) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6AF4 Offset: 0x6F6AF4 VA: 0x6F6AF4
		// // RVA: 0xAC953C Offset: 0xAC953C VA: 0xAC953C
		// private IEnumerator Co_CheckSimulationLive(Action<bool> endCallBack) { }

		// // RVA: 0xAC95E8 Offset: 0xAC95E8 VA: 0xAC95E8 Slot: 58
		// protected virtual bool CurrentMusicDecisionCheck(bool isSimulation, Action cancelCallback, MKIKFJKPEHK viewBoostData, int selectIndex = 0) { }

		// // RVA: 0xAC9FF8 Offset: 0xAC9FF8 VA: 0xAC9FF8
		// private void CheckBoostData(bool isSimulation, Action<bool> endCallback, Action cancelCallback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6B6C Offset: 0x6F6B6C VA: 0x6F6B6C
		// // RVA: 0xACA0C8 Offset: 0xACA0C8 VA: 0xACA0C8
		// private IEnumerator Co_CheckBoostData(bool isSimulation, Action<bool> endCallback, Action cancelCallback) { }

		// // RVA: 0xACA1C0 Offset: 0xACA1C0 VA: 0xACA1C0
		// private void OnCancelDecideMusic() { }

		// // RVA: -1 Offset: -1 Slot: 59
		// protected abstract void OnDecideCurrentMusic(ref VerticalMusicSelectSceneBase.MusicDecideInfo info);

		// // RVA: 0xACA1CC Offset: 0xACA1CC VA: 0xACA1CC
		// private void DecideCurrentMusic(bool isSimulation) { }

		// // RVA: 0xACAA10 Offset: 0xACAA10 VA: 0xACAA10
		// protected void OnClickPlayButton(bool isSimulation) { }

		// // RVA: 0xACB214 Offset: 0xACB214 VA: 0xACB214
		// protected bool CheckEventLimit() { }

		// // RVA: 0xACE0E0 Offset: 0xACE0E0 VA: 0xACE0E0
		// protected void ApplyRemainTime(VerticalMusicSelectMusicDetail musicDetail, long endTime, VerticalMusicSelectMusicDetail.MusicRemainTimeType remainType, LimitTimeWatcher.OnEndCallback endCallback) { }

		// // RVA: 0xACE260 Offset: 0xACE260 VA: 0xACE260
		// protected void ApplyEventRemainTime(VerticalMusicSelectMusicDetail musicDetail, long remainSec, VerticalMusicSelectMusicDetail.MusicRemainTimeType remainType) { }

		// // RVA: 0xACE2F0 Offset: 0xACE2F0 VA: 0xACE2F0
		// protected void ApplyEventBannerRemainTime(VerticalMusicSelectEventBanner eventBunner, long remainSec) { }

		// // RVA: 0xAC72BC Offset: 0xAC72BC VA: 0xAC72BC
		// public static void CrateFilterDataList(VerticalMusicDataList filterMusicList, List<VerticalMusicDataList> originalMusicList, int series, long currentTime, VerticalMusicSelectSceneBase.CheckMatchMusicFilterFunc checkFunc) { }

		// // RVA: 0xACEC6C Offset: 0xACEC6C VA: 0xACEC6C
		// private void OnWebViewClose() { }

		// // RVA: 0xACED08 Offset: 0xACED08 VA: 0xACED08
		// private void OnNetErrorToTitle() { }

		// // RVA: 0xACEDA4 Offset: 0xACEDA4 VA: 0xACEDA4
		// private VerticalMusicSelectSceneBase.MusicLockData GetLastStoryData() { }

		// // RVA: 0xACF194 Offset: 0xACF194 VA: 0xACF194
		// private bool CheckStoryMusic(int freeMusicId) { }

		// // RVA: 0xACF30C Offset: 0xACF30C VA: 0xACF30C
		// protected int GetLastStoryFreeMusicId() { }

		// // RVA: 0xACF5E8 Offset: 0xACF5E8 VA: 0xACF5E8
		// protected void CheckSnsNotice() { }

		// // RVA: 0xACF730 Offset: 0xACF730 VA: 0xACF730
		// protected void CheckOfferNotice() { }

		// // RVA: 0xAC3AA8 Offset: 0xAC3AA8 VA: 0xAC3AA8
		// protected void AddNotice(Action action) { }

		// // RVA: 0xAC3B28 Offset: 0xAC3B28 VA: 0xAC3B28
		// protected void ShowNotice() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6BE4 Offset: 0x6F6BE4 VA: 0x6F6BE4
		// // RVA: 0xACF818 Offset: 0xACF818 VA: 0xACF818
		// private IEnumerator Co_ShowNotice() { }

		// // RVA: 0xACF8C4 Offset: 0xACF8C4 VA: 0xACF8C4
		// private void OnEndFadeOutBGM() { }

		// // RVA: 0xACF944 Offset: 0xACF944 VA: 0xACF944
		// protected void FadeOutBGM() { }

		// // RVA: 0xACFA5C Offset: 0xACFA5C VA: 0xACFA5C
		// protected void ChangeTrialMusic(int wavId) { }

		// // RVA: 0xACFC14 Offset: 0xACFC14 VA: 0xACFC14
		// protected void ApplyMusic() { }

		// // RVA: 0xACFD6C Offset: 0xACFD6C VA: 0xACFD6C
		// protected void OnScrollEnded() { }

		// // RVA: 0xACFDB8 Offset: 0xACFDB8 VA: 0xACFDB8
		// protected void OnClickEventDetailButton() { }

		// // RVA: 0xAD012C Offset: 0xAD012C VA: 0xAD012C
		// protected void OnClickRankingButton(IBJAKJJICBC musicData) { }

		// // RVA: 0xAD03FC Offset: 0xAD03FC VA: 0xAD03FC
		// protected void OnClickRewardButton(Action openRewardWindowFunc) { }

		// // RVA: 0xAD0524 Offset: 0xAD0524 VA: 0xAD0524
		// protected void OnClickEventRewardButton() { }

		// // RVA: 0xAD07C8 Offset: 0xAD07C8 VA: 0xAD07C8
		// protected void OnClickDetailButton(VerticalMusicDataList.MusicListData musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xAD0AC0 Offset: 0xAD0AC0 VA: 0xAD0AC0
		// protected void OnClickEnemyDetailButton(IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xAD0290 Offset: 0xAD0290 VA: 0xAD0290
		// private void OnClickEventRankingButton(IBJAKJJICBC musicData) { }

		// // RVA: 0xAD0D34 Offset: 0xAD0D34 VA: 0xAD0D34
		// protected void OnClickEventRankingButton(IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP eventType, KGCNCBOKCBA.GNENJEHKMHD eventStatus, int eventId, IKDICBBFBMI eventCtrl, int selectDiva = 0) { }

		// // RVA: 0xAD0E84 Offset: 0xAD0E84 VA: 0xAD0E84
		// protected void OnClickEventRewardButton(MonoBehaviour owner, IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP eventType, KGCNCBOKCBA.GNENJEHKMHD eventStatus, int eventId, IKDICBBFBMI eventCtrl) { }

		// // RVA: 0xAD1110 Offset: 0xAD1110 VA: 0xAD1110
		// protected void OnClickStoryButton(IBJAKJJICBC musicData, OHCAABOMEOF.KGOGMKMBCPP eventType, KGCNCBOKCBA.GNENJEHKMHD eventStatus, int eventId, IKDICBBFBMI eventCtrl) { }

		// // RVA: 0xAD128C Offset: 0xAD128C VA: 0xAD128C
		// protected void OnClickMissionButton() { }

		// // RVA: 0xAD1410 Offset: 0xAD1410 VA: 0xAD1410
		// protected void OnClickMusicRate() { }

		// // RVA: 0xAD158C Offset: 0xAD158C VA: 0xAD158C
		// protected void OnClickMusicBookMark(Action okCallBack) { }

		// // RVA: 0xAD1ABC Offset: 0xAD1ABC VA: 0xAD1ABC
		// protected void OnClickEventDetailButton(IKDICBBFBMI scoreEventCtrl) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6C5C Offset: 0x6F6C5C VA: 0x6F6C5C
		// // RVA: 0xAC3990 Offset: 0xAC3990 VA: 0xAC3990
		// protected IEnumerator Co_CheckUnlockAndAddMusic() { }

		// // RVA: 0xACD40C Offset: 0xACD40C VA: 0xACD40C
		// protected void OpenLockSimulationLiveWindow() { }

		// // RVA: 0xACD850 Offset: 0xACD850 VA: 0xACD850
		// protected void OpenLockMusicInfoWindow() { }

		// // RVA: 0xAD1F18 Offset: 0xAD1F18 VA: 0xAD1F18
		// protected void OpenRewardWindow() { }

		// // RVA: 0xAD08F4 Offset: 0xAD08F4 VA: 0xAD08F4
		// protected void OpenMusicDetailWindow(VerticalMusicDataList.MusicListData musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xAD0BEC Offset: 0xAD0BEC VA: 0xAD0BEC
		// protected void OpenEnemyDetailWindow(IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xAC9928 Offset: 0xAC9928 VA: 0xAC9928
		// protected void OpenWeekRecoveryWindow(Action<int> recoveryCallback, Action cancelCallback) { }

		// // RVA: 0xAC9C88 Offset: 0xAC9C88 VA: 0xAC9C88
		// protected void OpenStaminaWindow(Action recoveryCallback, Action cancelCallback) { }

		// // RVA: 0xAD16B4 Offset: 0xAD16B4 VA: 0xAD16B4
		// protected void OpenMusicBookMarkWindow(Action okCallBack, bool initialze) { }

		// // RVA: 0xACD354 Offset: 0xACD354 VA: 0xACD354
		// private void GotoRegularMusicSelect() { }

		// // RVA: 0xACD2B0 Offset: 0xACD2B0 VA: 0xACD2B0
		// private void GotoEventMiniGame(int miniGameId) { }

		// // RVA: 0xACBE10 Offset: 0xACBE10 VA: 0xACBE10
		// protected void GotoEventMusicSelect(int eventId) { }

		// // RVA: 0xACB9AC Offset: 0xACB9AC VA: 0xACB9AC
		// protected void GotoEventQuest(int eventId) { }

		// // RVA: 0xACC274 Offset: 0xACC274 VA: 0xACC274
		// protected void GotoEventBattle(int eventId) { }

		// // RVA: 0xACC6D8 Offset: 0xACC6D8 VA: 0xACC6D8
		// protected void GotoEventRaid(int eventId) { }

		// // RVA: 0xACCE4C Offset: 0xACCE4C VA: 0xACCE4C
		// protected void GotoEventGoDiva(int eventId) { }

		// // RVA: 0xAD1E40 Offset: 0xAD1E40 VA: 0xAD1E40
		// private void GotoStorySelect() { }

		// // RVA: 0xAD22C0 Offset: 0xAD22C0 VA: 0xAD22C0
		// private bool IsEnableUnitDance(bool line6Mode = False) { }

		// // RVA: 0xAC37D8 Offset: 0xAC37D8 VA: 0xAC37D8
		// protected bool CanDoUnitDanceFocus(bool line6Mode = False) { }

		// // RVA: 0xAC7CC0 Offset: 0xAC7CC0 VA: 0xAC7CC0
		// protected bool SelectUnitDanceFocus(out int freeMusicId, out FreeCategoryId.Type category, ref bool line6Mode, bool isSimulation, OHCAABOMEOF.KGOGMKMBCPP eventCategory) { }

		// // RVA: 0xAD2568 Offset: 0xAD2568 VA: 0xAD2568
		// protected void SetupHelp(ref VerticalMusicSelectSceneBase.EventHelpInfo helpInfo, IKDICBBFBMI eventCtrl) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6CD4 Offset: 0x6F6CD4 VA: 0x6F6CD4
		// // RVA: 0xAD28EC Offset: 0xAD28EC VA: 0xAD28EC
		// protected IEnumerator Co_ShowHelp(MonoBehaviour owner, VerticalMusicSelectSceneBase.EventHelpInfo helpInfo) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6D4C Offset: 0x6F6D4C VA: 0x6F6D4C
		// // RVA: 0xAC3904 Offset: 0xAC3904 VA: 0xAC3904
		// protected IEnumerator TryShowUnitDanceTutorial() { }

		// // RVA: 0xAD29DC Offset: 0xAD29DC VA: 0xAD29DC
		// protected bool CheckTutorialFunc_UnitDance(TutorialConditionId conditionId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6DC4 Offset: 0x6F6DC4 VA: 0x6F6DC4
		// // RVA: 0xAD2AA0 Offset: 0xAD2AA0 VA: 0xAD2AA0
		// protected IEnumerator TryShow6LineModeTutorial() { }

		// // RVA: 0xAD2B4C Offset: 0xAD2B4C VA: 0xAD2B4C
		// protected bool CheckTutorialFunc_6Line(TutorialConditionId conditionId) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6E3C Offset: 0x6F6E3C VA: 0x6F6E3C
		// // RVA: 0xAC3A1C Offset: 0xAC3A1C VA: 0xAC3A1C
		// protected IEnumerator TryShowUtaRateTutorial() { }

		// // RVA: 0xAD2C28 Offset: 0xAD2C28 VA: 0xAD2C28
		// protected bool CheckTutorialFunc_UtaRate(TutorialConditionId conditionId) { }
	}
}
