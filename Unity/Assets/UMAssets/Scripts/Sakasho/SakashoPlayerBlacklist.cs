using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoPlayerBlacklist : SakashoAPIBase
{
	//// RVA: 0x2E59040 Offset: 0x2E59040 VA: 0x2E59040
	public static SakashoAPICallContext GetBlacklist(int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoPlayerBlacklistGetBlacklist, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E5922C Offset: 0x2E5922C VA: 0x2E5922C
	public static SakashoAPICallContext IsBlacklisted(int playerId, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["playerId"] = playerId;
		return new SakashoAPICallContext(Call(SakashoPlayerBlacklistIsBlacklisted, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E593BC Offset: 0x2E593BC VA: 0x2E593BC
	public static SakashoAPICallContext IsOnBlacklistOf(int playerId, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["playerId"] = playerId;
		return new SakashoAPICallContext(Call(SakashoPlayerBlacklistIsOnBlacklistOf, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E5954C Offset: 0x2E5954C VA: 0x2E5954C
	public static SakashoAPICallContext AddToBlacklist(int[] playerIds, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = new ArrayList();
		if(playerIds != null)
		{
			l = new ArrayList();
			for(int i = 0; i < playerIds.Length; i++)
			{
				l.Add(playerIds[i]);
			}
		}
		h["playerIds"] = l;
		return new SakashoAPICallContext(Call(SakashoPlayerBlacklistAddToBlacklist, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E59788 Offset: 0x2E59788 VA: 0x2E59788
	public static SakashoAPICallContext RemoveFromBlacklist(int[] playerIds, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = new ArrayList();
		if(playerIds != null)
		{
			l = new ArrayList();
			for(int i = 0; i < playerIds.Length; i++)
			{
				l.Add(playerIds[i]);
			}
		}
		h["playerIds"] = l;
		return new SakashoAPICallContext(Call(SakashoPlayerBlacklistRemoveFromBlacklist, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E599C8 Offset: 0x2E599C8 VA: 0x2E599C8
	private static int SakashoPlayerBlacklistGetBlacklist(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlayerBlacklistGetBlacklist(callbackId, json);
	}

	//// RVA: 0x2E59AD8 Offset: 0x2E59AD8 VA: 0x2E59AD8
	private static int SakashoPlayerBlacklistIsBlacklisted(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlayerBlacklistIsBlacklisted(callbackId, json);
	}

	//// RVA: 0x2E59BE8 Offset: 0x2E59BE8 VA: 0x2E59BE8
	private static int SakashoPlayerBlacklistIsOnBlacklistOf(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlayerBlacklistIsOnBlacklistOf(callbackId, json);
	}

	//// RVA: 0x2E59D00 Offset: 0x2E59D00 VA: 0x2E59D00
	private static int SakashoPlayerBlacklistAddToBlacklist(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlayerBlacklistAddToBlacklist(callbackId, json);
	}

	//// RVA: 0x2E59E18 Offset: 0x2E59E18 VA: 0x2E59E18
	private static int SakashoPlayerBlacklistRemoveFromBlacklist(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlayerBlacklistRemoveFromBlacklist(callbackId, json);
	}
}
