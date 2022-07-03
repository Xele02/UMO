using System.Collections;

namespace XeApp.Game.Menu
{
	public class EventBattleScene : MusicSelectSceneBase
	{
		// private MusicSelectEventInfo m_eventInfo; // 0xF8
		// private MusicSelectBattleInfo m_battleInfo; // 0xFC
		// private MusicSelectBattleMatch m_battleMatch; // 0x100
		// private MusicSelectBattleLimit m_battleLimit; // 0x104
		// private MusicSelectBattleExButton m_battleExButton; // 0x108
		// private MusicSelectBattleExGauge m_battleExGauge; // 0x10C
		// private EventTimeLimitMessage m_timeLimitMessage; // 0x110
		// private MusicSelectLineButton m_lineButton; // 0x114
		// private LayoutPopupExBattleScore m_ExBattleScore; // 0x118
		// private LayoutPopupExBattleScoreTotal m_ExBattleScoreTotal; // 0x11C
		// private LayoutBattleClassListWindow m_battleClassSelect; // 0x120
		// private MusicDataList m_musicList; // 0x124
		// private DivaIconDecoration m_selfDivaDeco; // 0x128
		// private DivaIconDecoration m_rivalDivaDeco; // 0x12C
		// private SceneIconDecoration m_selfSceneDeco; // 0x130
		// private SceneIconDecoration m_rivalSceneDeco; // 0x134
		// private bool m_isEventChecked; // 0x138
		// private bool m_isMatched; // 0x139
		// private bool m_isClassSelected; // 0x13A
		// private ConfigMenu m_gameSettingMenu; // 0x13C

		// protected override int musicListCount { get; } 0xF0F120
		// protected override MusicDataList currentMusicList { get; } 0xF0F130
		// protected override bool scrollIsClamp { get; } 0xF0F138

		// // RVA: 0xF0F128 Offset: 0xF0F128 VA: 0xF0F128 Slot: 32
		// protected override MusicDataList GetMusicList(int i) { }

		// RVA: 0xF0F140 Offset: 0xF0F140 VA: 0xF0F140 Slot: 5
		protected override void Start()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene Start");
		}

		// RVA: 0xF0F14C Offset: 0xF0F14C VA: 0xF0F14C Slot: 16
		protected override void OnPreSetCanvas()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene OnPreSetCanvas");
		}

		// RVA: 0xF0F2A0 Offset: 0xF0F2A0 VA: 0xF0F2A0 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene IsEndPreSetCanvas");
			return true;
		}

		// RVA: 0xF0F480 Offset: 0xF0F480 VA: 0xF0F480 Slot: 20
		protected override bool OnBgmStart()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene OnBgmStart");
			return true;
		}

		// RVA: 0xF0F4FC Offset: 0xF0F4FC VA: 0xF0F4FC Slot: 9
		protected override void OnStartEnterAnimation()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene OnStartEnterAnimation");
		}

		// RVA: 0xF0F770 Offset: 0xF0F770 VA: 0xF0F770 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene IsEndEnterAnimation");
			return true;
		}

		// RVA: 0xF0F964 Offset: 0xF0F964 VA: 0xF0F964 Slot: 12
		protected override void OnStartExitAnimation()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene OnStartExitAnimation");
		}

		// RVA: 0xF0FB20 Offset: 0xF0FB20 VA: 0xF0FB20 Slot: 13
		protected override bool IsEndExitAnimation()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene IsEndExitAnimation");
			return true;
		}

		// RVA: 0xF0FD14 Offset: 0xF0FD14 VA: 0xF0FD14 Slot: 51
		// protected override void OnDecideCurrentMusic() { }

		// RVA: 0xF0FEA4 Offset: 0xF0FEA4 VA: 0xF0FEA4 Slot: 15
		protected override void OnDeleteCache()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene OnDeleteCache");
		}

		// RVA: 0xF0FF9C Offset: 0xF0FF9C VA: 0xF0FF9C Slot: 14
		protected override void OnDestoryScene()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene OnDestoryScene");
		}

		// RVA: 0xF0FFD4 Offset: 0xF0FFD4 VA: 0xF0FFD4 Slot: 35
		protected override void CheckTryInstall()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene CheckTryInstall");
		}

		// // RVA: 0xF0FFD8 Offset: 0xF0FFD8 VA: 0xF0FFD8
		// private void TryInstall() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EDB9C Offset: 0x6EDB9C VA: 0x6EDB9C
		// // RVA: 0xF100B4 Offset: 0xF100B4 VA: 0xF100B4
		// private IEnumerator Co_Save() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EDC14 Offset: 0x6EDC14 VA: 0x6EDC14
		// // RVA: 0xF10124 Offset: 0xF10124 VA: 0xF10124 Slot: 36
		protected override IEnumerator Co_Initialize()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene CheckTryInstall");
			yield break;
		}

		// RVA: 0xF101AC Offset: 0xF101AC VA: 0xF101AC Slot: 38
		protected override PlayButtonWrapper CreatePlayButtonWrapper()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene CreatePlayButtonWrapper");
			return null;
		}

		// RVA: 0xF1022C Offset: 0xF1022C VA: 0xF1022C Slot: 39
		protected override void Release()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene Release");
		}

		// RVA: 0xF10300 Offset: 0xF10300 VA: 0xF10300 Slot: 40
		protected override void SetupViewMusicData()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene SetupViewMusicData");
		}

		// RVA: 0xF10450 Offset: 0xF10450 VA: 0xF10450 Slot: 41
		protected override void ApplyBasicInfo()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectScene* ApplyBasicInfo");
		}

		// RVA: 0xF1048C Offset: 0xF1048C VA: 0xF1048C Slot: 42
		protected override void ApplyMusicListInfo()
		{
			UnityEngine.Debug.LogError("TODO MusicSelectScene* ApplyMusicListInfo");
		}

		// RVA: 0xF104F4 Offset: 0xF104F4 VA: 0xF104F4 Slot: 44
		protected override void DelayedApplyMusicInfo()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene DelayedApplyMusicInfo");
		}

		// RVA: 0xF10658 Offset: 0xF10658 VA: 0xF10658 Slot: 46
		// protected override void ApplyMusicInfoBasic(IBJAKJJICBC musicData) { }

		// // RVA: 0xF117A8 Offset: 0xF117A8 VA: 0xF117A8
		// private void ApplyEventInfo() { }

		// RVA: 0xF121FC Offset: 0xF121FC VA: 0xF121FC Slot: 52
		// protected override void LeaveForScrollStart() { }

		// RVA: 0xF12254 Offset: 0xF12254 VA: 0xF12254 Slot: 53
		// protected override void EnterForScrollEnd() { }

		// RVA: 0xF122AC Offset: 0xF122AC VA: 0xF122AC Slot: 54
		// protected override void OnChangedDifficulty() { }

		// // RVA: 0xF123E4 Offset: 0xF123E4 VA: 0xF123E4
		// private void InitializeDecos() { }

		// // RVA: 0xF10280 Offset: 0xF10280 VA: 0xF10280
		// private void ReleaseDecos() { }

		// // RVA: 0xF108D8 Offset: 0xF108D8 VA: 0xF108D8
		// private void ApplyBattleInfo(IBJAKJJICBC musicData) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EDC8C Offset: 0x6EDC8C VA: 0x6EDC8C
		// // RVA: 0xF0F218 Offset: 0xF0F218 VA: 0xF0F218
		// private IEnumerator Co_PreSetCanvas() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EDD04 Offset: 0x6EDD04 VA: 0x6EDD04
		// // RVA: 0xF125B0 Offset: 0xF125B0 VA: 0xF125B0 Slot: 55
		protected override IEnumerator Co_LoadLayout()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene Co_LoadLayout");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDD7C Offset: 0x6EDD7C VA: 0x6EDD7C
		// // RVA: 0xF12638 Offset: 0xF12638 VA: 0xF12638 Slot: 56
		protected override IEnumerator Co_WaitForLoaded()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene Co_WaitForLoaded");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDDF4 Offset: 0x6EDDF4 VA: 0x6EDDF4
		// // RVA: 0xF126C0 Offset: 0xF126C0 VA: 0xF126C0 Slot: 57
		// protected override IEnumerator Co_WaitForAnimEnd(Action onEnd) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EDE6C Offset: 0x6EDE6C VA: 0x6EDE6C
		// // RVA: 0xF12764 Offset: 0xF12764 VA: 0xF12764 Slot: 37
		protected override IEnumerator Co_OnActivateScene()
		{
			UnityEngine.Debug.LogError("TODO EventBattleScene Co_OnActivateScene");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EDEE4 Offset: 0x6EDEE4 VA: 0x6EDEE4
		// // RVA: 0xF127EC Offset: 0xF127EC VA: 0xF127EC
		// private IEnumerator Co_UnlockedClass(PMFBBLGPLLJ viewSelectData) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EDF5C Offset: 0x6EDF5C VA: 0x6EDF5C
		// // RVA: 0xF12890 Offset: 0xF12890 VA: 0xF12890
		// private IEnumerator Co_SelectClass(PMFBBLGPLLJ viewSelectData) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EDFD4 Offset: 0x6EDFD4 VA: 0x6EDFD4
		// // RVA: 0xF12934 Offset: 0xF12934 VA: 0xF12934
		// private IEnumerator Co_ChallengeNewClass(PMFBBLGPLLJ viewSelectData) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE04C Offset: 0x6EE04C VA: 0x6EE04C
		// // RVA: 0xF129D8 Offset: 0xF129D8 VA: 0xF129D8
		// private IEnumerator Co_Matching() { }

		// // RVA: 0xF12A60 Offset: 0xF12A60 VA: 0xF12A60
		// private void OnClickExBattleScore() { }

		// // RVA: 0xF12C28 Offset: 0xF12C28 VA: 0xF12C28
		private void OverrideEnemySkill() { }

		// // RVA: 0xF12C98 Offset: 0xF12C98 VA: 0xF12C98
		// private void OnClickSelectClassButton() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE0C4 Offset: 0x6EE0C4 VA: 0x6EE0C4
		// // RVA: 0xF12D9C Offset: 0xF12D9C VA: 0xF12D9C
		// private IEnumerator Co_OpenBattleEventPopup() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE13C Offset: 0x6EE13C VA: 0x6EE13C
		// // RVA: 0xF12E24 Offset: 0xF12E24 VA: 0xF12E24
		// private IEnumerator Co_ConfirmSelectClass(Action<bool> onEnd) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE1B4 Offset: 0x6EE1B4 VA: 0x6EE1B4
		// // RVA: 0xF12EC8 Offset: 0xF12EC8 VA: 0xF12EC8
		// protected IEnumerator TryShowExRivalTutorial() { }

		// // RVA: 0xF12F50 Offset: 0xF12F50 VA: 0xF12F50
		// private bool CheckExRivalHelpFunc() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE22C Offset: 0x6EE22C VA: 0x6EE22C
		// // RVA: 0xF13108 Offset: 0xF13108 VA: 0xF13108
		// private IEnumerator Co_BattleAssetDownLoad(List<IBJAKJJICBC> musicList) { }

		// // RVA: 0xF13190 Offset: 0xF13190 VA: 0xF13190
		// protected void OnChangeLineMode(int style) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EE2A4 Offset: 0x6EE2A4 VA: 0x6EE2A4
		// // RVA: 0xF134C8 Offset: 0xF134C8 VA: 0xF134C8
		// private IEnumerator Co_ChangeLineMode(int freeMusicId, int strength, Action callback) { }

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

		// [CompilerGeneratedAttribute] // RVA: 0x6EE3EC Offset: 0x6EE3EC VA: 0x6EE3EC
		// // RVA: 0xF1382C Offset: 0xF1382C VA: 0xF1382C
		// private void <Co_OnActivateScene>b__60_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE3FC Offset: 0x6EE3FC VA: 0x6EE3FC
		// // RVA: 0xF13834 Offset: 0xF13834 VA: 0xF13834
		// private void <Co_OnActivateScene>b__60_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE40C Offset: 0x6EE40C VA: 0x6EE40C
		// // RVA: 0xF1383C Offset: 0xF1383C VA: 0xF1383C
		// private void <OnClickExBattleScore>b__65_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE41C Offset: 0x6EE41C VA: 0x6EE41C
		// // RVA: 0xF13B9C Offset: 0xF13B9C VA: 0xF13B9C
		// private void <OnClickExBattleScore>b__65_3() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EE42C Offset: 0x6EE42C VA: 0x6EE42C
		// // RVA: 0xF13BC8 Offset: 0xF13BC8 VA: 0xF13BC8
		// private void <OnClickExBattleScore>b__65_1(EMGOCNMMPHC view) { }
	}
}
