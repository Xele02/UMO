using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoAchievement : SakashoAPIBase
{
	//// RVA: 0x2BB0364 Offset: 0x2BB0364 VA: 0x2BB0364
	public static SakashoAPICallContext GetAchievementRecords(string[] keys, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if (keys != null)
		{
			l = new ArrayList();
			for(int i = 0; i < keys.Length; i++)
			{
				if(keys[i] != null)
				{
					l.Add(keys[i]);
				}
			}
		}
		h["keys"] = l;
		return new SakashoAPICallContext(Call(SakashoAchievementGetAchievementRecords, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BB05A8 Offset: 0x2BB05A8 VA: 0x2BB05A8
	public static SakashoAPICallContext ClaimAchievementPrizes(string[] keys, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if(keys != null)
		{
			l = new ArrayList();
			for(int i = 0; i < keys.Length; i++)
			{
				l.Add(l[i]);
			}
		}
		h["keys"] = l;
		return new SakashoAPICallContext(Call(SakashoAchievementClaimAchievementPrizes, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BB07EC Offset: 0x2BB07EC VA: 0x2BB07EC
	//public static SakashoAPICallContext ClaimAchievementPrizesAndSave(string[] keys, string[] names, string playerData, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BB0C14 Offset: 0x2BB0C14 VA: 0x2BB0C14
	//public static SakashoAPICallContext ClaimAchievementPrizesAndSave(string[] keys, string[] names, string playerData, bool asReceived, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BB0818 Offset: 0x2BB0818 VA: 0x2BB0818
	public static SakashoAPICallContext ClaimAchievementPrizesAndSave(string[] keys, string[] names, string playerData, bool asReceived, bool replace, OnSuccess onSuccess, OnError onError)
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
		l = null;
		if (names != null)
		{
			l = new ArrayList();
			for (int i = 0; i < names.Length; i++)
			{
				if (names[i] != null)
				{
					l.Add(names[i]);
				}
			}
		}
		h["names"] = l;
		if (playerData != null)
		{
			h["playerData"] = playerData;
		}
		h["asReceived"] = asReceived;
		h["replace"] = replace;
		return new SakashoAPICallContext(Call(SakashoAchievementClaimAchievementPrizesAndSave, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BB0C3C Offset: 0x2BB0C3C VA: 0x2BB0C3C
	public static SakashoAPICallContext ClaimAchievementPrizesSetInventoryClosedAt(string[] keys, int[] inventoryClosedAt, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if(keys != null)
		{
			l = new ArrayList();
			for(int i = 0; i < keys.Length; i++)
			{
				l.Add(keys[i]);
			}
		}
		h["keys"] = l;
		l = null;
		if(inventoryClosedAt != null)
		{
			l = new ArrayList();
			for(int i = 0; i < inventoryClosedAt.Length; i++)
			{
				l.Add(inventoryClosedAt[i]);
			}
		}
		h["inventoryClosedAt"] = l;
		return new SakashoAPICallContext(Call(SakashoAchievementClaimAchievementPrizesSetInventoryClosedAt, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BB0FB4 Offset: 0x2BB0FB4 VA: 0x2BB0FB4
	public static SakashoAPICallContext ClaimAchievementPrizesAndSaveSetInventoryClosedAt(string[] keys, string[] names, string playerData, bool asReceived, bool replace, int[] inventoryClosedAt, OnSuccess onSuccess, OnError onError)
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
		l = null;
		if (names != null)
		{
			l = new ArrayList();
			for (int i = 0; i < names.Length; i++)
			{
				if (names[i] != null)
				{
					l.Add(names[i]);
				}
			}
		}
		h["names"] = l;
		if (playerData != null)
		{
			h["playerData"] = playerData;
		}
		h["asReceived"] = asReceived;
		h["replace"] = replace;
		l = null;
		if (inventoryClosedAt != null)
		{
			l = new ArrayList();
			for (int i = 0; i < inventoryClosedAt.Length; i++)
			{
				l.Add(inventoryClosedAt[i]);
			}
		}
		h["inventoryClosedAt"] = l;
		return new SakashoAPICallContext(Call(SakashoAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BB14C0 Offset: 0x2BB14C0 VA: 0x2BB14C0
	private static /*extern */int SakashoAchievementGetAchievementRecords(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoAchievementGetAchievementRecords(callbackId, json);
	}

	//// RVA: 0x2BB15D8 Offset: 0x2BB15D8 VA: 0x2BB15D8
	private static int SakashoAchievementClaimAchievementPrizes(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoAchievementClaimAchievementPrizes(callbackId, json);
	}

	//// RVA: 0x2BB16F0 Offset: 0x2BB16F0 VA: 0x2BB16F0
	private static /*extern */int SakashoAchievementClaimAchievementPrizesAndSave(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoAchievementClaimAchievementPrizesAndSave(callbackId, json);
	}

	//// RVA: 0x2BB1810 Offset: 0x2BB1810 VA: 0x2BB1810
	private static int SakashoAchievementClaimAchievementPrizesSetInventoryClosedAt(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoAchievementClaimAchievementPrizesSetInventoryClosedAt(callbackId, json);
	}

	//// RVA: 0x2BB1940 Offset: 0x2BB1940 VA: 0x2BB1940
	private static /*extern */int SakashoAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoAchievementClaimAchievementPrizesAndSaveSetInventoryClosedAt(callbackId, json);
	}
}
