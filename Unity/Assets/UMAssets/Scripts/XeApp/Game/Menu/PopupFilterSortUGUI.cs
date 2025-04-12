using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUI : UIBehaviour, IPopupContent
	{
		public enum Parts
		{
			Line = 0,
			Title01 = 1,
			Title02 = 2,
			Sort = 3,
			ToggleButtons = 4,
			ExclusiveToggleButtons = 5,
			CheckBoxes = 6,
			RangeSlider = 7,
			RangeSliderSingle = 8,
			FilterSeries = 9,
			FilterMusicAttr = 10,
			FilterGoDivaMusicExp = 11,
			FilterUnitLive = 12,
			FilterComb = 13,
			FilterReward = 14,
			FilterDifficulty = 15,
			FilterBonus = 16,
			FilterPlate = 17,
			FilterMusicLock = 18,
			FilterMusicBookMark = 19,
			FilterRange = 20,
			FilterMusicSelectSeries = 21,
			FilterMusicSelect = 22,
			FilterShopProduct = 23,
			Max = 24,
		}

		public enum Scene
		{
			None = -1,
			MusicSelect = 0,
			GoDivaMusicSelect = 1,
			MissionMusicSelect = 2,
			UnitDispType = 3,
			PlateSelect = 4,
			VerticalMusicSelect = 5,
			ShopProduct = 6,
			Max = 7,
		}

		private enum GoDivaMusicSelect
		{
			Filter_Title = 0,
			Filter_Difficulty_Title = 1,
			Filter_Difficulty_Button = 2,
			Filter_Difficulty_Line = 3,
			Filter_MusicLevel_Title = 4,
			Filter_MusicLevel_Slider = 5,
			Filter_MusicLevel_Line = 6,
			Filter_MusicAttr_Title = 7,
			Filter_MusicAttr_Button = 8,
			Filter_MusicAttr_Line = 9,
			Filter_Combo_Title = 10,
			Filter_Combo_Button = 11,
			Filter_Combo_Line = 12,
			Filter_Reward_Title = 13,
			Filter_Reward_Button = 14,
			Filter_Reward_Line = 15,
			Filter_MusicExp_Title = 16,
			Filter_MusicExp_Button = 17,
			Filter_MusicExp_Line = 18,
			Max = 19,
		}

		private enum MissionMusicSelect
		{
			Filter_Title = 0,
			Filter_Difficulty_Title = 1,
			Filter_Difficulty_Button = 2,
			Filter_Difficulty_Line = 3,
			Filter_MusicLevel_Title = 4,
			Filter_MusicLevel_Slider = 5,
			Filter_MusicLevel_Line = 6,
			Filter_MusicAttr_Title = 7,
			Filter_MusicAttr_Button = 8,
			Filter_MusicAttr_Line = 9,
			Filter_Combo_Title = 10,
			Filter_Combo_Button = 11,
			Filter_Combo_Line = 12,
			Filter_Reward_Title = 13,
			Filter_Reward_Button = 14,
			Filter_Reward_Line = 15,
			Filter_Unit_Title = 16,
			Filter_Unit_Button = 17,
			Filter_Unit_Line = 18,
			Filter_Bonus_Title = 19,
			Filter_Bonus_Button = 20,
			Filter_Bonus_Line = 21,
			Max = 22,
		}

		private enum MusicSelect
		{
			Filter_Title = 0,
			Filter_Difficulty_Title = 1,
			Filter_Difficulty_Button = 2,
			Filter_Difficulty_Line = 3,
			Filter_MusicLevel_Title = 4,
			Filter_MusicLevel_Slider = 5,
			Filter_MusicLevel_Line = 6,
			Filter_MusicAttr_Title = 7,
			Filter_MusicAttr_Button = 8,
			Filter_MusicAttr_Line = 9,
			Filter_Combo_Title = 10,
			Filter_Combo_Button = 11,
			Filter_Combo_Line = 12,
			Filter_Reward_Title = 13,
			Filter_Reward_Button = 14,
			Filter_Reward_Line = 15,
			Filter_Unit_Title = 16,
			Filter_Unit_Button = 17,
			Filter_Unit_Line = 18,
			Max = 19,
		}

		private enum PlateSelect
		{
			Filter_Plate = 0,
			Max = 1,
		}

		private enum ShopProduct
		{
			Filter_Shop = 0,
			Max = 1,
		}

		private enum UnitDispType
		{
			Filter_Scene_Title = 0,
			Filter_Scene_Sort = 1,
			Filter_Diva_Title = 2,
			Filter_Diva_Sort = 3,
			Max = 4,
		}

		private enum VerticalMusicSelect
		{
			Filter_MusicSelect = 0,
			Max = 1,
		}

		private Scene[] ScrollableTable = new Scene[6] {
			Scene.MusicSelect, Scene.GoDivaMusicSelect, Scene.MissionMusicSelect,
			Scene.PlateSelect, Scene.VerticalMusicSelect, Scene.ShopProduct
		}; // 0xC
		private PopupWindowControl m_parentPopupControl; // 0x10
		public PopupFilterSortUGUISetting m_setting; // 0x14
		private static readonly Parts[] GoDivaMusicSelectTable = new Parts[19]
			{
				Parts.Title01,
				Parts.Title02,
				Parts.FilterDifficulty,
				Parts.Line,
				Parts.Title02,
				Parts.RangeSliderSingle,
				Parts.Line,
				Parts.Title02,
				Parts.FilterMusicAttr,
				Parts.Line,
				Parts.Title02,
				Parts.FilterComb,
				Parts.Line,
				Parts.Title02,
				Parts.FilterReward,
				Parts.Line,
				Parts.Title02,
				Parts.FilterGoDivaMusicExp,
				Parts.Line
			}; // 0x0
		private static readonly Parts[] MissionMusicSelectTable = new Parts[22]
			{
				Parts.Title01,
				Parts.Title02,
				Parts.FilterDifficulty,
				Parts.Line,
				Parts.Title02,
				Parts.RangeSliderSingle,
				Parts.Line,
				Parts.Title02,
				Parts.FilterMusicAttr,
				Parts.Line,
				Parts.Title02,
				Parts.FilterComb,
				Parts.Line,
				Parts.Title02,
				Parts.FilterReward,
				Parts.Line,
				Parts.Title02,
				Parts.FilterUnitLive,
				Parts.Line,
				Parts.Title02,
				Parts.FilterBonus,
				Parts.Line
			}; // 0x4
		private static readonly Parts[] MusicSelectTable = new Parts[19]
			{
				Parts.Title01,
				Parts.Title02,
				Parts.FilterDifficulty,
				Parts.Line,
				Parts.Title02,
				Parts.RangeSliderSingle,
				Parts.Line,
				Parts.Title02,
				Parts.FilterMusicAttr,
				Parts.Line,
				Parts.Title02,
				Parts.FilterComb,
				Parts.Line,
				Parts.Title02,
				Parts.FilterReward,
				Parts.Line,
				Parts.Title02,
				Parts.FilterUnitLive,
				Parts.Line,
			}; // 0x8
		private static readonly Parts[] PlateSelectTable = new Parts[1]
			{
				Parts.FilterPlate
			}; // 0xC
		private RectTransform m_plateFilterContent; // 0x1C
		private PopupFilterSortUGUIParts_PlateFilter m_plateFilterParts; // 0x20
		private RectTransform m_plateFilterPartsRect; // 0x24
		private static readonly Parts[] ShopProductTable = new Parts[1]
			{
				Parts.FilterShopProduct
			}; // 0x10
		private RectTransform m_shopProductContent; // 0x28
		private PopupFilterSortUGUIParts_ShopProduct m_shopProductParts; // 0x2C
		private RectTransform m_shopProductPartsRect; // 0x30
		private static readonly Parts[] UnitDispTypeTable = new Parts[4]
			{
				Parts.Title01,
				Parts.Sort,
				Parts.Title01,
				Parts.Sort
			}; // 0x14
		private static readonly Parts[] VerticalMusicSelectTable = new Parts[1]
			{
				Parts.FilterMusicSelect
			}; // 0x18

		public Transform Parent { get; private set; } // 0x18

		//// RVA: 0x1C8EB3C Offset: 0x1C8EB3C VA: 0x1C8EB3C
		public static Parts[] GetPartsTable(Scene a_type)
		{
			switch(a_type)
			{
				case Scene.MusicSelect:
					return MusicSelectTable;
				case Scene.GoDivaMusicSelect:
					return GoDivaMusicSelectTable;
				case Scene.MissionMusicSelect:
					return MissionMusicSelectTable;
				case Scene.UnitDispType:
					return UnitDispTypeTable;
				case Scene.PlateSelect:
					return PlateSelectTable;
				case Scene.VerticalMusicSelect:
					return VerticalMusicSelectTable;
				case Scene.ShopProduct:
					return ShopProductTable;
			}
			return null;
		}

		// RVA: 0x1C8EDB8 Offset: 0x1C8EDB8 VA: 0x1C8EDB8 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_parentPopupControl = control;
			m_setting = setting as PopupFilterSortUGUISetting;
			Parent = setting.m_parent;
			switch(m_setting.m_param.Scene)
			{
				case Scene.MusicSelect:
					InitializeMusicSelect();
					break;
				case Scene.GoDivaMusicSelect:
					InitializeGoDivaMusicSelect();
					break;
				case Scene.MissionMusicSelect:
					InitializeMissionMusicSelect();
					break;
				case Scene.UnitDispType:
					InitializeUnitDispType();
					break;
				case Scene.PlateSelect:
					if (MenuScene.Instance.GetCurrentTransitionRoot().TransitionName == TransitionList.Type.SCENE_SELECT)
						InitializePlateSelect();
					else if (((int)MenuScene.Instance.GetCurrentTransitionRoot().TransitionName & 0xfffffffe) != 104)
						InitializePlateSelectList();
					break;
				case Scene.VerticalMusicSelect:
					InitializeVerticalMusicSelect();
					break;
				case Scene.ShopProduct:
					InitializeShopProductList();
					break;
			}
			float f = 0;
			float f2 = 0;
			for(int i = 0; i < m_setting.m_list_parts.Count; i++)
			{
				if(m_setting.m_list_parts[i].m_base.gameObject.activeSelf)
				{
					m_setting.m_list_parts[i].m_base.gameObject.transform.localPosition = new Vector3(0, -f, 0);
					Rect r = m_setting.m_list_parts[i].m_base.GetGuidSize().rect;
					f += r.height;
					if(f2 < r.width)
					{
						f2 = r.width;
					}
				}
			}
			RectTransform rt = gameObject.GetComponent<RectTransform>();
			if (rt == null)
				rt = gameObject.AddComponent<RectTransform>();
			rt.sizeDelta = new Vector2(f2, f);
			rt.anchorMin = new Vector2(0, 1);
			rt.anchorMax = new Vector2(0, 1);
			rt.pivot = new Vector2(0, 1);
			rt.anchoredPosition3D = new Vector3(0, 0, 0);
			if(m_setting.m_param.Scene == Scene.PlateSelect)
				m_plateFilterContent = rt;
			else if(m_setting.m_param.Scene == Scene.ShopProduct)
				m_shopProductContent = rt;
		}

		// RVA: 0x1C961BC Offset: 0x1C961BC VA: 0x1C961BC
		public void Fainalize()
		{
			switch(m_setting.m_param.Scene)
			{
				case Scene.MusicSelect:
					FinalizeMusicSelect();
					break;
				case Scene.GoDivaMusicSelect:
					FinalizeGoDivaMusicSelect();
					break;
				case Scene.MissionMusicSelect:
					FinalizeMissionMusicSelect();
					break;
				case Scene.UnitDispType:
					FinalizeUnitDispType();
					break;
				case Scene.PlateSelect:
					if(MenuScene.Instance.GetCurrentTransitionRoot().TransitionName == TransitionList.Type.SCENE_SELECT)
					{
						FinalizePlateSelect();
					}
					else if(((int)MenuScene.Instance.GetCurrentTransitionRoot().TransitionName & 0xfffffffe) != 104)
					{
						FinalizePlateSelectList();
					}
					break;
				case Scene.VerticalMusicSelect:
					FinalizeVerticalMusicSelect();
					break;
				case Scene.ShopProduct:
					FinalizeShopProductList();
					break;
				default:
					break;
			}
		}

		// RVA: 0x1C98970 Offset: 0x1C98970 VA: 0x1C98970 Slot: 18
		public bool IsScrollable()
		{
			for(int i = 0; i < ScrollableTable.Length; i++)
			{
				if (m_setting.m_param.Scene == ScrollableTable[i])
					return true;
			}
			return false;
		}

		// RVA: 0x1C98A20 Offset: 0x1C98A20 VA: 0x1C98A20 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			if (m_setting.m_param.Scene == Scene.ShopProduct)
				ShowShopProduct();
			else if (m_setting.m_param.Scene == Scene.PlateSelect)
				ShowPlateSelect();
		}

		// RVA: 0x1C98D4C Offset: 0x1C98D4C VA: 0x1C98D4C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1C98D84 Offset: 0x1C98D84 VA: 0x1C98D84 Slot: 21
		public bool IsReady()
		{
			if (!m_setting.ISLoaded())
				return false;
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x1C98E54 Offset: 0x1C98E54 VA: 0x1C98E54 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0x1C907C4 Offset: 0x1C907C4 VA: 0x1C907C4
		private void InitializeGoDivaMusicSelect()
		{
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.FPMABHADHBB_EventGoDiva saveGoDiva = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.IMEBBACHPAN_EventGoDiva;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int music_level_limitmin = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmin", 1);
			int music_level_limitmax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmax", 25);
			(m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_Title_H1).SetTitle(bk.GetMessageByLabel("popup_filter_title_h1"));
			(m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_Title_H1).SetButton(bk.GetMessageByLabel("popup_sort_filter_reset"), ResetGoDivaMusicSelectFilter);
			(m_setting.m_list_parts[1].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_difficulty_title_h2"));
			(m_setting.m_list_parts[2].m_base as PopupFilterSortUGUIParts_FilterDifficulty).SetItem(m_setting.m_param.GoDivaMusicSelectParam.IsLine6Mode);
			(m_setting.m_list_parts[2].m_base as PopupFilterSortUGUIParts_FilterDifficulty).SetDifficulty(m_setting.m_param.GoDivaMusicSelectParam.Difficulty);
			(m_setting.m_list_parts[4].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_music_level_title_h2"));
			PopupFilterSortUGUIParts_RangeSlider slider = m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider;
			slider.SetRangeLimit(music_level_limitmin, music_level_limitmax);
			slider.SetMin(m_setting.m_param.EnableSave ? (saveGoDiva.KHAJGNDEPMG_FilterMusicLevelMin != 0 ? saveGoDiva.KHAJGNDEPMG_FilterMusicLevelMin : music_level_limitmin) : music_level_limitmin);
			slider.SetMax(m_setting.m_param.EnableSave ? (saveGoDiva.IKFKKJLBBBN_FilterMusicLevelMax != 0 ? saveGoDiva.IKFKKJLBBBN_FilterMusicLevelMax : music_level_limitmax) : music_level_limitmax);
			(m_setting.m_list_parts[7].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_music_attribute_title_h2"));
			(m_setting.m_list_parts[8].m_base as PopupFilterSortUGUIParts_FilterMusicAttr).SetBit(m_setting.m_param.EnableSave ? (uint)saveGoDiva.EOCPIGDIFNB_FilterMusicAttr : 0);
			(m_setting.m_list_parts[10].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_combo_title_h2"));
			(m_setting.m_list_parts[11].m_base as PopupFilterSortUGUIParts_FilterCombo).SetBit(m_setting.m_param.EnableSave ? (uint)saveGoDiva.JJNLEPEKNDO_FilterCombo : 0);
			(m_setting.m_list_parts[13].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_music_select_02"));
			(m_setting.m_list_parts[14].m_base as PopupFilterSortUGUIParts_FilterReward).SetBit(m_setting.m_param.EnableSave ? (uint)saveGoDiva.PGMJCBIHNHK_FilterReward : 0);
			(m_setting.m_list_parts[16].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_godiva_music_exp_title_h2"));
			(m_setting.m_list_parts[17].m_base as PopupFilterSortUGUIParts_FilterGoDivaMusicExp).SetBit(m_setting.m_param.EnableSave ? (uint)saveGoDiva.MENIBLFBNLC_FilterMusicExp : 0);
		}

		//// RVA: 0x1C96A14 Offset: 0x1C96A14 VA: 0x1C96A14
		private void FinalizeGoDivaMusicSelect()
		{
			if(!m_setting.m_param.EnableSave)
				return;
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.FPMABHADHBB_EventGoDiva saveGoDiva = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.IMEBBACHPAN_EventGoDiva;
			m_setting.m_param.GoDivaMusicSelectParam.Difficulty = (Difficulty.Type)(m_setting.m_list_parts[2].m_base as PopupFilterSortUGUIParts_FilterDifficulty).GetDifficulty();
			PopupFilterSortUGUIParts_RangeSlider slider = m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider;
			saveGoDiva.KHAJGNDEPMG_FilterMusicLevelMin = (int)(slider.GetMin() >= slider.GetLimitMin() ? slider.GetMin() : 0);
			saveGoDiva.IKFKKJLBBBN_FilterMusicLevelMax = (int)(slider.GetLimitMax() >= slider.GetMax() ? slider.GetMax() : 0);
			saveGoDiva.EOCPIGDIFNB_FilterMusicAttr = (int)(m_setting.m_list_parts[8].m_base as PopupFilterSortUGUIParts_FilterMusicAttr).GetBit();
			saveGoDiva.JJNLEPEKNDO_FilterCombo = (int)(m_setting.m_list_parts[11].m_base as PopupFilterSortUGUIParts_FilterCombo).GetBit();
			saveGoDiva.PGMJCBIHNHK_FilterReward = (int)(m_setting.m_list_parts[14].m_base as PopupFilterSortUGUIParts_FilterReward).GetBit();
			saveGoDiva.MENIBLFBNLC_FilterMusicExp = (int)(m_setting.m_list_parts[17].m_base as PopupFilterSortUGUIParts_FilterGoDivaMusicExp).GetBit();
        }

		//// RVA: 0x1C99598 Offset: 0x1C99598 VA: 0x1C99598
		public void ResetGoDivaMusicSelectFilter()
		{
			(m_setting.m_list_parts[2].m_base as PopupFilterSortUGUIParts_FilterDifficulty).SetDifficulty(m_setting.m_param.GoDivaMusicSelectParam.Difficulty);
			PopupFilterSortUGUIParts_RangeSlider slider = m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider;
			slider.SetMin(slider.GetLimitMin());
			slider.SetMax(slider.GetLimitMax());
			(m_setting.m_list_parts[8].m_base as PopupFilterSortUGUIParts_FilterMusicAttr).SetBit(0);
			(m_setting.m_list_parts[11].m_base as PopupFilterSortUGUIParts_FilterCombo).SetBit(0);
			(m_setting.m_list_parts[14].m_base as PopupFilterSortUGUIParts_FilterReward).SetBit(0);
			(m_setting.m_list_parts[17].m_base as PopupFilterSortUGUIParts_FilterGoDivaMusicExp).SetBit(0);
		}

		//// RVA: 0x1C91AA0 Offset: 0x1C91AA0 VA: 0x1C91AA0
		private void InitializeMissionMusicSelect()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "InitializeMissionMusicSelect");
		}

		//// RVA: 0x1C970C4 Offset: 0x1C970C4 VA: 0x1C970C4
		private void FinalizeMissionMusicSelect()
		{
			TodoLogger.LogError(TodoLogger.EventMission_6, "FinalizeMissionMusicSelect");
		}

		//// RVA: 0x1C99C34 Offset: 0x1C99C34 VA: 0x1C99C34
		//public void ResetMissionMusicSelectFilter() { }

		//// RVA: 0x1C8F4E4 Offset: 0x1C8F4E4 VA: 0x1C8F4E4
		private void InitializeMusicSelect()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			int music_level_limitmin = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmin", 1);
			int music_level_limitmax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("music_level_limitmax", 25);
			(m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_Title_H1).SetTitle(bk.GetMessageByLabel("popup_filter_title_h1"));
			(m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_Title_H1).SetButton(bk.GetMessageByLabel("popup_sort_filter_reset"), ResetMusicSelectFilter);
			(m_setting.m_list_parts[1].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_difficulty_title_h2"));
			(m_setting.m_list_parts[2].m_base as PopupFilterSortUGUIParts_FilterDifficulty).SetItem(m_setting.m_param.MusicSelectParam.IsLine6Mode);
			(m_setting.m_list_parts[2].m_base as PopupFilterSortUGUIParts_FilterDifficulty).SetDifficulty(m_setting.m_param.MusicSelectParam.Difficulty);
			(m_setting.m_list_parts[4].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_music_level_title_h2"));
			(m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).SetRangeLimit(music_level_limitmin, music_level_limitmax);
			(m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).SetMin(m_setting.m_param.EnableSave && GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.KHAJGNDEPMG_FilterMusicLevelMin != 0 ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.KHAJGNDEPMG_FilterMusicLevelMin : music_level_limitmin);
			(m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).SetMax(m_setting.m_param.EnableSave && GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.IKFKKJLBBBN_FilterMusicLevelMax != 0 ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.IKFKKJLBBBN_FilterMusicLevelMax : music_level_limitmax);
			(m_setting.m_list_parts[7].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_music_attribute_title_h2"));
			(m_setting.m_list_parts[8].m_base as PopupFilterSortUGUIParts_FilterMusicAttr).SetBit(m_setting.m_param.EnableSave ? (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.EOCPIGDIFNB_FilterMusicAttr : 0);
			(m_setting.m_list_parts[10].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_combo_title_h2"));
			(m_setting.m_list_parts[11].m_base as PopupFilterSortUGUIParts_FilterCombo).SetBit(m_setting.m_param.EnableSave ? (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.JJNLEPEKNDO_FilterCombo : 0);
			(m_setting.m_list_parts[13].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_music_select_02"));
			(m_setting.m_list_parts[14].m_base as PopupFilterSortUGUIParts_FilterReward).SetBit(m_setting.m_param.EnableSave ? (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.PGMJCBIHNHK_FilterReward : 0);
			(m_setting.m_list_parts[16].m_base as PopupFilterSortUGUIParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_unit_title_h2"));
			(m_setting.m_list_parts[17].m_base as PopupFilterSortUGUIParts_UnitLive).SetBit(m_setting.m_param.EnableSave ? (uint)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.DPDBMECAIIO_FilterUnit : 0);
		}

		//// RVA: 0x1C96350 Offset: 0x1C96350 VA: 0x1C96350
		private void FinalizeMusicSelect()
		{
			if(!m_setting.m_param.EnableSave)
				return;
			m_setting.m_param.MusicSelectParam.Difficulty = (Difficulty.Type)(m_setting.m_list_parts[2].m_base as PopupFilterSortUGUIParts_FilterDifficulty).GetDifficulty();
			float f = (m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).GetMin();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.KHAJGNDEPMG_FilterMusicLevelMin = f >= (m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).GetLimitMin() ? (int)f : 0;
			f = (m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).GetMax();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.IKFKKJLBBBN_FilterMusicLevelMax = f <= (m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).GetLimitMax() ? (int)f : 0;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.EOCPIGDIFNB_FilterMusicAttr = (int)(m_setting.m_list_parts[8].m_base as PopupFilterSortUGUIParts_FilterMusicAttr).GetBit();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.JJNLEPEKNDO_FilterCombo = (int)(m_setting.m_list_parts[11].m_base as PopupFilterSortUGUIParts_FilterMusicAttr).GetBit();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.PGMJCBIHNHK_FilterReward = (int)(m_setting.m_list_parts[14].m_base as PopupFilterSortUGUIParts_FilterMusicAttr).GetBit();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.KGDILGLNKFM_MusicSelect.DPDBMECAIIO_FilterUnit = (int)(m_setting.m_list_parts[17].m_base as PopupFilterSortUGUIParts_FilterMusicAttr).GetBit();
		}

		//// RVA: 0x1C9A3F8 Offset: 0x1C9A3F8 VA: 0x1C9A3F8
		public void ResetMusicSelectFilter()
		{
			(m_setting.m_list_parts[2].m_base as PopupFilterSortUGUIParts_FilterDifficulty).SetDifficulty(m_setting.m_param.MusicSelectParam.Difficulty);
			(m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).SetMin((m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).GetLimitMin());
			(m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).SetMax((m_setting.m_list_parts[5].m_base as PopupFilterSortUGUIParts_RangeSlider).GetLimitMax());
			(m_setting.m_list_parts[8].m_base as PopupFilterSortUGUIParts_FilterMusicAttr).SetBit(0);
			(m_setting.m_list_parts[11].m_base as PopupFilterSortUGUIParts_FilterCombo).SetBit(0);
			(m_setting.m_list_parts[14].m_base as PopupFilterSortUGUIParts_FilterReward).SetBit(0);
			(m_setting.m_list_parts[17].m_base as PopupFilterSortUGUIParts_UnitLive).SetBit(0);
		}

		//// RVA: 0x1C9AA7C Offset: 0x1C9AA7C VA: 0x1C9AA7C
		private void PlateFilterSkillButtonShowHideAnim()
		{
			this.StartCoroutineWatched(Co_PlateFilterSkillButtonShowHideAnim());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7081E4 Offset: 0x7081E4 VA: 0x7081E4
		//// RVA: 0x1C9AAA0 Offset: 0x1C9AAA0 VA: 0x1C9AAA0
		private IEnumerator Co_PlateFilterSkillButtonShowHideAnim()
		{
			//0x1C9E290
			while(m_plateFilterParts.filterSkill.IsPlaying() || 
				m_plateFilterParts.filterActiveSkill.IsPlaying() || 
				m_plateFilterParts.filterCenterSkill.IsPlaying())
			{
				PlateFilterHeightUpdate();
				yield return null;
			}
			m_plateFilterParts.filterSkill.m_showBtn.IsInputLock = false;
			m_plateFilterParts.filterActiveSkill.m_showBtn.IsInputLock = false;
			m_plateFilterParts.filterCenterSkill.m_showBtn.IsInputLock = false;
		}

		//// RVA: 0x1C9AB4C Offset: 0x1C9AB4C VA: 0x1C9AB4C
		private void PlateFilterHeightUpdate()
		{
			m_plateFilterParts.layoutGroup.CalculateLayoutInputVertical();
			m_plateFilterParts.layoutGroup.SetLayoutVertical();
			m_plateFilterParts.contentSizeFitter.SetLayoutVertical();
			m_plateFilterContent.sizeDelta = m_plateFilterPartsRect.sizeDelta;

		}

		//// RVA: 0x1C961AC Offset: 0x1C961AC VA: 0x1C961AC
		//public void PlateSelectSetUp(RectTransform popupContent) { }

		//// RVA: 0x1C935E0 Offset: 0x1C935E0 VA: 0x1C935E0
		private void InitializePlateSelect()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty prop = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty;
			m_plateFilterParts = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_PlateFilter;
			m_plateFilterPartsRect = m_plateFilterParts.GetComponent<RectTransform>();
			m_plateFilterParts.titleH1[0].SetTitle(bk.GetMessageByLabel("popup_sort_title_h1"));
			m_plateFilterParts.titleH1[0].EnableButton(false);
			m_plateFilterParts.titleH1[1].SetTitle(bk.GetMessageByLabel("popup_filter_title_h1"));
			m_plateFilterParts.titleH1[1].SetButton(bk.GetMessageByLabel("popup_sort_filter_reset"), ResetPlateSelectFilter);
			m_plateFilterParts.filterRarity.SetBit(m_setting.m_param.EnableSave ? (uint)prop.FFAKMECDMFC_sceneSelectRarityFilter : 0);
			m_plateFilterParts.filterAttribute.SetBit(m_setting.m_param.EnableSave ? (uint)prop.LMPKAPBCIFD_sceneSelectAttributeFilter : 0);
			m_plateFilterParts.filterSeries.SetBit(m_setting.m_param.EnableSave ? (uint)prop.MNNCLIFBAOA_sceneSelectSeriaseFilter : 0);
			m_plateFilterParts.filterNotesExpectation.SetBit(m_setting.m_param.EnableSave ? (uint)prop.DMKHBHDGABG_sceneSelectNotesExpectedFilter : 0);
			m_plateFilterParts.filterSort.SetupItem(PopupSortMenu.SceneSortItem.ToArray());
			m_plateFilterParts.filterSort.SetSortItem((SortItem)prop.LNFFKCDNCPN_sceneSelectSortItem);
			m_plateFilterParts.filterDiva.SetBit(m_setting.m_param.EnableSave ? (uint)prop.NPFGKBKKCFL_sceneSelectCompatibleFilter : 0);
			m_plateFilterParts.filterDiva.SetBitCompatible(m_setting.m_param.EnableSave ? (uint)prop.JACFDEKLDCK_isCompatibleDivaCheck : 0);
			m_plateFilterParts.filterDiva.Initialize(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas, true, true, false);
			m_plateFilterParts.filterDiva.SetSelectedDiva(m_setting.m_param.PlateSelectParam.SelectedDivaId);
			m_plateFilterParts.filterSkill.SetBitSkillRange(m_setting.m_param.EnableSave ? (uint)prop.IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter : 0);
			m_plateFilterParts.filterSkill.SetBitSkillRank(m_setting.m_param.EnableSave ? (uint)prop.AIPJDIPBDEA_sceneSelectLiveSkillRankFilter : 0);
			m_plateFilterParts.filterSkill.SetBitSkill(m_setting.m_param.EnableSave ? (ulong)prop.OCKOEPFNGJG_sceneSelectLiveSkillFilter : 0);
			m_plateFilterParts.filterSkill.SetupIcon();
			m_plateFilterParts.filterSkill.SetAllButton();
			m_plateFilterParts.filterSkill.OhClickShowHideButtonListener = PlateFilterSkillButtonShowHideAnim;
			m_plateFilterParts.filterActiveSkill.SetBitSkillRange(0);
 			m_plateFilterParts.filterActiveSkill.SetBitSkillRank(m_setting.m_param.EnableSave ? (uint)prop.BIBBAIFCGLD_sceneSelectActiveSkillRankFilter : 0);
			m_plateFilterParts.filterActiveSkill.SetBitSkill(m_setting.m_param.EnableSave ? (ulong)prop.POJHGOJDOND_sceneSelectActiveSkillFilter : 0);
			m_plateFilterParts.filterActiveSkill.SetupIcon();
			m_plateFilterParts.filterActiveSkill.SetAllButton();
			m_plateFilterParts.filterActiveSkill.OhClickShowHideButtonListener = PlateFilterSkillButtonShowHideAnim;
 			m_plateFilterParts.filterCenterSkill.SetBitSkillRank(m_setting.m_param.EnableSave ? (uint)prop.BPFPFOJNFLC_sceneSelectCenterSkillRankFilter : 0);
			m_plateFilterParts.filterCenterSkill.SetBitSkill(m_setting.m_param.EnableSave ? (ulong)prop.IHECEFMGKHO_sceneSelectCenterSkillFilter : 0);
			m_plateFilterParts.filterCenterSkill.SetupIcon();
			m_plateFilterParts.filterCenterSkill.SetAllButton();
			m_plateFilterParts.filterCenterSkill.OhClickShowHideButtonListener = PlateFilterSkillButtonShowHideAnim;
        }

		//// RVA: 0x1C97AC0 Offset: 0x1C97AC0 VA: 0x1C97AC0
		private void FinalizePlateSelect()
		{
			if(!m_setting.m_param.EnableSave)
				return;
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty prop = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty;
			PopupFilterSortUGUIParts_PlateFilter p = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_PlateFilter;
			prop.LNFFKCDNCPN_sceneSelectSortItem = (int)p.filterSort.GetSortItem();
			prop.FFAKMECDMFC_sceneSelectRarityFilter = (int)p.filterRarity.GetBit();
			prop.LMPKAPBCIFD_sceneSelectAttributeFilter = (int)p.filterAttribute.GetBit();
			prop.MNNCLIFBAOA_sceneSelectSeriaseFilter = (int)p.filterSeries.GetBit();
			prop.DMKHBHDGABG_sceneSelectNotesExpectedFilter = (int)p.filterNotesExpectation.GetBit();
			prop.NPFGKBKKCFL_sceneSelectCompatibleFilter = (int)p.filterDiva.GetBit();
			prop.JACFDEKLDCK_isCompatibleDivaCheck = (int)p.filterDiva.GetBitCompatible();
			prop.IMFEPOFGPHN_sceneSelectLiveSkillRangeFilter = (int)p.filterSkill.GetBitSkillRange();
			prop.AIPJDIPBDEA_sceneSelectLiveSkillRankFilter = (int)p.filterSkill.GetBitSkillRank();
			prop.OCKOEPFNGJG_sceneSelectLiveSkillFilter = (long)p.filterSkill.GetBitSkill();
			prop.BIBBAIFCGLD_sceneSelectActiveSkillRankFilter = (int)p.filterActiveSkill.GetBitSkillRank();
			prop.POJHGOJDOND_sceneSelectActiveSkillFilter = (long)p.filterActiveSkill.GetBitSkill();
			prop.BPFPFOJNFLC_sceneSelectCenterSkillRankFilter = (int)p.filterCenterSkill.GetBitSkillRank();
			prop.IHECEFMGKHO_sceneSelectCenterSkillFilter = (long)p.filterCenterSkill.GetBitSkill();
		}

		//// RVA: 0x1C9CAE8 Offset: 0x1C9CAE8 VA: 0x1C9CAE8
		private void ResetPlateSelectFilter()
		{
			PopupFilterSortUGUIParts_PlateFilter p = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_PlateFilter;
			p.filterRarity.SetBit(0);
			p.filterAttribute.SetBit(0);
			p.filterSeries.SetBit(0);
			p.filterNotesExpectation.SetBit(0);
			p.filterDiva.SetBit(0);
			p.filterDiva.SetBitCompatible(0);
			p.filterDiva.Initialize(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas, true, false, false);
			p.filterSkill.SetBitSkillRange(0);
			p.filterSkill.SetBitSkillRank(0);
			p.filterSkill.SetBitSkill(0);
			p.filterSkill.AllRelease();
			p.filterActiveSkill.SetBitSkillRange(0);
			p.filterActiveSkill.SetBitSkillRank(0);
			p.filterActiveSkill.SetBitSkill(0);
			p.filterActiveSkill.AllRelease();
			p.filterCenterSkill.SetBitSkillRank(0);
			p.filterCenterSkill.SetBitSkill(0);
			p.filterCenterSkill.AllRelease();
		}

		//// RVA: 0x1C94204 Offset: 0x1C94204 VA: 0x1C94204
		private void InitializePlateSelectList()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty prop = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty;
			m_plateFilterParts = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_PlateFilter;
			m_plateFilterPartsRect = m_plateFilterParts.GetComponent<RectTransform>();
			m_plateFilterParts.titleH1[0].SetTitle(bk.GetMessageByLabel("popup_sort_title_h1"));
			m_plateFilterParts.titleH1[0].EnableButton(false);
			m_plateFilterParts.titleH1[1].SetTitle(bk.GetMessageByLabel("popup_filter_title_h1"));
			m_plateFilterParts.titleH1[1].SetButton(bk.GetMessageByLabel("popup_sort_filter_reset"), ResetPlateSelectList);
			m_plateFilterParts.filterRarity.SetBit(m_setting.m_param.EnableSave ? (uint)prop.HMJNAGNIEJB_sceneListRarityFilter : 0);
			m_plateFilterParts.filterAttribute.SetBit(m_setting.m_param.EnableSave ? (uint)prop.HFGAILIOFAN_sceneListAttributeFilter : 0);
			m_plateFilterParts.filterSeries.SetBit(m_setting.m_param.EnableSave ? (uint)prop.AKFPHKLCHAA_sceneListSeriaseFilter : 0);
			m_plateFilterParts.filterNotesExpectation.SetBit(m_setting.m_param.EnableSave ? (uint)prop.MCJBFHMJECO_sceneListNotesExpectedFilter : 0);
			m_plateFilterParts.filterSort.SetupItem(PopupSortMenu.SceneSortItem.ToArray());
			m_plateFilterParts.filterSort.SetSortItem((SortItem)prop.GEAECNMDMHH_sceneListSortItem);
			m_plateFilterParts.filterDiva.SetBit(m_setting.m_param.EnableSave ? (uint)prop.PHCEMKLNJLH_sceneListCompatibleFilter : 0);
			m_plateFilterParts.filterDiva.Initialize(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas, true, false, false);
			m_plateFilterParts.filterSkill.SetBitSkillRange(m_setting.m_param.EnableSave ? (uint)prop.LALFKJDFPOD_sceneListLiveSkillRangeFilter : 0);
			m_plateFilterParts.filterSkill.SetBitSkillRank(m_setting.m_param.EnableSave ? (uint)prop.HKFPBAFALHO_sceneListLiveSkillRankFilter : 0);
			m_plateFilterParts.filterSkill.SetBitSkill(m_setting.m_param.EnableSave ? (ulong)prop.BOMCDAIEFLN_sceneListLiveSkillFilter : 0);
			m_plateFilterParts.filterSkill.SetupIcon();
			m_plateFilterParts.filterSkill.SetAllButton();
			m_plateFilterParts.filterSkill.OhClickShowHideButtonListener = PlateFilterSkillButtonShowHideAnim;
			m_plateFilterParts.filterActiveSkill.SetBitSkillRange(0);
 			m_plateFilterParts.filterActiveSkill.SetBitSkillRank(m_setting.m_param.EnableSave ? (uint)prop.ALFGELGDIGC_sceneListActiveSkillRankFilter : 0);
			m_plateFilterParts.filterActiveSkill.SetBitSkill(m_setting.m_param.EnableSave ? (ulong)prop.GIPNFAFFNLF_sceneListActiveSkillFilter : 0);
			m_plateFilterParts.filterActiveSkill.SetupIcon();
			m_plateFilterParts.filterActiveSkill.SetAllButton();
			m_plateFilterParts.filterActiveSkill.OhClickShowHideButtonListener = PlateFilterSkillButtonShowHideAnim;
 			m_plateFilterParts.filterCenterSkill.SetBitSkillRank(m_setting.m_param.EnableSave ? (uint)prop.MECEGIJIGBN_sceneListCenterSkillRankFilter : 0);
			m_plateFilterParts.filterCenterSkill.SetBitSkill(m_setting.m_param.EnableSave ? (ulong)prop.IOBABMJPAAE_sceneListCenterSkillFilter : 0);
			m_plateFilterParts.filterCenterSkill.SetupIcon();
			m_plateFilterParts.filterCenterSkill.SetAllButton();
			m_plateFilterParts.filterCenterSkill.OhClickShowHideButtonListener = PlateFilterSkillButtonShowHideAnim;
      }

		//// RVA: 0x1C97E50 Offset: 0x1C97E50 VA: 0x1C97E50
		private void FinalizePlateSelectList()
		{
			if(!m_setting.m_param.EnableSave)
				return;
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty prop = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty;
			PopupFilterSortUGUIParts_PlateFilter p = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_PlateFilter;
			prop.GEAECNMDMHH_sceneListSortItem = (int)p.filterSort.GetSortItem();
			prop.HMJNAGNIEJB_sceneListRarityFilter = (int)p.filterRarity.GetBit();
			prop.HFGAILIOFAN_sceneListAttributeFilter = (int)p.filterAttribute.GetBit();
			prop.AKFPHKLCHAA_sceneListSeriaseFilter = (int)p.filterSeries.GetBit();
			prop.MCJBFHMJECO_sceneListNotesExpectedFilter = (int)p.filterNotesExpectation.GetBit();
			prop.PHCEMKLNJLH_sceneListCompatibleFilter = (int)p.filterDiva.GetBit();
			prop.LALFKJDFPOD_sceneListLiveSkillRangeFilter = (int)p.filterSkill.GetBitSkillRange();
			prop.HKFPBAFALHO_sceneListLiveSkillRankFilter = (int)p.filterSkill.GetBitSkillRank();
			prop.BOMCDAIEFLN_sceneListLiveSkillFilter = (long)p.filterSkill.GetBitSkill();
			prop.ALFGELGDIGC_sceneListActiveSkillRankFilter = (int)p.filterActiveSkill.GetBitSkillRank();
			prop.GIPNFAFFNLF_sceneListActiveSkillFilter = (long)p.filterActiveSkill.GetBitSkill();
			prop.MECEGIJIGBN_sceneListCenterSkillRankFilter = (int)p.filterCenterSkill.GetBitSkillRank();
			prop.IOBABMJPAAE_sceneListCenterSkillFilter = (long)p.filterCenterSkill.GetBitSkill();
		}

		//// RVA: 0x1C9D088 Offset: 0x1C9D088 VA: 0x1C9D088
		private void ResetPlateSelectList()
		{
			PopupFilterSortUGUIParts_PlateFilter p = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_PlateFilter;
			p.filterRarity.SetBit(0);
			p.filterAttribute.SetBit(0);
			p.filterSeries.SetBit(0);
			p.filterNotesExpectation.SetBit(0);
			p.filterDiva.SetBit(0);
			p.filterDiva.SetBitCompatible(0);
			p.filterDiva.Initialize(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas, true, false, false);
			p.filterSkill.SetBitSkillRange(0);
			p.filterSkill.SetBitSkillRank(0);
			p.filterSkill.SetBitSkill(0);
			p.filterSkill.AllRelease();
			p.filterActiveSkill.SetBitSkillRange(0);
			p.filterActiveSkill.SetBitSkillRank(0);
			p.filterActiveSkill.SetBitSkill(0);
			p.filterActiveSkill.AllRelease();
			p.filterCenterSkill.SetBitSkillRank(0);
			p.filterCenterSkill.SetBitSkill(0);
			p.filterCenterSkill.AllRelease();
		}

		//// RVA: 0x1C98AAC Offset: 0x1C98AAC VA: 0x1C98AAC
		private void ShowPlateSelect()
		{
			PlateFilterHeightUpdate();
			PopupFilterSortUGUIParts_PlateFilter p = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_PlateFilter;
			p.filterSkill.SetupStateFilter();
			p.filterActiveSkill.SetupStateFilter();
			p.filterCenterSkill.SetupStateFilter();
		}

		//// RVA: 0x1C9D484 Offset: 0x1C9D484 VA: 0x1C9D484
		private void ShopProductSkillButtonShowHideAnim()
		{
			this.StartCoroutineWatched(Co_ShopProductSkillButtonShowHideAnim());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x70825C Offset: 0x70825C VA: 0x70825C
		//// RVA: 0x1C9D4A8 Offset: 0x1C9D4A8 VA: 0x1C9D4A8
		private IEnumerator Co_ShopProductSkillButtonShowHideAnim()
		{
			//0x1C9E544
			while(m_shopProductParts.filterSkill.IsPlaying() || m_shopProductParts.filterActiveSkill.IsPlaying() || m_shopProductParts.filterCenterSkill.IsPlaying())
			{
				ShopProductHeightUpdate();
				yield return null;
			}
			m_shopProductParts.filterSkill.m_showBtn.IsInputLock = false;
			m_shopProductParts.filterActiveSkill.m_showBtn.IsInputLock = false;
			m_shopProductParts.filterCenterSkill.m_showBtn.IsInputLock = false;
		}

		//// RVA: 0x1C9D554 Offset: 0x1C9D554 VA: 0x1C9D554
		private void ShopProductHeightUpdate()
		{
			m_shopProductParts.layoutGroup.CalculateLayoutInputVertical();
			m_shopProductParts.layoutGroup.SetLayoutVertical();
			m_shopProductParts.contentSizeFitter.SetLayoutVertical();
			m_shopProductContent.sizeDelta = m_shopProductPartsRect.sizeDelta;
		}

		//// RVA: 0x1C961B4 Offset: 0x1C961B4 VA: 0x1C961B4
		//public void ShopProductSetUp(RectTransform popupContent) { }

		//// RVA: 0x1C953EC Offset: 0x1C953EC VA: 0x1C953EC
		private void InitializeShopProductList()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.POCEANNLGLP_ShopProduct sort;
			if(m_setting.m_param.ShopProductParam.RarityMax < 5)
			{
                sort = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CCJMAIPBELA_ShopProduct1_4;
            }
			else
			{
				sort = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.HDKDFCCJEEP_ShopProduct5_6;
			}
			m_shopProductParts = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_ShopProduct;
			m_shopProductPartsRect = m_shopProductParts.gameObject.GetComponent<RectTransform>();
			m_shopProductParts.titleH1[0].SetTitle(bk.GetMessageByLabel("popup_sort_title_h1"));
			m_shopProductParts.titleH1[0].EnableButton(false);
			m_shopProductParts.titleH1[1].SetTitle(bk.GetMessageByLabel("popup_filter_title_h1"));
			m_shopProductParts.titleH1[1].SetButton(bk.GetMessageByLabel("popup_sort_filter_reset"), ResetShopProductList);
			m_shopProductParts.filterRarity.SetBit(m_setting.m_param.EnableSave ? (uint)sort.ACCHOFLOOEC_RarityFilter : 0);
			uint bitFlag = 0;
			for(int i = m_setting.m_param.ShopProductParam.RarityMin; i <= m_setting.m_param.ShopProductParam.RarityMax; i++)
			{
				if(i - 1 > -1)
					bitFlag |= (uint)(1 << (i - 1));
			}
			m_shopProductParts.filterRarity.SetRarity(bitFlag);
			m_shopProductParts.filterAttribute.SetBit(m_setting.m_param.EnableSave ? (uint)sort.BOFFOHHLLFG_AttrFilter : 0);
			m_shopProductParts.filterSeries.SetBit(m_setting.m_param.EnableSave ? (uint)sort.BBIIHLNBHDE_SerieFilter : 0);
			m_shopProductParts.filterHave.SetBit(m_setting.m_param.EnableSave ? (uint)sort.EGBPCFOGOCK_HaveFilter : 0);
			m_shopProductParts.filterNotesExpectation.SetBit(m_setting.m_param.EnableSave ? (uint)sort.NLLEDCOAPIG_NoteExpectedFilter : 0);
			m_shopProductParts.filterSort.SetupItem(PopupSortMenu.ShopSortItem.ToArray());
			m_shopProductParts.filterSort.SetSortItem((SortItem)sort.LHPDCGNKPHD_SortItem);
			m_shopProductParts.filterDiva.SetBit(m_setting.m_param.EnableSave ? (uint)sort.ABLBLOEKBKA_CompatibleFilter : 0);
			m_shopProductParts.filterDiva.Initialize(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas, true, false, false);
			m_shopProductParts.filterSkill.SetBitSkillRange(m_setting.m_param.EnableSave ? (uint)sort.OAJNACDACDF_LiveSkillRangeFilter : 0);
			m_shopProductParts.filterSkill.SetBitSkillRank(m_setting.m_param.EnableSave ? (uint)sort.EAPCPNGAPBB_LiveSkillRankFilter : 0);
			m_shopProductParts.filterSkill.SetBitSkill(m_setting.m_param.EnableSave ? (ulong)sort.PPEFJBBGGHI_LiveSkillFilter : 0);
			m_shopProductParts.filterSkill.SetupIcon();
			m_shopProductParts.filterSkill.SetAllButton();
			m_shopProductParts.filterSkill.OhClickShowHideButtonListener = ShopProductSkillButtonShowHideAnim;
			m_shopProductParts.filterActiveSkill.SetBitSkillRange(0);
			m_shopProductParts.filterActiveSkill.SetBitSkillRank(m_setting.m_param.EnableSave ? (uint)sort.DNLJMMBEKAA_ActiveSkillRankFilter : 0);
			m_shopProductParts.filterActiveSkill.SetBitSkill(m_setting.m_param.EnableSave ? (ulong)sort.LACACEBKHCM_ActiveSkillFilter : 0);
			m_shopProductParts.filterActiveSkill.SetupIcon();
			m_shopProductParts.filterActiveSkill.SetAllButton();
			m_shopProductParts.filterActiveSkill.OhClickShowHideButtonListener = ShopProductSkillButtonShowHideAnim;
			m_shopProductParts.filterCenterSkill.SetBitSkillRank(m_setting.m_param.EnableSave ? (uint)sort.PFNPLBNHDJK_CenterSkillRankFilter : 0);
			m_shopProductParts.filterCenterSkill.SetBitSkill(m_setting.m_param.EnableSave ? (ulong)sort.LKPCKPJGJKN_CenterSkillFilter : 0);
			m_shopProductParts.filterCenterSkill.SetupIcon();
			m_shopProductParts.filterCenterSkill.SetAllButton();
			m_shopProductParts.filterCenterSkill.OhClickShowHideButtonListener = ShopProductSkillButtonShowHideAnim;
		}

		//// RVA: 0x1C984AC Offset: 0x1C984AC VA: 0x1C984AC
		private void FinalizeShopProductList()
		{
			if(!m_setting.m_param.EnableSave)
				return;
			ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.POCEANNLGLP_ShopProduct sort;
			if(m_setting.m_param.ShopProductParam.RarityMax < 5)
			{
                sort = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CCJMAIPBELA_ShopProduct1_4;
            }
			else
			{
				sort = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.HDKDFCCJEEP_ShopProduct5_6;
			}
			PopupFilterSortUGUIParts_ShopProduct p = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_ShopProduct;
			sort.LHPDCGNKPHD_SortItem = (int)p.filterSort.GetSortItem();
			sort.ACCHOFLOOEC_RarityFilter = (int)p.filterRarity.GetBit();
			sort.BOFFOHHLLFG_AttrFilter = (int)p.filterAttribute.GetBit();
			sort.BBIIHLNBHDE_SerieFilter = (int)p.filterSeries.GetBit();
			sort.EGBPCFOGOCK_HaveFilter = (int)p.filterHave.GetBit();
			sort.NLLEDCOAPIG_NoteExpectedFilter = (int)p.filterNotesExpectation.GetBit();
			sort.ABLBLOEKBKA_CompatibleFilter = (int)p.filterDiva.GetBit();
			sort.OAJNACDACDF_LiveSkillRangeFilter = (int)p.filterSkill.GetBitSkillRange();
			sort.EAPCPNGAPBB_LiveSkillRankFilter = (int)p.filterSkill.GetBitSkillRank();
			sort.PPEFJBBGGHI_LiveSkillFilter = (long)p.filterSkill.GetBitSkill();
			sort.DNLJMMBEKAA_ActiveSkillRankFilter = (int)p.filterActiveSkill.GetBitSkillRank();
			sort.LACACEBKHCM_ActiveSkillFilter = (long)p.filterActiveSkill.GetBitSkill();
			sort.PFNPLBNHDJK_CenterSkillRankFilter = (int)p.filterCenterSkill.GetBitSkillRank();
			sort.LKPCKPJGJKN_CenterSkillFilter = (long)p.filterCenterSkill.GetBitSkill();
		}

		//// RVA: 0x1C9D758 Offset: 0x1C9D758 VA: 0x1C9D758
		private void ResetShopProductList()
		{
			PopupFilterSortUGUIParts_ShopProduct p = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_ShopProduct;
			p.filterRarity.SetBit(0);
			p.filterAttribute.SetBit(0);
			p.filterSeries.SetBit(0);
			p.filterHave.SetBit(0);
			p.filterNotesExpectation.SetBit(0);
			p.filterDiva.SetBit(0);
			p.filterDiva.SetBitCompatible(0);
			p.filterDiva.Initialize(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas, true, false, false);
			p.filterSkill.SetBitSkillRange(0);
			p.filterSkill.SetBitSkillRank(0);
			p.filterSkill.SetBitSkill(0);
			p.filterSkill.AllRelease();
			p.filterActiveSkill.SetBitSkillRange(0);
			p.filterActiveSkill.SetBitSkillRank(0);
			p.filterActiveSkill.SetBitSkill(0);
			p.filterActiveSkill.AllRelease();
			p.filterCenterSkill.SetBitSkillRank(0);
			p.filterCenterSkill.SetBitSkill(0);
			p.filterCenterSkill.AllRelease();
		}

		//// RVA: 0x1C98BFC Offset: 0x1C98BFC VA: 0x1C98BFC
		private void ShowShopProduct()
		{
			ShopProductHeightUpdate();
			PopupFilterSortUGUIParts_ShopProduct p = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_ShopProduct;
			p.filterSkill.SetupStateFilter();
			p.filterActiveSkill.SetupStateFilter();
			p.filterCenterSkill.SetupStateFilter();
		}

		//// RVA: 0x1C92FD8 Offset: 0x1C92FD8 VA: 0x1C92FD8
		private void InitializeUnitDispType()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			{
				PopupFilterSortUGUIParts_Title_H1 p = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_Title_H1;
				p.SetTitle(bk.GetMessageByLabel("popup_unit_disp_type_scene"));
				p.EnableButton(false);
			}
			{
				PopupFilterSortUGUIParts_Sort p = m_setting.m_list_parts[1].m_base as PopupFilterSortUGUIParts_Sort;
				p.SetupItem(PopupSortMenu.UnitSortItem.ToArray());
				p.SetSortItem((SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.LEAPMNHODPJ_unitWindowDispItem);
			}
			{
				PopupFilterSortUGUIParts_Title_H1 p = m_setting.m_list_parts[2].m_base as PopupFilterSortUGUIParts_Title_H1;
				p.SetTitle(bk.GetMessageByLabel("popup_unit_disp_type_diva"));
				p.EnableButton(false);
			}
			{
				PopupFilterSortUGUIParts_Sort p = m_setting.m_list_parts[3].m_base as PopupFilterSortUGUIParts_Sort;
				p.SetupItem(PopupSortMenu.UnitDivaSortItem.ToArray());
				p.SetSortItem((SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.BICLOMKLAOF_unitWindowDivaDispItem);
			}
		}

		//// RVA: 0x1C97830 Offset: 0x1C97830 VA: 0x1C97830
		private void FinalizeUnitDispType()
		{
			if (!m_setting.m_param.EnableSave)
				return;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.LEAPMNHODPJ_unitWindowDispItem = (int)(m_setting.m_list_parts[1].m_base as PopupFilterSortUGUIParts_Sort).GetSortItem();
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.BICLOMKLAOF_unitWindowDivaDispItem = (int)(m_setting.m_list_parts[3].m_base as PopupFilterSortUGUIParts_Sort).GetSortItem();
		}

		//// RVA: 0x1C94D6C Offset: 0x1C94D6C VA: 0x1C94D6C
		private void InitializeVerticalMusicSelect()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			PopupFilterSortUGUIParts_FilterMusicSelect filter = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_FilterMusicSelect;
			filter.titleSort.SetTitle(bk.GetMessageByLabel("popup_sort_title_h1"));
			filter.titleSort.EnableButton(false);
			filter.filterSort.SetupItem(PopupSortMenu.MusicSelectSortItem.ToArray());
			filter.filterSort.SetSortItem((SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect.LHPDCGNKPHD_sortItem);
			filter.titleFilter.SetTitle(bk.GetMessageByLabel("popup_filter_title_h1"));
			filter.titleFilter.SetButton(bk.GetMessageByLabel("popup_sort_filter_reset"), ResetVerticalMusicSelectFilter);
			filter.filterMusicBookMark.SetIndex(m_setting.m_param.EnableSave ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect.GONLKIDILLH_BookmarkIndex : 0);
			filter.filterMusicBookMark.SetBookMarkText();
			filter.filterMusicAttr.SetBit((uint)(m_setting.m_param.EnableSave ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect.EOCPIGDIFNB_MusicAttrFilterBits : 0));
			filter.filterCombo.SetBit((uint)(m_setting.m_param.EnableSave ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect.JJNLEPEKNDO_ComboFilterBits : 0));
			filter.filterReward.SetBit((uint)(m_setting.m_param.EnableSave ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect.PGMJCBIHNHK_RewardFilterBits : 0));
			filter.filterMusicLock.SetBit((uint)(m_setting.m_param.EnableSave ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect.AONOGHPAENH_filterMusicUnLock : 0));
			filter.filterRange.SetBit((uint)(m_setting.m_param.EnableSave ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect.ALGFGPCPGFK_filterRange : 0));
			filter.filterUnitLive.SetBit((uint)(m_setting.m_param.EnableSave ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect.DPDBMECAIIO_NumUnitsFilterBits : 0));
		}

		//// RVA: 0x1C981C0 Offset: 0x1C981C0 VA: 0x1C981C0
		private void FinalizeVerticalMusicSelect()
		{
			if(!m_setting.m_param.EnableSave)
				return;
			PopupFilterSortUGUIParts_FilterMusicSelect filter = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_FilterMusicSelect;
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.CLBMCCEEDGE_VerticalMusicSelect s = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.JHCKHAMFHMG_VerticalMusicSelect;
            s.LHPDCGNKPHD_sortItem = (int)filter.filterSort.GetSortItem();
			s.GONLKIDILLH_BookmarkIndex = filter.filterMusicBookMark.GetIndex();
			s.EOCPIGDIFNB_MusicAttrFilterBits = (int)filter.filterMusicAttr.GetBit();
			s.JJNLEPEKNDO_ComboFilterBits = (int)filter.filterCombo.GetBit();
			s.PGMJCBIHNHK_RewardFilterBits = (int)filter.filterReward.GetBit();
			s.AONOGHPAENH_filterMusicUnLock = (int)filter.filterMusicLock.GetBit();
			s.ALGFGPCPGFK_filterRange = (int)filter.filterRange.GetBit();
			s.DPDBMECAIIO_NumUnitsFilterBits = (int)filter.filterUnitLive.GetBit();
		}

		//// RVA: 0x1C9DD9C Offset: 0x1C9DD9C VA: 0x1C9DD9C
		public void ResetVerticalMusicSelectFilter()
		{
			PopupFilterSortUGUIParts_FilterMusicSelect filter = m_setting.m_list_parts[0].m_base as PopupFilterSortUGUIParts_FilterMusicSelect;
			filter.filterMusicBookMark.SetIndex(0);
			filter.filterMusicAttr.SetBit(0);
			filter.filterCombo.SetBit(0);
			filter.filterReward.SetBit(0);
			filter.filterMusicLock.SetBit(0);
			filter.filterRange.SetBit(0);
			filter.filterUnitLive.SetBit(0);
		}
	}
}
