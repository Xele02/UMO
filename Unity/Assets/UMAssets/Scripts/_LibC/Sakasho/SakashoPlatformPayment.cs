using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoPlatformPaymentRecover(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoPlatformPaymentGetProducts(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);
			return 0;
		}
	}
}
