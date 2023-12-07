using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoLineGetLineLinkageStatus(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["line_linkage"] = false;
			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoLineLinkWithLine(int callbackId, string json)
		{
			return 0;
		}
		
	}
}
