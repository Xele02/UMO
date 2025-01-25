using System.Collections;
using UnityEngine.UI;

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
			transform.Find("PopupFilterSortUGUIParts_Title02/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_SortDisplayOrder;
			transform.Find("PopupFilterSortUGUIParts_Title02 (1)/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_FilterFavorite;
			transform.Find("PopupFilterSortUGUIParts_Title02 (3)/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_Attribute;
			transform.Find("PopupFilterSortUGUIParts_Title02 (4)/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_Combo;
			transform.Find("PopupFilterSortUGUIParts_Title02 (5)/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_AchievedReward;
			transform.Find("PopupFilterSortUGUIParts_Title02 (6)/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_UnlockStatus;
			transform.Find("PopupFilterSortUGUIParts_Title02 (7)/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_SongTime;
			transform.Find("PopupFilterSortUGUIParts_Title02 (8)/Title/Text_Title").GetComponent<Text>().text = JpStringLiterals.UMO_UnitNumber;

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
