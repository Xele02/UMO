using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoAchievementGetAchievementRecords(int callbackId, string json)
		{
			// Hack directly send response

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);

			SendMessage(callbackId, res);
			// end hack

			return 0;
		}

		public static int SakashoAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt(int callbackId, string json)
		{
			// Hack directly send response

			return SakashoPlayerDataSavePlayerData(callbackId, json);
		}

		public static int SakashoAchievementClaimAchievementPrizesAndSave(int callbackId, string json)
		{
			// Hack directly send response

			return SakashoPlayerDataSavePlayerData(callbackId, json);
		}
	}
}
