using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

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
	public List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> AOIADBHHJAJ_GetValidBingoCells(int APFDNBGMMMM, int AMCCOGJACPK, int CPKMLLNADLJ, int AHHJLDLAPAN)
	{
		List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> res = new List<JKICPBIIHNE_Bingo.IEGCPLCLOHF>();
		JKICPBIIHNE_Bingo.HNOGDJFJGPM bingo = EBEDAPJFHCE_GetBingo(APFDNBGMMMM);
		res.Clear();
		for(int i = 0; i < 9; i++)
		{
			res.Add(new JKICPBIIHNE_Bingo.IEGCPLCLOHF());
		}
		for(int i = 0; i < bingo.DPGMFEGFCJN[0].MFMGDFACBON.Count; i++)
		{
			JKICPBIIHNE_Bingo.IEGCPLCLOHF data = bingo.DPGMFEGFCJN[0].MFMGDFACBON[i];
			if(data.PLALNIIBLOF_Enabled == 2)
			{
				if(data.PBEEPMLJGJC == AMCCOGJACPK)
				{
					if(data.NDFOAINJPIN < 10)
					{
						if(data.FDBOPFEOENF > 0)
						{
							if (data.FDBOPFEOENF != AHHJLDLAPAN)
								continue;
						}
						if(data.CPKMLLNADLJ_MusicSerieAttr > 0)
						{
							if (data.CPKMLLNADLJ_MusicSerieAttr != CPKMLLNADLJ)
								continue;
						}
						res[data.NDFOAINJPIN - 1].PPFNGGCBJKC = data.PPFNGGCBJKC;
						res[data.NDFOAINJPIN - 1].PBEEPMLJGJC = data.PBEEPMLJGJC;
						res[data.NDFOAINJPIN - 1].PLALNIIBLOF_Enabled = data.PLALNIIBLOF_Enabled;
						res[data.NDFOAINJPIN - 1].NDFOAINJPIN = data.NDFOAINJPIN;
						res[data.NDFOAINJPIN - 1].CPKMLLNADLJ_MusicSerieAttr = data.CPKMLLNADLJ_MusicSerieAttr;
						res[data.NDFOAINJPIN - 1].FDBOPFEOENF = data.FDBOPFEOENF;
						res[data.NDFOAINJPIN - 1].FEMMDNIELFC = data.FEMMDNIELFC;
						res[data.NDFOAINJPIN - 1].JEPGJJJBFLN = data.JEPGJJJBFLN;
						res[data.NDFOAINJPIN - 1].GOKJLBDJOLA_MusicDifficulty = data.GOKJLBDJOLA_MusicDifficulty;
						res[data.NDFOAINJPIN - 1].GPNPBHLLHDI = data.GPNPBHLLHDI;
						res[data.NDFOAINJPIN - 1].IMEPEOAFIIB = data.IMEPEOAFIIB;
						res[data.NDFOAINJPIN - 1].MAPNDFCJFLJ_ConditionType = data.MAPNDFCJFLJ_ConditionType;
						res[data.NDFOAINJPIN - 1].JBFLEDKDFCO_ConditionValue = data.JBFLEDKDFCO_ConditionValue;
						res[data.NDFOAINJPIN - 1].PMDLBHLNIDP = data.PMDLBHLNIDP;
						res[data.NDFOAINJPIN - 1].GLCLFMGPMAN = data.GLCLFMGPMAN;
						res[data.NDFOAINJPIN - 1].LJKMKCOAICL = data.LJKMKCOAICL;
						res[data.NDFOAINJPIN - 1].JJHPDDPKBHF = data.JJHPDDPKBHF;
					}
				}
			}
		}
		return res;
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
		int CHOFDPDFPDC = KOGBMDOONFA.JBFLEDKDFCO_ConditionValue;
		int type = KOGBMDOONFA.MAPNDFCJFLJ_ConditionType;
		int a = KOGBMDOONFA.NDFOAINJPIN;
		NFMHCLHEMHB_Bingo.CCGKCGJKADC saveBingo = MENDFPNPAAO_GetSaveBingo(APFDNBGMMMM);
		if(type < 18)
		{
			if(type < 15)
			{
				if(type == 7)
				{
					for(int i = 0; i < LKMHPJKIFDN.OHCIFMDPAPD_Story.CDENCMNHNGA.Count; i++)
					{
						LAEGMENIEDB_Story.ALGOILKGAAH dbData = LKMHPJKIFDN.OHCIFMDPAPD_Story.CDENCMNHNGA[i];
						if (dbData.KLCIIHKFPPO == CHOFDPDFPDC)
						{
							return LDEGEHAEALK.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[dbData.LFLLLOPAKCO - 1].HALOKFOJMLA ? 1 : 0;
						}
					}
					return 0;
				}
				if(type == 14)
				{
					return LDEGEHAEALK.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
				}
			}
			else
			{
				if(type == 15)
				{
					if(CHOFDPDFPDC > 0)
					{
						if (LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count < CHOFDPDFPDC)
							return 0;
						return LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[CHOFDPDFPDC - 1].HEBKEJBDCBH_DivaLevel;
					}
					if (LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count > 0)
					{
						int res = 0;
						for (int i = 0; i < LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
						{
							if (LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH != 0 &&
								LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].HEBKEJBDCBH_DivaLevel > res)
								res = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].HEBKEJBDCBH_DivaLevel;
						}
						return res;
					}
					return 0;
				}
				if(type == 17)
				{
					return LDEGEHAEALK.PNLOINMCCKH_Scene.MPFLFKBNFEI_GetNumSceneAtLevelOrMore(LKMHPJKIFDN.HNMMJINNHII_Game, LKMHPJKIFDN.ECNHDEHADGL_Scene, CHOFDPDFPDC);
				}
			}
			return HMFFHLPNMPH + 1;
		}
		if(type < 34)
		{
			if(type == 23)
			{
				if (OMNOFMEBLAD == null)
					return HMFFHLPNMPH;
				if (OMNOFMEBLAD.KNIFCANOHOC_Score > HMFFHLPNMPH)
					return OMNOFMEBLAD.KNIFCANOHOC_Score;
				return HMFFHLPNMPH;
			}
			if(type == 31)
			{
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.BOLCACJFJGG_Shop;
			}
			if(type == 33)
			{
				int cnt = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count;
				if (cnt < 1)
					return 0;
				int res = 0;
				for(int i = 0; i < cnt; i++)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i];
					if(dbScene.PPEGAKEIEGM_En == 2)
					{
						res += LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[i].DMNIMMGGJJJ_Leaf;
					}
				}
				return res;
			}
			return HMFFHLPNMPH + 1;
		}
		switch(type)
		{
			case 54:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNHALIDFACE_GetVOpCValue(CHOFDPDFPDC);
			case 55:
				if(CHOFDPDFPDC > 0)
				{
					if (CHOFDPDFPDC > 10)
						return 0;
					return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EJNFMAAKCMH_GetDOpCValue(CHOFDPDFPDC - 1);
				}
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNHALIDFACE_GetVOpCValue(CHOFDPDFPDC);
			case 59:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.ODJEADMLGFB_Lgin;
			case 61:
				if(CHOFDPDFPDC < 1)
				{
					int res = 0;
					for(int i = 0; i < 10; i++)
					{
						DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo divaInfo = LDEGEHAEALK.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(i + 1);
						if (divaInfo.CPGFPEDMDEH == 1 && divaInfo.KCCONFODCPN_IntimacyLevel > res)
							res = divaInfo.KCCONFODCPN_IntimacyLevel;
					}
					return res;
				}
				else
				{
					if(CHOFDPDFPDC < 11)
					{
						DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo divaInfo = LDEGEHAEALK.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(CHOFDPDFPDC);
						if (divaInfo.CPGFPEDMDEH == 1)
							return divaInfo.KCCONFODCPN_IntimacyLevel;
					}
				}
				return 0;
			case 62:
				{
					int cnt = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count;
					int cnt2 = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count;
					if (cnt2 < cnt)
					{
						cnt = cnt2;
					}
					if (cnt > 0)
					{
						int res = 0;
						for (int i = 0; i < cnt; i++)
						{
							MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i];
							if (dbScene.PPEGAKEIEGM_En == 2)
							{
								MMPBPOIFDAF_Scene.PMKOFEIONEG scene = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[i];
								res += dbScene.AGOEDLNOHND(LKMHPJKIFDN.JEMMMJEJLNL_Board, scene.EMOJHJGHJLN, scene.JPIPENJGGDD_Mlt, LKMHPJKIFDN.HNMMJINNHII_Game.GENHLFPKOEE(dbScene.EKLIPGELKCL_Rarity, dbScene.MCCIFLKCNKO_Feed));
							}
						}
						return res;
					}
					return 0;
				}
			case 65:
				if(CHOFDPDFPDC < 1)
				{
					int b = LDEGEHAEALK.BEKHNNCGIEL_Costume.EFFKJGEDONM_GetNumUnlockedCostume(LKMHPJKIFDN.MFPNGNMFEAL_Costume, LDEGEHAEALK.DGCJCAHIAPP_Diva, true);
					List<DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo> l = LDEGEHAEALK.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.FindAll((DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo JPAEDJJFFOI) =>
					{
						//0x1E52FE4
						return JPAEDJJFFOI.CPGFPEDMDEH == 1;
					});
					int c = 0;
					if(b > 0)
					{
						c = LDEGEHAEALK.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(2).CGKAEMGLHNK_Possessed() ? 1 : 0;
					}
					return (b - c) - l.Count;
				}
				else
				{
					int res = 0;
					List<LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo> l = LKMHPJKIFDN.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes.FindAll((LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo JPAEDJJFFOI) =>
					{
						//0x1E53018
						if(JPAEDJJFFOI.PPEGAKEIEGM_Enabled == 2)
						{
							return CHOFDPDFPDC == JPAEDJJFFOI.AHHJLDLAPAN_PrismDivaId;
						}
						return false;
					});
					for(int i = 0; i < l.Count; i++)
					{
						LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo c = l[i];
						if(c.JPIDIENBGKH_CostumeId != 2)
						{
							if(c.DAJGPBLEEOB_PrismCostumeModelId != 1)
							{
								res += LDEGEHAEALK.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(c.JPIDIENBGKH_CostumeId).CGKAEMGLHNK_Possessed() ? 1 : 0;
							}
						}
					}
					return res;
				}
			case 66:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.KGFLHCHAIGO_GetChgcValue(CHOFDPDFPDC);
			case 67:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKKOANOJHLB_GetGiftValue(CHOFDPDFPDC);
			case 68:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MLBJKMLMLEG_GetDOocValue(CHOFDPDFPDC);
			case 69:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FGGFDPFMKAF_GetDopuValue(CHOFDPDFPDC);
			case 70:
				if(CHOFDPDFPDC < 1)
				{
					int res = 0;
					for (int i = 0; i < LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List.Count; i++)
					{
						if(LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i].CGKAEMGLHNK_Possessed())
						{
							if(res < LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i].ANAJIAENLNB_Level)
							{
								res = LDEGEHAEALK.BEKHNNCGIEL_Costume.FABAGMLEKIB_List[i].ANAJIAENLNB_Level;
							}
						}
					}
					return res;
				}
				else
				{
					int res = 0;
					if (CHOFDPDFPDC < 11)
					{
						for(int i = 0; i < LKMHPJKIFDN.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes.Count; i++)
						{
							if(LKMHPJKIFDN.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[i].AHHJLDLAPAN_PrismDivaId == CHOFDPDFPDC)
							{
								EBFLJMOCLNA_Costume.ILFJDCICIKN cos = LDEGEHAEALK.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(LKMHPJKIFDN.MFPNGNMFEAL_Costume.CDENCMNHNGA_Costumes[i].JPIDIENBGKH_CostumeId);
								if (cos.CGKAEMGLHNK_Possessed())
								{
									if(res < cos.ANAJIAENLNB_Level)
									{
										res = cos.ANAJIAENLNB_Level;
									}
								}
							}
						}
					}
					return res;
				}
			case 71:
				{
					int cnt = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count;
					int cnt2 = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count;
					if (cnt2 < cnt)
						cnt = cnt2;
					if (cnt > 0)
					{
						int res = 0;
						for (int i = 0; i < cnt; i++)
						{
							MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = LKMHPJKIFDN.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i];
							if (dbScene.PPEGAKEIEGM_En == 2)
							{
								MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = LDEGEHAEALK.PNLOINMCCKH_Scene.OPIBAPEGCLA[i];
								if (saveScene.JPIPENJGGDD_Mlt > 1)
								{
									res += (saveScene.JPIPENJGGDD_Mlt - 1);
								}
							}
						}
						return res;
					}
					//LAB_00ac00c8
					return 0;
				}
			case 82:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FFMHGGHFNPJ_Scene;
			case 83:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNNKOAILFOL_Medal;
			case 84:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GCEKFPECEAI_DailyMission;
			case 85:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.HJNEMKGIBGE_EventMission;
			case 86:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.AIPKHFKODAH_EventPlay;
			case 87:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CDNJPNFGHOG_GetMedalShopValue(a - 1);
			case 88:
				return saveBingo.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NHPNPIBOHFB_Gacha;
			case 89:
				return LDEGEHAEALK.PNLOINMCCKH_Scene.NEAGFIEMLIL_GetSceneLevel(LKMHPJKIFDN.HNMMJINNHII_Game, LKMHPJKIFDN.ECNHDEHADGL_Scene, CHOFDPDFPDC);
			case 34:
				HighScoreRating hs = new HighScoreRating();
				hs.CalcUtaRate(null, false);
				return hs.GetUtaRateTotal();
			case 56:
			case 57:
			case 58:
			case 60:
			case 63:
			case 64:
			case 72:
			case 73:
			case 74:
			case 75:
			case 76:
			case 77:
			case 78:
			case 79:
			case 80:
			case 81:
			default:
				return HMFFHLPNMPH + 1;
		}
	}

	// // RVA: 0xAC0900 Offset: 0xAC0900 VA: 0xAC0900
	public bool FGHOILFCCKC(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, JKICPBIIHNE_Bingo.IEGCPLCLOHF KOGBMDOONFA, OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, long JHNMKKNEENE)
	{
		int val = KOGBMDOONFA.JBFLEDKDFCO_ConditionValue;
		//KOGBMDOONFA.FDBOPFEOENF
		KEODKEGFDLD_FreeMusicInfo fminfo = null;
		EONOEHOKBEB_Music minfo = null;
		if(OMNOFMEBLAD != null)
		{
			fminfo = LKMHPJKIFDN.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
			minfo = LKMHPJKIFDN.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fminfo.DLAEJOBELBH_MusicId);
			if(OMNOFMEBLAD.OBOPMHBPCFE_MvMode)
			{
				if (KOGBMDOONFA.MAPNDFCJFLJ_ConditionType == 0)
					return true;
				return KOGBMDOONFA.MAPNDFCJFLJ_ConditionType == 29;
			}
		}
		int a = KOGBMDOONFA.MAPNDFCJFLJ_ConditionType;
		if(a < 32)
		{
			switch (a)
			{
				case 0:
				case 7:
				case 14:
				case 15:
				case 17:
				case 23:
				case 31:
					return true;
				case 8:
					return OMNOFMEBLAD != null;
				case 9:
					if (fminfo == null || OMNOFMEBLAD == null)
						return false;
					if (KOGBMDOONFA.CPKMLLNADLJ_MusicSerieAttr == 0)
					{
						if (val != 0)
						{
							return minfo.AIHCEGFANAM_SerieAttr == val - 1;
						}
					}
					return KOGBMDOONFA.CPKMLLNADLJ_MusicSerieAttr == minfo.AIHCEGFANAM_SerieAttr;
				case 10:
					if (OMNOFMEBLAD != null)
					{
						return KOGBMDOONFA.GOKJLBDJOLA_MusicDifficulty == OMNOFMEBLAD.AKNELONELJK_Difficulty;
					}
					break;
				case 12:
					if (OMNOFMEBLAD != null)
					{
						return OMNOFMEBLAD.LCOHGOIDMDF_ComboRank != 0;
					}
					break;
				case 13:
					if (OMNOFMEBLAD != null)
					{
						return fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_Difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_Score) == 4;
					}
					break;
				case 21:
					if (OMNOFMEBLAD != null)
					{
						return OMNOFMEBLAD.KNCBNGCDMII_HadValkyrieMode;
					}
					break;
				case 22:
					if (OMNOFMEBLAD != null)
					{
						return OMNOFMEBLAD.HGEKDNNJAAC_HadAwakenDivaMode;
					}
					break;
			}
			return false;
		}
		if (a >= 33 & a <= 34)
			return true;
		switch(a)
		{
			case 54:
			case 55:
			case 59:
			case 61:
			case 62:
			case 65:
			case 66:
			case 67:
			case 68:
			case 69:
			case 70:
			case 71:
			case 82:
			case 83:
			case 84:
			case 85:
			case 86:
			case 87:
			case 88:
			case 89:
				return true;
			case 60:
				if (OMNOFMEBLAD != null)
					return OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == val;
				break;
			case 63:
				if(OMNOFMEBLAD != null)
				{
					for(int i = 0; i < OMNOFMEBLAD.CPNOKMINILL_SkillDataList.Count; i++)
					{
						if (OMNOFMEBLAD.CPNOKMINILL_SkillDataList[i].isActive && (int)OMNOFMEBLAD.CPNOKMINILL_SkillDataList[i].skillType == val)
							return true;
					}
				}
				break;
			case 64:
				if(OMNOFMEBLAD != null)
				{
					for (int i = 0; i < OMNOFMEBLAD.CPNOKMINILL_SkillDataList.Count; i++)
					{
						if (!OMNOFMEBLAD.CPNOKMINILL_SkillDataList[i].isActive && (int)OMNOFMEBLAD.CPNOKMINILL_SkillDataList[i].skillType == val)
							return true;
					}
				}
				break;
			case 72:
				if(OMNOFMEBLAD != null)
				{
					List<IBJAKJJICBC> list = IBJAKJJICBC.FKDIMODKKJD(5, OMNOFMEBLAD.NFFDIGEJHGL_ServerTime, true, false, false, false);
					for(int i = 0; i < list.Count; i++)
					{
						if(list[i].LHONOILACFL_IsWeeklyEvent)
						{
							if (OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == list[i].GHBPLHBNMBK_FreeMusicId)
								return true;
						}
					}
				}
				break;
			case 73:
				if(fminfo != null && OMNOFMEBLAD != null)
				{
					return fminfo.DLAEJOBELBH_MusicId == val;
				}
				break;
		}
		return false;
	}

	// // RVA: 0xAC108C Offset: 0xAC108C VA: 0xAC108C
	public bool HEFIKPAHCIA_HasBingoActive(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, long JHNMKKNEENE_Time = -1)
    {
		List<int> l = CNADOFDDNLO_GetActiveBingos();
		if(JHNMKKNEENE_Time < 0)
		{
			JHNMKKNEENE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}
		bool res = false;
		for(int i = 0; i < l.Count; i++)
		{
			res |= HEFIKPAHCIA_IsBingoValid(l[i], OMNOFMEBLAD, JHNMKKNEENE_Time);
		}
		return res;
    }

	// // RVA: 0xAC1228 Offset: 0xAC1228 VA: 0xAC1228
	public bool HEFIKPAHCIA_IsBingoValid(int APFDNBGMMMM, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, long JHNMKKNEENE = -1)
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
				List<JKICPBIIHNE_Bingo.IEGCPLCLOHF> l = AOIADBHHJAJ_GetValidBingoCells(APFDNBGMMMM, bingo.BJOHOIAKKFM_Bst, attr, diva);
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
						if(l[i].CPKMLLNADLJ_MusicSerieAttr < 1 || (l[i].CPKMLLNADLJ_MusicSerieAttr == minfo.AIHCEGFANAM_SerieAttr))
						{
							//LAB_00ac1720
							if(l[i].GOKJLBDJOLA_MusicDifficulty > 0)
							{
								if(OMNOFMEBLAD.AKNELONELJK_Difficulty < (l[i].GOKJLBDJOLA_MusicDifficulty - 1))
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
							int a = GOIAHBFBKPF(APFDNBGMMMM, OMNOFMEBLAD, l[i], IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN - 1].HMFFHLPNMPH_Cnt);
							if(l[i].PMDLBHLNIDP <= a)
							{
								if(bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN - 1].CMCKNKKCNDK_Stat < 2)
								{
									bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN - 1].CMCKNKKCNDK_Stat = 2;
									bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN - 1].OPGPHAEMIDO_Dt = JHNMKKNEENE;
								}
								a = l[i].PMDLBHLNIDP;
							}
							bingo.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[l[i].NDFOAINJPIN - 1].HMFFHLPNMPH_Cnt = a;
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
	public int OBOGIOGEBPK(int APFDNBGMMMM, FKMOKDCJFEN.ADCPCCNCOMD_Status CMCKNKKCNDK)
	{
		TodoLogger.Log(0, "OBOGIOGEBPK");
		return 0;
	}

	// // RVA: 0xAC26A8 Offset: 0xAC26A8 VA: 0xAC26A8
	// public int OBOGIOGEBPK(FKMOKDCJFEN.ADCPCCNCOMD CMCKNKKCNDK) { }

	// // RVA: 0xAC2790 Offset: 0xAC2790 VA: 0xAC2790
	// public void MNMCNPLIEFM(int APFDNBGMMMM, bool NLNNKIKIPBJ) { }

	// // RVA: 0xAC27DC Offset: 0xAC27DC VA: 0xAC27DC
	// public bool DOEGBMNNFKH(int APFDNBGMMMM) { }

	// // RVA: 0xAC2828 Offset: 0xAC2828 VA: 0xAC2828
	// public bool EAJLHMIMAPE(int APFDNBGMMMM) { }
}
