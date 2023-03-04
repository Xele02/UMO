
using XeSys;

public delegate void BODAGDPODNB(string HJLDBEJOMIO, IMCBBOAFION HIDFAIBOHCC, bool EFDMHILHFPJ, bool OPEDAAIEOGN);
public delegate bool LLKBLEFEGOO();

public class MBCPNPNMFHB
{
	public static bool OCDEJGJGJBF; // 0x4
	private const long FHGFONJKNLM = 60;
	private string[] LBONAHCGKBJ_UrlWithToken = new string[11]; // 0x8
	private long[] KNIKOPJKPCI_GetTime = new long[11]; // 0xC
	public BODAGDPODNB OIPOPJCPDPC_DisplayUrlCb; // 0x10
	private bool GAJMFACKAGL; // 0x18

	public static MBCPNPNMFHB HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public object Method { get; private set; }

	public LLKBLEFEGOO LKKNBHCGFBG { private get; set; } // 0x14 JGFDEEKLBGJ DPNHBBOHIIE NNHHILCHAEF

	//// RVA: 0xA2D7CC Offset: 0xA2D7CC VA: 0xA2D7CC
	public void IJBGPAENLJA()
	{
		HHCJCDFCLOB = this;
		for (int i = 0; i < 11; i++)
		{
			LBONAHCGKBJ_UrlWithToken[i] = "";
			KNIKOPJKPCI_GetTime[i] = 0;
		}
	}

	//// RVA: 0xA2D8D8 Offset: 0xA2D8D8 VA: 0xA2D8D8
	//public void BJEJNAIDDME() { }

	//// RVA: 0xA2D8E4 Offset: 0xA2D8E4 VA: 0xA2D8E4
	//public void HFONLKDDNMJ() { }

	//// RVA: 0xA2D8F0 Offset: 0xA2D8F0 VA: 0xA2D8F0
	//public bool FIFIFFGGOGB() { }

	//// RVA: 0xA2D92C Offset: 0xA2D92C VA: 0xA2D92C
	public void MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO INDDJNMPONH, IMCBBOAFION HIDFAIBOHCC_OnSuccess, IMCBBOAFION AOCANKOMKFG_OnFail)
	{
		MHOILBOJFHL.KCAEDEHGAFO OIPCCBHIKIA = INDDJNMPONH;
		LKFOCCGOINN_GetURL l = BAGOKKHNLDB(INDDJNMPONH);
		if(l != null)
		{
			bool DBJECEMOJON = true;
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(l);
			l.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0xA2E200
				LKFOCCGOINN_GetURL res = NHECPMNKEFK as LKFOCCGOINN_GetURL;
				LBONAHCGKBJ_UrlWithToken[(int)OIPCCBHIKIA] = res.NFEAMMJIMPG_Result.MCHAINJKMEB_UrlWithToken;
				KNIKOPJKPCI_GetTime[(int)OIPCCBHIKIA] = Utility.GetCurrentUnixTime();
				OIPOPJCPDPC_DisplayUrlCb(LBONAHCGKBJ_UrlWithToken[(int)OIPCCBHIKIA], HIDFAIBOHCC_OnSuccess, DBJECEMOJON, GAJMFACKAGL);
			};
			l.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0xA2E4F4
				SakashoErrorId eId = NHECPMNKEFK.CJMFJOMECKI_ErrorId;
				SakashoErrorId eId2 = eId;
				if (eId2 != SakashoErrorId.NETWORK_ERROR)
				{
					eId2 = SakashoErrorId.INVALID_PLAYER_TOKEN;
				}
				if(eId == SakashoErrorId.NETWORK_ERROR || eId == eId2 || eId == SakashoErrorId.INACTIVE_PLAYER_DEVICE)
				{
					AOCANKOMKFG_OnFail();
				}
				else
				{
					HIDFAIBOHCC_OnSuccess();
				}
			};
			return;
		}
		HIDFAIBOHCC_OnSuccess();
	}

	//// RVA: 0xA21E3C Offset: 0xA21E3C VA: 0xA21E3C
	//public void FLLLPBIECCP(string OKDLGFMLLFH, IMCBBOAFION HIDFAIBOHCC, DJBHIFLHJLK AOCANKOMKFG) { }

	//// RVA: 0xA2DE68 Offset: 0xA2DE68 VA: 0xA2DE68
	//public void PBIKAGIOOHC(string APLKCOFFHKN, IMCBBOAFION HIDFAIBOHCC, IMCBBOAFION AOCANKOMKFG) { }

	//// RVA: 0xA2DB5C Offset: 0xA2DB5C VA: 0xA2DB5C
	private LKFOCCGOINN_GetURL BAGOKKHNLDB(MHOILBOJFHL.KCAEDEHGAFO INDDJNMPONH)
	{
		switch(INDDJNMPONH)
		{
			case MHOILBOJFHL.KCAEDEHGAFO.CCFMGBNHMNN_Inquiry:
				return new IHCPIPBJCJL_GetInquiryURL();
			case MHOILBOJFHL.KCAEDEHGAFO.GHDACOGLNLJ_Contract:
				TodoLogger.LogNotImplemented("RequestURL GHDACOGLNLJ_Contract");
				break;
			default:
				TodoLogger.Log(0, "MBCPNPNMFHB.BAGOKKHNLDB");
				break;
		}
		return null;
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6B9FC0 Offset: 0x6B9FC0 VA: 0x6B9FC0
	//// RVA: 0xA2E094 Offset: 0xA2E094 VA: 0xA2E094
	//public IEnumerator EBIENHFDNNL_OpenRiyoukiyakuDirect() { }

	//// RVA: 0xA2E140 Offset: 0xA2E140 VA: 0xA2E140
	//private bool ODKJMFJIMMA(SakashoErrorId PPFNGGCBJKC) { }
}
