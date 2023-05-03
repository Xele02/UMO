using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoRepeatedAchievement : SakashoAPIBase
{
	//// RVA: 0x2E61D24 Offset: 0x2E61D24 VA: 0x2E61D24
	public static SakashoAPICallContext GetAchievementRecords(string[] keys, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if (keys != null)
		{
			l = new ArrayList();
			for (int i = 0; i < keys.Length; i++)
			{
				if (keys[i] != null)
				{
					l.Add(keys[i]);
				}
			}
		}
		h["keys"] = l;
		return new SakashoAPICallContext(Call(SakashoRepeatedAchievementGetAchievementRecords, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E61F68 Offset: 0x2E61F68 VA: 0x2E61F68
	//public static SakashoAPICallContext ClaimAchievementPrizes(string[] keys, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E621AC Offset: 0x2E621AC VA: 0x2E621AC
	//public static SakashoAPICallContext ClaimAchievementPrizesAndSave(string[] keys, string[] names, string playerData, bool asReceived, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E621D4 Offset: 0x2E621D4 VA: 0x2E621D4
	//public static SakashoAPICallContext ClaimAchievementPrizesAndSave(string[] keys, string[] names, string playerData, bool asReceived, bool replace, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E625D0 Offset: 0x2E625D0 VA: 0x2E625D0
	//public static SakashoAPICallContext ClaimAchievementPrizesSetInventoryClosedAt(string[] keys, int[] inventoryClosedAt, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E62948 Offset: 0x2E62948 VA: 0x2E62948
	//public static SakashoAPICallContext ClaimAchievementPrizesAndSaveSetInventoryClosedAt(string[] keys, string[] names, string playerData, bool asReceived, bool replace, int[] inventoryClosedAt, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E62E50 Offset: 0x2E62E50 VA: 0x2E62E50
	private static /*extern */int SakashoRepeatedAchievementGetAchievementRecords(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoRepeatedAchievementGetAchievementRecords(callbackId, json);
	}

	//// RVA: 0x2E62F70 Offset: 0x2E62F70 VA: 0x2E62F70
	//private static extern int SakashoRepeatedAchievementClaimAchievementPrizes(int callbackId, string json) { }

	//// RVA: 0x2E63090 Offset: 0x2E63090 VA: 0x2E63090
	//private static extern int SakashoRepeatedAchievementClaimAchievementPrizesAndSave(int callbackId, string json) { }

	//// RVA: 0x2E631B8 Offset: 0x2E631B8 VA: 0x2E631B8
	//private static extern int SakashoRepeatedAchievementClaimAchievementPrizesSetInventoryClosedAt(int callbackId, string json) { }

	//// RVA: 0x2E632B0 Offset: 0x2E632B0 VA: 0x2E632B0
	//private static extern int SakashoRepeatedAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt(int callbackId, string json) { }
}
