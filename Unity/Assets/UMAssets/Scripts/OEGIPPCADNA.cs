
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;


public class JFCBDOJBKNG
{
	private static string ODFODCGDAHD = ""; // 0x0
	private const string AAGJILMIBKD = "uta_rate_ranking";

	public static string LMPCPCAIEHH { get; }

	// RVA: 0x1C433A4 Offset: 0x1C433A4 VA: 0x1C433A4
	public static string AJAHDNPMPHA_GetEventRankingKey()
	{
		if(ODFODCGDAHD == "")
		{
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				ODFODCGDAHD = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("uta_rate_event_ranking_key", "uta_rate_ranking");
			}
		}
		return ODFODCGDAHD;
	}
}

public class OEGIPPCADNA
{
	public class JCDOJGNNIIL
	{
		public int LLNHMMBFPMA; // 0x8
		public List<int> LJNPPPOBHFK = new List<int>(); // 0xC
		public List<int> CCAPNEAOIBP = new List<int>(); // 0x10
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

	public static OEGIPPCADNA HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public int CDINKAANIAA { get { return MCILHNEDPBM; } set { return; } } //0x1B3C7CC AHHAOMGOPKA 0x1B3C7D4 OGJPMBDLJDA

	//// RVA: 0x1B3C7D8 Offset: 0x1B3C7D8 VA: 0x1B3C7D8
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
	}

	//// RVA: 0x1B3C83C Offset: 0x1B3C83C VA: 0x1B3C83C
	//public List<int> IFHPGJGLPPF() { }

	//// RVA: 0x1B3CB5C Offset: 0x1B3CB5C VA: 0x1B3CB5C
	//public void FAMFKPBPIAA(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG) { }

	//// RVA: 0x1B3CD88 Offset: 0x1B3CD88 VA: 0x1B3CD88
	//public void JPNACOLKHLB(int CJHEHIMLGGL, int NEFEFHBHFFF, int KKGKLNDOCFI, IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG) { }

	//// RVA: 0x1B3CF94 Offset: 0x1B3CF94 VA: 0x1B3CF94
	public void MJFKJHJJLMN_GetUtaRateRank(int LHJCOPMMIGO, bool FBBNPFFEJBN = false, IMCBBOAFION KLMFJJCNBIP_OnSuccess = null, DJBHIFLHJLK IDAEHNGOKAE_OnRankingError = null, DJBHIFLHJLK JGKOLBLPMPG_OnError = null)
	{
		KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(JFCBDOJBKNG.AJAHDNPMPHA_GetEventRankingKey(), () =>
		{
			//0x1B3EA54
			MCILHNEDPBM = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA;
			DPDCIICKJEJ = (int)KKLGENJKEBN.HHCJCDFCLOB.IPNEJCOFBIB;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MHEAEGMIKIE_PublicStatus.AILEOFKIELL_UtaRateRank = MCILHNEDPBM;
			PLOOEECNHFB_IsDone = true;
			KLMFJJCNBIP_OnSuccess();
		}, () =>
		{
			//0x1B3EBF0
			MCILHNEDPBM = 0;
			DPDCIICKJEJ = 0;
			PLOOEECNHFB_IsDone = true;
			IDAEHNGOKAE_OnRankingError();
		}, () =>
		{
			//0x1B3EC64
			MCILHNEDPBM = 0;
			DPDCIICKJEJ = 0;
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			JGKOLBLPMPG_OnError();
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
	public void FGMOMBKGCNF_UpdateTotalUtaRate(int DPDCIICKJEJ = 0, IMCBBOAFION KLMFJJCNBIP = null, DJBHIFLHJLK NIMPEHIECJH = null, DJBHIFLHJLK JGKOLBLPMPG = null)
	{
		int utaRate = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.EAHPKPADCPL_TotalUtaRate;
		if (utaRate < DPDCIICKJEJ)
			utaRate = DPDCIICKJEJ;
		KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(JFCBDOJBKNG.AJAHDNPMPHA_GetEventRankingKey(), 0, utaRate, () =>
		{
			//0x1B3ED68
			PLOOEECNHFB_IsDone = true;
			KLMFJJCNBIP();
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
			JGKOLBLPMPG();
		});
	}

	//// RVA: 0x1B3D458 Offset: 0x1B3D458 VA: 0x1B3D458
	//public long FBGDBGKNKOD() { }

	//// RVA: 0x1B3D538 Offset: 0x1B3D538 VA: 0x1B3D538
	//private void EJHFJGKPHCM(int NEFEFHBHFFF, List<IBIGBMDANNM> NNDGIAEFMOG, int KKGKLNDOCFI) { }

	//// RVA: 0x1B3D920 Offset: 0x1B3D920 VA: 0x1B3D920
	//private void CBDFJFCGKNK(int NEFEFHBHFFF, List<IBIGBMDANNM> NNDGIAEFMOG, int KKGKLNDOCFI) { }

	//// RVA: 0x1B3DD08 Offset: 0x1B3DD08 VA: 0x1B3DD08
	public static int BFKAHKBKBJE(int BDGDHOAJDFM, long APLJPFGAAHN)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			int a = BDGDHOAJDFM;
			int rangemax = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.LPJLEHAJADA("uta_ranking_range_max", 10000);
			int login_elapsed = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.LPJLEHAJADA("uta_ranking_login_elapsed_day", 90);
			if (rangemax != 0)
			{
				a = -1;
			}
			if(rangemax <= BDGDHOAJDFM)
			{
				BDGDHOAJDFM = a;
			}
			long serverTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if (APLJPFGAAHN != 0 && (login_elapsed * 86400) < (serverTime - APLJPFGAAHN))
			{
				BDGDHOAJDFM = -2;
			}
		}
		return BDGDHOAJDFM;
	}

	//// RVA: 0x1B3DF30 Offset: 0x1B3DF30 VA: 0x1B3DF30
	public static string GEEFFAEGHAH(int BDGDHOAJDFM, bool DECFKDIGIJL = true)
	{
		string str = MessageManager.Instance.GetBank("menu").GetMessageByLabel("utaraterank_none");
		if(BDGDHOAJDFM < 1)
		{
			if(BDGDHOAJDFM == -2)
				str = MessageManager.Instance.GetBank("menu").GetMessageByLabel("utaraterank_over_login");
			else if(BDGDHOAJDFM == -1)
				str = MessageManager.Instance.GetBank("menu").GetMessageByLabel("utaraterank_over_ranking");
		}
		else if(DECFKDIGIJL)
		{
			str = MessageManager.Instance.GetBank("menu").GetMessageByLabel(BDGDHOAJDFM.ToString()+"event_music_ranking_unit");
		}
		return str;
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BE1F4 Offset: 0x6BE1F4 VA: 0x6BE1F4
	//// RVA: 0x1B3E0D0 Offset: 0x1B3E0D0 VA: 0x1B3E0D0
	public IEnumerator JAAOHPKMEAF_Coroutine_Receive_UnreceivedAchivements(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		BBHNACPENDM_ServerSaveData KLCOAGDOJPL; // 0x20
		List<string> HLOHHJKCOIP; // 0x24
		List<JCDOJGNNIIL> NLLKGEGPLGO; // 0x28
		int AGOPAMONHHJ; // 0x2C
		int NDCHNBGOICA; // 0x30

		//0x1B3F31C
		KLCOAGDOJPL = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null || KLCOAGDOJPL == null)
		{
			//joined_r0x01b404dc
			if (MOBEEPPKFLG != null)
				MOBEEPPKFLG();
			yield break;
		}
		bool PLOOEECNHFB = false;
		bool NPNNPNAIONN = false;
		StringBuilder str = new StringBuilder(256);
		HLOHHJKCOIP = new List<string>();
		List<string> CLPMDJFKJBO = new List<string>();
		NLLKGEGPLGO = new List<JCDOJGNNIIL>();
		List<int> l1 = new List<int>();
		List<int> l2 = new List<int>();
		string s = "rating_reward_receive_key_";
		AGOPAMONHHJ = (int)HighScoreRating.GetUtaGrade(KLCOAGDOJPL.KCCLEHLLOFG_Common.EAHPKPADCPL_TotalUtaRate);
		int start = KLCOAGDOJPL.KCCLEHLLOFG_Common.EAFLCGCIOND_RetRewRecGra;
		if (start < AGOPAMONHHJ)
		{
			for(int i = start; i < AGOPAMONHHJ; i++)
			{
				if(start > -1)
				{
					HGPEFPFODHO_HighScoreRanking.LGNDICJEDNE dbrating = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO[i];
					int b = dbrating.BGFPPGPJONG;
					for(int j = 0; j < dbrating.AJMDFJFCIML_GetCount(); j++)
					{
						l1.Add(dbrating.NKOHMLHLJGL(j));
					}
					for(int j = 0; j < dbrating.HKDBDPPDCFG(); j++)
					{
						l2.Add(dbrating.FKNBLDPIPMC_GetItemId(j));
					}
					if (AGOPAMONHHJ < dbrating.PPFNGGCBJKC)
						break;
					JCDOJGNNIIL data = new JCDOJGNNIIL();
					data.LLNHMMBFPMA = dbrating.PPFNGGCBJKC;
					if (b > 0)
					{
						str.Clear();
						str.AppendFormat(s + b.ToString(), Array.Empty<object>());
						HLOHHJKCOIP.Add(s.ToString());
						for(int j = 0; j < l2.Count; j++)
						{
							data.LJNPPPOBHFK.Add(l2[j]);
						}
						for (int j = 0; j < l1.Count; j++)
						{
							data.CCAPNEAOIBP.Add(l1[j]);
						}
					}
					if(dbrating.GCKPDEDJFIC < 1)
					{
						if (b < 1)
							continue;
					}
					else
					{
						str.Clear();
						str.AppendFormat(s + dbrating.ICGAKKCCFOG, Array.Empty<object>());
						HLOHHJKCOIP.Add(str.ToString());
						data.LJNPPPOBHFK.Add(dbrating.HDOEJDHGFLH_ItemFullId);
						data.CCAPNEAOIBP.Add(dbrating.GCKPDEDJFIC);
					}
					NLLKGEGPLGO.Add(data);
				}
			}
		}
		NDCHNBGOICA = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("utarate_vc_achvment_get_count", 30);
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
			req.KMOBDLBKAAA = false;
			req.MIDAMHNABAJ = ls;
			PLOOEECNHFB = false;
			NPNNPNAIONN = false;
			CACGCMBKHDI_Request.HDHIKGLMOGF CMJMGEFNBDK = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x1B3F028
				JGMEFHJCNHP_GetAchievementRecords r = NHECPMNKEFK as JGMEFHJCNHP_GetAchievementRecords;
				for(int i = 0; i < r.NFEAMMJIMPG.CEDLLCCONJP.Count; i++)
				{
					if(!r.NFEAMMJIMPG.CEDLLCCONJP[i].OOIJCMLEAJP)
					{
						CLPMDJFKJBO.Add(r.NFEAMMJIMPG.CEDLLCCONJP[i].LJNAKDMILMC);
					}
				}
				PLOOEECNHFB = true;
			};
			req.BHFHGFKBOHH_OnSuccess = CMJMGEFNBDK;
			CACGCMBKHDI_Request.HDHIKGLMOGF DMLJLPMBLCH = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x1B3F2DC
				PLOOEECNHFB = true;
				NPNNPNAIONN = true;
			};
			req.MOBEEPPKFLG_OnFail = DMLJLPMBLCH;
			while (!PLOOEECNHFB)
				yield return null;
			if(NPNNPNAIONN)
			{
				//LAB_01b404d0
				if (MOBEEPPKFLG != null)
					MOBEEPPKFLG();
				yield break;
			}
			if(CLPMDJFKJBO.Count > 0)
			{
				PLOOEECNHFB = false;
				NPNNPNAIONN = false;
				FLONELKGABJ_ClaimAchievementPrizes req2 = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
				req2.KMOBDLBKAAA = false;
				req2.MIDAMHNABAJ = CLPMDJFKJBO;
				CACGCMBKHDI_Request.HDHIKGLMOGF EEIFDMNADPA = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x1B3F2E8
					PLOOEECNHFB = true;
				};
				req2.BHFHGFKBOHH_OnSuccess = EEIFDMNADPA;
				CACGCMBKHDI_Request.HDHIKGLMOGF NDBKOPGCPHJ = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x1B3F2F4
					PLOOEECNHFB = true;
					NPNNPNAIONN = true;
				};
				req2.MOBEEPPKFLG_OnFail = EEIFDMNADPA;
				while (!PLOOEECNHFB)
					yield return null;
				if(NPNNPNAIONN)
				{
					//LAB_01b404d0
					if (MOBEEPPKFLG != null)
						MOBEEPPKFLG();
					yield break;
				}
			}
		}
		FBKCFKPLMAL(NLLKGEGPLGO);
		KLCOAGDOJPL.KCCLEHLLOFG_Common.EAFLCGCIOND_RetRewRecGra = AGOPAMONHHJ;
		PLOOEECNHFB = false;
		NPNNPNAIONN = false;
		CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
		{
			//0x1B3F300
			PLOOEECNHFB = true;
		}, () =>
		{
			//0x1B3F30C
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
		}, null);
		//LAB_01b4010c
		while (!PLOOEECNHFB)
			yield return null;
		if(!NPNNPNAIONN)
		{
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		}
		else
		{
			if (MOBEEPPKFLG != null)
				MOBEEPPKFLG();
		}
	}

	//// RVA: 0x1B3E1B0 Offset: 0x1B3E1B0 VA: 0x1B3E1B0
	private void FBKCFKPLMAL(List<JCDOJGNNIIL> PFEGHILDOGF)
	{
		JKNGJFOBADP j = new JKNGJFOBADP();
		for (int i = 0; i < PFEGHILDOGF.Count; i++)
		{
			j.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MDPHOJAPCCC, PFEGHILDOGF[i].LLNHMMBFPMA.ToString());
			for(int k = 0; k < PFEGHILDOGF[i].LJNPPPOBHFK.Count; k++)
			{
				int id = PFEGHILDOGF[i].LJNPPPOBHFK[k];
				j.NGEPPDAOIBN(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id), EKLNMHFCAOI.DEACAHNLMNI_getItemId(id), PFEGHILDOGF[i].CCAPNEAOIBP[k], 0, EKLNMHFCAOI.FABCKNDLPDH(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id), EKLNMHFCAOI.DEACAHNLMNI_getItemId(id)));
			}
		}
	}
}
