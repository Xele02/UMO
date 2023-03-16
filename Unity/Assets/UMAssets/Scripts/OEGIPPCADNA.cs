
using System.Collections.Generic;
using UnityEngine;
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
	//public IEnumerator JAAOHPKMEAF_Receive_UnreceivedAchievements(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	//// RVA: 0x1B3E1B0 Offset: 0x1B3E1B0 VA: 0x1B3E1B0
	//private void FBKCFKPLMAL(List<OEGIPPCADNA.JCDOJGNNIIL> PFEGHILDOGF) { }
}
