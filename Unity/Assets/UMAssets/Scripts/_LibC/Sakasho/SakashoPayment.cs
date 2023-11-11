using System.Collections.Generic;
using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoPaymentGetRemainingForCurrencyIds(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData ids = jsonData["ids"];

			string message = "";

			EDOHBJAPLPF_JsonData arrayData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
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
					""paid"": 0,
					""total"": 0

				},
				{
					""description"": ""\u6b4c\u6676\u77f3\u8cfc\u5165\u306e\u304a\u307e\u3051 (6/1\uff5e8/31)"",
					""free"": 0,
					""id"": 3002,
					""name"": ""\u30b5\u30de\u30fc\u30b9\u30d5\u30a3\u30a2"",
					""paid"": 0,
					""total"": 0

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
			]");

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["balances"] = new EDOHBJAPLPF_JsonData();
			res["balances"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < ids.HNBFOAJIIAL_Count; i++)
			{
				int val = (int)ids[i];
				EDOHBJAPLPF_JsonData r = null;
				for(int j = 0; j < arrayData.HNBFOAJIIAL_Count; j++)
				{
					if ((int)arrayData[j]["id"] == val)
					{
						r = arrayData[j];
						break;
					}
				}
				if(r == null)
				{
					TodoLogger.LogError(0, "SakashoPaymentGetRemainingForCurrencyIds, missing id "+val);
					r = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"{
					""description"": ""No desc"",
					""free"": 0,
					""id"": "+val+@",
					""name"": ""No name"",
					""paid"": 0,
					""total"": 0
				}");
				}
				res["balances"].Add(r);
			}

			SendMessage(callbackId, res);
			return 0;
		}
		
		public static int SakashoPaymentGetVirtualCurrencyBalancesWithExpiredAt(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData ids = jsonData["virtualCurrencyIds"];

			string message = "";

			EDOHBJAPLPF_JsonData arrayData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
				{
					""description"": ""\u30c7\u30ab\u30eb\u30ac\u30c1\u30e3\u3092\u5f15\u304f\u305f\u3081\u306e\u30c1\u30b1\u30c3\u30c8"",
					""free"": [],
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
			]");

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["balances"] = new EDOHBJAPLPF_JsonData();
			res["balances"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < ids.HNBFOAJIIAL_Count; i++)
			{
				int val = (int)ids[i];
				EDOHBJAPLPF_JsonData r = null;
				for(int j = 0; j < arrayData.HNBFOAJIIAL_Count; j++)
				{
					if ((int)arrayData[j]["id"] == val)
					{
						r = arrayData[j];
						break;
					}
				}
				if(r == null)
				{
					TodoLogger.LogError(0, "SakashoPaymentGetVirtualCurrencyBalancesWithExpiredAt, missing id " + val);
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

		static EDOHBJAPLPF_JsonData arrayData2 = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
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
		]");


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


			string message = "";

			EDOHBJAPLPF_JsonData arrayData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
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
			]");

			EDOHBJAPLPF_JsonData arrayData3 = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(@"[
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
			]");

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["current_page"] = page;
			res["next_page"] = 0;
			res["previous_page"] = 0;
			res["products"] = new EDOHBJAPLPF_JsonData();
			res["products"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			if(productType == 0 && currencyId == 1001 && label == 10)
			{
				for (int i = 0; i < arrayData.HNBFOAJIIAL_Count; i++)
				{
					if((int)arrayData[i]["label"] == label)
						res["products"].Add(arrayData[i]);
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
			}
			else
			{
				TodoLogger.LogError(0, "Missing product info for "+json);
			}

			SendMessage(callbackId, res);
			return 0;
		}

		public static int SakashoPaymentRecover(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);
			return 0;
		}	

		public static int SakashoPaymentPurchase(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories] = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData inv = res[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
			inv.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			//{"quantity":1, "productId":429930, "currencyId":1001}
			EDOHBJAPLPF_JsonData req = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

            List<MLIBEPGADJH_Scene.KKLDOOJBJMN> scenesList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.FindAll((MLIBEPGADJH_Scene.KKLDOOJBJMN _) =>
			{
				return _.PPEGAKEIEGM_En == 2/* && _.EKLIPGELKCL_Rarity == 5*/;
			});
            EDOHBJAPLPF_JsonData gachaData = arrayData2;
			for(int i = 0; i < gachaData.HNBFOAJIIAL_Count; i++)
			{
				if((int)gachaData[i]["id"] == (int)req["productId"])
				{
					EDOHBJAPLPF_JsonData summons = gachaData[i]["item_set_name_for_api"];
					for(int j = 0; j < summons.HNBFOAJIIAL_Count; j++)
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
					break;
				}
			}

			SendMessage(callbackId, res);
			return 0;
		}
	}
}
