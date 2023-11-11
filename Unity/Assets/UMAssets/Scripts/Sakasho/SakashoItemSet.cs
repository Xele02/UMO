using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoItemSet : SakashoAPIBase
{
	// RVA: 0x2BC972C Offset: 0x2BC972C VA: 0x2BC972C
	public static SakashoAPICallContext GetItemSetRecord(string itemSetName, int itemProbabilityDisplayDigit, int groupKeyProbabilityDisplayDigit, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if (itemSetName != null)
			h["itemSetName"] = itemSetName;
		h["itemProbabilityDisplayDigit"] = itemProbabilityDisplayDigit;
		h["groupKeyProbabilityDisplayDigit"] = groupKeyProbabilityDisplayDigit;
		return new SakashoAPICallContext(Call(SakashoItemSetGetItemSetRecord, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	// RVA: 0x2BC9960 Offset: 0x2BC9960 VA: 0x2BC9960
	private static int SakashoItemSetGetItemSetRecord(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoItemSetGetItemSetRecord(callbackId, json);
	}
}
