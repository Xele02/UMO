using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using XeSys;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_PlateFilter : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateRarity filterRarity; // 0x10
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterMusicAttr filterAttribute; // 0x14
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSeries filterSeries; // 0x18
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateDiva filterDiva; // 0x1C
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSkill filterSkill; // 0x20
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSkill filterActiveSkill; // 0x24
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSkill filterCenterSkill; // 0x28
		[SerializeField]
		public PopupFilterSortUGUIParts_Sort filterSort; // 0x2C
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateNotes filterNotesExpectation; // 0x30
		[SerializeField]
		public PopupFilterSortUGUIParts_Title_H1[] titleH1; // 0x34
		[SerializeField]
		public ContentSizeFitter contentSizeFitter; // 0x38
		[SerializeField]
		public VerticalLayoutGroup layoutGroup; // 0x3C

		public override Type MyType { get { return Type.FilterPlate; } } //0x17982DC

		// [IteratorStateMachineAttribute] // RVA: 0x70985C Offset: 0x70985C VA: 0x70985C
		// RVA: 0x17982E4 Offset: 0x17982E4 VA: 0x17982E4 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x179839C
			filterRarity.Initialize();
			filterAttribute.Initialize();
			filterSeries.Initialize();
			filterSort.Initialize();
			filterDiva.Initialize();
			filterSkill.Initialize();
			filterActiveSkill.Initialize();
			filterCenterSkill.Initialize();
			filterNotesExpectation.Initialize();
			titleH1[0].Initialize();
			titleH1[1].Initialize();
			transform.Find("PopupFilterSortUGUIParts_Title02/Title/Text_Title").GetComponent<Text>().text = MessageManager.Instance.GetMessage("menu", "popup_filter_rarity_title_h2");
			transform.Find("PopupFilterSortUGUIParts_Title02 (4)/Title/Text_Title").GetComponent<Text>().text = MessageManager.Instance.GetMessage("menu", "popup_filter_music_attribute_title_h2");
			transform.Find("PopupFilterSortUGUIParts_Title02 (5)/Title/Text_Title").GetComponent<Text>().text = MessageManager.Instance.GetMessage("menu", "popup_filter_series_title_h2");
			transform.Find("PopupFilterSortUGUIParts_Title02 (7)/Title/Text_Title").GetComponent<Text>().text = MessageManager.Instance.GetMessage("menu", "popup_sort_item_notes_expectation");
			transform.Find("PopupFilterSortUGUIParts_Title02 (6)/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_DivaCompatibility;
			yield break;
		}
	}
}
