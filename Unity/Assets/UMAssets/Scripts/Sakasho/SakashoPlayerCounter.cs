using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoPlayerCounter : SakashoAPIBase
{
	//// RVA: 0x2E59F38 Offset: 0x2E59F38 VA: 0x2E59F38
	//public static SakashoAPICallContext GetPlayerCounterMasters(Nullable<int> label, int page, int ipp, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E5A1B0 Offset: 0x2E5A1B0 VA: 0x2E5A1B0
	public static SakashoAPICallContext GetPlayerCounters(string playerCounterMasterName, int[] playerIds, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if(playerCounterMasterName != null)
		{
			h["playerCounterMasterName"] = playerCounterMasterName;
		}
		ArrayList l = null;
		if (playerIds != null)
		{
			l = new ArrayList();
			for(int i = 0; i < playerIds.Length; i++)
			{
				l.Add(playerIds[i]);
			}
		}
		h["playerIds"] = l;
		return new SakashoAPICallContext(Call(SakashoPlayerCounterGetPlayerCounters, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E5A438 Offset: 0x2E5A438 VA: 0x2E5A438
	public static SakashoAPICallContext UpdatePlayerCounter(string playerCounterMasterName, int playerId, int countDelta, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if(playerCounterMasterName != null)
		{
			h["playerCounterMasterName"] = playerCounterMasterName;
		}
		h["playerId"] = playerId;
		h["countDelta"] = countDelta;
		return new SakashoAPICallContext(Call(SakashoPlayerCounterUpdatePlayerCounter, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E5A668 Offset: 0x2E5A668 VA: 0x2E5A668
	//public static SakashoAPICallContext GetPlayersCounters(SakashoPlayerCounterCriteria[] criteria, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E5ABBC Offset: 0x2E5ABBC VA: 0x2E5ABBC
	//public static SakashoAPICallContext UpdatePlayerCounters(SakashoPlayerCounterInfo[] playerCounterInfo, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E5B010 Offset: 0x2E5B010 VA: 0x2E5B010
	//private static extern int SakashoPlayerCounterGetPlayerCounterMasters(int callbackId, string json) { }

	//// RVA: 0x2E5B128 Offset: 0x2E5B128 VA: 0x2E5B128
	private static int SakashoPlayerCounterGetPlayerCounters(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlayerCounterGetPlayerCounters(callbackId, json);
	}

	//// RVA: 0x2E5B240 Offset: 0x2E5B240 VA: 0x2E5B240
	private static int SakashoPlayerCounterUpdatePlayerCounter(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlayerCounterUpdatePlayerCounter(callbackId, json);
	}

	//// RVA: 0x2E5B358 Offset: 0x2E5B358 VA: 0x2E5B358
	//private static extern int SakashoPlayerCounterGetPlayersCounters(int callbackId, string json) { }

	//// RVA: 0x2E5B470 Offset: 0x2E5B470 VA: 0x2E5B470
	//private static extern int SakashoPlayerCounterUpdatePlayerCounters(int callbackId, string json) { }
}
