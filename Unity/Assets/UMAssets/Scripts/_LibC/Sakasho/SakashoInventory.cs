using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoInventoryGetInventories(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			int page = (int)jsonData["page"];
			int ipp = (int)jsonData["ipp"];

			string message = "";
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			res["SAKASHO_CURRENT_ASSET_REVISION"] = "20220602120304";
			res["SAKASHO_CURRENT_DATE_TIME"] = Utility.GetCurrentUnixTime();
			res["SAKASHO_CURRENT_MASTER_REVISION"] = 5;
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
			res["next_page"] = 0;
			res["previous_page"] = 0;
			message = res.EJCOJCGIBNG_ToJson();

			UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", "" + callbackId + ":" + message);

			return 0;
		}
		public static int SakashoInventoryReceiveVirtualCurrencyFromInventory(int callbackId, string json)
		{
			string message = "";
			UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", "" + callbackId + ":" + message);

			return 0;
		}
	}
}
