
using System.Collections;
using System.Collections.Generic;
using SakashoSystemCallback;
using XeSys;

public class KDDNHFJFENA
{
	public string FJGCDPLCIAK_unique_key; // 0x8
	public string JPBAJIPKCPG_Sku; // 0xC
}

public class FHPFLAGNCAF
{
	public string FJGCDPLCIAK_unique_key; // 0x8
	public string OPFGFINHFCE_name; // 0xC
	public string KLMPFGOCBHC_description; // 0x10
	public string IPFEKNMBEBI_inventory_message; // 0x14
	public int NPPGKNGIFGK_price; // 0x18
	public string NGIKLCDKAMB_FormatedPrice; // 0x1C
	public string JMEMGIPGGIK_currency_code; // 0x20
	public int OJIMENABACH_price_amount_micros; // 0x24
	public string KACECFNECON_extra; // 0x28
	public long KBFOIECIADN_opened_at; // 0x30
	public long EGBOHDFBAPB_closed_at; // 0x38
	public KDDNHFJFENA IPOKMIAHMNF_PlatformProduct; // 0x40

	//// RVA: 0x14E8444 Offset: 0x14E8444 VA: 0x14E8444
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		FJGCDPLCIAK_unique_key = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, "unique_key");
		OPFGFINHFCE_name = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, "name");
		KLMPFGOCBHC_description = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, "description");
		IPFEKNMBEBI_inventory_message = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, "inventory_message");
		NPPGKNGIFGK_price = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_data, "price");
		NGIKLCDKAMB_FormatedPrice = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, "formatted_price");
		JMEMGIPGGIK_currency_code = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, "currency_code");
		OJIMENABACH_price_amount_micros = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_data, "price_amount_micros");
		KACECFNECON_extra = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, "extra");
		KBFOIECIADN_opened_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_data, "opened_at");
		EGBOHDFBAPB_closed_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_data, "closed_at");
		IPOKMIAHMNF_PlatformProduct = new KDDNHFJFENA();
		IPOKMIAHMNF_PlatformProduct.FJGCDPLCIAK_unique_key = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data["platform_product_sku"], "unique_key");
		IPOKMIAHMNF_PlatformProduct.JPBAJIPKCPG_Sku = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data["platform_product_sku"], "platform_sku");
	}

	//// RVA: 0x14E8700 Offset: 0x14E8700 VA: 0x14E8700
	//public void DJMMLIICFBG() { }
}

public class NHPDPKHMFEP
{
	public enum CJDLIFEENBF
	{
		GDMHELGCMHC = 0,
		KPFIEBIKDFN_1 = 1,
		GGCDANOKPMB_2 = 2,
		EANGJBHNNHF_3 = 3,
		HHEAABDHNAE_4 = 4,
		NGBOABGLAMM_5 = 5,
	}

	public enum GGNEBJEIFCP
	{
		CCAPCGPIIPF_0 = 0,
		AJAHGGBMOJE_1 = 1,
	}
	
	private const long HEJACPECLEH = 9223372036854775807;
	public static bool KKCKPHAFBDO = false; // 0x4
	public static string JHGKHBGAJJJ = JpStringLiterals.StringLiteral_9874; // 0x8
	public static string JKKDACNKPCP = JpStringLiterals.StringLiteral_9874; // 0xC
	public CJDLIFEENBF KCKKCNPGMDC; // 0x8
	private bool HNNAJBJCNEJ; // 0xC
	private JAILOEFCNJP.BEBLECKOAPK MKBOKLLDCFI; // 0x10
	private bool BHGMFDECGPG; // 0x14
	private long AGHHAHBJGMH; // 0x18
	public List<FHPFLAGNCAF> MHKCPJDNJKI_products = new List<FHPFLAGNCAF>(); // 0x20
	public JKNGJFOBADP BEJHIEGCGNE = new JKNGJFOBADP(); // 0x24
	public List<GJDFHLBONOL> LKNKNKAALJO = new List<GJDFHLBONOL>(); // 0x28
	public int DMFNALAGLHH; // 0x2C

	public static NHPDPKHMFEP HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public bool DLGMLAJMLOP { 
		get
		{//JOMOJIMDBDO 0x18977BC
			if(!BHGMFDECGPG)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB == null)
					return false;
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetIntParam("always_get_subscription", 0) != 0;
			}
			return true;
		} 
		set
		{ // LDODJDMAEHG 0x1897910
			BHGMFDECGPG = value;
		} }

	// // RVA: 0x1897918 Offset: 0x1897918 VA: 0x1897918
	public void IJBGPAENLJA()
	{
		HHCJCDFCLOB = this;
	}

	// // RVA: 0x1897998 Offset: 0x1897998 VA: 0x1897998
	private bool AIJFDCIDDLO(SakashoErrorId _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id < SakashoErrorId.CURRENCY_ID_NOT_FOUND)
		{
			if(_PPFNGGCBJKC_id <= SakashoErrorId.STORE_SERVER_ERROR || _PPFNGGCBJKC_id > SakashoErrorId.CANNOT_MAKE_PAYMENTS)
				return _PPFNGGCBJKC_id == SakashoErrorId.UNSUPPORTED_API_CALLED;
			return true;
		}
		if(_PPFNGGCBJKC_id != SakashoErrorId.IAB_APP_PUBLIC_KEY_NOT_FOUND && _PPFNGGCBJKC_id != SakashoErrorId.BAD_REQUEST)
			return false;
		return true;
	}

	// // RVA: 0x18979DC Offset: 0x18979DC VA: 0x18979DC
	public void OFKONDFPMLJ_GetProducts(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		MHKCPJDNJKI_products.Clear();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.AJHBAOCLNDF_MasterSw == 0)
		{
			_BHFHGFKBOHH_OnSuccess();
			return;
		}
		AHOBHNDOEBO req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new AHOBHNDOEBO());
		req.NBFDEFGFLPJ = AIJFDCIDDLO;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x189BF54
			for(int i = 0; i < req.NFEAMMJIMPG_Result.MHKCPJDNJKI_products.Count; i++)
			{
				MHKCPJDNJKI_products.Add(req.NFEAMMJIMPG_Result.MHKCPJDNJKI_products[i]);
			}
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x189C0D0
			if(AIJFDCIDDLO(req.CJMFJOMECKI_ErrorId))
				_BHFHGFKBOHH_OnSuccess();
			else
				_AOCANKOMKFG_OnError();
		};
	}

	// // RVA: 0x1897D38 Offset: 0x1897D38 VA: 0x1897D38
	public void NDAIOIOMPGG(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		OAGBCBBHMPF.NALHDBIKFJO CMCKNKKCNDK_status = OAGBCBBHMPF.NALHDBIKFJO.HJNNKCMLGFL_0_None;
		long CPFDDHIEODD_AppleStartedAt = 0;
		long LCNMPBBDGPJ_AppleExpiredAt = 0;
		long CBJBEGPLJDO_StartedAt = 0;
		long LPHAOMAKKNF_ExpiredAt = 0;
		long FDAEDIPOONF_GoogleStartedAt = 0;
		long PCHNPJFFJJM_GoogleExpiredAt = 0;
		if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.AJHBAOCLNDF_MasterSw != 0)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JHFIPCIHJNL_Base.IJHBIMNKOMC_tutorial_end == 2)
			{
				long EOLFJGMAJAB_CurrentTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				if(!DLGMLAJMLOP)
				{
					int mpass_update_duration = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetIntParam("mpass_update_duration", 10800);
					if((EOLFJGMAJAB_CurrentTime - AGHHAHBJGMH) < mpass_update_duration)
					{
						_BHFHGFKBOHH_OnSuccess();
					}
					HNNAJBJCNEJ = false;
					LGIDLHLBFFJ_MonthlyPass PJJEOFOFDCO = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass;
					string KHACGAGBDHN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.EFEGBHACJAL_GetStringParam("topplan_unique_key", "");
					OAGBCBBHMPF.NALHDBIKFJO GAFIOALKHIM_BfStatus = OAGBCBBHMPF.NALHDBIKFJO.HJNNKCMLGFL_0_None;
					if(PJJEOFOFDCO.KJBOIGIDKIF_Platform == 0)
					{
						PJJEOFOFDCO.KJBOIGIDKIF_Platform = 1;
					}
					string EEMFGMEEBDC_BfPlatform = "";
					string NJFKGJKINAG_AfPlatform = "google";
					EEMFGMEEBDC_BfPlatform = PJJEOFOFDCO.KJBOIGIDKIF_Platform == 1 ? "google" : "apple";
					int OCHIFBIBEOK = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetIntParam("hotfix_3_4_1_android", 0);
					long BMHKJPHNCIJ_BfStartedAt = PJJEOFOFDCO.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt;
					long KMJCPOGCJDG_BfExpiredAt = PJJEOFOFDCO.FMPLMFLMJNE_Last[0].NKMNFPMMJND_expired_at;
					if(KMJCPOGCJDG_BfExpiredAt != 0)
					{
						KMJCPOGCJDG_BfExpiredAt = Utility.RoundDownDayUnixTime(KMJCPOGCJDG_BfExpiredAt, 86399);
					}
					BCEHKBJAEDM NPALHBGHNKN = null;
					BJGEJMNDOLK_GetSubscriptionStatuses COJNCNGHIJC_Req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new BJGEJMNDOLK_GetSubscriptionStatuses());
					COJNCNGHIJC_Req.NBFDEFGFLPJ = AIJFDCIDDLO;
					COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
					{
						//0x189C188
						if(COJNCNGHIJC_Req.NFEAMMJIMPG_Result.FCABPFLKKBC_subscription_statuses.Count < 1)
						{
							JHGKHBGAJJJ = "no data";
							JKKDACNKPCP = "no data";
						}
						else
						{
							long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							long a3 = 0;
							foreach(var k in COJNCNGHIJC_Req.NFEAMMJIMPG_Result.FCABPFLKKBC_subscription_statuses)
							{
								long a1 = 0;
								if(k.LKCCMBEOLLA != null)
								{
									a1 = k.LKCCMBEOLLA.NKMNFPMMJND_expired_at;
								}
								long a2 = 0;
								if(k.PACPEOKLGCI_Google != null)
								{
									a2 = k.PACPEOKLGCI_Google.NKMNFPMMJND_expired_at;
								}
								if(a1 < a2)
									a1 = a2;
								if(OCHIFBIBEOK > 0 && !string.IsNullOrEmpty(k.FJGCDPLCIAK_unique_key) && k.FJGCDPLCIAK_unique_key == KHACGAGBDHN && a1 >= time)
								{
									NPALHBGHNKN = k;
									break;
								}
								if(a3 < a1)
								{
									NPALHBGHNKN = k;
									a3 = a1;
								}
							}
							if(NPALHBGHNKN == null || NPALHBGHNKN.LKCCMBEOLLA == null)
							{
								JHGKHBGAJJJ = JpStringLiterals.StringLiteral_12619;
								JKKDACNKPCP = JpStringLiterals.StringLiteral_12619;
							}
							else
							{
								CBJBEGPLJDO_StartedAt = NPALHBGHNKN.LKCCMBEOLLA.FDFGEMODIIF_StartedAt;
								LPHAOMAKKNF_ExpiredAt = NPALHBGHNKN.LKCCMBEOLLA.NKMNFPMMJND_expired_at;
							}
							if(NPALHBGHNKN != null)
							{
								if(NPALHBGHNKN.PACPEOKLGCI_Google != null)
								{
									CPFDDHIEODD_AppleStartedAt = NPALHBGHNKN.PACPEOKLGCI_Google.FDFGEMODIIF_StartedAt;
									LCNMPBBDGPJ_AppleExpiredAt = NPALHBGHNKN.PACPEOKLGCI_Google.NKMNFPMMJND_expired_at;
								}
								if(NPALHBGHNKN.FPIKAFLHBMO_Apple != null)
								{
									FDAEDIPOONF_GoogleStartedAt = NPALHBGHNKN.FPIKAFLHBMO_Apple.FDFGEMODIIF_StartedAt;
									PCHNPJFFJJM_GoogleExpiredAt = NPALHBGHNKN.FPIKAFLHBMO_Apple.NKMNFPMMJND_expired_at;
								}
							}
						}
						if(NPALHBGHNKN != null && !string.IsNullOrEmpty(NPALHBGHNKN.FJGCDPLCIAK_unique_key))
						{
							PJJEOFOFDCO.CPENFPEPDFC_Lguk.DNJEJEANJGL_Value = NPALHBGHNKN.FJGCDPLCIAK_unique_key;
						}
						string str = "";
						if(!JAILOEFCNJP.GEOMLGKCCNI(PJJEOFOFDCO, COJNCNGHIJC_Req.NFEAMMJIMPG_Result.FCABPFLKKBC_subscription_statuses, EOLFJGMAJAB_CurrentTime, out str, out MKBOKLLDCFI))
						{
							long st = PJJEOFOFDCO.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt;
							long exp = PJJEOFOFDCO.FMPLMFLMJNE_Last[0].NKMNFPMMJND_expired_at;
							long t = 0;
							if(exp != 0)
								t = Utility.RoundDownDayUnixTime(exp, 86399);
							long ct = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							if(GBCPDBJEDHL(true))
							{
								CMCKNKKCNDK_status = OAGBCBBHMPF.NALHDBIKFJO.FKKEAHEAOMM_1;
								KCKKCNPGMDC = CJDLIFEENBF.GGCDANOKPMB_2;
							}
							else if(t == 0)
							{
								KCKKCNPGMDC = CJDLIFEENBF.KPFIEBIKDFN_1;
							}
							else
							{
								KCKKCNPGMDC = CJDLIFEENBF.EANGJBHNNHF_3;
								CMCKNKKCNDK_status = OAGBCBBHMPF.NALHDBIKFJO.EANGJBHNNHF_2;
							}
							PJJEOFOFDCO.PMCKOEGANFB_Status = (int)CMCKNKKCNDK_status;
							PJJEOFOFDCO.KJBOIGIDKIF_Platform = 1;
							ILCCJNDFFOB.HHCJCDFCLOB.LPKDNOINDPE(CBJBEGPLJDO_StartedAt, LPHAOMAKKNF_ExpiredAt, FDAEDIPOONF_GoogleStartedAt, PCHNPJFFJJM_GoogleExpiredAt, CPFDDHIEODD_AppleStartedAt, LCNMPBBDGPJ_AppleExpiredAt,
								BMHKJPHNCIJ_BfStartedAt, KMJCPOGCJDG_BfExpiredAt, st, t, GAFIOALKHIM_BfStatus, CMCKNKKCNDK_status, EEMFGMEEBDC_BfPlatform, NJFKGJKINAG_AfPlatform, (int)(exp - EOLFJGMAJAB_CurrentTime), "");
							BHGMFDECGPG = false;
							AGHHAHBJGMH = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							if(str == KHACGAGBDHN)
							{
								HNNAJBJCNEJ = true;
								PJJEOFOFDCO.AFGLHGNKOFC();
							}
							_BHFHGFKBOHH_OnSuccess();
						}
						else
						{
							if(str == KHACGAGBDHN)
							{
								HNNAJBJCNEJ = true;
								PJJEOFOFDCO.AFGLHGNKOFC();
							}
							CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
							{
								//0x189D73C
								long st = PJJEOFOFDCO.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt;
								long exp = PJJEOFOFDCO.FMPLMFLMJNE_Last[0].NKMNFPMMJND_expired_at;
								long t = 0;
								if(exp != 0)
									t = Utility.RoundDownDayUnixTime(exp, 86399);
								long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
								if(GBCPDBJEDHL(true))
								{
									CMCKNKKCNDK_status = OAGBCBBHMPF.NALHDBIKFJO.FKKEAHEAOMM_1;
									KCKKCNPGMDC = CJDLIFEENBF.GGCDANOKPMB_2;
								}
								else if(t == 0)
								{
									KCKKCNPGMDC = CJDLIFEENBF.KPFIEBIKDFN_1;
								}
								else
								{
									CMCKNKKCNDK_status = OAGBCBBHMPF.NALHDBIKFJO.EANGJBHNNHF_2;
									KCKKCNPGMDC = CJDLIFEENBF.EANGJBHNNHF_3;
								}
								PJJEOFOFDCO.PMCKOEGANFB_Status = (int)CMCKNKKCNDK_status;
								PJJEOFOFDCO.KJBOIGIDKIF_Platform = 1;
								ILCCJNDFFOB.HHCJCDFCLOB.LPKDNOINDPE(CBJBEGPLJDO_StartedAt, LPHAOMAKKNF_ExpiredAt, FDAEDIPOONF_GoogleStartedAt, PCHNPJFFJJM_GoogleExpiredAt, CPFDDHIEODD_AppleStartedAt, LCNMPBBDGPJ_AppleExpiredAt,
									BMHKJPHNCIJ_BfStartedAt, KMJCPOGCJDG_BfExpiredAt, st, t, GAFIOALKHIM_BfStatus, CMCKNKKCNDK_status, EEMFGMEEBDC_BfPlatform, NJFKGJKINAG_AfPlatform, (int)(exp - EOLFJGMAJAB_CurrentTime), "");
								BHGMFDECGPG = false;
								AGHHAHBJGMH = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
								JNKDLNLLHCE_ClaimSubscriptionContinuationBonus KMKHDKECHLF = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JNKDLNLLHCE_ClaimSubscriptionContinuationBonus());
								KMKHDKECHLF.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KILNEADKPFI) =>
								{
									//0x189E088
									MHKCPJDNJKI_products.Clear();
									if(KMKHDKECHLF.NFEAMMJIMPG_Result.COGMPENEPBD_InventoryIds.Count < 1)
									{
										_BHFHGFKBOHH_OnSuccess();
										return;
									}
									else
									{
										GNDMFGGOPII_GetInventoryRecords PMFJEDMDFGD = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new GNDMFGGOPII_GetInventoryRecords());
										PMFJEDMDFGD.AMOMNBEAHBF_InventoryIds = KMKHDKECHLF.NFEAMMJIMPG_Result.COGMPENEPBD_InventoryIds;
										PMFJEDMDFGD.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request OCHKECIDBKA) =>
										{
											//0x189E444
											for(int i = 0; i < PMFJEDMDFGD.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories.Count; i++)
											{
												LKNKNKAALJO.Add(PMFJEDMDFGD.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i]);
											}
											_BHFHGFKBOHH_OnSuccess();
										};
										CACGCMBKHDI_Request.HDHIKGLMOGF GGPPHHEFHEJ = (CACGCMBKHDI_Request OCHKECIDBKA) =>
										{
											//0x189D1B4
											_AOCANKOMKFG_OnError();
										};
										PMFJEDMDFGD.MOBEEPPKFLG_OnFail = GGPPHHEFHEJ;
									}
								};
								CACGCMBKHDI_Request.HDHIKGLMOGF EEIFDMNADPA = (CACGCMBKHDI_Request KILNEADKPFI) =>
								{
									//0x189D1E0
									_AOCANKOMKFG_OnError();
								};
								KMKHDKECHLF.MOBEEPPKFLG_OnFail = EEIFDMNADPA;
							}, _AOCANKOMKFG_OnError, null);
						}
					};
					COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
					{
						//0x189D20C
						long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						string err = "";
						int errorId = 0;
						if(JIPCHHHLOMM.ANMFDAGDMDE_Error == null)
						{
							err = JIPCHHHLOMM.CJMFJOMECKI_ErrorId.ToString();
							errorId = (int)JIPCHHHLOMM.CJMFJOMECKI_ErrorId;
						}
						else
						{
							err = JIPCHHHLOMM.ANMFDAGDMDE_Error.ErrorCode;
						}
						JHGKHBGAJJJ = err;
						JKKDACNKPCP = err;
						KCKKCNPGMDC = CJDLIFEENBF.NGBOABGLAMM_5;
						if(JIPCHHHLOMM.CJMFJOMECKI_ErrorId == SakashoErrorId.STORE_SERVER_ERROR)
							KCKKCNPGMDC = CJDLIFEENBF.HHEAABDHNAE_4;
						CMCKNKKCNDK_status = OAGBCBBHMPF.NALHDBIKFJO.NGBOABGLAMM_4;
						if(JIPCHHHLOMM.CJMFJOMECKI_ErrorId == SakashoErrorId.STORE_SERVER_ERROR)
							CMCKNKKCNDK_status = OAGBCBBHMPF.NALHDBIKFJO.KEFKPCMGHIJ_3;
						PJJEOFOFDCO.PMCKOEGANFB_Status = (int)CMCKNKKCNDK_status;
						PJJEOFOFDCO.KJBOIGIDKIF_Platform = 1;
						ILCCJNDFFOB.HHCJCDFCLOB.LPKDNOINDPE(0, 0, 0, 0, 0, 0,
							BMHKJPHNCIJ_BfStartedAt, KMJCPOGCJDG_BfExpiredAt, 0, 0, GAFIOALKHIM_BfStatus, CMCKNKKCNDK_status, EEMFGMEEBDC_BfPlatform, NJFKGJKINAG_AfPlatform, (int)(time - EOLFJGMAJAB_CurrentTime), err);
						if(COJNCNGHIJC_Req.CJMFJOMECKI_ErrorId < SakashoErrorId.CURRENCY_ID_NOT_FOUND)
						{
							if(COJNCNGHIJC_Req.CJMFJOMECKI_ErrorId >= SakashoErrorId.STORE_SERVER_ERROR && COJNCNGHIJC_Req.CJMFJOMECKI_ErrorId < SakashoErrorId.CURRENCY_ID_NOT_FOUND)
							{
								//LAB_0189d620
								_BHFHGFKBOHH_OnSuccess();
								BHGMFDECGPG = false;
								AGHHAHBJGMH = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
								return;
							}
						}
						else if(COJNCNGHIJC_Req.CJMFJOMECKI_ErrorId == SakashoErrorId.BAD_REQUEST || COJNCNGHIJC_Req.CJMFJOMECKI_ErrorId == SakashoErrorId.IAB_APP_PUBLIC_KEY_NOT_FOUND)
						{
							//LAB_0189d620
							_BHFHGFKBOHH_OnSuccess();
							BHGMFDECGPG = false;
							AGHHAHBJGMH = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							return;
						}
						_AOCANKOMKFG_OnError();
					};
					return;
				}
			}
		}
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0x1898678 Offset: 0x1898678 VA: 0x1898678
	public bool GBCPDBJEDHL(bool JPIGJNMFDKK/* = false*/)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.AJHBAOCLNDF_MasterSw != 0 &&
			(!JPIGJNMFDKK || KCKKCNPGMDC > CJDLIFEENBF.HHEAABDHNAE_4/*4*/ || KCKKCNPGMDC == CJDLIFEENBF.GGCDANOKPMB_2/*2*/))
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
			{
				long t = FOHJOELPENH(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].NKMNFPMMJND_expired_at);
				long t2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt;
				return time >= t2 && t >= time;
			}
		}
		return false;
	}

	// // RVA: 0x18989E0 Offset: 0x18989E0 VA: 0x18989E0
	public static long FOHJOELPENH(long OKHMEPIOMBI)
	{ 
		return Utility.RoundDownDayUnixTime(OKHMEPIOMBI, 86399);
	}

	// // RVA: 0x1898A74 Offset: 0x1898A74 VA: 0x1898A74
	// public int JONBGADJPAF() { }

	// // RVA: 0x1898EF0 Offset: 0x1898EF0 VA: 0x1898EF0
	public int MENKMJPCELJ()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.AJHBAOCLNDF_MasterSw == 0)
			return -2;
		if(KCKKCNPGMDC == CJDLIFEENBF.HHEAABDHNAE_4/*4*/)
			return -3;
		if(!GBCPDBJEDHL(false))
			return NGHHJMJPEHN() ? 0 : -1;
		long t = Utility.RoundDownDayUnixTime(OLJANLKLOJH(), 86400);
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		int diff = (int)(t - time);
		if(diff != 0)
		{
			if((diff + 86399) < 86400)
				return 1;
			return (diff + 86399) % 86400;
		}
		return 1;
	}

	// // RVA: 0x1899158 Offset: 0x1899158 VA: 0x1899158
	public bool NGHHJMJPEHN()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.ABPFEOBAFCA_PurchaseSw == 0)
			return false;
		return MHKCPJDNJKI_products.Count > 0;
	}

	// // RVA: 0x1898C9C Offset: 0x1898C9C VA: 0x1898C9C
	public long OLJANLKLOJH()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		long t = FOHJOELPENH(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].NKMNFPMMJND_expired_at);
		if(t < time || time < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt)
			return 0;
		return t;
	}

	// // RVA: 0x1899284 Offset: 0x1899284 VA: 0x1899284
	// public long CGEEIPGEIDO() { }

	// // RVA: 0x18994E4 Offset: 0x18994E4 VA: 0x18994E4
	// private void MMGBNBPAJAL() { }

	// // RVA: 0x18994E8 Offset: 0x18994E8 VA: 0x18994E8
	public int BAFEDCMCONG_GetMonthlyPassRareGetCount()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.HKABHJKHFKL_RareGetCnt;
	}

	// // RVA: 0x18995C4 Offset: 0x18995C4 VA: 0x18995C4
	// public int KPEHCDMGHJC(NHPDPKHMFEP.GGNEBJEIFCP LDKJENNJPFL) { }

	// // RVA: 0x18998DC Offset: 0x18998DC VA: 0x18998DC
	public string MNAMCPDKFGI_GetPassPriceString(GGNEBJEIFCP LDKJENNJPFL)
	{
		FHPFLAGNCAF d = OHEIMMDOHOJ(MHKCPJDNJKI_products, LDKJENNJPFL);
		if (d != null)
			return d.NGIKLCDKAMB_FormatedPrice;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL_GetStringParam("pass_price", "\\1,200");
	}

	// // RVA: 0x18999F8 Offset: 0x18999F8 VA: 0x18999F8
	// public bool GJMGKBDGMOP(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError) { }

	// // RVA: 0x189A2FC Offset: 0x189A2FC VA: 0x189A2FC
	// public int HGEJHKCHBNB() { }

	// // RVA: 0x189A3D8 Offset: 0x189A3D8 VA: 0x189A3D8
	// public int DKJFDLJCHIM(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError) { }

	// // RVA: 0x189AC08 Offset: 0x189AC08 VA: 0x189AC08
	public bool KBJJGEJAMOK()
	{
		DMFNALAGLHH = 0;
		int stamp_hosei_ver = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetIntParam("stamp_hosei_ver", 1);
		if(stamp_hosei_ver != 0)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.MPLPHLAHJOC_StampHosei = stamp_hosei_ver;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.HMAHFMHPBBC())
			{
				for(int i = 0; i < 39; i++)
				{
					BEJHIEGCGNE.JCHLONCMPAJ();
					if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.BGANHMCJIIC() != null)
					{
						TodoLogger.LogError(TodoLogger.MonthlyPass, "KBJJGEJAMOK");
					}
					DMFNALAGLHH++;
					if (!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.HMAHFMHPBBC())
						break;
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x189B04C Offset: 0x189B04C VA: 0x189B04C
	// public void GBMFNHOFGOP(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError, NHPDPKHMFEP.GGNEBJEIFCP LDKJENNJPFL) { }

	// // RVA: 0x189B0C8 Offset: 0x189B0C8 VA: 0x189B0C8
	public int PIEFCAPBEAI()
	{
		if(GBCPDBJEDHL(false))
		{
			TodoLogger.LogError(TodoLogger.MonthlyPass, "PIEFCAPBEAI");
		}
		return 0;
	}

	// // RVA: 0x189B218 Offset: 0x189B218 VA: 0x189B218
	public int ALNBFHJBGIG()
	{
		if(GBCPDBJEDHL(false))
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(GBCPDBJEDHL(false) && HNNAJBJCNEJ)
				{
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetIntParam("diva_exp_bonus_sp_per", 50);
				}
				else
				{
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetIntParam("diva_exp_bonus_per", 20);
				}
			}
			return 20;
		}
		return 0;
	}

	// // RVA: 0x189B368 Offset: 0x189B368 VA: 0x189B368
	public bool CJMPCGHCGJB()
	{
		if(NILNABPCKGI())
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null;
		}
		return false;
	}

	// // RVA: 0x189B5A0 Offset: 0x189B5A0 VA: 0x189B5A0
	public int ELHKIEBJHLL()
	{
		if(NILNABPCKGI())
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OEJIPANCLOP.ALEDAGOCGGH;
			}
		}
		return 0;
	}

	// // RVA: 0x189B694 Offset: 0x189B694 VA: 0x189B694
	public int EOBEPKGEJFE()
	{
		if(NILNABPCKGI())
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OEJIPANCLOP.EIEOBPKBJDN;
			}
		}
		return 0;
	}

	// // RVA: 0x189B41C Offset: 0x189B41C VA: 0x189B41C
	public bool NILNABPCKGI()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			return time < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.BKONHFNBHKL_Aextm;
		}
		return false;
	}

	// // RVA: 0x189A23C Offset: 0x189A23C VA: 0x189A23C
	public bool ENAAHAPDMCO()
	{
		return GBCPDBJEDHL(false) && HNNAJBJCNEJ;
	}

	// // RVA: 0x189B788 Offset: 0x189B788 VA: 0x189B788
	public bool DCDDAAONHHC()
	{
		return MKBOKLLDCFI == JAILOEFCNJP.BEBLECKOAPK.GIDILNEPILF_1;
	}

	// // RVA: 0x189B798 Offset: 0x189B798 VA: 0x189B798
	// public void JDCDHJPBNIC() { }

	// // RVA: 0x189B8A0 Offset: 0x189B8A0 VA: 0x189B8A0
	public int OEFMFNICHHH()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.JOCGBFGPBCN_RateUpItemNum < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.HGEJHKCHBNB())
			return 0;
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HMMNDKHKEBC_MonthlyPass.HGEJHKCHBNB();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B69B8 Offset: 0x6B69B8 VA: 0x6B69B8
	// // RVA: 0x189A270 Offset: 0x189A270 VA: 0x189A270
	// private IEnumerator BMEPLLIPBBO(DJBHIFLHJLK _AOCANKOMKFG_OnError) { }

	// // RVA: 0x189BA58 Offset: 0x189BA58 VA: 0x189BA58
	public void FADCFLIHEPB_PreparePurchase(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, JFDNPFFOACP DLBACJNODGA, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(EJODPLCMDOH_Co_PreparePurchase(_BHFHGFKBOHH_OnSuccess, NIMPEHIECJH, DLBACJNODGA, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6A30 Offset: 0x6B6A30 VA: 0x6B6A30
	// // RVA: 0x189BAC8 Offset: 0x189BAC8 VA: 0x189BAC8
	private IEnumerator EJODPLCMDOH_Co_PreparePurchase(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, JFDNPFFOACP DLBACJNODGA, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0x189EB9C
		bool BEKAMBBOLBO_Done = false;
		bool NCFLGGPPNKN = false;
		bool CNAIDEAFAAM_Error = false;
		int PKJGLBGCBFE = MENKMJPCELJ();
		AMOCLPHDGBP data = new AMOCLPHDGBP();
		data.CLFGEAPFFMA = true;
		data.OLNDKPDNPCM_Auto_Recover(() =>
		{
			//0x189E6E4
			BEKAMBBOLBO_Done = true;
		}, () =>
		{
			//0x189E6F0
			BEKAMBBOLBO_Done = true;
			NCFLGGPPNKN = true;
		}, () =>
		{
			//0x189E6FC
			CNAIDEAFAAM_Error = true;
			BEKAMBBOLBO_Done = true;
		}, true, true);
		while (!BEKAMBBOLBO_Done)
			yield return null;
		if (!NCFLGGPPNKN)
		{
			if (!CNAIDEAFAAM_Error)
			{
				BHGMFDECGPG = true;
				NDAIOIOMPGG(() =>
				{
					//0x189E70C
					if(KCKKCNPGMDC == CJDLIFEENBF.HHEAABDHNAE_4)
					{
						JHHBAFKMBDL.HHCJCDFCLOB.EAGBOKEIAOC(NIMPEHIECJH);
					}
					else
					{
						int a = MENKMJPCELJ();
						if(a > 0 && PKJGLBGCBFE < 1)
						{
							JHHBAFKMBDL.HHCJCDFCLOB.PHAMJCBBBDB(DLBACJNODGA);
						}
						else
						{
							_BHFHGFKBOHH_OnSuccess();
						}
					}
				}, () =>
				{
					//0x189E8A0
					_AOCANKOMKFG_OnError();
				});
			}
			else
			{
				if (_AOCANKOMKFG_OnError != null)
					_AOCANKOMKFG_OnError();
			}
		}
		else if (NIMPEHIECJH != null)
			NIMPEHIECJH();
	}

	// // RVA: 0x18996D4 Offset: 0x18996D4 VA: 0x18996D4
	private FHPFLAGNCAF OHEIMMDOHOJ(List<FHPFLAGNCAF> _MHKCPJDNJKI_products, GGNEBJEIFCP LDKJENNJPFL)
	{
		string topplan_unique_key = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.EFEGBHACJAL_GetStringParam("topplan_unique_key", "");
		if(LDKJENNJPFL == GGNEBJEIFCP.AJAHGGBMOJE_1)
		{
			return _MHKCPJDNJKI_products.Find((FHPFLAGNCAF _GHPLINIACBB_x) =>
			{
				//0x189E900
				return _GHPLINIACBB_x.FJGCDPLCIAK_unique_key == topplan_unique_key;
			});
		}
		else if(LDKJENNJPFL == GGNEBJEIFCP.CCAPCGPIIPF_0)
		{
			return _MHKCPJDNJKI_products.Find((FHPFLAGNCAF _GHPLINIACBB_x) =>
			{
				//0x189E8CC
				return _GHPLINIACBB_x.FJGCDPLCIAK_unique_key != topplan_unique_key;
			});
		}
		return null;
	}

	// // RVA: 0x189BBE8 Offset: 0x189BBE8 VA: 0x189BBE8
	public string EAHHCPGNCMF(GGNEBJEIFCP LDKJENNJPFL)
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		string str = "";
		if (LDKJENNJPFL == GGNEBJEIFCP.AJAHGGBMOJE_1)
			str = "pop_pass_sp_text";
		if (LDKJENNJPFL == GGNEBJEIFCP.CCAPCGPIIPF_0)
			str = "pop_pass_text";
		return string.Format("{0}\n{1}\n{2}", bk.GetMessageByLabel(str + "01"), bk.GetMessageByLabel(str + "02"), bk.GetMessageByLabel(str + "_android"));
	}
}
