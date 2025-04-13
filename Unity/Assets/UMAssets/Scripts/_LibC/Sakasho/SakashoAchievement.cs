using System.Collections.Generic;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoAchievementGetAchievementRecords(int callbackId, string json)
		{
			// Hack directly send response

			EDOHBJAPLPF_JsonData msgData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData keysJson = msgData["keys"];
			List<string> keys = new List<string>();
			if(keys != null)
			{
				for(int i = 0; i < keysJson.HNBFOAJIIAL_Count; i++)
				{
					keys.Add((string)keysJson[i]);
				}
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			int playerStartRateNotGot = (int)playerAccount.playerData.serverData["common"]["ret_rew_rec_gra"];

			for(int i = 0; i < keys.Count; i++)
			{
				if(keys[i].StartsWith("rating_reward_receive_key_"))
				{
					string id = keys[i].Replace("rating_reward_receive_key_", "");
					HGPEFPFODHO_HighScoreRanking.LGNDICJEDNE dbrating = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO.Find((HGPEFPFODHO_HighScoreRanking.LGNDICJEDNE _) =>
					{
						return _.ICGAKKCCFOG == id;
					});
					if(dbrating != null)
					{
						EDOHBJAPLPF_JsonData dataRes = new EDOHBJAPLPF_JsonData();
						dataRes[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = keys[i];
						dataRes[AFEHLCGHAEE_Strings.LJGOOOMOMMA_message] = "Rating reward";
						dataRes[AFEHLCGHAEE_Strings.OOIJCMLEAJP_is_received] = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO.IndexOf(dbrating) < playerStartRateNotGot;
						dataRes[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items] = new EDOHBJAPLPF_JsonData();
						dataRes[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
						EDOHBJAPLPF_JsonData item = new EDOHBJAPLPF_JsonData();
						dataRes[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].Add(item);
						item[AFEHLCGHAEE_Strings.HAAJGNCFNJM_item_name] = JpStringLiterals.StringLiteral_10137;
						item[AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value] = 1001;
						item[AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count] = dbrating.GCKPDEDJFIC_ItemCount;
						item[AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type] = 1;
						res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes].Add(dataRes);
					}
					else
					{
						dbrating = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO.Find((HGPEFPFODHO_HighScoreRanking.LGNDICJEDNE _) =>
						{
							return _.BGFPPGPJONG.ToString() == id;
						});
						if(dbrating != null)
						{
							EDOHBJAPLPF_JsonData dataRes = new EDOHBJAPLPF_JsonData();
							dataRes[AFEHLCGHAEE_Strings.LJNAKDMILMC_key] = keys[i];
							dataRes[AFEHLCGHAEE_Strings.LJGOOOMOMMA_message] = "Rating reward";
							dataRes[AFEHLCGHAEE_Strings.OOIJCMLEAJP_is_received] = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO.IndexOf(dbrating) < playerStartRateNotGot;
							dataRes[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items] = new EDOHBJAPLPF_JsonData();
							dataRes[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
							for(int j = 0; j < dbrating.AJMDFJFCIML_GetCount(); j++)
							{
								EDOHBJAPLPF_JsonData item = new EDOHBJAPLPF_JsonData();
								dataRes[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].Add(item);
								item[AFEHLCGHAEE_Strings.HAAJGNCFNJM_item_name] = EKLNMHFCAOI.INCKKODFJAP_GetItemName(dbrating.FKNBLDPIPMC_GetItemId(j));
								item[AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value] = dbrating.FKNBLDPIPMC_GetItemId(j);
								item[AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count] = dbrating.NKOHMLHLJGL_GetItemCount(j);
								item[AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type] = 0;
							}
							res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes].Add(dataRes);
						}
						else
						{
							UnityEngine.Debug.LogError("Reward not found : "+keys[i]);
						}
					}
				}
			}

			// AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes
			//	>
			// 		AFEHLCGHAEE_Strings.LJNAKDMILMC_key
			//		AFEHLCGHAEE_Strings.LJGOOOMOMMA_message
			//		AFEHLCGHAEE_Strings.OOIJCMLEAJP_is_received
			//		"current_period" (optional)
			//		>	
			//			AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at
			//			AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at
			//		AFEHLCGHAEE_Strings.HBHMAKNGKFK_items
			//		>	
			//			AFEHLCGHAEE_Strings.HAAJGNCFNJM_item_name
			//			AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value
			//			AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count
			//			AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type ( optional )

			SendMessage(callbackId, res);
			// end hack

			return 0;
		}
		
		public static int SakashoAchievementClaimAchievementPrizes(int callbackId, string json)
		{
			// Hack directly send response
			EDOHBJAPLPF_JsonData msgData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			ClaimAchievements(msgData, res);

			SendMessage(callbackId, res);
			// end hack

			return 0;
		}

		public static int SakashoAchievementClaimAchievementPrizesSetInventoryClosedAt(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData msgData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			ClaimAchievements(msgData, res, true);

			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt(int callbackId, string json)
		{
			// Hack directly send response
			EDOHBJAPLPF_JsonData msgData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			ClaimAchievements(msgData, res, true);
			bool as_received = (bool)msgData["asReceived"];
			if(as_received)
				UnityEngine.Debug.LogError("asReceived true");
				
			SavePlayerData(msgData, res);
			SendMessage(callbackId, res);
			return SakashoPlayerDataSavePlayerData(callbackId, json);
		}

		private static void ClaimAchievements(EDOHBJAPLPF_JsonData msgData, EDOHBJAPLPF_JsonData res, bool useInventoryCloseAt = false)
		{
			List<long> closeAtList = null;
			if(useInventoryCloseAt && msgData.BBAJPINMOEP_Contains("inventoryClosedAt"))
			{
				closeAtList = new List<long>();
				for(int i = 0; i < msgData["inventoryClosedAt"].HNBFOAJIIAL_Count; i++)
				{
					closeAtList.Add((long)msgData["inventoryClosedAt"][i]);
				}
			}
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

				long closeAt = closeAtList != null && closeAtList.Count > i && closeAtList[i] > 0 ? closeAtList[i] : 32535097200;

				if(key.StartsWith("normal_quest_key_"))
				{
					int id = int.Parse(key.Replace("normal_quest_key_", ""));
					LCKMNLOLDPD reward = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.LFAAEPAAEMB.Find((LCKMNLOLDPD _) =>
					{
						return _.BGFPPGPJONG_QuestKeyId == id && _.APNMKLJMPMD_Type == 1;
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
						closed_at = closeAt
					});
					//UnityEngine.Debug.LogError(addedItem.item_name+" "+addedItem.item_value);
					addedItem.AddInInventoryResult(d);
                }
				else if(key.StartsWith("daily_quest_"))
				{
					int id = int.Parse(key.Replace("daily_quest_", ""));
					LCKMNLOLDPD reward = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.LFAAEPAAEMB.Find((LCKMNLOLDPD _) =>
					{
						return _.BGFPPGPJONG_QuestKeyId == id && _.APNMKLJMPMD_Type == 2;
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
						closed_at = closeAt
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
						closed_at = closeAt
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
						closed_at = closeAt
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
							closed_at = closeAt
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
						closed_at = closeAt
					});
					addedItem.AddInInventoryResult(d);
				}
				else if(key.StartsWith("rating_reward_receive_key_"))
				{
					string id = key.Replace("rating_reward_receive_key_", "");
					HGPEFPFODHO_HighScoreRanking.LGNDICJEDNE dbrating = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO.Find((HGPEFPFODHO_HighScoreRanking.LGNDICJEDNE _) =>
					{
						return _.ICGAKKCCFOG == id;
					});
					if(dbrating != null)
					{
						UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
						{
							item_count = dbrating.GCKPDEDJFIC_ItemCount,
							item_name = JpStringLiterals.StringLiteral_10137,
							item_type = 1,
							item_value = 1001,
							message = "Rating reward",
							closed_at = closeAt
						});
						addedItem.AddInInventoryResult(d);
					}
					else
					{
						dbrating = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO.Find((HGPEFPFODHO_HighScoreRanking.LGNDICJEDNE _) =>
						{
							return _.BGFPPGPJONG.ToString() == id;
						});
						if(dbrating != null)
						{
							for(int j = 0; j < dbrating.AJMDFJFCIML_GetCount(); j++)
							{
								UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
								{
									item_count = dbrating.NKOHMLHLJGL_GetItemCount(j),
									item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(dbrating.FKNBLDPIPMC_GetItemId(j)),
									item_type = 0,
									item_value = dbrating.FKNBLDPIPMC_GetItemId(j),
									message = "Rating reward",
									closed_at = closeAt
								});
								addedItem.AddInInventoryResult(d);
							}
						}
						else
						{
							UnityEngine.Debug.LogError("Reward not found : "+key);
						}
					}
				}
				else if(key.StartsWith("event_achv_"))
				{
					IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
					if(ev != null)
					{
						ICFLJACCIKF_EventBattle dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as ICFLJACCIKF_EventBattle;
						LNELCMNJPIC_EventGoDiva dbSectionGoDiva = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
						if(dbSection != null)
						{
							if(key.StartsWith(dbSection.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix))
							{
								bool found = false;
								for(int k = 0; k < dbSection.FCIPEDFHFEM_Rewards.Count; k++)
								{
									for(int j = 0; j < dbSection.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items.Count; j++)
									{
										if(dbSection.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId > 0)
										{
											if(key == string.Concat(dbSection.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix, dbSection.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId.ToString()))
											{
												MFDJIFIIPJD data = new MFDJIFIIPJD();
												data.KHEKNNFCAOI(dbSection.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items[j].GLCLFMGPMAN_ItemId, dbSection.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items[j].HMFFHLPNMPH_Cnt);
												UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
												{
													item_count = dbSection.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items[j].HMFFHLPNMPH_Cnt,
													item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.JJBGOIMEIPF_ItemId),
													item_type = data.MJBKGOJBPAD_Type,
													item_value = data.JJBGOIMEIPF_ItemId == 10001 ? 1001 : data.JJBGOIMEIPF_ItemId,
													message = "Event reward "+ev.DGCOMDILAKM_EventName,
													closed_at = closeAt
												});
												addedItem.AddInInventoryResult(d);
												found = true;
												break;
											}
										}
									}
								}
								if(!found)
								{
									for(int j = 0; j < dbSection.NNMPGOAGEOL_Missions.Count; j++)
									{
										string itKey = "";
                                        AKIIJBEJOEP mission = dbSection.NNMPGOAGEOL_Missions[j];
										if(mission.IKJAAKEINHC_Slt < 1)
										{
											if(mission.HPAOAKMKCMA_Slt2 > 0)
											{
												itKey += dbSection.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix;
												itKey += mission.HPAOAKMKCMA_Slt2.ToString("D4");
											}
										}
										else
										{
											itKey += dbSection.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix;
											itKey += mission.IKJAAKEINHC_Slt.ToString();
										}
                                        if (key == itKey)
										{
											MFDJIFIIPJD data = new MFDJIFIIPJD();
											data.KHEKNNFCAOI(mission.KIJAPOFAGPN_ItemId, mission.JDLJPNMLFID_ItemCount);
											UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
											{
												item_count = mission.JDLJPNMLFID_ItemCount,
												item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.JJBGOIMEIPF_ItemId),
												item_type = data.MJBKGOJBPAD_Type,
												item_value = data.JJBGOIMEIPF_ItemId == 10001 ? 1001 : data.JJBGOIMEIPF_ItemId,
												message = JpStringLiterals.StringLiteral_9777,
												closed_at = closeAt
											});
											addedItem.AddInInventoryResult(d);
											found = true;
											break;
										}
									}
								}
								if(!found)
								{
									UnityEngine.Debug.LogError("Missing reward for "+(string)msgData["keys"][i]+", reward item id not found");
								}
							}
							else
							{
								UnityEngine.Debug.LogError("Missing reward for "+(string)msgData["keys"][i]+", key does no match event prefix "+dbSection.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix);
							}
						}
						else if(dbSectionGoDiva != null)
						{
							if(key.StartsWith(dbSectionGoDiva.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix))
							{
								bool found = false;
								for(int k = 0; k < dbSectionGoDiva.FCIPEDFHFEM_Rewards.Count; k++)
								{
									for(int j = 0; j < dbSectionGoDiva.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items.Count; j++)
									{
										if(dbSectionGoDiva.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId > 0)
										{
											if(key == string.Concat(dbSectionGoDiva.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix, dbSectionGoDiva.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId.ToString()))
											{
												MFDJIFIIPJD data = new MFDJIFIIPJD();
												data.KHEKNNFCAOI(dbSectionGoDiva.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items[j].GLCLFMGPMAN_ItemId, dbSectionGoDiva.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items[j].HMFFHLPNMPH_ItemCnt);
												UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
												{
													item_count = dbSectionGoDiva.FCIPEDFHFEM_Rewards[k].AHJNPEAMCCH_Items[j].HMFFHLPNMPH_ItemCnt,
													item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.JJBGOIMEIPF_ItemId),
													item_type = data.MJBKGOJBPAD_Type,
													item_value = data.JJBGOIMEIPF_ItemId == 10001 ? 1001 : data.JJBGOIMEIPF_ItemId,
													message = "Event reward "+ev.DGCOMDILAKM_EventName,
													closed_at = closeAt
												});
												addedItem.AddInInventoryResult(d);
												found = true;
												break;
											}
										}
									}
								}
								if(!found)
								{
									for(int j = 0; j < dbSectionGoDiva.NNMPGOAGEOL_Missions.Count; j++)
									{
										string itKey = "";
                                        AKIIJBEJOEP mission = dbSectionGoDiva.NNMPGOAGEOL_Missions[j];
										if(mission.IKJAAKEINHC_Slt < 1)
										{
											if(mission.HPAOAKMKCMA_Slt2 > 0)
											{
												itKey += dbSectionGoDiva.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix;
												itKey += mission.HPAOAKMKCMA_Slt2.ToString("D4");
											}
										}
										else
										{
											itKey += dbSectionGoDiva.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix;
											itKey += mission.IKJAAKEINHC_Slt.ToString();
										}
                                        if (key == itKey)
										{
											MFDJIFIIPJD data = new MFDJIFIIPJD();
											data.KHEKNNFCAOI(mission.KIJAPOFAGPN_ItemId, mission.JDLJPNMLFID_ItemCount);
											UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
											{
												item_count = mission.JDLJPNMLFID_ItemCount,
												item_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(data.JJBGOIMEIPF_ItemId),
												item_type = data.MJBKGOJBPAD_Type,
												item_value = data.JJBGOIMEIPF_ItemId == 10001 ? 1001 : data.JJBGOIMEIPF_ItemId,
												message = JpStringLiterals.StringLiteral_9777,
												closed_at = closeAt
											});
											addedItem.AddInInventoryResult(d);
											found = true;
											break;
										}
									}
								}
								if(!found)
								{
									UnityEngine.Debug.LogError("Missing reward for "+(string)msgData["keys"][i]+", reward item id not found");
								}
							}
							else
							{
								UnityEngine.Debug.LogError("Missing reward for "+(string)msgData["keys"][i]+", key does no match event prefix "+dbSection.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix);
							}
						}
						else
						{
							UnityEngine.Debug.LogError("Missing reward for "+(string)msgData["keys"][i]+", could not find db section "+ev.JOPOPMLFINI_QuestId);
						}
					}
					else
					{
						UnityEngine.Debug.LogError("Missing reward for "+(string)msgData["keys"][i]+", could not find open event");
					}
				}
				else
				{
					UnityEngine.Debug.LogError("Missing reward for "+(string)msgData["keys"][i]);
				}
			}
		}

		public static int SakashoAchievementClaimAchievementPrizesAndSave(int callbackId, string json)
		{
			// Hack directly send response
			EDOHBJAPLPF_JsonData msgData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			ClaimAchievements(msgData, res);
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
