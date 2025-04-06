using System.Text;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using XeSys;
using XeApp.Game;
using XeApp.Game.Gacha;
using UnityEngine.Localization.SmartFormat;

public delegate void CDOPFBOHDEF(List<MFDJIFIIPJD> HBHMAKNGKFK);

public class CIOECGOMILE
{
	private enum LKBJIGBNIAD
	{
		JOHJEOPEOBA_0 = 0,
		MHELGOODGCO_1_Raid = 1,
	}

	public enum LIILJGHKIDL
	{
		HJNNKCMLGFL = 0,
		HLAJMFGDAHP = 1,
		FPNFLAAECMK = 2,
		IOPLLOIHMJC = 3,
	}

	public delegate void LHGEIKBCBBP(List<string> OHNJJIMGKGK);
	public delegate CACGCMBKHDI_Request PIIFKPKIOOB(PJKLMCGEJMK CPHFEPHDJIB, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE JEHOEIKANFL, string JCJDPGMKJAJ);

	private FENCAJJBLBH DCLNIAMEGLA; // 0x1C
	private bool DICMPMEEIJL_HasSystemProducts; // 0x20
	private bool JNDDNFEINEH; // 0x21
	private int FFAGOLDAHHN_EnergyProdId; // 0x24
	private int KMJLGBJBOAK_StaminaRefillCost; // 0x28
	private int[] KKFJJAHFLOK_Ap_ProdIds = new int[3]; // 0x2C
	private int[] ELJNINICAIF_Ap_Prices = new int[3]; // 0x30
	private int CDPHPAIAFDG_Continue_ProdId; // 0x34
	public int BPPGDBHGMDA_Continue_Price; // 0x38
	private int MCLKCGMIKNF_Vop_ProdId; // 0x3C
	private int DMEHACGEOFK_Vop_Price; // 0x40
	public static bool HMIBICNFJHD = false; // 0x4
	public long ECFNAOCFKKN; // 0x78
	public bool HAELBFCGHMB; // 0x80
	public int NPOPAOCGIJN; // 0x84
	public static bool BDNBIEMJMCD = false; // 0x5
	public JKNGJFOBADP JANMJPOKLFL = new JKNGJFOBADP(); // 0x88
	public JKNGJFOBADP EBEGGFECPOE = new JKNGJFOBADP(); // 0x8C
	private StringBuilder DGMPLJFDOHF = new StringBuilder(); // 0x90
	public List<LHGEIKBCBBP> BJCPJPLPDIH = new List<LHGEIKBCBBP>(); // 0x94
	public bool JHOKIPPIHII_IsSavingToServer; // 0x98
	public List<string> PMHLJAIGBGK; // 0x9C
	public List<int> FMEDFGOMNBK; // 0xA0
	public BBHNACPENDM_ServerSaveData.EMHDCKMFCGE KDLBAGCENNC; // 0xA4
	public List<Action> BFHJLPDOEPB = new List<Action>(); // 0xA8
	private static string AMIPEDALBJP_EpKey = "episode_key_{0:0000}_{1:00}"; // 0x8
	private static string AIFFODKHLJE_FreeKey = "free_key_{0:000}_{1:0}_{2:00}"; // 0xC
	private static string KINJMGALNDE_FreeKeyL6 = "free_key_{0:000}_{1:0}_{2:00}_l6"; // 0x10
	private static string GPECKLLDAFH_CosKey = "costume_key_{0:000}_{1:00}"; // 0x14
	private bool NEPILJAJFCC; // 0xAC
	private bool NFLGAPBIGAD; // 0xAD
	private bool GPOGFJFGNCA; // 0xAE
	private static string OHPLHJNCLPH_Energy = JpStringLiterals.StringLiteral_9793_Jp; // 0x18
	private static string CPBCGKAKDIA_Stamina = JpStringLiterals.StringLiteral_9794_Jp; // 0x1C
	private static string AJICGGJJNCA_Ap = "AP"; // 0x20
	private static string FNBPIOCLODC_Continue = JpStringLiterals.StringLiteral_9796_Jp; // 0x24
	private static string FBDLJDOLMNI_Vop = JpStringLiterals.StringLiteral_9797_Jp; // 0x28

	public static CIOECGOMILE HHCJCDFCLOB { get; private set; }  // 0x0 LGMPACEDIJF // NKACBOEHELJ OKPMHKNCNAL
	public BBHNACPENDM_ServerSaveData AHEFHIMGIBI_ServerSave { get; private set; }  // 0x8 LCHHPGMCKJD // GNMGJMDJEGI LGLGNHAMNIK
	private BBHNACPENDM_ServerSaveData CCNKAKCBBDJ { get; set; } // 0xC MOMIOKHCMKH GHMKOMEKBFO KKOICOJPENH
	public BBHNACPENDM_ServerSaveData FMFKHDPKLOC { get; set; } // 0x10 FDDDKGAMLLB AAMOPGKKGEI OBEALILDFEM
	public BBHNACPENDM_ServerSaveData MNJHBCIIHED_PrevServerData { get; private set; } // 0x14 JHPFMKPOIOC KBOFNPLNBOA ICKBCAJFDOM
	public bool LNAHEIEIBOI_Initialized { get; set; } // 0x18 INBPPDMFOAD FHEAKKHAAPF GOEIEJFPLOG
	public bool KONHMOLMOCI_IsSaving { get; private set; } // 0x19 DEDJLABCBOH MDEMPMONBLE NAALAEJIEAI
	public bool BLCDJDJJBHC { get; set; } // 0x1A BPLABMJENOI AAIACPOJKKO DNLNBFEHCKD
	public FKAFHLIDAFD LGBMDHOLOIF_decoPlayerData { get; private set; }  // 0x44 ABKMJCPPEJA EEIKGFMAOGO MPNANFEAALL
	[Obsolete("alias of \'decoPlayerData\'")] // RVA: 0x749814 Offset: 0x749814 VA: 0x749814
	public FKAFHLIDAFD PDKHANKAPCI { get { return LGBMDHOLOIF_decoPlayerData; } private set { LGBMDHOLOIF_decoPlayerData = value; } } //KGBNBKPMKDG 0xFFA2F8 PJNPGHDEINA 0xFFA300
	[Obsolete("alias of \'decoPlayerData\'")] // RVA: 0x749848 Offset: 0x749848 VA: 0x749848
	public FKAFHLIDAFD AEBNIAFEIHC { get { return LGBMDHOLOIF_decoPlayerData; } private set { LGBMDHOLOIF_decoPlayerData = value; } } // CJMMAKNNLGO 0xFF3E08 GGDKCIHDPGP 0xFFA308
	public AIFIANALLPB KPFKKDDOHCN { get; private set; } // 0x48 CNBPHMJCOGK EJCOPFKKFJA EEAFNGBEHHJ
	public PIGBKEIAMPE_FriendManager CHNJPFCKFOI_FriendManager { get; private set; } // 0x4C NMPHJGJOODM PPHAPIPAEOJ IDDONPAJKCN
	public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_Currencies { get; private set; } // 0x50 KCLAFENGONP PCHMJADGBEI MFONKBBKMIJ
	public MCGNOFMAPBJ BPLOEAHOPFI_StaminaUpdater { get; private set; } // 0x54 KKOIOMJKJJK IFLOIFCLBFJ NGMKCJOPEGH
	public JKNNIKNKMNJ IOCLFHJLHLE_IntimacyUpdater { get; private set; } // 0x58 GIKMDNCDMAA NJGEOHOLOOB CBKHODJCHHG
	public int[] PAAMLFNPJGJ_IntimacyDivaPresentLeft { get; private set; } // 0x5C LJCBJICKPNL CPKABGODIPL NLCNIFNICIL
	public int[] EDGFGECLOHE_IntimacyDivaTouchCount { get; private set; }  // 0x60 GAKFDLBABCG NHOJDHIBMOF AILLCMLGNHD
	public long JNCBOBPPHHB_IntimacyTensionTime { get; private set; } // 0x68 BJMLKCHCLGM JBGCIPFPNII GAPBDDCDGDF
	public long PKBOFLOJNIJ_LastLoginTime { get; private set; } // 0x70 DPNBIKNOLMF IPIGNFGMJKH OPKPOAHJAPD
	// public bool HBHCAGLPJOL { get; } // ???

	// // RVA: 0xFFA340 Offset: 0xFFA340 VA: 0xFFA340
	public int DEAPMEIDCGC_GetTotalPaidCurrency()
	{
		MCKCJMLOAFP_CurrencyInfo cur = BBEPLKNMICJ_Currencies.Find((MCKCJMLOAFP_CurrencyInfo BNKHBCBJBKI) =>
		{
			//0x100A11C
			return BNKHBCBJBKI.PPFNGGCBJKC_Id == 1001;
		});
		if (cur == null)
			return 0;
		return cur.BDLNMOIOMHK_Total;
	}

	// // RVA: 0xFFA4A4 Offset: 0xFFA4A4 VA: 0xFFA4A4
	public int NBJOCMAJLPK_GetTotalCurrency(int APHNELOFGAK)
	{
		MCKCJMLOAFP_CurrencyInfo m = BBEPLKNMICJ_Currencies.Find((MCKCJMLOAFP_CurrencyInfo BNKHBCBJBKI) =>
		{
			//0x100CD54
			return BNKHBCBJBKI.PPFNGGCBJKC_Id == APHNELOFGAK;
		});
		if (m == null)
			return 0;
		return m.BDLNMOIOMHK_Total;
	}

	// // RVA: 0xFFA5B0 Offset: 0xFFA5B0 VA: 0xFFA5B0
	public int NOJDLFKKMDD_GetCurrencyTotal(int MHFBCINOJEE)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[MHFBCINOJEE - 1];
			MCKCJMLOAFP_CurrencyInfo m = BBEPLKNMICJ_Currencies.Find((MCKCJMLOAFP_CurrencyInfo BNKHBCBJBKI) =>
			{
				//0x100CD8C
				return BNKHBCBJBKI.PPFNGGCBJKC_Id == db.CPGFOBNKKBF_CurrencyId;
			});
			if(m != null)
			{
				return m.BDLNMOIOMHK_Total;
			}
		}
		return 0;
	}

	// // RVA: 0xFFA7DC Offset: 0xFFA7DC VA: 0xFFA7DC
	public MCKCJMLOAFP_CurrencyInfo JBEKNFEGFFI()
	{
		return BBEPLKNMICJ_Currencies.Find((MCKCJMLOAFP_CurrencyInfo BNKHBCBJBKI) =>
		{
			//0x100A150
			return BNKHBCBJBKI.PPFNGGCBJKC_Id == 1001;
		});
	}

	// // RVA: 0xFFA934 Offset: 0xFFA934 VA: 0xFFA934
	public bool FDFDGEMMKKJ()
	{
		return KMJLGBJBOAK_StaminaRefillCost <= DEAPMEIDCGC_GetTotalPaidCurrency();
	}

	// // RVA: 0xFFA95C Offset: 0xFFA95C VA: 0xFFA95C
	// public bool EELJBMHKHNP(int NAPIAEHGKGP) { }

	// // RVA: 0xFFA9BC Offset: 0xFFA9BC VA: 0xFFA9BC
	public int CIPHAHDGGPH()
	{
		return KMJLGBJBOAK_StaminaRefillCost;
	}

	// // RVA: 0xFFA9C4 Offset: 0xFFA9C4 VA: 0xFFA9C4
	// public int[] CBOJGDKGCEF() { }

	// // RVA: 0xFFAA3C Offset: 0xFFAA3C VA: 0xFFAA3C
	private void HLBJOJBALIG(List<string> OHNJJIMGKGK)
	{
		for(int i = 0; i < BJCPJPLPDIH.Count; i++)
		{
			BJCPJPLPDIH[i].Invoke(OHNJJIMGKGK);
		}
	}

	// // RVA: 0xFFAB20 Offset: 0xFFAB20 VA: 0xFFAB20
	private void FGDMEFINCEE()
	{
		for(int i = 0; i < BFHJLPDOEPB.Count; i++)
		{
			BFHJLPDOEPB[i]();
		}
	}

	// // RVA: 0xFFABFC Offset: 0xFFABFC VA: 0xFFABFC
	public void DJICHKCLMCD_UpdateCurrencies(List<MCKCJMLOAFP_CurrencyInfo> PIPMPLFMCPL_CurrenciesInfo)
	{
		if(PIPMPLFMCPL_CurrenciesInfo != null)
		{
			for(int i = 0; i < PIPMPLFMCPL_CurrenciesInfo.Count; i++)
			{
				MCKCJMLOAFP_CurrencyInfo currency = BBEPLKNMICJ_Currencies.Find((MCKCJMLOAFP_CurrencyInfo EABDEAANPOE) =>
				{
					//0x100A2B4
					return EABDEAANPOE.PPFNGGCBJKC_Id == PIPMPLFMCPL_CurrenciesInfo[i].PPFNGGCBJKC_Id;
				});
				if(currency == null)
				{
					BBEPLKNMICJ_Currencies.Add(PIPMPLFMCPL_CurrenciesInfo[i]);
				}
				else
				{
					currency.KCKBGALKNMA_NumPaidCrystal = PIPMPLFMCPL_CurrenciesInfo[i].KCKBGALKNMA_NumPaidCrystal;
					currency.BDLNMOIOMHK_Total = PIPMPLFMCPL_CurrenciesInfo[i].BDLNMOIOMHK_Total;
					currency.JLNEMPJICEH_NumFreeCrystal = PIPMPLFMCPL_CurrenciesInfo[i].JLNEMPJICEH_NumFreeCrystal;
				}
			}
		}
	}

	// // RVA: 0xFFAE44 Offset: 0xFFAE44 VA: 0xFFAE44
	public void DJICHKCLMCD_UpdateCurrencies(List<KPPFJJJAFFC> PIPMPLFMCPL)
	{
		for(int i = 0; i < PIPMPLFMCPL.Count; i++)
		{
			KPPFJJJAFFC BNKHBCBJBKI = PIPMPLFMCPL[i];
			MCKCJMLOAFP_CurrencyInfo m = BBEPLKNMICJ_Currencies.Find((MCKCJMLOAFP_CurrencyInfo EABDEAANPOE) =>
			{
				//0x100A300
				return EABDEAANPOE.PPFNGGCBJKC_Id == BNKHBCBJBKI.PPFNGGCBJKC_Id;
			});
			if(m == null)
			{
				BBEPLKNMICJ_Currencies.Add(BNKHBCBJBKI);
			}
			else
			{
				m.KCKBGALKNMA_NumPaidCrystal = BNKHBCBJBKI.KCKBGALKNMA_NumPaidCrystal;
				m.BDLNMOIOMHK_Total = BNKHBCBJBKI.BDLNMOIOMHK_Total;
				m.JLNEMPJICEH_NumFreeCrystal = BNKHBCBJBKI.JLNEMPJICEH_NumFreeCrystal;
			}
		}
	}

	// // RVA: 0xFFB088 Offset: 0xFFB088 VA: 0xFFB088
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		AHEFHIMGIBI_ServerSave = new BBHNACPENDM_ServerSaveData();
		AHEFHIMGIBI_ServerSave.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO.FKNGHCNOEHO_1/*1*/;
		CCNKAKCBBDJ = new BBHNACPENDM_ServerSaveData();
		CCNKAKCBBDJ.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO.AFGALHECDIJ_3/*3*/;
		FMFKHDPKLOC = new BBHNACPENDM_ServerSaveData();
		CCNKAKCBBDJ.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO.GGEELFGJAMP_2/*2*/;
		MNJHBCIIHED_PrevServerData = new BBHNACPENDM_ServerSaveData();
		CCNKAKCBBDJ.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO.LPKPFMHEKEM/*4*/;
		KPFKKDDOHCN = new AIFIANALLPB();
		CHNJPFCKFOI_FriendManager = new PIGBKEIAMPE_FriendManager();
		LNAHEIEIBOI_Initialized = false;
		KONHMOLMOCI_IsSaving = false;
		BBEPLKNMICJ_Currencies = new List<MCKCJMLOAFP_CurrencyInfo>();
		BPLOEAHOPFI_StaminaUpdater = new MCGNOFMAPBJ();
		IOCLFHJLHLE_IntimacyUpdater = new JKNNIKNKMNJ();
		PAAMLFNPJGJ_IntimacyDivaPresentLeft = new int[10];
		EDGFGECLOHE_IntimacyDivaTouchCount = new int[10];
		for(int i = 0; i < 10; i++)
		{
			PAAMLFNPJGJ_IntimacyDivaPresentLeft[i] = 1;
			EDGFGECLOHE_IntimacyDivaTouchCount[i] = 1;
		}
		ECFNAOCFKKN = 0;
		BLCDJDJJBHC = false;
		JNCBOBPPHHB_IntimacyTensionTime = 0;
		PKBOFLOJNIJ_LastLoginTime = 0;
		MMPBPOIFDAF_Scene.PMKOFEIONEG.FBGGEFFJJHB = (int)Utility.GetCurrentUnixTime() * 0x87727;
		JNMFKOHFAFB_PublicStatus.KNHIPBADANI.FBGGEFFJJHB = (int)MMPBPOIFDAF_Scene.PMKOFEIONEG.FBGGEFFJJHB ^ 0x7651;
		LGBMDHOLOIF_decoPlayerData = new FKAFHLIDAFD();
		LGBMDHOLOIF_decoPlayerData = new FKAFHLIDAFD(); // are they drunk ?
	}

	// // RVA: 0xFFB4B0 Offset: 0xFFB4B0 VA: 0xFFB4B0
	public void BAGMHFKPFIF_Update()
	{
		if(NKGJPJPHLIF.HHCJCDFCLOB.PECPLBANLBN)
			return;

		if(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester != null)
		{
			BPLOEAHOPFI_StaminaUpdater.FJDBNGEPKHL_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			IOCLFHJLHLE_IntimacyUpdater.FJDBNGEPKHL_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}
		PDKNJAEGNIL();
		PDKNJAEGNIL(LGBMDHOLOIF_decoPlayerData);
		PDKNJAEGNIL(LGBMDHOLOIF_decoPlayerData);
	}

	// // RVA: 0xFFB7A8 Offset: 0xFFB7A8 VA: 0xFFB7A8
	public void ODJCMJBNDOK_Load(IMCBBOAFION BHFHGFKBOHH, IMCBBOAFION FLENFOEFHPL, DJBHIFLHJLK MOBEEPPKFLG, bool JKJEFPNIPFO = false)
	{
		N.a.StartCoroutineWatched(ODDEPBIJHOE_Coroutine_Load(BHFHGFKBOHH,FLENFOEFHPL,MOBEEPPKFLG,JKJEFPNIPFO));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7B58 Offset: 0x6B7B58 VA: 0x6B7B58
	// // RVA: 0xFFB818 Offset: 0xFFB818 VA: 0xFFB818
	private IEnumerator ODDEPBIJHOE_Coroutine_Load(IMCBBOAFION BHFHGFKBOHH_OnSuccess, IMCBBOAFION FLENFOEFHPL_OnSuccessWithTuto, DJBHIFLHJLK MOBEEPPKFLG_OnError, bool JKJEFPNIPFO)
	{
		// public CIOECGOMILE KIGBLACMODG; // 0x10
		// public DJBHIFLHJLK MOBEEPPKFLG; // 0x18
		// public bool JKJEFPNIPFO; // 0x1C
		// public IMCBBOAFION FLENFOEFHPL; // 0x24
		// public IMCBBOAFION BHFHGFKBOHH; // 0x28
		// private PJKLMCGEJMK OKDOIAEGADK; // 0x2C
		// private OKGLGHCBCJP DLMOKNDEMMB; // 0x30
		// private NAIJIFAJGGK BPOJOBICBAC; // 0x34
		// private DOLDMCAMEOD GHPOKNKDBGO; // 0x38
		//0x1010F04

		PJKLMCGEJMK OKDOIAEGADK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		OKGLGHCBCJP_Database DLMOKNDEMMB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		AHEFHIMGIBI_ServerSave.KHEKNNFCAOI_Init(DLMOKNDEMMB);
		FMFKHDPKLOC.KHEKNNFCAOI_Init(DLMOKNDEMMB);
		CCNKAKCBBDJ.KHEKNNFCAOI_Init(DLMOKNDEMMB);
		MNJHBCIIHED_PrevServerData.KHEKNNFCAOI_Init(DLMOKNDEMMB);
		DCLNIAMEGLA = null;
		HAELBFCGHMB = false;
		BLCDJDJJBHC = false;
		NAIJIFAJGGK_RequestLoadPlayerData BPOJOBICBAC = OKDOIAEGADK.IFFNCAFNEAG_AddRequest<NAIJIFAJGGK_RequestLoadPlayerData>(new NAIJIFAJGGK_RequestLoadPlayerData());
		BPOJOBICBAC.HHIHCJKLJFF_BlockToRequest = AHEFHIMGIBI_ServerSave.KPIDBPEKMFD_GetBlockList();
		BPOJOBICBAC.IJMPLDBGMHC_OnDataReceived = AHEFHIMGIBI_ServerSave.IIEMACPEEBJ_Load;
		yield return BPOJOBICBAC.GDPDELLNOBO_WaitDone(N.a);

		StringBuilder str = new StringBuilder();
		bool firstDone = false;
		bool b = false;
		for(int i = 0; i < AHEFHIMGIBI_ServerSave.MGJKEJHEBPO_Blocks.Count; i++)
		{
			if(firstDone)
			{
				str.Append(",");
			}
			str.Append(AHEFHIMGIBI_ServerSave.MGJKEJHEBPO_Blocks[i].JIKKNHIAEKG_BlockName);
			str.Append(":");
			str.Append(AHEFHIMGIBI_ServerSave.MGJKEJHEBPO_Blocks[i].LLBJFFFJEPJ_Deseralized);
			str.Append(":");
			str.Append(AHEFHIMGIBI_ServerSave.MGJKEJHEBPO_Blocks[i].FJMOAAPNCJI_SaveId);
			firstDone = true;
			b = b | !AHEFHIMGIBI_ServerSave.MGJKEJHEBPO_Blocks[i].LLBJFFFJEPJ_Deseralized;
		}

		TodoLogger.Log(TodoLogger.Filesystem, str.ToString());
		ILCCJNDFFOB.HHCJCDFCLOB.NJEIHFPKOMG_SendServerSaveLoadInfo(!(BPOJOBICBAC.NPNNPNAIONN_IsError || b) ? 1 : 0, (int)BPOJOBICBAC.CJMFJOMECKI_ErrorId, str.ToString());
		if(BPOJOBICBAC.NPNNPNAIONN_IsError || b)
		{
			// private CIOECGOMILE.<>c__DisplayClass119_0 OPLBFCEPDCH; // 0x14
				// public bool HFPLKFCPHDK; // 0x8
				// // RVA: 0x100A354 Offset: 0x100A354 VA: 0x100A354
				// internal void GEAINKJJEIF() { }
			bool HFPLKFCPHDK = true;
			JHHBAFKMBDL.HHCJCDFCLOB.AHEMKCHEHMM(() => {
				// 0x100A354
				HFPLKFCPHDK = false;
			});
			//goto LAB_0101175c;
			//2
			//LAB_0101175c:
			while(HFPLKFCPHDK)
			{
				yield return null;
			}
			//goto LAB_01011cb0;
			//LAB_01011cb0:
			if(MOBEEPPKFLG_OnError != null)
			{
				MOBEEPPKFLG_OnError();
			}
			TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error ODDEPBIJHOE_Coroutine_Load");
			yield break;
		}
		// L 379
		PKBOFLOJNIJ_LastLoginTime = BPOJOBICBAC.NFEAMMJIMPG_Result.IFNLEKOILPM_UpdatedAt;
		ECFNAOCFKKN = PKBOFLOJNIJ_LastLoginTime;
		HAELBFCGHMB = BPOJOBICBAC.NFEAMMJIMPG_Result.MLGKDBJLNBM_DataStatus == 2;
		BPOJOBICBAC = null;
		AHEFHIMGIBI_ServerSave.NEBDDPDPAKJ(JKJEFPNIPFO);
		FMFKHDPKLOC.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
		CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
		PJKLMCGEJMK.DALFMJFKCGJ = AHEFHIMGIBI_ServerSave.MCKEOKFMLAH_SaveId;

		DOLDMCAMEOD_RequestRemainingForCurrencyIds GHPOKNKDBGO = OKDOIAEGADK.IFFNCAFNEAG_AddRequest<DOLDMCAMEOD_RequestRemainingForCurrencyIds>(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
		GHPOKNKDBGO.CGCFENMHJIM_Ids = NFGNKHONICJ();
		yield return GHPOKNKDBGO.GDPDELLNOBO_WaitDone(N.a);

		//goto LAB_01011f20;
		//3
		if(GHPOKNKDBGO.NPNNPNAIONN_IsError)
		{
			if(MOBEEPPKFLG_OnError != null)
			{
				MOBEEPPKFLG_OnError();
			}
		}

		BBEPLKNMICJ_Currencies.Clear();
		DJICHKCLMCD_UpdateCurrencies(GHPOKNKDBGO.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
		GHPOKNKDBGO = null;

		// private CIOECGOMILE.<>c__DisplayClass119_1 LBLMCMHMNGC; // 0x20
			// public bool PLOOEECNHFB; // 0x8
			// public bool NPNNPNAIONN; // 0x9
			// // RVA: 0x100A368 Offset: 0x100A368 VA: 0x100A368
			// internal void MELEJFNIAIM() { }
			// // RVA: 0x100A374 Offset: 0x100A374 VA: 0x100A374
			// internal void CHHCNDJIEDC() { }
		bool PLOOEECNHFB = false;
		bool NPNNPNAIONN = false;
		NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.OMPBFINJHDF_RequestVirtualCurrencyBalancesWithExpiredAt(() => {
			//0x100A368
			PLOOEECNHFB = true;
		}, () => {
			//0x100A374
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
		});
		//break;
		while(!PLOOEECNHFB)
		{
			yield return null;
		}
		if(NPNNPNAIONN)
		{
			//LAB_01011cb0:
			if(MOBEEPPKFLG_OnError != null)
			{
				MOBEEPPKFLG_OnError();
			}
			TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error ODDEPBIJHOE_Coroutine_Load");
			yield break;
		}

		//L763
		KPFKKDDOHCN.BDPMNDGIEGI_RequestInventories(null, null, true);
		//LAB_01011a28:
		while(true)
		{
			if(KPFKKDDOHCN.PLOOEECNHFB)
			{
				CHNJPFCKFOI_FriendManager.MFKOGDNNKLP();
				CHNJPFCKFOI_FriendManager.HHDGOABFEPC_GetFriendLimit(null, null, false);
				//LAB_01011ac0:
				while(true)
				{
					if(CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsDone)
					{
						int friendLimit = DLMOKNDEMMB.FMPEMFPLPDA_Exp.PCJACJANGCA_GetFriendForLevel(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level);
						if(friendLimit != CHNJPFCKFOI_FriendManager.JPEIBHJIHPI_FriendLimit)
						{
							CHNJPFCKFOI_FriendManager.PGPLAOGALHD_SetFriendLimit(friendLimit, null, null);
							//LAB_01011bec:
							while(!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsDone)
							{
								yield return null;
							}
						}	
						yield return N.a.StartCoroutineWatched(EKKCGGHIFEG_Coroutine_GetFriendCounts(MOBEEPPKFLG_OnError));
						// to 8
						MCLANEJGNHD_GetSystemProducts();
						// goto LAB_01011c88;
						//9
						while(true)
						{
							if(DICMPMEEIJL_HasSystemProducts)
							{
								if(!JNDDNFEINEH)
								{
									OIEBCNPOMIB_UpdateDayChange(false);
									KPHFDEOFKLM_UpdateEnergyDayChange();
									LBLNLMGHLAG_UpdateShop();
									AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.LPFFDGNDLKG_UpdateMedals(true, 2160);
									if(IPOHDKPGNFO_HasIntimacyDateChanged())
									{
										FAFAKNJLLIC_ResetIntimacyPresentLeft();
										CDIADEIOIHP_ResetIntimacyTouchCount();
									}
									if(KDHGBOOECKC.HHCJCDFCLOB != null && KDHGBOOECKC.HHCJCDFCLOB.IHGJNLNJPOK())
									{
										KDHGBOOECKC.HHCJCDFCLOB.PCPECPFJMGC();
									}
									NPAPJMLJBKM(false);
									AHEFHIMGIBI_ServerSave.FHLMCCPCEAI_SaveHash.BEBJKJKBOGH_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
									MIPMDKBKKJD_UpdateStaminaInfo();
									PCMPDIMCBJM_UpdateIntimacyInfo();
									HLACGFNICAI_UpdateIntimacyTensionInfo();

									HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.AGEAPKNODHO();
									GameManager.Instance.localSave.FBCDKFENOEM_SyncFlagsFromServer();
									CHNJPFCKFOI_FriendManager.BCEAAAOLGEB_Reset();
									FGDMEFINCEE();
									if(AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd == 0)
									{
										if(FLENFOEFHPL_OnSuccessWithTuto != null)
										{
											FLENFOEFHPL_OnSuccessWithTuto();
										}
										LNAHEIEIBOI_Initialized = true;
										yield break;
									}
									
									LNAHEIEIBOI_Initialized = true;
									if(BHFHGFKBOHH_OnSuccess != null)
									{
										BHFHGFKBOHH_OnSuccess();
									}
									yield break;
								}
								//goto LAB_01011cb0;
								if(MOBEEPPKFLG_OnError != null)
								{
									MOBEEPPKFLG_OnError();
								}
								TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error ODDEPBIJHOE_Coroutine_Load");
								yield break;
							}
							// To 9
							yield return null;
						}
					}
					// to 6
					yield return null;
					//to LAB_01011ac0:
				}
			}
			else
			{
				// to 5
				yield return null;
				//goto LAB_01011a28;
			}
		}
	}

	// // RVA: 0xFFB930 Offset: 0xFFB930 VA: 0xFFB930
	public void CJMDNPCBEJF_LoadDecoData(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool JKJEFPNIPFO = false)
	{
		LGBMDHOLOIF_decoPlayerData.BELHFJNAEKB();
		N.a.StartCoroutineWatched(MMAECJEKMJK_Coroutine_LoadDecoData(LGBMDHOLOIF_decoPlayerData, BHFHGFKBOHH, MOBEEPPKFLG, false));
	}

	// // RVA: 0xFFBA78 Offset: 0xFFBA78 VA: 0xFFBA78
	// public void PCIBGCGCNOH(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool JKJEFPNIPFO = False) { }

	// // RVA: 0xFFBA90 Offset: 0xFFBA90 VA: 0xFFBA90
	// public void BKKGIOABILM(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool JKJEFPNIPFO = False) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7BD0 Offset: 0x6B7BD0 VA: 0x6B7BD0
	// // RVA: 0xFFB9B8 Offset: 0xFFB9B8 VA: 0xFFB9B8
	private IEnumerator MMAECJEKMJK_Coroutine_LoadDecoData(FKAFHLIDAFD JEBPDGCBPJC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool JKJEFPNIPFO)
	{
		NAIJIFAJGGK_RequestLoadPlayerData PNLGHFCFPPK;

		//0x10123C4
		JEBPDGCBPJC.LNAHEIEIBOI = false;
		JEBPDGCBPJC.DCLNIAMEGLA = null;
		JEBPDGCBPJC.BLCDJDJJBHC = false;
		PNLGHFCFPPK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAIJIFAJGGK_RequestLoadPlayerData());
		PNLGHFCFPPK.HHIHCJKLJFF_BlockToRequest = JEBPDGCBPJC.AHEFHIMGIBI.KPIDBPEKMFD_GetBlockList();
		PNLGHFCFPPK.IJMPLDBGMHC_OnDataReceived = JEBPDGCBPJC.AHEFHIMGIBI.IIEMACPEEBJ_Load;
		yield return PNLGHFCFPPK.GDPDELLNOBO_WaitDone(N.a);
		bool b = false;
		for(int i = 0; i < JEBPDGCBPJC.AHEFHIMGIBI.MGJKEJHEBPO_Blocks.Count; i++)
		{
			b |= !JEBPDGCBPJC.AHEFHIMGIBI.MGJKEJHEBPO_Blocks[i].LLBJFFFJEPJ_Deseralized;
		}
		if(!PNLGHFCFPPK.NPNNPNAIONN_IsError && !b)
		{
			PNLGHFCFPPK = null;
			JEBPDGCBPJC.FMFKHDPKLOC.ODDIHGPONFL_Copy(JEBPDGCBPJC.AHEFHIMGIBI);
			JEBPDGCBPJC.CCNKAKCBBDJ.ODDIHGPONFL_Copy(JEBPDGCBPJC.AHEFHIMGIBI);
			JEBPDGCBPJC.LNAHEIEIBOI = true;
			if(BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		}
		else
		{
			bool HFPLKFCPHDK = true;
			JHHBAFKMBDL.HHCJCDFCLOB.AHEMKCHEHMM(() =>
			{
				//0x100A388
				HFPLKFCPHDK = false;
			});
			while(HFPLKFCPHDK)
				yield return null;
			if(MOBEEPPKFLG != null)
				MOBEEPPKFLG();
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7C48 Offset: 0x6B7C48 VA: 0x6B7C48
	// // RVA: 0xFFBAC8 Offset: 0xFFBAC8 VA: 0xFFBAC8
	private IEnumerator EKKCGGHIFEG_Coroutine_GetFriendCounts(DJBHIFLHJLK MOBEEPPKFLG_OnError)
	{
		//0x1010240
		CHNJPFCKFOI_FriendManager.PFJBNPIBFMO_GetReceivedRequests(null, (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x100A39C
			MOBEEPPKFLG_OnError();
		}, false);
		while (!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsDone)
			yield return null;
		CHNJPFCKFOI_FriendManager.BMJANOADDCC_GetFriends(null, (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x100A3C8
			MOBEEPPKFLG_OnError();
		}, false);
		while (!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsDone)
			yield return null;
		CHNJPFCKFOI_FriendManager.MEJHFCBFPED_GetSentRequests(null, (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x100A3F4
			MOBEEPPKFLG_OnError();
		}, false);
		while (!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsDone)
			yield return null;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7CC0 Offset: 0x6B7CC0 VA: 0x6B7CC0
	// // RVA: 0xFFBB90 Offset: 0xFFBB90 VA: 0xFFBB90
	// private IEnumerator HLPJPJBKEPE(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xFFBC3C Offset: 0xFFBC3C VA: 0xFFBC3C
	private bool LEDMBIANHDG_HasIntimacyTouchDateChanged()
	{
		long time = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MJDMEKMGFJA_IntimacyTouchSaveTime;
		if(time != 0)
		{
			long serverTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			DateTime d = Utility.GetLocalDateTime(time);
			DateTime d2 = Utility.GetLocalDateTime(serverTime);
			return d.Year != d2.Year || d.Month != d2.Month || d.Day != d2.Day;
		}
		return false;
	}

	// // RVA: 0xFFBE9C Offset: 0xFFBE9C VA: 0xFFBE9C
	private bool IPOHDKPGNFO_HasIntimacyDateChanged()
	{
		long presentSaveDate = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ANNIPKMMIAC_IntimacyPresentSaveDate;
		int date = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
		if (presentSaveDate < 1)
		{
			if(!LEDMBIANHDG_HasIntimacyTouchDateChanged())
			{
				AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ANNIPKMMIAC_IntimacyPresentSaveDate = date;
				return false;
			}
			return true;
		}
		else
		{
			return presentSaveDate != date;
		}
	}

	// // RVA: 0xFF3BEC Offset: 0xFF3BEC VA: 0xFF3BEC
	public bool AIKJMHBDABF_SavePlayerData(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, List<long> AMOMNBEAHBF)
	{
		return ACEDPNCIGDG((PJKLMCGEJMK CPHFEPHDJIB, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE JEHOEIKANFL, string JCJDPGMKJAJ) =>
		{
			//0x100A420
			GGKHIHFPKDH_SavePlayerData req = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
			req.GJAEJFLLKGC_RetryTime = 1;
			req.DOMFHDPMCCO(JEHOEIKANFL, JCJDPGMKJAJ, AMOMNBEAHBF);
			return req;
		}, BHFHGFKBOHH, MOBEEPPKFLG);
	}

	// // RVA: 0xFFC6E4 Offset: 0xFFC6E4 VA: 0xFFC6E4
	public bool LOOCNGEPAMI(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, int HJBLIJOGNPC)
	{
		return ACEDPNCIGDG((PJKLMCGEJMK CPHFEPHDJIB, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE JEHOEIKANFL, string JCJDPGMKJAJ) =>
		{
			//0x100A528
			AHNHJFCAPCH_SetRaidbossRewardsReceivedAndSave req = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new AHNHJFCAPCH_SetRaidbossRewardsReceivedAndSave());
			req.GJAEJFLLKGC_RetryTime = 1;
			req.BIHCCEHLAOD.DOMFHDPMCCO(JEHOEIKANFL, JCJDPGMKJAJ, HJBLIJOGNPC);
			return req;
		}, BHFHGFKBOHH, MOBEEPPKFLG);
	}

	// // RVA: 0xFFC7CC Offset: 0xFFC7CC VA: 0xFFC7CC
	// public bool FAMAFKMHFAK(CIOECGOMILE.PIIFKPKIOOB JDEPBIPCMAL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xFFBFF8 Offset: 0xFFBFF8 VA: 0xFFBFF8
	private bool ACEDPNCIGDG(PIIFKPKIOOB JDEPBIPCMAL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		if(LNAHEIEIBOI_Initialized)
		{
			if (KONHMOLMOCI_IsSaving)
				return false;
			GameManager.Instance.localSave.FBCDKFENOEM_SyncFlagsFromServer();
			if(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common != null)
			{
				if(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MNLAJEDKLCI_StamineLotTime == 0)
				{
					AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MNLAJEDKLCI_StamineLotTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				}
			}
			IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
			if (IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP == 0)
			{
				if(!BLCDJDJJBHC)
				{
					if(!CNGFKOJANNP.HHCJCDFCLOB.AKPCMLEPPGC_IsInvalid)
					{
						AHEFHIMGIBI_ServerSave.IPLNOMCCNBI_UpdatePublicStatus();
						BBHNACPENDM_ServerSaveData.EMHDCKMFCGE data = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_ServerSave, true);
						if(data != null)
						{
							if(!data.LHIACHALIFC_IsEmpty())
							{
								for(int i = 0; i < data.KFGDPMNCCFO.Count; i++)
								{
									KLFDBFMNLBL_ServerSaveBlock block = AHEFHIMGIBI_ServerSave.LBDOLHGDIEB_GetBlock(data.KFGDPMNCCFO[i]);
									FENCAJJBLBH a = block.PFAKPFKJJKA();
									if(a != null)
									{
										N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(a, MOBEEPPKFLG, 1004));
										return true;
									}
								}
								if(CNGFKOJANNP.HHCJCDFCLOB.AKPCMLEPPGC_IsInvalid)
								{
									N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 1005));
									return true;
								}
								//NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester
								KONHMOLMOCI_IsSaving = true;
								PMHLJAIGBGK = null;
								FMEDFGOMNBK = null;
								KDLBAGCENNC = null;
								if(!JHOKIPPIHII_IsSavingToServer)
								{
									CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
									N.a.StartCoroutineWatched(NJDCNPOKGKF_Coroutine_Save(JDEPBIPCMAL, data, BHFHGFKBOHH, MOBEEPPKFLG));
									return true;
								}
								KDLBAGCENNC = data;
								CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
								AHEFHIMGIBI_ServerSave.PLCFEICAKBC(data.KFGDPMNCCFO);
								CCNKAKCBBDJ.PLCFEICAKBC(data.KFGDPMNCCFO);
								FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
								KONHMOLMOCI_IsSaving = false;
								//LAB_00ffc3e0;
							}
						}
					}
					else
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 1003));
						return true;
					}
				}
				else
				{
					N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 1002));
					return true;
				}
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 1001));
				return true;
			}
		}
		//LAB_00ffc3e0
		if (BHFHGFKBOHH != null)
			BHFHGFKBOHH();
		return true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7D38 Offset: 0x6B7D38 VA: 0x6B7D38
	// // RVA: 0xFFC8A4 Offset: 0xFFC8A4 VA: 0xFFC8A4
	private IEnumerator NJDCNPOKGKF_Coroutine_Save(CIOECGOMILE.PIIFKPKIOOB JDEPBIPCMAL, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE JEHOEIKANFL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		PJKLMCGEJMK OKDOIAEGADK; // 0x28
		CACGCMBKHDI_Request DLOIHKKKNBB; // 0x2C

		//0x10769F0
		OKDOIAEGADK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		bool BEKAMBBOLBO = false;
		string JCJDPGMKJAJ = "";
		OKDOIAEGADK.BNJPAKLNOPA_WorkerThreadQueue.Add(() => 
		{
			//0x100A648
			JCJDPGMKJAJ = JEHOEIKANFL.PBNINEMAOPB();
			BEKAMBBOLBO = true;
		});
		while(!BEKAMBBOLBO)
			yield return null;
		DLOIHKKKNBB = JDEPBIPCMAL(OKDOIAEGADK, JEHOEIKANFL, JCJDPGMKJAJ);
		yield return DLOIHKKKNBB.GDPDELLNOBO_WaitDone(N.a);
		if(DLOIHKKKNBB.NPNNPNAIONN_IsError)
		{
			if(MOBEEPPKFLG != null)
				MOBEEPPKFLG();
			KONHMOLMOCI_IsSaving = false;
			yield break;
		}
		List<string> l = (DLOIHKKKNBB as CJIKLGPIPBA).KPIDBPEKMFD();
		AHEFHIMGIBI_ServerSave.PLCFEICAKBC(l);
		CCNKAKCBBDJ.PLCFEICAKBC(l);
		FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
		ECFNAOCFKKN = (DLOIHKKKNBB as CJIKLGPIPBA).DPKGNBIAFDO();
		HLBJOJBALIG(l);
		int a = (DLOIHKKKNBB as CJIKLGPIPBA).JNFCOPCBHAP();
		if(a == 2 || BDNBIEMJMCD)
		{
			yield return N.a.StartCoroutineWatched(DEHKLOLHKID_Coroutine_ReSave(BHFHGFKBOHH, MOBEEPPKFLG));
		}
		if(BHFHGFKBOHH != null)
			BHFHGFKBOHH();
		KONHMOLMOCI_IsSaving = false;
	}

	// // RVA: 0xFF3E10 Offset: 0xFF3E10 VA: 0xFF3E10
	public bool OEAMJGPAIGP(FKAFHLIDAFD JEBPDGCBPJC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, List<long> AMOMNBEAHBF)
	{
		return OEAMJGPAIGP(BHFHGFKBOHH, MOBEEPPKFLG, AMOMNBEAHBF);
	}

	// // RVA: 0xFFC990 Offset: 0xFFC990 VA: 0xFFC990
	public bool OEAMJGPAIGP(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, List<long> AMOMNBEAHBF)
	{
		if(LGBMDHOLOIF_decoPlayerData.LNAHEIEIBOI)
		{
			if(LGBMDHOLOIF_decoPlayerData.KONHMOLMOCI)
				return false;
			IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
			if(IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP == 0)
			{
				PFAKPFKJJKA();
				if(LGBMDHOLOIF_decoPlayerData.BLCDJDJJBHC)
				{
					N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 1002));
					return true;
				}
				else
				{
					if(!CNGFKOJANNP.HHCJCDFCLOB.AKPCMLEPPGC_IsInvalid)
					{
						AHEFHIMGIBI_ServerSave.IPLNOMCCNBI_UpdatePublicStatus();
						BBHNACPENDM_ServerSaveData.EMHDCKMFCGE d = LGBMDHOLOIF_decoPlayerData.FMFKHDPKLOC.LEMFJICBALP(LGBMDHOLOIF_decoPlayerData.AHEFHIMGIBI, true);
						if(d != null)
						{
							if(!d.LHIACHALIFC_IsEmpty())
							{
								for(int i = 0; i < d.KFGDPMNCCFO.Count; i++)
								{
									FENCAJJBLBH falsif = LGBMDHOLOIF_decoPlayerData.AHEFHIMGIBI.LBDOLHGDIEB_GetBlock(d.KFGDPMNCCFO[i]).PFAKPFKJJKA();
									if(falsif != null)
									{
										N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(falsif, MOBEEPPKFLG, 1004));
										return true;
									}
								}
								if(CNGFKOJANNP.HHCJCDFCLOB.AKPCMLEPPGC_IsInvalid)
								{
									N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 1005));
									return true;
								}
								LGBMDHOLOIF_decoPlayerData.KONHMOLMOCI = true;
								GGKHIHFPKDH_SavePlayerData data = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
								data.GJAEJFLLKGC_RetryTime = 1.0f;
								data.DOMFHDPMCCO(d, AMOMNBEAHBF);
								LGBMDHOLOIF_decoPlayerData.CCNKAKCBBDJ.ODDIHGPONFL_Copy(LGBMDHOLOIF_decoPlayerData.AHEFHIMGIBI);
								N.a.StartCoroutineWatched(CAJOAKIOCEF_Coroutine_SaveDecoData(LGBMDHOLOIF_decoPlayerData, data, BHFHGFKBOHH, MOBEEPPKFLG));
								return true;
							}
						}
						//LAB_00ffcc40
					}
					else
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 1003));
						return true;
					}
				}
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 1001));
				return true;
			}
		}
		//LAB_00ffcc40
		if(BHFHGFKBOHH != null)
			BHFHGFKBOHH();
		return true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7DB0 Offset: 0x6B7DB0 VA: 0x6B7DB0
	// // RVA: 0xFFD094 Offset: 0xFFD094 VA: 0xFFD094
	private IEnumerator CAJOAKIOCEF_Coroutine_SaveDecoData(FKAFHLIDAFD JEBPDGCBPJC, GGKHIHFPKDH_SavePlayerData COJNCNGHIJC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		//0x1077BBC
		yield return COJNCNGHIJC.GDPDELLNOBO_WaitDone(N.a);
		if(COJNCNGHIJC.NPNNPNAIONN_IsError)
		{
			if(MOBEEPPKFLG != null)
				MOBEEPPKFLG();
		}
		else
		{
			JEBPDGCBPJC.AHEFHIMGIBI.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF_Names);
			JEBPDGCBPJC.CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF_Names);
			JEBPDGCBPJC.FMFKHDPKLOC.ODDIHGPONFL_Copy(JEBPDGCBPJC.CCNKAKCBBDJ);
			if(BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		}
		JEBPDGCBPJC.KONHMOLMOCI = false;
	}

	// // RVA: 0xFFD168 Offset: 0xFFD168 VA: 0xFFD168
	public bool BMKEBEJJKBE(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, ulong FIBPIDELFBB)
	{
		EBEGGFECPOE.JCHLONCMPAJ();
		if(LNAHEIEIBOI_Initialized)
		{
			if (KONHMOLMOCI_IsSaving)
				return false;
			if(CNGFKOJANNP.HHCJCDFCLOB.AKPCMLEPPGC_IsInvalid)
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 2001));
				return true;
			}
			else
			{
				bool a1_line6 = false;
				int a2 = 0;
				int a3 = 0;
				GameManager.Instance.localSave.FBCDKFENOEM_SyncFlagsFromServer();
				IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
				if(IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP == 0)
				{
					PFAKPFKJJKA();
					if(!BLCDJDJJBHC)
					{
						OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
						List<string> ls = new List<string>(10);
						List<int> li = new List<int>(10);
						if((FIBPIDELFBB & 1) != 0)
						{
							if(AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic != null)
							{
								List<JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo> lsongs = AHEFHIMGIBI_ServerSave.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo;
								for(int i = 0; i < lsongs.Count; i++)
								{
									if(lsongs[i].BKJPGJJAODB != null)
									{
										for(int j = 0; j < lsongs[i].BKJPGJJAODB.Count; j++)
										{
											JDDGGJCGOPA_RecordMusic.NPGCCNCHDLF(lsongs[i].BKJPGJJAODB[j], out a1_line6, out a2, out a3);
											DGMPLJFDOHF.Clear();
											if(!a1_line6)
											{
												DGMPLJFDOHF.AppendFormat(AIFFODKHLJE_FreeKey, lsongs[i].FDMENECIKEL_FreeMusicId, a2, a3);
											}
											else
											{
												DGMPLJFDOHF.AppendFormat(KINJMGALNDE_FreeKeyL6, lsongs[i].FDMENECIKEL_FreeMusicId, a2, a3);
											}
											ls.Add(DGMPLJFDOHF.ToString());
										}
									}
								}
							}
						}
						if ((FIBPIDELFBB & 2) != 0)
						{
							if (AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode != null)
							{
								//L385
								bool b = false;
								List<OCLHKHAMDHF_Episode.MGGPEOCPIEG> l = AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.POEDIMMMLME(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode, ref b);
								for(int i = 0; i < l.Count; i++)
								{
									JNIKPOIKFAC_Reward rwrd = l[i].KONJMFICNJJ;
									OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo epInfo = AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[l[i].HODPFJGODDN_EpIdx];
									if(!rwrd.MFKJAOLIPMA_IsVc || !epInfo.MCIHDIBHHBI_IsRewardReceived(l[i].CPNGJMKFCJI))
									{
										//LAB_00ffdc5c
										HMGPODKEFBA_EpisodeInfo dbEp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[l[i].HODPFJGODDN_EpIdx];
										FMLIFJBPFNA_Step dbStep = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps[dbEp.IOFHEGJPHKG_StepId - 1];
										OOOOCFAFGCP data = new OOOOCFAFGCP();
										data.ADCMNODJBGJ = JpStringLiterals.StringLiteral_9768;
										if(dbStep.FGOGPCMHPIN_Count - 1 == l[i].CPNGJMKFCJI)
										{
											data.LKGELAPAACK = true;
											data.LJGOOOMOMMA = JpStringLiterals.StringLiteral_9769;
											data.DNBFMLBNAEE = dbStep.JENFHJDFFAD_Pt[l[i].CPNGJMKFCJI];
										}
										else
										{
											data.LKGELAPAACK = false;
											data.LJGOOOMOMMA = string.Format(MessageManager.Instance.GetMessage("common", "unlock_episode_reward"), dbStep.JENFHJDFFAD_Pt[l[i].CPNGJMKFCJI]);
											data.DNBFMLBNAEE = dbStep.JENFHJDFFAD_Pt[l[i].CPNGJMKFCJI];
										}
										EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.CNACJCAMCFB_4, dbEp.KELFCMEOPPM.ToString() + ":" + l[i].HODPFJGODDN_EpIdx);
										EBEGGFECPOE.OBCINIPHGGH = 0;
										EBEGGFECPOE.PJBJCBEMEEC = 0;
										EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_ServerSave, rwrd.KIJAPOFAGPN_Item, rwrd.JDLJPNMLFID_Count, data, 0);
										epInfo.BDPOOJDJKAA_SetRewardReceived(l[i].CPNGJMKFCJI, true);
										if(rwrd.MFKJAOLIPMA_IsVc)
										{
											DGMPLJFDOHF.Clear();
											DGMPLJFDOHF.AppendFormat(AMIPEDALBJP_EpKey, l[i].HODPFJGODDN_EpIdx + 1, l[i].CPNGJMKFCJI + 1);
											ls.Add(DGMPLJFDOHF.ToString());
										}
										if(rwrd.KIJAPOFAGPN_Item == 50002)
										{
											ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.NEIJFCOANMA_50, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, AHEFHIMGIBI_ServerSave, 2, false);
										}
									}
								}
								AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BOAIINJHENE();
							}
						}
						bool b2 = false;
						if ((FIBPIDELFBB & 4) != 0)
						{
							//678
							b2 = false;
							if (AHEFHIMGIBI_ServerSave.GOACJBOCLHH_Quest != null)
							{
								List<NFPHOINMHKN_QuestInfo> dailyquest = AHEFHIMGIBI_ServerSave.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests;
								for(int i = 0; i < dailyquest.Count; i++)
								{
									if(dailyquest[i].JIOMCDGKIAF == 1)
									{
										if(dailyquest[i].EALOBDHOCHP_Stat > 0 && dailyquest[i].EALOBDHOCHP_Stat <= 2)
										{
											CNLPPCFJEID_QuestInfo qInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[dailyquest[i].PPFNGGCBJKC_Id - 1];
											LCKMNLOLDPD ldata = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.LFAAEPAAEMB[qInfo.EIHOBHDKCDB_RewardId - 1];
											OOOOCFAFGCP data = new OOOOCFAFGCP();
											data.ADCMNODJBGJ = JpStringLiterals.StringLiteral_9771;
											EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.LEABABGFEGB_8, dailyquest[i].PPFNGGCBJKC_Id.ToString());
											EBEGGFECPOE.OBCINIPHGGH = 0;
											EBEGGFECPOE.PJBJCBEMEEC = 0;
											EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_ServerSave, ldata.GLCLFMGPMAN_ItemFullId, ldata.HMFFHLPNMPH_Cnt, data, 0);
											if(ldata.APNMKLJMPMD_Type == 2)
											{
												DGMPLJFDOHF.Clear();
												DGMPLJFDOHF.AppendFormat("daily_quest_" + ldata.BGFPPGPJONG_QuestKeyId.ToString("D4"), Array.Empty<object>());
												ls.Add(DGMPLJFDOHF.ToString());
												b2 = true;
											}
											dailyquest[i].EALOBDHOCHP_Stat = 3;
											if(GNGMCIAIKMA.HHCJCDFCLOB != null)
											{
												GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.KJAFDMGNBPO_11, 0, 1, null);
												GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
											}
										}
										dailyquest[i].JIOMCDGKIAF = 0;
									}
								}
							}
						}
						if ((FIBPIDELFBB & 8) != 0)
						{
							//950
							if(AHEFHIMGIBI_ServerSave.GOACJBOCLHH_Quest != null)
							{
								List<NFPHOINMHKN_QuestInfo> normalQuest = AHEFHIMGIBI_ServerSave.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests;
								for(int i = 0; i < normalQuest.Count; i++)
								{
									if(normalQuest[i].JIOMCDGKIAF == 1)
									{
										if(normalQuest[i].EALOBDHOCHP_Stat < 3)
										{
											CNLPPCFJEID_QuestInfo qInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[normalQuest[i].PPFNGGCBJKC_Id - 1];
											LCKMNLOLDPD ldata = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.LFAAEPAAEMB[qInfo.EIHOBHDKCDB_RewardId - 1];
											normalQuest[i].EALOBDHOCHP_Stat = 3;
											OOOOCFAFGCP data = new OOOOCFAFGCP();
											if(ILLPDLODANB.FJFPHHEFMIB_IsSnsMission(qInfo))
											{
												data.ADCMNODJBGJ = JpStringLiterals.StringLiteral_9773;
												EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.LIHFAAPBLOH_12, normalQuest[i].PPFNGGCBJKC_Id.ToString());
											}
											else
											{
												if(ILLPDLODANB.HHMKDAIGMKC_IsDebutMission((ILLPDLODANB.LOEGALDKHPL)qInfo.INDDJNMPONH_Type))
												{
													data.ADCMNODJBGJ = JpStringLiterals.StringLiteral_9774;
													EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.NJCPDNAHPDP_13, normalQuest[i].PPFNGGCBJKC_Id.ToString());
												}
												else
												{
													data.ADCMNODJBGJ = JpStringLiterals.StringLiteral_9775;
													EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.APJJPDJNOJB_7, normalQuest[i].PPFNGGCBJKC_Id.ToString());
												}
											}
											EBEGGFECPOE.OBCINIPHGGH = 0;
											EBEGGFECPOE.PJBJCBEMEEC = 0;
											EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_ServerSave, ldata.GLCLFMGPMAN_ItemFullId, ldata.HMFFHLPNMPH_Cnt, data, 0);
											if(ldata.APNMKLJMPMD_Type == 1)
											{
												DGMPLJFDOHF.Clear();
												DGMPLJFDOHF.AppendFormat("normal_quest_key_" + ldata.BGFPPGPJONG_QuestKeyId.ToString("D4"), Array.Empty<object>());
												ls.Add(DGMPLJFDOHF.ToString());
												b2 = false;
											}
										}
										normalQuest[i].JIOMCDGKIAF = 0;
									}
								}
							}
						}
						if ((FIBPIDELFBB & 0x1c7fffffff0) != 0)
						{
							//1289
							for(int i = 0; i < 63; i++)
							{
								if((((ulong)1 << i) & FIBPIDELFBB) != 0)
								{
									IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.HADLGKFCGLK((ulong)1 << i);
									if(ev != null && ev.AGLILDLEFDK_Missions != null && ev.OLDFFDMPEBM_Quests != null)
									{
										int cnt = ev.AGLILDLEFDK_Missions.Count;
										if(ev.OLDFFDMPEBM_Quests.Count < cnt)
											cnt = ev.OLDFFDMPEBM_Quests.Count;
										for(int j = 0; j < cnt; j++)
										{
											if(ev.OLDFFDMPEBM_Quests[j].JIOMCDGKIAF == 1)
											{
												AKIIJBEJOEP d = ev.AGLILDLEFDK_Missions[ev.OLDFFDMPEBM_Quests[j].PPFNGGCBJKC_Id - 1];
												ev.OLDFFDMPEBM_Quests[j].EALOBDHOCHP_Stat = 3;
												OOOOCFAFGCP data = new OOOOCFAFGCP();
												data.ADCMNODJBGJ = JpStringLiterals.StringLiteral_9777;
												EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.PCDOEIFMLHG_10, (ev.PGIIDPEGGPI_EventId * 1000 + ev.OLDFFDMPEBM_Quests[j].PPFNGGCBJKC_Id).ToString());
												EBEGGFECPOE.OBCINIPHGGH = 0;
												EBEGGFECPOE.PJBJCBEMEEC = 0;
												EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_ServerSave, d.KIJAPOFAGPN_ItemId, d.JDLJPNMLFID_ItemCount, data, 0);
												if(d.IKJAAKEINHC_Slt < 1)
												{
													if(d.HPAOAKMKCMA_Slt2 > 0)
													{
														DGMPLJFDOHF.Clear();
														string s = ev.DCODGEOEDPG();
														DGMPLJFDOHF.Append(s != null ? s : "");
														DGMPLJFDOHF.Append(d.HPAOAKMKCMA_Slt2.ToString("D4"));
														ls.Add(DGMPLJFDOHF.ToString());
														if(d.PJPDOCNJNGJ)
														{
															li.Add((int)ev.OEGAJJANHGL());
														}
														else
														{
															li.Add(-1);
														}
														b2 = false;
													}
												}
												else
												{
													DGMPLJFDOHF.Clear();
													string s = ev.IFKKBHPMALH();
													DGMPLJFDOHF.Append(s != null ? s : "");
													DGMPLJFDOHF.Append(d.IKJAAKEINHC_Slt.ToString());
													ls.Add(DGMPLJFDOHF.ToString());
													if(d.PJPDOCNJNGJ)
													{
														li.Add((int)ev.OEGAJJANHGL());
													}
													else
													{
														li.Add(-1);
													}
													b2 = true;
												}
												if(GNGMCIAIKMA.HHCJCDFCLOB != null)
												{
													GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.CLJHDIKFECG_12, 0, 1, null);
													GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
												}
											}
											ev.OLDFFDMPEBM_Quests[j].JIOMCDGKIAF = 0;
										}
									}
								}
							}
						}
						if ((FIBPIDELFBB & 0x800000000) != 0)
						{
							//1646
							if(AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume != null)
							{
								bool b = false;
								List<EBFLJMOCLNA_Costume.AEGPJOENNML> l = AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.POEDIMMMLME(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, ref b);
								if(l != null)
								{
									for(int i = 0; i < l.Count; i++)
									{
                                        EBFLJMOCLNA_Costume.ILFJDCICIKN cos = AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(l[i].JPIDIENBGKH_CostumeId);
                                        EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.LEHHJINPFHA_25, l[i].JPIDIENBGKH_CostumeId.ToString() + ":" + cos.ANAJIAENLNB_Level);
										if(l[i].HGNBPGDIFGH_LevelInfo.LMNEDALDGNC())
										{
											EBEGGFECPOE.OBCINIPHGGH = 0;
											EBEGGFECPOE.PJBJCBEMEEC = 0;
											EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_ServerSave, l[i].HGNBPGDIFGH_LevelInfo.PIBLLGLCJEO_Value[0], l[i].HGNBPGDIFGH_LevelInfo.PIBLLGLCJEO_Value[1], null, 0);
										}
										if(l[i].HGNBPGDIFGH_LevelInfo.LDHIAOGPINB() > 0)
										{
											cos.PDADHMIODCA(l[i].HGNBPGDIFGH_LevelInfo.LDHIAOGPINB(), true);
										}
										int costume_upgrade_vc_count = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("costume_upgrade_vc_count", 5);
										EBEGGFECPOE.OBCINIPHGGH = 0;
										EBEGGFECPOE.PJBJCBEMEEC = 0;
										EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1), costume_upgrade_vc_count, null, 0);
										DGMPLJFDOHF.Clear();
										DGMPLJFDOHF.AppendFormat(GPECKLLDAFH_CosKey, l[i].JPIDIENBGKH_CostumeId, l[i].ANAJIAENLNB_Level + 1);
										ls.Add(DGMPLJFDOHF.ToString());
									}
								}
							}
						}
						if ((FIBPIDELFBB & 0x1000000000) != 0)
						{
							//1876
							if(AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer != null)
							{
								while(true)
								{
									OCMJNBIFJNM_Offer.JPOHOLBBFGP of = AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.FOFLMHELILC.Find((OCMJNBIFJNM_Offer.JPOHOLBBFGP JPAEDJJFFOI) =>
									{
										//0x100A184
										return JPAEDJJFFOI.JIOMCDGKIAF == 1;
									});
									if(of == null)
										break;
									int a = 0;
									switch(of.GBJFNGCDKPM_Type)
									{
										case 1:
											a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.HOJPJAFDIAD[of.MLDPDLPHJPM_OfferId - 1].LJNAKDMILMC;
											break;
										case 2:
											a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FFKIBJKEBNP[of.MLDPDLPHJPM_OfferId - 1].LJNAKDMILMC;
											break;
										case 3:
											a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.PMCDKBBHCJK[of.MLDPDLPHJPM_OfferId - 1].LJNAKDMILMC;
											break;
										case 4:
											a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG[of.MLDPDLPHJPM_OfferId - 1].LJNAKDMILMC;
											break;
										default:
											break;
									}
									if(a > 0)
									{
										DGMPLJFDOHF.Clear();
										DGMPLJFDOHF.AppendFormat("new_offer_clear_key_" + a.ToString("D4"), Array.Empty<object>());
										ls.Add(DGMPLJFDOHF.ToString());
										EBEGGFECPOE.OBCINIPHGGH = 0;
										EBEGGFECPOE.PJBJCBEMEEC = 0;
										EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.JMLJADADEEF_28, of.GBJFNGCDKPM_Type + ":" + of.MLDPDLPHJPM_OfferId);
										EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1), 5, null, 0);
										b2 = false;
									}
									of.JIOMCDGKIAF = 0;
								}
							}
						}
						AHEFHIMGIBI_ServerSave.IPLNOMCCNBI_UpdatePublicStatus();
						BBHNACPENDM_ServerSaveData.EMHDCKMFCGE e = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_ServerSave, true);
						if(e != null)
						{
							if(!e.LHIACHALIFC_IsEmpty())
							{
								for(int i = 0; i < e.KFGDPMNCCFO.Count; i++)
								{
									KLFDBFMNLBL_ServerSaveBlock block = AHEFHIMGIBI_ServerSave.LBDOLHGDIEB_GetBlock(e.KFGDPMNCCFO[i]);
									if(block.PFAKPFKJJKA() != null)
									{
										N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(block.PFAKPFKJJKA(), MOBEEPPKFLG, 2010));
										return true;
									}
								}
								KONHMOLMOCI_IsSaving = true;
								PMHLJAIGBGK = null;
								FMEDFGOMNBK = null;
								KDLBAGCENNC = null;
								if(JHOKIPPIHII_IsSavingToServer)
								{
									KDLBAGCENNC = e;
									if(ls.Count > 0)
									{
										PMHLJAIGBGK = ls;
										FMEDFGOMNBK = li;
									}
									CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
									AHEFHIMGIBI_ServerSave.PLCFEICAKBC(e.KFGDPMNCCFO);
									CCNKAKCBBDJ.PLCFEICAKBC(e.KFGDPMNCCFO);
									FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
									KONHMOLMOCI_IsSaving = false;
									//LAB_01000bc8;
								}
								else
								{
									if(ls.Count > 0)
									{
										MOMPDFMMICK_ClaimAchievementPrizesAndSave req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new MOMPDFMMICK_ClaimAchievementPrizesAndSave());
										req.GJAEJFLLKGC_RetryTime = 1;
										req.DOMFHDPMCCO(e, ls, b2);
										req.MEGNAIJPBFF = li;
										CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
										N.a.StartCoroutineWatched(AIBLBMDILLG_Coroutine_SaveWithAchievement(req, BHFHGFKBOHH, MOBEEPPKFLG));
										return true;
									}
									else
									{
										CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
										N.a.StartCoroutineWatched(NJDCNPOKGKF_Coroutine_Save((PJKLMCGEJMK OOAIKCALCHL, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE IPIFBCIMHMP, string JCJDPGMKJAJ) =>
										{
											//0x100A1B8
											GGKHIHFPKDH_SavePlayerData savereq = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
											savereq.GJAEJFLLKGC_RetryTime = 1;
											savereq.DOMFHDPMCCO(IPIFBCIMHMP, JCJDPGMKJAJ, null);
											return savereq;
										}, e, BHFHGFKBOHH, MOBEEPPKFLG));
										return true;
									}
								}
							}
						}
						//LAB_01000bc8
					}
					else
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 2003));
						return true;
					}
				}
				else
				{
					N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 2002));
					return true;
				}
			}
		}
		//LAB_01000bc8
		if (BHFHGFKBOHH != null)
			BHFHGFKBOHH();
		return true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7E28 Offset: 0x6B7E28 VA: 0x6B7E28
	// // RVA: 0x1000F50 Offset: 0x1000F50 VA: 0x1000F50
	private IEnumerator AIBLBMDILLG_Coroutine_SaveWithAchievement(MOMPDFMMICK_ClaimAchievementPrizesAndSave COJNCNGHIJC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		//0x1077E90
		yield return COJNCNGHIJC.GDPDELLNOBO_WaitDone(N.a);
		if(COJNCNGHIJC.NPNNPNAIONN_IsError)
		{
			if (MOBEEPPKFLG != null)
				MOBEEPPKFLG();
		}
		else
		{
			AHEFHIMGIBI_ServerSave.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF_Names);
			CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF_Names);
			FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
			ECFNAOCFKKN = COJNCNGHIJC.NFEAMMJIMPG.IFNLEKOILPM_UpdatedAt;
			HLBJOJBALIG(COJNCNGHIJC.HHIHCJKLJFF_Names);
			KPFKKDDOHCN.ECFNAOCFKKN_Date = 0;
			NKGJPJPHLIF.HHCJCDFCLOB.OLDKENOLHLL = 0;
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		}
		KONHMOLMOCI_IsSaving = false;
	}

	// // RVA: 0x1001024 Offset: 0x1001024 VA: 0x1001024
	public void PKKCKFCLACK(GJDFHLBONOL OKGGJOOCLHI, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK JEMKODBAOEP, DJBHIFLHJLK MOBEEPPKFLG)
	{
		List<GJDFHLBONOL> res = new List<GJDFHLBONOL>();
		res.Add(OKGGJOOCLHI);
		PKKCKFCLACK(res, BHFHGFKBOHH, JEMKODBAOEP, MOBEEPPKFLG, true);
	}

	// // RVA: 0x1001104 Offset: 0x1001104 VA: 0x1001104
	public void PKKCKFCLACK(List<GJDFHLBONOL> PJJFEAHIPGL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK JEMKODBAOEP, DJBHIFLHJLK MOBEEPPKFLG, bool MBJKHOOMAFE = false)
	{
		JANMJPOKLFL.JCHLONCMPAJ();
		JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.ICAPJDDJIEA_6, "");
		JANMJPOKLFL.OMGJFMMJPJD = MBJKHOOMAFE;
		KONHMOLMOCI_IsSaving = true;
		if(CNGFKOJANNP.HHCJCDFCLOB.AKPCMLEPPGC_IsInvalid)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 3001));
		}
		else
		{
			IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
			if (IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP == 0)
			{
				if(!BLCDJDJJBHC)
				{
					FENCAJJBLBH falsif = AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(true);
					if (falsif == null)
					{
						N.a.StartCoroutineWatched(PBCOEDMBDBE_Coroutine_ReceiveInventory(PJJFEAHIPGL, BHFHGFKBOHH, JEMKODBAOEP, MOBEEPPKFLG));
					}
					else
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(falsif, MOBEEPPKFLG, 3003));
					}
				}
				else
					N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 3003));
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 3002));
			}
		}
	}

	// // RVA: 0x1001458 Offset: 0x1001458 VA: 0x1001458
	private List<GJDFHLBONOL> FJPIIDAEMHC_FilterByType(List<GJDFHLBONOL> GPBJHKLFCEP, int INDDJNMPONH)
	{
		List<GJDFHLBONOL> res = new List<GJDFHLBONOL>(GPBJHKLFCEP.Count);
		for(int i = 0; i < GPBJHKLFCEP.Count; i++)
		{
			if(GPBJHKLFCEP[i].MJBKGOJBPAD_ItemType == INDDJNMPONH)
			{
				res.Add(GPBJHKLFCEP[i]);
			}
		}
		return res;
	}

	// // RVA: 0x1001608 Offset: 0x1001608 VA: 0x1001608
	private bool OBOHGFNECBG_HasExpiredItems(List<GJDFHLBONOL> PJJFEAHIPGL, long JHNMKKNEENE = 0)
	{
		if (JHNMKKNEENE == 0)
			JHNMKKNEENE = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		for (int i = 0; i < PJJFEAHIPGL.Count; i++)
		{
			if (PJJFEAHIPGL[i].EGBOHDFBAPB_ClosedAt < JHNMKKNEENE)
				return true;
		}
		return false;
	}

	// // RVA: 0x100179C Offset: 0x100179C VA: 0x100179C
	public bool HFCOBGMDOGG()
	{
		return GPOGFJFGNCA;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7EA0 Offset: 0x6B7EA0 VA: 0x6B7EA0
	// // RVA: 0x100136C Offset: 0x100136C VA: 0x100136C
	private IEnumerator PBCOEDMBDBE_Coroutine_ReceiveInventory(List<GJDFHLBONOL> PJJFEAHIPGL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK JEMKODBAOEP, DJBHIFLHJLK MOBEEPPKFLG)
	{
		bool HOEJANILKOG; // 0x28
		DOLDMCAMEOD_RequestRemainingForCurrencyIds DLOIHKKKNBB; // 0x2C

		//0x1075F2C
		if (OBOHGFNECBG_HasExpiredItems(PJJFEAHIPGL, 0))
		{
			JHHBAFKMBDL.HHCJCDFCLOB.ACJOEBNHBMF_DisplayExpiredPopup(() =>
			{
				//0x100A68C
				KONHMOLMOCI_IsSaving = false;
				if (MOBEEPPKFLG != null)
					MOBEEPPKFLG();
			}, JANMJPOKLFL.OMGJFMMJPJD);
		}
		else
		{
			JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
			List<GJDFHLBONOL> l = FJPIIDAEMHC_FilterByType(PJJFEAHIPGL, 0);
			bool b = false;
			if (KAJNAMKKKBN(l) == 1)
			{
				List<GJDFHLBONOL> l2 = FJPIIDAEMHC_FilterByType(PJJFEAHIPGL, 1);
				if (l2.Count != 0)
				{
					CIJGKKBOGPB(FJPIIDAEMHC_FilterByType(l2, 1));
					//LAB_01076134
					b = true;
				}
				else
				{
					JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
					KONHMOLMOCI_IsSaving = false;
					if (JEMKODBAOEP != null)
						JEMKODBAOEP();
					yield break;
				}
			}
			else
			{
				//LAB_01076108;
				while (!NFLGAPBIGAD)
					yield return null;
				if (NEPILJAJFCC)
				{
					CIJGKKBOGPB(FJPIIDAEMHC_FilterByType(PJJFEAHIPGL, 1));
					b = true;
				}
			}
			if(b)
			{
				//LAB_01076134
				HOEJANILKOG = false;
				//LAB_01076170;
				while (!NFLGAPBIGAD)
					yield return null;
				if(NEPILJAJFCC)
				{
					if(HOEJANILKOG)
					{
						DLOIHKKKNBB = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
						DLOIHKKKNBB.CGCFENMHJIM_Ids = NFGNKHONICJ();
						yield return DLOIHKKKNBB.GDPDELLNOBO_WaitDone(N.a);
						if(DLOIHKKKNBB.NPNNPNAIONN_IsError)
						{
							JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
							if (MOBEEPPKFLG != null)
								MOBEEPPKFLG();
							KONHMOLMOCI_IsSaving = false;
							yield break;
						}
						BBEPLKNMICJ_Currencies.Clear();
						DJICHKCLMCD_UpdateCurrencies(DLOIHKKKNBB.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
						DLOIHKKKNBB = null;
					}
					//break
					JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
					bool LBIMNONOOPG = false;
					KPFKKDDOHCN.ICEKFOCHJPI(() =>
					{
						//0x100A6CC
						LBIMNONOOPG = true;
					}, (CACGCMBKHDI_Request ONOPACPKFPK) =>
					{
						//0x100A6D8
						LBIMNONOOPG = true;
					});
					//LAB_0107660c
					while (!LBIMNONOOPG)
						yield return null;
					if(!NEPILJAJFCC)
					{
						KONHMOLMOCI_IsSaving = false;
						if (MOBEEPPKFLG != null)
							MOBEEPPKFLG();
					}
					else
					{
						KPFKKDDOHCN.ECFNAOCFKKN_Date = 0;
						NKGJPJPHLIF.HHCJCDFCLOB.OLDKENOLHLL = 0;
						KONHMOLMOCI_IsSaving = false;
						if (BHFHGFKBOHH != null)
							BHFHGFKBOHH();
					}
					yield break;
				}
				//LAB_01076384;
			}
			//LAB_01076384
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
			KONHMOLMOCI_IsSaving = false;
			if (MOBEEPPKFLG != null)
				MOBEEPPKFLG();
			// end
		}
	}

	// // RVA: 0x10017A4 Offset: 0x10017A4 VA: 0x10017A4
	public int KAJNAMKKKBN(List<GJDFHLBONOL> PJJFEAHIPGL)
	{
		GPOGFJFGNCA = false;
		NEPILJAJFCC = false;
		NFLGAPBIGAD = false;
		if(PJJFEAHIPGL.Count == 0)
		{
			NEPILJAJFCC = true;
			NFLGAPBIGAD = true;
			return 0;
		}
		CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
		ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.PBKOKCHKGGL_46, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CCNKAKCBBDJ, 2, false);
		List<long> l = new List<long>(PJJFEAHIPGL.Count);
		for(int i = 0; i < PJJFEAHIPGL.Count; i++)
		{
			if(!JANMJPOKLFL.HMDCGPGGOBA_IsAddItemOverflow(CCNKAKCBBDJ, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(PJJFEAHIPGL[i].JJBGOIMEIPF_ItemFullId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(PJJFEAHIPGL[i].JJBGOIMEIPF_ItemFullId), PJJFEAHIPGL[i].MBJIFDBEDAC_ItemCount))
			{
				JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.ICAPJDDJIEA_6, PJJFEAHIPGL[i].INDDJNMPONH_Type.ToString());
				JANMJPOKLFL.CPIICACGNBH_AddItem(CCNKAKCBBDJ, PJJFEAHIPGL[i].JJBGOIMEIPF_ItemFullId, PJJFEAHIPGL[i].MBJIFDBEDAC_ItemCount, null, 0);
				l.Add(PJJFEAHIPGL[i].MDPJFPHOPCH_Id);
			}
			else
			{
				GPOGFJFGNCA = true;
			}
		}
		if(l.Count != 0)
		{
			BBHNACPENDM_ServerSaveData.EMHDCKMFCGE diff = FMFKHDPKLOC.LEMFJICBALP(CCNKAKCBBDJ, true);
			KONHMOLMOCI_IsSaving = true;
			GGKHIHFPKDH_SavePlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
			req.DOMFHDPMCCO(diff, l);
			req.BHFHGFKBOHH_OnSuccess = GDHOKEOHABL;
			req.MOBEEPPKFLG_OnFail = GOPADPOIKNP;
			return 0;
		}
		return 1;
	}

	// // RVA: 0x1001E5C Offset: 0x1001E5C VA: 0x1001E5C
	private void GDHOKEOHABL(CACGCMBKHDI_Request KFBCOGJKEJP)
	{
		GGKHIHFPKDH_SavePlayerData r = KFBCOGJKEJP as GGKHIHFPKDH_SavePlayerData;
		FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
		AHEFHIMGIBI_ServerSave.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
		KPFKKDDOHCN.POMPFPJOMNN(r.AMOMNBEAHBF_InventoryIds);
		KPFKKDDOHCN.OEJMJDNIGJD();
		NEPILJAJFCC = true;
		NFLGAPBIGAD = true;
	}

	// // RVA: 0x1001FF8 Offset: 0x1001FF8 VA: 0x1001FF8
	private bool CIJGKKBOGPB(List<GJDFHLBONOL> PJJFEAHIPGL)
	{
		NEPILJAJFCC = false;
		NFLGAPBIGAD = false;
		if (PJJFEAHIPGL.Count != 0)
		{
			Dictionary<int, int> d = new Dictionary<int, int>();
			List<long> l = new List<long>(PJJFEAHIPGL.Count);
			for (int i = 0; i < PJJFEAHIPGL.Count; i++)
			{
				l.Add(PJJFEAHIPGL[i].MDPJFPHOPCH_Id);
			}
			if(l.Count != 0)
			{
				KONHMOLMOCI_IsSaving = true;
				MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory());
				req.AMOMNBEAHBF_Ids = l;
				req.BHFHGFKBOHH_OnSuccess = HKMNAICEDNE_OnSuccessReceiveInventory_VC;
				req.MOBEEPPKFLG_OnFail = GOPADPOIKNP;
				return true;
			}
		}
		NEPILJAJFCC = true;
		NFLGAPBIGAD = true;
		return true;
	}

	// // RVA: 0x1002388 Offset: 0x1002388 VA: 0x1002388
	private void HKMNAICEDNE_OnSuccessReceiveInventory_VC(CACGCMBKHDI_Request KFBCOGJKEJP)
	{
		MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory req = KFBCOGJKEJP as MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory;
		DJICHKCLMCD_UpdateCurrencies(req.NFEAMMJIMPG.BBEPLKNMICJ_Balances);
		ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.PBKOKCHKGGL_46, 2, false);
		KPFKKDDOHCN.PBBEPILMAHO(req.AMOMNBEAHBF_Ids, (GJDFHLBONOL AIMLPJOGPID) =>
		{
			//0x1009434
			JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.ICAPJDDJIEA_6, AIMLPJOGPID.INDDJNMPONH_Type.ToString());
			JANMJPOKLFL.CPIICACGNBH_AddItem(CCNKAKCBBDJ, AIMLPJOGPID.JJBGOIMEIPF_ItemFullId, AIMLPJOGPID.MBJIFDBEDAC_ItemCount, null, 0);
		});
		KPFKKDDOHCN.POMPFPJOMNN(req.AMOMNBEAHBF_Ids);
		KPFKKDDOHCN.OEJMJDNIGJD();
		NEPILJAJFCC = true;
		NFLGAPBIGAD = true;
	}

	// // RVA: 0x10025B4 Offset: 0x10025B4 VA: 0x10025B4
	private void GOPADPOIKNP(CACGCMBKHDI_Request KFBCOGJKEJP)
	{
		NFLGAPBIGAD = true;
	}

	// // RVA: 0x10025C0 Offset: 0x10025C0 VA: 0x10025C0
	public string PDLEOKCJDAK()
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		if(JANMJPOKLFL.OMGJFMMJPJD)
		{
			if(JANMJPOKLFL.EPPFEAIMFOE_ItemCount == 1)
			{
				return string.Format(bk.GetMessageByLabel("pbox_text_03"), JANMJPOKLFL.OLAICLNDMFF());
			}
		}
		if(!JANMJPOKLFL.OMGJFMMJPJD)
		{
			if(JANMJPOKLFL.EPPFEAIMFOE_ItemCount > 0)
			{
				if(!GPOGFJFGNCA)
				{
					return Smart.Format(bk.GetMessageByLabel("pbox_text_08"), JANMJPOKLFL.EPPFEAIMFOE_ItemCount);
				}
				return bk.GetMessageByLabel("pbox_text_07");
			}
		}
		if (!JANMJPOKLFL.OMGJFMMJPJD)
			return bk.GetMessageByLabel("pbox_text_07");
		else
			return bk.GetMessageByLabel("pbox_text_02");
	}

	// // RVA: 0x1002848 Offset: 0x1002848 VA: 0x1002848
	public void OIEBCNPOMIB_UpdateDayChange(bool FBBNPFFEJBN_Force)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		FEAOOBFHMBL.DOMFHDPMCCO_CheckDailyQuest(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, AHEFHIMGIBI_ServerSave, time, FBBNPFFEJBN_Force);
		if(AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter != null)
		{
			AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_Day.FHPENOLOPKI_CheckEndOfDay(time, FBBNPFFEJBN_Force);
		}
	}

	// // RVA: 0x1002A38 Offset: 0x1002A38 VA: 0x1002A38
	public void OFGCPFFPGHE(bool FBBNPFFEJBN)
	{
		NKOBMDPHNGP_EventRaidLobby lobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_EventRaidLobby;
		if(lobby != null)
		{
			lobby.KLEEKOAFIIK(FBBNPFFEJBN);
		}
	}

	// // RVA: 0x1002B48 Offset: 0x1002B48 VA: 0x1002B48
	public void MIPMDKBKKJD_UpdateStaminaInfo()
	{
		if(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common != null)
		{
			JJOPEDJCCJK_Exp dbExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp;
			int staminaGain = 30;
			if(dbExp != null)
			{
				staminaGain = dbExp.HPEOBAEGHKC_GetStaminaGainForLevel(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level);
			}
			BPLOEAHOPFI_StaminaUpdater.DCBENCMNOGO_MaxStamina = staminaGain;
			BPLOEAHOPFI_StaminaUpdater.NEPIPMPAFIE_Stamina = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCFPEJODJPP_Stamina;
			BPLOEAHOPFI_StaminaUpdater.DLPEEDCCNMJ_StaminaSaveTime = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.FOKNAMPDPFP_StaminaSaveTime;
			BPLOEAHOPFI_StaminaUpdater.FLJGHBLEDDB_HealSec = 300;
			if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System != null)
				{
					BPLOEAHOPFI_StaminaUpdater.FLJGHBLEDDB_HealSec = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.PFNBMPCIIJJ_HealSec;
				}
			}
		}
	}

	// // RVA: 0x1002F1C Offset: 0x1002F1C VA: 0x1002F1C
	public void FMIPEACLBKL()
	{
		AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCFPEJODJPP_Stamina = BPLOEAHOPFI_StaminaUpdater.NEPIPMPAFIE_Stamina;
		AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.FOKNAMPDPFP_StaminaSaveTime = BPLOEAHOPFI_StaminaUpdater.DLPEEDCCNMJ_StaminaSaveTime;
	}

	// // RVA: 0x1003010 Offset: 0x1003010 VA: 0x1003010
	public void GIFFIGPKOFE_AddStamina(int POKDILOKODG_Stamina)
	{
		BPLOEAHOPFI_StaminaUpdater.GFOAJNICANO(POKDILOKODG_Stamina);
		FMIPEACLBKL();
	}

	// // RVA: 0x1003050 Offset: 0x1003050 VA: 0x1003050
	public void GNNHEDHCJAE(EKLNMHFCAOI.FKGCBLHOOCL_Category INDDJNMPONH, int EIDOGCOPHII, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK MOBEEPPKFLG, string JKJDGDLAIME = "")
	{
		CJBHFDHBHEP(LKBJIGBNIAD.JOHJEOPEOBA_0, INDDJNMPONH, EIDOGCOPHII, BHFHGFKBOHH, HDFGHFOCHKE, BLPGAGLCBPK, MOBEEPPKFLG, JKJDGDLAIME, 0);
	}

	// // RVA: 0x100336C Offset: 0x100336C VA: 0x100336C
	// public void DNJKDCIAHMO(EKLNMHFCAOI.FKGCBLHOOCL INDDJNMPONH, int EIDOGCOPHII, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK MOBEEPPKFLG, string JKJDGDLAIME = "", CIOECGOMILE.LIILJGHKIDL AAIOPEICNNB = 0) { }

	// // RVA: 0x100309C Offset: 0x100309C VA: 0x100309C
	private void CJBHFDHBHEP(LKBJIGBNIAD NNCGBLONBMB, EKLNMHFCAOI.FKGCBLHOOCL_Category INDDJNMPONH, int EIDOGCOPHII, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK MOBEEPPKFLG, string JKJDGDLAIME = "", LIILJGHKIDL AAIOPEICNNB = 0)
	{
		if(CNGFKOJANNP.HHCJCDFCLOB.AKPCMLEPPGC_IsInvalid)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 4001));
		}
		else
		{
			IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
			if(IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP != 0)
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 4002));
			}
			else
			{
				if(BLCDJDJJBHC)
				{
					N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 4003));
				}
				else
				{
					FENCAJJBLBH f = AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(true);
					if(f != null)
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(f, MOBEEPPKFLG, 4004));
					}
					else
					{
						if(INDDJNMPONH == EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem || INDDJNMPONH == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
						{
							KONHMOLMOCI_IsSaving = true;
							N.a.StartCoroutineWatched(GBKDCGBHLCD_Coroutine_StaminaHeal_FreeVC(NNCGBLONBMB, INDDJNMPONH, EIDOGCOPHII, BHFHGFKBOHH, HDFGHFOCHKE, BLPGAGLCBPK, MOBEEPPKFLG, JKJDGDLAIME, AAIOPEICNNB));
						}
						else if(INDDJNMPONH == EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
						{
							KONHMOLMOCI_IsSaving = true;
							N.a.StartCoroutineWatched(IGOJFNIDAEE_Coroutine_StaminaHeal_PaidVC(NNCGBLONBMB, BHFHGFKBOHH, HDFGHFOCHKE, BLPGAGLCBPK, MOBEEPPKFLG, JKJDGDLAIME, AAIOPEICNNB));
						}
					}
				}
			}
		}
	}

	// // RVA: 0x1003670 Offset: 0x1003670 VA: 0x1003670
	private int BOHEFPHNODA(EKLNMHFCAOI.FKGCBLHOOCL_Category INDDJNMPONH, int KIJAPOFAGPN)
	{
		if(INDDJNMPONH != EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
			return KIJAPOFAGPN;
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN);
		JKDKODAPGBJ_EnergyItem.GFGCCICHBHK it = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA[id - 1];
		if(it.JBGEEPFKIGG_HealValue == 0)
		{
			return BPLOEAHOPFI_StaminaUpdater.DCBENCMNOGO_MaxStamina;
		}
		return it.JBGEEPFKIGG_HealValue;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7F18 Offset: 0x6B7F18 VA: 0x6B7F18
	// // RVA: 0x10034FC Offset: 0x10034FC VA: 0x10034FC
	private IEnumerator GBKDCGBHLCD_Coroutine_StaminaHeal_FreeVC(LKBJIGBNIAD NNCGBLONBMB, EKLNMHFCAOI.FKGCBLHOOCL_Category INDDJNMPONH, int EIDOGCOPHII, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK MOBEEPPKFLG, string JKJDGDLAIME, LIILJGHKIDL AAIOPEICNNB)
	{
		//0x107828C
		yield return null;
		if(INDDJNMPONH == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
		{
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(EIDOGCOPHII);
			if(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[id - 1].BFINGCJHOHI_Cnt == 0)
			{
				if(HDFGHFOCHKE != null)
					HDFGHFOCHKE();
				KONHMOLMOCI_IsSaving = false;
				yield break;
			}
		}
		else if(INDDJNMPONH == EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
		{
            NKOBMDPHNGP_EventRaidLobby ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_EventRaidLobby;
			if(ev != null)
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
			}
        }
		MCGNOFMAPBJ GCLOCOHFEEJ = null;
		int HGKJCJAMDGK = 0;
		if(NNCGBLONBMB == LKBJIGBNIAD.JOHJEOPEOBA_0)
		{
			GCLOCOHFEEJ = new MCGNOFMAPBJ();
			GCLOCOHFEEJ.ODDIHGPONFL(BPLOEAHOPFI_StaminaUpdater);
			HGKJCJAMDGK = BOHEFPHNODA(INDDJNMPONH, EIDOGCOPHII);
			bool a1 = GCLOCOHFEEJ.MAPPOEFALIP(HGKJCJAMDGK, true, false);
			if(!a1)
			{
				if(BLPGAGLCBPK != null)
					BLPGAGLCBPK();
				KONHMOLMOCI_IsSaving = false;
				yield break;
			}
			AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCFPEJODJPP_Stamina = GCLOCOHFEEJ.NEPIPMPAFIE_Stamina;
			AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.FOKNAMPDPFP_StaminaSaveTime = GCLOCOHFEEJ.DLPEEDCCNMJ_StaminaSaveTime;
		}
		else if(NNCGBLONBMB == LKBJIGBNIAD.MHELGOODGCO_1_Raid)
		{
			//KAFHAKBBJEI GCLOCOHFEEJ = new KAFHAKBBJEI();
			PKNOKJNLPOE_EventRaid ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
		}
		if(INDDJNMPONH == EKLNMHFCAOI.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
		{
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(EIDOGCOPHII);
			TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
		}
		else if(INDDJNMPONH == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
		{
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(EIDOGCOPHII);
			EGOLBAPFHHD_Common.FKLHGOGJOHH it = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[id - 1];
			it.BFINGCJHOHI_Cnt--;
			if(it.BFINGCJHOHI_Cnt < 0)
				it.BFINGCJHOHI_Cnt = 0;
		}
		AHEFHIMGIBI_ServerSave.IPLNOMCCNBI_UpdatePublicStatus();
		BBHNACPENDM_ServerSaveData.EMHDCKMFCGE data = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_ServerSave, true);
		if(data == null || data.LHIACHALIFC_IsEmpty())
		{
			if(MOBEEPPKFLG != null)
				MOBEEPPKFLG();
		}
		else
		{
			CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
			GGKHIHFPKDH_SavePlayerData COJNCNGHIJC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
			COJNCNGHIJC.GJAEJFLLKGC_RetryTime = 1;
			COJNCNGHIJC.DOMFHDPMCCO(data, null);
			COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x100A6EC
				AHEFHIMGIBI_ServerSave.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF_Names);
				CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF_Names);
				FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
				ECFNAOCFKKN = COJNCNGHIJC.NFEAMMJIMPG.IFNLEKOILPM_UpdatedAt;
				if(NNCGBLONBMB == LKBJIGBNIAD.MHELGOODGCO_1_Raid)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
				}
				else if(NNCGBLONBMB == LKBJIGBNIAD.JOHJEOPEOBA_0)
				{
					BPLOEAHOPFI_StaminaUpdater.ODDIHGPONFL(GCLOCOHFEEJ);
				}
				HLBJOJBALIG(COJNCNGHIJC.HHIHCJKLJFF_Names);
				if(NNCGBLONBMB == LKBJIGBNIAD.MHELGOODGCO_1_Raid)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
				}
				else if(NNCGBLONBMB == LKBJIGBNIAD.JOHJEOPEOBA_0)
				{
					int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(EIDOGCOPHII);
					ILCCJNDFFOB.HHCJCDFCLOB.FLBCPKHGLPE(HGKJCJAMDGK, GCLOCOHFEEJ.DCLKMNGMIKC_GetCurrent(), id, 1, JKJDGDLAIME);
				}
				KONHMOLMOCI_IsSaving = false;
				if(BHFHGFKBOHH != null)
					BHFHGFKBOHH();
			};
			COJNCNGHIJC.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x100AB10
				if(MOBEEPPKFLG != null)
					MOBEEPPKFLG();
				KONHMOLMOCI_IsSaving = false;
			};
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7F90 Offset: 0x6B7F90 VA: 0x6B7F90
	// // RVA: 0x10033BC Offset: 0x10033BC VA: 0x10033BC
	private IEnumerator IGOJFNIDAEE_Coroutine_StaminaHeal_PaidVC(LKBJIGBNIAD NNCGBLONBMB, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK MOBEEPPKFLG, string JKJDGDLAIME, CIOECGOMILE.LIILJGHKIDL AAIOPEICNNB)
	{
		PJKLMCGEJMK OKDOIAEGADK; // 0x34
		DOLDMCAMEOD_RequestRemainingForCurrencyIds PMNKDBLBFHM; // 0x38

		//0x1079454
		yield return null;
		OKDOIAEGADK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		PMNKDBLBFHM = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
		PMNKDBLBFHM.CGCFENMHJIM_Ids = NFGNKHONICJ();
		yield return PMNKDBLBFHM.GDPDELLNOBO_WaitDone(N.a);
		if(PMNKDBLBFHM.NPNNPNAIONN_IsError)
		{
			if(MOBEEPPKFLG != null)
				MOBEEPPKFLG();
		}
		else
		{
			DJICHKCLMCD_UpdateCurrencies(PMNKDBLBFHM.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
			int currency = DEAPMEIDCGC_GetTotalPaidCurrency();
			MCGNOFMAPBJ GCLOCOHFEEJ = null;
			int HGKJCJAMDGK_Max = 0;
			PKNOKJNLPOE_EventRaid FBFNJMKPBBA = null;
			int AFKAGFOFAHM = 0;
			bool needSave = false;
			if(NNCGBLONBMB == LKBJIGBNIAD.JOHJEOPEOBA_0)
			{
				GCLOCOHFEEJ = new MCGNOFMAPBJ();
				AFKAGFOFAHM = FFAGOLDAHHN_EnergyProdId;
				if(currency < KMJLGBJBOAK_StaminaRefillCost)
				{
					//LAB_01079c28
					if(HDFGHFOCHKE != null)
						HDFGHFOCHKE();
				}
				else
				{
					GCLOCOHFEEJ.ODDIHGPONFL(BPLOEAHOPFI_StaminaUpdater);
					HGKJCJAMDGK_Max = GCLOCOHFEEJ.DCBENCMNOGO_MaxStamina;
					if(GCLOCOHFEEJ.FCEMLLDEJFL(true, false))
					{
						AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BCFPEJODJPP_Stamina = GCLOCOHFEEJ.NEPIPMPAFIE_Stamina;
						AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.FOKNAMPDPFP_StaminaSaveTime = GCLOCOHFEEJ.DLPEEDCCNMJ_StaminaSaveTime;
						//LAB_01079e14
						needSave = true;
					}
					else
					{
						//LAB_01079f48
						if(BLPGAGLCBPK != null)
							BLPGAGLCBPK();
					}
				}
			}
			else if(NNCGBLONBMB != LKBJIGBNIAD.MHELGOODGCO_1_Raid)
			{
				//LAB_01079e14
				needSave = true;
			}
			else
			{
				TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event Raid");
				// L. 531
			}
			if(needSave)
			{
				//LAB_01079e14
				AHEFHIMGIBI_ServerSave.IPLNOMCCNBI_UpdatePublicStatus();
				BBHNACPENDM_ServerSaveData.EMHDCKMFCGE d = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_ServerSave, true);
				if(d != null)
				{
					if(!d.LHIACHALIFC_IsEmpty())
					{
						for(int i = 0; i < d.KFGDPMNCCFO.Count; i++)
						{
							KLFDBFMNLBL_ServerSaveBlock block = CCNKAKCBBDJ.LBDOLHGDIEB_GetBlock(d.KFGDPMNCCFO[i]);
							FENCAJJBLBH f = block.PFAKPFKJJKA();
							if(f != null)
							{
								N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(f, MOBEEPPKFLG, 5001));
								yield break;
							}
						}
						CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
						FNPBAENIEPG_PurchaseAndSave COJNCNGHIJC = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new FNPBAENIEPG_PurchaseAndSave());
						COJNCNGHIJC.GJAEJFLLKGC_RetryTime = 1;
						COJNCNGHIJC.DOMFHDPMCCO(d, AFKAGFOFAHM, 1, 1001);
						COJNCNGHIJC.LGEKLPJFJEI_TotalCurrency = currency;
						COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x100AB58
							AHEFHIMGIBI_ServerSave.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF);
							CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF);
							FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
							ECFNAOCFKKN = COJNCNGHIJC.NFEAMMJIMPG.IFNLEKOILPM_UpdatedAt;
							if(NNCGBLONBMB == LKBJIGBNIAD.MHELGOODGCO_1_Raid)
							{
								//FBFNJMKPBBA.JIHGDCFBGCK(GCLOCOHFEEJ);
								TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
							}
							else if(NNCGBLONBMB == LKBJIGBNIAD.JOHJEOPEOBA_0)
							{
								BPLOEAHOPFI_StaminaUpdater.ODDIHGPONFL(GCLOCOHFEEJ);
							}
							HLBJOJBALIG(COJNCNGHIJC.HHIHCJKLJFF);
                            MCKCJMLOAFP_CurrencyInfo m = JBEKNFEGFFI();
							int p = m.BDLNMOIOMHK_Total;
							DJICHKCLMCD_UpdateCurrencies(COJNCNGHIJC.NFEAMMJIMPG.BBEPLKNMICJ_Balances);
							int p2 = JBEKNFEGFFI().BDLNMOIOMHK_Total;
							ILCCJNDFFOB.HHCJCDFCLOB.PMFGEJJDMCK(1, 1, JKJDGDLAIME, p - p2, 0);
							if(NNCGBLONBMB == LKBJIGBNIAD.MHELGOODGCO_1_Raid)
							{
								//L 185
								TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event raid");
							}
							else
							{
								ILCCJNDFFOB.HHCJCDFCLOB.FLBCPKHGLPE(HGKJCJAMDGK_Max, GCLOCOHFEEJ.DCLKMNGMIKC_GetCurrent(), 0, KMJLGBJBOAK_StaminaRefillCost, JKJDGDLAIME);
							}
							if(BHFHGFKBOHH != null)
								BHFHGFKBOHH();
							KONHMOLMOCI_IsSaving = false;
                        };
						COJNCNGHIJC.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x100B0E8
							if(MOBEEPPKFLG != null)
								MOBEEPPKFLG();
							KONHMOLMOCI_IsSaving = false;
						};
						yield break;
					}
				}
				if(MOBEEPPKFLG != null)
				{
					MOBEEPPKFLG();
				}
				yield break;
			}
		}
		//LAB_01079f5c
		KONHMOLMOCI_IsSaving = false;
	}

	// // RVA: 0x1003830 Offset: 0x1003830 VA: 0x1003830
	public void PCMPDIMCBJM_UpdateIntimacyInfo()
	{
		if(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common != null)
		{
			IOCLFHJLHLE_IntimacyUpdater.DCBENCMNOGO_MaxCount = 5;
			IOCLFHJLHLE_IntimacyUpdater.NEPIPMPAFIE_CntVal = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BGEGFMKGNHN_IntimacyCntVal;
			IOCLFHJLHLE_IntimacyUpdater.DLPEEDCCNMJ_CntSaveTime = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ANOCNJABDJO_IntimacyCntSaveTime;
			IOCLFHJLHLE_IntimacyUpdater.FLJGHBLEDDB_UpdateInterval = 3600;
			if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy != null)
				{
					CEBFFLDKAEC_SecureInt a = new CEBFFLDKAEC_SecureInt();
					int interval = 3600;
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OHJFBLFELNK_IntArray.TryGetValue("fscnt_heal_time", out a))
					{
						interval = a.DNJEJEANJGL_Value;
					}
					IOCLFHJLHLE_IntimacyUpdater.FLJGHBLEDDB_UpdateInterval = interval;
					if (IOCLFHJLHLE_IntimacyUpdater.FLJGHBLEDDB_UpdateInterval == 0)
						IOCLFHJLHLE_IntimacyUpdater.FLJGHBLEDDB_UpdateInterval = 1;
				}
			}
		}
	}

	// // RVA: 0x1003BE8 Offset: 0x1003BE8 VA: 0x1003BE8
	public void MJNHMCABCGH()
	{
		AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BGEGFMKGNHN_IntimacyCntVal = IOCLFHJLHLE_IntimacyUpdater.NEPIPMPAFIE_CntVal;
		AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.ANOCNJABDJO_IntimacyCntSaveTime = IOCLFHJLHLE_IntimacyUpdater.DLPEEDCCNMJ_CntSaveTime;
	}

	// // RVA: 0x1003CDC Offset: 0x1003CDC VA: 0x1003CDC
	public void FAFAKNJLLIC_ResetIntimacyPresentLeft()
	{
		if(AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva != null)
		{
			int maxPresentCount = 1;
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NJGEDPHNIKC_IsPresentLimitEnabled())
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
				{
					if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy != null)
					{
						maxPresentCount = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NPKHLGBNOKO_GetMaxPresent();
					}
				}
			}
			for(int i = 0; i < 10; i++)
			{
				PAAMLFNPJGJ_IntimacyDivaPresentLeft[i] = maxPresentCount;
				AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].APKBMBKMPAB_IntimacyPresentCount = maxPresentCount;
			}
		}
	}

	// // RVA: 0x1003FB0 Offset: 0x1003FB0 VA: 0x1003FB0
	public void AMCJPIIFHCA()
	{
		DEKKMGAFJCG_Diva saveDivas = AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva;
		if(saveDivas != null)
		{
			for(int i = 0; i < 10; i++)
			{
				PAAMLFNPJGJ_IntimacyDivaPresentLeft[i] = saveDivas.NBIGLBMHEDC_DivaList[i].APKBMBKMPAB_IntimacyPresentCount;
			}
		}
	}

	// // RVA: 0x1004100 Offset: 0x1004100 VA: 0x1004100
	public bool MLEPCANKIIE(int AHHJLDLAPAN, int HMFFHLPNMPH)
	{
		if(AHHJLDLAPAN > 0)
		{
			if(AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva != null)
			{
				int a1 = PAAMLFNPJGJ_IntimacyDivaPresentLeft[AHHJLDLAPAN - 1] - HMFFHLPNMPH;
				if(a1 < 1)
					a1 = 0;
				PAAMLFNPJGJ_IntimacyDivaPresentLeft[AHHJLDLAPAN - 1] = a1;
				AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[AHHJLDLAPAN - 1].APKBMBKMPAB_IntimacyPresentCount = a1;
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x10042AC Offset: 0x10042AC VA: 0x10042AC
	public void CDIADEIOIHP_ResetIntimacyTouchCount()
	{
		if(AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva != null)
		{
			for(int i = 0; i < 10; i++)
			{
				EDGFGECLOHE_IntimacyDivaTouchCount[i] = 0;
				AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].NFDPLBOIDAB_IntimacyTouchCount = 0;
			}
		}
	}

	// // RVA: 0x1004400 Offset: 0x1004400 VA: 0x1004400
	public void HLACGFNICAI_UpdateIntimacyTensionInfo()
	{
		if (AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common == null)
			return;
		JNCBOBPPHHB_IntimacyTensionTime = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.FGDNHEABLBN_IntimacyTensionSaveTime;
	}

	// // RVA: 0x100447C Offset: 0x100447C VA: 0x100447C
	public bool MAEKFHENDAA()
	{
		if(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			JNCBOBPPHHB_IntimacyTensionTime = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.FGDNHEABLBN_IntimacyTensionSaveTime;
			if(time >= JNCBOBPPHHB_IntimacyTensionTime || (time + 10800) < JNCBOBPPHHB_IntimacyTensionTime ||
				JNCBOBPPHHB_IntimacyTensionTime == 0)
			{
				JNCBOBPPHHB_IntimacyTensionTime = time + 10800 /*% ??*/;
				AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.FGDNHEABLBN_IntimacyTensionSaveTime = JNCBOBPPHHB_IntimacyTensionTime;
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x1004694 Offset: 0x1004694 VA: 0x1004694
	// public void LEIPBJNLOEJ() { }

	// // RVA: 0x1004700 Offset: 0x1004700 VA: 0x1004700
	public void DLFDPCDKHOB(LOBDIAABMKG EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM_SummonType BJLONGBNPCI, CDOPFBOHDEF BHFHGFKBOHH, DJBHIFLHJLK HDFGHFOCHKE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		GPOGFJFGNCA = false;
		JANMJPOKLFL.JCHLONCMPAJ();
		if(CNGFKOJANNP.HHCJCDFCLOB.AKPCMLEPPGC_IsInvalid)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, JGKOLBLPMPG, 6001));
			return;
		}
		IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
		if (IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP != 0)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, JGKOLBLPMPG, 6002));
			return;
		}
		if(BLCDJDJJBHC)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, JGKOLBLPMPG, 6003));
			return;
		}
		FENCAJJBLBH f = AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(true);
		if(f != null)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(f, JGKOLBLPMPG, 6004));
			return;
		}
		bool canRequest = false;
		if(BJLONGBNPCI == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.OBLEFFEJGIJ_8)
		{
			if(EPNFGKBBJCE.NECDFDNBHFK != null)
			{
				if(EPNFGKBBJCE.MEONHEGJNEF())
				{
					//LAB_01004af0
					JHHBAFKMBDL.HHCJCDFCLOB.HMIHFLGLHBA(JGKOLBLPMPG);
					return;
				}
				int DBNAGGGJDAB = EPNFGKBBJCE.NECDFDNBHFK.LKHAAGIJEPG_PlayerStatus.DBNAGGGJDAB_CurrentStepIndex;
				MMNNAPPLHFM m = EPNFGKBBJCE.NECDFDNBHFK.BMFEGOMNECF_Step.Find((MMNNAPPLHFM GHPLINIACBB) =>
				{
					//0x100B934
					return GHPLINIACBB.AGBCJMMMLON_StepIndex == DBNAGGGJDAB;
				});
				//LAB_01004cec
				if (DEAPMEIDCGC_GetTotalPaidCurrency() >= m.LCJPKJMMIAP_CurrencyAmmount)
				{
					canRequest = true;
				}
				else
				{
					//LAB_01004cf4
					HDFGHFOCHKE();
					return;
				}
			}
		}
		else
		{
			KBPDNHOKEKD_ProductId k = EPNFGKBBJCE.DBHIEABGKII_GetSummon(BJLONGBNPCI);
			if(k != null)
			{
				if(EPNFGKBBJCE.MEONHEGJNEF())
				{
					//LAB_01004af0
					JHHBAFKMBDL.HHCJCDFCLOB.HMIHFLGLHBA(JGKOLBLPMPG);
					return;
				}
				if(EPNFGKBBJCE.INDDJNMPONH_Category != GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
				{
					if(BJLONGBNPCI < GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AEFCOHJBLPO_11 && ((1 << (int)BJLONGBNPCI) & 0x660U) != 0) // 0110 0110 0000
					{
						//LAB_01004cec
						if (NBJOCMAJLPK_GetTotalCurrency(EPNFGKBBJCE.OMNAPCHLBHF(BJLONGBNPCI)) >= k.NPPGKNGIFGK_Price)
						{
							//LAB_01004d24
							canRequest = true;
						}
						else
						{
							HDFGHFOCHKE();
							return;
						}
					}
					else
					{
						if ((k.JENBPPBNAHP_PlayerNormalLotFreeState != null && k.JENBPPBNAHP_PlayerNormalLotFreeState.LDBPAJKIPKD_IsNextFree) ||
							DEAPMEIDCGC_GetTotalPaidCurrency() >= k.NPPGKNGIFGK_Price)
						{
							//LAB_01004d24
							canRequest = true;
						}
						else
						{
							//LAB_01004cf4
							HDFGHFOCHKE();
							return;
						}
					}
				}
			}
		}
		if (canRequest)
		{

			//LAB_01004d24
			IAPIDHGIEED OMOEKOCNICP = null;
			if (EPNFGKBBJCE.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8)
			{
				OMOEKOCNICP = new IAPIDHGIEED();
				OMOEKOCNICP.ODDIHGPONFL(EPNFGKBBJCE.NECDFDNBHFK.LKHAAGIJEPG_PlayerStatus);
			}
			KONHMOLMOCI_IsSaving = true;
			EPNFGKBBJCE.KIAIFPFBGJC(BJLONGBNPCI, (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x100B128
				if (NHECPMNKEFK is CBMFOOHOAOE_Purchase)
				{
					CBMFOOHOAOE_Purchase r = NHECPMNKEFK as CBMFOOHOAOE_Purchase;
					int prev = JBEKNFEGFFI().BDLNMOIOMHK_Total;
					DJICHKCLMCD_UpdateCurrencies(r.NFEAMMJIMPG.BBEPLKNMICJ_balances);
					int next = JBEKNFEGFFI().BDLNMOIOMHK_Total;
					ILCCJNDFFOB.HHCJCDFCLOB.PMFGEJJDMCK(EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId, 0, EPNFGKBBJCE.OPFGFINHFCE_Name, next - prev, 0);
					N.a.StartCoroutineWatched(GPDPDNJMDNJ_Coroutine_DrawLotByPaidVC_AfterSave(EPNFGKBBJCE, BJLONGBNPCI, r.NFEAMMJIMPG.PJJFEAHIPGL_inventories, BHFHGFKBOHH, JGKOLBLPMPG, null, null));
				}
				else if (NHECPMNKEFK is IHJEDAFEJHH_StepUpLotPurchase)
				{
					IHJEDAFEJHH_StepUpLotPurchase r = NHECPMNKEFK as IHJEDAFEJHH_StepUpLotPurchase;
					int prev = JBEKNFEGFFI().BDLNMOIOMHK_Total;
					DJICHKCLMCD_UpdateCurrencies(r.NFEAMMJIMPG.BBEPLKNMICJ_Balances);
					int next = JBEKNFEGFFI().BDLNMOIOMHK_Total;
					ILCCJNDFFOB.HHCJCDFCLOB.PMFGEJJDMCK(EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId, 0, EPNFGKBBJCE.OPFGFINHFCE_Name, next - prev, 0);
					List<ANGEDJODMKO> l = new List<ANGEDJODMKO>();
					for (int i = 0; i < r.NFEAMMJIMPG.PJJFEAHIPGL_Inventory.Count; i++)
					{
						for (int j = 0; j < r.NFEAMMJIMPG.PJJFEAHIPGL_Inventory[i].PJJFEAHIPGL.Count; j++)
						{
							ANGEDJODMKO data = new ANGEDJODMKO();
							data.ODDIHGPONFL(r.NFEAMMJIMPG.PJJFEAHIPGL_Inventory[i].PJJFEAHIPGL[j]);
							data.NCDPBLBDOCM_item_set_name = r.NFEAMMJIMPG.PJJFEAHIPGL_Inventory[i].LJNAKDMILMC;
							l.Add(data);
						}
					}
					N.a.StartCoroutineWatched(GPDPDNJMDNJ_Coroutine_DrawLotByPaidVC_AfterSave(EPNFGKBBJCE, BJLONGBNPCI, l, BHFHGFKBOHH, JGKOLBLPMPG, OMOEKOCNICP, r.NFEAMMJIMPG.LKHAAGIJEPG_PlayerStatus));
				}
			}, () =>
			{
				//0x100B89C
				HDFGHFOCHKE();
				KONHMOLMOCI_IsSaving = false;
			}, () =>
			{
				//0x100B8E8
				JGKOLBLPMPG();
				KONHMOLMOCI_IsSaving = false;
			});
		}
		else
		{
			JGKOLBLPMPG();
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8008 Offset: 0x6B8008 VA: 0x6B8008
	// // RVA: 0x1004EE8 Offset: 0x1004EE8 VA: 0x1004EE8
	private IEnumerator GPDPDNJMDNJ_Coroutine_DrawLotByPaidVC_AfterSave(LOBDIAABMKG EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM_SummonType BJLONGBNPCI, List<ANGEDJODMKO> DMOHAHJDPAD, CDOPFBOHDEF BHFHGFKBOHH, DJBHIFLHJLK JGKOLBLPMPG, IAPIDHGIEED OMOEKOCNICP, IAPIDHGIEED ONNIHHLHLDP)
	{
		//0x100ECB0
		yield return null;
		EPNFGKBBJCE.DBHIEABGKII_GetSummon(BJLONGBNPCI);
		KBPDNHOKEKD_ProductId MEANCEOIMGE = EPNFGKBBJCE.DBHIEABGKII_GetSummon(BJLONGBNPCI);
		List<long> l = new List<long>(10);
		List<MFDJIFIIPJD> BODJIDOHAHF = new List<MFDJIFIIPJD>(10);
		JANMJPOKLFL.JCHLONCMPAJ();
		JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.DOEHLCLBCNN_3, EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId.ToString());
		List<ANGEDJODMKO> l2 = LOBDIAABMKG.KECIGJBEHBG(DMOHAHJDPAD);
		if(EPNFGKBBJCE.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8)
		{
			MMNNAPPLHFM m = EPNFGKBBJCE.NECDFDNBHFK.BMFEGOMNECF_Step[OMOEKOCNICP.DBNAGGGJDAB_CurrentStepIndex];
			ILCCJNDFFOB.HHCJCDFCLOB.JNBKOAKJDAL(EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId, l2.Count, 1, m.LCJPKJMMIAP_CurrencyAmmount, l2, AHEFHIMGIBI_ServerSave, OMOEKOCNICP, ONNIHHLHLDP, null);
		}
		else if(MEANCEOIMGE != null)
		{
			ILCCJNDFFOB.HHCJCDFCLOB.JNBKOAKJDAL(EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId, l2.Count, EPNFGKBBJCE.OMNAPCHLBHF(BJLONGBNPCI) == 1001 ? 1 : 2, MEANCEOIMGE.NPPGKNGIFGK_Price, l2, AHEFHIMGIBI_ServerSave, OMOEKOCNICP, ONNIHHLHLDP, MEANCEOIMGE.JENBPPBNAHP_PlayerNormalLotFreeState);
		}
		JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
		JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
		bool b1 = false;
		for(int i = 0; i < l2.Count; i++)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(l2[i].JJBGOIMEIPF_ItemFullId);
			if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_Day.BFAJMALBALG_AddGacha(l2[i].MBJIFDBEDAC_ItemCount);
				JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.JLFJCIOOABC_32);
				b1 = true;
			}
			MFDJIFIIPJD m = new MFDJIFIIPJD();
			m.KHEKNNFCAOI(l2[i].HAAJGNCFNJM_ItemName, l2[i].OCNINMIMHGC_ItemValue, l2[i].MBJIFDBEDAC_ItemCount, 0);
			JANMJPOKLFL.OBCINIPHGGH = 0;
			JANMJPOKLFL.IKBLCEFCGDE = 0;
			JANMJPOKLFL.PJBJCBEMEEC = 0;
			if (!JANMJPOKLFL.HMDCGPGGOBA_IsAddItemOverflow(AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(l2[i].JJBGOIMEIPF_ItemFullId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(l2[i].JJBGOIMEIPF_ItemFullId), l2[i].MBJIFDBEDAC_ItemCount))
			{
				l.Add(l2[i].MDPJFPHOPCH_Id);
				JANMJPOKLFL.CPIICACGNBH_AddItem(AHEFHIMGIBI_ServerSave, l2[i].JJBGOIMEIPF_ItemFullId, l2[i].MBJIFDBEDAC_ItemCount, null, 0);
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = AHEFHIMGIBI_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[EKLNMHFCAOI.DEACAHNLMNI_getItemId(l2[i].JJBGOIMEIPF_ItemFullId) - 1];
					m.CJEOENICNOC = JANMJPOKLFL.OBCINIPHGGH;
					m.MJBODMOLOBC_SceneLuck = saveScene.MJBODMOLOBC_Luck;
					m.JPIPENJGGDD_SceneMlt = saveScene.JPIPENJGGDD_Mlt;
					m.LHMOAJAIJCO_New = saveScene.LHMOAJAIJCO_New;
				}
			}
			else
			{
				m.HMGCLKNLMAL = true;
				GPOGFJFGNCA = true;
			}
			BODJIDOHAHF.Add(m);
		}
		if(b1 && GNGMCIAIKMA.HHCJCDFCLOB != null)
		{
			GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.DOEHLCLBCNN_14, 0, 1, null);
			GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
		}
		AHEFHIMGIBI_ServerSave.IPLNOMCCNBI_UpdatePublicStatus();
		BBHNACPENDM_ServerSaveData.EMHDCKMFCGE diff = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_ServerSave, true);
		if(diff != null)
		{
			if(!diff.LHIACHALIFC_IsEmpty())
			{
				CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
				GGKHIHFPKDH_SavePlayerData COJNCNGHIJC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
				COJNCNGHIJC.GJAEJFLLKGC_RetryTime = 1;
				COJNCNGHIJC.DOMFHDPMCCO(diff, l);
				COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x100B980
					JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
					GGKHIHFPKDH_SavePlayerData r = NHECPMNKEFK as GGKHIHFPKDH_SavePlayerData;
					AHEFHIMGIBI_ServerSave.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF_Names);
					CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF_Names);
					FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
					DJICHKCLMCD_UpdateCurrencies(COJNCNGHIJC.NFEAMMJIMPG.BBEPLKNMICJ);
					ECFNAOCFKKN = COJNCNGHIJC.NFEAMMJIMPG.IFNLEKOILPM_UpdatedAt;
					HLBJOJBALIG(r.HHIHCJKLJFF_Names);
					if(MEANCEOIMGE != null && MEANCEOIMGE.HMFDJHEEGNN_BuyLimit > 0)
					{
						MEANCEOIMGE.GIEBJDKLCDH_BoughtQuantity++;
						if (MEANCEOIMGE.HMFDJHEEGNN_BuyLimit <= MEANCEOIMGE.GIEBJDKLCDH_BoughtQuantity)
							MEANCEOIMGE.GIEBJDKLCDH_BoughtQuantity = MEANCEOIMGE.HMFDJHEEGNN_BuyLimit;
					}
					BHFHGFKBOHH(BODJIDOHAHF);
					KONHMOLMOCI_IsSaving = false;
				};
				COJNCNGHIJC.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x100BD34
					JDDGPJDKHNE.HHCJCDFCLOB.FOKEGEOKGDG();
					JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
					KONHMOLMOCI_IsSaving = false;
					JGKOLBLPMPG();
				};
				yield break;
			}
		}
		JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
		if(JGKOLBLPMPG != null)
			JGKOLBLPMPG();
		KONHMOLMOCI_IsSaving = false;
	}

	// // RVA: 0x1005050 Offset: 0x1005050 VA: 0x1005050
	public void JBOAMLIDAKF(LOBDIAABMKG EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM_SummonType BJLONGBNPCI, CDOPFBOHDEF BHFHGFKBOHH, DJBHIFLHJLK HDFGHFOCHKE, DJBHIFLHJLK JGKOLBLPMPG, bool IAHLNPMFJMH = false)
	{
		GPOGFJFGNCA = false;
		JANMJPOKLFL.JCHLONCMPAJ();
		if(!CNGFKOJANNP.HHCJCDFCLOB.AKPCMLEPPGC_IsInvalid)
		{
			IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
			if (IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP == 0)
			{
				if(!BLCDJDJJBHC)
				{
					FENCAJJBLBH f = AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(true);
					if(f == null)
					{
						KBPDNHOKEKD_ProductId k = EPNFGKBBJCE.DBHIEABGKII_GetSummon(BJLONGBNPCI);
						if (k == null)
						{
							JGKOLBLPMPG();
							return;
						}
						int c = 0;
						if(!IAHLNPMFJMH)
						{
							if(EPNFGKBBJCE.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
							{
								int a = LKBGPLDLNIK.JPIMHNNGJGI(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NKIGFPJPALK_LastLotTime, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System);
								if(a > 0)
								{
									HDFGHFOCHKE();
									return;
								}
								c = 1;
								if(EPNFGKBBJCE.MEONHEGJNEF())
								{
									//LAB_01005b34
									JHHBAFKMBDL.HHCJCDFCLOB.HMIHFLGLHBA(JGKOLBLPMPG);
									return;
								}
							}
							else if(EPNFGKBBJCE.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
							{
								if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null || CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave == null)
								{
									//LAB_01005aac
									JGKOLBLPMPG(); // HDFGHFOCHKE
									return;
								}
								if (EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), null) < GachaUtility.GetMenuPrice(GachaUtility.selectCategory, GachaUtility.selectedCountType, GachaUtility.selectedLotType))
								{
									//LAB_01005aac
									HDFGHFOCHKE();
									return;
								}
								if (EPNFGKBBJCE.MEONHEGJNEF())
								{
									//LAB_01005b34
									JHHBAFKMBDL.HHCJCDFCLOB.HMIHFLGLHBA(JGKOLBLPMPG);
									return;
								}
								c = GachaUtility.GetMenuLotCount(GachaUtility.selectCategory, GachaUtility.selectedCountType, GachaUtility.selectedLotType);
							}
							else if(EPNFGKBBJCE.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GKDFKDLFNAJ_5)
							{
								//LAB_01005aac
								HDFGHFOCHKE();
								return;
							}
							else if(EPNFGKBBJCE.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BKNHBNINDOC_6)
							{
								//LAB_01005aac
								HDFGHFOCHKE();
								return;
							}
							else
							{
								c = 1;
							}
						}
						KONHMOLMOCI_IsSaving = true;
						if(!IAHLNPMFJMH)
						{
							EPNFGKBBJCE.ICBNPNKJCBK(BJLONGBNPCI, (List<MFDJIFIIPJD> BODJIDOHAHF) =>
							{
								//0x100BDCC
								N.a.StartCoroutineWatched(GEOMKFMLDPL_Coroutine_DrawLotByFreeVC_AfterSave(EPNFGKBBJCE, BJLONGBNPCI, BODJIDOHAHF, BHFHGFKBOHH, JGKOLBLPMPG, IAHLNPMFJMH));
							}, () =>
							{
								//0x100BE64
								if (JGKOLBLPMPG != null)
									JGKOLBLPMPG();
								KONHMOLMOCI_IsSaving = false;
							}, c);
							return;
						}
						int fixed_scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("fixed_scene", 3);
						List<MFDJIFIIPJD> l = new List<MFDJIFIIPJD>();
						MFDJIFIIPJD m = new MFDJIFIIPJD();
						m.KHEKNNFCAOI("scene", fixed_scene, 1, 0);
						l.Add(m);
						N.a.StartCoroutineWatched(GEOMKFMLDPL_Coroutine_DrawLotByFreeVC_AfterSave(EPNFGKBBJCE, BJLONGBNPCI, l, BHFHGFKBOHH, JGKOLBLPMPG, IAHLNPMFJMH));
					}
					else
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(f, JGKOLBLPMPG, 7004));
					}
				}
				else
				{
					N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, JGKOLBLPMPG, 7003));
				}
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, JGKOLBLPMPG, 7002));
			}
		}
		else
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, JGKOLBLPMPG, 7001));
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8080 Offset: 0x6B8080 VA: 0x6B8080
	// // RVA: 0x1005C2C Offset: 0x1005C2C VA: 0x1005C2C
	private IEnumerator GEOMKFMLDPL_Coroutine_DrawLotByFreeVC_AfterSave(LOBDIAABMKG EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM_SummonType BJLONGBNPCI, List<MFDJIFIIPJD> BODJIDOHAHF, CDOPFBOHDEF BHFHGFKBOHH, DJBHIFLHJLK JGKOLBLPMPG, bool IAHLNPMFJMH)
	{
		//0x100D968
		yield return null;
		KBPDNHOKEKD_ProductId p = EPNFGKBBJCE.DBHIEABGKII_GetSummon(BJLONGBNPCI);
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		if(EPNFGKBBJCE.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave == null || IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database == null)
			{
				if (JGKOLBLPMPG != null)
					JGKOLBLPMPG();
				KONHMOLMOCI_IsSaving = false;
				yield break;
			}
			EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), null) - GachaUtility.GetMenuPrice(GachaUtility.selectCategory, GachaUtility.selectedCountType, GachaUtility.selectedLotType), null);
		}
		else if(EPNFGKBBJCE.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1)
		{
			AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NKIGFPJPALK_LastLotTime = t;
			ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.IDAIIJEMNMP_47, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, AHEFHIMGIBI_ServerSave, 2, false);
		}
		JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.DOEHLCLBCNN_3, EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId.ToString());
		ILCCJNDFFOB.HHCJCDFCLOB.JNBKOAKJDAL(EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId, BODJIDOHAHF.Count, EPNFGKBBJCE.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10 ? 4 : 3, BODJIDOHAHF.Count * p.NPPGKNGIFGK_Price, BODJIDOHAHF, AHEFHIMGIBI_ServerSave, null, null, null);
		JDDGPJDKHNE.HHCJCDFCLOB.NFNLGGHMEAM();
		JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = true;
		bool b1 = false;
		for(int i = 0; i < BODJIDOHAHF.Count; i++)
		{
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BODJIDOHAHF[i].JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_Day.BFAJMALBALG_AddGacha(BODJIDOHAHF[i].MBJIFDBEDAC_Cnt);
				JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.JLFJCIOOABC_32);
				b1 = true;
			}
			JANMJPOKLFL.OBCINIPHGGH = 0;
			JANMJPOKLFL.IKBLCEFCGDE = 0;
			JANMJPOKLFL.PJBJCBEMEEC = 0;
			if (!JANMJPOKLFL.HMDCGPGGOBA_IsAddItemOverflow(AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BODJIDOHAHF[i].JJBGOIMEIPF_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(BODJIDOHAHF[i].JJBGOIMEIPF_ItemId), BODJIDOHAHF[i].MBJIFDBEDAC_Cnt))
			{
				JANMJPOKLFL.CPIICACGNBH_AddItem(AHEFHIMGIBI_ServerSave, BODJIDOHAHF[i].JJBGOIMEIPF_ItemId, BODJIDOHAHF[i].MBJIFDBEDAC_Cnt, null, 0);
				if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BODJIDOHAHF[i].JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					BODJIDOHAHF[i].CJEOENICNOC = JANMJPOKLFL.OBCINIPHGGH;
					BODJIDOHAHF[i].JPIPENJGGDD_SceneMlt = JANMJPOKLFL.PJBJCBEMEEC;
					BODJIDOHAHF[i].MJBODMOLOBC_SceneLuck = JANMJPOKLFL.IKBLCEFCGDE;
					BODJIDOHAHF[i].LHMOAJAIJCO_New = BODJIDOHAHF[i].JPIPENJGGDD_SceneMlt == 0;
				}
				BODJIDOHAHF[i].HMGCLKNLMAL = false;
			}
			else
			{
				BODJIDOHAHF[i].HMGCLKNLMAL = true;
				GPOGFJFGNCA = true;
			}
		}
		if(b1 && GNGMCIAIKMA.HHCJCDFCLOB != null)
		{
			GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.DOEHLCLBCNN_14, 0, 1, null);
			GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
		}
		AHEFHIMGIBI_ServerSave.IPLNOMCCNBI_UpdatePublicStatus();
		BBHNACPENDM_ServerSaveData.EMHDCKMFCGE diff = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_ServerSave, true);
		if(diff == null || diff.LHIACHALIFC_IsEmpty())
		{
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
			if (JGKOLBLPMPG != null)
				JGKOLBLPMPG();
			KONHMOLMOCI_IsSaving = false;
			yield break;
		}
		CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
		if(!IAHLNPMFJMH)
		{
			GGKHIHFPKDH_SavePlayerData COJNCNGHIJC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
			COJNCNGHIJC.GJAEJFLLKGC_RetryTime = 1;
			COJNCNGHIJC.DOMFHDPMCCO(diff, null);
			COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x100BEAC
				GGKHIHFPKDH_SavePlayerData r = NHECPMNKEFK as GGKHIHFPKDH_SavePlayerData;
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
				AHEFHIMGIBI_ServerSave.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF_Names);
				CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF_Names);
				FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
				ECFNAOCFKKN = COJNCNGHIJC.NFEAMMJIMPG.IFNLEKOILPM_UpdatedAt;
				AHEFHIMGIBI_ServerSave.PLCFEICAKBC(r.HHIHCJKLJFF_Names);
				HLBJOJBALIG(COJNCNGHIJC.HHIHCJKLJFF_Names);
				BHFHGFKBOHH(BODJIDOHAHF);
				KONHMOLMOCI_IsSaving = false;
			};
			COJNCNGHIJC.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x100C1D0
				JDDGPJDKHNE.HHCJCDFCLOB.FOKEGEOKGDG();
				JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
				KONHMOLMOCI_IsSaving = false;
				JGKOLBLPMPG();
			};
		}
		else
		{
			JDDGPJDKHNE.HHCJCDFCLOB.FCMCNIMEAEA = false;
			HLBJOJBALIG(diff.KFGDPMNCCFO);
			BHFHGFKBOHH(BODJIDOHAHF);
			KONHMOLMOCI_IsSaving = false;
		}
	}

	// // RVA: 0x1005D78 Offset: 0x1005D78 VA: 0x1005D78
	private void MCLANEJGNHD_GetSystemProducts()
	{
		DICMPMEEIJL_HasSystemProducts = false;
		JNDDNFEINEH = false;
		NEAPMMJKOKA_GetProducts req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
		req.IPKCADIAAPG_Criteria = LCKOLEDFDAL.FBJHGFIHNHE_GetCriteriaForSystemProducts();
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x1009500
			NEAPMMJKOKA_GetProducts r = NHECPMNKEFK as NEAPMMJKOKA_GetProducts;
			for(int i = 0; i < r.NFEAMMJIMPG.MHKCPJDNJKI_Products.Count; i++)
			{
				KBPDNHOKEKD_ProductId prod = r.NFEAMMJIMPG.MHKCPJDNJKI_Products[i];
				if (prod.KAPMOPMDHJE_Label == 10)
				{
					if(prod.OriginalName.Contains(FNBPIOCLODC_Continue))
					{
						CDPHPAIAFDG_Continue_ProdId = prod.PPFNGGCBJKC_Id;
						BPPGDBHGMDA_Continue_Price = prod.NPPGKNGIFGK_Price;
					}
					else
					{
						if(prod.OriginalName.Contains(CPBCGKAKDIA_Stamina))
						{
							FFAGOLDAHHN_EnergyProdId = prod.PPFNGGCBJKC_Id;
							KMJLGBJBOAK_StaminaRefillCost = prod.NPPGKNGIFGK_Price;
						}
						else
						{
							if (!prod.OriginalName.Contains(OHPLHJNCLPH_Energy))
							{
								if (prod.OriginalName.Contains(FBDLJDOLMNI_Vop))
								{
									MCLKCGMIKNF_Vop_ProdId = prod.PPFNGGCBJKC_Id;
									DMEHACGEOFK_Vop_Price = prod.NPPGKNGIFGK_Price;
								}
								else
								{
									if (prod.OriginalName.Contains(AJICGGJJNCA_Ap))
									{
										string s = prod.OriginalName.Replace(JpStringLiterals.StringLiteral_9798, "");
										if (s != "2")
										{
											if (s != "3")
											{
												KKFJJAHFLOK_Ap_ProdIds[0] = prod.PPFNGGCBJKC_Id;
												ELJNINICAIF_Ap_Prices[0] = prod.NPPGKNGIFGK_Price;
											}
											else
											{
												KKFJJAHFLOK_Ap_ProdIds[2] = prod.PPFNGGCBJKC_Id;
												ELJNINICAIF_Ap_Prices[2] = prod.NPPGKNGIFGK_Price;
											}
										}
										else
										{
											KKFJJAHFLOK_Ap_ProdIds[1] = prod.PPFNGGCBJKC_Id;
											ELJNINICAIF_Ap_Prices[1] = prod.NPPGKNGIFGK_Price;
										}
									}
								}
							}
							else
							{
								FFAGOLDAHHN_EnergyProdId = prod.PPFNGGCBJKC_Id;
								KMJLGBJBOAK_StaminaRefillCost = prod.NPPGKNGIFGK_Price;
							}
						}
					}
				}
			}
			DICMPMEEIJL_HasSystemProducts = true;
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x100A094
			DICMPMEEIJL_HasSystemProducts = false;
			JNDDNFEINEH = false;
		};
	}

	// // RVA: 0x1005F44 Offset: 0x1005F44 VA: 0x1005F44
	public void OKGLDKFLGGK(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG, int GHBPLHBNMBK, int AKNELONELJK)
	{
		IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
		if(IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP == 0)
		{
			PFAKPFKJJKA();
			if(!BLCDJDJJBHC)
			{
				KONHMOLMOCI_IsSaving = true;
				N.a.StartCoroutineWatched(INJLKHHHMCI_Coroutine_InGameContinueByPaidVC(BHFHGFKBOHH, HDFGHFOCHKE, MOBEEPPKFLG, GHBPLHBNMBK, AKNELONELJK));
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 10002));
			}
		}
		else
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 10001));
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B80F8 Offset: 0x6B80F8 VA: 0x6B80F8
	// // RVA: 0x10060CC Offset: 0x10060CC VA: 0x10060CC
	private IEnumerator INJLKHHHMCI_Coroutine_InGameContinueByPaidVC(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG, int GHBPLHBNMBK, int AKNELONELJK)
	{
		PJKLMCGEJMK OKDOIAEGADK;
		DOLDMCAMEOD_RequestRemainingForCurrencyIds PMNKDBLBFHM;

		//0x1010610
		OKDOIAEGADK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		PMNKDBLBFHM = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
		PMNKDBLBFHM.CGCFENMHJIM_Ids = NFGNKHONICJ();
		yield return PMNKDBLBFHM.GDPDELLNOBO_WaitDone(N.a);
		if(PMNKDBLBFHM.NPNNPNAIONN_IsError)
		{
			if(MOBEEPPKFLG != null)
			{
				MOBEEPPKFLG();
			}
		}
		else
		{
			DJICHKCLMCD_UpdateCurrencies(PMNKDBLBFHM.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
			if(BPPGDBHGMDA_Continue_Price <= DEAPMEIDCGC_GetTotalPaidCurrency())
			{
				AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.AFBCPAGPLNB_IncContinue();
				AHEFHIMGIBI_ServerSave.IPLNOMCCNBI_UpdatePublicStatus();
				BBHNACPENDM_ServerSaveData.EMHDCKMFCGE e = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_ServerSave, true);
				if(e != null)
				{
					if(!e.LHIACHALIFC_IsEmpty())
					{
						for(int i = 0; i < e.KFGDPMNCCFO.Count; i++)
						{
							FENCAJJBLBH f = AHEFHIMGIBI_ServerSave.LBDOLHGDIEB_GetBlock(e.KFGDPMNCCFO[i]).PFAKPFKJJKA();
							if (f != null)
							{
								N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(f, MOBEEPPKFLG, 8001));
								yield break;
							}
						}
						CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
						FNPBAENIEPG_PurchaseAndSave COJNCNGHIJC = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new FNPBAENIEPG_PurchaseAndSave());
						COJNCNGHIJC.GJAEJFLLKGC_RetryTime = 1;
						COJNCNGHIJC.CLBFPFLNGKF = true;
						COJNCNGHIJC.DOMFHDPMCCO(e, CDPHPAIAFDG_Continue_ProdId, 1, 1001);
						COJNCNGHIJC.LGEKLPJFJEI_TotalCurrency = DEAPMEIDCGC_GetTotalPaidCurrency();
						COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x100C270
							AHEFHIMGIBI_ServerSave.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF);
							CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF);
							FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
							ECFNAOCFKKN = COJNCNGHIJC.NFEAMMJIMPG.IFNLEKOILPM_UpdatedAt;
							HLBJOJBALIG(COJNCNGHIJC.HHIHCJKLJFF);
							MCKCJMLOAFP_CurrencyInfo cinfo = JBEKNFEGFFI();
							int prevTotal = cinfo.BDLNMOIOMHK_Total;
							DJICHKCLMCD_UpdateCurrencies(COJNCNGHIJC.NFEAMMJIMPG.BBEPLKNMICJ_Balances);
							string str = JpStringLiterals.StringLiteral_9799 + GHBPLHBNMBK.ToString() + ":";
							if(AKNELONELJK < 5)
							{
								str += new string[]
								{
									"Easy",
									"Normal",
									"Hard",
									"VeryHard",
									"Extream",
								} [AKNELONELJK];
							}
							ILCCJNDFFOB.HHCJCDFCLOB.PMFGEJJDMCK(GHBPLHBNMBK, 2, str, prevTotal - cinfo.BDLNMOIOMHK_Total, 0);
							if(BHFHGFKBOHH != null)
							{
								BHFHGFKBOHH();
							}
							KONHMOLMOCI_IsSaving = false;
						};
						COJNCNGHIJC.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x100C634
							if(MOBEEPPKFLG != null)
								MOBEEPPKFLG();
							KONHMOLMOCI_IsSaving = false;
						};
						yield break;
					}
				}
				if(MOBEEPPKFLG != null)
				{
					MOBEEPPKFLG();
				}
				yield break;
			}
			if(HDFGHFOCHKE != null)
			{
				HDFGHFOCHKE();
			}
		}
		KONHMOLMOCI_IsSaving = false;
	}

	// // RVA: 0x10061FC Offset: 0x10061FC VA: 0x10061FC
	// public void JLLHLFDGCKF(int APHNELOFGAK, KBPDNHOKEKD BBABCIMFOPD, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B8170 Offset: 0x6B8170 VA: 0x6B8170
	// // RVA: 0x100639C Offset: 0x100639C VA: 0x100639C
	// private IEnumerator MKOCPKDBNJC_ActivateMonthlyPassByPaidVC(int APHNELOFGAK, KBPDNHOKEKD BBABCIMFOPD, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x10064CC Offset: 0x10064CC VA: 0x10064CC
	public void ELGMEAEDOHI_OfferFastCompleteByPaidVC(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG, BOPFPIHGJMD.MLBMHDCCGHI FGHGMHPNEMG, int MLDPDLPHJPM, int APPJOBEMLBE)
	{
		IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
		if(IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP == 0)
		{
			PFAKPFKJJKA();
			if(!BLCDJDJJBHC)
			{
				KONHMOLMOCI_IsSaving = true;
				N.a.StartCoroutineWatched(LJJAPOIKAMA_Coroutine_OfferFastCompleteByPaidVC(BHFHGFKBOHH, HDFGHFOCHKE, MOBEEPPKFLG, FGHGMHPNEMG, MLDPDLPHJPM, APPJOBEMLBE));
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 10002));
			}
		}
		else
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(null, MOBEEPPKFLG, 10001));
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B81E8 Offset: 0x6B81E8 VA: 0x6B81E8
	// // RVA: 0x100665C Offset: 0x100665C VA: 0x100665C
	private IEnumerator LJJAPOIKAMA_Coroutine_OfferFastCompleteByPaidVC(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG, BOPFPIHGJMD.MLBMHDCCGHI FGHGMHPNEMG, int MLDPDLPHJPM, int APPJOBEMLBE)
	{
		PJKLMCGEJMK OKDOIAEGADK; // 0x30
		DOLDMCAMEOD_RequestRemainingForCurrencyIds PMNKDBLBFHM; // 0x34

		//0x1012AA8
		OKDOIAEGADK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		PMNKDBLBFHM = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
		PMNKDBLBFHM.CGCFENMHJIM_Ids = NFGNKHONICJ();
		yield return PMNKDBLBFHM.GDPDELLNOBO_WaitDone(N.a);
		if(PMNKDBLBFHM.NPNNPNAIONN_IsError)
		{
			if(MOBEEPPKFLG != null)
			{
				MOBEEPPKFLG();
			}
		}
		else
		{
			DJICHKCLMCD_UpdateCurrencies(PMNKDBLBFHM.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
			if(DEAPMEIDCGC_GetTotalPaidCurrency() >= DMEHACGEOFK_Vop_Price)
			{
				AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.AFBCPAGPLNB_IncContinue();
				AHEFHIMGIBI_ServerSave.IPLNOMCCNBI_UpdatePublicStatus();
				BBHNACPENDM_ServerSaveData.EMHDCKMFCGE diff = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_ServerSave, true);
				if(diff != null)
				{
					if(!diff.LHIACHALIFC_IsEmpty())
					{
						for(int i = 0; i < diff.KFGDPMNCCFO.Count; i++)
						{
							FENCAJJBLBH err = AHEFHIMGIBI_ServerSave.LBDOLHGDIEB_GetBlock(diff.KFGDPMNCCFO[i]).PFAKPFKJJKA();
							if(err != null)
							{
								N.a.StartCoroutineWatched(EHNDCODOBBL_Falsification(err, MOBEEPPKFLG, 8001));
								yield break;
							}
						}
						CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
						FNPBAENIEPG_PurchaseAndSave COJNCNGHIJC = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new FNPBAENIEPG_PurchaseAndSave());
						COJNCNGHIJC.GJAEJFLLKGC_RetryTime = 1;
						COJNCNGHIJC.CLBFPFLNGKF = false;
						COJNCNGHIJC.DOMFHDPMCCO(diff, MCLKCGMIKNF_Vop_ProdId, APPJOBEMLBE, 1001);
						COJNCNGHIJC.LGEKLPJFJEI_TotalCurrency = DEAPMEIDCGC_GetTotalPaidCurrency();
						COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x100C980
							AHEFHIMGIBI_ServerSave.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF);
							CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC.HHIHCJKLJFF);
							FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
							ECFNAOCFKKN = COJNCNGHIJC.NFEAMMJIMPG.IFNLEKOILPM_UpdatedAt;
							HLBJOJBALIG(COJNCNGHIJC.HHIHCJKLJFF);
							int prev = JBEKNFEGFFI().BDLNMOIOMHK_Total;
							DJICHKCLMCD_UpdateCurrencies(COJNCNGHIJC.NFEAMMJIMPG.BBEPLKNMICJ_Balances);
							int next = JBEKNFEGFFI().BDLNMOIOMHK_Total;
							ILCCJNDFFOB.HHCJCDFCLOB.PMFGEJJDMCK((int)FGHGMHPNEMG * 10000 + MLDPDLPHJPM, 2, JpStringLiterals.StringLiteral_9797_Jp, prev - next, 0);
							if (BHFHGFKBOHH != null)
								BHFHGFKBOHH();
							KONHMOLMOCI_IsSaving = false;
						};
						COJNCNGHIJC.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x100CCEC
							if (MOBEEPPKFLG != null)
								MOBEEPPKFLG();
							KONHMOLMOCI_IsSaving = false;
						};
						yield break;
					}
				}
				if (MOBEEPPKFLG != null)
					MOBEEPPKFLG();
				yield break;
			}
			if (HDFGHFOCHKE != null)
				HDFGHFOCHKE();
		}
		KONHMOLMOCI_IsSaving = false;
	}

	// // RVA: 0x1000F04 Offset: 0x1000F04 VA: 0x1000F04
	public void PFAKPFKJJKA()
	{
		if(LNAHEIEIBOI_Initialized && AHEFHIMGIBI_ServerSave != null && BLCDJDJJBHC)
		{
			FENCAJJBLBH f = AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(true);
			if(f != null)
			{
				BLCDJDJJBHC = true;
				DCLNIAMEGLA = f;
			}
		}
	}

	// // RVA: 0xFFCF90 Offset: 0xFFCF90 VA: 0xFFCF90
	// public void PFAKPFKJJKA(FKAFHLIDAFD JEBPDGCBPJC) { }

	// // RVA: 0xFFB658 Offset: 0xFFB658 VA: 0xFFB658
	private void PDKNJAEGNIL()
	{
		if(LNAHEIEIBOI_Initialized && AHEFHIMGIBI_ServerSave != null)
		{
			if(BLCDJDJJBHC)
				return;
			if(AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(false) != null)
			{
				BLCDJDJJBHC = true;
				DCLNIAMEGLA = AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(false);
			}
		}
	}

	// // RVA: 0xFFB6A4 Offset: 0xFFB6A4 VA: 0xFFB6A4
	private void PDKNJAEGNIL(FKAFHLIDAFD JEBPDGCBPJC)
	{
		if(JEBPDGCBPJC.LNAHEIEIBOI)
		{
			if(JEBPDGCBPJC.AHEFHIMGIBI != null)
			{
				if(!JEBPDGCBPJC.BLCDJDJJBHC)
				{
					if(JEBPDGCBPJC.AHEFHIMGIBI.PFAKPFKJJKA(false) != null)
					{
						JEBPDGCBPJC.DCLNIAMEGLA = JEBPDGCBPJC.AHEFHIMGIBI.PFAKPFKJJKA(false);
						JEBPDGCBPJC.BLCDJDJJBHC = true;
					}
				}
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8260 Offset: 0x6B8260 VA: 0x6B8260
	// // RVA: 0xFFC7E4 Offset: 0xFFC7E4 VA: 0xFFC7E4
	private IEnumerator EHNDCODOBBL_Falsification(FENCAJJBLBH KOGBMDOONFA, DJBHIFLHJLK MOBEEPPKFLG, int NHJBJIGNLHI)
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "EHNDCODOBBL_Falsification");
		yield return null;
	}

	// // RVA: 0x10067C4 Offset: 0x10067C4 VA: 0x10067C4
	public bool HNDJBAAAHDO(ref int IBAKPKKEDJM, ref int BAOFEFFADPD)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB != null)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized && LNAHEIEIBOI_Initialized)
			{
				DateTime date = Utility.GetLocalDateTime(AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.AFPONJEJKCO_RenameDate + IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.KMNPFOPBDMA_RenameDay * 86400);
				long t = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				if(time < t)
				{
					IBAKPKKEDJM = date.Month;
					BAOFEFFADPD = date.Day;
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x1006B5C Offset: 0x1006B5C VA: 0x1006B5C
	public void AKCOAKHAGAL_CheckServerSaveDefaultInit()
	{
		if(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NIKCFOALFJC_DivaFirst == 0)
		{
			AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NIKCFOALFJC_DivaFirst = 1;
			if(AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[0].EALOBDHOCHP_Stat != 4)
			{
				AHEFHIMGIBI_ServerSave.LNOOKHJBENO_StoryRecord.LOAOLBNFNNP_InitDefault();
			}
		}
		if (AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id == 0)
		{
			AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NIKCFOALFJC_DivaFirst;
		}
		if (AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FODKKJIDDKN_VfId == 0)
			AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FODKKJIDDKN_VfId = 1;
	}

	// // RVA: 0x1006F44 Offset: 0x1006F44 VA: 0x1006F44
	// public bool GBEDPKIECPK() { }

	// // RVA: 0x1007300 Offset: 0x1007300 VA: 0x1007300
	// public void MCKHFOAAJGO(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B82D8 Offset: 0x6B82D8 VA: 0x6B82D8
	// // RVA: 0x1007358 Offset: 0x1007358 VA: 0x1007358
	private IEnumerator DEHKLOLHKID_Coroutine_ReSave(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		BBHNACPENDM_ServerSaveData GNJJEDPNELC; // 0x1C
		NAIJIFAJGGK_RequestLoadPlayerData AFHIJJJKJJJ; // 0x20

		//0x10757EC
		GNJJEDPNELC = new BBHNACPENDM_ServerSaveData();
		GNJJEDPNELC.CAKOEJHBIHF();
		AFHIJJJKJJJ = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAIJIFAJGGK_RequestLoadPlayerData());
		AFHIJJJKJJJ.HHIHCJKLJFF_BlockToRequest = GNJJEDPNELC.KPIDBPEKMFD_GetBlockList();
		AFHIJJJKJJJ.IJMPLDBGMHC_OnDataReceived = GNJJEDPNELC.IIEMACPEEBJ_Load;
		yield return AFHIJJJKJJJ.GDPDELLNOBO_WaitDone(N.a);
		if(AFHIJJJKJJJ.NPNNPNAIONN_IsError)
		{
			KONHMOLMOCI_IsSaving = false;
			AOCANKOMKFG();
		}
		else
		{
			if(BDNBIEMJMCD)
			{
				GNJJEDPNELC.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName = JpStringLiterals.StringLiteral_9806;
				GNJJEDPNELC.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof = JpStringLiterals.StringLiteral_9807;
				BDNBIEMJMCD = false;
			}
			AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName = GNJJEDPNELC.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
			AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof = GNJJEDPNELC.JHFIPCIHJNL_Base.CMKKFCGBILD_Prof;
			AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.KFKDMBPNLJK_BlockInvalid = true;
			FMFKHDPKLOC.JHFIPCIHJNL_Base.KFKDMBPNLJK_BlockInvalid = true;
			NPOPAOCGIJN = 0;
			HAELBFCGHMB = false;
			KONHMOLMOCI_IsSaving = false;
			AIKJMHBDABF_SavePlayerData(BHFHGFKBOHH, AOCANKOMKFG, null);
		}
	}

	// // RVA: 0x1007414 Offset: 0x1007414 VA: 0x1007414
	public void KPHFDEOFKLM_UpdateEnergyDayChange()
	{
		JKDKODAPGBJ_EnergyItem dbEnergy = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < dbEnergy.CDENCMNHNGA.Count; i++)
		{
			JKDKODAPGBJ_EnergyItem.GFGCCICHBHK it = dbEnergy.CDENCMNHNGA[i];
			if (it.PPEGAKEIEGM_Enabled == 2)
			{
				if(it.HJAFPEBIBOP_IsLimit > 0)
				{
					if(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem.Count > i)
					{
						EGOLBAPFHHD_Common.FKLHGOGJOHH serverItem = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[i];
						if(serverItem.BFINGCJHOHI_Cnt != 0)
						{
							long t = serverItem.BEBJKJKBOGH_Date;
							DateTime d1 = Utility.GetLocalDateTime(t);
							DateTime d2 = Utility.GetLocalDateTime(time);
							if(d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day)
							{
								;
							}
							else
							{
								serverItem.BFINGCJHOHI_Cnt = 0;
								Debug.Log(JpStringLiterals.StringLiteral_9787);
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0x10079FC Offset: 0x10079FC VA: 0x10079FC
	public List<int> NFGNKHONICJ()
	{
		List<int> res = new List<int>();
		res.Add(1001);
		res.AddRange(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH);
		List<HHJHIFJIKAC_BonusVc.MNGJPJBCMBH> l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA;
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].PLALNIIBLOF_Enabled == 2)
			{
				int idx = res.FindIndex((int GHPLINIACBB) =>
				{
					//0x100CD40
					return l[i].CPGFOBNKKBF_CurrencyId == GHPLINIACBB;
				});
				if(idx < 0 && l[i].CPGFOBNKKBF_CurrencyId != 0)
				{
					res.Add(l[i].CPGFOBNKKBF_CurrencyId);
				}
			}
		}
		return res;
	}

	// // RVA: 0x1007DC0 Offset: 0x1007DC0 VA: 0x1007DC0
	public void LBLNLMGHLAG_UpdateShop()
	{
		BKPAPCMJKHE_Shop shopDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop;
		GBEFGAIGGHA_Shop serverShop = AHEFHIMGIBI_ServerSave.IJOHDAJMBAL_Shop;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		serverShop.LBLNLMGHLAG_UpdateTimedItems(shopDb, time);
	}

	// // RVA: 0x1007FB8 Offset: 0x1007FB8 VA: 0x1007FB8
	public void NAOGKAIBBEH()
	{
		if(AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BKEKKFPEPBG_LDt != NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD)
		{
			AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BKEKKFPEPBG_LDt = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
			AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt++;
			if (AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt > 999999998)
				AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt = 0;
			Debug.Log(JpStringLiterals.StringLiteral_9788 + AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt + "</color>");
			if(GNGMCIAIKMA.HHCJCDFCLOB != null)
			{
				GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.IBGNFEOLKDP/*2*/, 0, 1, null);
				GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
			}
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.JKHNILLPKBO_LCnt = AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.HLKKGIKPLOM_LDay = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
			GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
		}
	}

	// // RVA: 0x1008444 Offset: 0x1008444 VA: 0x1008444
	public bool NPAPJMLJBKM(bool FBBNPFFEJBN_Force = false)
	{
		int a = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
		if(!FBBNPFFEJBN_Force)
		{
			if (AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.EMINMIPNAEG_LsDate == a)
				return false;
		}
		AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KBFFLGOBLAF_LsCnt = 0;
		AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.CBHANJJJDBN_SlsCnt = 0;
		AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.EMINMIPNAEG_LsDate = a;
		return true;
	}

	// // RVA: 0x1008608 Offset: 0x1008608 VA: 0x1008608
	public int PPADGJPHDAD()
	{
		int res = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OEJIPANCLOP.LHHOODFPCEL;
		if(NHPDPKHMFEP.HHCJCDFCLOB != null && NHPDPKHMFEP.HHCJCDFCLOB.CJMPCGHCGJB())
		{
			res += NHPDPKHMFEP.HHCJCDFCLOB.ELHKIEBJHLL();
		}
		return res;
	}

	// // RVA: 0x1008764 Offset: 0x1008764 VA: 0x1008764
	public int IIMNMNGEPIJ()
	{
		int res = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OEJIPANCLOP.JKDFMICLDJO;
		if(NHPDPKHMFEP.HHCJCDFCLOB != null && NHPDPKHMFEP.HHCJCDFCLOB.CJMPCGHCGJB())
		{
			res += NHPDPKHMFEP.HHCJCDFCLOB.EOBEPKGEJFE();
		}
		return res;
	}

	// // RVA: 0x10088C0 Offset: 0x10088C0 VA: 0x10088C0
	public int PIEPAMPMODI()
	{
		int a = AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KBFFLGOBLAF_LsCnt;
		if(NHPDPKHMFEP.HHCJCDFCLOB != null && NHPDPKHMFEP.HHCJCDFCLOB.CJMPCGHCGJB())
		{
			a += AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.CBHANJJJDBN_SlsCnt;
		}
		return a;
	}

	// // RVA: 0x10089E4 Offset: 0x10089E4 VA: 0x10089E4
	public int GGJMFEGHGIA()
	{
		return PPADGJPHDAD() - PIEPAMPMODI();
	}

	// // RVA: 0x1008A08 Offset: 0x1008A08 VA: 0x1008A08
	public int KJBENABMBCA(long KNCKIJBOODM)
	{
		return AHEFHIMGIBI_ServerSave.GJCOJBDOOJG_LimitedCompoItem.HPPKOGKNKMH(1, KNCKIJBOODM);
	}

	// // RVA: 0x1008A74 Offset: 0x1008A74 VA: 0x1008A74
	public bool LNCGIOILBDD(int HMFFHLPNMPH, long KNCKIJBOODM)
	{
		if(HMFFHLPNMPH <= KJBENABMBCA(KNCKIJBOODM))
		{
			if (PIEPAMPMODI() + HMFFHLPNMPH <= PPADGJPHDAD())
				return true;
		}
		return false;
	}

	// // RVA: 0x1008AC4 Offset: 0x1008AC4 VA: 0x1008AC4
	public bool HDKICOHCCJB(long KNCKIJBOODM)
	{
		return KJBENABMBCA(KNCKIJBOODM) > 0;
	}

	// // RVA: 0x1008AEC Offset: 0x1008AEC VA: 0x1008AEC
	public bool PPDOILECBAD()
	{
		return PIEPAMPMODI() >= PPADGJPHDAD();
	}

	// // RVA: 0x1008B14 Offset: 0x1008B14 VA: 0x1008B14
	public bool GJACBNJHDHI(int HMFFHLPNMPH, long KNCKIJBOODM)
	{
		if(HMFFHLPNMPH > 0 && LNCGIOILBDD(HMFFHLPNMPH, KNCKIJBOODM))
		{
			List<int> l = AHEFHIMGIBI_ServerSave.GJCOJBDOOJG_LimitedCompoItem.BHNDPHCBCKN(1, KNCKIJBOODM);
			int cnt = Mathf.Min(HMFFHLPNMPH, l.Count);
			for(int i = 0; i < cnt; i++)
			{
				AHEFHIMGIBI_ServerSave.GJCOJBDOOJG_LimitedCompoItem.LLOAMEOCJEO(1, l[i], KNCKIJBOODM);
			}
			if(NHPDPKHMFEP.HHCJCDFCLOB != null && NHPDPKHMFEP.HHCJCDFCLOB.CJMPCGHCGJB())
			{
				int a = NHPDPKHMFEP.HHCJCDFCLOB.ELHKIEBJHLL() - AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.CBHANJJJDBN_SlsCnt;
				if(a - HMFFHLPNMPH > 0)
				{
					AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.CBHANJJJDBN_SlsCnt += HMFFHLPNMPH;
					return true;
				}
				AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.CBHANJJJDBN_SlsCnt += a;
				HMFFHLPNMPH -= a;
			}
			if(HMFFHLPNMPH > 0)
			{
				AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KBFFLGOBLAF_LsCnt += HMFFHLPNMPH;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x1008ED0 Offset: 0x1008ED0 VA: 0x1008ED0
	public bool NKMNJIAGHBB()
	{
		return NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.CHINCCDPPIN_LsGetData;
	}

	// // RVA: 0x1008FB8 Offset: 0x1008FB8 VA: 0x1008FB8
	public void ONAAEGAJBBG(int CPCGBPOKHOJ)
	{
		int a = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
		JANMJPOKLFL.JCHLONCMPAJ();
		JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.HNJIKEJADJL/*41*/, "");
		JANMJPOKLFL.CPIICACGNBH(AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem, 1, CPCGBPOKHOJ, null, 0);
		AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.CHINCCDPPIN_LsGetData = a;
	}
}
