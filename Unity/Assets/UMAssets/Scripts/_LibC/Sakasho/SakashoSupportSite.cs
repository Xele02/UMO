using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoSupportSiteGetInquiryURL(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.EEDAHFGPNPH_sss_temporary_token] = "";
			res[AFEHLCGHAEE_Strings.MCHAINJKMEB_url_with_token] = "";
			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoSupportSiteGetOpinionURL(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.EEDAHFGPNPH_sss_temporary_token] = "";
			res[AFEHLCGHAEE_Strings.MCHAINJKMEB_url_with_token] = "";
			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoSupportSiteGetRemainingForCurrencyIdsURL(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.EEDAHFGPNPH_sss_temporary_token] = "";
			res[AFEHLCGHAEE_Strings.MCHAINJKMEB_url_with_token] = "";
			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoSupportSiteGetInformationURL(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.EEDAHFGPNPH_sss_temporary_token] = "";
			res[AFEHLCGHAEE_Strings.MCHAINJKMEB_url_with_token] = "";
			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoSupportSiteBuildUrl(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.EEDAHFGPNPH_sss_temporary_token] = "";
			res[AFEHLCGHAEE_Strings.MCHAINJKMEB_url_with_token] = "";
			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoSupportSiteGetCommonTemplateURL(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.EEDAHFGPNPH_sss_temporary_token] = "";
			res[AFEHLCGHAEE_Strings.MCHAINJKMEB_url_with_token] = "";
			SendMessage(callbackId, res);
			return 0;
		}
		
		public static int SakashoSupportSiteGetToken(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["sss_temporary_token"] = "";
			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoSupportSiteGetOriginalTemplateURL(int callbackId, string json)
		{
			TodoLogger.LogError(0, "SakashoSupportSiteGetOriginalTemplateURL");

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.EEDAHFGPNPH_sss_temporary_token] = "";
			res[AFEHLCGHAEE_Strings.MCHAINJKMEB_url_with_token] = "";
			SendMessage(callbackId, res);
			return 0;
		}
	}
}
