using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoPayment : SakashoAPIBase
{
	// RVA: 0x2E534A8 Offset: 0x2E534A8 VA: 0x2E534A8
	//public static SakashoAPICallContext GetLotBoxMaster(int id, int round, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2E53694 Offset: 0x2E53694 VA: 0x2E53694
	//public static SakashoAPICallContext GetLotBoxForPlayer(int id, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2E53824 Offset: 0x2E53824 VA: 0x2E53824
	//public static SakashoAPICallContext UpgradeLotBoxForPlayer(int id, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2E539B4 Offset: 0x2E539B4 VA: 0x2E539B4
	public static SakashoAPICallContext GetProducts(SakashoProductCriteria criteria, int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if(criteria != null)
		{
			h["currencyId"] = criteria.CurrencyId;
			if(criteria.Label != null)
			{
				h["label"] = criteria.Label;
			}
			h["productType"] = criteria.ProductType;
			if(criteria.MasterGroupName != null)
				h["masterGroupName"] = criteria.MasterGroupName;
		}
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoPaymentGetProducts, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// RVA: 0x2E53D34 Offset: 0x2E53D34 VA: 0x2E53D34
	public static SakashoAPICallContext Purchase(int productId, int quantity, int currencyId, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["productId"] = productId;
		h["quantity"] = quantity;
		h["currencyId"] = currencyId;
		return new SakashoAPICallContext(Call(SakashoPaymentPurchase, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// RVA: 0x2E53F7C Offset: 0x2E53F7C VA: 0x2E53F7C
	public static SakashoAPICallContext GetRemainingForCurrencyIds(int[] ids, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if (ids != null)
		{
			l = new ArrayList();
			for(int i = 0; i < ids.Length; i++)
			{
				l.Add(ids[i]);
			}
		}
		h["ids"] = l;
		return new SakashoAPICallContext(Call(SakashoPaymentGetRemainingForCurrencyIds, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// RVA: 0x2E541B8 Offset: 0x2E541B8 VA: 0x2E541B8
	public static SakashoAPICallContext PurchaseAndSave(int productId, int quantity, int currencyId, string[] names, string playerData, bool replace, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["productId"] = productId;
		h["quantity"] = quantity;
		h["currencyId"] = currencyId;
		ArrayList ar = null;
		if(names != null)
		{
			ar = new ArrayList();
			for(int i = 0; i < names.Length; i++)
			{
				if(names[i] != null)
				{
					ar.Add(names[i]);
				}
			}
		}
		h["names"] = ar;
		h["playerData"] = playerData;
		h["replace"] = replace;
		return new SakashoAPICallContext(Call(SakashoPaymentPurchaseAndSave, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// RVA: 0x2E54580 Offset: 0x2E54580 VA: 0x2E54580
	//public static SakashoAPICallContext GetGroupedProductBoughtCount(int[] groupKeys, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2E547BC Offset: 0x2E547BC VA: 0x2E547BC
	//public static SakashoAPICallContext PurchaseAndSave(int productId, int quantity, int currencyId, string[] names, string playerData, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2E547F0 Offset: 0x2E547F0 VA: 0x2E547F0
	public static SakashoAPICallContext GetPurchasingStatus(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoPaymentGetPurchasingStatus, "", onSuccess, onError));
	}

	// RVA: 0x2E548D4 Offset: 0x2E548D4 VA: 0x2E548D4
	public static SakashoAPICallContext Recover(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoPaymentRecover, "", onSuccess, onError));
	}

	// RVA: 0x2E549B8 Offset: 0x2E549B8 VA: 0x2E549B8
	//public static SakashoAPICallContext GetProductsWithItemSetDetail(SakashoProductCriteria criteria, int page, int ipp, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2E54D38 Offset: 0x2E54D38 VA: 0x2E54D38
	//public static SakashoAPICallContext GetPayments(string cursor, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2E54EB0 Offset: 0x2E54EB0 VA: 0x2E54EB0
	public static SakashoAPICallContext GetVirtualCurrencyBalancesWithExpiredAt(int[] virtualCurrencyIds, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if (virtualCurrencyIds != null)
		{
			l = new ArrayList();
			for (int i = 0; i < virtualCurrencyIds.Length; i++)
			{
				l.Add(virtualCurrencyIds[i]);
			}
		}
		h["virtualCurrencyIds"] = l;
		return new SakashoAPICallContext(Call(SakashoPaymentGetVirtualCurrencyBalancesWithExpiredAt, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// RVA: 0x2E550EC Offset: 0x2E550EC VA: 0x2E550EC
	//public static SakashoAPICallContext GetBoughtQuantity(int[] productIds, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2E55328 Offset: 0x2E55328 VA: 0x2E55328
	//public static SakashoAPICallContext GetTransactionState(int[] productIds, OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2E55568 Offset: 0x2E55568 VA: 0x2E55568
	//private static extern int SakashoPaymentGetLotBoxMaster(int callbackId, string json) { }

	// RVA: 0x2E55678 Offset: 0x2E55678 VA: 0x2E55678
	//private static extern int SakashoPaymentGetLotBoxForPlayer(int callbackId, string json) { }

	// RVA: 0x2E55788 Offset: 0x2E55788 VA: 0x2E55788
	//private static extern int SakashoPaymentUpgradeLotBoxForPlayer(int callbackId, string json) { }

	// RVA: 0x2E558A0 Offset: 0x2E558A0 VA: 0x2E558A0
	//private static extern int SakashoPaymentGetProducts(int callbackId, string json) { }
	private static int SakashoPaymentGetProducts(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPaymentGetProducts(callbackId, json);
	}

	// RVA: 0x2E559E8 Offset: 0x2E559E8 VA: 0x2E559E8
	private static int SakashoPaymentPurchase(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPaymentPurchase(callbackId, json);
	}

	// RVA: 0x2E55B28 Offset: 0x2E55B28 VA: 0x2E55B28
	//private static extern int SakashoPaymentGetRemainingForCurrencyIds(int callbackId, string json) { }
	private static int SakashoPaymentGetRemainingForCurrencyIds(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPaymentGetRemainingForCurrencyIds(callbackId, json);
	}

	// RVA: 0x2E55C40 Offset: 0x2E55C40 VA: 0x2E55C40
	private static int SakashoPaymentPurchaseAndSave(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPaymentPurchaseAndSave(callbackId, json);
	}

	// RVA: 0x2E55D50 Offset: 0x2E55D50 VA: 0x2E55D50
	//private static extern int SakashoPaymentGetGroupedProductBoughtCount(int callbackId, string json) { }

	// RVA: 0x2E55E68 Offset: 0x2E55E68 VA: 0x2E55E68
	private static int SakashoPaymentGetPurchasingStatus(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPaymentGetPurchasingStatus(callbackId, json);
	}

	// RVA: 0x2E55F78 Offset: 0x2E55F78 VA: 0x2E55F78
	//private static extern int SakashoPaymentRecover(int callbackId, string json) { }
	private static int SakashoPaymentRecover(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPaymentRecover(callbackId, json);
	}

	// RVA: 0x2E560B8 Offset: 0x2E560B8 VA: 0x2E560B8
	//private static extern int SakashoPaymentGetProductsWithItemSetDetail(int callbackId, string json) { }

	// RVA: 0x2E561D0 Offset: 0x2E561D0 VA: 0x2E561D0
	//private static extern int SakashoPaymentGetPayments(int callbackId, string json) { }

	// RVA: 0x2E56318 Offset: 0x2E56318 VA: 0x2E56318
	//private static extern int SakashoPaymentGetVirtualCurrencyBalancesWithExpiredAt(int callbackId, string json)
	private static int SakashoPaymentGetVirtualCurrencyBalancesWithExpiredAt(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPaymentGetVirtualCurrencyBalancesWithExpiredAt(callbackId, json);
	}

	// RVA: 0x2E56440 Offset: 0x2E56440 VA: 0x2E56440
	//private static extern int SakashoPaymentGetBoughtQuantity(int callbackId, string json) { }

	// RVA: 0x2E56550 Offset: 0x2E56550 VA: 0x2E56550
	//private static extern int SakashoPaymentGetTransactionState(int callbackId, string json) { }

	// RVA: 0x2E56660 Offset: 0x2E56660 VA: 0x2E56660
	//public void .ctor() { }
}
