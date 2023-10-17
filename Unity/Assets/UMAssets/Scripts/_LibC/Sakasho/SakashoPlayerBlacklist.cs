using System.Collections.Generic;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoPlayerBlacklistGetBlacklist(int callbackId, string json)
		{
			CheckDefaultRankingCreated();

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["player_blacklist"] = new EDOHBJAPLPF_JsonData();
			res["player_blacklist"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res["count"] = 0;
			res["next_page"] = -1;
			res["previous_page"] = -1;
			res["current_page"] = 1;

			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoPlayerBlacklistIsOnBlacklistOf(int callbackId, string json)
		{
			CheckDefaultRankingCreated();

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["blacklisted"] = false;

			SendMessage(callbackId, res);
			return 0;
		}
	}
}
