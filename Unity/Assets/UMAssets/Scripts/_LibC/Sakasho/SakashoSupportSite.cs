using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoSupportSiteGetInquiryURL(int callbackId, string json)
		{
			UnityEngine.Debug.Log("SakashoSupportSiteGetInquiryURL " + json);
			TodoLogger.Log(0, "SakashoSupportSiteGetInquiryURL");

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
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
	}
}
