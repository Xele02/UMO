using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using XeApp;
using XeApp.Game.Common;
using XeSys;

public delegate void JFDNPFFOACP();
public delegate void ELBOJBBIBFM(LGDNAJACFHI _PPFNGGCBJKC_id);
public delegate void BKEHAMOGHCL(AMOCLPHDGBP PKLPKMLGFGK, ELBOJBBIBFM EDMKFIJKJLB, JFDNPFFOACP NIMPEHIECJH);
public delegate void JCKIFJADNEF(PJHHCHAKGKI KFFBDNMNBMM, JFDNPFFOACP NIMPEHIECJH);
public delegate void PJHHCHAKGKI(int LBEBFEIHPOO, int _IBAKPKKEDJM_Month);
public delegate void KMIEKGLLDCI(int LBEBFEIHPOO, int _KLCMKLPIDDJ_Month, IMCBBOAFION BHEOPIPFEFJ, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail);

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
        FKPEAGGKNLC_Start_0 = 0,
        EBABINMPENN = 1,
        NALKNDBAEHD = 2,
        CPJMCILHPKO_3 = 3,
        ACJKDEHJGFI = 4,
        GCBEOFGKJPF_5 = 5,
        NGFFHEHOKJB_6 = 6,
        FJNADADCBGJ = 7,
        AAHHJDACPCN = 8,
        FMPPMBNDJJF = 9,
        EEEAMFOKGFK = 10,
    }

	public BKEHAMOGHCL MKDKKDNBEEK; // 0x8
	public JCKIFJADNEF AJGKLIIDKHA; // 0xC
	public KMIEKGLLDCI FIJMBKFJJIJ; // 0x10
	private IMCBBOAFION BHFHGFKBOHH_OnSuccess; // 0x14
	private JFDNPFFOACP NIMPEHIECJH; // 0x18
	private DJBHIFLHJLK MOBEEPPKFLG_OnFail; // 0x1C
	public Action PBJINBCLFBB; // 0x20
	private bool ENDJKKHKMNP; // 0x24
	private bool PPKOLFEBLCF = true; // 0x25
	private SakashoErrorId OHBJPKPCIEB = SakashoErrorId.PRODUCT_TRANSACTION_EXISTS; // 0x28
	private bool LNHFLJBGGJB_IsRunning; // 0x2C
	private bool OCNNKKPBDLL; // 0x2D
	private bool PBCJCAOLLKI; // 0x2E
	private bool NHOAJCLAEJD; // 0x2F
	public bool CLFGEAPFFMA; // 0x30
	private EMAGIFONJLD GDGBDFEGLKK; // 0x34
	private static string[] CMPEKADFEEO = new string[11] {"paidvc start ", "get_products_success ", "purchase_start ", "purchase_action ", "error_emultaion ", "purchase_success ",
															"purchase_cancel ", "purchase_error_special ", "purchase_error_permanent ", "purchase_error_purchase ", "processing now "}; // 0x0
	private int LBEBFEIHPOO; // 0x38
	private int KLCMKLPIDDJ_Month; // 0x3C
	private bool LPEJBOIONDP; // 0x40
	private bool KIECCJLPNMN; // 0x41
	private bool ALNCNJMEFHM; // 0x42
	private bool KCEDKOHKHGL; // 0x43
	private bool KMABBBKJFCB_Percent; // 0x44
	private int FJIKAAOMOKE; // 0x48

	public EJHPIMANJFP HFCNOINEPLB { get { return EJHPIMANJFP.HHCJCDFCLOB; } } // IHHPFGILBNE 0xCE9480

	public bool Unused() { return PPKOLFEBLCF && NHOAJCLAEJD && OCNNKKPBDLL && LPEJBOIONDP && OHBJPKPCIEB == SakashoErrorId.UNKNOWN; }

	// // RVA: 0xCE9488 Offset: 0xCE9488 VA: 0xCE9488
	private void FCPBCDOKOPD(FINNDKJENCG _PPFNGGCBJKC_id, string IBDJFHFIIHN/* = ""*/)
	{
		return;
	}

	// // RVA: 0xCE948C Offset: 0xCE948C VA: 0xCE948C
	private void JEEPGGGAKMI_ClearCallbacks()
	{
		BHFHGFKBOHH_OnSuccess = null;
		NIMPEHIECJH = null;
		MOBEEPPKFLG_OnFail = null;
		PBJINBCLFBB = null;
	}

	// // RVA: 0xCE949C Offset: 0xCE949C VA: 0xCE949C
	public void DCDPMEPNKND(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, Action PBJINBCLFBB, bool MBGCBCOPOLA/* = false*/, bool AJAPLLGJKJB/* = false*/)
	{
		if(AppEnv.IsCBT())
		{
			FAHKEEFPAFH(NIMPEHIECJH);
		}
		else
		{
			LPEJBOIONDP = false;
			CLFGEAPFFMA = AJAPLLGJKJB;
			LNHFLJBGGJB_IsRunning = false;
			OCNNKKPBDLL = true;
			N.a.StartCoroutineWatched(JGKMFHLKEJP_Coroutine_PreGetProductList(_BHFHGFKBOHH_OnSuccess, NIMPEHIECJH, _MOBEEPPKFLG_OnFail, PBJINBCLFBB));
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9118 Offset: 0x6B9118 VA: 0x6B9118
	// // RVA: 0xCE9838 Offset: 0xCE9838 VA: 0xCE9838
	private IEnumerator JGKMFHLKEJP_Coroutine_PreGetProductList(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, Action PBJINBCLFBB)
	{
		//0xD4A80C
		bool BEKAMBBOLBO_Done = false;
		bool NCFLGGPPNKN = false;
		bool CNAIDEAFAAM_Error = false;
		OLNDKPDNPCM_Auto_Recover(() =>
		{
			//0xD458C0
			BEKAMBBOLBO_Done = true;
		}, () =>
		{
			//0xD458CC
			BEKAMBBOLBO_Done = true;
			NCFLGGPPNKN = true;
		}, () =>
		{
			//0xD458D8
			BEKAMBBOLBO_Done = true;
			CNAIDEAFAAM_Error = true;
		}, true, false);
		while (!BEKAMBBOLBO_Done)
			yield return null;
		if(!NCFLGGPPNKN)
		{
			if(!CNAIDEAFAAM_Error)
			{
				this.BHFHGFKBOHH_OnSuccess = _BHFHGFKBOHH_OnSuccess;
				this.NIMPEHIECJH = NIMPEHIECJH;
				this.MOBEEPPKFLG_OnFail = _MOBEEPPKFLG_OnFail;
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
					if (_MOBEEPPKFLG_OnFail != null)
						_MOBEEPPKFLG_OnFail();
					JEEPGGGAKMI_ClearCallbacks();
				}, false, true);
			}
			else
			{
				if (_MOBEEPPKFLG_OnFail != null)
					_MOBEEPPKFLG_OnFail();
			}
		}
		else
		{
			if (NIMPEHIECJH != null)
				NIMPEHIECJH();
		}
	}

	// // RVA: 0xCE9924 Offset: 0xCE9924 VA: 0xCE9924
	private void JLNBMEMFGPH(LGDNAJACFHI _MEANCEOIMGE_Summon)
	{
		if (LNHFLJBGGJB_IsRunning)
			return;
		LNHFLJBGGJB_IsRunning = true;
		N.a.StartCoroutineWatched(IGFMPECJFJA_Coroutine_Purchase(_MEANCEOIMGE_Summon));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9190 Offset: 0x6B9190 VA: 0x6B9190
	// // RVA: 0xCE99D4 Offset: 0xCE99D4 VA: 0xCE99D4
	private IEnumerator IGFMPECJFJA_Coroutine_Purchase(LGDNAJACFHI _MEANCEOIMGE_Summon)
	{
		CBMFOOHOAOE_Purchase PNLGHFCFPPK_Request; // 0x30
		LAPFLEEAACL[] EKDFAFLIGKA; // 0x34
		int PAPFNLGLAIP; // 0x38

		//0xD4ACFC
		yield return null;
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		if(_MEANCEOIMGE_Summon.EMEKFFHCHMH_RewardEnd2 == 0 || (t >= _MEANCEOIMGE_Summon.EBEOPONDEKB_OpenedAt && _MEANCEOIMGE_Summon.EMEKFFHCHMH_RewardEnd2 >= t))
		{
			//LAB_00d4b224
			if(RuntimeSettings.CurrentSettings.RemoveCrystalLimit || _MEANCEOIMGE_Summon.FDGKHGFMCJJ + CIOECGOMILE.HHCJCDFCLOB.JBEKNFEGFFI().KCKBGALKNMA_paid < 10000)
			{
				//bool AAIOCNJGNEN = false;
				//LAB_00d4b344
				int a1 = 0;
				//AAIOCNJGNEN = false;
				PNLGHFCFPPK_Request = _MEANCEOIMGE_Summon.DMFHKJBCFBK();
				if(PNLGHFCFPPK_Request != null)
				{
					PNLGHFCFPPK_Request.NBFDEFGFLPJ = (SakashoErrorId OBFLLILNEHO) =>
					{
						//0xD4588C
						if(OBFLLILNEHO == SakashoErrorId.PRODUCT_TRANSACTION_EXISTS || OBFLLILNEHO == SakashoErrorId.PURCHASING_CANCELLED)
							return true;
						return OBFLLILNEHO >= SakashoErrorId.PENDING_TRANSACTION_OCCURED && OBFLLILNEHO < SakashoErrorId.INVALID_PRODUCT_IDS;
					};
					//if(PNLGHFCFPPK_Request == null)
					FCPBCDOKOPD(FINNDKJENCG.CPJMCILHPKO_3, _MEANCEOIMGE_Summon.OPFGFINHFCE_name);
					//LAB_00d4b4a0
					while(!PNLGHFCFPPK_Request.PLOOEECNHFB_IsDone)
						yield return null;
					if(PNLGHFCFPPK_Request.NPNNPNAIONN_IsError)
					{
						if(JGJFFKPFMDB.BDPBNKPKAJJ(PNLGHFCFPPK_Request.CJMFJOMECKI_ErrorId) == GOBDOEHKLHN.IPGGCCPIMMI_7)
						{
							FCPBCDOKOPD(FINNDKJENCG.NGFFHEHOKJB_6, BKPFOIIMFEN.CDENCMNHNGA_table[(int)PNLGHFCFPPK_Request.CJMFJOMECKI_ErrorId]);
							bool BEKAMBBOLBO_Done = false;
							TextPopupSetting s = new TextPopupSetting();
							s.TitleText = MessageManager.Instance.GetMessage("common", "popup_purchase_cancel_title");
							s.Buttons = new ButtonInfo[1]
							{
								new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
							};
							s.Text = MessageManager.Instance.GetMessage("common", "popup_purchase_cancel_01");
							PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
							{
								//0xD45DC4
								BEKAMBBOLBO_Done = true;
							}, null, null, null, true, true, false, null, null, null, null, null);
							//LAB_00d4b0fc
							if(!BEKAMBBOLBO_Done)
								yield return null;
							LNHFLJBGGJB_IsRunning = false;
							if(PBJINBCLFBB != null)
								PBJINBCLFBB();
							yield break;
						}
						FINNDKJENCG a2 = 0;
						string str = "";
						if(PNLGHFCFPPK_Request.CJMFJOMECKI_ErrorId < SakashoErrorId.PENDING_TRANSACTION_OCCURED)
						{
							/*if(PNLGHFCFPPK_Request.CJMFJOMECKI_ErrorId == SakashoErrorId.PRODUCT_TRANSACTION_EXISTS)
							{

							}*/
						}
						else
						{

						}
						TodoLogger.LogError(TodoLogger.RequestFail, "Error");
						//LAB_00d4c03c
						FCPBCDOKOPD(a2, str);
						LNHFLJBGGJB_IsRunning = false;
						if(PBJINBCLFBB != null)
							PBJINBCLFBB();
						yield break;
					}
					if(PNLGHFCFPPK_Request.NFEAMMJIMPG_Result != null)
					{
						int prev = CIOECGOMILE.HHCJCDFCLOB.JBEKNFEGFFI().KCKBGALKNMA_paid;
						CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(PNLGHFCFPPK_Request.NFEAMMJIMPG_Result.BBEPLKNMICJ_Balances);
						a1 = CIOECGOMILE.HHCJCDFCLOB.JBEKNFEGFFI().KCKBGALKNMA_paid - prev;
					}
					//>LAB_00d4bd6c
				}
				//LAB_00d4bd6c
				_MEANCEOIMGE_Summon.NLEKIOBIIIK();
				JCLIKCHGEBH(_MEANCEOIMGE_Summon);
				ILCCJNDFFOB.HHCJCDFCLOB.JONAMONAHOB(a1, CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency(), _MEANCEOIMGE_Summon);
				FCPBCDOKOPD(FINNDKJENCG.GCBEOFGKJPF_5, "");
				EKDFAFLIGKA = NKGJPJPHLIF.HHCJCDFCLOB.HECNGABHNDJ;
				//LAB_00d4d140
				for(PAPFNLGLAIP = 0; PAPFNLGLAIP < NKGJPJPHLIF.HHCJCDFCLOB.HECNGABHNDJ.Length; PAPFNLGLAIP++)
				{
					EKDFAFLIGKA[PAPFNLGLAIP].LAOEGNLOJHC_Start();
					//LAB_00d4d020
					while(!EKDFAFLIGKA[PAPFNLGLAIP].PLOOEECNHFB_IsDone)
						yield return null;
					if(EKDFAFLIGKA[PAPFNLGLAIP].NPNNPNAIONN_IsError)
					{
						//LAB_00d4d0e0
						MOBEEPPKFLG_OnFail();
						LNHFLJBGGJB_IsRunning = false;
						if(PBJINBCLFBB != null)
							PBJINBCLFBB();
						yield break;
					}
				}
				BHFHGFKBOHH_OnSuccess();
				LNHFLJBGGJB_IsRunning = false;
				if(PBJINBCLFBB != null)
					PBJINBCLFBB();
				yield break;
			}
			else
			{
				TextPopupSetting s = new TextPopupSetting();
				s.TitleText = MessageManager.Instance.GetMessage("common", "popup_purchase_limit_title");
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				s.Text = MessageManager.Instance.GetMessage("common", "popup_purchase_limit_01");
				PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
				{
					//0xD45D3C
					LNHFLJBGGJB_IsRunning = false;
					if(PBJINBCLFBB != null)
						PBJINBCLFBB();
				}, null, null, null, true, true, false, null, null, null, null, null);
			}
		}
		else
		{
			TextPopupSetting s = new TextPopupSetting();
			s.TitleText = MessageManager.Instance.GetMessage("common", "popup_purchase_expire_title");
			s.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
			};
			s.Text = MessageManager.Instance.GetMessage("common", "popup_purchase_expire_01");
			PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0xD45CBC
				LNHFLJBGGJB_IsRunning = false;
				if(PBJINBCLFBB != null)
					PBJINBCLFBB();
			}, null, null, null, true, true, false, null, null, null, null, null);
		}
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
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0xD45E64
			if (GIGHIFOIMNA != null)
				GIGHIFOIMNA();
		}, null, null, null, true, true, false, null, null, null, null, null);
	}

	// // RVA: 0xCE9D78 Offset: 0xCE9D78 VA: 0xCE9D78
	// private void AJHEHLHNMMF(int _PMBEODGMMBB_y, int _MABBBOEAPAA_p) { }

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
	// private IEnumerator NLMLHDONBJC_BirthdayRegistration(IMCBBOAFION _KLMFJJCNBIP_OnSuccess, JFDNPFFOACP NEFKBBNKNPP, JFDNPFFOACP _JGKOLBLPMPG_OnFail) { }

	// // RVA: 0xCE9EA0 Offset: 0xCE9EA0 VA: 0xCE9EA0
	private bool MJOKGGCMOMD_IsStoreServerError(SakashoErrorId GGBJNJJHLHJ)
	{
		return GGBJNJJHLHJ == SakashoErrorId.STORE_SERVER_ERROR;
	}

	// // RVA: 0xCE9EB0 Offset: 0xCE9EB0 VA: 0xCE9EB0
	public void OLNDKPDNPCM_Auto_Recover(IMCBBOAFION _KLMFJJCNBIP_OnSuccess, JFDNPFFOACP NEFKBBNKNPP, DJBHIFLHJLK _BFKEGJMPELF_OnError, bool EBKGBLFCENA/* = false*/, bool BOGDHEBBHFA/* = false*/)
	{
		N.a.StartCoroutineWatched(GEMPIKIBEKJ_Coroutine_AutoRecover(_KLMFJJCNBIP_OnSuccess,NEFKBBNKNPP,_BFKEGJMPELF_OnError,EBKGBLFCENA,BOGDHEBBHFA));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9280 Offset: 0x6B9280 VA: 0x6B9280
	// // RVA: 0xCE9F24 Offset: 0xCE9F24 VA: 0xCE9F24
	private IEnumerator GEMPIKIBEKJ_Coroutine_AutoRecover(IMCBBOAFION _KLMFJJCNBIP_OnSuccess, JFDNPFFOACP NEFKBBNKNPP, DJBHIFLHJLK _BFKEGJMPELF_OnError, bool EBKGBLFCENA, bool BOGDHEBBHFA)
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
		DPHPGLNFDLH_Time = OKDOIAEGADK_Server.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
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
						_BFKEGJMPELF_OnError();
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
				_BFKEGJMPELF_OnError();
				yield break;
			}
			CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(BKICHGFLJPF_RequestRemainingForCurrency.NFEAMMJIMPG_Result.BBEPLKNMICJ_Balances);
			if(CLFGEAPFFMA)
			{
				PPOJLIPFMMP = NKGJPJPHLIF.HHCJCDFCLOB.HECNGABHNDJ;
				for(GBIEKJGODJD_i = 0; GBIEKJGODJD_i < PPOJLIPFMMP.Length; GBIEKJGODJD_i++)
				{
					PPOJLIPFMMP[GBIEKJGODJD_i].LAOEGNLOJHC_Start();
					//LAB_00d48b44
					while(!PPOJLIPFMMP[GBIEKJGODJD_i].PLOOEECNHFB_IsDone)
					{
						// 5
						yield return null;
					}
					if(PPOJLIPFMMP[GBIEKJGODJD_i].NPNNPNAIONN_IsError)
					{
						//go LAB_00d48a98
						_BFKEGJMPELF_OnError();
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
				_KLMFJJCNBIP_OnSuccess();
				yield break;
			}
			if(!DDGIEBFGGDF_CheckIsError(BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId))
			{
				// go LAB_00d4846c
				if (!ELDMAINJHJI(JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId))
				{
					//LAB_00d48a98
					_BFKEGJMPELF_OnError();
					yield break;
				}
				// go LAB_00d4847c
				NEFKBBNKNPP();
				yield break;
			}
			if(BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId != SakashoErrorId.STORE_SERVER_ERROR)
			{
				// go LAB_00d48a60
				_KLMFJJCNBIP_OnSuccess();
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
					_KLMFJJCNBIP_OnSuccess();
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
			if(!CDDGCHNKLGJ_GetPurchasingStatus.NFEAMMJIMPG_Result.OIJLNFJALJP_aborted_transaction_exists)
			{
				// go LAB_00d48a60
				_KLMFJJCNBIP_OnSuccess();
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
				PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
				{
					//0xD45EBC
					BEKAMBBOLBO_Done = true;
				}, null, null, null, true, true, false, null, null, null, null, null);
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
					_BFKEGJMPELF_OnError();
					yield break;
				}
				if (BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.INTERNAL_CLIENT_ERROR)
				{
					// go LAB_00d48a98
					_BFKEGJMPELF_OnError();
					yield break;
				}
				if (BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.APPLICATION_UNDER_MAINTENANCE)
				{
					// go LAB_00d48a98
					_BFKEGJMPELF_OnError();
					yield break;
				}
				if (BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.OLDER_REQUIREMENT_CLIENT_VERSION)
				{
					// go LAB_00d48a98
					_BFKEGJMPELF_OnError();
					yield break;
				}
				if(BMLCHDIEAAO_PlatformPaymentRecover.PDAPLCPOCMA)
				{
					// go LAB_00d48a98
					_BFKEGJMPELF_OnError();
					yield break;
				}
				if(!DDGIEBFGGDF_CheckIsError(BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId))
				{
					// go LAB_00d48a98
					_BFKEGJMPELF_OnError();
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
					_BFKEGJMPELF_OnError();
					yield break;
				}
				if(!BOGDHEBBHFA)
				{
					// go LAB_00d48a60
					_KLMFJJCNBIP_OnSuccess();
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
			PBCJCAOLLKI = !NFJGANOGEFP_GetPurchasingStatus.NFEAMMJIMPG_Result.OIJLNFJALJP_aborted_transaction_exists;
			if(!PBCJCAOLLKI)
			{
				JNBNLCNBILD_PaymentRecover = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new IBBMABBJFOA_PaymentRecover());
				JNBNLCNBILD_PaymentRecover.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
				yield return JNBNLCNBILD_PaymentRecover.GDPDELLNOBO_WaitDone(N.a);
				//15
				if(!JNBNLCNBILD_PaymentRecover.NPNNPNAIONN_IsError)
				{
					if(JNBNLCNBILD_PaymentRecover.NFEAMMJIMPG_Result != null)
					{
						if(JNBNLCNBILD_PaymentRecover.NFEAMMJIMPG_Result.FHANAFNKIFC_Success != null)
						{
							//JNBNLCNBILD_PaymentRecover.LFOJDJCNOHB.FHANAFNKIFC_Success.Count
						}
					}
				}
				else
				{
					if(JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.NETWORK_ERROR)
					{
						// go LAB_00d48a98
						_BFKEGJMPELF_OnError();
						yield break;
					}
					if (JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.INTERNAL_CLIENT_ERROR)
					{
						// go LAB_00d48a98
						_BFKEGJMPELF_OnError();
						yield break;
					}
					if (JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.APPLICATION_UNDER_MAINTENANCE)
					{
						// go LAB_00d48a98
						_BFKEGJMPELF_OnError();
						yield break;
					}
					if (JNBNLCNBILD_PaymentRecover.CJMFJOMECKI_ErrorId == SakashoErrorId.OLDER_REQUIREMENT_CLIENT_VERSION)
					{
						// go LAB_00d48a98
						_BFKEGJMPELF_OnError();
						yield break;
					}
					if(JNBNLCNBILD_PaymentRecover.PDAPLCPOCMA)
					{
						// go LAB_00d48a98
						_BFKEGJMPELF_OnError();
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
				JMKKFJOMNEE = !DNHGKGHCJOE_GetPurchasingStatus.NFEAMMJIMPG_Result.OIJLNFJALJP_aborted_transaction_exists;
				BKICHGFLJPF_RequestRemainingForCurrency = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
				BKICHGFLJPF_RequestRemainingForCurrency.CGCFENMHJIM_Ids = new List<int>() { 1001, 3001, 3002, 3003, 3004, 4001 };
				BKICHGFLJPF_RequestRemainingForCurrency.CGCFENMHJIM_Ids.AddRange(FIPNIIFHOBE_dbGacha.DHIACJMOEBH);
				PCLDNINHHBE(BKICHGFLJPF_RequestRemainingForCurrency.CGCFENMHJIM_Ids, DPHPGLNFDLH_Time);
				yield return BKICHGFLJPF_RequestRemainingForCurrency.GDPDELLNOBO_WaitDone(N.a);
				//18
				if(BKICHGFLJPF_RequestRemainingForCurrency.NPNNPNAIONN_IsError)
				{
					// go LAB_00d48a98
					_BFKEGJMPELF_OnError();
					yield break;
				}
				CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(BKICHGFLJPF_RequestRemainingForCurrency.NFEAMMJIMPG_Result.BBEPLKNMICJ_Balances);
				if(CLFGEAPFFMA)
				{
					PPOJLIPFMMP = NKGJPJPHLIF.HHCJCDFCLOB.HECNGABHNDJ;
					GBIEKJGODJD_i = 0;
					for(; GBIEKJGODJD_i < PPOJLIPFMMP.Length; GBIEKJGODJD_i++)
					{
						PPOJLIPFMMP[GBIEKJGODJD_i].LAOEGNLOJHC_Start();
						//LAB_00d48d90
						if(!PPOJLIPFMMP[GBIEKJGODJD_i].PLOOEECNHFB_IsDone)
						{
							//19
							yield return null;
						}
						if(PPOJLIPFMMP[GBIEKJGODJD_i].NPNNPNAIONN_IsError)
						{
							// go LAB_00d48a98
							_BFKEGJMPELF_OnError();
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
					PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
					{
						//0xD45EEC
						BEKAMBBOLBO_Done = true;
					}, null, null, null, true, true, false, null, null, null, null, null);
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
					PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
					{
						//0xD45EE0
						BEKAMBBOLBO_Done = true;
					}, null, null, null, true, true, false, null, null, null, null, null);
					//LAB_00d490e0
					//20
					while (!BEKAMBBOLBO_Done)
						yield return null;
				}
				//LAB_00d49354
				_KLMFJJCNBIP_OnSuccess();
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
				_BFKEGJMPELF_OnError();
				yield break;
			}
			if(!BOGDHEBBHFA)
			{
				// go LAB_00d48a60
				_KLMFJJCNBIP_OnSuccess();
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
			_BFKEGJMPELF_OnError();
			yield break;
		}
		if (!BOGDHEBBHFA)
		{
			// go LAB_00d48a60
			_KLMFJJCNBIP_OnSuccess();
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
	private void PCLDNINHHBE(List<int> NNDGIAEFMOG, long _JHNMKKNEENE_Time)
	{
		HHJHIFJIKAC_BonusVc bonusVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc;
		for(int i = 0; i < bonusVc.CDENCMNHNGA_table.Count; i++)
		{
			if(bonusVc.CDENCMNHNGA_table[i].EHKLFIBLHPI_IsTimeValid(_JHNMKKNEENE_Time))
			{
				NNDGIAEFMOG.Add(bonusVc.CDENCMNHNGA_table[i].CPGFOBNKKBF_CurrencyId);
			}
		}
	}

	// // RVA: 0xCEA23C Offset: 0xCEA23C VA: 0xCEA23C
	private bool DDGIEBFGGDF_CheckIsError(SakashoErrorId _PPFNGGCBJKC_id)
	{
		if(_PPFNGGCBJKC_id != SakashoErrorId.UNSUPPORTED_API_CALLED)
		{
			if(_PPFNGGCBJKC_id != SakashoErrorId.IAB_APP_PUBLIC_KEY_NOT_FOUND
				&& _PPFNGGCBJKC_id != SakashoErrorId.BAD_REQUEST)
			{
				return (_PPFNGGCBJKC_id ^ SakashoErrorId.STORE_SERVER_ERROR) == 0 || GDGBDFEGLKK == EMAGIFONJLD.HLEGCGNPMAB;
			}
		}
		return true;
	}

	// // RVA: 0xCEA274 Offset: 0xCEA274 VA: 0xCEA274
	public static bool ELDMAINJHJI(SakashoErrorId _PPFNGGCBJKC_id)
	{
		if (_PPFNGGCBJKC_id >= SakashoErrorId.CANNOT_MAKE_PAYMENTS && _PPFNGGCBJKC_id < SakashoErrorId.PURCHASING_CANCELLED)
		{
			//return ((0x5cf >> (((int)PPFNGGCBJKC_id - 89) & 0xff)) & 1) != 0;
			return _PPFNGGCBJKC_id == SakashoErrorId.CANNOT_MAKE_PAYMENTS || 
					_PPFNGGCBJKC_id == SakashoErrorId.CURRENCY_ID_NOT_FOUND || 
					_PPFNGGCBJKC_id == SakashoErrorId.IAB_APP_PUBLIC_KEY_NOT_FOUND || 
					_PPFNGGCBJKC_id == SakashoErrorId.PRODUCT_TRANSACTION_EXISTS || 
					_PPFNGGCBJKC_id == SakashoErrorId.PLATFORM_RECEIPT_INVALID || 
					_PPFNGGCBJKC_id == SakashoErrorId.TRANSACTION_INVALID || 
					_PPFNGGCBJKC_id == SakashoErrorId.TRANSACTION_NOT_FOUND || 
					_PPFNGGCBJKC_id == SakashoErrorId.PLATFORM_PRODUCT_ID_NOT_REGISTERED;
			// 101 1100 1111
			// > CANNOT_MAKE_PAYMENTS = 89,
			// > CURRENCY_ID_NOT_FOUND = 90,
			// > IAB_APP_PUBLIC_KEY_NOT_FOUND = 91,
			// > PRODUCT_TRANSACTION_EXISTS = 92,
			// EXCEEDED_PRODUCT_QUANTITY_LIMIT = 93,
			// ANOTHER_PROCESS_IN_PROGRESS = 94,
			// > PLATFORM_RECEIPT_INVALID = 95,
			// > TRANSACTION_INVALID = 96,
			// > TRANSACTION_NOT_FOUND = 97,
			// PLAYER_AGE_UNKNOWN = 98,
			// > PLATFORM_PRODUCT_ID_NOT_REGISTERED = 99,
		}
		return false;
	}

	// // RVA: 0xCEA298 Offset: 0xCEA298 VA: 0xCEA298
	public void CGPFMPHAAJK(IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _BFKEGJMPELF_OnError)
	{
		N.a.StartCoroutineWatched(BIIABMDFMEN_Coroutine_ManualRecover(_KLMFJJCNBIP_OnSuccess, _BFKEGJMPELF_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B92F8 Offset: 0x6B92F8 VA: 0x6B92F8
	// // RVA: 0xCEA2F0 Offset: 0xCEA2F0 VA: 0xCEA2F0
	private IEnumerator BIIABMDFMEN_Coroutine_ManualRecover(IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _BFKEGJMPELF_OnError)
	{
		PJKLMCGEJMK OKDOIAEGADK_Server; // 0x20
		bool KDBFKPNNKCB; // 0x24
		bool OHPOPJFGGPI; // 0x25
		HDPDEAJGJEO_PaymentGetPurchasingStatus ALILLFMEOOJ; // 0x28
		bool IGIFAMIOHMP; // 0x2C
		PPJGPCKAMDC_PlatformPaymentRecover BMLCHDIEAAO_PlatformPaymentRecover; // 0x30
		IBBMABBJFOA_PaymentRecover GMODLKDMFCO; // 0x34
		HDPDEAJGJEO_PaymentGetPurchasingStatus JFBEAOHKCEB; // 0x38
		int DNNHOKJKHJK; // 0x3C

		//0xD49AD8
		OKDOIAEGADK_Server = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		bool BEKAMBBOLBO_Done = false;
		KDBFKPNNKCB = false;
		OHPOPJFGGPI = false;
		ALILLFMEOOJ = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new HDPDEAJGJEO_PaymentGetPurchasingStatus());
		ALILLFMEOOJ.NBFDEFGFLPJ = MJOKGGCMOMD_IsStoreServerError;
		yield return ALILLFMEOOJ.GDPDELLNOBO_WaitDone(N.a);
		IGIFAMIOHMP = false;
		if(!ALILLFMEOOJ.NPNNPNAIONN_IsError)
		{
			IGIFAMIOHMP = ALILLFMEOOJ.NFEAMMJIMPG_Result.OIJLNFJALJP_aborted_transaction_exists;
		}
		BMLCHDIEAAO_PlatformPaymentRecover = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new PPJGPCKAMDC_PlatformPaymentRecover());
		BMLCHDIEAAO_PlatformPaymentRecover.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
		yield return BMLCHDIEAAO_PlatformPaymentRecover.GDPDELLNOBO_WaitDone(N.a);
		if(BMLCHDIEAAO_PlatformPaymentRecover.NPNNPNAIONN_IsError)
		{
			if (!DDGIEBFGGDF_CheckIsError(BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId))
			{
				_BFKEGJMPELF_OnError();
				yield break;
			}
		}
		GMODLKDMFCO = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new IBBMABBJFOA_PaymentRecover());
		GMODLKDMFCO.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
		yield return GMODLKDMFCO.GDPDELLNOBO_WaitDone(N.a);
		if(GMODLKDMFCO.NPNNPNAIONN_IsError)
		{
			if (!DDGIEBFGGDF_CheckIsError(BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId))
			{
				_BFKEGJMPELF_OnError();
				yield break;
			}
		}
		else
		{
			if(GMODLKDMFCO.NFEAMMJIMPG_Result.FHANAFNKIFC_Success != null)
			{
				if (GMODLKDMFCO.NFEAMMJIMPG_Result.FHANAFNKIFC_Success.Count > 0)
					KDBFKPNNKCB = true;
				if (GMODLKDMFCO.NFEAMMJIMPG_Result.DOGDHKIEBJA_Error.Count > 0)
					OHPOPJFGGPI = true;
			}
		}
		JFBEAOHKCEB = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new HDPDEAJGJEO_PaymentGetPurchasingStatus());
		JFBEAOHKCEB.NBFDEFGFLPJ = MJOKGGCMOMD_IsStoreServerError;
		yield return JFBEAOHKCEB.GDPDELLNOBO_WaitDone(N.a);
		if(!JFBEAOHKCEB.NPNNPNAIONN_IsError)
		{
			if(IGIFAMIOHMP)
			{
				if (!JFBEAOHKCEB.NFEAMMJIMPG_Result.OIJLNFJALJP_aborted_transaction_exists)
					KDBFKPNNKCB = true;
			}
			IGIFAMIOHMP = JFBEAOHKCEB.NFEAMMJIMPG_Result.OIJLNFJALJP_aborted_transaction_exists;
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
		BEKAMBBOLBO_Done = false;
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = title;
		s.IsCaption = !string.IsNullOrEmpty(title);
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = msg;
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0xD45F00
			BEKAMBBOLBO_Done = true;
		}, null, null, null, true, true, false, null, null, null, null, null);
		while(!BEKAMBBOLBO_Done)
			yield return null;
		if(DNNHOKJKHJK < 2)
		{
			_KLMFJJCNBIP_OnSuccess();
			yield break;
		}
		//LAB_00d4a564
		_BFKEGJMPELF_OnError();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9370 Offset: 0x6B9370 VA: 0x6B9370
	// // RVA: 0xCEA3AC Offset: 0xCEA3AC VA: 0xCEA3AC
	public IEnumerator HELKENJBJBH_Coroutine_AccountRemoveRecover(IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _BFKEGJMPELF_OnError)
	{
		PJKLMCGEJMK OKDOIAEGADK_Server; // 0x20
		bool KDBFKPNNKCB; // 0x24
		bool OHPOPJFGGPI; // 0x25
		HDPDEAJGJEO_PaymentGetPurchasingStatus ALILLFMEOOJ; // 0x28
		bool IGIFAMIOHMP; // 0x2C
		PPJGPCKAMDC_PlatformPaymentRecover BMLCHDIEAAO_PlatformPaymentRecover; // 0x30
		IBBMABBJFOA_PaymentRecover GMODLKDMFCO; // 0x34
		HDPDEAJGJEO_PaymentGetPurchasingStatus JFBEAOHKCEB; // 0x38
		int DNNHOKJKHJK; // 0x3C

		//0xD45F78
		OKDOIAEGADK_Server = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		bool BEKAMBBOLBO_Done = false;
		KDBFKPNNKCB = false;
		OHPOPJFGGPI = false;
		ALILLFMEOOJ = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new HDPDEAJGJEO_PaymentGetPurchasingStatus());
		ALILLFMEOOJ.NBFDEFGFLPJ = MJOKGGCMOMD_IsStoreServerError;
		yield return ALILLFMEOOJ.GDPDELLNOBO_WaitDone(N.a);
		IGIFAMIOHMP = false;
		if(!ALILLFMEOOJ.NPNNPNAIONN_IsError)
		{
			IGIFAMIOHMP = ALILLFMEOOJ.NFEAMMJIMPG_Result.OIJLNFJALJP_aborted_transaction_exists;
		}
		BMLCHDIEAAO_PlatformPaymentRecover = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new PPJGPCKAMDC_PlatformPaymentRecover());
		BMLCHDIEAAO_PlatformPaymentRecover.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
		yield return BMLCHDIEAAO_PlatformPaymentRecover.GDPDELLNOBO_WaitDone(N.a);
		if(BMLCHDIEAAO_PlatformPaymentRecover.NPNNPNAIONN_IsError)
		{
			if(!DDGIEBFGGDF_CheckIsError(BMLCHDIEAAO_PlatformPaymentRecover.CJMFJOMECKI_ErrorId))
			{
				//LAB_00d467b0;
				_BFKEGJMPELF_OnError();
				yield break;
			}
		}
		GMODLKDMFCO = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new IBBMABBJFOA_PaymentRecover());
		GMODLKDMFCO.NBFDEFGFLPJ = DDGIEBFGGDF_CheckIsError;
		yield return GMODLKDMFCO.GDPDELLNOBO_WaitDone(N.a);
		if(GMODLKDMFCO.NPNNPNAIONN_IsError)
		{
			if(!DDGIEBFGGDF_CheckIsError(GMODLKDMFCO.CJMFJOMECKI_ErrorId))
			{
				//LAB_00d467b0;
				_BFKEGJMPELF_OnError();
				yield break;
			}
		}
		else
		{
			if(GMODLKDMFCO.NFEAMMJIMPG_Result.FHANAFNKIFC_Success != null)
			{
				if(GMODLKDMFCO.NFEAMMJIMPG_Result.FHANAFNKIFC_Success.Count > 0)
					KDBFKPNNKCB = true;
				if(GMODLKDMFCO.NFEAMMJIMPG_Result.DOGDHKIEBJA_Error.Count > 0)
					OHPOPJFGGPI = true;
			}
		}
		JFBEAOHKCEB = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new HDPDEAJGJEO_PaymentGetPurchasingStatus());
		JFBEAOHKCEB.NBFDEFGFLPJ = MJOKGGCMOMD_IsStoreServerError;
		yield return JFBEAOHKCEB.GDPDELLNOBO_WaitDone(N.a);
		if(!JFBEAOHKCEB.NPNNPNAIONN_IsError && IGIFAMIOHMP)
		{
			if(!JFBEAOHKCEB.NFEAMMJIMPG_Result.OIJLNFJALJP_aborted_transaction_exists)
				KDBFKPNNKCB = true;
		}
		DNNHOKJKHJK = 0;
		if(!OHPOPJFGGPI)
		{
			DNNHOKJKHJK = KDBFKPNNKCB ? 1 : 0;
			//LAB_00d469c4
			_KLMFJJCNBIP_OnSuccess();
			yield break;
		}
		DNNHOKJKHJK = 2;
		BEKAMBBOLBO_Done = false;
		TextPopupSetting s = new TextPopupSetting();
		s.TitleText = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_fail_title");
		s.IsCaption = !string.IsNullOrEmpty(s.TitleText);
		s.Buttons = new ButtonInfo[1]
		{
			new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
		};
		s.Text = MessageManager.Instance.GetMessage("common", "popup_purchase_recover_fail");
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0xD45F14
			BEKAMBBOLBO_Done = true;
		}, null, null, null, true, true, false, null, null, null, null, null);
		while(!BEKAMBBOLBO_Done)
			yield return null;
		if(DNNHOKJKHJK > 1)
		{
			//LAB_00d467b0
			_BFKEGJMPELF_OnError();
		}
		else
		{
			//LAB_00d469c4
			_KLMFJJCNBIP_OnSuccess();
		}
	}

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
		PopupWindowManager.Show(s, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
		{
			//0xD45F28
			NIMPEHIECJH();
		}, null, null, null, true, true, false, null, null, null, null, null);
	}

	// // RVA: 0xCEA5F8 Offset: 0xCEA5F8 VA: 0xCEA5F8
	private void JCLIKCHGEBH(LGDNAJACFHI _MEANCEOIMGE_Summon)
	{
		LHFOAFAOPLC.AMNOLHCJDPN(_MEANCEOIMGE_Summon.OJIMENABACH_price_amount_micros / 100000.0f, _MEANCEOIMGE_Summon.JMEMGIPGGIK_currency_code);
	}

	// // RVA: 0xCEA6C8 Offset: 0xCEA6C8 VA: 0xCEA6C8
	// public static void JCLIKCHGEBH(FHPFLAGNCAF _MEANCEOIMGE_Summon) { }

	// // RVA: 0xCEA6CC Offset: 0xCEA6CC VA: 0xCEA6CC
	// public static void FPEGBMIFDDN() { }

	// // RVA: 0xCEA6D0 Offset: 0xCEA6D0 VA: 0xCEA6D0
	// public static void HIBOGALOHHO() { }
}
