using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoRepeatedAchievementGetAchievementRecords(int callbackId, string json)
		{
			// Hack directly send response

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes] = new EDOHBJAPLPF_JsonData();
			res[AFEHLCGHAEE_Strings.CEDLLCCONJP_achievement_prizes].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			TodoLogger.Log(0, "SakashoRepeatedAchievementGetAchievementRecords");

			SendMessage(callbackId, res);
			// end hack

			return 0;
		}
		public static int SakashoRepeatedAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt(int callbackId, string json)
		{
			// Hack directly send response
			TodoLogger.LogError(0, "SakashoRepeatedAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt");
			return SakashoPlayerDataSavePlayerData(callbackId, json);
		}

		public static int SakashoRepeatedAchievementClaimAchievementPrizesAndSave(int callbackId, string json)
		{
			// Hack directly send response
			TodoLogger.LogError(0, "SakashoRepeatedAchievementClaimAchievementPrizesAndSave");
			return SakashoPlayerDataSavePlayerData(callbackId, json);
		}
	}
}
