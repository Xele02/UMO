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

            // Hack directly send response
            string message =
@"{
    ""SAKASHO_CURRENT_ASSET_REVISION"": ""20220622141305"",
    ""SAKASHO_CURRENT_DATE_TIME"": "+Utility.GetCurrentUnixTime()+@",
    ""SAKASHO_CURRENT_MASTER_REVISION"": 5,
    ""created_at"": 1501751856,
    ""data_status"": 1,
    ""updated_at"": 1656166393,
    ""player"": {";
            for(int i = 0; i < names.HNBFOAJIIAL_Count; i++)
            {
                string str = (string)names[i];
                message += @"
        """+str+@""":{";
				if(str == "common")
				{
					message += "\"mv_ticket\":999";
				}
				message += @"}"+(i != names.HNBFOAJIIAL_Count -1 ? "," : "");
            }
            message += @"
    }
}";
            //UnityEngine.Debug.Log(message);
            UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", ""+callbackId+":"+message);
            // end hack

            return 0;
        }

		public static int SakashoPlayerDataSearchForPlayer(int callbackId, string json)
		{
			//https://sakasho.sp.mbga.jp/v2/player_search?page=1&ipp=40&from=1&to=19&exclude_account_ban=1&key=plv&namespaces=base,public_status&order_by_updated_at=2&_reqid=1654421025
			string result = @"
{
    ""SAKASHO_CURRENT_ASSET_REVISION"": ""20220602120304"",
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

			UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", "" + callbackId + ":" + result);

			return 0;
		}

	}
}
