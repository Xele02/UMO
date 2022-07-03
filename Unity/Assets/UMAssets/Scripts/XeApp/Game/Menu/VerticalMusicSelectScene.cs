namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectScene : VerticalMusicSelectSceneBase
	{
		// // Fields
		// private static readonly FreeCategoryId.Type[] MUSIC_LIST_TYPE; // 0x0
		// private VerticalMusicSelectUISapporter m_musicSelectUISapporter; // 0xB0
		// private List<VerticalMusicDataList> m_originalMusicDataList; // 0xB4
		// private List<VerticalMusicDataList> m_originalEventMusicDataList; // 0xB8
		// private VerticalMusicDataList m_filterMusicDataList; // 0xBC
		// private VerticalMusicDataList m_filterMusicEventDataList; // 0xC0
		// private bool m_isListScroll; // 0xC4
		// private bool m_isChangeBg; // 0xC5
		// private bool m_isEndMyRankRequest; // 0xC6
		// private bool m_showScoreRankingPopup; // 0xC7
		// public static readonly MusicSelectConsts.SeriesType[] CategoryToSeriesType; // 0x4
		// [CompilerGeneratedAttribute] // RVA: 0x6758B0 Offset: 0x6758B0 VA: 0x6758B0
		// private int <list_no>k__BackingField; // 0xC8
		// private bool m_isBgCached; // 0xCC
		// private bool m_isScoreRankingPopup; // 0xCD
		// private bool m_isScoreEventTimeLimit; // 0xCE
		// private bool m_isListEmptyByFilter; // 0xCF
		// private int m_eventIndex; // 0xD0
		// private int m_pickupFreeMusicId; // 0xD4
		// private FreeCategoryId.Type m_pickupFreeCategoryId; // 0xD8
		// private OHCAABOMEOF.KGOGMKMBCPP m_currentEventType; // 0xDC
		// private VerticalMusicSelecChoiceMusicListTab.MusicTab m_musicTab; // 0xE0
		// private VerticalMusicSelectMusicList m_musicList; // 0xE4
		// private VerticalMusicSelectMusicDetail m_musicDetail; // 0xE8
		// private VerticalMusicSelectUtaRate m_utaRate; // 0xEC
		// private VerticalMusicSelectEventBanner m_eventBanner; // 0xF0
		// private VerticalMusicSelectEventItem m_eventItem; // 0xF4
		// private VerticalMusicSelectDifficultyButtonGroup m_difficultyButtonGroup; // 0xF8
		// private VerticalMusicSelectSeriesButtonGroup m_seriesButtonGroup; // 0xFC
		// private VerticalMusicSelecLine6Button m_line6Button; // 0x100
		// private VerticalMusicSelctSimulationButton m_simulationButton; // 0x104
		// private VerticalMusicSelectPlayButton m_playButton; // 0x108
		// private VerticalMusicSelecChoiceMusicListTab m_choiceMusicTab; // 0x10C
		// private MusicJecketScrollView m_jacketScroll; // 0x110
		// private VerticalMusicSelectMusicFilterButton m_filterButton; // 0x114
		// private VerticalMusicSelectSortOrder m_orderButton; // 0x118
		// private LayoutEventGoDivaFeverLimit m_feverLimit; // 0x11C
		// private static readonly int newSeriesBgIdDiff; // 0x8
		// private static readonly int eventCategoryId; // 0xC
		// private static readonly int[] CategoryToNewSeriesBgId; // 0x10
		// private static readonly int[] SeriesToNewSeriesBgId; // 0x14
		// private static readonly int noMusicCategoryId; // 0x18

		// // Properties
		// private VerticalMusicSelectSortOrder.SortOrder sortOrder { get; }
		// protected override IBJAKJJICBC selectMusicData { get; }
		// protected override VerticalMusicDataList.MusicListData selectMusicListData { get; }
		// protected override Difficulty.Type diff { get; }
		// protected override MusicSelectConsts.SeriesType series { get; }
		// protected override int list_no { get; set; }
		// protected override int musicListCount { get; }
		// protected override VerticalMusicDataList currentMusicList { get; }
		// protected override List<VerticalMusicDataList> originalMusicList { get; }
		// protected override bool isLine6Mode { get; }
		// private bool m_isLine6Mode { get; set; }
		// private List<VerticalMusicDataList> currentOriginalMusicDataList { get; }

		// // Methods

		// // RVA: 0xBE5B30 Offset: 0xBE5B30 VA: 0xBE5B30
		// private VerticalMusicSelectSortOrder.SortOrder get_sortOrder() { }

		// // RVA: 0xBE5B5C Offset: 0xBE5B5C VA: 0xBE5B5C Slot: 40
		// protected override IBJAKJJICBC get_selectMusicData() { }

		// // RVA: 0xBE5C04 Offset: 0xBE5C04 VA: 0xBE5C04 Slot: 41
		// protected override VerticalMusicDataList.MusicListData get_selectMusicListData() { }

		// // RVA: 0xBE5C90 Offset: 0xBE5C90 VA: 0xBE5C90 Slot: 31
		// protected override Difficulty.Type get_diff() { }

		// // RVA: 0xBE5CBC Offset: 0xBE5CBC VA: 0xBE5CBC Slot: 32
		// protected override MusicSelectConsts.SeriesType get_series() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5E8C Offset: 0x6F5E8C VA: 0x6F5E8C
		// // RVA: 0xBE5CE8 Offset: 0xBE5CE8 VA: 0xBE5CE8 Slot: 33
		// protected override void set_list_no(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F5E9C Offset: 0x6F5E9C VA: 0x6F5E9C
		// // RVA: 0xBE5CF0 Offset: 0xBE5CF0 VA: 0xBE5CF0 Slot: 34
		// protected override int get_list_no() { }

		// // RVA: 0xBE5CF8 Offset: 0xBE5CF8 VA: 0xBE5CF8 Slot: 36
		// protected override int get_musicListCount() { }

		// // RVA: 0xBE5D00 Offset: 0xBE5D00 VA: 0xBE5D00 Slot: 37
		// protected override VerticalMusicDataList GetMusicList(int i) { }

		// // RVA: 0xBE5D14 Offset: 0xBE5D14 VA: 0xBE5D14 Slot: 38
		// protected override VerticalMusicDataList get_currentMusicList() { }

		// // RVA: 0xBE5D2C Offset: 0xBE5D2C VA: 0xBE5D2C Slot: 39
		// protected override List<VerticalMusicDataList> get_originalMusicList() { }

		// // RVA: 0xBE5D34 Offset: 0xBE5D34 VA: 0xBE5D34 Slot: 35
		// protected override bool get_isLine6Mode() { }

		// // RVA: 0xBE5D7C Offset: 0xBE5D7C VA: 0xBE5D7C
		// private void set_m_isLine6Mode(bool value) { }

		// // RVA: 0xBE5D58 Offset: 0xBE5D58 VA: 0xBE5D58
		// private bool get_m_isLine6Mode() { }

		// // RVA: 0xBE5DA4 Offset: 0xBE5DA4 VA: 0xBE5DA4
		// private List<VerticalMusicDataList> get_currentOriginalMusicDataList() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F5EAC Offset: 0x6F5EAC VA: 0x6F5EAC
		// // RVA: 0xBE5DBC Offset: 0xBE5DBC VA: 0xBE5DBC Slot: 42
		// protected override IEnumerator Co_OnPreSetCanvas() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F5F24 Offset: 0x6F5F24 VA: 0x6F5F24
		// // RVA: 0xBE5E44 Offset: 0xBE5E44 VA: 0xBE5E44
		// private IEnumerator Co_SetupBg(BgType bgType, int bgId, bool isFade, Action endCallBack) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F5F9C Offset: 0x6F5F9C VA: 0x6F5F9C
		// // RVA: 0xBE5F30 Offset: 0xBE5F30 VA: 0xBE5F30 Slot: 43
		// protected override IEnumerator Co_OnPostSetCanvas() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6014 Offset: 0x6F6014 VA: 0x6F6014
		// // RVA: 0xBE5FB8 Offset: 0xBE5FB8 VA: 0xBE5FB8 Slot: 44
		// protected override IEnumerator Co_ActivateScene() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F608C Offset: 0x6F608C VA: 0x6F608C
		// // RVA: 0xBE6040 Offset: 0xBE6040 VA: 0xBE6040
		// private IEnumerator Co_ShowScoreRankingPopup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6104 Offset: 0x6F6104 VA: 0x6F6104
		// // RVA: 0xBE60C8 Offset: 0xBE60C8 VA: 0xBE60C8 Slot: 45
		// protected override IEnumerator Co_LoadResourceOnAwake() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F617C Offset: 0x6F617C VA: 0x6F617C
		// // RVA: 0xBE6150 Offset: 0xBE6150 VA: 0xBE6150 Slot: 46
		// protected override IEnumerator Co_WaitForLoaded() { }

		// // RVA: 0xBE61C0 Offset: 0xBE61C0 VA: 0xBE61C0 Slot: 9
		// protected override void OnStartEnterAnimation() { }

		// // RVA: 0xBE63FC Offset: 0xBE63FC VA: 0xBE63FC Slot: 10
		// protected override bool IsEndEnterAnimation() { }

		// // RVA: 0xBE65C8 Offset: 0xBE65C8 VA: 0xBE65C8 Slot: 12
		// protected override void OnStartExitAnimation() { }

		// // RVA: 0xBE683C Offset: 0xBE683C VA: 0xBE683C Slot: 13
		// protected override bool IsEndExitAnimation() { }

		// // RVA: 0xBE6A30 Offset: 0xBE6A30 VA: 0xBE6A30 Slot: 20
		// protected override bool OnBgmStart() { }

		// // RVA: 0xBE6AFC Offset: 0xBE6AFC VA: 0xBE6AFC Slot: 47
		// protected override void OnUpdate() { }

		// // RVA: 0xBE6B00 Offset: 0xBE6B00 VA: 0xBE6B00 Slot: 48
		// protected override void ReleaseScene() { }

		// // RVA: 0xBE6BA0 Offset: 0xBE6BA0 VA: 0xBE6BA0 Slot: 49
		// protected override void ReleaseCache() { }

		// // RVA: 0xBE6C68 Offset: 0xBE6C68 VA: 0xBE6C68 Slot: 50
		// protected override void OnInputDisable() { }

		// // RVA: 0xBE6CAC Offset: 0xBE6CAC VA: 0xBE6CAC Slot: 51
		// protected override void OnInputEnable() { }

		// // RVA: 0xBE6CF0 Offset: 0xBE6CF0 VA: 0xBE6CF0 Slot: 55
		// protected override int GetDanceDivaCount() { }

		// // RVA: 0xBE6D18 Offset: 0xBE6D18 VA: 0xBE6D18
		// protected void TryInstall(StringBuilder bundleName, VerticalMusicDataList musicList) { }

		// // RVA: 0xBE7054 Offset: 0xBE7054 VA: 0xBE7054
		// private void SetPlayButton(VerticalMusicSelectPlayButton.PlayButtonType type) { }

		// // RVA: 0xBE7164 Offset: 0xBE7164 VA: 0xBE7164
		// public void SetPlayButton(VerticalMusicDataList.MusicListData musicListData) { }

		// // RVA: 0xBE7438 Offset: 0xBE7438 VA: 0xBE7438
		// public void SetSimulationButton(VerticalMusicDataList.MusicListData musicListData) { }

		// // RVA: 0xBE7728 Offset: 0xBE7728 VA: 0xBE7728
		// public void SetMusicDetailRemainTime(long remainTime, VerticalMusicSelectMusicDetail.MusicRemainTimeType remainTimeType, LimitTimeWatcher.OnEndCallback endCallback) { }

		// // RVA: 0xBE7758 Offset: 0xBE7758 VA: 0xBE7758
		// public void SetTicketDropIcon(int ticketId) { }

		// // RVA: 0xBE7818 Offset: 0xBE7818 VA: 0xBE7818
		// private void SetCreateMusicList() { }

		// // RVA: 0xBE87B4 Offset: 0xBE87B4 VA: 0xBE87B4
		// public void SelectAprilFoolFocus() { }

		// // RVA: 0xBE8AE8 Offset: 0xBE8AE8 VA: 0xBE8AE8
		// private int GetMinigameListNo(int minigameId) { }

		// // RVA: 0xBE8C6C Offset: 0xBE8C6C VA: 0xBE8C6C
		// private void SelectArgsFocus(MusicSelectArgs args) { }

		// // RVA: 0xBE97AC Offset: 0xBE97AC VA: 0xBE97AC
		// private bool CheckShowEventBanner(OHCAABOMEOF.KGOGMKMBCPP eventType) { }

		// // RVA: 0xBE97F0 Offset: 0xBE97F0 VA: 0xBE97F0
		// private void ApplyEventInfo() { }

		// // RVA: 0xBEA28C Offset: 0xBEA28C VA: 0xBEA28C
		// private void OnClickEventBanner() { }

		// // RVA: 0xBEA808 Offset: 0xBEA808 VA: 0xBEA808 Slot: 52
		// protected override void ApplyCommonInfo() { }

		// // RVA: 0xBEAA40 Offset: 0xBEAA40 VA: 0xBEAA40 Slot: 53
		// protected override void ApplyMusicInfo() { }

		// // RVA: 0xBEBC94 Offset: 0xBEBC94 VA: 0xBEBC94
		// private int GetChangeBgId(VerticalMusicDataList.MusicListData musicListData) { }

		// // RVA: 0xBEBF44 Offset: 0xBEBF44 VA: 0xBEBF44 Slot: 54
		// protected override void DelayedApplyMusicInfo() { }

		// // RVA: 0xBEC300 Offset: 0xBEC300 VA: 0xBEC300 Slot: 59
		// protected override void OnDecideCurrentMusic(ref VerticalMusicSelectSceneBase.MusicDecideInfo info) { }

		// // RVA: 0xBEAACC Offset: 0xBEAACC VA: 0xBEAACC
		// private void ApplyMusicInfoNone() { }

		// // RVA: 0xBEAC3C Offset: 0xBEAC3C VA: 0xBEAC3C
		// private void ApplyMusicInfoEventEntrance() { }

		// // RVA: 0xBEB120 Offset: 0xBEB120 VA: 0xBEB120
		// private void ApplyMusicInfoNormal() { }

		// // RVA: 0xBEC304 Offset: 0xBEC304 VA: 0xBEC304
		// private void SetListNo(int no) { }

		// // RVA: 0xBEC314 Offset: 0xBEC314 VA: 0xBEC314 Slot: 57
		// protected override void OnClickDifficultyButton(int index) { }

		// // RVA: 0xBEC918 Offset: 0xBEC918 VA: 0xBEC918
		// private void OnClickSeriesButton(int index) { }

		// // RVA: 0xBEC9A4 Offset: 0xBEC9A4 VA: 0xBEC9A4
		// protected void OnClickUnitButton(int index) { }

		// // RVA: 0xBECA44 Offset: 0xBECA44 VA: 0xBECA44
		// private void ListChangeItemCallBack(int index) { }

		// // RVA: 0xBECA7C Offset: 0xBECA7C VA: 0xBECA7C
		// private void ListClipItemCallBack() { }

		// // RVA: 0xBECA8C Offset: 0xBECA8C VA: 0xBECA8C
		// private void OnScrollStartEvent() { }

		// // RVA: 0xBECB3C Offset: 0xBECB3C VA: 0xBECB3C
		// private void OnScrollEndEvent() { }

		// // RVA: 0xBECBEC Offset: 0xBECBEC VA: 0xBECBEC
		// private void OnClickLine6Button() { }

		// // RVA: 0xBECFD4 Offset: 0xBECFD4 VA: 0xBECFD4 Slot: 56
		// protected override void OnApplyUnitLiveButtonSetting(bool isUnit) { }

		// // RVA: 0xBEAA10 Offset: 0xBEAA10 VA: 0xBEAA10
		// private void SetMusicTab(VerticalMusicSelecChoiceMusicListTab.MusicTab type) { }

		// // RVA: 0xBE97A4 Offset: 0xBE97A4 VA: 0xBE97A4
		// private void SetMusicTab(bool isEvent) { }

		// // RVA: 0xBED05C Offset: 0xBED05C VA: 0xBED05C
		// private void OnClickMusicTabButton(bool isNormal) { }

		// // RVA: 0xBED3D0 Offset: 0xBED3D0 VA: 0xBED3D0
		// private void OnClickJacketButton() { }

		// // RVA: 0xBED824 Offset: 0xBED824 VA: 0xBED824
		// private void OnClickClozeJacketButton() { }

		// // RVA: 0xBED9AC Offset: 0xBED9AC VA: 0xBED9AC
		// private void OnClickJacketImageButton(int freeMusicId) { }

		// // RVA: 0xBEDC78 Offset: 0xBEDC78 VA: 0xBEDC78
		// private void OnClickSmallBigButton(VerticalMusicSelectSortOrder.SortOrder sortOrder) { }

		// // RVA: 0xBEDD10 Offset: 0xBEDD10 VA: 0xBEDD10
		// private void SetSmallBigOrderButtonEnable() { }

		// // RVA: 0xBEDD4C Offset: 0xBEDD4C VA: 0xBEDD4C
		// private void SetSeriesButtonEnable() { }

		// // RVA: 0xBEDD88 Offset: 0xBEDD88 VA: 0xBEDD88
		// private void MusicDataListSort() { }

		// // RVA: 0xBEE154 Offset: 0xBEE154 VA: 0xBEE154
		// private int MusicDataListSortCb(VerticalMusicDataList.MusicListData left, VerticalMusicDataList.MusicListData right) { }

		// // RVA: 0xBEE6D8 Offset: 0xBEE6D8 VA: 0xBEE6D8
		// private int EventMusicDataListSortCb(VerticalMusicDataList.MusicListData left, VerticalMusicDataList.MusicListData right) { }

		// // RVA: 0xBEE8C0 Offset: 0xBEE8C0 VA: 0xBEE8C0
		// private bool IsFilter() { }

		// // RVA: 0xBEEA68 Offset: 0xBEEA68 VA: 0xBEEA68
		// private void SetMusicFilterButton() { }

		// // RVA: 0xBEEAA8 Offset: 0xBEEAA8 VA: 0xBEEAA8
		// private void SetMusicFilterButtonEnable() { }

		// // RVA: 0xBEEAE0 Offset: 0xBEEAE0 VA: 0xBEEAE0
		// private void SetMusicFilterSortText() { }

		// // RVA: 0xBEEBC4 Offset: 0xBEEBC4 VA: 0xBEEBC4
		// private void CheckListEmptyByFilter() { }

		// // RVA: 0xBED2FC Offset: 0xBED2FC VA: 0xBED2FC
		// private void SetFreeMusicIdByListNo(int freeMusicId, OHCAABOMEOF.KGOGMKMBCPP gameEventType) { }

		// // RVA: 0xBEC3C0 Offset: 0xBEC3C0 VA: 0xBEC3C0
		// private void OnChangeFilter() { }

		// // RVA: 0xBEEC50 Offset: 0xBEEC50 VA: 0xBEEC50
		// private void OnClickFilterButton() { }

		// // RVA: 0xBEEE70 Offset: 0xBEEE70 VA: 0xBEEE70
		// private bool CheckMatchFilterFunc(VerticalMusicDataList.MusicListData musicListData, int series, long currentTime) { }

		// // RVA: 0xBEF1E8 Offset: 0xBEF1E8 VA: 0xBEF1E8
		// private bool CheckMusicFilter_Series(int series, IBJAKJJICBC musicData) { }

		// // RVA: 0xBEF238 Offset: 0xBEF238 VA: 0xBEF238
		// private bool CheckMusicFilter_MusicAttr(int filterBit, IBJAKJJICBC musicData) { }

		// // RVA: 0xBEF2F4 Offset: 0xBEF2F4 VA: 0xBEF2F4
		// private bool CheckMusicFilter_Combo(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty) { }

		// // RVA: 0xBEF460 Offset: 0xBEF460 VA: 0xBEF460
		// private bool CheckMusicFilter_Reward(int filterBit, IBJAKJJICBC musicData, Difficulty.Type difficulty, bool isLine6Mode) { }

		// // RVA: 0xBEF690 Offset: 0xBEF690 VA: 0xBEF690
		// private bool CheckMusicFilter_Unit(int filterBit, IBJAKJJICBC musicData) { }

		// // RVA: 0xBEF7A8 Offset: 0xBEF7A8 VA: 0xBEF7A8
		// private bool CheckMusicFilter_MusicBookMark(int index, IBJAKJJICBC musicData) { }

		// // RVA: 0xBEF7F4 Offset: 0xBEF7F4 VA: 0xBEF7F4
		// private bool CheckMusicFilter_MusicUnlock(int filterBit, bool isOpen) { }

		// // RVA: 0xBEF814 Offset: 0xBEF814 VA: 0xBEF814
		// private bool CheckMusicFilter_MusicRange(int filterBit, MusicSelectConsts.MusicTimeType timeType) { }

		// // RVA: 0xBEF84C Offset: 0xBEF84C VA: 0xBEF84C
		// private bool IsCanDoUnitHelp() { }

		// // RVA: 0xBEFB04 Offset: 0xBEFB04 VA: 0xBEFB04
		// public void .ctor() { }

		// // RVA: 0xBEFC08 Offset: 0xBEFC08 VA: 0xBEFC08
		// private static void .cctor() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F61F4 Offset: 0x6F61F4 VA: 0x6F61F4
		// // RVA: 0xBF00B8 Offset: 0xBF00B8 VA: 0xBF00B8
		// private void <Co_OnPreSetCanvas>b__63_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6204 Offset: 0x6F6204 VA: 0x6F6204
		// // RVA: 0xBF00C4 Offset: 0xBF00C4 VA: 0xBF00C4
		// private void <Co_OnPostSetCanvas>b__70_0(int index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6214 Offset: 0x6F6214 VA: 0x6F6214
		// // RVA: 0xBF00FC Offset: 0xBF00FC VA: 0xBF00FC
		// private void <Co_OnPostSetCanvas>b__70_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6224 Offset: 0x6F6224 VA: 0x6F6224
		// // RVA: 0xBF010C Offset: 0xBF010C VA: 0xBF010C
		// private void <Co_OnPostSetCanvas>b__70_2() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6234 Offset: 0x6F6234 VA: 0x6F6234
		// // RVA: 0xBF01A0 Offset: 0xBF01A0 VA: 0xBF01A0
		// private void <Co_OnPostSetCanvas>b__70_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6244 Offset: 0x6F6244 VA: 0x6F6244
		// // RVA: 0xBF01F0 Offset: 0xBF01F0 VA: 0xBF01F0
		// private void <Co_OnPostSetCanvas>b__70_4() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6254 Offset: 0x6F6254 VA: 0x6F6254
		// // RVA: 0xBF0240 Offset: 0xBF0240 VA: 0xBF0240
		// private void <Co_OnPostSetCanvas>b__70_5() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6264 Offset: 0x6F6264 VA: 0x6F6264
		// // RVA: 0xBF02C4 Offset: 0xBF02C4 VA: 0xBF02C4
		// private void <Co_OnPostSetCanvas>b__70_6() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6274 Offset: 0x6F6274 VA: 0x6F6274
		// // RVA: 0xBF02C8 Offset: 0xBF02C8 VA: 0xBF02C8
		// private void <Co_OnPostSetCanvas>b__70_7() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6284 Offset: 0x6F6284 VA: 0x6F6284
		// // RVA: 0xBF02CC Offset: 0xBF02CC VA: 0xBF02CC
		// private void <Co_OnPostSetCanvas>b__70_8(int index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6294 Offset: 0x6F6294 VA: 0x6F6294
		// // RVA: 0xBF02D0 Offset: 0xBF02D0 VA: 0xBF02D0
		// private void <Co_OnPostSetCanvas>b__70_9() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62A4 Offset: 0x6F62A4 VA: 0x6F62A4
		// // RVA: 0xBF036C Offset: 0xBF036C VA: 0xBF036C
		// private void <Co_OnPostSetCanvas>b__70_10() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62B4 Offset: 0x6F62B4 VA: 0x6F62B4
		// // RVA: 0xBF0370 Offset: 0xBF0370 VA: 0xBF0370
		// private void <Co_OnPostSetCanvas>b__70_11() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62C4 Offset: 0x6F62C4 VA: 0x6F62C4
		// // RVA: 0xBF0378 Offset: 0xBF0378 VA: 0xBF0378
		// private void <Co_OnPostSetCanvas>b__70_12() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62D4 Offset: 0x6F62D4 VA: 0x6F62D4
		// // RVA: 0xBF0380 Offset: 0xBF0380 VA: 0xBF0380
		// private void <Co_OnPostSetCanvas>b__70_13(int index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62E4 Offset: 0x6F62E4 VA: 0x6F62E4
		// // RVA: 0xBF0390 Offset: 0xBF0390 VA: 0xBF0390
		// private void <Co_OnPostSetCanvas>b__70_14() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F62F4 Offset: 0x6F62F4 VA: 0x6F62F4
		// // RVA: 0xBF0394 Offset: 0xBF0394 VA: 0xBF0394
		// private void <Co_OnPostSetCanvas>b__70_15(int index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6304 Offset: 0x6F6304 VA: 0x6F6304
		// // RVA: 0xBF0404 Offset: 0xBF0404 VA: 0xBF0404
		// private void <Co_OnPostSetCanvas>b__70_16() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6314 Offset: 0x6F6314 VA: 0x6F6314
		// // RVA: 0xBF046C Offset: 0xBF046C VA: 0xBF046C
		// private void <Co_OnPostSetCanvas>b__70_17(bool isSimulation) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6324 Offset: 0x6F6324 VA: 0x6F6324
		// // RVA: 0xBF04E0 Offset: 0xBF04E0 VA: 0xBF04E0
		// private void <Co_OnPostSetCanvas>b__70_18(bool isSimulation) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6334 Offset: 0x6F6334 VA: 0x6F6334
		// // RVA: 0xBF0554 Offset: 0xBF0554 VA: 0xBF0554
		// private void <Co_OnPostSetCanvas>b__70_19() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6344 Offset: 0x6F6344 VA: 0x6F6344
		// // RVA: 0xBF05C0 Offset: 0xBF05C0 VA: 0xBF05C0
		// private void <Co_OnPostSetCanvas>b__70_20() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6354 Offset: 0x6F6354 VA: 0x6F6354
		// // RVA: 0xBF0628 Offset: 0xBF0628 VA: 0xBF0628
		// private void <Co_OnPostSetCanvas>b__70_21(bool index) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6364 Offset: 0x6F6364 VA: 0x6F6364
		// // RVA: 0xBF0698 Offset: 0xBF0698 VA: 0xBF0698
		// private void <Co_OnPostSetCanvas>b__70_22() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6374 Offset: 0x6F6374 VA: 0x6F6374
		// // RVA: 0xBF06B8 Offset: 0xBF06B8 VA: 0xBF06B8
		// private void <Co_OnPostSetCanvas>b__70_23(int freeMusicId) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6384 Offset: 0x6F6384 VA: 0x6F6384
		// // RVA: 0xBF06BC Offset: 0xBF06BC VA: 0xBF06BC
		// private void <Co_OnPostSetCanvas>b__70_24() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6394 Offset: 0x6F6394 VA: 0x6F6394
		// // RVA: 0xBF06C0 Offset: 0xBF06C0 VA: 0xBF06C0
		// private void <Co_OnPostSetCanvas>b__70_25(int index, SwapScrollListContent content) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F63A4 Offset: 0x6F63A4 VA: 0x6F63A4
		// // RVA: 0xBF0888 Offset: 0xBF0888 VA: 0xBF0888
		// private void <Co_OnPostSetCanvas>b__70_26() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F63B4 Offset: 0x6F63B4 VA: 0x6F63B4
		// // RVA: 0xBF0894 Offset: 0xBF0894 VA: 0xBF0894
		// private void <Co_OnPostSetCanvas>b__70_27() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F63C4 Offset: 0x6F63C4 VA: 0x6F63C4
		// // RVA: 0xBF08A4 Offset: 0xBF08A4 VA: 0xBF08A4
		// private void <Co_ActivateScene>b__71_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F63D4 Offset: 0x6F63D4 VA: 0x6F63D4
		// // RVA: 0xBF08AC Offset: 0xBF08AC VA: 0xBF08AC
		// private void <Co_ActivateScene>b__71_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F63E4 Offset: 0x6F63E4 VA: 0x6F63E4
		// // RVA: 0xBF08B4 Offset: 0xBF08B4 VA: 0xBF08B4
		// private void <Co_LoadResourceOnAwake>b__73_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F63F4 Offset: 0x6F63F4 VA: 0x6F63F4
		// // RVA: 0xBF0984 Offset: 0xBF0984 VA: 0xBF0984
		// private void <Co_LoadResourceOnAwake>b__73_1(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6404 Offset: 0x6F6404 VA: 0x6F6404
		// // RVA: 0xBF0A54 Offset: 0xBF0A54 VA: 0xBF0A54
		// private void <Co_LoadResourceOnAwake>b__73_2(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6414 Offset: 0x6F6414 VA: 0x6F6414
		// // RVA: 0xBF0B24 Offset: 0xBF0B24 VA: 0xBF0B24
		// private void <Co_LoadResourceOnAwake>b__73_3(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6424 Offset: 0x6F6424 VA: 0x6F6424
		// // RVA: 0xBF0BF4 Offset: 0xBF0BF4 VA: 0xBF0BF4
		// private void <Co_LoadResourceOnAwake>b__73_4(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6434 Offset: 0x6F6434 VA: 0x6F6434
		// // RVA: 0xBF0CC4 Offset: 0xBF0CC4 VA: 0xBF0CC4
		// private void <Co_LoadResourceOnAwake>b__73_5(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6444 Offset: 0x6F6444 VA: 0x6F6444
		// // RVA: 0xBF0D94 Offset: 0xBF0D94 VA: 0xBF0D94
		// private void <Co_LoadResourceOnAwake>b__73_6(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6454 Offset: 0x6F6454 VA: 0x6F6454
		// // RVA: 0xBF0E64 Offset: 0xBF0E64 VA: 0xBF0E64
		// private void <Co_LoadResourceOnAwake>b__73_7(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6464 Offset: 0x6F6464 VA: 0x6F6464
		// // RVA: 0xBF0F34 Offset: 0xBF0F34 VA: 0xBF0F34
		// private void <Co_LoadResourceOnAwake>b__73_8(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6474 Offset: 0x6F6474 VA: 0x6F6474
		// // RVA: 0xBF1004 Offset: 0xBF1004 VA: 0xBF1004
		// private void <Co_LoadResourceOnAwake>b__73_9(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6484 Offset: 0x6F6484 VA: 0x6F6484
		// // RVA: 0xBF1114 Offset: 0xBF1114 VA: 0xBF1114
		// private void <Co_LoadResourceOnAwake>b__73_10(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6494 Offset: 0x6F6494 VA: 0x6F6494
		// // RVA: 0xBF11E4 Offset: 0xBF11E4 VA: 0xBF11E4
		// private void <Co_LoadResourceOnAwake>b__73_11(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F64A4 Offset: 0x6F64A4 VA: 0x6F64A4
		// // RVA: 0xBF12B4 Offset: 0xBF12B4 VA: 0xBF12B4
		// private void <Co_LoadResourceOnAwake>b__73_12(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F64B4 Offset: 0x6F64B4 VA: 0x6F64B4
		// // RVA: 0xBF1384 Offset: 0xBF1384 VA: 0xBF1384
		// private void <Co_LoadResourceOnAwake>b__73_13(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F64C4 Offset: 0x6F64C4 VA: 0x6F64C4
		// // RVA: 0xBF1454 Offset: 0xBF1454 VA: 0xBF1454
		// private void <ApplyEventInfo>b__97_0(long current, long limit, long remain) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F64D4 Offset: 0x6F64D4 VA: 0x6F64D4
		// // RVA: 0xBF1480 Offset: 0xBF1480 VA: 0xBF1480
		// private void <OnClickClozeJacketButton>b__121_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F64E4 Offset: 0x6F64E4 VA: 0x6F64E4
		// // RVA: 0xBF152C Offset: 0xBF152C VA: 0xBF152C
		// private void <OnClickJacketImageButton>b__122_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F64F4 Offset: 0x6F64F4 VA: 0x6F64F4
		// // RVA: 0xBF15D8 Offset: 0xBF15D8 VA: 0xBF15D8
		// private void <OnClickFilterButton>b__136_0(PopupFilterSortUGUI content) { }
	}
}
