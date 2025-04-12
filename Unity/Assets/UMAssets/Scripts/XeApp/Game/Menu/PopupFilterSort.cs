using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupFilterSort : UIBehaviour, IPopupContent
	{
		public enum Parts
		{
			FilterDiva = 0,
			FilterMainEp = 1,
			FilterSeries = 2,
			Sort = 3,
			Line = 4,
			Title01 = 5,
			Title02 = 6,
			Rarity = 7,
			FilterGoDivaMusicExp = 8,
			Title03 = 9,
			FilterDiva02 = 10,
			Sort02 = 11,
			Max = 12,
		}

		public enum Scene
		{
			None = -1,
			EpisodeSelect = 0,
			EpisodeSelect2 = 1,
			SelectHomeBg = 2,
			DivaSelect = 3,
			GoDivaMusicSelect = 4,
			Max = 5,
		}
		public enum DivaSelectParts
		{
			Filter_Diva_Button = 0,
			Max = 1,
		}

		public enum EpisodeParts
		{
			Sort_Title = 0,
			Sort_Button = 1,
			Sort_Line = 2,
			Filter_Title = 3,
			Filter_MainEp_Title = 4,
			Filter_MainEp_Button = 5,
			Filter_MainEp_Line = 6,
			Filter_Series_Title = 7,
			Filter_Series_Button = 8,
			Filter_Series_Line = 9,
			Filter_Diva_Title = 10,
			Filter_Diva_Button = 11,
			Filter_Diva_Line = 12,
			Max = 13,
		}

		public enum GoDivaMusicSelect
		{
			Filter_Title = 0,
			Filter_MusicExp_Title = 1,
			Filter_MusicExp_Button = 2,
			Filter_MusicExp_Line = 3,
			Max = 4,
		}
		public enum SelectHomeBg
		{
			Filter_Title = 0,
			Filter_Rarity_Title = 1,
			Filter_Rarity_Button = 2,
			Filter_Rarity_Line = 3,
			Filter_Series_Title = 4,
			Filter_Series_Button = 5,
			Filter_Series_Line = 6,
			Max = 7,
		}

		private Scene[] ScrollableTable = new Scene[2] { Scene.EpisodeSelect, Scene.EpisodeSelect2 }; // 0xC
		public PopupFilterSortSetting m_setting; // 0x10
		private PopupWindowControl m_parentPopupControl; // 0x14
		public int ResultSelectDivaId; // 0x1C
		private static readonly Parts[] DivaSelectPartsTable = new Parts[1]
		{
			Parts.FilterDiva
		}; // 0x0
		private static readonly Parts[] EpisodePartsTable = new Parts[13]
		{
			Parts.Title01,
			Parts.Sort,
			Parts.Line,
			Parts.Title01,
			Parts.Title02,
			Parts.FilterMainEp,
			Parts.Line,
			Parts.Title02,
			Parts.FilterSeries,
			Parts.Line,
			Parts.Title02,
			Parts.FilterDiva,
			Parts.Line,
		}; // 0x4
		private static readonly Parts[] EpisodePartsTable2 = new Parts[13]
		{
			Parts.Title01,
			Parts.Sort02,
			Parts.Line,
			Parts.Title01,
			Parts.Title02,
			Parts.FilterMainEp,
			Parts.Line,
			Parts.Title02,
			Parts.FilterSeries,
			Parts.Line,
			Parts.Title03,
			Parts.FilterDiva02,
			Parts.Line,
		}; // 0x8
		private static readonly SortItem[] EpisodeSortTable = new SortItem[3]
		{
			SortItem.EpisodeNo,
			SortItem.EpisodePoint,
			SortItem.DivaAndValkyrie,
		}; // 0xC
		private static readonly SortItem[] EpisodeSortTable2 = new SortItem[3]
		{
			SortItem.EpisodeNo,
			SortItem.EpisodePoint,
			SortItem.DivaValkyrieHomeBG,
		}; // 0x10
		private static readonly Parts[] GoDivaMusicSelectTable = new Parts[4]
		{
			Parts.Title01,
			Parts.Title02,
			Parts.FilterGoDivaMusicExp,
			Parts.Line,
		}; // 0x14
		private static readonly Parts[] SelectHomeBgPartsTable = new Parts[7]
		{
			Parts.Title01,
			Parts.Title02,
			Parts.Rarity,
			Parts.Line,
			Parts.Title02,
			Parts.FilterSeries,
			Parts.Line,
		}; // 0x18

		public Transform Parent { get; private set; } // 0x18


		// // RVA: 0xF8F524 Offset: 0xF8F524 VA: 0xF8F524
		public static Parts[] GetPartsTable(Scene a_type)
		{
			switch(a_type)
			{
				case Scene.EpisodeSelect:
					return EpisodePartsTable;
				case Scene.EpisodeSelect2:
					return EpisodePartsTable2;
				case Scene.SelectHomeBg:
					return SelectHomeBgPartsTable;
				case Scene.DivaSelect:
					return DivaSelectPartsTable;
				case Scene.GoDivaMusicSelect:
					return GoDivaMusicSelectTable;
			}
			return null;
		}

		// RVA: 0xF8F708 Offset: 0xF8F708 VA: 0xF8F708 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_parentPopupControl = control;
			m_setting = setting as PopupFilterSortSetting;
			Parent = setting.m_parent;
			switch(m_setting.m_param.Scene)
			{
				case Scene.EpisodeSelect:
					InitializeEpisode();
					break;
				case Scene.EpisodeSelect2:
					InitializeEpisode2();
					break;
				case Scene.SelectHomeBg:
					InitializeSelectHomeBg();
					break;
				case Scene.DivaSelect:
					InitializeDivaSelect(m_setting);
					break;
				case Scene.GoDivaMusicSelect:
					InitializeGoDivaMusicSelect();
					break;
			}
			float f = 0;
			float f2 = 0;
			for(int i = 0; i < m_setting.m_list_parts.Count; i++)
			{
				m_setting.m_list_parts[i].m_base.transform.localPosition = new Vector3(0, -f2, 0);
				Rect r = m_setting.m_list_parts[i].m_base.GetGuidSize().rect;
				f2 += r.height;
				if(f < r.width)
					f = r.width;
			}
			RectTransform rt = gameObject.GetComponent<RectTransform>();
			if(rt == null)
				rt = gameObject.AddComponent<RectTransform>();
			rt.sizeDelta = new Vector2(f, f2);
			rt.anchorMin = new Vector2(0, 1);
			rt.anchorMax = new Vector2(0, 1);
			rt.pivot = new Vector2(0, 1);
			rt.anchoredPosition3D = new Vector3(0, 0, 0);
		}

		// RVA: 0xF927D4 Offset: 0xF927D4 VA: 0xF927D4
		public void Fainalize()
		{
			switch(m_setting.m_param.Scene)
			{
				case Scene.EpisodeSelect:
					FainalizeEpisode();
					break;
				case Scene.EpisodeSelect2:
					FainalizeEpisode2();
					break;
				case Scene.SelectHomeBg:
					FainalizeSelectHomeBg();
					break;
				case Scene.DivaSelect:
					FainalizeDivaSelect();
					break;
				case Scene.GoDivaMusicSelect:
					FainalizeGoDivaMusicSelect();
					break;
			}
		}

		// RVA: 0xF9361C Offset: 0xF9361C VA: 0xF9361C Slot: 18
		public bool IsScrollable()
		{
			for(int i = 0; i < ScrollableTable.Length; i++)
			{
				if(ScrollableTable[i] == m_setting.m_param.Scene)
					return true;
			}
			return false;
		}

		// RVA: 0xF936CC Offset: 0xF936CC VA: 0xF936CC Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF93704 Offset: 0xF93704 VA: 0xF93704 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF9373C Offset: 0xF9373C VA: 0xF9373C Slot: 21
		public bool IsReady()
		{
			return m_setting.ISLoaded() && !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xF9380C Offset: 0xF9380C VA: 0xF9380C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		// // RVA: 0xF91E70 Offset: 0xF91E70 VA: 0xF91E70
		private void InitializeDivaSelect(PopupFilterSortSetting a_setting)
		{
			int a = 0;
			for(int i = 1; i < 11; i++)
			{
				if((a_setting.m_param.FilterDiva & (1 << i)) != 0)
				{
					a = i;
					break;
				}
			}
			ResultSelectDivaId = a;
			PopupFilterSortParts_FilterDiva p = (m_setting.m_list_parts[0].m_base as PopupFilterSortParts_FilterDiva);
			p.Initialize(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas, false, PopupFilterSortParts_FilterDiva.ButtonType.Single, PopupFilterSortParts_FilterDiva.WindowType.Middle, a_setting.m_param.DivaChangeMode);
			p.SetBit((uint)a_setting.m_param.FilterDiva);
			if(a_setting.m_param.DivaChangeMode)
			{
				m_parentPopupControl.FindButton(PopupButton.ButtonLabel.Ok).Disable = true;
				uint divaBits = p.GetBit();
				int firstDivaId = 0;
				for(int i = 1; i < 11; i++)
				{
					if ((divaBits & (1 << i)) != 0)
					{
						firstDivaId = i;
						break;
					}
				}
				p.OnChangeFilter = () =>
				{
					//0xF94DBC
					uint b = p.GetBit();
					int a2 = 0;
					for (int i = 1; i < 11; i++)
					{
						if ((b & (1 << i)) != 0)
						{
							a2 = i;
							break;
						}
					}
					m_parentPopupControl.FindButton(PopupButton.ButtonLabel.Ok).Disable = firstDivaId == a2;
				};
			}
		}

		// // RVA: 0xF93308 Offset: 0xF93308 VA: 0xF93308
		private void FainalizeDivaSelect()
		{
			PopupFilterSortParts_FilterDiva p = (m_setting.m_list_parts[0].m_base as PopupFilterSortParts_FilterDiva);
			uint b = p.GetBit();
			ResultSelectDivaId = 0;
			for (int i = 1; i < 11; i++)
			{
				if ((b & (1 << i)) != 0)
				{
					ResultSelectDivaId = i;
					break;
				}
			}
		}

		// // RVA: 0xF93828 Offset: 0xF93828 VA: 0xF93828
		// private int SelectDivaToFilter(int a_filter_diva) { }

		// // RVA: 0xF8FD14 Offset: 0xF8FD14 VA: 0xF8FD14
		private void InitializeEpisode()
		{
			TodoLogger.LogError(TodoLogger.OldEpisodeFilter, "InitializeEpisode");
		}

		// // RVA: 0xF909F0 Offset: 0xF909F0 VA: 0xF909F0
		private void InitializeEpisode2()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			{
				PopupFilterSortParts_Title_H1 p = m_setting.m_list_parts[0].m_base as PopupFilterSortParts_Title_H1;
				p.SetTitle(bk.GetMessageByLabel("popup_sort_title_h1"));
				p.EnableButton(false);
			}
			{
				PopupFilterSortParts_Sort2 p = m_setting.m_list_parts[1].m_base as PopupFilterSortParts_Sort2;
				p.Initialize(EpisodeSortTable2);
				p.SetSortItem(m_setting.m_param.EnableSave ? (SortItem)GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.LHPDCGNKPHD_sortItem : SortItem.EpisodeNo);
			}
			{
				PopupFilterSortParts_Title_H1 p = m_setting.m_list_parts[3].m_base as PopupFilterSortParts_Title_H1;
				p.SetTitle(bk.GetMessageByLabel("popup_filter_title_h1"));
				p.SetButton(bk.GetMessageByLabel("popup_sort_filter_reset"), ResetEpisodeFilter2);
			}
			{
				PopupFilterSortParts_Title_H2 p = m_setting.m_list_parts[4].m_base as PopupFilterSortParts_Title_H2;
				p.SetTitle(bk.GetMessageByLabel("popup_filter_mainep_title_h2"));
			}
			{
				PopupFilterSortParts_FilterMainEp p = m_setting.m_list_parts[5].m_base as PopupFilterSortParts_FilterMainEp;
				p.SetBit((uint)(m_setting.m_param.EnableSave ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.CNGFLNMNIMJ_filterMainEp : 0));
			}
			{
				PopupFilterSortParts_Title_H2 p = m_setting.m_list_parts[7].m_base as PopupFilterSortParts_Title_H2;
				p.SetTitle(bk.GetMessageByLabel("popup_filter_series_title_h2"));
			}
			{
				PopupFilterSortParts_FilterSeries p = m_setting.m_list_parts[8].m_base as PopupFilterSortParts_FilterSeries;
				p.SetBit((uint)(m_setting.m_param.EnableSave ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.JFOPNJOOGNI_filterSeriese : 0));
			}
			{
				PopupFilterSortParts_Title_H2 p = m_setting.m_list_parts[10].m_base as PopupFilterSortParts_Title_H2;
				p.SetTitle(bk.GetMessageByLabel("popup_filter_diva_val_title_h3"));
			}
			{
				PopupFilterSortParts_FilterDiva2 p = m_setting.m_list_parts[11].m_base as PopupFilterSortParts_FilterDiva2;
				p.Initialize(GameManager.Instance.ViewPlayerData.NBIGLBMHEDC_Divas, true, 0, 0, false);
				p.SetBit((uint)(m_setting.m_param.EnableSave ? GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.IKEMMEAEPLM_filterDivaAndVal : 0));
			}
		}

		// // RVA: 0xF92874 Offset: 0xF92874 VA: 0xF92874
		private void FainalizeEpisode()
		{
			TodoLogger.LogError(TodoLogger.OldEpisodeFilter, "FainalizeEpisode");
		}

		// // RVA: 0xF92C84 Offset: 0xF92C84 VA: 0xF92C84
		private void FainalizeEpisode2()
		{
			if(!m_setting.m_param.EnableSave)
				return;
			{
				PopupFilterSortParts_Sort2 p = m_setting.m_list_parts[1].m_base as PopupFilterSortParts_Sort2;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.LHPDCGNKPHD_sortItem = (int)p.GetSortItem();
			}
			{
				PopupFilterSortParts_FilterMainEp p = m_setting.m_list_parts[5].m_base as PopupFilterSortParts_FilterMainEp;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.CNGFLNMNIMJ_filterMainEp = (int)p.GetBit();
			}
			{
				PopupFilterSortParts_FilterSeries p = m_setting.m_list_parts[8].m_base as PopupFilterSortParts_FilterSeries;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.JFOPNJOOGNI_filterSeriese = (int)p.GetBit();
			}
			{
				PopupFilterSortParts_FilterDiva2 p = m_setting.m_list_parts[11].m_base as PopupFilterSortParts_FilterDiva2;
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.CEJNPBFIIMJ_EpisodeSelect.IKEMMEAEPLM_filterDivaAndVal = (int)p.GetBit();
			}
		}

		// // RVA: 0xF9422C Offset: 0xF9422C VA: 0xF9422C
		// public void ResetEpisodeFilter() { }

		// // RVA: 0xF94500 Offset: 0xF94500 VA: 0xF94500
		public void ResetEpisodeFilter2()
		{
			{
				PopupFilterSortParts_FilterMainEp p = m_setting.m_list_parts[5].m_base as PopupFilterSortParts_FilterMainEp;
				p.SetBit(0);
			}
			{
				PopupFilterSortParts_FilterSeries p = m_setting.m_list_parts[8].m_base as PopupFilterSortParts_FilterSeries;
				p.SetBit(0);
			}
			{
				PopupFilterSortParts_FilterDiva2 p = m_setting.m_list_parts[11].m_base as PopupFilterSortParts_FilterDiva2;
				p.SetBit(0);
			}
		}

		// // RVA: 0xF922A0 Offset: 0xF922A0 VA: 0xF922A0
		private void InitializeGoDivaMusicSelect()
		{
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.FPMABHADHBB_EventGoDiva saveGoDiva = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.IMEBBACHPAN_EventGoDiva;
			MessageBank bk = MessageManager.Instance.GetBank("menu");
			(m_setting.m_list_parts[0].m_base as PopupFilterSortParts_Title_H1).SetTitle(bk.GetMessageByLabel("popup_filter_title_h1"));
			(m_setting.m_list_parts[0].m_base as PopupFilterSortParts_Title_H1).SetButton(bk.GetMessageByLabel("popup_sort_filter_reset"), ResetGoDivaMusicSelectFilter);
			(m_setting.m_list_parts[1].m_base as PopupFilterSortParts_Title_H2).SetTitle(bk.GetMessageByLabel("popup_filter_godiva_music_exp_title_h2"));
			(m_setting.m_list_parts[2].m_base as PopupFilterSortParts_FilterGoDivaMusicExp).SetBit(m_setting.m_param.EnableSave ? (uint)saveGoDiva.MENIBLFBNLC_FilterMusicExp : 0);
		}

		// // RVA: 0xF93430 Offset: 0xF93430 VA: 0xF93430
		private void FainalizeGoDivaMusicSelect()
		{
			if(!m_setting.m_param.EnableSave)
				return;
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.FPMABHADHBB_EventGoDiva saveGoDiva = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.IMEBBACHPAN_EventGoDiva;
			saveGoDiva.MENIBLFBNLC_FilterMusicExp = (int)(m_setting.m_list_parts[2].m_base as PopupFilterSortParts_FilterGoDivaMusicExp).GetBit();
		}

		// // RVA: 0xF947D8 Offset: 0xF947D8 VA: 0xF947D8
		public void ResetGoDivaMusicSelectFilter()
		{
			(m_setting.m_list_parts[2].m_base as PopupFilterSortParts_FilterGoDivaMusicExp).SetBit(0);
		}

		// // RVA: 0xF916D8 Offset: 0xF916D8 VA: 0xF916D8
		private void InitializeSelectHomeBg()
		{
			MessageBank bk = MessageManager.Instance.GetBank("menu");
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MCINLGMJPDM_SelectHomeBG prop = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GIDCHFBCBML_SelectHomeBG;
			{
				PopupFilterSortParts_Title_H1 p = m_setting.m_list_parts[0].m_base as PopupFilterSortParts_Title_H1;
				p.SetTitle(bk.GetMessageByLabel("popup_filter_title_h1"));
				p.SetButton(bk.GetMessageByLabel("popup_sort_filter_reset"), ResetSelectHomeBg);
			}
			{
				PopupFilterSortParts_Title_H2 p = m_setting.m_list_parts[1].m_base as PopupFilterSortParts_Title_H2;
				p.SetTitle(bk.GetMessageByLabel("popup_filter_rarity_title_h2"));
			}
			{
				PopupFilterSortParts_FilterRarity p = m_setting.m_list_parts[2].m_base as PopupFilterSortParts_FilterRarity;
				p.SetBit((uint)prop.PLNMMHPILLO_FilterRarity);
				p.RarityRestrictions(JKHEOEEPBMJ.DGGEAHIKPBB);
				p.OnClickAllButton(JKHEOEEPBMJ.DGGEAHIKPBB);
			}
			{
				PopupFilterSortParts_Title_H2 p = m_setting.m_list_parts[4].m_base as PopupFilterSortParts_Title_H2;
				p.SetTitle(bk.GetMessageByLabel("popup_filter_series_title_h2"));
			}
			{
				PopupFilterSortParts_FilterSeries p = m_setting.m_list_parts[5].m_base as PopupFilterSortParts_FilterSeries;
				p.SetBit((uint)prop.HBEFGKLLMEC_FilterSeries);
			}
        }

		// // RVA: 0xF93098 Offset: 0xF93098 VA: 0xF93098
		private void FainalizeSelectHomeBg()
		{
            ILDKBCLAFPB.IJDOCJCLAIL_SortProprty.MCINLGMJPDM_SelectHomeBG prop = GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.GIDCHFBCBML_SelectHomeBG;
			{
				PopupFilterSortParts_FilterRarity p = m_setting.m_list_parts[2].m_base as PopupFilterSortParts_FilterRarity;
				prop.PLNMMHPILLO_FilterRarity = (int)p.GetBit();
			}
			{
				PopupFilterSortParts_FilterSeries p = m_setting.m_list_parts[5].m_base as PopupFilterSortParts_FilterSeries;
				prop.HBEFGKLLMEC_FilterSeries = (int)p.GetBit();
			}
		}

		// // RVA: 0xF94928 Offset: 0xF94928 VA: 0xF94928
		public void ResetSelectHomeBg()
		{
			{
				PopupFilterSortParts_FilterRarity p = m_setting.m_list_parts[2].m_base as PopupFilterSortParts_FilterRarity;
				p.SetBit(0);
			}
			{
				PopupFilterSortParts_FilterSeries p = m_setting.m_list_parts[5].m_base as PopupFilterSortParts_FilterSeries;
				p.SetBit(0);
			}
		}
	}
}
