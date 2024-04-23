using System.Collections.Generic;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static string[] counterNames = { "fan_count" };

		public static int SakashoPlayerCounterGetPlayerCounters(int callbackId, string json)
		{
			CheckDefaultRankingCreated();

			string[] toReturn = counterNames;

			EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			if(data.BBAJPINMOEP_Contains("playerCounterMasterName"))
			{
				toReturn = new string[] { (string)data["playerCounterMasterName"] };
			}
			EDOHBJAPLPF_JsonData playersIds = null;
			if(data.BBAJPINMOEP_Contains("playerIds"))
			{
				playersIds = data["playerIds"];
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["player_counters"] = new EDOHBJAPLPF_JsonData();
			for (int p = 0; p < playersIds.HNBFOAJIIAL_Count; p++)
			{
				res["player_counters"][playersIds[p].ToString()] = new EDOHBJAPLPF_JsonData();
				res["player_counters"][playersIds[p].ToString()]["player_count"] = 0;
			}

			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoPlayerCounterUpdatePlayerCounter(int callbackId, string json)
		{
			CheckDefaultRankingCreated();

			string toReturn = "";

			EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			if(data.BBAJPINMOEP_Contains("playerCounterMasterName"))
			{
				toReturn = (string)data["playerCounterMasterName"];;
			}
			int playerId = (int)data["playerId"];
			int delta = (int)data["countDelta"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["player_counter"] = 0;
			res["effective_count_delta"] = 0;

			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoPlayerCounterUpdatePlayerCounters(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			TodoLogger.LogError(TodoLogger.SakashoServer, "SakashoPlayerCounterUpdatePlayerCounters");
			SendMessage(callbackId, res);
			return 0;
		}
	}
}
