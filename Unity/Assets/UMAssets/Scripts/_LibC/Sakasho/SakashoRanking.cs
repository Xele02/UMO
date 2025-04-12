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
			res["rankings"].Add(GetRankingInfo("uta_rate_ranking", false));
			res["rankings"].Add(GetRankingInfo("uta_rate_ranking2", false));
			for(int i = 1; i <= 10; i++)
			{
				res["rankings"].Add(GetRankingInfo(string.Format("diva_ranking_14999_{0:D2}", i), false));
				res["rankings"].Add(GetRankingInfo(string.Format("diva_ranking_14010_{0:D2}", i), false));
				res["rankings"].Add(GetRankingInfo(string.Format("diva_ranking_14011_{0:D2}", i), false));
				res["rankings"].Add(GetRankingInfo(string.Format("diva_ranking_14012_{0:D2}", i), false));
			}
			//res["rankings"].Add(GetRankingInfo("collect_ranking2_1061", false));
			//res["rankings"].Add(GetRankingInfo("collect_ranking_1061", false));
			//res["rankings"].Add(GetRankingInfo("score_ranking_4021", false));
			res["rankings"].Add(GetRankingInfo("battle_ranking_3044", false));
			res["rankings"].Add(GetRankingInfo("battle_ranking2_3044", false));
			res["rankings"].Add(GetRankingInfo("battle_ranking_3045", false));
			res["rankings"].Add(GetRankingInfo("battle_ranking2_3045", false));
			res["rankings"].Add(GetRankingInfo("battle_ranking_3046", false));
			res["rankings"].Add(GetRankingInfo("battle_ranking2_3046", false));

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
				res["error_code"] = "RANKING_PLAYER_NOT_FOUND";
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
			int score = 0;
			if(data["score"].MDDJBLEDMBJ_IsInt)
			{
				score = (int)data["score"];
			}
			else if(data["score"].DCPEFFOMOOK_IsLong)
			{
				score = (int)((long)data["score"]);
			}
			else if(data["score"].NFPOKKABOHN_IsDouble)
			{
				score = (int)((double)data["score"]);
			}
			string extra = null;
			if(data.BBAJPINMOEP_Contains("extra") && data["extra"] != null)
				extra = (string)data["extra"];

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
				res["error_code"] = "RANKING_PLAYER_NOT_FOUND";
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

		public static int SakashoRankingClaimRankingRewards(int callbackId, string json)
		{
			TodoLogger.LogError(TodoLogger._Debug, "Implement SakashoRankingClaimRankingRewards");
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["inventory_ids"] = new EDOHBJAPLPF_JsonData();
			res["inventory_ids"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoRankingGetRankingRecordsByKeys(int callbackId, string json)
		{
			CheckDefaultRankingCreated();

			EDOHBJAPLPF_JsonData input = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData keysArray = input["keys"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["rankings"] = new EDOHBJAPLPF_JsonData();
			res["rankings"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			for (int i = 0; i < keysArray.HNBFOAJIIAL_Count; i++)
			{
				string k = (string)keysArray[i];
				EDOHBJAPLPF_JsonData info = GetRankingInfo(k, true);
				if(info != null)
					res["rankings"].Add(info);
			}
			SendMessage(callbackId, res);
			return 0;
		}

		public static EDOHBJAPLPF_JsonData GetRankingInfo(string k, bool withRewards)
		{
			if (k == "uta_rate_ranking")
			{
				EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
				data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
				data["allow_lower_score"] = false;
				data["allow_negative_score"] = false;
				data["allow_tied_rank"] = true;
				data["batch_interval_time"] = 0;
				data["batch_started_at"] = 0;
				data["closed_at"] = 1654558200;
				data["competition_closed_at"] = 1654558140;
				data["default_score"] = 0;
				data["description"] = "\u6b4c\u30ec\u30fc\u30c8\u30e9\u30f3\u30ad\u30f3\u30b0";
				data["id"] = 15934;
				data["is_reverse"] = false;
				data["name"] = "uta_rate_ranking";
				data["name_for_api"] = "uta_rate_ranking";
				data["opened_at"] = 1651825800;
				data["ranking_type"] = 1;
				data["reward_opened_at"] = 1654558140;
				data["score_precision"] = 6;
				data["update_type"] = 0;
				if (withRewards)
				{
					data["rewards"] = new EDOHBJAPLPF_JsonData();
					data["rewards"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				}
				return data;
			}
			else if (k == "uta_rate_ranking2")
			{
				EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
				data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
				data["allow_lower_score"] = false;
				data["allow_negative_score"] = false;
				data["allow_tied_rank"] = true;
				data["batch_interval_time"] = 0;
				data["batch_started_at"] = 0;
				data["closed_at"] = 1734274740;
				data["competition_closed_at"] = 1732978800;
				data["default_score"] = 0;
				data["description"] = "\u6b4c\u30ec\u30fc\u30c8\u30e9\u30f3\u30ad\u30f3\u30b0";
				data["id"] = 16510;
				data["is_reverse"] = false;
				data["name"] = "uta_rate_ranking2";
				data["name_for_api"] = "uta_rate_ranking2";
				data["opened_at"] = 1575126000;
				data["ranking_type"] = 1;
				data["reward_opened_at"] = 1732978860;
				data["score_precision"] = 6;
				data["update_type"] = 0;
				if (withRewards)
				{
					data["rewards"] = new EDOHBJAPLPF_JsonData();
					data["rewards"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				}
				return data;
			}
			else if (k.StartsWith("diva_ranking_"))
			{
				int divaId = int.Parse(k.Replace("diva_ranking_", "").Split(new char[] { '_' })[1]);
				EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
				data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
				data["allow_lower_score"] = false;
				data["allow_negative_score"] = true;
				data["allow_tied_rank"] = true;
				data["batch_interval_time"] = 0;
				data["batch_started_at"] = 0;
				data["closed_at"] = 1751986799;
				data["competition_closed_at"] = 1751295600;
				data["default_score"] = 0;
				data["is_reverse"] = false;
				data["name_for_api"] = k;
				data["opened_at"] = 1593529200;
				data["ranking_type"] = 1;
				data["reward_opened_at"] = 1751299200;
				if (withRewards)
				{
					data["rewards"] = new EDOHBJAPLPF_JsonData();
					data["rewards"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				}
				data["score_precision"] = 6;
				data["update_type"] = 0;
				switch (divaId)
				{
					case 1:
						data["description"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30d5\u30ec\u30a4\u30a2";
						data["id"] = 18404;
						data["name"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30d5\u30ec\u30a4\u30a2";
						break;
					case 2:
						data["description"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u7f8e\u96f2";
						data["id"] = 18405;
						data["name"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u7f8e\u96f2";
						break;
					case 3:
						data["description"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30ab\u30ca\u30e1";
						data["id"] = 18406;
						data["name"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30ab\u30ca\u30e1";
						break;
					case 4:
						data["description"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30de\u30ad\u30ca";
						data["id"] = 18407;
						data["name"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30de\u30ad\u30ca";
						break;
					case 5:
						data["description"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30ec\u30a4\u30ca";
						data["id"] = 18408;
						data["name"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30ec\u30a4\u30ca";
						break;
					case 6:
						data["description"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30e9\u30f3\u30ab";
						data["id"] = 18409;
						data["name"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30e9\u30f3\u30ab";
						break;
					case 7:
						data["description"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30b7\u30a7\u30ea\u30eb";
						data["id"] = 18410;
						data["name"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30b7\u30a7\u30ea\u30eb";
						break;
					case 8:
						data["description"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30df\u30ec\u30fc\u30cc";
						data["id"] = 18411;
						data["name"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30df\u30ec\u30fc\u30cc";
						break;
					case 9:
						data["description"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30d0\u30b5\u30e9";
						data["id"] = 18412;
						data["name"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30d0\u30b5\u30e9";
						break;
					case 10:
						data["description"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30df\u30f3\u30e1\u30a4";
						data["id"] = 18413;
						data["name"] = "\u6b4c\u59eb\u30a4\u30d9\u30f3\u30c8\u5e38\u8a2d\u30e9\u30f3\u30ad\u30f3\u30b0 \u30df\u30f3\u30e1\u30a4";
						break;
				}

				return data;
			}
			else if(k.StartsWith("battle_ranking_"))
			{
				EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
				data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
				data["allow_lower_score"] = false;
				data["allow_negative_score"] = false;
				data["allow_tied_rank"] = true;
				data["batch_interval_time"] = 0;
				data["batch_started_at"] = 0;
				data["closed_at"] = 1734274740;
				data["competition_closed_at"] = 1732978800;
				data["default_score"] = 0;
				data["description"] = "Battle ranking";
				data["id"] = 300000 + int.Parse(k.Replace("battle_ranking_", ""));
				data["is_reverse"] = false;
				data["name"] = "battle_ranking";
				data["name_for_api"] = k;
				data["opened_at"] = 1575126000;
				data["ranking_type"] = 1;
				data["reward_opened_at"] = 1732978860;
				data["score_precision"] = 6;
				data["update_type"] = 0;
				if (withRewards)
				{
					data["rewards"] = new EDOHBJAPLPF_JsonData();
					data["rewards"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				}
				return data;
			}
			else if(k.StartsWith("battle_ranking2_"))
			{
				EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
				data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
				data["allow_lower_score"] = false;
				data["allow_negative_score"] = false;
				data["allow_tied_rank"] = true;
				data["batch_interval_time"] = 0;
				data["batch_started_at"] = 0;
				data["closed_at"] = 1734274740;
				data["competition_closed_at"] = 1732978800;
				data["default_score"] = 0;
				data["description"] = "Battle ranking";
				data["id"] = 310000 + int.Parse(k.Replace("battle_ranking2_", ""));
				data["is_reverse"] = false;
				data["name"] = "battle_ranking2";
				data["name_for_api"] = k;
				data["opened_at"] = 1575126000;
				data["ranking_type"] = 1;
				data["reward_opened_at"] = 1732978860;
				data["score_precision"] = 6;
				data["update_type"] = 0;
				if (withRewards)
				{
					data["rewards"] = new EDOHBJAPLPF_JsonData();
					data["rewards"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				}
				return data;
			}
			else
			{
				TodoLogger.LogError(TodoLogger.SakashoServer, "SakashoRankingGetRankingRecordsByKeys unknown ranking " + k);
				return null;
			}
		}
	}
}
