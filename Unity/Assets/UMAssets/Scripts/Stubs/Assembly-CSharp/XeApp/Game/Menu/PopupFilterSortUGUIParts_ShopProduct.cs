using UnityEngine;
using UnityEngine.UI;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortUGUIParts_ShopProduct : PopupFilterSortUGUIPartsBase
	{
		private void Awake()
		{
			TodoLogger.LogError(0, "Implement monobehaviour");
		}
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

		public override Type MyType { get { TodoLogger.LogError(0, "Type"); return 0; } }
		protected override System.Collections.IEnumerator OnInitialize() { TodoLogger.LogError(0, "OnInitialize"); yield return null; }
	}
}
