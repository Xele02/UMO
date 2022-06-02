using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_ShopProduct : PopupFilterSortUGUIPartsBase
	{
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateRarity filterRarity;
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterMusicAttr filterAttribute;
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSeries filterSeries;
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterShopHave filterHave;
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateDiva filterDiva;
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSkill filterSkill;
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSkill filterActiveSkill;
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateSkill filterCenterSkill;
		[SerializeField]
		public PopupFilterSortUGUIParts_Sort filterSort;
		[SerializeField]
		public PopupFilterSortUGUIParts_FilterPlateNotes filterNotesExpectation;
		[SerializeField]
		public PopupFilterSortUGUIParts_Title_H1[] titleH1;
		[SerializeField]
		public ContentSizeFitter contentSizeFitter;
		[SerializeField]
		public VerticalLayoutGroup layoutGroup;
	}
}
