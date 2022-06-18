using System.Threading;
using System.Collections.Generic;
using SakashoSystemCallback;
using System;

public class SakashoCallbackRegistry
{
	private static IDictionary<int, ISakashoCallbackHandler> successHandlers = new Dictionary<int, ISakashoCallbackHandler>(); // 0x0
	private static IDictionary<int, ISakashoCallbackHandler> errorHandlers = new Dictionary<int, ISakashoCallbackHandler>(); // 0x4
	private static int lastCallbackId = 0; // 0x8
	private static IDictionary<int, int> callIdFromCallbackId = new Dictionary<int, int>(); // 0xC
	private static IDictionary<int, int> callbackIdFromCallId = new Dictionary<int, int>(); // 0x10
	private static object lockObject = new object(); // 0x14

	public static string GameObjectName { get; set; } // 0x18
	public static ISakashoQueueHolder MainThreadQueueHolder { get; set; } // 0x1C

	// // RVA: 0x3079714 Offset: 0x3079714 VA: 0x3079714
	private static void ParseMessage(string message, out int callbackId, out string json)
    {
        int idx = message.IndexOf(":");
        callbackId = Int32.Parse(message.Substring(0, idx));
        json = message.Substring(idx+1);
    }

	// // RVA: 0x3077424 Offset: 0x3077424 VA: 0x3077424
	public static int WithdrawCallbackId()
    {
        Monitor.Enter(lockObject);
        int val = lastCallbackId + 1;
        lastCallbackId = val;
        Monitor.Exit(lockObject);
        return val;
    }

	// // RVA: 0x3077B08 Offset: 0x3077B08 VA: 0x3077B08
    public static void SetCallback(int callbackId, OnSuccess onSuccess, OnError onError)
    {
        Monitor.Enter(lockObject);
        RemoveCallback(callbackId);
        successHandlers.Add(callbackId, new SakashoSuccessCallbackHandler(callbackId, onSuccess));
        errorHandlers.Add(callbackId, new SakashoErrorCallbackHandler(callbackId, onError));
        Monitor.Exit(lockObject);
    }

	// // RVA: 0x3078E44 Offset: 0x3078E44 VA: 0x3078E44
	public static void RemoveCallback(int callbackId)
    {
        Monitor.Enter(lockObject);
        successHandlers.Remove(callbackId);
        errorHandlers.Remove(callbackId);
        if(callIdFromCallbackId.ContainsKey(callbackId))
        {
            int callId = callIdFromCallbackId[callbackId];
            callIdFromCallbackId.Remove(callbackId);
            callbackIdFromCallId.Remove(callId);
        }
        Monitor.Exit(lockObject);
    }

	// // RVA: 0x3078110 Offset: 0x3078110 VA: 0x3078110
	// public static void RemoveCallbackByCallId(int callId) { }

	// // RVA: 0x3077DFC Offset: 0x3077DFC VA: 0x3077DFC
	public static void SetCallbackIdPair(int callbackId, int callId)
    {
        //?? test callbackId / callId valid
        // bVar5 = SBORROW4(callbackId,1);
        // iVar1 = callbackId + -1;
        // if (0 < callbackId) {
        //     bVar5 = SBORROW4(callId,1);
        //     iVar1 = callId + -1;
        // }
        // if (iVar1 < 0 != bVar5) {
        //     return;
        // }

        Monitor.Enter(lockObject);
        callIdFromCallbackId[callbackId] = callId;
        callbackIdFromCallId[callId] = callbackId;
        Monitor.Exit(lockObject);
    }

	// // RVA: 0x3079858 Offset: 0x3079858 VA: 0x3079858
	public static void FireOnSuccess(string message)
    {
        int callId;
        string json;
        ParseMessage(message, out callId, out json);
        Monitor.Enter(lockObject);

        if(successHandlers.ContainsKey(callId))
        {
            successHandlers[callId].Callback(json);
        }

        Monitor.Exit(lockObject);
    }

	// // RVA: 0x3079BA8 Offset: 0x3079BA8 VA: 0x3079BA8
	// public static void FireOnError(string message) { }

	// // RVA: 0x3079EF8 Offset: 0x3079EF8 VA: 0x3079EF8
	public static bool RunOnMainThread(Action action)
    {
        MainThreadQueueHolder.PushToQueue(action);
        return true;
    }
}
