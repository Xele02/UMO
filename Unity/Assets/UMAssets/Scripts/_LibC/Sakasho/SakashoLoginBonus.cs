using System;
using System.Collections.Generic;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		class LoginBonusData
		{
			public class Prize
			{
				public class Items
				{
					public int count;
					public string name;
					public int type;
					public int value;
				}

				public string inventory_message;
				public bool is_lot;
				public List<Items> items;
				public int required_count;
			}

			public int id;
			public string name;
			public string description;
			public string name_for_apis;
			public long opened_at;
			public long closed_at;
			public long reset_at;
			public List<Prize> prizes;
			public int max_count;
			public long? max_period;
			public bool repeat_with_count;
			public bool repeat_with_period;

			public EDOHBJAPLPF_JsonData GetLoginBonus()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["id"] = id;
				res["name"] = name;
				res["description"] = description;
				res["name_for_apis"] = name_for_apis;
				res["opened_at"] = opened_at;
				res["closed_at"] = closed_at;
				res["reset_at"] = reset_at;
				return res;
			}
		}

		class UserLoginInfo
		{
			public int id;
			public int count;
			public long last_updated;

			public UserLoginInfo(int id)
			{
				this.id = id;
				count = 0;
				last_updated = 0;
			}

			public void Load(EDOHBJAPLPF_JsonData data)
			{
				id = (int)data["id"];
				count = (int)data["count"];
				last_updated = JsonUtil.GetLong(data, "last_updated", 0);
			}

			public EDOHBJAPLPF_JsonData Save()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["id"] = id;
				res["count"] = count;
				res["last_updated"] = last_updated;
				return res;
			}
		}
		class UserLoginData
		{
			public Dictionary<int, UserLoginInfo> infos = new Dictionary<int, UserLoginInfo>();

			public void Load(EDOHBJAPLPF_JsonData data)
			{
				if(!data.BBAJPINMOEP_Contains("user_data"))
					return;
				if(!data["user_data"].BBAJPINMOEP_Contains("login_data"))
					return;
				EDOHBJAPLPF_JsonData json = data["user_data"]["login_data"];
				if(json.BBAJPINMOEP_Contains("info"))
				{
					EDOHBJAPLPF_JsonData info = json["info"];
					for(int i = 0; i < info.HNBFOAJIIAL_Count; i++)
					{
						UserLoginInfo d = new UserLoginInfo(0);
						d.Load(info[i]);
						infos.Add(d.id, d);
					}
				}
			}

			public void Save(EDOHBJAPLPF_JsonData data)
			{
				if(!data.BBAJPINMOEP_Contains("user_data"))
					data["user_data"] = new EDOHBJAPLPF_JsonData();
				
				data["user_data"]["login_data"] = new EDOHBJAPLPF_JsonData();
				data["user_data"]["login_data"]["info"] = new EDOHBJAPLPF_JsonData();
				data["user_data"]["login_data"]["info"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				foreach(var k in infos)
				{
					data["user_data"]["login_data"]["info"].Add(k.Value.Save());
				}
			}

			public UserLoginInfo GetOrCreate(int id)
			{
				if(!infos.ContainsKey(id))
				{
					infos.Add(id, new UserLoginInfo(id));
				}
				return infos[id];
			}
		}

		static List<LoginBonusData> LoginList = new List<LoginBonusData>()
		{
			new LoginBonusData()
			{
				id = 38788,
				name = JpStringLiterals.UMO_login_38788_name,
				description = JpStringLiterals.UMO_login_38788_desc,
				name_for_apis = "campaign_0001_bg_254",
				opened_at = 1653577200, //26/05/2022 17:00:00
				closed_at = 32514071100, //01/05/3000 07:25:00
				reset_at = 1653577200, //26/05/2022 17:00:00
				max_count = 14,
				max_period = null,
				repeat_with_count = false,
				repeat_with_period = false,
				prizes = new List<LoginBonusData.Prize>()
				{
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 1
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 2
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 3
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 2,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 4
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 5
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 6
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 3,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 7
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 8
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 9
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 3,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 10
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 11
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 12
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 3,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 13
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_38788_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 5,
								name = "sp_item",
								type = 0,
								value = 16
							}
						},
						required_count = 14
					}
				}
			},
			new LoginBonusData()
			{
				id = 10665,
				name = JpStringLiterals.UMO_login_10665_name,
				description = JpStringLiterals.UMO_login_10665_desc,
				name_for_apis = "comback1_001",
				opened_at = 1518620400, //14/02/2018 16:00:00
				closed_at = 32514071100, //01/05/3000 07:25:00
				reset_at = 1518620400 //14/02/2018 16:00:00
			},
			new LoginBonusData()
			{
				id = 10666,
				name = JpStringLiterals.UMO_login_10666_name,
				description = JpStringLiterals.UMO_login_10666_desc,
				name_for_apis = "comback2_001",
				opened_at = 1518620400, //14/02/2018 16:00:00
				closed_at = 32510606040, //22/03/3000 04:54:00
				reset_at = 1518620400 //14/02/2018 16:00:00
			},
			new LoginBonusData()
			{
				id = 7740,
				name = JpStringLiterals.UMO_login_7740_name,
				description = JpStringLiterals.UMO_login_7740_desc,
				name_for_apis = "regular_0002",
				opened_at = 1509462000, //31/10/2017 16:00:00
				closed_at = 32528605560, //16/10/3000 12:46:00
				reset_at = 1509462000, //31/10/2017 16:00:00
				max_count = 7,
				max_period = null,
				repeat_with_count = true,
				repeat_with_period = false,
				prizes = new List<LoginBonusData.Prize>()
				{
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_7740_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 20,
								name = "grow_item",
								type = 0,
								value = 2
							}
						},
						required_count = 1
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_7740_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 3000,
								name = "uc_item",
								type = 0,
								value = 1
							}
						},
						required_count = 2
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_7740_prize2_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 10,
								name = JpStringLiterals.StringLiteral_10137,
								type = 1,
								value = 1001
							}
						},
						required_count = 3
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_7740_prize2_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 20,
								name = "compo",
								type = 0,
								value = 2
							}
						},
						required_count = 4
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_7740_prize2_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "energy_item",
								type = 0,
								value = 1
							}
						},
						required_count = 5
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_7740_prize2_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 10,
								name = "compo",
								type = 0,
								value = 3
							}
						},
						required_count = 6
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_7740_prize2_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 10,
								name = JpStringLiterals.StringLiteral_10137,
								type = 1,
								value = 1001
							}
						},
						required_count = 7
					},
					new LoginBonusData.Prize() { required_count = 8 },
					new LoginBonusData.Prize() { required_count = 9 },
					new LoginBonusData.Prize() { required_count = 10 },
					new LoginBonusData.Prize() { required_count = 11 },
					new LoginBonusData.Prize() { required_count = 12 },
					new LoginBonusData.Prize() { required_count = 13 },
					new LoginBonusData.Prize() { required_count = 14 },
					new LoginBonusData.Prize() { required_count = 15 },
					new LoginBonusData.Prize() { required_count = 16 },
					new LoginBonusData.Prize() { required_count = 17 },
					new LoginBonusData.Prize() { required_count = 18 },
					new LoginBonusData.Prize() { required_count = 19 },
					new LoginBonusData.Prize() { required_count = 20 },
					new LoginBonusData.Prize() { required_count = 21 },
					new LoginBonusData.Prize() { required_count = 22 },
					new LoginBonusData.Prize() { required_count = 23 },
					new LoginBonusData.Prize() { required_count = 24 },
					new LoginBonusData.Prize() { required_count = 25 },
					new LoginBonusData.Prize() { required_count = 26 },
					new LoginBonusData.Prize() { required_count = 27 },
					new LoginBonusData.Prize() { required_count = 28 }
				}
			},
			new LoginBonusData()
			{
				id = 6541,
				name = JpStringLiterals.UMO_login_6541_name,
				description = JpStringLiterals.UMO_login_6541_desc,
				name_for_apis = "start_0001_bg_001",
				opened_at = 1479999600, //24/11/2016 16:00:00
				closed_at = 32529465420, //26/10/3000 11:37:00
				reset_at = 1479999600, //24/11/2016 16:00:00
				max_count = 7,
				max_period = null,
				repeat_with_count = false,
				repeat_with_period = false,
				prizes = new List<LoginBonusData.Prize>()
				{
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_6541_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 250,
								name = JpStringLiterals.StringLiteral_10137,
								type = 1,
								value = 1001
							}
						},
						required_count = 1
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_6541_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 150,
								name = JpStringLiterals.StringLiteral_10137,
								type = 1,
								value = 1001
							}
						},
						required_count = 2
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_6541_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 100,
								name = JpStringLiterals.StringLiteral_10137,
								type = 1,
								value = 1001
							}
						},
						required_count = 3
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_6541_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 100,
								name = JpStringLiterals.StringLiteral_10137,
								type = 1,
								value = 1001
							}
						},
						required_count = 4
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_6541_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 100,
								name = JpStringLiterals.StringLiteral_10137,
								type = 1,
								value = 1001
							}
						},
						required_count = 5
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_6541_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 150,
								name = JpStringLiterals.StringLiteral_10137,
								type = 1,
								value = 1001
							}
						},
						required_count = 6
					},
					new LoginBonusData.Prize()
					{
						inventory_message = JpStringLiterals.UMO_login_6541_prize1_msg,
						is_lot = false,
						items = new List<LoginBonusData.Prize.Items>()
						{
							new LoginBonusData.Prize.Items()
							{
								count = 1,
								name = "scene",
								type = 0,
								value = 1
							}
						},
						required_count = 7
					},
					new LoginBonusData.Prize() { required_count = 8 },
					new LoginBonusData.Prize() { required_count = 9 },
					new LoginBonusData.Prize() { required_count = 10 },
					new LoginBonusData.Prize() { required_count = 11 },
					new LoginBonusData.Prize() { required_count = 12 },
					new LoginBonusData.Prize() { required_count = 13 },
					new LoginBonusData.Prize() { required_count = 14 }
				}
			}
		};

		/*static EDOHBJAPLPF_JsonData loginInfo = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
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
		]");*/

		public static int SakashoLoginBonusGetLoginBonuses(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["current_page"] = 1;
			res["next_page"] = 0;
			res["previous_page"] = 0;
			//res["login_bonuses"] = new EDOHBJAPLPF_JsonData();
			//res["login_bonuses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			//res["login_bonuses"] = loginInfo;
			res["login_bonuses"] = new EDOHBJAPLPF_JsonData();
			res["login_bonuses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < LoginList.Count; i++)
			{
				res["login_bonuses"].Add(LoginList[i].GetLoginBonus());
			}
			SendMessage(callbackId, res);
			return 0;
		}


		public static int SakashoLoginBonusGetLoginBonusStatuses(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["login_bonuses"] = new EDOHBJAPLPF_JsonData();
			res["login_bonuses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			UserLoginData userLoginData = new UserLoginData();
			userLoginData.Load(playerAccount.playerData.serverData);

			if(req["ids"] != null)
			{
				for(int i = 0; i < req["ids"].HNBFOAJIIAL_Count; i++)
				{
					int id = (int)req["ids"][i];
					for(int j = 0; j < LoginList.Count; j++)
					{
						if((int)LoginList[j].id == id)
						{
							UserLoginInfo info = userLoginData.GetOrCreate(id);
							EDOHBJAPLPF_JsonData rData = new EDOHBJAPLPF_JsonData();
							rData["can_receive_next"] = ((string)(LoginList[j].name_for_apis)).Contains("comback") ? false : info.count < LoginList[j].max_count;
							if(info.last_updated != 0)
							{
								DateTime d1 = Utility.GetLocalDateTime(info.last_updated);
								DateTime d2 = Utility.GetLocalDateTime(Utility.GetCurrentUnixTime());
								if(d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day)
									rData["can_receive_next"] = false;
							}
							rData["count"] = info.count;
							rData["id"] = id;
							rData["last_received_at"] = info.last_updated;
							rData["name_for_apis"] = LoginList[j].name_for_apis;
							res["login_bonuses"].Add(rData);
							break;
						}
					}
				}
			}

			userLoginData.Save(playerAccount.playerData.serverData);

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
			LoginBonusData data = LoginList.Find((LoginBonusData _) =>
			{
				return _.id == id;
			});
			if(data != null)
			{
				res["closed_at"] = data.closed_at;
				res["description"] = data.description;
				res["login_bonus_prizes"] = new EDOHBJAPLPF_JsonData();
				res["login_bonus_prizes"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				if(data.prizes != null)
				{
					for(int i = 0; i < data.prizes.Count; i++)
					{
						EDOHBJAPLPF_JsonData p = new EDOHBJAPLPF_JsonData();
						if(data.prizes[i].inventory_message != null)
						{
							p["inventory_message"] = data.prizes[i].inventory_message;
							p["is_lot"] = data.prizes[i].is_lot;
						}
						else
						{
							p["inventory_message"] = null;
						}
						p["items"] = new EDOHBJAPLPF_JsonData();
						p["items"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
						if(data.prizes[i].items != null)
						{
							for(int j = 0; j < data.prizes[i].items.Count; j++)
							{
								EDOHBJAPLPF_JsonData it = new EDOHBJAPLPF_JsonData();
								it["item_count"] = data.prizes[i].items[j].count;
								it["item_name"] = data.prizes[i].items[j].name;
								it["item_type"] = data.prizes[i].items[j].type;
								it["item_value"] = data.prizes[i].items[j].value;
								p["items"].Add(it);
							}
						}
						p["required_count"] = data.prizes[i].required_count;
						res["login_bonus_prizes"].Add(p);
					}
				}
				res["max_count"] = data.max_count;
				res["max_period"] = data.max_period;
				res["name"] = data.name;
				res["name_for_apis"] = data.name_for_apis;
				res["opened_at"] = data.opened_at;
				res["repeat_with_count"] = data.repeat_with_count;
				res["repeat_with_period"] = data.repeat_with_period;
				res["reset_at"] = data.reset_at;
				res["id"] = data.id;
			}
			else
			{
				TodoLogger.LogError(0, "Request "+json);
			}
			/*if(id == 6541)
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
			}*/

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
			TodoLogger.LogError(0, "SakashoLoginBonusIncrementLoginCount");

			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoLoginBonusIncrementLoginCountIntArray(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData ids = req["ids"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();

			UserLoginData userLoginData = new UserLoginData();
			userLoginData.Load(playerAccount.playerData.serverData);
			
			res["last_played_at"] = 1654416444;
			res["login_bonuses"] = new EDOHBJAPLPF_JsonData();
			res["login_bonuses"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < ids.HNBFOAJIIAL_Count; i++)
			{
				int id = (int)ids[i];
				LoginBonusData data = LoginList.Find((LoginBonusData _) =>
				{
					return _.id == id;
				});
				if(data != null)
				{
					UserLoginInfo info = userLoginData.GetOrCreate(id);
					info.count++;
					int num = info.count;
					if(info.count >= data.max_count && data.repeat_with_count)
						info.count = 0;
					info.last_updated = Utility.GetCurrentUnixTime();
					EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
					res["login_bonuses"].Add(d);
					d["count"] = info.count;
					d["id"] = id;
					d["inventories"] = new EDOHBJAPLPF_JsonData();
					d["inventories"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					d["inventory_ids"] = new EDOHBJAPLPF_JsonData();
					d["inventory_ids"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					LoginBonusData.Prize p = data.prizes.Find((LoginBonusData.Prize _) =>
					{
						return _.required_count == num;
					});
					if(p != null && p.items != null)
					{
						List<LoginBonusData.Prize.Items> items = p.items;
						for (int j = 0; j < items.Count; j++)
						{
							UserInventoryItem addedItem = AddInventoryItem(new UserInventoryItem()
							{
								item_count = items[j].count,
								item_name = items[j].name,
								item_type = items[j].type,
								item_value = items[j].value,
								type = 105,
								message = p.inventory_message,
								closed_at = 32535097200
							});
							addedItem.AddInInventoryResult(d);
							
							/*res["inventories"] = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
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
							]");*/
						}
					}
					d["name"] = data.name;
					d["name_for_apis"] = data.name_for_apis;
				}
				else
				{
					TodoLogger.LogError(0, "Request "+json);
				}
				/*if(id == 6541)
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
				}*/
			}
			userLoginData.Save(playerAccount.playerData.serverData);
			SaveAccountServerData();

			SendMessage(callbackId, res);
			return 0;
		}
		
		
	}
	
}
