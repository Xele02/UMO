using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class HelpButton : LayoutUGUIScriptBase
	{
		[SerializeField]
		private ActionButton m_button; // 0x14
		// [CompilerGeneratedAttribute] // RVA: 0x66FD20 Offset: 0x66FD20 VA: 0x66FD20
		public UnityAction<int, int> HelpButtonListener; // 0x18
		private RectTransform m_rectTransform; // 0x1C
		private int m_searchId; // 0x20
		private int m_callHelpId; // 0x24
		private AbsoluteLayout m_buttonAnimLayout; // 0x28
		private bool m_isShow; // 0x2C
		private int m_blockCount; // 0x30
		private int m_pattern; // 0x34
		// private HelpButton.State m_state; // 0x38
		// private OHCAABOMEOF.KGOGMKMBCPP m_eventType; // 0x3C
		// private VeiwOptionHelpCategoryData m_helpCategory; // 0x40
		private const int ResultButtonPattern = 3;
		private const int ResultSearchId = 106;
		private const int RaidResultSearchId = 128;
		private const int VerticalMusicSelectSearchId = 102;
		public const int LuckyLeafPopupHelpSearchId = 113;
		public const int MusicRateHelpSearchId = 119;
		// private readonly HelpButton.HelpInfo MissionEventhelpPattern; // 0x44
		// private Dictionary<OHCAABOMEOF.KGOGMKMBCPP, int> m_eventHelpIdDict; // 0x50
		// private Dictionary<int, HelpButton.HelpInfo> ButtonDispPlaceDict; // 0x54
		// private Vector2[] AnchorPosTbl; // 0x58
		// private Vector2[] PivotTbl; // 0x5C

		// [CompilerGeneratedAttribute] // RVA: 0x6E1A6C Offset: 0x6E1A6C VA: 0x6E1A6C
		// // RVA: 0xE301F8 Offset: 0xE301F8 VA: 0xE301F8
		// public void add_HelpButtonListener(UnityAction<int, int> value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x6E1A7C Offset: 0x6E1A7C VA: 0x6E1A7C
		// // RVA: 0xE30304 Offset: 0xE30304 VA: 0xE30304
		// public void remove_HelpButtonListener(UnityAction<int, int> value) { }

		// RVA: 0xE30410 Offset: 0xE30410 VA: 0xE30410 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			UnityEngine.Debug.LogError("TODO InitializeFromLayout HelpButton");
			return true;	
		}

		// // RVA: 0xE30560 Offset: 0xE30560 VA: 0xE30560
		public void TryShow(TransitionList.Type transitionName)
		{
			UnityEngine.Debug.LogError("TODO TryShow HelpButton");
		}

		// // RVA: 0xE306A4 Offset: 0xE306A4 VA: 0xE306A4
		// public static int FindHelpUniqueId(int searchId) { }

		// // RVA: 0xE30C24 Offset: 0xE30C24 VA: 0xE30C24
		// public void ShowMusicSelectHelpButton() { }

		// // RVA: 0xE30C6C Offset: 0xE30C6C VA: 0xE30C6C
		// public void ShowResultHelpButton() { }

		// // RVA: 0xE30CB4 Offset: 0xE30CB4 VA: 0xE30CB4
		// public void ShowRaidResultHelpButton() { }

		// // RVA: 0xE30CFC Offset: 0xE30CFC VA: 0xE30CFC
		// public void HideResultHelpButton() { }

		// // RVA: 0xE30D00 Offset: 0xE30D00 VA: 0xE30D00
		// public void ShowMissiontEventHelpButton() { }

		// // RVA: 0xE30DC4 Offset: 0xE30DC4 VA: 0xE30DC4
		// public void HideMissionEventHelpButton() { }

		// // RVA: 0xE30DC8 Offset: 0xE30DC8 VA: 0xE30DC8
		// public void HideEventHelpButton() { }

		// // RVA: 0xE30DCC Offset: 0xE30DCC VA: 0xE30DCC
		// public void HideOfferHelpButton() { }

		// // RVA: 0xE30DD0 Offset: 0xE30DD0 VA: 0xE30DD0
		// public void HideDecoStorageHelpButton() { }

		// // RVA: 0xE30DD4 Offset: 0xE30DD4 VA: 0xE30DD4
		public void TryHide(TransitionList.Type transitionName)
		{
			UnityEngine.Debug.LogError("TODO Help TryHide");
		}

		// // RVA: 0xE30964 Offset: 0xE30964 VA: 0xE30964
		// private void Show(int pattern) { }

		// // RVA: 0xE30B7C Offset: 0xE30B7C VA: 0xE30B7C
		// private void Hide() { }

		// // RVA: 0xE30EB0 Offset: 0xE30EB0 VA: 0xE30EB0
		// public void TryEnter() { }

		// // RVA: 0xE30F5C Offset: 0xE30F5C VA: 0xE30F5C
		// public void TryLeave() { }

		// // RVA: 0xE31008 Offset: 0xE31008 VA: 0xE31008
		// public void SetEnable() { }

		// // RVA: 0xE31058 Offset: 0xE31058 VA: 0xE31058
		// public void SetDisable() { }

		// // RVA: 0xE31098 Offset: 0xE31098 VA: 0xE31098
		// private void OnPushHelpButton() { }

		// // RVA: 0xE31158 Offset: 0xE31158 VA: 0xE31158
		// public void AddEventHelpId(OHCAABOMEOF.KGOGMKMBCPP type, int helpId) { }

		// RVA: 0xE311E0 Offset: 0xE311E0 VA: 0xE311E0
		public HelpButton()
		{
			UnityEngine.Debug.LogError("TODO HelpButton()");
		}
	}
}
