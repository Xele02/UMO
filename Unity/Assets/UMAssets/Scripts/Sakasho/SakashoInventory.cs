using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoInventory : SakashoAPIBase
{
	public static class InventoryType
	{
		public const int ALL = -1;
		public const int PURCHASED = 100;
		public const int GIVEN_AS_LOGIN_BONUS = 105;
		public const int REWARD_FOR_INVITATION = 106;
		public const int PURCHASED_WITH_VC = 108;
		public const int GIVEN_AS_ACHIEVEMENT = 109;
		public const int GIVEN_AS_CBT_INCENTIVE = 110;
		public const int GIVEN_AS_RANKING_REWARD = 111;
		public const int GIVEN_AS_STEP_UP_LOT = 113;
	}

	//// RVA: 0x2BC8BAC Offset: 0x2BC8BAC VA: 0x2BC8BAC
	public static SakashoAPICallContext GetInventoryRecords(long[] ids, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if(ids != null)
		{
			l = new ArrayList();
			for(int i = 0; i < ids.Length; i++)
			{
				l.Add(ids[i]);
			}
		}
		h["ids"] = l;
		return new SakashoAPICallContext(Call(SakashoInventoryGetInventoryRecords, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BC8DF0 Offset: 0x2BC8DF0 VA: 0x2BC8DF0
	public static SakashoAPICallContext ReceiveVirtualCurrencyFromInventory(long[] ids, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if(ids != null)
		{
			l = new ArrayList();
			for(int i = 0; i < ids.Length; i++)
			{
				l.Add(ids[i].ToString());
			}
		}
		h["ids"] = l;
		return new SakashoAPICallContext(Call(SakashoInventoryReceiveVirtualCurrencyFromInventory, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BC9034 Offset: 0x2BC9034 VA: 0x2BC9034
	public static SakashoAPICallContext GetInventories(int page, int ipp, SakashoInventoryCriteria criteria, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["page"] = page;
		h["ipp"] = ipp;
		if(criteria != null)
		{
			h["onlyUnreceived"] = criteria.OnlyUnreceived;
			h["type"] = criteria.Type;
			ArrayList l = null;
			if(criteria.Types != null)
			{
				l = new ArrayList();
				for(int i = 0; i < criteria.Types.Length; i++)
				{
					l.Add(criteria.Types[i]);
				}
			}
			h["types"] = l;
		}
		return new SakashoAPICallContext(Call(SakashoInventoryGetInventories, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BC93E8 Offset: 0x2BC93E8 VA: 0x2BC93E8
	private static int SakashoInventoryGetInventoryRecords(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoInventoryGetInventoryRecords(callbackId, json);
	}

	//// RVA: 0x2BC94F8 Offset: 0x2BC94F8 VA: 0x2BC94F8
	private static int SakashoInventoryReceiveVirtualCurrencyFromInventory(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoInventoryReceiveVirtualCurrencyFromInventory(callbackId, json);
	}

	//// RVA: 0x2BC9618 Offset: 0x2BC9618 VA: 0x2BC9618
	//private static extern int SakashoInventoryGetInventories(int callbackId, string json) { }
	private static int SakashoInventoryGetInventories(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoInventoryGetInventories(callbackId, json);
	}
}
