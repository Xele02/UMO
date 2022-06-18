using System.Collections;
using Sakasho.JSON;
using SakashoSystemCallback;


public class SakashoInquiry : SakashoAPIBase
{
	// // RVA: 0x2BC7A48 Offset: 0x2BC7A48 VA: 0x2BC7A48
	// public static SakashoAPICallContext GetInquiryResponses(int page, int ipp, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BC7C34 Offset: 0x2BC7C34 VA: 0x2BC7C34
	// public static SakashoAPICallContext GetInquiryResponse(int uid, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BC7DC4 Offset: 0x2BC7DC4 VA: 0x2BC7DC4
	// public static SakashoAPICallContext SetInquiryResponseStatus(int uid, int state, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BC7FB0 Offset: 0x2BC7FB0 VA: 0x2BC7FB0
	// public static SakashoAPICallContext DeleteInquiryResponse(int uid, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BC8140 Offset: 0x2BC8140 VA: 0x2BC8140
	// public static SakashoAPICallContext SendInquiry(string subject, string body, Nullable<int> inReplyToUid, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2BC8388 Offset: 0x2BC8388 VA: 0x2BC8388
	public static SakashoAPICallContext GetInquiryResponsesNumber(string searchQuery, OnSuccess onSuccess, OnError onError)
    {
        Hashtable ht = new Hashtable();
        if(searchQuery != null)
        {
            ht["searchQuery"] = searchQuery;
        }
        int callId = SakashoAPIBase.Call(SakashoInquiryGetInquiryResponsesNumber, MiniJSON.jsonEncode(ht), onSuccess, onError);
        return new SakashoAPICallContext(callId);
    }

	// // RVA: 0x2BC8500 Offset: 0x2BC8500 VA: 0x2BC8500
	// private static extern int SakashoInquiryGetInquiryResponses(int callbackId, string json) { }

	// // RVA: 0x2BC8610 Offset: 0x2BC8610 VA: 0x2BC8610
	// private static extern int SakashoInquiryGetInquiryResponse(int callbackId, string json) { }

	// // RVA: 0x2BC8720 Offset: 0x2BC8720 VA: 0x2BC8720
	// private static extern int SakashoInquirySetInquiryResponseStatus(int callbackId, string json) { }

	// // RVA: 0x2BC8838 Offset: 0x2BC8838 VA: 0x2BC8838
	// private static extern int SakashoInquiryDeleteInquiryResponse(int callbackId, string json) { }

	// // RVA: 0x2BC8948 Offset: 0x2BC8948 VA: 0x2BC8948
	// private static extern int SakashoInquirySendInquiry(int callbackId, string json) { }

	// // RVA: 0x2BC8A90 Offset: 0x2BC8A90 VA: 0x2BC8A90
	private static /*extern*/ int SakashoInquiryGetInquiryResponsesNumber(int callbackId, string json)
    {
        return ExternLib.LibSakasho.SakashoInquiryGetInquiryResponsesNumber(callbackId, json);
    }

}
