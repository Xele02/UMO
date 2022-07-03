using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDSelect : LayoutLabelScriptBase
	{
		public delegate void SelectionChangedCallback(int offset);
		public delegate void ScrollRepeatedCallback(int repeatDelta, int beginIndex, int endIndex);

		// private static readonly int[] s_orderdJacketIndex = new int[6] { 6, 4, 2, 1, 3, 5 }; // 0x0
		// public static readonly int OrderdJacketNum = s_orderdJacketIndex.Length; // 0x4
		[SerializeField]
		private ActionButton m_eventDetailButton; // 0x18
		[SerializeField]
		private List<MusicSelectCDButton> m_cdSelectButtons; // 0x1C
		[SerializeField]
		private List<MusicSelectCDJacket> m_jacketImages; // 0x20
		[SerializeField]
		private List<MusicSelectCDJacket> m_singleJacketImages; // 0x24
		[SerializeField]
		private MusicSelectCDScroller m_scroller; // 0x28
		[SerializeField]
		private MusicSelectCDCursor m_cdCursor; // 0x2C
		[SerializeField]
		private MusicSelectPlayButton m_playButton; // 0x30
		[SerializeField]
		private MusicSelectUnitButton m_unitButton; // 0x34
		// private LayoutSymbolData m_symbolMain; // 0x38
		// private LayoutSymbolData m_symbolStyle; // 0x3C
		// private LayoutSymbolData m_symbolPlayButtonType; // 0x40
		// private LayoutSymbolData m_symbolPlayButtonMain; // 0x44
		// private LayoutSymbolData m_symbolCurMain; // 0x48
		// private LayoutSymbolData m_symbolCurTag; // 0x4C
		// private LayoutSymbolData m_symbolCurStyle; // 0x50
		// private LayoutSymbolData m_symbolCurItemNum; // 0x54
		// private LayoutSymbolData m_symbolCurCountExt; // 0x58
		// private LayoutSymbolData m_symbolCurCountExtAnim; // 0x5C
		// private LayoutSymbolData m_symbolCurItemDrop; // 0x60
		// private LayoutSymbolData m_symbolCurTimeLimited; // 0x64
		// private LayoutSymbolData m_symbolUnitLiveStyle; // 0x68
		// private LayoutSymbolData m_symbolCurWeekRecovery; // 0x6C
		// private LayoutSymbolData m_symbolCurStep; // 0x70
		// private LayoutSymbolData m_symbolScroll; // 0x74
		// private MusicSelectCDSelect.StyleType m_styleType; // 0x78
		// private LayoutSymbolData symbolCurMain; // 0x7C
		// private LayoutSymbolData symbolCurTag; // 0x80
		// private LayoutSymbolData symbolCurStyle; // 0x84
		// private LayoutSymbolData symbolCurItemNum; // 0x88
		// private LayoutSymbolData symbolCurCountExt; // 0x8C
		// private LayoutSymbolData symbolCurCountExtAnim; // 0x90
		// private LayoutSymbolData symbolCurItemDrop; // 0x94
		// private LayoutSymbolData symbolCurTimeLimited; // 0x98
		// private LayoutSymbolData symbolUnitLiveStyle; // 0x9C
		// private LayoutSymbolData symbolCurWeekRecovery; // 0xA0
		// private LayoutSymbolData symbolCurStep; // 0xA4
		// private MusicSelectCDCursor usingCursor; // 0xA8
		// private AbsoluteLayout m_eventRankingLayout; // 0xAC
		// private AbsoluteLayout m_eventGoDivaExpBonusLayout; // 0xB0
		// private AbsoluteLayout m_eventGoDivaRankingLayout; // 0xB4
		// private AbsoluteLayout m_eventGoDivaExpLayout; // 0xB8
		// private List<int> m_eventItemId = new List<int>; // 0xBC
		// private bool m_isShow; // 0xE4

		public Action onClickEventDetailButton { private get; set; } // 0xC0
		public Action<int> onClickFlowButton { private get; set; } // 0xC4
		// private Action<int> onClickUnitButton { private get; set; } // 0xC8
		public MusicSelectCDSelect.SelectionChangedCallback onSelectionChanged { private get; set; } // 0xCC
		public MusicSelectCDSelect.ScrollRepeatedCallback onScrollRepeated { private get; set; } // 0xD0
		public Action<bool> onScrollStarted { private get; set; } // 0xD4
		public Action<bool> onScrollUpdated { private get; set; } // 0xD8
		public Action<bool> onScrollEnded { private get; set; } // 0xDC
		public Action onClickPlayButton { private get; set; } // 0xE0

		// // RVA: 0x167015C Offset: 0x167015C VA: 0x167015C
		// public void TryEnter() { }

		// // RVA: 0x1670208 Offset: 0x1670208 VA: 0x1670208
		public void TryLeave()
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout TryLeave");
		}

		// // RVA: 0x167016C Offset: 0x167016C VA: 0x167016C
		public void Enter()
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout Enter");
		}

		// // RVA: 0x1670218 Offset: 0x1670218 VA: 0x1670218
		// public void Leave() { }

		// // RVA: 0x1670314 Offset: 0x1670314 VA: 0x1670314
		// public void Show() { }

		// // RVA: 0x16703B0 Offset: 0x16703B0 VA: 0x16703B0
		public void Hide()
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout Hide");
		}

		// // RVA: 0x167044C Offset: 0x167044C VA: 0x167044C
		public bool IsPlaying()
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout IsPlaying");
			return false;
		}

		// // RVA: 0x1670478 Offset: 0x1670478 VA: 0x1670478
		public void MakeCache()
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout MakeCache");
		}

		// // RVA: 0x16704A0 Offset: 0x16704A0 VA: 0x16704A0
		// public void ReleaseCache() { }

		// // RVA: 0x16702B4 Offset: 0x16702B4 VA: 0x16702B4
		// public void ScrollEnable() { }

		// // RVA: 0x16702EC Offset: 0x16702EC VA: 0x16702EC
		// public void ScrollDisable() { }

		// // RVA: 0x16704C8 Offset: 0x16704C8 VA: 0x16704C8
		// public void SetupUnitLive(IBJAKJJICBC musicData, MMOLNAHHDOM saveData) { }

		// // RVA: 0x1670598 Offset: 0x1670598 VA: 0x1670598
		// public int GetDanceDivaCount() { }

		// // RVA: 0x16705C4 Offset: 0x16705C4 VA: 0x16705C4
		// public void RefreshJackets() { }

		// // RVA: 0x1670A84 Offset: 0x1670A84 VA: 0x1670A84
		// public void SetStyleType(MusicSelectCDSelect.StyleType type) { }

		// // RVA: 0x1670C44 Offset: 0x1670C44 VA: 0x1670C44
		// public void ApplyCursorAttr(GameAttribute.Type attr) { }

		// // RVA: 0x1670CFC Offset: 0x1670CFC VA: 0x1670CFC
		// public void ApplyCursorSLiveFrame() { }

		// // RVA: 0x1670DAC Offset: 0x1670DAC VA: 0x1670DAC
		// public void ShowCursorRewardMark(bool forScore, bool forCombo, bool forClearCount) { }

		// // RVA: 0x1670E7C Offset: 0x1670E7C VA: 0x1670E7C
		// public void HideCursorRewardMark() { }

		// // RVA: 0x1670F2C Offset: 0x1670F2C VA: 0x1670F2C
		// public void ApplyCursorEventType(MusicSelectCDSelect.EventType type, bool simulation = False) { }

		// // RVA: 0x1671064 Offset: 0x1671064 VA: 0x1671064
		// public void ApplyCursorEventStyle(MusicSelectCDSelect.EventStyle style, bool isEventEntrance = False) { }

		// // RVA: 0x167121C Offset: 0x167121C VA: 0x167121C
		// public void ApplyDropItemType(MusicSelectCDSelect.DropType type) { }

		// // RVA: 0x1671318 Offset: 0x1671318 VA: 0x1671318
		// public void ApplyCursorEventRemainCount(int remainCount, bool isExtented = False) { }

		// // RVA: 0x16714E4 Offset: 0x16714E4 VA: 0x16714E4
		// public void ApplyCursorNew(bool isNew) { }

		// // RVA: 0x167159C Offset: 0x167159C VA: 0x167159C
		// public void ApplyCursorWeekRecoveryIcon(bool isShow) { }

		// // RVA: 0x1671634 Offset: 0x1671634 VA: 0x1671634
		// public void ApplyCursorStepCount(int count) { }

		// // RVA: 0x16716FC Offset: 0x16716FC VA: 0x16716FC
		// public void ApplyEventItems(List<int> itemIdList) { }

		// // RVA: 0x16718F0 Offset: 0x16718F0 VA: 0x16718F0
		// public void ApplyEventEndMessage(string message) { }

		// // RVA: 0x1671940 Offset: 0x1671940 VA: 0x1671940
		// public void ApplyEventCounting(bool isCounting) { }

		// // RVA: 0x1671970 Offset: 0x1671970 VA: 0x1671970
		// public void ApplyEventRemainTimePrefix(string prefix) { }

		// // RVA: 0x16719C0 Offset: 0x16719C0 VA: 0x16719C0
		// public void ApplyEventRemainTime(string time) { }

		// // RVA: 0x1671A98 Offset: 0x1671A98 VA: 0x1671A98
		// public void ApplyEventBonus(int percent) { }

		// // RVA: 0x1671B50 Offset: 0x1671B50 VA: 0x1671B50
		// public void ApplyMusicRatio(int ratio, bool isVisible) { }

		// // RVA: 0x1671C2C Offset: 0x1671C2C VA: 0x1671C2C
		// public void SetEventTicketIcon(IiconTexture image) { }

		// // RVA: 0x1671CE4 Offset: 0x1671CE4 VA: 0x1671CE4
		// public void EventTicketEnable(bool _enable) { }

		// // RVA: 0x1671D14 Offset: 0x1671D14 VA: 0x1671D14
		// public void SetEventItemIcon(IiconTexture image) { }

		// // RVA: 0x1671DCC Offset: 0x1671DCC VA: 0x1671DCC
		// public void ApplyEventTicketCount(int count) { }

		// // RVA: 0x1671EA8 Offset: 0x1671EA8 VA: 0x1671EA8
		// public void ApplyEventRank(int rank) { }

		// // RVA: 0x1671F60 Offset: 0x1671F60 VA: 0x1671F60
		// public void ApplyCursorLimited(bool isLimited) { }

		// // RVA: 0x1672040 Offset: 0x1672040 VA: 0x1672040
		// public void EnableEventMusicRank(bool isEnable) { }

		// // RVA: 0x16720D4 Offset: 0x16720D4 VA: 0x16720D4
		// public void ApplyEventMusicRank(int rank) { }

		// // RVA: 0x167218C Offset: 0x167218C VA: 0x167218C
		// public void EnableEventGoDivaExpBonus(bool isEnable) { }

		// // RVA: 0x1672220 Offset: 0x1672220 VA: 0x1672220
		// public void ApplyEventGoDivaExpBonus(float bonus) { }

		// // RVA: 0x16722D8 Offset: 0x16722D8 VA: 0x16722D8
		// public void EnableEventGoDivaRanking(bool isEnable) { }

		// // RVA: 0x167236C Offset: 0x167236C VA: 0x167236C
		// public void ApplyEventGoDivaRank(int rank) { }

		// // RVA: 0x1672424 Offset: 0x1672424 VA: 0x1672424
		// public void SetEventGoDivaExpType(ExpType expType) { }

		// // RVA: 0x16724C4 Offset: 0x16724C4 VA: 0x16724C4
		// public void HideEventFoDivaExp() { }

		// // RVA: 0x16724CC Offset: 0x16724CC VA: 0x16724CC
		// public void ApplyEventGoDivaExp(int exp) { }

		// // RVA: 0x1672584 Offset: 0x1672584 VA: 0x1672584
		// public void ChangeJacket(int order, int jacketId, GameAttribute.Type attr, bool forEvent = False) { }

		// // RVA: 0x16727D8 Offset: 0x16727D8 VA: 0x16727D8
		// public void HideJacket(int order) { }

		// // RVA: 0x16729DC Offset: 0x16729DC VA: 0x16729DC
		// public void RequestLeftFlow(int pageOffset, float flowSec, Action onEnd) { }

		// // RVA: 0x1672A24 Offset: 0x1672A24 VA: 0x1672A24
		// public void RequestRightFlow(int pageOffset, float flowSec, Action onEnd) { }

		// // RVA: 0x1672A6C Offset: 0x1672A6C VA: 0x1672A6C
		// public void SetScrollLimit(int leftLimitPage, int rightLimitPage) { }

		// // RVA: 0x1672AD0 Offset: 0x1672AD0 VA: 0x1672AD0
		// public void ClearScrollLimit() { }

		// // RVA: 0x1672B04 Offset: 0x1672B04 VA: 0x1672B04
		// public bool CheckLeftLimitPage() { }

		// // RVA: 0x1672B5C Offset: 0x1672B5C VA: 0x1672B5C
		// public bool CheckRightLimitPage() { }

		// // RVA: 0x1672BB4 Offset: 0x1672BB4 VA: 0x1672BB4
		// public void SetPlayButtonType(MusicSelectCDSelect.PlayButtonType type) { }

		// // RVA: 0x1672CF8 Offset: 0x1672CF8 VA: 0x1672CF8
		// public void SetPlayButtonDisable(bool isDisable) { }

		// // RVA: 0x1672D2C Offset: 0x1672D2C VA: 0x1672D2C
		// public void EnterPlayButton(bool immediate = False) { }

		// // RVA: 0x1672DC4 Offset: 0x1672DC4 VA: 0x1672DC4
		// public void LeavePlayButton(bool immediate = False) { }

		// // RVA: 0x1672E5C Offset: 0x1672E5C VA: 0x1672E5C
		// public void SetNeedEnergy(int energy) { }

		// // RVA: 0x1672E8C Offset: 0x1672E8C VA: 0x1672E8C
		// private void OnSelectionChanged(int offset) { }

		// // RVA: 0x1673300 Offset: 0x1673300 VA: 0x1673300
		// public void OnScrollRepeated(int repeatDelta, bool isSelectionFlipped) { }

		// // RVA: 0x167333C Offset: 0x167333C VA: 0x167333C
		// public void OnScrollStarted(bool isAuto) { }

		// // RVA: 0x16733D4 Offset: 0x16733D4 VA: 0x16733D4
		// public void OnScrollUpdated(bool isAuto) { }

		// // RVA: 0x1673448 Offset: 0x1673448 VA: 0x1673448
		// public void OnScrollEnded(bool isAuto) { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F344C Offset: 0x6F344C VA: 0x6F344C
		// // RVA: 0x16734E0 Offset: 0x16734E0 VA: 0x16734E0
		// private IEnumerator Co_Initialize() { }

		// [IteratorStateMachineAttribute] // RVA: 0x6F34C4 Offset: 0x6F34C4 VA: 0x6F34C4
		// // RVA: 0x1671848 Offset: 0x1671848 VA: 0x1671848
		// private IEnumerator Co_LoadItemImages(List<int> itemIdList) { }

		// // RVA: 0x16735AC Offset: 0x16735AC VA: 0x16735AC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout MusicSelectCDSelect");
			return true;
		}

		// [CompilerGeneratedAttribute] // RVA: 0x6F353C Offset: 0x6F353C VA: 0x6F353C
		// // RVA: 0x1673DE0 Offset: 0x1673DE0 VA: 0x1673DE0
		// private void <SetupUnitLive>b__99_0(MusicSelectUnitButton.Style style) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F354C Offset: 0x6F354C VA: 0x6F354C
		// // RVA: 0x1673ECC Offset: 0x1673ECC VA: 0x1673ECC
		// private void <Co_Initialize>b__154_0() { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F355C Offset: 0x6F355C VA: 0x6F355C
		// // RVA: 0x1673EE0 Offset: 0x1673EE0 VA: 0x1673EE0
		// private void <Co_Initialize>b__154_1(int offset) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6F356C Offset: 0x6F356C VA: 0x6F356C
		// // RVA: 0x1673F54 Offset: 0x1673F54 VA: 0x1673F54
		// private void <InitializeFromLayout>b__156_0() { }
	}
}
