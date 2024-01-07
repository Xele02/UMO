using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		static EDOHBJAPLPF_JsonData loginInfo = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
			{
				""closed_at"": 32514071100,
				""description"": ""\u8863\u88c5\u89e3\u653e\u5fdc\u63f4\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u2462"",
				""id"": 38788,
				""name"": ""\u8863\u88c5\u89e3\u653e\u5fdc\u63f4\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u2462"",
				""name_for_apis"": ""campaign_0001_bg_254"",
				""opened_at"": 1653577200,
				""reset_at"": 1653577200
			},
			{
				""closed_at"": 32514071100,
				""description"": ""\u30ab\u30e0\u30d0\u30c3\u30af\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9 28\u65e5\u9593\u975e\u30ed\u30b0\u30a4\u30f3\r\n"",
				""id"": 10665,
				""name"": ""\u30ab\u30e0\u30d0\u30c3\u30af\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9 28\u65e5\u9593\u975e\u30ed\u30b0\u30a4\u30f3"",
				""name_for_apis"": ""comback1_001"",
				""opened_at"": 1518620400,
				""reset_at"": 1518620400
			},
			{
				""closed_at"": 32510606040,
				""description"": ""\u30ab\u30e0\u30d0\u30c3\u30af\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9 28\u65e5\u9593\u975e\u30ed\u30b0\u30a4\u30f3\u3000\u6b4c\u6676\u77f3"",
				""id"": 10666,
				""name"": ""\u30ab\u30e0\u30d0\u30c3\u30af\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9 28\u65e5\u9593\u975e\u30ed\u30b0\u30a4\u30f3\u3000\u6b4c\u6676\u77f3"",
				""name_for_apis"": ""comback2_001"",
				""opened_at"": 1518620400,
				""reset_at"": 1518620400
			},
			{
				""closed_at"": 32528605560,
				""description"": ""\u6bce\u65e51\u56de\u30ed\u30b0\u30a4\u30f3\u6642\u306b\u4e00\u5ea6\u30d7\u30ec\u30bc\u30f3\u30c8\u3092\u53d7\u3051\u53d6\u308c\u308b\u3088\uff01"",
				""id"": 7740,
				""name"": ""\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9"",
				""name_for_apis"": ""regular_0002"",
				""opened_at"": 1509462000,
				""reset_at"": 1509462000
			},
			{
				""closed_at"": 32529465420,
				""description"": ""\u30b2\u30fc\u30e0\u958b\u59cb\u304b\u30897\u65e5\u76ee\u307e\u3067\u3082\u3089\u3048\u308b\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u3067\u3059\u3002"",
				""id"": 6541,
				""name"": ""\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9"",
				""name_for_apis"": ""start_0001_bg_001"",
				""opened_at"": 1479999600,
				""reset_at"": 1479999600
			}
		]");

		public static int SakashoLoginBonusGetLoginBonuses(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["current_page"] = 1;
			res["next_page"] = 0;
			res["previous_page"] = 0;
			res["login_bonuses"] = new EDOHBJAPLPF_JsonData();
			res["login_bonuses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res["login_bonuses"] = loginInfo;
			SendMessage(callbackId, res);
			return 0;
		}


		public static int SakashoLoginBonusGetLoginBonusStatuses(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["login_bonuses"] = new EDOHBJAPLPF_JsonData();
			res["login_bonuses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			if(req["ids"] != null)
			{
				for(int i = 0; i < req["ids"].HNBFOAJIIAL_Count; i++)
				{
					int id = (int)req["ids"][i];
					for(int j = 0; j < loginInfo.HNBFOAJIIAL_Count; j++)
					{
						if((int)loginInfo[j]["id"] == id)
						{
							EDOHBJAPLPF_JsonData rData = new EDOHBJAPLPF_JsonData();
							rData["can_receive_next"] = ((string)(loginInfo[j]["name_for_apis"])).Contains("comback") ? false : true;
							rData["count"] = 0;
							rData["id"] = id;
							rData["last_received_at"] = null;
							rData["name_for_apis"] = loginInfo[j]["name_for_apis"];
							res["login_bonuses"].Add(rData);
							break;
						}
					}
				}
			}

			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoLoginBonusGetLoginBonusRecord(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			int id = (int)req["id"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["current_page"] = 1;
			res["next_page"] = 2;
			res["previous_page"] = 0;
			if(id == 6541)
			{
				res["closed_at"] = 32514071100;
				res["description"] = "\u30b2\u30fc\u30e0\u958b\u59cb\u304b\u30897\u65e5\u76ee\u307e\u3067\u3082\u3089\u3048\u308b\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u3067\u3059\u3002";
				res["login_bonus_prizes"] = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
					{
						""inventory_message"": ""\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 250,
								""item_name"": ""\u6b4c\u6676\u77f3"",
								""item_type"": 1,
								""item_value"": 1001
							}
						],
						""required_count"": 1
					},
					{
						""inventory_message"": ""\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 150,
								""item_name"": ""\u6b4c\u6676\u77f3"",
								""item_type"": 1,
								""item_value"": 1001
							}
						],
						""required_count"": 2
					},
					{
						""inventory_message"": ""\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 100,
								""item_name"": ""\u6b4c\u6676\u77f3"",
								""item_type"": 1,
								""item_value"": 1001
							}
						],
						""required_count"": 3
					},
					{
						""inventory_message"": ""\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 100,
								""item_name"": ""\u6b4c\u6676\u77f3"",
								""item_type"": 1,
								""item_value"": 1001
							}
						],
						""required_count"": 4
					},
					{
						""inventory_message"": ""\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 100,
								""item_name"": ""\u6b4c\u6676\u77f3"",
								""item_type"": 1,
								""item_value"": 1001
							}
						],
						""required_count"": 5
					},
					{
						""inventory_message"": ""\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 150,
								""item_name"": ""\u6b4c\u6676\u77f3"",
								""item_type"": 1,
								""item_value"": 1001
							}
						],
						""required_count"": 6
					},
					{
						""inventory_message"": ""\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""scene"",
								""item_type"": 0,
								""item_value"": 1
							}
						],
						""required_count"": 7
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 8
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 9
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 10
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 11
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 12
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 13
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 14
					}
				]");
				res["max_count"] = 7;
				res["max_period"] = null;
				res["name"] = "\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9";
				res["name_for_apis"] = "start_0001_bg_001";
				res["opened_at"] = 1479999600;
				res["repeat_with_count"] = false;
				res["repeat_with_period"] = false;
				res["reset_at"] = 1479999600;
				res["id"] = 6541;
			}
			else if(id == 7740)
			{
				res["closed_at"] = 32514071100;
				res["description"] = "\u6bce\u65e51\u56de\u30ed\u30b0\u30a4\u30f3\u6642\u306b\u4e00\u5ea6\u30d7\u30ec\u30bc\u30f3\u30c8\u3092\u53d7\u3051\u53d6\u308c\u308b\u3088\uff01";
				res["login_bonus_prizes"] = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
					{
						""inventory_message"": ""\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002\t"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 20,
								""item_name"": ""grow_item"",
								""item_type"": 0,
								""item_value"": 2
							}
						],
						""required_count"": 1
					},
					{
						""inventory_message"": ""\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002\t"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 3000,
								""item_name"": ""uc_item"",
								""item_type"": 0,
								""item_value"": 1
							}
						],
						""required_count"": 2
					},
					{
						""inventory_message"": ""\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 10,
								""item_name"": ""\u6b4c\u6676\u77f3"",
								""item_type"": 1,
								""item_value"": 1001
							}
						],
						""required_count"": 3
					},
					{
						""inventory_message"": ""\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 20,
								""item_name"": ""compo"",
								""item_type"": 0,
								""item_value"": 2
							}
						],
						""required_count"": 4
					},
					{
						""inventory_message"": ""\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""energy_item"",
								""item_type"": 0,
								""item_value"": 1
							}
						],
						""required_count"": 5
					},
					{
						""inventory_message"": ""\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 10,
								""item_name"": ""compo"",
								""item_type"": 0,
								""item_value"": 3
							}
						],
						""required_count"": 6
					},
					{
						""inventory_message"": ""\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 10,
								""item_name"": ""\u6b4c\u6676\u77f3"",
								""item_type"": 1,
								""item_value"": 1001
							}
						],
						""required_count"": 7
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 8
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 9
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 10
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 11
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 12
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 13
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 14
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 15
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 16
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 17
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 18
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 19
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 20
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 21
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 22
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 23
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 24
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 25
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 26
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 27
					},
					{
						""inventory_message"": null,
						""items"": [],
						""required_count"": 28
					}
				]");
				res["max_count"] = 7;
				res["max_period"] = null;
				res["name"] = "\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9";
				res["name_for_apis"] = "regular_0002";
				res["opened_at"] = 1509462000;
				res["repeat_with_count"] = true;
				res["repeat_with_period"] = false;
				res["reset_at"] = 1509462000;
				res["id"] = 7740;
			}
			else if(id == 38788)
			{
				res["closed_at"] = 32514071100;
				res["description"] = "\u8863\u88c5\u89e3\u653e\u5fdc\u63f4\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u2462";
				res["login_bonus_prizes"] = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 1
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 2
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 3
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 2,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 4
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 5
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 6
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 3,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 7
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 8
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 9
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 3,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 10
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 11
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 1,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 12
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 3,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 13
					},
					{
						""inventory_message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
						""is_lot"": false,
						""items"": [
							{
								""item_count"": 5,
								""item_name"": ""sp_item"",
								""item_type"": 0,
								""item_value"": 16
							}
						],
						""required_count"": 14
					}
				]");
				res["max_count"] = 14;
				res["max_period"] = null;
				res["name"] = "\u8863\u88c5\u89e3\u653e\u5fdc\u63f4\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u2462";
				res["name_for_apis"] = "campaign_0001_bg_254";
				res["opened_at"] = 1653577200;
				res["repeat_with_count"] = false;
				res["repeat_with_period"] = false;
				res["reset_at"] = 1653577200;
				res["id"] = 38788;
			}
			else
			{
				TodoLogger.LogError(0, "Request "+json);
			}

			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoLoginBonusIncrementLoginCount(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			EDOHBJAPLPF_JsonData res = GetBaseMessage();

			res["last_played_at"] = 1654416444;
			res["login_bonuses"] = new EDOHBJAPLPF_JsonData();
			res["login_bonuses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoLoginBonusIncrementLoginCountIntArray(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData ids = req["ids"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			
			res["last_played_at"] = 1654416444;
			res["login_bonuses"] = new EDOHBJAPLPF_JsonData();
			res["login_bonuses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < ids.HNBFOAJIIAL_Count; i++)
			{
				int id = (int)ids[i];
				if(id == 6541)
				{
					res["count"] = 1;
					res["id"] = 6541;
					res["inventories"] = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
						{
							""created_at"": 1654416444,
							""id"": 9072875273,
							""item_count"": 250,
							""item_name"": ""\u6b4c\u6676\u77f3"",
							""item_type"": 1,
							""item_value"": 1001,
							""message"": ""\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
							""type"": 105
						}
					]");
					res["inventory_ids"] = new EDOHBJAPLPF_JsonData();
					res["inventory_ids"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					res["inventory_ids"].Add(9072875273);
					res["name"] = "\u30b9\u30bf\u30fc\u30c8\u30c0\u30c3\u30b7\u30e5\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9";
					res["name_for_apis"] = "start_0001_bg_001";
				}
				else if(id == 7740)
				{
					res["count"] = 1;
					res["id"] = 7740;
					res["inventories"] = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
						{
							""created_at"": 1654416444,
							""id"": 9072875274,
							""item_count"": 20,
							""item_name"": ""grow_item"",
							""item_type"": 0,
							""item_value"": 2,
							""message"": ""\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002\t"",
							""type"": 105
						}
					]");
					res["inventory_ids"] = new EDOHBJAPLPF_JsonData();
					res["inventory_ids"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					res["inventory_ids"].Add(9072875274);
					res["name"] = "\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9";
					res["name_for_apis"] = "regular_0002";
				}
				else if(id == 38788)
				{
					res["count"] = 1;
					res["id"] = 38788;
					res["inventories"] = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
						{
							""created_at"": 1654416444,
							""id"": 9072875276,
							""item_count"": 1,
							""item_name"": ""sp_item"",
							""item_type"": 0,
							""item_value"": 16,
							""message"": ""\u7279\u5225\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u306e\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002"",
							""type"": 105
						}
					]");
					res["inventory_ids"] = new EDOHBJAPLPF_JsonData();
					res["inventory_ids"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					res["inventory_ids"].Add(9072875276);
					res["name"] = "\u8863\u88c5\u89e3\u653e\u5fdc\u63f4\u30ed\u30b0\u30a4\u30f3\u30dc\u30fc\u30ca\u30b9\u2462";
					res["name_for_apis"] = "campaign_0001_bg_254";
				}
				else
				{
					TodoLogger.LogError(0, "Request "+json);
				}
			}

			SendMessage(callbackId, res);
			return 0;
		}
		
		
	}
	
}
