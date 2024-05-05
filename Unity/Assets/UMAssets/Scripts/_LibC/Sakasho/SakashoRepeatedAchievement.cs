using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoRepeatedAchievementGetAchievementRecords(int callbackId, string json)
		{
			// Hack directly send response
			TodoLogger.LogError(TodoLogger.SakashoServer, "SakashoRepeatedAchievementGetAchievementRecords");
			return SakashoAchievementGetAchievementRecords(callbackId, json);
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
