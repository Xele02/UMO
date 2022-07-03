namespace XeApp.Game.Menu
{
	public class VerticalMusicSelectSceneBase : TransitionRoot
	{
		// // Fields
		// [CompilerGeneratedAttribute] // RVA: 0x6758C0 Offset: 0x6758C0 VA: 0x6758C0
		// private bool <m_isEndPresetCanvas>k__BackingField; // 0x45
		// [CompilerGeneratedAttribute] // RVA: 0x6758D0 Offset: 0x6758D0 VA: 0x6758D0
		// private bool <m_isEndPostSetCanvas>k__BackingField; // 0x46
		// [CompilerGeneratedAttribute] // RVA: 0x6758E0 Offset: 0x6758E0 VA: 0x6758E0
		// private bool <m_isEndActivateScene>k__BackingField; // 0x47
		// [CompilerGeneratedAttribute] // RVA: 0x6758F0 Offset: 0x6758F0 VA: 0x6758F0
		// private bool <openSimulationLive>k__BackingField; // 0x48
		// [CompilerGeneratedAttribute] // RVA: 0x675900 Offset: 0x675900 VA: 0x675900
		// private IKDICBBFBMI <m_eventCtrl>k__BackingField; // 0x4C
		// protected IKDICBBFBMI m_scoreEventCtrl; // 0x50
		// [CompilerGeneratedAttribute] // RVA: 0x675910 Offset: 0x675910 VA: 0x675910
		// private int <m_eventId>k__BackingField; // 0x54
		// [CompilerGeneratedAttribute] // RVA: 0x675920 Offset: 0x675920 VA: 0x675920
		// private MMOLNAHHDOM <m_unitLiveLocalSaveData>k__BackingField; // 0x58
		// [CompilerGeneratedAttribute] // RVA: 0x675930 Offset: 0x675930 VA: 0x675930
		// private LimitTimeWatcher <m_musicTimeWatcher>k__BackingField; // 0x5C
		// [CompilerGeneratedAttribute] // RVA: 0x675940 Offset: 0x675940 VA: 0x675940
		// private LimitTimeWatcher <m_bannerTimeWatcher>k__BackingField; // 0x60
		// private VerticalMusicSelectSceneBase.MusicDecideInfo m_musicDecideInfo; // 0x68
		// private PopupAchieveRewardSetting m_rewardPopupSetting; // 0x88
		// private PopupUnitDanceWarning m_popupUnitDanceWarning; // 0x8C
		// private PopupMusicBookMarkSetting m_musicBookMarkSetting; // 0x90
		// private bool m_isConfirmedUnitDance; // 0x94
		// private TeamSlectSceneArgs m_teamSelectSceneArgs; // 0x98
		// [CompilerGeneratedAttribute] // RVA: 0x675950 Offset: 0x675950 VA: 0x675950
		// private int <m_eventTicketId>k__BackingField; // 0x9C
		// [CompilerGeneratedAttribute] // RVA: 0x675960 Offset: 0x675960 VA: 0x675960
		// private KGCNCBOKCBA.GNENJEHKMHD <m_eventStatus>k__BackingField; // 0xA0
		// [CompilerGeneratedAttribute] // RVA: 0x675970 Offset: 0x675970 VA: 0x675970
		// private bool <m_isEventTimeLimit>k__BackingField; // 0xA4
		// [CompilerGeneratedAttribute] // RVA: 0x675980 Offset: 0x675980 VA: 0x675980
		// private bool <m_muteSelectionSe>k__BackingField; // 0xA5
		// [CompilerGeneratedAttribute] // RVA: 0x675990 Offset: 0x675990 VA: 0x675990
		// private bool <m_requestFadeOutBgm>k__BackingField; // 0xA6
		// [CompilerGeneratedAttribute] // RVA: 0x6759A0 Offset: 0x6759A0 VA: 0x6759A0
		// private int <m_changeToTrialBgmId>k__BackingField; // 0xA8
		// private const float BGM_FADE_OUT_SEC = 0,3;
		// private List<Action> NoticeActionList; // 0xAC

		// // Properties
		// protected bool m_isEndPresetCanvas { get; set; }
		// protected bool m_isEndPostSetCanvas { get; set; }
		// protected bool m_isEndActivateScene { get; set; }
		// protected abstract Difficulty.Type diff { get; }
		// protected abstract MusicSelectConsts.SeriesType series { get; }
		// protected abstract int list_no { get; set; }
		// protected bool openSimulationLive { get; set; }
		// protected abstract bool isLine6Mode { get; }
		// protected abstract int musicListCount { get; }
		// protected abstract VerticalMusicDataList currentMusicList { get; }
		// protected abstract List<VerticalMusicDataList> originalMusicList { get; }
		// protected IKDICBBFBMI m_eventCtrl { get; set; }
		// protected int m_eventId { get; set; }
		// protected MMOLNAHHDOM m_unitLiveLocalSaveData { get; set; }
		// protected LimitTimeWatcher m_musicTimeWatcher { get; set; }
		// protected LimitTimeWatcher m_bannerTimeWatcher { get; set; }
		// protected abstract IBJAKJJICBC selectMusicData { get; }
		// protected abstract VerticalMusicDataList.MusicListData selectMusicListData { get; }
		// protected bool listIsEmpty { get; }
		// protected bool listIsEmptyByFilter { get; }
		// protected bool isExistSelectMusicData { get; }
		// protected int musicId { get; }
		// protected int freeMusicId { get; }
		// protected int gameEventType { get; }
		// protected int m_eventTicketId { get; set; }
		// protected KGCNCBOKCBA.GNENJEHKMHD m_eventStatus { get; set; }
		// protected bool m_isEventTimeLimit { get; set; }
		// private bool m_muteSelectionSe { get; set; }
		// private bool m_requestFadeOutBgm { get; set; }
		// private int m_changeToTrialBgmId { get; set; }
		// private float bgmFadeOutSec { get; }
		// public bool IsEventCounting { get; }
		// public bool IsEventEndChallengePeriod { get; }
		// public bool IsEventRankingEnd { get; }

		// // Methods

		// [CompilerGeneratedAttribute] // RVA: 0x6F6734 Offset: 0x6F6734 VA: 0x6F6734
		// // RVA: 0xAC8A7C Offset: 0xAC8A7C VA: 0xAC8A7C
		// protected bool get_m_isEndPresetCanvas() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6744 Offset: 0x6F6744 VA: 0x6F6744
		// // RVA: 0xAC7FB8 Offset: 0xAC7FB8 VA: 0xAC7FB8
		// protected void set_m_isEndPresetCanvas(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6754 Offset: 0x6F6754 VA: 0x6F6754
		// // RVA: 0xAC8A84 Offset: 0xAC8A84 VA: 0xAC8A84
		// protected bool get_m_isEndPostSetCanvas() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6764 Offset: 0x6F6764 VA: 0x6F6764
		// // RVA: 0xAC606C Offset: 0xAC606C VA: 0xAC606C
		// protected void set_m_isEndPostSetCanvas(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6774 Offset: 0x6F6774 VA: 0x6F6774
		// // RVA: 0xAC8A8C Offset: 0xAC8A8C VA: 0xAC8A8C
		// protected bool get_m_isEndActivateScene() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6784 Offset: 0x6F6784 VA: 0x6F6784
		// // RVA: 0xAC37D0 Offset: 0xAC37D0 VA: 0xAC37D0
		// protected void set_m_isEndActivateScene(bool value) { }

		// // RVA: -1 Offset: -1 Slot: 31
		// protected abstract Difficulty.Type get_diff();

		// // RVA: -1 Offset: -1 Slot: 32
		// protected abstract MusicSelectConsts.SeriesType get_series();

		// // RVA: -1 Offset: -1 Slot: 33
		// protected abstract void set_list_no(int value);

		// // RVA: -1 Offset: -1 Slot: 34
		// protected abstract int get_list_no();

		// [CompilerGeneratedAttribute] // RVA: 0x6F6794 Offset: 0x6F6794 VA: 0x6F6794
		// // RVA: 0xAC7CB8 Offset: 0xAC7CB8 VA: 0xAC7CB8
		// protected void set_openSimulationLive(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F67A4 Offset: 0x6F67A4 VA: 0x6F67A4
		// // RVA: 0xAC8A94 Offset: 0xAC8A94 VA: 0xAC8A94
		// protected bool get_openSimulationLive() { }

		// // RVA: -1 Offset: -1 Slot: 35
		// protected abstract bool get_isLine6Mode();

		// // RVA: -1 Offset: -1 Slot: 36
		// protected abstract int get_musicListCount();

		// // RVA: -1 Offset: -1 Slot: 37
		// protected abstract VerticalMusicDataList GetMusicList(int index);

		// // RVA: -1 Offset: -1 Slot: 38
		// protected abstract VerticalMusicDataList get_currentMusicList();

		// // RVA: -1 Offset: -1 Slot: 39
		// protected abstract List<VerticalMusicDataList> get_originalMusicList();

		// [CompilerGeneratedAttribute] // RVA: 0x6F67B4 Offset: 0x6F67B4 VA: 0x6F67B4
		// // RVA: 0xAC7238 Offset: 0xAC7238 VA: 0xAC7238
		// protected IKDICBBFBMI get_m_eventCtrl() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F67C4 Offset: 0x6F67C4 VA: 0x6F67C4
		// // RVA: 0xAC7230 Offset: 0xAC7230 VA: 0xAC7230
		// protected void set_m_eventCtrl(IKDICBBFBMI value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F67D4 Offset: 0x6F67D4 VA: 0x6F67D4
		// // RVA: 0xAC8A9C Offset: 0xAC8A9C VA: 0xAC8A9C
		// protected int get_m_eventId() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F67E4 Offset: 0x6F67E4 VA: 0x6F67E4
		// // RVA: 0xAC8AA4 Offset: 0xAC8AA4 VA: 0xAC8AA4
		// protected void set_m_eventId(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F67F4 Offset: 0x6F67F4 VA: 0x6F67F4
		// // RVA: 0xAC7240 Offset: 0xAC7240 VA: 0xAC7240
		// protected MMOLNAHHDOM get_m_unitLiveLocalSaveData() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6804 Offset: 0x6F6804 VA: 0x6F6804
		// // RVA: 0xAC8AAC Offset: 0xAC8AAC VA: 0xAC8AAC
		// private void set_m_unitLiveLocalSaveData(MMOLNAHHDOM value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6814 Offset: 0x6F6814 VA: 0x6F6814
		// // RVA: 0xAC8AB4 Offset: 0xAC8AB4 VA: 0xAC8AB4
		// protected LimitTimeWatcher get_m_musicTimeWatcher() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6824 Offset: 0x6F6824 VA: 0x6F6824
		// // RVA: 0xAC8ABC Offset: 0xAC8ABC VA: 0xAC8ABC
		// private void set_m_musicTimeWatcher(LimitTimeWatcher value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6834 Offset: 0x6F6834 VA: 0x6F6834
		// // RVA: 0xAC8AC4 Offset: 0xAC8AC4 VA: 0xAC8AC4
		// protected LimitTimeWatcher get_m_bannerTimeWatcher() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6844 Offset: 0x6F6844 VA: 0x6F6844
		// // RVA: 0xAC8ACC Offset: 0xAC8ACC VA: 0xAC8ACC
		// private void set_m_bannerTimeWatcher(LimitTimeWatcher value) { }

		// // RVA: -1 Offset: -1 Slot: 40
		// protected abstract IBJAKJJICBC get_selectMusicData();

		// // RVA: -1 Offset: -1 Slot: 41
		// protected abstract VerticalMusicDataList.MusicListData get_selectMusicListData();

		// // RVA: 0xAC8AD4 Offset: 0xAC8AD4 VA: 0xAC8AD4
		// protected bool get_listIsEmpty() { }

		// // RVA: 0xAC8B48 Offset: 0xAC8B48 VA: 0xAC8B48
		// protected bool get_listIsEmptyByFilter() { }

		// // RVA: 0xAC8B50 Offset: 0xAC8B50 VA: 0xAC8B50
		// protected bool get_isExistSelectMusicData() { }

		// // RVA: 0xAC8B58 Offset: 0xAC8B58 VA: 0xAC8B58
		// protected int get_musicId() { }

		// // RVA: 0xAC8BAC Offset: 0xAC8BAC VA: 0xAC8BAC
		// protected int get_freeMusicId() { }

		// // RVA: 0xAC8C00 Offset: 0xAC8C00 VA: 0xAC8C00
		// protected int get_gameEventType() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6854 Offset: 0x6F6854 VA: 0x6F6854
		// // RVA: 0xAC8C54 Offset: 0xAC8C54 VA: 0xAC8C54
		// protected void set_m_eventTicketId(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6864 Offset: 0x6F6864 VA: 0x6F6864
		// // RVA: 0xAC8C5C Offset: 0xAC8C5C VA: 0xAC8C5C
		// protected int get_m_eventTicketId() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6874 Offset: 0x6F6874 VA: 0x6F6874
		// // RVA: 0xAC7FB0 Offset: 0xAC7FB0 VA: 0xAC7FB0
		// protected KGCNCBOKCBA.GNENJEHKMHD get_m_eventStatus() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6884 Offset: 0x6F6884 VA: 0x6F6884
		// // RVA: 0xAC8C64 Offset: 0xAC8C64 VA: 0xAC8C64
		// protected void set_m_eventStatus(KGCNCBOKCBA.GNENJEHKMHD value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6894 Offset: 0x6F6894 VA: 0x6F6894
		// // RVA: 0xAC8C6C Offset: 0xAC8C6C VA: 0xAC8C6C
		// protected bool get_m_isEventTimeLimit() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F68A4 Offset: 0x6F68A4 VA: 0x6F68A4
		// // RVA: 0xAC8C74 Offset: 0xAC8C74 VA: 0xAC8C74
		// protected void set_m_isEventTimeLimit(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F68B4 Offset: 0x6F68B4 VA: 0x6F68B4
		// // RVA: 0xAC8C7C Offset: 0xAC8C7C VA: 0xAC8C7C
		// private void set_m_muteSelectionSe(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F68C4 Offset: 0x6F68C4 VA: 0x6F68C4
		// // RVA: 0xAC8C84 Offset: 0xAC8C84 VA: 0xAC8C84
		// private bool get_m_muteSelectionSe() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F68D4 Offset: 0x6F68D4 VA: 0x6F68D4
		// // RVA: 0xAC8C8C Offset: 0xAC8C8C VA: 0xAC8C8C
		// private void set_m_requestFadeOutBgm(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F68E4 Offset: 0x6F68E4 VA: 0x6F68E4
		// // RVA: 0xAC8C94 Offset: 0xAC8C94 VA: 0xAC8C94
		// private bool get_m_requestFadeOutBgm() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F68F4 Offset: 0x6F68F4 VA: 0x6F68F4
		// // RVA: 0xAC8C9C Offset: 0xAC8C9C VA: 0xAC8C9C
		// private void set_m_changeToTrialBgmId(int value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F6904 Offset: 0x6F6904 VA: 0x6F6904
		// // RVA: 0xAC8CA4 Offset: 0xAC8CA4 VA: 0xAC8CA4
		// private int get_m_changeToTrialBgmId() { }

		// // RVA: 0xAC8CAC Offset: 0xAC8CAC VA: 0xAC8CAC
		// private float get_bgmFadeOutSec() { }

		// // RVA: 0xAC8CB8 Offset: 0xAC8CB8 VA: 0xAC8CB8 Slot: 4
		// protected override void Awake() { }

		// // RVA: 0xAC8D74 Offset: 0xAC8D74 VA: 0xAC8D74
		// protected void Update() { }

		// // RVA: 0xAC8DD8 Offset: 0xAC8DD8 VA: 0xAC8DD8 Slot: 16
		// protected override void OnPreSetCanvas() { }

		// // RVA: 0xAC8EA4 Offset: 0xAC8EA4 VA: 0xAC8EA4 Slot: 17
		// protected override bool IsEndPreSetCanvas() { }

		// // RVA: 0xAC8F58 Offset: 0xAC8F58 VA: 0xAC8F58 Slot: 18
		// protected override void OnPostSetCanvas() { }

		// // RVA: 0xAC8F8C Offset: 0xAC8F8C VA: 0xAC8F8C Slot: 19
		// protected override bool IsEndPostSetCanvas() { }

		// // RVA: 0xAC8F94 Offset: 0xAC8F94 VA: 0xAC8F94 Slot: 23
		// protected override void OnActivateScene() { }

		// // RVA: 0xAC8FC8 Offset: 0xAC8FC8 VA: 0xAC8FC8 Slot: 24
		// protected override bool IsEndActivateScene() { }

		// // RVA: 0xAC8FD0 Offset: 0xAC8FD0 VA: 0xAC8FD0 Slot: 20
		// protected override bool OnBgmStart() { }

		// // RVA: 0xAC8FF0 Offset: 0xAC8FF0 VA: 0xAC8FF0 Slot: 14
		// protected override void OnDestoryScene() { }

		// // RVA: 0xAC9038 Offset: 0xAC9038 VA: 0xAC9038 Slot: 15
		// protected override void OnDeleteCache() { }

		// // RVA: 0xAC9070 Offset: 0xAC9070 VA: 0xAC9070 Slot: 30
		// protected override void InputDisable() { }

		// // RVA: 0xAC909C Offset: 0xAC909C VA: 0xAC909C Slot: 29
		// protected override void InputEnable() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F6914 Offset: 0x6F6914 VA: 0x6F6914
		// // RVA: 0xAC8CE8 Offset: 0xAC8CE8 VA: 0xAC8CE8
		// private IEnumerator Co_Awake() { }

		// // RVA: -1 Offset: -1 Slot: 42
		// protected abstract IEnumerator Co_OnPreSetCanvas();

		// // RVA: -1 Offset: -1 Slot: 43
		// protected abstract IEnumerator Co_OnPostSetCanvas();

		// // RVA: -1 Offset: -1 Slot: 44
		// protected abstract IEnumerator Co_ActivateScene();

		// // RVA: -1 Offset: -1 Slot: 45
		// protected abstract IEnumerator Co_LoadResourceOnAwake();

		// // RVA: -1 Offset: -1 Slot: 46
		// protected abstract IEnumerator Co_WaitForLoaded();

		// // RVA: -1 Offset: -1 Slot: 47
		// protected abstract void OnUpdate();

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

		// // RVA: 0xACFD7C Offset: 0xACFD7C VA: 0xACFD7C
		// public bool get_IsEventCounting() { }

		// // RVA: 0xACFD90 Offset: 0xACFD90 VA: 0xACFD90
		// public bool get_IsEventEndChallengePeriod() { }

		// // RVA: 0xACFDA4 Offset: 0xACFDA4 VA: 0xACFDA4
		// public bool get_IsEventRankingEnd() { }

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

		// // RVA: 0xAD2D24 Offset: 0xAD2D24 VA: 0xAD2D24
		// protected void .ctor() { }
	}
}
