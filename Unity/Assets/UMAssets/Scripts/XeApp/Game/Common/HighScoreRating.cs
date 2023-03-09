using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class HighScoreRating
	{
		public enum MusicAttr
		{
			None = 0,
			_MaxNum = 1,
		}

		public class HSRatingData
		{
			public int FreeMusicId { get; set; } // 0x8
			public int Difficulty { get; set; } // 0xC
			public int Score { get; set; } // 0x10
			public int RankNum { get; set; } // 0x14
			public int isLine6 { get; set; } // 0x18
			public int RawScore { get; set; } // 0x1C
		}
		/*
		public class UtaGradeData
		{
			public int grade; // 0x8
			public int rate; // 0xC
			public int pickup; // 0x10
			//public List<MFDJIFIIPJD> items; // 0x14
			public bool isNow; // 0x18

			// RVA: 0xEA6BC0 Offset: 0xEA6BC0 VA: 0xEA6BC0
			public void .ctor() { }

			//// RVA: 0xEA6C90 Offset: 0xEA6C90 VA: 0xEA6C90
			//public void Init(int grade, int rate, int pickup, List<MFDJIFIIPJD> items, bool isNow = False) { }
		}*/

		public const int LIST_UTA_GRADE_MIN = 25;
		public const int LIST_UTA_GRADE_NOWPLUS = 2;
		public const int HSR_RANKING_NUM = 10;
		public HSRatingData[,] hsRatingMusicData; // 0x10

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
			rateAttr = new int[1];
			rateAttr[0] = 0;
			rateTotal = 0;
			hsRatingMusicData = new HSRatingData[10, 1];
			for(int i = 0; i < 10; i++)
			{
				hsRatingMusicData[i, 0] = new HSRatingData();
				hsRatingMusicData[i, 0].FreeMusicId = 0;
				hsRatingMusicData[i, 0].Difficulty = 0;
				hsRatingMusicData[i, 0].Score = 0;
				hsRatingMusicData[i, 0].RawScore = 0;
				hsRatingMusicData[i, 0].isLine6 = 0;
			}
		}

		//// RVA: 0xEA2F84 Offset: 0xEA2F84 VA: 0xEA2F84
		public void CalcUtaRate(JDDGGJCGOPA_RecordMusic rec, bool pubUpd = false)
		{
			BBHNACPENDM_ServerSaveData serverData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			if (rec == null)
				rec = serverData.LCKMBHDMPIP_RecordMusic;
			int rating_coef = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.OHJFBLFELNK["score_rating_coef"];
			List<HSRatingData>[] l = new List<HSRatingData>[1];
			l[0] = new List<HSRatingData>();
			l[0].Clear();
			rateAttr[0] = 0;
			rateTotal = 0;
			for(int i = 0; i < rec.FAMANJGJANN_FreeMusicInfo.Count; i++)
			{
				KEODKEGFDLD_FreeMusicInfo info = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(rec.FAMANJGJANN_FreeMusicInfo[i].FDMENECIKEL_FreeMusicId);
				if(info != null && info.PPEGAKEIEGM_Enabled == 2 && info.DEPGBBJMFED_CategoryId != 5)
				{
					if(rec.FAMANJGJANN_FreeMusicInfo[i].IFNDLIGGGHP_HighScoreScore > 0)
					{
						HSRatingData data = new HSRatingData();
						data.FreeMusicId = info.GHBPLHBNMBK_FreeMusicId;
						data.Difficulty = rec.FAMANJGJANN_FreeMusicInfo[i].NOCLBJAGNHD_HighScoreDiff;
						data.Score = rec.FAMANJGJANN_FreeMusicInfo[i].IFNDLIGGGHP_HighScoreScore / rating_coef;
						data.RawScore = rec.FAMANJGJANN_FreeMusicInfo[i].IFNDLIGGGHP_HighScoreScore;
						data.isLine6 = rec.FAMANJGJANN_FreeMusicInfo[i].AOGEGMMBGEN_HighScoreLine6;
						l[0].Add(data);
					}
				}
			}
			if(l[0].Count > 0)
			{
				l[0].Sort((HSRatingData a, HSRatingData b) =>
				{
					//0xEA759C
					if (a.Score != b.Score)
						return a.Score.CompareTo(b.Score);
					return a.FreeMusicId.CompareTo(b.FreeMusicId);
				});
				rateAttr[0] = 0;
				int cnt = l[0].Count;
				if (cnt > 9)
					cnt = 10;
				int score = 0;
				for (int i = 1; i <= cnt; i++)
				{
					rateAttr[0] += l[0][i].Score;
					hsRatingMusicData[i - 1, 0].FreeMusicId = l[0][i].FreeMusicId;
					hsRatingMusicData[i - 1, 0].Difficulty = l[0][i].Difficulty;
					hsRatingMusicData[i - 1, 0].Score = l[0][i].Score;
					hsRatingMusicData[i - 1, 0].RawScore = l[0][i].RawScore;
					hsRatingMusicData[i - 1, 0].isLine6 = l[0][i].isLine6;
					int rank = 0;
					if(score < 1 || hsRatingMusicData[i - 1, 0].Score != score)
					{
						rank = i;
					}
					else
					{
						rank = hsRatingMusicData[i - 2, 0].RankNum;
					}
					hsRatingMusicData[i - 1, 0].RankNum = rank;
					score = hsRatingMusicData[i - 1, 0].Score;
				}
				rateTotal += rateAttr[0];
			}
			if (pubUpd)
				UpdatePublicStatus();
		}

		//// RVA: 0xEA4408 Offset: 0xEA4408 VA: 0xEA4408
		//public void CalcUtaRateForLog(JDDGGJCGOPA rec, int freeMusicId, int lastDifficulty, int lastRatingScore) { }

		//// RVA: 0xEA5310 Offset: 0xEA5310 VA: 0xEA5310
		public void CalcUtaRate(List<JNMFKOHFAFB_PublicStatus.LBGEDDJKOKF> hsRatings)
		{
			int coef = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.OHJFBLFELNK["score_rating_coef"];
			rateAttr[0] = 0;
			rateTotal = 0;
			if(hsRatings.Count > 0)
			{
				rateAttr[0] = 0;
				int score = 0;
				int curRank = 1;
				for(int i = 0; i < 10; i++)
				{
					if(hsRatings[0].BDCAICINCKK_GetScore(i) > 0)
					{
						rateAttr[0] += hsRatings[0].BDCAICINCKK_GetScore(i);
						hsRatingMusicData[i, 0].FreeMusicId = hsRatings[0].MLKHJPBAFCO_GetFreeMusicId(i);
						hsRatingMusicData[i, 0].Difficulty = hsRatings[0].FFACBDAJJJP_GetDifficulty(i);
						hsRatingMusicData[i, 0].Score = hsRatings[0].BDCAICINCKK_GetScore(i);
						hsRatingMusicData[i, 0].isLine6 = hsRatings[0].MJKFDJIPMMB_GetL6(i);
						int rank = 0;
						if(score < 1 || hsRatingMusicData[i, 0].Score != score)
						{
							rank = curRank;
						}
						else
						{
							rank = hsRatingMusicData[i - 1, 0].RankNum;
						}
						hsRatingMusicData[i, 0].RankNum = rank;
						score = hsRatingMusicData[i, 0].Score;
						curRank++;
					}
				}
				rateTotal += rateAttr[0];
			}
		}

		//// RVA: 0xEA3F80 Offset: 0xEA3F80 VA: 0xEA3F80
		private void UpdatePublicStatus()
		{
			JNMFKOHFAFB_PublicStatus.LBGEDDJKOKF rating = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MHEAEGMIKIE_PublicStatus.AEIADFODLMC_HsRating[0];
			rating.KMBPACJNEOF_Reset();
			for(int i = 0; i < 10; i++)
			{
				rating.GMLHMKAMOEN_SetFreeMusicId(i, hsRatingMusicData[i, 0].FreeMusicId);
				rating.HJHBGHMNGKL_SetDifficulty(i, hsRatingMusicData[i, 0].Difficulty);
				rating.ECKFCIHPHGJ_SetScore(i, hsRatingMusicData[i, 0].Score);
				rating.HPDBEKAGKOD_SetL6(i, hsRatingMusicData[i, 0].isLine6);
			}
		}

		//// RVA: 0xEA5AFC Offset: 0xEA5AFC VA: 0xEA5AFC
		public static int GetUtaRate(JDDGGJCGOPA_RecordMusic rec, int free_music_id)
		{
			JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo info = rec.FAMANJGJANN_FreeMusicInfo.Find((JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo x) =>
			{
				//0xEA7684
				return free_music_id == x.FDMENECIKEL_FreeMusicId;
			});
			int coef = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.OHJFBLFELNK["score_rating_coef"];
			int val = info.IFNDLIGGGHP_HighScoreScore;
			if (val > 0)
				return val / coef;
			return 0;
		}

		//// RVA: 0xEA5D28 Offset: 0xEA5D28 VA: 0xEA5D28
		//public static int CalcUtaRate(int rating_score) { }

		//// RVA: 0xEA5E50 Offset: 0xEA5E50 VA: 0xEA5E50
		public static int GetUtaRate(int free_music_id)
		{
			return GetUtaRate(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic, free_music_id);
		}

		//// RVA: 0xEA5F18 Offset: 0xEA5F18 VA: 0xEA5F18
		public int GetUtaRateAttr(int attr = 0)
		{
			if (attr != 0)
				return 0;
			return rateAttr[0];
		}

		//// RVA: 0xEA5F6C Offset: 0xEA5F6C VA: 0xEA5F6C
		//public int GetUtaRateTotal(List<JNMFKOHFAFB.LBGEDDJKOKF> hsRatingInfoList) { }

		//// RVA: 0xEA606C Offset: 0xEA606C VA: 0xEA606C
		public int GetUtaRateTotal()
		{
			int ratelimit = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.LPJLEHAJADA("uta_rate_total_limit", 99999);
			if (rateTotal <= ratelimit)
				return rateTotal;
			return ratelimit;
		}

		//// RVA: 0xEA6180 Offset: 0xEA6180 VA: 0xEA6180
		public static HighScoreRatingRank.Type GetUtaGrade(int total)
		{
			for(int i = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO.Count - 1; i >= 0;  i--)
			{
				if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO[i].ADKDHKMPMHP <= total)
					return (HighScoreRatingRank.Type)(i + 1);
			}
			return HighScoreRatingRank.Type.Be;
		}

		//// RVA: 0xEA6324 Offset: 0xEA6324 VA: 0xEA6324
		public HighScoreRatingRank.Type GetUtaGrade()
		{
			return GetUtaGrade(GetUtaRateTotal());
		}

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
