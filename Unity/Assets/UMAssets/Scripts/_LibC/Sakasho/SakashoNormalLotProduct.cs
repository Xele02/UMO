using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoNormalLotProductGetNormalLotItems(int callbackId, string json)
		{
			// Hack directly send response
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.DJJGPACGEMM_product_id] = (int)jsonData["productId"];
			res[AFEHLCGHAEE_Strings.BPNPBJALGHM_quantity] = (int)jsonData["quantity"];
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].Add(new EDOHBJAPLPF_JsonData());
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items][0]["item_count"] = 1;
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items][0]["item_name"] = "scene";
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items][0]["item_value"] = 90;
			
			SendMessage(callbackId, res);
			// end hack

			return 0;
		}
	}
}
