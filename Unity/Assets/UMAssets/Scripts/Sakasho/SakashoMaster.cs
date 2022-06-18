using System.Collections.Generic;
using System.Collections;
using Sakasho.JSON;
using SakashoSystemCallback;

public class SakashoMaster : SakashoAPIBase
{
	// // RVA: 0x2BCC5BC Offset: 0x2BCC5BC VA: 0x2BCC5BC
	public static SakashoAPICallContext GetMasters(string[] names, OnSuccess onSuccess, OnError onError)
    {
        Hashtable ht = new Hashtable();
        ArrayList al = null;
        if(names != null)
        {
            al = new ArrayList();
            for(int i = 0; i < names.Length; i++)
            {
                if(names[i] != null)
                {
                    al.Add(names[i]);
                }
            }
        }
        ht["names"] = al;
        int callId = SakashoAPIBase.Call(SakashoMasterGetMasters, MiniJSON.jsonEncode(ht), onSuccess, onError);
        return new SakashoAPICallContext(callId);
    }

	// // RVA: 0x2BCC800 Offset: 0x2BCC800 VA: 0x2BCC800
	// public static SakashoAPICallContext GetMasterRecord(string name, int id, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BCC9D4 Offset: 0x2BCC9D4 VA: 0x2BCC9D4
	// private static SakashoAPICallContext GetDistributionSchedulesInternal(Nullable<int> label, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BCCB94 Offset: 0x2BCCB94 VA: 0x2BCCB94
	// public static SakashoAPICallContext GetDistributionSchedules(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BCCBBC Offset: 0x2BCCBBC VA: 0x2BCCBBC
	// public static SakashoAPICallContext GetDistributionSchedules(int label, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BCCC54 Offset: 0x2BCCC54 VA: 0x2BCCC54
	// public static SakashoAPICallContext GetMasterRecords(string name, int[] ids, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BCCEDC Offset: 0x2BCCEDC VA: 0x2BCCEDC
	// public static SakashoAPICallContext GetMastersWithGlob(string query, bool onlyPermitted, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BCD0B0 Offset: 0x2BCD0B0 VA: 0x2BCD0B0
	private static /*extern */int SakashoMasterGetMasters(int callbackId, string json)
    {
        return ExternLib.LibSakasho.SakashoMasterGetMasters(callbackId, json);
    }

	// // RVA: 0x2BCD1F0 Offset: 0x2BCD1F0 VA: 0x2BCD1F0
	// private static extern int SakashoMasterGetMasterRecord(int callbackId, string json) { }

	// // RVA: 0x2BCD300 Offset: 0x2BCD300 VA: 0x2BCD300
	// private static extern int SakashoMasterGetDistributionSchedulesInternal(int callbackId, string json) { }

	// // RVA: 0x2BCD420 Offset: 0x2BCD420 VA: 0x2BCD420
	// private static extern int SakashoMasterGetMasterRecords(int callbackId, string json) { }

	// // RVA: 0x2BCD530 Offset: 0x2BCD530 VA: 0x2BCD530
	// private static extern int SakashoMasterGetMastersWithGlob(int callbackId, string json) { }
}
