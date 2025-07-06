using System.Collections;
using System.Collections.Generic;
using Sakasho.JSON;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public class UserInventoryItem
		{
			public int id;
			public int item_count;
			public string item_name; // normalized name
			public int item_type; // ?
			public int item_value; // full item id
			public string message;
			public long received_at;
			public long closed_at;
			public long created_at;
			public int type;


			public void Load(EDOHBJAPLPF_JsonData data)
			{
				id = (int)data["id"];
				item_count = (int)data["item_count"];
				item_name = (string)data["item_name"];
				item_type = (int)data["item_type"];
				item_value = (int)data["item_value"];
				message = (string)data["message"];
				received_at = JsonUtil.GetLong(data, "received_at", 0);
				closed_at = JsonUtil.GetLong(data, "closed_at", 0);
				created_at = JsonUtil.GetLong(data, "created_at", 0);
				type = (int)data["type"];
			}

			public EDOHBJAPLPF_JsonData Save()
			{
				EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
				res["id"] = id;
				res["item_count"] = item_count;
				res["item_name"] = item_name;
				res["item_type"] = item_type;
				res["item_value"] = item_value;
				res["message"] = message;
				res["received_at"] = received_at;
				res["closed_at"] = closed_at;
				res["created_at"] = created_at;
				res["type"] = type;
				return res;
			}

			public void AddInInventoryResult(EDOHBJAPLPF_JsonData data)
			{
				EDOHBJAPLPF_JsonData invItem = new EDOHBJAPLPF_JsonData();
				data["inventories"].Add(invItem);
				invItem["created_at"] = created_at;
				invItem["id"] = id;
				invItem["item_count"] = item_count;
				invItem["item_name"] = item_name;
				invItem["item_type"] = item_type;
				invItem["item_value"] = item_value;
				invItem["message"] = message;
				invItem["type"] = type;
				data["inventory_ids"].Add(id);
			}
		}

		class UserInventory
		{
			public int LastId = 0;
			public List<UserInventoryItem> Items = new List<UserInventoryItem>();
			//public List<UserInventoryItem> HistoryItems = new List<UserInventoryItem>();


			public void Load(EDOHBJAPLPF_JsonData data)
			{
				if(!data.BBAJPINMOEP_Contains("user_data"))
					return;
				if(!data["user_data"].BBAJPINMOEP_Contains("inventory"))
					return;
				EDOHBJAPLPF_JsonData json = data["user_data"]["inventory"];
				LastId = JsonUtil.GetInt(json, "last_id", 0);
				if(json.BBAJPINMOEP_Contains("items"))
				{
					EDOHBJAPLPF_JsonData array = json["items"];
					for(int i = 0; i < array.HNBFOAJIIAL_Count; i++)
					{
						UserInventoryItem d = new UserInventoryItem();
						d.Load(array[i]);
						Items.Add(d);
					}
				}
				/*if(json.BBAJPINMOEP_Contains("history_items"))
				{
					EDOHBJAPLPF_JsonData array = json["history_items"];
					for(int i = 0; i < array.HNBFOAJIIAL_Count; i++)
					{
						UserInventoryItem d = new UserInventoryItem();
						d.Load(array[i]);
						HistoryItems.Add(d);
					}
				}*/
			}

			public void Save(EDOHBJAPLPF_JsonData data)
			{
				if(!data.BBAJPINMOEP_Contains("user_data"))
					data["user_data"] = new EDOHBJAPLPF_JsonData();

				data["user_data"]["inventory"] = new EDOHBJAPLPF_JsonData();
				data["user_data"]["inventory"]["last_id"] = LastId;
				data["user_data"]["inventory"]["items"] = new EDOHBJAPLPF_JsonData();
				data["user_data"]["inventory"]["items"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for(int i = 0; i < Items.Count; i++)
				{
					data["user_data"]["inventory"]["items"].Add(Items[i].Save());
				}
				/*data["user_data"]["inventory"]["history_items"] = new EDOHBJAPLPF_JsonData();
				data["user_data"]["inventory"]["history_items"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for(int i = 0; i < HistoryItems.Count; i++)
				{
					data["user_data"]["inventory"]["history_items"].Add(HistoryItems[i].Save());
				}*/
			}

			public void AddItem(UserInventoryItem item)
			{
				item.id = LastId;
				item.created_at = Utility.GetCurrentUnixTime();
				LastId++;
				Items.Add(item);
			}

			public UserInventoryItem ConsumeItem(long id)
			{
				int idx = Items.FindIndex((UserInventoryItem _) =>
				{
					return _.id == id;
				});
				if(idx > -1)
				{
					UserInventoryItem item = Items[idx];
					item.received_at = Utility.GetCurrentUnixTime();
					//HistoryItems.Add(item);
					Items.RemoveAt(idx);
					return item;
				}
				return null;
			}
		}

		public static UserInventoryItem AddInventoryItem(UserInventoryItem item, PlayerData p)
		{
			UserInventory inv = new UserInventory();
			inv.Load(p.serverData);
			inv.AddItem(item);
			inv.Save(p.serverData);
			return item;
		}

		public static UserInventoryItem ConsumeInventoryItem(long id)
		{
			UserInventory inv = new UserInventory();
			inv.Load(playerAccount.playerData.serverData);
			UserInventoryItem res = inv.ConsumeItem(id);
			inv.Save(playerAccount.playerData.serverData);
			return res;
		}

		public static int SakashoInventoryGetInventories(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			int page = (int)jsonData["page"];
			int ipp = (int)jsonData["ipp"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["current_page"] = page;
			res["inventories"] = new EDOHBJAPLPF_JsonData();
			res["inventories"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			// fill, sample : 
			/*
			{
				"closed_at": 32509868340,
				"created_at": 1654415240,
				"id": 9072861175,
				"item_count": 1,
				"item_name": "scene",
				"item_type": 0,
				"item_value": 325,
				"message": "\u6b4c\u30de\u30af\u30ed\u30b9\u7279\u5225\u30d7\u30ec\u30bc\u30f3\u30c8\u3067\u3059\u3002",
				"received_at": 0,
				"type": 1
			},
			 
			 */
			
			UserInventory inv = new UserInventory();
			inv.Load(playerAccount.playerData.serverData);

			List<UserInventoryItem> filtered = inv.Items.FindAll((UserInventoryItem _) =>
			{
				return true;
			});
			filtered.Sort((UserInventoryItem a, UserInventoryItem b) =>
			{
				return b.created_at.CompareTo(a.created_at);
			});
			int start = (page - 1) * ipp;
			for(int i = start; i < filtered.Count && i < start + ipp; i++)
			{
				EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
				data["id"] = filtered[i].id;
				data["item_count"] = filtered[i].item_count;
				data["item_name"] = filtered[i].item_name;
				data["item_type"] = filtered[i].item_type;
				data["item_value"] = filtered[i].item_value;
				data["message"] = filtered[i].message;
				data["received_at"] = filtered[i].received_at;
				data["closed_at"] = filtered[i].closed_at;
				data["created_at"] = filtered[i].created_at;
				data["type"] = filtered[i].type;
				res["inventories"].Add(data);
			}

			// Adding campaign result if needed
			if(jsonData.BBAJPINMOEP_Contains("onlyUnreceived") && (bool)jsonData["onlyUnreceived"] && page == 1)
			{
				if(playerAccount.playerData.serverData.BBAJPINMOEP_Contains("ticket"))
				{
					if((int)playerAccount.playerData.serverData["ticket"]["received"] == 0 && 
						(string)playerAccount.playerData.serverData["ticket"]["pending"] == "" && 
						(string)playerAccount.playerData.serverData["ticket"]["entry_date"] != "")
					{
						HIADOIECMFP_EventPresentCampaign db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection("event_present_campaign_a") as HIADOIECMFP_EventPresentCampaign;
						if(db != null)
						{
							for(int i = 0; i < 10; i++)
							{
								int id = UnityEngine.Random.Range(1, db.OBPOHDENMHH.Count);
								EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
								data["id"] = 0;
								data["item_count"] = 1;
								data["item_name"] = "trigger_item";
								data["item_type"] = 2;
								data["item_value"] = id;
								data["message"] = "";
								data["received_at"] = 0;
								data["closed_at"] = 0;
								data["created_at"] = 0;
								data["type"] = 1;
								res["inventories"].Add(data);
							}
						}
					}
				}
			}

			/*EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			data["id"] = 1;
			data["item_count"] = 200;
			data["item_name"] = AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item;
			data["item_type"] = 0;
			data["item_value"] = 70004;
			data["message"] = "msg";
			data["received_at"] = 0;
			data["closed_at"] = Utility.GetCurrentUnixTime() + 24 * 3600;
			data["created_at"] = 0;
			data["type"] = 1;
			res["inventories"].Add(data);

			data = new EDOHBJAPLPF_JsonData();
			data["id"] = 2;
			data["item_count"] = 200;
			data["item_name"] = AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item;
			data["item_type"] = 0;
			data["item_value"] = 70005;
			data["message"] = "msg";
			data["received_at"] = 0;
			data["closed_at"] = Utility.GetCurrentUnixTime() + 24 * 3600;
			data["created_at"] = 0;
			data["type"] = 1;
			res["inventories"].Add(data);

			data = new EDOHBJAPLPF_JsonData();
			data["id"] = 3;
			data["item_count"] = 200;
			data["item_name"] = AFEHLCGHAEE_Strings.KBMDMEEMGLK_grow_item;
			data["item_type"] = 0;
			data["item_value"] = 70006;
			data["message"] = "msg";
			data["received_at"] = 0;
			data["closed_at"] = Utility.GetCurrentUnixTime() + 24 * 3600;
			data["created_at"] = 0;
			data["type"] = 1;
			res["inventories"].Add(data);
			
			data = new EDOHBJAPLPF_JsonData();
			data["id"] = 3;
			data["item_count"] = 100000;
			data["item_name"] = AFEHLCGHAEE_Strings.PJPGBPACBFA_uc_item;
			data["item_type"] = 0;
			data["item_value"] = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit, 1);
			data["message"] = "msg";
			data["received_at"] = 0;
			data["closed_at"] = Utility.GetCurrentUnixTime() + 24 * 3600;
			data["created_at"] = 0;
			data["type"] = 1;
			res["inventories"].Add(data);*/
			
			res["next_page"] = filtered.Count > page * ipp ? page + 1 : 0;
			res["previous_page"] = page > 1 ? page - 1 : 0;

			SendMessage(callbackId, res);
			return 0;
		}
		public static int SakashoInventoryReceiveVirtualCurrencyFromInventory(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData msgData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			List<int> balanceReturn = new List<int>();
			if(msgData["ids"] != null)
			{
				for(int i = 0; i < msgData["ids"].HNBFOAJIIAL_Count; i++)
				{
					UserInventoryItem item = ConsumeInventoryItem(JsonUtil.GetLong(msgData["ids"][i]));
					AddToBalance(item.item_value, item.item_count);
					balanceReturn.Add(item.item_value);
				}
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			GetBalances(res, balanceReturn);

			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoInventoryGetInventoryRecords(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			List<long> ids = new List<long>();
			EDOHBJAPLPF_JsonData l = jsonData["ids"];
			for(int i = 0; i < l.HNBFOAJIIAL_Count; i++)
			{
				ids.Add(JsonUtil.GetLong(l[i]));
			}

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["inventories"] = new EDOHBJAPLPF_JsonData();
			res["inventories"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			UserInventory inv = new UserInventory();
			inv.Load(playerAccount.playerData.serverData);

			List<UserInventoryItem> filtered = inv.Items.FindAll((UserInventoryItem _) =>
			{
				return ids.Contains(_.id);
			});
			filtered.Sort((UserInventoryItem a, UserInventoryItem b) =>
			{
				return b.created_at.CompareTo(a.created_at);
			});
			int start = 0;
			for(int i = start; i < filtered.Count; i++)
			{
				EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
				data["id"] = filtered[i].id;
				data["item_count"] = filtered[i].item_count;
				data["item_name"] = filtered[i].item_name;
				data["item_type"] = filtered[i].item_type;
				data["item_value"] = filtered[i].item_value;
				data["message"] = filtered[i].message;
				data["received_at"] = filtered[i].received_at;
				data["closed_at"] = filtered[i].closed_at;
				data["created_at"] = filtered[i].created_at;
				data["type"] = filtered[i].type;
				res["inventories"].Add(data);
			}

			SendMessage(callbackId, res);
			return 0;
		}
	}
}
