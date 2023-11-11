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
			res[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key]["rarity_6"] = "20.0%";
			res[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key]["rarity_5"] = "20.0%";
			res[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key]["rarity_4"] = "20.0%";
			res[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key]["rarity_3"] = "20.0%";
			res[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key]["rarity_2"] = "20.0%";
			res[AFEHLCGHAEE_Strings.PNIFJJPHLDH_probability_per_group_key]["rarity_1"] = "20.0%";
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < 6; i++)
			{
				for(int j = 0; j < 10; j++)
				{
					EDOHBJAPLPF_JsonData card = new EDOHBJAPLPF_JsonData();
					card[AFEHLCGHAEE_Strings.OPFGFINHFCE_name] = "scene";
					card[AFEHLCGHAEE_Strings.NANNGLGOFKH_value] = 90;
					card[AFEHLCGHAEE_Strings.BPNPBJALGHM_quantity] = 1;
					card[AFEHLCGHAEE_Strings.MMOJHIPAAIK_probability] = "0.1%";
					card[AFEHLCGHAEE_Strings.PANKNKOIIJE_group_key] = BPADANIKFHP.GIFAIIDJPND[i];
					res[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items].Add(card);
				}
			}
			SendMessage(callbackId, res);
			// end hack

			return 0;
		}
	}
}
