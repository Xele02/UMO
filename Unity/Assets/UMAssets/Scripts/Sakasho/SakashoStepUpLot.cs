using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoStepUpLot : SakashoAPIBase
{
	//// RVA: 0x2E684B4 Offset: 0x2E684B4 VA: 0x2E684B4
	//public static SakashoAPICallContext GetStepUpLotRecords(OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E68598 Offset: 0x2E68598 VA: 0x2E68598
	//public static SakashoAPICallContext GetStepUpLotDetail(string key, int itemProbabilityDisplayDigit, int groupKeyProbabilityDisplayDigit, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E687C8 Offset: 0x2E687C8 VA: 0x2E687C8
	public static SakashoAPICallContext Purchase(string key, string hash, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if (key != null)
			h["key"] = key;
		if (hash != null)
			h["hash"] = hash;
		return new SakashoAPICallContext(Call(SakashoStepUpLotPurchase, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E68988 Offset: 0x2E68988 VA: 0x2E68988
	//private static extern int SakashoStepUpLotGetStepUpLotRecords(int callbackId, string json) { }

	//// RVA: 0x2E68A98 Offset: 0x2E68A98 VA: 0x2E68A98
	//private static extern int SakashoStepUpLotGetStepUpLotDetail(int callbackId, string json) { }

	//// RVA: 0x2E68BA8 Offset: 0x2E68BA8 VA: 0x2E68BA8
	private static int SakashoStepUpLotPurchase(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoStepUpLotPurchase(callbackId, json);
	}
}
