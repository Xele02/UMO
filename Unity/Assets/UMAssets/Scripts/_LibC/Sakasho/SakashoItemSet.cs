using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoItemSetGetItemSetRecord(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description] = "Test";
			res[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			SendMessage(callbackId, res);
			// end hack

			return 0;
		}
	}
}
