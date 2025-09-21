using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJHPIMANJFP
{
	private const int NKDJBEMDJHB = 259200;
	private bool OCNNKKPBDLL; // 0xC
	public long ECFNAOCFKKN_LastDate; // 0x10

	public static EJHPIMANJFP HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public List<LGDNAJACFHI> MHKCPJDNJKI_products { get; private set; } // 0x8 CPMNDNELDME DFAHGPEFPOO IOMCCGAKKCP

	// // RVA: 0x12EFA68 Offset: 0x12EFA68 VA: 0x12EFA68
	public EJHPIMANJFP()
	{
		MHKCPJDNJKI_products = new List<LGDNAJACFHI>();
	}

	// // RVA: 0x12EFAF4 Offset: 0x12EFAF4 VA: 0x12EFAF4
	public void IJBGPAENLJA()
	{
		HHCJCDFCLOB = this;
	}

	// // RVA: 0x12EFB58 Offset: 0x12EFB58 VA: 0x12EFB58
	private bool AIJFDCIDDLO(SakashoErrorId _PPFNGGCBJKC_id)
	{
		if((_PPFNGGCBJKC_id < SakashoErrorId.STORE_SERVER_ERROR || _PPFNGGCBJKC_id > SakashoErrorId.CANNOT_MAKE_PAYMENTS) && _PPFNGGCBJKC_id != SakashoErrorId.UNSUPPORTED_API_CALLED)
			return _PPFNGGCBJKC_id == SakashoErrorId.IAB_APP_PUBLIC_KEY_NOT_FOUND; 
		return true;
	}

	// // RVA: 0x12EFB84 Offset: 0x12EFB84 VA: 0x12EFB84
	public void LILDGEPCPPG_GetProductList(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP GBHILNDNNDF, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool MBGCBCOPOLA, bool _FBBNPFFEJBN_Force)
	{
		if(!_FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if ((time - ECFNAOCFKKN_LastDate) < 3600)
				_BHFHGFKBOHH_OnSuccess();
		}
		OCNNKKPBDLL = MBGCBCOPOLA;
		MHKCPJDNJKI_products.Clear();
		N.a.StartCoroutineWatched(AHGFMJOAEPM_Coroutine_GetProductList(_BHFHGFKBOHH_OnSuccess, GBHILNDNNDF, _MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9050 Offset: 0x6B9050 VA: 0x6B9050
	// // RVA: 0x12EFD3C Offset: 0x12EFD3C VA: 0x12EFD3C
	private IEnumerator AHGFMJOAEPM_Coroutine_GetProductList(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		long IBCGNDADAEE_Time; // 0x28
		List<DKJMDIFAKKD_VcItem.BCEMHEAKBCC> JFKGICMBEBO; // 0x30
		List<KBPDNHOKEKD_ProductId> NDHIMOJGAPH; // 0x34
		int INIJHKEKFJI_i; // 0x38
		NEAPMMJKOKA_GetProducts DCNALBIJJGP; // 0x3C

		//0x12F06CC
		IBCGNDADAEE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		Debug.Log("call NetGetProductsAction");
		JFKGICMBEBO = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.JOBKIDDLCPL_schedules;
		//NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester
		INIJHKEKFJI_i = 0;
		NDHIMOJGAPH = new List<KBPDNHOKEKD_ProductId>();
		for(; INIJHKEKFJI_i < JFKGICMBEBO.Count; INIJHKEKFJI_i++)
		{
			//L215
			if(JFKGICMBEBO[INIJHKEKFJI_i].PPEGAKEIEGM_Enabled == 2)
			{
				if(IBCGNDADAEE_Time < JFKGICMBEBO[INIJHKEKFJI_i].PDBPFJJCADD_open_at || 
					IBCGNDADAEE_Time > JFKGICMBEBO[INIJHKEKFJI_i].EGBOHDFBAPB_CloseAt)
				{
					//LAB_012f1090
					object[] obj = new object[8]
					{
						JpStringLiterals.StringLiteral_10065,
						JFKGICMBEBO[INIJHKEKFJI_i].PPFNGGCBJKC_id,
						",label=",
						JFKGICMBEBO[INIJHKEKFJI_i].KAPMOPMDHJE_label,
						",open_at=",
						JFKGICMBEBO[INIJHKEKFJI_i].PDBPFJJCADD_open_at,
						",closed_at=",
						JFKGICMBEBO[INIJHKEKFJI_i].EGBOHDFBAPB_CloseAt
					};
					Debug.Log(string.Concat(obj));
				}
				else
				{
					object[] obj = new object[8]
					{
						JpStringLiterals.StringLiteral_10065,
						JFKGICMBEBO[INIJHKEKFJI_i].PPFNGGCBJKC_id,
						",label=",
						JFKGICMBEBO[INIJHKEKFJI_i].KAPMOPMDHJE_label,
						",open_at=",
						JFKGICMBEBO[INIJHKEKFJI_i].PDBPFJJCADD_open_at,
						",closed_at=",
						JFKGICMBEBO[INIJHKEKFJI_i].EGBOHDFBAPB_CloseAt
					};
					Debug.Log(string.Concat(obj));
					DCNALBIJJGP = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
					DCNALBIJJGP.NBFDEFGFLPJ = AIJFDCIDDLO;
					DCNALBIJJGP.IPKCADIAAPG_Criteria = LCKOLEDFDAL.CMNCOOIKDIH_GetCriteriaForLabel(JFKGICMBEBO[INIJHKEKFJI_i].KAPMOPMDHJE_label);
					while (!DCNALBIJJGP.PLOOEECNHFB_IsDone)
						yield return null;
					if(DCNALBIJJGP.NPNNPNAIONN_IsError)
					{
						Debug.Log("NetGetProductsAction error");
						if((DCNALBIJJGP.CJMFJOMECKI_ErrorId >= SakashoErrorId.STORE_SERVER_ERROR && DCNALBIJJGP.CJMFJOMECKI_ErrorId < SakashoErrorId.PRODUCT_TRANSACTION_EXISTS) ||
							DCNALBIJJGP.CJMFJOMECKI_ErrorId == SakashoErrorId.UNSUPPORTED_API_CALLED)
						{
							ECFNAOCFKKN_LastDate = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							if(!OCNNKKPBDLL)
							{
								IMCBBOAFION KDFFGLHBDLO = () =>
								{
									//0x12F05BC
									NIMPEHIECJH();
								};
								JHHBAFKMBDL.HHCJCDFCLOB.AJIJCMKMAMA(DCNALBIJJGP.CJMFJOMECKI_ErrorId, DCNALBIJJGP, 0, KDFFGLHBDLO);
								// go LAB_012f1000
								DCNALBIJJGP = null;
								yield break;
							}
						}
						else
						{
							if(!AMOCLPHDGBP.ELDMAINJHJI(DCNALBIJJGP.CJMFJOMECKI_ErrorId))
							{
								_MOBEEPPKFLG_OnFail();
								// go LAB_012f1000
								DCNALBIJJGP = null;
								yield break;
							}
						}
						NIMPEHIECJH();
						//LAB_012f1000
						DCNALBIJJGP = null;
						yield break;
					}
					int cnt = DCNALBIJJGP.NFEAMMJIMPG_Result.MHKCPJDNJKI_products.Count;
					Debug.Log(JpStringLiterals.StringLiteral_10064 + cnt.ToString());
					List<KBPDNHOKEKD_ProductId> HKICMNAACDA = DCNALBIJJGP.NFEAMMJIMPG_Result.MHKCPJDNJKI_products;
					int HIEGIHHJNAL_i = 0;
					for(; HIEGIHHJNAL_i < HKICMNAACDA.Count; HIEGIHHJNAL_i++)
					{
						int idx = NDHIMOJGAPH.FindIndex((KBPDNHOKEKD_ProductId _GHPLINIACBB_x) =>
						{
							//0x12F05F8
							return _GHPLINIACBB_x.GLHKICCPGKJ_PlatformProductId == HKICMNAACDA[HIEGIHHJNAL_i].GLHKICCPGKJ_PlatformProductId;
						});
						if(idx < 0)
						{
							NDHIMOJGAPH.Add(HKICMNAACDA[HIEGIHHJNAL_i]);
						}
						else
						{
							NDHIMOJGAPH[idx] = HKICMNAACDA[HIEGIHHJNAL_i];
						}
					}
					DCNALBIJJGP = null;
				}
			}
			else
			{
				object[] obj = new object[8]
				{
					JpStringLiterals.StringLiteral_10058,
					JFKGICMBEBO[INIJHKEKFJI_i].PPFNGGCBJKC_id,
					",label=",
					JFKGICMBEBO[INIJHKEKFJI_i].KAPMOPMDHJE_label,
					",open_at=",
					JFKGICMBEBO[INIJHKEKFJI_i].PDBPFJJCADD_open_at,
					",closed_at=",
					JFKGICMBEBO[INIJHKEKFJI_i].EGBOHDFBAPB_CloseAt
				};
				Debug.Log(string.Concat(obj));
			}
		}
		ALBOGEHBBAH(NDHIMOJGAPH);
		ECFNAOCFKKN_LastDate = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		if(MHKCPJDNJKI_products.Count != 0)
		{
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			NIMPEHIECJH();
		}
	}

	// // RVA: 0x12EFE30 Offset: 0x12EFE30 VA: 0x12EFE30
	private bool ALBOGEHBBAH(List<KBPDNHOKEKD_ProductId> BBKDLIPKADG)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		long staminaCheckTime = 0;
		if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			staminaCheckTime = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MNLAJEDKLCI_sta_lot_time;
		}
		long nextCheck = staminaCheckTime + 259200;
		for (int i = 0; i < BBKDLIPKADG.Count; i++)
		{
			DKJMDIFAKKD_VcItem.EBGPAPPHBAH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.ICGHMMOCJBA(BBKDLIPKADG[i].GLHKICCPGKJ_PlatformProductId, BBKDLIPKADG[i].OPFGFINHFCE_name, time, BBKDLIPKADG[i].KAPMOPMDHJE_label);
			if(item != null)
			{
				LGDNAJACFHI data = new LGDNAJACFHI();
				data.KHEKNNFCAOI_Init(BBKDLIPKADG[i]);
				if(staminaCheckTime != 0 && data.JLGHMCBLENL_IsBeginner)
				{
					if (time >= nextCheck)
						continue;
					if (nextCheck < data.EMEKFFHCHMH_RewardEnd2)
						data.EMEKFFHCHMH_RewardEnd2 = nextCheck;
				}
				if(data.GCJMGMBNBCB_BuyLimit < 1 || data.GCJMGMBNBCB_BuyLimit != data.AJIFADGGAAJ_BoughtQuantity)
				{
					MHKCPJDNJKI_products.Add(data);
				}
			}
		}
		MHKCPJDNJKI_products.Sort((LGDNAJACFHI HKICMNAACDA, LGDNAJACFHI BNKHBCBJBKI) =>
		{
			//0x12F04A8
			if(HKICMNAACDA.CHPMJNAFPMA_HasMonthlyPassBonus != BNKHBCBJBKI.CHPMJNAFPMA_HasMonthlyPassBonus)
			{
				int res = -1;
				if (!HKICMNAACDA.CHPMJNAFPMA_HasMonthlyPassBonus)
					res = 1;
				if (HKICMNAACDA.CHPMJNAFPMA_HasMonthlyPassBonus || BNKHBCBJBKI.CHPMJNAFPMA_HasMonthlyPassBonus)
					return res;
			}
			if (HKICMNAACDA.JLGHMCBLENL_IsBeginner != BNKHBCBJBKI.JLGHMCBLENL_IsBeginner)
			{
				int res = -1;
				if (!HKICMNAACDA.JLGHMCBLENL_IsBeginner)
					res = 1;
				if (HKICMNAACDA.JLGHMCBLENL_IsBeginner || BNKHBCBJBKI.JLGHMCBLENL_IsBeginner)
					return res;
			}
			if (HKICMNAACDA.NIIIKPNBLNP != BNKHBCBJBKI.NIIIKPNBLNP)
			{
				int res = -1;
				if (!HKICMNAACDA.NIIIKPNBLNP)
					res = 1;
				if (HKICMNAACDA.NIIIKPNBLNP || BNKHBCBJBKI.NIIIKPNBLNP)
					return res;
			}
			if (BNKHBCBJBKI.EEFLOOBOAGF_ViewOrder == HKICMNAACDA.EEFLOOBOAGF_ViewOrder)
				return HKICMNAACDA.NPPGKNGIFGK_price.CompareTo(BNKHBCBJBKI.NPPGKNGIFGK_price);
			return HKICMNAACDA.EEFLOOBOAGF_ViewOrder.CompareTo(BNKHBCBJBKI.EEFLOOBOAGF_ViewOrder);
		});
		return true;
	}
}
