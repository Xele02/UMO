using SakashoSystemCallback;
using UnityEngine;

public abstract class SakashoAPIBase
{
    public delegate int APICall(int callbackId, string json);
    
	// // RVA: 0x307737C Offset: 0x307737C VA: 0x307737C
	public static int Call(APICall method, string json, OnSuccess onSuccess, OnError onError)
    {
        int callbackId = SakashoCallbackRegistry.WithdrawCallbackId();
        return Call(method, json, callbackId, onSuccess, onError);
    }

	// // RVA: 0x3077630 Offset: 0x3077630 VA: 0x3077630
	// public static int Call(SakashoAPIBase.APICall method, string json) { }

	// // RVA: 0x3077564 Offset: 0x3077564 VA: 0x3077564
	public static int Call(APICall method, string json, int callbackId, OnSuccess onSuccess, OnError onError)
    {
        SakashoCallbackRegistry.SetCallback(callbackId, onSuccess, onError);
        UnityEngine.Debug.Log("[Sakasho] Call : "+method.Method.ToString()+"\n"+(json != null ? json.Substring(0, Mathf.Min(json.Length, 500)) : ""));
        int callId = method(callbackId, json);
        SakashoCallbackRegistry.SetCallbackIdPair(callbackId, callId);
        return callId;
    }

	// // RVA: 0x3078090 Offset: 0x3078090 VA: 0x3078090
	public static void RemoveCallbackByCallId(int callId)
	{
		SakashoCallbackRegistry.RemoveCallbackByCallId(callId);
	}
}
