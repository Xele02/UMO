using System.Collections.Generic;
using UnityEngine;

public class GNGMCIAIKMA
{
	public const sbyte HKKJGAJPNIL = 29;
	public const sbyte FKHFJOKHNAK = 63;
	private const short EAPCKKPCPII = 90;
	public static int FBGGEFFJJHB; // 0x0
	public static long BBEGLBMOBOF; // 0x8
	private int ILGOKEAIBBA; // 0x8
	private int NPNDCNDCDPC; // 0xC
	private int PFJENHEKCAO; // 0x10
	private int ELNEJEEKOEI; // 0x14
	private int IDKOMEFBCBD; // 0x18
	public int DKFOMHOJBGD; // 0x1C
	public List<long> GEAHCCJPOCN = new List<long>(); // 0x20
	private readonly sbyte[,] LMEHCADEKLN = new sbyte[3, 8] {
		{ 0x5b, 0x58, 0x59, 0x5e, 0x5f, 0x5c, 0x5d, 0x52},
		{ 0x53, 0x5b, 0x5e, 0x5d, 0x58, 0x5f, 0x52, 0x59}, 
		{ 0x5c, 0x53, 0x5b, 0x5f, 0x53, 0x59, 0x5f, 0x5d}
	}; // 0x24
	// public List<GNGMCIAIKMA.DFABPMMMIIB> CEHNIJPOEAF = new List<GNGMCIAIKMA.DFABPMMMIIB>(); // 0x28

	public static GNGMCIAIKMA HHCJCDFCLOB { get; private set; } // 0x10 GNGMCIAIKMA OKPMHKNCNAL
	// public int PMPKHBAJAFA { get; set; } // OAKEIKFELFC 0xAB8FE4  MBHILIEPJOO 0xAB9050
	// public int MALACFEDHDE { get; set; } //  KIMKKEOMPDL 0xAB90C0 PGILHFKNKEN 0xAB912C
	// private int HHKAGEAMHOE { get; set; } // DGNHFHGNDOF 0xAB919C  HDADMLNHJMN 0xAB9208
	// private int EEOPPDBICBN { get; set; } // GDODEJOPENB 0xAB9278 JIJIGMCJHBC 0xAB92E4
	// private int CEGHDFHLFPO { get; set; } // CDJABHMPLKM 0xAB9354  EIHJCGDLLPF 0xAB93C0

	// // RVA: 0xAB9430 Offset: 0xAB9430 VA: 0xAB9430
	// public int DDHNADFGKDF(int GJKPJMGPCEJ, int IKPIDCFOFEA) { }

	// // RVA: 0xAB9524 Offset: 0xAB9524 VA: 0xAB9524
	// public int[] EOPMDFOCAKJ(int GJKPJMGPCEJ) { }

	// // RVA: 0xAB9640 Offset: 0xAB9640 VA: 0xAB9640
	public GNGMCIAIKMA() 
	{ 
		FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
		BBEGLBMOBOF = ~FBGGEFFJJHB; // not sure
		ILGOKEAIBBA = FBGGEFFJJHB;
		NPNDCNDCDPC = FBGGEFFJJHB;
		PFJENHEKCAO = FBGGEFFJJHB;
		ELNEJEEKOEI = FBGGEFFJJHB;
		IDKOMEFBCBD = FBGGEFFJJHB;
	}

	// // RVA: 0xAB9974 Offset: 0xAB9974 VA: 0xAB9974
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
	}

	// // RVA: 0xAB99D8 Offset: 0xAB99D8 VA: 0xAB99D8
	// public bool GBCPDBJEDHL() { }

	// // RVA: 0xAB9AD0 Offset: 0xAB9AD0 VA: 0xAB9AD0
	// public bool GBCPDBJEDHL(long JHNMKKNEENE) { }

	// // RVA: 0xABA38C Offset: 0xABA38C VA: 0xABA38C
	// public bool NJBPNCDPGNO(int APFDNBGMMMM) { }

	// // RVA: 0xABA480 Offset: 0xABA480 VA: 0xABA480
	// public int AMIBPGONGFE(long JHNMKKNEENE, bool HLCDBGGEHPD) { }

	// // RVA: 0xABA5FC Offset: 0xABA5FC VA: 0xABA5FC
	// public void KGABKGKGNCA(int APFDNBGMMMM, bool BCGLDMKODLC) { }

	// // RVA: 0xABA788 Offset: 0xABA788 VA: 0xABA788
	// public int MIGJIALJLOF() { }

	// // RVA: 0xABA8C0 Offset: 0xABA8C0 VA: 0xABA8C0
	// public int FIAHJAMFNPD() { }

	// // RVA: 0xABA9F8 Offset: 0xABA9F8 VA: 0xABA9F8
	// public int GEAMLAKKMLI() { }

	// // RVA: 0xABAB30 Offset: 0xABAB30 VA: 0xABAB30
	// public bool DKMLDEDKPBA(int PLALNIIBLOF) { }

	// // RVA: 0xAB9E7C Offset: 0xAB9E7C VA: 0xAB9E7C
	public List<int> CNADOFDDNLO_GetActiveBingos(long JHNMKKNEENE)
	{
		List<int> res = new List<int>();
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb == null)
			return res;
		List<JKICPBIIHNE_Bingo.HNOGDJFJGPM> l = new List<JKICPBIIHNE_Bingo.HNOGDJFJGPM>();
		for(int i = 0; i < bingoDb.JJAICEAEGKF.Count; i++)
		{
			JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = bingoDb.JJAICEAEGKF[i];
			if(bingo.IJEKNCDIIAE_MasterVersion != 0)
			{
				if(bingo.IJEKNCDIIAE_MasterVersion < DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion)
				{
					if(bingo.PLALNIIBLOF_Enabled == 2)
					{
						if(bingo.PDBPFJJCADD_StartTime != 0)
						{
							if(bingo.PDBPFJJCADD_StartTime > JHNMKKNEENE)
								continue;
						}
						if(bingo.FDBNFFNFOND_EndTime != 0)
						{
							if(bingo.FDBNFFNFOND_EndTime < JHNMKKNEENE)
								continue;
						}
						if(MENDFPNPAAO_GetSaveBingo(bingo.PPFNGGCBJKC).JNLKJCDFFMM_Clear != 1)
						{
							l.Add(bingo);
						}
					}
				}
			}
		}
		l.Sort((JKICPBIIHNE_Bingo.HNOGDJFJGPM HKICMNAACDA, JKICPBIIHNE_Bingo.HNOGDJFJGPM BNKHBCBJBKI) => {
			//0x1E52F64
			return HKICMNAACDA.FDBNFFNFOND_EndTime.CompareTo(BNKHBCBJBKI.FDBNFFNFOND_EndTime);
		});
		for(int i = 0; i < l.Count; i++)
		{
			res.Add(l[i].PPFNGGCBJKC);
		}
		return res;
	}

	// // RVA: 0xABAB40 Offset: 0xABAB40 VA: 0xABAB40
	public List<int> CNADOFDDNLO_GetActiveBingos()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		return CNADOFDDNLO_GetActiveBingos(time);
	}

	// // RVA: 0xABAC38 Offset: 0xABAC38 VA: 0xABAC38
	// public bool MHNAINBNLHH(int APFDNBGMMMM) { }

	// // RVA: 0xABAD3C Offset: 0xABAD3C VA: 0xABAD3C
	// public bool DHPLHALIDHH(int APFDNBGMMMM) { }

	// // RVA: 0xABAE3C Offset: 0xABAE3C VA: 0xABAE3C
	// public bool DHPLHALIDHH(int APFDNBGMMMM, long JHNMKKNEENE) { }

	// // RVA: 0xABAFF4 Offset: 0xABAFF4 VA: 0xABAFF4
	// public bool KJNFBLAMJOH(int APFDNBGMMMM) { }

	// // RVA: 0xABAFC4 Offset: 0xABAFC4 VA: 0xABAFC4
	// public long GKDBBGIEPLC(int APFDNBGMMMM) { }

	// // RVA: 0xABAFFC Offset: 0xABAFFC VA: 0xABAFFC
	// public long DBEDJLOAILN(int APFDNBGMMMM) { }

	// // RVA: 0xABB2F4 Offset: 0xABB2F4 VA: 0xABB2F4
	// public int CBMJAPJKBNL(int PPFNGGCBJKC) { }

	// // RVA: 0xABB300 Offset: 0xABB300 VA: 0xABB300
	// public int LILBEIBCCKF(int EKANGPODCEP) { }

	// // RVA: 0xABB30C Offset: 0xABB30C VA: 0xABB30C
	// public bool DJGFICMNGGP(int APFDNBGMMMM) { }

	// // RVA: 0xABB380 Offset: 0xABB380 VA: 0xABB380
	// public int MGAHOPFMKHB() { }

	// // RVA: 0xABB3EC Offset: 0xABB3EC VA: 0xABB3EC
	// public bool NJELIKPFBEH(int AMCCOGJACPK) { }

	// // RVA: 0xABB460 Offset: 0xABB460 VA: 0xABB460
	// public int EAIJHJPKBFA(int APFDNBGMMMM) { }

	// // RVA: 0xABB4D4 Offset: 0xABB4D4 VA: 0xABB4D4
	// public int EHFLAKIFPOO(int APFDNBGMMMM) { }

	// // RVA: 0xABB674 Offset: 0xABB674 VA: 0xABB674
	// public bool IDKFAMEFCPD(int APFDNBGMMMM) { }

	// // RVA: 0xAB9C00 Offset: 0xAB9C00 VA: 0xAB9C00
	public JKICPBIIHNE_Bingo FJLIDJJAGOM_GetBingoDb()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FPOIPGFFAPE_Bingo;
		}
		return null;
	}

	// // RVA: 0xABAEB8 Offset: 0xABAEB8 VA: 0xABAEB8
	public JKICPBIIHNE_Bingo.HNOGDJFJGPM EBEDAPJFHCE_GetBingo(int APFDNBGMMMM)
	{
		JKICPBIIHNE_Bingo bingoDb = FJLIDJJAGOM_GetBingoDb();
		if(bingoDb != null)
		{
			return bingoDb.JJAICEAEGKF.Find((JKICPBIIHNE_Bingo.HNOGDJFJGPM JPAEDJJFFOI) => {
				//0x1E530F4
				return JPAEDJJFFOI.PPFNGGCBJKC == APFDNBGMMMM;
			});
		}
		return null;
	}

	// // RVA: 0xABB868 Offset: 0xABB868 VA: 0xABB868
	public NFMHCLHEMHB_Bingo PDMHKENDJHI_GetSaveBingoBlock()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PEGNNEFHDOP_Bingo;
		}
		return null;
	}

	// // RVA: 0xABA634 Offset: 0xABA634 VA: 0xABA634
	public NFMHCLHEMHB_Bingo.CCGKCGJKADC MENDFPNPAAO_GetSaveBingo(int PPFNGGCBJKC)
	{
		NFMHCLHEMHB_Bingo saveBingo = PDMHKENDJHI_GetSaveBingoBlock();
		if(saveBingo != null)
		{
			NFMHCLHEMHB_Bingo.CCGKCGJKADC res = saveBingo.MPCJGPEBCCD.Find((NFMHCLHEMHB_Bingo.CCGKCGJKADC JPAEDJJFFOI) => {
				//0x1E53140
				return JPAEDJJFFOI.PPFNGGCBJKC_Id == PPFNGGCBJKC;
			});
			if(res == null)
			{
				NFMHCLHEMHB_Bingo.CCGKCGJKADC n = saveBingo.EACEMMDIPFD_GetEmptyBingo();
				if(n != null)
				{
					n.KHEKNNFCAOI(PPFNGGCBJKC);
					res = n;
				}
			}
			return res;
		}
		return null;
	}

	// // RVA: 0xABB91C Offset: 0xABB91C VA: 0xABB91C
	// public NFMHCLHEMHB.CCGKCGJKADC MENDFPNPAAO(BBHNACPENDM AHEFHIMGIBI, int PPFNGGCBJKC) { }

	// // RVA: 0xABBA8C Offset: 0xABBA8C VA: 0xABBA8C
	// public bool BHFGBNNEMLI(int APFDNBGMMMM) { }

	// // RVA: 0xABBB00 Offset: 0xABBB00 VA: 0xABBB00
	// public int CGOIJPBINCF(int APFDNBGMMMM, bool BAFFAONJPCE) { }

	// // RVA: 0xABBC58 Offset: 0xABBC58 VA: 0xABBC58
	// public int JBEDFJHAAFP(int APFDNBGMMMM, bool BAFFAONJPCE) { }

	// // RVA: 0xABBDB0 Offset: 0xABBDB0 VA: 0xABBDB0
	// public int NIGPFNIIDII(int APFDNBGMMMM) { }

	// // RVA: 0xABBE78 Offset: 0xABBE78 VA: 0xABBE78
	// public JKICPBIIHNE.MKOCCBABHAH LAIDKMDLOPA(int APFDNBGMMMM, int EIHOBHDKCDB) { }

	// // RVA: 0xABBFE8 Offset: 0xABBFE8 VA: 0xABBFE8
	// public int DAIDHMMOGEI(int APFDNBGMMMM, int EIHOBHDKCDB) { }

	// // RVA: 0xABC00C Offset: 0xABC00C VA: 0xABC00C
	// public int KBIIEPNCLAD(int APFDNBGMMMM, int EIHOBHDKCDB) { }

	// // RVA: 0xABC030 Offset: 0xABC030 VA: 0xABC030
	// public List<JKICPBIIHNE.IEGCPLCLOHF> LABNDEFMAHI(int APFDNBGMMMM, int AMCCOGJACPK) { }

	// // RVA: 0xABC254 Offset: 0xABC254 VA: 0xABC254
	// public bool OIEBCNPOMIB(int APFDNBGMMMM, int AMCCOGJACPK, int EIHOBHDKCDB) { }

	// // RVA: 0xABC3B8 Offset: 0xABC3B8 VA: 0xABC3B8
	// public bool JJMANIALKBF(int APFDNBGMMMM, int EIHOBHDKCDB) { }

	// // RVA: 0xABC480 Offset: 0xABC480 VA: 0xABC480
	// public bool JIKFDBMMAIE(int APFDNBGMMMM) { }

	// // RVA: 0xABC520 Offset: 0xABC520 VA: 0xABC520
	// public List<int> ICNOKENCCJK(int APFDNBGMMMM, bool CADENLBDAEB, bool GNKMHCKFADN) { }

	// // RVA: 0xABC6F0 Offset: 0xABC6F0 VA: 0xABC6F0
	// public List<int> OAHPJJCHIPF(int APFDNBGMMMM) { }

	// // RVA: 0xABC83C Offset: 0xABC83C VA: 0xABC83C
	// public List<int> NCCCEBGHCOL(int APFDNBGMMMM) { }

	// // RVA: 0xABC978 Offset: 0xABC978 VA: 0xABC978
	// public List<int> BPGMPJHPKND(int APFDNBGMMMM) { }

	// // RVA: 0xABCB0C Offset: 0xABCB0C VA: 0xABCB0C
	// public List<int> PFDGKPCCGMG(int APFDNBGMMMM, bool CADENLBDAEB, bool JFPPDKHEEHN) { }

	// // RVA: 0xABCDE0 Offset: 0xABCDE0 VA: 0xABCDE0
	// public void DKKLLHMHBEA(int APFDNBGMMMM, List<int> GJKPJMGPCEJ, long JHNMKKNEENE) { }

	// // RVA: 0xABCEF8 Offset: 0xABCEF8 VA: 0xABCEF8
	// public List<int> OJPMBMOAFHM(int APFDNBGMMMM) { }

	// // RVA: 0xABD0A0 Offset: 0xABD0A0 VA: 0xABD0A0
	public List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> AOIADBHHJAJ(int APFDNBGMMMM, int AMCCOGJACPK, int CPKMLLNADLJ, int AHHJLDLAPAN)
	{
		TodoLogger.Log(0, "AOIADBHHJAJ");
		return new List<JKICPBIIHNE_Bingo.IEGCPLCLOHF>();
	}

	// // RVA: 0xABDC04 Offset: 0xABDC04 VA: 0xABDC04
	// public List<int> PDLKHLJFLHJ(int APFDNBGMMMM) { }

	// // RVA: 0xABDD84 Offset: 0xABDD84 VA: 0xABDD84
	// public List<int> OHDKDNGIFJC(int APFDNBGMMMM, int AMCCOGJACPK, int CPKMLLNADLJ, int AHHJLDLAPAN) { }

	// // RVA: 0xABDF74 Offset: 0xABDF74 VA: 0xABDF74
	// public int MLCGJAJCFDP(int APFDNBGMMMM, int PGGAIDEJGEC, int AMCCOGJACPK = 0) { }

	// // RVA: 0xAB9CB4 Offset: 0xAB9CB4 VA: 0xAB9CB4
	// public bool KIAAOBFJCHP(long JHNMKKNEENE) { }

	// // RVA: 0xABE1E8 Offset: 0xABE1E8 VA: 0xABE1E8
	// public bool HLNJABHOBKL() { }

	// // RVA: 0xABB770 Offset: 0xABB770 VA: 0xABB770
	// public GNGMCIAIKMA.DFABPMMMIIB GLJKKGFPEPA(int APFDNBGMMMM) { }

	// // RVA: 0xABE2E0 Offset: 0xABE2E0 VA: 0xABE2E0
	// public void GJENEJOANEL(int APFDNBGMMMM, DKFJADMCNPI.NLKCMNHOBAI INDDJNMPONH, int PPFNGGCBJKC, int HMFFHLPNMPH, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0xABE998 Offset: 0xABE998 VA: 0xABE998
	// public void GJENEJOANEL(BBHNACPENDM AHEFHIMGIBI, int APFDNBGMMMM, DKFJADMCNPI.NLKCMNHOBAI INDDJNMPONH, int PPFNGGCBJKC, int HMFFHLPNMPH) { }

	// // RVA: 0xABE6F4 Offset: 0xABE6F4 VA: 0xABE6F4
	// private void GJENEJOANEL(NFMHCLHEMHB.CCGKCGJKADC NHLBKJCPLBL, DKFJADMCNPI.NLKCMNHOBAI INDDJNMPONH, int PPFNGGCBJKC, int HMFFHLPNMPH) { }

	// // RVA: 0xABEA14 Offset: 0xABEA14 VA: 0xABEA14
	public void GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI INDDJNMPONH, int OIPCCBHIKIA, int HMFFHLPNMPH, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		TodoLogger.Log(0, "GJENEJOANEL");
	}

	// // RVA: 0xABEB0C Offset: 0xABEB0C VA: 0xABEB0C
	// public void GJENEJOANEL(BBHNACPENDM AHEFHIMGIBI, DKFJADMCNPI.NLKCMNHOBAI INDDJNMPONH, int OIPCCBHIKIA, int HMFFHLPNMPH) { }

	// // RVA: 0xABEBF4 Offset: 0xABEBF4 VA: 0xABEBF4
	public int GOIAHBFBKPF(int APFDNBGMMMM, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, JKICPBIIHNE_Bingo.IEGCPLCLOHF KOGBMDOONFA, OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, int HMFFHLPNMPH)
	{
		TodoLogger.Log(0, "GOIAHBFBKPF");
		return 0;
	}

	// // RVA: 0xAC0900 Offset: 0xAC0900 VA: 0xAC0900
	public bool FGHOILFCCKC(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, JKICPBIIHNE_Bingo.IEGCPLCLOHF KOGBMDOONFA, OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, long JHNMKKNEENE)
	{
		TodoLogger.Log(0, "FGHOILFCCKC");
		return false;
	}

	// // RVA: 0xAC108C Offset: 0xAC108C VA: 0xAC108C
	public bool HEFIKPAHCIA(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, long JHNMKKNEENE_Time = -1)
    {
		List<int> l = CNADOFDDNLO_GetActiveBingos();
		if(JHNMKKNEENE_Time < 0)
		{
			JHNMKKNEENE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}
		bool res = false;
		for(int i = 0; i < l.Count; i++)
		{
			res |= HEFIKPAHCIA(l[i], OMNOFMEBLAD, JHNMKKNEENE_Time);
		}
		return res;
    }

	// // RVA: 0xAC1228 Offset: 0xAC1228 VA: 0xAC1228
	public bool HEFIKPAHCIA(int APFDNBGMMMM, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, long JHNMKKNEENE = -1)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
		{
            NFMHCLHEMHB_Bingo.CCGKCGJKADC bingo = MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM);
            if (bingo.BJOHOIAKKFM_Bst != 0)
			{
				int id = bingo.AHCFGOGCJKI_St.PPFNGGCBJKC_Id;
				int scoreRank = 0;
				EONOEHOKBEB_Music minfo = null;
				int rankCombo = 0;
				if(OMNOFMEBLAD != null)
				{
					KEODKEGFDLD_FreeMusicInfo fminfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
					minfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fminfo.DLAEJOBELBH_MusicId);
					ADDHLABEFKH a = fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_Difficulty);
					scoreRank = a.DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_Score);
					rankCombo = a.CCFAAPPKILD_GetRankCombo(OMNOFMEBLAD.NLKEBAOBJCM_MaxCombo);
				}
				int diva = bingo.AHCFGOGCJKI_St.AHHJLDLAPAN_Dv;
                BJPLLEBHAGO_DivaInfo divaInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.GCINIJEMHFK_GetInfo(diva);
				int attr = 0;
				if(divaInfo != null)
				{
					attr = divaInfo.AIHCEGFANAM_Attr;
				}
				JKICPBIIHNE_Bingo.HNOGDJFJGPM dbBinfo = EBEDAPJFHCE_GetBingo(APFDNBGMMMM);
				List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> l = AOIADBHHJAJ(APFDNBGMMMM, bingo.BJOHOIAKKFM_Bst, attr, diva);
				if(JHNMKKNEENE < 0)
				{
					JHNMKKNEENE = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				}
				for(int i = 0; i < l.Count; i++)
				{
					bool b = false;
					if(OMNOFMEBLAD == null)
					{
						b = true;
					}
					else
					{
						if(l[i].CPKMLLNADLJ < 1 || (l[i].CPKMLLNADLJ == minfo.AIHCEGFANAM_SerieId))
						{
							//LAB_00ac1720
							if(l[i].GOKJLBDJOLA > 0)
							{
								if(OMNOFMEBLAD.AKNELONELJK_Difficulty < (l[i].GOKJLBDJOLA - 1))
									continue;
							}
							if(l[i].GPNPBHLLHDI <= scoreRank)
							{
								if(l[i].IMEPEOAFIIB <= rankCombo)
									b = true;
							}
						}
					}
					if(b)
					{
						//LAB_00ac17c0
						if(l[i].FDBOPFEOENF > 0 && l[i].FDBOPFEOENF != diva)
						{
							continue;
						}
						TodoLogger.Log(TodoLogger.ToCheck,"Last value ?");
						if(FGHOILFCCKC(OMNOFMEBLAD, l[i], IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, 0))
						{
							int a = GOIAHBFBKPF(APFDNBGMMMM, OMNOFMEBLAD, l[i], IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN].HMFFHLPNMPH_Cnt);
							if(l[i].PMDLBHLNIDP <= a)
							{
								if(bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN].CMCKNKKCNDK_Stat < 2)
								{
									bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN].CMCKNKKCNDK_Stat = 2;
									bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN].OPGPHAEMIDO_Dt = JHNMKKNEENE;
								}
								a = l[i].PMDLBHLNIDP;
							}
							bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN].HMFFHLPNMPH_Cnt = a;
						}
					}
				}
				return true;
            }
		}
		return false;
	}

	// // RVA: 0xAC1BB8 Offset: 0xAC1BB8 VA: 0xAC1BB8
	// public void FBHHEBDDIMO(int APFDNBGMMMM, bool NLNNKIKIPBJ) { }

	// // RVA: 0xAC1BF0 Offset: 0xAC1BF0 VA: 0xAC1BF0
	// public List<JJPEIELNEJB.JLHHGLANHGE> HNBJHJENFGL(JJPEIELNEJB.OMMBBPKFLNH KOGBMDOONFA, List<int> FFLGNFIAFFE) { }

	// // RVA: 0xAC21E4 Offset: 0xAC21E4 VA: 0xAC21E4
	// public void CPIICACGNBH(JKNGJFOBADP JANMJPOKLFL, BBHNACPENDM LDEGEHAEALK, int KIJAPOFAGPN, int HMFFHLPNMPH, int APFDNBGMMMM) { }

	// // RVA: 0xAC234C Offset: 0xAC234C VA: 0xAC234C
	// public bool NJJLNPOCKFO(int APFDNBGMMMM) { }

	// // RVA: 0xAC257C Offset: 0xAC257C VA: 0xAC257C
	// public int OBOGIOGEBPK(int APFDNBGMMMM, FKMOKDCJFEN.ADCPCCNCOMD CMCKNKKCNDK) { }

	// // RVA: 0xAC26A8 Offset: 0xAC26A8 VA: 0xAC26A8
	// public int OBOGIOGEBPK(FKMOKDCJFEN.ADCPCCNCOMD CMCKNKKCNDK) { }

	// // RVA: 0xAC2790 Offset: 0xAC2790 VA: 0xAC2790
	// public void MNMCNPLIEFM(int APFDNBGMMMM, bool NLNNKIKIPBJ) { }

	// // RVA: 0xAC27DC Offset: 0xAC27DC VA: 0xAC27DC
	// public bool DOEGBMNNFKH(int APFDNBGMMMM) { }

	// // RVA: 0xAC2828 Offset: 0xAC2828 VA: 0xAC2828
	// public bool EAJLHMIMAPE(int APFDNBGMMMM) { }
}
