using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoSupportSiteGetInquiryURL(int callbackId, string json)
		{
			UnityEngine.Debug.Log("SakashoSupportSiteGetInquiryURL " + json);
			TodoLogger.Log(0, "SakashoSupportSiteGetInquiryURL");

			string message = "";

			UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", "" + callbackId + ":" + message);

			return 0;
		}
	}
}
