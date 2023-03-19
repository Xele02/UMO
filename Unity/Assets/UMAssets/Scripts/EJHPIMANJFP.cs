using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJHPIMANJFP
{
	private const int NKDJBEMDJHB = 259200;
	private bool OCNNKKPBDLL; // 0xC
	public long ECFNAOCFKKN_LastRequestProductTime; // 0x10

	public static EJHPIMANJFP HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public List<LGDNAJACFHI> MHKCPJDNJKI { get; private set; } // 0x8 CPMNDNELDME DFAHGPEFPOO IOMCCGAKKCP

	// // RVA: 0x12EFA68 Offset: 0x12EFA68 VA: 0x12EFA68
	public EJHPIMANJFP()
	{
		MHKCPJDNJKI = new List<LGDNAJACFHI>();
	}

	// // RVA: 0x12EFAF4 Offset: 0x12EFAF4 VA: 0x12EFAF4
	public void IJBGPAENLJA()
	{
		HHCJCDFCLOB = this;
	}

	// // RVA: 0x12EFB58 Offset: 0x12EFB58 VA: 0x12EFB58
	private bool AIJFDCIDDLO(SakashoErrorId PPFNGGCBJKC)
	{
		TodoLogger.Log(0, "EJHPIMANJFP.AIJFDCIDDLO");
		return false;
	}

	// // RVA: 0x12EFB84 Offset: 0x12EFB84 VA: 0x12EFB84
	public void LILDGEPCPPG_GetProductList(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP GBHILNDNNDF, DJBHIFLHJLK MOBEEPPKFLG, bool MBGCBCOPOLA, bool FBBNPFFEJBN_Force)
	{
		if(!FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if ((time - ECFNAOCFKKN_LastRequestProductTime) < 3600)
				BHFHGFKBOHH();
		}
		OCNNKKPBDLL = MBGCBCOPOLA;
		MHKCPJDNJKI.Clear();
		N.a.StartCoroutineWatched(AHGFMJOAEPM_Coroutine_GetProductList(BHFHGFKBOHH, GBHILNDNNDF, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9050 Offset: 0x6B9050 VA: 0x6B9050
	// // RVA: 0x12EFD3C Offset: 0x12EFD3C VA: 0x12EFD3C
	private IEnumerator AHGFMJOAEPM_Coroutine_GetProductList(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		long IBCGNDADAEE_Time; // 0x28
		List<DKJMDIFAKKD_VcItem.BCEMHEAKBCC> JFKGICMBEBO; // 0x30
		List<KBPDNHOKEKD_ProductId> NDHIMOJGAPH; // 0x34
		int INIJHKEKFJI_i; // 0x38
		NEAPMMJKOKA_GetProducts DCNALBIJJGP; // 0x3C

		//0x12F06CC
		IBCGNDADAEE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		Debug.Log("call NetGetProductsAction");
		JFKGICMBEBO = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.JOBKIDDLCPL;
		//NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester
		INIJHKEKFJI_i = 0;
		NDHIMOJGAPH = new List<KBPDNHOKEKD_ProductId>();
		for(; INIJHKEKFJI_i < JFKGICMBEBO.Count; INIJHKEKFJI_i++)
		{
			//L215
			if(JFKGICMBEBO[INIJHKEKFJI_i].PPEGAKEIEGM_Enabled == 2)
			{
				if(IBCGNDADAEE_Time < JFKGICMBEBO[INIJHKEKFJI_i].PDBPFJJCADD_OpenAt || 
					IBCGNDADAEE_Time > JFKGICMBEBO[INIJHKEKFJI_i].EGBOHDFBAPB_CloseAt)
				{
					//LAB_012f1090
					object[] obj = new object[8]
					{
						JpStringLiterals.StringLiteral_10065,
						JFKGICMBEBO[INIJHKEKFJI_i].PPFNGGCBJKC_Id,
						",label=",
						JFKGICMBEBO[INIJHKEKFJI_i].KAPMOPMDHJE_Label,
						",open_at=",
						JFKGICMBEBO[INIJHKEKFJI_i].PDBPFJJCADD_OpenAt,
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
						JFKGICMBEBO[INIJHKEKFJI_i].PPFNGGCBJKC_Id,
						",label=",
						JFKGICMBEBO[INIJHKEKFJI_i].KAPMOPMDHJE_Label,
						",open_at=",
						JFKGICMBEBO[INIJHKEKFJI_i].PDBPFJJCADD_OpenAt,
						",closed_at=",
						JFKGICMBEBO[INIJHKEKFJI_i].EGBOHDFBAPB_CloseAt
					};
					Debug.Log(string.Concat(obj));
					DCNALBIJJGP = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
					DCNALBIJJGP.NBFDEFGFLPJ = AIJFDCIDDLO;
					DCNALBIJJGP.IPKCADIAAPG_Criteria = LCKOLEDFDAL.CMNCOOIKDIH_GetCriteriaForLabel(JFKGICMBEBO[INIJHKEKFJI_i].KAPMOPMDHJE_Label);
					while (!DCNALBIJJGP.PLOOEECNHFB_IsDone)
						yield return null;
					if(DCNALBIJJGP.NPNNPNAIONN_IsError)
					{
						Debug.Log("NetGetProductsAction error");
						if((DCNALBIJJGP.CJMFJOMECKI_ErrorId >= SakashoErrorId.STORE_SERVER_ERROR && DCNALBIJJGP.CJMFJOMECKI_ErrorId < SakashoErrorId.PRODUCT_TRANSACTION_EXISTS) ||
							DCNALBIJJGP.CJMFJOMECKI_ErrorId == SakashoErrorId.UNSUPPORTED_API_CALLED)
						{
							ECFNAOCFKKN_LastRequestProductTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
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
								MOBEEPPKFLG();
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
					int cnt = DCNALBIJJGP.NFEAMMJIMPG.MHKCPJDNJKI_Products.Count;
					Debug.Log(JpStringLiterals.StringLiteral_10064 + cnt.ToString());
					List<KBPDNHOKEKD_ProductId> HKICMNAACDA = DCNALBIJJGP.NFEAMMJIMPG.MHKCPJDNJKI_Products;
					int HIEGIHHJNAL_i = 0;
					for(; HIEGIHHJNAL_i < HKICMNAACDA.Count; HIEGIHHJNAL_i++)
					{
						int idx = NDHIMOJGAPH.FindIndex((KBPDNHOKEKD_ProductId GHPLINIACBB) =>
						{
							//0x12F05F8
							return GHPLINIACBB.GLHKICCPGKJ_PlatformProductId == HKICMNAACDA[HIEGIHHJNAL_i].GLHKICCPGKJ_PlatformProductId;
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
					JFKGICMBEBO[INIJHKEKFJI_i].PPFNGGCBJKC_Id,
					",label=",
					JFKGICMBEBO[INIJHKEKFJI_i].KAPMOPMDHJE_Label,
					",open_at=",
					JFKGICMBEBO[INIJHKEKFJI_i].PDBPFJJCADD_OpenAt,
					",closed_at=",
					JFKGICMBEBO[INIJHKEKFJI_i].EGBOHDFBAPB_CloseAt
				};
				Debug.Log(string.Concat(obj));
			}
		}
		ALBOGEHBBAH(NDHIMOJGAPH);
		ECFNAOCFKKN_LastRequestProductTime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		if(MHKCPJDNJKI.Count != 0)
		{
			BHFHGFKBOHH();
		}
		else
		{
			NIMPEHIECJH();
		}
	}

	// // RVA: 0x12EFE30 Offset: 0x12EFE30 VA: 0x12EFE30
	private bool ALBOGEHBBAH(List<KBPDNHOKEKD_ProductId> BBKDLIPKADG)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		long staminaCheckTime = 0;
		if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			staminaCheckTime = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MNLAJEDKLCI_StamineLotTime;
		}
		long nextCheck = staminaCheckTime + 259200;
		for (int i = 0; i < BBKDLIPKADG.Count; i++)
		{
			DKJMDIFAKKD_VcItem.EBGPAPPHBAH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.ICGHMMOCJBA(BBKDLIPKADG[i].GLHKICCPGKJ_PlatformProductId, BBKDLIPKADG[i].OPFGFINHFCE_Name, time, BBKDLIPKADG[i].KAPMOPMDHJE_Label);
			if(item != null)
			{
				LGDNAJACFHI data = new LGDNAJACFHI();
				data.KHEKNNFCAOI_Init(BBKDLIPKADG[i]);
				if(staminaCheckTime != 0 && data.JLGHMCBLENL)
				{
					if (time < nextCheck)
						continue;
					if (nextCheck > data.EMEKFFHCHMH)
						data.EMEKFFHCHMH = nextCheck;
				}
				if(data.GCJMGMBNBCB < 1 || data.GCJMGMBNBCB != data.AJIFADGGAAJ)
				{
					MHKCPJDNJKI.Add(data);
				}
			}
		}
		MHKCPJDNJKI.Sort((LGDNAJACFHI HKICMNAACDA, LGDNAJACFHI BNKHBCBJBKI) =>
		{
			//0x12F04A8
			if(HKICMNAACDA.CHPMJNAFPMA != BNKHBCBJBKI.CHPMJNAFPMA)
			{
				int res = -1;
				if (!HKICMNAACDA.CHPMJNAFPMA)
					res = 1;
				if (HKICMNAACDA.CHPMJNAFPMA || BNKHBCBJBKI.CHPMJNAFPMA)
					return res;
			}
			if (HKICMNAACDA.JLGHMCBLENL != BNKHBCBJBKI.JLGHMCBLENL)
			{
				int res = -1;
				if (!HKICMNAACDA.JLGHMCBLENL)
					res = 1;
				if (HKICMNAACDA.JLGHMCBLENL || BNKHBCBJBKI.JLGHMCBLENL)
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
			if (BNKHBCBJBKI.EEFLOOBOAGF == HKICMNAACDA.EEFLOOBOAGF)
				return HKICMNAACDA.NPPGKNGIFGK.CompareTo(BNKHBCBJBKI.NPPGKNGIFGK);
			return HKICMNAACDA.EEFLOOBOAGF.CompareTo(BNKHBCBJBKI.EEFLOOBOAGF);
		});
		return true;
	}
}
