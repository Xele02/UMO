
using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoNormalLotProduct : SakashoAPIBase
{
	//// RVA: 0x2E52858 Offset: 0x2E52858 VA: 0x2E52858
	public static SakashoAPICallContext GetNormalLotItems(int productId, int quantity, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["productId"] = productId;
		h["quantity"] = quantity;
		return new SakashoAPICallContext(Call(SakashoNormalLotProductGetNormalLotItems, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E52A48 Offset: 0x2E52A48 VA: 0x2E52A48
	private static int SakashoNormalLotProductGetNormalLotItems(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoNormalLotProductGetNormalLotItems(callbackId, json);
	}
}
