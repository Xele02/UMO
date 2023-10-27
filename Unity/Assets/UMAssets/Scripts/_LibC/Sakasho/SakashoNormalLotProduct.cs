using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoNormalLotProductGetNormalLotItems(int callbackId, string json)
		{
			// Hack directly send response

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.DJJGPACGEMM_product_id] = "Test";
			res[AFEHLCGHAEE_Strings.BPNPBJALGHM_quantity] = 1;
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			SendMessage(callbackId, res);
			// end hack

			return 0;
		}
	}
}
