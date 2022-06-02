using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortPartsBase : LayoutUGUIScriptBase
	{
		public enum Type
		{
			None = 0,
			TitleH1 = 1,
			TitleH2 = 2,
			Sort = 3,
			FilterDiva = 4,
			FilterSeries = 5,
			FilterMainEp = 6,
			FilterGoDivaExp = 7,
		}

		[SerializeField]
		private RectTransform m_rectSizeGuid;
		[SerializeField]
		protected Type m_type;
	}
}
