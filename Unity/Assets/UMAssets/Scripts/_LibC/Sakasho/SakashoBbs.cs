using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoBbsGetThreads(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["threads"] = new EDOHBJAPLPF_JsonData();
			res["threads"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res["current_page"] = 1;
			res["previous_page"] = 0;
			res["next_page"] = 0;

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoBbsCreateThread(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["thread_id"] = 0;

			SendMessage(callbackId, res);

			return 0;
		}
		
	}
}
