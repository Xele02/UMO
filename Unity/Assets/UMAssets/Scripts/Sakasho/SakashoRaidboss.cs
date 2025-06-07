using System.Collections;
using System.Security.Policy;
using ExternLib;
using Sakasho.JSON;
using SakashoSystemCallback;

public class SakashoRaidboss : SakashoAPIBase
{
	// // RVA: 0x2E5D4AC Offset: 0x2E5D4AC VA: 0x2E5D4AC
	public static SakashoAPICallContext AttackRaidbossAndSave(int entityId, int damage, int attackPlayerCount, SakashoRaidbossEffectData effectData, string[] namespacesForResponse, string[] namespacesForSave, string playerData, bool replace, OnSuccess onSuccess, OnError onError)
	{
        Hashtable h = new Hashtable();
        h["entityId"] = entityId;
        h["damage"] = damage;
        h["attackPlayerCount"] = attackPlayerCount;
		if(effectData != null)
		{
            h["effectId"] = effectData.EffectId;
            h["numberOfTimes"] = effectData.NumberOfTimes;
            h["durationSeconds"] = effectData.DurationSeconds;
        }
		ArrayList l = null;
		if(namespacesForResponse != null)
		{
            l = new ArrayList();
            for (int i = 0; i < namespacesForResponse.Length; i++)
			{
				if(namespacesForResponse[i] != null)
                    l.Add(namespacesForResponse[i]);
            }
        }
        h["namespacesForResponse"] = l;
		l = null;
		if(namespacesForSave != null)
		{
            l = new ArrayList();
            for (int i = 0; i < namespacesForSave.Length; i++)
            {
				if(namespacesForSave[i] != null)
                    l.Add(namespacesForSave[i]);
            }
        }
        h["namespacesForSave"] = l;
		if(playerData != null)
		{
            h["playerData"] = playerData;
        }
        h["replace"] = replace;
        return new SakashoAPICallContext(Call(SakashoRaidbossAttackRaidbossAndSave, MiniJSON.jsonEncode(h), onSuccess, onError));
    }

	// // RVA: 0x2E5DA68 Offset: 0x2E5DA68 VA: 0x2E5DA68
	public static SakashoAPICallContext EncounterRaidboss(string uniqueKey, OnSuccess onSuccess, OnError onError)
    {
        Hashtable h = new Hashtable();
        if(uniqueKey != null)
            h["uniqueKey"] = uniqueKey;
        return new SakashoAPICallContext(Call(SakashoRaidbossEncounterRaidboss, MiniJSON.jsonEncode(h), onSuccess, onError));
    }

	// // RVA: 0x2E5DBE0 Offset: 0x2E5DBE0 VA: 0x2E5DBE0
	// public static SakashoAPICallContext GetMyRaidbossCounts(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E5DCC4 Offset: 0x2E5DCC4 VA: 0x2E5DCC4
	public static SakashoAPICallContext GetMyRaidbosses(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoRaidbossGetMyRaidbosses, "", onSuccess, onError));
	}

	// // RVA: 0x2E5DDA8 Offset: 0x2E5DDA8 VA: 0x2E5DDA8
	public static SakashoAPICallContext SetRaidbossRewardsReceivedAndSave(int entityId, string[] names, string playerData, bool replace, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["entityId"] = entityId;
		ArrayList l = null;
		if(names != null)
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
		h["names"] = l;
		if(playerData != null)
		{
			h["playerData"] = playerData;
		}
		h["replace"] = replace;
		return new SakashoAPICallContext(Call(SakashoRaidbossSetRaidbossRewardsReceivedAndSave, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E5E0BC Offset: 0x2E5E0BC VA: 0x2E5E0BC
	public static SakashoAPICallContext GetRaidboss(int entityId, int playerCount, string[] namespaces, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["entityId"] = entityId;
		h["playerCount"] = playerCount;
		ArrayList l = null;
		if(namespaces != null)
		{
			l = new ArrayList();
			for(int i = 0; i < namespaces.Length; i++)
			{
				if(namespaces[i] != null)
					l.Add(namespaces[i]);
			}
		}
		h["namespaces"] = l;
		return new SakashoAPICallContext(Call(SakashoRaidbossGetRaidboss, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E5E3B4 Offset: 0x2E5E3B4 VA: 0x2E5E3B4
	public static SakashoAPICallContext RequestRaidbossHelp(int entityId, int friendPlayerCount, int otherPlayerCount, string[] namespaces, string searchKey, int searchNumberFrom, int searchNumberTo, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["entityId"] = entityId;
		h["friendPlayerCount"] = friendPlayerCount;
		h["otherPlayerCount"] = otherPlayerCount;
		ArrayList l = null;
		if(namespaces != null)
		{
			l = new ArrayList();
			for(int i = 0; i < namespaces.Length; i++)
			{
				if(namespaces[i] != null)
					l.Add(namespaces[i]);
			}
		}
		h["namespaces"] = l;
		if(searchKey != null)
			h["searchKey"] = searchKey;
		h["searchNumberFrom"] = searchNumberFrom;
		h["searchNumberTo"] = searchNumberTo;
		return new SakashoAPICallContext(Call(SakashoRaidbossRequestRaidbossHelp, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// // RVA: 0x2E5E7B8 Offset: 0x2E5E7B8 VA: 0x2E5E7B8
	// public static SakashoAPICallContext GetRaidbosses(int[] entityIds, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E5E9F4 Offset: 0x2E5E9F4 VA: 0x2E5E9F4
	// public static SakashoAPICallContext JoinRaidboss(int entityId, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E5EB88 Offset: 0x2E5EB88 VA: 0x2E5EB88
	private static int SakashoRaidbossAttackRaidbossAndSave(int callbackId, string json)
	{
        return ExternLib.LibSakasho.SakashoRaidbossAttackRaidbossAndSave(callbackId, json);
	}

	// // RVA: 0x2E5ECA0 Offset: 0x2E5ECA0 VA: 0x2E5ECA0
	private static int SakashoRaidbossEncounterRaidboss(int callbackId, string json)
    {
        return ExternLib.LibSakasho.SakashoRaidbossEncounterRaidboss(callbackId, json);
    }

	// // RVA: 0x2E5EDB0 Offset: 0x2E5EDB0 VA: 0x2E5EDB0
	// private static extern int SakashoRaidbossGetMyRaidbossCounts(int callbackId, string json) { }

	// // RVA: 0x2E5EEC0 Offset: 0x2E5EEC0 VA: 0x2E5EEC0
	private static int SakashoRaidbossGetMyRaidbosses(int callbackId, string json)
    {
        return ExternLib.LibSakasho.SakashoRaidbossGetMyRaidbosses(callbackId, json);
    }

	// // RVA: 0x2E5EFD0 Offset: 0x2E5EFD0 VA: 0x2E5EFD0
	private static int SakashoRaidbossSetRaidbossRewardsReceivedAndSave(int callbackId, string json)
	{
        return ExternLib.LibSakasho.SakashoRaidbossSetRaidbossRewardsReceivedAndSave(callbackId, json);
	}

	// // RVA: 0x2E5F0F0 Offset: 0x2E5F0F0 VA: 0x2E5F0F0
	private static int SakashoRaidbossGetRaidboss(int callbackId, string json)
	{
        return ExternLib.LibSakasho.SakashoRaidbossGetRaidboss(callbackId, json);
	}

	// // RVA: 0x2E5F1F8 Offset: 0x2E5F1F8 VA: 0x2E5F1F8
	private static int SakashoRaidbossRequestRaidbossHelp(int callbackId, string json)
	{
        return ExternLib.LibSakasho.SakashoRaidbossRequestRaidbossHelp(callbackId, json);
	}

	// // RVA: 0x2E5F308 Offset: 0x2E5F308 VA: 0x2E5F308
	// private static extern int SakashoRaidbossGetRaidbosses(int callbackId, string json) { }

	// // RVA: 0x2E5F418 Offset: 0x2E5F418 VA: 0x2E5F418
	// private static extern int SakashoRaidbossJoinRaidboss(int callbackId, string json) { }
}
