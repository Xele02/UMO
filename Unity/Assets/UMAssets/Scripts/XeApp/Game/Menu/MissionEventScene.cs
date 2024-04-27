using System.Collections;

namespace XeApp.Game.Menu
{
	public class MissionEventScene : MusicSelectSceneBase
	{
		// private const int EVENT_POINT_MAX = 99999999;
		// private MusicSelectSeriesInfo m_seriesInfo; // 0xF8
		// private MusicSelectEventInfo m_eventInfo; // 0xFC
		// private EventTimeLimitMessage m_timeLimitMessage; // 0x100
		// private LayoutQuestEvent2MissionSelect m_LayoutMissonSelect; // 0x104
		// private LayoutQuestEvent2EventBtn m_LayoutEventSettingBtn; // 0x108
		// private MusicSelectLineButton m_lineButton; // 0x10C
		// private MusicSelectBonusButton m_bonusButton; // 0x110
		// private MusicSelectMusicFilterButton m_filterButton; // 0x114
		// private LayoutQuestPopupMissionSettingSetting m_popMissionSetting; // 0x118
		// private PopupMissionMusicChangeAlertSetting m_popMusicChangeAlertSetting; // 0x11C
		// private IAFDICLEOPF m_missionSetData; // 0x120
		// private StringBuilder m_strBuilder; // 0x124
		// private MissionEventScene.Step m_showingStep; // 0x128
		// private MissionEventScene.Step m_currentStep; // 0x12C
		// private int m_selectedCardIndex; // 0x130
		// private bool m_isEventChecked; // 0x134
		// private MissionEventScene.Step m_cambackRankingStep; // 0x138
		// private List<MusicDataList> m_originalMusicDataList; // 0x13C
		// private List<MusicDataList> m_filteredMusicDataList; // 0x140

		// public int categoryId { get; set; } // 0x144
		// protected override int musicListCount { get; } 0xB42898
		// protected override MusicDataList currentMusicList { get; } 0xB42990

		// // RVA: 0xB42910 Offset: 0xB42910 VA: 0xB42910 Slot: 32
		// protected override MusicDataList GetMusicList(int i) { }

		// // RVA: 0xB42A10 Offset: 0xB42A10 VA: 0xB42A10 Slot: 35
		protected override void CheckTryInstall()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene CheckTryInstall");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2144 Offset: 0x6F2144 VA: 0x6F2144
		// // RVA: 0xB42A14 Offset: 0xB42A14 VA: 0xB42A14 Slot: 36
		protected override IEnumerator Co_Initialize()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene Co_Initialize");
			yield break;
		}

		// RVA: 0xB42A9C Offset: 0xB42A9C VA: 0xB42A9C Slot: 39
		protected override void Release()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene Release");
		}

		// RVA: 0xB42DD8 Offset: 0xB42DD8 VA: 0xB42DD8 Slot: 40
		protected override void SetupViewMusicData()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene SetupViewMusicData");
		}

		// RVA: 0xB42F28 Offset: 0xB42F28 VA: 0xB42F28 Slot: 38
		protected override PlayButtonWrapper CreatePlayButtonWrapper()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene CreatePlayButtonWrapper");
			return null;
		}

		// RVA: 0xB42FB4 Offset: 0xB42FB4 VA: 0xB42FB4 Slot: 51
		// protected override void OnDecideCurrentMusic() { }

		// RVA: 0xB4339C Offset: 0xB4339C VA: 0xB4339C Slot: 46
		// protected override void ApplyMusicInfoBasic(IBJAKJJICBC musicData) { }

		// RVA: 0xB434C0 Offset: 0xB434C0 VA: 0xB434C0 Slot: 41
		protected override void ApplyBasicInfo() 
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MusicSelectScene* ApplyBasicInfo");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F21BC Offset: 0x6F21BC VA: 0x6F21BC
		// // RVA: 0xB435A8 Offset: 0xB435A8 VA: 0xB435A8 Slot: 57
		// protected override IEnumerator Co_WaitForAnimEnd(Action onEnd) { }

		// // RVA: 0xB4364C Offset: 0xB4364C VA: 0xB4364C Slot: 42
		protected override void ApplyMusicListInfo()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MusicSelectScene* ApplyMusicListInfo");
		}

		// RVA: 0xB43798 Offset: 0xB43798 VA: 0xB43798 Slot: 52
		// protected override void LeaveForScrollStart() { }

		// RVA: 0xB437D0 Offset: 0xB437D0 VA: 0xB437D0 Slot: 53
		// protected override void EnterForScrollEnd() { }

		// RVA: 0xB43808 Offset: 0xB43808 VA: 0xB43808 Slot: 44
		protected override void DelayedApplyMusicInfo()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene DelayedApplyMusicInfo");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F2234 Offset: 0x6F2234 VA: 0x6F2234
		// // RVA: 0xB43A10 Offset: 0xB43A10 VA: 0xB43A10 Slot: 55
		protected override IEnumerator Co_LoadLayout()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene Co_LoadLayout");
			yield break;
		}

		// RVA: 0xB43A98 Offset: 0xB43A98 VA: 0xB43A98 Slot: 49
		// protected override int GetDanceDivaCount() { }

		// RVA: 0xB43AF4 Offset: 0xB43AF4 VA: 0xB43AF4 Slot: 48
		// protected override void ApplyUnitLiveButtonSetting(bool isUnit) { }

		// // RVA: 0xB43B98 Offset: 0xB43B98 VA: 0xB43B98
		// private bool IsFilter() { }

		// // RVA: 0xB43ED8 Offset: 0xB43ED8 VA: 0xB43ED8
		// private void CheckListEpmtyByFilter() { }

		// // RVA: 0xB43F5C Offset: 0xB43F5C VA: 0xB43F5C
		// private bool CheckMatchMusicFilter(IBJAKJJICBC musicData, long currentTime) { }

		// // RVA: 0xB44300 Offset: 0xB44300 VA: 0xB44300
		// private bool CheckMusicFilter_MusicLevel(int levelMin, int levelMax, IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xB443A8 Offset: 0xB443A8 VA: 0xB443A8
		// private bool CheckMusicFilter_MusicAttr(int filterBit, IBJAKJJICBC musicData) { }

		// // RVA: 0xB44464 Offset: 0xB44464 VA: 0xB44464
		// private bool CheckMusicFilter_Combo(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xB445D0 Offset: 0xB445D0 VA: 0xB445D0
		// private bool CheckMusicFilter_Reward(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty, bool isLine6Mode) { }

		// // RVA: 0xB4484C Offset: 0xB4484C VA: 0xB4484C
		// private bool CheckMusicFilter_Unit(int filterBit, IBJAKJJICBC musicData) { }

		// // RVA: 0xB44964 Offset: 0xB44964 VA: 0xB44964
		// private bool CheckMusicFilter_Bonus(int filterBit, IBJAKJJICBC musicData) { }

		// // RVA: 0xB449F4 Offset: 0xB449F4 VA: 0xB449F4
		// private void OnClickMusicFilterButton() { }

		// // RVA: 0xB44BD4 Offset: 0xB44BD4 VA: 0xB44BD4
		// private void OnChangeMusicFilter(bool isClear) { }

		// // RVA: 0xB44F88 Offset: 0xB44F88 VA: 0xB44F88
		// private void ApplyFilterButtonStatus() { }

		// // RVA: 0xB44FCC Offset: 0xB44FCC VA: 0xB44FCC
		// private void OnChangedSeries(FreeCategoryId.Type seriesId) { }

		// // RVA: 0xB44F24 Offset: 0xB44F24 VA: 0xB44F24
		// private void OnChangedSeries(FreeCategoryId.Type seriesId, int initListNo) { }

		// // RVA: 0xB451F0 Offset: 0xB451F0 VA: 0xB451F0
		// private void OnClickRankingButton() { }

		// // RVA: 0xB45200 Offset: 0xB45200 VA: 0xB45200
		// private void OnClickOkButton() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F22AC Offset: 0x6F22AC VA: 0x6F22AC
		// // RVA: 0xB45274 Offset: 0xB45274 VA: 0xB45274
		// private IEnumerator Co_OnClickOkButton() { }

		// // RVA: 0xB452FC Offset: 0xB452FC VA: 0xB452FC
		// private void OnClickEventBonusButton() { }

		// // RVA: 0xB4580C Offset: 0xB4580C VA: 0xB4580C
		// private void ApplyEventInfo() { }

		// // RVA: 0xB45FA0 Offset: 0xB45FA0 VA: 0xB45FA0
		// private static string EP_ToString(long point) { }

		// // RVA: 0xB46000 Offset: 0xB46000 VA: 0xB46000
		// private void OnClickEventSettingButton() { }

		// // RVA: 0xB46358 Offset: 0xB46358 VA: 0xB46358
		// private void SelectedMission(int index) { }

		// // RVA: 0xB46A38 Offset: 0xB46A38 VA: 0xB46A38
		// private void ReturnMissionSelect() { }

		// // RVA: 0xB46B74 Offset: 0xB46B74 VA: 0xB46B74
		// private void GotoBoxGacha() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F2324 Offset: 0x6F2324 VA: 0x6F2324
		// // RVA: 0xB469B0 Offset: 0xB469B0 VA: 0xB469B0
		// private IEnumerator Co_WaitButtonAnime(Action end) { }

		// // RVA: 0xB46CF8 Offset: 0xB46CF8 VA: 0xB46CF8
		// private void OnChangeMusic() { }

		// // RVA: 0xB46EA4 Offset: 0xB46EA4 VA: 0xB46EA4
		// private void OnSelectedDifficulty(Difficulty.Type difficulty) { }

		// // RVA: 0xB43264 Offset: 0xB43264 VA: 0xB43264
		// private void SaveDifficulty() { }

		// // RVA: 0xB4701C Offset: 0xB4701C VA: 0xB4701C Slot: 16
		protected override void OnPreSetCanvas()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene OnPreSetCanvas");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F239C Offset: 0x6F239C VA: 0x6F239C
		// // RVA: 0xB47104 Offset: 0xB47104 VA: 0xB47104
		// private IEnumerator Co_OnPresetCanvas() { }

		// // RVA: 0xB4718C Offset: 0xB4718C VA: 0xB4718C Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene IsEndPreSetCanvas");
			return true;
		}

		// RVA: 0xB471CC Offset: 0xB471CC VA: 0xB471CC Slot: 9
		protected override void OnStartEnterAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene OnStartEnterAnimation");
		}

		// RVA: 0xB47214 Offset: 0xB47214 VA: 0xB47214 Slot: 12
		protected override void OnStartExitAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene OnStartExitAnimation");
		}

		// RVA: 0xB4754C Offset: 0xB4754C VA: 0xB4754C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene IsEndExitAnimation");
			return true;
		}

		// RVA: 0xB47A70 Offset: 0xB47A70 VA: 0xB47A70 Slot: 15
		protected override void OnDeleteCache()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene OnDeleteCache");
		}

		// RVA: 0xB47B34 Offset: 0xB47B34 VA: 0xB47B34 Slot: 20
		protected override bool OnBgmStart()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene OnBgmStart");
			return true;
		}

		// // RVA: 0xB47560 Offset: 0xB47560 VA: 0xB47560
		// private bool IsPlayingLayout() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F2414 Offset: 0x6F2414 VA: 0x6F2414
		// // RVA: 0xB47C1C Offset: 0xB47C1C VA: 0xB47C1C Slot: 37
		protected override IEnumerator Co_OnActivateScene()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "MissionEventScene Co_OnActivateScene");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F248C Offset: 0x6F248C VA: 0x6F248C
		// // RVA: 0xB46E00 Offset: 0xB46E00 VA: 0xB46E00
		// private IEnumerator Co_ChangeMode(MissionEventScene.Step nextStep) { }

		// // RVA: 0xB466D4 Offset: 0xB466D4 VA: 0xB466D4
		// private int FindCategoryId(int freeMusicId, bool line6Mode) { }

		// // RVA: 0xB4511C Offset: 0xB4511C VA: 0xB4511C
		// private int FindMusicListIndex(int categoryId, int freeMusicId) { }

		// // RVA: 0xB4688C Offset: 0xB4688C VA: 0xB4688C
		// private void SetDefaultCategoryAndIndex() { }

		// // RVA: 0xB47CA4 Offset: 0xB47CA4 VA: 0xB47CA4
		// private void OverrideEnemySkill() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F2504 Offset: 0x6F2504 VA: 0x6F2504
		// // RVA: 0xB47DF0 Offset: 0xB47DF0 VA: 0xB47DF0
		// private IEnumerator Co_ShowChangeMusicAlert() { }

		// // RVA: 0xB47E78 Offset: 0xB47E78 VA: 0xB47E78
		// protected void OnChangeLineMode(int style) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F257C Offset: 0x6F257C VA: 0x6F257C
		// // RVA: 0xB4809C Offset: 0xB4809C VA: 0xB4809C
		// private IEnumerator Co_ChangeLiveMode(Action callback) { }

		// // RVA: 0xB48140 Offset: 0xB48140 VA: 0xB48140
		// public void .ctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F25F4 Offset: 0x6F25F4 VA: 0x6F25F4
		// // RVA: 0xB48280 Offset: 0xB48280 VA: 0xB48280
		// private string <OnDecideCurrentMusic>b__35_0(string tag) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2604 Offset: 0x6F2604 VA: 0x6F2604
		// // RVA: 0xB48388 Offset: 0xB48388 VA: 0xB48388
		// private void <ApplyMusicListInfo>b__39_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2614 Offset: 0x6F2614 VA: 0x6F2614
		// // RVA: 0xB48440 Offset: 0xB48440 VA: 0xB48440
		// private void <Co_LoadLayout>b__43_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2624 Offset: 0x6F2624 VA: 0x6F2624
		// // RVA: 0xB48510 Offset: 0xB48510 VA: 0xB48510
		// private void <Co_LoadLayout>b__43_1(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2634 Offset: 0x6F2634 VA: 0x6F2634
		// // RVA: 0xB485E0 Offset: 0xB485E0 VA: 0xB485E0
		// private void <Co_LoadLayout>b__43_2(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2644 Offset: 0x6F2644 VA: 0x6F2644
		// // RVA: 0xB486B0 Offset: 0xB486B0 VA: 0xB486B0
		// private void <Co_LoadLayout>b__43_3(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2654 Offset: 0x6F2654 VA: 0x6F2654
		// // RVA: 0xB48780 Offset: 0xB48780 VA: 0xB48780
		// private void <Co_LoadLayout>b__43_4(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2664 Offset: 0x6F2664 VA: 0x6F2664
		// // RVA: 0xB48850 Offset: 0xB48850 VA: 0xB48850
		// private void <Co_LoadLayout>b__43_5(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2674 Offset: 0x6F2674 VA: 0x6F2674
		// // RVA: 0xB48920 Offset: 0xB48920 VA: 0xB48920
		// private void <Co_LoadLayout>b__43_6(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2684 Offset: 0x6F2684 VA: 0x6F2684
		// // RVA: 0xB489F0 Offset: 0xB489F0 VA: 0xB489F0
		// private void <Co_LoadLayout>b__43_7(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2694 Offset: 0x6F2694 VA: 0x6F2694
		// // RVA: 0xB48AC0 Offset: 0xB48AC0 VA: 0xB48AC0
		// private void <Co_LoadLayout>b__43_8(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F26A4 Offset: 0x6F26A4 VA: 0x6F26A4
		// // RVA: 0xB48B90 Offset: 0xB48B90 VA: 0xB48B90
		// private void <Co_LoadLayout>b__43_9(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F26B4 Offset: 0x6F26B4 VA: 0x6F26B4
		// // RVA: 0xB48C60 Offset: 0xB48C60 VA: 0xB48C60
		// private void <Co_LoadLayout>b__43_10(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F26C4 Offset: 0x6F26C4 VA: 0x6F26C4
		// // RVA: 0xB48D30 Offset: 0xB48D30 VA: 0xB48D30
		// private void <Co_LoadLayout>b__43_11(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F26D4 Offset: 0x6F26D4 VA: 0x6F26D4
		// // RVA: 0xB48E00 Offset: 0xB48E00 VA: 0xB48E00
		// private void <Co_LoadLayout>b__43_12(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F26E4 Offset: 0x6F26E4 VA: 0x6F26E4
		// // RVA: 0xB48ED0 Offset: 0xB48ED0 VA: 0xB48ED0
		// private void <Co_LoadLayout>b__43_13(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F26F4 Offset: 0x6F26F4 VA: 0x6F26F4
		// // RVA: 0xB48FA0 Offset: 0xB48FA0 VA: 0xB48FA0
		// private void <ApplyEventInfo>b__64_0(long current, long limit, long remain) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2704 Offset: 0x6F2704 VA: 0x6F2704
		// // RVA: 0xB48FCC Offset: 0xB48FCC VA: 0xB48FCC
		// private void <ApplyEventInfo>b__64_1(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2714 Offset: 0x6F2714 VA: 0x6F2714
		// // RVA: 0xB49070 Offset: 0xB49070 VA: 0xB49070
		// private void <ApplyEventInfo>b__64_2(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2724 Offset: 0x6F2724 VA: 0x6F2724
		// // RVA: 0xB490A4 Offset: 0xB490A4 VA: 0xB490A4
		// private void <SelectedMission>b__67_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2734 Offset: 0x6F2734 VA: 0x6F2734
		// // RVA: 0xB490CC Offset: 0xB490CC VA: 0xB490CC
		// private void <ReturnMissionSelect>b__68_0() { }

		// [DebuggerHiddenAttribute] // RVA: 0x6F2744 Offset: 0x6F2744 VA: 0x6F2744
		// [CompilerGeneratedAttribute] // RVA: 0x6F2744 Offset: 0x6F2744 VA: 0x6F2744
		// // RVA: 0xB491E0 Offset: 0xB491E0 VA: 0xB491E0
		// private void <>n__0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F2774 Offset: 0x6F2774 VA: 0x6F2774
		// // RVA: 0xB491E8 Offset: 0xB491E8 VA: 0xB491E8
		// private void <OnChangeLineMode>b__90_0() { }
	}
}
