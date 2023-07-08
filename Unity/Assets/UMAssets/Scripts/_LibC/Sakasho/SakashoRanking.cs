using System.Collections.Generic;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public partial class RankingData
		{
			public int rankingId;
			public List<RankingDataUser> users = new List<RankingDataUser>();
		}

		public partial class RankingDataUser
		{
			public int userId;
			public int score;
			public int rank;
		}
		public partial class PlayerData
		{
			public Dictionary<int, RankingDataUser> rankingsData = new Dictionary<int, RankingDataUser>();
		}

		public partial class AccountData
		{
			public Dictionary<int, RankingData> rankings = new Dictionary<int, RankingData>();
		}

		private static void CheckDefaultRankingCreated()
		{
			if(!playerAccount.rankings.ContainsKey(16510))
			{
				playerAccount.rankings.Add(16510, new RankingData());
			}
		}

		public static int SakashoRankingGetRankings(int callbackId, string json)
		{
			CheckDefaultRankingCreated();

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["rankings"] = new EDOHBJAPLPF_JsonData();
            res["rankings"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoRankingGetRanksAroundSelf(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData input = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			int rankingId = (int)input["id"];
			int rankingType = (int)input["type"];
			int rankingFrom = (int)input["from"];
			int rankingTo = (int)input["to"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			if (!playerAccount.playerData.rankingsData.ContainsKey(rankingId))
			{
				res["error_code"] = (int)SakashoErrorId.RANKING_PLAYER_NOT_FOUND;//"RANKING_PLAYER_NOT_FOUND";
				res["error_detail"] = null;
			}
			else
			{
				res["ranks"] = new EDOHBJAPLPF_JsonData();
				res["ranks"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				// todo min/max
				EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
				d["extra"] = null;
				d["player_id"] = playerAccount.userId;
				d["rank"] = 1;//playerAccount.playerData.rankingsData[rankingId].rank;
				d["score"] = playerAccount.playerData.rankingsData[rankingId].score;
				res["ranks"].Add(d);
			}

			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoRankingUpdateRankingScore(int callbackId, string json)
		{
			CheckDefaultRankingCreated();

			EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			int id = (int)data["id"];
			int score = (int)data["score"];
			string extra = (string)data["extra"];

			if(playerAccount.rankings.ContainsKey(id))
			{
				RankingDataUser rUser;
				if (!playerAccount.playerData.rankingsData.ContainsKey(id))
				{
					rUser = new RankingDataUser();
					playerAccount.playerData.rankingsData.Add(id, rUser);
					playerAccount.rankings[id].users.Add(rUser);
				}
				else
				{
					rUser = playerAccount.playerData.rankingsData[id];
				}
				rUser.score = score;
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["score"] = score;
			res["rank"] = 1;
			res["ranking_dropped_player"] = false;
			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoRankingGetTopRanks(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData input = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			int rankingId = (int)input["id"];
			int rankingType = (int)input["type"];
			int rankingPage = (int)input["page"];
			int rankingIpp = (int)input["ipp"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			if (!playerAccount.playerData.rankingsData.ContainsKey(rankingId))
			{
				res["error_code"] = (int)SakashoErrorId.RANKING_PLAYER_NOT_FOUND;//"RANKING_PLAYER_NOT_FOUND";
				res["error_detail"] = null;
			}
			else
			{
				res["ranks"] = new EDOHBJAPLPF_JsonData();
				res["ranks"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				// todo min/max
				EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
				d["extra"] = null;
				d["player_id"] = playerAccount.userId;
				d["rank"] = playerAccount.playerData.rankingsData[rankingId].rank;
				d["score"] = playerAccount.playerData.rankingsData[rankingId].score;
				res["ranks"].Add(d);
			}
			res[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page] = 1;
			res[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page] = -1;
			res[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page] = -1;

			SendMessage(callbackId, res);
			return 0;
		}
	}
}
