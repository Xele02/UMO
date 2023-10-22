using System.Collections.Generic;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public struct ThreadInfo
		{
			public EDOHBJAPLPF_JsonData ThreadData;
		};
		public static Dictionary<int, ThreadInfo> Threads = new Dictionary<int, ThreadInfo>();
		public static int nextThreadId = 0;

		public static int SakashoBbsGetThreads(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["threads"] = new EDOHBJAPLPF_JsonData();
			res["threads"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			foreach(var t in Threads)
			{
				if(req.BBAJPINMOEP_Contains("threadGroup"))
				{
					if (t.Value.ThreadData.BBAJPINMOEP_Contains("threadGroup"))
					{
						if ((string)req["threadGroup"] != (string)t.Value.ThreadData["threadGroup"])
							continue;
					}
					else
						continue;
				}
				res["threads"].Add(t.Value.ThreadData);
			}
			res["current_page"] = 1;
			res["previous_page"] = 0;
			res["next_page"] = 0;

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoBbsCreateThread(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			EDOHBJAPLPF_JsonData threadInfo = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			threadInfo["comment_rotate"] = false;
			Threads.Add(nextThreadId, new ThreadInfo() { ThreadData = threadInfo });
			res["thread_id"] = nextThreadId;
			nextThreadId++;

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoBbsGetThreadComments(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["thread"] = Threads[(int)req["threadId"]].ThreadData;
			res["comments"] = new EDOHBJAPLPF_JsonData();
			res["comments"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res["current_page"] = 1;
			res["previous_page"] = 0;
			res["next_page"] = 0;

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoBbsCreateThreadComment(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["comment_index"] = 0;

			SendMessage(callbackId, res);

			return 0;
		}

	}
}
