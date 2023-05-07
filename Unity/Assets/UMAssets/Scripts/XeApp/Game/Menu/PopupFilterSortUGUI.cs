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
			TodoLogger.Log(0, "InitializeGoDivaMusicSelect");
		}

		//// RVA: 0x1C96A14 Offset: 0x1C96A14 VA: 0x1C96A14
		private void FinalizeGoDivaMusicSelect()
		{
			TodoLogger.Log(0, "FinalizeGoDivaMusicSelect");
		}

		//// RVA: 0x1C99598 Offset: 0x1C99598 VA: 0x1C99598
		//public void ResetGoDivaMusicSelectFilter() { }

		//// RVA: 0x1C91AA0 Offset: 0x1C91AA0 VA: 0x1C91AA0
		private void InitializeMissionMusicSelect()
		{
			TodoLogger.Log(0, "InitializeMissionMusicSelect");
		}

		//// RVA: 0x1C970C4 Offset: 0x1C970C4 VA: 0x1C970C4
		private void FinalizeMissionMusicSelect()
		{
			TodoLogger.Log(0, "FinalizeMissionMusicSelect");
		}

		//// RVA: 0x1C99C34 Offset: 0x1C99C34 VA: 0x1C99C34
		//public void ResetMissionMusicSelectFilter() { }

		//// RVA: 0x1C8F4E4 Offset: 0x1C8F4E4 VA: 0x1C8F4E4
		private void InitializeMusicSelect()
		{
			TodoLogger.Log(0, "InitializeMusicSelect");
		}

		//// RVA: 0x1C96350 Offset: 0x1C96350 VA: 0x1C96350
		private void FinalizeMusicSelect()
		{
			TodoLogger.Log(0, "FinalizeMusicSelect");
		}

		//// RVA: 0x1C9A3F8 Offset: 0x1C9A3F8 VA: 0x1C9A3F8
		//public void ResetMusicSelectFilter() { }

		//// RVA: 0x1C9AA7C Offset: 0x1C9AA7C VA: 0x1C9AA7C
		//private void PlateFilterSkillButtonShowHideAnim() { }

		//[IteratorStateMachineAttribute] // RVA: 0x7081E4 Offset: 0x7081E4 VA: 0x7081E4
		//// RVA: 0x1C9AAA0 Offset: 0x1C9AAA0 VA: 0x1C9AAA0
		//private IEnumerator Co_PlateFilterSkillButtonShowHideAnim() { }

		//// RVA: 0x1C9AB4C Offset: 0x1C9AB4C VA: 0x1C9AB4C
		//private void PlateFilterHeightUpdate() { }

		//// RVA: 0x1C961AC Offset: 0x1C961AC VA: 0x1C961AC
		//public void PlateSelectSetUp(RectTransform popupContent) { }

		//// RVA: 0x1C935E0 Offset: 0x1C935E0 VA: 0x1C935E0
		private void InitializePlateSelect()
		{
			TodoLogger.Log(0, "InitializePlateSelect");
		}

		//// RVA: 0x1C97AC0 Offset: 0x1C97AC0 VA: 0x1C97AC0
		private void FinalizePlateSelect()
		{
			TodoLogger.Log(0, "FinalizePlateSelect");
		}

		//// RVA: 0x1C9CAE8 Offset: 0x1C9CAE8 VA: 0x1C9CAE8
		//private void ResetPlateSelectFilter() { }

		//// RVA: 0x1C94204 Offset: 0x1C94204 VA: 0x1C94204
		private void InitializePlateSelectList()
		{
			TodoLogger.Log(0, "InitializePlateSelectList");
		}

		//// RVA: 0x1C97E50 Offset: 0x1C97E50 VA: 0x1C97E50
		private void FinalizePlateSelectList()
		{
			TodoLogger.Log(0, "FinalizePlateSelectList");
		}

		//// RVA: 0x1C9D088 Offset: 0x1C9D088 VA: 0x1C9D088
		//private void ResetPlateSelectList() { }

		//// RVA: 0x1C98AAC Offset: 0x1C98AAC VA: 0x1C98AAC
		private void ShowPlateSelect()
		{
			TodoLogger.Log(0, "ShowPlateSelect");
		}

		//// RVA: 0x1C9D484 Offset: 0x1C9D484 VA: 0x1C9D484
		//private void ShopProductSkillButtonShowHideAnim() { }

		//[IteratorStateMachineAttribute] // RVA: 0x70825C Offset: 0x70825C VA: 0x70825C
		//// RVA: 0x1C9D4A8 Offset: 0x1C9D4A8 VA: 0x1C9D4A8
		//private IEnumerator Co_ShopProductSkillButtonShowHideAnim() { }

		//// RVA: 0x1C9D554 Offset: 0x1C9D554 VA: 0x1C9D554
		//private void ShopProductHeightUpdate() { }

		//// RVA: 0x1C961B4 Offset: 0x1C961B4 VA: 0x1C961B4
		//public void ShopProductSetUp(RectTransform popupContent) { }

		//// RVA: 0x1C953EC Offset: 0x1C953EC VA: 0x1C953EC
		private void InitializeShopProductList()
		{
			TodoLogger.Log(0, "InitializeShopProductList");
		}

		//// RVA: 0x1C984AC Offset: 0x1C984AC VA: 0x1C984AC
		private void FinalizeShopProductList()
		{
			TodoLogger.Log(0, "FinalizeShopProductList");
		}

		//// RVA: 0x1C9D758 Offset: 0x1C9D758 VA: 0x1C9D758
		//private void ResetShopProductList() { }

		//// RVA: 0x1C98BFC Offset: 0x1C98BFC VA: 0x1C98BFC
		private void ShowShopProduct()
		{
			TodoLogger.Log(0, "ShowShopProduct");
		}

		//// RVA: 0x1C92FD8 Offset: 0x1C92FD8 VA: 0x1C92FD8
		private void InitializeUnitDispType()
		{
			TodoLogger.Log(0, "InitializeUnitDispType");
		}

		//// RVA: 0x1C97830 Offset: 0x1C97830 VA: 0x1C97830
		private void FinalizeUnitDispType()
		{
			TodoLogger.Log(0, "FinalizeUnitDispType");
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
