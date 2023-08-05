using XeSys.Gfx;
using System;
using UnityEngine.Events;
using UnityEngine;
using XeApp.Game.Common;
using UnityEngine.UI;
using System.Text;
using System.Collections.Generic;
using XeSys;
using mcrs;

namespace XeApp.Game.Menu
{
	public class SortMenuWindow : LayoutUGUIScriptBase
	{
		public enum SortTitle
		{
			Sort = 1,
			Status = 2,
		}

		public enum FilterType
		{
			Rare = 0,
			Attribute = 1,
			Series = 2,
			CenterSkill = 3,
			CompatibleDiva = 4,
			Interior = 5,
		}

		[Serializable]
		public class SortButtonEvent : UnityEvent<int> { }

		[Serializable]
		public class FilterButtonEvent : UnityEvent<uint> { }

		[Serializable]
		public class CompatibleDivaButtonEvent : UnityEvent<bool> { }

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
		private List<int> m_divaIdList = new List<int>(); // 0xA4
		private StringBuilder m_strBuilder = new StringBuilder(64); // 0xA8
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

		public SortMenuWindow.SortButtonEvent PushSortButtonEvent { get { return m_pushSortButtonEvent; } } //0x12D7004
		public SortMenuWindow.SortButtonEvent PushAssistButtonEvent { get { return m_pushAssistButtonEvent; } } //0x12D700C
		public SortMenuWindow.FilterButtonEvent PushRareButtonEvent { get { return m_pushRareButtonEvent; } } //0x12D7014
		public SortMenuWindow.FilterButtonEvent PushAttributeButtonEvent { get { return m_pushAttributeButtonEvent; } } //0x12D701C
		public SortMenuWindow.FilterButtonEvent PushSeriesButtonEvent { get { return m_pushSeriesButtonEvent; } } //0x12D7024
		public SortMenuWindow.FilterButtonEvent PushCenterSkillButtonEvent { get { return m_pushCenterSkillButtonEvent; } } //0x12D702C
		public SortMenuWindow.FilterButtonEvent PushDivaButtonEvent { get { return m_pushDivaButtonEvent; } } //0x12D7034
		public SortMenuWindow.FilterButtonEvent PushInteriorButtonEvent { get { return m_pushInteriorButtonEvent; } } //0x12D703C
		public SortMenuWindow.CompatibleDivaButtonEvent PushCompatibleDivaButtonEvent { get { return m_pushComatibleDivaButtonEvent; } } //0x12D7044

		//// RVA: 0x12D704C Offset: 0x12D704C VA: 0x12D704C
		//private bool SearchRarityFilterButton(string name) { }

		//// RVA: 0x12D71B8 Offset: 0x12D71B8 VA: 0x12D71B8
		public static string GetSortLabelUv(SortItem sortItem)
		{
			return m_sortLabelUvTbl[(int)sortItem];
		}

		//// RVA: 0x12D727C Offset: 0x12D727C VA: 0x12D727C
		//public static void ApplySortLabelTexture(RawImageEx image, SortItem item) { }

		//// RVA: g Offset: 0x12D7354 VA: 0x12D7354 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_uvMan = uvMan;
			m_filterAnimeLayout = layout.FindViewByExId("root_deck_sort_swtbl_sort_filter") as AbsoluteLayout;
			m_childfilterAnimeLayout = layout.FindViewByExId("swtbl_sort_filter_filter_all") as AbsoluteLayout;
			m_sortButtonLayout = layout.FindViewByExId("swtbl_sort_filter_sw_sort") as AbsoluteLayout;
			m_sortGroupButton.OnSelectToggleButtonEvent.AddListener(OnPushSortButton);
			m_assistGroupButton.OnSelectToggleButtonEvent.AddListener(OnPushAssistButton);
			m_resetButton.AddOnClickCallback(OnFilterReset);
			SetFilterButtonEvent(m_rareFilterToggleButtons, m_pushRareButtonEvent);
			SetFilterButtonEvent(m_attributeToggleButtons, m_pushAttributeButtonEvent);
			SetFilterButtonEvent(m_seriesToggleButtons, m_pushSeriesButtonEvent);
			SetFilterButtonEvent(m_centerSkillToggleButtons, m_pushCenterSkillButtonEvent);
			m_compatibleToggleButton.AddOnClickCallback(OnPushCompatibleButton);
			SetCimpatibleDivaFilterButtonEvent(m_divaToggleButtons, m_pushDivaButtonEvent);
			SetFilterButtonEvent(m_InteriorToggleButtons, m_pushInteriorButtonEvent);
			m_divaCompatibleLayout = layout.FindViewByExId("swtbl_sort_filter_swtbl_filter_compatibility") as AbsoluteLayout;
			for(int i = 0; i < m_rareIconImages.Length; i++)
			{
				m_rareIconImages[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(RARITYFILTERTABLE[i]));
			}
			for(int i = 0; i < m_seriesIconImages.Length; i++)
			{
				m_seriesIconImages[i].enabled = false;
				int index = i;
				GameManager.Instance.MenuResidentTextureCache.LoadLogo((4 - i) > 0 ? (4 - i) : 11, (IiconTexture texture) =>
				{
					//0x12DC360
					if(m_seriesIconImages[index] == null)
						return;
					m_seriesIconImages[index].enabled = true;
					texture.Set(m_seriesIconImages[index]);
				});
			}
			for(int i = 0; i < m_centerSkillIconImages.Length; i++)
			{
				m_centerSkillIconImages[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_centerSkillUvTbl[i]));
			}
			for(int i = 0; i < m_interiorIconImages.Length; i++)
			{
				m_strBuilder.Clear();
				m_strBuilder.AppendFormat("cmn_btn_sort_fnt_4{0}", i + 1);
				m_interiorIconImages[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_strBuilder.ToString()));
			}
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			m_compatibleText.text = bk.GetMessageByLabel("popup_sort_text_00");
			m_assistText.text = bk.GetMessageByLabel("assist_friend_select_caution_01");
			m_sortTitleLayout = layout.FindViewByExId("swtbl_sort_filter_sw_sort_title") as AbsoluteLayout;
			Loaded();
			ClearLoadedCallback();
			return true;
		}

		//// RVA: 0x12D84B8 Offset: 0x12D84B8 VA: 0x12D84B8
		public void SetSortLabel(int index, SortItem item, bool isFriend = false)
		{
			m_sortItemLabel[index].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_sortLabelUvTbl[(int)item]));
		}

		//// RVA: 0x12D8664 Offset: 0x12D8664 VA: 0x12D8664
		public void SetAssistSlotLabel()
		{
			for(int i = 0; i < m_assistSlotLabel.Length; i++)
			{
				m_assistSlotLabel[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_uvMan.GetUVData(m_assistSlotUvTbl[i]));
			}
		}

		//// RVA: 0x12D8854 Offset: 0x12D8854 VA: 0x12D8854
		//public void SelectedDivaId(int divaId) { }

		//// RVA: 0x12D8958 Offset: 0x12D8958 VA: 0x12D8958
		public void SetSelectSortButton(int index, bool isFriend = false)
		{
			m_sortGroupButton.SelectGroupButton(index);
		}

		//// RVA: 0x12D898C Offset: 0x12D898C VA: 0x12D898C
		public void SetSortButtonEnable(int index, bool isFriend = false)
		{
			m_sortToggleButtons[index].Hidden = false;
			m_sortItemLabel[index].enabled = true;
		}

		//// RVA: 0x12D8A50 Offset: 0x12D8A50 VA: 0x12D8A50
		public void SetSortButtonDisable(int index, bool isFriend = false)
		{
			m_sortToggleButtons[index].Hidden = true;
			m_sortItemLabel[index].enabled = false;
		}

		//// RVA: 0x12D8B14 Offset: 0x12D8B14 VA: 0x12D8B14
		public void SetSelectAssistButton(int index)
		{
			m_assistGroupButton.SelectGroupButton(index);
		}

		//// RVA: 0x12D8B48 Offset: 0x12D8B48 VA: 0x12D8B48
		//public void ShowFilter(bool isShowCompatibleCheck, bool isFriend = False) { }

		//// RVA: 0x12D8D70 Offset: 0x12D8D70 VA: 0x12D8D70
		//public void ShowDecoFilter(bool isDecoShopInterior = False) { }

		//// RVA: 0x12D8E68 Offset: 0x12D8E68 VA: 0x12D8E68
		public void ShowAssistSelectFilter()
		{
			m_filterAnimeLayout.StartChildrenAnimGoStop("05");
			m_sortButtonLayout.StartChildrenAnimGoStop("04");
			m_childfilterAnimeLayout.StartChildrenAnimGoStop("04");
			(transform as RectTransform).sizeDelta = new Vector2((transform as RectTransform).sizeDelta.x, 925);
		}

		//// RVA: 0x12D8FD4 Offset: 0x12D8FD4 VA: 0x12D8FD4
		//public void ShowAssistEditFilter(int attrId) { }

		//// RVA: 0x12D9174 Offset: 0x12D9174 VA: 0x12D9174
		public void HideFilter()
		{
			m_filterAnimeLayout.StartChildrenAnimGoStop("01");
			m_sortButtonLayout.StartChildrenAnimGoStop("01");
			m_childfilterAnimeLayout.StartChildrenAnimGoStop("01");
		}

		//// RVA: 0x12D9250 Offset: 0x12D9250 VA: 0x12D9250
		//public void SetDivaButtonIcon(List<FFHPBEPOMAK> divaList) { }

		//// RVA: 0x12D9710 Offset: 0x12D9710 VA: 0x12D9710
		//public void SetFilterButton(SortMenuWindow.FilterType type, uint bit) { }

		//// RVA: 0x12D9A30 Offset: 0x12D9A30 VA: 0x12D9A30
		//public void SetDivaFilterButton(uint bit) { }

		//// RVA: 0x12D9C00 Offset: 0x12D9C00 VA: 0x12D9C00
		//public void SetCompatibleDivaButtonState(bool isOn) { }

		//// RVA: 0x12D9E18 Offset: 0x12D9E18 VA: 0x12D9E18
		private void OnPushSortButton(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_pushSortButtonEvent.Invoke(index);
		}

		//// RVA: 0x12D9EE4 Offset: 0x12D9EE4 VA: 0x12D9EE4
		private void OnPushAssistButton(int index)
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			m_pushAssistButtonEvent.Invoke(index);
		}

		//// RVA: 0x12D9FB0 Offset: 0x12D9FB0 VA: 0x12D9FB0
		private void OnFilterReset()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			PushFilterButton(0, m_rareFilterToggleButtons);
			PushFilterButton(0, m_attributeToggleButtons);
			PushFilterButton(0, m_seriesToggleButtons);
			PushFilterButton(0, m_centerSkillToggleButtons);
			PushFilterButton(0, m_InteriorToggleButtons);
			PushFilterButton(0, m_divaToggleButtons);
			m_compatibleToggleButton.SetOff();

			m_pushRareButtonEvent.Invoke(0);
			m_pushAttributeButtonEvent.Invoke(0);
			m_pushSeriesButtonEvent.Invoke(0);
			m_pushCenterSkillButtonEvent.Invoke(0);
			m_pushDivaButtonEvent.Invoke(0);
			m_pushInteriorButtonEvent.Invoke(0);
			m_pushComatibleDivaButtonEvent.Invoke(false);
		}

		//// RVA: 0x12D8088 Offset: 0x12D8088 VA: 0x12D8088
		private void SetFilterButtonEvent(ToggleButton[] buttons, FilterButtonEvent buttonEvent)
		{
			for(int i = 0; i < buttons.Length; i++)
			{
				int index = i;
				buttons[i].AddOnClickCallback(() =>
				{
					//0x12DC764
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					PushFilterButton(index, buttons);
					buttonEvent.Invoke(GetFilterButtonBit(buttons));
				});
			}
		}

		//// RVA: 0x12D829C Offset: 0x12D829C VA: 0x12D829C
		private void SetCimpatibleDivaFilterButtonEvent(ToggleButton[] buttons, SortMenuWindow.FilterButtonEvent buttonEvent)
		{
			for(int i = 0; i < buttons.Length; i++)
			{
				int index = i;
				buttons[i].AddOnClickCallback(() =>
				{
					//0x12DC8E8
					SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
					m_compatibleToggleButton.SetOff();
					m_pushComatibleDivaButtonEvent.Invoke(false);
					PushFilterButton(index, buttons);
					buttonEvent.Invoke(GetFilterButtonBit(buttons));
				});
			}
		}

		//// RVA: 0x12DA228 Offset: 0x12DA228 VA: 0x12DA228
		private uint GetFilterButtonBit(ToggleButton[] buttons)
		{
			uint res = 0;
			for(int i = 1; i < buttons.Length; i++)
			{
				if(buttons[i].IsOn)
					res |= (uint)(1 << (i - 1));
			}
			return res;
		}

		//// RVA: 0x12D9888 Offset: 0x12D9888 VA: 0x12D9888
		private void PushFilterButton(int index, ToggleButton[] buttons)
		{
			if(index == 0)
			{
				buttons[0].SetOn();
				if(buttons.Length < 2)
					return;
				for(int i = 1; i < buttons.Length; i++)
					buttons[i].SetOff();
			}
			else
			{
				bool b = true;
				for(int i = 1; i < buttons.Length; i++)
				{
					if(buttons[i].IsOn)
					{
						b = false;
						break;
					}
				}
				if(b)
					buttons[0].SetOn();
				else
					buttons[0].SetOff();
			}
		}

		//// RVA: 0x12DA2C4 Offset: 0x12DA2C4 VA: 0x12DA2C4
		public void SetSortTitle(SortMenuWindow.SortTitle title)
		{
			m_sortTitleLayout.StartChildrenAnimGoStop(string.Format("{0:D2}", (int)title));
		}

		//// RVA: 0x12DA37C Offset: 0x12DA37C VA: 0x12DA37C
		private void OnPushCompatibleButton()
		{
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
			if(m_compatibleToggleButton.IsOn)
			{
				m_compatibleToggleButton.SetOn();
				UpdateCompatibleButton();
			}
			else
			{
				m_compatibleToggleButton.SetOff();
				PushFilterButton(0, m_divaToggleButtons);
				m_pushComatibleDivaButtonEvent.Invoke(false);
				m_pushDivaButtonEvent.Invoke(GetFilterButtonBit(m_divaToggleButtons));
			}
		}

		//// RVA: 0x12D9C60 Offset: 0x12D9C60 VA: 0x12D9C60
		private void UpdateCompatibleButton()
		{
			m_pushComatibleDivaButtonEvent.Invoke(true);
			m_divaToggleButtons[0].SetOff();
			for(int i = 1; i < m_divaToggleButtons.Length; i++)
			{
				if(i - 1 == m_selectedDivaListIndex)
					m_divaToggleButtons[i].SetOn();
				else
					m_divaToggleButtons[i].SetOff();
			}
			m_pushDivaButtonEvent.Invoke(GetFilterButtonBit(m_divaToggleButtons));
		}

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
	}
}
