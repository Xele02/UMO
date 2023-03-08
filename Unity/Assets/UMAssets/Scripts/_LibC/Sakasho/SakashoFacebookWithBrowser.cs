using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoFacebookWithBrowserGetFacebookLinkageStatus(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["facebook_linkage"] = false;
			SendMessage(callbackId, res);
			return 0;
		}
	}
}
