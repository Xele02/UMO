using System;
using System.Collections;
using XeSys;

namespace XeApp.Game.Menu
{
	public class EventMusicSelectScene : MusicSelectSceneBase
	{
		// private const int EVENT_POINT_MAX = 99999999;
		// private MusicSelectEventInfo m_eventInfo; // 0xF8
		// private EventTimeLimitMessage m_timeLimitMessage; // 0xFC
		// private MusicSelectLineButton m_lineButton; // 0x100
		private MusicDataList m_musicList; // 0x104
		// private bool m_isEventChecked; // 0x108
		// private bool m_isEventTimeLimit; // 0x109

		protected override int musicListCount { get { return 1; } } //0x13B12B0
		protected override MusicDataList currentMusicList { get { return m_musicList; } } //0x13B12C0

		// // RVA: 0x13B12B8 Offset: 0x13B12B8 VA: 0x13B12B8 Slot: 32
		protected override MusicDataList GetMusicList(int i)
		{
			return m_musicList;
		}

		// RVA: 0x13B12C8 Offset: 0x13B12C8 VA: 0x13B12C8 Slot: 16
		protected override void OnPreSetCanvas()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene OnPreSetCanvas");
		}

		// RVA: 0x13B1378 Offset: 0x13B1378 VA: 0x13B1378 Slot: 17
		protected override bool IsEndPreSetCanvas()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene IsEndPreSetCanvas");
			return true;
		}

		// RVA: 0x13B14B8 Offset: 0x13B14B8 VA: 0x13B14B8 Slot: 9
		protected override void OnStartEnterAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene OnStartEnterAnimation");
		}

		// RVA: 0x13B16B4 Offset: 0x13B16B4 VA: 0x13B16B4 Slot: 10
		protected override bool IsEndEnterAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene IsEndEnterAnimation");
			return true;
		}

		// RVA: 0x13B1808 Offset: 0x13B1808 VA: 0x13B1808 Slot: 12
		protected override void OnStartExitAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene OnStartExitAnimation");
		}

		// RVA: 0x13B193C Offset: 0x13B193C VA: 0x13B193C Slot: 13
		protected override bool IsEndExitAnimation()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene IsEndExitAnimation");
			return true;
		}

		// RVA: 0x13B1A90 Offset: 0x13B1A90 VA: 0x13B1A90 Slot: 35
		protected override void CheckTryInstall()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene CheckTryInstall");
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EEDAC Offset: 0x6EEDAC VA: 0x6EEDAC
		// // RVA: 0x13B1B80 Offset: 0x13B1B80 VA: 0x13B1B80 Slot: 36
		protected override IEnumerator Co_Initialize()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene Co_Initialize");
			yield break;
		}

		// RVA: 0x13B1C2C Offset: 0x13B1C2C VA: 0x13B1C2C Slot: 39
		protected override void Release()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene Release");
		}

		// RVA: 0x13B1C7C Offset: 0x13B1C7C VA: 0x13B1C7C Slot: 40
		protected override void SetupViewMusicData()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene SetupViewMusicData");
		}

		// RVA: 0x13B1EBC Offset: 0x13B1EBC VA: 0x13B1EBC Slot: 41
		protected override void ApplyBasicInfo()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "MusicSelectScene* ApplyBasicInfo");
		}

		// RVA: 0x13B1EC4 Offset: 0x13B1EC4 VA: 0x13B1EC4 Slot: 42
		protected override void ApplyMusicListInfo()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "MusicSelectScene* ApplyMusicListInfo");
		}

		// RVA: 0x13B1F2C Offset: 0x13B1F2C VA: 0x13B1F2C Slot: 44
		protected override void DelayedApplyMusicInfo()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene DelayedApplyMusicInfo");
		}

		// RVA: 0x13B20C0 Offset: 0x13B20C0 VA: 0x13B20C0 Slot: 45
		protected override string GetLiveEntranceMessage(IBJAKJJICBC musicData)
		{
			return MessageManager.Instance.GetMessage("menu", m_eventCtrl.MNDFBBMNJGN_IsUsingTicket ? "music_to_live_ticket_msg" : "music_to_live_stamina_msg");
		}

		// RVA: 0x13B21A8 Offset: 0x13B21A8 VA: 0x13B21A8 Slot: 46
		protected override void ApplyMusicInfoBasic(IBJAKJJICBC musicData)
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene ApplyMusicInfoBasic");
		}

		// // RVA: 0x13B2524 Offset: 0x13B2524 VA: 0x13B2524
		// private void ApplyEventInfo() { }

		// // RVA: 0x13B2D18 Offset: 0x13B2D18 VA: 0x13B2D18 Slot: 50
		protected override bool CurrentMusicDecisionCheck(Action cancelCallback, MKIKFJKPEHK viewBoostData, int selectIndex/* = 0*/)
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene CurrentMusicDecisionCheck");
			return base.CurrentMusicDecisionCheck(cancelCallback, viewBoostData, selectIndex);
		}

		// RVA: 0x13B325C Offset: 0x13B325C VA: 0x13B325C Slot: 52
		protected override void LeaveForScrollStart()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene LeaveForScrollStart");
		}

		// RVA: 0x13B3294 Offset: 0x13B3294 VA: 0x13B3294 Slot: 53
		// protected override void EnterForScrollEnd() { }

		// RVA: 0x13B32CC Offset: 0x13B32CC VA: 0x13B32CC Slot: 54
		protected override void OnChangedDifficulty()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene OnChangedDifficulty");
		}

		// // RVA: 0x13B2CB8 Offset: 0x13B2CB8 VA: 0x13B2CB8
		// private static string EP_ToString(long point) { }

		// // RVA: 0x13B2F34 Offset: 0x13B2F34 VA: 0x13B2F34
		// private void OpenTicketFewWindow(int currentTicket, int needTicket) { }

		// // RVA: 0x13B3404 Offset: 0x13B3404 VA: 0x13B3404
		// protected void OnChangeLineMode(int style) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EEE24 Offset: 0x6EEE24 VA: 0x6EEE24
		// // RVA: 0x13B36C8 Offset: 0x13B36C8 VA: 0x13B36C8
		// private IEnumerator Co_ChangeLiveMode(Action callback) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EEE9C Offset: 0x6EEE9C VA: 0x6EEE9C
		// // RVA: 0x13B3790 Offset: 0x13B3790 VA: 0x13B3790
		// private IEnumerator Co_RequestGetScoreRank(IKDICBBFBMI eventCtrl) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EEF14 Offset: 0x6EEF14 VA: 0x6EEF14
		// // RVA: 0x13B12EC Offset: 0x13B12EC VA: 0x13B12EC
		// private IEnumerator Co_PreSetCanvas() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6EEF8C Offset: 0x6EEF8C VA: 0x6EEF8C
		// // RVA: 0x13B3878 Offset: 0x13B3878 VA: 0x13B3878 Slot: 55
		protected override IEnumerator Co_LoadLayout()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene Co_LoadLayout");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EF004 Offset: 0x6EF004 VA: 0x6EF004
		// // RVA: 0x13B3924 Offset: 0x13B3924 VA: 0x13B3924 Slot: 56
		protected override IEnumerator Co_WaitForLoaded()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene Co_WaitForLoaded");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EF07C Offset: 0x6EF07C VA: 0x6EF07C
		// // RVA: 0x13B39D0 Offset: 0x13B39D0 VA: 0x13B39D0 Slot: 57
		protected override IEnumerator Co_WaitForAnimEnd(Action onEnd)
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene Co_WaitForAnimEnd");
			yield break;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6EF0F4 Offset: 0x6EF0F4 VA: 0x6EF0F4
		// // RVA: 0x13B3A98 Offset: 0x13B3A98 VA: 0x13B3A98 Slot: 37
		protected override IEnumerator Co_OnActivateScene()
		{
			TodoLogger.LogError(TodoLogger.EventBattle_3, "EventMusicSelectScene Co_OnActivateScene");
			yield break;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6EF16C Offset: 0x6EF16C VA: 0x6EF16C
		// // RVA: 0x13B3B4C Offset: 0x13B3B4C VA: 0x13B3B4C
		// private void <ApplyMusicInfoBasic>b__26_0(long current, long limit, long remain) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF17C Offset: 0x6EF17C VA: 0x6EF17C
		// // RVA: 0x13B3B78 Offset: 0x13B3B78 VA: 0x13B3B78
		// private void <ApplyEventInfo>b__27_0(long current, long limit, long remain) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF18C Offset: 0x6EF18C VA: 0x6EF18C
		// // RVA: 0x13B3BA4 Offset: 0x13B3BA4 VA: 0x13B3BA4
		// private void <ApplyEventInfo>b__27_1(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF19C Offset: 0x6EF19C VA: 0x6EF19C
		// // RVA: 0x13B3C48 Offset: 0x13B3C48 VA: 0x13B3C48
		// private void <ApplyEventInfo>b__27_2(IiconTexture image) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF1AC Offset: 0x6EF1AC VA: 0x6EF1AC
		// // RVA: 0x13B3C7C Offset: 0x13B3C7C VA: 0x13B3C7C
		// private void <OpenTicketFewWindow>b__33_0(PopupWindowControl ctrl, PopupButton.ButtonType type, PopupButton.ButtonLabel label) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF1BC Offset: 0x6EF1BC VA: 0x6EF1BC
		// [DebuggerHiddenAttribute] // RVA: 0x6EF1BC Offset: 0x6EF1BC VA: 0x6EF1BC
		// // RVA: 0x13B3C8C Offset: 0x13B3C8C VA: 0x13B3C8C
		// private void <>n__0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF1EC Offset: 0x6EF1EC VA: 0x6EF1EC
		// // RVA: 0x13B3C94 Offset: 0x13B3C94 VA: 0x13B3C94
		// private void <Co_LoadLayout>b__38_0(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF1FC Offset: 0x6EF1FC VA: 0x6EF1FC
		// // RVA: 0x13B3D64 Offset: 0x13B3D64 VA: 0x13B3D64
		// private void <Co_LoadLayout>b__38_1(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF20C Offset: 0x6EF20C VA: 0x6EF20C
		// // RVA: 0x13B3E34 Offset: 0x13B3E34 VA: 0x13B3E34
		// private void <Co_LoadLayout>b__38_2(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF21C Offset: 0x6EF21C VA: 0x6EF21C
		// // RVA: 0x13B3F04 Offset: 0x13B3F04 VA: 0x13B3F04
		// private void <Co_LoadLayout>b__38_3(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF22C Offset: 0x6EF22C VA: 0x6EF22C
		// // RVA: 0x13B3FD4 Offset: 0x13B3FD4 VA: 0x13B3FD4
		// private void <Co_LoadLayout>b__38_4(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF23C Offset: 0x6EF23C VA: 0x6EF23C
		// // RVA: 0x13B40A4 Offset: 0x13B40A4 VA: 0x13B40A4
		// private void <Co_LoadLayout>b__38_5(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF24C Offset: 0x6EF24C VA: 0x6EF24C
		// // RVA: 0x13B4174 Offset: 0x13B4174 VA: 0x13B4174
		// private void <Co_LoadLayout>b__38_6(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF25C Offset: 0x6EF25C VA: 0x6EF25C
		// // RVA: 0x13B4244 Offset: 0x13B4244 VA: 0x13B4244
		// private void <Co_LoadLayout>b__38_7(GameObject instance) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF26C Offset: 0x6EF26C VA: 0x6EF26C
		// [DebuggerHiddenAttribute] // RVA: 0x6EF26C Offset: 0x6EF26C VA: 0x6EF26C
		// // RVA: 0x13B4314 Offset: 0x13B4314 VA: 0x13B4314
		// private IEnumerator <>n__1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF29C Offset: 0x6EF29C VA: 0x6EF29C
		// [DebuggerHiddenAttribute] // RVA: 0x6EF29C Offset: 0x6EF29C VA: 0x6EF29C
		// // RVA: 0x13B431C Offset: 0x13B431C VA: 0x13B431C
		// private IEnumerator <>n__2(Action onEnd) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF2CC Offset: 0x6EF2CC VA: 0x6EF2CC
		// // RVA: 0x13B4324 Offset: 0x13B4324 VA: 0x13B4324
		// private void <Co_OnActivateScene>b__41_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF2DC Offset: 0x6EF2DC VA: 0x6EF2DC
		// // RVA: 0x13B4384 Offset: 0x13B4384 VA: 0x13B4384
		// private void <Co_OnActivateScene>b__41_1() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6EF2EC Offset: 0x6EF2EC VA: 0x6EF2EC
		// // RVA: 0x13B438C Offset: 0x13B438C VA: 0x13B438C
		// private void <Co_OnActivateScene>b__41_2() { }
	}
}
