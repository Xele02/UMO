using System;
using System.Collections.Generic;
using System.Linq;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public class CurrencyInfo
		{
			public int id;
			public string name;
			public string desc;
		}

		// Bonus VC : 
		// 1 : Cat 1 - 1 / Spring sphere 180001 3001		28 February 2022 => 28 June 2022		>> Fin fev > Fin juin
		// 2 : Cat 1 - 2 / Summer sphere 180002 3002		27 May 2021 => 30 September 2021		>> Fin mai > Fin sept
		// 3 : Cat 1 - 3 / Automn sphere 180003 3003		31 August 2021 => 31 December 2021		>> Fin aout > Fin dec
		// 4 : Cat 1 - 4 / Winter Sphere 180004 3004		30 November 2021 => 31 March 2022		>> Fin nov > fin mars
		// 18 : Cat 1 - 18 / Costume plate ticket (180018) 3005		30 April 2021 => 16 May 2021

		// Unique
		// 5 : Cat 2 - 0 / 4001	Lottery☆Drawing Ticket		31 October 2020 => 30 November 2020
		// 9 : Cat 2 - 0 / 4002	Lottery☆Drawing Ticket B	16 July 2021 => 30 August 2021

		// 6 : Cat 3 - 0 / 2002	5 confirmed gacha ticket A	16 August 2021 => 01 September 2021
		// 7 : Cat 3 - 0 / 2003	5 confirmed gacha ticket B	29 February 2020 => 04 March 2020
		// 8 : Cat 3 - 0 / SP Gacha ticket 2004	5 confirmed gacha ticket C			31 May 2021 => 01 September 2021
		// 11 : Cat 3 - 0 / 2010	5 Fixed Log Bowl Gacha Ticket Jul. 18 July 2020 => 31 July 2020
		// 12 : Cat 3 - 0 / 2008	Logbook Gacha Ticket with 5★5 fixed May 15 August 2020 => 31 August 2020
		// 13 : Cat 3 - 0 / 2009	5 Fixed Log Bowl Gacha Ticket Jun.	08 September 2020 => 30 September 2020
		// 14 : Cat 3 - 0 / 2010	5 Fixed Log Bowl Gacha Ticket Jul. 18 July 2016 => 31 July 2016

		// Unique
		// 10 : Cat 5 - 0 / New Year Gift 170016 5001		31 December 2021 => 30 January 2022
		// 16 : Cat 5 - 0 / Macross F Live Commemorative Set / Summer ticket 170013 ou 170014? 5002			10 November 2021 => 05 December 2021

		// Unique
		// 15 : Cat 7 - 0 / 4003	Lottery☆Drawing Ticket C	30 July 2021 => 30 August 2021

		// Unique
		// 17 : Cat 8 - 0 / 4004	Lottery☆Drawing Ticket D	26 December 2021 => 30 January 2022

		// Cat 4 = monthly pass
		// A Limiter a 1 : cat 2 / 5 / 6 / 7 / 8

		// 999999 5* gacha ticket
		
		// VC Cat unlock by label
		/*
		1 0 Friday, 20 October 2017 Tuesday, 17 May 2022					> All time
		2 1 Monday, 28 February 2022 Tuesday, 17 May 2022					> 180001
		3 2 Thursday, 27 May 2021 Monday, 06 September 2021				> 180002
		4 3 Tuesday, 31 August 2021 Saturday, 04 December 2021			> 180002 / 180003
		5 4 Tuesday, 30 November 2021 Monday, 28 February 2022			> 180004
		6 5 Tuesday, 13 July 2021 Monday, 30 August 2021					> 180002 180009 / 180004 180017
		7 6 Wednesday, 10 November 2021 Saturday, 04 December 2021		> 180001 / 180003 180016
		8 5 Sunday, 26 December 2021 Saturday, 29 January 2022			> Bonus 17 > Cat 8
		9 7 Friday, 30 July 2021 Monday, 30 August 2021					> 180002 180015 / 180009 / 180004
		10 10 Thursday, 31 December 2020 Sunday, 31 January 2021			> 180004 180008 / 999999 180004
		11 Ignore	8 Thursday, 30 January 2020 Sunday, 02 February 2020	> 180006 180004
		12 Ignore	9 Saturday, 29 February 2020 Tuesday, 03 March 2020		> 180007 180001
		13 Ignore	10 Tuesday, 31 December 2019 Sunday, 05 January 2020	
		14 11 Friday, 31 December 2021 Friday, 28 January 2022 			> 180004 180010
		15 12 Friday, 30 April 2021 Sunday, 09 May 2021 					> 180001 180018
		*/

		public class UserCurrencyInfo
		{
			public int id;
			public int free;
			public int paid;

			public void Load(EDOHBJAPLPF_JsonData data)
			{
				id = (int)data["id"];
				free = (int)data["free"];
				paid = (int)data["paid"];
			}

			public EDOHBJAPLPF_JsonData Save()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["id"] = id;
				res["free"] = free;
				res["paid"] = paid;
				return res;
			}
		}

		public class UserProductInfo
		{
			public int id;
			public int buy_count;

			public void Load(EDOHBJAPLPF_JsonData data)
			{
				id = (int)data["id"];
				buy_count = (int)data["buy_count"];
			}

			public EDOHBJAPLPF_JsonData Save()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["id"] = id;
				res["buy_count"] = buy_count;
				return res;
			}
		}

		public class UserProducts
		{
			public List<UserCurrencyInfo> Currencies = new List<UserCurrencyInfo>();
			public List<UserProductInfo> Products = new List<UserProductInfo>();

			public void Load(EDOHBJAPLPF_JsonData data)
			{
				if(!data.BBAJPINMOEP_Contains("user_data"))
					return;
				if(!data["user_data"].BBAJPINMOEP_Contains("products"))
					return;
				EDOHBJAPLPF_JsonData json = data["user_data"]["products"];
				if(json.BBAJPINMOEP_Contains("currencies"))
				{
					EDOHBJAPLPF_JsonData array = json["currencies"];
					for(int i = 0; i < array.HNBFOAJIIAL_Count; i++)
					{
						UserCurrencyInfo d = new UserCurrencyInfo();
						d.Load(array[i]);
						Currencies.Add(d);
					}
				}
				if(json.BBAJPINMOEP_Contains("products"))
				{
					EDOHBJAPLPF_JsonData array = json["products"];
					for(int i = 0; i < array.HNBFOAJIIAL_Count; i++)
					{
						UserProductInfo d = new UserProductInfo();
						d.Load(array[i]);
						Products.Add(d);
					}
				}
			}

			public void Save(EDOHBJAPLPF_JsonData data)
			{
				if(!data.BBAJPINMOEP_Contains("user_data"))
					data["user_data"] = new EDOHBJAPLPF_JsonData();

				data["user_data"]["products"] = new EDOHBJAPLPF_JsonData();
				data["user_data"]["products"]["currencies"] = new EDOHBJAPLPF_JsonData();
				data["user_data"]["products"]["currencies"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for(int i = 0; i < Currencies.Count; i++)
				{
					data["user_data"]["products"]["currencies"].Add(Currencies[i].Save());
				}
				data["user_data"]["products"]["products"] = new EDOHBJAPLPF_JsonData();
				data["user_data"]["products"]["products"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for(int i = 0; i < Products.Count; i++)
				{
					data["user_data"]["products"]["products"].Add(Products[i].Save());
				}
			}

		}

		static List<CurrencyInfo> Currencies = new List<CurrencyInfo>() {
			new CurrencyInfo()
			{
				id = 1001, // stones
				name = JpStringLiterals.StringLiteral_10137,
				desc = JpStringLiterals.UMO_currency_1001_desc
			},
			new CurrencyInfo()
			{
				id = 2002, // 5 confirmed gacha ticket A
				name = JpStringLiterals.UMO_currency_2002_name,
				desc = JpStringLiterals.UMO_currency_2002_desc
			},
			new CurrencyInfo()
			{
				id = 2003, // 5 confirmed gacha ticket B
				name = JpStringLiterals.UMO_currency_2003_name,
				desc = JpStringLiterals.UMO_currency_2003_desc
			},
			new CurrencyInfo()
			{
				id = 2004, // 5 confirmed gacha ticket C
				name = JpStringLiterals.UMO_currency_2004_name,
				desc = JpStringLiterals.UMO_currency_2004_desc
			},
			new CurrencyInfo()
			{
				id = 2008, // Logbook Gacha Ticket with 5★5 fixed May
				name = JpStringLiterals.UMO_currency_2008_name,
				desc = JpStringLiterals.UMO_currency_2008_desc
			},
			new CurrencyInfo()
			{
				id = 2009, // 5 Fixed Log Bowl Gacha Ticket Jun.
				name = JpStringLiterals.UMO_currency_2009_name,
				desc = JpStringLiterals.UMO_currency_2009_desc
			},
			new CurrencyInfo()
			{
				id = 2010, // 5 Fixed Log Bowl Gacha Ticket Jul.
				name = JpStringLiterals.UMO_currency_2010_name,
				desc = JpStringLiterals.UMO_currency_2010_desc
			},
			new CurrencyInfo()
			{
				id = 2101, // Decal Gacha Ticket
				name = JpStringLiterals.UMO_currency_2101_name,
				desc = JpStringLiterals.UMO_currency_2101_desc
			},
			new CurrencyInfo()
			{
				id = 2201, // Event Gacha Ticket (Collection A)
				name = JpStringLiterals.UMO_currency_2201_name,
				desc = JpStringLiterals.UMO_currency_2201_desc
			},
			new CurrencyInfo()
			{
				id = 2202, // Event Gacha Ticket (Collection B)
				name = JpStringLiterals.UMO_currency_2202_name,
				desc = JpStringLiterals.UMO_currency_2202_desc
			},
			new CurrencyInfo()
			{
				id = 2203, // Event gacha ticket (Collection C)
				name = JpStringLiterals.UMO_currency_2203_name,
				desc = JpStringLiterals.UMO_currency_2203_desc
			},
			new CurrencyInfo()
			{
				id = 2204, // Event gacha ticket (Mission A)
				name = JpStringLiterals.UMO_currency_2204_name,
				desc = JpStringLiterals.UMO_currency_2204_desc
			},
			new CurrencyInfo()
			{
				id = 2205, // Event gacha ticket (Mission B)
				name = JpStringLiterals.UMO_currency_2205_name,
				desc = JpStringLiterals.UMO_currency_2205_desc
			},
			new CurrencyInfo()
			{
				id = 2206, // Event gacha ticket (Mission C)
				name = JpStringLiterals.UMO_currency_2206_name,
				desc = JpStringLiterals.UMO_currency_2206_desc
			},
			new CurrencyInfo()
			{
				id = 2207, // Event Gacha Ticket (Diva - Battle A)
				name = JpStringLiterals.UMO_currency_2207_name,
				desc = JpStringLiterals.UMO_currency_2207_desc
			},
			new CurrencyInfo()
			{
				id = 2208, // Event Gacha Ticket (Diva - Battle B)
				name = JpStringLiterals.UMO_currency_2208_name,
				desc = JpStringLiterals.UMO_currency_2208_desc
			},
			new CurrencyInfo()
			{
				id = 2209, // Event Gacha Ticket (Diva - Battle C)
				name = JpStringLiterals.UMO_currency_2209_name,
				desc = JpStringLiterals.UMO_currency_2209_desc
			},
			new CurrencyInfo()
			{
				id = 3001, // Spring Sphere
				name = JpStringLiterals.UMO_currency_3001_name,
				desc = JpStringLiterals.UMO_currency_3001_desc
			},
			new CurrencyInfo()
			{
				id = 3002, // Summer Sphere
				name = JpStringLiterals.UMO_currency_3002_name,
				desc = JpStringLiterals.UMO_currency_3002_desc
			},
			new CurrencyInfo()
			{
				id = 3003, // Automn Sphere
				name = JpStringLiterals.UMO_currency_3003_name,
				desc = JpStringLiterals.UMO_currency_3003_desc
			},
			new CurrencyInfo()
			{
				id = 3004, // Winter sphere
				name = JpStringLiterals.UMO_currency_3004_name,
				desc = JpStringLiterals.UMO_currency_3004_desc
			},
			new CurrencyInfo()
			{
				id = 3005, // Costume Release Plate Exchange Ticket
				name = JpStringLiterals.UMO_currency_3005_name,
				desc = JpStringLiterals.UMO_currency_3005_desc
			},
			new CurrencyInfo()
			{
				id = 4001, // Lottery☆Drawing Ticket
				name = JpStringLiterals.UMO_currency_4001_name,
				desc = JpStringLiterals.UMO_currency_4001_desc
			},
			new CurrencyInfo()
			{
				id = 4002, // Lottery☆Drawing Ticket B
				name = JpStringLiterals.UMO_currency_4002_name,
				desc = JpStringLiterals.UMO_currency_4002_desc
			},
			new CurrencyInfo()
			{
				id = 4003, // Lottery☆Drawing Ticket C
				name = JpStringLiterals.UMO_currency_4003_name,
				desc = JpStringLiterals.UMO_currency_4003_desc
			},
			new CurrencyInfo()
			{
				id = 4004, // Lottery☆Drawing Ticket D
				name = JpStringLiterals.UMO_currency_4004_name,
				desc = JpStringLiterals.UMO_currency_4004_desc
			},
			new CurrencyInfo()
			{
				id = 5001, // New Year's gift
				name = JpStringLiterals.UMO_currency_5001_name,
				desc = JpStringLiterals.UMO_currency_5001_desc
			},
			new CurrencyInfo()
			{
				id = 5002, // Summer ticket
				name = JpStringLiterals.UMO_currency_5002_name,
				desc = JpStringLiterals.UMO_currency_5002_desc
			}
		};

		public static void ConsumeCurrency(int currency_id, int num)
		{
			UserProducts userProducts = new UserProducts();
			userProducts.Load(playerAccount.playerData.serverData);

			EDOHBJAPLPF_JsonData r = null;
			for(int j = 0; j < Currencies.Count; j++)
			{
				if (Currencies[j].id == currency_id)
				{
					UserCurrencyInfo uc = userProducts.Currencies.Find((UserCurrencyInfo _) =>
					{
						return _.id == currency_id;
					});
					if(uc == null)
					{
						uc = new UserCurrencyInfo();
						userProducts.Currencies.Add(uc);
						uc.id = currency_id;
					}
					uc.paid -= num;
					break;
				}
			}
			userProducts.Save(playerAccount.playerData.serverData);
			SaveAccountServerData();
		}

		public static void AddToBalance(int currency_id, int num)
		{
			UserProducts userProducts = new UserProducts();
			userProducts.Load(playerAccount.playerData.serverData);

			EDOHBJAPLPF_JsonData r = null;
			for(int j = 0; j < Currencies.Count; j++)
			{
				if (Currencies[j].id == currency_id)
				{
					UserCurrencyInfo uc = userProducts.Currencies.Find((UserCurrencyInfo _) =>
					{
						return _.id == currency_id;
					});
					if(uc == null)
					{
						uc = new UserCurrencyInfo();
						userProducts.Currencies.Add(uc);
						uc.id = currency_id;
					}
					uc.paid += num;
					break;
				}
			}
			userProducts.Save(playerAccount.playerData.serverData);
			SaveAccountServerData();
		}

		public static EDOHBJAPLPF_JsonData GetBalanceJson(int val)
		{
			UserProducts userProducts = new UserProducts();
			userProducts.Load(playerAccount.playerData.serverData);

			EDOHBJAPLPF_JsonData r = null;
			for(int j = 0; j < Currencies.Count; j++)
			{
				if (Currencies[j].id == val)
				{
					UserCurrencyInfo uc = userProducts.Currencies.Find((UserCurrencyInfo _) =>
					{
						return _.id == val;
					});
					r = new EDOHBJAPLPF_JsonData();
					r["description"] = Currencies[j].desc;
					r["free"] = uc != null ? uc.free : 0;
					r["id"] = Currencies[j].id;
					r["name"] = Currencies[j].name;
					r["paid"] = uc != null ? uc.paid : 0;
					r["total"] = uc != null ? uc.paid + uc.free : 0;
					break;
				}
			}
			if(r == null)
			{
				TodoLogger.LogError(TodoLogger.SakashoServer, "GetBalance, missing id "+val);
				r = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"{
				""description"": ""No desc"",
				""free"": 0,
				""id"": "+val+@",
				""name"": ""No name"",
				""paid"": 0,
				""total"": 0
			}");
			}
			return r;
		}

		public static void GetBalances(EDOHBJAPLPF_JsonData res, List<int> ids)
		{
			if(!res.BBAJPINMOEP_Contains("balances"))
			{
				res["balances"] = new EDOHBJAPLPF_JsonData();
				res["balances"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			}
			for(int i = 0; i < ids.Count; i++)
			{
				res["balances"].Add(GetBalanceJson(ids[i]));
			}
		}

		public static int SakashoPaymentGetRemainingForCurrencyIds(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData ids = jsonData["ids"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			List<int> intIds = new List<int>();
			for(int i = 0; i < ids.HNBFOAJIIAL_Count; i++)
			{
				intIds.Add((int)ids[i]);
			}
			GetBalances(res, intIds);

			SendMessage(callbackId, res);
			return 0;
		}
		
		public static int SakashoPaymentGetVirtualCurrencyBalancesWithExpiredAt(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData ids = jsonData["virtualCurrencyIds"];

			string message = "";

			/*EDOHBJAPLPF_JsonData arrayData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
				{
					""description"": ""\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [
						{
							remainings: ,
							expired_at:
						}
					],
					""id"": 2101,
					""name"": ""\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8"",
					""paid"": []
				},
				{
					""description"": ""\u53ce\u96c6\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [],
					""id"": 2201,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u53ce\u96c6A)"",
					""paid"": []
				},
				{
					""description"": ""\u53ce\u96c6\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [],
					""id"": 2202,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u53ce\u96c6B)"",
					""paid"": []
				},
				{
					""description"": ""\u53ce\u96c6\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [],
					""id"": 2203,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u53ce\u96c6C)"",
					""paid"": []
				},
				{
					""description"": ""\u30df\u30c3\u30b7\u30e7\u30f3\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [],
					""id"": 2204,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u30df\u30c3\u30b7\u30e7\u30f3A)"",
					""paid"": []
				},
				{
					""description"": ""\u30df\u30c3\u30b7\u30e7\u30f3\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [],
					""id"": 2205,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u30df\u30c3\u30b7\u30e7\u30f3B)"",
					""paid"": []
				},
				{
					""description"": ""\u30df\u30c3\u30b7\u30e7\u30f3\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [],
					""id"": 2206,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u30df\u30c3\u30b7\u30e7\u30f3C)"",
					""paid"": []
				},
				{
					""description"": ""\u30d0\u30c8\u30eb\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [],
					""id"": 2207,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u6b4c\u59eb-\u30d0\u30c8\u30ebA)"",
					""paid"": []
				},
				{
					""description"": ""\u30d0\u30c8\u30eb\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [],
					""id"": 2208,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u6b4c\u59eb-\u30d0\u30c8\u30ebB)"",
					""paid"": []
				},
				{
					""description"": ""\u30d0\u30c8\u30eb\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [],
					""id"": 2209,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u6b4c\u59eb-\u30d0\u30c8\u30ebC)"",
					""paid"": []
				}
			]");*/

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["balances"] = new EDOHBJAPLPF_JsonData();
			res["balances"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < ids.HNBFOAJIIAL_Count; i++)
			{
				int val = (int)ids[i];
				EDOHBJAPLPF_JsonData r = null;
				for(int j = 0; j < Currencies.Count; j++)
				{
					if ((int)Currencies[j].id == val)
					{
						/*UserCurrencyInfo uc = userProducts.Currencies.Find((UserCurrencyInfo _) =>
						{
							return _.id == val;
						});*/
						r = new EDOHBJAPLPF_JsonData();
						r["description"] = Currencies[j].desc;
						r["free"] = new EDOHBJAPLPF_JsonData();
						r["free"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
						r["id"] = Currencies[j].id;
						r["name"] = Currencies[j].name;
						r["paid"] = new EDOHBJAPLPF_JsonData();
						r["paid"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
						break;
					}
				}
				if(r == null)
				{
					TodoLogger.LogError(TodoLogger.SakashoServer, "SakashoPaymentGetVirtualCurrencyBalancesWithExpiredAt, missing id " + val);
					r = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"{
					""description"": ""No desc"",
					""free"": [],
					""id"": "+val+@",
					""name"": ""No name"",
					""paid"": []
				}");
				}
				res["balances"].Add(r);
			}

			SendMessage(callbackId, res);
			return 0;
		}

		public class ProductInfo
		{
			public class Description
			{
				public int banner_id;
				public string bg_id = "";
				public int day_count;
				public int disable_carousel;
				public List<int> feature;
				public int group_id;
				public string kakutei = "";
				public int kakutei_num;
				public string name = "";
				public string original_name = "";
				public string desc = "";
				public long open_time;
				public string templ = "";
				public long view_order;
				public int cost_item_id;
				public string free_badge_mess = "";
				public string free_multi = "";
				public int free_only;
				public int free_texture_id;
				public string label = "";
				public int sale_button_visible;
				public int ver;
				public int one_day;
				public int show_popup;
			}

			public class NormalLotFreeSetting
			{
				public int? duration_days;
				public int reset_count;
				public int? reset_hours;
			}

			public int id;
			public int productType;
			public string group_key = "";
			public int buy_limit;
			public long closed_at;
			public Description description;
			public string description_txt;
			public string imageUrl = "";
			public List<string> item_set_name_for_api;
			public int label;
			public string name = "";
			public string original_name = "";
			public long opened_at;
			public string platform_product_id;
			public Dictionary<int, int> price_by_currency = new Dictionary<int, int>();
			public NormalLotFreeSetting normal_lot_free_setting;

			public string GetDescription()
			{
				if(description != null)
				{
					EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
					if(description.banner_id != 0)
						res["banner_id"] = description.banner_id;
					res["bg_id"] = description.bg_id;
					res["day_count"] = description.day_count;
					res["disable_carousel"] = description.disable_carousel;
					if(description.feature != null)
					{
						res["feature"] = string.Join(",", description.feature);
					}
					res["group_id"] = description.group_id;
					if(description.kakutei_num != 0)
					{
						res["kakutei"] = description.kakutei_num;
					}
					else if(description.kakutei != "")
					{
						res["kakutei"] = description.kakutei;
					}
					res["name"] = description.name;
					res["original_name"] = description.original_name;
					if(description.desc != "")
						res["desc"] = description.desc;
					res["open_time"] = description.open_time;
					if(description.templ != "")
						res["templ"] = description.templ;
					if(description.view_order != 0)
						res["view_order"] = description.view_order;
					if(description.cost_item_id != 0)
						res["cost_item_id"] = description.cost_item_id;
					res["free_badge_mess"] = description.free_badge_mess;
					if(description.free_multi != "")
						res["free_multi"] = description.free_multi;
					if(description.free_only != 0)
						res["free_only"] = description.free_only;
					res["free_texture_id"] = description.free_texture_id;
					if(description.label != "")
						res["label"] = description.label;
					res["sale_button_visible"] = description.sale_button_visible;
					if(description.ver != 0)
						res["ver"] = description.ver;
					if(description.one_day != 0)
						res["one_day"] = description.one_day;
					if(description.show_popup != 0)
						res["show_popup"] = description.show_popup;
					return res.EJCOJCGIBNG_ToJson();
				}
				return description_txt;
			}
		}

		static bool ProductsInitialized = false;
		static List<ProductInfo> Products = new List<ProductInfo>()
		{
			new ProductInfo()
			{
				id = 178088,
				productType = 2,
				name = JpStringLiterals.UMO_product_178088_name,
				original_name = JpStringLiterals.UMO_product_178088_name_jp,
				buy_limit = 1,
				opened_at = 1556636400,
				closed_at = 32503647600,
				item_set_name_for_api = new List<string>() {
					"normal_lot_3_0023_0_assured",
					"normal_lot_3_0023_1_rare4only",
					"normal_lot_3_0023_0_assured",
					"normal_lot_3_0023_0_assured",
					"normal_lot_3_0023_0_assured",
					"normal_lot_3_0023_0_assured",
					"normal_lot_3_0023_0_assured",
					"normal_lot_3_0023_0_assured",
					"normal_lot_3_0023_0_assured",
					"normal_lot_3_0023_0_assured"
				},
				label = 3002304,
				price_by_currency = new Dictionary<int, int>() { { 1001, 300 } },
				description = new ProductInfo.Description()
				{
					banner_id = 30021,
					bg_id = "pl=13",
					day_count = 0,
					disable_carousel = 1,
					feature = new List<int>() { 13,121,206,62,73,85,134,145,157,25 },
					group_id = 30023,
					kakutei_num = 5,
					name = JpStringLiterals.UMO_product_178088_desc_name,
					original_name = JpStringLiterals.UMO_product_178088_desc_name_jp,
					open_time = 1556636400,
					templ = "gacha_debut_detail_30021",
					view_order = 48132221017718819
				}
			},
			new ProductInfo()
			{
				id = 429267,
				productType = 2,
				buy_limit = 0,
				closed_at = 1656558000,
				item_set_name_for_api = new List<string>() { "normal_lot_10_1008_0_rare4only" },
				label = 10100801,
				name = JpStringLiterals.UMO_product_429267_name,
				original_name = JpStringLiterals.UMO_product_429267_name_jp,
				opened_at = 1648695600,
				price_by_currency = new Dictionary<int, int>() { { 1001, 1 } },
				description = new ProductInfo.Description()
				{
					banner_id = 101001,
					bg_id = "gc=101008",
					cost_item_id = 240002,
					day_count = 0,
					desc = JpStringLiterals.UMO_product_429267_desc_desc,
					disable_carousel = 1,
					free_badge_mess = "",
					free_texture_id = 0,
					group_id = 101008,
					label = "popup_gacha_pass_rate_warning",
					name = JpStringLiterals.UMO_product_429267_desc_name,
					original_name = JpStringLiterals.UMO_product_429267_desc_name_jp,
					open_time = 1648695600,
					sale_button_visible = 0,
					templ = "gacha_item_detail",
					ver = 2,
					view_order = 38327875832643584
				}
			},
			new ProductInfo()
			{
				id = 429712,
				productType = 2,
				buy_limit = 0,
				closed_at = 1656428400,
				item_set_name_for_api = new List<string>() { "normal_lot_1_0318_0" },
				label = 1031801,
				name = JpStringLiterals.UMO_product_429712_name,
				original_name = JpStringLiterals.UMO_product_429712_name_jp,
				opened_at = 1650596400,
				price_by_currency = new Dictionary<int, int>() { { 1001, 2 } },
				description = new ProductInfo.Description()
				{
					banner_id = 10001,
					bg_id = "gc=10001",
					day_count = 0,
					desc = JpStringLiterals.UMO_product_429712_desc_desc,
					disable_carousel = 1,
					free_badge_mess = "",
					free_texture_id = 0,
					group_id = 10318,
					name = JpStringLiterals.UMO_product_429712_desc_name,
					original_name = JpStringLiterals.UMO_product_429712_desc_name_jp,
					open_time = 1650596400,
					sale_button_visible = 0,
					ver = 2
				}
			},
			new ProductInfo()
			{
				id = 429927,
				productType = 2,
				buy_limit = 0,
				closed_at = 1656428400,
				item_set_name_for_api = new List<string>() { "normal_lot_10_0045_0" },
				label = 10004501,
				name = JpStringLiterals.UMO_product_429927_name,
				original_name = JpStringLiterals.UMO_product_429927_name_jp,
				opened_at = 1651330800,
				price_by_currency = new Dictionary<int, int>() { { 1001, 1 } },
				description = new ProductInfo.Description()
				{
					banner_id = 100001,
					bg_id = "gc=100001",
					cost_item_id = 240001,
					day_count = 0,
					desc = JpStringLiterals.UMO_product_429927_desc_desc,
					disable_carousel = 1,
					free_badge_mess = "",
					free_texture_id = 0,
					group_id = 100045,
					label = "popup_gacha_pass_rate_warning",
					name = JpStringLiterals.UMO_product_429927_desc_name,
					original_name = JpStringLiterals.UMO_product_429927_desc_name,
					open_time = 1651330800,
					sale_button_visible = 0,
					templ = "gacha_pass_detail",
					ver = 2,
					view_order = 38323739779137536
				}
			},
			new ProductInfo()
			{
				id = 429928,
				productType = 2,
				buy_limit = 0,
				closed_at = 1656396000,
				item_set_name_for_api = new List<string>() { "normal_lot_4_1252_0_rare4only" },
				label = 4125201,
				name = JpStringLiterals.UMO_product_429928_name,
				original_name = JpStringLiterals.UMO_product_429928_name_jp,
				normal_lot_free_setting = new ProductInfo.NormalLotFreeSetting(),
				opened_at = 1651330800,
				price_by_currency = new Dictionary<int, int>() { { 1001, 50 }, { 2101, 1 } },
				description = new ProductInfo.Description()
				{
					bg_id = "gc=41252",
					day_count = 0,
					disable_carousel = 0,
					free_badge_mess = JpStringLiterals.UMO_product_429928_desc_free_msg,
					free_texture_id = 0,
					group_id = 41252,
					label = "popup_gacha_once_rate_warning",
					name = JpStringLiterals.UMO_product_429928_desc_name,
					original_name = JpStringLiterals.UMO_product_429928_desc_name_jp,
					open_time = 1651330800,
					sale_button_visible = 0,
					templ = "gacha_season_detail_41252",
					ver = 2,
					view_order = 52531521659076608
				}
			},
			new ProductInfo()
			{
				id = 429929,
				productType = 2,
				buy_limit = 0,
				closed_at = 1656396000,
				item_set_name_for_api = new List<string>()
				{
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_1_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only"
				},
				label = 4125202,
				name = JpStringLiterals.UMO_product_429929_name,
				original_name = JpStringLiterals.UMO_product_429929_name_jp,
				opened_at = 1651330800,
				price_by_currency = new Dictionary<int, int>() { { 1001, 500 }, { 2101, 10 } },
				description = new ProductInfo.Description()
				{
					bg_id = "gc=41252",
					day_count = 0,
					disable_carousel = 0,
					free_badge_mess = JpStringLiterals.UMO_product_429929_desc_free_msg,
					group_id = 41252,
					kakutei = JpStringLiterals.UMO_product_429929_desc_kakutei,
					label = "popup_gacha_once_rate_warning",
					name = JpStringLiterals.UMO_product_429929_desc_name,
					original_name = JpStringLiterals.UMO_product_429929_desc_name_jp,
					open_time = 1651330800,
					sale_button_visible = 0,
					templ = "gacha_season_detail_41252",
					ver = 2,
					view_order = 52531521659076608
				}
			},
			new ProductInfo()
			{
				id = 429930,
				productType = 2,
				buy_limit = 1,
				closed_at = 1656396000,
				item_set_name_for_api = new List<string>()
				{
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_1_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only",
					"normal_lot_4_1252_0_rare4only"
				},
				label = 4125204,
				name = JpStringLiterals.UMO_product_429930_name,
				original_name = JpStringLiterals.UMO_product_429930_name_jp,
				opened_at = 1651330800,
				price_by_currency = new Dictionary<int, int>() { { 1001, 300 } },
				description = new ProductInfo.Description()
				{
					bg_id = "gc=41252",
					day_count = 0,
					disable_carousel = 0,
					free_badge_mess = JpStringLiterals.UMO_product_429930_desc_free_msg,
					free_texture_id = 0,
					group_id = 41252,
					kakutei = JpStringLiterals.UMO_product_429930_desc_kakutei,
					label = "popup_gacha_once_rate_warning",
					name = JpStringLiterals.UMO_product_429930_desc_name,
					original_name = JpStringLiterals.UMO_product_429930_desc_name_jp,
					open_time = 1651330800,
					sale_button_visible = 0,
					templ = "gacha_season_detail_41252",
					ver = 2,
					view_order = 52531521659076608
				}
			},
			new ProductInfo()
			{
				id = 430020,
				productType = 2,
				buy_limit = 10,
				closed_at = 1654441200,
				item_set_name_for_api = new List<string>()
				{
					"normal_lot_3_1096_0_assured",
					"normal_lot_3_1096_0_assured",
					"normal_lot_3_1096_0_assured",
					"normal_lot_3_1096_0_assured",
					"normal_lot_3_1096_0_assured",
					"normal_lot_3_1096_0_assured",
					"normal_lot_3_1096_0_assured",
					"normal_lot_3_1096_0_assured",
					"normal_lot_3_1096_0_assured",
					"normal_lot_3_1096_0_assured"
				},
				label = 3109604,
				name = JpStringLiterals.UMO_product_430020_name,
				original_name = JpStringLiterals.UMO_product_430020_name_jp,
				normal_lot_free_setting = new ProductInfo.NormalLotFreeSetting()
				{
					duration_days = 1
				},
				opened_at = 1653577140,
				price_by_currency = new Dictionary<int, int>() { { 1001, 1000000 } },
				description = new ProductInfo.Description()
				{
					bg_id = "gc=31096",
					day_count = 0,
					disable_carousel = 0,
					free_badge_mess = JpStringLiterals.UMO_product_430020_desc_free_msg,
					free_multi = JpStringLiterals.UMO_product_430020_desc_free_multi_msg,
					free_only = 1,
					free_texture_id = 0,
					group_id = 31096,
					label = "popup_gacha_pass_rate_warning",
					name = JpStringLiterals.UMO_product_430020_desc_name,
					original_name = JpStringLiterals.UMO_product_430020_desc_name_jp,
					one_day = 1,
					open_time = 1653577200,
					sale_button_visible = 0,
					show_popup = 0,
					templ = "gacha_season_detail_31096",
					ver = 2,
					view_order = 67124600760172544
				}
			},
			new ProductInfo()
			{
				id = 67554,
				buy_limit = 0,
				closed_at = 32520895200,
				description_txt = JpStringLiterals.UMO_product_67554_desc,
				label = 10,
				name = JpStringLiterals.UMO_product_67554_name,
				original_name = JpStringLiterals.UMO_product_67554_name_jp,
				opened_at = 1497856800,
				price_by_currency = new Dictionary<int, int>() { { 1001, 10 } },
			},
			new ProductInfo()
			{
				id = 67572,
				buy_limit = 0,
				closed_at = 32520895200,
				description_txt = JpStringLiterals.UMO_product_67572_name,
				label = 10,
				name = JpStringLiterals.UMO_product_67572_name,
				original_name = JpStringLiterals.UMO_product_67572_name_jp,
				opened_at = 1497870000,
				price_by_currency = new Dictionary<int, int>() { { 1001, 10 } },
			},
			new ProductInfo()
			{
				id = 153192,
				buy_limit = 0,
				closed_at = 32525902800,
				description_txt = JpStringLiterals.UMO_product_153192_desc,
				label = 10,
				name = JpStringLiterals.UMO_product_153192_name,
				original_name = JpStringLiterals.UMO_product_153192_name_jp,
				opened_at = 1535342400,
				price_by_currency = new Dictionary<int, int>() { { 1001, 5 } },
			},
			new ProductInfo()
			{
				id = 167079,
				buy_limit = 0,
				closed_at = 32512611600,
				description_txt = JpStringLiterals.UMO_product_167079_name,
				label = 10,
				name = JpStringLiterals.UMO_product_167079_name,
				original_name = JpStringLiterals.UMO_product_167079_name_jp,
				normal_lot_free_setting = new ProductInfo.NormalLotFreeSetting(),
				opened_at = 1552575600,
				price_by_currency = new Dictionary<int, int>() { { 1001, 10 } },
			},
			new ProductInfo()
			{
				id = 222423,
				buy_limit = 0,
				closed_at = 32530057200,
				description_txt = JpStringLiterals.UMO_product_222423_desc,
				label = 10,
				name = JpStringLiterals.UMO_product_222423_name,
				original_name = JpStringLiterals.UMO_product_222423_name_jp,
				opened_at = 1570086000,
				price_by_currency = new Dictionary<int, int>() { { 1001, 5 } },
			},
			new ProductInfo()
			{
				id = 222424,
				buy_limit = 0,
				closed_at = 32530057200,
				description_txt = JpStringLiterals.UMO_product_222424_desc,
				label = 10,
				name = JpStringLiterals.UMO_product_222424_name,
				original_name = JpStringLiterals.UMO_product_222424_name_jp,
				opened_at = 1570086000,
				price_by_currency = new Dictionary<int, int>() { { 1001, 20 } },
			},
			/*new ProductInfo()
			{
				id = 428662,
				buy_limit = 5,
				closed_at = 1655305199,
				label = 39,
				name = JpStringLiterals.UMO_product_428662_name,
				opened_at = 1651330800,
				price_by_currency = new Dictionary<int, int>() { { 3001, 2200 }, { 3002, 2200 }, { 3003, 2200 }, { 3004, 2200 } },
			},
			new ProductInfo()
			{
				id = 428665,
				buy_limit = 10,
				closed_at = 1655305199,
				label = 40,
				name = JpStringLiterals.UMO_product_428665_name,
				opened_at = 1651330800,
				price_by_currency = new Dictionary<int, int>() { { 3001, 500 }, { 3002, 500 }, { 3003, 500 }, { 3004, 500 } },
			},
			new ProductInfo()
			{
				id = 428666,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 41,
				name = JpStringLiterals.UMO_product_428666_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 30 }, { 3002, 30 }, { 3003, 30 }, { 3004, 30 } },
			},
			new ProductInfo()
			{
				id = 428667,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 42,
				name = JpStringLiterals.UMO_product_428667_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 60 }, { 3002, 60 }, { 3003, 60 }, { 3004, 60 } },
			},
			new ProductInfo()
			{
				id = 428668,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 43,
				name = JpStringLiterals.UMO_product_428668_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 120 }, { 3002, 120 }, { 3003, 120 }, { 3004, 120 } },
			},
			new ProductInfo()
			{
				id = 428669,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 44,
				name = JpStringLiterals.UMO_product_428669_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 30 }, { 3002, 30 }, { 3003, 30 }, { 3004, 30 } },
			},
			new ProductInfo()
			{
				id = 428670,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 45,
				name = JpStringLiterals.UMO_product_428670_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 60 }, { 3002, 60 }, { 3003, 60 }, { 3004, 60 } },
			},
			new ProductInfo()
			{
				id = 428671,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 46,
				name = JpStringLiterals.UMO_product_428671_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 120 }, { 3002, 120 }, { 3003, 120 }, { 3004, 120 } },
			},
			new ProductInfo()
			{
				id = 428672,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 47,
				name = JpStringLiterals.UMO_product_428672_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 30 }, { 3002, 30 }, { 3003, 30 }, { 3004, 30 } },
			},
			new ProductInfo()
			{
				id = 428673,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 48,
				name = JpStringLiterals.UMO_product_428673_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 60 }, { 3002, 60 }, { 3003, 60 }, { 3004, 60 } },
			},
			new ProductInfo()
			{
				id = 428674,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 49,
				name = JpStringLiterals.UMO_product_428674_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 120 }, { 3002, 120 }, { 3003, 120 }, { 3004, 120 } },
			},
			new ProductInfo()
			{
				id = 428675,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 50,
				name = JpStringLiterals.UMO_product_428675_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 10 }, { 3002, 10 }, { 3003, 10 }, { 3004, 10 } },
			},
			new ProductInfo()
			{
				id = 428676,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 51,
				name = JpStringLiterals.UMO_product_428676_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 20 }, { 3002, 20 }, { 3003, 20 }, { 3004, 20 } },
			},
			new ProductInfo()
			{
				id = 428677,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 52,
				name = JpStringLiterals.UMO_product_428677_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 30 }, { 3002, 30 }, { 3003, 30 }, { 3004, 30 } },
			},
			new ProductInfo()
			{
				id = 428678,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 56,
				name = JpStringLiterals.UMO_product_428678_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 20 }, { 3002, 20 }, { 3003, 20 }, { 3004, 20 } },
			},
			new ProductInfo()
			{
				id = 428679,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 57,
				name = JpStringLiterals.UMO_product_428679_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 40 }, { 3002, 40 }, { 3003, 40 }, { 3004, 40 } },
			},
			new ProductInfo()
			{
				id = 428680,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 58,
				name = JpStringLiterals.UMO_product_428680_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 80 }, { 3002, 80 }, { 3003, 80 }, { 3004, 80 } },
			},
			new ProductInfo()
			{
				id = 428681,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 59,
				name = JpStringLiterals.UMO_product_428681_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 20 }, { 3002, 20 }, { 3003, 20 }, { 3004, 20 } },
			},
			new ProductInfo()
			{
				id = 428682,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 60,
				name = JpStringLiterals.UMO_product_428682_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 40 }, { 3002, 40 }, { 3003, 40 }, { 3004, 40 } },
			},
			new ProductInfo()
			{
				id = 428683,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 61,
				name = JpStringLiterals.UMO_product_428683_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 80 }, { 3002, 80 }, { 3003, 80 }, { 3004, 80 } },
			},
			new ProductInfo()
			{
				id = 428684,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 62,
				name = JpStringLiterals.UMO_product_428684_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 20 }, { 3002, 20 }, { 3003, 20 }, { 3004, 20 } },
			},
			new ProductInfo()
			{
				id = 428685,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 63,
				name = JpStringLiterals.UMO_product_428685_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 40 }, { 3002, 40 }, { 3003, 40 }, { 3004, 40 } },
			},
			new ProductInfo()
			{
				id = 428686,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 64,
				name = JpStringLiterals.UMO_product_428686_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 80 }, { 3002, 80 }, { 3003, 80 }, { 3004, 80 } },
			},
			new ProductInfo()
			{
				id = 428687,
				buy_limit = 0,
				closed_at = 1655305199,
				label = 65,
				name = JpStringLiterals.UMO_product_428687_name,
				opened_at = 1646017200,
				price_by_currency = new Dictionary<int, int>() { { 3001, 10 }, { 3002, 10 }, { 3003, 10 }, { 3004, 10 } },
			},
			new ProductInfo()
			{
				id = 428690,
				buy_limit = 1,
				closed_at = 1655305199,
				label = 66,
				name = JpStringLiterals.UMO_product_428690_name,
				opened_at = 1651330800,
				price_by_currency = new Dictionary<int, int>() { { 3001, 3000 }, { 3002, 3000 }, { 3003, 3000 }, { 3004, 3000 } },
			},
			new ProductInfo()
			{
				id = 428693,
				buy_limit = 20,
				closed_at = 1655305199,
				label = 67,
				name = JpStringLiterals.UMO_product_428693_name,
				opened_at = 1651330800,
				price_by_currency = new Dictionary<int, int>() { { 3001, 200 }, { 3002, 200 }, { 3003, 200 }, { 3004, 200 } },
			},
			new ProductInfo()
			{
				id = 428696,
				buy_limit = 1,
				closed_at = 1655305199,
				label = 68,
				name = JpStringLiterals.UMO_product_428696_name,
				opened_at = 1651330800,
				price_by_currency = new Dictionary<int, int>() { { 3001, 6000 }, { 3002, 6000 }, { 3003, 6000 }, { 3004, 6000 } },
			},
			new ProductInfo()
			{
				id = 428699,
				buy_limit = 1,
				closed_at = 1655305199,
				label = 69,
				name = JpStringLiterals.UMO_product_428699_name,
				opened_at = 1651330800,
				price_by_currency = new Dictionary<int, int>() { { 3001, 500 }, { 3002, 500 }, { 3003, 500 }, { 3004, 500 } },
			}*/
		};

		public static int SakashoPaymentGetProducts(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			int currencyId = -1;
			if(jsonData.BBAJPINMOEP_Contains("currencyId"))
				currencyId = (int)jsonData["currencyId"];
			int productType = -1;
			if (jsonData.BBAJPINMOEP_Contains("productType"))
				productType = (int)jsonData["productType"];
			int label = -1;
			if (jsonData.BBAJPINMOEP_Contains("label"))
				label = (int)jsonData["label"];
			string masterGroupName = null;
			if (jsonData.BBAJPINMOEP_Contains("masterGroupName"))
				masterGroupName = (string)jsonData["masterGroupName"];
			int page = (int)jsonData["page"];
			int ipp = (int)jsonData["ipp"];

			if(masterGroupName != null)
				TodoLogger.LogError(TodoLogger.SakashoServer, "masterGroupName == "+masterGroupName+", check");

			string message = "";

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["current_page"] = page;
			res["products"] = new EDOHBJAPLPF_JsonData();
			res["products"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			if(!ProductsInitialized)
			{
				ProductsInitialized = true;
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA.Count; i++)
				{
					DKJMDIFAKKD_VcItem.EBGPAPPHBAH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA[i];
					Products.Add(new ProductInfo() {
						id = 10000000 + item.PPFNGGCBJKC_Id,
						platform_product_id = item.GLHKICCPGKJ_PlatformProductIds.Length > 0 ? item.GLHKICCPGKJ_PlatformProductIds[0] : "UMO."+item.DLCGAMHADEN_Label+"."+item.PPFNGGCBJKC_Id,
						name = item.OPFGFINHFCE_Name,
						original_name = item.OriginalName,
						label = item.DLCGAMHADEN_Label,
						price_by_currency = new Dictionary<int, int>() { { 2, item.HMFFHLPNMPH_Count } }
					});
					for(int j = 0; j < item.KGOFMDMDFCJ_BonusId.Count(); j++)
					{
						//UnityEngine.Debug.LogError(item.KGOFMDMDFCJ_BonusId[j]+" "+item.NNIIINKFDBG_BonusCount[j]);
						if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(item.KGOFMDMDFCJ_BonusId[j]) == EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
						{
							int bonusId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(item.KGOFMDMDFCJ_BonusId[j]);
                            HHJHIFJIKAC_BonusVc.MNGJPJBCMBH bonusItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[bonusId - 1];
							/*long t = Utility.GetCurrentUnixTime();
							if(t < bonusItem.PDBPFJJCADD_OpenAt || t > bonusItem.EGBOHDFBAPB_ClosedAt)
								continue;
							if(bonusItem.INDDJNMPONH != 1)
							{
								int giftId = 0;
								switch(item.KGOFMDMDFCJ_BonusId[j])
								{
									case 180015: // 4周年娘くじ☆抽選券 vc id 236-243 (idx 247-253) + 68-73(67-72) + 51-54(50-53)
									{
										IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PKOJMBICNHH_GetBlockNames().Find((string _) => 
										{ 
											return _ == "event_box_gacha_e" || _ == "event_box_gacha_f"; 
										})) as IMDBGDNPLJA_EventBoxGacha;
										if(evDb != null)
										{
											giftId = evDb.KGDBEMPMAIJ_Boxes[0].GLCLFMGPMAN_ItemId;
										}
										break; // 4003
									}
									case 180009: //前夜祭娘くじ☆抽選券 vc id 220-227 (idx 231-238) + 99(95) + 56-61(55-60)
									{
										// Get the current kuji event
										IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection("event_box_gacha_d") as IMDBGDNPLJA_EventBoxGacha;
										if(evDb != null)
										{
											giftId = evDb.KGDBEMPMAIJ_Boxes[0].GLCLFMGPMAN_ItemId;
										}
										break; // 4002
									}
									case 180005: //娘くじ☆抽選券 vc id 212-219 (223-230) + 196-203(207-214) + 164-171(167-174) + 150-156(145-151) + 129-135(124-130)
													// + 34-49(33-38) + 42-44(41-43) + 5-10(4-9) + 17-22(16-21)
									{
										break; // 4001
									}
									case 180017: //娘くじ☆抽選券 vc id 172-179(183-190) + 76(75) + 62-64(61-63) + 27-32(26-31)
									{
										IMDBGDNPLJA_EventBoxGacha evDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PKOJMBICNHH_GetBlockNames().Find((string _) => 
										{ 
											return _ == "event_box_gacha_a" || _ == "event_box_gacha_b" || _ == "event_box_gacha_c"; 
										})) as IMDBGDNPLJA_EventBoxGacha;
										if(evDb != null)
										{
											giftId = evDb.KGDBEMPMAIJ_Boxes[0].GLCLFMGPMAN_ItemId;
										}
										break; // 4004
									}
									case 180008: //お正月SPガチャチケット vc id 75(74)
										break; // 2004
									case 180016: // マクロスFライブ記念チケット MAcross live comm vc id 65-67(64-66)
										giftId = 170013; // or 170014 ?
										break; // 5002
									case 180010: //超時空お年玉 New Year vc id 46-48(45-47)
										giftId = 170016;
										break; // 5001
									case 180007: //★5確定ガチャチケット vc id 33(32)
										break; // 2003
									case 180006: //★5確定ガチャチケット vc id 26(25)
										break; // 2002
								}
								Products.Add(new ProductInfo() {
									id = (10000000 + item.PPFNGGCBJKC_Id) * 100 + j,
									name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(item.KGOFMDMDFCJ_BonusId[j]),
									original_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(item.KGOFMDMDFCJ_BonusId[j], useJp:true),
									platform_product_id = "UMO_BonusVC."+giftId+"."+item.NNIIINKFDBG_BonusCount[j],
									closed_at = 32503647600,
									price_by_currency = new Dictionary<int, int>() { { bonusItem.CPGFOBNKKBF_CurrencyId, item.NNIIINKFDBG_BonusCount[j] } }
								});
								if(giftId == 0)
								{
									TodoLogger.LogError(TodoLogger.SakashoServer, "Unknow gift for bonus VC "+item.KGOFMDMDFCJ_BonusId[j]+" "+bonusId+" with currency "+bonusItem.CPGFOBNKKBF_CurrencyId+" for vc id "+item.PPFNGGCBJKC_Id+" ("+item.OPFGFINHFCE_Name+", label "+item.DLCGAMHADEN_Label+"), Name : "+EKLNMHFCAOI.INCKKODFJAP_GetItemName(item.KGOFMDMDFCJ_BonusId[j])+" Count : "+item.NNIIINKFDBG_BonusCount[j]);
								}
							}*/
							Products.Add(new ProductInfo() {
								id = (10000000 + item.PPFNGGCBJKC_Id) * 100 + j,
								name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(item.KGOFMDMDFCJ_BonusId[j]),
								original_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(item.KGOFMDMDFCJ_BonusId[j], useJp:true),
								platform_product_id = "UMO_BonusVC."+bonusItem.PPFNGGCBJKC_Id+"."+item.NNIIINKFDBG_BonusCount[j],
								closed_at = 32503647600,
								price_by_currency = new Dictionary<int, int>() { { bonusItem.CPGFOBNKKBF_CurrencyId, item.NNIIINKFDBG_BonusCount[j] } }
							});
                        }
					}
				}

				List<BKPAPCMJKHE_Shop.DNOENEKHGMI> shops = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA.FindAll((BKPAPCMJKHE_Shop.DNOENEKHGMI _) =>
				{
					return _.JPGALGPNJAI_VcId != 0;
				});
				foreach(BKPAPCMJKHE_Shop.DNOENEKHGMI shop in shops)
				{
					List<FJGOKILCBJA> items = FJGOKILCBJA.FKDIMODKKJD(shop.OPKDAIMPJBH_ShopId, shop.EFNMDPKEJIM_LineupId, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
					for(int i = 0; i < items.Count; i++)
					{
						ProductInfo p = Products.Find((ProductInfo _) =>
						{
							return _.label == items[i].KAPMOPMDHJE_Label;
						});
						if(p == null)
						{
							p = new ProductInfo()
							{
								id = 400000 + items[i].KAPMOPMDHJE_Label,
								buy_limit = items[i].ELEPHBOKIGK_BuyLimit,
								closed_at = 32512611600,
								label = items[i].KAPMOPMDHJE_Label,
								name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(items[i].KIJAPOFAGPN_ItemFullId),
								original_name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(items[i].KIJAPOFAGPN_ItemFullId, useJp:true),
								opened_at = 1651330800,
							};
							Products.Add(p);
						}
						int cId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[shop.JPGALGPNJAI_VcId - 1].CPGFOBNKKBF_CurrencyId;
						p.price_by_currency.Add(cId, items[i].DKEPCPPCIKA_Price);
					}
				}
			}

			List<ProductInfo> plist = Products.FindAll((ProductInfo _) =>
			{
				if(productType != -1 && _.productType != productType)
					return false;
				if(label != -1 && _.label != label)
					return false;
				if(currencyId != -1  && _.price_by_currency != null && !_.price_by_currency.ContainsKey(currencyId))
					return false;
				return true;
			});
			if(plist.Count == 0)
			{
				TodoLogger.LogError(TodoLogger.SakashoServer, "Missing product info for "+json);
			}


			UserProducts userProducts = new UserProducts();
			userProducts.Load(playerAccount.playerData.serverData);

			int start = (page - 1) * ipp;
			for(int i = start; i < start + ipp && i < plist.Count; i++)
			{
				EDOHBJAPLPF_JsonData p = new EDOHBJAPLPF_JsonData();
				res["products"].Add(p);

				UserProductInfo up = userProducts.Products.Find((UserProductInfo _) =>
				{
					return _.id == plist[i].id;
				});

				p["bought_quantity"] = up != null ? up.buy_count : 0;
				p["buy_limit"] = plist[i].buy_limit;
				p["closed_at"] = plist[i].closed_at;
				p["closed_at"] = Utility.GetCurrentUnixTime() + 24*3600;
				string str = plist[i].GetDescription();
				p["description"] = str;
				if(plist[i].group_key != "")
					p["group_key"] = plist[i].group_key;
				else
					p["group_key"] = null;
				p["id"] = plist[i].id;
				if(plist[i].imageUrl != "")
					p["imageUrl"] = plist[i].imageUrl;
				else
					p["imageUrl"] = null;
				if(plist[i].item_set_name_for_api != null)
				{
					EDOHBJAPLPF_JsonData set = new EDOHBJAPLPF_JsonData();
					set.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					p["item_set_name_for_api"] = set;
					for(int j = 0; j < plist[i].item_set_name_for_api.Count; j++)
					{
						set.Add(plist[i].item_set_name_for_api[j]);
					}
				}
				p["label"] = plist[i].label;
				p["name"] = plist[i].name;
				p["original_name"] = plist[i].original_name;
				p["opened_at"] = plist[i].opened_at;
				if(plist[i].platform_product_id != "")
					p["platform_product_id"] = plist[i].platform_product_id;
				else
					p["platform_product_id"] = null;
				if(currencyId != -1)
					p["price"] = plist[i].price_by_currency[currencyId];
				else
					p["price"] = plist[i].price_by_currency.First().Value;

				if(plist[i].normal_lot_free_setting != null)
				{
					p["normal_lot_free_setting"] = new EDOHBJAPLPF_JsonData();
					p["normal_lot_free_setting"]["duration_days"] = plist[i].normal_lot_free_setting.duration_days != 0 ? plist[i].normal_lot_free_setting.duration_days : null;
					p["normal_lot_free_setting"]["is_first_time"] = true; // TODO save
					p["normal_lot_free_setting"]["reset_count"] = 0; // ??
					p["normal_lot_free_setting"]["reset_hours"] = null; // ??
				}
			}
			res["next_page"] = plist.Count > page * ipp ? page + 1 : 0;
			res["previous_page"] = page > 1 ? page - 1 : 0;

			/*if(productType == 0 && currencyId == 1001 && label == 10)
			{
				for (int i = 0; i < arrayData.HNBFOAJIIAL_Count; i++)
				{
					if((int)arrayData[i]["label"] == label)
						res["products"].Add(arrayData[i]);
				}
			}
			else if(productType == 0 && currencyId == 3001)
			{
				for (int i = 0; i < arrayData4.HNBFOAJIIAL_Count; i++)
				{
					arrayData4[i]["closed_at"] = Utility.GetCurrentUnixTime() + 24*3600;
					res["products"].Add(arrayData4[i]);
				}
			}
			else if(productType == 0 && currencyId == 2)
			{
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA.Count; i++)
				{
                    DKJMDIFAKKD_VcItem.EBGPAPPHBAH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA[i];
                    if (item.DLCGAMHADEN == label)
					{
						EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
						data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = item.PPFNGGCBJKC;
						data[AFEHLCGHAEE_Strings.GLHKICCPGKJ_platform_product_id] = item.GLHKICCPGKJ.Length > 0 ? item.GLHKICCPGKJ[0] : "UMO."+label+"."+item.PPFNGGCBJKC;
						data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name] = item.OPFGFINHFCE;
						data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description] = "Desc "+item.OPFGFINHFCE;
						data[AFEHLCGHAEE_Strings.KAPMOPMDHJE_label] = label;
						res["products"].Add(data);
					}
				}
			}
			else if(productType == 2 && currencyId == 1001)
			{
				for (int i = 0; i < arrayData2.HNBFOAJIIAL_Count; i++)
				{
					arrayData2[i]["closed_at"] = Utility.GetCurrentUnixTime() + 24*3600;
					res["products"].Add(arrayData2[i]);
				}
			}
			else if(productType == 2 && currencyId == 2101)
			{
				for (int i = 0; i < arrayData3.HNBFOAJIIAL_Count; i++)
				{
					res["products"].Add(arrayData3[i]);
				}
			}*/

			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoPaymentRecover(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);
			return 0;
		}	

		public static int SakashoPaymentGetPurchasingStatus(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.OIJLNFJALJP_aborted_transaction_exists] = false;
			res[AFEHLCGHAEE_Strings.HIAIAJJPCDE_recoverable_products] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.HIAIAJJPCDE_recoverable_products].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoPaymentPurchaseAndSave(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();

			SakashoPaymentPurchaseInternal(json, res);
			EDOHBJAPLPF_JsonData msgData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			SavePlayerData(msgData, res);
			
			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoPaymentPurchase(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();

			SakashoPaymentPurchaseInternal(json, res);

			SendMessage(callbackId, res);
			return 0;
		}

		public static void SakashoPaymentPurchaseInternalProduct(ProductInfo product, EDOHBJAPLPF_JsonData res, int quantity)
		{
			EDOHBJAPLPF_JsonData inv = res[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
			if(product.productType == 2) // gacha
			{
				List<MLIBEPGADJH_Scene.KKLDOOJBJMN> scenesList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.FindAll((MLIBEPGADJH_Scene.KKLDOOJBJMN _) =>
				{
					return _.PPEGAKEIEGM_En == 2/* && _.EKLIPGELKCL_Rarity == 5*/;
				});
				List<string> summons = product.item_set_name_for_api;
				for(int j = 0; j < summons.Count; j++)
				{
					int id = scenesList[UnityEngine.Random.Range(0, scenesList.Count - 1)].BCCHOBPJJKE_Id;
					EDOHBJAPLPF_JsonData invData = new EDOHBJAPLPF_JsonData();
					inv.Add(invData);
					invData[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = id; // long
					invData[AFEHLCGHAEE_Strings.LJGOOOMOMMA_message] = ""; // string
					invData[AFEHLCGHAEE_Strings.HAAJGNCFNJM_item_name] = AFEHLCGHAEE_Strings.COIODGJDJEJ_scene; // string
					invData[AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value] = id; // int
					invData[AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type] = 3; // int
					invData[AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count] = 1; // int
					invData[AFEHLCGHAEE_Strings.INDDJNMPONH_type] = 0; // int
					invData[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at] = Utility.GetCurrentUnixTime(); // long
					invData[AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at] = Utility.GetTargetUnixTime(2030, 1, 1, 0, 0, 0); // long
					invData[AFEHLCGHAEE_Strings.LNDEFMALKAN_received_at] = Utility.GetCurrentUnixTime(); // long
					invData["order"] = j; // long
				}
			}
			else if(product.productType == 0) // shop
			{
				if(product.price_by_currency.ContainsKey(2))
				{
					// VC
					DKJMDIFAKKD_VcItem.EBGPAPPHBAH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA.Find((DKJMDIFAKKD_VcItem.EBGPAPPHBAH _) =>
					{
						return _.PPFNGGCBJKC_Id == product.id % 10000000;
					});
					if(item != null)
					{
						// bought vc, update balance
						AddToBalance(item.CPGFOBNKKBF_Currency, item.HMFFHLPNMPH_Count * quantity);
						GetBalances(res, new List<int>() { item.CPGFOBNKKBF_Currency });
						for(int i = 0; i < item.KGOFMDMDFCJ_BonusId.Length; i++)
						{
							if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(item.KGOFMDMDFCJ_BonusId[i]) == EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
							{
								HHJHIFJIKAC_BonusVc.MNGJPJBCMBH db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[EKLNMHFCAOI.DEACAHNLMNI_getItemId(item.KGOFMDMDFCJ_BonusId[i]) - 1];
								//if(db.INDDJNMPONH == 1)
								//{
									AddToBalance(db.CPGFOBNKKBF_CurrencyId, item.NNIIINKFDBG_BonusCount[i] * quantity);
									GetBalances(res, new List<int>() { db.CPGFOBNKKBF_CurrencyId });
								/*}
								else
								{
									ProductInfo pBonus = Products.Find((ProductInfo _) =>
									{
										return _.id == (10000000 + item.PPFNGGCBJKC_Id) * 100 + i;
									});
									if(pBonus != null)
									{
										SakashoPaymentPurchaseInternalProduct(pBonus, res, quantity);
									}
									else
									{
										TodoLogger.LogError(TodoLogger.SakashoServer, "Bonus not found : "+(10000000 + item.PPFNGGCBJKC_Id) * 100 + i);
									}
								}*/
							}
							else
							{
								TodoLogger.LogError(TodoLogger.SakashoServer, "Bonus not vc "+item.KGOFMDMDFCJ_BonusId[i]);
							}
						}
					}
				}
				else if(product.platform_product_id != null && product.platform_product_id.StartsWith("UMO_BonusVC."))
				{
					string[] strs = product.platform_product_id.Split(new char[] { '.' });
					EDOHBJAPLPF_JsonData invData = new EDOHBJAPLPF_JsonData();
					inv.Add(invData);
					//UnityEngine.Debug.LogError(dbItem2.EJHMPCJNHBP_ItemFullId);
					int id = int.Parse(strs[1]);
					int cnt = int.Parse(strs[2]);
					HHJHIFJIKAC_BonusVc.MNGJPJBCMBH db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[id - 1];
					int itemId = 0;
					switch(db.PPFNGGCBJKC_Id)
					{
						case 15:// 4003 4周年娘くじ☆抽選券 vc id 236-243 (idx 247-253) + 68-73(67-72) + 51-54(50-53)
						case 9: // 4002 前夜祭娘くじ☆抽選券 vc id 220-227 (idx 231-238) + 99(95) + 56-61(55-60)
						case 5: // 4001 娘くじ☆抽選券 vc id 212-219 (223-230) + 196-203(207-214) + 164-171(167-174) + 150-156(145-151) + 129-135(124-130)
													// + 34-49(33-38) + 42-44(41-43) + 5-10(4-9) + 17-22(16-21)
						case 17: // 4004 娘くじ☆抽選券 vc id 172-179(183-190) + 76(75) + 62-64(61-63) + 27-32(26-31)
							// Kuji ticket
						{
							CHHECNJBMLA_EventBoxGacha ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.Find((IKDICBBFBMI_EventBase _) =>
							{
								return _.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.OCCGDMDBCHK_EventGacha;
							}) as CHHECNJBMLA_EventBoxGacha;
							if(ev != null)
							{
								itemId = ev.DIACKBHMKEH_GetCurrentBoxInfo().GLCLFMGPMAN_ItemId;
							}
							else
							{
								TodoLogger.LogError(TodoLogger.SakashoServer, "No gacha event enabled, can't reward a ticket");
							}
						}
						break;
						case 8: //お正月SPガチャチケット vc id 75(74)
							break; // 2004
						case 16: // マクロスFライブ記念チケット MAcross live comm vc id 65-67(64-66)
							itemId = 170013; // or 170014 ?
							break; // 5002
						case 10: //超時空お年玉 New Year vc id 46-48(45-47)
							itemId = 170016;
							break; // 5001
						case 7: //★5確定ガチャチケット vc id 33(32)
							break; // 2003
						case 6: //★5確定ガチャチケット vc id 26(25)
							break; // 2002
					}
					if(itemId != 0)
					{
						invData[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = itemId; // long
						invData[AFEHLCGHAEE_Strings.LJGOOOMOMMA_message] = ""; // string
						MFDJIFIIPJD data = new MFDJIFIIPJD();
						data.KHEKNNFCAOI(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(itemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(itemId), 0);
						invData[AFEHLCGHAEE_Strings.HAAJGNCFNJM_item_name] = data.HAAJGNCFNJM_ItemName; // string
						invData[AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value] = data.NNFNGLJOKKF_ItemId; // int
						invData[AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type] = 0; // int
						invData[AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count] = cnt * quantity; // int
						invData[AFEHLCGHAEE_Strings.INDDJNMPONH_type] = 0; // int
						invData[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at] = Utility.GetCurrentUnixTime(); // long
						invData[AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at] = Utility.GetTargetUnixTime(2030, 1, 1, 0, 0, 0); // long
						invData[AFEHLCGHAEE_Strings.LNDEFMALKAN_received_at] = Utility.GetCurrentUnixTime(); // long
						invData["order"] = 0; // long
					}
					else
					{
						TodoLogger.LogError(TodoLogger.SakashoServer, "Could not find an item for vc bonus item "+db.PPFNGGCBJKC_Id);
					}
				}
				else
				{
					BKPAPCMJKHE_Shop.BOMCAJJCPME dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI.Find((BKPAPCMJKHE_Shop.BOMCAJJCPME _) =>
					{
						return _.ICKAMKNDAEB == product.label;
					});
					if(dbItem != null)
					{
						BKPAPCMJKHE_Shop.GPNPMJJKONJ dbItem2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbItem.GJGNOFAPFJD - 1];
						EDOHBJAPLPF_JsonData invData = new EDOHBJAPLPF_JsonData();
						inv.Add(invData);
						//UnityEngine.Debug.LogError(dbItem2.EJHMPCJNHBP_ItemFullId);
						invData[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = dbItem2.EJHMPCJNHBP_ItemFullId; // long
						invData[AFEHLCGHAEE_Strings.LJGOOOMOMMA_message] = ""; // string
						MFDJIFIIPJD data = new MFDJIFIIPJD();
						data.KHEKNNFCAOI(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(dbItem2.EJHMPCJNHBP_ItemFullId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(dbItem2.EJHMPCJNHBP_ItemFullId), 0);
						invData[AFEHLCGHAEE_Strings.HAAJGNCFNJM_item_name] = data.HAAJGNCFNJM_ItemName; // string
						invData[AFEHLCGHAEE_Strings.OCNINMIMHGC_item_value] = data.NNFNGLJOKKF_ItemId; // int
						invData[AFEHLCGHAEE_Strings.MJBKGOJBPAD_item_type] = 0; // int
						invData[AFEHLCGHAEE_Strings.MBJIFDBEDAC_item_count] = dbItem2.LBCNKLPIMHL_Count * quantity; // int
						invData[AFEHLCGHAEE_Strings.INDDJNMPONH_type] = 0; // int
						invData[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at] = Utility.GetCurrentUnixTime(); // long
						invData[AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at] = Utility.GetTargetUnixTime(2030, 1, 1, 0, 0, 0); // long
						invData[AFEHLCGHAEE_Strings.LNDEFMALKAN_received_at] = Utility.GetCurrentUnixTime(); // long
						invData["order"] = 0; // long
					}
					else
					{
						TodoLogger.LogError(TodoLogger.SakashoServer, "Unknown shop label "+product.label);
					}
				}
			}
		}

		public static void SakashoPaymentPurchaseInternal(string json, EDOHBJAPLPF_JsonData res)
		{
			res[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories] = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData inv = res[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
			inv.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			//{"quantity":1, "productId":429930, "currencyId":1001} gacha
			//{"quantity":11, "productId":428666, "currencyId":3001} // buy shop
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			int pId = (int)req["productId"];
			int quantity = (int)req["quantity"];
			ProductInfo product = Products.Find((ProductInfo _) =>
			{
				return _.id == pId;
			});
			if(product != null)
			{
				int currency = (int)req["currencyId"];
				if(!product.price_by_currency.ContainsKey(currency))
				{
					UnityEngine.Debug.LogError("Can't buy with this currency "+json);
				}
				else
				{
					SakashoPaymentPurchaseInternalProduct(product, res, quantity);
					if(currency != 2)
					{
						ConsumeCurrency(currency, product.price_by_currency[currency] * quantity);
						GetBalances(res, new List<int>() { currency });
					}
				}

				UserProducts userProducts = new UserProducts();
				userProducts.Load(playerAccount.playerData.serverData);
				UserProductInfo p = userProducts.Products.Find((UserProductInfo _) =>
				{
					return _.id == product.id;
				});
				if(p == null)
				{
					p = new UserProductInfo();
					p.id = product.id;
					userProducts.Products.Add(p);
				}
				p.buy_count += quantity;

				userProducts.Save(playerAccount.playerData.serverData);
				SaveAccountServerData();

			}
			else
			{
				TodoLogger.LogError(TodoLogger.SakashoServer, "Unknown product "+pId+" "+json);
			}

			//BOKJNFPGGIB EFHCKFKLJDK_purchased_virtual_currency 
			//List<BOKJNFPGGIB> DPHEHNKLHEI_gained_virtual_currencies
			//PFIJNPCEOIL JENBPPBNAHP_player_normal_lot_free_state
		}
	}
}

		/*static EDOHBJAPLPF_JsonData arrayData2 = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
			{
				""bought_quantity"": 0,
				""buy_limit"": 1,
				""closed_at"": 32503647600,
				""description"": ""{\r\n  \""banner_id\"":30021,\r\n  \""bg_id\"":\""pl=13\"",\r\n  \""day_count\"":0,\r\n  \""disable_carousel\"":1,\r\n  \""feature\"":\""13,121,206,62,73,85,134,145,157,25\"",\r\n  \""group_id\"":30023,\r\n  \""kakutei\"":5,\r\n  \""name\"":\""\u30c7\u30d3\u30e5\u30fc\u30ac\u30c1\u30e3\"",\r\n  \""open_time\"":1556636400,\r\n  \""templ\"":\""gacha_debut_detail_30021\"",\r\n  \""view_order\"":48132221017718819\r\n}"",
				""group_key"": null,
				""id"": 178088,
				""imageUrl"": null,
				""item_set_name_for_api"": [
					""normal_lot_3_0023_0_assured"",
					""normal_lot_3_0023_1_rare4only"",
					""normal_lot_3_0023_0_assured"",
					""normal_lot_3_0023_0_assured"",
					""normal_lot_3_0023_0_assured"",
					""normal_lot_3_0023_0_assured"",
					""normal_lot_3_0023_0_assured"",
					""normal_lot_3_0023_0_assured"",
					""normal_lot_3_0023_0_assured"",
					""normal_lot_3_0023_0_assured""
				],
				""label"": 3002304,
				""name"": ""\u26055\u78ba\u5b9a\u30c7\u30d3\u30e5\u30fc\u30ac\u30c1\u30e322 10\u9023"",
				""opened_at"": 1556636400,
				""platform_product_id"": null,
				""price"": 300
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1656558000,
				""description"": ""{\n  \""banner_id\"":101001,\n  \""bg_id\"":\""gc=101008\"",\n  \""cost_item_id\"":240002,\n  \""day_count\"":0,\n  \""desc\"":\""\u26055\u78ba\u5b9a\u30b5\u30fc\u30d3\u30b9\u30c1\u30b1\u30c3\u30c8\u3092\u6d88\u8cbb\u3057\n\u26055\u306e\u30d7\u30ec\u30fc\u30c8\u3092\u5165\u624b\u3067\u304d\u307e\u3059\u3002\n\u203b2022/3/31\u30e9\u30a4\u30f3\u30ca\u30c3\u30d7\u66f4\u65b0\"",\n  \""disable_carousel\"":1,\n  \""free_badge_mess\"":\""\"",\n  \""free_texture_id\"":0,\n  \""group_id\"":101008,\n  \""label\"":\""popup_gacha_pass_rate_warning\"",\n  \""name\"":\""\u26055\u78ba\u5b9a\u30b5\u30fc\u30d3\u30b9\u30ac\u30c1\u30e3\"",\n  \""open_time\"":1648695600,\n  \""sale_button_visible\"":0,\n  \""templ\"":\""gacha_item_detail\"",\n  \""ver\"":2,\n  \""view_order\"":38327875832643584\n}"",
				""group_key"": null,
				""id"": 429267,
				""imageUrl"": null,
				""item_set_name_for_api"": [
					""normal_lot_10_1008_0_rare4only""
				],
				""label"": 10100801,
				""name"": ""\u26055\u78ba\u5b9a\u30b5\u30fc\u30d3\u30b9\u30ac\u30c1\u30e38"",
				""opened_at"": 1648695600,
				""platform_product_id"": null,
				""price"": 1
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1656428400,
				""description"": ""{\n  \""banner_id\"":10001,\n  \""bg_id\"":\""gc=10001\"",\n  \""day_count\"":0,\n  \""desc\"":\""\n\u671d\u30fb\u663c\u30fb\u591c\n1\u65e5\u306b3\u56de\u6b4c\u6676\u77f3\u306a\u3057\u3067\u3082\u5f15\u3051\u308b\u30ac\u30c1\u30e3\u3067\u3059\u3002\n\n\u300c\u3053\u3093\u306a\u30b5\u30fc\u30d3\u30b91\u65e53\u56de\u3057\u304b\u3057\u306a\u3044\u3093\u3060\u304b\u3089\u306d\uff01\u300d\n\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\u3000\uff0d\u30b7\u30a7\u30ea\u30eb\u30fb\u30ce\u30fc\u30e0\uff0d\"",\n  \""disable_carousel\"":1,\n  \""free_badge_mess\"":\""\"",\n  \""free_texture_id\"":0,\n  \""group_id\"":10318,\n  \""name\"":\""\u30b5\u30fc\u30d3\u30b9\u30ac\u30c1\u30e3\"",\n  \""open_time\"":1650596400,\n  \""sale_button_visible\"":0,\n  \""ver\"":2\n}"",
				""group_key"": null,
				""id"": 429712,
				""imageUrl"": null,
				""item_set_name_for_api"": [
					""normal_lot_1_0318_0""
				],
				""label"": 1031801,
				""name"": ""\u30b5\u30fc\u30d3\u30b9\u30ac\u30c1\u30e3317"",
				""opened_at"": 1650596400,
				""platform_product_id"": null,
				""price"": 2
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1656428400,
				""description"": ""{\n  \""banner_id\"":100001,\n  \""bg_id\"":\""gc=100001\"",\n  \""cost_item_id\"":240001,\n  \""day_count\"":0,\n  \""desc\"":\""\u8d85\u6642\u7a7a\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8\u3092\u6d88\u8cbb\u3057\u3066\n\u26051\uff5e\u26056\u306e\u30d7\u30ec\u30fc\u30c8\u3092\u5165\u624b\u3067\u304d\u307e\u3059\u3002\n\u203b2022/5/1\u30e9\u30a4\u30f3\u30ca\u30c3\u30d7\u66f4\u65b0\"",\n  \""disable_carousel\"":1,\n  \""free_badge_mess\"":\""\"",\n  \""free_texture_id\"":0,\n  \""group_id\"":100045,\n  \""label\"":\""popup_gacha_pass_rate_warning\"",\n  \""name\"":\""\u8d85\u6642\u7a7a\u30ac\u30c1\u30e3\"",\n  \""open_time\"":1651330800,\n  \""sale_button_visible\"":0,\n  \""templ\"":\""gacha_pass_detail\"",\n  \""ver\"":2,\n  \""view_order\"":38323739779137536\n}"",
				""group_key"": null,
				""id"": 429927,
				""imageUrl"": null,
				""item_set_name_for_api"": [
					""normal_lot_10_0045_0""
				],
				""label"": 10004501,
				""name"": ""\u8d85\u6642\u7a7a\u30ac\u30c1\u30e345"",
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""price"": 1
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1656396000,
				""description"": ""{\n  \""bg_id\"":\""gc=41252\"",\n  \""day_count\"":0,\n  \""disable_carousel\"":0,\n  \""free_badge_mess\"":\""1\u56de\u7121\u6599\uff01\"",\n  \""free_texture_id\"":0,\n  \""group_id\"":41252,\n  \""label\"":\""popup_gacha_once_rate_warning\"",\n  \""name\"":\""\u26055\u4ee5\u4e0a\u78ba\u5b9a\u30ac\u30c1\u30e3\"",\n  \""open_time\"":1651330800,\n  \""sale_button_visible\"":0,\n  \""templ\"":\""gacha_season_detail_41252\"",\n  \""ver\"":2,\n  \""view_order\"":52531521659076608\n}"",
				""group_key"": null,
				""id"": 429928,
				""imageUrl"": null,
				""item_set_name_for_api"": [
					""normal_lot_4_1252_0_rare4only""
				],
				""label"": 4125201,
				""name"": ""\u30d4\u30c3\u30af\u30a2\u30c3\u30d7\u30ac\u30c1\u30e3159"",
				""normal_lot_free_setting"": {
					""duration_days"": null,
					""is_first_time"": true,
					""reset_count"": 0,
					""reset_hours"": null
				},
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""player_normal_lot_free_state"": {
					""is_next_free"": true
				},
				""price"": 50
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1656396000,
				""description"": ""{\r\n  \""bg_id\"":\""gc=41252\"",\r\n  \""day_count\"":0,\r\n  \""disable_carousel\"":0,\r\n  \""free_badge_mess\"":\""1\u56de\u7121\u6599\uff01\"",\r\n  \""free_texture_id\"":0,\r\n  \""group_id\"":41252,\r\n  \""kakutei\"":\""\u26055\u4ee5\u4e0a10\u679a\u78ba\u5b9a\"",\r\n  \""label\"":\""popup_gacha_once_rate_warning\"",\r\n  \""name\"":\""\u26055\u4ee5\u4e0a\u78ba\u5b9a\u30ac\u30c1\u30e3\"",\r\n  \""open_time\"":1651330800,\r\n  \""sale_button_visible\"":0,\r\n  \""templ\"":\""gacha_season_detail_41252\"",\r\n  \""ver\"":2,\r\n  \""view_order\"":52531521659076608\r\n}"",
				""group_key"": null,
				""id"": 429929,
				""imageUrl"": null,
				""item_set_name_for_api"": [
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_1_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only""
				],
				""label"": 4125202,
				""name"": ""\u30d4\u30c3\u30af\u30a2\u30c3\u30d7\u30ac\u30c1\u30e3159 10\u9023"",
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""price"": 500
			},
			{
				""bought_quantity"": 0,
				""buy_limit"": 1,
				""closed_at"": 1656396000,
				""description"": ""{\r\n  \""bg_id\"":\""gc=41252\"",\r\n  \""day_count\"":0,\r\n  \""disable_carousel\"":0,\r\n  \""free_badge_mess\"":\""1\u56de\u7121\u6599\uff01\"",\r\n  \""free_texture_id\"":0,\r\n  \""group_id\"":41252,\r\n  \""kakutei\"":\""\u26055\u4ee5\u4e0a10\u679a\u78ba\u5b9a\"",\r\n  \""label\"":\""popup_gacha_once_rate_warning\"",\r\n  \""name\"":\""\u26055\u4ee5\u4e0a\u78ba\u5b9a\u30ac\u30c1\u30e3\"",\r\n  \""open_time\"":1651330800,\r\n  \""sale_button_visible\"":0,\r\n  \""templ\"":\""gacha_season_detail_41252\"",\r\n  \""ver\"":2,\r\n  \""view_order\"":52531521659076608\r\n}"",
				""group_key"": null,
				""id"": 429930,
				""imageUrl"": null,
				""item_set_name_for_api"": [
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_1_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only""
				],
				""label"": 4125204,
				""name"": ""\u30d4\u30c3\u30af\u30a2\u30c3\u30d7\u30ac\u30c1\u30e3159 10\u9023 \u521d\u56de"",
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""price"": 300
			},
			{
				""bought_quantity"": 1,
				""buy_limit"": 10,
				""closed_at"": 1654441200,
				""description"": ""{\n  \""bg_id\"":\""gc=31096\"",\n  \""day_count\"":0,\n  \""disable_carousel\"":0,\n  \""free_badge_mess\"":\""10\u9023\u7121\u6599\"",\n  \""free_multi\"":\""1\u65e51\u56de\\n\u7121\u6599\uff01\"",\n  \""free_only\"":1,\n  \""free_texture_id\"":0,\n  \""group_id\"":31096,\n  \""label\"":\""popup_gacha_pass_rate_warning\"",\n  \""name\"":\""\u7121\u659910\u9023\u30ac\u30c1\u30e3\"",\n  \""one_day\"":1,\n  \""open_time\"":1653577200,\n  \""sale_button_visible\"":0,\n  \""show_popup\"":0,\n  \""templ\"":\""gacha_season_detail_31096\"",\n  \""ver\"":2,\n  \""view_order\"":67124600760172544\n}"",
				""group_key"": null,
				""id"": 430020,
				""imageUrl"": null,
				""item_set_name_for_api"": [
					""normal_lot_3_1096_0_assured"",
					""normal_lot_3_1096_0_assured"",
					""normal_lot_3_1096_0_assured"",
					""normal_lot_3_1096_0_assured"",
					""normal_lot_3_1096_0_assured"",
					""normal_lot_3_1096_0_assured"",
					""normal_lot_3_1096_0_assured"",
					""normal_lot_3_1096_0_assured"",
					""normal_lot_3_1096_0_assured"",
					""normal_lot_3_1096_0_assured""
				],
				""label"": 3109604,
				""name"": ""\u304a\u5f97\u30ac\u30c1\u30e331096 10\u9023"",
				""normal_lot_free_setting"": {
					""duration_days"": 1,
					""is_first_time"": false,
					""reset_count"": null,
					""reset_hours"": 0
				},
				""opened_at"": 1653577140,
				""platform_product_id"": null,
				""player_normal_lot_free_state"": {
					""is_next_free"": false,
					""next_time_at"": null
				},
				""price"": 1000000
			}
		]");*/

		/*static EDOHBJAPLPF_JsonData arrayData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 32520895200,
				""description"": ""\u30b2\u30fc\u30e0\u4e2d\u306b\u30b3\u30f3\u30c6\u30cb\u30e5\u30fc\u3067\u304d\u307e\u3059\u3002"",
				""group_key"": null,
				""id"": 67554,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 10,
				""name"": ""\u30b3\u30f3\u30c6\u30cb\u30e5\u30fc"",
				""opened_at"": 1497856800,
				""platform_product_id"": null,
				""price"": 10
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 32520895200,
				""description"": ""\u30b9\u30bf\u30df\u30ca\u56de\u5fa9"",
				""group_key"": null,
				""id"": 67572,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 10,
				""name"": ""\u30b9\u30bf\u30df\u30ca\u56de\u5fa9"",
				""opened_at"": 1497870000,
				""platform_product_id"": null,
				""price"": 10
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 32525902800,
				""description"": ""VOP\u9ad8\u901f\u5b8c\u4e86\u306e\u5b9f\u884c\u306b\u4f7f\u7528\u3057\u307e\u3059\u3002"",
				""group_key"": null,
				""id"": 153192,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 10,
				""name"": ""VOP\u9ad8\u901f\u5b8c\u4e86"",
				""opened_at"": 1535342400,
				""platform_product_id"": null,
				""price"": 5
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 32512611600,
				""description"": ""AP\u56de\u5fa9"",
				""group_key"": null,
				""id"": 167079,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 10,
				""name"": ""AP\u56de\u5fa9"",
				""normal_lot_free_setting"": {
					""duration_days"": null,
					""is_first_time"": false,
					""reset_count"": null,
					""reset_hours"": null
				},
				""opened_at"": 1552575600,
				""platform_product_id"": null,
				""player_normal_lot_free_state"": {
					""is_next_free"": false
				},
				""price"": 10
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 32530057200,
				""description"": ""AP\u56de\u5fa9(\u5c0f)"",
				""group_key"": null,
				""id"": 222423,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 10,
				""name"": ""AP\u56de\u5fa92"",
				""opened_at"": 1570086000,
				""platform_product_id"": null,
				""price"": 5
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 32530057200,
				""description"": ""AP\u56de\u5fa9\uff08\u5927\uff09"",
				""group_key"": null,
				""id"": 222424,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 10,
				""name"": ""AP\u56de\u5fa93"",
				""opened_at"": 1570086000,
				""platform_product_id"": null,
				""price"": 20
			}
		]");*/

		/*static EDOHBJAPLPF_JsonData arrayData3 = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1656396000,
				""description"": ""{\n  \""bg_id\"":\""gc=41252\"",\n  \""day_count\"":0,\n  \""disable_carousel\"":0,\n  \""free_badge_mess\"":\""1\u56de\u7121\u6599\uff01\"",\n  \""free_texture_id\"":0,\n  \""group_id\"":41252,\n  \""label\"":\""popup_gacha_once_rate_warning\"",\n  \""name\"":\""\u26055\u4ee5\u4e0a\u78ba\u5b9a\u30ac\u30c1\u30e3\"",\n  \""open_time\"":1651330800,\n  \""sale_button_visible\"":0,\n  \""templ\"":\""gacha_season_detail_41252\"",\n  \""ver\"":2,\n  \""view_order\"":52531521659076608\n}"",
				""group_key"": null,
				""id"": 429928,
				""imageUrl"": null,
				""item_set_name_for_api"": [
					""normal_lot_4_1252_0_rare4only""
				],
				""label"": 4125201,
				""name"": ""\u30d4\u30c3\u30af\u30a2\u30c3\u30d7\u30ac\u30c1\u30e3159"",
				""normal_lot_free_setting"": {
					""duration_days"": null,
					""is_first_time"": true,
					""reset_count"": 0,
					""reset_hours"": null
				},
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""player_normal_lot_free_state"": {
					""is_next_free"": true
				},
				""price"": 1
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1656396000,
				""description"": ""{\r\n  \""bg_id\"":\""gc=41252\"",\r\n  \""day_count\"":0,\r\n  \""disable_carousel\"":0,\r\n  \""free_badge_mess\"":\""1\u56de\u7121\u6599\uff01\"",\r\n  \""free_texture_id\"":0,\r\n  \""group_id\"":41252,\r\n  \""kakutei\"":\""\u26055\u4ee5\u4e0a10\u679a\u78ba\u5b9a\"",\r\n  \""label\"":\""popup_gacha_once_rate_warning\"",\r\n  \""name\"":\""\u26055\u4ee5\u4e0a\u78ba\u5b9a\u30ac\u30c1\u30e3\"",\r\n  \""open_time\"":1651330800,\r\n  \""sale_button_visible\"":0,\r\n  \""templ\"":\""gacha_season_detail_41252\"",\r\n  \""ver\"":2,\r\n  \""view_order\"":52531521659076608\r\n}"",
				""group_key"": null,
				""id"": 429929,
				""imageUrl"": null,
				""item_set_name_for_api"": [
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_1_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only"",
					""normal_lot_4_1252_0_rare4only""
				],
				""label"": 4125202,
				""name"": ""\u30d4\u30c3\u30af\u30a2\u30c3\u30d7\u30ac\u30c1\u30e3159 10\u9023"",
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""price"": 10
			}
		]");*/

		/*static EDOHBJAPLPF_JsonData arrayData4 = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
			{
				""bought_quantity"": 0,
				""buy_limit"": 5,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428662,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 39,
				""name"": ""2022\u5e74\u6625 5\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u5e78\u904b\u306e\u714c\u77f3\u00d71\uff08\u8cfc\u5165\u5236\u9650\u6709\uff065\u6708\uff09"",
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""price"": 2200
			},
			{
				""bought_quantity"": 0,
				""buy_limit"": 10,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428665,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 40,
				""name"": ""2022\u5e74\u6625 5\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u5e78\u904b\u306e\u8f1d\u77f3\u00d71\uff08\u8cfc\u5165\u5236\u9650\u6709\uff065\u6708\uff09"",
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""price"": 500
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428666,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 41,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u661f\u306e\u7d50\u6676\uff08\u5c0f\uff09\u00d75"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 30
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428667,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 42,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u661f\u306e\u7d50\u6676\uff08\u4e2d\uff09\u00d75"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 60
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428668,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 43,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u661f\u306e\u7d50\u6676\uff08\u5927\uff09\u00d75"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 120
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428669,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 44,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u611b\u306e\u7d50\u6676\uff08\u5c0f\uff09\u00d75"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 30
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428670,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 45,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u611b\u306e\u7d50\u6676\uff08\u4e2d\uff09\u00d75"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 60
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428671,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 46,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u611b\u306e\u7d50\u6676\uff08\u5927\uff09\u00d75"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 120
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428672,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 47,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u547d\u306e\u7d50\u6676\uff08\u5c0f\uff09\u00d75"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 30
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428673,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 48,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u547d\u306e\u7d50\u6676\uff08\u4e2d\uff09\u00d75"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 60
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428674,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 49,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u547d\u306e\u7d50\u6676\uff08\u5927\uff09\u00d75"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 120
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428675,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 50,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30e1\u30ed\u30c7\u30a3\u30b9\u30c8\u30fc\u30f3\uff08\u5c0f\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 10
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428676,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 51,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30e1\u30ed\u30c7\u30a3\u30b9\u30c8\u30fc\u30f3\uff08\u4e2d\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 20
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428677,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 52,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30e1\u30ed\u30c7\u30a3\u30b9\u30c8\u30fc\u30f3\uff08\u5927\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 30
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428678,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 56,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30bd\u30a6\u30eb\u30b9\u30c8\u30fc\u30f3\uff08\u5c0f\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 20
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428679,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 57,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30bd\u30a6\u30eb\u30b9\u30c8\u30fc\u30f3\uff08\u4e2d\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 40
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428680,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 58,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30bd\u30a6\u30eb\u30b9\u30c8\u30fc\u30f3\uff08\u5927\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 80
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428681,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 59,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30dc\u30a4\u30b9\u30b9\u30c8\u30fc\u30f3\uff08\u5c0f\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 20
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428682,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 60,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30dc\u30a4\u30b9\u30b9\u30c8\u30fc\u30f3\uff08\u4e2d\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 40
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428683,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 61,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30dc\u30a4\u30b9\u30b9\u30c8\u30fc\u30f3\uff08\u5927\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 80
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428684,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 62,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30c1\u30e3\u30fc\u30e0\u30b9\u30c8\u30fc\u30f3\uff08\u5c0f\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 20
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428685,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 63,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30c1\u30e3\u30fc\u30e0\u30b9\u30c8\u30fc\u30f3\uff08\u4e2d\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 40
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428686,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 64,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30c1\u30e3\u30fc\u30e0\u30b9\u30c8\u30fc\u30f3\uff08\u5927\uff09\u00d720"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 80
			},
			{
				""bought_quantity"": null,
				""buy_limit"": 0,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428687,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 65,
				""name"": ""2022\u5e74\u6625 2\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1aUC\u00d72000"",
				""opened_at"": 1646017200,
				""platform_product_id"": null,
				""price"": 10
			},
			{
				""bought_quantity"": 0,
				""buy_limit"": 1,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428690,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 66,
				""name"": ""2022\u5e74\u6625 5\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u26055\u78ba\u5b9a\u30ac\u30c1\u30e3\u30c1\u30b1\u00d71\uff08\u8cfc\u5165\u5236\u9650\u6709\uff065\u6708\uff09"",
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""price"": 3000
			},
			{
				""bought_quantity"": 0,
				""buy_limit"": 20,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428693,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 67,
				""name"": ""2022\u5e74\u6625 5\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u8d85\u6642\u7a7a\u30ac\u30c1\u30e3\u30c1\u30b1\u00d71\uff08\u8cfc\u5165\u5236\u9650\u6709\uff065\u6708\uff09"",
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""price"": 200
			},
			{
				""bought_quantity"": 0,
				""buy_limit"": 1,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428696,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 68,
				""name"": ""2022\u5e74\u6625 5\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a\u30b7\u30fc\u30af\u30ec\u30c3\u30c8\u30b9\u30c8\u30fc\u30f3\u00d71\uff08\u8cfc\u5165\u5236\u9650\u6709\uff065\u6708\uff09"",
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""price"": 6000
			},
			{
				""bought_quantity"": 0,
				""buy_limit"": 1,
				""closed_at"": 1655305199,
				""description"": null,
				""group_key"": null,
				""id"": 428699,
				""imageUrl"": null,
				""item_set_name_for_api"": null,
				""label"": 69,
				""name"": ""2022\u5e74\u6625 5\u6708 : \u6625\u30b9\u30d5\u30a3\u30a2\uff1a \u30a8\u30d4\u30bd\u30fc\u30c9\u30aa\u30fc\u30d6\uff08\u5927\uff09\u00d71\uff08\u8cfc\u5165\u5236\u9650\u6709\uff065\u6708\uff09"",
				""opened_at"": 1651330800,
				""platform_product_id"": null,
				""price"": 500
			}
		]");*/

			/*EDOHBJAPLPF_JsonData arrayData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
				{
					""description"": ""\u30b2\u30fc\u30e0\u5185\u3067\u8cfc\u5165\u3067\u304d\u308b\u4eee\u60f3\u901a\u8ca8"",
					""free"": 0,
					""id"": 1001,
					""name"": ""\u6b4c\u6676\u77f3"",
					""paid"": 9999,
					""total"": 9999

				},
				{
					""description"": ""\u6b4c\u6676\u77f3\u8cfc\u5165\u306e\u304a\u307e\u3051 (3/1\uff5e5/31)"",
					""free"": 0,
					""id"": 3001,
					""name"": ""\u30b9\u30d7\u30ea\u30f3\u30b0\u30b9\u30d5\u30a3\u30a2"",
					""paid"": 9999,
					""total"": 9999

				},
				{
					""description"": ""\u6b4c\u6676\u77f3\u8cfc\u5165\u306e\u304a\u307e\u3051 (6/1\uff5e8/31)"",
					""free"": 0,
					""id"": 3002,
					""name"": ""\u30b5\u30de\u30fc\u30b9\u30d5\u30a3\u30a2"",
					""paid"": 9999,
					""total"": 9999

				},
				{
					""description"": ""\u6b4c\u6676\u77f3\u8cfc\u5165\u306e\u304a\u307e\u3051 (9/1\uff5e11/30)"",
					""free"": 0,
					""id"": 3003,
					""name"": ""\u30aa\u30fc\u30bf\u30e0\u30b9\u30d5\u30a3\u30a2"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u6b4c\u6676\u77f3\u8cfc\u5165\u306e\u304a\u307e\u3051 (12/1\uff5e2/28)"",
					""free"": 0,
					""id"": 3004,
					""name"": ""\u30a6\u30a3\u30f3\u30bf\u30fc\u30b9\u30d5\u30a3\u30a2"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u5a18\u304f\u3058\u2606\u62bd\u9078\u7528"",
					""free"": 0,
					""id"": 4001,
					""name"": ""\u5a18\u304f\u3058\u2606\u62bd\u9078\u5238"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u26055\u78ba\u5b9a\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2002,
					""name"": ""\u26055\u78ba\u5b9a\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8A"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u26055\u78ba\u5b9a\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2003,
					""name"": ""\u26055\u78ba\u5b9a\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8B"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u26055\u78ba\u5b9a\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2004,
					""name"": ""\u26055\u78ba\u5b9a\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8C"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u5a18\u304f\u3058\u2606\u62bd\u9078\u7528"",
					""free"": 0,
					""id"": 4002,
					""name"": ""\u5a18\u304f\u3058\u2606\u62bd\u9078\u5238B"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u304a\u5e74\u7389\u7528\u901a\u8ca8"",
					""free"": 0,
					""id"": 5001,
					""name"": ""\u304a\u5e74\u7389"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2101,
					""name"": ""\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30ed\u30b0\u30dc\u7528\u306e\u26055\u78ba\u5b9a\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2008,
					""name"": ""\u26055\u78ba\u5b9a\u30ed\u30b0\u30dc\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8\u30005\u6708"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30ed\u30b0\u30dc\u7528\u306e\u26055\u78ba\u5b9a\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2009,
					""name"": ""\u26055\u78ba\u5b9a\u30ed\u30b0\u30dc\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8\u30006\u6708"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30ed\u30b0\u30dc\u7528\u306e\u26055\u78ba\u5b9a\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2010,
					""name"": ""\u26055\u78ba\u5b9a\u30ed\u30b0\u30dc\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8\u30007\u6708"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u5a18\u304f\u3058\u2606\u62bd\u9078\u7528"",
					""free"": 0,
					""id"": 4003,
					""name"": ""\u5a18\u304f\u3058\u2606\u62bd\u9078\u5238C"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30b5\u30de\u30fc\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 5002,
					""name"": ""\u30b5\u30de\u30fc\u30c1\u30b1\u30c3\u30c8"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u5a18\u30af\u30b8\u2606\u62bd\u9078\u7528"",
					""free"": 0,
					""id"": 4004,
					""name"": ""\u5a18\u304f\u3058\u2606\u62bd\u9078\u5238D"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u8863\u88c5\u89e3\u653e\u30d7\u30ec\u30fc\u30c8\u4ea4\u63db\u5238"",
					""free"": 0,
					""id"": 3005,
					""name"": ""\u8863\u88c5\u89e3\u653e\u30d7\u30ec\u30fc\u30c8\u4ea4\u63db\u5238"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u53ce\u96c6\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2201,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u53ce\u96c6A)"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u53ce\u96c6\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2202,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u53ce\u96c6B)"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u53ce\u96c6\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2203,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u53ce\u96c6C)"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30df\u30c3\u30b7\u30e7\u30f3\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2204,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u30df\u30c3\u30b7\u30e7\u30f3A)"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30df\u30c3\u30b7\u30e7\u30f3\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2205,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u30df\u30c3\u30b7\u30e7\u30f3B)"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30df\u30c3\u30b7\u30e7\u30f3\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2206,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u30df\u30c3\u30b7\u30e7\u30f3C)"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30d0\u30c8\u30eb\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2207,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u6b4c\u59eb-\u30d0\u30c8\u30ebA)"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30d0\u30c8\u30eb\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2208,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u6b4c\u59eb-\u30d0\u30c8\u30ebB)"",
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u30d0\u30c8\u30eb\u30a4\u30d9\u30f3\u30c8\u5831\u916c\u7528\u3001\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": 0,
					""id"": 2209,
					""name"": ""\u30a4\u30d9\u30f3\u30c8\u30ac\u30c1\u30e3\u30c1\u30b1\u30c3\u30c8(\u6b4c\u59eb-\u30d0\u30c8\u30ebC)"",
					""paid"": 0,
					""total"": 0

				}
			]");*/
