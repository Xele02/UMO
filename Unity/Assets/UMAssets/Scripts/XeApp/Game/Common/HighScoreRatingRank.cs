namespace XeApp.Game.Common
{
	public class HighScoreRatingRank
	{
		public enum Type
		{
			None = 0,
			Be = 1,
		}

		// RVA: 0xEA7758 Offset: 0xEA7758 VA: 0xEA7758
		//public static string GetRankName(HighScoreRatingRank.Type type) { }

		//// RVA: 0xEA78B4 Offset: 0xEA78B4 VA: 0xEA78B4
		//public static string GetRankName(int id) { }

		// RVA: 0xEA798C Offset: 0xEA798C VA: 0xEA798C
		public static int GetRankIDMax()
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO.Count;
		}
	}
}
