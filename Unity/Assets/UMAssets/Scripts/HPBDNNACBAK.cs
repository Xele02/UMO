using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XeApp.Game.Gacha;

public class HPBDNNACBAK
{
	public class MBMMGKJBJGD
	{
		public int PPFNGGCBJKC_Id { get; set; } // 0x8 FDGEMCPHJCB DEMEPMAEJOO HIGKAIDMOKN
		public int HNBFOAJIIAL_Remaining { get; set; } // 0xC MLBMGFPHPOG EEACFDLDNHD AOFFLCJEKMI
		public long DJJENNPDPCM_ExpireAt { get; set; } // 0x10 OGIFPJBPGDE FOBEMADNEGI KBAEBIIJPCN
	}

	public const int IIGEPHHOIPG = 72;
	private const int EKMKJLJPMCB = 1;
	private bool DLNDPMNLMGC; // 0xC
	private bool DFJNNAOKGPM; // 0xD
	private string JHJMNLMNPGO; // 0x10
	public long ECFNAOCFKKN; // 0x18
	private int CHCMPDJFHHE = -1; // 0x20
	private List<int> PACLICFCHJI = new List<int>(); // 0x24
	public bool PFLJNIANOHE; // 0x28
	public List<int> MILIGHHGOML = new List<int>(); // 0x2C
	private MGCDMPJLFKP FJCPJJABKFL = new MGCDMPJLFKP(); // 0x30
	private FFHFGBLNLGL JEKMEPKPADB = new FFHFGBLNLGL(); // 0x34
	public List<MBMMGKJBJGD> GGKFCDDFHFP = new List<MBMMGKJBJGD>(); // 0x38

	public List<LOBDIAABMKG> MHKCPJDNJKI_GatchaProducts { get; private set; } // 0x8 CPMNDNELDME DFAHGPEFPOO IOMCCGAKKCP


	// // RVA: 0x1601B14 Offset: 0x1601B14 VA: 0x1601B14
	public HPBDNNACBAK()
	{
		JHJMNLMNPGO = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/sys";
		MHKCPJDNJKI_GatchaProducts = new List<LOBDIAABMKG>();
	}

	// // RVA: 0x1601CC4 Offset: 0x1601CC4 VA: 0x1601CC4
	public static int NKIHMCHJIEM()
	{
		int decal_gacha_ticket_currency_id = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("decal_gacha_ticket_currency_id", 2101);
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(decal_gacha_ticket_currency_id) == null)
		{
			Debug.LogError(JpStringLiterals.StringLiteral_11015);
		}
		return decal_gacha_ticket_currency_id;
	}

	// // RVA: 0x1601E48 Offset: 0x1601E48 VA: 0x1601E48
	public static bool FIHFDIBDKKE(int APHNELOFGAK)
	{
		return NKIHMCHJIEM() == APHNELOFGAK;
	}

	// // RVA: 0x1601E6C Offset: 0x1601E6C VA: 0x1601E6C
	public List<LOBDIAABMKG> FIGBNDFBKPE(int APHNELOFGAK)
	{
		List<LOBDIAABMKG> res = new List<LOBDIAABMKG>();
		for (int i = 0; i < MHKCPJDNJKI_GatchaProducts.Count; i++)
		{
			if (MHKCPJDNJKI_GatchaProducts[i].KACECFNECON != null)
			{
				for (int j = 0; j < 10; j++)
				{
					if (MHKCPJDNJKI_GatchaProducts[i].OMNAPCHLBHF((GCAHJLOGMCI.NFCAJPIJFAM)(j + 1)) == APHNELOFGAK)
					{
						res.Add(MHKCPJDNJKI_GatchaProducts[i]);
						break;
					}
				}
			}
		}
		res.Sort((LOBDIAABMKG HKICMNAACDA, LOBDIAABMKG BNKHBCBJBKI) =>
		{
			//0x1606114
			return HKICMNAACDA.EABMLBFHJBH.CompareTo(BNKHBCBJBKI.EABMLBFHJBH);
		});
		return res;
	}

	// // RVA: 0x1602108 Offset: 0x1602108 VA: 0x1602108
	public List<LOBDIAABMKG> NDALDMHNMKI(int KIJAPOFAGPN)
	{
		List<LOBDIAABMKG> res = new List<LOBDIAABMKG>();
		for(int i = 0; i < MHKCPJDNJKI_GatchaProducts.Count; i++)
		{
			if(MHKCPJDNJKI_GatchaProducts[i].KACECFNECON != null)
			{
				for (int j = 0; j < 10; j++)
				{
					if(MHKCPJDNJKI_GatchaProducts[i].HNDLKGOMMNM((GCAHJLOGMCI.NFCAJPIJFAM)(j + 1)).MJNOAMAFNHA == KIJAPOFAGPN)
					{
						res.Add(MHKCPJDNJKI_GatchaProducts[i]);
						break;
					}
				}
			}
		}
		res.Sort((LOBDIAABMKG HKICMNAACDA, LOBDIAABMKG BNKHBCBJBKI) =>
		{
			//0x1606168
			return HKICMNAACDA.EABMLBFHJBH.CompareTo(BNKHBCBJBKI.EABMLBFHJBH);
		});
		return res;
	}

	// // RVA: 0x16023CC Offset: 0x16023CC VA: 0x16023CC
	public void LILDGEPCPPG_GetProducList(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, bool IAHLNPMFJMH = false, bool FBBNPFFEJBN = true)
	{
		DFJNNAOKGPM |= DLNDPMNLMGC && !IAHLNPMFJMH;
		DLNDPMNLMGC = IAHLNPMFJMH;
		if(!IAHLNPMFJMH)
		{
			MHKCPJDNJKI_GatchaProducts.Clear();
			LJODCEJPINC();
			BHFHGFKBOHH();
		}
		else
		{
			if(!FBBNPFFEJBN)
			{
				if(MHKCPJDNJKI_GatchaProducts.Count > 0 && ECFNAOCFKKN != 0)
				{
					int gachaListAvailTime = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("gacha_list_avail_time", 1200);
					long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					if((time - ECFNAOCFKKN) < gachaListAvailTime)
					{
						BHFHGFKBOHH();
					}
				}
			}
			MHKCPJDNJKI_GatchaProducts.Clear();
			N.a.StartCoroutineWatched(AHGFMJOAEPM_Coroutine_GetProductList(BHFHGFKBOHH, MOBEEPPKFLG));
		}
	}

	// // RVA: 0x16026C4 Offset: 0x16026C4 VA: 0x16026C4
	private void LJODCEJPINC()
	{
		LOBDIAABMKG data = new LOBDIAABMKG();
		if (!data.EJGLNKNKLFC(1, GCAHJLOGMCI.KNMMOMEHDON.ANFKBNLLJFN_7/*7*/))
			return;
		MHKCPJDNJKI_GatchaProducts.Add(data);
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B61C0 Offset: 0x6B61C0 VA: 0x6B61C0
	// // RVA: 0x160278C Offset: 0x160278C VA: 0x160278C
	private IEnumerator AHGFMJOAEPM_Coroutine_GetProductList(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		PJKLMCGEJMK OKDOIAEGADK_Server; // 0x20
		NEAPMMJKOKA_GetProducts DLOIHKKKNBB_GetProductRequest; // 0x24
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
		OKDOIAEGADK_Server = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		DLOIHKKKNBB_GetProductRequest = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
		DLOIHKKKNBB_GetProductRequest.IPKCADIAAPG_Criteria = LCKOLEDFDAL.CIPJGLGBKFE();
		while (!DLOIHKKKNBB_GetProductRequest.PLOOEECNHFB_IsDone)
			yield return null;
		if(DLOIHKKKNBB_GetProductRequest.NPNNPNAIONN_IsError)
		{
			MHKCPJDNJKI_GatchaProducts.Clear();
			//LAB_01607234 (psVar22.clear())
			MOBEEPPKFLG();
		}
		else
		{
			ALBOGEHBBAH(DLOIHKKKNBB_GetProductRequest.NFEAMMJIMPG.MHKCPJDNJKI_Products, 1001);
			int ticketGachaEnable = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("ticket_gacha_enable", 0);
			if (ticketGachaEnable != 0)
			{
				CFFJOHEKJIK_bonusVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc;
				HLLLGHINECC_i = 0;
				OKHGOGDCABL_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				for (; HLLLGHINECC_i < CFFJOHEKJIK_bonusVc.CDENCMNHNGA.Count; HLLLGHINECC_i++)
				{
					if (CFFJOHEKJIK_bonusVc.CDENCMNHNGA[HLLLGHINECC_i].EHKLFIBLHPI_IsTimeValid(OKHGOGDCABL_Time))
					{
						JDNODBMEFBA_GetProductRequest = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
						JDNODBMEFBA_GetProductRequest.IPKCADIAAPG_Criteria = LCKOLEDFDAL.DGKCONBHMJA_GetCriteriaForCurrency(CFFJOHEKJIK_bonusVc.CDENCMNHNGA[HLLLGHINECC_i].CPGFOBNKKBF);
						//LAB_016073bc
						while (!JDNODBMEFBA_GetProductRequest.PLOOEECNHFB_IsDone)
							yield return null;
						if (JDNODBMEFBA_GetProductRequest.NPNNPNAIONN_IsError)
						{
							MHKCPJDNJKI_GatchaProducts.Clear();
							MOBEEPPKFLG();
							yield break;
						}
						else
						{
							ALBOGEHBBAH(JDNODBMEFBA_GetProductRequest.NFEAMMJIMPG.MHKCPJDNJKI_Products, CFFJOHEKJIK_bonusVc.CDENCMNHNGA[HLLLGHINECC_i].CPGFOBNKKBF);
						}
					}
				}
			}
			if(!DLNDPMNLMGC)
			{
				int stepup_gacha_enable = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("stepup_gacha_enable", 0);
				if(stepup_gacha_enable != 0)
				{
					bool BEKAMBBOLBO = false;
					bool CNAIDEAFAAM = false;
					BDFEDBLGOPJ_GetStepUpLotRecords = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new BHDAFKEKPEB_GetStepUpLotRecords());
					BDFEDBLGOPJ_GetStepUpLotRecords.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
					{
						//0x16062FC
						BEKAMBBOLBO = true;
						CNAIDEAFAAM = true;
					};
					BDFEDBLGOPJ_GetStepUpLotRecords.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
					{
						//0x1606308
						BEKAMBBOLBO = true;
					};
					//LAB_01606eb4
					while (!BEKAMBBOLBO)
						yield return null;
					if(CNAIDEAFAAM)
					{
						MHKCPJDNJKI_GatchaProducts.Clear();
						MOBEEPPKFLG();
						yield break;
					}
					GGOLBBBGFME = BDFEDBLGOPJ_GetStepUpLotRecords.NFEAMMJIMPG.JOMCOLHEBBI;
					JFPHGIOBDNG = new List<JBHCLFDBPKP>();
					if (GGOLBBBGFME.Count > 0)
					{
						for (HLLLGHINECC_i = 0; HLLLGHINECC_i < GGOLBBBGFME.Count; HLLLGHINECC_i++)
						{
							BEKAMBBOLBO = false;
							CNAIDEAFAAM = false;
							HHDMGJIKEKF_GetStepUpLotDetail = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new EDOGNHECOMI_GetStepUpLotDetail());
							HHDMGJIKEKF_GetStepUpLotDetail.MMEBLOIJBKE = GGOLBBBGFME[HLLLGHINECC_i].FJGCDPLCIAK;
							CACGCMBKHDI_Request.HDHIKGLMOGF DMLJLPMBLCH = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
							{
								//0x1606314
								BEKAMBBOLBO = true;
								CNAIDEAFAAM = true;
							};
							HHDMGJIKEKF_GetStepUpLotDetail.MOBEEPPKFLG_OnFail = DMLJLPMBLCH;
							CACGCMBKHDI_Request.HDHIKGLMOGF EEIFDMNADPA = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
							{
								//0x1606320
								BEKAMBBOLBO = true;
							};
							HHDMGJIKEKF_GetStepUpLotDetail.BHFHGFKBOHH_OnSuccess = EEIFDMNADPA;
							//LAB_016079a4
							while (!BEKAMBBOLBO)
								yield return null;
							JFPHGIOBDNG.Add(HHDMGJIKEKF_GetStepUpLotDetail.NFEAMMJIMPG);
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
					MHKCPJDNJKI_GatchaProducts.Clear();
					MOBEEPPKFLG();
					yield break;
				}
				ALBOGEHBBAH(JDNODBMEFBA_GetProductRequest.NFEAMMJIMPG.MHKCPJDNJKI_Products, JCELHAIJDHE);
			}
			CLAAFINFLJN();
			for(HLLLGHINECC_i = 0; HLLLGHINECC_i < MHKCPJDNJKI_GatchaProducts.Count; HLLLGHINECC_i++)
			{
				if(MHKCPJDNJKI_GatchaProducts[HLLLGHINECC_i] != null && MHKCPJDNJKI_GatchaProducts[HLLLGHINECC_i].KACECFNECON != null)
				{
					List<MCKCJMLOAFP_CurrencyInfo> l = new List<MCKCJMLOAFP_CurrencyInfo>();
					for(int i = 0; i < MHKCPJDNJKI_GatchaProducts[HLLLGHINECC_i].KACECFNECON.ANFKCPGENCM.Count; i++)
					{
						CEBFFLDKAEC_SecureInt a = MHKCPJDNJKI_GatchaProducts[HLLLGHINECC_i].KACECFNECON.ANFKCPGENCM[i];
						int JBFLEDKDFCO = a.DNJEJEANJGL_Value;
						MCKCJMLOAFP_CurrencyInfo currency = CIOECGOMILE.HHCJCDFCLOB.BBEPLKNMICJ_Currencies.Find((MCKCJMLOAFP_CurrencyInfo GHPLINIACBB) =>
						{
							//0x1606334
							if(GHPLINIACBB.PPFNGGCBJKC_Id != JBFLEDKDFCO)
								return false;
							return GHPLINIACBB.BDLNMOIOMHK_Total > 0;
						});
						if(currency != null)
						{
							l.Add(currency);
						}
					}
					if(l.Count > 0)
					{
						IBLEFBPKMMF = l[0].PPFNGGCBJKC_Id;
						JDNODBMEFBA_GetProductRequest = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
						JDNODBMEFBA_GetProductRequest.IPKCADIAAPG_Criteria = LCKOLEDFDAL.DGKCONBHMJA_GetCriteriaForCurrency(IBLEFBPKMMF);
						//LAB_01607fd4
						while (!JDNODBMEFBA_GetProductRequest.PLOOEECNHFB_IsDone)
							yield return null;
						if(JDNODBMEFBA_GetProductRequest.NPNNPNAIONN_IsError)
						{
							MHKCPJDNJKI_GatchaProducts.Clear();
							MOBEEPPKFLG();
							yield break;
						}
						ALBOGEHBBAH(JDNODBMEFBA_GetProductRequest.NFEAMMJIMPG.MHKCPJDNJKI_Products, IBLEFBPKMMF);
						JDNODBMEFBA_GetProductRequest = null;
					}
				}
			}
			CLAAFINFLJN();
			OKINLIEHCEC();
			MHKCPJDNJKI_GatchaProducts.Sort((LOBDIAABMKG HKICMNAACDA, LOBDIAABMKG BNKHBCBJBKI) =>
			{
				//0x16061BC
				TodoLogger.LogError(0, "Sort");
				return 0;
			});
			ECFNAOCFKKN = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			BHFHGFKBOHH();
		}
	}

	// // RVA: 0x160286C Offset: 0x160286C VA: 0x160286C
	private void CLAAFINFLJN()
	{
		TodoLogger.LogError(0, "CLAAFINFLJN");
	}

	// // RVA: 0x1602AD8 Offset: 0x1602AD8 VA: 0x1602AD8
	public void OMPBFINJHDF_RequestVirtualCurrencyBalancesWithExpiredAt(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		// public CNABKDIKIOB LECJIEDBMKP; // 0xC
		// // RVA: 0x160637C Offset: 0x160637C VA: 0x160637C
		// internal void HBLACKDFCAA(CACGCMBKHDI JIPCHHHLOMM) { }
		// // RVA: 0x1606AB4 Offset: 0x1606AB4 VA: 0x1606AB4
		// internal void FCGLLIIOJNI(CACGCMBKHDI JIPCHHHLOMM) { }

		CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt LECJIEDBMKP = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest<CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt>(new CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt());
		LECJIEDBMKP.CJNLEEEECOC = new List<int>(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH);
		LECJIEDBMKP.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) => {
			//0x160637C
			GGKFCDDFHFP.Clear();
			for(int i = 0; i < LECJIEDBMKP.NFEAMMJIMPG.OMDCENKJNKP.Count; i++)
			{
				int id = LECJIEDBMKP.NFEAMMJIMPG.OMDCENKJNKP[i].PPFNGGCBJKC_Id;
				List<CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt.NDMAHKFPCAB.BNMFBONAKMG.KIDKCJGODNG> l = LECJIEDBMKP.NFEAMMJIMPG.OMDCENKJNKP[i].FKIJMMGIDGG_Free;
				List<CNABKDIKIOB_RequestVirtualCurrencyBalancesWithExpiredAt.NDMAHKFPCAB.BNMFBONAKMG.KIDKCJGODNG> l2 = LECJIEDBMKP.NFEAMMJIMPG.OMDCENKJNKP[i].GHOBKCKLCJE_Paid;
				for(int j = 0; j < l.Count; j++)
				{
					MBMMGKJBJGD data = new MBMMGKJBJGD();
					data.PPFNGGCBJKC_Id = id;
					data.HNBFOAJIIAL_Remaining = l[i].BBEMFICNDOG_Remaining;
					data.DJJENNPDPCM_ExpireAt = l[i].HBKKLHCNCKE_ExpireAt;
					GGKFCDDFHFP.Add(data);
				}
				for (int j = 0; j < l2.Count; j++)
				{
					MBMMGKJBJGD data = GGKFCDDFHFP.Find((MBMMGKJBJGD GHPLINIACBB) =>
					{
						//0x1606AC8
						return GHPLINIACBB.DJJENNPDPCM_ExpireAt == l2[i].HBKKLHCNCKE_ExpireAt;
					});
					if(data == null)
					{
						data = new MBMMGKJBJGD();
						data.PPFNGGCBJKC_Id = id;
						data.HNBFOAJIIAL_Remaining = l2[i].BBEMFICNDOG_Remaining;
						data.DJJENNPDPCM_ExpireAt = l2[i].HBKKLHCNCKE_ExpireAt;
						GGKFCDDFHFP.Add(data);
					}
					else
					{
						data.HNBFOAJIIAL_Remaining += l2[i].BBEMFICNDOG_Remaining;
					}
				}
			}
			GGKFCDDFHFP.Sort((MBMMGKJBJGD HKICMNAACDA, MBMMGKJBJGD BNKHBCBJBKI) =>
			{
				//0x1606254
				return HKICMNAACDA.DJJENNPDPCM_ExpireAt.CompareTo(BNKHBCBJBKI.DJJENNPDPCM_ExpireAt);
			});
			if (BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		};
		LECJIEDBMKP.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) => {
			//0x1606AB4
			TodoLogger.LogError(0, "TODO");
		};
	}

	// // RVA: 0x1602DCC Offset: 0x1602DCC VA: 0x1602DCC
	// private bool KOJKNBDFJBJ(KBPDNHOKEKD PKLPKMLGFGK) { }

	// // RVA: 0x1603070 Offset: 0x1603070 VA: 0x1603070
	private bool ALBOGEHBBAH(List<KBPDNHOKEKD_ProductId> BBKDLIPKADG, int APHNELOFGAK)
	{
		TodoLogger.LogError(0, "ALBOGEHBBAH");
		return true;
	}

	// // RVA: 0x1603FA0 Offset: 0x1603FA0 VA: 0x1603FA0
	private bool BCNEGDOHICK(List<KOPCFBCDBPC> JOMCOLHEBBI, List<JBHCLFDBPKP> IHHEKIJMNLJ, int APHNELOFGAK)
	{
		TodoLogger.LogError(0, "BCNEGDOHICK");
		return true;
	}

	// // RVA: 0x1603B50 Offset: 0x1603B50 VA: 0x1603B50
	// private void ILNEOCCIPDA(Dictionary<int, List<KBPDNHOKEKD>> EKFKOGHAKNE, GCAHJLOGMCI.KNMMOMEHDON INDDJNMPONH, int APHNELOFGAK) { }

	// // RVA: 0x16038F4 Offset: 0x16038F4 VA: 0x16038F4
	// private void KDGFJJHFKIL(Dictionary<int, List<KBPDNHOKEKD>> EKFKOGHAKNE, GCAHJLOGMCI.KNMMOMEHDON INDDJNMPONH, int APHNELOFGAK) { }

	// // RVA: 0x160421C Offset: 0x160421C VA: 0x160421C
	// private void DGMLALAJGMA(Dictionary<int, int> BEIEHPNODAM, List<KOPCFBCDBPC> CCBEKGNDDBE, List<JBHCLFDBPKP> BKGFCEIFMNF, GCAHJLOGMCI.KNMMOMEHDON INDDJNMPONH, int APHNELOFGAK) { }

	// // RVA: 0x1603D6C Offset: 0x1603D6C VA: 0x1603D6C
	// private void BAKCIMHDMMA(List<LOBDIAABMKG> NNDGIAEFMOG) { }

	// // RVA: 0x1604508 Offset: 0x1604508 VA: 0x1604508
	// private void LGBOLKILENN() { }

	// // RVA: 0x160450C Offset: 0x160450C VA: 0x160450C
	public int GEFFCCAOAFE(int IOPHIHFOOEP, int IDGLPENLFHJ = 0)
	{
		LOBDIAABMKG data = MHKCPJDNJKI_GatchaProducts[IOPHIHFOOEP];
		IKMBBPDBECA d = MHKCPJDNJKI_GatchaProducts[IOPHIHFOOEP].KACECFNECON;
		if(d == null)
		{
			data = MHKCPJDNJKI_GatchaProducts.Find((LOBDIAABMKG JPAEDJJFFOI) =>
			{
				//0x1606B1C
				if(JPAEDJJFFOI.FDEBLMKEMLF_TypeAndSeriesId != data.FDEBLMKEMLF_TypeAndSeriesId)
				{
					return false;
				}
				return JPAEDJJFFOI.KACECFNECON != null;
			});
			if (data == null)
				return IDGLPENLFHJ;
			d = data.KACECFNECON;
		}
		return d.INHOGJODJFJ;
	}

	// // RVA: 0x160469C Offset: 0x160469C VA: 0x160469C
	public void DKHDHGAFPGC()
	{
		FJCPJJABKFL.DHDCHLAIAMP.Clear();
		long t = GachaUtility.GetGachaProductsLastOpenTime();
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.AGJINOICNJP_GachaLastShowTime = t;
		MGCDMPJLFKP.MIIIIBANPPB data = new MGCDMPJLFKP.MIIIIBANPPB();
		data.CADENLBDAEB = false;
		data.FDEBLMKEMLF = 0;
		data.CLDKMLONBHJ = 0;
		data.JDDIOOJHIHP = 0;
		data.INHOGJODJFJ = 0;
		data.NPDKEIIMCDI = t;
		FJCPJJABKFL.DHDCHLAIAMP.Add(data);
		FJCPJJABKFL.HJMKBCFJOOH_Save();
		ANGMDEPOBEE();
	}

	// // RVA: 0x1604A54 Offset: 0x1604A54 VA: 0x1604A54
	public void JHPGCAHIDIO_DeleteCache()
	{
		string path = JHJMNLMNPGO + "/gach";
		if (File.Exists(path))
			File.Delete(path);
	}

	// // RVA: 0x1604ADC Offset: 0x1604ADC VA: 0x1604ADC
	public void KCILENCPNHD()
    {
		JEKMEPKPADB.PCODDPDFLHK();
	}

	// // RVA: 0x1604B08 Offset: 0x1604B08 VA: 0x1604B08
	// public void DLNKOBKDOIB(int HHGMPEEGFMA, int BHBHMFCMLHN) { }

	// // RVA: 0x1604B68 Offset: 0x1604B68 VA: 0x1604B68
	public void CIEDHFEKKII()
	{
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NDLADIBEHAM_ClearGachaDrawList();
		JEKMEPKPADB.NDLADIBEHAM();
	}

	// // RVA: 0x1604C68 Offset: 0x1604C68 VA: 0x1604C68
	public void HIKNIPGJDAI(int BHBHMFCMLHN)
    {
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.INJFPFAJGPK_KeepGachaDraw(BHBHMFCMLHN);
		JEKMEPKPADB.INJFPFAJGPK_KeepGachaDraw(BHBHMFCMLHN);
		JEKMEPKPADB.LDCGCCGDLCB_UpdateSaveGacha(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
	}

	// // RVA: 0x1604D98 Offset: 0x1604D98 VA: 0x1604D98
	public void OKINLIEHCEC()
	{
		FJCPJJABKFL.PCODDPDFLHK();
		MGCDMPJLFKP.MIIIIBANPPB data = FJCPJJABKFL.DHDCHLAIAMP.Find((MGCDMPJLFKP.MIIIIBANPPB JPAEDJJFFOI) =>
		{
			//0x16062C4
			return JPAEDJJFFOI.FDEBLMKEMLF > 0;
		});
		if(data == null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			long t = JPAICCMDGHD(time);
			for(int i = 0; i < MHKCPJDNJKI_GatchaProducts.Count; i++)
			{
				bool b = false;
				if(MHKCPJDNJKI_GatchaProducts[i].INDDJNMPONH_Category != GCAHJLOGMCI.KNMMOMEHDON.CCAPCGPIIPF_1/*1*/ && MHKCPJDNJKI_GatchaProducts[i].INDDJNMPONH_Category != GCAHJLOGMCI.KNMMOMEHDON.ANFKBNLLJFN_7/*7*/)
				{
					long t2 = GachaUtility.GetGachaProductOpenTime(MHKCPJDNJKI_GatchaProducts[i]);
					b = t < t2;
					if(b)
					{
						PFLJNIANOHE = true;
					}
				}
				MHKCPJDNJKI_GatchaProducts[i].CADENLBDAEB = b;
			}
		}
		else
		{
			for (int i = 0; i < MHKCPJDNJKI_GatchaProducts.Count; i++)
			{
				bool b = false;
				LOBDIAABMKG MEANCEOIMGE = MHKCPJDNJKI_GatchaProducts[i];
				if (MHKCPJDNJKI_GatchaProducts[i].INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.CCAPCGPIIPF_1/*1*/ || MHKCPJDNJKI_GatchaProducts[i].INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.ANFKBNLLJFN_7/*7*/)
				{
					b = false;
				}
				else
				{
					int INHOGJODJFJ = GEFFCCAOAFE(i, 0);
					MGCDMPJLFKP.MIIIIBANPPB data2 = FJCPJJABKFL.DHDCHLAIAMP.Find((MGCDMPJLFKP.MIIIIBANPPB JPAEDJJFFOI) =>
					{
						//0x1606B60
						return JPAEDJJFFOI.INHOGJODJFJ == INHOGJODJFJ;
					});
					if(data2 == null)
					{
						PFLJNIANOHE = true;
						b = true;
					}
					else
					{
						b = data2.CADENLBDAEB;
					}
				}
				MHKCPJDNJKI_GatchaProducts[i].CADENLBDAEB = b;
			}
		}
	}

	// // RVA: 0x1605380 Offset: 0x1605380 VA: 0x1605380
	public long JPAICCMDGHD(long JHNMKKNEENE)
	{
		long t = 0;
		if(FJCPJJABKFL.DHDCHLAIAMP != null)
		{
			if(FJCPJJABKFL.DHDCHLAIAMP.Count > 0)
			{
				t = FJCPJJABKFL.DHDCHLAIAMP[0].NPDKEIIMCDI;
			}
		}
		long t2 = Math.Max(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.AGJINOICNJP_GachaLastShowTime, t);
		if (JHNMKKNEENE < t2)
			return 0;
		return t2;
	}

	// // RVA: 0x16055B8 Offset: 0x16055B8 VA: 0x16055B8
	public bool CPGNMGCIIKI()
	{
		return LKBGPLDLNIK.JPIMHNNGJGI(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime()) == 0;
	}

	// // RVA: 0x16056E8 Offset: 0x16056E8 VA: 0x16056E8
	// public void CAILKLPCFHK(LOBDIAABMKG MEANCEOIMGE, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x16058D0 Offset: 0x16058D0 VA: 0x16058D0
	public void IFDJHOKOEGA()
    {
		HODOGPOKOOJ.JNDKAFPBENO_Gacha.Clear();
		HODOGPOKOOJ.IBBMNGEHDEP_Pickup.Clear();
		for(int i = 0; i < MHKCPJDNJKI_GatchaProducts.Count; i++)
		{
			HODOGPOKOOJ.JNDKAFPBENO_Gacha.Add(MHKCPJDNJKI_GatchaProducts[i].FDEBLMKEMLF_TypeAndSeriesId);
			if(MHKCPJDNJKI_GatchaProducts[i].KACECFNECON != null)
			{
				for(int j = 0; j < MHKCPJDNJKI_GatchaProducts[i].KACECFNECON.PGKIHFOKEHL.Count; j++)
				{
					int val = MHKCPJDNJKI_GatchaProducts[i].KACECFNECON.PGKIHFOKEHL[j].DNJEJEANJGL_Value;
					int idx = HODOGPOKOOJ.IBBMNGEHDEP_Pickup.FindIndex((int GHPLINIACBB) =>
					{
						//0x1606C94
						return val == GHPLINIACBB;
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
		for(int i = 0; i < MHKCPJDNJKI_GatchaProducts.Count; i++)
		{
			if(MHKCPJDNJKI_GatchaProducts[i].INDDJNMPONH_Category != GCAHJLOGMCI.KNMMOMEHDON.CCAPCGPIIPF_1 /*1*/)
			{
				if (MHKCPJDNJKI_GatchaProducts[i].CADENLBDAEB)
				{
					PFLJNIANOHE = true;
					return;
				}
			}
		}
	}

	// // RVA: 0x1605D84 Offset: 0x1605D84 VA: 0x1605D84
	public KBPDNHOKEKD_ProductId.KNEKLJHNHAK FJICMLBOJCH(out string APLHNNCBLIJ)
	{
		APLHNNCBLIJ = "";
		int found = -1;
		KBPDNHOKEKD_ProductId.KNEKLJHNHAK res = 0;
		for(int i = 0; i < MHKCPJDNJKI_GatchaProducts.Count; i++)
		{
			KBPDNHOKEKD_ProductId.KNEKLJHNHAK r = MHKCPJDNJKI_GatchaProducts[i].FJICMLBOJCH();
			if(r != KBPDNHOKEKD_ProductId.KNEKLJHNHAK.HJNNKCMLGFL_0/*0*/ && r != KBPDNHOKEKD_ProductId.KNEKLJHNHAK.DKIKNLEDDBK_3/*3*/)
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
			APLHNNCBLIJ = MHKCPJDNJKI_GatchaProducts[found].JCIBGEDBOHP;
		}
		return res;
	}

	// // RVA: 0x1605F14 Offset: 0x1605F14 VA: 0x1605F14
	// private bool MFGDDLPKFGF(KBPDNHOKEKD.KNEKLJHNHAK LJPMEHDDBGP) { }

	// // RVA: 0x1605F2C Offset: 0x1605F2C VA: 0x1605F2C
	public bool GGBCCADCPNP()
	{
		foreach(var k in MHKCPJDNJKI_GatchaProducts)
		{
			if (k.CMCNKHLIKPP_HighRarityScene)
				return true;
		}
		return false;
	}
}
