
namespace XeApp.Game.Menu
{
	public sealed class GeneralList
	{
		public enum SortOrder
		{
			Ascend = 0,
			Descend = 1,
			_Num = 2,
		}

		public enum RankRange
		{
			Myself = 0,
			Rank1 = 1,
			Rank100 = 2,
			Rank500 = 3,
			Rank1000 = 4,
			Rank5000 = 5,
			_Num = 6,
		}

		public const int SortOrderNum = 2;
		public static readonly string[] SortOrderUvNames = new string[2] { "cmn_btn_orde_fnt_01", "cmn_btn_orde_fnt_02" }; // 0x0
		public const int RankRangeNum = 6;
		public static readonly string[] RankRangeUvNames = new string[6] { "sel_list_pop_fnt01", "sel_list_pop_fnt02",
				"sel_list_pop_fnt03", "sel_list_pop_fnt04", "sel_list_pop_fnt05", "sel_list_pop_fnt06" }; // 0x4
	}


}
