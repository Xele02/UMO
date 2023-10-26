using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoStepUpLotPurchase(int callbackId, string json)
		{
			// Hack directly send response

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.OPFGFINHFCE_name] = "Test";
			res[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description] = "Desc";
			res[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			res[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res[AFEHLCGHAEE_Strings.LKHAAGIJEPG_player_status] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.LKHAAGIJEPG_player_status][AFEHLCGHAEE_Strings.DBNAGGGJDAB_current_step_index] = 0;
			res[AFEHLCGHAEE_Strings.LKHAAGIJEPG_player_status][AFEHLCGHAEE_Strings.LPIKIBKFOJE_current_step_count] = 1;
			res[AFEHLCGHAEE_Strings.LKHAAGIJEPG_player_status][AFEHLCGHAEE_Strings.KHEBCAGHEIN_total_count] = 1;
			res[AFEHLCGHAEE_Strings.LKHAAGIJEPG_player_status][AFEHLCGHAEE_Strings.ENJCKADOFBD_next_purchase_hash] = "";

			SendMessage(callbackId, res);
			// end hack

			return 0;
		}
	}
}
