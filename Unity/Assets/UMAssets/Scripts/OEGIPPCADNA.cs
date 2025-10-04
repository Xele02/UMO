
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Localization.SmartFormat;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;


public class JFCBDOJBKNG
{
	private static string ODFODCGDAHD = ""; // 0x0
	private const string AAGJILMIBKD_uta_rate_ranking = "uta_rate_ranking";

	//public static string LMPCPCAIEHH_EventRankingKey { get; } 0x1C433A4

	// RVA: 0x1C433A4 Offset: 0x1C433A4 VA: 0x1C433A4
	public static string AJAHDNPMPHA_GetEventRankingKey()
	{
		if(ODFODCGDAHD == "")
		{
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				ODFODCGDAHD = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL_GetStringParam("uta_rate_event_ranking_key", "uta_rate_ranking");
			}
		}
		return ODFODCGDAHD;
	}
}

public class OEGIPPCADNA
{
	public class JCDOJGNNIIL
	{
		public int LLNHMMBFPMA_ScoreRatingRanking; // 0x8
		public List<int> LJNPPPOBHFK_ItemIds = new List<int>(); // 0xC
		public List<int> CCAPNEAOIBP_ItemCount = new List<int>(); // 0x10
	}

	public bool PLOOEECNHFB_IsDone; // 0x8
	public bool NPNNPNAIONN_IsError; // 0x9
	public bool FKKDIDMGLMI_IsDroppedPlayer; // 0xA
	public bool FLCLIHBOHCH = true; // 0xB
	public bool DPPIBCENJJJ; // 0xC
	public int DPDCIICKJEJ; // 0x10
	private int MCILHNEDPBM; // 0x14
	public List<RankingListInfo> HGGPIBNLALJ = new List<RankingListInfo>(); // 0x18
	public List<RankingListInfo> BMKBAMFBAPJ = new List<RankingListInfo>(); // 0x1C

	public static OEGIPPCADNA HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF_bgs NKACBOEHELJ_bgs OKPMHKNCNAL_bgs
	public int CDINKAANIAA_Rank { get { return MCILHNEDPBM; } set { return; } } //0x1B3C7CC AHHAOMGOPKA_bgs 0x1B3C7D4 OGJPMBDLJDA_bgs

	//// RVA: 0x1B3C7D8 Offset: 0x1B3C7D8 VA: 0x1B3C7D8
	public void IJBGPAENLJA_OnAwake(MonoBehaviour _DANMJLOBLIE_mb)
	{
		HHCJCDFCLOB = this;
	}

	//// RVA: 0x1B3C83C Offset: 0x1B3C83C VA: 0x1B3C83C
	public List<int> IFHPGJGLPPF_GetRankingThreshold()
	{
		List<int> res = new List<int>();
		if(IMMAOANGPNK.HHCJCDFCLOB != null)
		{
			string ranking_threshold = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.EFEGBHACJAL_GetStringParam("ranking_threshold", "1,100,500,1000");
			string[] ranking_thresholds = ranking_threshold.Split(new char[] { ',' });
			for(int i = 0; i < ranking_thresholds.Length; i++)
			{
				res.Add(int.Parse(ranking_thresholds[i]));
			}
			res.Sort((int _HKICMNAACDA_a, int _BNKHBCBJBKI_b) =>
			{
				//0x1B3E6A8
				return _HKICMNAACDA_a - _BNKHBCBJBKI_b;
			});
		}
		return res;
	}

	//// RVA: 0x1B3CB5C Offset: 0x1B3CB5C VA: 0x1B3CB5C
	public void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		DPPIBCENJJJ = false;
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(JFCBDOJBKNG.AJAHDNPMPHA_GetEventRankingKey(), PFFJNEFNAMI, _CJHEHIMLGGL_Position, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0x1B3E6B0
				PLOOEECNHFB_IsDone = true;
				HGGPIBNLALJ.Clear();
				if(MAGKKPOFJIM != null)
				{
					EJHFJGKPHCM(NEFEFHBHFFF, MAGKKPOFJIM, _CJHEHIMLGGL_Position);
				}
				if (_KLMFJJCNBIP_OnSuccess != null)
					_KLMFJJCNBIP_OnSuccess();
			}, () =>
			{
				//0x1B3E7B0
				PLOOEECNHFB_IsDone = true;
				if (_IDAEHNGOKAE_OnRankingError != null)
					_IDAEHNGOKAE_OnRankingError();
			}, () =>
			{
				//0x1B3E7F0
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				if (_JGKOLBLPMPG_OnFail != null)
					_JGKOLBLPMPG_OnFail();
			}, true);
	}

	//// RVA: 0x1B3CD88 Offset: 0x1B3CD88 VA: 0x1B3CD88
	public void JPNACOLKHLB_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, int KKGKLNDOCFI, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(_CJHEHIMLGGL_Position, NEFEFHBHFFF, (int _JGNBPFCJLKI_d, List<IBIGBMDANNM> MAGKKPOFJIM) =>
		{
			//0x1B3E848
			PLOOEECNHFB_IsDone = true;
			BMKBAMFBAPJ.Clear();
			if(MAGKKPOFJIM == null)
			{
				if (NEFEFHBHFFF > 0)
					DPPIBCENJJJ = true;
			}
			else
			{
				if(MAGKKPOFJIM.Count < 1 && NEFEFHBHFFF > 0)
				{
					DPPIBCENJJJ = true;
				}
				CBDFJFCGKNK(_JGNBPFCJLKI_d, MAGKKPOFJIM, KKGKLNDOCFI);
				if (_KLMFJJCNBIP_OnSuccess != null)
					_KLMFJJCNBIP_OnSuccess();
			}
		}, () =>
		{
			//0x1B3E9BC
			PLOOEECNHFB_IsDone = true;
			if (_IDAEHNGOKAE_OnRankingError != null)
				_IDAEHNGOKAE_OnRankingError();
		}, () =>
		{
			//0x1B3E9FC
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			if (_JGKOLBLPMPG_OnFail != null)
				_JGKOLBLPMPG_OnFail();
		}, true);
	}

	//// RVA: 0x1B3CF94 Offset: 0x1B3CF94 VA: 0x1B3CF94
	public void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO, bool _FBBNPFFEJBN_Force/* = false*/, IMCBBOAFION KLMFJJCNBIP_OnSuccess/* = null*/, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError/* = null*/, DJBHIFLHJLK _JGKOLBLPMPG_OnFail/* = null*/)
	{
		KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(JFCBDOJBKNG.AJAHDNPMPHA_GetEventRankingKey(), () =>
		{
			//0x1B3EA54
			MCILHNEDPBM = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
			DPDCIICKJEJ = (int)KKLGENJKEBN.HHCJCDFCLOB.IPNEJCOFBIB_ScoreTrunc;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.AILEOFKIELL_UtaRateRank = MCILHNEDPBM;
			PLOOEECNHFB_IsDone = true;
			KLMFJJCNBIP_OnSuccess();
		}, () =>
		{
			//0x1B3EBF0
			MCILHNEDPBM = 0;
			DPDCIICKJEJ = 0;
			PLOOEECNHFB_IsDone = true;
			_IDAEHNGOKAE_OnRankingError();
		}, () =>
		{
			//0x1B3EC64
			MCILHNEDPBM = 0;
			DPDCIICKJEJ = 0;
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_JGKOLBLPMPG_OnFail();
		}, () =>
		{
			//0x1B3ECF0
			MCILHNEDPBM = 0;
			DPDCIICKJEJ = 0;
			PLOOEECNHFB_IsDone = true;
			FKKDIDMGLMI_IsDroppedPlayer = true;
		});
	}

	//// RVA: 0x1B3D1B0 Offset: 0x1B3D1B0 VA: 0x1B3D1B0
	public void FGMOMBKGCNF_UpdateRankingValue(int DPDCIICKJEJ/* = 0*/, IMCBBOAFION _KLMFJJCNBIP_OnSuccess/* = null*/, DJBHIFLHJLK NIMPEHIECJH/* = null*/, DJBHIFLHJLK _JGKOLBLPMPG_OnFail/* = null*/)
	{
		int utaRate = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.EAHPKPADCPL_total_uta_rate;
		if (utaRate < DPDCIICKJEJ)
			utaRate = DPDCIICKJEJ;
		KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(JFCBDOJBKNG.AJAHDNPMPHA_GetEventRankingKey(), 0, utaRate, () =>
		{
			//0x1B3ED68
			PLOOEECNHFB_IsDone = true;
			_KLMFJJCNBIP_OnSuccess();
		}, () =>
		{
			//0x1B3EDA8
			PLOOEECNHFB_IsDone = true;
			NIMPEHIECJH();
		}, () =>
		{
			//0x1B3EDE8
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_JGKOLBLPMPG_OnFail();
		});
	}

	//// RVA: 0x1B3D458 Offset: 0x1B3D458 VA: 0x1B3D458
	//public long FBGDBGKNKOD_GetCurrentPoint() { }

	//// RVA: 0x1B3D538 Offset: 0x1B3D538 VA: 0x1B3D538
	private void EJHFJGKPHCM(int NEFEFHBHFFF, List<IBIGBMDANNM> NNDGIAEFMOG, int KKGKLNDOCFI)
	{
		if(NNDGIAEFMOG != null)
		{
			for(int i = 0; i < NNDGIAEFMOG.Count; i++)
			{
				RankingListInfo r = HGGPIBNLALJ.Find((RankingListInfo _GHPLINIACBB_x) =>
				{
					//0x1B3EE40
					return _GHPLINIACBB_x.friend.MLPEHNBNOGD_PlayerId == NNDGIAEFMOG[i].MLPEHNBNOGD_PlayerId;
				});
				if(r == null)
				{
					if(KKGKLNDOCFI <= NNDGIAEFMOG[i].FJOLNJLLJEJ_rank)
					{
						EAJCBFGKKFA_FriendInfo data = new EAJCBFGKKFA_FriendInfo();
						data.KHEKNNFCAOI_Init(NNDGIAEFMOG[i]);
						HGGPIBNLALJ.Add(new RankingListInfo(i, true, data));
					}
				}
			}
		}
	}

	//// RVA: 0x1B3D920 Offset: 0x1B3D920 VA: 0x1B3D920
	private void CBDFJFCGKNK(int NEFEFHBHFFF, List<IBIGBMDANNM> NNDGIAEFMOG, int KKGKLNDOCFI)
	{
		if(NNDGIAEFMOG != null)
		{
			for(int i = 0; i < NNDGIAEFMOG.Count; i++)
			{
				RankingListInfo r = HGGPIBNLALJ.Find((RankingListInfo _GHPLINIACBB_x) =>
				{
					//0x1B3EF30
					return _GHPLINIACBB_x.friend.MLPEHNBNOGD_PlayerId == NNDGIAEFMOG[i].MLPEHNBNOGD_PlayerId;
				});
				if(r == null)
				{
					EAJCBFGKKFA_FriendInfo data = new EAJCBFGKKFA_FriendInfo();
					data.KHEKNNFCAOI_Init(NNDGIAEFMOG[i]);
					if (NEFEFHBHFFF < 0)
						HGGPIBNLALJ.Insert(i, new RankingListInfo(i, true, data));
					else
						HGGPIBNLALJ.Add(new RankingListInfo(i, true, data));
				}
			}
		}
	}

	//// RVA: 0x1B3DD08 Offset: 0x1B3DD08 VA: 0x1B3DD08
	public static int BFKAHKBKBJE(int _BDGDHOAJDFM__rank, long APLJPFGAAHN)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			int a = _BDGDHOAJDFM__rank;
			int rangemax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.LPJLEHAJADA_GetIntParam("uta_ranking_range_max", 10000);
			int login_elapsed = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.LPJLEHAJADA_GetIntParam("uta_ranking_login_elapsed_day", 90);
			if (rangemax != 0)
			{
				a = -1;
			}
			if(rangemax <= _BDGDHOAJDFM__rank)
			{
				_BDGDHOAJDFM__rank = a;
			}
			long serverTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if (APLJPFGAAHN != 0 && (login_elapsed * 86400) < (serverTime - APLJPFGAAHN))
			{
				_BDGDHOAJDFM__rank = -2;
			}
		}
		return _BDGDHOAJDFM__rank;
	}

	//// RVA: 0x1B3DF30 Offset: 0x1B3DF30 VA: 0x1B3DF30
	public static string GEEFFAEGHAH(int _BDGDHOAJDFM__rank, bool DECFKDIGIJL/* = true*/)
	{
		string str = MessageManager.Instance.GetBank("menu").GetMessageByLabel("utaraterank_none");
		if(_BDGDHOAJDFM__rank < 1)
		{
			if(_BDGDHOAJDFM__rank == -2)
				str = MessageManager.Instance.GetBank("menu").GetMessageByLabel("utaraterank_over_login");
			else if(_BDGDHOAJDFM__rank == -1)
				str = MessageManager.Instance.GetBank("menu").GetMessageByLabel("utaraterank_over_ranking");
		}
		else if(DECFKDIGIJL)
		{
			str = _BDGDHOAJDFM__rank.ToString() + Smart.Format(MessageManager.Instance.GetBank("menu").GetMessageByLabel("event_music_ranking_unit"), _BDGDHOAJDFM__rank);
		}
		return str;
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BE1F4 Offset: 0x6BE1F4 VA: 0x6BE1F4
	//// RVA: 0x1B3E0D0 Offset: 0x1B3E0D0 VA: 0x1B3E0D0
	public IEnumerator JAAOHPKMEAF_Coroutine_Receive_UnreceivedAchivements(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		BBHNACPENDM_ServerSaveData KLCOAGDOJPL; // 0x20
		List<string> HLOHHJKCOIP; // 0x24
		List<JCDOJGNNIIL> NLLKGEGPLGO; // 0x28
		int AGOPAMONHHJ; // 0x2C
		int NDCHNBGOICA; // 0x30

		//0x1B3F31C
		KLCOAGDOJPL = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null || KLCOAGDOJPL == null)
		{
			//joined_r0x01b404dc
			if (_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
			yield break;
		}
		bool PLOOEECNHFB_IsDone = false;
		bool NPNNPNAIONN_IsError = false;
		StringBuilder str = new StringBuilder(256);
		HLOHHJKCOIP = new List<string>();
		List<string> CLPMDJFKJBO = new List<string>();
		NLLKGEGPLGO = new List<JCDOJGNNIIL>();
		List<int> l1 = new List<int>();
		List<int> l2 = new List<int>();
		string s = "rating_reward_receive_key_";
		AGOPAMONHHJ = (int)HighScoreRating.GetUtaGrade(KLCOAGDOJPL.KCCLEHLLOFG_Common.EAHPKPADCPL_total_uta_rate);
		int start = KLCOAGDOJPL.KCCLEHLLOFG_Common.EAFLCGCIOND_RetRewRecGra;
		if (start < AGOPAMONHHJ)
		{
			for(int i = start; i < AGOPAMONHHJ; i++)
			{
				if(start > -1)
				{
					HGPEFPFODHO_HighScoreRanking.LGNDICJEDNE dbrating = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO[i];
					int b = dbrating.BGFPPGPJONG_QuestKeyId;
					for(int j = 0; j < dbrating.AJMDFJFCIML_GetCount(); j++)
					{
						l1.Add(dbrating.NKOHMLHLJGL_GetItemCount(j));
					}
					for(int j = 0; j < dbrating.HKDBDPPDCFG(); j++)
					{
						l2.Add(dbrating.FKNBLDPIPMC_GetItemCode(j));
					}
					if (AGOPAMONHHJ < dbrating.PPFNGGCBJKC_id)
						break;
					JCDOJGNNIIL data = new JCDOJGNNIIL();
					data.LLNHMMBFPMA_ScoreRatingRanking = dbrating.PPFNGGCBJKC_id;
					if (b > 0)
					{
						str.Clear();
						str.AppendFormat(s + b.ToString(), Array.Empty<object>());
						HLOHHJKCOIP.Add(str.ToString());
						for(int j = 0; j < l2.Count; j++)
						{
							data.LJNPPPOBHFK_ItemIds.Add(l2[j]);
						}
						for (int j = 0; j < l1.Count; j++)
						{
							data.CCAPNEAOIBP_ItemCount.Add(l1[j]);
						}
					}
					if(dbrating.GCKPDEDJFIC_ItemCount < 1)
					{
						if (b < 1)
							continue;
					}
					else
					{
						str.Clear();
						str.AppendFormat(s + dbrating.ICGAKKCCFOG, Array.Empty<object>());
						HLOHHJKCOIP.Add(str.ToString());
						data.LJNPPPOBHFK_ItemIds.Add(dbrating.HDOEJDHGFLH_ItemFullId);
						data.CCAPNEAOIBP_ItemCount.Add(dbrating.GCKPDEDJFIC_ItemCount);
					}
					NLLKGEGPLGO.Add(data);
				}
			}
		}
		NDCHNBGOICA = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("utarate_vc_achvment_get_count", 30);
		while(HLOHHJKCOIP.Count > 0)
		{
			List<string> ls = new List<string>();
			if(NDCHNBGOICA < HLOHHJKCOIP.Count)
			{
				for(int i = 0; i < NDCHNBGOICA; i++)
				{
					ls.Add(HLOHHJKCOIP[0]);
					HLOHHJKCOIP.RemoveAt(0);
				}
			}
			else
			{
				for(int i = 0; i < HLOHHJKCOIP.Count; i++)
				{
					ls.Add(HLOHHJKCOIP[i]);
				}
				HLOHHJKCOIP.Clear();
			}
			CLPMDJFKJBO.Clear();
			JGMEFHJCNHP_GetAchievementRecords req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JGMEFHJCNHP_GetAchievementRecords());
			req.KMOBDLBKAAA_Repeatable = false;
			req.MIDAMHNABAJ_Keys = ls;
			PLOOEECNHFB_IsDone = false;
			NPNNPNAIONN_IsError = false;
			CACGCMBKHDI_Request.HDHIKGLMOGF CMJMGEFNBDK = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x1B3F028
				JGMEFHJCNHP_GetAchievementRecords r = NHECPMNKEFK as JGMEFHJCNHP_GetAchievementRecords;
				for(int i = 0; i < r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes.Count; i++)
				{
					if(!r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].OOIJCMLEAJP_is_received)
					{
						CLPMDJFKJBO.Add(r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].LJNAKDMILMC_key);
					}
				}
				PLOOEECNHFB_IsDone = true;
			};
			req.BHFHGFKBOHH_OnSuccess = CMJMGEFNBDK;
			CACGCMBKHDI_Request.HDHIKGLMOGF DMLJLPMBLCH = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x1B3F2DC
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
			};
			req.MOBEEPPKFLG_OnFail = DMLJLPMBLCH;
			while (!PLOOEECNHFB_IsDone)
				yield return null;
			if(NPNNPNAIONN_IsError)
			{
				//LAB_01b404d0
				if (_MOBEEPPKFLG_OnFail != null)
					_MOBEEPPKFLG_OnFail();
				yield break;
			}
			if(CLPMDJFKJBO.Count > 0)
			{
				PLOOEECNHFB_IsDone = false;
				NPNNPNAIONN_IsError = false;
				FLONELKGABJ_ClaimAchievementPrizes req2 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
				req2.KMOBDLBKAAA_Repeatable = false;
				req2.MIDAMHNABAJ_Keys = CLPMDJFKJBO;
				CACGCMBKHDI_Request.HDHIKGLMOGF EEIFDMNADPA = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x1B3F2E8
					PLOOEECNHFB_IsDone = true;
				};
				req2.BHFHGFKBOHH_OnSuccess = EEIFDMNADPA;
				CACGCMBKHDI_Request.HDHIKGLMOGF NDBKOPGCPHJ = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x1B3F2F4
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
				};
				req2.MOBEEPPKFLG_OnFail = EEIFDMNADPA;
				while (!PLOOEECNHFB_IsDone)
					yield return null;
				if(NPNNPNAIONN_IsError)
				{
					//LAB_01b404d0
					if (_MOBEEPPKFLG_OnFail != null)
						_MOBEEPPKFLG_OnFail();
					yield break;
				}
			}
		}
		FBKCFKPLMAL_AddItems(NLLKGEGPLGO);
		KLCOAGDOJPL.KCCLEHLLOFG_Common.EAFLCGCIOND_RetRewRecGra = AGOPAMONHHJ;
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
		{
			//0x1B3F300
			PLOOEECNHFB_IsDone = true;
		}, () =>
		{
			//0x1B3F30C
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
		}, null);
		//LAB_01b4010c
		while (!PLOOEECNHFB_IsDone)
			yield return null;
		if(!NPNNPNAIONN_IsError)
		{
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			if (_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
		}
	}

	//// RVA: 0x1B3E1B0 Offset: 0x1B3E1B0 VA: 0x1B3E1B0
	private void FBKCFKPLMAL_AddItems(List<JCDOJGNNIIL> PFEGHILDOGF)
	{
		JKNGJFOBADP j = new JKNGJFOBADP();
		for (int i = 0; i < PFEGHILDOGF.Count; i++)
		{
			j.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MDPHOJAPCCC, PFEGHILDOGF[i].LLNHMMBFPMA_ScoreRatingRanking.ToString());
			for(int k = 0; k < PFEGHILDOGF[i].LJNPPPOBHFK_ItemIds.Count; k++)
			{
				int id = PFEGHILDOGF[i].LJNPPPOBHFK_ItemIds[k];
				j.NGEPPDAOIBN(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id), EKLNMHFCAOI.DEACAHNLMNI_getItemId(id), PFEGHILDOGF[i].CCAPNEAOIBP_ItemCount[k], 0, EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id), EKLNMHFCAOI.DEACAHNLMNI_getItemId(id)));
			}
		}
	}
}
