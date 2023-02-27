using System.Collections;
using Sakasho.JSON;
using SakashoSystemCallback;

public class SakashoPlayerData : SakashoAPIBase
{
	public enum SearchOrder
	{
		NONE = 0,
		KEY_ASC = 1,
		KEY_DESC = 2,
		UPDATED_AT_ASC = 4,
		UPDATED_AT_DESC = 8,
	}

	public const string DEFAULT_PLAYER_DATA_NAME = "base";
	public static string[] DEFAULT_PLAYER_DATA_NAMES = new string[1] { "base" }; // 0x0

	// // RVA: 0x2E5B590 Offset: 0x2E5B590 VA: 0x2E5B590
	public static SakashoAPICallContext LoadPlayerData(string[] names, bool withToken, OnSuccess onSuccess, OnError onError)
    {
        Hashtable ht = new Hashtable();
        ArrayList ar = null;
        if(names != null)
        {
            ar = new ArrayList();
            for(int i = 0; i < names.Length; i++)
            {
                if(names[i] != null)
                    ar.Add(names[i]);
            }
        }
        ht["names"] = ar;
        ht["withToken"] = withToken;
        int callId = SakashoAPIBase.Call(SakashoPlayerDataLoadPlayerData, MiniJSON.jsonEncode(ht), onSuccess, onError);
        return new SakashoAPICallContext(callId);
    }

	// // RVA: 0x2E5B838 Offset: 0x2E5B838 VA: 0x2E5B838
	public static SakashoAPICallContext LoadPlayerData(string[] names, OnSuccess onSuccess, OnError onError)
    {
        return LoadPlayerData(names, false, onSuccess, onError);
    }

	// // RVA: 0x2E5B8D4 Offset: 0x2E5B8D4 VA: 0x2E5B8D4
	public static SakashoAPICallContext SavePlayerData(string[] names, string playerData, bool replace, long[] inventoryIds, string token, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if(names != null)
		{
			l = new ArrayList();
			for(int i = 0; i < names.Length; i++)
			{
				l.Add(names[i]);
			}
		}
		h["names"] = l;
		if(playerData != null)
		{
			h["playerData"] = playerData;
		}
		h["replace"] = replace.ToString();
		l = null;
		if(inventoryIds != null)
		{
			l = new ArrayList();
			for(int i = 0; i < inventoryIds.Length; i++)
			{
				l.Add(inventoryIds[i].ToString());
			}
		}
		h["inventoryIds"] = l;
		if (token != null)
			h["token"] = token;
		return new SakashoAPICallContext(Call(SakashoPlayerDataSavePlayerData, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E5BCDC Offset: 0x2E5BCDC VA: 0x2E5BCDC
	public static SakashoAPICallContext SavePlayerData(string[] names, string playerData, bool replace, long[] inventoryIds, OnSuccess onSuccess, OnError onError)
	{
		return SavePlayerData(names, playerData, replace, inventoryIds, null, onSuccess, onError);
	}

	// // RVA: 0x2E5BD90 Offset: 0x2E5BD90 VA: 0x2E5BD90
	public static SakashoAPICallContext SearchForPlayer(SakashoPlayerCriteria criteria, string[] names, SakashoPlayerData.SearchOrder order, int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable hash = new Hashtable();
		if(criteria.Key != null)
		{
			hash["key"] = criteria.Key;
		}
		if(criteria.EqualTo != null)
		{
			hash["equalTo"] = criteria.EqualTo;
		}
		if(criteria.NumberFrom != null)
		{
			hash["numberFrom"] = criteria.NumberFrom;
		}
		if (criteria.NumberTo != null)
		{
			hash["numberTo"] = criteria.NumberTo;
		}
		if(criteria.StringStartsWith != null)
		{
			hash["stringStartsWith"] = criteria.StringStartsWith;
		}
		hash["onlyFriends"] = "" + criteria.OnlyFriends;
		hash["excludeAccountBan"] = "" + criteria.ExcludeAccountBan;
		ArrayList l = null;
		if (names != null)
		{
			l = new ArrayList();
			for(int i = 0; i < names.Length; i++)
			{
				if(names[i] != null)
				{
					l.Add(names[i]);
				}
			}
		}
		hash["names"] = l;
		hash["order"] = "" + order;
		hash["page"] = "" + page;
		hash["ipp"] = "" + ipp;
		return new SakashoAPICallContext(SakashoAPIBase.Call(SakashoPlayerDataSearchForPlayer, MiniJSON.jsonEncode(hash), onSuccess, onError));
	}

	// // RVA: 0x2E5C3F4 Offset: 0x2E5C3F4 VA: 0x2E5C3F4
	// public static SakashoAPICallContext GetPlayerData(int[] ids, string[] names, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E5C754 Offset: 0x2E5C754 VA: 0x2E5C754
	// public static SakashoAPICallContext DeletePlayerData(string[] names, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E5C998 Offset: 0x2E5C998 VA: 0x2E5C998
	private static /*extern */int SakashoPlayerDataLoadPlayerData(int callbackId, string json)
    {
        return ExternLib.LibSakasho.SakashoPlayerDataLoadPlayerData(callbackId, json);
    }

	// // RVA: 0x2E5CAA8 Offset: 0x2E5CAA8 VA: 0x2E5CAA8
	// private static extern int SakashoPlayerDataSavePlayerData(int callbackId, string json) { }
	private static int SakashoPlayerDataSavePlayerData(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlayerDataSavePlayerData(callbackId, json);
	}

	// // RVA: 0x2E5CBB8 Offset: 0x2E5CBB8 VA: 0x2E5CBB8
	private static /*extern */int SakashoPlayerDataSearchForPlayer(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlayerDataSearchForPlayer(callbackId, json);
	}

	// // RVA: 0x2E5CCC8 Offset: 0x2E5CCC8 VA: 0x2E5CCC8
	// private static extern int SakashoPlayerDataGetPlayerData(int callbackId, string json) { }

	// // RVA: 0x2E5CDD8 Offset: 0x2E5CDD8 VA: 0x2E5CDD8
	// private static extern int SakashoPlayerDataDeletePlayerData(int callbackId, string json) { }
}
