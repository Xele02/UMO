using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoRegularRanking : SakashoAPIBase
{
	public static class RankingOrder
	{
		public const int NONE = 0;
		public const int TARGET_ID_ASC = 1;
		public const int TARGET_ID_DESC = 2;
	}

	//// RVA: 0x2E60E8C Offset: 0x2E60E8C VA: 0x2E60E8C
	//public static SakashoAPICallContext GetRegularRankingCategories(int page, int ipp, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E61078 Offset: 0x2E61078 VA: 0x2E61078
	//public static SakashoAPICallContext GetRegularRankings(string categoryId, int sortOrderByTargetId, int page, int ipp, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E61304 Offset: 0x2E61304 VA: 0x2E61304
	public static SakashoAPICallContext GetRegularRankingTopRanks(string categoryId, string targetId, int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if (categoryId != null)
			h["categoryId"] = categoryId;
		if (targetId != null)
			h["targetId"] = targetId;
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoRegularRankingGetRegularRankingTopRanks, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E61578 Offset: 0x2E61578 VA: 0x2E61578
	public static SakashoAPICallContext GetRegularRankingRanksAroundTarget(string categoryId, string targetId, int from, int to, int? playerId, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if (categoryId != null)
			h["categoryId"] = categoryId;
		if (targetId != null)
			h["targetId"] = targetId;
		h["from"] = from;
		h["to"] = to;
		if(playerId.HasValue)
			h["playerId"] = playerId;
		return new SakashoAPICallContext(Call(SakashoRegularRankingGetRegularRankingRanksAroundTarget, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E6186C Offset: 0x2E6186C VA: 0x2E6186C
	//public static SakashoAPICallContext GetRegularRankings(string categoryId, int page, int ipp, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E618A0 Offset: 0x2E618A0 VA: 0x2E618A0
	//private static extern int SakashoRegularRankingGetRegularRankingCategories(int callbackId, string json) { }

	//// RVA: 0x2E619C0 Offset: 0x2E619C0 VA: 0x2E619C0
	//private static extern int SakashoRegularRankingGetRegularRankings(int callbackId, string json) { }

	//// RVA: 0x2E61AD8 Offset: 0x2E61AD8 VA: 0x2E61AD8
	private static int SakashoRegularRankingGetRegularRankingTopRanks(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoRegularRankingGetRegularRankingTopRanks(callbackId, json);
	}

	//// RVA: 0x2E61BF8 Offset: 0x2E61BF8 VA: 0x2E61BF8
	private static int SakashoRegularRankingGetRegularRankingRanksAroundTarget(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoRegularRankingGetRegularRankingRanksAroundTarget(callbackId, json);
	}
}
