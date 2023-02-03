using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoFCMPushNotification : SakashoAPIBase
{
	// RVA: 0x2BBA5B8 Offset: 0x2BBA5B8 VA: 0x2BBA5B8
	public static SakashoAPICallContext GetFCMTokens(OnSuccess onSuccess, OnError onError)
	{
		int callID = Call(SakashoFCMPushNotificationGetFCMTokens, "", onSuccess, onError);
		return new SakashoAPICallContext(callID);
	}

	//// RVA: 0x2BBA69C Offset: 0x2BBA69C VA: 0x2BBA69C
	public static SakashoAPICallContext AcceptPushNotification(string fcm_token, OnSuccess onSuccess, OnError onError)
	{
		Hashtable hash = new Hashtable();
		if (fcm_token != null)
			hash["fcm_token"] = fcm_token;

		int callID = Call(SakashoFCMPushNotificationAcceptPushNotification, MiniJSON.jsonEncode(hash), onSuccess, onError);
		return new SakashoAPICallContext(callID);
	}

	//// RVA: 0x2BBA814 Offset: 0x2BBA814 VA: 0x2BBA814
	public static SakashoAPICallContext BlockPushNotification(string fcmToken, OnSuccess onSuccess, OnError onError)
	{
		Hashtable hash = new Hashtable();
		if (fcmToken != null)
			hash["fcmToken"] = fcmToken;

		int callID = Call(SakashoFCMPushNotificationBlockPushNotification, MiniJSON.jsonEncode(hash), onSuccess, onError);
		return new SakashoAPICallContext(callID);
	}

	//// RVA: 0x2BBA98C Offset: 0x2BBA98C VA: 0x2BBA98C
	//public static SakashoAPICallContext SendPushNotification(int[] recipientIds, SakashoFCMPushNotificationPayload payload, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBAF18 Offset: 0x2BBAF18 VA: 0x2BBAF18
	//public static SakashoAPICallContext AcceptPushNotificationWithTimeZoneAndLocale(string fcm_token, string time_zone, string locale, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBB118 Offset: 0x2BBB118 VA: 0x2BBB118
	private static /*extern */int SakashoFCMPushNotificationGetFCMTokens(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFCMPushNotificationGetFCMTokens(callbackId, json);
	}

	//// RVA: 0x2BBB230 Offset: 0x2BBB230 VA: 0x2BBB230
	private static /*extern */int SakashoFCMPushNotificationAcceptPushNotification(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFCMPushNotificationAcceptPushNotification(callbackId, json);
	}

	//// RVA: 0x2BBB350 Offset: 0x2BBB350 VA: 0x2BBB350
	private static /*extern */int SakashoFCMPushNotificationBlockPushNotification(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFCMPushNotificationBlockPushNotification(callbackId, json);
	}

	//// RVA: 0x2BBB470 Offset: 0x2BBB470 VA: 0x2BBB470
	//private static extern int SakashoFCMPushNotificationSendPushNotification(int callbackId, string json) { }

	//// RVA: 0x2BBB590 Offset: 0x2BBB590 VA: 0x2BBB590
	//private static extern int SakashoFCMPushNotificationAcceptPushNotificationWithTimeZoneAndLocale(int callbackId, string json) { }
}
