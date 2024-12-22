using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_ShopProduct : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateRarity filterRarity; // 0x10
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterMusicAttr filterAttribute; // 0x14
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSeries filterSeries; // 0x18
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterShopHave filterHave; // 0x1C
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateDiva filterDiva; // 0x20
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSkill filterSkill; // 0x24
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSkill filterActiveSkill; // 0x28
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSkill filterCenterSkill; // 0x2C
		[SerializeField]
		public PopupFilterSortUGUIParts_Sort filterSort; // 0x30
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateNotes filterNotesExpectation; // 0x34
		[SerializeField]
		public PopupFilterSortUGUIParts_Title_H1[] titleH1; // 0x38
		[SerializeField]
		public ContentSizeFitter contentSizeFitter; // 0x3C
		[SerializeField]
		public VerticalLayoutGroup layoutGroup; // 0x40

		public override Type MyType { get { return Type.FilterShopProduct; } } //0x17992D8

		// [IteratorStateMachineAttribute] // RVA: 0x709A6C Offset: 0x709A6C VA: 0x709A6C
		// RVA: 0x17992E0 Offset: 0x17992E0 VA: 0x17992E0 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1799398
			filterRarity.Initialize();
			filterAttribute.Initialize();
			filterSeries.Initialize();
			filterHave.Initialize();
			filterSort.Initialize();
			filterDiva.Initialize();
			filterSkill.Initialize();
			filterActiveSkill.Initialize();
			filterCenterSkill.Initialize();
			filterNotesExpectation.Initialize();
			titleH1[0].Initialize();
			titleH1[1].Initialize();
			yield break;
		}
	}
}
