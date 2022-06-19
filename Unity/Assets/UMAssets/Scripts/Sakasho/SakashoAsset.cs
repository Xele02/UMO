using System.Collections;
using Sakasho.JSON;
using SakashoSystemCallback;

public class SakashoAsset : SakashoAPIBase
{
	// RVA: 0x2BB3DB0 Offset: 0x2BB3DB0 VA: 0x2BB3DB0
	public static SakashoAPICallContext GetAssetList(string name, OnSuccess onSuccess, OnError onError)
    {
        Hashtable ht = new Hashtable();
        if(name != null)
        {
            ht["name"] = name;
        }

        int callId = SakashoAPIBase.Call(SakashoAssetGetAssetList, MiniJSON.jsonEncode(ht), onSuccess, onError);
        return new SakashoAPICallContext(callId);
    }

	// RVA: 0x2BB3F28 Offset: 0x2BB3F28 VA: 0x2BB3F28
	// public static SakashoAPICallContext GetBaseUrl(OnSuccess onSuccess, OnError onError) { }

	// RVA: 0x2BB4010 Offset: 0x2BB4010 VA: 0x2BB4010
	private static /*extern*/ int SakashoAssetGetAssetList(int callbackId, string json)
    {
        return ExternLib.LibSakasho.SakashoAssetGetAssetList(callbackId, json);
    }

	// RVA: 0x2BB4158 Offset: 0x2BB4158 VA: 0x2BB4158
	// private static extern int SakashoAssetGetBaseUrl(int callbackId, string json) { }
}
