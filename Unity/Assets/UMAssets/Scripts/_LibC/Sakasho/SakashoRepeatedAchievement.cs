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
			TodoLogger.LogError(TodoLogger.SakashoServer, "SakashoRepeatedAchievementGetAchievementRecords");

			SendMessage(callbackId, res);
			// end hack

			return 0;
		}

		public static int SakashoRepeatedAchievementClaimAchievementPrizes(int callbackId, string json)
		{
			// Hack directly send response
			return SakashoAchievementClaimAchievementPrizes(callbackId, json);
		}

		public static int SakashoRepeatedAchievementClaimAchievementPrizesSetInventoryClosedAt(int callbackId, string json)
		{
			// Hack directly send response

			return SakashoAchievementClaimAchievementPrizesSetInventoryClosedAt(callbackId, json);
		}

		public static int SakashoRepeatedAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt(int callbackId, string json)
		{
			// Hack directly send response
			return SakashoAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt(callbackId, json);
		}

		public static int SakashoRepeatedAchievementClaimAchievementPrizesAndSave(int callbackId, string json)
		{
			// Hack directly send response
			return SakashoAchievementClaimAchievementPrizesAndSave(callbackId, json);
		}
	}
}
