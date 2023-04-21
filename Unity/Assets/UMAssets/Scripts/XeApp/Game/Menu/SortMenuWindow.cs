using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;

namespace XeApp.Game.Menu
{
	public class SortMenuWindow : LayoutUGUIScriptBase
	{
    public void Awake() { TodoLogger.Log(0, "Implement LayoutUGUIScriptBase"); }
		[Serializable]
		public class SortButtonEvent : UnityEvent<int>
		{
		}

		[Serializable]
		public class FilterButtonEvent : UnityEvent<uint>
		{
		}

		[Serializable]
		public class CompatibleDivaButtonEvent : UnityEvent<bool>
		{
		}

		// Fields
		[SerializeField]
		private RawImageEx[] m_sortItemLabel; // 0x14
		[SerializeField]
		private RawImageEx[] m_assistSlotLabel; // 0x18
		[SerializeField]
		private RawImageEx[] m_divaIconImages; // 0x1C
		[SerializeField]
		private RawImageEx[] m_rareIconImages; // 0x20
		[SerializeField]
		private RawImageEx[] m_seriesIconImages; // 0x24
		[SerializeField]
		private RawImageEx[] m_centerSkillIconImages; // 0x28
		[SerializeField]
		private RawImageEx[] m_interiorIconImages; // 0x2C
		[SerializeField]
		private ActionButton m_resetButton; // 0x30
		[SerializeField]
		private ToggleButtonGroup m_sortGroupButton; // 0x34
		[SerializeField]
		private ToggleButton[] m_sortToggleButtons; // 0x38
		[SerializeField]
		private ToggleButtonGroup m_assistGroupButton; // 0x3C
		[SerializeField]
		private ToggleButton[] m_assistToggleButtons; // 0x40
		[SerializeField]
		private ToggleButton[] m_rareFilterToggleButtons; // 0x44
		[SerializeField]
		private ToggleButton[] m_attributeToggleButtons; // 0x48
		[SerializeField]
		private ToggleButton[] m_seriesToggleButtons; // 0x4C
		[SerializeField]
		private ToggleButton[] m_centerSkillToggleButtons; // 0x50
		[SerializeField]
		private ToggleButton m_compatibleToggleButton; // 0x54
		[SerializeField]
		private ToggleButton[] m_divaToggleButtons; // 0x58
		[SerializeField]
		private ToggleButton[] m_InteriorToggleButtons; // 0x5C
		[SerializeField]
		private Text m_compatibleText; // 0x60
		[SerializeField]
		private Text m_assistText; // 0x64
		[SerializeField]
		private SortButtonEvent m_pushSortButtonEvent; // 0x68
		[SerializeField]
		private SortButtonEvent m_pushAssistButtonEvent; // 0x6C
		[SerializeField]
		private FilterButtonEvent m_pushRareButtonEvent; // 0x70
		[SerializeField]
		private FilterButtonEvent m_pushAttributeButtonEvent; // 0x74
		[SerializeField]
		private FilterButtonEvent m_pushSeriesButtonEvent; // 0x78
		[SerializeField]
		private FilterButtonEvent m_pushCenterSkillButtonEvent; // 0x7C
		[SerializeField]
		private FilterButtonEvent m_pushDivaButtonEvent; // 0x80
		[SerializeField]
		private FilterButtonEvent m_pushInteriorButtonEvent; // 0x84
		[SerializeField]
		private CompatibleDivaButtonEvent m_pushComatibleDivaButtonEvent; // 0x88
		private byte m_selectedDivaListIndex; // 0x8C
		private AbsoluteLayout m_filterAnimeLayout; // 0x90
		private AbsoluteLayout m_childfilterAnimeLayout; // 0x94
		private AbsoluteLayout m_divaCompatibleLayout; // 0x98
		private AbsoluteLayout m_sortTitleLayout; // 0x9C
		private AbsoluteLayout m_sortButtonLayout; // 0xA0
		private List<int> m_divaIdList; // 0xA4
		private StringBuilder m_strBuilder; // 0xA8
		private const int m_sceneSelectContentHeight = 1200;
		private const int m_sceneListContentHeight = 1240;
		private const int m_sceneAssistSelectContentHeight = 925;
		private const int m_sceneAssistFreeContentHeight = 815;
		private const int m_sceneAssistAttrContentHeight = 680;
		private const int m_friendContentHeight = 950;
		private TexUVListManager m_uvMan; // 0xAC
		private static readonly string[] RARITYFILTERTABLE = new string[7] {
			"cmn_btn_sort_fnt_21", "cmn_btn_sort_fnt_22", "cmn_btn_sort_fnt_23", "cmn_btn_sort_fnt_24",
			"cmn_btn_sort_fnt_25", "cmn_btn_sort_fnt_26", "cmn_btn_sort_fnt_47"}; // 0x0
		private static readonly string[] m_centerSkillUvTbl = new string[4] {
			"cmn_skill_rank_icon_02", "cmn_skill_rank_icon_03", "cmn_skill_rank_icon_04", "cmn_skill_rank_icon_05"
		}; // 0x4
		private static readonly string[] m_sortLabelUvTbl = new string[48] {
			"cmn_btn_sort_fnt_27", "cmn_btn_sort_fnt_02", "cmn_btn_sort_fnt_03", "cmn_btn_sort_fnt_04",
			"cmn_btn_sort_fnt_05", "cmn_btn_sort_fnt_06", "cmn_btn_sort_fnt_07", "cmn_btn_sort_fnt_08",
			"cmn_btn_sort_fnt_11", "cmn_btn_sort_fnt_09", "cmn_btn_sort_fnt_10", "cmn_btn_sort_fnt_12",
			"cmn_btn_sort_fnt_13", "cmn_btn_sort_fnt_14", "cmn_btn_sort_fnt_15", "cmn_btn_sort_fnt_16",
			"cmn_btn_sort_fnt_28", "cmn_btn_sort_fnt_29", "cmn_btn_sort_fnt_30", "cmn_btn_sort_fnt_31",
			"cmn_btn_sort_fnt_32", "cmn_btn_sort_fnt_33", "cmn_btn_sort_fnt_34", "cmn_btn_sort_fnt_01",
			"cmn_btn_sort_fnt_35", "cmn_btn_sort_fnt_47", "cmn_btn_sort_fnt_36", "cmn_btn_sort_fnt_37",
			"cmn_btn_sort_fnt_38", "cmn_btn_sort_fnt_39", "cmn_btn_sort_fnt_45", "cmn_btn_sort_fnt_46",
			"cmn_btn_sort_fnt_44", "cmn_btn_sort_fnt_45", "cmn_btn_sort_fnt_46", "cmn_btn_sort_fnt_47",
			"cmn_btn_sort_fnt_48", "sel_card_sort_fnt_filter", "", "", "", "", "", "", "", "", "",
			"cmn_btn_sort_fnt_48"
		}; // 0x8
		private static readonly string[] m_assistSlotUvTbl = new string[5] {
			"cmn_btn_sort_fnt_48", "cmn_btn_sort_fnt_18", "cmn_btn_sort_fnt_19", "cmn_btn_sort_fnt_20",
			"cmn_btn_sort_fnt_49"
		}; // 0xC

		//public SortMenuWindow.SortButtonEvent PushSortButtonEvent { get; }
		//public SortMenuWindow.SortButtonEvent PushAssistButtonEvent { get; }
		//public SortMenuWindow.FilterButtonEvent PushRareButtonEvent { get; }
		//public SortMenuWindow.FilterButtonEvent PushAttributeButtonEvent { get; }
		//public SortMenuWindow.FilterButtonEvent PushSeriesButtonEvent { get; }
		//public SortMenuWindow.FilterButtonEvent PushCenterSkillButtonEvent { get; }
		//public SortMenuWindow.FilterButtonEvent PushDivaButtonEvent { get; }
		//public SortMenuWindow.FilterButtonEvent PushInteriorButtonEvent { get; }
		//public SortMenuWindow.CompatibleDivaButtonEvent PushCompatibleDivaButtonEvent { get; }

		//// RVA: 0x12D7004 Offset: 0x12D7004 VA: 0x12D7004
		//public SortMenuWindow.SortButtonEvent get_PushSortButtonEvent() { }

		//// RVA: 0x12D700C Offset: 0x12D700C VA: 0x12D700C
		//public SortMenuWindow.SortButtonEvent get_PushAssistButtonEvent() { }

		//// RVA: 0x12D7014 Offset: 0x12D7014 VA: 0x12D7014
		//public SortMenuWindow.FilterButtonEvent get_PushRareButtonEvent() { }

		//// RVA: 0x12D701C Offset: 0x12D701C VA: 0x12D701C
		//public SortMenuWindow.FilterButtonEvent get_PushAttributeButtonEvent() { }

		//// RVA: 0x12D7024 Offset: 0x12D7024 VA: 0x12D7024
		//public SortMenuWindow.FilterButtonEvent get_PushSeriesButtonEvent() { }

		//// RVA: 0x12D702C Offset: 0x12D702C VA: 0x12D702C
		//public SortMenuWindow.FilterButtonEvent get_PushCenterSkillButtonEvent() { }

		//// RVA: 0x12D7034 Offset: 0x12D7034 VA: 0x12D7034
		//public SortMenuWindow.FilterButtonEvent get_PushDivaButtonEvent() { }

		//// RVA: 0x12D703C Offset: 0x12D703C VA: 0x12D703C
		//public SortMenuWindow.FilterButtonEvent get_PushInteriorButtonEvent() { }

		//// RVA: 0x12D7044 Offset: 0x12D7044 VA: 0x12D7044
		//public SortMenuWindow.CompatibleDivaButtonEvent get_PushCompatibleDivaButtonEvent() { }

		//// RVA: 0x12D704C Offset: 0x12D704C VA: 0x12D704C
		//private bool SearchRarityFilterButton(string name) { }

		//// RVA: 0x12D71B8 Offset: 0x12D71B8 VA: 0x12D71B8
		public static string GetSortLabelUv(SortItem sortItem)
		{
			return m_sortLabelUvTbl[(int)sortItem];
		}

		//// RVA: 0x12D727C Offset: 0x12D727C VA: 0x12D727C
		//public static void ApplySortLabelTexture(RawImageEx image, SortItem item) { }

		//// RVA: 0x12D7354 Offset: 0x12D7354 VA: 0x12D7354 Slot: 5
		//public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan) { }

		//// RVA: 0x12D84B8 Offset: 0x12D84B8 VA: 0x12D84B8
		//public void SetSortLabel(int index, SortItem item, bool isFriend = False) { }

		//// RVA: 0x12D8664 Offset: 0x12D8664 VA: 0x12D8664
		//public void SetAssistSlotLabel() { }

		//// RVA: 0x12D8854 Offset: 0x12D8854 VA: 0x12D8854
		//public void SelectedDivaId(int divaId) { }

		//// RVA: 0x12D8958 Offset: 0x12D8958 VA: 0x12D8958
		//public void SetSelectSortButton(int index, bool isFriend = False) { }

		//// RVA: 0x12D898C Offset: 0x12D898C VA: 0x12D898C
		//public void SetSortButtonEnable(int index, bool isFriend = False) { }

		//// RVA: 0x12D8A50 Offset: 0x12D8A50 VA: 0x12D8A50
		//public void SetSortButtonDisable(int index, bool isFriend = False) { }

		//// RVA: 0x12D8B14 Offset: 0x12D8B14 VA: 0x12D8B14
		//public void SetSelectAssistButton(int index) { }

		//// RVA: 0x12D8B48 Offset: 0x12D8B48 VA: 0x12D8B48
		//public void ShowFilter(bool isShowCompatibleCheck, bool isFriend = False) { }

		//// RVA: 0x12D8D70 Offset: 0x12D8D70 VA: 0x12D8D70
		//public void ShowDecoFilter(bool isDecoShopInterior = False) { }

		//// RVA: 0x12D8E68 Offset: 0x12D8E68 VA: 0x12D8E68
		//public void ShowAssistSelectFilter() { }

		//// RVA: 0x12D8FD4 Offset: 0x12D8FD4 VA: 0x12D8FD4
		//public void ShowAssistEditFilter(int attrId) { }

		//// RVA: 0x12D9174 Offset: 0x12D9174 VA: 0x12D9174
		//public void HideFilter() { }

		//// RVA: 0x12D9250 Offset: 0x12D9250 VA: 0x12D9250
		//public void SetDivaButtonIcon(List<FFHPBEPOMAK> divaList) { }

		//// RVA: 0x12D9710 Offset: 0x12D9710 VA: 0x12D9710
		//public void SetFilterButton(SortMenuWindow.FilterType type, uint bit) { }

		//// RVA: 0x12D9A30 Offset: 0x12D9A30 VA: 0x12D9A30
		//public void SetDivaFilterButton(uint bit) { }

		//// RVA: 0x12D9C00 Offset: 0x12D9C00 VA: 0x12D9C00
		//public void SetCompatibleDivaButtonState(bool isOn) { }

		//// RVA: 0x12D9E18 Offset: 0x12D9E18 VA: 0x12D9E18
		//private void OnPushSortButton(int index) { }

		//// RVA: 0x12D9EE4 Offset: 0x12D9EE4 VA: 0x12D9EE4
		//private void OnPushAssistButton(int index) { }

		//// RVA: 0x12D9FB0 Offset: 0x12D9FB0 VA: 0x12D9FB0
		//private void OnFilterReset() { }

		//// RVA: 0x12D8088 Offset: 0x12D8088 VA: 0x12D8088
		//private void SetFilterButtonEvent(ToggleButton[] buttons, SortMenuWindow.FilterButtonEvent buttonEvent) { }

		//// RVA: 0x12D829C Offset: 0x12D829C VA: 0x12D829C
		//private void SetCimpatibleDivaFilterButtonEvent(ToggleButton[] buttons, SortMenuWindow.FilterButtonEvent buttonEvent) { }

		//// RVA: 0x12DA228 Offset: 0x12DA228 VA: 0x12DA228
		//private uint GetFilterButtonBit(ToggleButton[] buttons) { }

		//// RVA: 0x12D9888 Offset: 0x12D9888 VA: 0x12D9888
		//private void PushFilterButton(int index, ToggleButton[] buttons) { }

		//// RVA: 0x12DA2C4 Offset: 0x12DA2C4 VA: 0x12DA2C4
		//public void SetSortTitle(SortMenuWindow.SortTitle title) { }

		//// RVA: 0x12DA37C Offset: 0x12DA37C VA: 0x12DA37C
		//private void OnPushCompatibleButton() { }

		//// RVA: 0x12D9C60 Offset: 0x12D9C60 VA: 0x12D9C60
		//private void UpdateCompatibleButton() { }

		//// RVA: 0x12DA4FC Offset: 0x12DA4FC VA: 0x12DA4FC
		public static int SortSecondPriority(GCIJNCFDNON_SceneInfo left, GCIJNCFDNON_SceneInfo right)
		{
			int res = left.JKGFBFPIMGA_Rarity - right.JKGFBFPIMGA_Rarity;
			if (res == 0)
				res = left.EKLIPGELKCL_SceneRarity - right.EKLIPGELKCL_SceneRarity;
			return res;
		}

		//// RVA: 0x12DA548 Offset: 0x12DA548 VA: 0x12DA548
		public static int SortThirdPriority(GCIJNCFDNON_SceneInfo left, GCIJNCFDNON_SceneInfo right)
		{
			return right.BCCHOBPJJKE_SceneId - left.BCCHOBPJJKE_SceneId;
		}

		//// RVA: 0x12DA588 Offset: 0x12DA588 VA: 0x12DA588
		public static int GetSameEvaluationValue(GCIJNCFDNON_SceneInfo left, GCIJNCFDNON_SceneInfo right)
		{
			int res = SortSecondPriority(right, left);
			if (res != 0)
				return res;
			return SortThirdPriority(left, right);
		}

		//// RVA: 0x12DA650 Offset: 0x12DA650 VA: 0x12DA650
		//public void .ctor() { }
	}
}
