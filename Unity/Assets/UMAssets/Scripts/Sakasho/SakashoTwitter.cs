using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoTwitter : SakashoAPIBase
{
	// RVA: 0x2E6BEC4 Offset: 0x2E6BEC4 VA: 0x2E6BEC4
	//public static void CallCreatePlayerFromTwitterAfterOAuth() { }

	//// RVA: 0x2E6BF60 Offset: 0x2E6BF60 VA: 0x2E6BF60
	//public static void CallLinkWithTwitterAfterOAuth() { }

	//// RVA: 0x2E6BFFC Offset: 0x2E6BFFC VA: 0x2E6BFFC
	public static SakashoAPICallContext GetTwitterLinkageStatus(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoTwitterGetTwitterLinkageStatus, "", onSuccess, onError));
	}

	//// RVA: 0x2E6C0E0 Offset: 0x2E6C0E0 VA: 0x2E6C0E0
	public static SakashoAPICallContext LinkWithTwitter(bool isOverwritable, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["isOverwritable"] = isOverwritable;
		return new SakashoAPICallContext(Call(SakashoTwitterLinkWithTwitter, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2E6C270 Offset: 0x2E6C270 VA: 0x2E6C270
	public static SakashoAPICallContext UnlinkTwitter(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoTwitterUnlinkTwitter, "", onSuccess, onError));
	}

	//// RVA: 0x2E6C354 Offset: 0x2E6C354 VA: 0x2E6C354
	//public static void ClearCallback() { }

	//// RVA: 0x2E6C3F0 Offset: 0x2E6C3F0 VA: 0x2E6C3F0
	//public static SakashoAPICallContext GetAuthenticateUrl(bool isOverwritable, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E6C580 Offset: 0x2E6C580 VA: 0x2E6C580
	//public static SakashoAPICallContext CallLinkWithTwitterAfterOauthWithCallback(OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E6C664 Offset: 0x2E6C664 VA: 0x2E6C664
	//public static SakashoAPICallContext CallCreatePlayerFromTwitterAfterOauthWithCallback(OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2E6C748 Offset: 0x2E6C748 VA: 0x2E6C748
	//public static void CancelLinkWithTwitterBeforeOauth() { }

	//// RVA: 0x2E6C7E8 Offset: 0x2E6C7E8 VA: 0x2E6C7E8
	//private static extern int SakashoTwitterCallCreatePlayerFromTwitterAfterOAuth(int callbackId, string json) { }

	//// RVA: 0x2E6C908 Offset: 0x2E6C908 VA: 0x2E6C908
	//private static extern int SakashoTwitterCallLinkWithTwitterAfterOAuth(int callbackId, string json) { }

	//// RVA: 0x2E6CA20 Offset: 0x2E6CA20 VA: 0x2E6CA20
	private static int SakashoTwitterGetTwitterLinkageStatus(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoTwitterGetTwitterLinkageStatus(callbackId, json);
	}

	//// RVA: 0x2E6CB38 Offset: 0x2E6CB38 VA: 0x2E6CB38
	private static int SakashoTwitterLinkWithTwitter(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoTwitterLinkWithTwitter(callbackId, json);
	}

	//// RVA: 0x2E6CC48 Offset: 0x2E6CC48 VA: 0x2E6CC48
	private static int SakashoTwitterUnlinkTwitter(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoTwitterUnlinkTwitter(callbackId, json);
	}

	//// RVA: 0x2E6CD50 Offset: 0x2E6CD50 VA: 0x2E6CD50
	//private static extern int SakashoTwitterClearCallback(int callbackId, string json) { }

	//// RVA: 0x2E6CE58 Offset: 0x2E6CE58 VA: 0x2E6CE58
	//private static extern int SakashoTwitterGetAuthenticateUrl(int callbackId, string json) { }

	//// RVA: 0x2E6CF68 Offset: 0x2E6CF68 VA: 0x2E6CF68
	//private static extern int SakashoTwitterCallLinkWithTwitterAfterOauthWithCallback(int callbackId, string json) { }

	//// RVA: 0x2E6D090 Offset: 0x2E6D090 VA: 0x2E6D090
	//private static extern int SakashoTwitterCallCreatePlayerFromTwitterAfterOauthWithCallback(int callbackId, string json) { }

	//// RVA: 0x2E6D1C0 Offset: 0x2E6D1C0 VA: 0x2E6D1C0
	//private static extern int SakashoTwitterCancelLinkWithTwitterBeforeOauth(int callbackId, string json) { }
}
