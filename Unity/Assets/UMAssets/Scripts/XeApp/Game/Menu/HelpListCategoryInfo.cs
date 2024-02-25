using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class HelpListCategoryInfo
	{
		public string name = ""; // 0x8
		public int uniqueId; // 0xC

		// RVA: 0xE325D8 Offset: 0xE325D8 VA: 0xE325D8
		public HelpListCategoryInfo(VeiwOptionHelpCategoryData view)
		{
			name = view.categoryName;
			uniqueId = view.uniqueId;
		}
	}
}
