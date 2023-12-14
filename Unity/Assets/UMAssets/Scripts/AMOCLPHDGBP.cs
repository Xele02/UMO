using System;
using System.Collections;
using System.Collections.Generic;
using XeApp;
using XeApp.Game.Common;
using XeSys;

public delegate void JFDNPFFOACP();
public delegate void ELBOJBBIBFM(LGDNAJACFHI PPFNGGCBJKC_Id);
public delegate void BKEHAMOGHCL(AMOCLPHDGBP PKLPKMLGFGK, ELBOJBBIBFM EDMKFIJKJLB, JFDNPFFOACP NIMPEHIECJH);
public delegate void JCKIFJADNEF(PJHHCHAKGKI KFFBDNMNBMM, JFDNPFFOACP NIMPEHIECJH);
public delegate void PJHHCHAKGKI(int LBEBFEIHPOO, int IBAKPKKEDJM);
public delegate void KMIEKGLLDCI(int LBEBFEIHPOO, int KLCMKLPIDDJ, IMCBBOAFION BHEOPIPFEFJ, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK MOBEEPPKFLG);

public class AMOCLPHDGBP
{
    private enum EMAGIFONJLD
    {
        LCNHAHPGDEA = 0,
        PLBEBIPLODF = 1,
        HLEGCGNPMAB = 0,
    }

    private enum FINNDKJENCG
    {
        FKPEAGGKNLC = 0,
        EBABINMPENN = 1,
        NALKNDBAEHD = 2,
        CPJMCILHPKO = 3,
        ACJKDEHJGFI = 4,
        GCBEOFGKJPF = 5,
        NGFFHEHOKJB = 6,
        FJNADADCBGJ = 7,
        AAHHJDACPCN = 8,
        FMPPMBNDJJF = 9,
        EEEAMFOKGFK = 10,
    }

	public BKEHAMOGHCL MKDKKDNBEEK; // 0x8
	public JCKIFJADNEF AJGKLIIDKHA; // 0xC
	public KMIEKGLLDCI FIJMBKFJJIJ; // 0x10
	private IMCBBOAFION BHFHGFKBOHH; // 0x14
	private JFDNPFFOACP NIMPEHIECJH; // 0x18
	private DJBHIFLHJLK MOBEEPPKFLG; // 0x1C
	public Action PBJINBCLFBB; // 0x20
	private bool ENDJKKHKMNP; // 0x24
	private bool PPKOLFEBLCF = true; // 0x25
	private SakashoErrorId OHBJPKPCIEB = SakashoErrorId.PRODUCT_TRANSACTION_EXISTS; // 0x28
	private bool LNHFLJBGGJB; // 0x2C
	private bool OCNNKKPBDLL; // 0x2D
	private bool PBCJCAOLLKI; // 0x2E
	private bool NHOAJCLAEJD; // 0x2F
	public bool CLFGEAPFFMA; // 0x30
	private EMAGIFONJLD GDGBDFEGLKK; // 0x34
	private static string[] CMPEKADFEEO = new string[11] {"paidvc start ", "get_products_success ", "purchase_start ", "purchase_action ", "error_emultaion ", "purchase_success ",
															"purchase_cancel ", "purchase_error_special ", "purchase_error_permanent ", "purchase_error_purchase ", "processing now "}; // 0x0
	private int LBEBFEIHPOO; // 0x38
	private int KLCMKLPIDDJ; // 0x3C
	private bool LPEJBOIONDP; // 0x40
	private bool KIECCJLPNMN; // 0x41
	private bool ALNCNJMEFHM; // 0x42
	private bool KCEDKOHKHGL; // 0x43
	private bool KMABBBKJFCB; // 0x44
	private int FJIKAAOMOKE; // 0x48

	public EJHPIMANJFP HFCNOINEPLB { get { return EJHPIMANJFP.HHCJCDFCLOB; } } // IHHPFGILBNE 0xCE9480

	// // RVA: 0xCE9488 Offset: 0xCE9488 VA: 0xCE9488
	private void FCPBCDOKOPD(FINNDKJENCG PPFNGGCBJKC_Id, string IBDJFHFIIHN = "")
	{
		return;
	}

	// // RVA: 0xCE948C Offset: 0xCE948C VA: 0xCE948C
	private void JEEPGGGAKMI_ClearCallbacks()
	{
		BHFHGFKBOHH = null;
		NIMPEHIECJH = null;
		MOBEEPPKFLG = null;
		PBJINBCLFBB = null;
	}

	// // RVA: 0xCE949C Offset: 0xCE949C VA: 0xCE949C
	public void DCDPMEPNKND(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK MOBEEPPKFLG, Action PBJINBCLFBB, bool MBGCBCOPOLA = false, bool AJAPLLGJKJB = false)
	{
		if(AppEnv.IsCBT())
		{
			FAHKEEFPAFH(NIMPEHIECJH);
		}
		else
		{
			LPEJBOIONDP = false;
			CLFGEAPFFMA = AJAPLLGJKJB;
			LNHFLJBGGJB = false;
			OCNNKKPBDLL = true;
			N.a.StartCoroutineWatched(JGKMFHLKEJP_Coroutine_PreGetProductList(BHFHGFKBOHH, NIMPEHIECJH, MOBEEPPKFLG, PBJINBCLFBB));
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9118 Offset: 0x6B9118 VA: 0x6B9118
	// // RVA: 0xCE9838 Offset: 0xCE9838 VA: 0xCE9838
	private IEnumerator JGKMFHLKEJP_Coroutine_PreGetProductList(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK MOBEEPPKFLG, Action PBJINBCLFBB)
	{
		//0xD4A80C
		bool BEKAMBBOLBO = false;
		bool NCFLGGPPNKN = false;
		bool CNAIDEAFAAM = false;
		OLNDKPDNPCM_Auto_Recover(() =>
		{
			//0xD458C0
			BEKAMBBOLBO = true;
		}, () =>
		{
			//0xD458CC
			BEKAMBBOLBO = true;
			NCFLGGPPNKN = true;
		}, () =>
		{
			//0xD458D8
			BEKAMBBOLBO = true;
			CNAIDEAFAAM = true;
		}, true, false);
		while (!BEKAMBBOLBO)
			yield return null;
		if(!NCFLGGPPNKN)
		{
			if(!CNAIDEAFAAM)
			{
				this.BHFHGFKBOHH = BHFHGFKBOHH;
				this.NIMPEHIECJH = NIMPEHIECJH;
				this.MOBEEPPKFLG = MOBEEPPKFLG;
				this.PBJINBCLFBB = PBJINBCLFBB;
				HFCNOINEPLB.LILDGEPCPPG_GetProductList(() =>
				{
					//0xD458E8
					FCPBCDOKOPD(FINNDKJENCG.EBABINMPENN/*1*/, "");
					LHFOAFAOPLC.JIABJFIJACN();
					MKDKKDNBEEK(this, JLNBMEMFGPH, () =>
					{
						//0xD45A70
						if (NIMPEHIECJH != null)
							NIMPEHIECJH();
						JEEPGGGAKMI_ClearCallbacks();
					});
				}, () =>
				{
					//0xD45AF4
					HENOMNBDBMA(() =>
					{
						//0xD45BAC
						if (NIMPEHIECJH != null)
							NIMPEHIECJH();
						JEEPGGGAKMI_ClearCallbacks();
					});
				}, () =>
				{
					//0xD45C30
					if (MOBEEPPKFLG != null)
						MOBEEPPKFLG();
					JEEPGGGAKMI_ClearCallbacks();
				}, false, true);
			}
			else
			{
				if (MOBEEPPKFLG != null)
					MOBEEPPKFLG();
			}
		}
		else
		{
			if (NIMPEHIECJH != null)
				NIMPEHIECJH();
		}
	}

	// // RVA: 0xCE9924 Offset: 0xCE9924 VA: 0xCE9924
	private void JLNBMEMFGPH(LGDNAJACFHI MEANCEOIMGE)
	{
		if (LNHFLJBGGJB)
			return;
		LNHFLJBGGJB = true;
		N.a.StartCoroutineWatched(IGFMPECJFJA_Coroutine_Purchase(MEANCEOIMGE));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9190 Offset: 0x6B9190 VA: 0x6B9190
	// // RVA: 0xCE99D4 Offset: 0xCE99D4 VA: 0xCE99D4
	private IEnumerator IGFMPECJFJA_Coroutine_Purchase(LGDNAJACFHI MEANCEOIMGE)
	{
		TodoLogger.LogError(0, "IGFMPECJFJA_Coroutine_Purchase");
		yield return null;
	}

	// // RVA: 0xCE9A78 Offset: 0xCE9A78 VA: 0xCE9A78
	private void HENOMNBDBMA(JFDNPFFOACP GIGHIFOIMNA)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage("common", "popup_purchase_expire_title");
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("common", "popup_purchase_expire_01");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0xD45E64
			if (GIGHIFOIMNA != null)
				GIGHIFOIMNA();
		}, null, null, null);
	}

	// // RVA: 0xCE9D78 Offset: 0xCE9D78 VA: 0xCE9D78
	// private void AJHEHLHNMMF(int PMBEODGMMBB, int MABBBOEAPAA) { }

	// // RVA: 0xCE9D8C Offset: 0xCE9D8C VA: 0xCE9D8C
	// private void DCGBPKBCGIO() { }

	// // RVA: 0xCE9DA0 Offset: 0xCE9DA0 VA: 0xCE9DA0
	// private void GFKFKJAPPLA() { }

	// // RVA: 0xCE9DB4 Offset: 0xCE9DB4 VA: 0xCE9DB4
	// private void FDMEGIGOIPD() { }

	// // RVA: 0xCE9DC0 Offset: 0xCE9DC0 VA: 0xCE9DC0
	// private void KJMDILMLFBG() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9208 Offset: 0x6B9208 VA: 0x6B9208
	// // RVA: 0xCE9DCC Offset: 0xCE9DCC VA: 0xCE9DCC
	// private IEnumerator NLMLHDONBJC_BirthdayRegistration(IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP, JFDNPFFOACP JGKOLBLPMPG) { }

	// // RVA: 0xCE9EA0 Offset: 0xCE9EA0 VA: 0xCE9EA0
	private bool MJOKGGCMOMD_IsStoreServerError(SakashoErrorId GGBJNJJHLHJ)
	{
		return GGBJNJJHLHJ == SakashoErrorId.STORE_SERVER_ERROR;
	}

	// // RVA: 0xCE9EB0 Offset: 0xCE9EB0 VA: 0xCE9EB0
	public void OLNDKPDNPCM_Auto_Recover(IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP, DJBHIFLHJLK BFKEGJMPELF, bool EBKGBLFCENA = false, bool BOGDHEBBHFA = false)
	{
		N.a.StartCoroutineWatched(GEMPIKIBEKJ_Coroutine_AutoRecover(KLMFJJCNBIP,NEFKBBNKNPP,BFKEGJMPELF,EBKGBLFCENA,BOGDHEBBHFA));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9280 Offset: 0x6B9280 VA: 0x6B9280
	// // RVA: 0xCE9F24 Offset: 0xCE9F24 VA: 0xCE9F24
	private IEnumerator GEMPIKIBEKJ_Coroutine_AutoRecover(IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP, DJBHIFLHJLK BFKEGJMPELF, bool EBKGBLFCENA, bool BOGDHEBBHFA)
	{
		PJKLMCGEJMK OKDOIAEGADK_Server; // 0x2C
		long DPHPGLNFDLH_Time; // 0x30
		PMDCIJMMNGK_GachaTicket FIPNIIFHOBE_dbGacha; // 0x38
		IBBMABBJFOA_PaymentRecover JNBNLCNBILD_PaymentRecover; // 0x3C
		DOLDMCAMEOD_RequestRemainingForCurrencyIds BKICHGFLJPF_RequestRemainingForCurrency; // 0x40
		PPJGPCKAMDC_PlatformPaymentRecover BMLCHDIEAAO_PlatformPaymentRecover; // 0x44
		LAPFLEEAACL[] PPOJLIPFMMP; // 0x48
		int GBIEKJGODJD_i; // 0x4C
		HDPDEAJGJEO_PaymentGetPurchasingStatus CDDGCHNKLGJ_GetPurchasingStatus; // 0x50
		HDPDEAJGJEO_PaymentGetPurchasingStatus NFJGANOGEFP_GetPurchasingStatus; // 0x54
		HDPDEAJGJEO_PaymentGetPurchasingStatus DNHGKGHCJOE_GetPurchasingStatus; // 0x58
		bool JMKKFJOMNEE; // 0x5C

		//0xD46B3C
		OKDOIAEGADK_Server = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		DPHPGLNFDLH_Time = OKDOIAEGADK_Server.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		FIPNIIFHOBE_dbGacha = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket;
		bool BEKAMBBOLBO_Done = false;
		PBCJCAOLLKI = false;
		NHOAJCLAEJD = false;
		if(GDGBDFEGLKK == EMAGIFONJLD.HLEGCGNPMAB/*0*/)
		{
			JNBNLCNBILD_PaymentRecover = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new IBBMABBJFOA_PaymentRecover());
			JNBNLCNBILD_PaymentRecover.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
			yield return JNBNLCNBILD_PaymentRecover.GDPDELLNOBO_WaitDone(N.a);
			// 1
			if(JNBNLCNBILD_PaymentRecover.NPNNPNAIONN_IsError)
			{
				if (!DDGIEBFGGDF_CheckIsError(JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId))
				{
					//LAB_00d4846c
					if(!ELDMAINJHJI(JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId))
					{
						//LAB_00d48a98
						BFKEGJMPELF();
						yield break;
					}
					// go LAB_00d4847c
					NEFKBBNKNPP();
					yield break;
				}
				if(JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.STORE_SERVER_ERROR)
				{
					if(BOGDHEBBHFA)
					{
						BEKAMBBOLBO_Done = false;
						JHHBAFKMBDL.HHCJCDFCLOB.EAGBOKEIAOC(() =>
						{
							//0xD45E80
							BEKAMBBOLBO_Done = true;
						});
						// go LAB_00d46edc
						//LAB_00d46edc
						//2
						while (!BEKAMBBOLBO_Done)
							yield return null;
						// go LAB_00d4847c
						NEFKBBNKNPP();
						yield break;
					}
					if (EBKGBLFCENA)
					{
						BEKAMBBOLBO_Done = false;
						JHHBAFKMBDL.HHCJCDFCLOB.HEMIGMPCFFM(() =>
						{
							//0xD45E8C
							BEKAMBBOLBO_Done = true;
						});
						//LAB_00d46f10
						//3
						while (!BEKAMBBOLBO_Done)
							yield return null;
						// go LAB_00d4847c
						NEFKBBNKNPP();
						yield break;
					}
				}
			}
			BKICHGFLJPF_RequestRemainingForCurrency = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
			BKICHGFLJPF_RequestRemainingForCurrency.CGCFENMHJIM_Ids = new List<int>() { 1001, 3001, 3002, 3003, 3004, 4001 };
			BKICHGFLJPF_RequestRemainingForCurrency.CGCFENMHJIM_Ids.AddRange(FIPNIIFHOBE_dbGacha.DHIACJMOEBH);
			PCLDNINHHBE(BKICHGFLJPF_RequestRemainingForCurrency.CGCFENMHJIM_Ids, DPHPGLNFDLH_Time);
			yield return BKICHGFLJPF_RequestRemainingForCurrency.GDPDELLNOBO_WaitDone(N.a);
			//4
			if(BKICHGFLJPF_RequestRemainingForCurrency.NPNNPNAIONN_IsError)
			{
				// go LAB_00d48a98
				BFKEGJMPELF();
				yield break;
			}
			CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(BKICHGFLJPF_RequestRemainingForCurrency.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
			if(CLFGEAPFFMA)
			{
				PPOJLIPFMMP = NKGJPJPHLIF.HHCJCDFCLOB.HECNGABHNDJ;
				for(GBIEKJGODJD_i = 0; GBIEKJGODJD_i < PPOJLIPFMMP.Length; GBIEKJGODJD_i++)
				{
					PPOJLIPFMMP[GBIEKJGODJD_i].LAOEGNLOJHC_Convert();
					//LAB_00d48b44
					while(!PPOJLIPFMMP[GBIEKJGODJD_i].PLOOEECNHFB_IsDone)
					{
						// 5
						yield return null;
					}
					if(PPOJLIPFMMP[GBIEKJGODJD_i].NPNNPNAIONN_IsError)
					{
						//go LAB_00d48a98
						BFKEGJMPELF();
						yield break;
					}
				}
			}
			BMLCHDIEAAO_PlatformPaymentRecover = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new PPJGPCKAMDC_PlatformPaymentRecover());
			BMLCHDIEAAO_PlatformPaymentRecover.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
			yield return BMLCHDIEAAO_PlatformPaymentRecover.GDPDELLNOBO_WaitDone(N.a);
			// 6
			if(!BMLCHDIEAAO_PlatformPaymentRecover.NPNNPNAIONN_IsError)
			{
				//LAB_00d48a60
				KLMFJJCNBIP();
				yield break;
			}
			if(!DDGIEBFGGDF_CheckIsError(BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId))
			{
				// go LAB_00d4846c
				if (!ELDMAINJHJI(JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId))
				{
					//LAB_00d48a98
					BFKEGJMPELF();
					yield break;
				}
				// go LAB_00d4847c
				NEFKBBNKNPP();
				yield break;
			}
			if(BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId != SakashoErrorId.STORE_SERVER_ERROR)
			{
				// go LAB_00d48a60
				KLMFJJCNBIP();
				yield break;
			}
			if (BOGDHEBBHFA)
			{
				BEKAMBBOLBO_Done = false;
				JHHBAFKMBDL.HHCJCDFCLOB.EAGBOKEIAOC(() =>
				{
					//0xD45E98
					BEKAMBBOLBO_Done = true;
				});
				//LAB_00d471fc
				//7
				while (!BEKAMBBOLBO_Done)
					yield return null;
				// go LAB_00d4847c
			}
			else
			{
				if (!EBKGBLFCENA)
				{
					// go LAB_00d48a60
					KLMFJJCNBIP();
					yield break;
				}
				BEKAMBBOLBO_Done = false;
				JHHBAFKMBDL.HHCJCDFCLOB.HEMIGMPCFFM(() =>
				{
					//0xD45EA4
					BEKAMBBOLBO_Done = true;
				});
				//LAB_00d47230
				//8
				while (!BEKAMBBOLBO_Done)
					yield return null;
			}
			//LAB_00d4847c
			NEFKBBNKNPP();
			yield break;
		}
		CDDGCHNKLGJ_GetPurchasingStatus = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new HDPDEAJGJEO_PaymentGetPurchasingStatus());
		CDDGCHNKLGJ_GetPurchasingStatus.NBFDEFGFLPJ = MJOKGGCMOMD_IsStoreServerError;
		yield return CDDGCHNKLGJ_GetPurchasingStatus.GDPDELLNOBO_WaitDone(N.a);
		//9
		if(!CDDGCHNKLGJ_GetPurchasingStatus.NPNNPNAIONN_IsError)
		{
			if(!CDDGCHNKLGJ_GetPurchasingStatus.NFEAMMJIMPG.OIJLNFJALJP_aborted_transaction_exists)
			{
				// go LAB_00d48a60
				KLMFJJCNBIP();
				yield break;
			}
			BEKAMBBOLBO_Done = false;
			{ 
				TextPopupSetting setting = new TextPopupSetting();
				setting.TitleText = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_title");
				setting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				setting.Text = MessageManager.Instance.GetMessage("common", "popup_purchase_recover");
				PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
				{
					//0xD45EBC
					BEKAMBBOLBO_Done = true;
				}, null, null, null);
			}
			//LAB_00d47d74
			//11
			while (!BEKAMBBOLBO_Done)
				yield return null;
			BMLCHDIEAAO_PlatformPaymentRecover = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new PPJGPCKAMDC_PlatformPaymentRecover());
			BMLCHDIEAAO_PlatformPaymentRecover.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
			yield return BMLCHDIEAAO_PlatformPaymentRecover.GDPDELLNOBO_WaitDone(N.a);
			//12
			if(BMLCHDIEAAO_PlatformPaymentRecover.NPNNPNAIONN_IsError)
			{
				if(BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.NETWORK_ERROR)
				{
					// go LAB_00d48a98
					BFKEGJMPELF();
					yield break;
				}
				if (BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.INTERNAL_CLIENT_ERROR)
				{
					// go LAB_00d48a98
					BFKEGJMPELF();
					yield break;
				}
				if (BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.APPLICATION_UNDER_MAINTENANCE)
				{
					// go LAB_00d48a98
					BFKEGJMPELF();
					yield break;
				}
				if (BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.OLDER_REQUIREMENT_CLIENT_VERSION)
				{
					// go LAB_00d48a98
					BFKEGJMPELF();
					yield break;
				}
				if(BMLCHDIEAAO_PlatformPaymentRecover.PDAPLCPOCMA)
				{
					// go LAB_00d48a98
					BFKEGJMPELF();
					yield break;
				}
				if(!DDGIEBFGGDF_CheckIsError(BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId))
				{
					// go LAB_00d48a98
					BFKEGJMPELF();
					yield break;
				}
			}
			NFJGANOGEFP_GetPurchasingStatus = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new HDPDEAJGJEO_PaymentGetPurchasingStatus());
			NFJGANOGEFP_GetPurchasingStatus.NBFDEFGFLPJ = MJOKGGCMOMD_IsStoreServerError;
			yield return NFJGANOGEFP_GetPurchasingStatus.GDPDELLNOBO_WaitDone(N.a);
			// 13
			if(NFJGANOGEFP_GetPurchasingStatus.NPNNPNAIONN_IsError)
			{
				if(NFJGANOGEFP_GetPurchasingStatus.CJMFJOMECKI_ErrorId != SakashoErrorId.STORE_SERVER_ERROR)
				{
					// go LAB_00d48a98
					BFKEGJMPELF();
					yield break;
				}
				if(!BOGDHEBBHFA)
				{
					// go LAB_00d48a60
					KLMFJJCNBIP();
					yield break;
				}
				BEKAMBBOLBO_Done = false;
				JHHBAFKMBDL.HHCJCDFCLOB.EAGBOKEIAOC(() =>
				{
					//0xD45EC8
					BEKAMBBOLBO_Done = true;
				});
				//LAB_00d476f4
				// 14
				while (!BEKAMBBOLBO_Done)
					yield return null;
				// go LAB_00d4847c
				NEFKBBNKNPP();
				yield break;
			}
			PBCJCAOLLKI = !NFJGANOGEFP_GetPurchasingStatus.NFEAMMJIMPG.OIJLNFJALJP_aborted_transaction_exists;
			if(!PBCJCAOLLKI)
			{
				JNBNLCNBILD_PaymentRecover = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new IBBMABBJFOA_PaymentRecover());
				JNBNLCNBILD_PaymentRecover.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
				yield return JNBNLCNBILD_PaymentRecover.GDPDELLNOBO_WaitDone(N.a);
				//15
				if(!JNBNLCNBILD_PaymentRecover.NPNNPNAIONN_IsError)
				{
					if(JNBNLCNBILD_PaymentRecover.NFEAMMJIMPG != null)
					{
						if(JNBNLCNBILD_PaymentRecover.NFEAMMJIMPG.FHANAFNKIFC_Success != null)
						{
							//JNBNLCNBILD.LFOJDJCNOHB.FHANAFNKIFC.Count
						}
					}
				}
				else
				{
					if(JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.NETWORK_ERROR)
					{
						// go LAB_00d48a98
						BFKEGJMPELF();
						yield break;
					}
					if (JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.INTERNAL_CLIENT_ERROR)
					{
						// go LAB_00d48a98
						BFKEGJMPELF();
						yield break;
					}
					if (JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.APPLICATION_UNDER_MAINTENANCE)
					{
						// go LAB_00d48a98
						BFKEGJMPELF();
						yield break;
					}
					if (JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.OLDER_REQUIREMENT_CLIENT_VERSION)
					{
						// go LAB_00d48a98
						BFKEGJMPELF();
						yield break;
					}
					if(JNBNLCNBILD_PaymentRecover.PDAPLCPOCMA)
					{
						// go LAB_00d48a98
						BFKEGJMPELF();
						yield break;
					}
				}
				JNBNLCNBILD_PaymentRecover = null;
				//LAB_00d4802c
			}
			//LAB_00d4802c
			DNHGKGHCJOE_GetPurchasingStatus = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new HDPDEAJGJEO_PaymentGetPurchasingStatus());
			DNHGKGHCJOE_GetPurchasingStatus.NBFDEFGFLPJ = MJOKGGCMOMD_IsStoreServerError;
			yield return DNHGKGHCJOE_GetPurchasingStatus.GDPDELLNOBO_WaitDone(N.a);
			//16
			if(!DNHGKGHCJOE_GetPurchasingStatus.NPNNPNAIONN_IsError)
			{
				JMKKFJOMNEE = false;
				JMKKFJOMNEE = !DNHGKGHCJOE_GetPurchasingStatus.NFEAMMJIMPG.OIJLNFJALJP_aborted_transaction_exists;
				BKICHGFLJPF_RequestRemainingForCurrency = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
				BKICHGFLJPF_RequestRemainingForCurrency.CGCFENMHJIM_Ids = new List<int>() { 1001, 3001, 3002, 3003, 3004, 4001 };
				BKICHGFLJPF_RequestRemainingForCurrency.CGCFENMHJIM_Ids.AddRange(FIPNIIFHOBE_dbGacha.DHIACJMOEBH);
				PCLDNINHHBE(BKICHGFLJPF_RequestRemainingForCurrency.CGCFENMHJIM_Ids, DPHPGLNFDLH_Time);
				yield return BKICHGFLJPF_RequestRemainingForCurrency.GDPDELLNOBO_WaitDone(N.a);
				//18
				if(BKICHGFLJPF_RequestRemainingForCurrency.NPNNPNAIONN_IsError)
				{
					// go LAB_00d48a98
					BFKEGJMPELF();
					yield break;
				}
				CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(BKICHGFLJPF_RequestRemainingForCurrency.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
				if(CLFGEAPFFMA)
				{
					PPOJLIPFMMP = NKGJPJPHLIF.HHCJCDFCLOB.HECNGABHNDJ;
					GBIEKJGODJD_i = 0;
					for(; GBIEKJGODJD_i < PPOJLIPFMMP.Length; GBIEKJGODJD_i++)
					{
						PPOJLIPFMMP[GBIEKJGODJD_i].LAOEGNLOJHC_Convert();
						//LAB_00d48d90
						if(!PPOJLIPFMMP[GBIEKJGODJD_i].PLOOEECNHFB_IsDone)
						{
							//19
							yield return null;
						}
						if(PPOJLIPFMMP[GBIEKJGODJD_i].NPNNPNAIONN_IsError)
						{
							// go LAB_00d48a98
							BFKEGJMPELF();
							yield break;
						}
					}
					PPOJLIPFMMP = null;
				}
				BEKAMBBOLBO_Done = false;
				if(!JMKKFJOMNEE)
				{ 
					TextPopupSetting setting = new TextPopupSetting();
					setting.TitleText = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_fail_title");
					setting.Buttons = new ButtonInfo[1]
					{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					setting.Text = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_fail");
					PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
					{
						//0xD45EEC
						BEKAMBBOLBO_Done = true;
					}, null, null, null);
					//LAB_00d49334
					//21
					while (!BEKAMBBOLBO_Done)
						yield return null;
					//go LAB_00d49354
				}
				else
				{
					TextPopupSetting setting = new TextPopupSetting();
					setting.TitleText = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_done_title");
					setting.Buttons = new ButtonInfo[1]
					{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
					};
					setting.Text = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_done");
					PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
					{
						//0xD45EE0
						BEKAMBBOLBO_Done = true;
					}, null, null, null);
					//LAB_00d490e0
					//20
					while (!BEKAMBBOLBO_Done)
						yield return null;
				}
				//LAB_00d49354
				KLMFJJCNBIP();
				CDDGCHNKLGJ_GetPurchasingStatus = null;
				NFJGANOGEFP_GetPurchasingStatus = null;
				DNHGKGHCJOE_GetPurchasingStatus = null;
				BKICHGFLJPF_RequestRemainingForCurrency = null;
				BMLCHDIEAAO_PlatformPaymentRecover = null;
				yield break;
			}
			if(DNHGKGHCJOE_GetPurchasingStatus.CJMFJOMECKI_ErrorId != SakashoErrorId.STORE_SERVER_ERROR)
			{
				// go LAB_00d48a98
				BFKEGJMPELF();
				yield break;
			}
			if(!BOGDHEBBHFA)
			{
				// go LAB_00d48a60
				KLMFJJCNBIP();
				yield break;
			}
			BEKAMBBOLBO_Done = false;
			JHHBAFKMBDL.HHCJCDFCLOB.EAGBOKEIAOC(() =>
			{
				//0xD45ED4
				BEKAMBBOLBO_Done = true;
			});
			//LAB_00d47944
			//17
			while (!BEKAMBBOLBO_Done)
				yield return null;
			// go LAB_00d4847c
			NEFKBBNKNPP();
			yield break;
		}
		if(CDDGCHNKLGJ_GetPurchasingStatus.CJMFJOMECKI_ErrorId != SakashoErrorId.STORE_SERVER_ERROR)
		{
			// go LAB_00d48a98
			BFKEGJMPELF();
			yield break;
		}
		if (!BOGDHEBBHFA)
		{
			// go LAB_00d48a60
			KLMFJJCNBIP();
			yield break;
		}
		BEKAMBBOLBO_Done = false;
		JHHBAFKMBDL.HHCJCDFCLOB.EAGBOKEIAOC(() =>
		{
			//0xD45EB0
			BEKAMBBOLBO_Done = true;
		});
		//LAB_00d47380
		// 10
		while (!BEKAMBBOLBO_Done)
			yield return null;
		// go LAB_00d4847c
		NEFKBBNKNPP();
		yield break;
	}

	// // RVA: 0xCEA030 Offset: 0xCEA030 VA: 0xCEA030
	private void PCLDNINHHBE(List<int> NNDGIAEFMOG, long JHNMKKNEENE_Time)
	{
		HHJHIFJIKAC_BonusVc bonusVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc;
		for(int i = 0; i < bonusVc.CDENCMNHNGA.Count; i++)
		{
			if(bonusVc.CDENCMNHNGA[i].EHKLFIBLHPI_IsTimeValid(JHNMKKNEENE_Time))
			{
				NNDGIAEFMOG.Add(bonusVc.CDENCMNHNGA[i].CPGFOBNKKBF);
			}
		}
	}

	// // RVA: 0xCEA23C Offset: 0xCEA23C VA: 0xCEA23C
	private bool DDGIEBFGGDF_CheckIsError(SakashoErrorId PPFNGGCBJKC_Id)
	{
		if(PPFNGGCBJKC_Id != SakashoErrorId.UNSUPPORTED_API_CALLED)
		{
			if(PPFNGGCBJKC_Id != SakashoErrorId.IAB_APP_PUBLIC_KEY_NOT_FOUND
				&& PPFNGGCBJKC_Id != SakashoErrorId.BAD_REQUEST)
			{
				return (PPFNGGCBJKC_Id ^ SakashoErrorId.STORE_SERVER_ERROR) == 0 || GDGBDFEGLKK == EMAGIFONJLD.HLEGCGNPMAB;
			}
		}
		return true;
	}

	// // RVA: 0xCEA274 Offset: 0xCEA274 VA: 0xCEA274
	public static bool ELDMAINJHJI(SakashoErrorId PPFNGGCBJKC_Id)
	{
		if (PPFNGGCBJKC_Id >= SakashoErrorId.CANNOT_MAKE_PAYMENTS && PPFNGGCBJKC_Id < SakashoErrorId.PURCHASING_CANCELLED)
		{
			TodoLogger.LogError(TodoLogger.ToCheck, "Check ELDMAINJHJI");
			return ((0x5cf >> (((int)PPFNGGCBJKC_Id - 59) & 0xff)) & 1) != 0;
		}
		return false;
	}

	// // RVA: 0xCEA298 Offset: 0xCEA298 VA: 0xCEA298
	public void CGPFMPHAAJK(IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK BFKEGJMPELF)
	{
		N.a.StartCoroutineWatched(BIIABMDFMEN_Coroutine_ManualRecover(KLMFJJCNBIP, BFKEGJMPELF));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B92F8 Offset: 0x6B92F8 VA: 0x6B92F8
	// // RVA: 0xCEA2F0 Offset: 0xCEA2F0 VA: 0xCEA2F0
	private IEnumerator BIIABMDFMEN_Coroutine_ManualRecover(IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK BFKEGJMPELF)
	{
		PJKLMCGEJMK OKDOIAEGADK; // 0x20
		bool KDBFKPNNKCB; // 0x24
		bool OHPOPJFGGPI; // 0x25
		HDPDEAJGJEO_PaymentGetPurchasingStatus ALILLFMEOOJ; // 0x28
		bool IGIFAMIOHMP; // 0x2C
		PPJGPCKAMDC_PlatformPaymentRecover BMLCHDIEAAO; // 0x30
		IBBMABBJFOA_PaymentRecover GMODLKDMFCO; // 0x34
		HDPDEAJGJEO_PaymentGetPurchasingStatus JFBEAOHKCEB; // 0x38
		int DNNHOKJKHJK; // 0x3C

		//0xD49AD8
		OKDOIAEGADK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		bool BEKAMBBOLBO = false;
		KDBFKPNNKCB = false;
		OHPOPJFGGPI = false;
		ALILLFMEOOJ = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new HDPDEAJGJEO_PaymentGetPurchasingStatus());
		ALILLFMEOOJ.NBFDEFGFLPJ = MJOKGGCMOMD_IsStoreServerError;
		yield return ALILLFMEOOJ.GDPDELLNOBO_WaitDone(N.a);
		IGIFAMIOHMP = false;
		if(!ALILLFMEOOJ.NPNNPNAIONN_IsError)
		{
			IGIFAMIOHMP = ALILLFMEOOJ.NFEAMMJIMPG.OIJLNFJALJP_aborted_transaction_exists;
		}
		BMLCHDIEAAO = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new PPJGPCKAMDC_PlatformPaymentRecover());
		BMLCHDIEAAO.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
		yield return BMLCHDIEAAO.GDPDELLNOBO_WaitDone(N.a);
		if(BMLCHDIEAAO.NPNNPNAIONN_IsError)
		{
			if (!DDGIEBFGGDF_CheckIsError(BMLCHDIEAAO.CJMFJOMECKI_ErrorId))
			{
				BFKEGJMPELF();
				yield break;
			}
		}
		GMODLKDMFCO = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new IBBMABBJFOA_PaymentRecover());
		GMODLKDMFCO.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
		yield return GMODLKDMFCO.GDPDELLNOBO_WaitDone(N.a);
		if(GMODLKDMFCO.NPNNPNAIONN_IsError)
		{
			if (!DDGIEBFGGDF_CheckIsError(BMLCHDIEAAO.CJMFJOMECKI_ErrorId))
			{
				BFKEGJMPELF();
				yield break;
			}
		}
		else
		{
			if(GMODLKDMFCO.NFEAMMJIMPG.FHANAFNKIFC_Success != null)
			{
				if (GMODLKDMFCO.NFEAMMJIMPG.FHANAFNKIFC_Success.Count > 0)
					KDBFKPNNKCB = true;
				if (GMODLKDMFCO.NFEAMMJIMPG.DOGDHKIEBJA_Errors.Count > 0)
					OHPOPJFGGPI = true;
			}
		}
		JFBEAOHKCEB = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new HDPDEAJGJEO_PaymentGetPurchasingStatus());
		JFBEAOHKCEB.NBFDEFGFLPJ = MJOKGGCMOMD_IsStoreServerError;
		yield return JFBEAOHKCEB.GDPDELLNOBO_WaitDone(N.a);
		if(!JFBEAOHKCEB.NPNNPNAIONN_IsError)
		{
			if(IGIFAMIOHMP)
			{
				if (!JFBEAOHKCEB.NFEAMMJIMPG.OIJLNFJALJP_aborted_transaction_exists)
					KDBFKPNNKCB = true;
			}
			IGIFAMIOHMP = JFBEAOHKCEB.NFEAMMJIMPG.OIJLNFJALJP_aborted_transaction_exists;
		}
		string title;
		string msg;
		if(!IGIFAMIOHMP)
		{
			DNNHOKJKHJK = 0;
			if (OHPOPJFGGPI)
			{
				DNNHOKJKHJK = 2;
				title = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_fail_title");
				msg = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_fail");
			}
			else
			{
				if (!KDBFKPNNKCB)
				{
					title = "";
					msg = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_none");
				}
				else
				{
					DNNHOKJKHJK = 1;
					title = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_done_title");
					msg = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_done");
				}
			}
		}
		else
		{
			DNNHOKJKHJK = 0;
			OHPOPJFGGPI = true;
			//LAB_00d4a284
			DNNHOKJKHJK = 2;
			title = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_fail_title");
			msg = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_fail");
		}
		BEKAMBBOLBO = false;
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = title;
		s.IsCaption = !string.IsNullOrEmpty(title);
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = msg;
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0xD45F00
			BEKAMBBOLBO = true;
		}, null, null, null);
		while(!BEKAMBBOLBO)
			yield return null;
		if(DNNHOKJKHJK < 2)
		{
			KLMFJJCNBIP();
			yield break;
		}
		//LAB_00d4a564
		BFKEGJMPELF();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9370 Offset: 0x6B9370 VA: 0x6B9370
	// // RVA: 0xCEA3AC Offset: 0xCEA3AC VA: 0xCEA3AC
	// public IEnumerator HELKENJBJBH_AccountRemoveRecover(IMCBBOAFION KLMFJJCNBIP, DJBHIFLHJLK BFKEGJMPELF) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B93E8 Offset: 0x6B93E8 VA: 0x6B93E8
	// // RVA: 0xCEA468 Offset: 0xCEA468 VA: 0xCEA468
	// public IEnumerator KCCCOEMPPEA(SakashoErrorId MFDOKGNKNJJ, bool JBADCKAEMLI) { }

	// // RVA: 0xCEA524 Offset: 0xCEA524 VA: 0xCEA524
	// private void FOKFHDAFODE() { }

	// // RVA: 0xCEA538 Offset: 0xCEA538 VA: 0xCEA538
	// private void LFGLFMCIGIK() { }

	// // RVA: 0xCEA54C Offset: 0xCEA54C VA: 0xCEA54C
	// private void DHAOCHPANFH() { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B9460 Offset: 0x6B9460 VA: 0x6B9460
	// // RVA: 0xCEA560 Offset: 0xCEA560 VA: 0xCEA560
	// public IEnumerator PKNNELLMKPD_Test() { }

	// // RVA: 0xCEA5E8 Offset: 0xCEA5E8 VA: 0xCEA5E8
	// public void PFEKONLBFDM() { }

	// // RVA: 0xCE95AC Offset: 0xCE95AC VA: 0xCE95AC
	private void FAHKEEFPAFH(JFDNPFFOACP NIMPEHIECJH)
	{
		TextPopupSetting s = new TextPopupSetting();
		s.IsCaption = false;
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
		};
		s.Text = MessageManager.Instance.GetMessage("menu", "popup_cbt_purchase");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType INDDJNMPONH, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0xD45F28
			NIMPEHIECJH();
		}, null, null, null);
	}

	// // RVA: 0xCEA5F8 Offset: 0xCEA5F8 VA: 0xCEA5F8
	// private void JCLIKCHGEBH(LGDNAJACFHI MEANCEOIMGE) { }

	// // RVA: 0xCEA6C8 Offset: 0xCEA6C8 VA: 0xCEA6C8
	// public static void JCLIKCHGEBH(FHPFLAGNCAF MEANCEOIMGE) { }

	// // RVA: 0xCEA6CC Offset: 0xCEA6CC VA: 0xCEA6CC
	// public static void FPEGBMIFDDN() { }

	// // RVA: 0xCEA6D0 Offset: 0xCEA6D0 VA: 0xCEA6D0
	// public static void HIBOGALOHHO() { }
}
