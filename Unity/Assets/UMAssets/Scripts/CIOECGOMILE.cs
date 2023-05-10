using System.Text;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using XeSys;
using XeApp.Game;

public class CIOECGOMILE
{
	public delegate void LHGEIKBCBBP(List<string> OHNJJIMGKGK);
	public delegate CACGCMBKHDI_Request PIIFKPKIOOB(PJKLMCGEJMK CPHFEPHDJIB, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE JEHOEIKANFL, string JCJDPGMKJAJ);

	private FENCAJJBLBH DCLNIAMEGLA; // 0x1C
	private bool DICMPMEEIJL_HasSystemProducts; // 0x20
	private bool JNDDNFEINEH; // 0x21
	private int FFAGOLDAHHN_EnergyProdId; // 0x24
	private int KMJLGBJBOAK_StaminaProdId; // 0x28
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
	public bool JHOKIPPIHII; // 0x98
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
	private static string OHPLHJNCLPH_Energy = JpStringLiterals.StringLiteral_9793; // 0x18
	private static string CPBCGKAKDIA_Stamina = JpStringLiterals.StringLiteral_9794; // 0x1C
	private static string AJICGGJJNCA_Ap = "AP"; // 0x20
	private static string FNBPIOCLODC_Continue = JpStringLiterals.StringLiteral_9796; // 0x24
	private static string FBDLJDOLMNI_Vop = JpStringLiterals.StringLiteral_9797; // 0x28

	public static CIOECGOMILE HHCJCDFCLOB { get; private set; }  // 0x0 LGMPACEDIJF // NKACBOEHELJ OKPMHKNCNAL
	public BBHNACPENDM_ServerSaveData AHEFHIMGIBI_ServerSave { get; private set; }  // 0x8 LCHHPGMCKJD // GNMGJMDJEGI LGLGNHAMNIK
	private BBHNACPENDM_ServerSaveData CCNKAKCBBDJ { get; set; } // 0xC MOMIOKHCMKH GHMKOMEKBFO KKOICOJPENH
	public BBHNACPENDM_ServerSaveData FMFKHDPKLOC { get; set; } // 0x10 FDDDKGAMLLB AAMOPGKKGEI OBEALILDFEM
	public BBHNACPENDM_ServerSaveData MNJHBCIIHED_PrevServerData { get; private set; } // 0x14 JHPFMKPOIOC KBOFNPLNBOA ICKBCAJFDOM
	public bool LNAHEIEIBOI_Initialized { get; set; } // 0x18 INBPPDMFOAD FHEAKKHAAPF GOEIEJFPLOG
	public bool KONHMOLMOCI { get; private set; } // 0x19 DEDJLABCBOH MDEMPMONBLE NAALAEJIEAI
	public bool BLCDJDJJBHC { get; set; } // 0x1A BPLABMJENOI AAIACPOJKKO DNLNBFEHCKD
	public FKAFHLIDAFD LGBMDHOLOIF { get; private set; }  // 0x44 ABKMJCPPEJA EEIKGFMAOGO MPNANFEAALL
	// [ObsoleteAttribute] // RVA: 0x749814 Offset: 0x749814 VA: 0x749814
	// public FKAFHLIDAFD PDKHANKAPCI { get; private set; } // KGBNBKPMKDG 0xFFA2F8 PJNPGHDEINA 0xFFA300
	// [ObsoleteAttribute] // RVA: 0x749848 Offset: 0x749848 VA: 0x749848
	// public FKAFHLIDAFD AEBNIAFEIHC { get; private set; } // CJMMAKNNLGO 0xFF3E08 GGDKCIHDPGP 0xFFA308
	public AIFIANALLPB KPFKKDDOHCN { get; private set; } // 0x48 CNBPHMJCOGK EJCOPFKKFJA EEAFNGBEHHJ
	public PIGBKEIAMPE_FriendManager CHNJPFCKFOI_FriendManager { get; private set; } // 0x4C NMPHJGJOODM PPHAPIPAEOJ IDDONPAJKCN
	public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_Currencies { get; private set; } // 0x50 KCLAFENGONP PCHMJADGBEI MFONKBBKMIJ
	public MCGNOFMAPBJ BPLOEAHOPFI_StaminaUpdater { get; private set; } // 0x54 KKOIOMJKJJK IFLOIFCLBFJ NGMKCJOPEGH
	public JKNNIKNKMNJ IOCLFHJLHLE_IntimacyUpdater { get; private set; } // 0x58 GIKMDNCDMAA NJGEOHOLOOB CBKHODJCHHG
	public int[] PAAMLFNPJGJ_IntimacyDivaPresentLeft { get; private set; } // 0x5C LJCBJICKPNL CPKABGODIPL NLCNIFNICIL
	public int[] EDGFGECLOHE_IntimacyDivaTouchCount { get; private set; }  // 0x60 GAKFDLBABCG NHOJDHIBMOF AILLCMLGNHD
	public long JNCBOBPPHHB_IntimacyTensionTime { get; private set; } // 0x68 BJMLKCHCLGM JBGCIPFPNII GAPBDDCDGDF
	public long PKBOFLOJNIJ { get; private set; } // 0x70 DPNBIKNOLMF IPIGNFGMJKH OPKPOAHJAPD
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
	// public int NBJOCMAJLPK(int APHNELOFGAK) { }

	// // RVA: 0xFFA5B0 Offset: 0xFFA5B0 VA: 0xFFA5B0
	public int NOJDLFKKMDD(int MHFBCINOJEE)
	{
		TodoLogger.Log(0, "NOJDLFKKMDD");
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
	// public bool FDFDGEMMKKJ() { }

	// // RVA: 0xFFA95C Offset: 0xFFA95C VA: 0xFFA95C
	// public bool EELJBMHKHNP(int NAPIAEHGKGP) { }

	// // RVA: 0xFFA9BC Offset: 0xFFA9BC VA: 0xFFA9BC
	// public int CIPHAHDGGPH() { }

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
	// public void DJICHKCLMCD(List<KPPFJJJAFFC> PIPMPLFMCPL) { }

	// // RVA: 0xFFB088 Offset: 0xFFB088 VA: 0xFFB088
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		AHEFHIMGIBI_ServerSave = new BBHNACPENDM_ServerSaveData();
		AHEFHIMGIBI_ServerSave.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO.FKNGHCNOEHO/*1*/;
		CCNKAKCBBDJ = new BBHNACPENDM_ServerSaveData();
		CCNKAKCBBDJ.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO.AFGALHECDIJ/*3*/;
		FMFKHDPKLOC = new BBHNACPENDM_ServerSaveData();
		CCNKAKCBBDJ.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO.GGEELFGJAMP/*2*/;
		MNJHBCIIHED_PrevServerData = new BBHNACPENDM_ServerSaveData();
		CCNKAKCBBDJ.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO.LPKPFMHEKEM/*4*/;
		KPFKKDDOHCN = new AIFIANALLPB();
		CHNJPFCKFOI_FriendManager = new PIGBKEIAMPE_FriendManager();
		LNAHEIEIBOI_Initialized = false;
		KONHMOLMOCI = false;
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
		PKBOFLOJNIJ = 0;
		MMPBPOIFDAF_Scene.PMKOFEIONEG.FBGGEFFJJHB = (int)Utility.GetCurrentUnixTime() * 0x87727;
		JNMFKOHFAFB_PublicStatus.KNHIPBADANI.FBGGEFFJJHB = (int)MMPBPOIFDAF_Scene.PMKOFEIONEG.FBGGEFFJJHB ^ 0x7651;
		LGBMDHOLOIF = new FKAFHLIDAFD();
		LGBMDHOLOIF = new FKAFHLIDAFD(); // are they drunk ?
	}

	// // RVA: 0xFFB4B0 Offset: 0xFFB4B0 VA: 0xFFB4B0
	public void BAGMHFKPFIF_Update()
	{
		if(!NKGJPJPHLIF.HHCJCDFCLOB.PECPLBANLBN)
			return;

		if(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester != null)
		{
			BPLOEAHOPFI_StaminaUpdater.FJDBNGEPKHL_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			IOCLFHJLHLE_IntimacyUpdater.FJDBNGEPKHL_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}
		PDKNJAEGNIL();
		PDKNJAEGNIL(LGBMDHOLOIF);
		PDKNJAEGNIL(LGBMDHOLOIF);
		TodoLogger.Log(0, "TODO");
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
		//UnityEngine.Debug.Log("Enter ODDEPBIJHOE_Coroutine_Load");

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

		UnityEngine.Debug.Log(str.ToString());
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
			UnityEngine.Debug.LogError("Exit Error ODDEPBIJHOE_Coroutine_Load");
			yield break;
		}
		// L 379
		PKBOFLOJNIJ = BPOJOBICBAC.NFEAMMJIMPG_Result.IFNLEKOILPM_UpdatedAt;
		ECFNAOCFKKN = PKBOFLOJNIJ;
		HAELBFCGHMB = BPOJOBICBAC.NFEAMMJIMPG_Result.MLGKDBJLNBM_DataStatus == 2;
		BPOJOBICBAC = null;
		AHEFHIMGIBI_ServerSave.NEBDDPDPAKJ(JKJEFPNIPFO);
		FMFKHDPKLOC.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
		CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_ServerSave);
		PJKLMCGEJMK.DALFMJFKCGJ = AHEFHIMGIBI_ServerSave.MCKEOKFMLAH;

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
			UnityEngine.Debug.LogError("Exit Error ODDEPBIJHOE_Coroutine_Load");
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
					if(CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsSuccess)
					{
						int friendLimit = DLMOKNDEMMB.FMPEMFPLPDA_Exp.PCJACJANGCA_GetFriendForLevel(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level);
						if(friendLimit != CHNJPFCKFOI_FriendManager.JPEIBHJIHPI_FriendLimit)
						{
							CHNJPFCKFOI_FriendManager.PGPLAOGALHD_SetFriendLimit(friendLimit, null, null);
							//LAB_01011bec:
							while(!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsSuccess)
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
										//UnityEngine.Debug.Log("Exit ODDEPBIJHOE_Coroutine_Load");
										yield break;
									}
									
									LNAHEIEIBOI_Initialized = true;
									if(BHFHGFKBOHH_OnSuccess != null)
									{
										BHFHGFKBOHH_OnSuccess();
									}
									//UnityEngine.Debug.LogError("Exit ODDEPBIJHOE_Coroutine_Load");
									yield break;
								}
								//goto LAB_01011cb0;
								if(MOBEEPPKFLG_OnError != null)
								{
									MOBEEPPKFLG_OnError();
								}
								UnityEngine.Debug.LogError("Exit Error ODDEPBIJHOE_Coroutine_Load");
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

		//UnityEngine.Debug.Log("Exit ODDEPBIJHOE_Coroutine_Load");
	}

	// // RVA: 0xFFB930 Offset: 0xFFB930 VA: 0xFFB930
	// public void CJMDNPCBEJF(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool JKJEFPNIPFO = False) { }

	// // RVA: 0xFFBA78 Offset: 0xFFBA78 VA: 0xFFBA78
	// public void PCIBGCGCNOH(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool JKJEFPNIPFO = False) { }

	// // RVA: 0xFFBA90 Offset: 0xFFBA90 VA: 0xFFBA90
	// public void BKKGIOABILM(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool JKJEFPNIPFO = False) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7BD0 Offset: 0x6B7BD0 VA: 0x6B7BD0
	// // RVA: 0xFFB9B8 Offset: 0xFFB9B8 VA: 0xFFB9B8
	// private IEnumerator MMAECJEKMJK_LoadDecoData(FKAFHLIDAFD JEBPDGCBPJC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool JKJEFPNIPFO) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7C48 Offset: 0x6B7C48 VA: 0x6B7C48
	// // RVA: 0xFFBAC8 Offset: 0xFFBAC8 VA: 0xFFBAC8
	private IEnumerator EKKCGGHIFEG_Coroutine_GetFriendCounts(DJBHIFLHJLK MOBEEPPKFLG_OnError)
	{
		//UnityEngine.Debug.Log("Enter EKKCGGHIFEG_GetFriendCounts");
		//0x1010240
		CHNJPFCKFOI_FriendManager.PFJBNPIBFMO_GetReceivedRequests(null, (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x100A39C
			MOBEEPPKFLG_OnError();
		}, false);
		while (!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsSuccess)
			yield return null;
		CHNJPFCKFOI_FriendManager.BMJANOADDCC_GetFriends(null, (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x100A3C8
			MOBEEPPKFLG_OnError();
		}, false);
		while (!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsSuccess)
			yield return null;
		CHNJPFCKFOI_FriendManager.MEJHFCBFPED_GetSentRequests(null, (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x100A3F4
			MOBEEPPKFLG_OnError();
		}, false);
		while (!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsSuccess)
			yield return null;
		//UnityEngine.Debug.Log("Exit EKKCGGHIFEG_GetFriendCounts");
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
			req.GJAEJFLLKGC = 1;
			req.DOMFHDPMCCO(JEHOEIKANFL, JCJDPGMKJAJ, AMOMNBEAHBF);
			return req;
		}, BHFHGFKBOHH, MOBEEPPKFLG);
	}

	// // RVA: 0xFFC6E4 Offset: 0xFFC6E4 VA: 0xFFC6E4
	public bool LOOCNGEPAMI(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, int HJBLIJOGNPC)
	{
		TodoLogger.Log(0, "LOOCNGEPAMI");
		PMHLJAIGBGK = new List<string>();
		FMEDFGOMNBK = new List<int>();
		KDLBAGCENNC = new BBHNACPENDM_ServerSaveData.EMHDCKMFCGE(null, null, false, 0);
		BHFHGFKBOHH();
		return false;
	}

	// // RVA: 0xFFC7CC Offset: 0xFFC7CC VA: 0xFFC7CC
	// public bool FAMAFKMHFAK(CIOECGOMILE.PIIFKPKIOOB JDEPBIPCMAL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xFFBFF8 Offset: 0xFFBFF8 VA: 0xFFBFF8
	private bool ACEDPNCIGDG(PIIFKPKIOOB JDEPBIPCMAL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		if(LNAHEIEIBOI_Initialized)
		{
			if (KONHMOLMOCI)
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
								KONHMOLMOCI = true;
								PMHLJAIGBGK = null;
								FMEDFGOMNBK = null;
								KDLBAGCENNC = null;
								if(!JHOKIPPIHII)
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
								KONHMOLMOCI = false;
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
			KONHMOLMOCI = false;
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
		KONHMOLMOCI = false;
	}

	// // RVA: 0xFF3E10 Offset: 0xFF3E10 VA: 0xFF3E10
	// public bool OEAMJGPAIGP(FKAFHLIDAFD JEBPDGCBPJC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, List<long> AMOMNBEAHBF) { }

	// // RVA: 0xFFC990 Offset: 0xFFC990 VA: 0xFFC990
	// public bool OEAMJGPAIGP(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, List<long> AMOMNBEAHBF) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7DB0 Offset: 0x6B7DB0 VA: 0x6B7DB0
	// // RVA: 0xFFD094 Offset: 0xFFD094 VA: 0xFFD094
	// private IEnumerator CAJOAKIOCEF_SaveDecoData(FKAFHLIDAFD JEBPDGCBPJC, GGKHIHFPKDH COJNCNGHIJC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xFFD168 Offset: 0xFFD168 VA: 0xFFD168
	public bool BMKEBEJJKBE(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, ulong FIBPIDELFBB)
	{
		EBEGGFECPOE.JCHLONCMPAJ();
		if(LNAHEIEIBOI_Initialized)
		{
			if (KONHMOLMOCI)
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
								TodoLogger.Log(0, "BMKEBEJJKBE Episode");
							}
						}
						bool b2 = false;
						if ((FIBPIDELFBB & 4) != 0)
						{
							//678
							TodoLogger.Log(0, "BMKEBEJJKBE Episode");
						}
						if ((FIBPIDELFBB & 8) != 0)
						{
							//950
							TodoLogger.Log(0, "BMKEBEJJKBE Episode");
						}
						if ((FIBPIDELFBB & 0x1c7fffffff0) != 0)
						{
							//1289
							TodoLogger.Log(0, "BMKEBEJJKBE Episode");
						}
						if ((FIBPIDELFBB & 0x800000000) != 0)
						{
							//1646
							TodoLogger.Log(0, "BMKEBEJJKBE Episode");
						}
						if ((FIBPIDELFBB & 0x1000000000) != 0)
						{
							//1876
							TodoLogger.Log(0, "BMKEBEJJKBE Episode");
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
								KONHMOLMOCI = true;
								PMHLJAIGBGK = null;
								FMEDFGOMNBK = null;
								KDLBAGCENNC = null;
								if(JHOKIPPIHII)
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
									KONHMOLMOCI = false;
									//LAB_01000bc8;
								}
								else
								{
									if(ls.Count > 0)
									{
										MOMPDFMMICK_ClaimAchievementPrizesAndSave req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new MOMPDFMMICK_ClaimAchievementPrizesAndSave());
										req.GJAEJFLLKGC = 1;
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
											savereq.GJAEJFLLKGC = 1;
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
			ECFNAOCFKKN = COJNCNGHIJC.NFEAMMJIMPG.IFNLEKOILPM;
			HLBJOJBALIG(COJNCNGHIJC.HHIHCJKLJFF_Names);
			KPFKKDDOHCN.ECFNAOCFKKN_Date = 0;
			NKGJPJPHLIF.HHCJCDFCLOB.OLDKENOLHLL = 0;
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		}
		KONHMOLMOCI = false;
	}

	// // RVA: 0x1001024 Offset: 0x1001024 VA: 0x1001024
	// public void PKKCKFCLACK(GJDFHLBONOL OKGGJOOCLHI, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK JEMKODBAOEP, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x1001104 Offset: 0x1001104 VA: 0x1001104
	// public void PKKCKFCLACK(List<GJDFHLBONOL> PJJFEAHIPGL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK JEMKODBAOEP, DJBHIFLHJLK MOBEEPPKFLG, bool MBJKHOOMAFE = False) { }

	// // RVA: 0x1001458 Offset: 0x1001458 VA: 0x1001458
	// private List<GJDFHLBONOL> FJPIIDAEMHC(List<GJDFHLBONOL> GPBJHKLFCEP, int INDDJNMPONH) { }

	// // RVA: 0x1001608 Offset: 0x1001608 VA: 0x1001608
	// private bool OBOHGFNECBG(List<GJDFHLBONOL> PJJFEAHIPGL, long JHNMKKNEENE = 0) { }

	// // RVA: 0x100179C Offset: 0x100179C VA: 0x100179C
	// public bool HFCOBGMDOGG() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7EA0 Offset: 0x6B7EA0 VA: 0x6B7EA0
	// // RVA: 0x100136C Offset: 0x100136C VA: 0x100136C
	// private IEnumerator PBCOEDMBDBE_ReceiveInventory(List<GJDFHLBONOL> PJJFEAHIPGL, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK JEMKODBAOEP, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x10017A4 Offset: 0x10017A4 VA: 0x10017A4
	// public int KAJNAMKKKBN(List<GJDFHLBONOL> PJJFEAHIPGL) { }

	// // RVA: 0x1001E5C Offset: 0x1001E5C VA: 0x1001E5C
	// private void GDHOKEOHABL(CACGCMBKHDI KFBCOGJKEJP) { }

	// // RVA: 0x1001FF8 Offset: 0x1001FF8 VA: 0x1001FF8
	// private bool CIJGKKBOGPB(List<GJDFHLBONOL> PJJFEAHIPGL) { }

	// // RVA: 0x1002388 Offset: 0x1002388 VA: 0x1002388
	// private void HKMNAICEDNE(CACGCMBKHDI KFBCOGJKEJP) { }

	// // RVA: 0x10025B4 Offset: 0x10025B4 VA: 0x10025B4
	// private void GOPADPOIKNP(CACGCMBKHDI KFBCOGJKEJP) { }

	// // RVA: 0x10025C0 Offset: 0x10025C0 VA: 0x10025C0
	// public string PDLEOKCJDAK() { }

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
		NKOBMDPHNGP_EventRaidLobby lobby = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD.BCKENOKGLIJ/*9*/) as NKOBMDPHNGP_EventRaidLobby;
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
			BPLOEAHOPFI_StaminaUpdater.DCBENCMNOGO_GainStamina = staminaGain;
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
	// public void GNNHEDHCJAE(EKLNMHFCAOI.FKGCBLHOOCL INDDJNMPONH, int EIDOGCOPHII, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK MOBEEPPKFLG, string JKJDGDLAIME = "") { }

	// // RVA: 0x100336C Offset: 0x100336C VA: 0x100336C
	// public void DNJKDCIAHMO(EKLNMHFCAOI.FKGCBLHOOCL INDDJNMPONH, int EIDOGCOPHII, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK MOBEEPPKFLG, string JKJDGDLAIME = "", CIOECGOMILE.LIILJGHKIDL AAIOPEICNNB = 0) { }

	// // RVA: 0x100309C Offset: 0x100309C VA: 0x100309C
	// private void CJBHFDHBHEP(CIOECGOMILE.LKBJIGBNIAD NNCGBLONBMB, EKLNMHFCAOI.FKGCBLHOOCL INDDJNMPONH, int EIDOGCOPHII, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK MOBEEPPKFLG, string JKJDGDLAIME = "", CIOECGOMILE.LIILJGHKIDL AAIOPEICNNB = 0) { }

	// // RVA: 0x1003670 Offset: 0x1003670 VA: 0x1003670
	// private int BOHEFPHNODA(EKLNMHFCAOI.FKGCBLHOOCL INDDJNMPONH, int KIJAPOFAGPN) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7F18 Offset: 0x6B7F18 VA: 0x6B7F18
	// // RVA: 0x10034FC Offset: 0x10034FC VA: 0x10034FC
	// private IEnumerator GBKDCGBHLCD_StaminaHeal_FreeVC(CIOECGOMILE.LKBJIGBNIAD NNCGBLONBMB, EKLNMHFCAOI.FKGCBLHOOCL INDDJNMPONH, int EIDOGCOPHII, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK MOBEEPPKFLG, string JKJDGDLAIME, CIOECGOMILE.LIILJGHKIDL AAIOPEICNNB) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7F90 Offset: 0x6B7F90 VA: 0x6B7F90
	// // RVA: 0x10033BC Offset: 0x10033BC VA: 0x10033BC
	// private IEnumerator IGOJFNIDAEE_StaminaHeal_PaidVC(CIOECGOMILE.LKBJIGBNIAD NNCGBLONBMB, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK MOBEEPPKFLG, string JKJDGDLAIME, CIOECGOMILE.LIILJGHKIDL AAIOPEICNNB) { }

	// // RVA: 0x1003830 Offset: 0x1003830 VA: 0x1003830
	public void PCMPDIMCBJM_UpdateIntimacyInfo()
	{
		if(AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common != null)
		{
			IOCLFHJLHLE_IntimacyUpdater.DCBENCMNOGO_Gain = 5;
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
	// public bool MLEPCANKIIE(int AHHJLDLAPAN, int HMFFHLPNMPH) { }

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
	// public void DLFDPCDKHOB(LOBDIAABMKG EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI, CDOPFBOHDEF BHFHGFKBOHH, DJBHIFLHJLK HDFGHFOCHKE, DJBHIFLHJLK JGKOLBLPMPG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B8008 Offset: 0x6B8008 VA: 0x6B8008
	// // RVA: 0x1004EE8 Offset: 0x1004EE8 VA: 0x1004EE8
	// private IEnumerator GPDPDNJMDNJ_DrawLotByPaidVC_AfterSave(LOBDIAABMKG EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI, List<ANGEDJODMKO> DMOHAHJDPAD, CDOPFBOHDEF BHFHGFKBOHH, DJBHIFLHJLK JGKOLBLPMPG, IAPIDHGIEED OMOEKOCNICP, IAPIDHGIEED ONNIHHLHLDP) { }

	// // RVA: 0x1005050 Offset: 0x1005050 VA: 0x1005050
	// public void JBOAMLIDAKF(LOBDIAABMKG EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI, CDOPFBOHDEF BHFHGFKBOHH, DJBHIFLHJLK HDFGHFOCHKE, DJBHIFLHJLK JGKOLBLPMPG, bool IAHLNPMFJMH = False) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B8080 Offset: 0x6B8080 VA: 0x6B8080
	// // RVA: 0x1005C2C Offset: 0x1005C2C VA: 0x1005C2C
	// private IEnumerator GEOMKFMLDPL_DrawLotFreeVC_AfterSave(LOBDIAABMKG EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI, List<MFDJIFIIPJD> BODJIDOHAHF, CDOPFBOHDEF BHFHGFKBOHH, DJBHIFLHJLK JGKOLBLPMPG, bool IAHLNPMFJMH) { }

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
					if(prod.OPFGFINHFCE_Name.Contains(FNBPIOCLODC_Continue))
					{
						CDPHPAIAFDG_Continue_ProdId = prod.PPFNGGCBJKC_Id;
						BPPGDBHGMDA_Continue_Price = prod.NPPGKNGIFGK_Price;
					}
					else
					{
						if(prod.OPFGFINHFCE_Name.Contains(CPBCGKAKDIA_Stamina))
						{
							KMJLGBJBOAK_StaminaProdId = prod.PPFNGGCBJKC_Id; // ??
						}
						else
						{
							if (!prod.OPFGFINHFCE_Name.Contains(OHPLHJNCLPH_Energy))
							{
								if (prod.OPFGFINHFCE_Name.Contains(FBDLJDOLMNI_Vop))
								{
									MCLKCGMIKNF_Vop_ProdId = prod.PPFNGGCBJKC_Id;
									DMEHACGEOFK_Vop_Price = prod.NPPGKNGIFGK_Price;
								}
								else
								{
									if (prod.OPFGFINHFCE_Name.Contains(AJICGGJJNCA_Ap))
									{
										string s = prod.OPFGFINHFCE_Name.Replace(JpStringLiterals.StringLiteral_9798, "");
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
			TodoLogger.Log(0, "MOBEEPPKFLG_OnFail");
		};
	}

	// // RVA: 0x1005F44 Offset: 0x1005F44 VA: 0x1005F44
	// public void OKGLDKFLGGK(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG, int GHBPLHBNMBK, int AKNELONELJK) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B80F8 Offset: 0x6B80F8 VA: 0x6B80F8
	// // RVA: 0x10060CC Offset: 0x10060CC VA: 0x10060CC
	// private IEnumerator INJLKHHHMCI_InGameContinueByPaidVC(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG, int GHBPLHBNMBK, int AKNELONELJK) { }

	// // RVA: 0x10061FC Offset: 0x10061FC VA: 0x10061FC
	// public void JLLHLFDGCKF(int APHNELOFGAK, KBPDNHOKEKD BBABCIMFOPD, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B8170 Offset: 0x6B8170 VA: 0x6B8170
	// // RVA: 0x100639C Offset: 0x100639C VA: 0x100639C
	// private IEnumerator MKOCPKDBNJC_ActivateMonthlyPassByPaidVC(int APHNELOFGAK, KBPDNHOKEKD BBABCIMFOPD, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x10064CC Offset: 0x10064CC VA: 0x10064CC
	// public void ELGMEAEDOHI(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG, BOPFPIHGJMD.MLBMHDCCGHI FGHGMHPNEMG, int MLDPDLPHJPM, int APPJOBEMLBE) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B81E8 Offset: 0x6B81E8 VA: 0x6B81E8
	// // RVA: 0x100665C Offset: 0x100665C VA: 0x100665C
	// private IEnumerator LJJAPOIKAMA_OfferFastCompleteByPaidVC(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK MOBEEPPKFLG, BOPFPIHGJMD.MLBMHDCCGHI FGHGMHPNEMG, int MLDPDLPHJPM, int APPJOBEMLBE) { }

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
		TodoLogger.Log(0, "EHNDCODOBBL_Falsification");
		yield return null;
	}

	// // RVA: 0x10067C4 Offset: 0x10067C4 VA: 0x10067C4
	// public bool HNDJBAAAHDO(ref int IBAKPKKEDJM, ref int BAOFEFFADPD) { }

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
		TodoLogger.Log(0, "DEHKLOLHKID_Coroutine_ReSave");
		yield return null;
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
				if(it.HJAFPEBIBOP > 0)
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
					return l[i].CPGFOBNKKBF == GHPLINIACBB;
				});
				if(idx < 0 && l[i].CPGFOBNKKBF != 0)
				{
					res.Add(l[i].CPGFOBNKKBF);
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
	// public int IIMNMNGEPIJ() { }

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
	// public int GGJMFEGHGIA() { }

	// // RVA: 0x1008A08 Offset: 0x1008A08 VA: 0x1008A08
	public int KJBENABMBCA(long KNCKIJBOODM)
	{
		TodoLogger.Log(0, "KJBENABMBCA");
		return 10;
	}

	// // RVA: 0x1008A74 Offset: 0x1008A74 VA: 0x1008A74
	// public bool LNCGIOILBDD(int HMFFHLPNMPH, long KNCKIJBOODM) { }

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
		TodoLogger.Log(0, "GJACBNJHDHI");
		return true;
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

	// [CompilerGeneratedAttribute] // RVA: 0x6B8350 Offset: 0x6B8350 VA: 0x6B8350
	// // RVA: 0x1009434 Offset: 0x1009434 VA: 0x1009434
	// private void <OnSuccessReceiveInventory_VC>b__156_0(GJDFHLBONOL AIMLPJOGPID) { }
}
