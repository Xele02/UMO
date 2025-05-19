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
	public static SakashoAPICallContext SendPushNotification(int[] recipientIds, SakashoFCMPushNotificationPayload payload, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		ArrayList l = null;
		if(recipientIds != null)
		{
			l = new ArrayList();
			for(int i = 0; i < recipientIds.Length; i++)
			{
				l.Add(recipientIds[i]);
			}
		}
		h["recipientIds"] = l;
		if(payload != null)
		{
			if(payload.Message != null)
			{
				h["message"] = payload.Message;
			}
			if(payload.TimeToLive.HasValue)
			{
				h["timeToLive"] = payload.TimeToLive.Value;
			}
			if(payload.IOSCategory != null)
			{
				h["iOSCategory"] = payload.IOSCategory;
			}
			if(payload.IOSBadgeNumber.HasValue)
			{
				h["iOSBadgeNumber"] = payload.IOSBadgeNumber.Value;
			}
			if(payload.IOSSoundPath != null)
			{
				h["iOSSoundPath"] = payload.IOSSoundPath;
			}
			if(payload.IOSMediaAttachment != null)
			{
				h["iOSMediaAttachment"] = payload.IOSMediaAttachment;
			}
			if(payload.AndroidMessageTitle != null)
			{
				h["androidMessageTitle"] = payload.AndroidMessageTitle;
			}
			if(payload.AndroidCollapseKey != null)
			{
				h["androidCollapseKey"] = payload.AndroidCollapseKey;
			}
			if(payload.AndroidIconName != null)
			{
				h["androidIconName"] = payload.AndroidIconName;
			}
			if(payload.AndroidChannelId != null)
			{
				h["androidChannelId"] = payload.AndroidChannelId;
			}
			if(payload.Extras != null)
			{
				h["extras"] = payload.Extras;
			}
		}
		return new SakashoAPICallContext(Call(SakashoFCMPushNotificationSendPushNotification, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

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
	private static int SakashoFCMPushNotificationSendPushNotification(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFCMPushNotificationSendPushNotification(callbackId, json);
	}

	//// RVA: 0x2BBB590 Offset: 0x2BBB590 VA: 0x2BBB590
	//private static extern int SakashoFCMPushNotificationAcceptPushNotificationWithTimeZoneAndLocale(int callbackId, string json) { }
}
