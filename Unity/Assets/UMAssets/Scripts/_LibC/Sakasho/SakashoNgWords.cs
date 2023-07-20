using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoNgWordsValidate(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);
			return 0;
		}
	}
}
