using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoFacebookWithBrowser : SakashoAPIBase
{
	//// RVA: 0x2BBBD6C Offset: 0x2BBBD6C VA: 0x2BBBD6C
	//public static void CallCreatePlayerFromFacebookAfterOAuth(string codeHash) { }

	//// RVA: 0x2BBBE9C Offset: 0x2BBBE9C VA: 0x2BBBE9C
	//public static void CallLinkWithFacebookAfterOAuth(string codeHash) { }

	//// RVA: 0x2BBBFCC Offset: 0x2BBBFCC VA: 0x2BBBFCC
	//public static void ClearCallback() { }

	//// RVA: 0x2BBC068 Offset: 0x2BBC068 VA: 0x2BBC068
	public static SakashoAPICallContext GetFacebookLinkageStatus(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoFacebookWithBrowserGetFacebookLinkageStatus, "", onSuccess, onError));
	}

	//// RVA: 0x2BBC14C Offset: 0x2BBC14C VA: 0x2BBC14C
	public static SakashoAPICallContext LinkWithFacebook(bool isOverwritable, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["isOverwritable"] = isOverwritable;
		return new SakashoAPICallContext(Call(SakashoFacebookWithBrowserLinkWithFacebook, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BBC2DC Offset: 0x2BBC2DC VA: 0x2BBC2DC
	public static SakashoAPICallContext UnlinkFacebook(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoFacebookWithBrowserUnlinkFacebook, "", onSuccess, onError));
	}

	//// RVA: 0x2BBC3C0 Offset: 0x2BBC3C0 VA: 0x2BBC3C0
	//public static SakashoAPICallContext GetAuthenticateUrl(bool isOverwritable, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBC550 Offset: 0x2BBC550 VA: 0x2BBC550
	//public static SakashoAPICallContext CallLinkWithFacebookAfterOauthWithCallback(string codeHash, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBC6C8 Offset: 0x2BBC6C8 VA: 0x2BBC6C8
	//public static SakashoAPICallContext CallCreatePlayerFromFacebookAfterOauthWithCallback(string codeHash, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBC840 Offset: 0x2BBC840 VA: 0x2BBC840
	//public static void CancelLinkWithFacebookBeforeOauth() { }

	//// RVA: 0x2BBC8E0 Offset: 0x2BBC8E0 VA: 0x2BBC8E0
	//private static extern int SakashoFacebookWithBrowserCallCreatePlayerFromFacebookAfterOAuth(int callbackId, string json) { }

	//// RVA: 0x2BBC9D8 Offset: 0x2BBC9D8 VA: 0x2BBC9D8
	//private static extern int SakashoFacebookWithBrowserCallLinkWithFacebookAfterOAuth(int callbackId, string json) { }

	//// RVA: 0x2BBCB00 Offset: 0x2BBCB00 VA: 0x2BBCB00
	//private static extern int SakashoFacebookWithBrowserClearCallback(int callbackId, string json) { }

	//// RVA: 0x2BBCC18 Offset: 0x2BBCC18 VA: 0x2BBCC18
	private static int SakashoFacebookWithBrowserGetFacebookLinkageStatus(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFacebookWithBrowserGetFacebookLinkageStatus(callbackId, json);
	}

	//// RVA: 0x2BBCD38 Offset: 0x2BBCD38 VA: 0x2BBCD38
	private static int SakashoFacebookWithBrowserLinkWithFacebook(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFacebookWithBrowserLinkWithFacebook(callbackId, json);
	}

	//// RVA: 0x2BBCE50 Offset: 0x2BBCE50 VA: 0x2BBCE50
	private static int SakashoFacebookWithBrowserUnlinkFacebook(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFacebookWithBrowserUnlinkFacebook(callbackId, json);
	}

	//// RVA: 0x2BBCF68 Offset: 0x2BBCF68 VA: 0x2BBCF68
	//private static extern int SakashoFacebookWithBrowserGetAuthenticateUrl(int callbackId, string json) { }

	//// RVA: 0x2BBD088 Offset: 0x2BBD088 VA: 0x2BBD088
	//private static extern int SakashoFacebookWithBrowserCallLinkWithFacebookAfterOauthWithCallback(int callbackId, string json) { }

	//// RVA: 0x2BBD180 Offset: 0x2BBD180 VA: 0x2BBD180
	//private static extern int SakashoFacebookWithBrowserCallCreatePlayerFromFacebookAfterOauthWithCallback(int callbackId, string json) { }

	//// RVA: 0x2BBD278 Offset: 0x2BBD278 VA: 0x2BBD278
	//private static extern int SakashoFacebookWithBrowserCancelLinkWithFacebookBeforeOauth(int callbackId, string json) { }
}
