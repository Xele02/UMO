using System.Collections;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_FilterMusicSelect : PopupFilterSortUGUIPartsBase
	{
		public PopupFilterSortUGUIParts_Sort filterSort; // 0x10
		public PopupFilterSortUGUIParts_FilterMusicBookMark filterMusicBookMark; // 0x14
		public PopupFilterSortUGUIParts_FilterMusicAttr filterMusicAttr; // 0x18
		public PopupFilterSortUGUIParts_FilterCombo filterCombo; // 0x1C
		public PopupFilterSortUGUIParts_FilterReward filterReward; // 0x20
		public PopupFilterSortUGUIParts_FilterMusicLock filterMusicLock; // 0x24
		public PopupFilterSortUGUIParts_FilterRange filterRange; // 0x28
		public PopupFilterSortUGUIParts_UnitLive filterUnitLive; // 0x2C
		public PopupFilterSortUGUIParts_Title_H1 titleSort; // 0x30
		public PopupFilterSortUGUIParts_Title_H1 titleFilter; // 0x34

		public override PopupFilterSortUGUIPartsBase.Type MyType { get { return PopupFilterSortUGUIPartsBase.Type.FilterMusicSelect; } } //0x1CA2310

		//[IteratorStateMachineAttribute] // RVA: 0x708DA4 Offset: 0x708DA4 VA: 0x708DA4
		// RVA: 0x1CA2318 Offset: 0x1CA2318 VA: 0x1CA2318 Slot: 5
		protected override IEnumerator OnInitialize()
		{
			//0x1CA23D8
			filterSort.Initialize();
			filterMusicBookMark.Initialize();
			filterMusicAttr.Initialize();
			filterCombo.Initialize();
			filterReward.Initialize();
			filterMusicLock.Initialize();
			filterRange.Initialize();
			filterUnitLive.Initialize();
			titleSort.Initialize();
			titleFilter.Initialize();
			yield break;
		}
	}
}
