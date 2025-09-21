
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp;
using XeApp.Game.Common;
using XeSys;

public delegate void BODAGDPODNB(string HJLDBEJOMIO, IMCBBOAFION _HIDFAIBOHCC_OnSuccess, bool EFDMHILHFPJ, bool OPEDAAIEOGN);
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
	public void BJEJNAIDDME()
	{
		GAJMFACKAGL = true;
	}

	//// RVA: 0xA2D8E4 Offset: 0xA2D8E4 VA: 0xA2D8E4
	public void HFONLKDDNMJ()
	{
		GAJMFACKAGL = false;
	}

	//// RVA: 0xA2D8F0 Offset: 0xA2D8F0 VA: 0xA2D8F0
	public bool FIFIFFGGOGB()
	{
		if(!GAJMFACKAGL)
			return false;
		return LKKNBHCGFBG();
	}

	//// RVA: 0xA2D92C Offset: 0xA2D92C VA: 0xA2D92C
	public void MDGPGGLHIPB_ShowWebUrl(MHOILBOJFHL.KCAEDEHGAFO _INDDJNMPONH_Type, IMCBBOAFION _HIDFAIBOHCC_OnSuccess, IMCBBOAFION _AOCANKOMKFG_OnError)
	{
		MHOILBOJFHL.KCAEDEHGAFO OIPCCBHIKIA_index = _INDDJNMPONH_Type;
		LKFOCCGOINN_GetURL l = BAGOKKHNLDB(_INDDJNMPONH_Type);
		if(l != null)
		{
			bool DBJECEMOJON = true;
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(l);
			l.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0xA2E200
				LKFOCCGOINN_GetURL res = NHECPMNKEFK as LKFOCCGOINN_GetURL;
				LBONAHCGKBJ_UrlWithToken[(int)OIPCCBHIKIA_index] = res.NFEAMMJIMPG_Result.MCHAINJKMEB_url_with_token;
				KNIKOPJKPCI_GetTime[(int)OIPCCBHIKIA_index] = Utility.GetCurrentUnixTime();
				OIPOPJCPDPC_DisplayUrlCb(LBONAHCGKBJ_UrlWithToken[(int)OIPCCBHIKIA_index], _HIDFAIBOHCC_OnSuccess, DBJECEMOJON, GAJMFACKAGL);
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
					_AOCANKOMKFG_OnError();
				}
				else
				{
					_HIDFAIBOHCC_OnSuccess();
				}
			};
			return;
		}
		_HIDFAIBOHCC_OnSuccess();
	}

	//// RVA: 0xA21E3C Offset: 0xA21E3C VA: 0xA21E3C
	public void FLLLPBIECCP(string _OKDLGFMLLFH_Templ, IMCBBOAFION _HIDFAIBOHCC_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		AMFBEGANJGC_GetOriginalTemplateURL data = new AMFBEGANJGC_GetOriginalTemplateURL();
		data.COHBIBEAMAF = _OKDLGFMLLFH_Templ;
		data.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0xA2E580
			AMFBEGANJGC_GetOriginalTemplateURL r = NHECPMNKEFK as AMFBEGANJGC_GetOriginalTemplateURL;
			OIPOPJCPDPC_DisplayUrlCb(r.NFEAMMJIMPG_Result.MCHAINJKMEB_url_with_token, _HIDFAIBOHCC_OnSuccess, true, GAJMFACKAGL);
		};
		data.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0xA2E704
			if(NHECPMNKEFK.CJMFJOMECKI_ErrorId != SakashoErrorId.NETWORK_ERROR && NHECPMNKEFK.CJMFJOMECKI_ErrorId != SakashoErrorId.INVALID_PLAYER_TOKEN && NHECPMNKEFK.CJMFJOMECKI_ErrorId != SakashoErrorId.INACTIVE_PLAYER_DEVICE)
			{
				_HIDFAIBOHCC_OnSuccess();
			}
			else
			{
				_AOCANKOMKFG_OnError();
			}
		};
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(data);
	}

	//// RVA: 0xA2DE68 Offset: 0xA2DE68 VA: 0xA2DE68
	public void PBIKAGIOOHC(string APLKCOFFHKN, IMCBBOAFION _HIDFAIBOHCC_OnSuccess, IMCBBOAFION _AOCANKOMKFG_OnError)
	{
		AIOILMKDPOG_GetInformationDetailURL req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new AIOILMKDPOG_GetInformationDetailURL());
		req.APLKCOFFHKN = APLKCOFFHKN;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0xA2E7AC
			AIOILMKDPOG_GetInformationDetailURL r = NHECPMNKEFK as AIOILMKDPOG_GetInformationDetailURL;
			OIPOPJCPDPC_DisplayUrlCb(r.NFEAMMJIMPG_Result.MCHAINJKMEB_url_with_token, _HIDFAIBOHCC_OnSuccess, true, GAJMFACKAGL);
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0xA2E930
			if(NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.NETWORK_ERROR || 
				NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.INVALID_PLAYER_TOKEN || 
				NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.INACTIVE_PLAYER_DEVICE)
			{
				_AOCANKOMKFG_OnError();
			}
			else
			{
				_HIDFAIBOHCC_OnSuccess();
			}
		};
	}

	//// RVA: 0xA2DB5C Offset: 0xA2DB5C VA: 0xA2DB5C
	private LKFOCCGOINN_GetURL BAGOKKHNLDB(MHOILBOJFHL.KCAEDEHGAFO _INDDJNMPONH_Type)
	{
		switch(_INDDJNMPONH_Type)
		{
			case MHOILBOJFHL.KCAEDEHGAFO.GCCBFIFJHII_Information:
				return new KNOINKGFINE_GetInformationURL();
			case MHOILBOJFHL.KCAEDEHGAFO.CCFMGBNHMNN_Inquiry:
				return new IHCPIPBJCJL_GetInquiryURL();
			case MHOILBOJFHL.KCAEDEHGAFO.FFIDPICMNKN_Opinion:
				return new OIMLBEGNFNN_GetOpinionURL();
			case MHOILBOJFHL.KCAEDEHGAFO.LCNNIHGFBMP_Balance:
				{
					KAEOJLJDOBI_GetRemainingForCurrencyIdsURL res = new KAEOJLJDOBI_GetRemainingForCurrencyIdsURL();
					res.JHPMKDEEJGM = new List<int>();
					res.JHPMKDEEJGM.Add(1001);
					return res;
				}
			case MHOILBOJFHL.KCAEDEHGAFO.EHDHJCGOGGN_Copyright:
				return new DDCHNOGMOHK_GetCommonTemplateURL("use_of_legend_sub");
			case MHOILBOJFHL.KCAEDEHGAFO.BFKFPEDCFCL_Settlement:
				return new DDCHNOGMOHK_GetCommonTemplateURL("shikin_kessai_ho_sub");
			case MHOILBOJFHL.KCAEDEHGAFO.LCCLAEBKMLD_Legals:
				return new DDCHNOGMOHK_GetCommonTemplateURL("tokusho_ho_android");
			case MHOILBOJFHL.KCAEDEHGAFO.EMAOPPMGKBD_Policy:
				return new DDCHNOGMOHK_GetCommonTemplateURL("android_privacypolicy");
			case MHOILBOJFHL.KCAEDEHGAFO.GHDACOGLNLJ_Contract:
				return new DDCHNOGMOHK_GetCommonTemplateURL(AppEnv.IsCBT() ? "riyou_kiyaku_sub" : "riyou_kiyaku");
			case MHOILBOJFHL.KCAEDEHGAFO.JMIDCMFKPOE_Credit:
				{
					AMFBEGANJGC_GetOriginalTemplateURL res = new AMFBEGANJGC_GetOriginalTemplateURL();
					res.COHBIBEAMAF = "credit";
					return res;
				}
		}
		return null;
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6B9FC0 Offset: 0x6B9FC0 VA: 0x6B9FC0
	//// RVA: 0xA2E094 Offset: 0xA2E094 VA: 0xA2E094
	public IEnumerator EBIENHFDNNL_Coroutine_OpenRiyoukiyakuDirect()
	{
		float DNALKLKKGAG; // 0x18
		SakashoAPICallContext OIDFKCIECJN; // 0x1C
		bool OLIDBAGENIL; // 0x20

		//0xA2EA0C
		string s = AppEnv.IsCBT() ? "riyou_kiyaku_sub" : "riyou_kiyaku";
		DNALKLKKGAG = 0;
		bool BEKAMBBOLBO_Done = false;
		string HPEPNAGOHEN = null;
		SakashoError DOGDHKIEBJA_Error = null;
		OIDFKCIECJN = SakashoSupportSite.GetCommonTemplateURL(s, (string _IDLHJIOMJBK_Data) =>
		{
			//0xA2E9C4
			BEKAMBBOLBO_Done = true;
			HPEPNAGOHEN = _IDLHJIOMJBK_Data;
		}, (SakashoError _CNAIDEAFAAM_Error) =>
		{
			//0xA2E9D4
			BEKAMBBOLBO_Done = false;
			DOGDHKIEBJA_Error = _CNAIDEAFAAM_Error;
		});
		OLIDBAGENIL = false;
		while(!BEKAMBBOLBO_Done)
		{
			DNALKLKKGAG += Time.deltaTime;
			if(DNALKLKKGAG >= 15)
			{
				OLIDBAGENIL = true;
				OIDFKCIECJN.CancelAPICall();
				BEKAMBBOLBO_Done = true;
				break;
			}
			yield return null;
		}
		if(!OLIDBAGENIL)
		{
			if(HPEPNAGOHEN == null)
			{
				if(DOGDHKIEBJA_Error == null)
					yield break;
				Debug.Log("errorId=" + DOGDHKIEBJA_Error.getErrorId().ToString());
				BEKAMBBOLBO_Done = false;
				TextPopupSetting setting = new TextPopupSetting();
				setting.TitleText = JpStringLiterals.StringLiteral_11918;
				setting.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
				};
				setting.Text = string.Format(JpStringLiterals.StringLiteral_12462, DOGDHKIEBJA_Error.getErrorId().ToString());
				PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
				{
					//0xA2E9FC
					BEKAMBBOLBO_Done = true;
				}, null, null, null, true, true, false, null, null, null, null, null);
				while(!BEKAMBBOLBO_Done)
					yield return null;
			}
			else
			{
				EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(HPEPNAGOHEN);
				string url = (string)data[AFEHLCGHAEE_Strings.MCHAINJKMEB_url_with_token];
				Debug.Log("url_with_token=" + url);
				BEKAMBBOLBO_Done = false;
				OIPOPJCPDPC_DisplayUrlCb(url, () =>
				{
					//0xA2E9F0
					BEKAMBBOLBO_Done = true;
				}, true, false);
				while(!BEKAMBBOLBO_Done)
					yield return null;
			}
		}
		else
		{
			BEKAMBBOLBO_Done = false;
			TextPopupSetting setting = new TextPopupSetting();
			setting.TitleText = JpStringLiterals.StringLiteral_11918;
			setting.Buttons = new ButtonInfo[1]
			{
				new ButtonInfo() { Label = PopupButton.ButtonLabel.Close, Type = PopupButton.ButtonType.Negative }
			};
			setting.Text = JpStringLiterals.StringLiteral_12459;
			PopupWindowManager.Show(setting, (PopupWindowControl HEIEPLBJGJA, PopupButton.ButtonType _INDDJNMPONH_Type, PopupButton.ButtonLabel LHFGEOAJAAL) =>
			{
				//0xA2E9E4
				BEKAMBBOLBO_Done = true;
			}, null, null, null, true, true, false, null, null, null, null, null);
			while(!BEKAMBBOLBO_Done)
				yield return null;
		}
	}

	//// RVA: 0xA2E140 Offset: 0xA2E140 VA: 0xA2E140
	//private bool ODKJMFJIMMA(SakashoErrorId _PPFNGGCBJKC_id) { }
}
