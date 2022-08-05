namespace XeApp.Game.Common
{
	public class HighScoreRating
	{
		public const int LIST_UTA_GRADE_MIN = 25;
		public const int LIST_UTA_GRADE_NOWPLUS = 2;
		public const int HSR_RANKING_NUM = 10;
		public HighScoreRating.HSRatingData[,] hsRatingMusicData; // 0x10

		public int[] rateAttr { get; private set; } // 0x8
		public int rateTotal { get; private set; } // 0xC

		// RVA: 0xEA2B7C Offset: 0xEA2B7C VA: 0xEA2B7C
		public HighScoreRating()
		{
			Init();
		}

		// RVA: 0xEA2B9C Offset: 0xEA2B9C VA: 0xEA2B9C
		public void Init()
		{
			UnityEngine.Debug.LogError("TODO HighScoreRating");
		}

		//// RVA: 0xEA2F84 Offset: 0xEA2F84 VA: 0xEA2F84
		//public void CalcUtaRate(JDDGGJCGOPA rec, bool pubUpd = False) { }

		//// RVA: 0xEA4408 Offset: 0xEA4408 VA: 0xEA4408
		//public void CalcUtaRateForLog(JDDGGJCGOPA rec, int freeMusicId, int lastDifficulty, int lastRatingScore) { }

		//// RVA: 0xEA5310 Offset: 0xEA5310 VA: 0xEA5310
		//public void CalcUtaRate(List<JNMFKOHFAFB.LBGEDDJKOKF> hsRatings) { }

		//// RVA: 0xEA3F80 Offset: 0xEA3F80 VA: 0xEA3F80
		//private void UpdatePublicStatus() { }

		//// RVA: 0xEA5AFC Offset: 0xEA5AFC VA: 0xEA5AFC
		// public static int GetUtaRate(JDDGGJCGOPA rec, int free_music_id)

		//// RVA: 0xEA5D28 Offset: 0xEA5D28 VA: 0xEA5D28
		//public static int CalcUtaRate(int rating_score) { }

		//// RVA: 0xEA5E50 Offset: 0xEA5E50 VA: 0xEA5E50
		public static int GetUtaRate(int free_music_id)
		{
			UnityEngine.Debug.LogError("GetUtaRate");
			return 0;
		}

		//// RVA: 0xEA5F18 Offset: 0xEA5F18 VA: 0xEA5F18
		//public int GetUtaRateAttr(int attr = 0) { }

		//// RVA: 0xEA5F6C Offset: 0xEA5F6C VA: 0xEA5F6C
		//public int GetUtaRateTotal(List<JNMFKOHFAFB.LBGEDDJKOKF> hsRatingInfoList) { }

		//// RVA: 0xEA606C Offset: 0xEA606C VA: 0xEA606C
		//public int GetUtaRateTotal() { }

		//// RVA: 0xEA6180 Offset: 0xEA6180 VA: 0xEA6180
		//public static HighScoreRatingRank.Type GetUtaGrade(int total) { }

		//// RVA: 0xEA6324 Offset: 0xEA6324 VA: 0xEA6324
		//public HighScoreRatingRank.Type GetUtaGrade() { }

		//// RVA: 0xEA6338 Offset: 0xEA6338 VA: 0xEA6338
		//public static HighScoreRatingRank.Type GetReceivedRewardUtaGrade() { }

		//// RVA: 0xEA6414 Offset: 0xEA6414 VA: 0xEA6414
		//public static bool IsNotReceivedRewardUtaGrade() { }

		//// RVA: 0xEA6544 Offset: 0xEA6544 VA: 0xEA6544
		//public static int GetNextUtaGradeNum(int rateTotal) { }

		//// RVA: 0xEA66C8 Offset: 0xEA66C8 VA: 0xEA66C8
		//public HighScoreRating.UtaGradeData GetNextUtaGradeInfo(int rateTotal) { }

		//// RVA: 0xEA6D38 Offset: 0xEA6D38 VA: 0xEA6D38
		//public HighScoreRating.UtaGradeData GetNextUtaGradeInfo() { }

		//// RVA: 0xEA6D50 Offset: 0xEA6D50 VA: 0xEA6D50
		//public List<HighScoreRating.UtaGradeData> GetUtaGradeList(HighScoreRatingRank.Type nowGrade) { }

		//// RVA: 0xEA72FC Offset: 0xEA72FC VA: 0xEA72FC
		//public List<HighScoreRating.UtaGradeData> GetUtaGradeList() { }

		//// RVA: 0xEA7318 Offset: 0xEA7318 VA: 0xEA7318
		//public List<HighScoreRating.UtaGradeData> GetNotReceivedRewardUtaGradeList(int nowGrade = 0, int prevGrade = 0) { }
	}
}
