using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoRanking : SakashoAPIBase
{
    public static class RankType
    {
        public const int ALL = 0;
        public const int FRIEND = 1;
    }

	// // RVA: 0x2E5F528 Offset: 0x2E5F528 VA: 0x2E5F528
	public static SakashoAPICallContext GetRankings(OnSuccess onSuccess, OnError onError)
    {
        return new SakashoAPICallContext(Call(SakashoRankingGetRankings, "", onSuccess, onError));
    }

	// // RVA: 0x2E5F60C Offset: 0x2E5F60C VA: 0x2E5F60C
	// public static SakashoAPICallContext GetRankingRecord(int id, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E5F79C Offset: 0x2E5F79C VA: 0x2E5F79C
	public static SakashoAPICallContext GetRanksAroundSelf(int id, int type, int from, int to, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["id"] = id;
		h["type"] = type;
		h["from"] = from;
		h["to"] = to;
		return new SakashoAPICallContext(Call(SakashoRankingGetRanksAroundSelf, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E5FA40 Offset: 0x2E5FA40 VA: 0x2E5FA40
	public static SakashoAPICallContext GetTopRanks(int id, int type, int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["id"] = id;
		h["type"] = type;
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoRankingGetTopRanks, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E5FCE4 Offset: 0x2E5FCE4 VA: 0x2E5FCE4
	public static SakashoAPICallContext UpdateRankingScore(int id, double score, string extra, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["id"] = id;
		h["score"] = score;
		h["extra"] = extra;
		return new SakashoAPICallContext(Call(SakashoRankingUpdateRankingScore, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E5FF14 Offset: 0x2E5FF14 VA: 0x2E5FF14
	// public static SakashoAPICallContext ClaimRankingRewards(int id, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E600A4 Offset: 0x2E600A4 VA: 0x2E600A4
	public static SakashoAPICallContext UpdateRankingScore(int id, double score, OnSuccess onSuccess, OnError onError)
	{
		return UpdateRankingScore(id, score, null, onSuccess, onError);
	}

	// // RVA: 0x2E600D0 Offset: 0x2E600D0 VA: 0x2E600D0
	public static SakashoAPICallContext GetRankingRecordsByKeys(string[] keys, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if (keys != null)
		{
			l = new ArrayList();
			for(int i = 0; i < keys.Length; i++)
			{
				if (keys[i] != null)
					l.Add(keys[i]);
			}
		}
		h["keys"] = l;
		return new SakashoAPICallContext(Call(SakashoRankingGetRankingRecordsByKeys, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E60314 Offset: 0x2E60314 VA: 0x2E60314
	// public static SakashoAPICallContext GetMyRanks(string[] uniqueKeys, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E60558 Offset: 0x2E60558 VA: 0x2E60558
	private static int SakashoRankingGetRankings(int callbackId, string json)
    {
        return ExternLib.LibSakasho.SakashoRankingGetRankings(callbackId, json);
    }

	// // RVA: 0x2E606A0 Offset: 0x2E606A0 VA: 0x2E606A0
	// private static extern int SakashoRankingGetRankingRecord(int callbackId, string json) { }

	// // RVA: 0x2E607B0 Offset: 0x2E607B0 VA: 0x2E607B0
	// private static extern int SakashoRankingGetRanksAroundSelf(int callbackId, string json) { }
	private static int SakashoRankingGetRanksAroundSelf(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoRankingGetRanksAroundSelf(callbackId, json);
	}

	// // RVA: 0x2E608C0 Offset: 0x2E608C0 VA: 0x2E608C0
	private static int SakashoRankingGetTopRanks(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoRankingGetTopRanks(callbackId, json);
	}

	// // RVA: 0x2E60A08 Offset: 0x2E60A08 VA: 0x2E60A08
	private static int SakashoRankingUpdateRankingScore(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoRankingUpdateRankingScore(callbackId, json);
	}

	// // RVA: 0x2E60B18 Offset: 0x2E60B18 VA: 0x2E60B18
	// private static extern int SakashoRankingClaimRankingRewards(int callbackId, string json) { }

	// // RVA: 0x2E60C28 Offset: 0x2E60C28 VA: 0x2E60C28
	private static /*extern */int SakashoRankingGetRankingRecordsByKeys(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoRankingGetRankingRecordsByKeys(callbackId, json);
	}

	// // RVA: 0x2E60D40 Offset: 0x2E60D40 VA: 0x2E60D40
	// private static extern int SakashoRankingGetMyRanks(int callbackId, string json) { }
}
