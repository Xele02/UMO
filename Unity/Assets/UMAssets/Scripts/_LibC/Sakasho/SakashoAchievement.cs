using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoAchievementGetAchievementRecords(int callbackId, string json)
		{
			// Hack directly send response

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			TodoLogger.LogError(TodoLogger.SakashoServer, "SakashoAchievementGetAchievementRecords");

			SendMessage(callbackId, res);
			// end hack

			return 0;
		}

		public static int SakashoAchievementClaimAchievementPrizes(int callbackId, string json)
		{
			// Hack directly send response

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			TodoLogger.LogError(TodoLogger.SakashoServer, "SakashoAchievementClaimAchievementPrizes");

			SendMessage(callbackId, res);
			// end hack

			return 0;
		}

		public static int SakashoAchievementClaimAchievementPrizesSetInventoryClosedAt(int callbackId, string json)
		{
			// Hack directly send response

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			TodoLogger.LogError(TodoLogger.SakashoServer, "SakashoAchievementClaimAchievementPrizesSetInventoryClosedAt");

			SendMessage(callbackId, res);
			// end hack

			return 0;
		}

		public static int SakashoAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt(int callbackId, string json)
		{
			// Hack directly send response
			TodoLogger.LogError(TodoLogger.SakashoServer, "SakashoAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt");
			return SakashoPlayerDataSavePlayerData(callbackId, json);
		}

		public static int SakashoAchievementClaimAchievementPrizesAndSave(int callbackId, string json)
		{
			// Hack directly send response
			EDOHBJAPLPF_JsonData msgData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["achievement_prizes"] = new EDOHBJAPLPF_JsonData();
			res["achievement_prizes"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < msgData["keys"].HNBFOAJIIAL_Count; i++)
			{
				EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
				res["achievement_prizes"].Add(d);
				string key = (string)msgData["keys"][i];
				d["key"] = key;
				d["inventories"] = new EDOHBJAPLPF_JsonData();
				d["inventories"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				d["inventory_ids"] = new EDOHBJAPLPF_JsonData();
				d["inventory_ids"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

				if(key.StartsWith("normal_quest_key_"))
				{
					int id = int.Parse(key.Replace("normal_quest_key_", ""));
					LCKMNLOLDPD reward = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.LFAAEPAAEMB.Find((LCKMNLOLDPD _) =>
					{
						return _.BGFPPGPJONG_QuestKeyId == id;
					});
                    CNLPPCFJEID_QuestInfo quest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests.Find((CNLPPCFJEID_QuestInfo _) =>
					{
						return _.EIHOBHDKCDB_RewardId == reward.PPFNGGCBJKC;
					});
                    if (reward.GLCLFMGPMAN_ItemFullId != 10000)
						TodoLogger.LogError(TodoLogger.SakashoServer, "Unknown item : " + reward.GLCLFMGPMAN_ItemFullId);

                    UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
					{
						item_count = reward.HMFFHLPNMPH_Cnt,
						item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(reward.GLCLFMGPMAN_ItemFullId),
						item_type = 1,
						item_value = 1001,
						type = 109,
						message = ILLPDLODANB.HHMKDAIGMKC_IsDebutMission((ILLPDLODANB.LOEGALDKHPL)quest.INDDJNMPONH_Type) ? JpStringLiterals.UMO_achievements_debut_quest : JpStringLiterals.UMO_achievements_normal_quest,
						closed_at = 32535097200
					});
					//UnityEngine.Debug.LogError(addedItem.item_name+" "+addedItem.item_value);
					addedItem.AddInInventoryResult(d);
                }
				else if(key.StartsWith("daily_quest_"))
				{
					int id = int.Parse(key.Replace("daily_quest_", ""));
					LCKMNLOLDPD reward = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.LFAAEPAAEMB.Find((LCKMNLOLDPD _) =>
					{
						return _.BGFPPGPJONG_QuestKeyId == id;
					});
                    CNLPPCFJEID_QuestInfo quest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests.Find((CNLPPCFJEID_QuestInfo _) =>
					{
						return _.EIHOBHDKCDB_RewardId == reward.PPFNGGCBJKC;
					});
                    if (reward.GLCLFMGPMAN_ItemFullId != 10000)
						TodoLogger.LogError(TodoLogger.SakashoServer, "Unknown item : " + reward.GLCLFMGPMAN_ItemFullId);

                    UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
					{
						item_count = reward.HMFFHLPNMPH_Cnt,
						item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(reward.GLCLFMGPMAN_ItemFullId),
						item_type = 1,
						item_value = 1001,
						type = 109,
						message = JpStringLiterals.UMO_achievements_daily_quest,
						closed_at = 32535097200
					});
					//UnityEngine.Debug.LogError(addedItem.item_name+" "+addedItem.item_value);
					addedItem.AddInInventoryResult(d);
                }
				else if(key.StartsWith("free_key_"))
				{
					bool isLine6 = key.Contains("_l6");
					string k2 = key.Replace("free_key_", "").Replace("_l6", "");
					string[] vals = k2.Split(new char[] { '_' });
					int musicId = int.Parse(vals[0]);
					int diff = int.Parse(vals[1]);
					int reward = int.Parse(vals[2]);
					KEODKEGFDLD_FreeMusicInfo mdata = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(musicId);
					HDNKOFNBCEO_RewardInfo rinfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NEJKJJPIGKD_GetRewardInfo(mdata, diff, isLine6);
					UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
					{
						item_count = rinfo.KAINPNMMAEK(reward),
						item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(rinfo.FKNBLDPIPMC_GetGlobalId(reward)),
						item_type = 1,
						item_value = 1001,
						type = 109,
						message = JpStringLiterals.UMO_achievements_freemusic,
						closed_at = 32535097200
					});
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(rinfo.FKNBLDPIPMC_GetGlobalId(reward)) != EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
						TodoLogger.LogError(TodoLogger.SakashoServer, "Unknown item : " + rinfo.FKNBLDPIPMC_GetGlobalId(reward));
					addedItem.AddInInventoryResult(d);
				}
				else if(key.StartsWith("episode_key_"))
				{
					string k2 = key.Replace("episode_key_", "");
					string[] vals = k2.Split(new char[] { '_' });
					int epId = int.Parse(vals[0]);
					int rewardId = int.Parse(vals[1]);
					HMGPODKEFBA_EpisodeInfo dbEp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList[epId - 1];
					JNIKPOIKFAC_Reward reward = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.LFAAEPAAEMB_Rewards[dbEp.HHJGBJCIFON_Rewards[rewardId - 1]];
					UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
					{
						item_count = reward.JDLJPNMLFID_Count,
						item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(reward.KIJAPOFAGPN_Item),
						item_type = 1,
						item_value = 1001,
						type = 109,
						message = JpStringLiterals.UMO_achievements_episode,
						closed_at = 32535097200
					});
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(reward.KIJAPOFAGPN_Item) != EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
						TodoLogger.LogError(TodoLogger.SakashoServer, "Unknown item : " + reward.KIJAPOFAGPN_Item);
					addedItem.AddInInventoryResult(d);
				}
				else if(key.StartsWith("new_offer_clear_key_"))
				{
					string k2 = key.Replace("new_offer_clear_key_", "");
					int ofId = int.Parse(k2);
					LGHIPHEDCNC_Offer.NONCDAINJLD of1 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.HOJPJAFDIAD.Find((LGHIPHEDCNC_Offer.LHDLCLNBPLB _) =>
					{
						return _.LJNAKDMILMC == ofId;
					});
					LGHIPHEDCNC_Offer.NONCDAINJLD of2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.FFKIBJKEBNP.Find((LGHIPHEDCNC_Offer.BFEIHCJHHAJ _) =>
					{
						return _.LJNAKDMILMC == ofId;
					});
					LGHIPHEDCNC_Offer.NONCDAINJLD of3 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.PMCDKBBHCJK.Find((LGHIPHEDCNC_Offer.PDLENIHAMBC _) =>
					{
						return _.LJNAKDMILMC == ofId;
					});
					LGHIPHEDCNC_Offer.NONCDAINJLD of4 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBCMJGOOHLJ_Offer.OICGEEKOLOG.Find((LGHIPHEDCNC_Offer.FCOBCHHKMOA _) =>
					{
						return _.LJNAKDMILMC == ofId;
					});
					LGHIPHEDCNC_Offer.NONCDAINJLD of = of1;
					if(of2 != null)
					{
						if(of != null)
							UnityEngine.Debug.LogError("multiple reward found, check");
						else
							of = of2;
					}
					if(of3 != null)
					{
						if(of != null)
							UnityEngine.Debug.LogError("multiple reward found, check");
						else
							of = of3;
					}
					if(of4 != null)
					{
						if(of != null)
							UnityEngine.Debug.LogError("multiple reward found, check");
						else
							of = of4;
					}
					if(of != null)
					{
						UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
						{
							item_count = 5,
							item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1)),
							item_type = 1,
							item_value = 1001,
							type = 109,
							message = JpStringLiterals.UMO_achievements_new_offer,
							closed_at = 32535097200
						});
						addedItem.AddInInventoryResult(d);
					}
				}
				else if(key.StartsWith("costume_key_"))
				{
					string k2 = key.Replace("costume_key_", "");
					string[] vals = k2.Split(new char[] { '_' });
					int cosId = int.Parse(vals[0]);
					int levelId = int.Parse(vals[1]);
					int costume_upgrade_vc_count = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("costume_upgrade_vc_count", 5);
					UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
					{
						item_count = costume_upgrade_vc_count,
						item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1)),
						item_type = 1,
						item_value = 1001,
						type = 109,
						message = JpStringLiterals.UMO_achievements_costume,
						closed_at = 32535097200
					});
					addedItem.AddInInventoryResult(d);
				}
				else
				{
					UnityEngine.Debug.LogError("Missing reward for "+(string)msgData["keys"][i]);
				}
			}
			bool as_received = (bool)msgData["asReceived"];
			if(as_received)
				UnityEngine.Debug.LogError("asReceived true");
				
			SavePlayerData(msgData, res);
			SendMessage(callbackId, res);
			return SakashoPlayerDataSavePlayerData(callbackId, json);
		}

		/*
		"achievement_prizes": [
        {
            "inventories": [ // normal
                {
                    "created_at": 1654419587,
                    "id": 9072914395,
                    "item_count": 10,
                    "item_name": "\u6b4c\u6676\u77f3",
                    "item_type": 1,
                    "item_value": 1001,
                    "message": "\u30ce\u30fc\u30de\u30eb\u30df\u30c3\u30b7\u30e7\u30f3\u306e\u9054\u6210\u5831\u916c\u3067\u3059\u3002",
                    "type": 109
                }
            ],
            "inventory_ids": [
                9072914395
            ],
            "key": "normal_quest_key_0214"
        },
		{
            "inventories": [ // episode
                {
                    "created_at": 1654417138,
                    "id": 9072883632,
                    "item_count": 10,
                    "item_name": "\u6b4c\u6676\u77f3",
                    "item_type": 1,
                    "item_value": 1001,
                    "message": "\u30a8\u30d4\u30bd\u30fc\u30c9\u306e\u89e3\u653e\u5831\u916c\u3067\u3059\u3002",
                    "type": 109
                }
            ],
            "inventory_ids": [
                9072883632
            ],
            "key": "episode_key_0001_04"
        },
		{
            "inventories": [ // debut
                {
                    "created_at": 1654417540,
                    "id": 9072888411,
                    "item_count": 10,
                    "item_name": "\u6b4c\u6676\u77f3",
                    "item_type": 1,
                    "item_value": 1001,
                    "message": "\u30c7\u30d3\u30e5\u30fc\u30df\u30c3\u30b7\u30e7\u30f3\u306e\u9054\u6210\u5831\u916c\u3067\u3059\u3002",
                    "type": 109
                }
            ],
            "inventory_ids": [
                9072888411
            ],
            "key": "normal_quest_key_0218"
        },
		{
            "inventories": [ // new offer
                {
                    "created_at": 1654420544,
                    "id": 9072927034,
                    "item_count": 5,
                    "item_name": "\u6b4c\u6676\u77f3",
                    "item_type": 1,
                    "item_value": 1001,
                    "message": "\u30d0\u30eb\u30ad\u30ea\u30fc\u30aa\u30da\u30ec\u30fc\u30b7\u30e7\u30f3\u306e\u521d\u56de\u9054\u6210\u5831\u916c\u3067\u3059\u3002",
                    "type": 109
                }
            ],
            "inventory_ids": [
                9072927034
            ],
            "key": "new_offer_clear_key_40001"
        },
        {
            "inventories": [ // costume
                {
                    "created_at": 1654421770,
                    "id": 9072943400,
                    "item_count": 5,
                    "item_name": "\u6b4c\u6676\u77f3",
                    "item_type": 1,
                    "item_value": 1001,
                    "message": "\u8863\u88c5\u5f37\u5316\u306e\u304d\u3083\u308f\u308f\u30e9\u30f3\u30af\u30a2\u30c3\u30d7\u5831\u916c\u3067\u3059\u3002",
                    "type": 109
                }
            ],
            "inventory_ids": [
                9072943400
            ],
            "key": "costume_key_001_01"
        }
		free_key_<free_music_id>_<diff>_<song_reward_num> 
		free_key_1560_3_00_l6
		song_reward_num : 0-3 = clear / 4-7 = score / 8-11 = combo
		daily_quest_
    ],
		*/
	}
}
