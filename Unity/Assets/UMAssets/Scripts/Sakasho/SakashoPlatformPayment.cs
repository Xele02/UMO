using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoPlatformPayment : SakashoAPIBase
{
	//// RVA: 0x2E57F90 Offset: 0x2E57F90 VA: 0x2E57F90
	public static SakashoAPICallContext GetProducts(string cursor, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if(cursor != null)
		{
			h["cursor"] = cursor;
		}
		return new SakashoAPICallContext(Call(SakashoPlatformPaymentGetProducts, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E58108 Offset: 0x2E58108 VA: 0x2E58108
	public static SakashoAPICallContext Recover(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoPlatformPaymentRecover, "", onSuccess, onError));
	}

	//// RVA: 0x2E581EC Offset: 0x2E581EC VA: 0x2E581EC
	//public static SakashoAPICallContext Purchase(string sku, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E58364 Offset: 0x2E58364 VA: 0x2E58364
	//public static SakashoAPICallContext GetPaymentHistories(int year, int month, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E58550 Offset: 0x2E58550 VA: 0x2E58550
	//public static SakashoAPICallContext GetPurchaseCount(string platform_product_unique_key, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E586C8 Offset: 0x2E586C8 VA: 0x2E586C8
	public static SakashoAPICallContext GetSubscriptionStatuses(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoPlatformPaymentGetSubscriptionStatuses, "", onSuccess, onError));
	}

	//// RVA: 0x2E587AC Offset: 0x2E587AC VA: 0x2E587AC
	//public static SakashoAPICallContext ClaimSubscriptionContinuationBonus(OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E58890 Offset: 0x2E58890 VA: 0x2E58890
	//private static extern int SakashoPlatformPaymentGetProducts(int callbackId, string json) { }
	private static int SakashoPlatformPaymentGetProducts(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlatformPaymentGetProducts(callbackId, json);
	}

	//// RVA: 0x2E589A0 Offset: 0x2E589A0 VA: 0x2E589A0
	//private static extern int SakashoPlatformPaymentRecover(int callbackId, string json) { }
	private static int SakashoPlatformPaymentRecover(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlatformPaymentRecover(callbackId, json);
	}

	//// RVA: 0x2E58AB0 Offset: 0x2E58AB0 VA: 0x2E58AB0
	//private static extern int SakashoPlatformPaymentPurchase(int callbackId, string json) { }

	//// RVA: 0x2E58BC0 Offset: 0x2E58BC0 VA: 0x2E58BC0
	//private static extern int SakashoPlatformPaymentGetPaymentHistories(int callbackId, string json) { }

	//// RVA: 0x2E58CD8 Offset: 0x2E58CD8 VA: 0x2E58CD8
	//private static extern int SakashoPlatformPaymentGetPurchaseCount(int callbackId, string json) { }

	//// RVA: 0x2E58DF0 Offset: 0x2E58DF0 VA: 0x2E58DF0
	private static int SakashoPlatformPaymentGetSubscriptionStatuses(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoPlatformPaymentGetSubscriptionStatuses(callbackId, json);
	}

	//// RVA: 0x2E58F10 Offset: 0x2E58F10 VA: 0x2E58F10
	//private static extern int SakashoPlatformPaymentClaimSubscriptionContinuationBonus(int callbackId, string json) { }
}
