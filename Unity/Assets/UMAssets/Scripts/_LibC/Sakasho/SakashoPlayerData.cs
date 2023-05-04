using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using XeApp.Game.Common;
using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static int SakashoPlayerDataLoadPlayerData(int callbackId, string json)
        {
            UnityEngine.Debug.Log("SakashoPlayerDataLoadPlayerData "+json);
            
            EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
            EDOHBJAPLPF_JsonData names = jsonData["names"];

			/*string account_info = System.Text.Encoding.UTF8.GetString(System.IO.File.ReadAllBytes(UnityEngine.Application.dataPath+"/../../Data/RequestPlayerAccount.json"));
            EDOHBJAPLPF_JsonData jsonRes = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(account_info);

            jsonRes["common"]["mv_ticket"] = 999;
			*/
			EDOHBJAPLPF_JsonData jsonRes = playerAccount.serverData;
			List<string> missingBlock = new List<string>();
			if(jsonRes != null)
			{
				for (int i = 0; i < names.HNBFOAJIIAL_Count; i++)
				{
					string str = (string)names[i];
					if (!jsonRes.BBAJPINMOEP_Contains(str))
					{
						UnityEngine.Debug.LogError("Server data missing block "+str);
						missingBlock.Add(str);
					}
				}
			}

			if(jsonRes == null || missingBlock.Count > 0)
			{
				// Init default profile data
				BBHNACPENDM_ServerSaveData newData = new BBHNACPENDM_ServerSaveData();
				newData.KHEKNNFCAOI_Init(0xFFFFFFFFFFFFFF);
				bool allBlock = jsonRes == null;
				if (jsonRes == null)
				{
					UnityEngine.Debug.LogError("Create new server data");
					jsonRes = new EDOHBJAPLPF_JsonData();
					playerAccount.serverData = jsonRes;
				}
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();

				// Config full unlocked profile
				(newData.LBDOLHGDIEB_GetBlock("base") as JBMPOAAMGNB_Base).PBEKKMOPENN_AgreeTosVer = 1;
				(newData.LBDOLHGDIEB_GetBlock("base") as JBMPOAAMGNB_Base).IJHBIMNKOMC_TutorialEnd = 2;
				{
					EGOLBAPFHHD_Common commonBlock = newData.LBDOLHGDIEB_GetBlock("common") as EGOLBAPFHHD_Common;
					// set max level
					commonBlock.KIECDDFNCAN_Level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.PIAMMJNADJH_PlayerMaxLevel;
					// set max uta grade
					commonBlock.EAHPKPADCPL_TotalUtaRate = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.PGHCCAMKCIO.Last().ADKDHKMPMHP_Rate;
					// set uta reward all get
					commonBlock.EAFLCGCIOND_RetRewRecGra = (int)HighScoreRating.GetUtaGrade(commonBlock.EAHPKPADCPL_TotalUtaRate);
					// set master version for shown new song popup
					commonBlock.MMPPEHPKGLI_AddRegularMusicMVer = DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion;
					// give a lot of stamina
					commonBlock.BCFPEJODJPP_Stamina = 9999;
					// set all 6line & multi diva song shown
					for (int i = 1; i < EGOLBAPFHHD_Common.HKJKONOKBLN_ShowLine6AddLength * 8; i++)
					{
						commonBlock.LIPHECJKIDD(i, true);
					}
				}
				{
					BAHFBCEPFGP_AddMusic addMusicBlock = newData.LBDOLHGDIEB_GetBlock("add_music") as BAHFBCEPFGP_AddMusic;
					for(int i = 1; i < 38 * 8; i++)
					{
						for (int j = 2; j <= 5; j++)
							addMusicBlock.DDCBGCODHHN(i, j);
					}
				}
				{
					NEKDCJKANAH_StoryRecord storyBlock = newData.LBDOLHGDIEB_GetBlock("story_record") as NEKDCJKANAH_StoryRecord;
					LAEGMENIEDB_Story storyDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story;
					for (int i = 0; i < storyDb.CDENCMNHNGA.Count; i++)
					{
						storyBlock.MMKAJBFBKNH[i].EALOBDHOCHP_Stat = 4;
					}
				}
				{
					DEKKMGAFJCG_Diva divaBlock = newData.LBDOLHGDIEB_GetBlock("diva") as DEKKMGAFJCG_Diva;
					for(int i = 0; i < divaBlock.NBIGLBMHEDC_DivaList.Count; i++)
					{
						divaBlock.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_Have = 1;
					}
				}
				{
					DDEMMEPBOIA_Sns snsBlock = newData.LBDOLHGDIEB_GetBlock("sns") as DDEMMEPBOIA_Sns;
					int numSns = 0;
					for (int i = 0; i < 2000; i++)
					{
						BOKMNHAFJHF_Sns.KEIGMAOCJHK dbSns = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OMGFKMANMAB_Sns.CDENCMNHNGA[i];
						if (dbSns.PPEGAKEIEGM_Enabled == 2)
						{
							DDEMMEPBOIA_Sns.EFIFBJGKPJF saveSns = snsBlock.HAJEJPFGILG[i];
							if (saveSns.BEBJKJKBOGH_Date == 0)
							{
								saveSns.BEBJKJKBOGH_Date = time;
							}
							numSns++;
						}
					}
					EGOLBAPFHHD_Common commonBlock = newData.LBDOLHGDIEB_GetBlock("common") as EGOLBAPFHHD_Common;
					commonBlock.JLJJHDGEHLK_RecvSns = numSns;
				}
				{
					MLIBEPGADJH_Scene dbScenes = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene;
					MMPBPOIFDAF_Scene saveScenes = newData.LBDOLHGDIEB_GetBlock("scene") as MMPBPOIFDAF_Scene;
					for (int i = 0; i < dbScenes.CDENCMNHNGA_SceneList.Count; i++)
					{
						MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = dbScenes.CDENCMNHNGA_SceneList[i];
						if (dbScene.PPEGAKEIEGM_En == 2)
						{
							if (i < saveScenes.OPIBAPEGCLA.Count)
							{
								MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = saveScenes.OPIBAPEGCLA[i];
								if (saveScene.BEBJKJKBOGH_Date == 0)
								{
									saveScene.BEBJKJKBOGH_Date = time;
								}
								saveScene.ANAJIAENLNB_Level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LAGGGIEIPEG(dbScene.EKLIPGELKCL_Rarity, true, dbScene.MCCIFLKCNKO_Feed);
								for (int j = 0; j < saveScene.ANAJIAENLNB_Level - 1; j++)
								{
									int idx = j / 8;
									int idx2 = j % 8;
									saveScene.PDNIFBEGMHC_Mb[idx] |= (byte)(1 << idx2);
								}
							}
						}
					}
				}

				// End all normal quest
				ODPNBADOFAN_Quest saveQuests = newData.LBDOLHGDIEB_GetBlock("quest") as ODPNBADOFAN_Quest;
				for (int i = 0; i < saveQuests.GPMKFMFEKLN_NormalQuests.Count; i++)
				{
					saveQuests.GPMKFMFEKLN_NormalQuests[i].EALOBDHOCHP_Stat = 3;
					saveQuests.GPMKFMFEKLN_NormalQuests[i].CADENLBDAEB_New = false;
				}
				//


				for (int i = 0; i < newData.MGJKEJHEBPO_Blocks.Count; i++)
				{
					if(allBlock || missingBlock.Contains(newData.MGJKEJHEBPO_Blocks[i].JIKKNHIAEKG_BlockName))
						newData.MGJKEJHEBPO_Blocks[i].OKJPIBHMKMJ(jsonRes, newData.MGJKEJHEBPO_Blocks[i].FJMOAAPNCJI_SaveId);
				}

				// reload and recreate json to remove forced var init in load
				Dictionary<string, EDOHBJAPLPF_JsonData> blocks;
				blocks = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject<Dictionary<string, EDOHBJAPLPF_JsonData>>(jsonRes.EJCOJCGIBNG_ToJson());
				/*newData.IIEMACPEEBJ_Load(blocks.Keys.ToList(), jsonRes);

				jsonRes = new EDOHBJAPLPF_JsonData();
				playerAccount.serverData = jsonRes;
				for (int i = 0; i < newData.MGJKEJHEBPO_Blocks.Count; i++)
				{
					if (allBlock || missingBlock.Contains(newData.MGJKEJHEBPO_Blocks[i].JIKKNHIAEKG_BlockName))
						newData.MGJKEJHEBPO_Blocks[i].OKJPIBHMKMJ(jsonRes, newData.MGJKEJHEBPO_Blocks[i].FJMOAAPNCJI_SaveId);
				}*/

				SaveAccountServerData();

				// Debug, reload and compare
				BBHNACPENDM_ServerSaveData newData_ = new BBHNACPENDM_ServerSaveData();
				newData_.KHEKNNFCAOI_Init(0xFFFFFFFFFFFFFF);
				newData_.IIEMACPEEBJ_Load(blocks.Keys.ToList(), IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(jsonRes.EJCOJCGIBNG_ToJson())); // Check reload from string json
				bool hasDiff = false;
				foreach (var k in blocks.Keys)
				{
					if(!newData.LBDOLHGDIEB_GetBlock(k).AGBOGBEOFME(newData_.LBDOLHGDIEB_GetBlock(k)))
					{
						UnityEngine.Debug.LogError("Block diff : "+ k);
						hasDiff = true;
					}
					else
					{
						//UnityEngine.Debug.LogError("Block ok : " + k);
					}
				}
				if(hasDiff)
				{
					KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
					writer.GALFODHMEOL_PrettyPrint = true;

					EDOHBJAPLPF_JsonData errorJson = new EDOHBJAPLPF_JsonData();

					for (int i = 0; i < newData_.MGJKEJHEBPO_Blocks.Count; i++)
					{
						newData_.MGJKEJHEBPO_Blocks[i].OKJPIBHMKMJ(errorJson, newData.MGJKEJHEBPO_Blocks[i].FJMOAAPNCJI_SaveId);
					}

					errorJson.EJCOJCGIBNG_ToJson(writer);
					string saveData = writer.ToString();

					string path = Application.persistentDataPath + "/Profiles/" + playerAccount.userId.ToString();
					if (!Directory.Exists(path))
						Directory.CreateDirectory(path);

					path += "/data_save_error.json";
					File.WriteAllText(path, saveData);
					UnityEngine.Debug.LogError("saved error server data " + path);
				}
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["created_at"] = 1501751856;
			res["data_status"] = 1;
			res["updated_at"] = 1656166393;
			res["player"] = new EDOHBJAPLPF_JsonData();
			res["player"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			for (int i = 0; i < names.HNBFOAJIIAL_Count; i++)
			{
				string str = (string)names[i];
				res["player"][str] = jsonRes[str];
			}

			SendMessage(callbackId, res);
			// end hack

			return 0;
        }

		public static int SakashoPlayerDataSearchForPlayer(int callbackId, string json)
		{
			//https://sakasho.sp.mbga.jp/v2/player_search?page=1&ipp=40&from=1&to=19&exclude_account_ban=1&key=plv&namespaces=base,public_status&order_by_updated_at=2&_reqid=1654421025
			string result = @"
{
    ""SAKASHO_CURRENT_ASSET_REVISION"": ""20220622141305"",
	""SAKASHO_CURRENT_DATE_TIME"": " + Utility.GetCurrentUnixTime() + @",
    ""SAKASHO_CURRENT_MASTER_REVISION"": 5,
    ""current_page"": 1,
    ""next_page"": 0,
    ""players"": [
        {
            ""is_friend"": false,
            ""player_data"": {
                ""base"": {
                    ""agree_tos_ver"": 1,
                    ""force_rename"": 0,
                    ""name"": ""AA"",
                    ""prof"": ""BB"",
                    ""rename_date"": 0,
                    ""rev"": 2,
                    ""save_id"": 4853,
                    ""tutorial_end"": 2,
                    ""ver"": 1

				},
                ""public_status"": {
                    ""assist_data"": {
                        ""assist_data_list"": [
                            {
                                ""id"": 3313,
                                ""leaf"": 0,
                                ""luck"": 0,
                                ""lv"": 1,
                                ""mb"": ""//////////////////9/"",
                                ""mlt"": 1,
                                ""sb"": ""AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""

							},
                            {
                                ""id"": 2557,
                                ""leaf"": 0,
                                ""luck"": 0,
                                ""lv"": 1,
                                ""mb"": ""//////////////8BAAAA"",
                                ""mlt"": 2,
                                ""sb"": ""AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
                            },
                            {
                                ""id"": 746,
                                ""leaf"": 0,
                                ""luck"": 0,
                                ""lv"": 1,
                                ""mb"": ""//////////////8BAAAA"",
                                ""mlt"": 1,
                                ""sb"": ""AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
                            },
                            {
                                ""id"": 749,
                                ""leaf"": 0,
                                ""luck"": 2,
                                ""lv"": 1,
                                ""mb"": ""//////////////8BAAAA"",
                                ""mlt"": 3,
                                ""sb"": ""/wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
                            }
                        ],
                        ""assist_name"": ""CC""
                    },
                    ""c_col"": 0,
                    ""c_id"": 0,
                    ""cos_cnt"": 24,
                    ""dc_nm"": ""DD"",
                    ""dc_tm"": 1611282502,
                    ""df_clr"": [
                        20,
                        10,
                        0,
                        0,
                        0
                    ],
                    ""df_clr_l6"": [
                        0,
                        0,
                        0,
                        0,
                        0
                    ],
                    ""df_fcb"": [
                        12,
                        0,
                        0,
                        0,
                        0
                    ],
                    ""df_fcb_l6"": [
                        0,
                        0,
                        0,
                        0,
                        0
                    ],
                    ""diva_id"": 6,
                    ""em_cnt"": 0,
                    ""em_id"": 1,
                    ""hs_rating"": [
                        {
                            ""df"": [
                                0,
                                0,
                                0,
                                1,
                                0,
                                1,
                                0,
                                0,
                                0,
                                0
                            ],
                            ""id"": [
                                5,
                                17,
                                59,
                                18,
                                8,
                                23,
                                19,
                                21,
                                24,
                                26
                            ],
                            ""l6"": [
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0,
                                0
                            ],
                            ""sc"": [
                                56,
                                47,
                                33,
                                27,
                                24,
                                22,
                                19,
                                19,
                                19,
                                19
                            ]
                        }
                    ],
                    ""lv"": 8,
                    ""lv_max_cnt"": 17,
                    ""m_scene"": {
                        ""id"": 3313,
                        ""leaf"": 0,
                        ""luck"": 0,
                        ""lv"": 1,
                        ""mb"": ""//////////////////9/"",
                        ""mlt"": 1,
                        ""sb"": ""AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
                    },
                    ""max_df"": 0,
                    ""max_id"": 5,
                    ""max_l6"": 0,
                    ""max_sc"": 564997,
                    ""mc_power"": 44864,
                    ""pf_tap"": 7051,
                    ""plv"": 11,
                    ""psh"": 0,
                    ""q_cnt"": 277,
                    ""rev"": 2,
                    ""s_scene"": [
                        {
                            ""id"": 193,
                            ""leaf"": 0,
                            ""luck"": 0,
                            ""lv"": 1,
                            ""mb"": ""//////////////8BAAAA"",
                            ""mlt"": 2,
                            ""sb"": ""AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
                        },
                        {
                            ""id"": 134,
                            ""leaf"": 0,
                            ""luck"": 2,
                            ""lv"": 1,
                            ""mb"": ""//////////////8BAAAA"",
                            ""mlt"": 3,
                            ""sb"": ""/wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA=""
                        }
                    ],
                    ""save_id"": 7718,
                    ""scn_cnt"": 1456,
                    ""t_clr"": 60,
                    ""utarate_rank"": 241982,
                    ""vf_cnt"": 7,
                    ""vf_id"": 1
                }
            },
            ""player_id"": 49552951,
            ""updated_at"": 1654421023,
            ""value"": 11
        }
	],
	""previous_page"": 0
}";

			SendMessage(callbackId, result);
			return 0;
		}
		static int saveCnt = 0;
		public static int SakashoPlayerDataSavePlayerData(int callbackId, string json)
		{
			TodoLogger.Log(0, "Save player data");

			KIJECNFNNDB_JsonWriter writer = new KIJECNFNNDB_JsonWriter();
			writer.GALFODHMEOL_PrettyPrint = true;
			EDOHBJAPLPF_JsonData msgData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject((string)msgData["playerData"]).EJCOJCGIBNG_ToJson(writer);
			string saveData = writer.ToString();

			string path = Application.persistentDataPath + "/Profiles/" + playerAccount.userId.ToString();
			if (!Directory.Exists(path))
				Directory.CreateDirectory(path);

			path += "/data_save_"+ saveCnt.ToString() + ".json";
			File.WriteAllText(path, saveData);
			UnityEngine.Debug.LogError("saved server tmp data " + path);
			saveCnt++;

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["created_at"] = 1501751856;
			res["data_status"] = 1;
			res["updated_at"] = 1656166393;
			SendMessage(callbackId, res);
			return 0;
		}

	}
}
