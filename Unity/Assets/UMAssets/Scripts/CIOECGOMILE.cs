using System.Text;
using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using XeSys;
using XeApp.Game;
using XeApp.Game.Gacha;
using UnityEngine.Localization.SmartFormat;

public delegate void CDOPFBOHDEF(List<MFDJIFIIPJD> _HBHMAKNGKFK_items);

// namespace XeApp.Game.Net
[System.Obsolete()]
public class CIOECGOMILE {}
public class CIOECGOMILE_NetPlayerDataManager
{
	private enum LKBJIGBNIAD_RestoreType
	{
		JOHJEOPEOBA_0_Stamina = 0,
		MHELGOODGCO_1_Ap = 1,
	}

	public enum LIILJGHKIDL_RestoreButtonType
	{
		HJNNKCMLGFL_0_None = 0,
		HLAJMFGDAHP_1_PaidS = 1,
		FPNFLAAECMK_2_PaidL = 2,
		IOPLLOIHMJC_3_Last = 3,
	}

	public delegate void LHGEIKBCBBP(List<string> _OHNJJIMGKGK_Names);
	public delegate CACGCMBKHDI_NetBaseAction PIIFKPKIOOB(PJKLMCGEJMK_NetActionManager _CPHFEPHDJIB_ServerRequester, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE JEHOEIKANFL, string _JCJDPGMKJAJ_PlayerData);

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
	public long ECFNAOCFKKN_LastDate; // 0x78
	public bool HAELBFCGHMB; // 0x80
	public int NPOPAOCGIJN; // 0x84
	public static bool BDNBIEMJMCD = false; // 0x5
	public JKNGJFOBADP JANMJPOKLFL_InventoryUtil = new JKNGJFOBADP(); // 0x88
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

	public static CIOECGOMILE_NetPlayerDataManager HHCJCDFCLOB_Instance { get; private set; }  // 0x0 LGMPACEDIJF_bgs // NKACBOEHELJ_bgs OKPMHKNCNAL_bgs
	public BBHNACPENDM_ServerSaveData AHEFHIMGIBI_PlayerData { get; private set; }  // 0x8 LCHHPGMCKJD_bgs // GNMGJMDJEGI_bgs LGLGNHAMNIK_bgs
	private BBHNACPENDM_ServerSaveData CCNKAKCBBDJ { get; set; } // 0xC MOMIOKHCMKH_bgs GHMKOMEKBFO_bgs KKOICOJPENH_bgs
	public BBHNACPENDM_ServerSaveData FMFKHDPKLOC { get; set; } // 0x10 FDDDKGAMLLB_bgs AAMOPGKKGEI_bgs OBEALILDFEM_bgs
	public BBHNACPENDM_ServerSaveData MNJHBCIIHED_PrevServerData { get; private set; } // 0x14 JHPFMKPOIOC_bgs KBOFNPLNBOA_bgs ICKBCAJFDOM_bgs
	public bool LNAHEIEIBOI_Initialized { get; set; } // 0x18 INBPPDMFOAD_bgs FHEAKKHAAPF_bgs GOEIEJFPLOG_bgs
	public bool KONHMOLMOCI_IsSaving { get; private set; } // 0x19 DEDJLABCBOH_bgs MDEMPMONBLE_bgs NAALAEJIEAI_bgs
	public bool BLCDJDJJBHC { get; set; } // 0x1A BPLABMJENOI_bgs AAIACPOJKKO_bgs DNLNBFEHCKD_bgs
	public FKAFHLIDAFD LGBMDHOLOIF_decoPlayerData { get; private set; }  // 0x44 ABKMJCPPEJA_bgs EEIKGFMAOGO_bgs MPNANFEAALL_bgs
	[Obsolete("alias of \'decoPlayerData\'")] // RVA: 0x749814 Offset: 0x749814 VA: 0x749814
	public FKAFHLIDAFD PDKHANKAPCI_DecoPublicSet { get { return LGBMDHOLOIF_decoPlayerData; } private set { LGBMDHOLOIF_decoPlayerData = value; } } //KGBNBKPMKDG_bgs 0xFFA2F8 PJNPGHDEINA_bgs 0xFFA300
	[Obsolete("alias of \'decoPlayerData\'")] // RVA: 0x749848 Offset: 0x749848 VA: 0x749848
	public FKAFHLIDAFD AEBNIAFEIHC { get { return LGBMDHOLOIF_decoPlayerData; } private set { LGBMDHOLOIF_decoPlayerData = value; } } // CJMMAKNNLGO_bgs 0xFF3E08 GGDKCIHDPGP_bgs 0xFFA308
	public AIFIANALLPB_NetInventoryManager KPFKKDDOHCN { get; private set; } // 0x48 CNBPHMJCOGK_bgs EJCOPFKKFJA_bgs EEAFNGBEHHJ_bgs
	public PIGBKEIAMPE_NetFriendManager CHNJPFCKFOI_FriendManager { get; private set; } // 0x4C NMPHJGJOODM_bgs PPHAPIPAEOJ_bgs IDDONPAJKCN_bgs
	public List<MCKCJMLOAFP_CurrencyInfo> BBEPLKNMICJ_balances { get; private set; } // 0x50 KCLAFENGONP_bgs PCHMJADGBEI_bgs MFONKBBKMIJ_bgs
	public MCGNOFMAPBJ BPLOEAHOPFI_stamina { get; private set; } // 0x54 KKOIOMJKJJK_bgs IFLOIFCLBFJ_get_stamina NGMKCJOPEGH_set_stamina
	public JKNNIKNKMNJ IOCLFHJLHLE_IntimacyUpdater { get; private set; } // 0x58 GIKMDNCDMAA_bgs NJGEOHOLOOB_bgs CBKHODJCHHG_bgs
	public int[] PAAMLFNPJGJ_IntimacyDivaPresentLeft { get; private set; } // 0x5C LJCBJICKPNL_bgs CPKABGODIPL_bgs NLCNIFNICIL_bgs
	public int[] EDGFGECLOHE_IntimacyDivaTouchCount { get; private set; }  // 0x60 GAKFDLBABCG_bgs NHOJDHIBMOF_bgs AILLCMLGNHD_bgs
	public long JNCBOBPPHHB_IntimacyTensionTime { get; private set; } // 0x68 BJMLKCHCLGM_bgs JBGCIPFPNII_bgs GAPBDDCDGDF_bgs
	public long PKBOFLOJNIJ_LastLoginTime { get; private set; } // 0x70 DPNBIKNOLMF_bgs IPIGNFGMJKH_bgs OPKPOAHJAPD_bgs
	// public bool HBHCAGLPJOL { get; } // ???

	// // RVA: 0xFFA340 Offset: 0xFFA340 VA: 0xFFA340
	public int DEAPMEIDCGC_GetTotalPaidCurrency()
	{
		MCKCJMLOAFP_CurrencyInfo cur = BBEPLKNMICJ_balances.Find((MCKCJMLOAFP_CurrencyInfo _BNKHBCBJBKI_b) =>
		{
			//0x100A11C
			return _BNKHBCBJBKI_b.PPFNGGCBJKC_id == 1001;
		});
		if (cur == null)
			return 0;
		return cur.BDLNMOIOMHK_total;
	}

	// // RVA: 0xFFA4A4 Offset: 0xFFA4A4 VA: 0xFFA4A4
	public int NBJOCMAJLPK_GetTotalCurrency(int _APHNELOFGAK_CurrencyId)
	{
		MCKCJMLOAFP_CurrencyInfo m = BBEPLKNMICJ_balances.Find((MCKCJMLOAFP_CurrencyInfo _BNKHBCBJBKI_b) =>
		{
			//0x100CD54
			return _BNKHBCBJBKI_b.PPFNGGCBJKC_id == _APHNELOFGAK_CurrencyId;
		});
		if (m == null)
			return 0;
		return m.BDLNMOIOMHK_total;
	}

	// // RVA: 0xFFA5B0 Offset: 0xFFA5B0 VA: 0xFFA5B0
	public int NOJDLFKKMDD_GetCurrencyTotal(int _MHFBCINOJEE_Num)
	{
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH db = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[_MHFBCINOJEE_Num - 1];
			MCKCJMLOAFP_CurrencyInfo m = BBEPLKNMICJ_balances.Find((MCKCJMLOAFP_CurrencyInfo _BNKHBCBJBKI_b) =>
			{
				//0x100CD8C
				return _BNKHBCBJBKI_b.PPFNGGCBJKC_id == db.CPGFOBNKKBF_CurrencyId;
			});
			if(m != null)
			{
				return m.BDLNMOIOMHK_total;
			}
		}
		return 0;
	}

	// // RVA: 0xFFA7DC Offset: 0xFFA7DC VA: 0xFFA7DC
	public MCKCJMLOAFP_CurrencyInfo JBEKNFEGFFI()
	{
		return BBEPLKNMICJ_balances.Find((MCKCJMLOAFP_CurrencyInfo _BNKHBCBJBKI_b) =>
		{
			//0x100A150
			return _BNKHBCBJBKI_b.PPFNGGCBJKC_id == 1001;
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
	public int[] CBOJGDKGCEF_GetApPrice()
	{
		return ELJNINICAIF_Ap_Prices;
	}

	// // RVA: 0xFFAA3C Offset: 0xFFAA3C VA: 0xFFAA3C
	private void HLBJOJBALIG(List<string> _OHNJJIMGKGK_Names)
	{
		for(int i = 0; i < BJCPJPLPDIH.Count; i++)
		{
			BJCPJPLPDIH[i].Invoke(_OHNJJIMGKGK_Names);
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
	public void DJICHKCLMCD_UpdateCurrencies(List<MCKCJMLOAFP_CurrencyInfo> _PIPMPLFMCPL_CurrenciesInfo)
	{
		if(_PIPMPLFMCPL_CurrenciesInfo != null)
		{
			for(int i = 0; i < _PIPMPLFMCPL_CurrenciesInfo.Count; i++)
			{
				MCKCJMLOAFP_CurrencyInfo currency = BBEPLKNMICJ_balances.Find((MCKCJMLOAFP_CurrencyInfo EABDEAANPOE) =>
				{
					//0x100A2B4
					return EABDEAANPOE.PPFNGGCBJKC_id == _PIPMPLFMCPL_CurrenciesInfo[i].PPFNGGCBJKC_id;
				});
				if(currency == null)
				{
					BBEPLKNMICJ_balances.Add(_PIPMPLFMCPL_CurrenciesInfo[i]);
				}
				else
				{
					currency.KCKBGALKNMA_paid = _PIPMPLFMCPL_CurrenciesInfo[i].KCKBGALKNMA_paid;
					currency.BDLNMOIOMHK_total = _PIPMPLFMCPL_CurrenciesInfo[i].BDLNMOIOMHK_total;
					currency.JLNEMPJICEH_free = _PIPMPLFMCPL_CurrenciesInfo[i].JLNEMPJICEH_free;
				}
			}
		}
	}

	// // RVA: 0xFFAE44 Offset: 0xFFAE44 VA: 0xFFAE44
	public void DJICHKCLMCD_UpdateCurrencies(List<KPPFJJJAFFC> _PIPMPLFMCPL_CurrenciesInfo)
	{
		for(int i = 0; i < _PIPMPLFMCPL_CurrenciesInfo.Count; i++)
		{
			KPPFJJJAFFC BNKHBCBJBKI_b = _PIPMPLFMCPL_CurrenciesInfo[i];
			MCKCJMLOAFP_CurrencyInfo m = BBEPLKNMICJ_balances.Find((MCKCJMLOAFP_CurrencyInfo EABDEAANPOE) =>
			{
				//0x100A300
				return EABDEAANPOE.PPFNGGCBJKC_id == BNKHBCBJBKI_b.PPFNGGCBJKC_id;
			});
			if(m == null)
			{
				BBEPLKNMICJ_balances.Add(BNKHBCBJBKI_b);
			}
			else
			{
				m.KCKBGALKNMA_paid = BNKHBCBJBKI_b.KCKBGALKNMA_paid;
				m.BDLNMOIOMHK_total = BNKHBCBJBKI_b.BDLNMOIOMHK_total;
				m.JLNEMPJICEH_free = BNKHBCBJBKI_b.JLNEMPJICEH_free;
			}
		}
	}

	// // RVA: 0xFFB088 Offset: 0xFFB088 VA: 0xFFB088
	public void IJBGPAENLJA_OnAwake(MonoBehaviour _DANMJLOBLIE_mb)
	{
		HHCJCDFCLOB_Instance = this;
		AHEFHIMGIBI_PlayerData = new BBHNACPENDM_ServerSaveData();
		AHEFHIMGIBI_PlayerData.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO_DataType.FKNGHCNOEHO_1_Local/*1*/;
		CCNKAKCBBDJ = new BBHNACPENDM_ServerSaveData();
		CCNKAKCBBDJ.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO_DataType.AFGALHECDIJ_3/*3*/;
		FMFKHDPKLOC = new BBHNACPENDM_ServerSaveData();
		FMFKHDPKLOC.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO_DataType.GGEELFGJAMP_2/*2*/;
		MNJHBCIIHED_PrevServerData = new BBHNACPENDM_ServerSaveData();
		MNJHBCIIHED_PrevServerData.HFCOIIHIENB = BBHNACPENDM_ServerSaveData.BDADJONBIBO_DataType.LPKPFMHEKEM_4_PreviousLocal/*4*/;
		KPFKKDDOHCN = new AIFIANALLPB_NetInventoryManager();
		CHNJPFCKFOI_FriendManager = new PIGBKEIAMPE_NetFriendManager();
		LNAHEIEIBOI_Initialized = false;
		KONHMOLMOCI_IsSaving = false;
		BBEPLKNMICJ_balances = new List<MCKCJMLOAFP_CurrencyInfo>();
		BPLOEAHOPFI_stamina = new MCGNOFMAPBJ();
		IOCLFHJLHLE_IntimacyUpdater = new JKNNIKNKMNJ();
		PAAMLFNPJGJ_IntimacyDivaPresentLeft = new int[10];
		EDGFGECLOHE_IntimacyDivaTouchCount = new int[10];
		for(int i = 0; i < 10; i++)
		{
			PAAMLFNPJGJ_IntimacyDivaPresentLeft[i] = 1;
			EDGFGECLOHE_IntimacyDivaTouchCount[i] = 1;
		}
		ECFNAOCFKKN_LastDate = 0;
		BLCDJDJJBHC = false;
		JNCBOBPPHHB_IntimacyTensionTime = 0;
		PKBOFLOJNIJ_LastLoginTime = 0;
		MMPBPOIFDAF_Scene.PMKOFEIONEG.FBGGEFFJJHB_xor = (int)Utility.GetCurrentUnixTime() * 0x87727;
		JNMFKOHFAFB_PublicStatus.KNHIPBADANI.FBGGEFFJJHB_xor = (int)MMPBPOIFDAF_Scene.PMKOFEIONEG.FBGGEFFJJHB_xor ^ 0x7651;
		LGBMDHOLOIF_decoPlayerData = new FKAFHLIDAFD();
		LGBMDHOLOIF_decoPlayerData = new FKAFHLIDAFD(); // are they drunk ?
	}

	// // RVA: 0xFFB4B0 Offset: 0xFFB4B0 VA: 0xFFB4B0
	public void BAGMHFKPFIF_Update()
	{
		if(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.PECPLBANLBN)
			return;

		if(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester != null)
		{
			BPLOEAHOPFI_stamina.FJDBNGEPKHL_Time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			IOCLFHJLHLE_IntimacyUpdater.FJDBNGEPKHL_Time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		}
		PDKNJAEGNIL();
		PDKNJAEGNIL(LGBMDHOLOIF_decoPlayerData);
		PDKNJAEGNIL(LGBMDHOLOIF_decoPlayerData);
	}

	// // RVA: 0xFFB7A8 Offset: 0xFFB7A8 VA: 0xFFB7A8
	public void ODJCMJBNDOK_Start(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, IMCBBOAFION _FLENFOEFHPL_OnSuccessWithTuto, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool JKJEFPNIPFO/* = false*/)
	{
		N.a.StartCoroutineWatched(ODDEPBIJHOE_Coroutine_Load(_BHFHGFKBOHH_OnSuccess,_FLENFOEFHPL_OnSuccessWithTuto,_MOBEEPPKFLG_OnFail,JKJEFPNIPFO));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7B58 Offset: 0x6B7B58 VA: 0x6B7B58
	// // RVA: 0xFFB818 Offset: 0xFFB818 VA: 0xFFB818
	private IEnumerator ODDEPBIJHOE_Coroutine_Load(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, IMCBBOAFION _FLENFOEFHPL_OnSuccessWithTuto, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool JKJEFPNIPFO)
	{
		//0x1010F04

		PJKLMCGEJMK_NetActionManager OKDOIAEGADK_Server = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		OKGLGHCBCJP_Database DLMOKNDEMMB = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database;
		AHEFHIMGIBI_PlayerData.KHEKNNFCAOI_Init(DLMOKNDEMMB);
		FMFKHDPKLOC.KHEKNNFCAOI_Init(DLMOKNDEMMB);
		CCNKAKCBBDJ.KHEKNNFCAOI_Init(DLMOKNDEMMB);
		MNJHBCIIHED_PrevServerData.KHEKNNFCAOI_Init(DLMOKNDEMMB);
		DCLNIAMEGLA = null;
		HAELBFCGHMB = false;
		BLCDJDJJBHC = false;
		NAIJIFAJGGK_RequestLoadPlayerData BPOJOBICBAC = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest<NAIJIFAJGGK_RequestLoadPlayerData>(new NAIJIFAJGGK_RequestLoadPlayerData());
		BPOJOBICBAC.HHIHCJKLJFF_Names = AHEFHIMGIBI_PlayerData.KPIDBPEKMFD_GetNames();
		BPOJOBICBAC.IJMPLDBGMHC_OnDataReceived = AHEFHIMGIBI_PlayerData.IIEMACPEEBJ_Deserialize;
		yield return BPOJOBICBAC.GDPDELLNOBO_WaitDone(N.a);

		StringBuilder str = new StringBuilder();
		bool firstDone = false;
		bool b = false;
		for(int i = 0; i < AHEFHIMGIBI_PlayerData.MGJKEJHEBPO_Blocks.Count; i++)
		{
			if(firstDone)
			{
				str.Append(",");
			}
			str.Append(AHEFHIMGIBI_PlayerData.MGJKEJHEBPO_Blocks[i].JIKKNHIAEKG_BlockName);
			str.Append(":");
			str.Append(AHEFHIMGIBI_PlayerData.MGJKEJHEBPO_Blocks[i].LLBJFFFJEPJ_Deseralized);
			str.Append(":");
			str.Append(AHEFHIMGIBI_PlayerData.MGJKEJHEBPO_Blocks[i].FJMOAAPNCJI_SaveId);
			firstDone = true;
			b = b | !AHEFHIMGIBI_PlayerData.MGJKEJHEBPO_Blocks[i].LLBJFFFJEPJ_Deseralized;
		}

		TodoLogger.Log(TodoLogger.Filesystem, str.ToString());
		ILCCJNDFFOB.HHCJCDFCLOB_Instance.NJEIHFPKOMG_GameStartLoad(!(BPOJOBICBAC.NPNNPNAIONN_IsError || b) ? 1 : 0, (int)BPOJOBICBAC.CJMFJOMECKI_ErrorId, str.ToString());
		if(BPOJOBICBAC.NPNNPNAIONN_IsError || b)
		{
			// private CIOECGOMILE_NetPlayerDataManager.<>c__DisplayClass119_0 OPLBFCEPDCH; // 0x14
				// public bool HFPLKFCPHDK; // 0x8
				// // RVA: 0x100A354 Offset: 0x100A354 VA: 0x100A354
				// internal void GEAINKJJEIF() { }
			bool HFPLKFCPHDK = true;
			JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.AHEMKCHEHMM(() => {
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
			if(_MOBEEPPKFLG_OnFail != null)
			{
				_MOBEEPPKFLG_OnFail();
			}
			TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error ODDEPBIJHOE_Coroutine_Load");
			yield break;
		}
		// L 379
		PKBOFLOJNIJ_LastLoginTime = BPOJOBICBAC.NFEAMMJIMPG_Result.IFNLEKOILPM_updated_at;
		ECFNAOCFKKN_LastDate = PKBOFLOJNIJ_LastLoginTime;
		HAELBFCGHMB = BPOJOBICBAC.NFEAMMJIMPG_Result.MLGKDBJLNBM_data_status == 2;
		BPOJOBICBAC = null;
		AHEFHIMGIBI_PlayerData.NEBDDPDPAKJ(JKJEFPNIPFO);
		FMFKHDPKLOC.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
		CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
		PJKLMCGEJMK_NetActionManager.DALFMJFKCGJ = AHEFHIMGIBI_PlayerData.MCKEOKFMLAH_SaveId;

		DOLDMCAMEOD_RequestRemainingForCurrencyIds GHPOKNKDBGO = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest<DOLDMCAMEOD_RequestRemainingForCurrencyIds>(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
		GHPOKNKDBGO.CGCFENMHJIM_Ids = NFGNKHONICJ();
		yield return GHPOKNKDBGO.GDPDELLNOBO_WaitDone(N.a);

		//goto LAB_01011f20;
		//3
		if(GHPOKNKDBGO.NPNNPNAIONN_IsError)
		{
			if(_MOBEEPPKFLG_OnFail != null)
			{
				_MOBEEPPKFLG_OnFail();
			}
		}

		BBEPLKNMICJ_balances.Clear();
		DJICHKCLMCD_UpdateCurrencies(GHPOKNKDBGO.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
		GHPOKNKDBGO = null;

		// private CIOECGOMILE_NetPlayerDataManager.<>c__DisplayClass119_1 LBLMCMHMNGC; // 0x20
			// public bool PLOOEECNHFB_IsDone; // 0x8
			// public bool NPNNPNAIONN_IsError; // 0x9
			// // RVA: 0x100A368 Offset: 0x100A368 VA: 0x100A368
			// internal void MELEJFNIAIM() { }
			// // RVA: 0x100A374 Offset: 0x100A374 VA: 0x100A374
			// internal void CHHCNDJIEDC() { }
		bool PLOOEECNHFB_IsDone = false;
		bool NPNNPNAIONN_IsError = false;
		NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.FPNBCFJHENI.OMPBFINJHDF_RequestVirtualCurrencyBalancesWithExpiredAt(() => {
			//0x100A368
			PLOOEECNHFB_IsDone = true;
		}, () => {
			//0x100A374
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
		});
		//break;
		while(!PLOOEECNHFB_IsDone)
		{
			yield return null;
		}
		if(NPNNPNAIONN_IsError)
		{
			//LAB_01011cb0:
			if(_MOBEEPPKFLG_OnFail != null)
			{
				_MOBEEPPKFLG_OnFail();
			}
			TodoLogger.LogError(TodoLogger.Coroutine, "Exit Error ODDEPBIJHOE_Coroutine_Load");
			yield break;
		}

		//L763
		KPFKKDDOHCN.BDPMNDGIEGI_RequestInventories(null, null, true);
		//LAB_01011a28:
		while(true)
		{
			if(KPFKKDDOHCN.PLOOEECNHFB_IsDone)
			{
				CHNJPFCKFOI_FriendManager.MFKOGDNNKLP();
				CHNJPFCKFOI_FriendManager.HHDGOABFEPC_GetFriendLimit(null, null, false);
				//LAB_01011ac0:
				while(true)
				{
					if(CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsDone)
					{
						int friendLimit = DLMOKNDEMMB.FMPEMFPLPDA_Exp.PCJACJANGCA_GetFriendForLevel(AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level);
						if(friendLimit != CHNJPFCKFOI_FriendManager.JPEIBHJIHPI_FriendLimit)
						{
							CHNJPFCKFOI_FriendManager.PGPLAOGALHD_SetFriendLimit(friendLimit, null, null);
							//LAB_01011bec:
							while(!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsDone)
							{
								yield return null;
							}
						}	
						yield return N.a.StartCoroutineWatched(EKKCGGHIFEG_Coroutine_GetFriendCounts(_MOBEEPPKFLG_OnFail));
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
									LBLNLMGHLAG_UpdateTimedItems();
									AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.LPFFDGNDLKG_UpdateMedals(true, 2160);
									if(IPOHDKPGNFO_HasIntimacyDateChanged())
									{
										FAFAKNJLLIC_ResetIntimacyPresentLeft();
										CDIADEIOIHP_ResetIntimacyTouchCount();
									}
									if(KDHGBOOECKC_NetOfferManager.HHCJCDFCLOB_Instance != null && KDHGBOOECKC_NetOfferManager.HHCJCDFCLOB_Instance.IHGJNLNJPOK())
									{
										KDHGBOOECKC_NetOfferManager.HHCJCDFCLOB_Instance.PCPECPFJMGC();
									}
									NPAPJMLJBKM(false);
									AHEFHIMGIBI_PlayerData.FHLMCCPCEAI_SaveHash.BEBJKJKBOGH_date = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
									MIPMDKBKKJD_UpdateStaminaInfo();
									PCMPDIMCBJM_UpdateIntimacyInfo();
									HLACGFNICAI_UpdateIntimacyTensionInfo();

									HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.AGEAPKNODHO();
									GameManager.Instance.localSave.FBCDKFENOEM_SyncFlagsFromServer();
									CHNJPFCKFOI_FriendManager.BCEAAAOLGEB_Reset();
									FGDMEFINCEE();
									if(AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.IJHBIMNKOMC_tutorial_end == 0)
									{
										if(_FLENFOEFHPL_OnSuccessWithTuto != null)
										{
											_FLENFOEFHPL_OnSuccessWithTuto();
										}
										LNAHEIEIBOI_Initialized = true;
										yield break;
									}
									
									LNAHEIEIBOI_Initialized = true;
									if(_BHFHGFKBOHH_OnSuccess != null)
									{
										_BHFHGFKBOHH_OnSuccess();
									}
									yield break;
								}
								//goto LAB_01011cb0;
								if(_MOBEEPPKFLG_OnFail != null)
								{
									_MOBEEPPKFLG_OnFail();
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
	public void CJMDNPCBEJF_LoadDecoData(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool JKJEFPNIPFO/* = false*/)
	{
		LGBMDHOLOIF_decoPlayerData.BELHFJNAEKB();
		N.a.StartCoroutineWatched(MMAECJEKMJK_Coroutine_LoadDecoData(LGBMDHOLOIF_decoPlayerData, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, false));
	}

	// // RVA: 0xFFBA78 Offset: 0xFFBA78 VA: 0xFFBA78
	// public void PCIBGCGCNOH(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool JKJEFPNIPFO = False) { }

	// // RVA: 0xFFBA90 Offset: 0xFFBA90 VA: 0xFFBA90
	// public void BKKGIOABILM(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool JKJEFPNIPFO = False) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7BD0 Offset: 0x6B7BD0 VA: 0x6B7BD0
	// // RVA: 0xFFB9B8 Offset: 0xFFB9B8 VA: 0xFFB9B8
	private IEnumerator MMAECJEKMJK_Coroutine_LoadDecoData(FKAFHLIDAFD JEBPDGCBPJC, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool JKJEFPNIPFO)
	{
		NAIJIFAJGGK_RequestLoadPlayerData PNLGHFCFPPK_Request;

		//0x10123C4
		JEBPDGCBPJC.LNAHEIEIBOI_Initialized = false;
		JEBPDGCBPJC.DCLNIAMEGLA = null;
		JEBPDGCBPJC.BLCDJDJJBHC = false;
		PNLGHFCFPPK_Request = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAIJIFAJGGK_RequestLoadPlayerData());
		PNLGHFCFPPK_Request.HHIHCJKLJFF_Names = JEBPDGCBPJC.AHEFHIMGIBI_PlayerData.KPIDBPEKMFD_GetNames();
		PNLGHFCFPPK_Request.IJMPLDBGMHC_OnDataReceived = JEBPDGCBPJC.AHEFHIMGIBI_PlayerData.IIEMACPEEBJ_Deserialize;
		yield return PNLGHFCFPPK_Request.GDPDELLNOBO_WaitDone(N.a);
		bool b = false;
		for(int i = 0; i < JEBPDGCBPJC.AHEFHIMGIBI_PlayerData.MGJKEJHEBPO_Blocks.Count; i++)
		{
			b |= !JEBPDGCBPJC.AHEFHIMGIBI_PlayerData.MGJKEJHEBPO_Blocks[i].LLBJFFFJEPJ_Deseralized;
		}
		if(!PNLGHFCFPPK_Request.NPNNPNAIONN_IsError && !b)
		{
			PNLGHFCFPPK_Request = null;
			JEBPDGCBPJC.FMFKHDPKLOC.ODDIHGPONFL_Copy(JEBPDGCBPJC.AHEFHIMGIBI_PlayerData);
			JEBPDGCBPJC.CCNKAKCBBDJ.ODDIHGPONFL_Copy(JEBPDGCBPJC.AHEFHIMGIBI_PlayerData);
			JEBPDGCBPJC.LNAHEIEIBOI_Initialized = true;
			if(_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			bool HFPLKFCPHDK = true;
			JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.AHEMKCHEHMM(() =>
			{
				//0x100A388
				HFPLKFCPHDK = false;
			});
			while(HFPLKFCPHDK)
				yield return null;
			if(_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7C48 Offset: 0x6B7C48 VA: 0x6B7C48
	// // RVA: 0xFFBAC8 Offset: 0xFFBAC8 VA: 0xFFBAC8
	private IEnumerator EKKCGGHIFEG_Coroutine_GetFriendCounts(DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		//0x1010240
		CHNJPFCKFOI_FriendManager.PFJBNPIBFMO_GetReceivedRequests(null, (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x100A39C
			_MOBEEPPKFLG_OnFail();
		}, false);
		while (!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsDone)
			yield return null;
		CHNJPFCKFOI_FriendManager.BMJANOADDCC_GetFriends(null, (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x100A3C8
			_MOBEEPPKFLG_OnFail();
		}, false);
		while (!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsDone)
			yield return null;
		CHNJPFCKFOI_FriendManager.MEJHFCBFPED_GetSentRequests(null, (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
		{
			//0x100A3F4
			_MOBEEPPKFLG_OnFail();
		}, false);
		while (!CHNJPFCKFOI_FriendManager.PLOOEECNHFB_IsDone)
			yield return null;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7CC0 Offset: 0x6B7CC0 VA: 0x6B7CC0
	// // RVA: 0xFFBB90 Offset: 0xFFBB90 VA: 0xFFBB90
	// private IEnumerator HLPJPJBKEPE_Corotuine_PurchaseRecover(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0xFFBC3C Offset: 0xFFBC3C VA: 0xFFBC3C
	private bool LEDMBIANHDG_HasIntimacyTouchDateChanged()
	{
		long time = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MJDMEKMGFJA_IntimacyTouchSaveTime;
		if(time != 0)
		{
			long serverTime = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			DateTime d = Utility.GetLocalDateTime(time);
			DateTime d2 = Utility.GetLocalDateTime(serverTime);
			return d.Year != d2.Year || d.Month != d2.Month || d.Day != d2.Day;
		}
		return false;
	}

	// // RVA: 0xFFBE9C Offset: 0xFFBE9C VA: 0xFFBE9C
	private bool IPOHDKPGNFO_HasIntimacyDateChanged()
	{
		long presentSaveDate = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ANNIPKMMIAC_IntimacyPresentSaveDate;
		int date = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.DHMLDAGGKCD;
		if (presentSaveDate < 1)
		{
			if(!LEDMBIANHDG_HasIntimacyTouchDateChanged())
			{
				AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ANNIPKMMIAC_IntimacyPresentSaveDate = date;
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
	public bool AIKJMHBDABF_SavePlayerData(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, List<long> _AMOMNBEAHBF_InventoryIds)
	{
		return ACEDPNCIGDG((PJKLMCGEJMK_NetActionManager _CPHFEPHDJIB_ServerRequester, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE JEHOEIKANFL, string _JCJDPGMKJAJ_PlayerData) =>
		{
			//0x100A420
			GGKHIHFPKDH_SavePlayerData req = _CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
			req.GJAEJFLLKGC_RetryTime = 1;
			req.DOMFHDPMCCO_Init(JEHOEIKANFL, _JCJDPGMKJAJ_PlayerData, _AMOMNBEAHBF_InventoryIds);
			return req;
		}, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0xFFC6E4 Offset: 0xFFC6E4 VA: 0xFFC6E4
	public bool LOOCNGEPAMI(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, int HJBLIJOGNPC)
	{
		return ACEDPNCIGDG((PJKLMCGEJMK_NetActionManager _CPHFEPHDJIB_ServerRequester, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE JEHOEIKANFL, string _JCJDPGMKJAJ_PlayerData) =>
		{
			//0x100A528
			AHNHJFCAPCH_SetRaidbossRewardsReceivedAndSave req = _CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new AHNHJFCAPCH_SetRaidbossRewardsReceivedAndSave());
			req.GJAEJFLLKGC_RetryTime = 1;
			req.BIHCCEHLAOD.DOMFHDPMCCO_Init(JEHOEIKANFL, _JCJDPGMKJAJ_PlayerData, HJBLIJOGNPC);
			return req;
		}, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0xFFC7CC Offset: 0xFFC7CC VA: 0xFFC7CC
	public bool FAMAFKMHFAK(PIIFKPKIOOB JDEPBIPCMAL, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		return ACEDPNCIGDG(JDEPBIPCMAL, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0xFFBFF8 Offset: 0xFFBFF8 VA: 0xFFBFF8
	private bool ACEDPNCIGDG(PIIFKPKIOOB JDEPBIPCMAL, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		if(LNAHEIEIBOI_Initialized)
		{
			if (KONHMOLMOCI_IsSaving)
				return false;
			GameManager.Instance.localSave.FBCDKFENOEM_SyncFlagsFromServer();
			if(AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common != null)
			{
				if(AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MNLAJEDKLCI_sta_lot_time == 0)
				{
					AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MNLAJEDKLCI_sta_lot_time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				}
			}
			IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.PFAKPFKJJKA();
			if (IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ENEBEGGOHFP == 0)
			{
				if(!BLCDJDJJBHC)
				{
					if(!CNGFKOJANNP.HHCJCDFCLOB_Instance.AKPCMLEPPGC_IsInvalid)
					{
						AHEFHIMGIBI_PlayerData.IPLNOMCCNBI_UpdatePublicStatus();
						BBHNACPENDM_ServerSaveData.EMHDCKMFCGE data = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_PlayerData, true);
						if(data != null)
						{
							if(!data.LHIACHALIFC_IsEmpty())
							{
								for(int i = 0; i < data.KFGDPMNCCFO_NaespaceForSave.Count; i++)
								{
									KLFDBFMNLBL_ServerSaveBlock block = AHEFHIMGIBI_PlayerData.LBDOLHGDIEB_Find(data.KFGDPMNCCFO_NaespaceForSave[i]);
									FENCAJJBLBH a = block.PFAKPFKJJKA();
									if(a != null)
									{
										N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(a, _MOBEEPPKFLG_OnFail, 1004));
										return true;
									}
								}
								if(CNGFKOJANNP.HHCJCDFCLOB_Instance.AKPCMLEPPGC_IsInvalid)
								{
									N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 1005));
									return true;
								}
								//NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester
								KONHMOLMOCI_IsSaving = true;
								PMHLJAIGBGK = null;
								FMEDFGOMNBK = null;
								KDLBAGCENNC = null;
								if(!JHOKIPPIHII_IsSavingToServer)
								{
									CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
									N.a.StartCoroutineWatched(NJDCNPOKGKF_Coroutine_Save(JDEPBIPCMAL, data, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
									return true;
								}
								KDLBAGCENNC = data;
								CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
								AHEFHIMGIBI_PlayerData.PLCFEICAKBC(data.KFGDPMNCCFO_NaespaceForSave);
								CCNKAKCBBDJ.PLCFEICAKBC(data.KFGDPMNCCFO_NaespaceForSave);
								FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
								KONHMOLMOCI_IsSaving = false;
								//LAB_00ffc3e0;
							}
						}
					}
					else
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 1003));
						return true;
					}
				}
				else
				{
					N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 1002));
					return true;
				}
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 1001));
				return true;
			}
		}
		//LAB_00ffc3e0
		if (_BHFHGFKBOHH_OnSuccess != null)
			_BHFHGFKBOHH_OnSuccess();
		return true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7D38 Offset: 0x6B7D38 VA: 0x6B7D38
	// // RVA: 0xFFC8A4 Offset: 0xFFC8A4 VA: 0xFFC8A4
	private IEnumerator NJDCNPOKGKF_Coroutine_Save(CIOECGOMILE_NetPlayerDataManager.PIIFKPKIOOB JDEPBIPCMAL, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE JEHOEIKANFL, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		PJKLMCGEJMK_NetActionManager OKDOIAEGADK_Server; // 0x28
		CACGCMBKHDI_NetBaseAction DLOIHKKKNBB_Request; // 0x2C

		//0x10769F0
		OKDOIAEGADK_Server = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		bool BEKAMBBOLBO_Done = false;
		string JCJDPGMKJAJ_PlayerData = "";
		OKDOIAEGADK_Server.BNJPAKLNOPA_WorkerThreadQueue.Add(() => 
		{
			//0x100A648
			JCJDPGMKJAJ_PlayerData = JEHOEIKANFL.PBNINEMAOPB();
			BEKAMBBOLBO_Done = true;
		});
		while(!BEKAMBBOLBO_Done)
			yield return null;
		DLOIHKKKNBB_Request = JDEPBIPCMAL(OKDOIAEGADK_Server, JEHOEIKANFL, JCJDPGMKJAJ_PlayerData);
		yield return DLOIHKKKNBB_Request.GDPDELLNOBO_WaitDone(N.a);
		if(DLOIHKKKNBB_Request.NPNNPNAIONN_IsError)
		{
			if(_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
			KONHMOLMOCI_IsSaving = false;
			yield break;
		}
		List<string> l = (DLOIHKKKNBB_Request as CJIKLGPIPBA).KPIDBPEKMFD_GetNames();
		AHEFHIMGIBI_PlayerData.PLCFEICAKBC(l);
		CCNKAKCBBDJ.PLCFEICAKBC(l);
		FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
		ECFNAOCFKKN_LastDate = (DLOIHKKKNBB_Request as CJIKLGPIPBA).DPKGNBIAFDO_GetUpdatedAt();
		HLBJOJBALIG(l);
		int a = (DLOIHKKKNBB_Request as CJIKLGPIPBA).JNFCOPCBHAP_GetDataStatus();
		if(a == 2 || BDNBIEMJMCD)
		{
			yield return N.a.StartCoroutineWatched(DEHKLOLHKID_Coroutine_ReSave(_BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
		}
		if(_BHFHGFKBOHH_OnSuccess != null)
			_BHFHGFKBOHH_OnSuccess();
		KONHMOLMOCI_IsSaving = false;
	}

	// // RVA: 0xFF3E10 Offset: 0xFF3E10 VA: 0xFF3E10
	public bool OEAMJGPAIGP(FKAFHLIDAFD JEBPDGCBPJC, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, List<long> _AMOMNBEAHBF_InventoryIds)
	{
		return OEAMJGPAIGP(_BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, _AMOMNBEAHBF_InventoryIds);
	}

	// // RVA: 0xFFC990 Offset: 0xFFC990 VA: 0xFFC990
	public bool OEAMJGPAIGP(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, List<long> _AMOMNBEAHBF_InventoryIds)
	{
		if(LGBMDHOLOIF_decoPlayerData.LNAHEIEIBOI_Initialized)
		{
			if(LGBMDHOLOIF_decoPlayerData.KONHMOLMOCI_IsSaving)
				return false;
			IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.PFAKPFKJJKA();
			if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ENEBEGGOHFP == 0)
			{
				PFAKPFKJJKA();
				if(LGBMDHOLOIF_decoPlayerData.BLCDJDJJBHC)
				{
					N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 1002));
					return true;
				}
				else
				{
					if(!CNGFKOJANNP.HHCJCDFCLOB_Instance.AKPCMLEPPGC_IsInvalid)
					{
						AHEFHIMGIBI_PlayerData.IPLNOMCCNBI_UpdatePublicStatus();
						BBHNACPENDM_ServerSaveData.EMHDCKMFCGE d = LGBMDHOLOIF_decoPlayerData.FMFKHDPKLOC.LEMFJICBALP(LGBMDHOLOIF_decoPlayerData.AHEFHIMGIBI_PlayerData, true);
						if(d != null)
						{
							if(!d.LHIACHALIFC_IsEmpty())
							{
								for(int i = 0; i < d.KFGDPMNCCFO_NaespaceForSave.Count; i++)
								{
									FENCAJJBLBH falsif = LGBMDHOLOIF_decoPlayerData.AHEFHIMGIBI_PlayerData.LBDOLHGDIEB_Find(d.KFGDPMNCCFO_NaespaceForSave[i]).PFAKPFKJJKA();
									if(falsif != null)
									{
										N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(falsif, _MOBEEPPKFLG_OnFail, 1004));
										return true;
									}
								}
								if(CNGFKOJANNP.HHCJCDFCLOB_Instance.AKPCMLEPPGC_IsInvalid)
								{
									N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 1005));
									return true;
								}
								LGBMDHOLOIF_decoPlayerData.KONHMOLMOCI_IsSaving = true;
								GGKHIHFPKDH_SavePlayerData data = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
								data.GJAEJFLLKGC_RetryTime = 1.0f;
								data.DOMFHDPMCCO_Init(d, _AMOMNBEAHBF_InventoryIds);
								LGBMDHOLOIF_decoPlayerData.CCNKAKCBBDJ.ODDIHGPONFL_Copy(LGBMDHOLOIF_decoPlayerData.AHEFHIMGIBI_PlayerData);
								N.a.StartCoroutineWatched(CAJOAKIOCEF_Coroutine_SaveDecoData(LGBMDHOLOIF_decoPlayerData, data, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
								return true;
							}
						}
						//LAB_00ffcc40
					}
					else
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 1003));
						return true;
					}
				}
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 1001));
				return true;
			}
		}
		//LAB_00ffcc40
		if(_BHFHGFKBOHH_OnSuccess != null)
			_BHFHGFKBOHH_OnSuccess();
		return true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7DB0 Offset: 0x6B7DB0 VA: 0x6B7DB0
	// // RVA: 0xFFD094 Offset: 0xFFD094 VA: 0xFFD094
	private IEnumerator CAJOAKIOCEF_Coroutine_SaveDecoData(FKAFHLIDAFD JEBPDGCBPJC, GGKHIHFPKDH_SavePlayerData _COJNCNGHIJC_Req, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		//0x1077BBC
		yield return _COJNCNGHIJC_Req.GDPDELLNOBO_WaitDone(N.a);
		if(_COJNCNGHIJC_Req.NPNNPNAIONN_IsError)
		{
			if(_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
		}
		else
		{
			JEBPDGCBPJC.AHEFHIMGIBI_PlayerData.PLCFEICAKBC(_COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
			JEBPDGCBPJC.CCNKAKCBBDJ.PLCFEICAKBC(_COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
			JEBPDGCBPJC.FMFKHDPKLOC.ODDIHGPONFL_Copy(JEBPDGCBPJC.CCNKAKCBBDJ);
			if(_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		}
		JEBPDGCBPJC.KONHMOLMOCI_IsSaving = false;
	}

	// // RVA: 0xFFD168 Offset: 0xFFD168 VA: 0xFFD168
	public bool BMKEBEJJKBE(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, ulong FIBPIDELFBB)
	{
		EBEGGFECPOE.JCHLONCMPAJ_Clear();
		if(LNAHEIEIBOI_Initialized)
		{
			if (KONHMOLMOCI_IsSaving)
				return false;
			if(CNGFKOJANNP.HHCJCDFCLOB_Instance.AKPCMLEPPGC_IsInvalid)
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 2001));
				return true;
			}
			else
			{
				bool a1_line6 = false;
				int a2 = 0;
				int a3 = 0;
				GameManager.Instance.localSave.FBCDKFENOEM_SyncFlagsFromServer();
				IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.PFAKPFKJJKA();
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ENEBEGGOHFP == 0)
				{
					PFAKPFKJJKA();
					if(!BLCDJDJJBHC)
					{
						OKGLGHCBCJP_Database db = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database;
						List<string> ls = new List<string>(10);
						List<int> li = new List<int>(10);
						if((FIBPIDELFBB & 1) != 0)
						{
							if(AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic != null)
							{
								List<JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo> lsongs = AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo;
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
												DGMPLJFDOHF.AppendFormat(AIFFODKHLJE_FreeKey, lsongs[i].FDMENECIKEL_record_music_id, a2, a3);
											}
											else
											{
												DGMPLJFDOHF.AppendFormat(KINJMGALNDE_FreeKeyL6, lsongs[i].FDMENECIKEL_record_music_id, a2, a3);
											}
											ls.Add(DGMPLJFDOHF.ToString());
										}
									}
								}
							}
						}
						if ((FIBPIDELFBB & 2) != 0)
						{
							if (AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode != null)
							{
								//L385
								bool b = false;
								List<OCLHKHAMDHF_Episode.MGGPEOCPIEG> l = AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.POEDIMMMLME(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode, ref b);
								for(int i = 0; i < l.Count; i++)
								{
									JNIKPOIKFAC_Reward rwrd = l[i].KONJMFICNJJ_RewardsInfo;
									OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo epInfo = AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList[l[i].HODPFJGODDN_EpIdx];
									if(!rwrd.MFKJAOLIPMA_IsVc || !epInfo.MCIHDIBHHBI_IsRewardReceived(l[i].CPNGJMKFCJI))
									{
										//LAB_00ffdc5c
										HMGPODKEFBA_EpisodeInfo dbEp = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[l[i].HODPFJGODDN_EpIdx];
										FMLIFJBPFNA_Step dbStep = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.KODIKHBMBBJ_Steps[dbEp.IOFHEGJPHKG_StepId - 1];
										OOOOCFAFGCP data = new OOOOCFAFGCP();
										data.ADCMNODJBGJ_title = JpStringLiterals.StringLiteral_9768;
										if(dbStep.FGOGPCMHPIN_Count - 1 == l[i].CPNGJMKFCJI)
										{
											data.LKGELAPAACK = true;
											data.LJGOOOMOMMA_message = JpStringLiterals.StringLiteral_9769;
											data.DNBFMLBNAEE_point = dbStep.JENFHJDFFAD_Pt[l[i].CPNGJMKFCJI];
										}
										else
										{
											data.LKGELAPAACK = false;
											data.LJGOOOMOMMA_message = string.Format(MessageManager.Instance.GetMessage("common", "unlock_episode_reward"), dbStep.JENFHJDFFAD_Pt[l[i].CPNGJMKFCJI]);
											data.DNBFMLBNAEE_point = dbStep.JENFHJDFFAD_Pt[l[i].CPNGJMKFCJI];
										}
										EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.CNACJCAMCFB_4_Episode, dbEp.KELFCMEOPPM_EpisodeId.ToString() + ":" + l[i].HODPFJGODDN_EpIdx);
										EBEGGFECPOE.OBCINIPHGGH = 0;
										EBEGGFECPOE.PJBJCBEMEEC = 0;
										EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_PlayerData, rwrd.KIJAPOFAGPN_ItemId, rwrd.JDLJPNMLFID_ItemCount, data, 0);
										epInfo.BDPOOJDJKAA_SetRewardReceived(l[i].CPNGJMKFCJI, true);
										if(rwrd.MFKJAOLIPMA_IsVc)
										{
											DGMPLJFDOHF.Clear();
											DGMPLJFDOHF.AppendFormat(AMIPEDALBJP_EpKey, l[i].HODPFJGODDN_EpIdx + 1, l[i].CPNGJMKFCJI + 1);
											ls.Add(DGMPLJFDOHF.ToString());
										}
										if(rwrd.KIJAPOFAGPN_ItemId == 50002)
										{
											ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL_ValueType.NEIJFCOANMA_50_DebutMissoin9, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, AHEFHIMGIBI_PlayerData, 2, false);
										}
									}
								}
								AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BOAIINJHENE();
							}
						}
						bool b2 = false;
						if ((FIBPIDELFBB & 4) != 0)
						{
							//678
							b2 = false;
							if (AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest != null)
							{
								List<NFPHOINMHKN_QuestInfo> dailyquest = AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests;
								for(int i = 0; i < dailyquest.Count; i++)
								{
									if(dailyquest[i].JIOMCDGKIAF == 1)
									{
										if(dailyquest[i].EALOBDHOCHP_stat > 0 && dailyquest[i].EALOBDHOCHP_stat <= 2)
										{
											CNLPPCFJEID_QuestInfo qInfo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[dailyquest[i].PPFNGGCBJKC_id - 1];
											LCKMNLOLDPD ldata = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.LFAAEPAAEMB_Rewards[qInfo.EIHOBHDKCDB_RewardId - 1];
											OOOOCFAFGCP data = new OOOOCFAFGCP();
											data.ADCMNODJBGJ_title = JpStringLiterals.StringLiteral_9771;
											EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.LEABABGFEGB_8_DailyMission, dailyquest[i].PPFNGGCBJKC_id.ToString());
											EBEGGFECPOE.OBCINIPHGGH = 0;
											EBEGGFECPOE.PJBJCBEMEEC = 0;
											EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_PlayerData, ldata.GLCLFMGPMAN_ItemId, ldata.HMFFHLPNMPH_count, data, 0);
											if(ldata.APNMKLJMPMD_Type == 2)
											{
												DGMPLJFDOHF.Clear();
												DGMPLJFDOHF.AppendFormat("daily_quest_" + ldata.BGFPPGPJONG_QuestKeyId.ToString("D4"), Array.Empty<object>());
												ls.Add(DGMPLJFDOHF.ToString());
												b2 = true;
											}
											dailyquest[i].EALOBDHOCHP_stat = 3;
											if(GNGMCIAIKMA.HHCJCDFCLOB_Instance != null)
											{
												GNGMCIAIKMA.HHCJCDFCLOB_Instance.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI_BingoMissionType.KJAFDMGNBPO_11_DailyMission, 0, 1, null);
												GNGMCIAIKMA.HHCJCDFCLOB_Instance.HEFIKPAHCIA_UpdateMission(null, -1);
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
							if(AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest != null)
							{
								List<NFPHOINMHKN_QuestInfo> normalQuest = AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests;
								for(int i = 0; i < normalQuest.Count; i++)
								{
									if(normalQuest[i].JIOMCDGKIAF == 1)
									{
										if(normalQuest[i].EALOBDHOCHP_stat < 3)
										{
											CNLPPCFJEID_QuestInfo qInfo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[normalQuest[i].PPFNGGCBJKC_id - 1];
											LCKMNLOLDPD ldata = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.LFAAEPAAEMB_Rewards[qInfo.EIHOBHDKCDB_RewardId - 1];
											normalQuest[i].EALOBDHOCHP_stat = 3;
											OOOOCFAFGCP data = new OOOOCFAFGCP();
											if(ILLPDLODANB.FJFPHHEFMIB_IsSnsMission(qInfo))
											{
												data.ADCMNODJBGJ_title = JpStringLiterals.StringLiteral_9773;
												EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.LIHFAAPBLOH_12_SNSMission, normalQuest[i].PPFNGGCBJKC_id.ToString());
											}
											else
											{
												if(ILLPDLODANB.HHMKDAIGMKC_IsDebutMission((ILLPDLODANB.LOEGALDKHPL_ValueType)qInfo.INDDJNMPONH_type))
												{
													data.ADCMNODJBGJ_title = JpStringLiterals.StringLiteral_9774;
													EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.NJCPDNAHPDP_13_DebutMission, normalQuest[i].PPFNGGCBJKC_id.ToString());
												}
												else
												{
													data.ADCMNODJBGJ_title = JpStringLiterals.StringLiteral_9775;
													EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.APJJPDJNOJB_7_NormalMission, normalQuest[i].PPFNGGCBJKC_id.ToString());
												}
											}
											EBEGGFECPOE.OBCINIPHGGH = 0;
											EBEGGFECPOE.PJBJCBEMEEC = 0;
											EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_PlayerData, ldata.GLCLFMGPMAN_ItemId, ldata.HMFFHLPNMPH_count, data, 0);
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
									IKDICBBFBMI_NetEventBaseController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.HADLGKFCGLK((ulong)1 << i);
									if(ev != null && ev.AGLILDLEFDK_Missions != null && ev.OLDFFDMPEBM_Quests != null)
									{
										int cnt = ev.AGLILDLEFDK_Missions.Count;
										if(ev.OLDFFDMPEBM_Quests.Count < cnt)
											cnt = ev.OLDFFDMPEBM_Quests.Count;
										for(int j = 0; j < cnt; j++)
										{
											if(ev.OLDFFDMPEBM_Quests[j].JIOMCDGKIAF == 1)
											{
												AKIIJBEJOEP d = ev.AGLILDLEFDK_Missions[ev.OLDFFDMPEBM_Quests[j].PPFNGGCBJKC_id - 1];
												ev.OLDFFDMPEBM_Quests[j].EALOBDHOCHP_stat = 3;
												OOOOCFAFGCP data = new OOOOCFAFGCP();
												data.ADCMNODJBGJ_title = JpStringLiterals.StringLiteral_9777;
												EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.PCDOEIFMLHG_10_EventMision, (ev.PGIIDPEGGPI_EventId * 1000 + ev.OLDFFDMPEBM_Quests[j].PPFNGGCBJKC_id).ToString());
												EBEGGFECPOE.OBCINIPHGGH = 0;
												EBEGGFECPOE.PJBJCBEMEEC = 0;
												EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_PlayerData, d.KIJAPOFAGPN_ItemId, d.JDLJPNMLFID_ItemCount, data, 0);
												if(d.IKJAAKEINHC_Slt < 1)
												{
													if(d.HPAOAKMKCMA_Slt2 > 0)
													{
														DGMPLJFDOHF.Clear();
														string s = ev.DCODGEOEDPG();
														DGMPLJFDOHF.Append(s != null ? s : "");
														DGMPLJFDOHF.Append(d.HPAOAKMKCMA_Slt2.ToString("D4"));
														ls.Add(DGMPLJFDOHF.ToString());
														if(d.PJPDOCNJNGJ_IsLimited)
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
													if(d.PJPDOCNJNGJ_IsLimited)
													{
														li.Add((int)ev.OEGAJJANHGL());
													}
													else
													{
														li.Add(-1);
													}
													b2 = true;
												}
												if(GNGMCIAIKMA.HHCJCDFCLOB_Instance != null)
												{
													GNGMCIAIKMA.HHCJCDFCLOB_Instance.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI_BingoMissionType.CLJHDIKFECG_12_Mission, 0, 1, null);
													GNGMCIAIKMA.HHCJCDFCLOB_Instance.HEFIKPAHCIA_UpdateMission(null, -1);
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
							if(AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume != null)
							{
								bool b = false;
								List<EBFLJMOCLNA_Costume.AEGPJOENNML> l = AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.POEDIMMMLME(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume, ref b);
								if(l != null)
								{
									for(int i = 0; i < l.Count; i++)
									{
                                        EBFLJMOCLNA_Costume.ILFJDCICIKN cos = AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.EEOADCECNOM_GetCostume(l[i].JPIDIENBGKH_CostumeId);
                                        EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.LEHHJINPFHA_25_CostumeUpgrade, l[i].JPIDIENBGKH_CostumeId.ToString() + ":" + cos.ANAJIAENLNB_lv);
										if(l[i].HGNBPGDIFGH_LevelInfo.LMNEDALDGNC())
										{
											EBEGGFECPOE.OBCINIPHGGH = 0;
											EBEGGFECPOE.PJBJCBEMEEC = 0;
											EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_PlayerData, l[i].HGNBPGDIFGH_LevelInfo.PIBLLGLCJEO_Param[0], l[i].HGNBPGDIFGH_LevelInfo.PIBLLGLCJEO_Param[1], null, 0);
										}
										if(l[i].HGNBPGDIFGH_LevelInfo.LDHIAOGPINB() > 0)
										{
											cos.PDADHMIODCA(l[i].HGNBPGDIFGH_LevelInfo.LDHIAOGPINB(), true);
										}
										int costume_upgrade_vc_count = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("costume_upgrade_vc_count", 5);
										EBEGGFECPOE.OBCINIPHGGH = 0;
										EBEGGFECPOE.PJBJCBEMEEC = 0;
										EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1), costume_upgrade_vc_count, null, 0);
										DGMPLJFDOHF.Clear();
										DGMPLJFDOHF.AppendFormat(GPECKLLDAFH_CosKey, l[i].JPIDIENBGKH_CostumeId, l[i].ANAJIAENLNB_lv + 1);
										ls.Add(DGMPLJFDOHF.ToString());
									}
								}
							}
						}
						if ((FIBPIDELFBB & 0x1000000000) != 0)
						{
							//1876
							if(AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer != null)
							{
								while(true)
								{
									OCMJNBIFJNM_Offer.JPOHOLBBFGP of = AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC.Find((OCMJNBIFJNM_Offer.JPOHOLBBFGP JPAEDJJFFOI) =>
									{
										//0x100A184
										return JPAEDJJFFOI.JIOMCDGKIAF == 1;
									});
									if(of == null)
										break;
									int a = 0;
									switch(of.GBJFNGCDKPM_typ)
									{
										case 1:
											a = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.HOJPJAFDIAD[of.MLDPDLPHJPM_OfferId - 1].LJNAKDMILMC_key;
											break;
										case 2:
											a = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FFKIBJKEBNP[of.MLDPDLPHJPM_OfferId - 1].LJNAKDMILMC_key;
											break;
										case 3:
											a = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.PMCDKBBHCJK[of.MLDPDLPHJPM_OfferId - 1].LJNAKDMILMC_key;
											break;
										case 4:
											a = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG[of.MLDPDLPHJPM_OfferId - 1].LJNAKDMILMC_key;
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
										EBEGGFECPOE.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.JMLJADADEEF_28_OfferStone, of.GBJFNGCDKPM_typ + ":" + of.MLDPDLPHJPM_OfferId);
										EBEGGFECPOE.CPIICACGNBH_AddItem(AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1), 5, null, 0);
										b2 = false;
									}
									of.JIOMCDGKIAF = 0;
								}
							}
						}
						AHEFHIMGIBI_PlayerData.IPLNOMCCNBI_UpdatePublicStatus();
						BBHNACPENDM_ServerSaveData.EMHDCKMFCGE e = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_PlayerData, true);
						if(e != null)
						{
							if(!e.LHIACHALIFC_IsEmpty())
							{
								for(int i = 0; i < e.KFGDPMNCCFO_NaespaceForSave.Count; i++)
								{
									KLFDBFMNLBL_ServerSaveBlock block = AHEFHIMGIBI_PlayerData.LBDOLHGDIEB_Find(e.KFGDPMNCCFO_NaespaceForSave[i]);
									if(block.PFAKPFKJJKA() != null)
									{
										N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(block.PFAKPFKJJKA(), _MOBEEPPKFLG_OnFail, 2010));
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
									CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
									AHEFHIMGIBI_PlayerData.PLCFEICAKBC(e.KFGDPMNCCFO_NaespaceForSave);
									CCNKAKCBBDJ.PLCFEICAKBC(e.KFGDPMNCCFO_NaespaceForSave);
									FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
									KONHMOLMOCI_IsSaving = false;
									//LAB_01000bc8;
								}
								else
								{
									if(ls.Count > 0)
									{
										MOMPDFMMICK_ClaimAchievementPrizesAndSave req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new MOMPDFMMICK_ClaimAchievementPrizesAndSave());
										req.GJAEJFLLKGC_RetryTime = 1;
										req.DOMFHDPMCCO_Init(e, ls, b2);
										req.MEGNAIJPBFF_InventoryClosedAt = li;
										CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
										N.a.StartCoroutineWatched(AIBLBMDILLG_Coroutine_SaveWithAchievement(req, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
										return true;
									}
									else
									{
										CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
										N.a.StartCoroutineWatched(NJDCNPOKGKF_Coroutine_Save((PJKLMCGEJMK_NetActionManager OOAIKCALCHL, BBHNACPENDM_ServerSaveData.EMHDCKMFCGE IPIFBCIMHMP, string _JCJDPGMKJAJ_PlayerData) =>
										{
											//0x100A1B8
											GGKHIHFPKDH_SavePlayerData savereq = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
											savereq.GJAEJFLLKGC_RetryTime = 1;
											savereq.DOMFHDPMCCO_Init(IPIFBCIMHMP, _JCJDPGMKJAJ_PlayerData, null);
											return savereq;
										}, e, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
										return true;
									}
								}
							}
						}
						//LAB_01000bc8
					}
					else
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 2003));
						return true;
					}
				}
				else
				{
					N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 2002));
					return true;
				}
			}
		}
		//LAB_01000bc8
		if (_BHFHGFKBOHH_OnSuccess != null)
			_BHFHGFKBOHH_OnSuccess();
		return true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7E28 Offset: 0x6B7E28 VA: 0x6B7E28
	// // RVA: 0x1000F50 Offset: 0x1000F50 VA: 0x1000F50
	private IEnumerator AIBLBMDILLG_Coroutine_SaveWithAchievement(MOMPDFMMICK_ClaimAchievementPrizesAndSave _COJNCNGHIJC_Req, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		//0x1077E90
		yield return _COJNCNGHIJC_Req.GDPDELLNOBO_WaitDone(N.a);
		if(_COJNCNGHIJC_Req.NPNNPNAIONN_IsError)
		{
			if (_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
		}
		else
		{
			AHEFHIMGIBI_PlayerData.PLCFEICAKBC(_COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
			CCNKAKCBBDJ.PLCFEICAKBC(_COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
			FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
			ECFNAOCFKKN_LastDate = _COJNCNGHIJC_Req.NFEAMMJIMPG_Result.IFNLEKOILPM_updated_at;
			HLBJOJBALIG(_COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
			KPFKKDDOHCN.ECFNAOCFKKN_LastDate = 0;
			NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.OLDKENOLHLL = 0;
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		}
		KONHMOLMOCI_IsSaving = false;
	}

	// // RVA: 0x1001024 Offset: 0x1001024 VA: 0x1001024
	public void PKKCKFCLACK(GJDFHLBONOL OKGGJOOCLHI, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK JEMKODBAOEP, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		List<GJDFHLBONOL> res = new List<GJDFHLBONOL>();
		res.Add(OKGGJOOCLHI);
		PKKCKFCLACK(res, _BHFHGFKBOHH_OnSuccess, JEMKODBAOEP, _MOBEEPPKFLG_OnFail, true);
	}

	// // RVA: 0x1001104 Offset: 0x1001104 VA: 0x1001104
	public void PKKCKFCLACK(List<GJDFHLBONOL> _PJJFEAHIPGL_inventories, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK JEMKODBAOEP, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool MBJKHOOMAFE/* = false*/)
	{
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
		JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.ICAPJDDJIEA_6_Present, "");
		JANMJPOKLFL_InventoryUtil.OMGJFMMJPJD = MBJKHOOMAFE;
		KONHMOLMOCI_IsSaving = true;
		if(CNGFKOJANNP.HHCJCDFCLOB_Instance.AKPCMLEPPGC_IsInvalid)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 3001));
		}
		else
		{
			IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.PFAKPFKJJKA();
			if (IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ENEBEGGOHFP == 0)
			{
				if(!BLCDJDJJBHC)
				{
					FENCAJJBLBH falsif = AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
					if (falsif == null)
					{
						N.a.StartCoroutineWatched(PBCOEDMBDBE_Coroutine_ReceiveInventory(_PJJFEAHIPGL_inventories, _BHFHGFKBOHH_OnSuccess, JEMKODBAOEP, _MOBEEPPKFLG_OnFail));
					}
					else
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(falsif, _MOBEEPPKFLG_OnFail, 3003));
					}
				}
				else
					N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 3003));
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 3002));
			}
		}
	}

	// // RVA: 0x1001458 Offset: 0x1001458 VA: 0x1001458
	private List<GJDFHLBONOL> FJPIIDAEMHC_FilterByType(List<GJDFHLBONOL> GPBJHKLFCEP, int _INDDJNMPONH_type)
	{
		List<GJDFHLBONOL> res = new List<GJDFHLBONOL>(GPBJHKLFCEP.Count);
		for(int i = 0; i < GPBJHKLFCEP.Count; i++)
		{
			if(GPBJHKLFCEP[i].MJBKGOJBPAD_item_type == _INDDJNMPONH_type)
			{
				res.Add(GPBJHKLFCEP[i]);
			}
		}
		return res;
	}

	// // RVA: 0x1001608 Offset: 0x1001608 VA: 0x1001608
	private bool OBOHGFNECBG_HasExpiredItems(List<GJDFHLBONOL> _PJJFEAHIPGL_inventories, long _JHNMKKNEENE_Time/* = 0*/)
	{
		if (_JHNMKKNEENE_Time == 0)
			_JHNMKKNEENE_Time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		for (int i = 0; i < _PJJFEAHIPGL_inventories.Count; i++)
		{
			if (_PJJFEAHIPGL_inventories[i].EGBOHDFBAPB_closed_at < _JHNMKKNEENE_Time)
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
	private IEnumerator PBCOEDMBDBE_Coroutine_ReceiveInventory(List<GJDFHLBONOL> _PJJFEAHIPGL_inventories, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK JEMKODBAOEP, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		bool HOEJANILKOG; // 0x28
		DOLDMCAMEOD_RequestRemainingForCurrencyIds DLOIHKKKNBB_Request; // 0x2C

		//0x1075F2C
		if (OBOHGFNECBG_HasExpiredItems(_PJJFEAHIPGL_inventories, 0))
		{
			JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.ACJOEBNHBMF_DisplayExpiredPopup(() =>
			{
				//0x100A68C
				KONHMOLMOCI_IsSaving = false;
				if (_MOBEEPPKFLG_OnFail != null)
					_MOBEEPPKFLG_OnFail();
			}, JANMJPOKLFL_InventoryUtil.OMGJFMMJPJD);
		}
		else
		{
			JDDGPJDKHNE.HHCJCDFCLOB_Instance.NFNLGGHMEAM();
			JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = true;
			List<GJDFHLBONOL> l = FJPIIDAEMHC_FilterByType(_PJJFEAHIPGL_inventories, 0);
			bool b = false;
			if (KAJNAMKKKBN(l) == 1)
			{
				List<GJDFHLBONOL> l2 = FJPIIDAEMHC_FilterByType(_PJJFEAHIPGL_inventories, 1);
				if (l2.Count != 0)
				{
					CIJGKKBOGPB(FJPIIDAEMHC_FilterByType(l2, 1));
					//LAB_01076134
					b = true;
				}
				else
				{
					JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
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
					CIJGKKBOGPB(FJPIIDAEMHC_FilterByType(_PJJFEAHIPGL_inventories, 1));
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
						DLOIHKKKNBB_Request = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
						DLOIHKKKNBB_Request.CGCFENMHJIM_Ids = NFGNKHONICJ();
						yield return DLOIHKKKNBB_Request.GDPDELLNOBO_WaitDone(N.a);
						if(DLOIHKKKNBB_Request.NPNNPNAIONN_IsError)
						{
							JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
							if (_MOBEEPPKFLG_OnFail != null)
								_MOBEEPPKFLG_OnFail();
							KONHMOLMOCI_IsSaving = false;
							yield break;
						}
						BBEPLKNMICJ_balances.Clear();
						DJICHKCLMCD_UpdateCurrencies(DLOIHKKKNBB_Request.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
						DLOIHKKKNBB_Request = null;
					}
					//break
					JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
					bool LBIMNONOOPG = false;
					KPFKKDDOHCN.ICEKFOCHJPI(() =>
					{
						//0x100A6CC
						LBIMNONOOPG = true;
					}, (CACGCMBKHDI_NetBaseAction _ONOPACPKFPK_ac) =>
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
						if (_MOBEEPPKFLG_OnFail != null)
							_MOBEEPPKFLG_OnFail();
					}
					else
					{
						KPFKKDDOHCN.ECFNAOCFKKN_LastDate = 0;
						NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.OLDKENOLHLL = 0;
						KONHMOLMOCI_IsSaving = false;
						if (_BHFHGFKBOHH_OnSuccess != null)
							_BHFHGFKBOHH_OnSuccess();
					}
					yield break;
				}
				//LAB_01076384;
			}
			//LAB_01076384
			JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
			KONHMOLMOCI_IsSaving = false;
			if (_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
			// end
		}
	}

	// // RVA: 0x10017A4 Offset: 0x10017A4 VA: 0x10017A4
	public int KAJNAMKKKBN(List<GJDFHLBONOL> _PJJFEAHIPGL_inventories)
	{
		GPOGFJFGNCA = false;
		NEPILJAJFCC = false;
		NFLGAPBIGAD = false;
		if(_PJJFEAHIPGL_inventories.Count == 0)
		{
			NEPILJAJFCC = true;
			NFLGAPBIGAD = true;
			return 0;
		}
		CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
		ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL_ValueType.PBKOKCHKGGL_46_DebugMission6, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CCNKAKCBBDJ, 2, false);
		List<long> l = new List<long>(_PJJFEAHIPGL_inventories.Count);
		for(int i = 0; i < _PJJFEAHIPGL_inventories.Count; i++)
		{
			if(!JANMJPOKLFL_InventoryUtil.HMDCGPGGOBA_IsAddItemOverflow(CCNKAKCBBDJ, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(_PJJFEAHIPGL_inventories[i].JJBGOIMEIPF_ItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_PJJFEAHIPGL_inventories[i].JJBGOIMEIPF_ItemId), _PJJFEAHIPGL_inventories[i].MBJIFDBEDAC_item_count))
			{
				JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.ICAPJDDJIEA_6_Present, _PJJFEAHIPGL_inventories[i].INDDJNMPONH_type.ToString());
				JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CCNKAKCBBDJ, _PJJFEAHIPGL_inventories[i].JJBGOIMEIPF_ItemId, _PJJFEAHIPGL_inventories[i].MBJIFDBEDAC_item_count, null, 0);
				l.Add(_PJJFEAHIPGL_inventories[i].MDPJFPHOPCH_Id);
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
			GGKHIHFPKDH_SavePlayerData req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
			req.DOMFHDPMCCO_Init(diff, l);
			req.BHFHGFKBOHH_OnSuccess = GDHOKEOHABL;
			req.MOBEEPPKFLG_OnFail = GOPADPOIKNP;
			return 0;
		}
		return 1;
	}

	// // RVA: 0x1001E5C Offset: 0x1001E5C VA: 0x1001E5C
	private void GDHOKEOHABL(CACGCMBKHDI_NetBaseAction KFBCOGJKEJP)
	{
		GGKHIHFPKDH_SavePlayerData r = KFBCOGJKEJP as GGKHIHFPKDH_SavePlayerData;
		FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
		AHEFHIMGIBI_PlayerData.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
		KPFKKDDOHCN.POMPFPJOMNN(r.AMOMNBEAHBF_InventoryIds);
		KPFKKDDOHCN.OEJMJDNIGJD();
		NEPILJAJFCC = true;
		NFLGAPBIGAD = true;
	}

	// // RVA: 0x1001FF8 Offset: 0x1001FF8 VA: 0x1001FF8
	private bool CIJGKKBOGPB(List<GJDFHLBONOL> _PJJFEAHIPGL_inventories)
	{
		NEPILJAJFCC = false;
		NFLGAPBIGAD = false;
		if (_PJJFEAHIPGL_inventories.Count != 0)
		{
			Dictionary<int, int> d = new Dictionary<int, int>();
			List<long> l = new List<long>(_PJJFEAHIPGL_inventories.Count);
			for (int i = 0; i < _PJJFEAHIPGL_inventories.Count; i++)
			{
				l.Add(_PJJFEAHIPGL_inventories[i].MDPJFPHOPCH_Id);
			}
			if(l.Count != 0)
			{
				KONHMOLMOCI_IsSaving = true;
				MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory());
				req.AMOMNBEAHBF_InventoryIds = l;
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
	private void HKMNAICEDNE_OnSuccessReceiveInventory_VC(CACGCMBKHDI_NetBaseAction KFBCOGJKEJP)
	{
		MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory req = KFBCOGJKEJP as MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory;
		DJICHKCLMCD_UpdateCurrencies(req.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
		ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL_ValueType.PBKOKCHKGGL_46_DebugMission6, 2, false);
		KPFKKDDOHCN.PBBEPILMAHO(req.AMOMNBEAHBF_InventoryIds, (GJDFHLBONOL _AIMLPJOGPID_Data) =>
		{
			//0x1009434
			JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.ICAPJDDJIEA_6_Present, _AIMLPJOGPID_Data.INDDJNMPONH_type.ToString());
			JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CCNKAKCBBDJ, _AIMLPJOGPID_Data.JJBGOIMEIPF_ItemId, _AIMLPJOGPID_Data.MBJIFDBEDAC_item_count, null, 0);
		});
		KPFKKDDOHCN.POMPFPJOMNN(req.AMOMNBEAHBF_InventoryIds);
		KPFKKDDOHCN.OEJMJDNIGJD();
		NEPILJAJFCC = true;
		NFLGAPBIGAD = true;
	}

	// // RVA: 0x10025B4 Offset: 0x10025B4 VA: 0x10025B4
	private void GOPADPOIKNP(CACGCMBKHDI_NetBaseAction KFBCOGJKEJP)
	{
		NFLGAPBIGAD = true;
	}

	// // RVA: 0x10025C0 Offset: 0x10025C0 VA: 0x10025C0
	public string PDLEOKCJDAK()
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		if(JANMJPOKLFL_InventoryUtil.OMGJFMMJPJD)
		{
			if(JANMJPOKLFL_InventoryUtil.EPPFEAIMFOE_ItemCount == 1)
			{
				return string.Format(bk.GetMessageByLabel("pbox_text_03"), JANMJPOKLFL_InventoryUtil.OLAICLNDMFF());
			}
		}
		if(!JANMJPOKLFL_InventoryUtil.OMGJFMMJPJD)
		{
			if(JANMJPOKLFL_InventoryUtil.EPPFEAIMFOE_ItemCount > 0)
			{
				if(!GPOGFJFGNCA)
				{
					return Smart.Format(bk.GetMessageByLabel("pbox_text_08"), JANMJPOKLFL_InventoryUtil.EPPFEAIMFOE_ItemCount);
				}
				return bk.GetMessageByLabel("pbox_text_07");
			}
		}
		if (!JANMJPOKLFL_InventoryUtil.OMGJFMMJPJD)
			return bk.GetMessageByLabel("pbox_text_07");
		else
			return bk.GetMessageByLabel("pbox_text_02");
	}

	// // RVA: 0x1002848 Offset: 0x1002848 VA: 0x1002848
	public void OIEBCNPOMIB_UpdateDayChange(bool _FBBNPFFEJBN_Force)
	{
		long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		FEAOOBFHMBL.DOMFHDPMCCO_Init(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, AHEFHIMGIBI_PlayerData, time, _FBBNPFFEJBN_Force);
		if(AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter != null)
		{
			AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.FHPENOLOPKI_CheckEndOfDay(time, _FBBNPFFEJBN_Force);
		}
	}

	// // RVA: 0x1002A38 Offset: 0x1002A38 VA: 0x1002A38
	public void OFGCPFFPGHE(bool _FBBNPFFEJBN_Force)
	{
		NKOBMDPHNGP_NetEventRaidLobbyController lobby = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/) as NKOBMDPHNGP_NetEventRaidLobbyController;
		if(lobby != null)
		{
			lobby.KLEEKOAFIIK(_FBBNPFFEJBN_Force);
		}
	}

	// // RVA: 0x1002B48 Offset: 0x1002B48 VA: 0x1002B48
	public void MIPMDKBKKJD_UpdateStaminaInfo()
	{
		if(AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common != null)
		{
			JJOPEDJCCJK_Exp dbExp = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp;
			int staminaGain = 30;
			if(dbExp != null)
			{
				staminaGain = dbExp.HPEOBAEGHKC_GetStaminaGainForLevel(AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level);
			}
			BPLOEAHOPFI_stamina.DCBENCMNOGO_MaxCount = staminaGain;
			BPLOEAHOPFI_stamina.NEPIPMPAFIE_CntVal = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BCFPEJODJPP_Stamina;
			BPLOEAHOPFI_stamina.DLPEEDCCNMJ_CntSaveTime = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FOKNAMPDPFP_StaminaSaveTime;
			BPLOEAHOPFI_stamina.FLJGHBLEDDB_UpdateInterval = 300;
			if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
			{
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System != null)
				{
					BPLOEAHOPFI_stamina.FLJGHBLEDDB_UpdateInterval = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP_Settings.PFNBMPCIIJJ_heal_sec;
				}
			}
		}
	}

	// // RVA: 0x1002F1C Offset: 0x1002F1C VA: 0x1002F1C
	public void FMIPEACLBKL()
	{
		AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BCFPEJODJPP_Stamina = BPLOEAHOPFI_stamina.NEPIPMPAFIE_CntVal;
		AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FOKNAMPDPFP_StaminaSaveTime = BPLOEAHOPFI_stamina.DLPEEDCCNMJ_CntSaveTime;
	}

	// // RVA: 0x1003010 Offset: 0x1003010 VA: 0x1003010
	public void GIFFIGPKOFE_AddStamina(int _POKDILOKODG_MaxEnergy)
	{
		BPLOEAHOPFI_stamina.GFOAJNICANO(_POKDILOKODG_MaxEnergy);
		FMIPEACLBKL();
	}

	// // RVA: 0x1003050 Offset: 0x1003050 VA: 0x1003050
	public void GNNHEDHCJAE(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int EIDOGCOPHII, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, string _JKJDGDLAIME_Place/* = ""*/)
	{
		CJBHFDHBHEP(LKBJIGBNIAD_RestoreType.JOHJEOPEOBA_0_Stamina, _INDDJNMPONH_type, EIDOGCOPHII, _BHFHGFKBOHH_OnSuccess, HDFGHFOCHKE, BLPGAGLCBPK, _MOBEEPPKFLG_OnFail, _JKJDGDLAIME_Place, 0);
	}

	// // RVA: 0x100336C Offset: 0x100336C VA: 0x100336C
	public void DNJKDCIAHMO(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int EIDOGCOPHII, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, string _JKJDGDLAIME_Place/* = ""*/, CIOECGOMILE_NetPlayerDataManager.LIILJGHKIDL_RestoreButtonType AAIOPEICNNB/* = 0*/)
	{
		CJBHFDHBHEP(LKBJIGBNIAD_RestoreType.MHELGOODGCO_1_Ap, _INDDJNMPONH_type, EIDOGCOPHII, _BHFHGFKBOHH_OnSuccess, HDFGHFOCHKE, BLPGAGLCBPK, _MOBEEPPKFLG_OnFail, _JKJDGDLAIME_Place, AAIOPEICNNB);
	}

	// // RVA: 0x100309C Offset: 0x100309C VA: 0x100309C
	private void CJBHFDHBHEP(LKBJIGBNIAD_RestoreType NNCGBLONBMB, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int EIDOGCOPHII, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, string _JKJDGDLAIME_Place/* = ""*/, LIILJGHKIDL_RestoreButtonType AAIOPEICNNB/* = 0*/)
	{
		if(CNGFKOJANNP.HHCJCDFCLOB_Instance.AKPCMLEPPGC_IsInvalid)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 4001));
		}
		else
		{
			IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.PFAKPFKJJKA();
			if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ENEBEGGOHFP != 0)
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 4002));
			}
			else
			{
				if(BLCDJDJJBHC)
				{
					N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 4003));
				}
				else
				{
					FENCAJJBLBH f = AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
					if(f != null)
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(f, _MOBEEPPKFLG_OnFail, 4004));
					}
					else
					{
						if(_INDDJNMPONH_type == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem || _INDDJNMPONH_type == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
						{
							KONHMOLMOCI_IsSaving = true;
							N.a.StartCoroutineWatched(GBKDCGBHLCD_Coroutine_StaminaHeal_FreeVC(NNCGBLONBMB, _INDDJNMPONH_type, EIDOGCOPHII, _BHFHGFKBOHH_OnSuccess, HDFGHFOCHKE, BLPGAGLCBPK, _MOBEEPPKFLG_OnFail, _JKJDGDLAIME_Place, AAIOPEICNNB));
						}
						else if(_INDDJNMPONH_type == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
						{
							KONHMOLMOCI_IsSaving = true;
							N.a.StartCoroutineWatched(IGOJFNIDAEE_Coroutine_StaminaHeal_PaidVC(NNCGBLONBMB, _BHFHGFKBOHH_OnSuccess, HDFGHFOCHKE, BLPGAGLCBPK, _MOBEEPPKFLG_OnFail, _JKJDGDLAIME_Place, AAIOPEICNNB));
						}
					}
				}
			}
		}
	}

	// // RVA: 0x1003670 Offset: 0x1003670 VA: 0x1003670
	private int BOHEFPHNODA(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int _KIJAPOFAGPN_ItemId)
	{
		if(_INDDJNMPONH_type != EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
			return _KIJAPOFAGPN_ItemId;
		int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId);
		JKDKODAPGBJ_EnergyItem.GFGCCICHBHK it = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem.CDENCMNHNGA_table[id - 1];
		if(it.JBGEEPFKIGG_val == 0)
		{
			return BPLOEAHOPFI_stamina.DCBENCMNOGO_MaxCount;
		}
		return it.JBGEEPFKIGG_val;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7F18 Offset: 0x6B7F18 VA: 0x6B7F18
	// // RVA: 0x10034FC Offset: 0x10034FC VA: 0x10034FC
	private IEnumerator GBKDCGBHLCD_Coroutine_StaminaHeal_FreeVC(LKBJIGBNIAD_RestoreType NNCGBLONBMB, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _INDDJNMPONH_type, int EIDOGCOPHII, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, string _JKJDGDLAIME_Place, LIILJGHKIDL_RestoreButtonType AAIOPEICNNB)
	{
		//0x107828C
		yield return null;
		NKOBMDPHNGP_NetEventRaidLobbyController ev = null;
		if(_INDDJNMPONH_type == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
		{
			int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(EIDOGCOPHII);
			if(AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[id - 1].BFINGCJHOHI_cnt == 0)
			{
				if(HDFGHFOCHKE != null)
					HDFGHFOCHKE();
				KONHMOLMOCI_IsSaving = false;
				yield break;
			}
		}
		else if(_INDDJNMPONH_type == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
		{
            ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.MCGPGMGEPHG_EventRaidLobby, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as NKOBMDPHNGP_NetEventRaidLobbyController;
			if(ev != null)
			{
				if(ev.EHGKMLPCDBM_GetItemCount( (XeApp.Game.Common.RaidItemConstants.Type) EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(EIDOGCOPHII), null) == 0)
				{
					if(HDFGHFOCHKE != null)
						HDFGHFOCHKE();
					KONHMOLMOCI_IsSaving = false;
					yield break;
				}
			}
        }
		MCGNOFMAPBJ GCLOCOHFEEJ = null;
		int HGKJCJAMDGK_Max = 0;
		PKNOKJNLPOE_NetEventRaidController AIOGBKCJLHM = null;
		if(NNCGBLONBMB == LKBJIGBNIAD_RestoreType.JOHJEOPEOBA_0_Stamina)
		{
			GCLOCOHFEEJ = new MCGNOFMAPBJ();
			GCLOCOHFEEJ.ODDIHGPONFL_Copy(BPLOEAHOPFI_stamina);
			HGKJCJAMDGK_Max = BOHEFPHNODA(_INDDJNMPONH_type, EIDOGCOPHII);
			bool a1 = GCLOCOHFEEJ.MAPPOEFALIP(HGKJCJAMDGK_Max, true, false);
			if(!a1)
			{
				if(BLPGAGLCBPK != null)
					BLPGAGLCBPK();
				KONHMOLMOCI_IsSaving = false;
				yield break;
			}
			AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BCFPEJODJPP_Stamina = GCLOCOHFEEJ.NEPIPMPAFIE_CntVal;
			AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FOKNAMPDPFP_StaminaSaveTime = GCLOCOHFEEJ.DLPEEDCCNMJ_CntSaveTime;
		}
		else if(NNCGBLONBMB == LKBJIGBNIAD_RestoreType.MHELGOODGCO_1_Ap)
		{
			GCLOCOHFEEJ = new KAFHAKBBJEI();
			AIOGBKCJLHM = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_NetEventRaidController;
			AIOGBKCJLHM.FEFCBFNLDEP(GCLOCOHFEEJ);
			if(_INDDJNMPONH_type == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
				HGKJCJAMDGK_Max = AIOGBKCJLHM.COEIAHBIFBN(EIDOGCOPHII, AAIOPEICNNB);
			else
				HGKJCJAMDGK_Max = AIOGBKCJLHM.BFPIHPBKEGK_GetApMax();
			if(!GCLOCOHFEEJ.MAPPOEFALIP(HGKJCJAMDGK_Max, true, false))
			{
				//LAB_01078d00
				if(BLPGAGLCBPK != null)
					BLPGAGLCBPK();
				KONHMOLMOCI_IsSaving = false;
				yield break;
			}
			AIOGBKCJLHM.IBMOHKFJDDH_SaveApCounter(GCLOCOHFEEJ);
			if(_INDDJNMPONH_type == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
			{
				AIOGBKCJLHM.NLHLDMGDAFN(EIDOGCOPHII);
			}
		}
		//LAB_01078bf4
		if(_INDDJNMPONH_type == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CFLFPPDMFAE_RaidItem)
		{
			int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(EIDOGCOPHII);
			ev.NCBELAFIPDN_SetItemCount( (XeApp.Game.Common.RaidItemConstants.Type) id, Mathf.Max(0, ev.EHGKMLPCDBM_GetItemCount( (XeApp.Game.Common.RaidItemConstants.Type) id, null) - 1), null);
		}
		else if(_INDDJNMPONH_type == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
		{
			int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(EIDOGCOPHII);
			EGOLBAPFHHD_Common.FKLHGOGJOHH it = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[id - 1];
			it.BFINGCJHOHI_cnt--;
			if(it.BFINGCJHOHI_cnt < 0)
				it.BFINGCJHOHI_cnt = 0;
		}
		AHEFHIMGIBI_PlayerData.IPLNOMCCNBI_UpdatePublicStatus();
		BBHNACPENDM_ServerSaveData.EMHDCKMFCGE data = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_PlayerData, true);
		if(data == null || data.LHIACHALIFC_IsEmpty())
		{
			if(_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
		}
		else
		{
			CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
			GGKHIHFPKDH_SavePlayerData COJNCNGHIJC_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
			COJNCNGHIJC_Req.GJAEJFLLKGC_RetryTime = 1;
			COJNCNGHIJC_Req.DOMFHDPMCCO_Init(data, null);
			COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x100A6EC
				AHEFHIMGIBI_PlayerData.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
				CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
				FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
				ECFNAOCFKKN_LastDate = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.IFNLEKOILPM_updated_at;
				if(NNCGBLONBMB == LKBJIGBNIAD_RestoreType.MHELGOODGCO_1_Ap)
				{
					AIOGBKCJLHM.JIHGDCFBGCK(GCLOCOHFEEJ);
				}
				else if(NNCGBLONBMB == LKBJIGBNIAD_RestoreType.JOHJEOPEOBA_0_Stamina)
				{
					BPLOEAHOPFI_stamina.ODDIHGPONFL_Copy(GCLOCOHFEEJ);
				}
				HLBJOJBALIG(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
				if(NNCGBLONBMB == LKBJIGBNIAD_RestoreType.MHELGOODGCO_1_Ap)
				{
					ILCCJNDFFOB.HHCJCDFCLOB_Instance.ICDCMLKMEHI_HealAp(HGKJCJAMDGK_Max, GCLOCOHFEEJ.DCLKMNGMIKC_GetCurrentValue(), EIDOGCOPHII, 1, _JKJDGDLAIME_Place);
				}
				else if(NNCGBLONBMB == LKBJIGBNIAD_RestoreType.JOHJEOPEOBA_0_Stamina)
				{
					int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(EIDOGCOPHII);
					ILCCJNDFFOB.HHCJCDFCLOB_Instance.FLBCPKHGLPE_Energy(HGKJCJAMDGK_Max, GCLOCOHFEEJ.DCLKMNGMIKC_GetCurrentValue(), id, 1, _JKJDGDLAIME_Place);
				}
				KONHMOLMOCI_IsSaving = false;
				if(_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
			};
			COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x100AB10
				if(_MOBEEPPKFLG_OnFail != null)
					_MOBEEPPKFLG_OnFail();
				KONHMOLMOCI_IsSaving = false;
			};
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7F90 Offset: 0x6B7F90 VA: 0x6B7F90
	// // RVA: 0x10033BC Offset: 0x10033BC VA: 0x10033BC
	private IEnumerator IGOJFNIDAEE_Coroutine_StaminaHeal_PaidVC(LKBJIGBNIAD_RestoreType NNCGBLONBMB, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, JFDNPFFOACP BLPGAGLCBPK, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, string _JKJDGDLAIME_Place, CIOECGOMILE_NetPlayerDataManager.LIILJGHKIDL_RestoreButtonType AAIOPEICNNB)
	{
		PJKLMCGEJMK_NetActionManager OKDOIAEGADK_Server; // 0x34
		DOLDMCAMEOD_RequestRemainingForCurrencyIds PMNKDBLBFHM; // 0x38

		//0x1079454
		yield return null;
		OKDOIAEGADK_Server = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		PMNKDBLBFHM = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
		PMNKDBLBFHM.CGCFENMHJIM_Ids = NFGNKHONICJ();
		yield return PMNKDBLBFHM.GDPDELLNOBO_WaitDone(N.a);
		if(PMNKDBLBFHM.NPNNPNAIONN_IsError)
		{
			if(_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
		}
		else
		{
			DJICHKCLMCD_UpdateCurrencies(PMNKDBLBFHM.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
			int currency = DEAPMEIDCGC_GetTotalPaidCurrency();
			MCGNOFMAPBJ GCLOCOHFEEJ = null;
			int HGKJCJAMDGK_Max = 0;
			PKNOKJNLPOE_NetEventRaidController FBFNJMKPBBA = null;
			int AFKAGFOFAHM_ProductId = 0;
			bool needSave = false;
			if(NNCGBLONBMB == LKBJIGBNIAD_RestoreType.JOHJEOPEOBA_0_Stamina)
			{
				GCLOCOHFEEJ = new MCGNOFMAPBJ();
				AFKAGFOFAHM_ProductId = FFAGOLDAHHN_EnergyProdId;
				if(currency < KMJLGBJBOAK_StaminaRefillCost)
				{
					//LAB_01079c28
					if(HDFGHFOCHKE != null)
						HDFGHFOCHKE();
					KONHMOLMOCI_IsSaving = false;
					yield break;
				}
				else
				{
					GCLOCOHFEEJ.ODDIHGPONFL_Copy(BPLOEAHOPFI_stamina);
					HGKJCJAMDGK_Max = GCLOCOHFEEJ.DCBENCMNOGO_MaxCount;
					if(GCLOCOHFEEJ.FCEMLLDEJFL(true, false))
					{
						AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BCFPEJODJPP_Stamina = GCLOCOHFEEJ.NEPIPMPAFIE_CntVal;
						AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FOKNAMPDPFP_StaminaSaveTime = GCLOCOHFEEJ.DLPEEDCCNMJ_CntSaveTime;
						//LAB_01079e14
						needSave = true;
					}
					else
					{
						//LAB_01079f48
						if(BLPGAGLCBPK != null)
							BLPGAGLCBPK();
						KONHMOLMOCI_IsSaving = false;
						yield break;
					}
				}
			}
			else if(NNCGBLONBMB != LKBJIGBNIAD_RestoreType.MHELGOODGCO_1_Ap)
			{
				//LAB_01079e14
				needSave = true;
			}
			else
			{
				// L. 531
				GCLOCOHFEEJ = new KAFHAKBBJEI();
				AFKAGFOFAHM_ProductId = KKFJJAHFLOK_Ap_ProdIds[(int)AAIOPEICNNB];
				if(ELJNINICAIF_Ap_Prices[(int)AAIOPEICNNB] <= currency)
				{
					FBFNJMKPBBA = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_NetEventRaidController;
					FBFNJMKPBBA.FEFCBFNLDEP(GCLOCOHFEEJ);
					HGKJCJAMDGK_Max = FBFNJMKPBBA.COEIAHBIFBN(10000, AAIOPEICNNB);
					if(GCLOCOHFEEJ.MAPPOEFALIP(HGKJCJAMDGK_Max, true, false))
					{
						FBFNJMKPBBA.IBMOHKFJDDH_SaveApCounter(GCLOCOHFEEJ);
						FBFNJMKPBBA.GOPAABMHDOA();
						//LAB_01079e14
						needSave = true;
					}
					else
					{
						//LAB_01079f48
						if(BLPGAGLCBPK != null)
							BLPGAGLCBPK();
						KONHMOLMOCI_IsSaving = false;
						yield break;
					}
				}
				else
				{
					if(HDFGHFOCHKE != null)
						HDFGHFOCHKE();
					KONHMOLMOCI_IsSaving = false;
					yield break;
				}
			}
			if(needSave)
			{
				//LAB_01079e14
				AHEFHIMGIBI_PlayerData.IPLNOMCCNBI_UpdatePublicStatus();
				BBHNACPENDM_ServerSaveData.EMHDCKMFCGE d = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_PlayerData, true);
				if(d != null)
				{
					if(!d.LHIACHALIFC_IsEmpty())
					{
						for(int i = 0; i < d.KFGDPMNCCFO_NaespaceForSave.Count; i++)
						{
							KLFDBFMNLBL_ServerSaveBlock block = CCNKAKCBBDJ.LBDOLHGDIEB_Find(d.KFGDPMNCCFO_NaespaceForSave[i]);
							FENCAJJBLBH f = block.PFAKPFKJJKA();
							if(f != null)
							{
								N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(f, _MOBEEPPKFLG_OnFail, 5001));
								yield break;
							}
						}
						CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
						FNPBAENIEPG_PurchaseAndSave COJNCNGHIJC_Req = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new FNPBAENIEPG_PurchaseAndSave());
						COJNCNGHIJC_Req.GJAEJFLLKGC_RetryTime = 1;
						COJNCNGHIJC_Req.DOMFHDPMCCO_Init(d, AFKAGFOFAHM_ProductId, 1, 1001);
						COJNCNGHIJC_Req.LGEKLPJFJEI_TotalCurrency = currency;
						COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
						{
							//0x100AB58
							AHEFHIMGIBI_PlayerData.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
							CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
							FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
							ECFNAOCFKKN_LastDate = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.IFNLEKOILPM_updated_at;
							if(NNCGBLONBMB == LKBJIGBNIAD_RestoreType.MHELGOODGCO_1_Ap)
							{
								FBFNJMKPBBA.JIHGDCFBGCK(GCLOCOHFEEJ);
							}
							else if(NNCGBLONBMB == LKBJIGBNIAD_RestoreType.JOHJEOPEOBA_0_Stamina)
							{
								BPLOEAHOPFI_stamina.ODDIHGPONFL_Copy(GCLOCOHFEEJ);
							}
							HLBJOJBALIG(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
                            MCKCJMLOAFP_CurrencyInfo m = JBEKNFEGFFI();
							int p = m.BDLNMOIOMHK_total;
							DJICHKCLMCD_UpdateCurrencies(COJNCNGHIJC_Req.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
							int p2 = JBEKNFEGFFI().BDLNMOIOMHK_total;
							ILCCJNDFFOB.HHCJCDFCLOB_Instance.PMFGEJJDMCK_Consume(1, 1, _JKJDGDLAIME_Place, p - p2, 0);
							if(NNCGBLONBMB == LKBJIGBNIAD_RestoreType.MHELGOODGCO_1_Ap)
							{
								//L 185
								ILCCJNDFFOB.HHCJCDFCLOB_Instance.ICDCMLKMEHI_HealAp(HGKJCJAMDGK_Max, GCLOCOHFEEJ.DCLKMNGMIKC_GetCurrentValue(), 10001, ELJNINICAIF_Ap_Prices[(int)AAIOPEICNNB], _JKJDGDLAIME_Place);
							}
							else
							{
								ILCCJNDFFOB.HHCJCDFCLOB_Instance.FLBCPKHGLPE_Energy(HGKJCJAMDGK_Max, GCLOCOHFEEJ.DCLKMNGMIKC_GetCurrentValue(), 0, KMJLGBJBOAK_StaminaRefillCost, _JKJDGDLAIME_Place);
							}
							if(_BHFHGFKBOHH_OnSuccess != null)
								_BHFHGFKBOHH_OnSuccess();
							KONHMOLMOCI_IsSaving = false;
                        };
						COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
						{
							//0x100B0E8
							if(_MOBEEPPKFLG_OnFail != null)
								_MOBEEPPKFLG_OnFail();
							KONHMOLMOCI_IsSaving = false;
						};
						yield break;
					}
				}
				if(_MOBEEPPKFLG_OnFail != null)
				{
					_MOBEEPPKFLG_OnFail();
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
		if(AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common != null)
		{
			IOCLFHJLHLE_IntimacyUpdater.DCBENCMNOGO_MaxCount = 5;
			IOCLFHJLHLE_IntimacyUpdater.NEPIPMPAFIE_CntVal = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BGEGFMKGNHN_IntimacyCntVal;
			IOCLFHJLHLE_IntimacyUpdater.DLPEEDCCNMJ_CntSaveTime = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ANOCNJABDJO_IntimacyCntSaveTime;
			IOCLFHJLHLE_IntimacyUpdater.FLJGHBLEDDB_UpdateInterval = 3600;
			if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
			{
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy != null)
				{
					CEBFFLDKAEC_SecureInt a = new CEBFFLDKAEC_SecureInt();
					int interval = 3600;
					if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.OHJFBLFELNK_m_intParam.TryGetValue("fscnt_heal_time", out a))
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
		AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BGEGFMKGNHN_IntimacyCntVal = IOCLFHJLHLE_IntimacyUpdater.NEPIPMPAFIE_CntVal;
		AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ANOCNJABDJO_IntimacyCntSaveTime = IOCLFHJLHLE_IntimacyUpdater.DLPEEDCCNMJ_CntSaveTime;
	}

	// // RVA: 0x1003CDC Offset: 0x1003CDC VA: 0x1003CDC
	public void FAFAKNJLLIC_ResetIntimacyPresentLeft()
	{
		if(AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva != null)
		{
			int maxPresentCount = 1;
			if (IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NJGEDPHNIKC_IsPresentLimitEnabled())
			{
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
				{
					if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy != null)
					{
						maxPresentCount = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.NPKHLGBNOKO_GetMaxPresent();
					}
				}
			}
			for(int i = 0; i < 10; i++)
			{
				PAAMLFNPJGJ_IntimacyDivaPresentLeft[i] = maxPresentCount;
				AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].APKBMBKMPAB_IntimacyPresentCount = maxPresentCount;
			}
		}
	}

	// // RVA: 0x1003FB0 Offset: 0x1003FB0 VA: 0x1003FB0
	public void AMCJPIIFHCA()
	{
		DEKKMGAFJCG_Diva saveDivas = AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva;
		if(saveDivas != null)
		{
			for(int i = 0; i < 10; i++)
			{
				PAAMLFNPJGJ_IntimacyDivaPresentLeft[i] = saveDivas.NBIGLBMHEDC_DivaList[i].APKBMBKMPAB_IntimacyPresentCount;
			}
		}
	}

	// // RVA: 0x1004100 Offset: 0x1004100 VA: 0x1004100
	public bool MLEPCANKIIE(int _AHHJLDLAPAN_DivaId, int _HMFFHLPNMPH_count)
	{
		if(_AHHJLDLAPAN_DivaId > 0)
		{
			if(AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva != null)
			{
				int a1 = PAAMLFNPJGJ_IntimacyDivaPresentLeft[_AHHJLDLAPAN_DivaId - 1] - _HMFFHLPNMPH_count;
				if(a1 < 1)
					a1 = 0;
				PAAMLFNPJGJ_IntimacyDivaPresentLeft[_AHHJLDLAPAN_DivaId - 1] = a1;
				AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[_AHHJLDLAPAN_DivaId - 1].APKBMBKMPAB_IntimacyPresentCount = a1;
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x10042AC Offset: 0x10042AC VA: 0x10042AC
	public void CDIADEIOIHP_ResetIntimacyTouchCount()
	{
		if(AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva != null)
		{
			for(int i = 0; i < 10; i++)
			{
				EDGFGECLOHE_IntimacyDivaTouchCount[i] = 0;
				AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].NFDPLBOIDAB_IntimacyTouchCount = 0;
			}
		}
	}

	// // RVA: 0x1004400 Offset: 0x1004400 VA: 0x1004400
	public void HLACGFNICAI_UpdateIntimacyTensionInfo()
	{
		if (AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common == null)
			return;
		JNCBOBPPHHB_IntimacyTensionTime = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FGDNHEABLBN_IntimacyTensionSaveTime;
	}

	// // RVA: 0x100447C Offset: 0x100447C VA: 0x100447C
	public bool MAEKFHENDAA()
	{
		if(AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common != null)
		{
			long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			JNCBOBPPHHB_IntimacyTensionTime = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FGDNHEABLBN_IntimacyTensionSaveTime;
			if(time >= JNCBOBPPHHB_IntimacyTensionTime || (time + 10800) < JNCBOBPPHHB_IntimacyTensionTime ||
				JNCBOBPPHHB_IntimacyTensionTime == 0)
			{
				JNCBOBPPHHB_IntimacyTensionTime = time + 10800 /*% ??*/;
				AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.FGDNHEABLBN_IntimacyTensionSaveTime = JNCBOBPPHHB_IntimacyTensionTime;
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x1004694 Offset: 0x1004694 VA: 0x1004694
	// public void LEIPBJNLOEJ() { }

	// // RVA: 0x1004700 Offset: 0x1004700 VA: 0x1004700
	public void DLFDPCDKHOB(LOBDIAABMKG_GachaProductData EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType, CDOPFBOHDEF _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK HDFGHFOCHKE, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		GPOGFJFGNCA = false;
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
		if(CNGFKOJANNP.HHCJCDFCLOB_Instance.AKPCMLEPPGC_IsInvalid)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _JGKOLBLPMPG_OnFail, 6001));
			return;
		}
		IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.PFAKPFKJJKA();
		if (IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ENEBEGGOHFP != 0)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _JGKOLBLPMPG_OnFail, 6002));
			return;
		}
		if(BLCDJDJJBHC)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _JGKOLBLPMPG_OnFail, 6003));
			return;
		}
		FENCAJJBLBH f = AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
		if(f != null)
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(f, _JGKOLBLPMPG_OnFail, 6004));
			return;
		}
		bool canRequest = false;
		if(_BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.OBLEFFEJGIJ_8)
		{
			if(EPNFGKBBJCE.NECDFDNBHFK_StepData != null)
			{
				if(EPNFGKBBJCE.MEONHEGJNEF())
				{
					//LAB_01004af0
					JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.HMIHFLGLHBA(_JGKOLBLPMPG_OnFail);
					return;
				}
				int DBNAGGGJDAB_current_step_index = EPNFGKBBJCE.NECDFDNBHFK_StepData.LKHAAGIJEPG_player_status.DBNAGGGJDAB_current_step_index;
				MMNNAPPLHFM m = EPNFGKBBJCE.NECDFDNBHFK_StepData.BMFEGOMNECF_steps.Find((MMNNAPPLHFM _GHPLINIACBB_x) =>
				{
					//0x100B934
					return _GHPLINIACBB_x.AGBCJMMMLON_step_index == DBNAGGGJDAB_current_step_index;
				});
				//LAB_01004cec
				if (DEAPMEIDCGC_GetTotalPaidCurrency() >= m.LCJPKJMMIAP_virtual_currency_amount)
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
			KBPDNHOKEKD_ProductId k = EPNFGKBBJCE.DBHIEABGKII_GetSummon(_BJLONGBNPCI_SummonType);
			if(k != null)
			{
				if(EPNFGKBBJCE.MEONHEGJNEF())
				{
					//LAB_01004af0
					JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.HMIHFLGLHBA(_JGKOLBLPMPG_OnFail);
					return;
				}
				if(EPNFGKBBJCE.INDDJNMPONH_type != GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1_Normal)
				{
					if(_BJLONGBNPCI_SummonType < GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AEFCOHJBLPO_11_Num && ((1 << (int)_BJLONGBNPCI_SummonType) & 0x660U) != 0) // 0110 0110 0000
					{
						//LAB_01004cec
						if (NBJOCMAJLPK_GetTotalCurrency(EPNFGKBBJCE.OMNAPCHLBHF_GetPurchaseCurrencyId(_BJLONGBNPCI_SummonType)) >= k.NPPGKNGIFGK_price)
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
							DEAPMEIDCGC_GetTotalPaidCurrency() >= k.NPPGKNGIFGK_price)
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
			if (EPNFGKBBJCE.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8_StepUp)
			{
				OMOEKOCNICP = new IAPIDHGIEED();
				OMOEKOCNICP.ODDIHGPONFL_Copy(EPNFGKBBJCE.NECDFDNBHFK_StepData.LKHAAGIJEPG_player_status);
			}
			KONHMOLMOCI_IsSaving = true;
			EPNFGKBBJCE.KIAIFPFBGJC(_BJLONGBNPCI_SummonType, (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x100B128
				if (NHECPMNKEFK is CBMFOOHOAOE_Purchase)
				{
					CBMFOOHOAOE_Purchase r = NHECPMNKEFK as CBMFOOHOAOE_Purchase;
					int prev = JBEKNFEGFFI().BDLNMOIOMHK_total;
					DJICHKCLMCD_UpdateCurrencies(r.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
					int next = JBEKNFEGFFI().BDLNMOIOMHK_total;
					ILCCJNDFFOB.HHCJCDFCLOB_Instance.PMFGEJJDMCK_Consume(EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId, 0, EPNFGKBBJCE.OPFGFINHFCE_name, next - prev, 0);
					N.a.StartCoroutineWatched(GPDPDNJMDNJ_Coroutine_DrawLotByPaidVC_AfterSave(EPNFGKBBJCE, _BJLONGBNPCI_SummonType, r.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories, _BHFHGFKBOHH_OnSuccess, _JGKOLBLPMPG_OnFail, null, null));
				}
				else if (NHECPMNKEFK is IHJEDAFEJHH_StepUpLotPurchase)
				{
					IHJEDAFEJHH_StepUpLotPurchase r = NHECPMNKEFK as IHJEDAFEJHH_StepUpLotPurchase;
					int prev = JBEKNFEGFFI().BDLNMOIOMHK_total;
					DJICHKCLMCD_UpdateCurrencies(r.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
					int next = JBEKNFEGFFI().BDLNMOIOMHK_total;
					ILCCJNDFFOB.HHCJCDFCLOB_Instance.PMFGEJJDMCK_Consume(EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId, 0, EPNFGKBBJCE.OPFGFINHFCE_name, next - prev, 0);
					List<ANGEDJODMKO> l = new List<ANGEDJODMKO>();
					for (int i = 0; i < r.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories.Count; i++)
					{
						for (int j = 0; j < r.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].PJJFEAHIPGL_inventories.Count; j++)
						{
							ANGEDJODMKO data = new ANGEDJODMKO();
							data.ODDIHGPONFL_Copy(r.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].PJJFEAHIPGL_inventories[j]);
							data.NCDPBLBDOCM_item_set_name = r.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].LJNAKDMILMC_key;
							l.Add(data);
						}
					}
					N.a.StartCoroutineWatched(GPDPDNJMDNJ_Coroutine_DrawLotByPaidVC_AfterSave(EPNFGKBBJCE, _BJLONGBNPCI_SummonType, l, _BHFHGFKBOHH_OnSuccess, _JGKOLBLPMPG_OnFail, OMOEKOCNICP, r.NFEAMMJIMPG_Result.LKHAAGIJEPG_player_status));
				}
			}, () =>
			{
				//0x100B89C
				HDFGHFOCHKE();
				KONHMOLMOCI_IsSaving = false;
			}, () =>
			{
				//0x100B8E8
				_JGKOLBLPMPG_OnFail();
				KONHMOLMOCI_IsSaving = false;
			});
		}
		else
		{
			_JGKOLBLPMPG_OnFail();
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8008 Offset: 0x6B8008 VA: 0x6B8008
	// // RVA: 0x1004EE8 Offset: 0x1004EE8 VA: 0x1004EE8
	private IEnumerator GPDPDNJMDNJ_Coroutine_DrawLotByPaidVC_AfterSave(LOBDIAABMKG_GachaProductData EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType, List<ANGEDJODMKO> DMOHAHJDPAD, CDOPFBOHDEF _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, IAPIDHGIEED OMOEKOCNICP, IAPIDHGIEED ONNIHHLHLDP)
	{
		//0x100ECB0
		yield return null;
		EPNFGKBBJCE.DBHIEABGKII_GetSummon(_BJLONGBNPCI_SummonType);
		KBPDNHOKEKD_ProductId MEANCEOIMGE_Summon = EPNFGKBBJCE.DBHIEABGKII_GetSummon(_BJLONGBNPCI_SummonType);
		List<long> l = new List<long>(10);
		List<MFDJIFIIPJD> BODJIDOHAHF = new List<MFDJIFIIPJD>(10);
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
		JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.DOEHLCLBCNN_3_Gacha, EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId.ToString());
		List<ANGEDJODMKO> l2 = LOBDIAABMKG_GachaProductData.KECIGJBEHBG(DMOHAHJDPAD);
		if(EPNFGKBBJCE.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8_StepUp)
		{
			MMNNAPPLHFM m = EPNFGKBBJCE.NECDFDNBHFK_StepData.BMFEGOMNECF_steps[OMOEKOCNICP.DBNAGGGJDAB_current_step_index];
			ILCCJNDFFOB.HHCJCDFCLOB_Instance.JNBKOAKJDAL_Gacha(EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId, l2.Count, 1, m.LCJPKJMMIAP_virtual_currency_amount, l2, AHEFHIMGIBI_PlayerData, OMOEKOCNICP, ONNIHHLHLDP, null);
		}
		else if(MEANCEOIMGE_Summon != null)
		{
			ILCCJNDFFOB.HHCJCDFCLOB_Instance.JNBKOAKJDAL_Gacha(EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId, l2.Count, EPNFGKBBJCE.OMNAPCHLBHF_GetPurchaseCurrencyId(_BJLONGBNPCI_SummonType) == 1001 ? 1 : 2, MEANCEOIMGE_Summon.NPPGKNGIFGK_price, l2, AHEFHIMGIBI_PlayerData, OMOEKOCNICP, ONNIHHLHLDP, MEANCEOIMGE_Summon.JENBPPBNAHP_PlayerNormalLotFreeState);
		}
		JDDGPJDKHNE.HHCJCDFCLOB_Instance.NFNLGGHMEAM();
		JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = true;
		bool b1 = false;
		for(int i = 0; i < l2.Count; i++)
		{
			EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(l2[i].JJBGOIMEIPF_ItemId);
			if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.BFAJMALBALG_AddGacha(l2[i].MBJIFDBEDAC_item_count);
				JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.JLFJCIOOABC_32_DrawGacha);
				b1 = true;
			}
			MFDJIFIIPJD m = new MFDJIFIIPJD();
			m.KHEKNNFCAOI_Init(l2[i].HAAJGNCFNJM_item_name, l2[i].OCNINMIMHGC_item_value, l2[i].MBJIFDBEDAC_item_count, 0);
			JANMJPOKLFL_InventoryUtil.OBCINIPHGGH = 0;
			JANMJPOKLFL_InventoryUtil.IKBLCEFCGDE_LastLuck = 0;
			JANMJPOKLFL_InventoryUtil.PJBJCBEMEEC = 0;
			if (!JANMJPOKLFL_InventoryUtil.HMDCGPGGOBA_IsAddItemOverflow(AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(l2[i].JJBGOIMEIPF_ItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(l2[i].JJBGOIMEIPF_ItemId), l2[i].MBJIFDBEDAC_item_count))
			{
				l.Add(l2[i].MDPJFPHOPCH_Id);
				JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(AHEFHIMGIBI_PlayerData, l2[i].JJBGOIMEIPF_ItemId, l2[i].MBJIFDBEDAC_item_count, null, 0);
				if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(l2[i].JJBGOIMEIPF_ItemId) - 1];
					m.CJEOENICNOC = JANMJPOKLFL_InventoryUtil.OBCINIPHGGH;
					m.MJBODMOLOBC_luck = saveScene.MJBODMOLOBC_luck;
					m.JPIPENJGGDD_NumBoard = saveScene.JPIPENJGGDD_NumBoard;
					m.LHMOAJAIJCO_is_new = saveScene.LHMOAJAIJCO_is_new;
				}
			}
			else
			{
				m.HMGCLKNLMAL = true;
				GPOGFJFGNCA = true;
			}
			BODJIDOHAHF.Add(m);
		}
		if(b1 && GNGMCIAIKMA.HHCJCDFCLOB_Instance != null)
		{
			GNGMCIAIKMA.HHCJCDFCLOB_Instance.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI_BingoMissionType.DOEHLCLBCNN_14_Gacha, 0, 1, null);
			GNGMCIAIKMA.HHCJCDFCLOB_Instance.HEFIKPAHCIA_UpdateMission(null, -1);
		}
		AHEFHIMGIBI_PlayerData.IPLNOMCCNBI_UpdatePublicStatus();
		BBHNACPENDM_ServerSaveData.EMHDCKMFCGE diff = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_PlayerData, true);
		if(diff != null)
		{
			if(!diff.LHIACHALIFC_IsEmpty())
			{
				CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
				GGKHIHFPKDH_SavePlayerData COJNCNGHIJC_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
				COJNCNGHIJC_Req.GJAEJFLLKGC_RetryTime = 1;
				COJNCNGHIJC_Req.DOMFHDPMCCO_Init(diff, l);
				COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
				{
					//0x100B980
					JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
					GGKHIHFPKDH_SavePlayerData r = NHECPMNKEFK as GGKHIHFPKDH_SavePlayerData;
					AHEFHIMGIBI_PlayerData.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
					CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
					FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
					DJICHKCLMCD_UpdateCurrencies(COJNCNGHIJC_Req.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
					ECFNAOCFKKN_LastDate = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.IFNLEKOILPM_updated_at;
					HLBJOJBALIG(r.HHIHCJKLJFF_Names);
					if(MEANCEOIMGE_Summon != null && MEANCEOIMGE_Summon.HMFDJHEEGNN_buy_limit > 0)
					{
						MEANCEOIMGE_Summon.GIEBJDKLCDH_bought_quantity++;
						if (MEANCEOIMGE_Summon.HMFDJHEEGNN_buy_limit <= MEANCEOIMGE_Summon.GIEBJDKLCDH_bought_quantity)
							MEANCEOIMGE_Summon.GIEBJDKLCDH_bought_quantity = MEANCEOIMGE_Summon.HMFDJHEEGNN_buy_limit;
					}
					_BHFHGFKBOHH_OnSuccess(BODJIDOHAHF);
					KONHMOLMOCI_IsSaving = false;
				};
				COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
				{
					//0x100BD34
					JDDGPJDKHNE.HHCJCDFCLOB_Instance.FOKEGEOKGDG();
					JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
					KONHMOLMOCI_IsSaving = false;
					_JGKOLBLPMPG_OnFail();
				};
				yield break;
			}
		}
		JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
		if(_JGKOLBLPMPG_OnFail != null)
			_JGKOLBLPMPG_OnFail();
		KONHMOLMOCI_IsSaving = false;
	}

	// // RVA: 0x1005050 Offset: 0x1005050 VA: 0x1005050
	public void JBOAMLIDAKF(LOBDIAABMKG_GachaProductData EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType, CDOPFBOHDEF _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK HDFGHFOCHKE, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, bool _IAHLNPMFJMH_Tutorial/* = false*/)
	{
		GPOGFJFGNCA = false;
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
		if(!CNGFKOJANNP.HHCJCDFCLOB_Instance.AKPCMLEPPGC_IsInvalid)
		{
			IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.PFAKPFKJJKA();
			if (IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ENEBEGGOHFP == 0)
			{
				if(!BLCDJDJJBHC)
				{
					FENCAJJBLBH f = AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
					if(f == null)
					{
						KBPDNHOKEKD_ProductId k = EPNFGKBBJCE.DBHIEABGKII_GetSummon(_BJLONGBNPCI_SummonType);
						if (k == null)
						{
							_JGKOLBLPMPG_OnFail();
							return;
						}
						int c = 0;
						if(!_IAHLNPMFJMH_Tutorial)
						{
							if(EPNFGKBBJCE.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1_Normal)
							{
								int a = LKBGPLDLNIK.JPIMHNNGJGI(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime(), AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NKIGFPJPALK_last_lot_time, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System);
								if(a > 0)
								{
									HDFGHFOCHKE();
									return;
								}
								c = 1;
								if(EPNFGKBBJCE.MEONHEGJNEF())
								{
									//LAB_01005b34
									JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.HMIHFLGLHBA(_JGKOLBLPMPG_OnFail);
									return;
								}
							}
							else if(EPNFGKBBJCE.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10_LimitedItem)
							{
								if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database == null || CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData == null)
								{
									//LAB_01005aac
									_JGKOLBLPMPG_OnFail(); // HDFGHFOCHKE
									return;
								}
								if (EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), null) < GachaUtility.GetMenuPrice(GachaUtility.selectCategory, GachaUtility.selectedCountType, GachaUtility.selectedLotType))
								{
									//LAB_01005aac
									HDFGHFOCHKE();
									return;
								}
								if (EPNFGKBBJCE.MEONHEGJNEF())
								{
									//LAB_01005b34
									JHHBAFKMBDL_NetUIControl.HHCJCDFCLOB_Instance.HMIHFLGLHBA(_JGKOLBLPMPG_OnFail);
									return;
								}
								c = GachaUtility.GetMenuLotCount(GachaUtility.selectCategory, GachaUtility.selectedCountType, GachaUtility.selectedLotType);
							}
							else if(EPNFGKBBJCE.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GKDFKDLFNAJ_5_LimitedTicket1)
							{
								//LAB_01005aac
								HDFGHFOCHKE();
								return;
							}
							else if(EPNFGKBBJCE.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BKNHBNINDOC_6_LimitedTicket2)
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
						if(!_IAHLNPMFJMH_Tutorial)
						{
							EPNFGKBBJCE.ICBNPNKJCBK(_BJLONGBNPCI_SummonType, (List<MFDJIFIIPJD> BODJIDOHAHF) =>
							{
								//0x100BDCC
								N.a.StartCoroutineWatched(GEOMKFMLDPL_Coroutine_DrawLotByFreeVC_AfterSave(EPNFGKBBJCE, _BJLONGBNPCI_SummonType, BODJIDOHAHF, _BHFHGFKBOHH_OnSuccess, _JGKOLBLPMPG_OnFail, _IAHLNPMFJMH_Tutorial));
							}, () =>
							{
								//0x100BE64
								if (_JGKOLBLPMPG_OnFail != null)
									_JGKOLBLPMPG_OnFail();
								KONHMOLMOCI_IsSaving = false;
							}, c);
							return;
						}
						int fixed_scene = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("fixed_scene", 3);
						List<MFDJIFIIPJD> l = new List<MFDJIFIIPJD>();
						MFDJIFIIPJD m = new MFDJIFIIPJD();
						m.KHEKNNFCAOI_Init("scene", fixed_scene, 1, 0);
						l.Add(m);
						N.a.StartCoroutineWatched(GEOMKFMLDPL_Coroutine_DrawLotByFreeVC_AfterSave(EPNFGKBBJCE, _BJLONGBNPCI_SummonType, l, _BHFHGFKBOHH_OnSuccess, _JGKOLBLPMPG_OnFail, _IAHLNPMFJMH_Tutorial));
					}
					else
					{
						N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(f, _JGKOLBLPMPG_OnFail, 7004));
					}
				}
				else
				{
					N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _JGKOLBLPMPG_OnFail, 7003));
				}
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _JGKOLBLPMPG_OnFail, 7002));
			}
		}
		else
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _JGKOLBLPMPG_OnFail, 7001));
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8080 Offset: 0x6B8080 VA: 0x6B8080
	// // RVA: 0x1005C2C Offset: 0x1005C2C VA: 0x1005C2C
	private IEnumerator GEOMKFMLDPL_Coroutine_DrawLotByFreeVC_AfterSave(LOBDIAABMKG_GachaProductData EPNFGKBBJCE, GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType, List<MFDJIFIIPJD> BODJIDOHAHF, CDOPFBOHDEF _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, bool _IAHLNPMFJMH_Tutorial)
	{
		//0x100D968
		yield return null;
		KBPDNHOKEKD_ProductId p = EPNFGKBBJCE.DBHIEABGKII_GetSummon(_BJLONGBNPCI_SummonType);
		long t = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		if(EPNFGKBBJCE.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10_LimitedItem)
		{
			if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData == null || IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database == null)
			{
				if (_JGKOLBLPMPG_OnFail != null)
					_JGKOLBLPMPG_OnFail();
				KONHMOLMOCI_IsSaving = false;
				yield break;
			}
			EKLNMHFCAOI_ItemManager.DPHGFMEPOCA_SetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(EPNFGKBBJCE.MJNOAMAFNHA_CostItemId), null) - GachaUtility.GetMenuPrice(GachaUtility.selectCategory, GachaUtility.selectedCountType, GachaUtility.selectedLotType), null);
		}
		else if(EPNFGKBBJCE.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1_Normal)
		{
			AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NKIGFPJPALK_last_lot_time = t;
			ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL_ValueType.IDAIIJEMNMP_47_Gacha, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, AHEFHIMGIBI_PlayerData, 2, false);
		}
		JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.DOEHLCLBCNN_3_Gacha, EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId.ToString());
		ILCCJNDFFOB.HHCJCDFCLOB_Instance.JNBKOAKJDAL_Gacha(EPNFGKBBJCE.FDEBLMKEMLF_TypeAndSeriesId, BODJIDOHAHF.Count, EPNFGKBBJCE.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10_LimitedItem ? 4 : 3, BODJIDOHAHF.Count * p.NPPGKNGIFGK_price, BODJIDOHAHF, AHEFHIMGIBI_PlayerData, null, null, null);
		JDDGPJDKHNE.HHCJCDFCLOB_Instance.NFNLGGHMEAM();
		JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = true;
		bool b1 = false;
		for(int i = 0; i < BODJIDOHAHF.Count; i++)
		{
			if(EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(BODJIDOHAHF[i].JJBGOIMEIPF_ItemId) == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			{
				AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.BFAJMALBALG_AddGacha(BODJIDOHAHF[i].MBJIFDBEDAC_item_count);
				JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.JLFJCIOOABC_32_DrawGacha);
				b1 = true;
			}
			JANMJPOKLFL_InventoryUtil.OBCINIPHGGH = 0;
			JANMJPOKLFL_InventoryUtil.IKBLCEFCGDE_LastLuck = 0;
			JANMJPOKLFL_InventoryUtil.PJBJCBEMEEC = 0;
			if (!JANMJPOKLFL_InventoryUtil.HMDCGPGGOBA_IsAddItemOverflow(AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(BODJIDOHAHF[i].JJBGOIMEIPF_ItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(BODJIDOHAHF[i].JJBGOIMEIPF_ItemId), BODJIDOHAHF[i].MBJIFDBEDAC_item_count))
			{
				JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(AHEFHIMGIBI_PlayerData, BODJIDOHAHF[i].JJBGOIMEIPF_ItemId, BODJIDOHAHF[i].MBJIFDBEDAC_item_count, null, 0);
				if(EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(BODJIDOHAHF[i].JJBGOIMEIPF_ItemId) == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					BODJIDOHAHF[i].CJEOENICNOC = JANMJPOKLFL_InventoryUtil.OBCINIPHGGH;
					BODJIDOHAHF[i].JPIPENJGGDD_NumBoard = JANMJPOKLFL_InventoryUtil.PJBJCBEMEEC;
					BODJIDOHAHF[i].MJBODMOLOBC_luck = JANMJPOKLFL_InventoryUtil.IKBLCEFCGDE_LastLuck;
					BODJIDOHAHF[i].LHMOAJAIJCO_is_new = BODJIDOHAHF[i].JPIPENJGGDD_NumBoard == 0;
				}
				BODJIDOHAHF[i].HMGCLKNLMAL = false;
			}
			else
			{
				BODJIDOHAHF[i].HMGCLKNLMAL = true;
				GPOGFJFGNCA = true;
			}
		}
		if(b1 && GNGMCIAIKMA.HHCJCDFCLOB_Instance != null)
		{
			GNGMCIAIKMA.HHCJCDFCLOB_Instance.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI_BingoMissionType.DOEHLCLBCNN_14_Gacha, 0, 1, null);
			GNGMCIAIKMA.HHCJCDFCLOB_Instance.HEFIKPAHCIA_UpdateMission(null, -1);
		}
		AHEFHIMGIBI_PlayerData.IPLNOMCCNBI_UpdatePublicStatus();
		BBHNACPENDM_ServerSaveData.EMHDCKMFCGE diff = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_PlayerData, true);
		if(diff == null || diff.LHIACHALIFC_IsEmpty())
		{
			JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
			if (_JGKOLBLPMPG_OnFail != null)
				_JGKOLBLPMPG_OnFail();
			KONHMOLMOCI_IsSaving = false;
			yield break;
		}
		CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
		if(!_IAHLNPMFJMH_Tutorial)
		{
			GGKHIHFPKDH_SavePlayerData COJNCNGHIJC_Req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
			COJNCNGHIJC_Req.GJAEJFLLKGC_RetryTime = 1;
			COJNCNGHIJC_Req.DOMFHDPMCCO_Init(diff, null);
			COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x100BEAC
				GGKHIHFPKDH_SavePlayerData r = NHECPMNKEFK as GGKHIHFPKDH_SavePlayerData;
				JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
				AHEFHIMGIBI_PlayerData.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
				CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
				FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
				ECFNAOCFKKN_LastDate = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.IFNLEKOILPM_updated_at;
				AHEFHIMGIBI_PlayerData.PLCFEICAKBC(r.HHIHCJKLJFF_Names);
				HLBJOJBALIG(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
				_BHFHGFKBOHH_OnSuccess(BODJIDOHAHF);
				KONHMOLMOCI_IsSaving = false;
			};
			COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x100C1D0
				JDDGPJDKHNE.HHCJCDFCLOB_Instance.FOKEGEOKGDG();
				JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
				KONHMOLMOCI_IsSaving = false;
				_JGKOLBLPMPG_OnFail();
			};
		}
		else
		{
			JDDGPJDKHNE.HHCJCDFCLOB_Instance.FCMCNIMEAEA = false;
			HLBJOJBALIG(diff.KFGDPMNCCFO_NaespaceForSave);
			_BHFHGFKBOHH_OnSuccess(BODJIDOHAHF);
			KONHMOLMOCI_IsSaving = false;
		}
	}

	// // RVA: 0x1005D78 Offset: 0x1005D78 VA: 0x1005D78
	private void MCLANEJGNHD_GetSystemProducts()
	{
		DICMPMEEIJL_HasSystemProducts = false;
		JNDDNFEINEH = false;
		NEAPMMJKOKA_GetProducts req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
		req.IPKCADIAAPG_Criteria = LCKOLEDFDAL.FBJHGFIHNHE_GetCriteriaForSystemProducts();
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x1009500
			NEAPMMJKOKA_GetProducts r = NHECPMNKEFK as NEAPMMJKOKA_GetProducts;
			for(int i = 0; i < r.NFEAMMJIMPG_Result.MHKCPJDNJKI_products.Count; i++)
			{
				KBPDNHOKEKD_ProductId prod = r.NFEAMMJIMPG_Result.MHKCPJDNJKI_products[i];
				if (prod.KAPMOPMDHJE_label == 10)
				{
					if(prod.OriginalName.Contains(FNBPIOCLODC_Continue))
					{
						CDPHPAIAFDG_Continue_ProdId = prod.PPFNGGCBJKC_id;
						BPPGDBHGMDA_Continue_Price = prod.NPPGKNGIFGK_price;
					}
					else
					{
						if(prod.OriginalName.Contains(CPBCGKAKDIA_Stamina))
						{
							FFAGOLDAHHN_EnergyProdId = prod.PPFNGGCBJKC_id;
							KMJLGBJBOAK_StaminaRefillCost = prod.NPPGKNGIFGK_price;
						}
						else
						{
							if (!prod.OriginalName.Contains(OHPLHJNCLPH_Energy))
							{
								if (prod.OriginalName.Contains(FBDLJDOLMNI_Vop))
								{
									MCLKCGMIKNF_Vop_ProdId = prod.PPFNGGCBJKC_id;
									DMEHACGEOFK_Vop_Price = prod.NPPGKNGIFGK_price;
								}
								else
								{
									if (prod.OriginalName.Contains(AJICGGJJNCA_Ap))
									{
										string s = prod.OriginalName.Replace(JpStringLiterals.StringLiteral_9798_Jp, "");
										if (s != "2")
										{
											if (s != "3")
											{
												KKFJJAHFLOK_Ap_ProdIds[0] = prod.PPFNGGCBJKC_id;
												ELJNINICAIF_Ap_Prices[0] = prod.NPPGKNGIFGK_price;
											}
											else
											{
												KKFJJAHFLOK_Ap_ProdIds[2] = prod.PPFNGGCBJKC_id;
												ELJNINICAIF_Ap_Prices[2] = prod.NPPGKNGIFGK_price;
											}
										}
										else
										{
											KKFJJAHFLOK_Ap_ProdIds[1] = prod.PPFNGGCBJKC_id;
											ELJNINICAIF_Ap_Prices[1] = prod.NPPGKNGIFGK_price;
										}
									}
								}
							}
							else
							{
								FFAGOLDAHHN_EnergyProdId = prod.PPFNGGCBJKC_id;
								KMJLGBJBOAK_StaminaRefillCost = prod.NPPGKNGIFGK_price;
							}
						}
					}
				}
			}
			DICMPMEEIJL_HasSystemProducts = true;
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x100A094
			DICMPMEEIJL_HasSystemProducts = false;
			JNDDNFEINEH = false;
		};
	}

	// // RVA: 0x1005F44 Offset: 0x1005F44 VA: 0x1005F44
	public void OKGLDKFLGGK(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, int _GHBPLHBNMBK_FreeMusicId, int _AKNELONELJK_difficulty)
	{
		IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.PFAKPFKJJKA();
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ENEBEGGOHFP == 0)
		{
			PFAKPFKJJKA();
			if(!BLCDJDJJBHC)
			{
				KONHMOLMOCI_IsSaving = true;
				N.a.StartCoroutineWatched(INJLKHHHMCI_Coroutine_InGameContinueByPaidVC(_BHFHGFKBOHH_OnSuccess, HDFGHFOCHKE, _MOBEEPPKFLG_OnFail, _GHBPLHBNMBK_FreeMusicId, _AKNELONELJK_difficulty));
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 10002));
			}
		}
		else
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 10001));
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B80F8 Offset: 0x6B80F8 VA: 0x6B80F8
	// // RVA: 0x10060CC Offset: 0x10060CC VA: 0x10060CC
	private IEnumerator INJLKHHHMCI_Coroutine_InGameContinueByPaidVC(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, int _GHBPLHBNMBK_FreeMusicId, int _AKNELONELJK_difficulty)
	{
		PJKLMCGEJMK_NetActionManager OKDOIAEGADK_Server;
		DOLDMCAMEOD_RequestRemainingForCurrencyIds PMNKDBLBFHM;

		//0x1010610
		OKDOIAEGADK_Server = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		PMNKDBLBFHM = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
		PMNKDBLBFHM.CGCFENMHJIM_Ids = NFGNKHONICJ();
		yield return PMNKDBLBFHM.GDPDELLNOBO_WaitDone(N.a);
		if(PMNKDBLBFHM.NPNNPNAIONN_IsError)
		{
			if(_MOBEEPPKFLG_OnFail != null)
			{
				_MOBEEPPKFLG_OnFail();
			}
		}
		else
		{
			DJICHKCLMCD_UpdateCurrencies(PMNKDBLBFHM.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
			if(BPPGDBHGMDA_Continue_Price <= DEAPMEIDCGC_GetTotalPaidCurrency())
			{
				AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.AFBCPAGPLNB_IncContinue();
				AHEFHIMGIBI_PlayerData.IPLNOMCCNBI_UpdatePublicStatus();
				BBHNACPENDM_ServerSaveData.EMHDCKMFCGE e = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_PlayerData, true);
				if(e != null)
				{
					if(!e.LHIACHALIFC_IsEmpty())
					{
						for(int i = 0; i < e.KFGDPMNCCFO_NaespaceForSave.Count; i++)
						{
							FENCAJJBLBH f = AHEFHIMGIBI_PlayerData.LBDOLHGDIEB_Find(e.KFGDPMNCCFO_NaespaceForSave[i]).PFAKPFKJJKA();
							if (f != null)
							{
								N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(f, _MOBEEPPKFLG_OnFail, 8001));
								yield break;
							}
						}
						CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
						FNPBAENIEPG_PurchaseAndSave COJNCNGHIJC_Req = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new FNPBAENIEPG_PurchaseAndSave());
						COJNCNGHIJC_Req.GJAEJFLLKGC_RetryTime = 1;
						COJNCNGHIJC_Req.CLBFPFLNGKF = true;
						COJNCNGHIJC_Req.DOMFHDPMCCO_Init(e, CDPHPAIAFDG_Continue_ProdId, 1, 1001);
						COJNCNGHIJC_Req.LGEKLPJFJEI_TotalCurrency = DEAPMEIDCGC_GetTotalPaidCurrency();
						COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
						{
							//0x100C270
							AHEFHIMGIBI_PlayerData.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
							CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
							FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
							ECFNAOCFKKN_LastDate = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.IFNLEKOILPM_updated_at;
							HLBJOJBALIG(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
							MCKCJMLOAFP_CurrencyInfo cinfo = JBEKNFEGFFI();
							int prevTotal = cinfo.BDLNMOIOMHK_total;
							DJICHKCLMCD_UpdateCurrencies(COJNCNGHIJC_Req.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
							string str = JpStringLiterals.StringLiteral_9799 + _GHBPLHBNMBK_FreeMusicId.ToString() + ":";
							if(_AKNELONELJK_difficulty < 5)
							{
								str += new string[]
								{
									"Easy",
									"Normal",
									"Hard",
									"VeryHard",
									"Extream",
								} [_AKNELONELJK_difficulty];
							}
							ILCCJNDFFOB.HHCJCDFCLOB_Instance.PMFGEJJDMCK_Consume(_GHBPLHBNMBK_FreeMusicId, 2, str, prevTotal - cinfo.BDLNMOIOMHK_total, 0);
							if(_BHFHGFKBOHH_OnSuccess != null)
							{
								_BHFHGFKBOHH_OnSuccess();
							}
							KONHMOLMOCI_IsSaving = false;
						};
						COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
						{
							//0x100C634
							if(_MOBEEPPKFLG_OnFail != null)
								_MOBEEPPKFLG_OnFail();
							KONHMOLMOCI_IsSaving = false;
						};
						yield break;
					}
				}
				if(_MOBEEPPKFLG_OnFail != null)
				{
					_MOBEEPPKFLG_OnFail();
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
	// public void JLLHLFDGCKF(int _APHNELOFGAK_CurrencyId, KBPDNHOKEKD_ProductId BBABCIMFOPD, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B8170 Offset: 0x6B8170 VA: 0x6B8170
	// // RVA: 0x100639C Offset: 0x100639C VA: 0x100639C
	// private IEnumerator MKOCPKDBNJC_ActivateMonthlyPassByPaidVC(int _APHNELOFGAK_CurrencyId, KBPDNHOKEKD_ProductId BBABCIMFOPD, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0x10064CC Offset: 0x10064CC VA: 0x10064CC
	public void ELGMEAEDOHI_OfferFastCompleteByPaidVC(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, BOPFPIHGJMD.MLBMHDCCGHI_OfferType _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, int APPJOBEMLBE)
	{
		IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.PFAKPFKJJKA();
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ENEBEGGOHFP == 0)
		{
			PFAKPFKJJKA();
			if(!BLCDJDJJBHC)
			{
				KONHMOLMOCI_IsSaving = true;
				N.a.StartCoroutineWatched(LJJAPOIKAMA_Coroutine_OfferFastCompleteByPaidVC(_BHFHGFKBOHH_OnSuccess, HDFGHFOCHKE, _MOBEEPPKFLG_OnFail, _FGHGMHPNEMG_Type, _MLDPDLPHJPM_OfferId, APPJOBEMLBE));
			}
			else
			{
				N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 10002));
			}
		}
		else
		{
			N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(null, _MOBEEPPKFLG_OnFail, 10001));
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B81E8 Offset: 0x6B81E8 VA: 0x6B81E8
	// // RVA: 0x100665C Offset: 0x100665C VA: 0x100665C
	private IEnumerator LJJAPOIKAMA_Coroutine_OfferFastCompleteByPaidVC(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP HDFGHFOCHKE, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, BOPFPIHGJMD.MLBMHDCCGHI_OfferType _FGHGMHPNEMG_Type, int _MLDPDLPHJPM_OfferId, int APPJOBEMLBE)
	{
		PJKLMCGEJMK_NetActionManager OKDOIAEGADK_Server; // 0x30
		DOLDMCAMEOD_RequestRemainingForCurrencyIds PMNKDBLBFHM; // 0x34

		//0x1012AA8
		OKDOIAEGADK_Server = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		PMNKDBLBFHM = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
		PMNKDBLBFHM.CGCFENMHJIM_Ids = NFGNKHONICJ();
		yield return PMNKDBLBFHM.GDPDELLNOBO_WaitDone(N.a);
		if(PMNKDBLBFHM.NPNNPNAIONN_IsError)
		{
			if(_MOBEEPPKFLG_OnFail != null)
			{
				_MOBEEPPKFLG_OnFail();
			}
		}
		else
		{
			DJICHKCLMCD_UpdateCurrencies(PMNKDBLBFHM.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
			if(DEAPMEIDCGC_GetTotalPaidCurrency() >= DMEHACGEOFK_Vop_Price)
			{
				AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.AFBCPAGPLNB_IncContinue();
				AHEFHIMGIBI_PlayerData.IPLNOMCCNBI_UpdatePublicStatus();
				BBHNACPENDM_ServerSaveData.EMHDCKMFCGE diff = FMFKHDPKLOC.LEMFJICBALP(AHEFHIMGIBI_PlayerData, true);
				if(diff != null)
				{
					if(!diff.LHIACHALIFC_IsEmpty())
					{
						for(int i = 0; i < diff.KFGDPMNCCFO_NaespaceForSave.Count; i++)
						{
							FENCAJJBLBH err = AHEFHIMGIBI_PlayerData.LBDOLHGDIEB_Find(diff.KFGDPMNCCFO_NaespaceForSave[i]).PFAKPFKJJKA();
							if(err != null)
							{
								N.a.StartCoroutineWatched(EHNDCODOBBL_Coroutine_Falsification(err, _MOBEEPPKFLG_OnFail, 8001));
								yield break;
							}
						}
						CCNKAKCBBDJ.ODDIHGPONFL_Copy(AHEFHIMGIBI_PlayerData);
						FNPBAENIEPG_PurchaseAndSave COJNCNGHIJC_Req = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new FNPBAENIEPG_PurchaseAndSave());
						COJNCNGHIJC_Req.GJAEJFLLKGC_RetryTime = 1;
						COJNCNGHIJC_Req.CLBFPFLNGKF = false;
						COJNCNGHIJC_Req.DOMFHDPMCCO_Init(diff, MCLKCGMIKNF_Vop_ProdId, APPJOBEMLBE, 1001);
						COJNCNGHIJC_Req.LGEKLPJFJEI_TotalCurrency = DEAPMEIDCGC_GetTotalPaidCurrency();
						COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
						{
							//0x100C980
							AHEFHIMGIBI_PlayerData.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
							CCNKAKCBBDJ.PLCFEICAKBC(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
							FMFKHDPKLOC.ODDIHGPONFL_Copy(CCNKAKCBBDJ);
							ECFNAOCFKKN_LastDate = COJNCNGHIJC_Req.NFEAMMJIMPG_Result.IFNLEKOILPM_updated_at;
							HLBJOJBALIG(COJNCNGHIJC_Req.HHIHCJKLJFF_Names);
							int prev = JBEKNFEGFFI().BDLNMOIOMHK_total;
							DJICHKCLMCD_UpdateCurrencies(COJNCNGHIJC_Req.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
							int next = JBEKNFEGFFI().BDLNMOIOMHK_total;
							ILCCJNDFFOB.HHCJCDFCLOB_Instance.PMFGEJJDMCK_Consume((int)_FGHGMHPNEMG_Type * 10000 + _MLDPDLPHJPM_OfferId, 2, JpStringLiterals.StringLiteral_9797_Jp, prev - next, 0);
							if (_BHFHGFKBOHH_OnSuccess != null)
								_BHFHGFKBOHH_OnSuccess();
							KONHMOLMOCI_IsSaving = false;
						};
						COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
						{
							//0x100CCEC
							if (_MOBEEPPKFLG_OnFail != null)
								_MOBEEPPKFLG_OnFail();
							KONHMOLMOCI_IsSaving = false;
						};
						yield break;
					}
				}
				if (_MOBEEPPKFLG_OnFail != null)
					_MOBEEPPKFLG_OnFail();
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
		if(LNAHEIEIBOI_Initialized && AHEFHIMGIBI_PlayerData != null && BLCDJDJJBHC)
		{
			FENCAJJBLBH f = AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
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
		if(LNAHEIEIBOI_Initialized && AHEFHIMGIBI_PlayerData != null)
		{
			if(BLCDJDJJBHC)
				return;
			if(AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(false) != null)
			{
				BLCDJDJJBHC = true;
				DCLNIAMEGLA = AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(false);
			}
		}
	}

	// // RVA: 0xFFB6A4 Offset: 0xFFB6A4 VA: 0xFFB6A4
	private void PDKNJAEGNIL(FKAFHLIDAFD JEBPDGCBPJC)
	{
		if(JEBPDGCBPJC.LNAHEIEIBOI_Initialized)
		{
			if(JEBPDGCBPJC.AHEFHIMGIBI_PlayerData != null)
			{
				if(!JEBPDGCBPJC.BLCDJDJJBHC)
				{
					if(JEBPDGCBPJC.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(false) != null)
					{
						JEBPDGCBPJC.DCLNIAMEGLA = JEBPDGCBPJC.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(false);
						JEBPDGCBPJC.BLCDJDJJBHC = true;
					}
				}
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8260 Offset: 0x6B8260 VA: 0x6B8260
	// // RVA: 0xFFC7E4 Offset: 0xFFC7E4 VA: 0xFFC7E4
	private IEnumerator EHNDCODOBBL_Coroutine_Falsification(FENCAJJBLBH _KOGBMDOONFA_Info, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, int NHJBJIGNLHI)
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "EHNDCODOBBL_Coroutine_Falsification");
		yield return null;
	}

	// // RVA: 0x10067C4 Offset: 0x10067C4 VA: 0x10067C4
	public bool HNDJBAAAHDO(ref int _IBAKPKKEDJM_month, ref int _BAOFEFFADPD_day)
	{
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance != null)
		{
			if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized && LNAHEIEIBOI_Initialized)
			{
				DateTime date = Utility.GetLocalDateTime(AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.AFPONJEJKCO_rename_date + IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP_Settings.KMNPFOPBDMA_RenameDay * 86400);
				long t = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
				long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				if(time < t)
				{
					_IBAKPKKEDJM_month = date.Month;
					_BAOFEFFADPD_day = date.Day;
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x1006B5C Offset: 0x1006B5C VA: 0x1006B5C
	public void AKCOAKHAGAL_CheckServerSaveDefaultInit()
	{
		if(AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NIKCFOALFJC_diva_1st == 0)
		{
			AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NIKCFOALFJC_diva_1st = 1;
			if(AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[0].EALOBDHOCHP_stat != 4)
			{
				AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.LOAOLBNFNNP_InitDefault();
			}
		}
		if (AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_diva[0].DIPKCALNIII_diva_id == 0)
		{
			AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_diva[0].DIPKCALNIII_diva_id = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NIKCFOALFJC_diva_1st;
		}
		if (AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FODKKJIDDKN_vf_Id == 0)
			AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FODKKJIDDKN_vf_Id = 1;
	}

	// // RVA: 0x1006F44 Offset: 0x1006F44 VA: 0x1006F44
	// public bool GBEDPKIECPK() { }

	// // RVA: 0x1007300 Offset: 0x1007300 VA: 0x1007300
	// public void MCKHFOAAJGO(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B82D8 Offset: 0x6B82D8 VA: 0x6B82D8
	// // RVA: 0x1007358 Offset: 0x1007358 VA: 0x1007358
	private IEnumerator DEHKLOLHKID_Coroutine_ReSave(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		BBHNACPENDM_ServerSaveData GNJJEDPNELC; // 0x1C
		NAIJIFAJGGK_RequestLoadPlayerData AFHIJJJKJJJ; // 0x20

		//0x10757EC
		GNJJEDPNELC = new BBHNACPENDM_ServerSaveData();
		GNJJEDPNELC.CAKOEJHBIHF();
		AFHIJJJKJJJ = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NAIJIFAJGGK_RequestLoadPlayerData());
		AFHIJJJKJJJ.HHIHCJKLJFF_Names = GNJJEDPNELC.KPIDBPEKMFD_GetNames();
		AFHIJJJKJJJ.IJMPLDBGMHC_OnDataReceived = GNJJEDPNELC.IIEMACPEEBJ_Deserialize;
		yield return AFHIJJJKJJJ.GDPDELLNOBO_WaitDone(N.a);
		if(AFHIJJJKJJJ.NPNNPNAIONN_IsError)
		{
			KONHMOLMOCI_IsSaving = false;
			_AOCANKOMKFG_OnError();
		}
		else
		{
			if(BDNBIEMJMCD)
			{
				GNJJEDPNELC.JHFIPCIHJNL_Base.OPFGFINHFCE_name = JpStringLiterals.StringLiteral_9806;
				GNJJEDPNELC.JHFIPCIHJNL_Base.CMKKFCGBILD_prof = JpStringLiterals.StringLiteral_9807;
				BDNBIEMJMCD = false;
			}
			AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.OPFGFINHFCE_name = GNJJEDPNELC.JHFIPCIHJNL_Base.OPFGFINHFCE_name;
			AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.CMKKFCGBILD_prof = GNJJEDPNELC.JHFIPCIHJNL_Base.CMKKFCGBILD_prof;
			AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.KFKDMBPNLJK_BlockInvalid = true;
			FMFKHDPKLOC.JHFIPCIHJNL_Base.KFKDMBPNLJK_BlockInvalid = true;
			NPOPAOCGIJN = 0;
			HAELBFCGHMB = false;
			KONHMOLMOCI_IsSaving = false;
			AIKJMHBDABF_SavePlayerData(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError, null);
		}
	}

	// // RVA: 0x1007414 Offset: 0x1007414 VA: 0x1007414
	public void KPHFDEOFKLM_UpdateEnergyDayChange()
	{
		JKDKODAPGBJ_EnergyItem dbEnergy = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.KOPOGNLKAEN_EnergyItem;
		long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < dbEnergy.CDENCMNHNGA_table.Count; i++)
		{
			JKDKODAPGBJ_EnergyItem.GFGCCICHBHK it = dbEnergy.CDENCMNHNGA_table[i];
			if (it.PPEGAKEIEGM_Enabled == 2)
			{
				if(it.HJAFPEBIBOP_Limit > 0)
				{
					if(AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem.Count > i)
					{
						EGOLBAPFHHD_Common.FKLHGOGJOHH serverItem = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[i];
						if(serverItem.BFINGCJHOHI_cnt != 0)
						{
							long t = serverItem.BEBJKJKBOGH_date;
							DateTime d1 = Utility.GetLocalDateTime(t);
							DateTime d2 = Utility.GetLocalDateTime(time);
							if(d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day)
							{
								;
							}
							else
							{
								serverItem.BFINGCJHOHI_cnt = 0;
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
		res.AddRange(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH_vcIdsList);
		List<HHJHIFJIKAC_BonusVc.MNGJPJBCMBH> l = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table;
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].PLALNIIBLOF_en == 2)
			{
				int idx = res.FindIndex((int _GHPLINIACBB_x) =>
				{
					//0x100CD40
					return l[i].CPGFOBNKKBF_CurrencyId == _GHPLINIACBB_x;
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
	public void LBLNLMGHLAG_UpdateTimedItems()
	{
		BKPAPCMJKHE_Shop shopDb = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop;
		GBEFGAIGGHA_Shop serverShop = AHEFHIMGIBI_PlayerData.IJOHDAJMBAL_Shop;
		long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		serverShop.LBLNLMGHLAG_UpdateTimedItems(shopDb, time);
	}

	// // RVA: 0x1007FB8 Offset: 0x1007FB8 VA: 0x1007FB8
	public void NAOGKAIBBEH()
	{
		if(AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.BKEKKFPEPBG_LDt != NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.DHMLDAGGKCD)
		{
			AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.BKEKKFPEPBG_LDt = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.DHMLDAGGKCD;
			AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.BJDKMJFCOOM_LCnt++;
			if (AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.BJDKMJFCOOM_LCnt > 999999998)
				AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.BJDKMJFCOOM_LCnt = 0;
			Debug.Log(JpStringLiterals.StringLiteral_9788 + AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.BJDKMJFCOOM_LCnt + "</color>");
			if(GNGMCIAIKMA.HHCJCDFCLOB_Instance != null)
			{
				GNGMCIAIKMA.HHCJCDFCLOB_Instance.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI_BingoMissionType.IBGNFEOLKDP_2_Login/*2*/, 0, 1, null);
				GNGMCIAIKMA.HHCJCDFCLOB_Instance.HEFIKPAHCIA_UpdateMission(null, -1);
			}
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.JKHNILLPKBO_LCnt = AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.BJDKMJFCOOM_LCnt;
			GameManager.Instance.localSave.EPJOACOONAC_GetSave().IAHLNPMFJMH_Tutorial.HLKKGIKPLOM_LDay = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.DHMLDAGGKCD;
			GameManager.Instance.localSave.HJMKBCFJOOH_Save();
		}
	}

	// // RVA: 0x1008444 Offset: 0x1008444 VA: 0x1008444
	public bool NPAPJMLJBKM(bool _FBBNPFFEJBN_Force/* = false*/)
	{
		int a = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.DHMLDAGGKCD;
		if(!_FBBNPFFEJBN_Force)
		{
			if (AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.EMINMIPNAEG_LsDate == a)
				return false;
		}
		AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KBFFLGOBLAF_LsCnt = 0;
		AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.CBHANJJJDBN_SlsCnt = 0;
		AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.EMINMIPNAEG_LsDate = a;
		return true;
	}

	// // RVA: 0x1008608 Offset: 0x1008608 VA: 0x1008608
	public int PPADGJPHDAD()
	{
		int res = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OEJIPANCLOP.LHHOODFPCEL;
		if(NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance != null && NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance.CJMPCGHCGJB())
		{
			res += NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance.ELHKIEBJHLL();
		}
		return res;
	}

	// // RVA: 0x1008764 Offset: 0x1008764 VA: 0x1008764
	public int IIMNMNGEPIJ()
	{
		int res = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OEJIPANCLOP.JKDFMICLDJO;
		if(NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance != null && NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance.CJMPCGHCGJB())
		{
			res += NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance.EOBEPKGEJFE();
		}
		return res;
	}

	// // RVA: 0x10088C0 Offset: 0x10088C0 VA: 0x10088C0
	public int PIEPAMPMODI()
	{
		int a = AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KBFFLGOBLAF_LsCnt;
		if(NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance != null && NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance.CJMPCGHCGJB())
		{
			a += AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.CBHANJJJDBN_SlsCnt;
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
		return AHEFHIMGIBI_PlayerData.GJCOJBDOOJG_LimitedCompoItem.HPPKOGKNKMH(1, KNCKIJBOODM);
	}

	// // RVA: 0x1008A74 Offset: 0x1008A74 VA: 0x1008A74
	public bool LNCGIOILBDD(int _HMFFHLPNMPH_count, long KNCKIJBOODM)
	{
		if(_HMFFHLPNMPH_count <= KJBENABMBCA(KNCKIJBOODM))
		{
			if (PIEPAMPMODI() + _HMFFHLPNMPH_count <= PPADGJPHDAD())
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
	public bool GJACBNJHDHI(int _HMFFHLPNMPH_count, long KNCKIJBOODM)
	{
		if(_HMFFHLPNMPH_count > 0 && LNCGIOILBDD(_HMFFHLPNMPH_count, KNCKIJBOODM))
		{
			List<int> l = AHEFHIMGIBI_PlayerData.GJCOJBDOOJG_LimitedCompoItem.BHNDPHCBCKN(1, KNCKIJBOODM);
			int cnt = Mathf.Min(_HMFFHLPNMPH_count, l.Count);
			for(int i = 0; i < cnt; i++)
			{
				AHEFHIMGIBI_PlayerData.GJCOJBDOOJG_LimitedCompoItem.LLOAMEOCJEO(1, l[i], KNCKIJBOODM);
			}
			if(NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance != null && NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance.CJMPCGHCGJB())
			{
				int a = NHPDPKHMFEP_NetMonthlyPassManager.HHCJCDFCLOB_Instance.ELHKIEBJHLL() - AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.CBHANJJJDBN_SlsCnt;
				if(a - _HMFFHLPNMPH_count > 0)
				{
					AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.CBHANJJJDBN_SlsCnt += _HMFFHLPNMPH_count;
					return true;
				}
				AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.CBHANJJJDBN_SlsCnt += a;
				_HMFFHLPNMPH_count -= a;
			}
			if(_HMFFHLPNMPH_count > 0)
			{
				AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KBFFLGOBLAF_LsCnt += _HMFFHLPNMPH_count;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x1008ED0 Offset: 0x1008ED0 VA: 0x1008ED0
	public bool NKMNJIAGHBB()
	{
		return NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.DHMLDAGGKCD != AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.CHINCCDPPIN_LsGetData;
	}

	// // RVA: 0x1008FB8 Offset: 0x1008FB8 VA: 0x1008FB8
	public void ONAAEGAJBBG(int CPCGBPOKHOJ)
	{
		int a = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.DHMLDAGGKCD;
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
		JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.HNJIKEJADJL_41_LiveSkipTicketGet/*41*/, "");
		JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem, 1, CPCGBPOKHOJ, null, 0);
		AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.CHINCCDPPIN_LsGetData = a;
	}
}
