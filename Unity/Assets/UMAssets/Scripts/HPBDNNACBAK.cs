using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XeApp.Game.Gacha;
using XeSys;

// namespace XeApp.Game.Net
[System.Obsolete()]
public class HPBDNNACBAK {}
public class HPBDNNACBAK_NetGachaProductManager
{
	public class MBMMGKJBJGD
	{
		public int PPFNGGCBJKC_id { get; set; } // 0x8 FDGEMCPHJCB_bgs DEMEPMAEJOO_get_id HIGKAIDMOKN_set_id
		public int HNBFOAJIIAL_Count { get; set; } // 0xC MLBMGFPHPOG_bgs EEACFDLDNHD_bgs AOFFLCJEKMI_bgs
		public long DJJENNPDPCM_ExpireAt { get; set; } // 0x10 OGIFPJBPGDE_bgs FOBEMADNEGI_bgs KBAEBIIJPCN_bgs
	}

	public const int IIGEPHHOIPG = 72;
	private const int EKMKJLJPMCB = 1;
	private bool DLNDPMNLMGC_IsTutorial; // 0xC
	private bool DFJNNAOKGPM; // 0xD
	private string JHJMNLMNPGO_BasePath; // 0x10
	public long ECFNAOCFKKN_LastDate; // 0x18
	private int CHCMPDJFHHE = -1; // 0x20
	private List<int> PACLICFCHJI = new List<int>(); // 0x24
	public bool PFLJNIANOHE; // 0x28
	public List<int> MILIGHHGOML = new List<int>(); // 0x2C
	private MGCDMPJLFKP FJCPJJABKFL = new MGCDMPJLFKP(); // 0x30
	private FFHFGBLNLGL JEKMEPKPADB = new FFHFGBLNLGL(); // 0x34
	public List<MBMMGKJBJGD> GGKFCDDFHFP = new List<MBMMGKJBJGD>(); // 0x38

	public List<LOBDIAABMKG_GachaProductData> MHKCPJDNJKI_products { get; private set; } // 0x8 CPMNDNELDME_bgs DFAHGPEFPOO_bgs IOMCCGAKKCP_bgs

	public bool Unused() { return CHCMPDJFHHE == 0; }

	// // RVA: 0x1601B14 Offset: 0x1601B14 VA: 0x1601B14
	public HPBDNNACBAK_NetGachaProductManager()
	{
		JHJMNLMNPGO_BasePath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/sys";
		MHKCPJDNJKI_products = new List<LOBDIAABMKG_GachaProductData>();
	}

	// // RVA: 0x1601CC4 Offset: 0x1601CC4 VA: 0x1601CC4
	public static int NKIHMCHJIEM()
	{
		int decal_gacha_ticket_currency_id = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("decal_gacha_ticket_currency_id", 2101);
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(decal_gacha_ticket_currency_id) == null)
		{
			Debug.LogError(JpStringLiterals.StringLiteral_11015);
		}
		return decal_gacha_ticket_currency_id;
	}

	// // RVA: 0x1601E48 Offset: 0x1601E48 VA: 0x1601E48
	public static bool FIHFDIBDKKE(int _APHNELOFGAK_CurrencyId)
	{
		return NKIHMCHJIEM() == _APHNELOFGAK_CurrencyId;
	}

	// // RVA: 0x1601E6C Offset: 0x1601E6C VA: 0x1601E6C
	public List<LOBDIAABMKG_GachaProductData> FIGBNDFBKPE(int _APHNELOFGAK_CurrencyId)
	{
		List<LOBDIAABMKG_GachaProductData> res = new List<LOBDIAABMKG_GachaProductData>();
		for (int i = 0; i < MHKCPJDNJKI_products.Count; i++)
		{
			if (MHKCPJDNJKI_products[i].KACECFNECON_extra != null)
			{
				for (int j = 0; j < 10; j++)
				{
					if (MHKCPJDNJKI_products[i].OMNAPCHLBHF_GetPurchaseCurrencyId((GCAHJLOGMCI.NFCAJPIJFAM_SummonType)(j + 1)) == _APHNELOFGAK_CurrencyId)
					{
						res.Add(MHKCPJDNJKI_products[i]);
						break;
					}
				}
			}
		}
		res.Sort((LOBDIAABMKG_GachaProductData _HKICMNAACDA_a, LOBDIAABMKG_GachaProductData _BNKHBCBJBKI_b) =>
		{
			//0x1606114
			return _HKICMNAACDA_a.EABMLBFHJBH_CloseAt.CompareTo(_BNKHBCBJBKI_b.EABMLBFHJBH_CloseAt);
		});
		return res;
	}

	// // RVA: 0x1602108 Offset: 0x1602108 VA: 0x1602108
	public List<LOBDIAABMKG_GachaProductData> NDALDMHNMKI(int _KIJAPOFAGPN_ItemId)
	{
		List<LOBDIAABMKG_GachaProductData> res = new List<LOBDIAABMKG_GachaProductData>();
		for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
		{
			if(MHKCPJDNJKI_products[i].KACECFNECON_extra != null)
			{
				for (int j = 0; j < 10; j++)
				{
					if(MHKCPJDNJKI_products[i].HNDLKGOMMNM((GCAHJLOGMCI.NFCAJPIJFAM_SummonType)(j + 1)).MJNOAMAFNHA_CostItemId == _KIJAPOFAGPN_ItemId)
					{
						res.Add(MHKCPJDNJKI_products[i]);
						break;
					}
				}
			}
		}
		res.Sort((LOBDIAABMKG_GachaProductData _HKICMNAACDA_a, LOBDIAABMKG_GachaProductData _BNKHBCBJBKI_b) =>
		{
			//0x1606168
			return _HKICMNAACDA_a.EABMLBFHJBH_CloseAt.CompareTo(_BNKHBCBJBKI_b.EABMLBFHJBH_CloseAt);
		});
		return res;
	}

	// // RVA: 0x16023CC Offset: 0x16023CC VA: 0x16023CC
	public void LILDGEPCPPG_GetProductList(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool _IAHLNPMFJMH_Tutorial/* = false*/, bool _FBBNPFFEJBN_Force/* = true*/)
	{
		DFJNNAOKGPM = _FBBNPFFEJBN_Force | (DLNDPMNLMGC_IsTutorial && !_IAHLNPMFJMH_Tutorial);
		DLNDPMNLMGC_IsTutorial = _IAHLNPMFJMH_Tutorial;
		if(_IAHLNPMFJMH_Tutorial)
		{
			MHKCPJDNJKI_products.Clear();
			LJODCEJPINC();
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			if(!_FBBNPFFEJBN_Force)
			{
				if(MHKCPJDNJKI_products.Count > 0 && ECFNAOCFKKN_LastDate != 0)
				{
					int gachaListAvailTime = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("gacha_list_avail_time", 1200);
					long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					if((time - ECFNAOCFKKN_LastDate) < gachaListAvailTime)
					{
						_BHFHGFKBOHH_OnSuccess();
					}
				}
			}
			MHKCPJDNJKI_products.Clear();
			N.a.StartCoroutineWatched(AHGFMJOAEPM_Coroutine_GetProductList(_BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
		}
	}

	// // RVA: 0x16026C4 Offset: 0x16026C4 VA: 0x16026C4
	private void LJODCEJPINC()
	{
		LOBDIAABMKG_GachaProductData data = new LOBDIAABMKG_GachaProductData();
		if (!data.EJGLNKNKLFC(1, GCAHJLOGMCI.KNMMOMEHDON_GachaType.ANFKBNLLJFN_7/*7*/))
			return;
		MHKCPJDNJKI_products.Add(data);
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B61C0 Offset: 0x6B61C0 VA: 0x6B61C0
	// // RVA: 0x160278C Offset: 0x160278C VA: 0x160278C
	private IEnumerator AHGFMJOAEPM_Coroutine_GetProductList(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		PJKLMCGEJMK_NetActionManager OKDOIAEGADK_Server; // 0x20
		NEAPMMJKOKA_GetProducts DLOIHKKKNBB_Request; // 0x24
		int JCELHAIJDHE; // 0x28
		HHJHIFJIKAC_BonusVc CFFJOHEKJIK_bonusVc; // 0x2C
		long OKHGOGDCABL_Time; // 0x30
		int HLLLGHINECC_i; // 0x38
		NEAPMMJKOKA_GetProducts JDNODBMEFBA_GetProductRequest; // 0x3C
		BHDAFKEKPEB_GetStepUpLotRecords BDFEDBLGOPJ_GetStepUpLotRecords; // 0x40
		List<KOPCFBCDBPC> GGOLBBBGFME; // 0x44
		List<JBHCLFDBPKP> JFPHGIOBDNG; // 0x48
		EDOGNHECOMI_GetStepUpLotDetail HHDMGJIKEKF_GetStepUpLotDetail; // 0x4C
		int IBLEFBPKMMF; // 0x50

		// 0x1606CAC
		OKDOIAEGADK_Server = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		DLOIHKKKNBB_Request = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
		DLOIHKKKNBB_Request.IPKCADIAAPG_Criteria = LCKOLEDFDAL.CIPJGLGBKFE();
		while (!DLOIHKKKNBB_Request.PLOOEECNHFB_IsDone)
			yield return null;
		if(DLOIHKKKNBB_Request.NPNNPNAIONN_IsError)
		{
			MHKCPJDNJKI_products.Clear();
			//LAB_01607234 (psVar22.clear())
			_MOBEEPPKFLG_OnFail();
		}
		else
		{
			ALBOGEHBBAH(DLOIHKKKNBB_Request.NFEAMMJIMPG_Result.MHKCPJDNJKI_products, 1001);
			int ticketGachaEnable = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("ticket_gacha_enable", 0);
			if (ticketGachaEnable != 0)
			{
				CFFJOHEKJIK_bonusVc = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc;
				HLLLGHINECC_i = 0;
				OKHGOGDCABL_Time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				for (; HLLLGHINECC_i < CFFJOHEKJIK_bonusVc.CDENCMNHNGA_table.Count; HLLLGHINECC_i++)
				{
					if (CFFJOHEKJIK_bonusVc.CDENCMNHNGA_table[HLLLGHINECC_i].EHKLFIBLHPI_IsTimeValid(OKHGOGDCABL_Time))
					{
						JDNODBMEFBA_GetProductRequest = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
						JDNODBMEFBA_GetProductRequest.IPKCADIAAPG_Criteria = LCKOLEDFDAL.DGKCONBHMJA_GetCriteriaForCurrency(CFFJOHEKJIK_bonusVc.CDENCMNHNGA_table[HLLLGHINECC_i].CPGFOBNKKBF_CurrencyId);
						//LAB_016073bc
						while (!JDNODBMEFBA_GetProductRequest.PLOOEECNHFB_IsDone)
							yield return null;
						if (JDNODBMEFBA_GetProductRequest.NPNNPNAIONN_IsError)
						{
							MHKCPJDNJKI_products.Clear();
							_MOBEEPPKFLG_OnFail();
							yield break;
						}
						else
						{
							ALBOGEHBBAH(JDNODBMEFBA_GetProductRequest.NFEAMMJIMPG_Result.MHKCPJDNJKI_products, CFFJOHEKJIK_bonusVc.CDENCMNHNGA_table[HLLLGHINECC_i].CPGFOBNKKBF_CurrencyId);
						}
					}
				}
			}
			if(!DLNDPMNLMGC_IsTutorial)
			{
				int stepup_gacha_enable = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("stepup_gacha_enable", 0);
				if(stepup_gacha_enable != 0)
				{
					bool BEKAMBBOLBO_Done = false;
					bool CNAIDEAFAAM_Error = false;
					BDFEDBLGOPJ_GetStepUpLotRecords = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new BHDAFKEKPEB_GetStepUpLotRecords());
					BDFEDBLGOPJ_GetStepUpLotRecords.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
					{
						//0x16062FC
						BEKAMBBOLBO_Done = true;
						CNAIDEAFAAM_Error = true;
					};
					BDFEDBLGOPJ_GetStepUpLotRecords.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
					{
						//0x1606308
						BEKAMBBOLBO_Done = true;
					};
					//LAB_01606eb4
					while (!BEKAMBBOLBO_Done)
						yield return null;
					if(CNAIDEAFAAM_Error)
					{
						MHKCPJDNJKI_products.Clear();
						_MOBEEPPKFLG_OnFail();
						yield break;
					}
					GGOLBBBGFME = BDFEDBLGOPJ_GetStepUpLotRecords.NFEAMMJIMPG_Result.JOMCOLHEBBI_step_up_lots;
					JFPHGIOBDNG = new List<JBHCLFDBPKP>();
					if (GGOLBBBGFME.Count > 0)
					{
						for (HLLLGHINECC_i = 0; HLLLGHINECC_i < GGOLBBBGFME.Count; HLLLGHINECC_i++)
						{
							BEKAMBBOLBO_Done = false;
							CNAIDEAFAAM_Error = false;
							HHDMGJIKEKF_GetStepUpLotDetail = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new EDOGNHECOMI_GetStepUpLotDetail(false));
							HHDMGJIKEKF_GetStepUpLotDetail.MMEBLOIJBKE_UniqueKey = GGOLBBBGFME[HLLLGHINECC_i].FJGCDPLCIAK_unique_key;
							CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF DMLJLPMBLCH = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
							{
								//0x1606314
								BEKAMBBOLBO_Done = true;
								CNAIDEAFAAM_Error = true;
							};
							HHDMGJIKEKF_GetStepUpLotDetail.MOBEEPPKFLG_OnFail = DMLJLPMBLCH;
							CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF EEIFDMNADPA = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) =>
							{
								//0x1606320
								BEKAMBBOLBO_Done = true;
							};
							HHDMGJIKEKF_GetStepUpLotDetail.BHFHGFKBOHH_OnSuccess = EEIFDMNADPA;
							//LAB_016079a4
							while (!BEKAMBBOLBO_Done)
								yield return null;
							JFPHGIOBDNG.Add(HHDMGJIKEKF_GetStepUpLotDetail.NFEAMMJIMPG_Result);
							HHDMGJIKEKF_GetStepUpLotDetail = null;
						}
						BCNEGDOHICK(GGOLBBBGFME, JFPHGIOBDNG, 1001);
					}
					BDFEDBLGOPJ_GetStepUpLotRecords = null;
					GGOLBBBGFME = null;
					JFPHGIOBDNG = null;
				}
			}
			JCELHAIJDHE = NKIHMCHJIEM();
			if(JCELHAIJDHE != 0)
			{
				JDNODBMEFBA_GetProductRequest = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
				JDNODBMEFBA_GetProductRequest.IPKCADIAAPG_Criteria = LCKOLEDFDAL.DGKCONBHMJA_GetCriteriaForCurrency(JCELHAIJDHE);
				//LAB_01607b2c
				while (!JDNODBMEFBA_GetProductRequest.PLOOEECNHFB_IsDone)
					yield return null;
				if(JDNODBMEFBA_GetProductRequest.NPNNPNAIONN_IsError)
				{
					MHKCPJDNJKI_products.Clear();
					_MOBEEPPKFLG_OnFail();
					yield break;
				}
				ALBOGEHBBAH(JDNODBMEFBA_GetProductRequest.NFEAMMJIMPG_Result.MHKCPJDNJKI_products, JCELHAIJDHE);
			}
			CLAAFINFLJN();
			for(HLLLGHINECC_i = 0; HLLLGHINECC_i < MHKCPJDNJKI_products.Count; HLLLGHINECC_i++)
			{
				if(MHKCPJDNJKI_products[HLLLGHINECC_i] != null && MHKCPJDNJKI_products[HLLLGHINECC_i].KACECFNECON_extra != null)
				{
					List<MCKCJMLOAFP_CurrencyInfo> l = new List<MCKCJMLOAFP_CurrencyInfo>();
					for(int i = 0; i < MHKCPJDNJKI_products[HLLLGHINECC_i].KACECFNECON_extra.ANFKCPGENCM_TicketVcId.Count; i++)
					{
						CEBFFLDKAEC_SecureInt a = MHKCPJDNJKI_products[HLLLGHINECC_i].KACECFNECON_extra.ANFKCPGENCM_TicketVcId[i];
						int JBFLEDKDFCO_cid = a.DNJEJEANJGL_Value;
						MCKCJMLOAFP_CurrencyInfo currency = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.BBEPLKNMICJ_balances.Find((MCKCJMLOAFP_CurrencyInfo _GHPLINIACBB_x) =>
						{
							//0x1606334
							if(_GHPLINIACBB_x.PPFNGGCBJKC_id != JBFLEDKDFCO_cid)
								return false;
							return _GHPLINIACBB_x.BDLNMOIOMHK_total > 0;
						});
						if(currency != null)
						{
							l.Add(currency);
						}
					}
					if(l.Count > 0)
					{
						IBLEFBPKMMF = l[0].PPFNGGCBJKC_id;
						JDNODBMEFBA_GetProductRequest = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
						JDNODBMEFBA_GetProductRequest.IPKCADIAAPG_Criteria = LCKOLEDFDAL.DGKCONBHMJA_GetCriteriaForCurrency(IBLEFBPKMMF);
						//LAB_01607fd4
						while (!JDNODBMEFBA_GetProductRequest.PLOOEECNHFB_IsDone)
							yield return null;
						if(JDNODBMEFBA_GetProductRequest.NPNNPNAIONN_IsError)
						{
							MHKCPJDNJKI_products.Clear();
							_MOBEEPPKFLG_OnFail();
							yield break;
						}
						ALBOGEHBBAH(JDNODBMEFBA_GetProductRequest.NFEAMMJIMPG_Result.MHKCPJDNJKI_products, IBLEFBPKMMF);
						JDNODBMEFBA_GetProductRequest = null;
					}
				}
			}
			CLAAFINFLJN();
			OKINLIEHCEC();
			MHKCPJDNJKI_products.Sort((LOBDIAABMKG_GachaProductData _HKICMNAACDA_a, LOBDIAABMKG_GachaProductData _BNKHBCBJBKI_b) =>
			{
				//0x16061BC
				if(_HKICMNAACDA_a.EEFLOOBOAGF_ViewOrder == _BNKHBCBJBKI_b.EEFLOOBOAGF_ViewOrder)
					return _HKICMNAACDA_a.FDEBLMKEMLF_TypeAndSeriesId - _BNKHBCBJBKI_b.FDEBLMKEMLF_TypeAndSeriesId;
				if(_HKICMNAACDA_a.EEFLOOBOAGF_ViewOrder >= _BNKHBCBJBKI_b.EEFLOOBOAGF_ViewOrder)
				{
					if(_BNKHBCBJBKI_b.EEFLOOBOAGF_ViewOrder < _HKICMNAACDA_a.EEFLOOBOAGF_ViewOrder)
						return -1;
					return 0;
				}
				return 1;
			});
			ECFNAOCFKKN_LastDate = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			_BHFHGFKBOHH_OnSuccess();
		}
	}

	// // RVA: 0x160286C Offset: 0x160286C VA: 0x160286C
	private void CLAAFINFLJN()
	{
		for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
		{
			int a = MHKCPJDNJKI_products[i].FDEBLMKEMLF_TypeAndSeriesId;
			for(int j = 0; j < MHKCPJDNJKI_products.Count; j++)
			{
				if(i != j)
				{
					if(MHKCPJDNJKI_products[j].FDEBLMKEMLF_TypeAndSeriesId == a)
					{
						MHKCPJDNJKI_products[i].EIHCALCFNEJ(MHKCPJDNJKI_products[j]);
						MHKCPJDNJKI_products.RemoveAt(j);
						j--;
					}
				}
			}
		}
	}

	// // RVA: 0x1602AD8 Offset: 0x1602AD8 VA: 0x1602AD8
	public void OMPBFINJHDF_RequestVirtualCurrencyBalancesWithExpiredAt(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		// public CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt LECJIEDBMKP; // 0xC
		// // RVA: 0x160637C Offset: 0x160637C VA: 0x160637C
		// internal void HBLACKDFCAA(CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) { }
		// // RVA: 0x1606AB4 Offset: 0x1606AB4 VA: 0x1606AB4
		// internal void FCGLLIIOJNI(CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) { }

		CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt LECJIEDBMKP = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest<CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt>(new CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt());
		LECJIEDBMKP.CJNLEEEECOC = new List<int>(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH_vcIdsList);
		LECJIEDBMKP.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) => {
			//0x160637C
			GGKFCDDFHFP.Clear();
			for(int i = 0; i < LECJIEDBMKP.NFEAMMJIMPG_Result.OMDCENKJNKP_Balances.Count; i++)
			{
				int id = LECJIEDBMKP.NFEAMMJIMPG_Result.OMDCENKJNKP_Balances[i].PPFNGGCBJKC_id;
				List<CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt.NDMAHKFPCAB.BNMFBONAKMG.KIDKCJGODNG> l = LECJIEDBMKP.NFEAMMJIMPG_Result.OMDCENKJNKP_Balances[i].FKIJMMGIDGG_Free;
				List<CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt.NDMAHKFPCAB.BNMFBONAKMG.KIDKCJGODNG> l2 = LECJIEDBMKP.NFEAMMJIMPG_Result.OMDCENKJNKP_Balances[i].GHOBKCKLCJE_Paid;
				for(int j = 0; j < l.Count; j++)
				{
					MBMMGKJBJGD data = new MBMMGKJBJGD();
					data.PPFNGGCBJKC_id = id;
					data.HNBFOAJIIAL_Count = l[i].BBEMFICNDOG_Remaining;
					data.DJJENNPDPCM_ExpireAt = l[i].HBKKLHCNCKE_ExpireAt;
					GGKFCDDFHFP.Add(data);
				}
				for (int j = 0; j < l2.Count; j++)
				{
					MBMMGKJBJGD data = GGKFCDDFHFP.Find((MBMMGKJBJGD _GHPLINIACBB_x) =>
					{
						//0x1606AC8
						return _GHPLINIACBB_x.DJJENNPDPCM_ExpireAt == l2[i].HBKKLHCNCKE_ExpireAt;
					});
					if(data == null)
					{
						data = new MBMMGKJBJGD();
						data.PPFNGGCBJKC_id = id;
						data.HNBFOAJIIAL_Count = l2[i].BBEMFICNDOG_Remaining;
						data.DJJENNPDPCM_ExpireAt = l2[i].HBKKLHCNCKE_ExpireAt;
						GGKFCDDFHFP.Add(data);
					}
					else
					{
						data.HNBFOAJIIAL_Count += l2[i].BBEMFICNDOG_Remaining;
					}
				}
			}
			GGKFCDDFHFP.Sort((MBMMGKJBJGD _HKICMNAACDA_a, MBMMGKJBJGD _BNKHBCBJBKI_b) =>
			{
				//0x1606254
				return _HKICMNAACDA_a.DJJENNPDPCM_ExpireAt.CompareTo(_BNKHBCBJBKI_b.DJJENNPDPCM_ExpireAt);
			});
			if (_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		};
		LECJIEDBMKP.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction JIPCHHHLOMM) => {
			//0x1606AB4
			if(_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
		};
	}

	// // RVA: 0x1602DCC Offset: 0x1602DCC VA: 0x1602DCC
	private bool KOJKNBDFJBJ(KBPDNHOKEKD_ProductId PKLPKMLGFGK)
	{
		if(PKLPKMLGFGK.KHEGONOKLPN_NormalLotFreeSetting != null)
		{
			if(PKLPKMLGFGK.JENBPPBNAHP_PlayerNormalLotFreeState == null || !PKLPKMLGFGK.JENBPPBNAHP_PlayerNormalLotFreeState.LDBPAJKIPKD_IsNextFree)
			{
				EDOHBJAPLPF_JsonData d = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(PKLPKMLGFGK.KLMPFGOCBHC_description);
				if(d.BBAJPINMOEP_Contains("free_only"))
				{
					if((int)d["free_only"] == 1)
						return true;
				}
			}
		}
		DateTime date = Utility.GetLocalDateTime(PKLPKMLGFGK.KBFOIECIADN_opened_at);
		if(date.Minute == 59)
		{
			return NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() - PKLPKMLGFGK.KBFOIECIADN_opened_at < 60;
		}
		return false;
	}

	// // RVA: 0x1603070 Offset: 0x1603070 VA: 0x1603070
	private bool ALBOGEHBBAH(List<KBPDNHOKEKD_ProductId> BBKDLIPKADG, int _APHNELOFGAK_CurrencyId)
	{
		List<Dictionary<int,List<KBPDNHOKEKD_ProductId>>> gachaListByType = new List<Dictionary<int,List<KBPDNHOKEKD_ProductId>>>();
		for(int i = 0; i < 11; i++)
		{
			gachaListByType.Add(new Dictionary<int, List<KBPDNHOKEKD_ProductId>>());
		}
		int saveBeginnerGachaVersion = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BKCJPIPJCCM_sta_lot_done;
		int currentBeginnerGachaVersion = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NCEMAEDMJLO_GetBeginnerGachaVersion(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
		for(int i = 0; i < BBKDLIPKADG.Count; i++)
		{
			if(!BBKDLIPKADG[i].EJENFBLDAIN_IsOwnedMax && !KOJKNBDFJBJ(BBKDLIPKADG[i]))
			{
                GCAHJLOGMCI.KNMMOMEHDON_GachaType gachaType = GCAHJLOGMCI.OLMFIANJBOB_GetType(BBKDLIPKADG[i].KAPMOPMDHJE_label);
				int gachaId = GCAHJLOGMCI.GPAJHMLOPNP_GetSeries(BBKDLIPKADG[i].KAPMOPMDHJE_label);
				if(gachaType == GCAHJLOGMCI.KNMMOMEHDON_GachaType.JGDEHOGIENP_4_Sphere_CostumeTicket || !DLNDPMNLMGC_IsTutorial)
				{
					if(gachaType == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3_Debut)
					{
						if(saveBeginnerGachaVersion != currentBeginnerGachaVersion || !BBKDLIPKADG[i].OPFGFINHFCE_name.Contains(JpStringLiterals.StringLiteral_10431_Jp))
						{
							if(gachaListByType[(int)gachaType].ContainsKey(gachaId))
							{
								gachaListByType[(int)gachaType][gachaId].Add(BBKDLIPKADG[i]);
							}
							else
							{
								gachaListByType[(int)gachaType].Add(gachaId, new List<KBPDNHOKEKD_ProductId>(4) { BBKDLIPKADG[i] });
							}
						}
					}
					else if(gachaType < GCAHJLOGMCI.KNMMOMEHDON_GachaType.AEFCOHJBLPO_11_Num)
					{
						if(saveBeginnerGachaVersion != currentBeginnerGachaVersion || !BBKDLIPKADG[i].OPFGFINHFCE_name.Contains(JpStringLiterals.StringLiteral_10431_Jp))
						{
							if(gachaListByType[(int)gachaType].ContainsKey(gachaId))
							{
								gachaListByType[(int)gachaType][gachaId].Add(BBKDLIPKADG[i]);
							}
							else
							{
								gachaListByType[(int)gachaType].Add(gachaId, new List<KBPDNHOKEKD_ProductId>(4) { BBKDLIPKADG[i] });
							}
						}
					}
				}
            }
		}
		KDGFJJHFKIL(gachaListByType[3], GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3_Debut, _APHNELOFGAK_CurrencyId);
		KDGFJJHFKIL(gachaListByType[4], GCAHJLOGMCI.KNMMOMEHDON_GachaType.JGDEHOGIENP_4_Sphere_CostumeTicket, _APHNELOFGAK_CurrencyId);
		KDGFJJHFKIL(gachaListByType[5], GCAHJLOGMCI.KNMMOMEHDON_GachaType.GKDFKDLFNAJ_5_LimitedTicket1, _APHNELOFGAK_CurrencyId);
		KDGFJJHFKIL(gachaListByType[2], GCAHJLOGMCI.KNMMOMEHDON_GachaType.PHABJLGFJNI_2_Regular, _APHNELOFGAK_CurrencyId);
		KDGFJJHFKIL(gachaListByType[6], GCAHJLOGMCI.KNMMOMEHDON_GachaType.BKNHBNINDOC_6_LimitedTicket2, _APHNELOFGAK_CurrencyId);
		KDGFJJHFKIL(gachaListByType[1], GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1_Normal, _APHNELOFGAK_CurrencyId);
		KDGFJJHFKIL(gachaListByType[9], GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9, _APHNELOFGAK_CurrencyId);
		KDGFJJHFKIL(gachaListByType[10], GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10_LimitedItem, _APHNELOFGAK_CurrencyId);
		return true;
	}

	// // RVA: 0x1603FA0 Offset: 0x1603FA0 VA: 0x1603FA0
	private bool BCNEGDOHICK(List<KOPCFBCDBPC> _JOMCOLHEBBI_step_up_lots, List<JBHCLFDBPKP> IHHEKIJMNLJ, int _APHNELOFGAK_CurrencyId)
	{
		Dictionary<int,int> d = new Dictionary<int,int>();
		for(int i = 0; i < _JOMCOLHEBBI_step_up_lots.Count; i++)
		{
			if(_JOMCOLHEBBI_step_up_lots[i].FJGCDPLCIAK_unique_key.Contains("stepup_"))
			{
				int v = int.Parse(_JOMCOLHEBBI_step_up_lots[i].FJGCDPLCIAK_unique_key.Substring(9, 4));
				if(!d.ContainsKey(v))
					d.Add(v, i);
				else
					d[v] = i;
			}
		}
		DGMLALAJGMA(d, _JOMCOLHEBBI_step_up_lots, IHHEKIJMNLJ, GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8_StepUp, _APHNELOFGAK_CurrencyId);
		return true;
	}

	// // RVA: 0x1603B50 Offset: 0x1603B50 VA: 0x1603B50
	// private void ILNEOCCIPDA(Dictionary<int, List<KBPDNHOKEKD_ProductId>> _EKFKOGHAKNE_GachaList, GCAHJLOGMCI.KNMMOMEHDON_GachaType _INDDJNMPONH_type, int _APHNELOFGAK_CurrencyId) { }

	// // RVA: 0x16038F4 Offset: 0x16038F4 VA: 0x16038F4
	private void KDGFJJHFKIL(Dictionary<int, List<KBPDNHOKEKD_ProductId>> _EKFKOGHAKNE_GachaList, GCAHJLOGMCI.KNMMOMEHDON_GachaType _INDDJNMPONH_type, int _APHNELOFGAK_CurrencyId)
	{
		if(_EKFKOGHAKNE_GachaList.Keys.Count > 0)
		{
			List<int> l = new List<int>(_EKFKOGHAKNE_GachaList.Keys);
			for(int i = l.Count - 1; i >= 0; i--)
			{
				LOBDIAABMKG_GachaProductData data = new LOBDIAABMKG_GachaProductData();
				if(data.KHEKNNFCAOI_Init(_EKFKOGHAKNE_GachaList[l[i]], l[i], _INDDJNMPONH_type, DLNDPMNLMGC_IsTutorial, _APHNELOFGAK_CurrencyId))
				{
					MHKCPJDNJKI_products.Add(data);
				}
			}
		}
	}

	// // RVA: 0x160421C Offset: 0x160421C VA: 0x160421C
	private void DGMLALAJGMA(Dictionary<int, int> BEIEHPNODAM, List<KOPCFBCDBPC> CCBEKGNDDBE, List<JBHCLFDBPKP> BKGFCEIFMNF, GCAHJLOGMCI.KNMMOMEHDON_GachaType _INDDJNMPONH_type, int _APHNELOFGAK_CurrencyId)
	{
		int cnt = BEIEHPNODAM.Keys.Count;
		if(cnt > 0)
		{
			List<int> l = new List<int>(BEIEHPNODAM.Keys);
			for(int i = cnt - 1; i >= 0; i--)
			{
				LOBDIAABMKG_GachaProductData data = new LOBDIAABMKG_GachaProductData();
				int idx = BEIEHPNODAM[l[i]];
				if(data.KHEKNNFCAOI_Init(CCBEKGNDDBE[idx], BKGFCEIFMNF[idx], l[i], _INDDJNMPONH_type, _APHNELOFGAK_CurrencyId))
				{
					MHKCPJDNJKI_products.Add(data);
				}
			}
		}
	}

	// // RVA: 0x1603D6C Offset: 0x1603D6C VA: 0x1603D6C
	// private void BAKCIMHDMMA(List<LOBDIAABMKG_GachaProductData> NNDGIAEFMOG) { }

	// // RVA: 0x1604508 Offset: 0x1604508 VA: 0x1604508
	// private void LGBOLKILENN() { }

	// // RVA: 0x160450C Offset: 0x160450C VA: 0x160450C
	public int GEFFCCAOAFE(int _IOPHIHFOOEP_idx, int IDGLPENLFHJ/* = 0*/)
	{
		LOBDIAABMKG_GachaProductData data = MHKCPJDNJKI_products[_IOPHIHFOOEP_idx];
		IKMBBPDBECA d = MHKCPJDNJKI_products[_IOPHIHFOOEP_idx].KACECFNECON_extra;
		if(d == null)
		{
			data = MHKCPJDNJKI_products.Find((LOBDIAABMKG_GachaProductData JPAEDJJFFOI) =>
			{
				//0x1606B1C
				if(JPAEDJJFFOI.FDEBLMKEMLF_TypeAndSeriesId != data.FDEBLMKEMLF_TypeAndSeriesId)
				{
					return false;
				}
				return JPAEDJJFFOI.KACECFNECON_extra != null;
			});
			if (data == null)
				return IDGLPENLFHJ;
			d = data.KACECFNECON_extra;
		}
		return d.INHOGJODJFJ_GroupId;
	}

	// // RVA: 0x160469C Offset: 0x160469C VA: 0x160469C
	public void DKHDHGAFPGC()
	{
		FJCPJJABKFL.DHDCHLAIAMP.Clear();
		long t = GachaUtility.GetGachaProductsLastOpenTime();
		CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.AGJINOICNJP_GachaLastShowTime = t;
		MGCDMPJLFKP.MIIIIBANPPB data = new MGCDMPJLFKP.MIIIIBANPPB();
		data.CADENLBDAEB_IsNew = false;
		data.FDEBLMKEMLF_TypeAndSeriesId = 0;
		data.CLDKMLONBHJ = 0;
		data.JDDIOOJHIHP = 0;
		data.INHOGJODJFJ_GroupId = 0;
		data.NPDKEIIMCDI_LastShowtime = t;
		FJCPJJABKFL.DHDCHLAIAMP.Add(data);
		FJCPJJABKFL.HJMKBCFJOOH_Save();
		ANGMDEPOBEE();
	}

	// // RVA: 0x1604A54 Offset: 0x1604A54 VA: 0x1604A54
	public void JHPGCAHIDIO_DeleteCache()
	{
		string path = JHJMNLMNPGO_BasePath + "/gach";
		if (File.Exists(path))
			File.Delete(path);
	}

	// // RVA: 0x1604ADC Offset: 0x1604ADC VA: 0x1604ADC
	public void KCILENCPNHD()
    {
		JEKMEPKPADB.PCODDPDFLHK_Load();
	}

	// // RVA: 0x1604B08 Offset: 0x1604B08 VA: 0x1604B08
	public void DLNKOBKDOIB(int _HHGMPEEGFMA_GachaId, int BHBHMFCMLHN)
	{
		JEKMEPKPADB.NIFJAPKCPOK_SetGachaValue(_HHGMPEEGFMA_GachaId, BHBHMFCMLHN);
		JEKMEPKPADB.HJMKBCFJOOH_Save();
	}

	// // RVA: 0x1604B68 Offset: 0x1604B68 VA: 0x1604B68
	public void CIEDHFEKKII()
	{
		CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NDLADIBEHAM_Clear();
		JEKMEPKPADB.NDLADIBEHAM_Clear();
	}

	// // RVA: 0x1604C68 Offset: 0x1604C68 VA: 0x1604C68
	public void HIKNIPGJDAI(int BHBHMFCMLHN)
    {
		CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.INJFPFAJGPK_KeepGachaDraw(BHBHMFCMLHN);
		JEKMEPKPADB.INJFPFAJGPK_KeepGachaDraw(BHBHMFCMLHN);
		JEKMEPKPADB.LDCGCCGDLCB_UpdateSaveGacha(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData);
	}

	// // RVA: 0x1604D98 Offset: 0x1604D98 VA: 0x1604D98
	public void OKINLIEHCEC()
	{
		FJCPJJABKFL.PCODDPDFLHK_Load();
		MGCDMPJLFKP.MIIIIBANPPB data = FJCPJJABKFL.DHDCHLAIAMP.Find((MGCDMPJLFKP.MIIIIBANPPB JPAEDJJFFOI) =>
		{
			//0x16062C4
			return JPAEDJJFFOI.FDEBLMKEMLF_TypeAndSeriesId > 0;
		});
		if(data == null)
		{
			long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			long t = JPAICCMDGHD_GetMaxLastShowDate(time);
			for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
			{
				bool b = false;
				if(MHKCPJDNJKI_products[i].INDDJNMPONH_type != GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1_Normal/*1*/ && MHKCPJDNJKI_products[i].INDDJNMPONH_type != GCAHJLOGMCI.KNMMOMEHDON_GachaType.ANFKBNLLJFN_7/*7*/)
				{
					long t2 = GachaUtility.GetGachaProductOpenTime(MHKCPJDNJKI_products[i]);
					b = t < t2;
					if(b)
					{
						PFLJNIANOHE = true;
					}
				}
				MHKCPJDNJKI_products[i].CADENLBDAEB_IsNew = b;
			}
		}
		else
		{
			for (int i = 0; i < MHKCPJDNJKI_products.Count; i++)
			{
				bool b = false;
				LOBDIAABMKG_GachaProductData MEANCEOIMGE_Summon = MHKCPJDNJKI_products[i];
				if (MHKCPJDNJKI_products[i].INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1_Normal/*1*/ || MHKCPJDNJKI_products[i].INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.ANFKBNLLJFN_7/*7*/)
				{
					b = false;
				}
				else
				{
					int INHOGJODJFJ_GroupId = GEFFCCAOAFE(i, 0);
					MGCDMPJLFKP.MIIIIBANPPB data2 = FJCPJJABKFL.DHDCHLAIAMP.Find((MGCDMPJLFKP.MIIIIBANPPB JPAEDJJFFOI) =>
					{
						//0x1606B60
						return JPAEDJJFFOI.INHOGJODJFJ_GroupId == INHOGJODJFJ_GroupId;
					});
					if(data2 == null)
					{
						PFLJNIANOHE = true;
						b = true;
					}
					else
					{
						b = data2.CADENLBDAEB_IsNew;
					}
				}
				MHKCPJDNJKI_products[i].CADENLBDAEB_IsNew = b;
			}
		}
	}

	// // RVA: 0x1605380 Offset: 0x1605380 VA: 0x1605380
	public long JPAICCMDGHD_GetMaxLastShowDate(long _JHNMKKNEENE_Time)
	{
		long t = 0;
		if(FJCPJJABKFL.DHDCHLAIAMP != null)
		{
			if(FJCPJJABKFL.DHDCHLAIAMP.Count > 0)
			{
				t = FJCPJJABKFL.DHDCHLAIAMP[0].NPDKEIIMCDI_LastShowtime;
			}
		}
		long t2 = System.Math.Max(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.AGJINOICNJP_GachaLastShowTime, t);
		if (_JHNMKKNEENE_Time < t2)
			return 0;
		return t2;
	}

	// // RVA: 0x16055B8 Offset: 0x16055B8 VA: 0x16055B8
	public bool CPGNMGCIIKI()
	{
		return LKBGPLDLNIK.JPIMHNNGJGI(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime()) == 0;
	}

	// // RVA: 0x16056E8 Offset: 0x16056E8 VA: 0x16056E8
	public void CAILKLPCFHK(LOBDIAABMKG_GachaProductData _MEANCEOIMGE_Summon, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		if(_MEANCEOIMGE_Summon.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1_Normal)
		{
			_BHFHGFKBOHH_OnSuccess();
		}
		else if(_MEANCEOIMGE_Summon.INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8_StepUp)
		{
			_MEANCEOIMGE_Summon.OALDDFAJFDL_GetStepUpItemSetRecord(() =>
			{
				//0x1606BE4
				_BHFHGFKBOHH_OnSuccess();
			}, () =>
			{
				//0x1606C10
				_AOCANKOMKFG_OnError();
			});
		}
		else
		{
			_MEANCEOIMGE_Summon.AHOOLEAGACO_GetItemSetRecord(() =>
			{
				//0x1606C3C
				_BHFHGFKBOHH_OnSuccess();
			}, () =>
			{
				//0x1606C68
				_AOCANKOMKFG_OnError();
			});
		}
	}

	// // RVA: 0x16058D0 Offset: 0x16058D0 VA: 0x16058D0
	public void IFDJHOKOEGA()
    {
		HODOGPOKOOJ.JNDKAFPBENO_Gacha.Clear();
		HODOGPOKOOJ.IBBMNGEHDEP_Pickup.Clear();
		for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
		{
			HODOGPOKOOJ.JNDKAFPBENO_Gacha.Add(MHKCPJDNJKI_products[i].FDEBLMKEMLF_TypeAndSeriesId);
			if(MHKCPJDNJKI_products[i].KACECFNECON_extra != null)
			{
				for(int j = 0; j < MHKCPJDNJKI_products[i].KACECFNECON_extra.PGKIHFOKEHL_Feature.Count; j++)
				{
					int val = MHKCPJDNJKI_products[i].KACECFNECON_extra.PGKIHFOKEHL_Feature[j].DNJEJEANJGL_Value;
					int idx = HODOGPOKOOJ.IBBMNGEHDEP_Pickup.FindIndex((int _GHPLINIACBB_x) =>
					{
						//0x1606C94
						return val == _GHPLINIACBB_x;
					});
					if(idx < 0)
					{
						HODOGPOKOOJ.IBBMNGEHDEP_Pickup.Add(val);
					}
				}
			}
		}
    }

	// // RVA: 0x1604918 Offset: 0x1604918 VA: 0x1604918
	public void ANGMDEPOBEE()
	{
		PFLJNIANOHE = false;
		for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
		{
			if(MHKCPJDNJKI_products[i].INDDJNMPONH_type != GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1_Normal /*1*/)
			{
				if (MHKCPJDNJKI_products[i].CADENLBDAEB_IsNew)
				{
					PFLJNIANOHE = true;
					return;
				}
			}
		}
	}

	// // RVA: 0x1605D84 Offset: 0x1605D84 VA: 0x1605D84
	public KBPDNHOKEKD_ProductId.KNEKLJHNHAK_FreeType FJICMLBOJCH(out string APLHNNCBLIJ)
	{
		APLHNNCBLIJ = "";
		int found = -1;
		KBPDNHOKEKD_ProductId.KNEKLJHNHAK_FreeType res = 0;
		for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
		{
			KBPDNHOKEKD_ProductId.KNEKLJHNHAK_FreeType r = MHKCPJDNJKI_products[i].FJICMLBOJCH();
			if(r != KBPDNHOKEKD_ProductId.KNEKLJHNHAK_FreeType.HJNNKCMLGFL_0_None/*0*/ && r != KBPDNHOKEKD_ProductId.KNEKLJHNHAK_FreeType.DKIKNLEDDBK_3_NextFree/*3*/)
			{
				if(res == 0 || res > r)
				{
					found = i;
					res = r;
				}
			}
		}
		if(found > -1)
		{
			APLHNNCBLIJ = MHKCPJDNJKI_products[found].JCIBGEDBOHP_FreeBadgeMess;
		}
		return res;
	}

	// // RVA: 0x1605F14 Offset: 0x1605F14 VA: 0x1605F14
	// private bool MFGDDLPKFGF(KBPDNHOKEKD_ProductId.KNEKLJHNHAK_FreeType _LJPMEHDDBGP_UnlockError) { }

	// // RVA: 0x1605F2C Offset: 0x1605F2C VA: 0x1605F2C
	public bool GGBCCADCPNP()
	{
		foreach(var k in MHKCPJDNJKI_products)
		{
			if (k.CMCNKHLIKPP_HighRarityScene)
				return true;
		}
		return false;
	}
}
