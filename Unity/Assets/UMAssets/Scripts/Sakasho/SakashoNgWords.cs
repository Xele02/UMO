using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;
using System.Collections.Generic;

public class SakashoNgWords : SakashoAPIBase
{
	//// RVA: 0x2E519EC Offset: 0x2E519EC VA: 0x2E519EC
	//public static SakashoAPICallContext GetNgWords(OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E51AD0 Offset: 0x2E51AD0 VA: 0x2E51AD0
	public static SakashoAPICallContext Validate(IDictionary<string, string> targets, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if(targets != null)
		{
			h["targets"] = targets;
		}
		return new SakashoAPICallContext(Call(SakashoNgWordsValidate, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E51C48 Offset: 0x2E51C48 VA: 0x2E51C48
	//public static SakashoAPICallContext InitializeMorphEngine(string systemDicPath, string userDicPath, string ngWords, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E51E48 Offset: 0x2E51E48 VA: 0x2E51E48
	//public static SakashoAPICallContext ValidateAtClientSide(string text, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E51FC0 Offset: 0x2E51FC0 VA: 0x2E51FC0
	//public static SakashoAPICallContext FinishMorphEngine(OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E520A4 Offset: 0x2E520A4 VA: 0x2E520A4
	//public static SakashoAPICallContext GetMorphEngineStatus(OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E52188 Offset: 0x2E52188 VA: 0x2E52188
	//private static extern int SakashoNgWordsGetNgWords(int callbackId, string json) { }

	//// RVA: 0x2E522D0 Offset: 0x2E522D0 VA: 0x2E522D0
	private static /*ectern*/ int SakashoNgWordsValidate(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoNgWordsValidate(callbackId, json);
	}

	//// RVA: 0x2E52410 Offset: 0x2E52410 VA: 0x2E52410
	//private static extern int SakashoNgWordsInitializeMorphEngine(int callbackId, string json) { }

	//// RVA: 0x2E52520 Offset: 0x2E52520 VA: 0x2E52520
	//private static extern int SakashoNgWordsValidateAtClientSide(int callbackId, string json) { }

	//// RVA: 0x2E52630 Offset: 0x2E52630 VA: 0x2E52630
	//private static extern int SakashoNgWordsFinishMorphEngine(int callbackId, string json) { }

	//// RVA: 0x2E52740 Offset: 0x2E52740 VA: 0x2E52740
	//private static extern int SakashoNgWordsGetMorphEngineStatus(int callbackId, string json) { }
}
